namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    public partial class SchemaRegistryAvroEncoder
    {
        public SchemaRegistryAvroEncoder(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroObjectEncoderOptions options = null) { }
        public object DecodeMessageData(Azure.Messaging.MessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public object DecodeMessageData(Azure.Messaging.ReadOnlyMessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DecodeMessageDataAsync(Azure.Messaging.MessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DecodeMessageDataAsync(Azure.Messaging.ReadOnlyMessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public void EncodeMessageData(Azure.Messaging.MessageWithMetadata message, object data, System.Type inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.Tasks.Task EncodeMessageDataAsync(Azure.Messaging.MessageWithMetadata message, object data, System.Type inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchemaRegistryAvroObjectEncoderOptions
    {
        public SchemaRegistryAvroObjectEncoderOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
