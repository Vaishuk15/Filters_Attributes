namespace Filters_Attributes.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class CustomResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Logic to execute before the action result is executed
            if (context.Result is ObjectResult objectResult)
            {
                // Modify the result if it's an ObjectResult
                objectResult.Value = "Modified value: " + objectResult.Value.ToString();
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Logic to execute after the action result is executed
        }
    }

}
