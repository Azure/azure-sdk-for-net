namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    public partial class SchemaRegistryAvroEncoder
    {
        public SchemaRegistryAvroEncoder(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroEncoderOptions options = null) { }
        public object DecodeMessageData(Azure.MessageWithMetadata message, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DecodeMessageDataAsync(Azure.MessageWithMetadata message, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TData> DecodeMessageDataAsync<TData>(Azure.MessageWithMetadata message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public TData DecodeMessageData<TData>(Azure.MessageWithMetadata message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.MessageWithMetadata EncodeMessageData(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.MessageWithMetadata> EncodeMessageDataAsync(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TMessage> EncodeMessageDataAsync<TMessage, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TMessage : Azure.MessageWithMetadata, new() { throw null; }
        public TMessage EncodeMessageData<TMessage, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TMessage : Azure.MessageWithMetadata, new() { throw null; }
    }
    public partial class SchemaRegistryAvroEncoderOptions
    {
        public SchemaRegistryAvroEncoderOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
