namespace Azure.Identity.BrokeredAuthentication
{
    public partial class InteractiveBrowserCredentialBrokerOptions : Azure.Identity.InteractiveBrowserCredentialOptions
    {
        public InteractiveBrowserCredentialBrokerOptions(System.IntPtr parentWindowHandle, bool msaPassthrough = false) { }
    }
    public partial class SharedTokenCacheCredentialBrokerOptions : Azure.Identity.SharedTokenCacheCredentialOptions
    {
        public SharedTokenCacheCredentialBrokerOptions(Azure.Identity.TokenCachePersistenceOptions tokenCacheOptions, bool msaPassthrough = false) { }
        public SharedTokenCacheCredentialBrokerOptions(bool msaPassthrough = false) { }
    }
}
