namespace Azure.MixedReality.RemoteRendering
{
    public partial class AssetConversion
    {
        internal AssetConversion() { }
        public string ConversionId { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError Error { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.AssetConversionOptions Options { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.AssetConversionOutput Output { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.AssetConversionStatus Status { get { throw null; } }
    }
    public partial class AssetConversionInputOptions
    {
        public AssetConversionInputOptions(System.Uri storageContainerUri, string relativeInputAssetPath) { }
        public string BlobPrefix { get { throw null; } set { } }
        public string RelativeInputAssetPath { get { throw null; } }
        public string StorageContainerReadListSas { get { throw null; } set { } }
        public System.Uri StorageContainerUri { get { throw null; } }
    }
    public partial class AssetConversionOperation : Azure.Operation<Azure.MixedReality.RemoteRendering.AssetConversion>
    {
        protected AssetConversionOperation() { }
        public AssetConversionOperation(string conversionId, Azure.MixedReality.RemoteRendering.RemoteRenderingClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.MixedReality.RemoteRendering.AssetConversion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.MixedReality.RemoteRendering.AssetConversion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.MixedReality.RemoteRendering.AssetConversion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssetConversionOptions
    {
        public AssetConversionOptions(Azure.MixedReality.RemoteRendering.AssetConversionInputOptions inputOptions, Azure.MixedReality.RemoteRendering.AssetConversionOutputOptions outputOptions) { }
        public Azure.MixedReality.RemoteRendering.AssetConversionInputOptions InputOptions { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.AssetConversionOutputOptions OutputOptions { get { throw null; } }
    }
    public partial class AssetConversionOutput
    {
        internal AssetConversionOutput() { }
        public string OutputAssetUri { get { throw null; } }
    }
    public partial class AssetConversionOutputOptions
    {
        public AssetConversionOutputOptions(System.Uri storageContainerUri) { }
        public string BlobPrefix { get { throw null; } set { } }
        public string OutputAssetFilename { get { throw null; } set { } }
        public System.Uri StorageContainerUri { get { throw null; } }
        public string StorageContainerWriteSas { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetConversionStatus : System.IEquatable<Azure.MixedReality.RemoteRendering.AssetConversionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetConversionStatus(string value) { throw null; }
        public static Azure.MixedReality.RemoteRendering.AssetConversionStatus Cancelled { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.AssetConversionStatus Failed { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.AssetConversionStatus NotStarted { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.AssetConversionStatus Running { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.AssetConversionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.MixedReality.RemoteRendering.AssetConversionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.MixedReality.RemoteRendering.AssetConversionStatus left, Azure.MixedReality.RemoteRendering.AssetConversionStatus right) { throw null; }
        public static implicit operator Azure.MixedReality.RemoteRendering.AssetConversionStatus (string value) { throw null; }
        public static bool operator !=(Azure.MixedReality.RemoteRendering.AssetConversionStatus left, Azure.MixedReality.RemoteRendering.AssetConversionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoteRenderingClient
    {
        protected RemoteRenderingClient() { }
        public RemoteRenderingClient(System.Uri remoteRenderingEndpoint, System.Guid accountId, string accountDomain, Azure.AzureKeyCredential keyCredential) { }
        public RemoteRenderingClient(System.Uri remoteRenderingEndpoint, System.Guid accountId, string accountDomain, Azure.AzureKeyCredential keyCredential, Azure.MixedReality.RemoteRendering.RemoteRenderingClientOptions options) { }
        public RemoteRenderingClient(System.Uri remoteRenderingEndpoint, System.Guid accountId, string accountDomain, Azure.Core.AccessToken accessToken, Azure.MixedReality.RemoteRendering.RemoteRenderingClientOptions options = null) { }
        public RemoteRenderingClient(System.Uri remoteRenderingEndpoint, System.Guid accountId, string accountDomain, Azure.Core.TokenCredential credential, Azure.MixedReality.RemoteRendering.RemoteRenderingClientOptions options = null) { }
        public virtual Azure.Response<Azure.MixedReality.RemoteRendering.AssetConversion> GetConversion(string conversionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.MixedReality.RemoteRendering.AssetConversion>> GetConversionAsync(string conversionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.MixedReality.RemoteRendering.AssetConversion> GetConversions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.MixedReality.RemoteRendering.AssetConversion> GetConversionsAync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.MixedReality.RemoteRendering.RenderingSession> GetSession(string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.MixedReality.RemoteRendering.RenderingSession>> GetSessionAsync(string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.MixedReality.RemoteRendering.RenderingSession> GetSessions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.MixedReality.RemoteRendering.RenderingSession> GetSessionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.MixedReality.RemoteRendering.AssetConversionOperation StartConversion(string conversionId, Azure.MixedReality.RemoteRendering.AssetConversionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.MixedReality.RemoteRendering.AssetConversionOperation> StartConversionAsync(string conversionId, Azure.MixedReality.RemoteRendering.AssetConversionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.MixedReality.RemoteRendering.StartRenderingSessionOperation StartSession(string sessionId, Azure.MixedReality.RemoteRendering.RenderingSessionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.MixedReality.RemoteRendering.StartRenderingSessionOperation> StartSessionAsync(string sessionId, Azure.MixedReality.RemoteRendering.RenderingSessionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopSession(string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopSessionAsync(string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.MixedReality.RemoteRendering.RenderingSession> UpdateSession(string sessionId, Azure.MixedReality.RemoteRendering.UpdateSessionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.MixedReality.RemoteRendering.RenderingSession>> UpdateSessionAsync(string sessionId, Azure.MixedReality.RemoteRendering.UpdateSessionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RemoteRenderingClientOptions : Azure.Core.ClientOptions
    {
        public RemoteRenderingClientOptions(Azure.MixedReality.RemoteRendering.RemoteRenderingClientOptions.ServiceVersion version = Azure.MixedReality.RemoteRendering.RemoteRenderingClientOptions.ServiceVersion.V2021_01_01) { }
        public System.Uri AuthenticationEndpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2021_01_01 = 1,
        }
    }
    public static partial class RemoteRenderingModelFactory
    {
        public static Azure.MixedReality.RemoteRendering.AssetConversion AssetConversion(string conversionId, Azure.MixedReality.RemoteRendering.AssetConversionOptions options, Azure.MixedReality.RemoteRendering.AssetConversionOutput output, Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError error, Azure.MixedReality.RemoteRendering.AssetConversionStatus status, System.DateTimeOffset createdOn) { throw null; }
        public static Azure.MixedReality.RemoteRendering.AssetConversionOutput AssetConversionOutput(System.Uri outputAssetUri) { throw null; }
        public static Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError RemoteRenderingServiceError(string code, string message, System.Collections.Generic.IReadOnlyList<Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError> details, string target, Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError innerError) { throw null; }
        public static Azure.MixedReality.RemoteRendering.RenderingSession RenderingSession(string sessionId, int? arrInspectorPort, int? handshakePort, int? elapsedTimeMinutes, string host, int? maxLeaseTimeMinutes, Azure.MixedReality.RemoteRendering.RenderingServerSize size, Azure.MixedReality.RemoteRendering.RenderingSessionStatus status, float? teraflops, Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError error, System.DateTimeOffset? createdOn) { throw null; }
    }
    public partial class RemoteRenderingServiceError
    {
        internal RemoteRenderingServiceError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError> Details { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RenderingServerSize : System.IEquatable<Azure.MixedReality.RemoteRendering.RenderingServerSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RenderingServerSize(string value) { throw null; }
        public static Azure.MixedReality.RemoteRendering.RenderingServerSize Premium { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.RenderingServerSize Standard { get { throw null; } }
        public bool Equals(Azure.MixedReality.RemoteRendering.RenderingServerSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.MixedReality.RemoteRendering.RenderingServerSize left, Azure.MixedReality.RemoteRendering.RenderingServerSize right) { throw null; }
        public static implicit operator Azure.MixedReality.RemoteRendering.RenderingServerSize (string value) { throw null; }
        public static bool operator !=(Azure.MixedReality.RemoteRendering.RenderingServerSize left, Azure.MixedReality.RemoteRendering.RenderingServerSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RenderingSession
    {
        internal RenderingSession() { }
        public int? ArrInspectorPort { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? ElapsedTimeMinutes { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.RemoteRenderingServiceError Error { get { throw null; } }
        public int? HandshakePort { get { throw null; } }
        public string Host { get { throw null; } }
        public System.TimeSpan? MaxLeaseTime { get { throw null; } }
        public string SessionId { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.RenderingServerSize Size { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.RenderingSessionStatus Status { get { throw null; } }
        public float? Teraflops { get { throw null; } }
    }
    public partial class RenderingSessionOptions
    {
        public RenderingSessionOptions(System.TimeSpan maxLeaseTime, Azure.MixedReality.RemoteRendering.RenderingServerSize size) { }
        public System.TimeSpan MaxLeaseTime { get { throw null; } }
        public Azure.MixedReality.RemoteRendering.RenderingServerSize Size { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RenderingSessionStatus : System.IEquatable<Azure.MixedReality.RemoteRendering.RenderingSessionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RenderingSessionStatus(string value) { throw null; }
        public static Azure.MixedReality.RemoteRendering.RenderingSessionStatus Error { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.RenderingSessionStatus Expired { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.RenderingSessionStatus Ready { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.RenderingSessionStatus Starting { get { throw null; } }
        public static Azure.MixedReality.RemoteRendering.RenderingSessionStatus Stopped { get { throw null; } }
        public bool Equals(Azure.MixedReality.RemoteRendering.RenderingSessionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.MixedReality.RemoteRendering.RenderingSessionStatus left, Azure.MixedReality.RemoteRendering.RenderingSessionStatus right) { throw null; }
        public static implicit operator Azure.MixedReality.RemoteRendering.RenderingSessionStatus (string value) { throw null; }
        public static bool operator !=(Azure.MixedReality.RemoteRendering.RenderingSessionStatus left, Azure.MixedReality.RemoteRendering.RenderingSessionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartRenderingSessionOperation : Azure.Operation<Azure.MixedReality.RemoteRendering.RenderingSession>
    {
        protected StartRenderingSessionOperation() { }
        public StartRenderingSessionOperation(string sessionId, Azure.MixedReality.RemoteRendering.RemoteRenderingClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.MixedReality.RemoteRendering.RenderingSession Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.MixedReality.RemoteRendering.RenderingSession>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.MixedReality.RemoteRendering.RenderingSession>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateSessionOptions
    {
        public UpdateSessionOptions(System.TimeSpan maxLeaseTime) { }
        public System.TimeSpan MaxLeaseTime { get { throw null; } }
    }
}
