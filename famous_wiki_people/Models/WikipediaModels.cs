using System.Text.Json.Serialization;

namespace Wikipedia.Models
{
    /// <summary>
    /// Represents the response from Wikipedia's search API.
    /// </summary>
    public class WikipediaApiQueryResponse
    {
        [JsonPropertyName("query")]
        public QueryObject Query { get; set; }
    }

    public class QueryObject
    {
        [JsonPropertyName("search")]
        public List<RawSearchResult> Search { get; set; }
    }

    public class RawSearchResult
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("pageid")]
        public long PageId { get; set; }

        [JsonPropertyName("snippet")]
        public string Snippet { get; set; }
    }


    public class WikipediaImageApiResponse
    {
        [JsonPropertyName("query")]
        public ImageQueryObject Query { get; set; }
    }

    public class ImageQueryObject
    {
        [JsonPropertyName("pages")]
        public Dictionary<string, PageData> Pages { get; set; }
    }

    public class PageData
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("pageid")]
        public long PageId { get; set; }

        [JsonPropertyName("thumbnail")]
        public Thumbnail? Thumbnail { get; set; }
    }

    public class Thumbnail
    {
        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
}