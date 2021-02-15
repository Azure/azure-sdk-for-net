namespace Azure.MixedReality.Authentication
{
    public partial class MixedRealityStsClient
    {
        protected MixedRealityStsClient() { }
        public MixedRealityStsClient(System.Guid accountId, string accountDomain, Azure.AzureKeyCredential keyCredential, Azure.MixedReality.Authentication.MixedRealityStsClientOptions options = null) { }
        public MixedRealityStsClient(System.Guid accountId, string accountDomain, Azure.Core.TokenCredential credential, Azure.MixedReality.Authentication.MixedRealityStsClientOptions options = null) { }
        public MixedRealityStsClient(System.Guid accountId, System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.MixedReality.Authentication.MixedRealityStsClientOptions options = null) { }
        public MixedRealityStsClient(System.Guid accountId, System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.MixedReality.Authentication.MixedRealityStsClientOptions options = null) { }
        public System.Guid AccountId { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.Core.AccessToken> GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Core.AccessToken>> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MixedRealityStsClientOptions : Azure.Core.ClientOptions
    {
        public MixedRealityStsClientOptions(Azure.MixedReality.Authentication.MixedRealityStsClientOptions.ServiceVersion version = Azure.MixedReality.Authentication.MixedRealityStsClientOptions.ServiceVersion.V2019_02_28_preview) { }
        public enum ServiceVersion
        {
            V2019_02_28_preview = 1,
        }
    }
}
