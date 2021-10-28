namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    public partial class SchemaRegistryAvroEncoder
    {
        public SchemaRegistryAvroEncoder(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroObjectEncoderOptions options = null) { }
        public object DecodeMessageBody(Azure.Messaging.MessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public object DecodeMessageBody(Azure.Messaging.ReadOnlyMessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DecodeMessageBodyAsync(Azure.Messaging.MessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DecodeMessageBodyAsync(Azure.Messaging.ReadOnlyMessageWithMetadata message, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public void EncodeMessageBody(Azure.Messaging.MessageWithMetadata message, object value, System.Type inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.Tasks.Task EncodeMessageBodyAsync(Azure.Messaging.MessageWithMetadata message, object value, System.Type inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SchemaRegistryAvroEncoderExtensions
    {
        public static object DecodeMessageBody(this Azure.Messaging.ReadOnlyMessageWithMetadata message, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroEncoder avroEncoder, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<object> DecodeMessageBodyAsync(this Azure.Messaging.ReadOnlyMessageWithMetadata message, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroEncoder avroEncoder, System.Type returnType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static void EncodeMessageBody(this Azure.Messaging.MessageWithMetadata message, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroEncoder avroEncoder, object value, System.Type inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public static System.Threading.Tasks.Task EncodeMessageBodyAsync(this Azure.Messaging.MessageWithMetadata message, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroEncoder avroEncoder, object value, System.Type inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchemaRegistryAvroObjectEncoderOptions
    {
        public SchemaRegistryAvroObjectEncoderOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
