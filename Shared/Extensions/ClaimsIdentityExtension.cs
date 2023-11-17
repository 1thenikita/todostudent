using System.Security.Claims;

namespace TodoStudent.Shared.Extensions;

public static class ClaimsIdentityExtension
{
    public static Guid GetId(this ClaimsPrincipal user)
    {
        return Guid.Parse(user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString());
    }
}