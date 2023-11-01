namespace System.Net.ClientModel
{
    public static partial class ModelReaderWriter
    {
        public static object? Read(System.BinaryData data, [System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)] System.Type returnType, System.Net.ClientModel.ModelReaderWriterFormat format) { throw null; }
        public static object? Read(System.BinaryData data, [System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)] System.Type returnType, System.Net.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public static T? Read<T>(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterFormat format) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
        public static T? Read<T>(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions? options = null) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
        public static System.BinaryData Write(object model, System.Net.ClientModel.ModelReaderWriterFormat format) { throw null; }
        public static System.BinaryData Write(object model, System.Net.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.BinaryData Write<T>(T model, System.Net.ClientModel.ModelReaderWriterFormat format) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
        public static System.BinaryData Write<T>(T model, System.Net.ClientModel.ModelReaderWriterOptions? options = null) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelReaderWriterFormat : System.IEquatable<System.Net.ClientModel.ModelReaderWriterFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelReaderWriterFormat(string value) { throw null; }
        public static System.Net.ClientModel.ModelReaderWriterFormat Json { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterFormat Wire { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterFormat Xml { get { throw null; } }
        public bool Equals(System.Net.ClientModel.ModelReaderWriterFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(System.Net.ClientModel.ModelReaderWriterFormat left, System.Net.ClientModel.ModelReaderWriterFormat right) { throw null; }
        public static implicit operator System.Net.ClientModel.ModelReaderWriterFormat (string value) { throw null; }
        public static bool operator !=(System.Net.ClientModel.ModelReaderWriterFormat left, System.Net.ClientModel.ModelReaderWriterFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelReaderWriterOptions
    {
        public ModelReaderWriterOptions() { }
        public ModelReaderWriterOptions(System.Net.ClientModel.ModelReaderWriterFormat format) { }
        public static System.Net.ClientModel.ModelReaderWriterOptions DefaultWireOptions { get { throw null; } }
        public System.Net.ClientModel.ModelReaderWriterFormat Format { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterOptions GetOptions(System.Net.ClientModel.ModelReaderWriterFormat format) { throw null; }
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
        System.Net.ClientModel.ModelReaderWriterFormat GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options);
        T Read(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options);
        System.BinaryData Write(System.Net.ClientModel.ModelReaderWriterOptions options);
    }
    [System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute("The constructors of the type being deserialized are dynamically accessed and may be trimmed.")]
    public partial class ModelJsonConverter : System.Text.Json.Serialization.JsonConverter<System.Net.ClientModel.Core.IJsonModel<object>>
    {
        public ModelJsonConverter() { }
        public ModelJsonConverter(System.Net.ClientModel.ModelReaderWriterFormat format) { }
        public ModelJsonConverter(System.Net.ClientModel.ModelReaderWriterOptions options) { }
        public System.Net.ClientModel.ModelReaderWriterOptions ModelReaderWriterOptions { get { throw null; } }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override System.Net.ClientModel.Core.IJsonModel<object> Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.Core.IJsonModel<object> value, System.Text.Json.JsonSerializerOptions options) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public sealed partial class ModelReaderProxyAttribute : System.Attribute
    {
        public ModelReaderProxyAttribute([System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)] System.Type proxyType) { }
        [System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)]
        public System.Type ProxyType { get { throw null; } }
    }
}
