using System.Net;

namespace Wikipedia.Exceptions
{
    public class WikipediaApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public WikipediaApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}