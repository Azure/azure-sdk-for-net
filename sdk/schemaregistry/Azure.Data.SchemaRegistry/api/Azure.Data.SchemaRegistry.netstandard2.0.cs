namespace Azure.Data.SchemaRegistry
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchemaFormat : System.IEquatable<Azure.Data.SchemaRegistry.SchemaFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchemaFormat(string value) { throw null; }
        public static Azure.Data.SchemaRegistry.SchemaFormat Avro { get { throw null; } }
        public static Azure.Data.SchemaRegistry.SchemaFormat Custom { get { throw null; } }
        public static Azure.Data.SchemaRegistry.SchemaFormat Json { get { throw null; } }
        public static Azure.Data.SchemaRegistry.SchemaFormat Protobuf { get { throw null; } }
        public bool Equals(Azure.Data.SchemaRegistry.SchemaFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.SchemaRegistry.SchemaFormat left, Azure.Data.SchemaRegistry.SchemaFormat right) { throw null; }
        public static implicit operator Azure.Data.SchemaRegistry.SchemaFormat (string value) { throw null; }
        public static bool operator !=(Azure.Data.SchemaRegistry.SchemaFormat left, Azure.Data.SchemaRegistry.SchemaFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SchemaProperties
    {
        internal SchemaProperties() { }
        public Azure.Data.SchemaRegistry.SchemaFormat Format { get { throw null; } }
        public string GroupName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public int Version { get { throw null; } }
    }
    public partial class SchemaRegistryClient
    {
        protected SchemaRegistryClient() { }
        public SchemaRegistryClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential) { }
        public SchemaRegistryClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential, Azure.Data.SchemaRegistry.SchemaRegistryClientOptions options) { }
        public string FullyQualifiedNamespace { get { throw null; } }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaRegistrySchema> GetSchema(string groupName, string schemaName, int schemaVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaRegistrySchema> GetSchema(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaRegistrySchema>> GetSchemaAsync(string groupName, string schemaName, int schemaVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaRegistrySchema>> GetSchemaAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties> GetSchemaProperties(string groupName, string schemaName, string schemaDefinition, Azure.Data.SchemaRegistry.SchemaFormat format, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties>> GetSchemaPropertiesAsync(string groupName, string schemaName, string schemaDefinition, Azure.Data.SchemaRegistry.SchemaFormat format, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties> RegisterSchema(string groupName, string schemaName, string schemaDefinition, Azure.Data.SchemaRegistry.SchemaFormat format, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties>> RegisterSchemaAsync(string groupName, string schemaName, string schemaDefinition, Azure.Data.SchemaRegistry.SchemaFormat format, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchemaRegistryClientOptions : Azure.Core.ClientOptions
    {
        public SchemaRegistryClientOptions(Azure.Data.SchemaRegistry.SchemaRegistryClientOptions.ServiceVersion version = Azure.Data.SchemaRegistry.SchemaRegistryClientOptions.ServiceVersion.V2023_07) { }
        public enum ServiceVersion
        {
            V2021_10 = 1,
            V2022_10 = 2,
            V2023_07 = 3,
        }
    }
    public static partial class SchemaRegistryModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Data.SchemaRegistry.SchemaProperties SchemaProperties(Azure.Data.SchemaRegistry.SchemaFormat format, string schemaId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Data.SchemaRegistry.SchemaProperties SchemaProperties(Azure.Data.SchemaRegistry.SchemaFormat format, string schemaId, string groupName, string name) { throw null; }
        public static Azure.Data.SchemaRegistry.SchemaProperties SchemaProperties(Azure.Data.SchemaRegistry.SchemaFormat format, string schemaId, string groupName, string name, int version) { throw null; }
        public static Azure.Data.SchemaRegistry.SchemaRegistrySchema SchemaRegistrySchema(Azure.Data.SchemaRegistry.SchemaProperties properties, string definition) { throw null; }
    }
    public partial class SchemaRegistrySchema
    {
        internal SchemaRegistrySchema() { }
        public string Definition { get { throw null; } }
        public Azure.Data.SchemaRegistry.SchemaProperties Properties { get { throw null; } }
    }
}
namespace Azure.Data.SchemaRegistry.Serialization
{
    public partial class SchemaRegistrySerializer
    {
        protected SchemaRegistrySerializer() { }
        public SchemaRegistrySerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, Azure.Core.SchemaValidator schemaValidator) { }
        public SchemaRegistrySerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, Azure.Core.SchemaValidator schemaValidator, Azure.Data.SchemaRegistry.Serialization.SchemaRegistrySerializerOptions serializerOptions) { }
        public SchemaRegistrySerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Azure.Core.SchemaValidator schemaValidator) { }
        public SchemaRegistrySerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Azure.Core.SchemaValidator schemaValidator, Azure.Data.SchemaRegistry.Serialization.SchemaRegistrySerializerOptions serializerOptions) { }
        public object Deserialize(Azure.Messaging.MessageContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DeserializeAsync(Azure.Messaging.MessageContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TData> DeserializeAsync<TData>(Azure.Messaging.MessageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public TData Deserialize<TData>(Azure.Messaging.MessageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Messaging.MessageContent Serialize(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Messaging.MessageContent> SerializeAsync(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TMessage> SerializeAsync<TMessage, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TMessage : Azure.Messaging.MessageContent, new() { throw null; }
        public TMessage Serialize<TMessage, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TMessage : Azure.Messaging.MessageContent, new() { throw null; }
    }
    public partial class SchemaRegistrySerializerOptions
    {
        public SchemaRegistrySerializerOptions() { }
        public Azure.Data.SchemaRegistry.SchemaFormat Format { get { throw null; } set { } }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
    }
}
