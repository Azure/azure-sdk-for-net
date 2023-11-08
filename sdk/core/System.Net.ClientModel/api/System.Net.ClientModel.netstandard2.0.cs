namespace System.Net.ClientModel
{
    public static partial class ModelReaderWriter
    {
        public static object? Read(System.BinaryData data, System.Type returnType, System.Net.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public static T? Read<T>(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions? options = null) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
        public static System.BinaryData Write(object model, System.Net.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.BinaryData Write<T>(T model, System.Net.ClientModel.ModelReaderWriterOptions? options = null) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
    }
    public partial class ModelReaderWriterOptions
    {
        public ModelReaderWriterOptions(string format) { }
        public string Format { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterOptions Json { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterOptions Wire { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterOptions Xml { get { throw null; } }
    }
}
namespace System.Net.ClientModel.Core
{
    public partial interface IJsonModel<out T> : System.Net.ClientModel.Core.IModel<T>
    {
        T Read(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options);
        void Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options);
    }
    public partial interface IModel<out T>
    {
        string GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options);
        T Read(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options);
        System.BinaryData Write(System.Net.ClientModel.ModelReaderWriterOptions options);
    }
    public partial class ModelJsonConverter : System.Text.Json.Serialization.JsonConverter<System.Net.ClientModel.Core.IJsonModel<object>>
    {
        public ModelJsonConverter() { }
        public ModelJsonConverter(System.Net.ClientModel.ModelReaderWriterOptions options) { }
        public System.Net.ClientModel.ModelReaderWriterOptions ModelReaderWriterOptions { get { throw null; } }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override System.Net.ClientModel.Core.IJsonModel<object> Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.Core.IJsonModel<object> value, System.Text.Json.JsonSerializerOptions options) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public sealed partial class ModelReaderProxyAttribute : System.Attribute
    {
        public ModelReaderProxyAttribute(System.Type proxyType) { }
        public System.Type ProxyType { get { throw null; } }
    }
}
