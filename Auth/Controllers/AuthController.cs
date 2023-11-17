using Microsoft.AspNetCore.Mvc;
using TodoStudent.Server.Services;
using TodoStudent.Shared.Models;
using TodoStudent.Shared.ViewModels;

namespace TodoStudent.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private AuthService AuthService;

    public AuthController(AuthService authService)
    {
        AuthService = authService;
    }

    /// <summary>
    /// Auth User by auth data.
    /// </summary>
    /// <param name="model">Auth data.</param>
    /// <returns>Auth helper model.</returns>
    [HttpPost("user")]
    public async Task<ActionResult<ServiceResponse<AuthHelperModel<UserViewModel>>>> AuthUser(UserAuthModel model)
    {
        return await AuthService.Authenticate(model);
    }
}