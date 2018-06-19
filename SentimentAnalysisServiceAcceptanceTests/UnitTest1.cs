using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SentimentAnalysisService;
using SentimentAnalysisService.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace SentimentAnalysisServiceAcceptanceTests
{
    public partial class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var client = new CustomWebApplicationFactory().CreateClient();

            HttpContent httpContent = new StringContent("{'text':'I am happy.'}");
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("/api/analysis", httpContent);

            var content = await response.Content.ReadAsStringAsync();

            var sentiment = JsonConvert.DeserializeObject<Sentiment>(content);

            Assert.Equal(Tone.Joy, sentiment.Tone);
        }
    }

    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var webHostBuilder = new WebHostBuilder();
            webHostBuilder.UseStartup<Startup>();

            return webHostBuilder;
        }
    }
}
