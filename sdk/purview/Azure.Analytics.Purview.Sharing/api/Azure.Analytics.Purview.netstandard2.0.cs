namespace Azure.Analytics.Purview
{
    public partial class Client
    {
        protected Client() { }
        public Client(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.ClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ClientOptions : Azure.Core.ClientOptions
    {
        public ClientOptions(Azure.Analytics.Purview.Generated.ClientOptions.ServiceVersion version = Azure.Analytics.Purview.Generated.ClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}