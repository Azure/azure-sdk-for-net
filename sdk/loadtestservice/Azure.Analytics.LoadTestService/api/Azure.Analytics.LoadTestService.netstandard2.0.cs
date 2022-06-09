namespace Azure.Analytics.LoadTestService
{
    public partial class LoadTestServiceClient
    {
        protected LoadTestServiceClient() { }
        public LoadTestServiceClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.LoadTestService.LoadTestServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class LoadTestServiceClientOptions : Azure.Core.ClientOptions
    {
        public LoadTestServiceClientOptions(Azure.Analytics.LoadTestService.Generated.LoadTestServiceClientOptions.ServiceVersion version = Azure.Analytics.LoadTestService.Generated.LoadTestServiceClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}