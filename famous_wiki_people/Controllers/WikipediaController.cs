using Microsoft.AspNetCore.Mvc;
using Wikipedia.Services;

namespace Wikipedia.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WikipediaController : ControllerBase
    {
        private readonly WikipediaService _wikipediaService;

        public WikipediaController(WikipediaService wikipediaService)
        {
            _wikipediaService = wikipediaService;
        }

        [HttpGet("testEndpoint")]
        public IActionResult TriggerQueryData()
        {
            try
            {
                _wikipediaService.QueryData();
                return Ok("Successfully query data");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed with error message: {ex.Message}");
            }
        }
    }
}