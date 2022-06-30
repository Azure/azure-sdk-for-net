namespace Azure.Template
{
    public partial class ConfidentialLedgerClient
    {
        protected ConfidentialLedgerClient() { }
        public ConfidentialLedgerClient(System.Uri ledgerUri, Azure.Core.TokenCredential credential) { }
        public ConfidentialLedgerClient(System.Uri ledgerUri, Azure.Core.TokenCredential credential, Azure.Template.ConfidentialLedgerClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCollections(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConsortiumMembers(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConsortiumMembersAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConstitution(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConstitutionAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCurrentLedgerEntry(string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCurrentLedgerEntryAsync(string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnclaveQuotes(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnclaveQuotesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetReceipt(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceiptAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTransactionStatus(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransactionStatusAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
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
