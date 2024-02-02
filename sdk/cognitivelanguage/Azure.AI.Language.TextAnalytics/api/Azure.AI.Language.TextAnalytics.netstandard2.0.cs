namespace Azure.AI.Language.TextAnalytics
{
    public partial class TextAnalyticsClient
    {
        protected TextAnalyticsClient() { }
        public TextAnalyticsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.TextAnalytics.TextAnalyticsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class TextAnalyticsClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalyticsClientOptions(Azure.AI.Language.TextAnalytics.Generated.TextAnalyticsClientOptions.ServiceVersion version = Azure.AI.Language.TextAnalytics.Generated.TextAnalyticsClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}