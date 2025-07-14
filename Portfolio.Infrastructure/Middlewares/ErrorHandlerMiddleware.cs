using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static Portfolio.Core.Constants;

namespace Portfolio.Infrastructure.Middlewares;

public class ErrorHandlerMiddleware(
    RequestDelegate next, 
    ILogger<ErrorHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ErrorConstants.UNHANDLED_EXCEPTION);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(new
            {
                StatusCode = 500,
                Message = "An unexpected error occurred."
            }.ToString()!);
        }
    }
}
