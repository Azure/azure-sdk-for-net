namespace Azure.Core.Serialization
{
    public partial class GeographyConverter : System.Text.Json.Serialization.JsonConverter<Microsoft.Spatial.Geography>
    {
        public GeographyConverter() { }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override Microsoft.Spatial.Geography Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, Microsoft.Spatial.Geography value, System.Text.Json.JsonSerializerOptions options) { }
    }
}
