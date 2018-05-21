using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SentimentAnalysisService.Controllers
{
    [Route("api/[controller]")]
    public class AnalysisController : Controller
    {

        public AnalysisController(ISentimentAnalyser sentimentAnalyser = null){
            SentimentAnalyser = sentimentAnalyser;
        }

        public ISentimentAnalyser SentimentAnalyser { get; }

        // GET api/analysis
        [HttpGet]
        public Sentiment Get(string text)
        {
            return SentimentAnalyser.Analyse(text);
        }
    }
}
