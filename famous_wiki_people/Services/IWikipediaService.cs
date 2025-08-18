using Wikipedia.DTOs;

namespace Wikipedia.Services
{
    public interface IWikipediaService
    {
        public Task<string> GetListOfPageApiEndpointsAsync();

        public IAsyncEnumerable<SearchResultDto>  SearchArticlesAsync(string searchTerm);

        public Task<IEnumerable<SearchResultWithImageDto>> SearchArticlesWithImagesAsync(string searchTerm);
    }
}