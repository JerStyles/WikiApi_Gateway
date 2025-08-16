using Microsoft.AspNetCore.Mvc;
using WikiPeople.Services;

namespace WikiPeople.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WikiPeopleController : ControllerBase
    {
        // test if controller works
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "wiki", "people", "data" };
        }

        // test if WikipediaService works

        private readonly WikipediaService _wikipediaService;

        public WikiPeopleController(WikipediaService wikipediaService)
        {
            _wikipediaService = wikipediaService;
        }

        [HttpGet("query")]
        public IActionResult TriggerQueryData()
        {
            try
            {
                _wikipediaService.QueryData();

                return Ok("Successfully query data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occorred {ex.Message}");
            }
        }
    }
}