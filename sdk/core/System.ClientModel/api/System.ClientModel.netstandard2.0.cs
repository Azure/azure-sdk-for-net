namespace System.ClientModel
{
    public partial class ClientRequestException : System.Exception, System.Runtime.Serialization.ISerializable
    {
        public ClientRequestException(System.ClientModel.Primitives.PipelineResponse response) { }
        public ClientRequestException(System.ClientModel.Primitives.PipelineResponse? response, string? message, System.Exception? innerException = null) { }
        protected ClientRequestException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public int Status { get { throw null; } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public virtual System.ClientModel.Primitives.PipelineResponse? GetRawResponse() { throw null; }
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
    public partial class NullableOutputMessage<T> : System.ClientModel.OutputMessage
    {
        internal NullableOutputMessage() { }
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
        public override System.ClientModel.Primitives.PipelineResponse GetRawResponse() { throw null; }
    }
    public abstract partial class OutputMessage
    {
        protected OutputMessage() { }
        public static System.ClientModel.NullableOutputMessage<T> FromNullableValue<T>(T? value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.OutputMessage FromResponse(System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.OutputMessage<T> FromValue<T>(T value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public abstract System.ClientModel.Primitives.PipelineResponse GetRawResponse();
    }
    public partial class OutputMessage<T> : System.ClientModel.NullableOutputMessage<T>
    {
        internal OutputMessage() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasValue { get { throw null; } }
        public override T Value { get { throw null; } }
    }
    public partial class RequestOptions
    {
        public RequestOptions() { }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public virtual System.ClientModel.Primitives.ErrorBehavior ErrorBehavior { get { throw null; } set { } }
        public virtual System.ClientModel.Primitives.MessageHeaders RequestHeaders { get { throw null; } }
        public void AddPolicy(System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelinePosition position) { }
        protected internal void Apply(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.MessageClassifier? messageClassifier = null) { }
    }
    public abstract partial class ServiceClientOptions
    {
        protected ServiceClientOptions() { }
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelinePolicy? RetryPolicy { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelineTransport? Transport { get { throw null; } set { } }
        public void AddPolicy(System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelinePosition position) { }
    }
}
namespace System.ClientModel.Primitives
{
    public partial class ClientPipeline
    {
        internal ClientPipeline() { }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.ServiceClientOptions options, params System.ClientModel.Primitives.PipelinePolicy[] perCallPolicies) { throw null; }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.ServiceClientOptions options, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> perCallPolicies, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> perTryPolicies) { throw null; }
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
        public override void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { throw null; }
    }
    public partial class MessageClassifier
    {
        protected internal MessageClassifier() { }
        public virtual bool IsError(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public partial class MessageDelay
    {
        public MessageDelay() { }
        protected virtual System.TimeSpan GetDelay(System.ClientModel.Primitives.PipelineMessage message, int delayCount) { throw null; }
        protected virtual void OnDelayComplete(System.ClientModel.Primitives.PipelineMessage message) { }
        protected virtual void Wait(System.TimeSpan duration, System.Threading.CancellationToken cancellationToken) { }
        protected virtual System.Threading.Tasks.Task WaitAsync(System.TimeSpan duration, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public System.ClientModel.Primitives.MessageClassifier? MessageClassifier { get { throw null; } protected internal set { } }
        public virtual System.ClientModel.Primitives.PipelineRequest Request { get { throw null; } }
        public virtual System.ClientModel.Primitives.PipelineResponse Response { get { throw null; } protected internal set { } }
        public void Apply(System.ClientModel.RequestOptions options, System.ClientModel.Primitives.MessageClassifier? messageClassifier = null) { }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void SetProperty(System.Type type, object value) { }
        public bool TryGetProperty(System.Type type, out object? value) { throw null; }
        public bool TryGetResponse(out System.ClientModel.Primitives.PipelineResponse response) { throw null; }
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
        public abstract int Length { get; }
        public abstract bool ProcessNext();
        public abstract System.Threading.Tasks.ValueTask<bool> ProcessNextAsync();
    }
    public abstract partial class PipelineRequest : System.IDisposable
    {
        protected PipelineRequest() { }
        public abstract System.ClientModel.InputContent? Content { get; set; }
        public abstract System.ClientModel.Primitives.MessageHeaders Headers { get; }
        public abstract string Method { get; set; }
        public abstract System.Uri Uri { get; set; }
        public static System.ClientModel.Primitives.PipelineRequest Create() { throw null; }
        public abstract void Dispose();
    }
    public abstract partial class PipelineResponse : System.IDisposable
    {
        protected PipelineResponse() { }
        public System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public abstract System.ClientModel.Primitives.MessageHeaders Headers { get; }
        public bool IsError { get { throw null; } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public static System.ClientModel.Primitives.PipelineResponse Create(System.Net.Http.HttpResponseMessage response) { throw null; }
        public abstract void Dispose();
    }
    public abstract partial class PipelineTransport : System.ClientModel.Primitives.PipelinePolicy, System.IDisposable
    {
        protected PipelineTransport() { }
        public static System.ClientModel.Primitives.PipelineTransport Create(System.Net.Http.HttpClient client, System.Action<System.ClientModel.Primitives.PipelineMessage, System.Net.Http.HttpRequestMessage>? onSendingRequest = null, System.Action<System.ClientModel.Primitives.PipelineMessage, System.Net.Http.HttpResponseMessage>? onReceivedResponse = null) { throw null; }
        public abstract System.ClientModel.Primitives.PipelineMessage CreateMessage();
        public virtual void Dispose() { }
        public abstract void Process(System.ClientModel.Primitives.PipelineMessage message);
        public override void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { }
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message);
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { throw null; }
    }
    public partial class RequestRetryPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        public RequestRetryPolicy() { }
        public RequestRetryPolicy(int maxRetries, System.ClientModel.Primitives.MessageDelay delay) { }
        protected virtual void OnRequestSent(System.ClientModel.Primitives.PipelineMessage message) { }
        protected virtual System.Threading.Tasks.ValueTask OnRequestSentAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
        protected virtual void OnSendingRequest(System.ClientModel.Primitives.PipelineMessage message) { }
        protected virtual System.Threading.Tasks.ValueTask OnSendingRequestAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
        public override void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { throw null; }
        protected virtual bool ShouldRetry(System.ClientModel.Primitives.PipelineMessage message, System.Exception? exception) { throw null; }
        protected virtual System.Threading.Tasks.ValueTask<bool> ShouldRetryAsync(System.ClientModel.Primitives.PipelineMessage message, System.Exception? exception) { throw null; }
    }
    public partial class ResponseBufferingPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        public ResponseBufferingPolicy(System.TimeSpan networkTimeout) { }
        public override void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { throw null; }
        public static void SetBufferResponse(System.ClientModel.Primitives.PipelineMessage message, bool bufferResponse) { }
        public static void SetNetworkTimeout(System.ClientModel.Primitives.PipelineMessage message, System.TimeSpan networkTimeout) { }
        public static bool TryGetBufferResponse(System.ClientModel.Primitives.PipelineMessage message, out bool bufferResponse) { throw null; }
        public static bool TryGetNetworkTimeout(System.ClientModel.Primitives.PipelineMessage message, out System.TimeSpan networkTimeout) { throw null; }
    }
    public partial class ResponseStatusClassifier : System.ClientModel.Primitives.MessageClassifier
    {
        public ResponseStatusClassifier(System.ReadOnlySpan<ushort> successStatusCodes) { }
        public override bool IsError(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
}
