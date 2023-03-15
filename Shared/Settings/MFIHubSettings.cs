using Microsoft.Extensions.Configuration;

namespace MFIHub.Shared.Settings
{
    public class MFIHubSettings : IMFIHubSettings
    {
        private readonly IConfiguration _configuration;

        public MFIHubSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Url
        {
            get
            {
                return _configuration["Settings:Url"];
            }
        }
    }
}
