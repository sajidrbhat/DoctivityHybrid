using DoctivityHybrid.Shared.Dtos;
using System.Runtime.CompilerServices;

namespace DoctivityHybrid.Shared.Services
{
    public interface IAuthService
    {
        Task<MethodResult<LoggedInUser>> LoginAsync(string username, string password);

        Task<MethodResult> PlatformLoginAsync(LoggedInUser user);

        Task<MethodResult> PlatformLogoutAsync();
    }
}
