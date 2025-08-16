using Microsoft.AspNetCore.Mvc;

namespace WikiPeople.Settings
{
    public class WikipediaApiSettings
    {
        // READ-ONLY, set when initialized.
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
        public string AccessToken { get; init;  }
    }
}