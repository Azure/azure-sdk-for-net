namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    public partial class SchemaRegistryAvroObjectSerializer : Azure.Core.Serialization.ObjectSerializer
    {
        public SchemaRegistryAvroObjectSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.SchemaRegistryAvroObjectSerializerOptions options = null) { }
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
