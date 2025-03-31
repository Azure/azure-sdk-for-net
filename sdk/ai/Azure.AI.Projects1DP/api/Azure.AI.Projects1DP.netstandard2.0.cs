namespace Azure.AI.Projects1DP
{
    public partial class Projects1DPClient
    {
        protected Projects1DPClient() { }
        public Projects1DPClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Projects1DP.Projects1DPClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class Projects1DPClientOptions : Azure.Core.ClientOptions
    {
        public Projects1DPClientOptions(Azure.AI.Projects1DP.Generated.Projects1DPClientOptions.ServiceVersion version = Azure.AI.Projects1DP.Generated.Projects1DPClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}