namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        protected ConfidentialLedgerClient() { }
        public ConfidentialLedgerClient(System.Uri ledgerUri, Azure.Core.TokenCredential credential, Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateUser(string userId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateUserAsync(string userId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetConsortiumMembers(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConsortiumMembersAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetConstitution(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConstitutionAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCurrentLedgerEntry(string subLedgerId = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCurrentLedgerEntryAsync(string subLedgerId = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetEnclaveQuotes(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnclaveQuotesAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLedgerEntries(string subLedgerId = null, string fromTransactionId = null, string toTransactionId = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerEntriesAsync(string subLedgerId = null, string fromTransactionId = null, string toTransactionId = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetLedgerEntry(string transactionId, string subLedgerId = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerEntryAsync(string transactionId, string subLedgerId = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetReceipt(string transactionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceiptAsync(string transactionId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetTransactionStatus(string transactionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransactionStatusAsync(string transactionId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Security.ConfidentialLedger.PostLedgerEntryOperation PostLedgerEntry(Azure.Core.RequestContent content, string subLedgerId = null, bool waitForCompletion = true, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.ConfidentialLedger.PostLedgerEntryOperation> PostLedgerEntryAsync(Azure.Core.RequestContent content, string subLedgerId = null, bool waitForCompletion = true, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class ConfidentialLedgerClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerClientOptions(Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion version = Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion.V0_1_preview) { }
        public System.TimeSpan OperationPollingInterval { get { throw null; } set { } }
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
        public ConfidentialLedgerIdentityServiceClient(System.Uri identityServiceUri, Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetLedgerIdentity(string ledgerId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerIdentityAsync(string ledgerId, Azure.RequestOptions options = null) { throw null; }
        public static System.Security.Cryptography.X509Certificates.X509Certificate2 ParseCertificate(Azure.Response getIdentityResponse) { throw null; }
    }
    public partial class PostLedgerEntryOperation : Azure.Operation
    {
        protected PostLedgerEntryOperation() { }
        public PostLedgerEntryOperation(Azure.Security.ConfidentialLedger.ConfidentialLedgerClient client, string transactionId) { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
