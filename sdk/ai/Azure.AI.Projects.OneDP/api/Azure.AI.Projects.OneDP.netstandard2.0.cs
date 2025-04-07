namespace Azure.AI.Projects.OneDP
{
    public partial class OneDPClient
    {
        protected OneDPClient() { }
        public OneDPClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Projects.OneDP.OneDPClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class OneDPClientOptions : Azure.Core.ClientOptions
    {
        public OneDPClientOptions(Azure.AI.Projects.OneDP.Generated.OneDPClientOptions.ServiceVersion version = Azure.AI.Projects.OneDP.Generated.OneDPClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}