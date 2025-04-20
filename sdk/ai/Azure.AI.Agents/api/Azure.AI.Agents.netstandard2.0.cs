namespace Azure.AI.Agents
{
    public partial class AgentsClient
    {
        protected AgentsClient() { }
        public AgentsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Agents.AgentsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class AgentsClientOptions : Azure.Core.ClientOptions
    {
        public AgentsClientOptions(Azure.AI.Agents.Generated.AgentsClientOptions.ServiceVersion version = Azure.AI.Agents.Generated.AgentsClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}