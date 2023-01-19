using Microsoft.AspNetCore.Mvc;
using TestLib;

namespace MVCApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private ITestLib testClass { get; }

        public TestController(ITestLib _testLib)
        {
            testClass = _testLib;
        }

        [HttpGet(Name = "GetTestResult")]
        public string Get()
        {
            return testClass.PrintMsg("hello!");
        }
    }
}
