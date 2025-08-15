using Microsoft.AspNetCore.Mvc;

namespace WikiPeople.Controllers
{
    [Route("api")]
    [ApiController]
    public class WikiPeopleController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "wiki", "data", "people" };
        }
    }
}