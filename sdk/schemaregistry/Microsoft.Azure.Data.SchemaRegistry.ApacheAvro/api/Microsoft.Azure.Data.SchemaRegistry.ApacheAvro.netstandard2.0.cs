namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    public partial class LruCache<TKey, TValue> : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.IEnumerable where TKey : notnull
    {
        public LruCache(int capacity) { }
        public int Count { get { throw null; } }
        public int TotalLength { get { throw null; } }
        public void AddOrUpdate(TKey key, TValue? val, int length) { }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGet(TKey key, out TValue? value) { throw null; }
    }
    public partial class SchemaRegistryAvroSerializer
    {
        protected SchemaRegistryAvroSerializer() { }
        public SchemaRegistryAvroSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client) { }
        public SchemaRegistryAvroSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName) { }
        public SchemaRegistryAvroSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroSerializerOptions options) { }
        public object Deserialize(Azure.Messaging.MessageContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<object> DeserializeAsync(Azure.Messaging.MessageContent content, System.Type dataType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TData> DeserializeAsync<TData>(Azure.Messaging.MessageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public TData Deserialize<TData>(Azure.Messaging.MessageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Messaging.MessageContent Serialize(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Messaging.MessageContent> SerializeAsync(object data, System.Type dataType = null, System.Type messageType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<TMessage> SerializeAsync<TMessage, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TMessage : Azure.Messaging.MessageContent, new() { throw null; }
        public TMessage Serialize<TMessage, TData>(TData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TMessage : Azure.Messaging.MessageContent, new() { throw null; }
    }
    public partial class SchemaRegistryAvroSerializerOptions
    {
        public SchemaRegistryAvroSerializerOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
