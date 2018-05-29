using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SentimentAnalysisService.Controllers
{
    [Route("api/[controller]")]
    public class AnalysisController : Controller
    {

        public AnalysisController(ISentimentAnalyzer sentimentAnalyser = null){
            SentimentAnalyser = sentimentAnalyser;
        }

        public ISentimentAnalyzer SentimentAnalyser { get; }

        // GET api/analysis
        [HttpGet]
        public Task<Sentiment> Get(string text)
        {
            return SentimentAnalyser.Analyse(text);
        }
    }
}
