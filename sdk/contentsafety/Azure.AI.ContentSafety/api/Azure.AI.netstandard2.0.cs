namespace Azure.AI
{
    public partial class Client
    {
        protected Client() { }
        public Client(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.ClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ClientOptions : Azure.Core.ClientOptions
    {
        public ClientOptions(Azure.AI.Generated.ClientOptions.ServiceVersion version = Azure.AI.Generated.ClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}