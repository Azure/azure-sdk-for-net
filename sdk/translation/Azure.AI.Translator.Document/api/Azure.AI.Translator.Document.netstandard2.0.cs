namespace Azure.AI.Translator.Document
{
    public partial class DocumentClient
    {
        protected DocumentClient() { }
        public DocumentClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Translator.Document.DocumentClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class DocumentClientOptions : Azure.Core.ClientOptions
    {
        public DocumentClientOptions(Azure.AI.Translator.Document.Generated.DocumentClientOptions.ServiceVersion version = Azure.AI.Translator.Document.Generated.DocumentClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}