using Balance.Application.Services;
using Balance.Core.Entities;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Balance.Api.Attributes
{
    public class RequestLoggerFilterAttribute : ActionFilterAttribute
    {
        private readonly IRequestLogService _requestLogService;

        public RequestLoggerFilterAttribute(IRequestLogService requestLogService)
        {
            _requestLogService = requestLogService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var host = context.HttpContext.Request.Host.ToString();

            var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var actionName = descriptor.ActionName;
            var controllerName = descriptor.ControllerName;
            var userAgent = context.HttpContext.Request.Headers["User-Agent"];

            _requestLogService.Log(new RequestLog()
            {
                Host = host,
                Route = $"{controllerName}/{actionName}",
                UserAgent= userAgent,
                DateTimeStamp= DateTime.UtcNow,
            }).Wait();

        }
    }
}
