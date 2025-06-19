namespace Azure.Analytics.PlanetaryComputer
{
    public partial class PlanetaryComputerClient
    {
        protected PlanetaryComputerClient() { }
        public PlanetaryComputerClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.PlanetaryComputer.PlanetaryComputerClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class PlanetaryComputerClientOptions : Azure.Core.ClientOptions
    {
        public PlanetaryComputerClientOptions(Azure.Analytics.PlanetaryComputer.Generated.PlanetaryComputerClientOptions.ServiceVersion version = Azure.Analytics.PlanetaryComputer.Generated.PlanetaryComputerClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}