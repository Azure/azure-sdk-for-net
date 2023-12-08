namespace System.ClientModel
{
    public partial class ClientRequestException : System.Exception, System.Runtime.Serialization.ISerializable
    {
        public ClientRequestException(System.ClientModel.Primitives.PipelineResponse response, string? message = null, System.Exception? innerException = null) { }
        protected ClientRequestException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public ClientRequestException(string message, System.Exception? innerException = null) { }
        public int Status { get { throw null; } protected set { } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public System.ClientModel.Primitives.PipelineResponse? GetRawResponse() { throw null; }
    }
    public abstract partial class ClientResult
    {
        protected ClientResult(System.ClientModel.Primitives.PipelineResponse response) { }
        public static System.ClientModel.OptionalClientResult<T> FromOptionalValue<T>(T? value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.ClientResult FromResponse(System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.ClientResult<T> FromValue<T>(T value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse GetRawResponse() { throw null; }
    }
    public abstract partial class ClientResult<T> : System.ClientModel.OptionalClientResult<T>
    {
        protected ClientResult(T value, System.ClientModel.Primitives.PipelineResponse response) : base (default(T), default(System.ClientModel.Primitives.PipelineResponse)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public sealed override bool HasValue { get { throw null; } }
        public sealed override T Value { get { throw null; } }
    }
    public abstract partial class InputContent : System.IDisposable
    {
        protected InputContent() { }
        public static System.ClientModel.InputContent Create(System.BinaryData value) { throw null; }
        public static System.ClientModel.InputContent Create<T>(T model, System.ClientModel.ModelReaderWriterOptions? options = null) where T : System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken);
    }
    public partial class KeyCredential
    {
        public KeyCredential(string key) { }
        public string GetValue() { throw null; }
        public void Update(string key) { }
    }
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
    public abstract partial class OptionalClientResult<T> : System.ClientModel.ClientResult
    {
        protected OptionalClientResult(T? value, System.ClientModel.Primitives.PipelineResponse response) : base (default(System.ClientModel.Primitives.PipelineResponse)) { }
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
    }
    public partial class RequestOptions
    {
        public RequestOptions() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public System.ClientModel.Primitives.ErrorBehavior ErrorBehavior { get { throw null; } set { } }
        public void AddHeader(string name, string value) { }
        public void AddPolicy(System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelinePosition position) { }
        protected internal void Apply(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineMessageClassifier? messageClassifier = null) { }
    }
}
namespace System.ClientModel.Primitives
{
    public partial class ClientPipeline
    {
        internal ClientPipeline() { }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.Primitives.PipelineOptions options, params System.ClientModel.Primitives.PipelinePolicy[] perCallPolicies) { throw null; }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.Primitives.PipelineOptions options, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> perCallPolicies, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> perTryPolicies) { throw null; }
        public System.ClientModel.Primitives.PipelineMessage CreateMessage() { throw null; }
        public void Send(System.ClientModel.Primitives.PipelineMessage message) { }
        public System.Threading.Tasks.ValueTask SendAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    [System.FlagsAttribute]
    public enum ErrorBehavior
    {
        Default = 0,
        NoThrow = 1,
    }
    public partial class HttpClientPipelineTransport : System.ClientModel.Primitives.PipelineTransport, System.IDisposable
    {
        public HttpClientPipelineTransport() { }
        public HttpClientPipelineTransport(System.Net.Http.HttpClient client) { }
        protected override System.ClientModel.Primitives.PipelineMessage CreateMessageCore() { throw null; }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void OnReceivedResponse(System.ClientModel.Primitives.PipelineMessage message, System.Net.Http.HttpResponseMessage httpResponse) { }
        protected virtual void OnSendingRequest(System.ClientModel.Primitives.PipelineMessage message, System.Net.Http.HttpRequestMessage httpRequest) { }
        protected sealed override void ProcessCore(System.ClientModel.Primitives.PipelineMessage message) { }
        protected sealed override System.Threading.Tasks.ValueTask ProcessCoreAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
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
    public partial class KeyCredentialAuthenticationPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        public KeyCredentialAuthenticationPolicy(System.ClientModel.KeyCredential credential, string headerName, string? keyPrefix = null) { }
        public sealed override void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { }
        public sealed override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { throw null; }
    }
    public abstract partial class MessageHeaders
    {
        protected MessageHeaders() { }
        public abstract int Count { get; }
        public abstract void Add(string name, string value);
        public abstract bool Remove(string name);
        public abstract void Set(string name, string value);
        public abstract bool TryGetHeaders(out System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.IEnumerable<string>>> headers);
        public abstract bool TryGetHeaders(out System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> headers);
        public abstract bool TryGetValue(string name, out string? value);
        public abstract bool TryGetValues(string name, out System.Collections.Generic.IEnumerable<string>? values);
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
    public partial class PipelineMessage : System.IDisposable
    {
        protected internal PipelineMessage(System.ClientModel.Primitives.PipelineRequest request) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelineMessageClassifier? MessageClassifier { get { throw null; } protected internal set { } }
        public System.ClientModel.Primitives.PipelineRequest Request { get { throw null; } }
        public System.ClientModel.Primitives.PipelineResponse? Response { get { throw null; } protected internal set { } }
        public void Apply(System.ClientModel.RequestOptions options, System.ClientModel.Primitives.PipelineMessageClassifier? messageClassifier = null) { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void SetProperty(System.Type type, object value) { }
        public bool TryGetProperty(System.Type type, out object? value) { throw null; }
    }
    public partial class PipelineMessageClassifier
    {
        protected internal PipelineMessageClassifier() { }
        public virtual bool IsErrorResponse(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public partial class PipelineOptions
    {
        public PipelineOptions() { }
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelinePolicy? RetryPolicy { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelineTransport? Transport { get { throw null; } set { } }
        public void AddPolicy(System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelinePosition position) { }
    }
    public abstract partial class PipelinePolicy
    {
        protected PipelinePolicy() { }
        public abstract void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline);
    }
    public enum PipelinePosition
    {
        PerCall = 0,
        PerTry = 1,
    }
    public abstract partial class PipelineProcessor
    {
        protected PipelineProcessor() { }
        public abstract bool ProcessNext();
        public abstract System.Threading.Tasks.ValueTask<bool> ProcessNextAsync();
    }
    public abstract partial class PipelineRequest : System.IDisposable
    {
        protected PipelineRequest() { }
        public System.ClientModel.InputContent? Content { get { throw null; } set { } }
        public System.ClientModel.Primitives.MessageHeaders Headers { get { throw null; } }
        public string Method { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public abstract void Dispose();
        protected abstract System.ClientModel.InputContent? GetContentCore();
        protected abstract System.ClientModel.Primitives.MessageHeaders GetHeadersCore();
        protected abstract string GetMethodCore();
        protected abstract System.Uri GetUriCore();
        protected abstract void SetContentCore(System.ClientModel.InputContent? content);
        protected abstract void SetMethodCore(string method);
        protected abstract void SetUriCore(System.Uri uri);
    }
    public abstract partial class PipelineResponse : System.IDisposable
    {
        protected PipelineResponse() { }
        public System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public System.ClientModel.Primitives.MessageHeaders Headers { get { throw null; } }
        public bool IsError { get { throw null; } protected internal set { } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public abstract void Dispose();
        protected abstract System.ClientModel.Primitives.MessageHeaders GetHeadersCore();
    }
    public abstract partial class PipelineTransport : System.ClientModel.Primitives.PipelinePolicy
    {
        protected PipelineTransport() { }
        public System.ClientModel.Primitives.PipelineMessage CreateMessage() { throw null; }
        protected abstract System.ClientModel.Primitives.PipelineMessage CreateMessageCore();
        public void Process(System.ClientModel.Primitives.PipelineMessage message) { }
        public sealed override void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { }
        public System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
        public sealed override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { throw null; }
        protected abstract void ProcessCore(System.ClientModel.Primitives.PipelineMessage message);
        protected abstract System.Threading.Tasks.ValueTask ProcessCoreAsync(System.ClientModel.Primitives.PipelineMessage message);
    }
    public partial class ResponseBufferingPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        public ResponseBufferingPolicy(System.TimeSpan networkTimeout) { }
        public sealed override void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { }
        public sealed override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { throw null; }
        public static void SetBufferResponse(System.ClientModel.Primitives.PipelineMessage message, bool bufferResponse) { }
        public static void SetNetworkTimeout(System.ClientModel.Primitives.PipelineMessage message, System.TimeSpan networkTimeout) { }
        public static bool TryGetBufferResponse(System.ClientModel.Primitives.PipelineMessage message, out bool bufferResponse) { throw null; }
        public static bool TryGetNetworkTimeout(System.ClientModel.Primitives.PipelineMessage message, out System.TimeSpan networkTimeout) { throw null; }
    }
    public partial class ResponseStatusClassifier : System.ClientModel.Primitives.PipelineMessageClassifier
    {
        public ResponseStatusClassifier(System.ReadOnlySpan<ushort> successStatusCodes) { }
        public sealed override bool IsErrorResponse(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
}
