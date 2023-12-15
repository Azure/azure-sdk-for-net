namespace Azure.Core.Serialization
{
    public partial class NewtonsoftJsonETagConverter : Newtonsoft.Json.JsonConverter
    {
        public NewtonsoftJsonETagConverter() { }
        public override bool CanConvert(System.Type objectType) { throw null; }
        public override object? ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) { throw null; }
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) { }
    }
    public partial class NewtonsoftJsonObjectSerializer : Azure.Core.Serialization.ObjectSerializer, Azure.Core.Serialization.IMemberNameConverter
    {
        public NewtonsoftJsonObjectSerializer() { }
        public NewtonsoftJsonObjectSerializer(Newtonsoft.Json.JsonSerializerSettings settings) { }
        string? Azure.Core.Serialization.IMemberNameConverter.ConvertMemberName(System.Reflection.MemberInfo member) { throw null; }
        public static Newtonsoft.Json.JsonSerializerSettings CreateJsonSerializerSettings() { throw null; }
        public override object Deserialize(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<object?> DeserializeAsync(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void Serialize(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { }
        public override System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
