using System.Collections.Generic;

namespace SentimentAnalysisService.Controllers
{
    public interface ISentimentAnalyser
    {
        Sentiment Analyse(string text);
    }
}