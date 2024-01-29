using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Shared.Core.Enums;

namespace SeuHotel.Infrastructure.Middleware;

public class OperationsPermissionMiddleware
{
    private readonly RequestDelegate _next;

    public OperationsPermissionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Items.Add("isAnonymous", false);
        
        var endpointFeature = context.Features.Get<IEndpointFeature>();
        
        if (endpointFeature is not null)
        {
            var endpoint = endpointFeature.Endpoint;
            if (endpoint is not null)
            {
                var anonymous = endpoint.Metadata.GetMetadata<IAllowAnonymous>();
                if (anonymous is not null)
                {
                    context.Items["isAnonymous"] = true;
                    await _next(context);
                    return;
                }
            }
        }

        var method = context.Request.Method;

        var role = context.User.Claims.Where(x => x.Type == ClaimTypes.Role)
            .Select(x => x.Value)
            .FirstOrDefault();

        bool forbidden = true;

        bool isCustomer = role == UserTypeEnum.Customer.ToString() &&
                       (method.ToUpper() == HttpMethods.Get.ToUpper() ||
                        method.ToUpper() == HttpMethods.Post.ToUpper() ||
                        method.ToUpper() == HttpMethods.Put.ToUpper() ||
                        method.ToUpper() == HttpMethods.Delete.ToUpper());
        bool isOwner = role == UserTypeEnum.Owner.ToString();
        bool isAdmin = role == UserTypeEnum.Admin.ToString();

        context.Items.Add("isAdmin", isAdmin);

        if (isAdmin || isOwner || isCustomer)
            forbidden = false;

        if (forbidden)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        };

        await _next(context);
    }
}