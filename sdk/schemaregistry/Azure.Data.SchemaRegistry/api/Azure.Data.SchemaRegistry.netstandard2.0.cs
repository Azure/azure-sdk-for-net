namespace Azure.Data.SchemaRegistry
{
    public partial class SchemaProperties
    {
        internal SchemaProperties() { }
        public string GroupName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class SchemaRegistryClient
    {
        protected SchemaRegistryClient() { }
        public SchemaRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public SchemaRegistryClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Data.SchemaRegistry.SchemaRegistryClientOptions options) { }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties> GetSchema(string groupName, string schemaName, string serializationType, string schemaContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties> GetSchema(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties>> GetSchemaAsync(string groupName, string schemaName, string serializationType, string schemaContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties>> GetSchemaAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties> RegisterSchema(string groupName, string schemaName, string serializationType, string schemaContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties>> RegisterSchemaAsync(string groupName, string schemaName, string serializationType, string schemaContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
