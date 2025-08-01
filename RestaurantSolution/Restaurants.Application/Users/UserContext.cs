using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.User;

public interface IUserContext
{
    CurrentUser GetCurrentUser();
}
public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{

    public CurrentUser GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("User is not authenticated.");
        }

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userid = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var role = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

        return new CurrentUser(userid, email, role);
    }

}
