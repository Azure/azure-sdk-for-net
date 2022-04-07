namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    public partial class AvroSerializationException : System.Exception
    {
        public AvroSerializationException() { }
        protected AvroSerializationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public AvroSerializationException(string message) { }
        public AvroSerializationException(string message, System.Exception innerException) { }
        public AvroSerializationException(string message, string serializedSchemaId, System.Exception innerException) { }
        public string SerializedSchemaId { get { throw null; } set { } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
    public partial class SchemaRegistryAvroSerializer
    {
        public SchemaRegistryAvroSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroSerializerOptions options = null) { }
        public object Deserialize(Azure.BinaryContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DeserializeAsync(Azure.BinaryContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TData> DeserializeAsync<TData>(Azure.BinaryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public TData Deserialize<TData>(Azure.BinaryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.BinaryContent Serialize(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.BinaryContent> SerializeAsync(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TEnvelope> SerializeAsync<TEnvelope, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TEnvelope : Azure.BinaryContent, new() { throw null; }
        public TEnvelope Serialize<TEnvelope, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TEnvelope : Azure.BinaryContent, new() { throw null; }
    }
    public partial class SchemaRegistryAvroSerializerOptions
    {
        public SchemaRegistryAvroSerializerOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
