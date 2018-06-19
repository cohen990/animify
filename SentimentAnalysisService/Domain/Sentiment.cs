namespace SentimentAnalysisService.Domain
{
    public class Sentiment
    {
        public Tone Tone { get; }

        public Sentiment(Tone tone)
        {
            Tone = tone;
        }
    }
}
