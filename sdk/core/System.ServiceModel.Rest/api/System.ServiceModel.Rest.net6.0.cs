namespace System.ServiceModel.Rest
{
    [System.FlagsAttribute]
    public enum ErrorBehavior
    {
        Default = 0,
        NoThrow = 1,
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
        public static System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>? DefaultLoggingPolicy { get { throw null; } set { } }
        public static System.TimeSpan DefaultNetworkTimeout { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>? DefaultRetryPolicy { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.Pipeline.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage>? DefaultTransport { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>? LoggingPolicy { get { throw null; } set { } }
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>[]? PerCallPolicies { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>[]? PerTryPolicies { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>? RetryPolicy { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.Pipeline.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage>? Transport { get { throw null; } set { } }
    }
    public partial class RequestOptions : System.ServiceModel.Rest.PipelineOptions
    {
        public RequestOptions() { }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public static System.Threading.CancellationToken DefaultCancellationToken { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.ResponseErrorClassifier DefaultResponseClassifier { get { throw null; } set { } }
        public virtual System.ServiceModel.Rest.ErrorBehavior ErrorBehavior { get { throw null; } set { } }
        public virtual System.ServiceModel.Rest.Core.ResponseErrorClassifier ResponseClassifier { get { throw null; } set { } }
        public virtual void Apply(System.ServiceModel.Rest.Core.PipelineMessage message) { }
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
    public partial class PipelineMessage : System.IDisposable
    {
        protected internal PipelineMessage(System.ServiceModel.Rest.Core.PipelineRequest request) { }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public bool HasResponse { get { throw null; } }
        public virtual System.ServiceModel.Rest.Core.PipelineRequest Request { get { throw null; } }
        public virtual System.ServiceModel.Rest.Core.PipelineResponse Response { get { throw null; } protected internal set { } }
        public virtual System.ServiceModel.Rest.Core.ResponseErrorClassifier ResponseClassifier { get { throw null; } set { } }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void SetProperty(System.Type type, object value) { }
        public bool TryGetProperty(System.Type type, out object? value) { throw null; }
    }
    public abstract partial class PipelineRequest : System.IDisposable
    {
        protected PipelineRequest() { }
        public abstract System.ServiceModel.Rest.Core.RequestBody? Content { get; set; }
        public abstract System.ServiceModel.Rest.Core.MessageHeaders Headers { get; }
        public abstract string Method { get; set; }
        public abstract System.Uri Uri { get; set; }
        public abstract void Dispose();
    }
    public abstract partial class PipelineResponse : System.IDisposable
    {
        protected PipelineResponse() { }
        public System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; protected internal set; }
        public abstract System.ServiceModel.Rest.Core.MessageHeaders Headers { get; }
        public bool IsError { get { throw null; } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public abstract void Dispose();
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
    public partial class HttpPipelineMessageTransport : System.ServiceModel.Rest.Core.Pipeline.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage>, System.IDisposable
    {
        public HttpPipelineMessageTransport() { }
        public HttpPipelineMessageTransport(System.Net.Http.HttpClient client) { }
        public override System.ServiceModel.Rest.Core.PipelineMessage CreateMessage() { throw null; }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void OnReceivedResponse(System.ServiceModel.Rest.Core.PipelineMessage message, System.Net.Http.HttpResponseMessage httpResponse, System.IO.Stream? contentStream) { }
        protected virtual void OnSendingRequest(System.ServiceModel.Rest.Core.PipelineMessage message, System.Net.Http.HttpRequestMessage httpRequest) { }
        public override void Process(System.ServiceModel.Rest.Core.PipelineMessage message) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ServiceModel.Rest.Core.PipelineMessage message) { throw null; }
    }
    public partial class HttpPipelineRequest : System.ServiceModel.Rest.Core.PipelineRequest, System.IDisposable
    {
        public HttpPipelineRequest() { }
        public override System.ServiceModel.Rest.Core.RequestBody? Content { get { throw null; } set { } }
        public override System.ServiceModel.Rest.Core.MessageHeaders Headers { get { throw null; } }
        public override string Method { get { throw null; } set { } }
        public override System.Uri Uri { get { throw null; } set { } }
        public override void Dispose() { }
        public override string ToString() { throw null; }
    }
    public partial class HttpPipelineResponse : System.ServiceModel.Rest.Core.PipelineResponse, System.IDisposable
    {
        protected internal HttpPipelineResponse(System.Net.Http.HttpResponseMessage httpResponse, System.IO.Stream? contentStream) { }
        public override System.IO.Stream? ContentStream { get { throw null; } protected internal set { } }
        public override System.ServiceModel.Rest.Core.MessageHeaders Headers { get { throw null; } }
        public override string ReasonPhrase { get { throw null; } }
        public override int Status { get { throw null; } }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
    }
    public partial interface IPipelineEnumerator
    {
        int Length { get; }
        bool ProcessNext();
        System.Threading.Tasks.ValueTask<bool> ProcessNextAsync();
    }
    public partial class KeyCredentialPolicy : System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>
    {
        public KeyCredentialPolicy(System.ServiceModel.Rest.KeyCredential credential, string name, string? prefix = null) { }
        public override void Process(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { throw null; }
    }
    public partial class MessagePipeline : System.ServiceModel.Rest.Core.Pipeline.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage>
    {
        public MessagePipeline(System.ServiceModel.Rest.Core.Pipeline.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage> transport, System.ReadOnlyMemory<System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>> policies) { }
        public static System.ServiceModel.Rest.Core.Pipeline.MessagePipeline Create(System.ServiceModel.Rest.PipelineOptions options, System.ReadOnlySpan<System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>> perCallPolicies, System.ReadOnlySpan<System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>> perTryPolicies) { throw null; }
        public static System.ServiceModel.Rest.Core.Pipeline.MessagePipeline Create(System.ServiceModel.Rest.PipelineOptions options, params System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>[] perTryPolicies) { throw null; }
        public override System.ServiceModel.Rest.Core.PipelineMessage CreateMessage() { throw null; }
        public override void Send(System.ServiceModel.Rest.Core.PipelineMessage message) { }
        public override System.Threading.Tasks.ValueTask SendAsync(System.ServiceModel.Rest.Core.PipelineMessage message) { throw null; }
    }
    public abstract partial class PipelinePolicy<TMessage> where TMessage : System.ServiceModel.Rest.Core.PipelineMessage
    {
        protected PipelinePolicy() { }
        public abstract void Process(TMessage message, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline);
    }
    public abstract partial class PipelineTransport<TMessage> : System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<TMessage> where TMessage : System.ServiceModel.Rest.Core.PipelineMessage
    {
        protected PipelineTransport() { }
        public abstract TMessage CreateMessage();
        public abstract void Process(TMessage message);
        public override void Process(TMessage message, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { }
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(TMessage message);
        public override System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { throw null; }
    }
    public abstract partial class Pipeline<TMessage> where TMessage : System.ServiceModel.Rest.Core.PipelineMessage
    {
        protected Pipeline() { }
        public abstract TMessage CreateMessage();
        public abstract void Send(TMessage message);
        public abstract System.Threading.Tasks.ValueTask SendAsync(TMessage message);
    }
    public partial class ResponseBufferingPolicy : System.ServiceModel.Rest.Core.Pipeline.PipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>
    {
        public ResponseBufferingPolicy(System.TimeSpan networkTimeout) { }
        public override void Process(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.Pipeline.IPipelineEnumerator pipeline) { throw null; }
        public static void SetBufferResponse(System.ServiceModel.Rest.Core.PipelineMessage message, bool bufferResponse) { }
        public static void SetNetworkTimeout(System.ServiceModel.Rest.Core.PipelineMessage message, System.TimeSpan networkTimeout) { }
        public static bool TryGetBufferResponse(System.ServiceModel.Rest.Core.PipelineMessage message, out bool bufferResponse) { throw null; }
        public static bool TryGetNetworkTimeout(System.ServiceModel.Rest.Core.PipelineMessage message, out System.TimeSpan networkTimeout) { throw null; }
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
        public static System.ServiceModel.Rest.NullableResult<bool> ProcessHeadAsBoolMessage(this System.ServiceModel.Rest.Core.Pipeline.MessagePipeline pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.TelemetrySource clientDiagnostics, System.ServiceModel.Rest.RequestOptions requestContext) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ServiceModel.Rest.NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this System.ServiceModel.Rest.Core.Pipeline.MessagePipeline pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.TelemetrySource clientDiagnostics, System.ServiceModel.Rest.RequestOptions requestContext) { throw null; }
        public static System.ServiceModel.Rest.Core.PipelineResponse ProcessMessage(this System.ServiceModel.Rest.Core.Pipeline.MessagePipeline pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.RequestOptions requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ServiceModel.Rest.Core.PipelineResponse> ProcessMessageAsync(this System.ServiceModel.Rest.Core.Pipeline.MessagePipeline pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.RequestOptions requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
