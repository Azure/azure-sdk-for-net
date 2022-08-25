namespace Azure.Communication.AlphaIds
{
    public partial class AlphaIdsClient
    {
        protected AlphaIdsClient() { }
        public AlphaIdsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Communication.AlphaIds.AlphaIdsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class AlphaIdsClientOptions : Azure.Core.ClientOptions
    {
        public AlphaIdsClientOptions(Azure.Communication.AlphaIds.Generated.AlphaIdsClientOptions.ServiceVersion version = Azure.Communication.AlphaIds.Generated.AlphaIdsClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}