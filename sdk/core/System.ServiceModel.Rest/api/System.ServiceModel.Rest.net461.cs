namespace System.ServiceModel.Rest
{
    public abstract partial class Credential
    {
        protected Credential() { }
    }
    public partial class KeyCredential : System.ServiceModel.Rest.Credential
    {
        public KeyCredential(string key) { }
        public string Key { get { throw null; } }
        public void Update(string key) { }
    }
    public partial class NullableResult<T>
    {
        public NullableResult(T? value, System.ServiceModel.Rest.Result result) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual bool HasValue { get { throw null; } }
        public virtual T? Value { get { throw null; } }
        public virtual System.ServiceModel.Rest.Result GetRawResult() { throw null; }
    }
    public partial class PipelineOptions
    {
        public PipelineOptions() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        public static System.Threading.CancellationToken DefaultCancellationToken { get { throw null; } set { } }
    }
    public partial class RequestErrorException : System.Exception
    {
        protected RequestErrorException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public RequestErrorException(System.ServiceModel.Rest.Result result) { }
        protected RequestErrorException(System.ServiceModel.Rest.Result result, string message, System.Exception? innerException) { }
        public int Status { get { throw null; } }
    }
    public abstract partial class Result
    {
        protected Result() { }
        public virtual System.BinaryData Content { get { throw null; } }
        public abstract System.IO.Stream? ContentStream { get; set; }
        public abstract int Status { get; }
        public static System.ServiceModel.Rest.Result<T> FromValue<T>(T value, System.ServiceModel.Rest.Result result) { throw null; }
        protected abstract bool TryGetHeader(string name, out string? value);
        public bool TryGetHeaderValue(string name, out string? value) { throw null; }
    }
    public partial class Result<T> : System.ServiceModel.Rest.NullableResult<T>
    {
        public Result(T value, System.ServiceModel.Rest.Result result) : base (default(T), default(System.ServiceModel.Rest.Result)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasValue { get { throw null; } }
        public override T Value { get { throw null; } }
        public override System.ServiceModel.Rest.Result GetRawResult() { throw null; }
    }
    public partial class TelemetrySource
    {
        public TelemetrySource(System.ServiceModel.Rest.PipelineOptions options, bool suppressNestedClientActivities = true) { }
        public System.ServiceModel.Rest.TelemetrySpan CreateSpan(string name, System.Diagnostics.ActivityKind kind = System.Diagnostics.ActivityKind.Internal) { throw null; }
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
        public abstract void Dispose();
        public abstract bool TryComputeLength(out long length);
        public abstract void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
        public abstract System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation);
    }
}
