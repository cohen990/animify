using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EasyConfig;
using SentimentAnalysisService.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SentimentAnalysisService.Infrastructure.Watson;
using SentimentAnalysisService.Domain;
using System.Linq;

namespace SentimentAnalysisService.Actions
{
    public class AnalyseTone
    {
        public async Task<Sentiment> Analyse(string text)
        {
            var config = new Config(new ConsoleWriter());
            config.WithJson("watson-config.json");
            var configurationValues = config.PopulateClass<WatsonConfig>();

            HttpClient client = new HttpClient();

            var byteArray = Encoding.ASCII.GetBytes($"{configurationValues.Username}:{configurationValues.Password}");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var content = new StringContent("{\"text\": \"" + text + "\"}");
            var response = await client.PostAsync("https://gateway.watsonplatform.net/tone-analyzer/api/v3/tone?version=2017-09-21", content);

            var responseAsString = await response.Content.ReadAsStringAsync();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var toneAnalysis = JsonConvert.DeserializeObject<ToneAnalysis>(responseAsString, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });

            var tone = Tone.Neutral;

            if(toneAnalysis.documentTone.Tones.Single().ToneId == "joy")
            {
                tone = Tone.Joy;
            }

            return new Sentiment(tone);
        }
    }
}