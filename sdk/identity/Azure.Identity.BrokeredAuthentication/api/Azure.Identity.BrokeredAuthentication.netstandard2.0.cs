namespace Azure.Identity.BrokeredAuthentication
{
    public partial class InteractiveBrowserCredentialBrokerOptions : Azure.Identity.InteractiveBrowserCredentialOptions
    {
        public InteractiveBrowserCredentialBrokerOptions(System.IntPtr parentWindowHandle, bool msaPassThrough = false) { }
    }
    public partial class SharedTokenCacheCredentialBrokerOptions : Azure.Identity.SharedTokenCacheCredentialOptions
    {
        public SharedTokenCacheCredentialBrokerOptions(Azure.Identity.TokenCachePersistenceOptions tokenCacheOptions, bool msaPassThrough = false) { }
        public SharedTokenCacheCredentialBrokerOptions(bool msaPassThrough = false) { }
    }
}
