namespace Azure.AI.ContentSafety
{
    public partial class ContentSafetyClient
    {
        protected ContentSafetyClient() { }
        public ContentSafetyClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ContentSafetyClientOptions : Azure.Core.ClientOptions
    {
        public ContentSafetyClientOptions(Azure.AI.ContentSafety.Generated.ContentSafetyClientOptions.ServiceVersion version = Azure.AI.ContentSafety.Generated.ContentSafetyClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}