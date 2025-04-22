namespace Azure.AI.Agents.Persistent
{
    public partial class PersistentClient
    {
        protected PersistentClient() { }
        public PersistentClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Agents.Persistent.PersistentClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class PersistentClientOptions : Azure.Core.ClientOptions
    {
        public PersistentClientOptions(Azure.AI.Agents.Persistent.Generated.PersistentClientOptions.ServiceVersion version = Azure.AI.Agents.Persistent.Generated.PersistentClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}