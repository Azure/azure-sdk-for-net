namespace Azure.AI.ContentUnderstanding
{
    public partial class ContentUnderstandingClient
    {
        protected ContentUnderstandingClient() { }
        public ContentUnderstandingClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.ContentUnderstanding.ContentUnderstandingClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ContentUnderstandingClientOptions : Azure.Core.ClientOptions
    {
        public ContentUnderstandingClientOptions(Azure.AI.ContentUnderstanding.Generated.ContentUnderstandingClientOptions.ServiceVersion version = Azure.AI.ContentUnderstanding.Generated.ContentUnderstandingClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}