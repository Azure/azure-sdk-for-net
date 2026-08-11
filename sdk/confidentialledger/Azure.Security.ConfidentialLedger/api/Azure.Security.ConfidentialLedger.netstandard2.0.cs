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
        public ConfidentialLedgerClient(Azure.Security.ConfidentialLedger.ConfidentialLedgerClientSettings settings) { }
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
        public virtual Azure.Response CreateUserDefinedEndpoint(Azure.Security.ConfidentialLedger.Models.LedgerBundle bundle, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedEndpointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedEndpointAsync(Azure.Security.ConfidentialLedger.Models.LedgerBundle bundle, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateUserDefinedFunction(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction> CreateUserDefinedFunction(string functionId, Azure.Security.ConfidentialLedger.Models.UserDefinedFunction userDefinedFunction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedFunctionAsync(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>> CreateUserDefinedFunctionAsync(string functionId, Azure.Security.ConfidentialLedger.Models.UserDefinedFunction userDefinedFunction, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateUserDefinedRoleStable(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles> CreateUserDefinedRoleStable(Azure.Security.ConfidentialLedger.Models.UserDefinedRoles body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateUserDefinedRoleStableAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>> CreateUserDefinedRoleStableAsync(Azure.Security.ConfidentialLedger.Models.UserDefinedRoles body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteLedgerUser(string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteLedgerUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLedgerUserAsync(string userId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLedgerUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUserDefinedFunction(string functionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteUserDefinedFunction(string functionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserDefinedFunctionAsync(string functionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserDefinedFunctionAsync(string functionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUserDefinedRoleStable(string roleName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteUserDefinedRoleStable(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserDefinedRoleStableAsync(string roleName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserDefinedRoleStableAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteUserDefinedFunction(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution> ExecuteUserDefinedFunction(string functionId, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties userDefinedFunctionExecutionProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteUserDefinedFunctionAsync(string functionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution>> ExecuteUserDefinedFunctionAsync(string functionId, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties userDefinedFunctionExecutionProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCollections(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo> GetCollections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCollectionsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo> GetCollectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetConsortiumMembers(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Security.ConfidentialLedger.Models.ConsortiumMember> GetConsortiumMembers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetConsortiumMembersAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.ConfidentialLedger.Models.ConsortiumMember> GetConsortiumMembersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConstitution(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerConstitution> GetConstitution(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConstitutionAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerConstitution>> GetConstitutionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response GetOperationStatus(string operationId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationStatusAsync(string operationId, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerBundle> GetUserDefinedEndpoint(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserDefinedEndpointAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.ConfidentialLedger.Models.LedgerBundle>> GetUserDefinedEndpointAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Operation RehydratePostLedgerEntryOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRuntimeOptionsStable(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRuntimeOptionsStableAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateUserDefinedRoleStable(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateUserDefinedRoleStableAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public static partial class ConfidentialLedgerClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddConfidentialLedgerClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddConfidentialLedgerClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Security.ConfidentialLedger.ConfidentialLedgerClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedConfidentialLedgerClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedConfidentialLedgerClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Security.ConfidentialLedger.ConfidentialLedgerClientSettings> configureSettings) { throw null; }
    }
    public partial class ConfidentialLedgerClientOptions : Azure.Core.ClientOptions
    {
        public ConfidentialLedgerClientOptions(Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion version = Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions.ServiceVersion.V2024_12_09_Preview) { }
        public System.Uri CertificateEndpoint { get { throw null; } set { } }
        public bool UseLedgerGateway { get { throw null; } set { } }
        public bool VerifyConnection { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2022_05_13 = 1,
            V2024_01_26_Preview = 2,
            V2024_08_22_Preview = 3,
            V2024_12_09_Preview = 4,
        }
    }
    public partial class ConfidentialLedgerClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public ConfidentialLedgerClientSettings() { }
        public System.Uri LedgerEndpoint { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.ApplicationClaim JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.ApplicationClaim PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind? (string value) { throw null; }
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
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol left, Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClaimDigest : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>
    {
        internal ClaimDigest() { }
        public Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol Protocol { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.ClaimDigest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.ClaimDigest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.ClaimDigest System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ClaimDigest System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ClaimDigest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialLedgerEnclaves : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>
    {
        internal ConfidentialLedgerEnclaves() { }
        public string CurrentNodeId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Security.ConfidentialLedger.Models.EnclaveQuote> EnclaveQuotes { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ConfidentialLedgerModelFactory
    {
        public static Azure.Security.ConfidentialLedger.Models.ApplicationClaim ApplicationClaim(Azure.Security.ConfidentialLedger.Models.ClaimDigest digest = null, Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind kind = default(Azure.Security.ConfidentialLedger.Models.ApplicationClaimKind), Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim ledgerEntry = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ClaimDigest ClaimDigest(string value = null, Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol protocol = default(Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol)) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerEnclaves ConfidentialLedgerEnclaves(string currentNodeId = null, System.Collections.Generic.IDictionary<string, Azure.Security.ConfidentialLedger.Models.EnclaveQuote> enclaveQuotes = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ConsortiumMember ConsortiumMember(string certificate = null, string id = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.EnclaveQuote EnclaveQuote(string nodeId = null, string mrenclave = null, string quoteVersion = null, string raw = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.EndpointProperties EndpointProperties(System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> authnPolicies = null, Azure.Security.ConfidentialLedger.Models.ForwardingRequired forwardingRequired = default(Azure.Security.ConfidentialLedger.Models.ForwardingRequired), Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy interpreterReuse = null, string jsFunction = null, string jsModule = null, Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode? mode = default(Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode?), System.Collections.Generic.IDictionary<string, System.BinaryData> openapi = null, bool? openapiHidden = default(bool?), Azure.Security.ConfidentialLedger.Models.RedirectionStrategy? redirectionStrategy = default(Azure.Security.ConfidentialLedger.Models.RedirectionStrategy?)) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy InterpreterReusePolicy(string key = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions JsRuntimeOptions(bool? logExceptionDetails = default(bool?), long? maxCachedInterpreters = default(long?), long? maxExecutionTimeMs = default(long?), long? maxHeapBytes = default(long?), long? maxStackBytes = default(long?), bool? returnExceptionDetails = default(bool?)) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerBundle LedgerBundle(Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ModuleDef> modules = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo LedgerCollectionInfo(string collectionId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerConstitution LedgerConstitution(string digest = null, string script = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata LedgerEndpointMetadata(System.Collections.Generic.IDictionary<string, Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties> endpoints = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerEntry LedgerEntry(string contents = null, string collectionId = null, string transactionId = null, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook> preHooks = null, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook> postHooks = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim LedgerEntryClaim(string collectionId = null, string contents = null, string secretKey = null, Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol protocol = default(Azure.Security.ConfidentialLedger.Models.ApplicationClaimProtocol)) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerQueryResult LedgerQueryResult(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState state = default(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState), Azure.Security.ConfidentialLedger.Models.LedgerEntry entry = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerRole LedgerRole(string roleName = null, System.Collections.Generic.IEnumerable<string> roleActions = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerUser LedgerUser(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName assignedRole = default(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName), string userId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles LedgerUserMultipleRoles(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName> assignedRoles = null, string userId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerWriteResult LedgerWriteResult(string transactionId = null, string collectionId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties MethodToEndpointProperties(Azure.Security.ConfidentialLedger.Models.EndpointProperties @get = null, Azure.Security.ConfidentialLedger.Models.EndpointProperties put = null, Azure.Security.ConfidentialLedger.Models.EndpointProperties patch = null, Azure.Security.ConfidentialLedger.Models.EndpointProperties delete = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ModuleDef ModuleDef(string module = null, string name = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ReceiptContents ReceiptContents(string cert = null, string leaf = null, Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents leafComponents = null, string nodeId = null, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ReceiptElement> proof = null, string root = null, System.Collections.Generic.IEnumerable<string> serviceEndorsements = null, string signature = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ReceiptElement ReceiptElement(string left = null, string right = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents ReceiptLeafComponents(string claimsDigest = null, string commitEvidence = null, string writeSetDigest = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.TransactionReceipt TransactionReceipt(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ApplicationClaim> applicationClaims = null, Azure.Security.ConfidentialLedger.Models.ReceiptContents receipt = null, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState state = default(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState), string transactionId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.TransactionStatus TransactionStatus(Azure.Security.ConfidentialLedger.Models.TransactionState state = default(Azure.Security.ConfidentialLedger.Models.TransactionState), string transactionId = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunction UserDefinedFunction(string code = null, string id = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution UserDefinedFunctionExecution(Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError error = null, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult result = null, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus status = default(Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus)) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError UserDefinedFunctionExecutionError(string message = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties UserDefinedFunctionExecutionProperties(System.Collections.Generic.IEnumerable<string> arguments = null, string exportedFunctionName = null, Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions runtimeOptions = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult UserDefinedFunctionExecutionResult(string returnValue = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook UserDefinedFunctionHook(string functionId = null, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties properties = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedRole UserDefinedRole(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.LedgerRole> role = null) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.UserDefinedRoles UserDefinedRoles(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.LedgerRole> roles = null) { throw null; }
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
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState? (string value) { throw null; }
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
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName? (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName left, Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsortiumMember : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>
    {
        internal ConsortiumMember() { }
        public string Certificate { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.ConsortiumMember JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.ConsortiumMember PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.ConsortiumMember System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.ConsortiumMember System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ConsortiumMember>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnclaveQuote : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.EnclaveQuote>
    {
        internal EnclaveQuote() { }
        public string Mrenclave { get { throw null; } }
        public string NodeId { get { throw null; } }
        public string QuoteVersion { get { throw null; } }
        public string Raw { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.EnclaveQuote JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.EnclaveQuote PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Openapi { get { throw null; } }
        public bool? OpenapiHidden { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.RedirectionStrategy? RedirectionStrategy { get { throw null; } set { } }
        protected virtual Azure.Security.ConfidentialLedger.Models.EndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.EndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.Security.ConfidentialLedger.Models.ForwardingRequired? (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.ForwardingRequired left, Azure.Security.ConfidentialLedger.Models.ForwardingRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InterpreterReusePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy>
    {
        public InterpreterReusePolicy(string key) { }
        public string Key { get { throw null; } set { } }
        protected virtual Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.InterpreterReusePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.JsRuntimeOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerBundle : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerBundle>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerBundle>
    {
        public LedgerBundle(Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata metadata, System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.ModuleDef> modules) { }
        public Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.ModuleDef> Modules { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerBundle JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.LedgerBundle (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Security.ConfidentialLedger.Models.LedgerBundle ledgerBundle) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerBundle PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.LedgerBundle System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerBundle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerBundle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerBundle System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerBundle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerBundle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerBundle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerCollectionInfo : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo>
    {
        internal LedgerCollectionInfo() { }
        public string CollectionId { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerCollectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerConstitution : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerConstitution>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerConstitution>
    {
        internal LedgerConstitution() { }
        public string Digest { get { throw null; } }
        public string Script { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerConstitution JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.LedgerConstitution (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerConstitution PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.LedgerConstitution System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerConstitution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerConstitution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerConstitution System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerConstitution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerConstitution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerConstitution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerEndpointMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata>
    {
        public LedgerEndpointMetadata(System.Collections.Generic.IDictionary<string, Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties> endpoints) { }
        public System.Collections.Generic.IDictionary<string, Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties> Endpoints { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEndpointMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LedgerEndpointMode : System.IEquatable<Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LedgerEndpointMode(string value) { throw null; }
        public static Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode Historical { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode Readonly { get { throw null; } }
        public static Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode Readwrite { get { throw null; } }
        public bool Equals(Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode left, Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode right) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode (string value) { throw null; }
        public static implicit operator Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode? (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode left, Azure.Security.ConfidentialLedger.Models.LedgerEndpointMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LedgerEntry : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerEntry>
    {
        public LedgerEntry(string contents) { }
        public string CollectionId { get { throw null; } }
        public string Contents { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook> PostHooks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook> PreHooks { get { throw null; } }
        public string TransactionId { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.LedgerEntry (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Security.ConfidentialLedger.Models.LedgerEntry ledgerEntry) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerEntryClaim PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerQueryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.LedgerQueryResult (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerQueryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.LedgerQueryResult System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerQueryResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerQueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerRole : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerRole>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerRole>
    {
        public LedgerRole() { }
        public System.Collections.Generic.IList<string> RoleActions { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerRole JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerRole PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.LedgerRole System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerRole System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LedgerUser : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerUser>
    {
        public LedgerUser(Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName assignedRole) { }
        public Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerUserRoleName AssignedRole { get { throw null; } set { } }
        public string UserId { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerUser JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.LedgerUser (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerUser PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerUserMultipleRoles PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string TransactionId { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerWriteResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.LedgerWriteResult (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.LedgerWriteResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.LedgerWriteResult System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.LedgerWriteResult System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.LedgerWriteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MethodToEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>
    {
        public MethodToEndpointProperties() { }
        public Azure.Security.ConfidentialLedger.Models.EndpointProperties Delete { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.EndpointProperties Get { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.EndpointProperties Patch { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.EndpointProperties Put { get { throw null; } set { } }
        protected virtual Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.MethodToEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModuleDef : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.ModuleDef>
    {
        public ModuleDef(string module, string name) { }
        public string Module { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Security.ConfidentialLedger.Models.ModuleDef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.ModuleDef (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.ModuleDef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.ReceiptElement> Proof { get { throw null; } }
        public string Root { get { throw null; } }
        public System.Collections.Generic.IList<string> ServiceEndorsements { get { throw null; } }
        public string Signature { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.ReceiptContents JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.ReceiptContents PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.ReceiptElement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.ReceiptElement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.ReceiptLeafComponents PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.Security.ConfidentialLedger.Models.RedirectionStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.RedirectionStrategy left, Azure.Security.ConfidentialLedger.Models.RedirectionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransactionReceipt : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionReceipt>
    {
        internal TransactionReceipt() { }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.ApplicationClaim> ApplicationClaims { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ReceiptContents Receipt { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.ConfidentialLedgerQueryState State { get { throw null; } }
        public string TransactionId { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.TransactionReceipt JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.TransactionReceipt (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.TransactionReceipt PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.Security.ConfidentialLedger.Models.TransactionState? (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.TransactionState left, Azure.Security.ConfidentialLedger.Models.TransactionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransactionStatus : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.TransactionStatus>
    {
        internal TransactionStatus() { }
        public Azure.Security.ConfidentialLedger.Models.TransactionState State { get { throw null; } }
        public string TransactionId { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.TransactionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.TransactionStatus (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.TransactionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.UserDefinedFunction (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Security.ConfidentialLedger.Models.UserDefinedFunction userDefinedFunction) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunction System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunction System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedFunctionExecution : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution>
    {
        internal UserDefinedFunctionExecution() { }
        public Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError Error { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult Result { get { throw null; } }
        public Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus Status { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedFunctionExecutionError : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError>
    {
        internal UserDefinedFunctionExecutionError() { }
        public string Message { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties userDefinedFunctionExecutionProperties) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedFunctionExecutionResult : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult>
    {
        internal UserDefinedFunctionExecutionResult() { }
        public string ReturnValue { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static implicit operator Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus left, Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDefinedFunctionHook : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>
    {
        public UserDefinedFunctionHook(string functionId) { }
        public string FunctionId { get { throw null; } set { } }
        public Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionExecutionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedFunctionHook>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedRole : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>
    {
        internal UserDefinedRole() { }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.LedgerRole> Role { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedRole JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.UserDefinedRole (Azure.Response response) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedRole PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.UserDefinedRole System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedRole System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDefinedRoles : System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>, System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>
    {
        public UserDefinedRoles(System.Collections.Generic.IEnumerable<Azure.Security.ConfidentialLedger.Models.LedgerRole> roles) { }
        public System.Collections.Generic.IList<Azure.Security.ConfidentialLedger.Models.LedgerRole> Roles { get { throw null; } }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedRoles JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Security.ConfidentialLedger.Models.UserDefinedRoles (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Security.ConfidentialLedger.Models.UserDefinedRoles userDefinedRoles) { throw null; }
        protected virtual Azure.Security.ConfidentialLedger.Models.UserDefinedRoles PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Security.ConfidentialLedger.Models.UserDefinedRoles System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Security.ConfidentialLedger.Models.UserDefinedRoles System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Security.ConfidentialLedger.Models.UserDefinedRoles>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
