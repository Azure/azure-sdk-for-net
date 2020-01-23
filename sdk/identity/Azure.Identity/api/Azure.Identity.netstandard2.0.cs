namespace Azure.Identity
{
    public partial class AuthenticationFailedException : System.Exception
    {
        public AuthenticationFailedException(string message) { }
        public AuthenticationFailedException(string message, System.Exception innerException) { }
    }
    public partial class AuthFileCredential : Azure.Core.TokenCredential
    {
        public AuthFileCredential(string filePath) { }
        public AuthFileCredential(string pathToFile, Azure.Identity.TokenCredentialOptions options) { }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public bool ExcludeEnvironmentCredential { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool ExcludeInteractiveBrowserCredential { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool ExcludeManagedIdentityCredential { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool ExcludeSharedTokenCacheCredential { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string InteractiveBrowserTenantId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ManagedIdentityClientId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string SharedTokenCacheTenantId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string SharedTokenCacheUsername { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
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
        public string ClientId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string DeviceCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset ExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Message { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IReadOnlyCollection<string> Scopes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string UserCode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri VerificationUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
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
        public string TenantId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Username { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class TokenCredentialOptions : Azure.Core.ClientOptions
    {
        public TokenCredentialOptions() { }
        public System.Uri AuthorityHost { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
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
