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
    public abstract partial class AuthenticationTokenProvider
    {
        protected AuthenticationTokenProvider() { }
        public abstract System.ClientModel.Primitives.GetTokenOptions? CreateTokenOptions(System.Collections.Generic.IReadOnlyDictionary<string, object> properties);
        public abstract System.ClientModel.Primitives.AuthenticationToken GetToken(System.ClientModel.Primitives.GetTokenOptions options, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.ValueTask<System.ClientModel.Primitives.AuthenticationToken> GetTokenAsync(System.ClientModel.Primitives.GetTokenOptions options, System.Threading.CancellationToken cancellationToken);
    }
    public abstract partial class BinaryContent : System.IDisposable
    {
        protected BinaryContent() { }
        public string? MediaType { get { throw null; } protected set { } }
        public static System.ClientModel.BinaryContent Create(System.BinaryData value) { throw null; }
        public static System.ClientModel.BinaryContent Create(System.IO.Stream stream) { throw null; }
        public static System.ClientModel.BinaryContent CreateJson(string jsonString, bool validate = false) { throw null; }
        public static System.ClientModel.BinaryContent CreateJson<T>(T jsonSerializable, System.Text.Json.JsonSerializerOptions? options = null) { throw null; }
        public static System.ClientModel.BinaryContent CreateJson<T>(T jsonSerializable, System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> jsonTypeInfo) { throw null; }
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
    public static partial class ConfigurationManagerExtensions
    {
        public static System.ClientModel.Primitives.ClientConnection GetConnection(this Microsoft.Extensions.Configuration.IConfigurationManager configuration, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.ClientConnection GetConnection(this Microsoft.Extensions.Configuration.IConfigurationSection section) { throw null; }
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
    public static partial class ActivityExtensions
    {
        public static System.Diagnostics.Activity MarkClientActivityFailed(this System.Diagnostics.Activity activity, System.Exception? exception) { throw null; }
        public static System.Diagnostics.Activity? StartClientActivity(this System.Diagnostics.ActivitySource activitySource, System.ClientModel.Primitives.ClientPipelineOptions options, string name, System.Diagnostics.ActivityKind kind = System.Diagnostics.ActivityKind.Internal, System.Diagnostics.ActivityContext parentContext = default(System.Diagnostics.ActivityContext), System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object?>>? tags = null) { throw null; }
    }
    public partial class ApiKeyAuthenticationPolicy : System.ClientModel.Primitives.AuthenticationPolicy
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
    public abstract partial class AuthenticationPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        protected AuthenticationPolicy() { }
    }
    public partial class AuthenticationToken
    {
        public AuthenticationToken(string tokenValue, string tokenType, System.DateTimeOffset expiresOn, System.DateTimeOffset? refreshOn = default(System.DateTimeOffset?)) { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.DateTimeOffset? RefreshOn { get { throw null; } }
        public string TokenType { get { throw null; } }
        public string TokenValue { get { throw null; } }
    }
    public partial class BearerTokenPolicy : System.ClientModel.Primitives.AuthenticationPolicy
    {
        public BearerTokenPolicy(System.ClientModel.AuthenticationTokenProvider tokenProvider, System.Collections.Generic.IEnumerable<System.Collections.Generic.IReadOnlyDictionary<string, object>> contexts) { }
        public BearerTokenPolicy(System.ClientModel.AuthenticationTokenProvider tokenProvider, string scope) { }
        public override void Process(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { throw null; }
    }
    public partial class ClientCache
    {
        public ClientCache(int maxSize) { }
        public T GetClient<T>(object clientId, System.Func<T> createClient) where T : class { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientConnection
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientConnection(string id, string locator) { throw null; }
        public ClientConnection(string id, string locator, object credential, System.ClientModel.Primitives.CredentialKind credentialKind) { throw null; }
        public ClientConnection(string id, string locator, object? credential, System.ClientModel.Primitives.CredentialKind credentialKind, System.Collections.Generic.IReadOnlyDictionary<string, string>? metadata) { throw null; }
        public ClientConnection(string id, string locator, object? credential, System.ClientModel.Primitives.CredentialKind credentialKind, System.Collections.Generic.IReadOnlyDictionary<string, string>? metadata, Microsoft.Extensions.Configuration.IConfigurationSection? configurationSection) { throw null; }
        public Microsoft.Extensions.Configuration.IConfiguration? Configuration { get { throw null; } }
        public object? Credential { get { throw null; } }
        public System.ClientModel.Primitives.CredentialKind CredentialKind { get { throw null; } }
        public string Id { get { throw null; } }
        public string Locator { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public override string ToString() { throw null; }
        public bool TryGetLocatorAsUri(out System.Uri? uri) { throw null; }
    }
    public partial class ClientConnectionCollection : System.Collections.ObjectModel.KeyedCollection<string, System.ClientModel.Primitives.ClientConnection>
    {
        public ClientConnectionCollection() { }
        public void AddRange(System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> connections) { }
        protected override string GetKeyForItem(System.ClientModel.Primitives.ClientConnection item) { throw null; }
    }
    public abstract partial class ClientConnectionProvider
    {
        protected ClientConnectionProvider(int maxCacheSize) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.ClientModel.Primitives.ClientCache Subclients { get { throw null; } }
        public abstract System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections();
        public abstract System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId);
    }
    [System.FlagsAttribute]
    public enum ClientErrorBehaviors
    {
        Default = 0,
        NoThrow = 1,
    }
    public partial class ClientLoggingOptions
    {
        public ClientLoggingOptions() { }
        public System.Collections.Generic.IList<string> AllowedHeaderNames { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedQueryParameters { get { throw null; } }
        public bool? EnableLogging { get { throw null; } set { } }
        public bool? EnableMessageContentLogging { get { throw null; } set { } }
        public bool? EnableMessageLogging { get { throw null; } set { } }
        public Microsoft.Extensions.Logging.ILoggerFactory? LoggerFactory { get { throw null; } set { } }
        public int? MessageContentSizeLimit { get { throw null; } set { } }
        protected void AssertNotFrozen() { }
        public virtual void Freeze() { }
    }
    public sealed partial class ClientPipeline
    {
        internal ClientPipeline() { }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.Primitives.ClientPipelineOptions? options = null) { throw null; }
        public static System.ClientModel.Primitives.ClientPipeline Create(System.ClientModel.Primitives.ClientPipelineOptions options, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> perCallPolicies, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> perTryPolicies, System.ReadOnlySpan<System.ClientModel.Primitives.PipelinePolicy> beforeTransportPolicies) { throw null; }
        public System.ClientModel.Primitives.PipelineMessage CreateMessage() { throw null; }
        public System.ClientModel.Primitives.PipelineMessage CreateMessage(System.Uri uri, string method, System.ClientModel.Primitives.PipelineMessageClassifier? classifier = null) { throw null; }
        public void Send(System.ClientModel.Primitives.PipelineMessage message) { }
        public System.Threading.Tasks.ValueTask SendAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public partial class ClientPipelineOptions
    {
        public ClientPipelineOptions() { }
        public System.ClientModel.Primitives.ClientLoggingOptions? ClientLoggingOptions { get { throw null; } set { } }
        public bool? EnableDistributedTracing { get { throw null; } set { } }
        public System.ClientModel.Primitives.PipelinePolicy? MessageLoggingPolicy { get { throw null; } set { } }
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
        public ClientRetryPolicy(int maxRetries, bool enableLogging, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory) { }
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
    public enum CredentialKind
    {
        None = 0,
        ApiKeyString = 1,
        TokenCredential = 2,
    }
    public partial class GetTokenOptions
    {
        public const string AuthorizationUrlPropertyName = "authorizationUrl";
        public const string RefreshUrlPropertyName = "refreshUrl";
        public const string ScopesPropertyName = "scopes";
        public const string TokenUrlPropertyName = "tokenUrl";
        public GetTokenOptions(System.Collections.Generic.IReadOnlyDictionary<string, object> properties) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
    }
    public partial class HttpClientPipelineTransport : System.ClientModel.Primitives.PipelineTransport, System.IDisposable
    {
        public HttpClientPipelineTransport() { }
        public HttpClientPipelineTransport(System.Net.Http.HttpClient client) { }
        public HttpClientPipelineTransport(System.Net.Http.HttpClient? client, bool enableLogging, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory) { }
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
        T? Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options);
        void Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options);
    }
    public partial interface IPersistableModel<out T>
    {
        T? Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options);
        string GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options);
        System.BinaryData Write(System.ClientModel.Primitives.ModelReaderWriterOptions options);
    }
    public partial class JsonModelConverter : System.Text.Json.Serialization.JsonConverter<System.ClientModel.Primitives.IJsonModel<object>>
    {
        public JsonModelConverter() { }
        public JsonModelConverter(System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public JsonModelConverter(System.ClientModel.Primitives.ModelReaderWriterOptions options, System.ClientModel.Primitives.ModelReaderWriterContext context) { }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override System.ClientModel.Primitives.IJsonModel<object>? Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.IJsonModel<object> value, System.Text.Json.JsonSerializerOptions options) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct JsonPatch
    {
        private object _dummy;
        private int _dummyPrimitive;
        public JsonPatch(System.ReadOnlyMemory<byte> utf8Json) { throw null; }
        public void Append(System.ReadOnlySpan<byte> arrayPath, System.BinaryData utf8Json) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, bool value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, byte value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, byte[] utf8Json) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, System.DateTime value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, System.DateTimeOffset value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, decimal value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, double value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, System.Guid value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, short value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, int value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, long value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, System.ReadOnlySpan<byte> utf8Json) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, sbyte value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, float value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, string value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, System.TimeSpan value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, ushort value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, uint value) { }
        public void Append(System.ReadOnlySpan<byte> arrayPath, ulong value) { }
        public void AppendNull(System.ReadOnlySpan<byte> arrayPath) { }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public bool Contains(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Contains(System.ReadOnlySpan<byte> prefix, System.ReadOnlySpan<byte> property) { throw null; }
        public bool GetBoolean(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public byte GetByte(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public System.DateTime GetDateTime(System.ReadOnlySpan<byte> jsonPath, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { throw null; }
        public System.DateTimeOffset GetDateTimeOffset(System.ReadOnlySpan<byte> jsonPath, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { throw null; }
        public decimal GetDecimal(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public double GetDouble(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public float GetFloat(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public System.Guid GetGuid(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public short GetInt16(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public int GetInt32(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public long GetInt64(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public sbyte GetInt8(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public System.BinaryData GetJson(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public T? GetNullableValue<T>(System.ReadOnlySpan<byte> jsonPath) where T : struct { throw null; }
        public string? GetString(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public System.TimeSpan GetTimeSpan(System.ReadOnlySpan<byte> jsonPath, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { throw null; }
        public ushort GetUInt16(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public uint GetUInt32(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public ulong GetUInt64(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public bool IsRemoved(System.ReadOnlySpan<byte> jsonPath) { throw null; }
        public void Remove(System.ReadOnlySpan<byte> jsonPath) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, System.BinaryData utf8Json) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, bool value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, byte value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, byte[] utf8Json) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Set(System.ReadOnlySpan<byte> jsonPath, System.ClientModel.Primitives.JsonPatch.EncodedValue value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, System.DateTime value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, System.DateTimeOffset value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, decimal value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, double value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, System.Guid value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, short value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, int value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, long value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, System.ReadOnlySpan<byte> utf8Json) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, sbyte value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, float value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, string value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, System.TimeSpan value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, ushort value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, uint value) { }
        public void Set(System.ReadOnlySpan<byte> jsonPath, ulong value) { }
        public void SetNull(System.ReadOnlySpan<byte> jsonPath) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void SetPropagators(System.ClientModel.Primitives.JsonPatch.PropagatorSetter setter, System.ClientModel.Primitives.JsonPatch.PropagatorGetter getter) { }
        public override string ToString() { throw null; }
        public string ToString(string format) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TryGetEncodedValue(System.ReadOnlySpan<byte> jsonPath, out System.ClientModel.Primitives.JsonPatch.EncodedValue value) { throw null; }
        public bool TryGetJson(System.ReadOnlySpan<byte> jsonPath, out System.ReadOnlyMemory<byte> value) { throw null; }
        public bool TryGetNullableValue<T>(System.ReadOnlySpan<byte> jsonPath, out T? value) where T : struct { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out bool value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out byte value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out System.DateTime value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out System.DateTimeOffset value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out decimal value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out double value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out System.Guid value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out short value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out int value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out long value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out sbyte value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out float value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out string? value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out System.TimeSpan value, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out ushort value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out uint value) { throw null; }
        public bool TryGetValue(System.ReadOnlySpan<byte> jsonPath, out ulong value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer, System.ReadOnlySpan<byte> jsonPath) { }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct EncodedValue
        {
            private object _dummy;
            private int _dummyPrimitive;
        }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public delegate bool PropagatorGetter(System.ReadOnlySpan<byte> jsonPath, out System.ClientModel.Primitives.JsonPatch.EncodedValue value);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public delegate bool PropagatorSetter(System.ReadOnlySpan<byte> jsonPath, System.ClientModel.Primitives.JsonPatch.EncodedValue value);
    }
    public partial class MessageLoggingPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        public MessageLoggingPolicy(System.ClientModel.Primitives.ClientLoggingOptions? options = null) { }
        public static System.ClientModel.Primitives.MessageLoggingPolicy Default { get { throw null; } }
        public sealed override void Process(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { }
        public sealed override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { throw null; }
    }
    public static partial class ModelReaderWriter
    {
        public static object? Read(System.BinaryData data, System.Type returnType, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) { throw null; }
        public static object? Read(System.BinaryData data, System.Type returnType, System.ClientModel.Primitives.ModelReaderWriterOptions options, System.ClientModel.Primitives.ModelReaderWriterContext context) { throw null; }
        public static T? Read<T>(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) { throw null; }
        public static T? Read<T>(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options, System.ClientModel.Primitives.ModelReaderWriterContext context) { throw null; }
        public static System.BinaryData Write(object model, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.BinaryData Write(object model, System.ClientModel.Primitives.ModelReaderWriterOptions options, System.ClientModel.Primitives.ModelReaderWriterContext context) { throw null; }
        public static System.BinaryData Write<T>(T model, System.ClientModel.Primitives.ModelReaderWriterOptions? options = null) { throw null; }
        public static System.BinaryData Write<T>(T model, System.ClientModel.Primitives.ModelReaderWriterOptions options, System.ClientModel.Primitives.ModelReaderWriterContext context) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class, AllowMultiple=true)]
    public partial class ModelReaderWriterBuildableAttribute : System.Attribute
    {
        public ModelReaderWriterBuildableAttribute(System.Type type) { }
    }
    public abstract partial class ModelReaderWriterContext
    {
        protected ModelReaderWriterContext() { }
        public System.ClientModel.Primitives.ModelReaderWriterTypeBuilder GetTypeBuilder(System.Type type) { throw null; }
        public bool TryGetTypeBuilder(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder? builder) { throw null; }
        protected virtual bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder? builder) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly)]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public sealed partial class ModelReaderWriterContextTypeAttribute : System.Attribute
    {
        public ModelReaderWriterContextTypeAttribute(System.Type contextType) { }
    }
    public partial class ModelReaderWriterOptions
    {
        public ModelReaderWriterOptions(string format) { }
        public string Format { get { throw null; } }
        public static System.ClientModel.Primitives.ModelReaderWriterOptions Json { get { throw null; } }
        public static System.ClientModel.Primitives.ModelReaderWriterOptions Xml { get { throw null; } }
    }
    public abstract partial class ModelReaderWriterTypeBuilder
    {
        protected ModelReaderWriterTypeBuilder() { }
        protected abstract System.Type BuilderType { get; }
        protected virtual System.Type? ItemType { get { throw null; } }
        protected virtual void AddItem(object collectionBuilder, object? item) { }
        protected virtual void AddItemWithKey(object collectionBuilder, string key, object? item) { }
        protected virtual object ConvertCollectionBuilder(object collectionBuilder) { throw null; }
        protected abstract object CreateInstance();
        protected virtual System.Collections.IEnumerable? GetItems(object collection) { throw null; }
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
        public virtual string ClientRequestId { get { throw null; } }
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
        protected PipelineTransport(bool enableLogging, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory) { }
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
    public partial class UserAgentPolicy : System.ClientModel.Primitives.PipelinePolicy
    {
        public UserAgentPolicy(System.Reflection.Assembly callerAssembly, string? applicationId = null) { }
        public string? ApplicationId { get { throw null; } }
        public System.Reflection.Assembly Assembly { get { throw null; } }
        public string UserAgentValue { get { throw null; } }
        public override void Process(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(System.ClientModel.Primitives.PipelineMessage message, System.Collections.Generic.IReadOnlyList<System.ClientModel.Primitives.PipelinePolicy> pipeline, int currentIndex) { throw null; }
    }
}
