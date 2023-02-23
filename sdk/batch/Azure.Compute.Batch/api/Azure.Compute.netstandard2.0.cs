namespace Azure.Compute
{
    public partial class Client
    {
        protected Client() { }
        public Client(string endpoint, Azure.Core.TokenCredential credential, Azure.Compute.ClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ClientOptions : Azure.Core.ClientOptions
    {
        public ClientOptions(Azure.Compute.Generated.ClientOptions.ServiceVersion version = Azure.Compute.Generated.ClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}