namespace Azure.MixedReality.Authentication
{
    public partial class AzureMixedRealityAuthenticationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMixedRealityAuthenticationContext() { }
        public static Azure.MixedReality.Authentication.AzureMixedRealityAuthenticationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
            V2019_02_28 = 1,
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            V2019_02_28_preview = 1,
        }
    }
}
