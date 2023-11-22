namespace System.ClientModel
{
    public static partial class ModelReaderWriter
    {
        public static object? Read(System.BinaryData data, System.Type returnType, System.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public static T? Read<T>(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions? options = null) where T : System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
        public static System.BinaryData Write(object model, System.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.BinaryData Write<T>(T model, System.ClientModel.ModelReaderWriterOptions? options = null) where T : System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
    }
    public partial class ModelReaderWriterOptions
    {
        public ModelReaderWriterOptions(string format) { }
        public string Format { get { throw null; } }
        public static System.ClientModel.ModelReaderWriterOptions Json { get { throw null; } }
        public static System.ClientModel.ModelReaderWriterOptions Xml { get { throw null; } }
    }
}
namespace System.ClientModel.Primitives
{
    public partial interface IJsonModel<out T> : System.ClientModel.Primitives.IPersistableModel<T>
    {
        T Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options);
        void Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options);
    }
    public partial interface IPersistableModel<out T>
    {
        T Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options);
        string GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options);
        System.BinaryData Write(System.ClientModel.ModelReaderWriterOptions options);
    }
    public partial class ModelJsonConverter : System.Text.Json.Serialization.JsonConverter<System.ClientModel.Primitives.IJsonModel<object>>
    {
        public ModelJsonConverter() { }
        public ModelJsonConverter(System.ClientModel.ModelReaderWriterOptions options) { }
        public System.ClientModel.ModelReaderWriterOptions Options { get { throw null; } }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override System.ClientModel.Primitives.IJsonModel<object> Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.IJsonModel<object> value, System.Text.Json.JsonSerializerOptions options) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public sealed partial class PersistableModelProxyAttribute : System.Attribute
    {
        public PersistableModelProxyAttribute(System.Type proxyType) { }
        public System.Type ProxyType { get { throw null; } }
    }
}
