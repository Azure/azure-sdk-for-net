namespace Azure.Identity
{
    public partial class AuthenticationFailedException : System.Exception
    {
        [System.ObsoleteAttribute(DiagnosticId="SYSLIB0051")]
        protected AuthenticationFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public AuthenticationFailedException(string message) { }
        public AuthenticationFailedException(string message, System.Exception innerException) { }
    }
    public partial class AuthenticationRecord
    {
        internal AuthenticationRecord() { }
        public string Authority { get { throw null; } }
        public string ClientId { get { throw null; } }
        public string HomeAccountId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string Username { get { throw null; } }
        public static Azure.Identity.AuthenticationRecord Deserialize(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Identity.AuthenticationRecord> DeserializeAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public void Serialize(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.Tasks.Task SerializeAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AuthenticationRequiredException : Azure.Identity.CredentialUnavailableException
    {
        [System.ObsoleteAttribute(DiagnosticId="SYSLIB0051")]
        protected AuthenticationRequiredException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (default(string)) { }
        public AuthenticationRequiredException(string message, Azure.Core.TokenRequestContext context) : base (default(string)) { }
        public AuthenticationRequiredException(string message, Azure.Core.TokenRequestContext context, System.Exception innerException) : base (default(string)) { }
        public Azure.Core.TokenRequestContext TokenRequestContext { get { throw null; } }
    }
    public partial class AuthorizationCodeCredential : Azure.Core.TokenCredential
    {
        protected AuthorizationCodeCredential() { }
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode) { }
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode, Azure.Identity.AuthorizationCodeCredentialOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode, Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AuthorizationCodeCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public AuthorizationCodeCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public System.Uri RedirectUri { get { throw null; } set { } }
    }
    public static partial class AzureAuthorityHosts
    {
        public static System.Uri AzureChina { get { throw null; } }
        [System.ObsoleteAttribute("Microsoft Cloud Germany was closed on October 29th, 2021.")]
        public static System.Uri AzureGermany { get { throw null; } }
        public static System.Uri AzureGovernment { get { throw null; } }
        public static System.Uri AzurePublicCloud { get { throw null; } }
    }
    public partial class AzureCliCredential : Azure.Core.TokenCredential
    {
        public AzureCliCredential() { }
        public AzureCliCredential(Azure.Identity.AzureCliCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureCliCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public AzureCliCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public System.TimeSpan? ProcessTimeout { get { throw null; } set { } }
        public string Subscription { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class AzureDeveloperCliCredential : Azure.Core.TokenCredential
    {
        public AzureDeveloperCliCredential() { }
        public AzureDeveloperCliCredential(Azure.Identity.AzureDeveloperCliCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureDeveloperCliCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public AzureDeveloperCliCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public System.TimeSpan? ProcessTimeout { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class AzurePipelinesCredential : Azure.Core.TokenCredential
    {
        protected AzurePipelinesCredential() { }
        public AzurePipelinesCredential(string tenantId, string clientId, string serviceConnectionId, string systemAccessToken, Azure.Identity.AzurePipelinesCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class AzurePipelinesCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public AzurePipelinesCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
    }
    public partial class AzurePowerShellCredential : Azure.Core.TokenCredential
    {
        public AzurePowerShellCredential() { }
        public AzurePowerShellCredential(Azure.Identity.AzurePowerShellCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzurePowerShellCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public AzurePowerShellCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public System.TimeSpan? ProcessTimeout { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class BrowserCustomizationOptions
    {
        public BrowserCustomizationOptions() { }
        public string ErrorMessage { get { throw null; } set { } }
        public string SuccessMessage { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This option requires additional dependencies on Microsoft.Identity.Client.Desktop and is no longer supported. Consider using brokered authentication instead")]
        public bool? UseEmbeddedWebView { get { throw null; } set { } }
    }
    public partial class ChainedTokenCredential : Azure.Core.TokenCredential
    {
        protected ChainedTokenCredential() { }
        public ChainedTokenCredential(params Azure.Core.TokenCredential[] sources) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClientAssertionCredential : Azure.Core.TokenCredential
    {
        protected ClientAssertionCredential() { }
        public ClientAssertionCredential(string tenantId, string clientId, System.Func<string> assertionCallback, Azure.Identity.ClientAssertionCredentialOptions options = null) { }
        public ClientAssertionCredential(string tenantId, string clientId, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<string>> assertionCallback, Azure.Identity.ClientAssertionCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClientAssertionCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public ClientAssertionCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
    }
    public partial class ClientCertificateCredential : Azure.Core.TokenCredential
    {
        protected ClientCertificateCredential() { }
        public ClientCertificateCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate) { }
        public ClientCertificateCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, Azure.Identity.ClientCertificateCredentialOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ClientCertificateCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, Azure.Identity.TokenCredentialOptions options) { }
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath) { }
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, Azure.Identity.ClientCertificateCredentialOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClientCertificateCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public ClientCertificateCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public bool SendCertificateChain { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
    }
    public partial class ClientSecretCredential : Azure.Core.TokenCredential
    {
        protected ClientSecretCredential() { }
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret) { }
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret, Azure.Identity.ClientSecretCredentialOptions options) { }
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret, Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClientSecretCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public ClientSecretCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
    }
    public partial class CredentialUnavailableException : Azure.Identity.AuthenticationFailedException
    {
        [System.ObsoleteAttribute(DiagnosticId="SYSLIB0051")]
        protected CredentialUnavailableException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (default(string)) { }
        public CredentialUnavailableException(string message) : base (default(string)) { }
        public CredentialUnavailableException(string message, System.Exception innerException) : base (default(string)) { }
    }
    public partial class DefaultAzureCredential : Azure.Core.TokenCredential
    {
        public const string DefaultEnvironmentVariableName = "AZURE_TOKEN_CREDENTIALS";
        protected DefaultAzureCredential() { }
        public DefaultAzureCredential(Azure.Identity.DefaultAzureCredentialOptions options) { }
        public DefaultAzureCredential(bool includeInteractiveCredentials = false) { }
        public DefaultAzureCredential(string configurationEnvironmentVariableName, Azure.Identity.DefaultAzureCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultAzureCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public DefaultAzureCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public System.TimeSpan? CredentialProcessTimeout { get { throw null; } set { } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public bool ExcludeAzureCliCredential { get { throw null; } set { } }
        public bool ExcludeAzureDeveloperCliCredential { get { throw null; } set { } }
        public bool ExcludeAzurePowerShellCredential { get { throw null; } set { } }
        public bool ExcludeBrokerCredential { get { throw null; } set { } }
        public bool ExcludeEnvironmentCredential { get { throw null; } set { } }
        public bool ExcludeInteractiveBrowserCredential { get { throw null; } set { } }
        public bool ExcludeManagedIdentityCredential { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("SharedTokenCacheCredential is deprecated. Consider using other dev tool credentials, such as VisualStudioCredential.")]
        public bool ExcludeSharedTokenCacheCredential { get { throw null; } set { } }
        public bool ExcludeVisualStudioCodeCredential { get { throw null; } set { } }
        public bool ExcludeVisualStudioCredential { get { throw null; } set { } }
        public bool ExcludeWorkloadIdentityCredential { get { throw null; } set { } }
        public string InteractiveBrowserCredentialClientId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string InteractiveBrowserTenantId { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedIdentityResourceId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string SharedTokenCacheTenantId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("SharedTokenCacheCredential is deprecated. Consider using other dev tool credentials, such as VisualStudioCredential.")]
        public string SharedTokenCacheUsername { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string VisualStudioCodeTenantId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string VisualStudioTenantId { get { throw null; } set { } }
        public string WorkloadIdentityClientId { get { throw null; } set { } }
    }
    public partial class DeviceCodeCredential : Azure.Core.TokenCredential
    {
        public DeviceCodeCredential() { }
        public DeviceCodeCredential(Azure.Identity.DeviceCodeCredentialOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public DeviceCodeCredential(System.Func<Azure.Identity.DeviceCodeInfo, System.Threading.CancellationToken, System.Threading.Tasks.Task> deviceCodeCallback, string clientId, Azure.Identity.TokenCredentialOptions options = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public DeviceCodeCredential(System.Func<Azure.Identity.DeviceCodeInfo, System.Threading.CancellationToken, System.Threading.Tasks.Task> deviceCodeCallback, string tenantId, string clientId, Azure.Identity.TokenCredentialOptions options = null) { }
        public virtual Azure.Identity.AuthenticationRecord Authenticate(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Identity.AuthenticationRecord Authenticate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Identity.AuthenticationRecord> AuthenticateAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Identity.AuthenticationRecord> AuthenticateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceCodeCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public DeviceCodeCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public Azure.Identity.AuthenticationRecord AuthenticationRecord { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public System.Func<Azure.Identity.DeviceCodeInfo, System.Threading.CancellationToken, System.Threading.Tasks.Task> DeviceCodeCallback { get { throw null; } set { } }
        public bool DisableAutomaticAuthentication { get { throw null; } set { } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct DeviceCodeInfo
    {
        private object _dummy;
        private int _dummyPrimitive;
        public string ClientId { get { throw null; } }
        public string DeviceCode { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<string> Scopes { get { throw null; } }
        public string UserCode { get { throw null; } }
        public System.Uri VerificationUri { get { throw null; } }
    }
    public partial class EnvironmentCredential : Azure.Core.TokenCredential
    {
        public EnvironmentCredential() { }
        public EnvironmentCredential(Azure.Identity.EnvironmentCredentialOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public EnvironmentCredential(Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public EnvironmentCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
    }
    public static partial class IdentityModelFactory
    {
        public static Azure.Identity.AuthenticationRecord AuthenticationRecord(string username, string authority, string homeAccountId, string tenantId, string clientId) { throw null; }
        public static Azure.Identity.DeviceCodeInfo DeviceCodeInfo(string userCode, string deviceCode, System.Uri verificationUri, System.DateTimeOffset expiresOn, string message, string clientId, System.Collections.Generic.IReadOnlyCollection<string> scopes) { throw null; }
    }
    public partial class InteractiveBrowserCredential : Azure.Core.TokenCredential
    {
        public InteractiveBrowserCredential() { }
        public InteractiveBrowserCredential(Azure.Identity.InteractiveBrowserCredentialOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public InteractiveBrowserCredential(string clientId) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public InteractiveBrowserCredential(string tenantId, string clientId, Azure.Identity.TokenCredentialOptions options = null) { }
        public virtual Azure.Identity.AuthenticationRecord Authenticate(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Identity.AuthenticationRecord Authenticate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Identity.AuthenticationRecord> AuthenticateAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Identity.AuthenticationRecord> AuthenticateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InteractiveBrowserCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public InteractiveBrowserCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public Azure.Identity.AuthenticationRecord AuthenticationRecord { get { throw null; } set { } }
        public Azure.Identity.BrowserCustomizationOptions BrowserCustomization { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public bool DisableAutomaticAuthentication { get { throw null; } set { } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public string LoginHint { get { throw null; } set { } }
        public System.Uri RedirectUri { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
    }
    public partial class ManagedIdentityCredential : Azure.Core.TokenCredential
    {
        protected ManagedIdentityCredential() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ManagedIdentityCredential(Azure.Core.ResourceIdentifier resourceId, Azure.Identity.TokenCredentialOptions options = null) { }
        public ManagedIdentityCredential(Azure.Identity.ManagedIdentityCredentialOptions options) { }
        public ManagedIdentityCredential(Azure.Identity.ManagedIdentityId id) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ManagedIdentityCredential(string clientId = null, Azure.Identity.TokenCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedIdentityCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public ManagedIdentityCredentialOptions(Azure.Identity.ManagedIdentityId managedIdentityId = null) { }
    }
    public partial class ManagedIdentityId
    {
        internal ManagedIdentityId() { }
        public static Azure.Identity.ManagedIdentityId SystemAssigned { get { throw null; } }
        public static Azure.Identity.ManagedIdentityId FromUserAssignedClientId(string id) { throw null; }
        public static Azure.Identity.ManagedIdentityId FromUserAssignedObjectId(string id) { throw null; }
        public static Azure.Identity.ManagedIdentityId FromUserAssignedResourceId(Azure.Core.ResourceIdentifier id) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnBehalfOfCredential : Azure.Core.TokenCredential
    {
        protected OnBehalfOfCredential() { }
        public OnBehalfOfCredential(string tenantId, string clientId, System.Func<string> clientAssertionCallback, string userAssertion, Azure.Identity.OnBehalfOfCredentialOptions options = null) { }
        public OnBehalfOfCredential(string tenantId, string clientId, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<string>> clientAssertionCallback, string userAssertion, Azure.Identity.OnBehalfOfCredentialOptions options = null) { }
        public OnBehalfOfCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, string userAssertion) { }
        public OnBehalfOfCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, string userAssertion, Azure.Identity.OnBehalfOfCredentialOptions options) { }
        public OnBehalfOfCredential(string tenantId, string clientId, string clientSecret, string userAssertion) { }
        public OnBehalfOfCredential(string tenantId, string clientId, string clientSecret, string userAssertion, Azure.Identity.OnBehalfOfCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class OnBehalfOfCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public OnBehalfOfCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public bool SendCertificateChain { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This credential is deprecated. Consider using other dev tool credentials, such as VisualStudioCredential.")]
    public partial class SharedTokenCacheCredential : Azure.Core.TokenCredential
    {
        public SharedTokenCacheCredential() { }
        public SharedTokenCacheCredential(Azure.Identity.SharedTokenCacheCredentialOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SharedTokenCacheCredential(string username, Azure.Identity.TokenCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("SharedTokenCacheCredential is deprecated. Consider using other dev tool credentials, such as VisualStudioCredential.")]
    public partial class SharedTokenCacheCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public SharedTokenCacheCredentialOptions() { }
        public SharedTokenCacheCredentialOptions(Azure.Identity.TokenCachePersistenceOptions tokenCacheOptions) { }
        public Azure.Identity.AuthenticationRecord AuthenticationRecord { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public bool EnableGuestTenantAuthentication { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct TokenCacheData
    {
        private object _dummy;
        private int _dummyPrimitive;
        public TokenCacheData(System.ReadOnlyMemory<byte> cacheBytes) { throw null; }
        public System.ReadOnlyMemory<byte> CacheBytes { get { throw null; } }
    }
    public partial class TokenCachePersistenceOptions
    {
        public TokenCachePersistenceOptions() { }
        public string Name { get { throw null; } set { } }
        public bool UnsafeAllowUnencryptedStorage { get { throw null; } set { } }
    }
    public partial class TokenCacheRefreshArgs
    {
        internal TokenCacheRefreshArgs() { }
        public bool IsCaeEnabled { get { throw null; } }
        public string SuggestedCacheKey { get { throw null; } }
    }
    public partial class TokenCacheUpdatedArgs
    {
        internal TokenCacheUpdatedArgs() { }
        public bool IsCaeEnabled { get { throw null; } }
        public System.ReadOnlyMemory<byte> UnsafeCacheData { get { throw null; } }
    }
    public partial class TokenCredentialDiagnosticsOptions : Azure.Core.DiagnosticsOptions
    {
        public TokenCredentialDiagnosticsOptions() { }
        public bool IsAccountIdentifierLoggingEnabled { get { throw null; } set { } }
    }
    public partial class TokenCredentialOptions : Azure.Core.ClientOptions
    {
        public TokenCredentialOptions() { }
        public System.Uri AuthorityHost { get { throw null; } set { } }
        public new Azure.Identity.TokenCredentialDiagnosticsOptions Diagnostics { get { throw null; } }
        public bool IsUnsafeSupportLoggingEnabled { get { throw null; } set { } }
    }
    public abstract partial class UnsafeTokenCacheOptions : Azure.Identity.TokenCachePersistenceOptions
    {
        protected UnsafeTokenCacheOptions() { }
        protected internal abstract System.Threading.Tasks.Task<System.ReadOnlyMemory<byte>> RefreshCacheAsync();
        protected internal virtual System.Threading.Tasks.Task<Azure.Identity.TokenCacheData> RefreshCacheAsync(Azure.Identity.TokenCacheRefreshArgs args, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal abstract System.Threading.Tasks.Task TokenCacheUpdatedAsync(Azure.Identity.TokenCacheUpdatedArgs tokenCacheUpdatedArgs);
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This credential is deprecated because it doesn't support multifactor authentication (MFA). See https://aka.ms/azsdk/identity/mfa for details about MFA enforcement for Microsoft Entra ID and migration guidance.")]
    public partial class UsernamePasswordCredential : Azure.Core.TokenCredential
    {
        protected UsernamePasswordCredential() { }
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId) { }
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId, Azure.Identity.TokenCredentialOptions options) { }
        public UsernamePasswordCredential(string username, string password, string tenantId, string clientId, Azure.Identity.UsernamePasswordCredentialOptions options) { }
        public virtual Azure.Identity.AuthenticationRecord Authenticate(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Identity.AuthenticationRecord Authenticate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Identity.AuthenticationRecord> AuthenticateAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Identity.AuthenticationRecord> AuthenticateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This credential is deprecated because it doesn't support multifactor authentication (MFA). See https://aka.ms/azsdk/identity/mfa for details about MFA enforcement for Microsoft Entra ID and migration guidance.")]
    public partial class UsernamePasswordCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public UsernamePasswordCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public Azure.Identity.TokenCachePersistenceOptions TokenCachePersistenceOptions { get { throw null; } set { } }
    }
    public partial class VisualStudioCodeCredential : Azure.Identity.InteractiveBrowserCredential
    {
        public VisualStudioCodeCredential() { }
        public VisualStudioCodeCredential(Azure.Identity.VisualStudioCodeCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VisualStudioCodeCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public VisualStudioCodeCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class VisualStudioCredential : Azure.Core.TokenCredential
    {
        public VisualStudioCredential() { }
        public VisualStudioCredential(Azure.Identity.VisualStudioCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class VisualStudioCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public VisualStudioCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public System.TimeSpan? ProcessTimeout { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class WorkloadIdentityCredential : Azure.Core.TokenCredential
    {
        public WorkloadIdentityCredential() { }
        public WorkloadIdentityCredential(Azure.Identity.WorkloadIdentityCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadIdentityCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public WorkloadIdentityCredentialOptions() { }
        public System.Collections.Generic.IList<string> AdditionallyAllowedTenants { get { throw null; } }
        public bool AzureKubernetesTokenProxy { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public bool DisableInstanceDiscovery { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public string TokenFilePath { get { throw null; } set { } }
    }
}
