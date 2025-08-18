using Wikipedia.DTOs;
using System.Runtime.CompilerServices;

namespace Wikipedia.Services
{
    public interface IWikipediaService
    {
        public Task<string> GetListOfPageApiEndpointsAsync();

        public IAsyncEnumerable<SearchResultDto> SearchArticlesAsync(string searchTerm, [EnumeratorCancellation] CancellationToken cancellationToken = default);

        public IAsyncEnumerable<SearchResultWithImageDto> SearchArticlesWithImagesAsync(string searchTerm, [EnumeratorCancellation] CancellationToken cancellationToken = default);
    }
}