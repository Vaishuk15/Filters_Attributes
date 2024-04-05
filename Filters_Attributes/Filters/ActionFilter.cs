using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters_Attributes.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        private readonly ILogger<CustomActionFilter> _logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Logic to execute before the action method
            _logger.LogInformation("Executing action {ActionName}", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logic to execute after the action method
            _logger.LogInformation("Finished executing action {ActionName}", context.ActionDescriptor.DisplayName);
        }
    }

}
