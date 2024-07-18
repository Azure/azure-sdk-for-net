namespace Azure.AI.Language.Text
{
    public partial class TextClient
    {
        protected TextClient() { }
        public TextClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Text.TextClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class TextClientOptions : Azure.Core.ClientOptions
    {
        public TextClientOptions(Azure.AI.Language.Text.Generated.TextClientOptions.ServiceVersion version = Azure.AI.Language.Text.Generated.TextClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}