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
            var analyseTone = new AnalyseTone();
            var sentiment = await analyseTone.Analyse("Hello there!");
            Assert.True(sentiment != null);

        }
    }
}
