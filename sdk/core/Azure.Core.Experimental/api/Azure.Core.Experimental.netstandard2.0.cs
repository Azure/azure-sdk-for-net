namespace Azure
{
    public partial class RequestOptions
    {
        public RequestOptions() { }
        public RequestOptions(Azure.ResponseStatusOption statusOption) { }
        public RequestOptions(System.Action<Azure.Core.HttpMessage> perCall) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public Azure.Core.Pipeline.HttpPipelinePolicy? PerCallPolicy { get { throw null; } set { } }
        public Azure.ResponseStatusOption StatusOption { get { throw null; } set { } }
        public static void Apply(Azure.RequestOptions requestOptions, Azure.Core.HttpMessage message) { }
        public static implicit operator Azure.RequestOptions (Azure.ResponseStatusOption option) { throw null; }
    }
    public enum ResponseStatusOption
    {
        Default = 0,
        NoThrow = 1,
    }
}
namespace Azure.Core
{
    public partial class ClassifiedResponse : Azure.Response
    {
        public ClassifiedResponse(Azure.Response response) { }
        public override string ClientRequestId { get { throw null; } set { } }
        public override System.IO.Stream? ContentStream { get { throw null; } set { } }
        public bool IsError { get { throw null; } }
        public override string ReasonPhrase { get { throw null; } }
        public override int Status { get { throw null; } }
        protected override bool ContainsHeader(string name) { throw null; }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected override System.Collections.Generic.IEnumerable<Azure.Core.HttpHeader> EnumerateHeaders() { throw null; }
        protected override bool TryGetHeader(string name, out string? value) { throw null; }
        protected override bool TryGetHeaderValues(string name, out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
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
        public bool Equals(string other) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.ContentType left, Azure.Core.ContentType right) { throw null; }
        public static implicit operator Azure.Core.ContentType (string contentType) { throw null; }
        public static bool operator !=(Azure.Core.ContentType left, Azure.Core.ContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    public partial class JsonData : System.Dynamic.IDynamicMetaObjectProvider, System.IEquatable<Azure.Core.JsonData>
    {
        public JsonData() { }
        public JsonData(object? value) { }
        public JsonData(object? value, System.Text.Json.JsonSerializerOptions options, System.Type? type = null) { }
        public JsonData(System.Text.Json.JsonDocument jsonDocument) { }
        public Azure.Core.JsonData this[int arrayIndex] { get { throw null; } set { } }
        public Azure.Core.JsonData this[string propertyName] { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Core.JsonData> Items { get { throw null; } }
        public System.Text.Json.JsonValueKind Kind { get { throw null; } }
        public int Length { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Properties { get { throw null; } }
        public void Add(bool value) { }
        public void Add(double value) { }
        public void Add(int value) { }
        public void Add(long value) { }
        public Azure.Core.JsonData Add(object? serializable) { throw null; }
        public Azure.Core.JsonData Add(object? serializable, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public void Add(float value) { }
        public void Add(string? value) { }
        public Azure.Core.JsonData AddEmptyArray() { throw null; }
        public Azure.Core.JsonData AddEmptyObject() { throw null; }
        public Azure.Core.JsonData Add<T>(T[] serializable) { throw null; }
        public Azure.Core.JsonData Add<T>(T[] serializable, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public static Azure.Core.JsonData EmptyArray() { throw null; }
        public static Azure.Core.JsonData EmptyObject() { throw null; }
        public bool Equals(Azure.Core.JsonData other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public static Azure.Core.JsonData FromBytes(byte[] utf8Json) { throw null; }
        public static Azure.Core.JsonData FromBytes(System.ReadOnlyMemory<byte> utf8Json) { throw null; }
        public static Azure.Core.JsonData FromObject<T>(T value, System.Text.Json.JsonSerializerOptions? options = null) { throw null; }
        public static Azure.Core.JsonData FromStream(System.IO.Stream utf8Json) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Core.JsonData> FromStreamAsync(System.IO.Stream utf8JsonStream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.JsonData FromString(string json) { throw null; }
        public Azure.Core.JsonData? Get(string propertyName) { throw null; }
        public override int GetHashCode() { throw null; }
        public T Get<T>(string propertyName) { throw null; }
        public T Get<T>(string propertyName, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public static bool operator ==(Azure.Core.JsonData? left, string? right) { throw null; }
        public static bool operator ==(string? left, Azure.Core.JsonData? right) { throw null; }
        public static explicit operator bool (Azure.Core.JsonData json) { throw null; }
        public static explicit operator double (Azure.Core.JsonData json) { throw null; }
        public static explicit operator int (Azure.Core.JsonData json) { throw null; }
        public static explicit operator long (Azure.Core.JsonData json) { throw null; }
        public static explicit operator bool? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator double? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator int? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator long? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator float? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator float (Azure.Core.JsonData json) { throw null; }
        public static explicit operator string (Azure.Core.JsonData json) { throw null; }
        public static implicit operator Azure.Core.JsonData (bool value) { throw null; }
        public static implicit operator Azure.Core.JsonData (double value) { throw null; }
        public static implicit operator Azure.Core.JsonData (int value) { throw null; }
        public static implicit operator Azure.Core.JsonData (long value) { throw null; }
        public static implicit operator Azure.Core.JsonData (bool? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (double? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (int? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (long? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (float? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (float value) { throw null; }
        public static implicit operator Azure.Core.JsonData (string? value) { throw null; }
        public static bool operator !=(Azure.Core.JsonData? left, string? right) { throw null; }
        public static bool operator !=(string? left, Azure.Core.JsonData? right) { throw null; }
        public void Set(string propertyName, bool value) { }
        public void Set(string propertyName, double value) { }
        public void Set(string propertyName, int value) { }
        public void Set(string propertyName, long value) { }
        public Azure.Core.JsonData Set(string propertyName, object? serializable) { throw null; }
        public Azure.Core.JsonData Set(string propertyName, object? serializable, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public void Set(string propertyName, float value) { }
        public void Set(string propertyName, string? value) { }
        public Azure.Core.JsonData SetEmptyArray(string propertyName) { throw null; }
        public Azure.Core.JsonData SetEmptyObject(string propertyName) { throw null; }
        public Azure.Core.JsonData Set<T>(string propertyName, T[] serializable) { throw null; }
        public Azure.Core.JsonData Set<T>(string propertyName, T[] serializable, System.Text.Json.JsonSerializerOptions options) { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public string ToJsonString() { throw null; }
        public override string ToString() { throw null; }
        public T To<T>() { throw null; }
        public T To<T>(System.Text.Json.JsonSerializerOptions options) { throw null; }
        public long WriteTo(System.IO.Stream stream) { throw null; }
        public System.Threading.Tasks.Task<long> WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class ResponsePropertiesPolicy : Azure.Core.Pipeline.HttpPipelinePolicy
    {
        public ResponsePropertiesPolicy(Azure.Core.ClientOptions options) { }
        public override void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
    }
}
namespace Azure.Core.Pipeline
{
    public static partial class ResponseExtensions
    {
        public static Azure.RequestFailedException CreateRequestFailedException(this Azure.Response response) { throw null; }
        public static bool IsError(this Azure.Response response) { throw null; }
    }
}
