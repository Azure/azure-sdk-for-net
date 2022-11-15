namespace ADP.Common.Operations
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LongRunningOperationStatus : System.IEquatable<ADP.Common.Operations.LongRunningOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LongRunningOperationStatus(string value) { throw null; }
        public static ADP.Common.Operations.LongRunningOperationStatus Canceled { get { throw null; } }
        public static ADP.Common.Operations.LongRunningOperationStatus Created { get { throw null; } }
        public static ADP.Common.Operations.LongRunningOperationStatus Failed { get { throw null; } }
        public static ADP.Common.Operations.LongRunningOperationStatus InProgress { get { throw null; } }
        public static ADP.Common.Operations.LongRunningOperationStatus Succeeded { get { throw null; } }
        public bool Equals(ADP.Common.Operations.LongRunningOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(ADP.Common.Operations.LongRunningOperationStatus left, ADP.Common.Operations.LongRunningOperationStatus right) { throw null; }
        public static implicit operator ADP.Common.Operations.LongRunningOperationStatus (string value) { throw null; }
        public static bool operator !=(ADP.Common.Operations.LongRunningOperationStatus left, ADP.Common.Operations.LongRunningOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LongRunningOperationWithResponseHeaders
    {
        internal LongRunningOperationWithResponseHeaders() { }
        public Azure.Core.Foundations.Error Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string OperationType { get { throw null; } }
        public ADP.Common.Operations.LongRunningOperationStatus Status { get { throw null; } }
    }
}
namespace ADP.DataManagement.Ingestion.Discoveries
{
    public partial class Discovery
    {
        internal Discovery() { }
        public string DiscoveryId { get { throw null; } }
        public string ExternalPackageId { get { throw null; } }
        public string ManifestUploadUri { get { throw null; } }
        public ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus? Status { get { throw null; } }
    }
    public partial class DiscoveryCreationParameters
    {
        public DiscoveryCreationParameters() { }
        public string ExternalPackageId { get { throw null; } set { } }
    }
    public partial class DiscoveryLroResponse
    {
        internal DiscoveryLroResponse() { }
        public Azure.Core.Foundations.Error Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType? OperationType { get { throw null; } }
        public ADP.Common.Operations.LongRunningOperationStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryOperationType : System.IEquatable<ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryOperationType(string value) { throw null; }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType AbortDiscovery { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType CompleteDiscovery { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType FinalizeFileList { get { throw null; } }
        public bool Equals(ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType left, ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType right) { throw null; }
        public static implicit operator ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType (string value) { throw null; }
        public static bool operator !=(ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType left, ADP.DataManagement.Ingestion.Discoveries.DiscoveryOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoverySpecialFile
    {
        internal DiscoverySpecialFile() { }
        public string ClientFileName { get { throw null; } }
        public string FileUploadUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryStatus : System.IEquatable<ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryStatus(string value) { throw null; }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus Aborted { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus Aborting { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus Completed { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus Completing { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus Created { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus Failed { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus GeneratedSpecialFilesUploadInfo { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus GeneratingSpecialFilesUploadInfo { get { throw null; } }
        public bool Equals(ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus left, ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus right) { throw null; }
        public static implicit operator ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus (string value) { throw null; }
        public static bool operator !=(ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus left, ADP.DataManagement.Ingestion.Discoveries.DiscoveryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryUpload
    {
        internal DiscoveryUpload() { }
        public string ManifestDownloadUri { get { throw null; } }
        public string ResourceEndpoint { get { throw null; } }
        public string UploadId { get { throw null; } }
    }
}
namespace ADP.DataManagement.Ingestion.Uploads
{
    public partial class Upload
    {
        internal Upload() { }
        public string DiscoveryId { get { throw null; } }
        public string ExternalPackageId { get { throw null; } }
        public string ManifestUploadUri { get { throw null; } }
        public string ResourceEndpoint { get { throw null; } }
        public ADP.DataManagement.Ingestion.Uploads.UploadStatus? Status { get { throw null; } }
    }
    public partial class UploadCreationParameters
    {
        public UploadCreationParameters() { }
        public string DiscoveryId { get { throw null; } set { } }
        public string ExternalPackageId { get { throw null; } set { } }
    }
    public partial class UploadDataFile
    {
        internal UploadDataFile() { }
        public string ClientFileName { get { throw null; } }
        public string FileUploadUri { get { throw null; } }
    }
    public partial class UploadLroResponse
    {
        internal UploadLroResponse() { }
        public Azure.Core.Foundations.Error Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public ADP.DataManagement.Ingestion.Uploads.UploadOperationType? OperationType { get { throw null; } }
        public ADP.Common.Operations.LongRunningOperationStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UploadOperationType : System.IEquatable<ADP.DataManagement.Ingestion.Uploads.UploadOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UploadOperationType(string value) { throw null; }
        public static ADP.DataManagement.Ingestion.Uploads.UploadOperationType AbortUpload { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadOperationType CompleteUpload { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadOperationType FinalizeFileList { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadOperationType ShardFiles { get { throw null; } }
        public bool Equals(ADP.DataManagement.Ingestion.Uploads.UploadOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(ADP.DataManagement.Ingestion.Uploads.UploadOperationType left, ADP.DataManagement.Ingestion.Uploads.UploadOperationType right) { throw null; }
        public static implicit operator ADP.DataManagement.Ingestion.Uploads.UploadOperationType (string value) { throw null; }
        public static bool operator !=(ADP.DataManagement.Ingestion.Uploads.UploadOperationType left, ADP.DataManagement.Ingestion.Uploads.UploadOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UploadResultMeasurement
    {
        internal UploadResultMeasurement() { }
        public string MeasurementId { get { throw null; } }
    }
    public partial class UploadSpecialFile
    {
        internal UploadSpecialFile() { }
        public string ClientFileName { get { throw null; } }
        public string FileUploadUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UploadStatus : System.IEquatable<ADP.DataManagement.Ingestion.Uploads.UploadStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UploadStatus(string value) { throw null; }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus Aborted { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus Aborting { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus Completed { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus Completing { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus Created { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus Failed { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus GeneratedDataFilesUploadInfo { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus GeneratedSpecialFilesUploadInfo { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus GeneratingDataFilesUploadInfo { get { throw null; } }
        public static ADP.DataManagement.Ingestion.Uploads.UploadStatus GeneratingSpecialFilesUploadInfo { get { throw null; } }
        public bool Equals(ADP.DataManagement.Ingestion.Uploads.UploadStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(ADP.DataManagement.Ingestion.Uploads.UploadStatus left, ADP.DataManagement.Ingestion.Uploads.UploadStatus right) { throw null; }
        public static implicit operator ADP.DataManagement.Ingestion.Uploads.UploadStatus (string value) { throw null; }
        public static bool operator !=(ADP.DataManagement.Ingestion.Uploads.UploadStatus left, ADP.DataManagement.Ingestion.Uploads.UploadStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace AutonomousDevelopmentPlatform
{
    public partial class AutonomousDevelopmentPlatformClientOptions : Azure.Core.ClientOptions
    {
        public AutonomousDevelopmentPlatformClientOptions(AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions.ServiceVersion version = AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions.ServiceVersion.V2022_11_30_Preview) { }
        public enum ServiceVersion
        {
            V2022_11_30_Preview = 1,
        }
    }
    public partial class DiscoveriesClient
    {
        protected DiscoveriesClient() { }
        public DiscoveriesClient(Azure.Core.TokenCredential credential) { }
        public DiscoveriesClient(Azure.Core.TokenCredential credential, AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Cancel(Azure.WaitUntil waitUntil, string discoveryId, string operationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelAsync(Azure.WaitUntil waitUntil, string discoveryId, string operationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Complete(Azure.WaitUntil waitUntil, string discoveryId, string operationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CompleteAsync(Azure.WaitUntil waitUntil, string discoveryId, string operationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<ADP.DataManagement.Ingestion.Discoveries.Discovery> CreateOrReplace(string discoveryId, ADP.DataManagement.Ingestion.Discoveries.DiscoveryCreationParameters body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplace(string discoveryId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<ADP.DataManagement.Ingestion.Discoveries.Discovery>> CreateOrReplaceAsync(string discoveryId, ADP.DataManagement.Ingestion.Discoveries.DiscoveryCreationParameters body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceAsync(string discoveryId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Get(string discoveryId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string discoveryId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<ADP.DataManagement.Ingestion.Discoveries.Discovery> GetValue(string discoveryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<ADP.DataManagement.Ingestion.Discoveries.Discovery>> GetValueAsync(string discoveryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveryResultUploadsClient
    {
        protected DiscoveryResultUploadsClient() { }
        public DiscoveryResultUploadsClient(Azure.Core.TokenCredential credential) { }
        public DiscoveryResultUploadsClient(Azure.Core.TokenCredential credential, AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> List(string discoveryId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> ListAsync(string discoveryId, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DiscoverySpecialFilesClient
    {
        protected DiscoverySpecialFilesClient() { }
        public DiscoverySpecialFilesClient(Azure.Core.TokenCredential credential) { }
        public DiscoverySpecialFilesClient(Azure.Core.TokenCredential credential, AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Generate(Azure.WaitUntil waitUntil, string discoveryId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> GenerateAsync(Azure.WaitUntil waitUntil, string discoveryId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> List(string discoveryId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> ListAsync(string discoveryId, Azure.RequestContext context = null) { throw null; }
    }
    public partial class LongRunningClient
    {
        protected LongRunningClient() { }
        public LongRunningClient(Azure.Core.TokenCredential credential) { }
        public LongRunningClient(Azure.Core.TokenCredential credential, AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Get(Azure.WaitUntil waitUntil, string operationId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> GetAsync(Azure.WaitUntil waitUntil, string operationId, Azure.RequestContext context = null) { throw null; }
    }
    public partial class UploadDataFilesClient
    {
        protected UploadDataFilesClient() { }
        public UploadDataFilesClient(Azure.Core.TokenCredential credential) { }
        public UploadDataFilesClient(Azure.Core.TokenCredential credential, AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Generate(Azure.WaitUntil waitUntil, string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> GenerateAsync(Azure.WaitUntil waitUntil, string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> List(string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> ListAsync(string uploadId, Azure.RequestContext context = null) { throw null; }
    }
    public partial class UploadResultMeasurementsClient
    {
        protected UploadResultMeasurementsClient() { }
        public UploadResultMeasurementsClient(Azure.Core.TokenCredential credential) { }
        public UploadResultMeasurementsClient(Azure.Core.TokenCredential credential, AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> List(string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> ListAsync(string uploadId, Azure.RequestContext context = null) { throw null; }
    }
    public partial class UploadsClient
    {
        protected UploadsClient() { }
        public UploadsClient(Azure.Core.TokenCredential credential) { }
        public UploadsClient(Azure.Core.TokenCredential credential, AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Cancel(Azure.WaitUntil waitUntil, string uploadId, string operationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelAsync(Azure.WaitUntil waitUntil, string uploadId, string operationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Complete(Azure.WaitUntil waitUntil, string uploadId, string operationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CompleteAsync(Azure.WaitUntil waitUntil, string uploadId, string operationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<ADP.DataManagement.Ingestion.Uploads.Upload> CreateOrReplace(string uploadId, ADP.DataManagement.Ingestion.Uploads.UploadCreationParameters body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplace(string uploadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<ADP.DataManagement.Ingestion.Uploads.Upload>> CreateOrReplaceAsync(string uploadId, ADP.DataManagement.Ingestion.Uploads.UploadCreationParameters body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceAsync(string uploadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Get(string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<ADP.DataManagement.Ingestion.Uploads.Upload> GetValue(string uploadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<ADP.DataManagement.Ingestion.Uploads.Upload>> GetValueAsync(string uploadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UploadSpecialFilesClient
    {
        protected UploadSpecialFilesClient() { }
        public UploadSpecialFilesClient(Azure.Core.TokenCredential credential) { }
        public UploadSpecialFilesClient(Azure.Core.TokenCredential credential, AutonomousDevelopmentPlatform.AutonomousDevelopmentPlatformClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Generate(Azure.WaitUntil waitUntil, string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> GenerateAsync(Azure.WaitUntil waitUntil, string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> List(string uploadId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> ListAsync(string uploadId, Azure.RequestContext context = null) { throw null; }
    }
}
namespace Azure.Core.Foundations
{
    public partial class Error
    {
        internal Error() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Foundations.Error> Details { get { throw null; } }
        public Azure.Core.Foundations.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class InnerError
    {
        internal InnerError() { }
        public string Code { get { throw null; } }
        public Azure.Core.Foundations.InnerError Innererror { get { throw null; } }
    }
}
