using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

namespace DoctivityHybrid.Web.Services
{
    public class WebAuthStateProvider : RevalidatingServerAuthenticationStateProvider
    {
        public WebAuthStateProvider(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override TimeSpan RevalidationInterval => TimeSpan.FromDays(7);

        protected override Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            // Implement custom validation logic here if needed
            return Task.FromResult(true);
        }
    }
}
