namespace Azure.Identity.Broker
{
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    [System.Runtime.Versioning.UnsupportedOSPlatformAttribute("browser")]
    public sealed partial class BrokerCredentialResolver : System.ClientModel.Primitives.CredentialResolver
    {
        public BrokerCredentialResolver() { }
        public override bool TryResolve(Microsoft.Extensions.Configuration.IConfigurationSection credentialSection, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out System.ClientModel.AuthenticationTokenProvider? provider) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class ConfigurationExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddBrokerCredentialResolver(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.Extensions.Hosting.IHostApplicationBuilder AddBrokerCredentialResolver(this Microsoft.Extensions.Hosting.IHostApplicationBuilder builder) { throw null; }
    }
    public partial class InteractiveBrowserCredentialBrokerOptions : Azure.Identity.InteractiveBrowserCredentialOptions
    {
        public InteractiveBrowserCredentialBrokerOptions(System.IntPtr parentWindowHandle) { }
        public bool? IsLegacyMsaPassthroughEnabled { get { throw null; } set { } }
        public bool UseDefaultBrokerAccount { get { throw null; } set { } }
    }
    [System.ObsoleteAttribute("SharedTokenCacheCredential is deprecated. For brokered authentication, consider using InteractiveBrowserCredential.")]
    public partial class SharedTokenCacheCredentialBrokerOptions : Azure.Identity.SharedTokenCacheCredentialOptions
    {
        public SharedTokenCacheCredentialBrokerOptions() { }
        public SharedTokenCacheCredentialBrokerOptions(Azure.Identity.TokenCachePersistenceOptions tokenCacheOptions) { }
        public bool? IsLegacyMsaPassthroughEnabled { get { throw null; } set { } }
        public bool UseDefaultBrokerAccount { get { throw null; } set { } }
    }
}
