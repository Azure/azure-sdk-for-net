namespace System.ClientModel
{
    public partial class ApiKeyCredential
    {
        public ApiKeyCredential(string key) { }
        public void Deconstruct(out string key) { throw null; }
        public void Update(string key) { }
    }
    public partial class ClientResult
    {
        protected ClientResult(System.ClientModel.Primitives.PipelineResponse response) { }
        public static System.ClientModel.OptionalClientResult<T> FromOptionalValue<T>(T? value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.ClientResult FromResponse(System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.ClientResult<T> FromValue<T>(T value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse GetRawResponse() { throw null; }
    }
    public partial class ClientResultException : System.Exception, System.Runtime.Serialization.ISerializable
    {
        public ClientResultException(System.ClientModel.Primitives.PipelineResponse response, System.Exception? innerException = null) { }
        protected ClientResultException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public ClientResultException(string message, System.ClientModel.Primitives.PipelineResponse? response = null, System.Exception? innerException = null) { }
        public int Status { get { throw null; } protected set { } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public System.ClientModel.Primitives.PipelineResponse? GetRawResponse() { throw null; }
    }
    public partial class ClientResult<T> : System.ClientModel.OptionalClientResult<T>
    {
        protected internal ClientResult(T value, System.ClientModel.Primitives.PipelineResponse response) : base (default(T), default(System.ClientModel.Primitives.PipelineResponse)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public sealed override bool HasValue { get { throw null; } }
        public sealed override T Value { get { throw null; } }
    }
    public partial class OptionalClientResult<T> : System.ClientModel.ClientResult
    {
        protected internal OptionalClientResult(T? value, System.ClientModel.Primitives.PipelineResponse response) : base (default(System.ClientModel.Primitives.PipelineResponse)) { }
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
    }
}
namespace System.ClientModel.Primitives
{
    public partial interface IJsonModel<out T> : System.ClientModel.Primitives.IPersistableModel<T>
    {
        T Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options);
        void Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options);
    }
    public partial interface IPersistableModel<out T>
    {
        T Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options);
        string GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options);
        System.BinaryData Write(System.ClientModel.Primitives.ModelReaderWriterOptions options);
    }
    public abstract partial class MessageHeaders : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>>, System.Collections.IEnumerable
    {
        protected MessageHeaders() { }
        public abstract void Add(string name, string value);
        public abstract System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> GetEnumerator();
        public abstract bool Remove(string name);
        public abstract void Set(string name, string value);
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public abstract bool TryGetValue(string name, out string? value);
        public abstract bool TryGetValues(string name, out System.Collections.Generic.IEnumerable<string>? values);
    }
    public static partial class ModelReaderWriter
    {
        public static object? Read(System.BinaryData data, System.Type returnType, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) { throw null; }
        public static T? Read<T>(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) where T : System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
        public static System.BinaryData Write(object model, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.BinaryData Write<T>(T model, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) where T : System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
    }
    public partial class ModelReaderWriterOptions
    {
        public ModelReaderWriterOptions(string format) { }
        public string Format { get { throw null; } }
        public static System.ClientModel.Primitives.ModelReaderWriterOptions Json { get { throw null; } }
        public static System.ClientModel.Primitives.ModelReaderWriterOptions Xml { get { throw null; } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public sealed partial class PersistableModelProxyAttribute : System.Attribute
    {
        public PersistableModelProxyAttribute(System.Type proxyType) { }
        public System.Type ProxyType { get { throw null; } }
    }
    public abstract partial class PipelineResponse : System.IDisposable
    {
        protected PipelineResponse() { }
        public System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public System.ClientModel.Primitives.MessageHeaders Headers { get { throw null; } }
        public virtual bool IsError { get { throw null; } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public abstract void Dispose();
        protected abstract System.ClientModel.Primitives.MessageHeaders GetHeadersCore();
        protected virtual void SetIsErrorCore(bool isError) { }
    }
}
