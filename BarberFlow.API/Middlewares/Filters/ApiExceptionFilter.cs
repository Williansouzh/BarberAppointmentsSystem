using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberFlow.API.Middlewares.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ApiExceptionFilter> _logger;

    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An unhandled exception occurred while processing the request.");
        context.Result = new ObjectResult(new
        {
            Message = "An error occurred while processing your request.",
            Details = context.Exception.Message
        })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
