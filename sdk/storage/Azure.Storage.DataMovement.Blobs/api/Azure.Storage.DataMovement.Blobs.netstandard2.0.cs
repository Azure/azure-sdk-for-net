namespace Azure.Storage.DataMovement.Blobs
{
    public partial class BlobTransferManager : Azure.Storage.DataMovement.StorageTransferManager
    {
        protected internal BlobTransferManager() { }
        public BlobTransferManager(Azure.Storage.DataMovement.Models.StorageTransferManagerOptions options) { }
        public override System.Threading.Tasks.Task CancelTransfersAsync() { throw null; }
        public override System.Threading.Tasks.Task CleanAsync() { throw null; }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties GetJobProperties(string jobId) { throw null; }
        public override System.Threading.Tasks.Task PauseJobAsync(string jobId) { throw null; }
        public override System.Threading.Tasks.Task PauseTransfersAsync() { throw null; }
        public override System.Threading.Tasks.Task ResumeJobAsync(string jobId) { throw null; }
        public string ScheduleCopy(System.Uri sourceUri, Azure.Storage.Blobs.BlobClient destinationClient, Azure.Storage.DataMovement.Blobs.Models.BlobCopyMethod copyMethod, Azure.Storage.Blobs.Models.BlobCopyFromUriOptions copyOptions = null) { throw null; }
        public string ScheduleCopyDirectory(System.Uri sourceUri, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationClient, Azure.Storage.DataMovement.Blobs.Models.BlobCopyMethod copyMethod, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryCopyFromUriOptions copyOptions = null) { throw null; }
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
    public partial class BlobCopyDirectoryEventHandler
    {
        public BlobCopyDirectoryEventHandler() { }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobCopyDirectoryTransferFailedEventArgs> DirectoriesFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobCopyDirectoryTransferSuccessEventArgs> DirectoriesTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobCopyTransferFailedEventArgs> FilesFailedTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobCopyTransferSuccessEventArgs> FilesTransferred { add { } remove { } }
    }
    public partial class BlobCopyDirectoryProgress
    {
        public BlobCopyDirectoryProgress() { }
        public int BlobsFailedTransferred { get { throw null; } }
        public int BlobsSuccesfullyTransferred { get { throw null; } }
    }
    public partial class BlobCopyDirectoryTransferFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobCopyDirectoryTransferFailedEventArgs(System.Uri sourceDirectoryUri, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationDirectoryClient, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryPath { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public System.Uri SourceDirectoryUri { get { throw null; } }
    }
    public partial class BlobCopyDirectoryTransferSuccessEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobCopyDirectoryTransferSuccessEventArgs(System.Uri sourceDirectoryUri, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationDirectoryClient, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryPath { get { throw null; } }
        public System.Uri SourceDirectoryUri { get { throw null; } }
    }
    public enum BlobCopyMethod
    {
        ServiceSideAsyncCopy = 0,
        ServiceSideSyncCopy = 1,
        ServiceSideSyncUploadFromUriCopy = 2,
    }
    public partial class BlobCopyTransferFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobCopyTransferFailedEventArgs(System.Uri sourceUri, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
    }
    public partial class BlobCopyTransferSkippedEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobCopyTransferSkippedEventArgs(System.Uri sourceUri, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
    }
    public partial class BlobCopyTransferSuccessEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobCopyTransferSuccessEventArgs(System.Uri sourceUri, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
    }
    public partial class BlobDirectoryCopyFromUriOptions
    {
        public BlobDirectoryCopyFromUriOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy DestinationImmutabilityPolicy { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobCopyDirectoryEventHandler EventHandler { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.Blobs.Models.BlobCopyDirectoryProgress> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } set { } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
    }
    public partial class BlobDirectoryDownloadOptions
    {
        public BlobDirectoryDownloadOptions() { }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDownloadDirectoryEventHandler EventHandler { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.Blobs.Models.BlobCopyDirectoryProgress> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.DownloadTransactionalHashingOptions TransactionalHashingOptions { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions TransferOptions { get { throw null; } set { } }
    }
    public partial class BlobDirectoryUploadOptions
    {
        public BlobDirectoryUploadOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobUploadDirectoryEventHandler EventHandler { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.Blobs.Models.BlobUploadDirectoryProgress> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.UploadTransactionalHashingOptions TransactionalHashingOptions { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions TransferOptions { get { throw null; } set { } }
    }
    public partial class BlobDownloadDirectoryEventHandler
    {
        public BlobDownloadDirectoryEventHandler() { }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadDirectoryTransferFailedEventArgs> DirectoriesFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadDirectoryTransferSuccessEventArgs> DirectoriesTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadTransferFailedEventArgs> FilesFailedTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadTransferSuccessEventArgs> FilesTransferred { add { } remove { } }
    }
    public partial class BlobDownloadDirectoryProgress
    {
        public BlobDownloadDirectoryProgress() { }
        public int BlobsFailedTransferred { get { throw null; } }
        public int BlobsSuccesfullyTransferred { get { throw null; } }
        public long TotalBytesTransferred { get { throw null; } }
    }
    public partial class BlobDownloadDirectoryTransferFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobDownloadDirectoryTransferFailedEventArgs(Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceBlobDirectoryClient, string destinationPath, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string DestinationDirectoryPath { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient SourceDirectoryClient { get { throw null; } }
    }
    public partial class BlobDownloadDirectoryTransferSuccessEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobDownloadDirectoryTransferSuccessEventArgs(Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceBlobDirectoryClient, string destinationPath, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string DestinationDirectoryPath { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient SourceDirectoryClient { get { throw null; } }
    }
    public partial class BlobDownloadTransferFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobDownloadTransferFailedEventArgs(Azure.Storage.Blobs.Specialized.BlobBaseClient sourceBlobClient, string destinationLocalPath, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string DestinationLocalPath { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient SourceBlobClient { get { throw null; } }
    }
    public partial class BlobDownloadTransferSuccessEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobDownloadTransferSuccessEventArgs(Azure.Storage.Blobs.Specialized.BlobBaseClient sourceBlobClient, string destinationLocalPath, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string DestinationLocalPath { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient SourceBlobClient { get { throw null; } }
    }
    public partial class BlobTransferJobProperties
    {
        internal BlobTransferJobProperties() { }
        public Azure.Storage.DataMovement.Blobs.Models.BlobCopyMethod CopyMethod { get { throw null; } }
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
    public partial class BlobUploadDirectoryEventHandler
    {
        public BlobUploadDirectoryEventHandler() { }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobUploadDirectoryTransferFailedEventArgs> DirectoriesFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobUploadDirectoryTransferSuccessEventArgs> DirectoriesTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobUploadTransferFailedEventArgs> FilesFailedTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobUploadTransferSkippedEventArgs> FilesSkippedTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobUploadTransferSuccessEventArgs> FilesTransferred { add { } remove { } }
    }
    public partial class BlobUploadDirectoryProgress
    {
        public BlobUploadDirectoryProgress() { }
        public int BlobsFailedTransferred { get { throw null; } }
        public int BlobsSkippedTransfering { get { throw null; } }
        public int BlobsSuccesfullyTransferred { get { throw null; } }
        public long TotalBytesTransferred { get { throw null; } }
    }
    public partial class BlobUploadDirectoryTransferFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobUploadDirectoryTransferFailedEventArgs(string sourcePath, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationBlobClient, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryClient { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string SourceDirectoryPath { get { throw null; } }
    }
    public partial class BlobUploadDirectoryTransferSuccessEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobUploadDirectoryTransferSuccessEventArgs(string sourcePath, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationBlobClient, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryClient { get { throw null; } }
        public string SourceDirectoryPath { get { throw null; } }
    }
    public partial class BlobUploadTransferFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobUploadTransferFailedEventArgs(string sourcePath, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string SourcePath { get { throw null; } }
    }
    public partial class BlobUploadTransferSkippedEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobUploadTransferSkippedEventArgs(string sourcePath, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string SourcePath { get { throw null; } }
    }
    public partial class BlobUploadTransferSuccessEventArgs : Azure.SyncAsyncEventArgs
    {
        public BlobUploadTransferSuccessEventArgs(string sourcePath, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
        public string SourcePath { get { throw null; } }
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
