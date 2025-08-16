using Microsoft.AspNetCore.Mvc;

namespace Wikipedia.Settings
{
    public class WikipediaApiSettings
    {
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
        public string AccessToken { get; init; }
    }
}