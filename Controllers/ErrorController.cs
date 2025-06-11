

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{

    public IActionResult Error()
    {
        return Problem(title: "Unexpected error occurred.", statusCode: 500);
    }
}
