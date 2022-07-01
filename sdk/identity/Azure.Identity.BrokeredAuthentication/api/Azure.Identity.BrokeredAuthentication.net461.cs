namespace Azure.Identity.BrokeredAuthentication
{
    public partial class InteractiveBrowserCredentialBrokerOptions : Azure.Identity.InteractiveBrowserCredentialOptions
    {
        public InteractiveBrowserCredentialBrokerOptions() { }
    }
    public partial class SharedTokenCacheCredentialBrokerOptions : Azure.Identity.SharedTokenCacheCredentialOptions
    {
        public SharedTokenCacheCredentialBrokerOptions() { }
        public SharedTokenCacheCredentialBrokerOptions(Azure.Identity.TokenCachePersistenceOptions tokenCacheOptions) { }
    }
}
