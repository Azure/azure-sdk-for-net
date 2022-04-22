namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    public partial class SchemaRegistryAvroEncoder
    {
        public SchemaRegistryAvroEncoder(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroObjectEncoderOptions options = null) { }
        public object DecodeMessageData(Azure.Messaging.MessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DecodeMessageDataAsync(Azure.Messaging.MessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<T> EncodeMessageDataAsync<T>(object data, System.Type inputType = null, System.Func<System.BinaryData, T> messageFactory = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Messaging.MessageWithMetadata { throw null; }
        public T EncodeMessageData<T>(object data, System.Type inputType = null, System.Func<System.BinaryData, T> messageFactory = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.Messaging.MessageWithMetadata { throw null; }
    }
    public partial class SchemaRegistryAvroObjectEncoderOptions
    {
        public SchemaRegistryAvroObjectEncoderOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
