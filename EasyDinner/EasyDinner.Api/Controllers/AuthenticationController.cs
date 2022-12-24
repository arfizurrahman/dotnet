using EasyDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace EasyDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [Route("register")]
    public IActionResult Register(RegisterRequest request){
        return Ok(request);
    }

    [Route("login")]
    public IActionResult Login(LoginRequest request){
        return Ok(request);
    }
}