namespace Azure.AI.AutonomousDevelopmentPlatform
{
    public partial class AutonomousDevelopmentPlatformClient
    {
        protected AutonomousDevelopmentPlatformClient() { }
        public AutonomousDevelopmentPlatformClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class AutonomousDevelopmentPlatformClientOptions : Azure.Core.ClientOptions
    {
        public AutonomousDevelopmentPlatformClientOptions(Azure.AI.AutonomousDevelopmentPlatform.Generated.AutonomousDevelopmentPlatformClientOptions.ServiceVersion version = Azure.AI.AutonomousDevelopmentPlatform.Generated.AutonomousDevelopmentPlatformClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}