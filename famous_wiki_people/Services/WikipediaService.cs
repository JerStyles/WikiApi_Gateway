using Microsoft.Extensions.Options;
using Wikipedia.DTOs;
using Wikipedia.Settings;
using Wikipedia.Models;

using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;
using Wikipedia.Exceptions;

namespace Wikipedia.Services
{
    public class WikipediaService : IWikipediaService
    {
        private readonly HttpClient _httpClient;
        private readonly WikipediaApiSettings _apiSettings;

        public WikipediaService(HttpClient httpClient, IOptions<WikipediaApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
            _httpClient.BaseAddress = new Uri(_apiSettings.BaseUrl);
        }

        public async Task<string> GetListOfPageApiEndpointsAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_apiSettings.RestApiPageEndpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new WikipediaApiException(
                    ex.StatusCode ?? HttpStatusCode.InternalServerError,
                    $"Failed to query info from Wikipedia API: {ex.Message}"
                );
            }


        }

        public async Task<IEnumerable<SearchResultDto>> SearchArticlesAsync(string searchTerm)
        {
            var searchResults = await FetchSearchResults(searchTerm);
            return searchResults.Select(r => new SearchResultDto(r.PageId, r.Title, r.Snippet));

        }

        public async Task<IEnumerable<SearchResultWithImageDto>> SearchArticlesWithImagesAsync(string searchTerm)
        {
            var searchResults = await FetchSearchResults(searchTerm);

            if (!searchResults.Any())
            {
                return Enumerable.Empty<SearchResultWithImageDto>();
            }

            var pageIds = searchResults.Select(r => r.PageId).ToList();
            var imageUrls = await FetchImageUrls(pageIds);

            return searchResults.Select(r => new SearchResultWithImageDto(
                r.PageId,
                r.Title,
                r.Snippet,
                imageUrls.TryGetValue(r.PageId, out var url) ? url : null
            ));
        }


        private async Task<List<RawSearchResult>> FetchSearchResults(string searchTerm)
        {
            var query = new Dictionary<string, string>
            {
                {"action", "query"},
                {"list", "search"},
                {"srsearch", searchTerm},
                {"format", "json"}
            };

            var resultUri = $"{_apiSettings.ActionApiEndpoint}?{await new FormUrlEncodedContent(query).ReadAsStringAsync()}";

            var response = await _httpClient.GetFromJsonAsync<WikipediaApiQueryResponse>(resultUri);

            return response?.Query?.Search ?? new List<RawSearchResult>();
        }

        private async Task<Dictionary<long, string>> FetchImageUrls(IEnumerable<long> pageIds)
        {
            var pageIdString = string.Join("|", pageIds);
            var query = new Dictionary<string, string>
            {
                {"action", "query"},
                {"pageids", pageIdString},
                {"prop", "pageimages"},
                {"pithumbsize", "200"},
                { "format", "json"}
            };

            var resultUri = $"{_apiSettings.ActionApiEndpoint}?{await new FormUrlEncodedContent(query).ReadAsStringAsync()}";

            var response = await _httpClient.GetFromJsonAsync<WikipediaImageApiResponse>(resultUri);

            var imageUrls = new Dictionary<long, string>();
            if (response?.Query?.Pages != null)
            {
                foreach (var page in response.Query.Pages.Values)
                {
                    if (page.Thumbnail?.Source != null)
                    {
                        imageUrls[page.PageId] = page.Thumbnail.Source;
                    }
                }
            }

            return imageUrls;
        }
    }
}

