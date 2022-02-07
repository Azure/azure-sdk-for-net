namespace Azure.Storage.DataMovement.Blobs
{
    public partial class BlobTransferManager : Azure.Storage.DataMovement.StorageTransferManager
    {
        protected internal BlobTransferManager() { }
        public BlobTransferManager(Azure.Storage.DataMovement.Models.StorageTransferManagerOptions options) { }
        public override void CancelTransfers() { }
        public override void Clean() { }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties GetJobProperties(string jobId) { throw null; }
        public System.Threading.Tasks.Task PauseJob(string jobId) { throw null; }
        public override void PauseTransfers() { }
        public System.Threading.Tasks.Task ResumeJob(string jobId) { throw null; }
        public string ScheduleCopy(System.Uri sourceUri, Azure.Storage.Blobs.BlobClient destinationClient, Azure.Storage.DataMovement.Blobs.Models.BlobServiceCopyMethod copyMethod, Azure.Storage.Blobs.Models.BlobCopyFromUriOptions copyOptions = null) { throw null; }
        public string ScheduleCopyDirectory(System.Uri sourceUri, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationClient, Azure.Storage.DataMovement.Blobs.Models.BlobServiceCopyMethod copyMethod, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryCopyFromUriOptions copyOptions = null) { throw null; }
        public string ScheduleDownload(Azure.Storage.Blobs.BlobClient sourceClient, string destinationLocalPath, Azure.Storage.Blobs.Models.BlobDownloadToOptions options = null) { throw null; }
        public string ScheduleDownloadDirectory(Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceClient, string destinationLocalPath, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryDownloadOptions options = null) { throw null; }
        public string ScheduleUpload(string sourceLocalPath, Azure.Storage.Blobs.BlobClient destinationClient, Azure.Storage.Blobs.Models.BlobUploadOptions uploadOptions = null) { throw null; }
        public string ScheduleUploadDirectory(string sourceLocalPath, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationClient, bool overwrite = false, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryUploadOptions options = null) { throw null; }
    }
    public partial class BlobVirtualDirectoryClient
    {
        protected BlobVirtualDirectoryClient() { }
        public BlobVirtualDirectoryClient(Azure.Storage.Blobs.BlobContainerClient client, string directoryPath) { }
        public BlobVirtualDirectoryClient(Azure.Storage.Blobs.BlobServiceClient client, string containerName, string directoryPath) { }
        public BlobVirtualDirectoryClient(string connectionString, string blobContainerName, string blobDirectoryPath) { }
        public BlobVirtualDirectoryClient(string connectionString, string blobContainerName, string blobDirectoryPath, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobVirtualDirectoryClient(System.Uri blobDirectoryUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobVirtualDirectoryClient(System.Uri blobDirectoryUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobVirtualDirectoryClient(System.Uri blobDirectoryUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobVirtualDirectoryClient(System.Uri blobDirectoryUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string BlobContainerName { get { throw null; } }
        public virtual string DirectoryPath { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<Azure.Response> Download(string targetPath) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Response> Download(string targetPath, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryDownloadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Response> Download(string targetPath, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Response>> DownloadAsync(string targetPath) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Response>> DownloadAsync(string targetPath, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryDownloadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Response>> DownloadAsync(string targetPath, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Storage.Blobs.BlobClient GetBlobClient(string blobName) { throw null; }
        protected internal virtual Azure.Storage.Blobs.BlobClient GetBlobClientCore(string blobName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobs(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobsAsync(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchy(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string delimiter = null, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchyAsync(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string delimiter = null, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.Specialized.BlockBlobClient GetBlockBlobClient(string blobName) { throw null; }
        protected internal virtual Azure.Storage.Blobs.Specialized.BlockBlobClient GetBlockBlobClientCore(string blobName) { throw null; }
        public virtual Azure.Storage.Blobs.BlobContainerClient GetParentBlobContainerClient() { throw null; }
        protected internal virtual Azure.Storage.Blobs.BlobContainerClient GetParentBlobContainerClientCore() { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> Upload(string sourceDirectoryPath, bool overwrite = false, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryUploadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>>> UploadAsync(string sourceDirectoryPath, bool overwrite = false, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryUploadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SpecializedBlobExtensions
    {
        public static Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient GetBlobVirtualDirectoryClient(this Azure.Storage.Blobs.BlobContainerClient client, string directoryPath) { throw null; }
        public static Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient GetBlobVirtualDirectoryClient(this Azure.Storage.Blobs.BlobServiceClient client, string containerName, string directoryPath) { throw null; }
    }
}
namespace Azure.Storage.DataMovement.Blobs.Models
{
    public partial class BlobDirectoryCopyFromUriOptions
    {
        public BlobDirectoryCopyFromUriOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy DestinationImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } set { } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
    }
    public partial class BlobDirectoryDownloadOptions
    {
        public BlobDirectoryDownloadOptions() { }
        public Azure.Storage.DataMovement.TransferProgressHandler ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.DownloadTransactionalHashingOptions TransactionalHashingOptions { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions TransferOptions { get { throw null; } set { } }
    }
    public partial class BlobDirectoryUploadOptions
    {
        public BlobDirectoryUploadOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.TransferProgressHandler> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.UploadTransactionalHashingOptions TransactionalHashingOptions { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions TransferOptions { get { throw null; } set { } }
    }
    public enum BlobServiceCopyMethod
    {
        ServiceSideAsyncCopy = 0,
        ServiceSideSyncCopy = 1,
    }
    public partial class BlobTransferJobProperties
    {
        internal BlobTransferJobProperties() { }
        public Azure.Storage.DataMovement.Blobs.Models.BlobServiceCopyMethod CopyMethod { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationBlobDirectoryClient { get { throw null; } }
        public string DestinationLocalPath { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryCopyFromUriOptions DirectoryCopyFromUriOptions { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryDownloadOptions DirectoryDownloadOptions { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryUploadOptions DirectoryUploadOptions { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobCopyFromUriOptions SingleCopyFromUriOptions { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobDownloadToOptions SingleDownloadOptions { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobUploadOptions SingleUploadOptions { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient SourceBlobClient { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient SourceBlobDirectoryClient { get { throw null; } }
        public string SourceLocalPath { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
        public Azure.Storage.DataMovement.Models.StorageJobTransferStatus Status { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.StorageTransferType TransferType { get { throw null; } }
    }
    public enum StorageTransferType
    {
        SingleUpload = 0,
        SingleDownload = 1,
        DirectoryUpload = 2,
        DirectoryDownload = 3,
        SingleServiceCopy = 4,
        DirectoryServiceCopy = 5,
    }
}
