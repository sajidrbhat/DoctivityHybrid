using DoctivityHybrid.Shared.Dtos;
using DoctivityHybrid.Shared.Services;
using Microsoft.AspNetCore.Authentication;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace DoctivityHybrid.Web.Services
{
    public class AuthService : IAuthService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult> PlatformLoginAsync(LoggedInUser user)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                return MethodResult.Failure("No HTTP context available.");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            var identity = new ClaimsIdentity(claims, WebConstants.WebAuthScheme);
            var principal = new ClaimsPrincipal(identity);

            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
            };

            await httpContext.SignInAsync(WebConstants.WebAuthScheme, principal, authenticationProperties);

            return MethodResult.Success();
        }

        public async Task<MethodResult<LoggedInUser>> LoginAsync(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                var loggedInUser = new LoggedInUser(1, "admin");
                return MethodResult<LoggedInUser>.Success(loggedInUser);
            }
            else
            {
                return MethodResult<LoggedInUser>.Failure("Invalid username or password.");
            }
        }
    }
}
