using Filters_Attributes.ActionFilters;
using Filters_Attributes.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Filters_Attributes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AuthorizationFilter]
    [ServiceFilter(typeof(ExceptionHandlingFilter))]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        // Apply the custom authorization filter
        public IActionResult Get()
        {
            // Your action method logic


            return Ok(new string[] { "value1", "value2" });
        }

        [HttpPost("ResourceFilter")]
        [ResourceFilter] // Apply the custom resource filter
        public IActionResult GetRes()
        {
            // Your action method logic
            return Ok("Response modified by Resource Filter");
        }

        [HttpGet("ActionFilter")]
        [ServiceFilter(typeof(CustomActionFilter))] // Apply the custom action filter
        public IActionResult GetResponse()
        {
            _logger.LogInformation("Inside Get action method");
            // Your action method logic
            return Ok("Response from Get action method");
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Example logic to handle a specific exception
            if (id == 0)
            {
                throw new Exception("ID cannot be zero");
            }

            // Your action method logic
            return Ok("Value retrieved successfully");
        }
        [HttpGet("ResultFilter")]
        [ServiceFilter(typeof(CustomResultFilter))] // Apply the custom result filter
        public IActionResult GetResult()
        {
            // Your action method logic
            return Ok("Original value");
        }
    }
}
