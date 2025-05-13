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
        public virtual Azure.Response CreateLedgerEntry(Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response CreateLedgerEntry(Azure.Core.RequestContent content, string collectionId = null, string tags = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLedgerEntryAsync(Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLedgerEntryAsync(Azure.Core.RequestContent content, string collectionId = null, string tags = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateLedgerUser(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateLedgerUserAsync(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateUser(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateUserAsync(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateUserDefinedEndpoint(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedEndpointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateUserDefinedFunction(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedFunctionAsync(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateUserDefinedRole(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedRoleAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteLedgerUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLedgerUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteUserDefinedFunction(string functionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserDefinedFunctionAsync(string functionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteUserDefinedRole(string roleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserDefinedRoleAsync(string roleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ExecuteUserDefinedFunction(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteUserDefinedFunctionAsync(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Pageable<System.BinaryData> GetLedgerEntries(string collectionId, string fromTransactionId, string toTransactionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLedgerEntries(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, string tag = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerEntriesAsync(string collectionId, string fromTransactionId, string toTransactionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerEntriesAsync(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, string tag = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLedgerEntry(string transactionId, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerEntryAsync(string transactionId, string collectionId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLedgerUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLedgerUsers(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerUsersAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetReceipt(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceiptAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRuntimeOptions(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRuntimeOptionsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTransactionStatus(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransactionStatusAsync(string transactionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUserDefinedEndpoint(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedEndpointAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUserDefinedEndpointsModule(string moduleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedEndpointsModuleAsync(string moduleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUserDefinedFunction(string functionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedFunctionAsync(string functionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetUserDefinedFunctions(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetUserDefinedFunctionsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUserDefinedRole(string roleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedRoleAsync(string roleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetUsers(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetUsersAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation PostLedgerEntry(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation PostLedgerEntry(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId = null, string tags = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> PostLedgerEntryAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> PostLedgerEntryAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId = null, string tags = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateRuntimeOptions(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRuntimeOptionsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateUserDefinedRole(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateUserDefinedRoleAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ConfidentialLedgerClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerClientOptions(Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion version = Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion.V2024_12_09_Preview) { }
        public System.Uri CertificateEndpoint { get { throw null; } set { } }
        public bool VerifyConnection { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2022_05_13 = 1,
            V2024_01_26_Preview = 2,
            V2024_08_22_Preview = 3,
            V2024_12_09_Preview = 4,
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
        public ConfidentialLedgerCertificateClientOptions(Azure.Security.ConfidentialLedger.Certificate.ConfidentialLedgerCertificateClientOptions.ServiceVersion version = Azure.Security.ConfidentialLedger.Certificate.ConfidentialLedgerCertificateClientOptions.ServiceVersion.V2024_12_09_Preview) { }
        public enum ServiceVersion
        {
            V2022_05_13 = 1,
            V2024_01_26_Preview = 2,
            V2024_08_22_Preview = 3,
            V2024_12_09_Preview = 4,
        }
    }
}
