namespace Azure.AI.Projects
{
    public partial class OneDPClient
    {
        protected OneDPClient() { }
        public OneDPClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.ProjectsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class OneDPClientOptions : Azure.Core.ClientOptions
    {
        public OneDPClientOptions(Azure.AI.Projects.GeneratedClientOptions.ServiceVersion version = Azure.AI.Projects.GeneratedClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}
