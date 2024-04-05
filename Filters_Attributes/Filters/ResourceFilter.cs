using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Filters_Attributes.ActionFilters
{
public class ResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Modify or replace the input parameters, headers, etc. before the action method is executed
            // For demonstration purposes, we'll modify the response headers
            context.HttpContext.Response.Headers.Add("Custom-Header", "Value-Modified-By-Resource-Filter");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Modify or replace the result of the action method after it has been executed
            // For demonstration purposes, we'll append a custom footer to the response body
            if (context.Result is ObjectResult objectResult)
            {
                objectResult.Value += "\nCustom Footer Added by Resource Filter";
            }
        }
    }

}
