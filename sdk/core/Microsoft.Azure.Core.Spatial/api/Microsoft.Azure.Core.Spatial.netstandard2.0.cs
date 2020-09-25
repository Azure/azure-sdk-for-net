namespace Azure.Core.Serialization
{
    public partial class GeographyPointConverter : System.Text.Json.Serialization.JsonConverter<Microsoft.Spatial.GeographyPoint>
    {
        public GeographyPointConverter() { }
        public override Microsoft.Spatial.GeographyPoint Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, Microsoft.Spatial.GeographyPoint value, System.Text.Json.JsonSerializerOptions options) { }
    }
}
