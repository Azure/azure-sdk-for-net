namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestingClient
    {
        protected LoadTestingClient() { }
        public LoadTestingClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Developer.LoadTesting.LoadTestingClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class LoadTestingClientOptions : Azure.Core.ClientOptions
    {
        public LoadTestingClientOptions(Azure.Developer.LoadTesting.Generated.LoadTestingClientOptions.ServiceVersion version = Azure.Developer.LoadTesting.Generated.LoadTestingClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}