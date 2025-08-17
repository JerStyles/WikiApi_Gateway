using Microsoft.AspNetCore.Mvc;
using Wikipedia.DTOs;
using Wikipedia.Services;

namespace Wikipedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WikipediaController : ControllerBase
    {
        private readonly IWikipediaService _wikipediaService;
        private readonly ILogger<WikipediaController> _logger;


        public WikipediaController(IWikipediaService wikipediaService, ILogger<WikipediaController> logger)
        {
            _wikipediaService = wikipediaService;
            _logger = logger;
        }


        [HttpGet("page-api-endpoints")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListOfPageApiEntrypointsAsync()
        {

            var result = await _wikipediaService.GetListOfPageApiEndpointsAsync();
            return Ok(result);

        }


        [HttpGet("search")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchWiki([FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest(new ApiErrorDto("searchTerm is required and cannot be empty."));
            }

            var result = await _wikipediaService.SearchArticlesAsync(searchTerm);
            return Ok(result);
        }

        [HttpGet("search-with-images")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchWikiWithImages([FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest(new ApiErrorDto("search term is required and cannot be empty."));
            }

            var result = await _wikipediaService.SearchArticlesWithImagesAsync(searchTerm);
            return Ok(result);
        }

    }
}