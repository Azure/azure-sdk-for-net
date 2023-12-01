namespace Azure.Identity.Broker
{
    public partial class InteractiveBrowserCredentialBrokerOptions : Azure.Identity.InteractiveBrowserCredentialOptions
    {
        public InteractiveBrowserCredentialBrokerOptions(System.IntPtr parentWindowHandle) { }
        public bool? IsLegacyMsaPassthroughEnabled { get { throw null; } set { } }
    }
    public partial class SharedTokenCacheCredentialBrokerOptions : Azure.Identity.SharedTokenCacheCredentialOptions
    {
        public SharedTokenCacheCredentialBrokerOptions() { }
        public SharedTokenCacheCredentialBrokerOptions(Azure.Identity.TokenCachePersistenceOptions tokenCacheOptions) { }
        public bool? IsMsaPassthroughEnabled { get { throw null; } set { } }
    }
}
