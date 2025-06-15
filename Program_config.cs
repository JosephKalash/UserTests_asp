using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Npgsql.Replication;

namespace UserTests.Program_configurations
{

    public static class ProgramConfiguration
    {
        public static void UseSwaggerConfiguredUI(this WebApplication app)
        {

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
                // Enable this to persist authorization data
                c.EnablePersistAuthorization();
            });
        }
        public static IServiceCollection AddAuthorizationConfiguration(this IServiceCollection services)
        {

            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy(AdminPolicy.PolicyName, policy => policy.RequireClaim("Role", AdminPolicy.ClaimValue));
                    options.AddPolicy(UserPolicy.PolicyName, policy => policy.RequireClaim("Role", UserPolicy.ClaimValue, AdminPolicy.ClaimValue));
                }
            );
            return services;
        }
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                }
            );
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IUserTestRepository, UserTestRepository>();
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SupportNonNullableReferenceTypes();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,  // Changed from ApiKey to Http
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
                });
                c.MapType<QuestionType>(() => new OpenApiSchema
                {
                    Type = "string",
                    Enum = [.. Enum.GetNames(typeof(QuestionType))
                    .Select(name => new OpenApiString(name))
                    .Cast<IOpenApiAny>()]
                });
            });
            return services;

        }
    }
}