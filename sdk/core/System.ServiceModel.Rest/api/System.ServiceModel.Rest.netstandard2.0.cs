namespace System.ServiceModel.Rest
{
    public partial class KeyCredential
    {
        public KeyCredential(string key) { }
        public string Key { get { throw null; } }
        public void Update(string key) { }
    }
    public partial class MessagePipeline : System.ServiceModel.Rest.Core.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage>
    {
        public MessagePipeline(System.ServiceModel.Rest.Core.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage> transport, System.ReadOnlyMemory<System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>> policies) { }
        public static System.ServiceModel.Rest.MessagePipeline Create(System.ServiceModel.Rest.Core.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage> defaultTransport, System.ServiceModel.Rest.RequestOptions options, System.ReadOnlySpan<System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>> clientPerTryPolicies, System.ReadOnlySpan<System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>> clientPerCallPolicies) { throw null; }
        public static System.ServiceModel.Rest.MessagePipeline Create(System.ServiceModel.Rest.Core.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage> defaultTransport, System.ServiceModel.Rest.RequestOptions options, params System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>[] clientPerTryPolicies) { throw null; }
        public override System.ServiceModel.Rest.Core.PipelineMessage CreateMessage(System.ServiceModel.Rest.RequestOptions options, System.ServiceModel.Rest.Core.ResponseErrorClassifier classifier) { throw null; }
        public override void Send(System.ServiceModel.Rest.Core.PipelineMessage message) { }
        public override System.Threading.Tasks.ValueTask SendAsync(System.ServiceModel.Rest.Core.PipelineMessage message) { throw null; }
    }
    public partial class NullableResult<T> : System.ServiceModel.Rest.Result
    {
        public NullableResult(T? value, System.ServiceModel.Rest.Core.PipelineResponse response) { }
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
        public override System.ServiceModel.Rest.Core.PipelineResponse GetRawResponse() { throw null; }
    }
    public partial class RequestErrorException : System.Exception
    {
        protected RequestErrorException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public RequestErrorException(System.ServiceModel.Rest.Core.PipelineResponse response) { }
        protected RequestErrorException(System.ServiceModel.Rest.Core.PipelineResponse response, string message, System.Exception? innerException) { }
        public int Status { get { throw null; } }
    }
    public partial class RequestOptions
    {
        public RequestOptions() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public static System.Threading.CancellationToken DefaultCancellationToken { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>? DefaultLoggingPolicy { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>? DefaultRetryPolicy { get { throw null; } set { } }
        public static System.ServiceModel.Rest.Core.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage>? DefaultTransport { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>? LoggingPolicy { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>[]? PerCallPolicies { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>[]? PerTryPolicies { get { throw null; } set { } }
        public System.ServiceModel.Rest.ResultErrorOptions ResultErrorOptions { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>? RetryPolicy { get { throw null; } set { } }
        public System.ServiceModel.Rest.Core.PipelineTransport<System.ServiceModel.Rest.Core.PipelineMessage>? Transport { get { throw null; } set { } }
    }
    public abstract partial class Result
    {
        protected Result() { }
        public static System.ServiceModel.Rest.Result FromResponse(System.ServiceModel.Rest.Core.PipelineResponse response) { throw null; }
        public static System.ServiceModel.Rest.Result<T> FromValue<T>(T value, System.ServiceModel.Rest.Core.PipelineResponse response) { throw null; }
        public abstract System.ServiceModel.Rest.Core.PipelineResponse GetRawResponse();
    }
    [System.FlagsAttribute]
    public enum ResultErrorOptions
    {
        Default = 0,
        NoThrow = 1,
    }
    public partial class Result<T> : System.ServiceModel.Rest.NullableResult<T>
    {
        public Result(T value, System.ServiceModel.Rest.Core.PipelineResponse response) : base (default(T), default(System.ServiceModel.Rest.Core.PipelineResponse)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasValue { get { throw null; } }
        public override T Value { get { throw null; } }
    }
    public partial class TelemetrySource
    {
        public TelemetrySource(System.ServiceModel.Rest.RequestOptions options, bool suppressNestedClientActivities = true) { }
        public System.ServiceModel.Rest.TelemetrySpan CreateSpan(string name) { throw null; }
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
namespace System.ServiceModel.Rest.Core
{
    public partial interface IPipelinePolicy<TMessage>
    {
        void Process(TMessage message, System.ServiceModel.Rest.Core.PipelineEnumerator pipeline);
        System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, System.ServiceModel.Rest.Core.PipelineEnumerator pipeline);
    }
    public abstract partial class PipelineEnumerator
    {
        protected PipelineEnumerator() { }
        public int Length { get { throw null; } }
        public abstract bool ProcessNext();
        public abstract System.Threading.Tasks.ValueTask<bool> ProcessNextAsync();
    }
    public abstract partial class PipelineMessage : System.IDisposable
    {
        protected PipelineMessage(System.ServiceModel.Rest.Core.PipelineRequest request, System.ServiceModel.Rest.Core.ResponseErrorClassifier classifier) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public abstract System.ServiceModel.Rest.Core.PipelineRequest PipelineRequest { get; set; }
        public abstract System.ServiceModel.Rest.Core.PipelineResponse? PipelineResponse { get; set; }
        public abstract System.ServiceModel.Rest.Core.ResponseErrorClassifier ResponseErrorClassifier { get; set; }
        public abstract void Dispose();
    }
    public enum PipelinePosition
    {
        PerCall = 0,
        PerRetry = 1,
        BeforeTransport = 2,
    }
    public abstract partial class PipelineRequest : System.IDisposable
    {
        protected PipelineRequest() { }
        public abstract string ClientRequestId { get; set; }
        public abstract void Dispose();
        public abstract void SetContent(System.ServiceModel.Rest.Core.RequestBody content);
        public abstract void SetHeaderValue(string name, string value);
        public abstract void SetMethod(string method);
        public abstract void SetUri(System.ServiceModel.Rest.Experimental.Core.RequestUri uri);
    }
    public abstract partial class PipelineResponse
    {
        protected PipelineResponse() { }
        public abstract System.BinaryData Content { get; }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public virtual bool IsError { get { throw null; } set { } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public abstract bool TryGetHeaderValue(string name, out string? value);
    }
    public abstract partial class PipelineTransport<TMessage> : System.ServiceModel.Rest.Core.IPipelinePolicy<TMessage>
    {
        protected PipelineTransport() { }
        public abstract TMessage CreateMessage(System.ServiceModel.Rest.RequestOptions options, System.ServiceModel.Rest.Core.ResponseErrorClassifier classifier);
        public abstract void Process(TMessage message);
        public void Process(TMessage message, System.ServiceModel.Rest.Core.PipelineEnumerator pipeline) { }
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(TMessage message);
        public System.Threading.Tasks.ValueTask ProcessAsync(TMessage message, System.ServiceModel.Rest.Core.PipelineEnumerator pipeline) { throw null; }
    }
    public abstract partial class Pipeline<TMessage>
    {
        protected Pipeline() { }
        public abstract TMessage CreateMessage(System.ServiceModel.Rest.RequestOptions options, System.ServiceModel.Rest.Core.ResponseErrorClassifier classifier);
        public abstract void Send(TMessage message);
        public abstract System.Threading.Tasks.ValueTask SendAsync(TMessage message);
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
}
namespace System.ServiceModel.Rest.Experimental
{
    public partial class ClientUtilities
    {
        public ClientUtilities() { }
        public static void AssertNotNullOrEmpty(string value, string name) { }
        public static void AssertNotNull<T>(T value, string name) { }
        public static void ThrowIfCancellationRequested(System.Threading.CancellationToken cancellationToken) { }
    }
    public partial class KeyCredentialPolicy : System.ServiceModel.Rest.Core.IPipelinePolicy<System.ServiceModel.Rest.Core.PipelineMessage>
    {
        public KeyCredentialPolicy(System.ServiceModel.Rest.KeyCredential credential, string name, string? prefix = null) { }
        public void Process(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.PipelineEnumerator pipeline) { }
        public System.Threading.Tasks.ValueTask ProcessAsync(System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.Core.PipelineEnumerator pipeline) { throw null; }
    }
}
namespace System.ServiceModel.Rest.Experimental.Core
{
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
        public virtual void AppendPath(System.ReadOnlySpan<char> value, bool escape) { }
        public virtual void AppendPath(string value) { }
        public virtual void AppendPath(string value, bool escape) { }
        public virtual void AppendQuery(System.ReadOnlySpan<char> name, System.ReadOnlySpan<char> value, bool escapeValue) { }
        public virtual void AppendQuery(string name, string value) { }
        public virtual void AppendQuery(string name, string value, bool escapeValue) { }
        public void AppendRawPathOrQueryOrHostOrScheme(string value, bool escape) { }
        public virtual void Reset(System.Uri value) { }
        public override string ToString() { throw null; }
        public virtual System.Uri ToUri() { throw null; }
    }
}
namespace System.ServiceModel.Rest.Experimental.Core.Pipeline
{
    public static partial class PipelineProtocolExtensions
    {
        public static System.ServiceModel.Rest.NullableResult<bool> ProcessHeadAsBoolMessage(this System.ServiceModel.Rest.Core.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage> pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.TelemetrySource clientDiagnostics, System.ServiceModel.Rest.RequestOptions? requestContext) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ServiceModel.Rest.NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this System.ServiceModel.Rest.Core.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage> pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.TelemetrySource clientDiagnostics, System.ServiceModel.Rest.RequestOptions? requestContext) { throw null; }
        public static System.ServiceModel.Rest.Core.PipelineResponse ProcessMessage(this System.ServiceModel.Rest.Core.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage> pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.RequestOptions? requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ServiceModel.Rest.Core.PipelineResponse> ProcessMessageAsync(this System.ServiceModel.Rest.Core.Pipeline<System.ServiceModel.Rest.Core.PipelineMessage> pipeline, System.ServiceModel.Rest.Core.PipelineMessage message, System.ServiceModel.Rest.RequestOptions? requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace System.ServiceModel.Rest.Experimental.Core.Serialization
{
    public partial interface IUtf8JsonWriteable
    {
        void Write(System.Text.Json.Utf8JsonWriter writer);
    }
    public static partial class ModelSerializationExtensions
    {
        public static object? GetObject(this in System.Text.Json.JsonElement element) { throw null; }
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
        public OptionalDictionary(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optionalDictionary) { }
        public OptionalDictionary(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optionalDictionary) { }
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
        public OptionalList(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<System.Collections.Generic.IList<T>> optionalList) { }
        public OptionalList(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optionalList) { }
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
        public static System.Collections.Generic.IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IList<T> ToList<T>(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<System.Collections.Generic.IList<T>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyList<T> ToList<T>(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optional) { throw null; }
        public static T? ToNullable<T>(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<T?> optional) where T : struct { throw null; }
        public static T? ToNullable<T>(System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<T> optional) where T : struct { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptionalProperty<T>
    {
        private readonly T _Value_k__BackingField;
        private readonly int _dummyPrimitive;
        public OptionalProperty(T value) { throw null; }
        public bool HasValue { get { throw null; } }
        public T Value { get { throw null; } }
        public static implicit operator T (System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<T> optional) { throw null; }
        public static implicit operator System.ServiceModel.Rest.Experimental.Core.Serialization.OptionalProperty<T> (T value) { throw null; }
    }
    public partial class Utf8JsonRequestBody : System.ServiceModel.Rest.Core.RequestBody
    {
        public Utf8JsonRequestBody() { }
        public System.Text.Json.Utf8JsonWriter JsonWriter { get { throw null; } }
        public override void Dispose() { }
        public override bool TryComputeLength(out long length) { throw null; }
        public override void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation) { }
        public override System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation) { throw null; }
    }
}
