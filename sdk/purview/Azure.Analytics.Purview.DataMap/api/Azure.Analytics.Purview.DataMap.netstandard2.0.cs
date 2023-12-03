namespace Azure.Analytics.Purview.DataMap
{
    public partial class DataMapClient
    {
        protected DataMapClient() { }
        public DataMapClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.DataMap.DataMapClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class DataMapClientOptions : Azure.Core.ClientOptions
    {
        public DataMapClientOptions(Azure.Analytics.Purview.DataMap.Generated.DataMapClientOptions.ServiceVersion version = Azure.Analytics.Purview.DataMap.Generated.DataMapClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}