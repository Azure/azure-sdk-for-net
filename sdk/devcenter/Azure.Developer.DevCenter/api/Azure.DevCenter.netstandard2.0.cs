namespace Azure.DevCenter
{
    public partial class DevCenterClient
    {
        protected DevCenterClient() { }
        public DevCenterClient(string endpoint, Azure.Core.TokenCredential credential, Azure.DevCenterClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class DevCenterClientOptions : Azure.Core.ClientOptions
    {
        public DevCenterClientOptions(Azure.DevCenter.Generated.DevCenterClientOptions.ServiceVersion version = Azure.DevCenter.Generated.DevCenterClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}
