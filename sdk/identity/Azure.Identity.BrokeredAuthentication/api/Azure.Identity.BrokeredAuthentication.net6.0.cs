namespace Azure.Identity.BrokeredAuthentication
{
    public partial class InteractiveBrowserCredentialBrokerOptions : Azure.Identity.InteractiveBrowserCredentialOptions
    {
        public InteractiveBrowserCredentialBrokerOptions(System.IntPtr parentWindowHandle) { }
        public InteractiveBrowserCredentialBrokerOptions(System.IntPtr parentWindowHandle, bool enableMsaPassthrough) { }
    }
    public partial class SharedTokenCacheCredentialBrokerOptions : Azure.Identity.SharedTokenCacheCredentialOptions
    {
        public SharedTokenCacheCredentialBrokerOptions() { }
        public SharedTokenCacheCredentialBrokerOptions(Azure.Identity.TokenCachePersistenceOptions tokenCacheOptions) { }
        public SharedTokenCacheCredentialBrokerOptions(Azure.Identity.TokenCachePersistenceOptions tokenCacheOptions = null, bool enableMsaPassthrough = false) { }
    }
}
