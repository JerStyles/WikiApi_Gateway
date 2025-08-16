using Microsoft.Extensions.Options;
using Wikipedia.Settings;

namespace Wikipedia.Services
{
    public class WikipediaService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _accessToken;

        public WikipediaService(IOptions<WikipediaApiSettings> wikipediaApiSettings)
        {
            _clientId = wikipediaApiSettings.Value.ClientId;
            _clientSecret = wikipediaApiSettings.Value.ClientSecret;
            _accessToken = wikipediaApiSettings.Value.AccessToken;
        }

        public void QueryData()
        {
            Console.WriteLine($"ClientId: {_clientId}");
            Console.WriteLine($"ClientSecret: {_clientSecret}");
        }

    }
}