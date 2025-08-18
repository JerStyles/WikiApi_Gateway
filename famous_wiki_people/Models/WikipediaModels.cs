using System.Text.Json.Serialization;

namespace Wikipedia.Models
{
    // 1. Map model with Api query result
    // {
    //    "batchcomplete":"",
    //    "continue":{
    //       "sroffset":10,
    //       "continue":"-||"
    //    },
    //    "query":{                   <- !!!!START FROM HERE!!!!
    //       "searchinfo":{
    //          "totalhits":7417
    //       },
    //       "search":[
    //          {
    //             "ns":0,
    //             "title":"Albert Einstein",
    //             "pageid":736,
    //             "size":231737,
    //             "wordcount":22859,
    //             "snippet":"<span class=\"searchmatch\">Albert</span> <span class=\"searchmatch\">Einstein</span> (14 March 1879\u00a0\u2013 18 April 1955) was a German-born theoretical physicist who is best known for developing the theory of relativity. Einstein",
    //             "timestamp":"2025-08-17T03:04:46Z"
    //          },{...}]}

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

    // 2. Map model with Api query result with images
    //      {
    //    "batchcomplete":"",
    //    "query":{        <---- !!!!START FROM HERE!!!!!
    //       "normalized":[
    //          {
    //             "from":"Albert_Einstein",
    //             "to":"Albert Einstein"
    //          }
    //       ],
    //       "pages":{
    //          "736":{
    //             "pageid":736,
    //             "ns":0,
    //             "title":"Albert Einstein",
    //             "thumbnail":{
    //                "source":"https://upload.wikimedia.org/wikipedia/commons/thumb/1/14/Albert_Einstein_1947.jpg/60px-Albert_Einstein_1947.jpg",
    //                "width":50,
    //                "height":61
    //             },
    //             "pageimage":"Albert_Einstein_1947.jpg"
    //          }
    //       }
    //    }
    // }

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