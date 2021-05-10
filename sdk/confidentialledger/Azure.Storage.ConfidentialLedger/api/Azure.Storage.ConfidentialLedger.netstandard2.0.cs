namespace Azure.Storage.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        protected ConfidentialLedgerClient() { }
        public ConfidentialLedgerClient(System.Uri ledgerUri, Azure.Core.TokenCredential credential, Azure.Storage.ConfidentialLedger.ConfidentialLedgerClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateUser(string userId, Azure.Core.RequestContent requestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateUserAsync(string userId, Azure.Core.RequestContent requestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConsortiumMembers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConsortiumMembersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConstitution(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConstitutionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCurrentLedgerEntry(string subLedgerId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCurrentLedgerEntryAsync(string subLedgerId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEnclaveQuotes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnclaveQuotesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLedgerEntries(string subLedgerId = null, string fromTransactionId = null, string toTransactionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerEntriesAsync(string subLedgerId = null, string fromTransactionId = null, string toTransactionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLedgerEntry(string transactionId, string subLedgerId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerEntryAsync(string transactionId, string subLedgerId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetReceipt(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceiptAsync(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTransactionStatus(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransactionStatusAsync(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostLedgerEntry(Azure.Core.RequestContent requestBody, string subLedgerId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostLedgerEntryAsync(Azure.Core.RequestContent requestBody, string subLedgerId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfidentialLedgerClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerClientOptions(Azure.Storage.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion version = Azure.Storage.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion.V0_1_preview) { }
        public enum ServiceVersion
        {
            V0_1_preview = 1,
        }
    }
    public static partial class ConfidentialLedgerConstants
    {
        public const string TransactionIdHeaderName = "x-ms-ccf-transaction-id";
    }
    public partial class ConfidentialLedgerIdentityServiceClient
    {
        protected ConfidentialLedgerIdentityServiceClient() { }
        public ConfidentialLedgerIdentityServiceClient(System.Uri identityServiceUri, Azure.Core.TokenCredential credential, Azure.Storage.ConfidentialLedger.ConfidentialLedgerClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetLedgerIdentity(string ledgerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerIdentityAsync(string ledgerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
