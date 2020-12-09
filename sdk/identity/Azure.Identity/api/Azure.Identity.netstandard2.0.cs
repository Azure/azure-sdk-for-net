namespace Azure.Identity
{
    public partial class AuthenticationFailedException : System.Exception
    {
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
        public AuthenticationRequiredException(string message, Azure.Core.TokenRequestContext context) : base (default(string)) { }
        public AuthenticationRequiredException(string message, Azure.Core.TokenRequestContext context, System.Exception innerException) : base (default(string)) { }
        public Azure.Core.TokenRequestContext TokenRequestContext { get { throw null; } }
    }
    public partial class AuthorizationCodeCredential : Azure.Core.TokenCredential
    {
        protected AuthorizationCodeCredential() { }
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode) { }
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode, Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AzureAuthorityHosts
    {
        public static System.Uri AzureChina { get { throw null; } }
        public static System.Uri AzureGermany { get { throw null; } }
        public static System.Uri AzureGovernment { get { throw null; } }
        public static System.Uri AzurePublicCloud { get { throw null; } }
    }
    public partial class AzureCliCredential : Azure.Core.TokenCredential
    {
        public AzureCliCredential() { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChainedTokenCredential : Azure.Core.TokenCredential
    {
        public ChainedTokenCredential(params Azure.Core.TokenCredential[] sources) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClientCertificateCredential : Azure.Core.TokenCredential
    {
        protected ClientCertificateCredential() { }
        public ClientCertificateCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate) { }
        public ClientCertificateCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, Azure.Identity.ClientCertificateCredentialOptions options) { }
        public ClientCertificateCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, Azure.Identity.TokenCredentialOptions options) { }
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath) { }
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, Azure.Identity.ClientCertificateCredentialOptions options) { }
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClientCertificateCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public ClientCertificateCredentialOptions() { }
        public bool SendCertificateChain { get { throw null; } set { } }
        public Azure.Identity.TokenCache TokenCache { get { throw null; } set { } }
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
        public Azure.Identity.TokenCache TokenCache { get { throw null; } set { } }
    }
    public partial class CredentialUnavailableException : Azure.Identity.AuthenticationFailedException
    {
        public CredentialUnavailableException(string message) : base (default(string)) { }
        public CredentialUnavailableException(string message, System.Exception innerException) : base (default(string)) { }
    }
    public partial class DefaultAzureCredential : Azure.Core.TokenCredential
    {
        public DefaultAzureCredential(Azure.Identity.DefaultAzureCredentialOptions options) { }
        public DefaultAzureCredential(bool includeInteractiveCredentials = false) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultAzureCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public DefaultAzureCredentialOptions() { }
        public bool ExcludeAzureCliCredential { get { throw null; } set { } }
        public bool ExcludeEnvironmentCredential { get { throw null; } set { } }
        public bool ExcludeInteractiveBrowserCredential { get { throw null; } set { } }
        public bool ExcludeManagedIdentityCredential { get { throw null; } set { } }
        public bool ExcludeSharedTokenCacheCredential { get { throw null; } set { } }
        public bool ExcludeVisualStudioCodeCredential { get { throw null; } set { } }
        public bool ExcludeVisualStudioCredential { get { throw null; } set { } }
        public string InteractiveBrowserTenantId { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SharedTokenCacheTenantId { get { throw null; } set { } }
        public string SharedTokenCacheUsername { get { throw null; } set { } }
        public string VisualStudioCodeTenantId { get { throw null; } set { } }
        public string VisualStudioTenantId { get { throw null; } set { } }
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
        public Azure.Identity.AuthenticationRecord AuthenticationRecord { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public System.Func<Azure.Identity.DeviceCodeInfo, System.Threading.CancellationToken, System.Threading.Tasks.Task> DeviceCodeCallback { get { throw null; } set { } }
        public bool DisableAutomaticAuthentication { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public Azure.Identity.TokenCache TokenCache { get { throw null; } set { } }
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
        public EnvironmentCredential(Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.Identity.AuthenticationRecord AuthenticationRecord { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public bool DisableAutomaticAuthentication { get { throw null; } set { } }
        public System.Uri RedirectUri { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public Azure.Identity.TokenCache TokenCache { get { throw null; } set { } }
    }
    public partial class ManagedIdentityCredential : Azure.Core.TokenCredential
    {
        protected ManagedIdentityCredential() { }
        public ManagedIdentityCredential(string clientId = null, Azure.Identity.TokenCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PersistentTokenCache : Azure.Identity.TokenCache
    {
        public PersistentTokenCache(Azure.Identity.PersistentTokenCacheOptions options) { }
        public PersistentTokenCache(bool allowUnencryptedStorage = true) { }
    }
    public partial class PersistentTokenCacheOptions
    {
        public PersistentTokenCacheOptions() { }
        public bool AllowUnencryptedStorage { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class SharedTokenCacheCredential : Azure.Core.TokenCredential
    {
        public SharedTokenCacheCredential() { }
        public SharedTokenCacheCredential(Azure.Identity.SharedTokenCacheCredentialOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SharedTokenCacheCredential(string username, Azure.Identity.TokenCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedTokenCacheCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public SharedTokenCacheCredentialOptions() { }
        public SharedTokenCacheCredentialOptions(Azure.Identity.TokenCache tokenCache) { }
        public Azure.Identity.AuthenticationRecord AuthenticationRecord { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public bool EnableGuestTenantAuthentication { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public Azure.Identity.TokenCache TokenCache { get { throw null; } }
        public string Username { get { throw null; } set { } }
    }
    public partial class TokenCache : System.IDisposable
    {
        public TokenCache() { }
        public event System.Func<Azure.Identity.TokenCacheUpdatedArgs, System.Threading.Tasks.Task> Updated { add { } remove { } }
        public static Azure.Identity.TokenCache Deserialize(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Identity.TokenCache> DeserializeAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void Serialize(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.Tasks.Task SerializeAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TokenCacheUpdatedArgs
    {
        internal TokenCacheUpdatedArgs() { }
        public Azure.Identity.TokenCache Cache { get { throw null; } }
    }
    public partial class TokenCredentialOptions : Azure.Core.ClientOptions
    {
        public TokenCredentialOptions() { }
        public System.Uri AuthorityHost { get { throw null; } set { } }
    }
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
    public partial class UsernamePasswordCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public UsernamePasswordCredentialOptions() { }
        public Azure.Identity.TokenCache TokenCache { get { throw null; } set { } }
    }
    public partial class VisualStudioCodeCredential : Azure.Core.TokenCredential
    {
        public VisualStudioCodeCredential() { }
        public VisualStudioCodeCredential(Azure.Identity.VisualStudioCodeCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class VisualStudioCodeCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public VisualStudioCodeCredentialOptions() { }
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
        public string TenantId { get { throw null; } set { } }
    }
}
