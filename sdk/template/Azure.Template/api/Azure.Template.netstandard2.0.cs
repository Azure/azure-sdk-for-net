namespace Azure.Template
{
    public partial class ConfidentialLedgerClient
    {
        protected ConfidentialLedgerClient() { }
        public ConfidentialLedgerClient(System.Uri ledgerUri, Azure.Core.TokenCredential credential) { }
        public ConfidentialLedgerClient(System.Uri ledgerUri, Azure.Core.TokenCredential credential, Azure.Template.ConfidentialLedgerClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetCollections(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionsAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConfidentialLedgerClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerClientOptions(Azure.Template.ConfidentialLedgerClientOptions.ServiceVersion version = Azure.Template.ConfidentialLedgerClientOptions.ServiceVersion.V2022_05_13) { }
        public enum ServiceVersion
        {
            V2022_05_13 = 1,
        }
    }
}
