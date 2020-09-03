namespace Azure.Data.SchemaRegistry.Avro
{
    public partial class AvroObjectSerializer : Azure.Core.Serialization.ObjectSerializer
    {
        public AvroObjectSerializer(Azure.Data.SchemaRegistry.SchemaRegistryClient client, string groupName, Azure.Data.SchemaRegistry.Avro.AvroObjectSerializerOptions options = null) { }
        public override object Deserialize(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<object> DeserializeAsync(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void Serialize(System.IO.Stream stream, object value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { }
        public override System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class AvroObjectSerializerOptions
    {
        public AvroObjectSerializerOptions() { }
        public bool AutoRegisterSchemas { get { throw null; } set { } }
    }
}
