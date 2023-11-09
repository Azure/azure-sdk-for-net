namespace System.Net.ClientModel
{
    public partial class ClientRequestException : System.Exception
    {
        public ClientRequestException(System.Net.ClientModel.Core.MessageResponse response) { }
        protected ClientRequestException(System.Net.ClientModel.Core.MessageResponse response, string message, System.Exception? innerException) { }
        protected ClientRequestException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public int Status { get { throw null; } }
        public virtual System.Net.ClientModel.Core.MessageResponse? GetRawResponse() { throw null; }
    }
    public partial class KeyCredential
    {
        public KeyCredential(string key) { }
        public string Key { get { throw null; } }
        public void Update(string key) { }
    }
    public static partial class ModelReaderWriter
    {
        public static object? Read(System.BinaryData data, System.Type returnType, System.Net.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public static T? Read<T>(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions? options = null) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
        public static System.BinaryData Write(object model, System.Net.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.BinaryData Write<T>(T model, System.Net.ClientModel.ModelReaderWriterOptions? options = null) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
    }
    public partial class ModelReaderWriterOptions
    {
        public ModelReaderWriterOptions(string format) { }
        public string Format { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterOptions Json { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterOptions Wire { get { throw null; } }
        public static System.Net.ClientModel.ModelReaderWriterOptions Xml { get { throw null; } }
    }
    public partial class NullableResult<T> : System.Net.ClientModel.Result
    {
        internal NullableResult() { }
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
        public override System.Net.ClientModel.Core.MessageResponse GetRawResponse() { throw null; }
    }
    public partial class RequestOptions : System.Net.ClientModel.Core.PipelineOptions
    {
        public RequestOptions() { }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public static System.Threading.CancellationToken DefaultCancellationToken { get { throw null; } set { } }
        public virtual System.Net.ClientModel.Core.ErrorBehavior ErrorBehavior { get { throw null; } set { } }
        public virtual void Apply(System.Net.ClientModel.Core.PipelineMessage message) { }
    }
    public abstract partial class Result
    {
        protected Result() { }
        public static System.Net.ClientModel.NullableResult<T> FromNullableValue<T>(T? value, System.Net.ClientModel.Core.MessageResponse response) { throw null; }
        public static System.Net.ClientModel.Result FromResponse(System.Net.ClientModel.Core.MessageResponse response) { throw null; }
        public static System.Net.ClientModel.Result<T> FromValue<T>(T value, System.Net.ClientModel.Core.MessageResponse response) { throw null; }
        public abstract System.Net.ClientModel.Core.MessageResponse GetRawResponse();
    }
    public partial class Result<T> : System.Net.ClientModel.NullableResult<T>
    {
        internal Result() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasValue { get { throw null; } }
        public override T Value { get { throw null; } }
    }
}
namespace System.Net.ClientModel.Core
{
    public partial class ClientPipeline
    {
        public ClientPipeline(System.Net.ClientModel.Core.PipelineTransport transport, System.ReadOnlyMemory<System.Net.ClientModel.Core.PipelinePolicy> policies) { }
        public static System.Net.ClientModel.Core.ClientPipeline Create(System.Net.ClientModel.Core.PipelineOptions options) { throw null; }
        public System.Net.ClientModel.Core.PipelineMessage CreateMessage() { throw null; }
        public void Send(System.Net.ClientModel.Core.PipelineMessage message) { }
        public System.Threading.Tasks.ValueTask SendAsync(System.Net.ClientModel.Core.PipelineMessage message) { throw null; }
    }
    [System.FlagsAttribute]
    public enum ErrorBehavior
    {
        Default = 0,
        NoThrow = 1,
    }
    public partial interface IJsonModel<out T> : System.Net.ClientModel.Core.IModel<T>
    {
        T Create(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options);
        void Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options);
    }
    public partial interface IModel<out T>
    {
        T Create(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options);
        string GetWireFormat(System.Net.ClientModel.ModelReaderWriterOptions options);
        System.BinaryData Write(System.Net.ClientModel.ModelReaderWriterOptions options);
    }
    public partial class KeyCredentialAuthenticationPolicy : System.Net.ClientModel.Core.PipelinePolicy
    {
        public KeyCredentialAuthenticationPolicy(System.Net.ClientModel.KeyCredential credential, string headerName, string? keyPrefix = null) { }
        public override void Process(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineProcessor pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineProcessor pipeline) { throw null; }
    }
    public partial class MessageClassifier
    {
        protected internal MessageClassifier() { }
        public virtual bool IsError(System.Net.ClientModel.Core.PipelineMessage message) { throw null; }
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
    public abstract partial class MessageRequest : System.IDisposable
    {
        protected MessageRequest() { }
        public abstract System.Net.ClientModel.Core.RequestBodyContent? Content { get; set; }
        public abstract System.Net.ClientModel.Core.MessageHeaders Headers { get; }
        public abstract string Method { get; set; }
        public abstract System.Uri Uri { get; set; }
        public abstract void Dispose();
    }
    public abstract partial class MessageResponse : System.IDisposable
    {
        protected MessageResponse() { }
        public System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; protected internal set; }
        public abstract System.Net.ClientModel.Core.MessageHeaders Headers { get; }
        public bool IsError { get { throw null; } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public abstract void Dispose();
    }
    public partial class ModelJsonConverter : System.Text.Json.Serialization.JsonConverter<System.Net.ClientModel.Core.IJsonModel<object>>
    {
        public ModelJsonConverter() { }
        public ModelJsonConverter(System.Net.ClientModel.ModelReaderWriterOptions options) { }
        public System.Net.ClientModel.ModelReaderWriterOptions Options { get { throw null; } }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override System.Net.ClientModel.Core.IJsonModel<object> Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.Core.IJsonModel<object> value, System.Text.Json.JsonSerializerOptions options) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public sealed partial class ModelReaderProxyAttribute : System.Attribute
    {
        public ModelReaderProxyAttribute(System.Type proxyType) { }
        public System.Type ProxyType { get { throw null; } }
    }
    public partial class PipelineMessage : System.IDisposable
    {
        protected internal PipelineMessage(System.Net.ClientModel.Core.MessageRequest request) { }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public bool HasResponse { get { throw null; } }
        public virtual System.Net.ClientModel.Core.MessageClassifier MessageClassifier { get { throw null; } set { } }
        public virtual System.Net.ClientModel.Core.MessageRequest Request { get { throw null; } }
        public virtual System.Net.ClientModel.Core.MessageResponse Response { get { throw null; } protected internal set { } }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void SetProperty(System.Type type, object value) { }
        public bool TryGetProperty(System.Type type, out object? value) { throw null; }
    }
    public partial class PipelineOptions
    {
        public PipelineOptions() { }
        public System.Net.ClientModel.Core.PipelinePolicy? LoggingPolicy { get { throw null; } set { } }
        public virtual System.Net.ClientModel.Core.MessageClassifier? MessageClassifier { get { throw null; } set { } }
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelinePolicy[]? PerCallPolicies { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelinePolicy[]? PerTryPolicies { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelinePolicy? RetryPolicy { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelineTransport? Transport { get { throw null; } set { } }
    }
    public abstract partial class PipelinePolicy
    {
        protected PipelinePolicy() { }
        public abstract void Process(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineProcessor pipeline);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineProcessor pipeline);
    }
    public abstract partial class PipelineProcessor
    {
        protected PipelineProcessor() { }
        public abstract int Length { get; }
        public abstract bool ProcessNext();
        public abstract System.Threading.Tasks.ValueTask<bool> ProcessNextAsync();
    }
    public abstract partial class PipelineTransport : System.Net.ClientModel.Core.PipelinePolicy
    {
        protected PipelineTransport() { }
        public abstract System.Net.ClientModel.Core.PipelineMessage CreateMessage();
        public abstract void Process(System.Net.ClientModel.Core.PipelineMessage message);
        public override void Process(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineProcessor pipeline) { }
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message);
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineProcessor pipeline) { throw null; }
    }
    public abstract partial class RequestBodyContent : System.IDisposable
    {
        protected RequestBodyContent() { }
        public static System.Net.ClientModel.Core.RequestBodyContent Create(System.BinaryData value) { throw null; }
        public static System.Net.ClientModel.Core.RequestBodyContent Create(System.Net.ClientModel.Core.IModel<object> model, System.Net.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken);
    }
    public partial class ResponseBufferingPolicy : System.Net.ClientModel.Core.PipelinePolicy
    {
        public ResponseBufferingPolicy(System.TimeSpan networkTimeout) { }
        public override void Process(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineProcessor pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineProcessor pipeline) { throw null; }
        public static void SetBufferResponse(System.Net.ClientModel.Core.PipelineMessage message, bool bufferResponse) { }
        public static void SetNetworkTimeout(System.Net.ClientModel.Core.PipelineMessage message, System.TimeSpan networkTimeout) { }
        public static bool TryGetBufferResponse(System.Net.ClientModel.Core.PipelineMessage message, out bool bufferResponse) { throw null; }
        public static bool TryGetNetworkTimeout(System.Net.ClientModel.Core.PipelineMessage message, out System.TimeSpan networkTimeout) { throw null; }
    }
    public partial class ResponseStatusClassifier : System.Net.ClientModel.Core.MessageClassifier
    {
        public ResponseStatusClassifier(System.ReadOnlySpan<ushort> successStatusCodes) { }
        public override bool IsError(System.Net.ClientModel.Core.PipelineMessage message) { throw null; }
    }
}
namespace System.Net.ClientModel.Internal
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
    public partial interface IUtf8JsonContentWriteable
    {
        void Write(System.Text.Json.Utf8JsonWriter writer);
    }
    public static partial class ModelReaderWriterExtensions
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
    public static partial class ModelReaderWriterHelper
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public static void ValidateFormat(System.Net.ClientModel.Core.IModel<object> model, string format) { }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public static void ValidateFormat<T>(System.Net.ClientModel.Core.IModel<T> model, string format) { }
    }
    public partial class OptionalDictionary<TKey, TValue> : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IDictionary<TKey, TValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>, System.Collections.IEnumerable where TKey : notnull
    {
        public OptionalDictionary() { }
        public OptionalDictionary(System.Net.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optionalDictionary) { }
        public OptionalDictionary(System.Net.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optionalDictionary) { }
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
        public OptionalList(System.Net.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IList<T>> optionalList) { }
        public OptionalList(System.Net.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optionalList) { }
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
        public static System.Collections.Generic.IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.Net.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.Net.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IList<T> ToList<T>(System.Net.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IList<T>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyList<T> ToList<T>(System.Net.ClientModel.Internal.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optional) { throw null; }
        public static T? ToNullable<T>(System.Net.ClientModel.Internal.OptionalProperty<T?> optional) where T : struct { throw null; }
        public static T? ToNullable<T>(System.Net.ClientModel.Internal.OptionalProperty<T> optional) where T : struct { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptionalProperty<T>
    {
        private readonly T _Value_k__BackingField;
        private readonly int _dummyPrimitive;
        public OptionalProperty(T value) { throw null; }
        public bool HasValue { get { throw null; } }
        public T Value { get { throw null; } }
        public static implicit operator T (System.Net.ClientModel.Internal.OptionalProperty<T> optional) { throw null; }
        public static implicit operator System.Net.ClientModel.Internal.OptionalProperty<T> (T value) { throw null; }
    }
    public static partial class PipelineProtocolExtensions
    {
        public static System.Net.ClientModel.NullableResult<bool> ProcessHeadAsBoolMessage(this System.Net.ClientModel.Core.ClientPipeline pipeline, System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.RequestOptions requestContext) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.Net.ClientModel.NullableResult<bool>> ProcessHeadAsBoolMessageAsync(this System.Net.ClientModel.Core.ClientPipeline pipeline, System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.RequestOptions requestContext) { throw null; }
        public static System.Net.ClientModel.Core.MessageResponse ProcessMessage(this System.Net.ClientModel.Core.ClientPipeline pipeline, System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.RequestOptions requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.Net.ClientModel.Core.MessageResponse> ProcessMessageAsync(this System.Net.ClientModel.Core.ClientPipeline pipeline, System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.RequestOptions requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Utf8JsonContentWriter : System.IDisposable
    {
        public Utf8JsonContentWriter() { }
        public System.BinaryData WrittenContent { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void Write(System.Net.ClientModel.Internal.IUtf8JsonContentWriteable content) { }
    }
}
namespace System.Net.ClientModel.Internal.Core
{
    public partial class HttpClientPipelineTransport : System.Net.ClientModel.Core.PipelineTransport, System.IDisposable
    {
        public HttpClientPipelineTransport() { }
        public HttpClientPipelineTransport(System.Net.Http.HttpClient client) { }
        public override System.Net.ClientModel.Core.PipelineMessage CreateMessage() { throw null; }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void OnReceivedResponse(System.Net.ClientModel.Core.PipelineMessage message, System.Net.Http.HttpResponseMessage httpResponse) { }
        protected virtual void OnSendingRequest(System.Net.ClientModel.Core.PipelineMessage message, System.Net.Http.HttpRequestMessage httpRequest) { }
        public override void Process(System.Net.ClientModel.Core.PipelineMessage message) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message) { throw null; }
    }
    public partial class HttpMessageRequest : System.Net.ClientModel.Core.MessageRequest, System.IDisposable
    {
        protected internal HttpMessageRequest() { }
        public override System.Net.ClientModel.Core.RequestBodyContent? Content { get { throw null; } set { } }
        public override System.Net.ClientModel.Core.MessageHeaders Headers { get { throw null; } }
        public override string Method { get { throw null; } set { } }
        public override System.Uri Uri { get { throw null; } set { } }
        public override void Dispose() { }
        public override string ToString() { throw null; }
    }
    public partial class HttpMessageResponse : System.Net.ClientModel.Core.MessageResponse, System.IDisposable
    {
        protected internal HttpMessageResponse(System.Net.Http.HttpResponseMessage httpResponse) { }
        public override System.IO.Stream? ContentStream { get { throw null; } protected internal set { } }
        public override System.Net.ClientModel.Core.MessageHeaders Headers { get { throw null; } }
        public override string ReasonPhrase { get { throw null; } }
        public override int Status { get { throw null; } }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
    }
}
