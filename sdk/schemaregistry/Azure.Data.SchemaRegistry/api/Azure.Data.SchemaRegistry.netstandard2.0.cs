namespace Azure.Data.SchemaRegistry
{
    public partial class SchemaRegistryClient
    {
        protected SchemaRegistryClient() { }
        public SchemaRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public SchemaRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Data.SchemaRegistry.SchemaRegistryClientOptions options) { }
    }
    public partial class SchemaRegistryClientOptions : Azure.Core.ClientOptions
    {
        public SchemaRegistryClientOptions(Azure.Data.SchemaRegistry.SchemaRegistryClientOptions.ServiceVersion version = Azure.Data.SchemaRegistry.SchemaRegistryClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
}
namespace Azure.Data.SchemaRegistry.Models
{
    public partial class SchemaId
    {
        internal SchemaId() { }
        public string Id { get { throw null; } }
    }
}
