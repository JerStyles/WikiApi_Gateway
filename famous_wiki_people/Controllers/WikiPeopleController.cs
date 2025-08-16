using Microsoft.AspNetCore.Mvc;

namespace WikiPeople.Controller
{
    [Route("api")]
    [ApiController]
    public class WikiPeopleController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "wiki", "people", "data" };
        }
    }
}