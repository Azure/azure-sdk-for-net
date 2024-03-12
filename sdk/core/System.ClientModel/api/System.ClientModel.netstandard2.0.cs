namespace System.ClientModel
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
        public MessageFailedException(System.ClientModel.Primitives.PipelineResponse response) { }
        protected MessageFailedException(System.ClientModel.Primitives.PipelineResponse response, string message, System.Exception? innerException) { }
        protected MessageFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public int Status { get { throw null; } }
    }
    public partial class NullableResult<T> : System.ClientModel.Result
    {
        public NullableResult(T? value, System.ClientModel.Primitives.PipelineResponse response) { }
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
        public override System.ClientModel.Primitives.PipelineResponse GetRawResponse() { throw null; }
    }
    public partial class RequestOptions
    {
        public RequestOptions() { }
        public bool BufferResponse { get { throw null; } set { } }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public static System.Threading.CancellationToken DefaultCancellationToken { get { throw null; } set { } }
        public static System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>? DefaultLoggingPolicy { get { throw null; } set { } }
        public static System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>? DefaultRetryPolicy { get { throw null; } set { } }
        public static System.ClientModel.Primitives.Pipeline.PipelineTransport<System.ClientModel.Primitives.PipelineMessage>? DefaultTransport { get { throw null; } set { } }
        public System.ClientModel.ErrorBehavior ErrorBehavior { get { throw null; } set { } }
        public System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>? LoggingPolicy { get { throw null; } set { } }
        public System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>[]? PerCallPolicies { get { throw null; } set { } }
        public System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>[]? PerTryPolicies { get { throw null; } set { } }
        public System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>? RetryPolicy { get { throw null; } set { } }
        public System.ClientModel.Primitives.Pipeline.PipelineTransport<System.ClientModel.Primitives.PipelineMessage>? Transport { get { throw null; } set { } }
    }
    public abstract partial class Result
    {
        protected Result() { }
        public static System.ClientModel.Result FromResponse(System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.Result<T> FromValue<T>(T value, System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public abstract System.ClientModel.Primitives.PipelineResponse GetRawResponse();
    }
    public partial class Result<T> : System.ClientModel.NullableResult<T>
    {
        public Result(T value, System.ClientModel.Primitives.PipelineResponse response) : base (default(T), default(System.ClientModel.Primitives.PipelineResponse)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasValue { get { throw null; } }
        public override T Value { get { throw null; } }
    }
}
namespace System.ClientModel.Internal
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
        public OptionalDictionary(System.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optionalDictionary) { }
        public OptionalDictionary(System.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optionalDictionary) { }
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
        public OptionalList(System.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IList<T>> optionalList) { }
        public OptionalList(System.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optionalList) { }
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
        public static System.Collections.Generic.IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IList<T> ToList<T>(System.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IList<T>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyList<T> ToList<T>(System.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optional) { throw null; }
        public static T? ToNullable<T>(System.ClientModel.Internal.OptionalProperty<T?> optional) where T : struct { throw null; }
        public static T? ToNullable<T>(System.ClientModel.Internal.OptionalProperty<T> optional) where T : struct { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptionalProperty<T>
    {
        private readonly T _Value_k__BackingField;
        private readonly int _dummyPrimitive;
        public OptionalProperty(T value) { throw null; }
        public bool HasValue { get { throw null; } }
        public T Value { get { throw null; } }
        public static implicit operator T (System.ClientModel.Internal.OptionalProperty<T> optional) { throw null; }
        public static implicit operator System.ClientModel.Internal.OptionalProperty<T> (T value) { throw null; }
    }
    public static partial class PipelineProtocolExtensions
    {
        public static System.ClientModel.NullableResult<bool> ProcessHeadAsBoolMessage(this System.ClientModel.Primitives.Pipeline.Pipeline<System.ClientModel.Primitives.PipelineMessage> pipeline, System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.TelemetrySource clientDiagnostics, System.ClientModel.RequestOptions? requestContext) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ClientModel.NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this System.ClientModel.Primitives.Pipeline.Pipeline<System.ClientModel.Primitives.PipelineMessage> pipeline, System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.TelemetrySource clientDiagnostics, System.ClientModel.RequestOptions? requestContext) { throw null; }
        public static System.ClientModel.Primitives.PipelineResponse ProcessMessage(this System.ClientModel.Primitives.Pipeline.Pipeline<System.ClientModel.Primitives.PipelineMessage> pipeline, System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.RequestOptions? requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ClientModel.Primitives.PipelineResponse> ProcessMessageAsync(this System.ClientModel.Primitives.Pipeline.Pipeline<System.ClientModel.Primitives.PipelineMessage> pipeline, System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.RequestOptions? requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class Utf8JsonRequestBody : System.ClientModel.Primitives.RequestBody
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
    public partial class PipelineMessage : System.IDisposable
    {
        protected internal PipelineMessage(System.ClientModel.Primitives.PipelineRequest request, System.ClientModel.Primitives.ResponseErrorClassifier classifier) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public bool HasResponse { get { throw null; } }
        public virtual System.ClientModel.Primitives.PipelineRequest Request { get { throw null; } }
        public virtual System.ClientModel.Primitives.PipelineResponse Response { get { throw null; } set { } }
        public virtual System.ClientModel.Primitives.ResponseErrorClassifier ResponseClassifier { get { throw null; } set { } }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
    }
    public enum PipelinePosition
    {
        PerCall = 0,
        PerRetry = 1,
        BeforeTransport = 2,
    }
    public abstract partial class PipelineRequest
    {
        protected PipelineRequest() { }
        public abstract System.ClientModel.Primitives.RequestBody? Content { get; set; }
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
        public static System.ClientModel.Primitives.RequestBody CreateFromStream(System.IO.Stream stream) { throw null; }
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
    }
    public partial class ResponseErrorClassifier
    {
        public ResponseErrorClassifier() { }
        public virtual bool IsErrorResponse(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public partial class StatusResponseClassifier : System.ClientModel.Primitives.ResponseErrorClassifier
    {
        public StatusResponseClassifier(System.ReadOnlySpan<ushort> successStatusCodes) { }
        public override bool IsErrorResponse(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public partial class TelemetrySource
    {
        public TelemetrySource(System.ClientModel.RequestOptions options, bool suppressNestedClientActivities = true) { }
        public System.ClientModel.Primitives.TelemetrySpan CreateSpan(string name) { throw null; }
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
namespace System.ClientModel.Primitives.Pipeline
{
    public partial class HttpPipelineMessageTransport : System.ClientModel.Primitives.Pipeline.PipelineTransport<System.ClientModel.Primitives.PipelineMessage>, System.IDisposable
    {
        public HttpPipelineMessageTransport() { }
        public HttpPipelineMessageTransport(System.Net.Http.HttpClient client) { }
        public override System.ClientModel.Primitives.PipelineMessage CreateMessage(System.ClientModel.RequestOptions options, System.ClientModel.Primitives.ResponseErrorClassifier classifier) { throw null; }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void OnReceivedResponse(System.ClientModel.Primitives.PipelineMessage message, System.Net.Http.HttpResponseMessage httpResponse, System.IO.Stream? contentStream) { }
        protected virtual void OnSendingRequest(System.ClientModel.Primitives.PipelineMessage message) { }
        public override void Process(System.ClientModel.Primitives.PipelineMessage message) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public partial class HttpPipelineRequest : System.ClientModel.Primitives.PipelineRequest, System.IDisposable
    {
        public HttpPipelineRequest() { }
        public override System.ClientModel.Primitives.RequestBody? Content { get { throw null; } set { } }
        public override System.Uri Uri { get { throw null; } set { } }
        protected virtual void AddHeader(string name, string value) { }
        protected virtual bool ContainsHeader(string name) { throw null; }
        public virtual void Dispose() { }
        protected virtual void OnSending(System.ClientModel.Primitives.PipelineMessage message, System.Net.Http.HttpRequestMessage httpRequest) { }
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
    public partial class HttpPipelineResponse : System.ClientModel.Primitives.PipelineResponse, System.IDisposable
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
    public partial interface IPipelinePolicy<TMessage>
    {
        void Process(TMessage message, System.ClientModel.Primitives.Pipeline.IPipelineEnumerator pipeline);
        System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, System.ClientModel.Primitives.Pipeline.IPipelineEnumerator pipeline);
    }
    public partial class KeyCredentialPolicy : System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>
    {
        public KeyCredentialPolicy(System.ClientModel.KeyCredential credential, string name, string? prefix = null) { }
        public void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.Pipeline.IPipelineEnumerator pipeline) { }
        public System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.Pipeline.IPipelineEnumerator pipeline) { throw null; }
    }
    public partial class MessagePipeline : System.ClientModel.Primitives.Pipeline.Pipeline<System.ClientModel.Primitives.PipelineMessage>
    {
        public MessagePipeline(System.ClientModel.Primitives.Pipeline.PipelineTransport<System.ClientModel.Primitives.PipelineMessage> transport, System.ReadOnlyMemory<System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>> policies) { }
        public static System.ClientModel.Primitives.Pipeline.MessagePipeline Create(System.ClientModel.RequestOptions options, params System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>[] perTryPolicies) { throw null; }
        public static System.ClientModel.Primitives.Pipeline.MessagePipeline Create(System.ClientModel.RequestOptions options, System.ReadOnlySpan<System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>> perCallPolicies, System.ReadOnlySpan<System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>> perTryPolicies) { throw null; }
        public override System.ClientModel.Primitives.PipelineMessage CreateMessage(System.ClientModel.RequestOptions options, System.ClientModel.Primitives.ResponseErrorClassifier classifier) { throw null; }
        public override void Send(System.ClientModel.Primitives.PipelineMessage message) { }
        public override System.Threading.Tasks.ValueTask SendAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public abstract partial class PipelineTransport<TMessage> : System.ClientModel.Primitives.Pipeline.IPipelinePolicy<TMessage>
    {
        protected PipelineTransport() { }
        public abstract TMessage CreateMessage(System.ClientModel.RequestOptions options, System.ClientModel.Primitives.ResponseErrorClassifier classifier);
        public abstract void Process(TMessage message);
        public void Process(TMessage message, System.ClientModel.Primitives.Pipeline.IPipelineEnumerator pipeline) { }
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(TMessage message);
        public System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, System.ClientModel.Primitives.Pipeline.IPipelineEnumerator pipeline) { throw null; }
    }
    public abstract partial class Pipeline<TMessage>
    {
        protected Pipeline() { }
        public abstract TMessage CreateMessage(System.ClientModel.RequestOptions options, System.ClientModel.Primitives.ResponseErrorClassifier classifier);
        public abstract void Send(TMessage message);
        public abstract System.Threading.Tasks.ValueTask SendAsync(TMessage message);
    }
    public partial class ResponseBufferingPolicy : System.ClientModel.Primitives.Pipeline.IPipelinePolicy<System.ClientModel.Primitives.PipelineMessage>
    {
        public ResponseBufferingPolicy(System.TimeSpan networkTimeout, bool bufferResponse) { }
        protected virtual bool BufferResponse(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
        public void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.Pipeline.IPipelineEnumerator pipeline) { }
        public System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.Pipeline.IPipelineEnumerator pipeline) { throw null; }
        protected virtual void SetReadTimeoutStream(System.ClientModel.Primitives.PipelineMessage message, System.IO.Stream responseContentStream, System.TimeSpan networkTimeout) { }
        protected virtual bool TryGetNetworkTimeoutOverride(System.ClientModel.Primitives.PipelineMessage message, out System.TimeSpan timeout) { throw null; }
    }
}
