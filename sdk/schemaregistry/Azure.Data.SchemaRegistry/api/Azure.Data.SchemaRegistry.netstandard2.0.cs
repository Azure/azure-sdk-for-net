namespace Azure.Data.SchemaRegistry
{
    public partial class SchemaProperties
    {
        internal SchemaProperties() { }
        public string Content { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class SchemaRegistryClient
    {
        protected SchemaRegistryClient() { }
        public SchemaRegistryClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public SchemaRegistryClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Data.SchemaRegistry.SchemaRegistryClientOptions options) { }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties> GetSchema(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties>> GetSchemaAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties> GetSchemaId(string groupName, string schemaName, Azure.Data.SchemaRegistry.Models.SerializationType serializationType, string schemaContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties>> GetSchemaIdAsync(string groupName, string schemaName, Azure.Data.SchemaRegistry.Models.SerializationType serializationType, string schemaContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties> RegisterSchema(string groupName, string schemaName, Azure.Data.SchemaRegistry.Models.SerializationType serializationType, string schemaContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.SchemaRegistry.SchemaProperties>> RegisterSchemaAsync(string groupName, string schemaName, Azure.Data.SchemaRegistry.Models.SerializationType serializationType, string schemaContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchemaRegistryClientOptions : Azure.Core.ClientOptions
    {
        public SchemaRegistryClientOptions(Azure.Data.SchemaRegistry.SchemaRegistryClientOptions.ServiceVersion version = Azure.Data.SchemaRegistry.SchemaRegistryClientOptions.ServiceVersion.V2017_04) { }
        public enum ServiceVersion
        {
            V2017_04 = 0,
        }
    }
}
namespace Azure.Data.SchemaRegistry.Avro
{
    public partial class SchemaRegistryAvroObjectSerializer : Azure.Core.Serialization.ObjectSerializer
    {
        public SchemaRegistryAvroObjectSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Azure.Data.SchemaRegistry.Avro.SchemaRegistryAvroObjectSerializerOptions options = null) { }
        public override object Deserialize(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<object> DeserializeAsync(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void Serialize(System.IO.Stream stream, object value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { }
        public override System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class SchemaRegistryAvroObjectSerializerOptions
    {
        public SchemaRegistryAvroObjectSerializerOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
namespace Azure.Data.SchemaRegistry.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SerializationType : System.IEquatable<Azure.Data.SchemaRegistry.Models.SerializationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SerializationType(string value) { throw null; }
        public static Azure.Data.SchemaRegistry.Models.SerializationType Avro { get { throw null; } }
        public bool Equals(Azure.Data.SchemaRegistry.Models.SerializationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.SchemaRegistry.Models.SerializationType left, Azure.Data.SchemaRegistry.Models.SerializationType right) { throw null; }
        public static implicit operator Azure.Data.SchemaRegistry.Models.SerializationType (string value) { throw null; }
        public static bool operator !=(Azure.Data.SchemaRegistry.Models.SerializationType left, Azure.Data.SchemaRegistry.Models.SerializationType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
