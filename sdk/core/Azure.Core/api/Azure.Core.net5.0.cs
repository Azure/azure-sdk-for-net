namespace Azure
{
    public abstract partial class AsyncPageable<T> : System.Collections.Generic.IAsyncEnumerable<T> where T : notnull
    {
        protected AsyncPageable() { }
        protected AsyncPageable(System.Threading.CancellationToken cancellationToken) { }
        protected virtual System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public abstract System.Collections.Generic.IAsyncEnumerable<Azure.Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = default(int?));
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public static Azure.AsyncPageable<T> FromPages(System.Collections.Generic.IEnumerable<Azure.Page<T>> pages) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerator<T> GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string? ToString() { throw null; }
    }
    public partial class AzureKeyCredential
    {
        public AzureKeyCredential(string key) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Key { get { throw null; } }
        public void Update(string key) { }
    }
    public partial class AzureSasCredential
    {
        public AzureSasCredential(string signature) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Signature { get { throw null; } }
        public void Update(string signature) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ETag : System.IEquatable<Azure.ETag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly Azure.ETag All;
        public ETag(string etag) { throw null; }
        public bool Equals(Azure.ETag other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public bool Equals(string? other) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ETag left, Azure.ETag right) { throw null; }
        public static bool operator !=(Azure.ETag left, Azure.ETag right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public string ToString(string format) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpRange : System.IEquatable<Azure.HttpRange>
    {
        private readonly int _dummyPrimitive;
        public HttpRange(long offset = (long)0, long? length = default(long?)) { throw null; }
        public long? Length { get { throw null; } }
        public long Offset { get { throw null; } }
        public bool Equals(Azure.HttpRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.HttpRange left, Azure.HttpRange right) { throw null; }
        public static bool operator !=(Azure.HttpRange left, Azure.HttpRange right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JsonPatchDocument
    {
        public JsonPatchDocument() { }
        public JsonPatchDocument(Azure.Core.Serialization.ObjectSerializer serializer) { }
        public JsonPatchDocument(System.ReadOnlyMemory<byte> rawDocument) { }
        public JsonPatchDocument(System.ReadOnlyMemory<byte> rawDocument, Azure.Core.Serialization.ObjectSerializer serializer) { }
        public void AppendAddRaw(string path, string rawJsonValue) { }
        public void AppendAdd<T>(string path, T value) { }
        public void AppendCopy(string from, string path) { }
        public void AppendMove(string from, string path) { }
        public void AppendRemove(string path) { }
        public void AppendReplaceRaw(string path, string rawJsonValue) { }
        public void AppendReplace<T>(string path, T value) { }
        public void AppendTestRaw(string path, string rawJsonValue) { }
        public void AppendTest<T>(string path, T value) { }
        public System.ReadOnlyMemory<byte> ToBytes() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MatchConditions
    {
        public MatchConditions() { }
        public Azure.ETag? IfMatch { get { throw null; } set { } }
        public Azure.ETag? IfNoneMatch { get { throw null; } set { } }
    }
    public abstract partial class Operation<T> where T : notnull
    {
        protected Operation() { }
        public abstract bool HasCompleted { get; }
        public abstract bool HasValue { get; }
        public abstract string Id { get; }
        public abstract T Value { get; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public abstract Azure.Response GetRawResponse();
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string? ToString() { throw null; }
        public abstract Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.ValueTask<Azure.Response<T>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.ValueTask<Azure.Response<T>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken);
    }
    public abstract partial class Pageable<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable where T : notnull
    {
        protected Pageable() { }
        protected Pageable(System.Threading.CancellationToken cancellationToken) { }
        protected virtual System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public abstract System.Collections.Generic.IEnumerable<Azure.Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = default(int?));
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public static Azure.Pageable<T> FromPages(System.Collections.Generic.IEnumerable<Azure.Page<T>> pages) { throw null; }
        public virtual System.Collections.Generic.IEnumerator<T> GetEnumerator() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string? ToString() { throw null; }
    }
    public abstract partial class Page<T>
    {
        protected Page() { }
        public abstract string? ContinuationToken { get; }
        public abstract System.Collections.Generic.IReadOnlyList<T> Values { get; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public static Azure.Page<T> FromValues(System.Collections.Generic.IReadOnlyList<T> values, string? continuationToken, Azure.Response response) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public abstract Azure.Response GetRawResponse();
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string? ToString() { throw null; }
    }
    public partial class RequestConditions : Azure.MatchConditions
    {
        public RequestConditions() { }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
    }
    public partial class RequestFailedException : System.Exception, System.Runtime.Serialization.ISerializable
    {
        public RequestFailedException(int status, string message) { }
        public RequestFailedException(int status, string message, System.Exception? innerException) { }
        public RequestFailedException(int status, string message, string? errorCode, System.Exception? innerException) { }
        protected RequestFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public RequestFailedException(string message) { }
        public RequestFailedException(string message, System.Exception? innerException) { }
        public string? ErrorCode { get { throw null; } }
        public int Status { get { throw null; } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
    public abstract partial class Response : System.IDisposable
    {
        protected Response() { }
        public abstract string ClientRequestId { get; set; }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public virtual Azure.Core.ResponseHeaders Headers { get { throw null; } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        protected internal abstract bool ContainsHeader(string name);
        public abstract void Dispose();
        protected internal abstract System.Collections.Generic.IEnumerable<Azure.Core.HttpHeader> EnumerateHeaders();
        public static Azure.Response<T> FromValue<T>(T value, Azure.Response response) { throw null; }
        public override string ToString() { throw null; }
        protected internal abstract bool TryGetHeader(string name, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out string? value);
        protected internal abstract bool TryGetHeaderValues(string name, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out System.Collections.Generic.IEnumerable<string>? values);
    }
    public abstract partial class Response<T>
    {
        protected Response() { }
        public abstract T Value { get; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public abstract Azure.Response GetRawResponse();
        public static implicit operator T (Azure.Response<T> response) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Core
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct AccessToken
    {
        private object _dummy;
        private int _dummyPrimitive;
        public AccessToken(string accessToken, System.DateTimeOffset expiresOn) { throw null; }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Token { get { throw null; } }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public abstract partial class ClientOptions
    {
        protected ClientOptions() { }
        public Azure.Core.DiagnosticsOptions Diagnostics { get { throw null; } }
        public Azure.Core.RetryOptions Retry { get { throw null; } }
        public Azure.Core.Pipeline.HttpPipelineTransport Transport { get { throw null; } set { } }
        public void AddPolicy(Azure.Core.Pipeline.HttpPipelinePolicy policy, Azure.Core.HttpPipelinePosition position) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string? ToString() { throw null; }
    }
    public partial class DiagnosticsOptions
    {
        internal DiagnosticsOptions() { }
        public string? ApplicationId { get { throw null; } set { } }
        public static string? DefaultApplicationId { get { throw null; } set { } }
        public bool IsDistributedTracingEnabled { get { throw null; } set { } }
        public bool IsLoggingContentEnabled { get { throw null; } set { } }
        public bool IsLoggingEnabled { get { throw null; } set { } }
        public bool IsTelemetryEnabled { get { throw null; } set { } }
        public int LoggedContentSizeLimit { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LoggedHeaderNames { get { throw null; } }
        public System.Collections.Generic.IList<string> LoggedQueryParameters { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpHeader : System.IEquatable<Azure.Core.HttpHeader>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpHeader(string name, string value) { throw null; }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        public bool Equals(Azure.Core.HttpHeader other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
        public static partial class Common
        {
            public static readonly Azure.Core.HttpHeader FormUrlEncodedContentType;
            public static readonly Azure.Core.HttpHeader JsonAccept;
            public static readonly Azure.Core.HttpHeader JsonContentType;
            public static readonly Azure.Core.HttpHeader OctetStreamContentType;
        }
        public static partial class Names
        {
            public static string Accept { get { throw null; } }
            public static string Authorization { get { throw null; } }
            public static string ContentDisposition { get { throw null; } }
            public static string ContentLength { get { throw null; } }
            public static string ContentType { get { throw null; } }
            public static string Date { get { throw null; } }
            public static string ETag { get { throw null; } }
            public static string Host { get { throw null; } }
            public static string IfMatch { get { throw null; } }
            public static string IfModifiedSince { get { throw null; } }
            public static string IfNoneMatch { get { throw null; } }
            public static string IfUnmodifiedSince { get { throw null; } }
            public static string Range { get { throw null; } }
            public static string Referer { get { throw null; } }
            public static string UserAgent { get { throw null; } }
            public static string XMsDate { get { throw null; } }
            public static string XMsRange { get { throw null; } }
            public static string XMsRequestId { get { throw null; } }
        }
    }
    public sealed partial class HttpMessage : System.IDisposable
    {
        public HttpMessage(Azure.Core.Request request, Azure.Core.ResponseClassifier responseClassifier) { }
        public bool BufferResponse { get { throw null; } set { } }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public bool HasResponse { get { throw null; } }
        public Azure.Core.Request Request { get { throw null; } }
        public Azure.Response Response { get { throw null; } set { } }
        public Azure.Core.ResponseClassifier ResponseClassifier { get { throw null; } }
        public void Dispose() { }
        public System.IO.Stream? ExtractResponseContent() { throw null; }
        public void SetProperty(string name, object value) { }
        public bool TryGetProperty(string name, out object? value) { throw null; }
    }
    public enum HttpPipelinePosition
    {
        PerCall = 0,
        PerRetry = 1,
    }
    public abstract partial class Request : System.IDisposable
    {
        protected Request() { }
        public abstract string ClientRequestId { get; set; }
        public virtual Azure.Core.RequestContent? Content { get { throw null; } set { } }
        public Azure.Core.RequestHeaders Headers { get { throw null; } }
        public virtual Azure.Core.RequestMethod Method { get { throw null; } set { } }
        public virtual Azure.Core.RequestUriBuilder Uri { get { throw null; } set { } }
        protected internal abstract void AddHeader(string name, string value);
        protected internal abstract bool ContainsHeader(string name);
        public abstract void Dispose();
        protected internal abstract System.Collections.Generic.IEnumerable<Azure.Core.HttpHeader> EnumerateHeaders();
        protected internal abstract bool RemoveHeader(string name);
        protected internal virtual void SetHeader(string name, string value) { }
        protected internal abstract bool TryGetHeader(string name, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out string? value);
        protected internal abstract bool TryGetHeaderValues(string name, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out System.Collections.Generic.IEnumerable<string>? values);
    }
    public abstract partial class RequestContent : System.IDisposable
    {
        protected RequestContent() { }
        public static Azure.Core.RequestContent Create(System.Buffers.ReadOnlySequence<byte> bytes) { throw null; }
        public static Azure.Core.RequestContent Create(byte[] bytes) { throw null; }
        public static Azure.Core.RequestContent Create(byte[] bytes, int index, int length) { throw null; }
        public static Azure.Core.RequestContent Create(System.IO.Stream stream) { throw null; }
        public static Azure.Core.RequestContent Create(System.ReadOnlyMemory<byte> bytes) { throw null; }
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestHeaders : System.Collections.Generic.IEnumerable<Azure.Core.HttpHeader>, System.Collections.IEnumerable
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public void Add(Azure.Core.HttpHeader header) { }
        public void Add(string name, string value) { }
        public bool Contains(string name) { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Core.HttpHeader> GetEnumerator() { throw null; }
        public bool Remove(string name) { throw null; }
        public void SetValue(string name, string value) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string name, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out string? value) { throw null; }
        public bool TryGetValues(string name, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestMethod : System.IEquatable<Azure.Core.RequestMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestMethod(string method) { throw null; }
        public static Azure.Core.RequestMethod Delete { get { throw null; } }
        public static Azure.Core.RequestMethod Get { get { throw null; } }
        public static Azure.Core.RequestMethod Head { get { throw null; } }
        public string Method { get { throw null; } }
        public static Azure.Core.RequestMethod Options { get { throw null; } }
        public static Azure.Core.RequestMethod Patch { get { throw null; } }
        public static Azure.Core.RequestMethod Post { get { throw null; } }
        public static Azure.Core.RequestMethod Put { get { throw null; } }
        public static Azure.Core.RequestMethod Trace { get { throw null; } }
        public bool Equals(Azure.Core.RequestMethod other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.RequestMethod left, Azure.Core.RequestMethod right) { throw null; }
        public static bool operator !=(Azure.Core.RequestMethod left, Azure.Core.RequestMethod right) { throw null; }
        public static Azure.Core.RequestMethod Parse(string method) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestUriBuilder
    {
        public RequestUriBuilder() { }
        public string? Host { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string PathAndQuery { get { throw null; } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string? Scheme { get { throw null; } set { } }
        public void AppendPath(string value) { }
        public void AppendPath(string value, bool escape) { }
        public void AppendQuery(string name, string value) { }
        public void AppendQuery(string name, string value, bool escapeValue) { }
        public void Reset(System.Uri value) { }
        public override string ToString() { throw null; }
        public System.Uri ToUri() { throw null; }
    }
    public partial class ResponseClassifier
    {
        public ResponseClassifier() { }
        public virtual bool IsErrorResponse(Azure.Core.HttpMessage message) { throw null; }
        public virtual bool IsRetriable(Azure.Core.HttpMessage message, System.Exception exception) { throw null; }
        public virtual bool IsRetriableException(System.Exception exception) { throw null; }
        public virtual bool IsRetriableResponse(Azure.Core.HttpMessage message) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseHeaders : System.Collections.Generic.IEnumerable<Azure.Core.HttpHeader>, System.Collections.IEnumerable
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public int? ContentLength { get { throw null; } }
        public string? ContentType { get { throw null; } }
        public System.DateTimeOffset? Date { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string? RequestId { get { throw null; } }
        public bool Contains(string name) { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Core.HttpHeader> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string name, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out string? value) { throw null; }
        public bool TryGetValues(string name, [System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
    }
    public enum RetryMode
    {
        Fixed = 0,
        Exponential = 1,
    }
    public partial class RetryOptions
    {
        internal RetryOptions() { }
        public System.TimeSpan Delay { get { throw null; } set { } }
        public System.TimeSpan MaxDelay { get { throw null; } set { } }
        public int MaxRetries { get { throw null; } set { } }
        public Azure.Core.RetryMode Mode { get { throw null; } set { } }
        public System.TimeSpan NetworkTimeout { get { throw null; } set { } }
    }
    public abstract partial class TokenCredential
    {
        protected TokenCredential() { }
        public abstract Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken);
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TokenRequestContext
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TokenRequestContext(string[] scopes, string? parentRequestId = null) { throw null; }
        public string? ParentRequestId { get { throw null; } }
        public string[] Scopes { get { throw null; } }
    }
}
namespace Azure.Core.Cryptography
{
    public partial interface IKeyEncryptionKey
    {
        string KeyId { get; }
        byte[] UnwrapKey(string algorithm, System.ReadOnlyMemory<byte> encryptedKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<byte[]> UnwrapKeyAsync(string algorithm, System.ReadOnlyMemory<byte> encryptedKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        byte[] WrapKey(string algorithm, System.ReadOnlyMemory<byte> key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<byte[]> WrapKeyAsync(string algorithm, System.ReadOnlyMemory<byte> key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial interface IKeyEncryptionKeyResolver
    {
        Azure.Core.Cryptography.IKeyEncryptionKey Resolve(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<Azure.Core.Cryptography.IKeyEncryptionKey> ResolveAsync(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
namespace Azure.Core.Diagnostics
{
    public partial class AzureEventSourceListener : System.Diagnostics.Tracing.EventListener
    {
        public const string TraitName = "AzureEventSource";
        public const string TraitValue = "true";
        public AzureEventSourceListener(System.Action<System.Diagnostics.Tracing.EventWrittenEventArgs, string> log, System.Diagnostics.Tracing.EventLevel level) { }
        public static Azure.Core.Diagnostics.AzureEventSourceListener CreateConsoleLogger(System.Diagnostics.Tracing.EventLevel level = System.Diagnostics.Tracing.EventLevel.Informational) { throw null; }
        public static Azure.Core.Diagnostics.AzureEventSourceListener CreateTraceLogger(System.Diagnostics.Tracing.EventLevel level = System.Diagnostics.Tracing.EventLevel.Informational) { throw null; }
        protected sealed override void OnEventSourceCreated(System.Diagnostics.Tracing.EventSource eventSource) { }
        protected sealed override void OnEventWritten(System.Diagnostics.Tracing.EventWrittenEventArgs eventData) { }
    }
}
namespace Azure.Core.Extensions
{
    public partial interface IAzureClientBuilder<TClient, TOptions> where TOptions : class
    {
    }
    public partial interface IAzureClientFactoryBuilder
    {
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(System.Func<TOptions, TClient> clientFactory) where TOptions : class;
    }
    public partial interface IAzureClientFactoryBuilderWithConfiguration<in TConfiguration> : Azure.Core.Extensions.IAzureClientFactoryBuilder
    {
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(TConfiguration configuration) where TOptions : class;
    }
    public partial interface IAzureClientFactoryBuilderWithCredential
    {
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(System.Func<TOptions, Azure.Core.TokenCredential, TClient> clientFactory, bool requiresCredential = true) where TOptions : class;
    }
}
namespace Azure.Core.Pipeline
{
    public partial class BearerTokenAuthenticationPolicy : Azure.Core.Pipeline.HttpPipelinePolicy
    {
        public BearerTokenAuthenticationPolicy(Azure.Core.TokenCredential credential, System.Collections.Generic.IEnumerable<string> scopes) { }
        public BearerTokenAuthenticationPolicy(Azure.Core.TokenCredential credential, string scope) { }
        public override void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
    }
    public partial class HttpClientTransport : Azure.Core.Pipeline.HttpPipelineTransport
    {
        public static readonly Azure.Core.Pipeline.HttpClientTransport Shared;
        public HttpClientTransport() { }
        public HttpClientTransport(System.Net.Http.HttpClient client) { }
        public HttpClientTransport(System.Net.Http.HttpMessageHandler messageHandler) { }
        public sealed override Azure.Core.Request CreateRequest() { throw null; }
        public override void Process(Azure.Core.HttpMessage message) { }
        public sealed override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message) { throw null; }
    }
    public partial class HttpPipeline
    {
        public HttpPipeline(Azure.Core.Pipeline.HttpPipelineTransport transport, Azure.Core.Pipeline.HttpPipelinePolicy[]? policies = null, Azure.Core.ResponseClassifier? responseClassifier = null) { }
        public Azure.Core.ResponseClassifier ResponseClassifier { get { throw null; } }
        public static System.IDisposable CreateClientRequestIdScope(string? clientRequestId) { throw null; }
        public Azure.Core.HttpMessage CreateMessage() { throw null; }
        public Azure.Core.Request CreateRequest() { throw null; }
        public void Send(Azure.Core.HttpMessage message, System.Threading.CancellationToken cancellationToken) { }
        public System.Threading.Tasks.ValueTask SendAsync(Azure.Core.HttpMessage message, System.Threading.CancellationToken cancellationToken) { throw null; }
        public Azure.Response SendRequest(Azure.Core.Request request, System.Threading.CancellationToken cancellationToken) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Response> SendRequestAsync(Azure.Core.Request request, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public static partial class HttpPipelineBuilder
    {
        public static Azure.Core.Pipeline.HttpPipeline Build(Azure.Core.ClientOptions options, params Azure.Core.Pipeline.HttpPipelinePolicy[] perRetryPolicies) { throw null; }
        public static Azure.Core.Pipeline.HttpPipeline Build(Azure.Core.ClientOptions options, Azure.Core.Pipeline.HttpPipelinePolicy[] perCallPolicies, Azure.Core.Pipeline.HttpPipelinePolicy[] perRetryPolicies, Azure.Core.ResponseClassifier responseClassifier) { throw null; }
    }
    public abstract partial class HttpPipelinePolicy
    {
        protected HttpPipelinePolicy() { }
        public abstract void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline);
        protected static void ProcessNext(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        protected static System.Threading.Tasks.ValueTask ProcessNextAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
    }
    public abstract partial class HttpPipelineSynchronousPolicy : Azure.Core.Pipeline.HttpPipelinePolicy
    {
        protected HttpPipelineSynchronousPolicy() { }
        public virtual void OnReceivedResponse(Azure.Core.HttpMessage message) { }
        public virtual void OnSendingRequest(Azure.Core.HttpMessage message) { }
        public override void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
    }
    public abstract partial class HttpPipelineTransport
    {
        protected HttpPipelineTransport() { }
        public abstract Azure.Core.Request CreateRequest();
        public abstract void Process(Azure.Core.HttpMessage message);
        public abstract System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message);
    }
}
namespace Azure.Core.Serialization
{
    public partial interface IMemberNameConverter
    {
        string? ConvertMemberName(System.Reflection.MemberInfo member);
    }
    public partial class JsonObjectSerializer : Azure.Core.Serialization.ObjectSerializer, Azure.Core.Serialization.IMemberNameConverter
    {
        public JsonObjectSerializer() { }
        public JsonObjectSerializer(System.Text.Json.JsonSerializerOptions options) { }
        string? Azure.Core.Serialization.IMemberNameConverter.ConvertMemberName(System.Reflection.MemberInfo member) { throw null; }
        public override object? Deserialize(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<object?> DeserializeAsync(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void Serialize(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { }
        public override System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public abstract partial class ObjectSerializer
    {
        protected ObjectSerializer() { }
        public abstract object? Deserialize(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.ValueTask<object?> DeserializeAsync(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken);
        public abstract void Serialize(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken);
    }
}
