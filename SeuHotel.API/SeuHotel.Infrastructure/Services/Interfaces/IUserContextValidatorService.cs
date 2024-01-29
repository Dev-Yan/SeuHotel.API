using Microsoft.AspNetCore.Http;

namespace SeuHotel.Infrastructure.Services.Interfaces;

public interface IUserContextValidatorService
{
    long GetCurrentUserId(HttpContext httpContext);
    bool IsOwner(HttpContext httpContext);
    bool IsAdmin(HttpContext httpContext);
    bool IsAnonymous(HttpContext httpContext);
}