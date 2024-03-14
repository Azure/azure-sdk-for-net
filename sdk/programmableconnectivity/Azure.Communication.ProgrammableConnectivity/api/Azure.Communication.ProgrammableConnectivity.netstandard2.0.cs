namespace Azure.Communication.ProgrammableConnectivity
{
    public partial class ProgrammableConnectivityClient
    {
        protected ProgrammableConnectivityClient() { }
        public ProgrammableConnectivityClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Communication.ProgrammableConnectivity.ProgrammableConnectivityClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ProgrammableConnectivityClientOptions : Azure.Core.ClientOptions
    {
        public ProgrammableConnectivityClientOptions(Azure.Communication.ProgrammableConnectivity.Generated.ProgrammableConnectivityClientOptions.ServiceVersion version = Azure.Communication.ProgrammableConnectivity.Generated.ProgrammableConnectivityClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}