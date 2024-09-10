namespace System.ClientModel
{
    public partial class ApiKeyCredential
    {
        public ApiKeyCredential(string key) { }
        public void Deconstruct(out string key) { throw null; }
        public static implicit operator System.ClientModel.ApiKeyCredential (string key) { throw null; }
        public void Update(string key) { }
    }
    public abstract partial class AsyncCollectionResult<T> : System.ClientModel.ClientResult, System.Collections.Generic.IAsyncEnumerable<T>
    {
        protected internal AsyncCollectionResult() { }
        protected internal AsyncCollectionResult(System.ClientModel.Primitives.PipelineResponse response) { }
        public abstract System.Collections.Generic.IAsyncEnumerator<T> GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public abstract partial class AsyncPageCollection<T> : System.Collections.Generic.IAsyncEnumerable<System.ClientModel.PageResult<T>>
    {
        protected AsyncPageCollection() { }
        public System.Collections.Generic.IAsyncEnumerable<T> GetAllValuesAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected abstract System.Collections.Generic.IAsyncEnumerator<System.ClientModel.PageResult<T>> GetAsyncEnumeratorCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public System.Threading.Tasks.Task<System.ClientModel.PageResult<T>> GetCurrentPageAsync() { throw null; }
        protected abstract System.Threading.Tasks.Task<System.ClientModel.PageResult<T>> GetCurrentPageAsyncCore();
        System.Collections.Generic.IAsyncEnumerator<System.ClientModel.PageResult<T>> System.Collections.Generic.IAsyncEnumerable<System.ClientModel.PageResult<T>>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
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
        protected ClientResult() { }
        protected ClientResult(System.ClientModel.Primitives.PipelineResponse response) { }
        public static System.ClientModel.ClientResult<T?> FromOptionalValue<T>(T? value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.ClientResult FromResponse(System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.ClientResult<T> FromValue<T>(T value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse GetRawResponse() { throw null; }
        protected void SetRawResponse(System.ClientModel.Primitives.PipelineResponse response) { }
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
        protected internal ClientResult(T value, System.ClientModel.Primitives.PipelineResponse response) { }
        public virtual T Value { get { throw null; } }
        public static implicit operator T (System.ClientModel.ClientResult<T> result) { throw null; }
    }
    public abstract partial class CollectionResult<T> : System.ClientModel.ClientResult, System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable
    {
        protected internal CollectionResult() { }
        protected internal CollectionResult(System.ClientModel.Primitives.PipelineResponse response) { }
        public abstract System.Collections.Generic.IEnumerator<T> GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContinuationToken
    {
        protected ContinuationToken() { }
        protected ContinuationToken(System.BinaryData bytes) { }
        public static System.ClientModel.ContinuationToken FromBytes(System.BinaryData bytes) { throw null; }
        public virtual System.BinaryData ToBytes() { throw null; }
    }
    public abstract partial class PageCollection<T> : System.Collections.Generic.IEnumerable<System.ClientModel.PageResult<T>>, System.Collections.IEnumerable
    {
        protected PageCollection() { }
        public System.Collections.Generic.IEnumerable<T> GetAllValues() { throw null; }
        public System.ClientModel.PageResult<T> GetCurrentPage() { throw null; }
        protected abstract System.ClientModel.PageResult<T> GetCurrentPageCore();
        protected abstract System.Collections.Generic.IEnumerator<System.ClientModel.PageResult<T>> GetEnumeratorCore();
        System.Collections.Generic.IEnumerator<System.ClientModel.PageResult<T>> System.Collections.Generic.IEnumerable<System.ClientModel.PageResult<T>>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PageResult<T> : System.ClientModel.ClientResult
    {
        internal PageResult() { }
        public System.ClientModel.ContinuationToken? NextPageToken { get { throw null; } }
        public System.ClientModel.ContinuationToken PageToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<T> Values { get { throw null; } }
        public static System.ClientModel.PageResult<T> Create(System.Collections.Generic.IReadOnlyList<T> values, System.ClientModel.ContinuationToken pageToken, System.ClientModel.ContinuationToken? nextPageToken, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
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
        public object? ProxiedModel { get { throw null; } }
        public static System.ClientModel.Primitives.ModelReaderWriterOptions Xml { get { throw null; } }
        public void AddProxy<T>(System.ClientModel.Primitives.IPersistableModel<T> proxy) { }
        public System.ClientModel.Primitives.IJsonModel<T> ResolveProxy<T>(System.ClientModel.Primitives.IJsonModel<T> proxiedModel) { throw null; }
        public System.ClientModel.Primitives.IPersistableModel<T> ResolveProxy<T>(System.ClientModel.Primitives.IPersistableModel<T> model) { throw null; }
        public bool TryGetProxy<T>(out System.ClientModel.Primitives.IJsonModel<T>? proxy) { throw null; }
        public bool TryGetProxy<T>(out System.ClientModel.Primitives.IPersistableModel<T>? proxy) { throw null; }
    }
    public abstract partial class OperationResult : System.ClientModel.ClientResult
    {
        protected OperationResult(System.ClientModel.Primitives.PipelineResponse response) { }
        public abstract bool IsCompleted { get; protected set; }
        public abstract System.ClientModel.ContinuationToken? RehydrationToken { get; protected set; }
        public abstract void WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
