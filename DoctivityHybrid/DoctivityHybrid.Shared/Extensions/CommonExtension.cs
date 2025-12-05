using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace DoctivityHybrid.Shared.Extensions
{
    public static class CommonExtension
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var UserIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return UserIdClaim != null ? int.Parse(UserIdClaim.Value) : 0;
        }
    }
}
