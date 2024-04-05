using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Filters_Attributes.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionHandlingFilter> _logger;

        public ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the exception
            _logger.LogError(context.Exception, "An unhandled exception occurred.");

            // Set the result to be returned to the client
            context.Result = new ObjectResult("An error occurred. Please try again later.")
            {
                StatusCode = 500 // Internal Server Error
            };

            // Ensure the exception is marked as handled
            context.ExceptionHandled = true;
        }
    }
}
