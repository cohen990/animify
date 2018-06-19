using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisService.Actions;
using SentimentAnalysisService.Domain;

namespace SentimentAnalysisService.Api
{
    [Route("api/[controller]")]
    public class AnalysisController : Controller
    {
        public AnalyseTone AnalyseTone { get; }

        public AnalysisController(AnalyseTone analyseTone = null)
        {
            AnalyseTone = analyseTone ?? new AnalyseTone();
        }

        // POST api/analysis
        [HttpPost]
        public Task<Sentiment> Get([FromBody] SentimentRequest sentimentRequest)
        {
            return AnalyseTone.Analyse(sentimentRequest.Text);
        }
    }
}
