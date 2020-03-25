namespace Azure.Identity
{
    public partial class AuthenticationFailedException : System.Exception
    {
        public AuthenticationFailedException(string message) { }
        public AuthenticationFailedException(string message, System.Exception innerException) { }
    }
    public partial class AuthorizationCodeCredential : Azure.Core.TokenCredential
    {
        protected AuthorizationCodeCredential() { }
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode) { }
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode, Azure.Identity.TokenCredentialOptions options) { }
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
        public ClientCertificateCredential(string tenantId, string clientId, System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, Azure.Identity.TokenCredentialOptions options) { }
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath) { }
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClientSecretCredential : Azure.Core.TokenCredential
    {
        protected ClientSecretCredential() { }
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret) { }
        public ClientSecretCredential(string tenantId, string clientId, string clientSecret, Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string InteractiveBrowserTenantId { get { throw null; } set { } }
        public string ManagedIdentityClientId { get { throw null; } set { } }
        public string SharedTokenCacheTenantId { get { throw null; } set { } }
        public string SharedTokenCacheUsername { get { throw null; } set { } }
    }
    public partial class DeviceCodeCredential : Azure.Core.TokenCredential
    {
        protected DeviceCodeCredential() { }
        public DeviceCodeCredential(System.Func<Azure.Identity.DeviceCodeInfo, System.Threading.CancellationToken, System.Threading.Tasks.Task> deviceCodeCallback, string clientId, Azure.Identity.TokenCredentialOptions options = null) { }
        public DeviceCodeCredential(System.Func<Azure.Identity.DeviceCodeInfo, System.Threading.CancellationToken, System.Threading.Tasks.Task> deviceCodeCallback, string tenantId, string clientId, Azure.Identity.TokenCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class InteractiveBrowserCredential : Azure.Core.TokenCredential
    {
        public InteractiveBrowserCredential() { }
        public InteractiveBrowserCredential(string clientId) { }
        public InteractiveBrowserCredential(string tenantId, string clientId, Azure.Identity.TokenCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KnownAuthorityHosts
    {
        public static readonly System.Uri AzureChinaCloud;
        public static readonly System.Uri AzureCloud;
        public static readonly System.Uri AzureGermanCloud;
        public static readonly System.Uri AzureUSGovernment;
    }
    public partial class ManagedIdentityCredential : Azure.Core.TokenCredential
    {
        protected ManagedIdentityCredential() { }
        public ManagedIdentityCredential(string clientId = null, Azure.Identity.TokenCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedTokenCacheCredential : Azure.Core.TokenCredential
    {
        public SharedTokenCacheCredential() { }
        public SharedTokenCacheCredential(Azure.Identity.SharedTokenCacheCredentialOptions options) { }
        public SharedTokenCacheCredential(string username, Azure.Identity.TokenCredentialOptions options = null) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedTokenCacheCredentialOptions : Azure.Identity.TokenCredentialOptions
    {
        public SharedTokenCacheCredentialOptions() { }
        public string TenantId { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
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
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
