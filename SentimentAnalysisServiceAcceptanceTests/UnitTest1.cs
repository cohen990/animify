using SentimentAnalysisService.Domain;
using Xunit;

namespace SentimentAnalysisServiceAcceptanceTests
{
    public partial class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Sentiment response = null;
            Assert.Equal(Tone.Neutral, response.Tone);
        }
    }
}
