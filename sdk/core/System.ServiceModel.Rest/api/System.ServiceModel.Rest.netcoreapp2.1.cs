namespace System.ServiceModel.Rest
{
    public partial class KeyCredential
    {
        public KeyCredential(string key) { }
        public string Key { get { throw null; } }
        public void Update(string key) { }
    }
    public abstract partial class NullableResult<T>
    {
        protected NullableResult() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public abstract bool HasValue { get; }
        public abstract T? Value { get; }
        public abstract System.ServiceModel.Rest.Result GetRawResult();
    }
    public partial class PipelineOptions
    {
        public PipelineOptions() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public static System.Threading.CancellationToken DefaultCancellationToken { get { throw null; } set { } }
        public System.ServiceModel.Rest.ResultErrorOptions ResultErrorOptions { get { throw null; } set { } }
    }
    public partial class RequestErrorException : System.Exception
    {
        protected RequestErrorException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public RequestErrorException(System.ServiceModel.Rest.Result result) { }
        protected RequestErrorException(System.ServiceModel.Rest.Result result, string message, System.Exception? innerException) { }
        public int Status { get { throw null; } }
    }
    public abstract partial class Result : System.IDisposable
    {
        protected Result() { }
        public virtual System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public virtual bool IsError { get { throw null; } set { } }
        public abstract int Status { get; }
        public abstract void Dispose();
        public static System.ServiceModel.Rest.Result<T> FromValue<T>(T value, System.ServiceModel.Rest.Result result) { throw null; }
        protected abstract bool TryGetHeader(string name, out string? value);
        public bool TryGetHeaderValue(string name, out string? value) { throw null; }
    }
    [System.FlagsAttribute]
    public enum ResultErrorOptions
    {
        Default = 0,
        NoThrow = 1,
    }
    public abstract partial class Result<T> : System.ServiceModel.Rest.NullableResult<T>
    {
        protected Result() { }
    }
    public partial class TelemetrySource
    {
        public TelemetrySource(System.ServiceModel.Rest.PipelineOptions options, bool suppressNestedClientActivities = true) { }
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
    public abstract partial class RequestBody : System.IDisposable
    {
        protected RequestBody() { }
        public static System.ServiceModel.Rest.Core.RequestBody Create(System.IO.Stream stream) { throw null; }
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
    }
    public partial class ResponseErrorClassifier
    {
        public ResponseErrorClassifier() { }
        public virtual bool IsErrorResponse(System.ServiceModel.Rest.Core.RestMessage message) { throw null; }
    }
    public abstract partial class RestMessage : System.IDisposable
    {
        protected RestMessage() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public abstract System.ServiceModel.Rest.Result? Result { get; }
        public abstract void Dispose();
    }
}
namespace System.ServiceModel.Rest.Core.Pipeline
{
    public abstract partial class MessagePipeline
    {
        protected MessagePipeline() { }
        public abstract System.ServiceModel.Rest.Core.RestMessage CreateRestMessage(System.ServiceModel.Rest.PipelineOptions options, System.ServiceModel.Rest.Core.ResponseErrorClassifier classifier);
        public abstract void Send(System.ServiceModel.Rest.Core.RestMessage message, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task SendAsync(System.ServiceModel.Rest.Core.RestMessage message, System.Threading.CancellationToken cancellationToken);
    }
}
namespace System.ServiceModel.Rest.Shared
{
    public partial class ClientUtilities
    {
        public ClientUtilities() { }
        public static void AssertNotNullOrEmpty(string value, string name) { }
        public static void AssertNotNull<T>(T value, string name) { }
        public static void ThrowIfCancellationRequested(System.Threading.CancellationToken cancellationToken) { }
    }
}
namespace System.ServiceModel.Rest.Shared.Core
{
    public partial class RequestUri
    {
        public RequestUri() { }
        protected bool HasPath { get { throw null; } }
        protected bool HasQuery { get { throw null; } }
        public string? Host { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string PathAndQuery { get { throw null; } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string? Scheme { get { throw null; } set { } }
        public virtual void AppendPath(System.ReadOnlySpan<char> value, bool escape) { }
        public virtual void AppendPath(string value) { }
        public virtual void AppendPath(string value, bool escape) { }
        public virtual void AppendQuery(System.ReadOnlySpan<char> name, System.ReadOnlySpan<char> value, bool escapeValue) { }
        public virtual void AppendQuery(string name, string value) { }
        public virtual void AppendQuery(string name, string value, bool escapeValue) { }
        public virtual void AppendRaw(string value, bool escape) { }
        public virtual void AppendRawNextLink(string nextLink, bool escape) { }
        public virtual void Reset(System.Uri value) { }
        public override string ToString() { throw null; }
        public virtual System.Uri ToUri() { throw null; }
    }
}
namespace System.ServiceModel.Rest.Shared.Core.Pipeline
{
    public static partial class PipelineProtocolExtensions
    {
        public static System.ServiceModel.Rest.Result<bool> ProcessHeadAsBoolMessage(this System.ServiceModel.Rest.Core.Pipeline.MessagePipeline pipeline, System.ServiceModel.Rest.Core.RestMessage message, System.ServiceModel.Rest.TelemetrySource clientDiagnostics, System.ServiceModel.Rest.PipelineOptions? requestContext) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ServiceModel.Rest.Result<bool>> ProcessHeadAsBoolMessageAsync(this System.ServiceModel.Rest.Core.Pipeline.MessagePipeline pipeline, System.ServiceModel.Rest.Core.RestMessage message, System.ServiceModel.Rest.TelemetrySource clientDiagnostics, System.ServiceModel.Rest.PipelineOptions? requestContext) { throw null; }
        public static System.ServiceModel.Rest.Result ProcessMessage(this System.ServiceModel.Rest.Core.Pipeline.MessagePipeline pipeline, System.ServiceModel.Rest.Core.RestMessage message, System.ServiceModel.Rest.PipelineOptions? requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<System.ServiceModel.Rest.Result> ProcessMessageAsync(this System.ServiceModel.Rest.Core.Pipeline.MessagePipeline pipeline, System.ServiceModel.Rest.Core.RestMessage message, System.ServiceModel.Rest.PipelineOptions? requestContext, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace System.ServiceModel.Rest.Shared.Serialization
{
    public partial interface IUtf8JsonWriteable
    {
        void Write(System.Text.Json.Utf8JsonWriter writer);
    }
    public partial class OptionalDictionary<TKey, TValue> : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IDictionary<TKey, TValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>, System.Collections.IEnumerable where TKey : notnull
    {
        public OptionalDictionary() { }
        public OptionalDictionary(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optionalDictionary) { }
        public OptionalDictionary(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optionalDictionary) { }
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
        public OptionalList(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<System.Collections.Generic.IList<T>> optionalList) { }
        public OptionalList(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optionalList) { }
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
        public static System.Collections.Generic.IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<System.Collections.Generic.IDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>> optional) { throw null; }
        public static System.Collections.Generic.IList<T> ToList<T>(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<System.Collections.Generic.IList<T>> optional) { throw null; }
        public static System.Collections.Generic.IReadOnlyList<T> ToList<T>(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<System.Collections.Generic.IReadOnlyList<T>> optional) { throw null; }
        public static T? ToNullable<T>(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<T?> optional) where T : struct { throw null; }
        public static T? ToNullable<T>(System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<T> optional) where T : struct { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptionalProperty<T>
    {
        private readonly T _Value_k__BackingField;
        private readonly int _dummyPrimitive;
        public OptionalProperty(T value) { throw null; }
        public bool HasValue { get { throw null; } }
        public T Value { get { throw null; } }
        public static implicit operator T (System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<T> optional) { throw null; }
        public static implicit operator System.ServiceModel.Rest.Shared.Serialization.OptionalProperty<T> (T value) { throw null; }
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
