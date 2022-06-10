namespace Azure.Monitor.Ingestion
{
    public partial class IngestionUsingDataCollectionRulesClient
    {
        protected IngestionUsingDataCollectionRulesClient() { }
        public IngestionUsingDataCollectionRulesClient(string endpoint, Azure.AzureKeyCredential credential) { }
        public IngestionUsingDataCollectionRulesClient(string endpoint, Azure.AzureKeyCredential credential, Azure.Monitor.Ingestion.IngestionUsingDataCollectionRulesClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Upload(string ruleId, string stream, Azure.Core.RequestContent content, string contentEncoding = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(string ruleId, string stream, Azure.Core.RequestContent content, string contentEncoding = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class IngestionUsingDataCollectionRulesClientOptions : Azure.Core.ClientOptions
    {
        public IngestionUsingDataCollectionRulesClientOptions(Azure.Monitor.Ingestion.IngestionUsingDataCollectionRulesClientOptions.ServiceVersion version = Azure.Monitor.Ingestion.IngestionUsingDataCollectionRulesClientOptions.ServiceVersion.V2021_11_01_preview) { }
        public enum ServiceVersion
        {
            V2021_11_01_preview = 1,
        }
    }
}
