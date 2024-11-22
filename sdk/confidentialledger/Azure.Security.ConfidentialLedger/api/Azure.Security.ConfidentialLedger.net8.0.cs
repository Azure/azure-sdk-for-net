namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        protected ConfidentialLedgerClient() { }
        public ConfidentialLedgerClient(System.Uri ledgerEndpoint, Azure.Core.TokenCredential credential) { }
        public ConfidentialLedgerClient(System.Uri ledgerEndpoint, Azure.Core.TokenCredential credential, Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions options) { }
        public ConfidentialLedgerClient(System.Uri ledgerEndpoint, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate) { }
        public ConfidentialLedgerClient(System.Uri ledgerEndpoint, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateLedgerEntry(Azure.Core.RequestContent content, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLedgerEntryAsync(Azure.Core.RequestContent content, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateUser(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateUserAsync(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCollections(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCollectionsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetConsortiumMembers(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetConsortiumMembersAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConstitution(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConstitutionAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCurrentLedgerEntry(string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCurrentLedgerEntryAsync(string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnclaveQuotes(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnclaveQuotesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLedgerEntries(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerEntriesAsync(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLedgerEntry(string transactionId, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerEntryAsync(string transactionId, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetReceipt(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceiptAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTransactionStatus(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransactionStatusAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation PostLedgerEntry(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> PostLedgerEntryAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConfidentialLedgerClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerClientOptions(Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion version = Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion.V2022_05_13) { }
        public System.Uri CertificateEndpoint { get { throw null; } set { } }
        public bool VerifyConnection { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2022_05_13 = 1,
        }
    }
}
namespace Azure.Security.ConfidentialLedger.Certificate
{
    public partial class ConfidentialLedgerCertificateClient
    {
        protected ConfidentialLedgerCertificateClient() { }
        public ConfidentialLedgerCertificateClient(System.Uri certificateEndpoint) { }
        public ConfidentialLedgerCertificateClient(System.Uri certificateEndpoint, Azure.Security.ConfidentialLedger.Certificate.ConfidentialLedgerCertificateClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetLedgerIdentity(string ledgerId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerIdentityAsync(string ledgerId, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConfidentialLedgerCertificateClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerCertificateClientOptions(Azure.Security.ConfidentialLedger.Certificate.ConfidentialLedgerCertificateClientOptions.ServiceVersion version = Azure.Security.ConfidentialLedger.Certificate.ConfidentialLedgerCertificateClientOptions.ServiceVersion.V2022_05_13) { }
        public enum ServiceVersion
        {
            V2022_05_13 = 1,
        }
    }
}
