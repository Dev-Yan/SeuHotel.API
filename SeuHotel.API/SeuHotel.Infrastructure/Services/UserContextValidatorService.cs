using Microsoft.AspNetCore.Http;
using SeuHotel.Infrastructure.Services.Interfaces;

namespace SeuHotel.Infrastructure.Services
{

    public class UserContextValidatorService : IUserContextValidatorService
    {
        public long GetCurrentUserId(HttpContext httpContext)
        {
            var userIdClaim = httpContext.User.Claims.FirstOrDefault(x => x.Type == "id");
            return userIdClaim != null ? Convert.ToInt64(userIdClaim.Value) : throw new InvalidOperationException("User ID claim not found.");
        }

        public bool IsOwner(HttpContext httpContext)
        {
            return (bool)(httpContext.Items["isOwner"] ?? false);
        }

        public bool IsAdmin(HttpContext httpContext)
        {
            return (bool)(httpContext.Items["isAdmin"] ?? false);
        }

        public bool IsAnonymous(HttpContext httpContext)
        {
            return (bool)(httpContext.Items["isAnonymous"] ?? false);
        }
    }
}
