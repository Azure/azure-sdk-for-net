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
    public static partial class AzureCoreExtensions
    {
        public static dynamic ToDynamicFromJson(this System.BinaryData utf8Json) { throw null; }
        public static dynamic ToDynamicFromJson(this System.BinaryData utf8Json, Azure.Core.Serialization.JsonPropertyNames propertyNameFormat, string dateTimeFormat = "o") { throw null; }
        public static System.Threading.Tasks.ValueTask<T?> ToObjectAsync<T>(this System.BinaryData data, Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static object? ToObjectFromJson(this System.BinaryData data) { throw null; }
        public static T? ToObject<T>(this System.BinaryData data, Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureKeyCredential
    {
        public AzureKeyCredential(string key) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Key { get { throw null; } }
        public void Update(string key) { }
    }
    public partial class AzureNamedKeyCredential
    {
        public AzureNamedKeyCredential(string name, string key) { }
        public string Name { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Deconstruct(out string name, out string key) { throw null; }
        public void Update(string name, string key) { }
    }
    public partial class AzureSasCredential
    {
        public AzureSasCredential(string signature) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Signature { get { throw null; } }
        public void Update(string signature) { }
    }
    [System.FlagsAttribute]
    public enum ErrorOptions
    {
        Default = 0,
        NoThrow = 1,
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
    public partial class HttpAuthorization
    {
        public HttpAuthorization(string scheme, string parameter) { }
        public string Parameter { get { throw null; } }
        public string Scheme { get { throw null; } }
        public override string ToString() { throw null; }
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
    public abstract partial class NullableResponse<T>
    {
        protected NullableResponse() { }
        public abstract bool HasValue { get; }
        public abstract T? Value { get; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public abstract Azure.Response GetRawResponse();
        public override string ToString() { throw null; }
    }
    public abstract partial class Operation
    {
        protected Operation() { }
        public abstract bool HasCompleted { get; }
        public abstract string Id { get; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public abstract Azure.Response GetRawResponse();
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string? ToString() { throw null; }
        public abstract Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public virtual Azure.Response WaitForCompletionResponse(Azure.Core.DelayStrategy delayStrategy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response WaitForCompletionResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response WaitForCompletionResponse(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(Azure.Core.DelayStrategy delayStrategy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class Operation<T> : Azure.Operation where T : notnull
    {
        protected Operation() { }
        public abstract bool HasValue { get; }
        public abstract T Value { get; }
        public virtual Azure.Response<T> WaitForCompletion(Azure.Core.DelayStrategy delayStrategy, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<T> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<T> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Response<T>> WaitForCompletionAsync(Azure.Core.DelayStrategy delayStrategy, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Response<T>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Response<T>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class PageableOperation<T> : Azure.Operation<Azure.AsyncPageable<T>> where T : notnull
    {
        protected PageableOperation() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.AsyncPageable<T> Value { get { throw null; } }
        public abstract Azure.Pageable<T> GetValues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract Azure.AsyncPageable<T> GetValuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
    public partial class RequestContext
    {
        public RequestContext() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public Azure.ErrorOptions ErrorOptions { get { throw null; } set { } }
        public void AddClassifier(Azure.Core.ResponseClassificationHandler classifier) { }
        public void AddClassifier(int statusCode, bool isError) { }
        public void AddPolicy(Azure.Core.Pipeline.HttpPipelinePolicy policy, Azure.Core.HttpPipelinePosition position) { }
        public static implicit operator Azure.RequestContext (Azure.ErrorOptions options) { throw null; }
    }
    public partial class RequestFailedException : System.Exception, System.Runtime.Serialization.ISerializable
    {
        public RequestFailedException(Azure.Response response) { }
        public RequestFailedException(Azure.Response response, System.Exception? innerException) { }
        public RequestFailedException(Azure.Response response, System.Exception? innerException, Azure.Core.RequestFailedDetailsParser? detailsParser) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestFailedException(int status, string message) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestFailedException(int status, string message, System.Exception? innerException) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestFailedException(int status, string message, string? errorCode, System.Exception? innerException) { }
        protected RequestFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public RequestFailedException(string message) { }
        public RequestFailedException(string message, System.Exception? innerException) { }
        public string? ErrorCode { get { throw null; } }
        public int Status { get { throw null; } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public Azure.Response? GetRawResponse() { throw null; }
    }
    public abstract partial class Response : System.IDisposable
    {
        protected Response() { }
        public abstract string ClientRequestId { get; set; }
        public virtual System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public virtual Azure.Core.ResponseHeaders Headers { get { throw null; } }
        public virtual bool IsError { get { throw null; } }
        public abstract string ReasonPhrase { get; }
        public abstract int Status { get; }
        protected internal abstract bool ContainsHeader(string name);
        public abstract void Dispose();
        protected internal abstract System.Collections.Generic.IEnumerable<Azure.Core.HttpHeader> EnumerateHeaders();
        public static Azure.Response<T> FromValue<T>(T value, Azure.Response response) { throw null; }
        public override string ToString() { throw null; }
        protected internal abstract bool TryGetHeader(string name, out string? value);
        protected internal abstract bool TryGetHeaderValues(string name, out System.Collections.Generic.IEnumerable<string>? values);
    }
    public sealed partial class ResponseError
    {
        public ResponseError(string? code, string? message) { }
        public string? Code { get { throw null; } }
        public string? Message { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public abstract partial class Response<T> : Azure.NullableResponse<T>
    {
        protected Response() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasValue { get { throw null; } }
        public override T Value { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator T (Azure.Response<T> response) { throw null; }
    }
    public partial class SyncAsyncEventArgs : System.EventArgs
    {
        public SyncAsyncEventArgs(bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public bool IsRunningSynchronously { get { throw null; } }
    }
    public enum WaitUntil
    {
        Completed = 0,
        Started = 1,
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureLocation : System.IEquatable<Azure.Core.AzureLocation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureLocation(string location) { throw null; }
        public AzureLocation(string name, string displayName) { throw null; }
        public static Azure.Core.AzureLocation AustraliaCentral { get { throw null; } }
        public static Azure.Core.AzureLocation AustraliaCentral2 { get { throw null; } }
        public static Azure.Core.AzureLocation AustraliaEast { get { throw null; } }
        public static Azure.Core.AzureLocation AustraliaSoutheast { get { throw null; } }
        public static Azure.Core.AzureLocation BrazilSouth { get { throw null; } }
        public static Azure.Core.AzureLocation BrazilSoutheast { get { throw null; } }
        public static Azure.Core.AzureLocation CanadaCentral { get { throw null; } }
        public static Azure.Core.AzureLocation CanadaEast { get { throw null; } }
        public static Azure.Core.AzureLocation CentralIndia { get { throw null; } }
        public static Azure.Core.AzureLocation CentralUS { get { throw null; } }
        public static Azure.Core.AzureLocation ChinaEast { get { throw null; } }
        public static Azure.Core.AzureLocation ChinaEast2 { get { throw null; } }
        public static Azure.Core.AzureLocation ChinaNorth { get { throw null; } }
        public static Azure.Core.AzureLocation ChinaNorth2 { get { throw null; } }
        public string? DisplayName { get { throw null; } }
        public static Azure.Core.AzureLocation EastAsia { get { throw null; } }
        public static Azure.Core.AzureLocation EastUS { get { throw null; } }
        public static Azure.Core.AzureLocation EastUS2 { get { throw null; } }
        public static Azure.Core.AzureLocation FranceCentral { get { throw null; } }
        public static Azure.Core.AzureLocation FranceSouth { get { throw null; } }
        public static Azure.Core.AzureLocation GermanyCentral { get { throw null; } }
        public static Azure.Core.AzureLocation GermanyNorth { get { throw null; } }
        public static Azure.Core.AzureLocation GermanyNorthEast { get { throw null; } }
        public static Azure.Core.AzureLocation GermanyWestCentral { get { throw null; } }
        public static Azure.Core.AzureLocation JapanEast { get { throw null; } }
        public static Azure.Core.AzureLocation JapanWest { get { throw null; } }
        public static Azure.Core.AzureLocation KoreaCentral { get { throw null; } }
        public static Azure.Core.AzureLocation KoreaSouth { get { throw null; } }
        public string Name { get { throw null; } }
        public static Azure.Core.AzureLocation NorthCentralUS { get { throw null; } }
        public static Azure.Core.AzureLocation NorthEurope { get { throw null; } }
        public static Azure.Core.AzureLocation NorwayEast { get { throw null; } }
        public static Azure.Core.AzureLocation NorwayWest { get { throw null; } }
        public static Azure.Core.AzureLocation QatarCentral { get { throw null; } }
        public static Azure.Core.AzureLocation SouthAfricaNorth { get { throw null; } }
        public static Azure.Core.AzureLocation SouthAfricaWest { get { throw null; } }
        public static Azure.Core.AzureLocation SouthCentralUS { get { throw null; } }
        public static Azure.Core.AzureLocation SoutheastAsia { get { throw null; } }
        public static Azure.Core.AzureLocation SouthIndia { get { throw null; } }
        public static Azure.Core.AzureLocation SwedenCentral { get { throw null; } }
        public static Azure.Core.AzureLocation SwitzerlandNorth { get { throw null; } }
        public static Azure.Core.AzureLocation SwitzerlandWest { get { throw null; } }
        public static Azure.Core.AzureLocation UAECentral { get { throw null; } }
        public static Azure.Core.AzureLocation UAENorth { get { throw null; } }
        public static Azure.Core.AzureLocation UKSouth { get { throw null; } }
        public static Azure.Core.AzureLocation UKWest { get { throw null; } }
        public static Azure.Core.AzureLocation USDoDCentral { get { throw null; } }
        public static Azure.Core.AzureLocation USDoDEast { get { throw null; } }
        public static Azure.Core.AzureLocation USGovArizona { get { throw null; } }
        public static Azure.Core.AzureLocation USGovIowa { get { throw null; } }
        public static Azure.Core.AzureLocation USGovTexas { get { throw null; } }
        public static Azure.Core.AzureLocation USGovVirginia { get { throw null; } }
        public static Azure.Core.AzureLocation WestCentralUS { get { throw null; } }
        public static Azure.Core.AzureLocation WestEurope { get { throw null; } }
        public static Azure.Core.AzureLocation WestIndia { get { throw null; } }
        public static Azure.Core.AzureLocation WestUS { get { throw null; } }
        public static Azure.Core.AzureLocation WestUS2 { get { throw null; } }
        public static Azure.Core.AzureLocation WestUS3 { get { throw null; } }
        public bool Equals(Azure.Core.AzureLocation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.AzureLocation left, Azure.Core.AzureLocation right) { throw null; }
        public static implicit operator string (Azure.Core.AzureLocation location) { throw null; }
        public static implicit operator Azure.Core.AzureLocation (string location) { throw null; }
        public static bool operator !=(Azure.Core.AzureLocation left, Azure.Core.AzureLocation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ClientOptions
    {
        protected ClientOptions() { }
        protected ClientOptions(Azure.Core.DiagnosticsOptions? diagnostics) { }
        public static Azure.Core.ClientOptions Default { get { throw null; } }
        public Azure.Core.DiagnosticsOptions Diagnostics { get { throw null; } }
        public Azure.Core.RetryOptions Retry { get { throw null; } }
        public Azure.Core.Pipeline.HttpPipelinePolicy? RetryPolicy { get { throw null; } set { } }
        public Azure.Core.Pipeline.HttpPipelineTransport Transport { get { throw null; } set { } }
        public void AddPolicy(Azure.Core.Pipeline.HttpPipelinePolicy policy, Azure.Core.HttpPipelinePosition position) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string? ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentType : System.IEquatable<Azure.Core.ContentType>, System.IEquatable<string>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentType(string contentType) { throw null; }
        public static Azure.Core.ContentType ApplicationJson { get { throw null; } }
        public static Azure.Core.ContentType ApplicationOctetStream { get { throw null; } }
        public static Azure.Core.ContentType TextPlain { get { throw null; } }
        public bool Equals(Azure.Core.ContentType other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public bool Equals(string? other) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.ContentType left, Azure.Core.ContentType right) { throw null; }
        public static implicit operator Azure.Core.ContentType (string contentType) { throw null; }
        public static bool operator !=(Azure.Core.ContentType left, Azure.Core.ContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DelayStrategy
    {
        protected DelayStrategy(System.TimeSpan? maxDelay = default(System.TimeSpan?), double jitterFactor = 0.2) { }
        public static Azure.Core.DelayStrategy CreateExponentialDelayStrategy(System.TimeSpan? initialDelay = default(System.TimeSpan?), System.TimeSpan? maxDelay = default(System.TimeSpan?)) { throw null; }
        public static Azure.Core.DelayStrategy CreateFixedDelayStrategy(System.TimeSpan? delay = default(System.TimeSpan?)) { throw null; }
        public System.TimeSpan GetNextDelay(Azure.Response? response, int retryNumber) { throw null; }
        protected abstract System.TimeSpan GetNextDelayCore(Azure.Response? response, int retryNumber);
        protected static System.TimeSpan Max(System.TimeSpan val1, System.TimeSpan val2) { throw null; }
        protected static System.TimeSpan Min(System.TimeSpan val1, System.TimeSpan val2) { throw null; }
    }
    public static partial class DelegatedTokenCredential
    {
        public static Azure.Core.TokenCredential Create(System.Func<Azure.Core.TokenRequestContext, System.Threading.CancellationToken, Azure.Core.AccessToken> getToken) { throw null; }
        public static Azure.Core.TokenCredential Create(System.Func<Azure.Core.TokenRequestContext, System.Threading.CancellationToken, Azure.Core.AccessToken> getToken, System.Func<Azure.Core.TokenRequestContext, System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<Azure.Core.AccessToken>> getTokenAsync) { throw null; }
    }
    public partial class DiagnosticsOptions
    {
        protected internal DiagnosticsOptions() { }
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
            public static string Prefer { get { throw null; } }
            public static string Range { get { throw null; } }
            public static string Referer { get { throw null; } }
            public static string UserAgent { get { throw null; } }
            public static string WwwAuthenticate { get { throw null; } }
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
        public System.TimeSpan? NetworkTimeout { get { throw null; } set { } }
        public Azure.Core.MessageProcessingContext ProcessingContext { get { throw null; } }
        public Azure.Core.Request Request { get { throw null; } }
        public Azure.Response Response { get { throw null; } set { } }
        public Azure.Core.ResponseClassifier ResponseClassifier { get { throw null; } set { } }
        public void Dispose() { }
        public System.IO.Stream? ExtractResponseContent() { throw null; }
        public void SetProperty(string name, object value) { }
        public void SetProperty(System.Type type, object value) { }
        public bool TryGetProperty(string name, out object? value) { throw null; }
        public bool TryGetProperty(System.Type type, out object? value) { throw null; }
    }
    public enum HttpPipelinePosition
    {
        PerCall = 0,
        PerRetry = 1,
        BeforeTransport = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageProcessingContext
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public int RetryNumber { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public static partial class MultipartResponse
    {
        public static Azure.Response[] Parse(Azure.Response response, bool expectCrLf, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response[]> ParseAsync(Azure.Response response, bool expectCrLf, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        protected internal abstract bool TryGetHeader(string name, out string? value);
        protected internal abstract bool TryGetHeaderValues(string name, out System.Collections.Generic.IEnumerable<string>? values);
    }
    public abstract partial class RequestContent : System.IDisposable
    {
        protected RequestContent() { }
        public static Azure.Core.RequestContent Create(Azure.Core.Serialization.DynamicData content) { throw null; }
        public static Azure.Core.RequestContent Create(System.BinaryData content) { throw null; }
        public static Azure.Core.RequestContent Create(System.Buffers.ReadOnlySequence<byte> bytes) { throw null; }
        public static Azure.Core.RequestContent Create(byte[] bytes) { throw null; }
        public static Azure.Core.RequestContent Create(byte[] bytes, int index, int length) { throw null; }
        public static Azure.Core.RequestContent Create(System.IO.Stream stream) { throw null; }
        public static Azure.Core.RequestContent Create(object serializable) { throw null; }
        public static Azure.Core.RequestContent Create(object serializable, Azure.Core.Serialization.JsonPropertyNames propertyNameFormat, string dateTimeFormat = "o") { throw null; }
        public static Azure.Core.RequestContent Create(object serializable, Azure.Core.Serialization.ObjectSerializer? serializer) { throw null; }
        public static Azure.Core.RequestContent Create(System.ReadOnlyMemory<byte> bytes) { throw null; }
        public static Azure.Core.RequestContent Create(string content) { throw null; }
        public abstract void Dispose();
        public static implicit operator Azure.Core.RequestContent (Azure.Core.Serialization.DynamicData content) { throw null; }
        public static implicit operator Azure.Core.RequestContent (System.BinaryData content) { throw null; }
        public static implicit operator Azure.Core.RequestContent (string content) { throw null; }
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
    }
    public abstract partial class RequestFailedDetailsParser
    {
        protected RequestFailedDetailsParser() { }
        public abstract bool TryParse(Azure.Response response, out Azure.ResponseError? error, out System.Collections.Generic.IDictionary<string, string>? data);
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
        public bool TryGetValue(string name, out string? value) { throw null; }
        public bool TryGetValues(string name, out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
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
        protected bool HasPath { get { throw null; } }
        protected bool HasQuery { get { throw null; } }
        public string? Host { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string PathAndQuery { get { throw null; } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string? Scheme { get { throw null; } set { } }
        public void AppendPath(System.ReadOnlySpan<char> value, bool escape) { }
        public void AppendPath(string value) { }
        public void AppendPath(string value, bool escape) { }
        public void AppendQuery(System.ReadOnlySpan<char> name, System.ReadOnlySpan<char> value, bool escapeValue) { }
        public void AppendQuery(string name, string value) { }
        public void AppendQuery(string name, string value, bool escapeValue) { }
        public void Reset(System.Uri value) { }
        public override string ToString() { throw null; }
        public System.Uri ToUri() { throw null; }
    }
    public sealed partial class ResourceIdentifier : System.IComparable<Azure.Core.ResourceIdentifier>, System.IEquatable<Azure.Core.ResourceIdentifier>
    {
        public static readonly Azure.Core.ResourceIdentifier Root;
        public ResourceIdentifier(string resourceId) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier? Parent { get { throw null; } }
        public string? Provider { get { throw null; } }
        public string? ResourceGroupName { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public string? SubscriptionId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ResourceIdentifier AppendChildResource(string childResourceType, string childResourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ResourceIdentifier AppendProviderResource(string providerNamespace, string resourceType, string resourceName) { throw null; }
        public int CompareTo(Azure.Core.ResourceIdentifier? other) { throw null; }
        public bool Equals(Azure.Core.ResourceIdentifier? other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.ResourceIdentifier left, Azure.Core.ResourceIdentifier right) { throw null; }
        public static bool operator >(Azure.Core.ResourceIdentifier left, Azure.Core.ResourceIdentifier right) { throw null; }
        public static bool operator >=(Azure.Core.ResourceIdentifier left, Azure.Core.ResourceIdentifier right) { throw null; }
        public static implicit operator string (Azure.Core.ResourceIdentifier id) { throw null; }
        public static bool operator !=(Azure.Core.ResourceIdentifier left, Azure.Core.ResourceIdentifier right) { throw null; }
        public static bool operator <(Azure.Core.ResourceIdentifier left, Azure.Core.ResourceIdentifier right) { throw null; }
        public static bool operator <=(Azure.Core.ResourceIdentifier left, Azure.Core.ResourceIdentifier right) { throw null; }
        public static Azure.Core.ResourceIdentifier Parse(string input) { throw null; }
        public override string ToString() { throw null; }
        public static bool TryParse(string? input, out Azure.Core.ResourceIdentifier? result) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceType : System.IEquatable<Azure.Core.ResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceType(string resourceType) { throw null; }
        public string Namespace { get { throw null; } }
        public string Type { get { throw null; } }
        public bool Equals(Azure.Core.ResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string GetLastType() { throw null; }
        public static bool operator ==(Azure.Core.ResourceType left, Azure.Core.ResourceType right) { throw null; }
        public static implicit operator string (Azure.Core.ResourceType resourceType) { throw null; }
        public static implicit operator Azure.Core.ResourceType (string resourceType) { throw null; }
        public static bool operator !=(Azure.Core.ResourceType left, Azure.Core.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ResponseClassificationHandler
    {
        protected ResponseClassificationHandler() { }
        public abstract bool TryClassify(Azure.Core.HttpMessage message, out bool isError);
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
        public long? ContentLengthLong { get { throw null; } }
        public string? ContentType { get { throw null; } }
        public System.DateTimeOffset? Date { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string? RequestId { get { throw null; } }
        public bool Contains(string name) { throw null; }
        public System.Collections.Generic.IEnumerator<Azure.Core.HttpHeader> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string name, out string? value) { throw null; }
        public bool TryGetValues(string name, out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
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
    public partial class StatusCodeClassifier : Azure.Core.ResponseClassifier
    {
        public StatusCodeClassifier(System.ReadOnlySpan<ushort> successStatusCodes) { }
        public override bool IsErrorResponse(Azure.Core.HttpMessage message) { throw null; }
    }
    public delegate System.Threading.Tasks.Task SyncAsyncEventHandler<T>(T e) where T : Azure.SyncAsyncEventArgs;
    public partial class TelemetryDetails
    {
        public TelemetryDetails(System.Reflection.Assembly assembly, string? applicationId = null) { }
        public string? ApplicationId { get { throw null; } }
        public System.Reflection.Assembly Assembly { get { throw null; } }
        public void Apply(Azure.Core.HttpMessage message) { }
        public override string ToString() { throw null; }
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
        public TokenRequestContext(string[] scopes, string? parentRequestId) { throw null; }
        public TokenRequestContext(string[] scopes, string? parentRequestId, string? claims) { throw null; }
        public TokenRequestContext(string[] scopes, string? parentRequestId, string? claims, string? tenantId) { throw null; }
        public TokenRequestContext(string[] scopes, string? parentRequestId = null, string? claims = null, string? tenantId = null, bool isCaeEnabled = false) { throw null; }
        public string? Claims { get { throw null; } }
        public bool IsCaeEnabled { get { throw null; } }
        public string? ParentRequestId { get { throw null; } }
        public string[] Scopes { get { throw null; } }
        public string? TenantId { get { throw null; } }
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
namespace Azure.Core.GeoJson
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoArray<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.Generic.IReadOnlyList<T>, System.Collections.IEnumerable
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public int Count { get { throw null; } }
        public T this[int index] { get { throw null; } }
        public Azure.Core.GeoJson.GeoArray<T>.Enumerator GetEnumerator() { throw null; }
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct Enumerator : System.Collections.Generic.IEnumerator<T>, System.Collections.IEnumerator, System.IDisposable
        {
            private object _dummy;
            private int _dummyPrimitive;
            public T Current { get { throw null; } }
            object System.Collections.IEnumerator.Current { get { throw null; } }
            public void Dispose() { }
            public bool MoveNext() { throw null; }
            public void Reset() { }
        }
    }
    public sealed partial class GeoBoundingBox : System.IEquatable<Azure.Core.GeoJson.GeoBoundingBox>
    {
        public GeoBoundingBox(double west, double south, double east, double north) { }
        public GeoBoundingBox(double west, double south, double east, double north, double? minAltitude, double? maxAltitude) { }
        public double East { get { throw null; } }
        public double this[int index] { get { throw null; } }
        public double? MaxAltitude { get { throw null; } }
        public double? MinAltitude { get { throw null; } }
        public double North { get { throw null; } }
        public double South { get { throw null; } }
        public double West { get { throw null; } }
        public bool Equals(Azure.Core.GeoJson.GeoBoundingBox? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class GeoCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoObject>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoObject>, System.Collections.IEnumerable
    {
        public GeoCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject> geometries) { }
        public GeoCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject> geometries, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoObject this[int index] { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoObject> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public sealed partial class GeoLinearRing
    {
        public GeoLinearRing(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> coordinates) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition> Coordinates { get { throw null; } }
    }
    public sealed partial class GeoLineString : Azure.Core.GeoJson.GeoObject
    {
        public GeoLineString(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> coordinates) { }
        public GeoLineString(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> coordinates, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition> Coordinates { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
    }
    public sealed partial class GeoLineStringCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLineString>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoLineString>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoLineString>, System.Collections.IEnumerable
    {
        public GeoLineStringCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLineString> lines) { }
        public GeoLineStringCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLineString> lines, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition>> Coordinates { get { throw null; } }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoLineString this[int index] { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoLineString> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class GeoObject
    {
        internal GeoObject() { }
        public Azure.Core.GeoJson.GeoBoundingBox? BoundingBox { get { throw null; } }
        public abstract Azure.Core.GeoJson.GeoObjectType Type { get; }
        public static Azure.Core.GeoJson.GeoObject Parse(string json) { throw null; }
        public override string ToString() { throw null; }
        public bool TryGetCustomProperty(string name, out object? value) { throw null; }
    }
    public enum GeoObjectType
    {
        Point = 0,
        MultiPoint = 1,
        Polygon = 2,
        MultiPolygon = 3,
        LineString = 4,
        MultiLineString = 5,
        GeometryCollection = 6,
    }
    public sealed partial class GeoPoint : Azure.Core.GeoJson.GeoObject
    {
        public GeoPoint(Azure.Core.GeoJson.GeoPosition position) { }
        public GeoPoint(Azure.Core.GeoJson.GeoPosition position, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public GeoPoint(double longitude, double latitude) { }
        public GeoPoint(double longitude, double latitude, double? altitude) { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
    }
    public sealed partial class GeoPointCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoPoint>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPoint>, System.Collections.IEnumerable
    {
        public GeoPointCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint> points) { }
        public GeoPointCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint> points, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition> Coordinates { get { throw null; } }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoPoint this[int index] { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoPoint> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public sealed partial class GeoPolygon : Azure.Core.GeoJson.GeoObject
    {
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLinearRing> rings) { }
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLinearRing> rings, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> positions) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition>> Coordinates { get { throw null; } }
        public Azure.Core.GeoJson.GeoLinearRing OuterRing { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoLinearRing> Rings { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
    }
    public sealed partial class GeoPolygonCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoPolygon>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPolygon>, System.Collections.IEnumerable
    {
        public GeoPolygonCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon> polygons) { }
        public GeoPolygonCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon> polygons, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition>>> Coordinates { get { throw null; } }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoPolygon this[int index] { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoPolygon> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoPosition : System.IEquatable<Azure.Core.GeoJson.GeoPosition>
    {
        private readonly int _dummyPrimitive;
        public GeoPosition(double longitude, double latitude) { throw null; }
        public GeoPosition(double longitude, double latitude, double? altitude) { throw null; }
        public double? Altitude { get { throw null; } }
        public int Count { get { throw null; } }
        public double this[int index] { get { throw null; } }
        public double Latitude { get { throw null; } }
        public double Longitude { get { throw null; } }
        public bool Equals(Azure.Core.GeoJson.GeoPosition other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.GeoJson.GeoPosition left, Azure.Core.GeoJson.GeoPosition right) { throw null; }
        public static bool operator !=(Azure.Core.GeoJson.GeoPosition left, Azure.Core.GeoJson.GeoPosition right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Core.Pipeline
{
    public partial class BearerTokenAuthenticationPolicy : Azure.Core.Pipeline.HttpPipelinePolicy
    {
        public BearerTokenAuthenticationPolicy(Azure.Core.TokenCredential credential, System.Collections.Generic.IEnumerable<string> scopes) { }
        public BearerTokenAuthenticationPolicy(Azure.Core.TokenCredential credential, string scope) { }
        protected void AuthenticateAndAuthorizeRequest(Azure.Core.HttpMessage message, Azure.Core.TokenRequestContext context) { }
        protected System.Threading.Tasks.ValueTask AuthenticateAndAuthorizeRequestAsync(Azure.Core.HttpMessage message, Azure.Core.TokenRequestContext context) { throw null; }
        protected virtual void AuthorizeRequest(Azure.Core.HttpMessage message) { }
        protected virtual System.Threading.Tasks.ValueTask AuthorizeRequestAsync(Azure.Core.HttpMessage message) { throw null; }
        protected virtual bool AuthorizeRequestOnChallenge(Azure.Core.HttpMessage message) { throw null; }
        protected virtual System.Threading.Tasks.ValueTask<bool> AuthorizeRequestOnChallengeAsync(Azure.Core.HttpMessage message) { throw null; }
        public override void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
    }
    public sealed partial class DisposableHttpPipeline : Azure.Core.Pipeline.HttpPipeline, System.IDisposable
    {
        internal DisposableHttpPipeline() : base (default(Azure.Core.Pipeline.HttpPipelineTransport), default(Azure.Core.Pipeline.HttpPipelinePolicy[]), default(Azure.Core.ResponseClassifier)) { }
        public void Dispose() { }
    }
    public partial class HttpClientTransport : Azure.Core.Pipeline.HttpPipelineTransport, System.IDisposable
    {
        public static readonly Azure.Core.Pipeline.HttpClientTransport Shared;
        public HttpClientTransport() { }
        public HttpClientTransport(System.Net.Http.HttpClient client) { }
        public HttpClientTransport(System.Net.Http.HttpMessageHandler messageHandler) { }
        public sealed override Azure.Core.Request CreateRequest() { throw null; }
        public void Dispose() { }
        public override void Process(Azure.Core.HttpMessage message) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message) { throw null; }
    }
    public partial class HttpPipeline
    {
        public HttpPipeline(Azure.Core.Pipeline.HttpPipelineTransport transport, Azure.Core.Pipeline.HttpPipelinePolicy[]? policies = null, Azure.Core.ResponseClassifier? responseClassifier = null) { }
        public Azure.Core.ResponseClassifier ResponseClassifier { get { throw null; } }
        public static System.IDisposable CreateClientRequestIdScope(string? clientRequestId) { throw null; }
        public static System.IDisposable CreateHttpMessagePropertiesScope(System.Collections.Generic.IDictionary<string, object?> messageProperties) { throw null; }
        public Azure.Core.HttpMessage CreateMessage() { throw null; }
        public Azure.Core.HttpMessage CreateMessage(Azure.RequestContext? context) { throw null; }
        public Azure.Core.HttpMessage CreateMessage(Azure.RequestContext? context, Azure.Core.ResponseClassifier? classifier = null) { throw null; }
        public Azure.Core.Request CreateRequest() { throw null; }
        public void Send(Azure.Core.HttpMessage message, System.Threading.CancellationToken cancellationToken) { }
        public System.Threading.Tasks.ValueTask SendAsync(Azure.Core.HttpMessage message, System.Threading.CancellationToken cancellationToken) { throw null; }
        public Azure.Response SendRequest(Azure.Core.Request request, System.Threading.CancellationToken cancellationToken) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Response> SendRequestAsync(Azure.Core.Request request, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public static partial class HttpPipelineBuilder
    {
        public static Azure.Core.Pipeline.HttpPipeline Build(Azure.Core.ClientOptions options, params Azure.Core.Pipeline.HttpPipelinePolicy[] perRetryPolicies) { throw null; }
        public static Azure.Core.Pipeline.DisposableHttpPipeline Build(Azure.Core.ClientOptions options, Azure.Core.Pipeline.HttpPipelinePolicy[] perCallPolicies, Azure.Core.Pipeline.HttpPipelinePolicy[] perRetryPolicies, Azure.Core.Pipeline.HttpPipelineTransportOptions transportOptions, Azure.Core.ResponseClassifier? responseClassifier) { throw null; }
        public static Azure.Core.Pipeline.HttpPipeline Build(Azure.Core.ClientOptions options, Azure.Core.Pipeline.HttpPipelinePolicy[] perCallPolicies, Azure.Core.Pipeline.HttpPipelinePolicy[] perRetryPolicies, Azure.Core.ResponseClassifier? responseClassifier) { throw null; }
        public static Azure.Core.Pipeline.HttpPipeline Build(Azure.Core.Pipeline.HttpPipelineOptions options) { throw null; }
        public static Azure.Core.Pipeline.DisposableHttpPipeline Build(Azure.Core.Pipeline.HttpPipelineOptions options, Azure.Core.Pipeline.HttpPipelineTransportOptions transportOptions) { throw null; }
    }
    public partial class HttpPipelineOptions
    {
        public HttpPipelineOptions(Azure.Core.ClientOptions options) { }
        public Azure.Core.ClientOptions ClientOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.Pipeline.HttpPipelinePolicy> PerCallPolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.Pipeline.HttpPipelinePolicy> PerRetryPolicies { get { throw null; } }
        public Azure.Core.RequestFailedDetailsParser RequestFailedDetailsParser { get { throw null; } set { } }
        public Azure.Core.ResponseClassifier? ResponseClassifier { get { throw null; } set { } }
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
    public partial class HttpPipelineTransportOptions
    {
        public HttpPipelineTransportOptions() { }
        public System.Collections.Generic.IList<System.Security.Cryptography.X509Certificates.X509Certificate2> ClientCertificates { get { throw null; } }
        public bool IsClientRedirectEnabled { get { throw null; } set { } }
        public System.Func<Azure.Core.Pipeline.ServerCertificateCustomValidationArgs, bool>? ServerCertificateCustomValidationCallback { get { throw null; } set { } }
    }
    public sealed partial class RedirectPolicy : Azure.Core.Pipeline.HttpPipelinePolicy
    {
        internal RedirectPolicy() { }
        public override void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
        public static void SetAllowAutoRedirect(Azure.Core.HttpMessage message, bool allowAutoRedirect) { }
    }
    public partial class RetryPolicy : Azure.Core.Pipeline.HttpPipelinePolicy
    {
        public RetryPolicy(int maxRetries = 3, Azure.Core.DelayStrategy? delayStrategy = null) { }
        protected internal virtual void OnRequestSent(Azure.Core.HttpMessage message) { }
        protected internal virtual System.Threading.Tasks.ValueTask OnRequestSentAsync(Azure.Core.HttpMessage message) { throw null; }
        protected internal virtual void OnSendingRequest(Azure.Core.HttpMessage message) { }
        protected internal virtual System.Threading.Tasks.ValueTask OnSendingRequestAsync(Azure.Core.HttpMessage message) { throw null; }
        public override void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
        protected internal virtual bool ShouldRetry(Azure.Core.HttpMessage message, System.Exception? exception) { throw null; }
        protected internal virtual System.Threading.Tasks.ValueTask<bool> ShouldRetryAsync(Azure.Core.HttpMessage message, System.Exception? exception) { throw null; }
    }
    public partial class ServerCertificateCustomValidationArgs
    {
        public ServerCertificateCustomValidationArgs(System.Security.Cryptography.X509Certificates.X509Certificate2? certificate, System.Security.Cryptography.X509Certificates.X509Chain? certificateAuthorityChain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { }
        public System.Security.Cryptography.X509Certificates.X509Certificate2? Certificate { get { throw null; } }
        public System.Security.Cryptography.X509Certificates.X509Chain? CertificateAuthorityChain { get { throw null; } }
        public System.Net.Security.SslPolicyErrors SslPolicyErrors { get { throw null; } }
    }
}
namespace Azure.Core.Serialization
{
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    public sealed partial class DynamicData : System.Dynamic.IDynamicMetaObjectProvider, System.IDisposable
    {
        internal DynamicData() { }
        public void Dispose() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Serialization.DynamicData? left, object? right) { throw null; }
        public static explicit operator System.DateTime (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static explicit operator System.DateTimeOffset (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static explicit operator System.Guid (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator bool (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator byte (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator decimal (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator double (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator short (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator int (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator long (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator sbyte (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator float (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator string (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator ushort (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator uint (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static implicit operator ulong (Azure.Core.Serialization.DynamicData value) { throw null; }
        public static bool operator !=(Azure.Core.Serialization.DynamicData? left, object? right) { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial interface IMemberNameConverter
    {
        string? ConvertMemberName(System.Reflection.MemberInfo member);
    }
    public partial class JsonObjectSerializer : Azure.Core.Serialization.ObjectSerializer, Azure.Core.Serialization.IMemberNameConverter
    {
        public JsonObjectSerializer() { }
        public JsonObjectSerializer(System.Text.Json.JsonSerializerOptions options) { }
        public static Azure.Core.Serialization.JsonObjectSerializer Default { get { throw null; } }
        string? Azure.Core.Serialization.IMemberNameConverter.ConvertMemberName(System.Reflection.MemberInfo member) { throw null; }
        public override object? Deserialize(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<object?> DeserializeAsync(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void Serialize(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { }
        public override System.BinaryData Serialize(object? value, System.Type? inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<System.BinaryData> SerializeAsync(object? value, System.Type? inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum JsonPropertyNames
    {
        UseExact = 0,
        CamelCase = 1,
    }
    public abstract partial class ObjectSerializer
    {
        protected ObjectSerializer() { }
        public abstract object? Deserialize(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.ValueTask<object?> DeserializeAsync(System.IO.Stream stream, System.Type returnType, System.Threading.CancellationToken cancellationToken);
        public abstract void Serialize(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken);
        public virtual System.BinaryData Serialize(object? value, System.Type? inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public abstract System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object? value, System.Type inputType, System.Threading.CancellationToken cancellationToken);
        public virtual System.Threading.Tasks.ValueTask<System.BinaryData> SerializeAsync(object? value, System.Type? inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Messaging
{
    public partial class CloudEvent
    {
        public CloudEvent(string source, string type, System.BinaryData? data, string? dataContentType, Azure.Messaging.CloudEventDataFormat dataFormat = Azure.Messaging.CloudEventDataFormat.Binary) { }
        public CloudEvent(string source, string type, object? jsonSerializableData, System.Type? dataSerializationType = null) { }
        public System.BinaryData? Data { get { throw null; } set { } }
        public string? DataContentType { get { throw null; } set { } }
        public string? DataSchema { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> ExtensionAttributes { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string? Subject { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public static Azure.Messaging.CloudEvent? Parse(System.BinaryData json, bool skipValidation = false) { throw null; }
        public static Azure.Messaging.CloudEvent[] ParseMany(System.BinaryData json, bool skipValidation = false) { throw null; }
    }
    public enum CloudEventDataFormat
    {
        Binary = 0,
        Json = 1,
    }
    public partial class MessageContent
    {
        public MessageContent() { }
        public virtual Azure.Core.ContentType? ContentType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual Azure.Core.ContentType? ContentTypeCore { get { throw null; } set { } }
        public virtual System.BinaryData? Data { get { throw null; } set { } }
        public virtual bool IsReadOnly { get { throw null; } }
    }
}
