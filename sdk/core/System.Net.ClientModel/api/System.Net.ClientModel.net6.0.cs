namespace System.Net.ClientModel
{
    public partial class KeyCredential
    {
        public KeyCredential(string key) { }
        public bool TryGetKey(out string key) { throw null; }
        public void Update(string key) { }
    }
    public partial class NullableResult<T> : System.Net.ClientModel.Result
    {
        internal NullableResult() { }
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
        public override System.Net.ClientModel.Core.PipelineResponse GetRawResponse() { throw null; }
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
        public static System.Net.ClientModel.NullableResult<T> FromNullableValue<T>(T? value, System.Net.ClientModel.Core.PipelineResponse response) { throw null; }
        public static System.Net.ClientModel.Result FromResponse(System.Net.ClientModel.Core.PipelineResponse response) { throw null; }
        public static System.Net.ClientModel.Result<T> FromValue<T>(T value, System.Net.ClientModel.Core.PipelineResponse response) { throw null; }
        public abstract System.Net.ClientModel.Core.PipelineResponse GetRawResponse();
    }
    public partial class Result<T> : System.Net.ClientModel.NullableResult<T>
    {
        internal Result() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasValue { get { throw null; } }
        public override T Value { get { throw null; } }
    }
    public partial class UnsuccessfulRequestException : System.Exception
    {
        public UnsuccessfulRequestException(System.Net.ClientModel.Core.PipelineResponse response) { }
        protected UnsuccessfulRequestException(System.Net.ClientModel.Core.PipelineResponse response, string message, System.Exception? innerException) { }
        protected UnsuccessfulRequestException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public int Status { get { throw null; } }
    }
}
namespace System.Net.ClientModel.Core
{
    [System.FlagsAttribute]
    public enum ErrorBehavior
    {
        Default = 0,
        NoThrow = 1,
    }
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
    public partial class HttpPipelineRequest : System.Net.ClientModel.Core.PipelineRequest, System.IDisposable
    {
        protected internal HttpPipelineRequest() { }
        public override System.Net.ClientModel.Core.MessageBody? Content { get { throw null; } set { } }
        public override System.Net.ClientModel.Core.MessageHeaders Headers { get { throw null; } }
        public override string Method { get { throw null; } set { } }
        public override System.Uri Uri { get { throw null; } set { } }
        public override void Dispose() { }
        public override string ToString() { throw null; }
    }
    public partial class HttpPipelineResponse : System.Net.ClientModel.Core.PipelineResponse, System.IDisposable
    {
        protected internal HttpPipelineResponse(System.Net.Http.HttpResponseMessage httpResponse) { }
        public override System.Net.ClientModel.Core.MessageBody? Content { get { throw null; } protected internal set { } }
        public override System.Net.ClientModel.Core.MessageHeaders Headers { get { throw null; } }
        public override string ReasonPhrase { get { throw null; } }
        public override int Status { get { throw null; } }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
    }
    public partial interface IJsonModel<out T> : System.Net.ClientModel.Core.IModel<T>
    {
        T Read(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.Core.ModelReaderWriterOptions options);
        void Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.Core.ModelReaderWriterOptions options);
    }
    public partial interface IModel<out T>
    {
        T Read(System.BinaryData data, System.Net.ClientModel.Core.ModelReaderWriterOptions options);
        System.BinaryData Write(System.Net.ClientModel.Core.ModelReaderWriterOptions options);
    }
    public partial class KeyCredentialAuthenticationPolicy : System.Net.ClientModel.Core.PipelinePolicy
    {
        public KeyCredentialAuthenticationPolicy(System.Net.ClientModel.KeyCredential credential, string header, string? keyPrefix = null) { }
        public override void Process(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineEnumerator pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineEnumerator pipeline) { throw null; }
    }
    public abstract partial class MessageBody : System.IDisposable
    {
        protected MessageBody() { }
        public static System.Net.ClientModel.Core.MessageBody CreateBody(System.BinaryData value) { throw null; }
        public static System.Net.ClientModel.Core.MessageBody CreateBody(System.IO.Stream stream) { throw null; }
        public static System.Net.ClientModel.Core.MessageBody CreateBody(System.Net.ClientModel.Core.IJsonModel<object> model, System.Net.ClientModel.Core.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.Net.ClientModel.Core.MessageBody CreateBody(System.Net.ClientModel.Core.IModel<object> model, System.Net.ClientModel.Core.ModelReaderWriterOptions? options = null) { throw null; }
        public abstract void Dispose();
        public static explicit operator System.IO.Stream (System.Net.ClientModel.Core.MessageBody content) { throw null; }
        public static implicit operator System.BinaryData (System.Net.ClientModel.Core.MessageBody content) { throw null; }
        public static implicit operator System.ReadOnlyMemory<byte> (System.Net.ClientModel.Core.MessageBody content) { throw null; }
        protected virtual System.BinaryData ToBinaryData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual System.Threading.Tasks.Task<System.BinaryData> ToBinaryDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual System.IO.Stream ToStream(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual System.Threading.Tasks.Task<System.IO.Stream> ToStreamAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken);
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
    public partial class MessagePipeline
    {
        public MessagePipeline(System.Net.ClientModel.Core.PipelineTransport transport, System.ReadOnlyMemory<System.Net.ClientModel.Core.PipelinePolicy> policies) { }
        public static System.Net.ClientModel.Core.MessagePipeline Create(System.Net.ClientModel.Core.PipelineOptions options, params System.Net.ClientModel.Core.PipelinePolicy[] perTryPolicies) { throw null; }
        public static System.Net.ClientModel.Core.MessagePipeline Create(System.Net.ClientModel.Core.PipelineOptions options, System.ReadOnlySpan<System.Net.ClientModel.Core.PipelinePolicy> perCallPolicies, System.ReadOnlySpan<System.Net.ClientModel.Core.PipelinePolicy> perTryPolicies) { throw null; }
        public System.Net.ClientModel.Core.PipelineMessage CreateMessage() { throw null; }
        public void Send(System.Net.ClientModel.Core.PipelineMessage message) { }
        public System.Threading.Tasks.ValueTask SendAsync(System.Net.ClientModel.Core.PipelineMessage message) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute("The constructors of the type being deserialized are dynamically accessed and may be trimmed.")]
    public partial class ModelJsonConverter : System.Text.Json.Serialization.JsonConverter<System.Net.ClientModel.Core.IJsonModel<object>>
    {
        public ModelJsonConverter() { }
        public ModelJsonConverter(System.Net.ClientModel.Core.ModelReaderWriterFormat format) { }
        public ModelJsonConverter(System.Net.ClientModel.Core.ModelReaderWriterOptions options) { }
        public System.Net.ClientModel.Core.ModelReaderWriterOptions ModelReaderWriterOptions { get { throw null; } }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override System.Net.ClientModel.Core.IJsonModel<object> Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.Core.IJsonModel<object> value, System.Text.Json.JsonSerializerOptions options) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public sealed partial class ModelReaderProxyAttribute : System.Attribute
    {
        public ModelReaderProxyAttribute([System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)] System.Type proxyType) { }
        [System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)]
        public System.Type ProxyType { get { throw null; } }
    }
    public static partial class ModelReaderWriter
    {
        public static object? Read(System.BinaryData data, [System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)] System.Type returnType, System.Net.ClientModel.Core.ModelReaderWriterFormat format) { throw null; }
        public static object? Read(System.BinaryData data, [System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)] System.Type returnType, System.Net.ClientModel.Core.ModelReaderWriterOptions? options = null) { throw null; }
        public static T? Read<T>(System.BinaryData data, System.Net.ClientModel.Core.ModelReaderWriterFormat format) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
        public static T? Read<T>(System.BinaryData data, System.Net.ClientModel.Core.ModelReaderWriterOptions? options = null) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
        public static System.BinaryData Write(object model, System.Net.ClientModel.Core.ModelReaderWriterFormat format) { throw null; }
        public static System.BinaryData Write(object model, System.Net.ClientModel.Core.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.BinaryData WriteCore(System.Net.ClientModel.Core.IJsonModel<object> model, System.Net.ClientModel.Core.ModelReaderWriterOptions options) { throw null; }
        public static System.BinaryData Write<T>(T model, System.Net.ClientModel.Core.ModelReaderWriterFormat format) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
        public static System.BinaryData Write<T>(T model, System.Net.ClientModel.Core.ModelReaderWriterOptions? options = null) where T : System.Net.ClientModel.Core.IModel<T> { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelReaderWriterFormat : System.IEquatable<System.Net.ClientModel.Core.ModelReaderWriterFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly System.Net.ClientModel.Core.ModelReaderWriterFormat Json;
        public static readonly System.Net.ClientModel.Core.ModelReaderWriterFormat Wire;
        public ModelReaderWriterFormat(string value) { throw null; }
        public bool Equals(System.Net.ClientModel.Core.ModelReaderWriterFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(System.Net.ClientModel.Core.ModelReaderWriterFormat left, System.Net.ClientModel.Core.ModelReaderWriterFormat right) { throw null; }
        public static implicit operator System.Net.ClientModel.Core.ModelReaderWriterFormat (string value) { throw null; }
        public static bool operator !=(System.Net.ClientModel.Core.ModelReaderWriterFormat left, System.Net.ClientModel.Core.ModelReaderWriterFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelReaderWriterOptions
    {
        public static readonly System.Net.ClientModel.Core.ModelReaderWriterOptions DefaultWireOptions;
        public ModelReaderWriterOptions() { }
        public ModelReaderWriterOptions(System.Net.ClientModel.Core.ModelReaderWriterFormat format) { }
        public System.Net.ClientModel.Core.ModelReaderWriterFormat Format { get { throw null; } }
        public static System.Net.ClientModel.Core.ModelReaderWriterOptions GetOptions(System.Net.ClientModel.Core.ModelReaderWriterFormat format) { throw null; }
    }
    public abstract partial class PipelineEnumerator
    {
        protected PipelineEnumerator() { }
        public abstract int Length { get; }
        public abstract bool ProcessNext();
        public abstract System.Threading.Tasks.ValueTask<bool> ProcessNextAsync();
    }
    public partial class PipelineMessage : System.IDisposable
    {
        protected internal PipelineMessage(System.Net.ClientModel.Core.PipelineRequest request) { }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public bool HasResponse { get { throw null; } }
        public virtual System.Net.ClientModel.Core.MessageClassifier MessageClassifier { get { throw null; } set { } }
        public virtual System.Net.ClientModel.Core.PipelineRequest Request { get { throw null; } }
        public virtual System.Net.ClientModel.Core.PipelineResponse Response { get { throw null; } protected internal set { } }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public void SetProperty(System.Type type, object value) { }
        public bool TryGetProperty(System.Type type, out object? value) { throw null; }
    }
    public partial class PipelineOptions
    {
        public PipelineOptions() { }
        public static System.Net.ClientModel.Core.PipelinePolicy? DefaultLoggingPolicy { get { throw null; } set { } }
        public static System.Net.ClientModel.Core.MessageClassifier DefaultMessageClassifier { get { throw null; } set { } }
        public static System.TimeSpan DefaultNetworkTimeout { get { throw null; } set { } }
        public static System.Net.ClientModel.Core.PipelinePolicy? DefaultRetryPolicy { get { throw null; } set { } }
        public static System.Net.ClientModel.Core.PipelineTransport? DefaultTransport { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelinePolicy? LoggingPolicy { get { throw null; } set { } }
        public virtual System.Net.ClientModel.Core.MessageClassifier MessageClassifier { get { throw null; } set { } }
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelinePolicy[]? PerCallPolicies { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelinePolicy[]? PerTryPolicies { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelinePolicy? RetryPolicy { get { throw null; } set { } }
        public System.Net.ClientModel.Core.PipelineTransport? Transport { get { throw null; } set { } }
    }
    public abstract partial class PipelinePolicy
    {
        protected PipelinePolicy() { }
        public abstract void Process(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineEnumerator pipeline);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineEnumerator pipeline);
    }
    public abstract partial class PipelineRequest : System.IDisposable
    {
        protected PipelineRequest() { }
        public abstract System.Net.ClientModel.Core.MessageBody? Content { get; set; }
        public abstract System.Net.ClientModel.Core.MessageHeaders Headers { get; }
        public abstract string Method { get; set; }
        public abstract System.Uri Uri { get; set; }
        public abstract void Dispose();
    }
    public abstract partial class PipelineResponse : System.IDisposable
    {
        protected PipelineResponse() { }
        public abstract System.Net.ClientModel.Core.MessageBody? Content { get; protected internal set; }
        public abstract System.Net.ClientModel.Core.MessageHeaders Headers { get; }
        public bool IsError { get { throw null; } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        public abstract void Dispose();
    }
    public abstract partial class PipelineTransport : System.Net.ClientModel.Core.PipelinePolicy
    {
        protected PipelineTransport() { }
        public abstract System.Net.ClientModel.Core.PipelineMessage CreateMessage();
        public abstract void Process(System.Net.ClientModel.Core.PipelineMessage message);
        public override void Process(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineEnumerator pipeline) { }
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message);
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineEnumerator pipeline) { throw null; }
    }
    public partial class ResponseBufferingPolicy : System.Net.ClientModel.Core.PipelinePolicy
    {
        public ResponseBufferingPolicy(System.TimeSpan networkTimeout) { }
        public override void Process(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineEnumerator pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.Net.ClientModel.Core.PipelineMessage message, System.Net.ClientModel.Core.PipelineEnumerator pipeline) { throw null; }
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
