using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EasyConfig;

namespace SentimentAnalysisService.Controllers
{
    public class WatsonToneAnalyzer:ISentimentAnalyzer
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
            HttpResponseMessage response = await client.PostAsync("https://gateway.watsonplatform.net/tone-analyzer/api/v3/tone?version=2017-09-21",
                                                                 content);
            HttpContent responseContent = response.Content;
            var sentiment = new Sentiment();
            sentiment.Analysis = await responseContent.ReadAsStringAsync();

            return sentiment;
        }
    }
}