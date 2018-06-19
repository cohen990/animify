using System.Collections.Generic;

namespace SentimentAnalysisService.Infrastructure.Watson
{
    /*{
     *  "document_tone":{
     *      "tones":[
     *          {
     *              "score":0.92324,"tone_id":"joy","tone_name":"Joy"
     *          }
     *      ]
     *  }
     *}
     */
    public class ToneAnalysis
    {
        public DocumentTone documentTone;
    }

    public class DocumentTone
    {
        public List<ToneObject> Tones;
    }

    public class ToneObject
    {
        public float Score;
        public string ToneId;
        public string ToneName;
    }
}