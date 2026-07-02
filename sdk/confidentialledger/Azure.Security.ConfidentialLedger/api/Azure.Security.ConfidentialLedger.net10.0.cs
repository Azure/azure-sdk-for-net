namespace Azure.Security.ConfidentialLedger
{
    public partial class AzureSecurityConfidentialLedgerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureSecurityConfidentialLedgerContext() { }
        public static Azure.Security.ConfidentialLedger.AzureSecurityConfidentialLedgerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult> CreateLedgerEntry(Azure.Security.ConfidentialLedger.Models.LedgerEntry entry, string collectionId = null, string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLedgerEntryAsync(Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLedgerEntryAsync(Azure.Core.RequestContent content, string collectionId = null, string tags = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>> CreateLedgerEntryAsync(Azure.Security.ConfidentialLedger.Models.LedgerEntry entry, string collectionId = null, string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrUpdateLedgerUser(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateLedgerUserAsync(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateUser(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateUserAsync(string userId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateUserDefinedEndpoint(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateUserDefinedEndpoint(Azure.Security.ConfidentialLedger.Models.Bundle bundle, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedEndpointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedEndpointAsync(Azure.Security.ConfidentialLedger.Models.Bundle bundle, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateUserDefinedFunction(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction> CreateUserDefinedFunction(string functionId, Azure.Security.ConfidentialLedger.Models.UserDefinedFunction userDefinedFunction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedFunctionAsync(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>> CreateUserDefinedFunctionAsync(string functionId, Azure.Security.ConfidentialLedger.Models.UserDefinedFunction userDefinedFunction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateUserDefinedRoleStable(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles> CreateUserDefinedRoleStable(Azure.Security.ConfidentialLedger.Models.UserDefinedRoles body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedRoleStableAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>> CreateUserDefinedRoleStableAsync(Azure.Security.ConfidentialLedger.Models.UserDefinedRoles body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteLedgerUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLedgerUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteUserDefinedFunction(string functionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserDefinedFunctionAsync(string functionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteUserDefinedRoleStable(string roleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserDefinedRoleStableAsync(string roleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ExecuteUserDefinedFunction(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse> ExecuteUserDefinedFunction(string functionId, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties userDefinedFunctionExecutionProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteUserDefinedFunctionAsync(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse>> ExecuteUserDefinedFunctionAsync(string functionId, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties userDefinedFunctionExecutionProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCollections(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Security.ConfidentialLedger.Models.Collection> GetCollections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCollectionsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.ConfidentialLedger.Models.Collection> GetCollectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetConsortiumMembers(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Security.ConfidentialLedger.Models.ConsortiumMember> GetConsortiumMembers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetConsortiumMembersAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.ConfidentialLedger.Models.ConsortiumMember> GetConsortiumMembersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConstitution(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.Constitution> GetConstitution(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConstitutionAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.Constitution>> GetConstitutionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCurrentLedgerEntry(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerEntry> GetCurrentLedgerEntry(string collectionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCurrentLedgerEntryAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerEntry>> GetCurrentLedgerEntryAsync(string collectionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEnclaveQuotes(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves> GetEnclaveQuotes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnclaveQuotesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>> GetEnclaveQuotesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLedgerEntries(string collectionId, string fromTransactionId, string toTransactionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLedgerEntries(string collectionId, string fromTransactionId, string toTransactionId, string tag, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Security.ConfidentialLedger.Models.LedgerEntry> GetLedgerEntries(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, string tag = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerEntriesAsync(string collectionId, string fromTransactionId, string toTransactionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerEntriesAsync(string collectionId, string fromTransactionId, string toTransactionId, string tag, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.ConfidentialLedger.Models.LedgerEntry> GetLedgerEntriesAsync(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, string tag = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLedgerEntry(string transactionId, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult> GetLedgerEntry(string transactionId, string collectionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerEntryAsync(string transactionId, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>> GetLedgerEntryAsync(string transactionId, string collectionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLedgerUser(string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles> GetLedgerUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLedgerUserAsync(string userId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles>> GetLedgerUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLedgerUsers(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles> GetLedgerUsers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLedgerUsersAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles> GetLedgerUsersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetReceipt(string transactionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.TransactionReceipt> GetReceipt(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetReceiptAsync(string transactionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>> GetReceiptAsync(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRuntimeOptions(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions> GetRuntimeOptions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRuntimeOptionsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>> GetRuntimeOptionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTags(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<string> GetTags(string collectionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTagsAsync(string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<string> GetTagsAsync(string collectionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTransactionStatus(string transactionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.TransactionStatus> GetTransactionStatus(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTransactionStatusAsync(string transactionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.TransactionStatus>> GetTransactionStatusAsync(string transactionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerUser> GetUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerUser>> GetUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUserDefinedEndpoint(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.Bundle> GetUserDefinedEndpoint(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedEndpointAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.Bundle>> GetUserDefinedEndpointAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUserDefinedEndpointsModule(string moduleName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.ModuleDef> GetUserDefinedEndpointsModule(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedEndpointsModuleAsync(string moduleName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.ModuleDef>> GetUserDefinedEndpointsModuleAsync(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUserDefinedFunction(string functionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction> GetUserDefinedFunction(string functionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedFunctionAsync(string functionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>> GetUserDefinedFunctionAsync(string functionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetUserDefinedFunctions(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction> GetUserDefinedFunctions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetUserDefinedFunctionsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction> GetUserDefinedFunctionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUserDefinedRole(string roleName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedRole> GetUserDefinedRole(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedRoleAsync(string roleName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>> GetUserDefinedRoleAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetUsers(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Security.ConfidentialLedger.Models.LedgerUser> GetUsers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetUsersAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.ConfidentialLedger.Models.LedgerUser> GetUsersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation PostLedgerEntry(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation PostLedgerEntry(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId = null, string tags = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> PostLedgerEntryAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> PostLedgerEntryAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string collectionId = null, string tags = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateRuntimeOptionsStable(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRuntimeOptionsStableAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateUserDefinedRoleStable(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateUserDefinedRoleStableAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
namespace Azure.Security.ConfidentialLedger.Models
{
    public partial class ApplicationClaim : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ApplicationClaim>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ApplicationClaim>
    {
        internal ApplicationClaim() { }
        public Azure.Security.ConfidentialLedger.Models.ClaimDigest Digest { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind Kind { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim LedgerEntry { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ApplicationClaim System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ApplicationClaim>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ApplicationClaim>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ApplicationClaim System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ApplicationClaim>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ApplicationClaim>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ApplicationClaim>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationClaimKind : System.IEquatable<Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationClaimKind(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind ClaimDigest { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind LedgerEntry { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind left, Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind left, Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationClaimProtocol : System.IEquatable<Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationClaimProtocol(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol LedgerEntryV1 { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol left, Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol left, Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Bundle : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Bundle>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Bundle>
    {
        public Bundle(Azure.Security.ConfidentialLedger.Models.Metadata metadata, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ModuleDef> modules) { }
        public Azure.Security.ConfidentialLedger.Models.Metadata Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.ModuleDef> Modules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Bundle System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Bundle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Bundle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Bundle System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Bundle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Bundle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Bundle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClaimDigest : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>
    {
        internal ClaimDigest() { }
        public Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol Protocol { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ClaimDigest System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ClaimDigest System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Collection : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Collection>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Collection>
    {
        internal Collection() { }
        public string CollectionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Collection System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Collection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Collection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Collection System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Collection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Collection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Collection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialLedgerEnclaves : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>
    {
        internal ConfidentialLedgerEnclaves() { }
        public string CurrentNodeId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Security.ConfidentialLedger.Models.EnclaveQuote> EnclaveQuotes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerQueryState : System.IEquatable<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerQueryState(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState Loading { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState Ready { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState left, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState left, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerUserRoleName : System.IEquatable<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerUserRoleName(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName Administrator { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName Contributor { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName Reader { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName left, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName left, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsortiumMember : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>
    {
        internal ConsortiumMember() { }
        public string Certificate { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ConsortiumMember System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ConsortiumMember System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Constitution : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Constitution>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Constitution>
    {
        internal Constitution() { }
        public string Digest { get { throw null; } }
        public string Script { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Constitution System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Constitution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Constitution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Constitution System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Constitution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Constitution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Constitution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveQuote : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>
    {
        internal EnclaveQuote() { }
        public string Mrenclave { get { throw null; } }
        public string NodeId { get { throw null; } }
        public string QuoteVersion { get { throw null; } }
        public string Raw { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.EnclaveQuote System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.EnclaveQuote System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.EndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EndpointProperties>
    {
        public EndpointProperties(System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> authnPolicies, Azure.Security.ConfidentialLedger.Models.ForwardingRequired forwardingRequired) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> AuthnPolicies { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ForwardingRequired ForwardingRequired { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy InterpreterReuse { get { throw null; } set { } }
        public string JsFunction { get { throw null; } set { } }
        public string JsModule { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.Mode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Openapi { get { throw null; } }
        public bool? OpenapiHidden { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.RedirectionStrategy? RedirectionStrategy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.EndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.EndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.EndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.EndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForwardingRequired : System.IEquatable<Azure.Security.ConfidentialLedger.Models.ForwardingRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForwardingRequired(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ForwardingRequired Always { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.ForwardingRequired Never { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.ForwardingRequired Sometimes { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.ForwardingRequired other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.ForwardingRequired left, Azure.Security.ConfidentialLedger.Models.ForwardingRequired right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ForwardingRequired (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ForwardingRequired left, Azure.Security.ConfidentialLedger.Models.ForwardingRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InterpreterReusePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>
    {
        public InterpreterReusePolicy(string key) { }
        public string Key { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JsRuntimeOptions : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>
    {
        public JsRuntimeOptions() { }
        public bool? LogExceptionDetails { get { throw null; } set { } }
        public long? MaxCachedInterpreters { get { throw null; } set { } }
        public long? MaxExecutionTimeMs { get { throw null; } set { } }
        public long? MaxHeapBytes { get { throw null; } set { } }
        public long? MaxStackBytes { get { throw null; } set { } }
        public bool? ReturnExceptionDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerEntry : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>
    {
        public LedgerEntry(string contents) { }
        public string CollectionId { get { throw null; } }
        public string Contents { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook> PostHooks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook> PreHooks { get { throw null; } }
        public string TransactionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerEntry System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerEntry System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerEntryClaim : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim>
    {
        internal LedgerEntryClaim() { }
        public string CollectionId { get { throw null; } }
        public string Contents { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol Protocol { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerQueryResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>
    {
        internal LedgerQueryResult() { }
        public Azure.Security.ConfidentialLedger.Models.LedgerEntry Entry { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerQueryResult System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerQueryResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerUser : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>
    {
        public LedgerUser(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName assignedRole) { }
        public Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName AssignedRole { get { throw null; } set { } }
        public string UserId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerUser System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerUser System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerUserMultipleRoles : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles>
    {
        public LedgerUserMultipleRoles(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName> assignedRoles) { }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName> AssignedRoles { get { throw null; } }
        public string UserId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerWriteResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>
    {
        internal LedgerWriteResult() { }
        public string CollectionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerWriteResult System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerWriteResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Metadata : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Metadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Metadata>
    {
        public Metadata(System.Collections.Generic.IDictionary<string, Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties> endpoints) { }
        public System.Collections.Generic.IDictionary<string, Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties> Endpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Metadata System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Metadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Metadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Metadata System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Metadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Metadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Metadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MethodToEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>
    {
        public MethodToEndpointProperties() { }
        public Azure.Security.ConfidentialLedger.Models.EndpointProperties Delete { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.EndpointProperties Get { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.EndpointProperties Patch { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.EndpointProperties Put { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.Security.ConfidentialLedger.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.Mode Historical { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.Mode Readonly { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.Mode Readwrite { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.Mode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.Mode left, Azure.Security.ConfidentialLedger.Models.Mode right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.Mode (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.Mode left, Azure.Security.ConfidentialLedger.Models.Mode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModuleDef : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>
    {
        public ModuleDef(string module, string name) { }
        public string Module { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ModuleDef System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ModuleDef System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReceiptContents : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptContents>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptContents>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ReceiptContents System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptContents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptContents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ReceiptContents System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptContents>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptContents>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptContents>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReceiptElement : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptElement>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptElement>
    {
        internal ReceiptElement() { }
        public string Left { get { throw null; } }
        public string Right { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ReceiptElement System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ReceiptElement System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReceiptLeafComponents : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents>
    {
        internal ReceiptLeafComponents() { }
        public string ClaimsDigest { get { throw null; } }
        public string CommitEvidence { get { throw null; } }
        public string WriteSetDigest { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedirectionStrategy : System.IEquatable<Azure.Security.ConfidentialLedger.Models.RedirectionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedirectionStrategy(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.RedirectionStrategy None { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.RedirectionStrategy ToBackup { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.RedirectionStrategy ToPrimary { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.RedirectionStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.RedirectionStrategy left, Azure.Security.ConfidentialLedger.Models.RedirectionStrategy right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.RedirectionStrategy (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.RedirectionStrategy left, Azure.Security.ConfidentialLedger.Models.RedirectionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Role : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Role>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Role>
    {
        public Role() { }
        public System.Collections.Generic.IList<string> RoleActions { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Role System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Role>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.Role>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.Role System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Role>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Role>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.Role>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SecurityConfidentialLedgerModelFactory
    {
        public static Azure.Security.ConfidentialLedger.Models.ApplicationClaim ApplicationClaim(Azure.Security.ConfidentialLedger.Models.ClaimDigest digest = null, Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind kind = default(Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind), Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim ledgerEntry = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ClaimDigest ClaimDigest(string value = null, Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol protocol = default(Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol)) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.Collection Collection(string collectionId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves ConfidentialLedgerEnclaves(string currentNodeId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Security.ConfidentialLedger.Models.EnclaveQuote> enclaveQuotes = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ConsortiumMember ConsortiumMember(string certificate = null, string id = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.Constitution Constitution(string digest = null, string script = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.EnclaveQuote EnclaveQuote(string nodeId = null, string mrenclave = null, string quoteVersion = null, string raw = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerEntry LedgerEntry(string contents = null, string collectionId = null, string transactionId = null, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook> preHooks = null, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook> postHooks = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim LedgerEntryClaim(string collectionId = null, string contents = null, string secretKey = null, Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol protocol = default(Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol)) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerQueryResult LedgerQueryResult(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState state = default(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState), Azure.Security.ConfidentialLedger.Models.LedgerEntry entry = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerUser LedgerUser(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName assignedRole = default(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName), string userId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles LedgerUserMultipleRoles(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName> assignedRoles = null, string userId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerWriteResult LedgerWriteResult(string collectionId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ReceiptContents ReceiptContents(string cert = null, string leaf = null, Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents leafComponents = null, string nodeId = null, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ReceiptElement> proof = null, string root = null, System.Collections.Generic.IEnumerable<string> serviceEndorsements = null, string signature = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ReceiptElement ReceiptElement(string left = null, string right = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents ReceiptLeafComponents(string claimsDigest = null, string commitEvidence = null, string writeSetDigest = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.TransactionReceipt TransactionReceipt(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ApplicationClaim> applicationClaims = null, Azure.Security.ConfidentialLedger.Models.ReceiptContents receipt = null, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState state = default(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState), string transactionId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.TransactionStatus TransactionStatus(Azure.Security.ConfidentialLedger.Models.TransactionState state = default(Azure.Security.ConfidentialLedger.Models.TransactionState), string transactionId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunction UserDefinedFunction(string code = null, string id = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError UserDefinedFunctionExecutionError(string message = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse UserDefinedFunctionExecutionResponse(Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError error = null, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult result = null, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus status = default(Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus)) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult UserDefinedFunctionExecutionResult(string returnValue = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedRole UserDefinedRole(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.Role> role = null) { throw null; }
    }
    public partial class TransactionReceipt : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>
    {
        internal TransactionReceipt() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.ConfidentialLedger.Models.ApplicationClaim> ApplicationClaims { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ReceiptContents Receipt { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState State { get { throw null; } }
        public string TransactionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.TransactionReceipt System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.TransactionReceipt System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransactionState : System.IEquatable<Azure.Security.ConfidentialLedger.Models.TransactionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransactionState(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.TransactionState Committed { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.TransactionState Pending { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.TransactionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.TransactionState left, Azure.Security.ConfidentialLedger.Models.TransactionState right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.TransactionState (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.TransactionState left, Azure.Security.ConfidentialLedger.Models.TransactionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransactionStatus : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>
    {
        internal TransactionStatus() { }
        public Azure.Security.ConfidentialLedger.Models.TransactionState State { get { throw null; } }
        public string TransactionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.TransactionStatus System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.TransactionStatus System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedFunction : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>
    {
        public UserDefinedFunction(string code) { }
        public string Code { get { throw null; } set { } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunction System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunction System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedFunctionExecutionError : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>
    {
        internal UserDefinedFunctionExecutionError() { }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedFunctionExecutionProperties : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>
    {
        public UserDefinedFunctionExecutionProperties() { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string ExportedFunctionName { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions RuntimeOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedFunctionExecutionResponse : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse>
    {
        internal UserDefinedFunctionExecutionResponse() { }
        public Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError Error { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult Result { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedFunctionExecutionResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>
    {
        internal UserDefinedFunctionExecutionResult() { }
        public string ReturnValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserDefinedFunctionExecutionStatus : System.IEquatable<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserDefinedFunctionExecutionStatus(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus Failed { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus left, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus left, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDefinedFunctionHook : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>
    {
        public UserDefinedFunctionHook(string functionId) { }
        public string FunctionId { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedRole : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>
    {
        internal UserDefinedRole() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.ConfidentialLedger.Models.Role> Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedRole System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedRole System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedRoles : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>
    {
        public UserDefinedRoles(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.Role> roles) { }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.Role> Roles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedRoles System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedRoles System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
