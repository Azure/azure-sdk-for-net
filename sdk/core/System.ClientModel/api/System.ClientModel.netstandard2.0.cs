namespace System.ClientModel
{
    public partial class ClientRequestException : System.Exception
    {
        public ClientRequestException(System.ClientModel.Primitives.PipelineResponse response) { }
        protected ClientRequestException(System.ClientModel.Primitives.PipelineResponse response, string message, System.Exception? innerException) { }
        protected ClientRequestException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public int Status { get { throw null; } }
        public virtual System.ClientModel.Primitives.PipelineResponse? GetRawResponse() { throw null; }
    }
    public abstract partial class InputContent : System.IDisposable
    {
        protected InputContent() { }
        public static System.ClientModel.InputContent Create(System.BinaryData value) { throw null; }
        public static System.ClientModel.InputContent Create(System.ClientModel.Primitives.IPersistableModel<object> model, System.ClientModel.ModelReaderWriterOptions? options = null) { throw null; }
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken);
    }
    public partial class KeyCredential
    {
        public KeyCredential(string key) { }
        public string Key { get { throw null; } }
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
        public static System.ClientModel.ModelReaderWriterOptions Wire { get { throw null; } }
        public static System.ClientModel.ModelReaderWriterOptions Xml { get { throw null; } }
    }
    public partial class NullableOutputMessage<T> : System.ClientModel.OutputMessage where T : class, System.ClientModel.Primitives.IPersistableModel<T>
    {
        internal NullableOutputMessage() { }
        public virtual T? Value { get { throw null; } }
        public override System.ClientModel.Primitives.PipelineResponse GetRawResponse() { throw null; }
    }
    public abstract partial class OutputMessage
    {
        protected OutputMessage() { }
        public static System.ClientModel.NullableOutputMessage<T> FromNullableValue<T>(T? value, System.ClientModel.Primitives.PipelineResponse response) where T : class, System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
        public static System.ClientModel.OutputMessage FromResponse(System.ClientModel.Primitives.PipelineResponse response) { throw null; }
        public static System.ClientModel.OutputMessage<T> FromValue<T>(T value, System.ClientModel.Primitives.PipelineResponse response) where T : class, System.ClientModel.Primitives.IPersistableModel<T> { throw null; }
        public abstract System.ClientModel.Primitives.PipelineResponse GetRawResponse();
    }
    public partial class OutputMessage<T> : System.ClientModel.NullableOutputMessage<T> where T : class, System.ClientModel.Primitives.IPersistableModel<T>
    {
        internal OutputMessage() { }
        public override T Value { get { throw null; } }
    }
    public partial class RequestOptions : System.ClientModel.Primitives.PipelineOptions
    {
        public RequestOptions() { }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public virtual System.ClientModel.Primitives.ErrorBehavior ErrorBehavior { get { throw null; } set { } }
        public virtual void Apply(System.ClientModel.Primitives.PipelineMessage message) { }
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
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public static void ValidateFormat(System.ClientModel.Primitives.IPersistableModel<object> model, string format) { }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public static void ValidateFormat<T>(System.ClientModel.Primitives.IPersistableModel<T> model, string format) { }
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
        public static System.ClientModel.Primitives.PipelineResponse ProcessMessage(this System.ClientModel.Primitives.ClientPipeline pipeline, System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.RequestOptions requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ClientModel.Primitives.PipelineResponse> ProcessMessageAsync(this System.ClientModel.Primitives.ClientPipeline pipeline, System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.RequestOptions requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Utf8JsonContentWriter : System.IDisposable
    {
        public Utf8JsonContentWriter() { }
        public System.BinaryData WrittenContent { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void Write(System.ClientModel.Internal.IUtf8JsonContentWriteable content) { }
    }
}
namespace System.ClientModel.Internal.Primitives
{
    public partial class HttpClientPipelineTransport : System.ClientModel.Primitives.PipelineTransport, System.IDisposable
    {
        public HttpClientPipelineTransport() { }
        public HttpClientPipelineTransport(System.Net.Http.HttpClient client) { }
        public override System.ClientModel.Primitives.PipelineMessage CreateMessage() { throw null; }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected virtual void OnReceivedResponse(System.ClientModel.Primitives.PipelineMessage message, System.Net.Http.HttpResponseMessage httpResponse) { }
        protected virtual void OnSendingRequest(System.ClientModel.Primitives.PipelineMessage message, System.Net.Http.HttpRequestMessage httpRequest) { }
        public override void Process(System.ClientModel.Primitives.PipelineMessage message) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public partial class HttpPipelineRequest : System.ClientModel.Primitives.PipelineRequest, System.IDisposable
    {
        protected internal HttpPipelineRequest() { }
        public override System.ClientModel.InputContent? Content { get { throw null; } set { } }
        public override System.ClientModel.Primitives.MessageHeaders Headers { get { throw null; } }
        public override string Method { get { throw null; } set { } }
        public override System.Uri Uri { get { throw null; } set { } }
        public override void Dispose() { }
        public override string ToString() { throw null; }
    }
    public partial class HttpPipelineResponse : System.ClientModel.Primitives.PipelineResponse, System.IDisposable
    {
        protected internal HttpPipelineResponse(System.Net.Http.HttpResponseMessage httpResponse) { }
        public override System.IO.Stream? ContentStream { get { throw null; } protected internal set { } }
        public override System.ClientModel.Primitives.MessageHeaders Headers { get { throw null; } }
        public override string ReasonPhrase { get { throw null; } }
        public override int Status { get { throw null; } }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
    }
}
namespace System.ClientModel.Primitives
{
    public partial class ClientPipeline
    {
        internal ClientPipeline() { }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.Primitives.PipelineOptions options) { throw null; }
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
        string GetWireFormat(System.ClientModel.ModelReaderWriterOptions options);
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
        public bool HasResponse { get { throw null; } }
        public virtual System.ClientModel.Primitives.MessageClassifier MessageClassifier { get { throw null; } protected internal set { } }
        public virtual System.ClientModel.Primitives.PipelineRequest Request { get { throw null; } }
        public virtual System.ClientModel.Primitives.PipelineResponse Response { get { throw null; } protected internal set { } }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void SetProperty(System.Type type, object value) { }
        public bool TryGetProperty(System.Type type, out object? value) { throw null; }
    }
    public partial class PipelineOptions
    {
        public PipelineOptions() { }
        public System.ClientModel.Primitives.PipelinePolicy? LoggingPolicy { get { throw null; } set { } }
        public virtual System.ClientModel.Primitives.MessageClassifier? MessageClassifier { get { throw null; } set { } }
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelinePolicy[]? PerCallPolicies { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelinePolicy[]? PerTryPolicies { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelinePolicy? RetryPolicy { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelineTransport? Transport { get { throw null; } set { } }
    }
    public abstract partial class PipelinePolicy
    {
        protected PipelinePolicy() { }
        public abstract void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline);
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
        public abstract void Dispose();
    }
    public abstract partial class PipelineResponse : System.IDisposable
    {
        protected PipelineResponse() { }
        public System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; protected internal set; }
        public abstract System.ClientModel.Primitives.MessageHeaders Headers { get; }
        public bool IsError { get { throw null; } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public abstract void Dispose();
    }
    public abstract partial class PipelineTransport : System.ClientModel.Primitives.PipelinePolicy
    {
        protected PipelineTransport() { }
        public abstract System.ClientModel.Primitives.PipelineMessage CreateMessage();
        public abstract void Process(System.ClientModel.Primitives.PipelineMessage message);
        public override void Process(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { }
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message);
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineProcessor pipeline) { throw null; }
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
