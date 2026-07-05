namespace Azure.Core.Serialization
{
    public partial class MicrosoftSpatialGeoJsonConverter : System.Text.Json.Serialization.JsonConverter<object>
    {
        public MicrosoftSpatialGeoJsonConverter() { }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override object Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, object value, System.Text.Json.JsonSerializerOptions options) { }
    }
}
