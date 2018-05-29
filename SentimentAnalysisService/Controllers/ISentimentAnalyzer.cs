using System.Threading.Tasks;

namespace SentimentAnalysisService.Controllers
{
    public interface ISentimentAnalyzer
    {
        Task<Sentiment> Analyse(string text);
    }
}