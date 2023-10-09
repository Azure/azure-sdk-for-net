namespace System.ServiceModel.Rest
{
    [System.FlagsAttribute]
    public enum ErrorBehavior
    {
        Default = 0,
        NoThrow = 1,
    }
    public partial class InvocationOptions
    {
        public InvocationOptions() { }
        public virtual bool BufferResponse { get { throw null; } set { } }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public static System.Threading.CancellationToken DefaultCancellationToken { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.ResponseErrorClassifier DefaultResponseClassifier { get { throw null; } set { } }
        public virtual System.ServiceModel.Rest.ErrorBehavior ErrorBehavior { get { throw null; } set { } }
        public virtual System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public virtual System.ServiceModel.Rest.Core.ResponseErrorClassifier ResponseClassifier { get { throw null; } set { } }
    }
    public partial class KeyCredential
    {
        public KeyCredential(string key) { }
        public bool TryGetKey(out string key) { throw null; }
        public void Update(string key) { }
    }
    public partial class MessageFailedException : System.Exception
    {
        protected MessageFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public MessageFailedException(System.ServiceModel.Rest.Core.PipelineResponse response) { }
        protected MessageFailedException(System.ServiceModel.Rest.Core.PipelineResponse response, string message, System.Exception? innerException) { }
        public int Status { get { throw null; } }
    }
    public partial class NullableResult<T> : System.ServiceModel.Rest.Result
    {
        public NullableResult(T? value, System.ServiceModel.Rest.Core.PipelineResponse response) { }
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
        public override System.ServiceModel.Rest.Core.PipelineResponse GetRawResponse() { throw null; }
    }
    public partial class PipelineOptions
    {
        public PipelineOptions() { }
        public static System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>? DefaultLoggingPolicy { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>? DefaultRetryPolicy { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.Pipeline.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>? DefaultTransport { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>? LoggingPolicy { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>[]? PerCallPolicies { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>[]? PerTryPolicies { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>? RetryPolicy { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>? Transport { get { throw null; } set { } }
    }
    public abstract partial class Result
    {
        protected Result() { }
        public static System.ServiceModel.Rest.Result FromResponse(System.ServiceModel.Rest.Core.PipelineResponse response) { throw null; }
        public static System.ServiceModel.Rest.Result<T> FromValue<T>(T value, System.ServiceModel.Rest.Core.PipelineResponse response) { throw null; }
        public abstract System.ServiceModel.Rest.Core.PipelineResponse GetRawResponse();
    }
    public partial class Result<T> : System.ServiceModel.Rest.NullableResult<T>
    {
        public Result(T value, System.ServiceModel.Rest.Core.PipelineResponse response) : base (default(T), default(System.ServiceModel.Rest.Core.PipelineResponse)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasValue { get { throw null; } }
        public override T Value { get { throw null; } }
    }
}
namespace System.ServiceModel.Rest.Core
{
    public partial class PipelineMessage : System.IDisposable
    {
        protected internal PipelineMessage(System.ServiceModel.Rest.Core.PipelineRequest request) { }
        public bool HasResponse { get { throw null; } }
        public virtual System.ServiceModel.Rest.Core.PipelineRequest Request { get { throw null; } }
        public virtual System.ServiceModel.Rest.Core.PipelineResponse Response { get { throw null; } set { } }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
    }
    public abstract partial class PipelineRequest
    {
        protected PipelineRequest() { }
        public abstract System.ServiceModel.Rest.Core.RequestBody? Content { get; set; }
        public abstract System.Uri Uri { get; set; }
        protected internal virtual System.Uri GetUri() { throw null; }
        public abstract void SetHeaderValue(string name, string value);
        public abstract void SetMethod(string method);
    }
    public abstract partial class PipelineResponse : System.IDisposable
    {
        protected PipelineResponse() { }
        public virtual System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public virtual bool IsError { get { throw null; } set { } }
        public abstract int Status { get; }
        public abstract void Dispose();
        public abstract bool TryGetHeaders(out System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> headers);
        public abstract bool TryGetHeaderValue(string name, out System.Collections.Generic.IEnumerable<string>? value);
        public abstract bool TryGetHeaderValue(string name, out string? value);
        public abstract bool TryGetReasonPhrase(out string reasonPhrase);
    }
    public abstract partial class RequestBody : System.IDisposable
    {
        protected RequestBody() { }
        public static System.ServiceModel.Rest.Core.RequestBody CreateFromStream(System.IO.Stream stream) { throw null; }
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
    }
    public partial class ResponseErrorClassifier
    {
        public ResponseErrorClassifier() { }
        public virtual bool IsErrorResponse(System.ServiceModel.Rest.Core.PipelineMessage message) { throw null; }
    }
    public partial class StatusResponseClassifier : System.ServiceModel.Rest.Core.ResponseErrorClassifier
    {
        public StatusResponseClassifier(System.ReadOnlySpan<ushort> successStatusCodes) { }
        public override bool IsErrorResponse(System.ServiceModel.Rest.Core.PipelineMessage message) { throw null; }
    }
    public partial class TelemetrySource
    {
        public TelemetrySource(System.ServiceModel.Rest.PipelineOptions options, bool suppressNestedClientActivities = true) { }
        public System.ServiceModel.Rest.Core.TelemetrySpan CreateSpan(string name) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetrySpan : System.IDisposable
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public void Dispose() { }
        public void Failed(System.Exception exception) { }
        public void Start() { }
    }
}
namespace System.ServiceModel.Rest.Core.Pipeline
{
    public partial class HttpPipelineMessageTransport : System.ServiceModel.Rest.Core.Pipeline.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>, System.IDisposable
    {
        public HttpPipelineMessageTransport() { }
        public HttpPipelineMessageTransport(System.Net.Http.HttpClient client) { }
        public override System.ServiceModel.Rest.Core.PipelineMessage CreateMessage() { throw null; }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void OnReceivedResponse(System.ServiceModel.Rest.Core.PipelineMessage message, System.Net.Http.HttpResponseMessage httpResponse, System.IO.Stream? contentStream) { }
        protected virtual void OnSendingRequest(System.ServiceModel.Rest.Core.PipelineMessage message, System.Net.Http.HttpRequestMessage httpRequest) { }
        public override void Process(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions options) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions options) { throw null; }
    }
    public partial class HttpPipelineRequest : System.ServiceModel.Rest.Core.PipelineRequest, System.IDisposable
    {
        public HttpPipelineRequest() { }
        public override System.ServiceModel.Rest.Core.RequestBody? Content { get { throw null; } set { } }
        public override System.Uri Uri { get { throw null; } set { } }
        protected virtual void AddHeader(string name, string value) { }
        protected virtual bool ContainsHeader(string name) { throw null; }
        public virtual void Dispose() { }
        protected virtual bool RemoveHeader(string name) { throw null; }
        protected virtual void SetHeader(string name, string value) { }
        public override void SetHeaderValue(string name, string value) { }
        public virtual void SetMethod(System.Net.Http.HttpMethod method) { }
        public override void SetMethod(string method) { }
        public override string ToString() { throw null; }
        protected virtual bool TryGetHeader(string name, out string? value) { throw null; }
        protected bool TryGetHeaderNames(out System.Collections.Generic.IEnumerable<string> headerNames) { throw null; }
        protected virtual bool TryGetHeaderValues(string name, out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
        public virtual bool TryGetMethod(out System.Net.Http.HttpMethod method) { throw null; }
    }
    public partial class HttpPipelineResponse : System.ServiceModel.Rest.Core.PipelineResponse, System.IDisposable
    {
        public HttpPipelineResponse(System.Net.Http.HttpResponseMessage? httpResponse, System.IO.Stream? contentStream) { }
        public override System.IO.Stream? ContentStream { get { throw null; } set { } }
        public override int Status { get { throw null; } }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public override bool TryGetHeaders(out System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> headers) { throw null; }
        public override bool TryGetHeaderValue(string name, out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
        public override bool TryGetHeaderValue(string name, out string? value) { throw null; }
        public override bool TryGetReasonPhrase(out string reasonPhrase) { throw null; }
    }
    public partial interface IPipelineEnumerator
    {
        int Length { get; }
        bool ProcessNext();
        System.Threading.Tasks.ValueTask<bool> ProcessNextAsync();
    }
    public partial interface IPipelinePolicy<TMessage, TOptions>
    {
        void Process(TMessage message, TOptions options, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline);
        System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, TOptions options, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline);
    }
    public partial class KeyCredentialPolicy : System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>
    {
        public KeyCredentialPolicy(System.ServiceModel.Rest.KeyCredential credential, string name, string? prefix = null) { }
        public void Process(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions options, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { }
        public System.Threading.Tasks.ValueTask ProcessAsync(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions options, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { throw null; }
    }
    public partial class MessagePipeline : System.ServiceModel.Rest.Core.Pipeline.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>
    {
        public MessagePipeline(System.ServiceModel.Rest.Core.Pipeline.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions> transport, System.ReadOnlyMemory<System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>> policies) { }
        public static System.ServiceModel.Rest.Core.Pipeline.MessagePipeline Create(System.ServiceModel.Rest.PipelineOptions options, System.ReadOnlySpan<System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>> perCallPolicies, System.ReadOnlySpan<System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>> perTryPolicies) { throw null; }
        public static System.ServiceModel.Rest.Core.Pipeline.MessagePipeline Create(System.ServiceModel.Rest.PipelineOptions options, params System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>[] perTryPolicies) { throw null; }
        public override System.ServiceModel.Rest.Core.PipelineMessage CreateMessage() { throw null; }
        public override void Send(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions options) { }
        public override System.Threading.Tasks.ValueTask SendAsync(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions options) { throw null; }
    }
    public abstract partial class PipelineTransport<TMessage, TOptions> : System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<TMessage, TOptions>
    {
        protected PipelineTransport() { }
        public abstract TMessage CreateMessage();
        public abstract void Process(TMessage message, TOptions options);
        public void Process(TMessage message, TOptions options, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { }
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, TOptions options);
        public System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, TOptions options, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { throw null; }
    }
    public abstract partial class Pipeline<TMessage, TOptions>
    {
        protected Pipeline() { }
        public abstract TMessage CreateMessage();
        public abstract void Send(TMessage message, TOptions options);
        public abstract System.Threading.Tasks.ValueTask SendAsync(TMessage message, TOptions options);
    }
    public partial class ResponseBufferingPolicy : System.ServiceModel.Rest.Core.Pipeline.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions>
    {
        public ResponseBufferingPolicy(System.TimeSpan networkTimeout) { }
        public void Process(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions options, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { }
        public System.Threading.Tasks.ValueTask ProcessAsync(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions options, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { throw null; }
    }
}
namespace System.ServiceModel.Rest.Internal
{
    public partial class ClientUtilities
    {
        public ClientUtilities() { }
        public static void AssertInRange<T>(T value, T minimum, T maximum, string name) where T : notnull, System.IComparable<T> { }
        public static void AssertNotNullOrEmpty(string value, string name) { }
        public static void AssertNotNull<T>(T value, string name) { }
        public static System.Exception CreateOperationCanceledException(System.Exception? innerException, System.Threading.CancellationToken cancellationToken, string? message = null) { throw null; }
        public static bool ShouldWrapInOperationCanceledException(System.Exception exception, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static void ThrowIfCancellationRequested(System.Threading.CancellationToken cancellationToken) { }
    }
    public partial interface IUtf8JsonWriteable
    {
        void Write(System.Text.Json.Utf8JsonWriter writer);
    }
    public static partial class ModelSerializationExtensions
    {
        public static byte[]? GetBytesFromBase64(this in System.Text.Json.JsonElement element, string format) { throw null; }
        public static char GetChar(this in System.Text.Json.JsonElement element) { throw null; }
        public static System.DateTimeOffset GetDateTimeOffset(this in System.Text.Json.JsonElement element, string format) { throw null; }
        public static object? GetObject(this in System.Text.Json.JsonElement element) { throw null; }
        public static string GetRequiredString(this in System.Text.Json.JsonElement element) { throw null; }
        public static System.TimeSpan GetTimeSpan(this in System.Text.Json.JsonElement element, string format) { throw null; }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void ThrowNonNullablePropertyIsNull(this System.Text.Json.JsonProperty property) { }
        public static void WriteBase64StringValue(this System.Text.Json.Utf8JsonWriter writer, byte[] value, string format) { }
        public static void WriteNonEmptyArray(this System.Text.Json.Utf8JsonWriter writer, string name, System.Collections.Generic.IReadOnlyList<string> values) { }
        public static void WriteNumberValue(this System.Text.Json.Utf8JsonWriter writer, System.DateTimeOffset value, string format) { }
        public static void WriteObjectValue(this System.Text.Json.Utf8JsonWriter writer, object value) { }
        public static void WriteStringValue(this System.Text.Json.Utf8JsonWriter writer, char value) { }
        public static void WriteStringValue(this System.Text.Json.Utf8JsonWriter writer, System.DateTime value, string format) { }
        public static void WriteStringValue(this System.Text.Json.Utf8JsonWriter writer, System.DateTimeOffset value, string format) { }
        public static void WriteStringValue(this System.Text.Json.Utf8JsonWriter writer, System.TimeSpan value, string format) { }
    }
    public partial class OptionalDictionary<TKey, TValue> : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IDictionary<TKey, TValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>, System.Collections.IEnumerable where TKey : notnull
    {
        public OptionalDictionary() { }
        public OptionalDictionary(System.ServiceModel.Rest.Internal.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optionalDictionary) { }
        public OptionalDictionary(System.ServiceModel.Rest.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optionalDictionary) { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public bool IsUndefined { get { throw null; } }
        public TValue this[TKey key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<TKey> Keys { get { throw null; } }
        System.Collections.Generic.IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>.Keys { get { throw null; } }
        System.Collections.Generic.IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>.Values { get { throw null; } }
        public System.Collections.Generic.ICollection<TValue> Values { get { throw null; } }
        public void Add(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { }
        public void Add(TKey key, TValue value) { }
        public void Clear() { }
        public bool Contains(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { throw null; }
        public bool ContainsKey(TKey key) { throw null; }
        public void CopyTo(System.Collections.Generic.KeyValuePair<TKey, TValue>[] array, int arrayIndex) { }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> GetEnumerator() { throw null; }
        public bool Remove(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { throw null; }
        public bool Remove(TKey key) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(TKey key, out TValue value) { throw null; }
    }
    public partial class OptionalList<T> : System.Collections.Generic.ICollection<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<T>, System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.Generic.IReadOnlyList<T>, System.Collections.IEnumerable
    {
        public OptionalList() { }
        public OptionalList(System.ServiceModel.Rest.Internal.OptionalProperty<System.Collections.Generic.IList<T>> optionalList) { }
        public OptionalList(System.ServiceModel.Rest.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optionalList) { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public bool IsUndefined { get { throw null; } }
        public T this[int index] { get { throw null; } set { } }
        public void Add(T item) { }
        public void Clear() { }
        public bool Contains(T item) { throw null; }
        public void CopyTo(T[] array, int arrayIndex) { }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() { throw null; }
        public int IndexOf(T item) { throw null; }
        public void Insert(int index, T item) { }
        public bool Remove(T item) { throw null; }
        public void RemoveAt(int index) { }
        public void Reset() { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public static partial class OptionalProperty
    {
        public static bool IsCollectionDefined<T>(System.Collections.Generic.IEnumerable<T> collection) { throw null; }
        public static bool IsCollectionDefined<TKey, TValue>(System.Collections.Generic.IDictionary<TKey, TValue> collection) { throw null; }
        public static bool IsCollectionDefined<TKey, TValue>(System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> collection) { throw null; }
        public static bool IsDefined(object value) { throw null; }
        public static bool IsDefined(string value) { throw null; }
        public static bool IsDefined(System.Text.Json.JsonElement value) { throw null; }
        public static bool IsDefined<T>(T? value) where T : struct { throw null; }
        public static System.Collections.Generic.IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.ServiceModel.Rest.Internal.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.ServiceModel.Rest.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IList<T> ToList<T>(System.ServiceModel.Rest.Internal.OptionalProperty<System.Collections.Generic.IList<T>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyList<T> ToList<T>(System.ServiceModel.Rest.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optional) { throw null; }
        public static T? ToNullable<T>(System.ServiceModel.Rest.Internal.OptionalProperty<T?> optional) where T : struct { throw null; }
        public static T? ToNullable<T>(System.ServiceModel.Rest.Internal.OptionalProperty<T> optional) where T : struct { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptionalProperty<T>
    {
        private readonly T _Value_k__BackingField;
        private readonly int _dummyPrimitive;
        public OptionalProperty(T value) { throw null; }
        public bool HasValue { get { throw null; } }
        public T Value { get { throw null; } }
        public static implicit operator T (System.ServiceModel.Rest.Internal.OptionalProperty<T> optional) { throw null; }
        public static implicit operator System.ServiceModel.Rest.Internal.OptionalProperty<T> (T value) { throw null; }
    }
    public static partial class PipelineProtocolExtensions
    {
        public static System.ServiceModel.Rest.NullableResult<bool> ProcessHeadAsBoolMessage(this System.ServiceModel.Rest.Core.Pipeline.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions> pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.TelemetrySource clientDiagnostics, System.ServiceModel.Rest.InvocationOptions requestContext) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ServiceModel.Rest.NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this System.ServiceModel.Rest.Core.Pipeline.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions> pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.TelemetrySource clientDiagnostics, System.ServiceModel.Rest.InvocationOptions requestContext) { throw null; }
        public static System.ServiceModel.Rest.Core.PipelineResponse ProcessMessage(this System.ServiceModel.Rest.Core.Pipeline.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions> pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ServiceModel.Rest.Core.PipelineResponse> ProcessMessageAsync(this System.ServiceModel.Rest.Core.Pipeline.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage, System.ServiceModel.Rest.InvocationOptions> pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.InvocationOptions requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RequestUri
    {
        public RequestUri() { }
        protected bool HasPath { get { throw null; } }
        protected bool HasQuery { get { throw null; } }
        public virtual string? Host { get { throw null; } set { } }
        public virtual string Path { get { throw null; } set { } }
        public string PathAndQuery { get { throw null; } }
        public virtual int Port { get { throw null; } set { } }
        public virtual string Query { get { throw null; } set { } }
        public virtual string? Scheme { get { throw null; } set { } }
        public void AppendPath(bool value, bool escape = false) { }
        public void AppendPath(byte[] value, string format, bool escape = true) { }
        public void AppendPath(System.Collections.Generic.IEnumerable<string> value, bool escape = true) { }
        public void AppendPath(System.DateTimeOffset value, string format, bool escape = true) { }
        public void AppendPath(double value, bool escape = true) { }
        public void AppendPath(System.Guid value, bool escape = true) { }
        public void AppendPath(int value, bool escape = true) { }
        public void AppendPath(long value, bool escape = true) { }
        public virtual void AppendPath(System.ReadOnlySpan<char> value, bool escape) { }
        public void AppendPath(float value, bool escape = true) { }
        public virtual void AppendPath(string value) { }
        public virtual void AppendPath(string value, bool escape) { }
        public void AppendPath(System.TimeSpan value, string format, bool escape = true) { }
        public virtual void AppendQuery(System.ReadOnlySpan<char> name, System.ReadOnlySpan<char> value, bool escapeValue) { }
        public void AppendQuery(string name, bool value, bool escape = false) { }
        public void AppendQuery(string name, byte[] value, string format, bool escape = true) { }
        public void AppendQuery(string name, System.DateTimeOffset value, string format, bool escape = true) { }
        public void AppendQuery(string name, decimal value, bool escape = true) { }
        public void AppendQuery(string name, double value, bool escape = true) { }
        public void AppendQuery(string name, System.Guid value, bool escape = true) { }
        public void AppendQuery(string name, int value, bool escape = true) { }
        public void AppendQuery(string name, long value, bool escape = true) { }
        public void AppendQuery(string name, float value, bool escape = true) { }
        public virtual void AppendQuery(string name, string value) { }
        public virtual void AppendQuery(string name, string value, bool escapeValue) { }
        public void AppendQuery(string name, System.TimeSpan value, bool escape = true) { }
        public void AppendQuery(string name, System.TimeSpan value, string format, bool escape = true) { }
        public void AppendQueryDelimited<T>(string name, System.Collections.Generic.IEnumerable<T> value, string delimiter, bool escape = true) { }
        public void AppendQueryDelimited<T>(string name, System.Collections.Generic.IEnumerable<T> value, string delimiter, string format, bool escape = true) { }
        public void AppendRawPathOrQueryOrHostOrScheme(string value, bool escape) { }
        public virtual void Reset(System.Uri value) { }
        public override string ToString() { throw null; }
        public virtual System.Uri ToUri() { throw null; }
    }
    public partial class Utf8JsonRequestBody : System.ServiceModel.Rest.Core.RequestBody
    {
        public Utf8JsonRequestBody() { }
        public System.Text.Json.Utf8JsonWriter JsonWriter { get { throw null; } }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public override bool TryComputeLength(out long length) { throw null; }
        public override void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation) { }
        public override System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation) { throw null; }
    }
}
