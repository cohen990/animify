using System;
using System.Threading.Tasks;
using SentimentAnalysisService.Controllers;
using Xunit;

namespace SentimentAnalysisServiceTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1Async()
        {
            var ibmAnalyzer = new WatsonToneAnalyzer();
            var sentiment = await ibmAnalyzer.Analyse("Hello there!");
            Assert.True(sentiment != null);

        }
    }
}
