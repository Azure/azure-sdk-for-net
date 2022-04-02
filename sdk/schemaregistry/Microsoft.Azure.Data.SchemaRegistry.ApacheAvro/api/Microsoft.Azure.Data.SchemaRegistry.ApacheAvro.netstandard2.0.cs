namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    public partial class SchemaRegistryAvroException : System.Exception
    {
        public SchemaRegistryAvroException() { }
        protected SchemaRegistryAvroException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public SchemaRegistryAvroException(string message) { }
        public SchemaRegistryAvroException(string message, System.Exception innerException) { }
        public SchemaRegistryAvroException(string message, string schemaId, System.Exception innerException) { }
        public string SchemaId { get { throw null; } set { } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
    public partial class SchemaRegistryAvroSerializer
    {
        public SchemaRegistryAvroSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client) { }
        public SchemaRegistryAvroSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName) { }
        public SchemaRegistryAvroSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroSerializerOptions options) { }
        public object Deserialize(Azure.Messaging.MessageContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DeserializeAsync(Azure.Messaging.MessageContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TData> DeserializeAsync<TData>(Azure.Messaging.MessageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public TData Deserialize<TData>(Azure.Messaging.MessageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Messaging.MessageContent Serialize(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Messaging.MessageContent> SerializeAsync(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TEnvelope> SerializeAsync<TEnvelope, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TEnvelope : Azure.Messaging.MessageContent, new() { throw null; }
        public TEnvelope Serialize<TEnvelope, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TEnvelope : Azure.Messaging.MessageContent, new() { throw null; }
    }
    public partial class SchemaRegistryAvroSerializerOptions
    {
        public SchemaRegistryAvroSerializerOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
