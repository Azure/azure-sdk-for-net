namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        protected ConfidentialLedgerClient() { }
        public ConfidentialLedgerClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConfidentialLedgerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateLedgerEntry(Azure.Core.RequestContent content, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLedgerEntryAsync(Azure.Core.RequestContent content, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateUser(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateUserAsync(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConsortiumMembers(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConsortiumMembersAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConstitution(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConstitutionAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCurrentLedgerEntry(string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCurrentLedgerEntryAsync(string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnclaveQuotes(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnclaveQuotesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLedgerEntry(string transactionId, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerEntryAsync(string transactionId, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetReceipt(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceiptAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTransactionStatus(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransactionStatusAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ListCollections(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListCollectionsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> ListLedgerEntries(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> ListLedgerEntriesAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConfidentialLedgerClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerClientOptions(Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion version = Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion.V2022_08_13) { }
        public enum ServiceVersion
        {
            V2022_08_13 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LedgerQueryState : System.IEquatable<Azure.Security.ConfidentialLedger.LedgerQueryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LedgerQueryState(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.LedgerQueryState Loading { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.LedgerQueryState Ready { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.LedgerQueryState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.LedgerQueryState left, Azure.Security.ConfidentialLedger.LedgerQueryState right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.LedgerQueryState (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.LedgerQueryState left, Azure.Security.ConfidentialLedger.LedgerQueryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LedgerUserRole : System.IEquatable<Azure.Security.ConfidentialLedger.LedgerUserRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LedgerUserRole(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.LedgerUserRole Administrator { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.LedgerUserRole Contributor { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.LedgerUserRole Reader { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.LedgerUserRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.LedgerUserRole left, Azure.Security.ConfidentialLedger.LedgerUserRole right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.LedgerUserRole (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.LedgerUserRole left, Azure.Security.ConfidentialLedger.LedgerUserRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransactionState : System.IEquatable<Azure.Security.ConfidentialLedger.TransactionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransactionState(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.TransactionState Committed { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.TransactionState Pending { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.TransactionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.TransactionState left, Azure.Security.ConfidentialLedger.TransactionState right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.TransactionState (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.TransactionState left, Azure.Security.ConfidentialLedger.TransactionState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
