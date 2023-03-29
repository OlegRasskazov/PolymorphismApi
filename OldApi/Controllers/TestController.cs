using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OldApi.Models;

namespace OldApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("first")]
        public FirstSubClass First() => new FirstSubClass() { FirstDetails = "Details", Id = Guid.NewGuid(), Name = "First" };

        [HttpGet("second")]
        public SecondSubClass Second() => new SecondSubClass() { Id = Guid.NewGuid(), Name = "First", Count = 12 };

        [HttpPost]
        public ActionResult Test([FromBody] BaseClass baseClass)
        {
            Console.WriteLine(baseClass.GetType().Name);
            if (baseClass is FirstSubClass)
                Console.WriteLine(JsonConvert.SerializeObject((FirstSubClass)baseClass));
            else if (baseClass is SecondSubClass)
                Console.WriteLine(JsonConvert.SerializeObject((SecondSubClass)baseClass));

            return Ok();
        }
    }
}