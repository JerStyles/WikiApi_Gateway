
using Microsoft.Extensions.Options;
using WikiPeople.Settings;

namespace WikiPeople.Services
{
    public class WikipediaService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _accessToken;

        public WikipediaService(IOptions<WikipediaApiSettings> wikipediaSettings)
        {
            _clientId = wikipediaSettings.Value.ClientId;
            _clientSecret = wikipediaSettings.Value.ClientSecret;
            _accessToken = wikipediaSettings.Value.AccessToken;
        }

        public void QueryData()
        {
            Console.WriteLine($"Using clientId: {_clientId}");
        }
    }

}