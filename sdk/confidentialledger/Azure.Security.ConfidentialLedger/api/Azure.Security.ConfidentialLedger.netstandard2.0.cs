namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        protected ConfidentialLedgerClient() { }
        public ConfidentialLedgerClient(System.Uri ledgerUri, Azure.Core.TokenCredential credential, Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateUser(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateUserAsync(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Pageable<System.BinaryData> GetLedgerEntries(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerEntriesAsync(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLedgerEntry(string transactionId, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerEntryAsync(string transactionId, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetReceipt(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceiptAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.TransactionReceipt> GetReceiptValue(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>> GetReceiptValueAsync(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTransactionStatus(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransactionStatusAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PostLedgerEntry(Azure.Core.RequestContent content, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Security.ConfidentialLedger.PostLedgerEntryOperation PostLedgerEntry(Azure.Core.RequestContent content, string subLedgerId = null, bool waitForCompletion = true, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostLedgerEntryAsync(Azure.Core.RequestContent content, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.ConfidentialLedger.PostLedgerEntryOperation> PostLedgerEntryAsync(Azure.Core.RequestContent content, string subLedgerId = null, bool waitForCompletion = true, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConfidentialLedgerClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerClientOptions(Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion version = Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion.V2022_04_20_preview) { }
        public System.TimeSpan OperationPollingInterval { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2022_04_20_preview = 1,
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
        public virtual Azure.Response GetLedgerIdentity(string ledgerId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerIdentityAsync(string ledgerId, Azure.RequestContext context = null) { throw null; }
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
    }
}
namespace Azure.Security.ConfidentialLedger.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerQueryState : System.IEquatable<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerQueryState(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState Loading { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState Ready { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState left, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState left, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReceiptContents
    {
        internal ReceiptContents() { }
        public string Cert { get { throw null; } }
        public string Leaf { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents LeafComponents { get { throw null; } }
        public string NodeId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.ConfidentialLedger.Models.ReceiptElement> Proof { get { throw null; } }
        public string Root { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ServiceEndorsements { get { throw null; } }
        public string Signature { get { throw null; } }
    }
    public partial class ReceiptElement
    {
        internal ReceiptElement() { }
        public string Left { get { throw null; } }
        public string Right { get { throw null; } }
    }
    public partial class ReceiptLeafComponents
    {
        internal ReceiptLeafComponents() { }
        public string ClaimsDigest { get { throw null; } }
        public string CommitEvidence { get { throw null; } }
        public string WriteSetDigest { get { throw null; } }
    }
    public partial class TransactionReceipt
    {
        internal TransactionReceipt() { }
        public Azure.Security.ConfidentialLedger.Models.ReceiptContents Receipt { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState State { get { throw null; } }
        public string TransactionId { get { throw null; } }
    }
}
