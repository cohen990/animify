using EasyConfig.Attributes;

namespace SentimentAnalysisService.Controllers
{
    internal class WatsonConfig
    {
        [JsonConfig("watson-tone-analyzer-username"), Required]
        public string Username { get; set; }

        [JsonConfig("watson-tone-analyzer-password"), Required, SensitiveInformation]
        public string Password { get; set; }
    }
}