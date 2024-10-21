namespace System.ClientModel
{
    public partial class ApiKeyCredential
    {
        public ApiKeyCredential(string key) { }
        public void Deconstruct(out string key) { throw null; }
        public void Update(string key) { }
    }
    public abstract partial class AsyncCollectionResult<T> : System.ClientModel.Primitives.AsyncCollectionResult, System.Collections.Generic.IAsyncEnumerable<T>
    {
        protected internal AsyncCollectionResult() { }
        public System.Collections.Generic.IAsyncEnumerator<T> GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected abstract System.Collections.Generic.IAsyncEnumerable<T> GetValuesFromPageAsync(System.ClientModel.ClientResult page);
    }
    public abstract partial class BinaryContent : System.IDisposable
    {
        protected BinaryContent() { }
        public static System.ClientModel.BinaryContent Create(System.BinaryData value) { throw null; }
        public static System.ClientModel.BinaryContent Create(System.IO.Stream stream) { throw null; }
        public static System.ClientModel.BinaryContent Create<T>(T model, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) where T : System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial class ClientResult
    {
        protected ClientResult(System.ClientModel.Primitives.PipelineResponse response) { }
        public static System.ClientModel.ClientResult<T?> FromOptionalValue<T>(T? value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.ClientResult FromResponse(System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.ClientResult<T> FromValue<T>(T value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse GetRawResponse() { throw null; }
    }
    public partial class ClientResultException : System.Exception
    {
        public ClientResultException(System.ClientModel.Primitives.PipelineResponse response, System.Exception? innerException = null) { }
        public ClientResultException(string message, System.ClientModel.Primitives.PipelineResponse? response = null, System.Exception? innerException = null) { }
        public int Status { get { throw null; } protected set { } }
        public static System.Threading.Tasks.Task<System.ClientModel.ClientResultException> CreateAsync(System.ClientModel.Primitives.PipelineResponse response, System.Exception? innerException = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse? GetRawResponse() { throw null; }
    }
    public partial class ClientResult<T> : System.ClientModel.ClientResult
    {
        protected internal ClientResult(T value, System.ClientModel.Primitives.PipelineResponse response) : base (default(System.ClientModel.Primitives.PipelineResponse)) { }
        public virtual T Value { get { throw null; } }
        public static implicit operator T (System.ClientModel.ClientResult<T> result) { throw null; }
    }
    public abstract partial class CollectionResult<T> : System.ClientModel.Primitives.CollectionResult, System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable
    {
        protected internal CollectionResult() { }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() { throw null; }
        protected abstract System.Collections.Generic.IEnumerable<T> GetValuesFromPage(System.ClientModel.ClientResult page);
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContinuationToken
    {
        protected ContinuationToken() { }
        protected ContinuationToken(System.BinaryData bytes) { }
        public static System.ClientModel.ContinuationToken FromBytes(System.BinaryData bytes) { throw null; }
        public virtual System.BinaryData ToBytes() { throw null; }
    }
}
namespace System.ClientModel.Primitives
{
    public partial class ApiKeyAuthenticationPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        internal ApiKeyAuthenticationPolicy() { }
        public static System.ClientModel.Primitives.ApiKeyAuthenticationPolicy CreateBasicAuthorizationPolicy(System.ClientModel.ApiKeyCredential credential) { throw null; }
        public static System.ClientModel.Primitives.ApiKeyAuthenticationPolicy CreateBearerAuthorizationPolicy(System.ClientModel.ApiKeyCredential credential) { throw null; }
        public static System.ClientModel.Primitives.ApiKeyAuthenticationPolicy CreateHeaderApiKeyPolicy(System.ClientModel.ApiKeyCredential credential, string headerName, string? keyPrefix = null) { throw null; }
        public sealed override void Process(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { }
        public sealed override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { throw null; }
    }
    public abstract partial class AsyncCollectionResult
    {
        protected AsyncCollectionResult() { }
        public abstract System.ClientModel.ContinuationToken? GetContinuationToken(System.ClientModel.ClientResult page);
        public abstract System.Collections.Generic.IAsyncEnumerable<System.ClientModel.ClientResult> GetRawPagesAsync();
    }
    [System.FlagsAttribute]
    public enum ClientErrorBehaviors
    {
        Default = 0,
        NoThrow = 1,
    }
    public sealed partial class ClientPipeline
    {
        internal ClientPipeline() { }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.Primitives.ClientPipelineOptions? options = null) { throw null; }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.Primitives.ClientPipelineOptions options, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> perCallPolicies, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> perTryPolicies, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> beforeTransportPolicies) { throw null; }
        public System.ClientModel.Primitives.PipelineMessage CreateMessage() { throw null; }
        public void Send(System.ClientModel.Primitives.PipelineMessage message) { }
        public System.Threading.Tasks.ValueTask SendAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public partial class ClientPipelineOptions
    {
        public ClientPipelineOptions() { }
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelinePolicy? RetryPolicy { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelineTransport? Transport { get { throw null; } set { } }
        public void AddPolicy(System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelinePosition position) { }
        protected void AssertNotFrozen() { }
        public virtual void Freeze() { }
    }
    public partial class ClientRetryPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        public ClientRetryPolicy(int maxRetries = 3) { }
        public static System.ClientModel.Primitives.ClientRetryPolicy Default { get { throw null; } }
        protected virtual System.TimeSpan GetNextDelay(System.ClientModel.Primitives.PipelineMessage message, int tryCount) { throw null; }
        protected virtual void OnRequestSent(System.ClientModel.Primitives.PipelineMessage message) { }
        protected virtual System.Threading.Tasks.ValueTask OnRequestSentAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
        protected virtual void OnSendingRequest(System.ClientModel.Primitives.PipelineMessage message) { }
        protected virtual System.Threading.Tasks.ValueTask OnSendingRequestAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
        protected virtual void OnTryComplete(System.ClientModel.Primitives.PipelineMessage message) { }
        public sealed override void Process(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { }
        public sealed override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { throw null; }
        protected virtual bool ShouldRetry(System.ClientModel.Primitives.PipelineMessage message, System.Exception? exception) { throw null; }
        protected virtual System.Threading.Tasks.ValueTask<bool> ShouldRetryAsync(System.ClientModel.Primitives.PipelineMessage message, System.Exception? exception) { throw null; }
        protected virtual void Wait(System.TimeSpan time, System.Threading.CancellationToken cancellationToken) { }
        protected virtual System.Threading.Tasks.Task WaitAsync(System.TimeSpan time, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public abstract partial class CollectionResult
    {
        protected CollectionResult() { }
        public abstract System.ClientModel.ContinuationToken? GetContinuationToken(System.ClientModel.ClientResult page);
        public abstract System.Collections.Generic.IEnumerable<System.ClientModel.ClientResult> GetRawPages();
    }
    public partial class HttpClientPipelineTransport : System.ClientModel.Primitives.PipelineTransport, System.IDisposable
    {
        public HttpClientPipelineTransport() { }
        public HttpClientPipelineTransport(System.Net.Http.HttpClient client) { }
        public static System.ClientModel.Primitives.HttpClientPipelineTransport Shared { get { throw null; } }
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
        T Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options);
        void Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options);
    }
    public partial interface IPersistableModel<out T>
    {
        T Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options);
        string GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options);
        System.BinaryData Write(System.ClientModel.Primitives.ModelReaderWriterOptions options);
    }
    public partial class JsonModelConverter : System.Text.Json.Serialization.JsonConverter<System.ClientModel.Primitives.IJsonModel<object>>
    {
        public JsonModelConverter() { }
        public JsonModelConverter(System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override System.ClientModel.Primitives.IJsonModel<object> Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.IJsonModel<object> value, System.Text.Json.JsonSerializerOptions options) { }
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
    public abstract partial class OperationResult
    {
        protected OperationResult(System.ClientModel.Primitives.PipelineResponse response) { }
        public bool HasCompleted { get { throw null; } protected set { } }
        public abstract System.ClientModel.ContinuationToken? RehydrationToken { get; protected set; }
        public System.ClientModel.Primitives.PipelineResponse GetRawResponse() { throw null; }
        protected void SetRawResponse(System.ClientModel.Primitives.PipelineResponse response) { }
        public abstract System.ClientModel.ClientResult UpdateStatus(System.ClientModel.Primitives.RequestOptions? options = null);
        public abstract System.Threading.Tasks.ValueTask<System.ClientModel.ClientResult> UpdateStatusAsync(System.ClientModel.Primitives.RequestOptions? options = null);
        public virtual void WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.ValueTask WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public bool BufferResponse { get { throw null; } set { } }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } protected internal set { } }
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelineRequest Request { get { throw null; } }
        public System.ClientModel.Primitives.PipelineResponse? Response { get { throw null; } protected internal set { } }
        public System.ClientModel.Primitives.PipelineMessageClassifier ResponseClassifier { get { throw null; } set { } }
        public void Apply(System.ClientModel.Primitives.RequestOptions? options) { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public System.ClientModel.Primitives.PipelineResponse? ExtractResponse() { throw null; }
        public void SetProperty(System.Type key, object? value) { }
        public bool TryGetProperty(System.Type key, out object? value) { throw null; }
    }
    public abstract partial class PipelineMessageClassifier
    {
        protected PipelineMessageClassifier() { }
        public static System.ClientModel.Primitives.PipelineMessageClassifier Default { get { throw null; } }
        public static System.ClientModel.Primitives.PipelineMessageClassifier Create(System.ReadOnlySpan<ushort> successStatusCodes) { throw null; }
        public abstract bool TryClassify(System.ClientModel.Primitives.PipelineMessage message, out bool isError);
        public abstract bool TryClassify(System.ClientModel.Primitives.PipelineMessage message, System.Exception? exception, out bool isRetriable);
    }
    public abstract partial class PipelinePolicy
    {
        protected PipelinePolicy() { }
        public abstract void Process(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex);
        protected static void ProcessNext(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { }
        protected static System.Threading.Tasks.ValueTask ProcessNextAsync(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { throw null; }
    }
    public enum PipelinePosition
    {
        PerCall = 0,
        PerTry = 1,
        BeforeTransport = 2,
    }
    public abstract partial class PipelineRequest : System.IDisposable
    {
        protected PipelineRequest() { }
        public System.ClientModel.BinaryContent? Content { get { throw null; } set { } }
        protected abstract System.ClientModel.BinaryContent? ContentCore { get; set; }
        public System.ClientModel.Primitives.PipelineRequestHeaders Headers { get { throw null; } }
        protected abstract System.ClientModel.Primitives.PipelineRequestHeaders HeadersCore { get; }
        public string Method { get { throw null; } set { } }
        protected abstract string MethodCore { get; set; }
        public System.Uri? Uri { get { throw null; } set { } }
        protected abstract System.Uri? UriCore { get; set; }
        public abstract void Dispose();
    }
    public abstract partial class PipelineRequestHeaders : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>>, System.Collections.IEnumerable
    {
        protected PipelineRequestHeaders() { }
        public abstract void Add(string name, string value);
        public abstract System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> GetEnumerator();
        public abstract bool Remove(string name);
        public abstract void Set(string name, string value);
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public abstract bool TryGetValue(string name, out string? value);
        public abstract bool TryGetValues(string name, out System.Collections.Generic.IEnumerable<string>? values);
    }
    public abstract partial class PipelineResponse : System.IDisposable
    {
        protected PipelineResponse() { }
        public abstract System.BinaryData Content { get; }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public System.ClientModel.Primitives.PipelineResponseHeaders Headers { get { throw null; } }
        protected abstract System.ClientModel.Primitives.PipelineResponseHeaders HeadersCore { get; }
        public virtual bool IsError { get { throw null; } }
        protected internal virtual bool IsErrorCore { get { throw null; } set { } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public abstract System.BinaryData BufferContent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.ValueTask<System.BinaryData> BufferContentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract void Dispose();
    }
    public abstract partial class PipelineResponseHeaders : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>>, System.Collections.IEnumerable
    {
        protected PipelineResponseHeaders() { }
        public abstract System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public abstract bool TryGetValue(string name, out string? value);
        public abstract bool TryGetValues(string name, out System.Collections.Generic.IEnumerable<string>? values);
    }
    public abstract partial class PipelineTransport : System.ClientModel.Primitives.PipelinePolicy
    {
        protected PipelineTransport() { }
        public System.ClientModel.Primitives.PipelineMessage CreateMessage() { throw null; }
        protected abstract System.ClientModel.Primitives.PipelineMessage CreateMessageCore();
        public void Process(System.ClientModel.Primitives.PipelineMessage message) { }
        public sealed override void Process(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { }
        public System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
        public sealed override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { throw null; }
        protected abstract void ProcessCore(System.ClientModel.Primitives.PipelineMessage message);
        protected abstract System.Threading.Tasks.ValueTask ProcessCoreAsync(System.ClientModel.Primitives.PipelineMessage message);
    }
    public partial class RequestOptions
    {
        public RequestOptions() { }
        public bool BufferResponse { get { throw null; } set { } }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public System.ClientModel.Primitives.ClientErrorBehaviors ErrorOptions { get { throw null; } set { } }
        public void AddHeader(string name, string value) { }
        public void AddPolicy(System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelinePosition position) { }
        protected internal virtual void Apply(System.ClientModel.Primitives.PipelineMessage message) { }
        protected void AssertNotFrozen() { }
        public virtual void Freeze() { }
        public void SetHeader(string name, string value) { }
    }
}
namespace System.ClientModel.Primitives.TwoWayPipeline
{
    public sealed partial class TwoWayPipeline
    {
        internal TwoWayPipeline() { }
        public static System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipeline Create(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineOptions options) { throw null; }
        public static System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipeline Create(System.ReadOnlySpan<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> policies) { throw null; }
        public System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage CreateMessage() { throw null; }
        public System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineServiceMessage> GetResponseStream() { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineServiceMessage> GetResponseStreamAsync() { throw null; }
        public void Send(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage message) { }
        public System.Threading.Tasks.Task SendAsync(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage message) { throw null; }
    }
    public abstract partial class TwoWayPipelineClientMessage
    {
        protected TwoWayPipelineClientMessage() { }
        public System.BinaryData? Content { get { throw null; } set { } }
        public void SetProperty(System.Type key, object? value) { }
        public bool TryGetProperty(System.Type key, out object? value) { throw null; }
    }
    public partial class TwoWayPipelineOptions
    {
        public TwoWayPipelineOptions() { }
    }
    public abstract partial class TwoWayPipelinePolicy
    {
        protected TwoWayPipelinePolicy() { }
        public abstract void Process(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage clientMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex);
        public abstract void Process(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineServiceMessage serviceMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage clientMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineServiceMessage serviceMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex);
        protected static void ProcessNext(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage clientMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex) { }
        protected static void ProcessNext(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineServiceMessage serviceMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex) { }
        protected static System.Threading.Tasks.ValueTask ProcessNextAsync(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage clientMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex) { throw null; }
        protected static System.Threading.Tasks.ValueTask ProcessNextAsync(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineServiceMessage serviceMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex) { throw null; }
    }
    public abstract partial class TwoWayPipelineServiceMessage
    {
        protected TwoWayPipelineServiceMessage() { }
        public System.BinaryData? Content { get { throw null; } set { } }
        public void SetProperty(System.Type key, object? value) { }
        public bool TryGetProperty(System.Type key, out object? value) { throw null; }
    }
    public partial class TwoWayPipelineTransport : System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy
    {
        public TwoWayPipelineTransport() { }
        public override void Process(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage clientMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex) { }
        public override void Process(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineServiceMessage serviceMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineClientMessage clientMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex) { throw null; }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelineServiceMessage serviceMessage, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.TwoWayPipeline.TwoWayPipelinePolicy> pipeline, int currentIndex) { throw null; }
    }
    public partial class WebSocketTwoWayPipelineTransport
    {
        public WebSocketTwoWayPipelineTransport() { }
    }
}
