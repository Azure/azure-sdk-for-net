namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema
{
    public abstract partial class SchemaRegistryJsonSchemaGenerator
    {
        protected SchemaRegistryJsonSchemaGenerator() { }
        public abstract string GenerateSchema(System.Type dataType);
        public abstract void Validate(object data, System.Type dataType, string schemaDefinition);
    }
    public partial class SchemaRegistryJsonSerializer
    {
        protected SchemaRegistryJsonSerializer() { }
        public SchemaRegistryJsonSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, Microsoft.Azure.Data.SchemaRegistry.JsonSchema.SchemaRegistryJsonSchemaGenerator jsonSchemaGenerator) { }
        public SchemaRegistryJsonSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, Microsoft.Azure.Data.SchemaRegistry.JsonSchema.SchemaRegistryJsonSchemaGenerator jsonSchemaGenerator, Microsoft.Azure.Data.SchemaRegistry.JsonSchema.SchemaRegistryJsonSerializerOptions serializerOptions) { }
        public SchemaRegistryJsonSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.JsonSchema.SchemaRegistryJsonSchemaGenerator jsonSchemaGenerator) { }
        public SchemaRegistryJsonSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.JsonSchema.SchemaRegistryJsonSchemaGenerator jsonSchemaGenerator, Microsoft.Azure.Data.SchemaRegistry.JsonSchema.SchemaRegistryJsonSerializerOptions serializerOptions) { }
        public object Deserialize(Azure.Messaging.MessageContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DeserializeAsync(Azure.Messaging.MessageContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TData> DeserializeAsync<TData>(Azure.Messaging.MessageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public TData Deserialize<TData>(Azure.Messaging.MessageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Messaging.MessageContent Serialize(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Messaging.MessageContent> SerializeAsync(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TMessage> SerializeAsync<TMessage, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TMessage : Azure.Messaging.MessageContent, new() { throw null; }
        public TMessage Serialize<TMessage, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TMessage : Azure.Messaging.MessageContent, new() { throw null; }
    }
    public partial class SchemaRegistryJsonSerializerOptions
    {
        public SchemaRegistryJsonSerializerOptions() { }
        public Azure.Core.Serialization.ObjectSerializer ObjectSerializer { get { throw null; } set { } }
    }
}
