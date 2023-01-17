namespace Azure.Template.
{
    public partial class Client
    {
        protected Client() { }
        public Client(string endpoint, Azure.Core.TokenCredential credential, Azure.Template..ClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ClientOptions : Azure.Core.ClientOptions
    {
        public ClientOptions(Azure.Template..Generated.ClientOptions.ServiceVersion version = Azure.Template..Generated.ClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}