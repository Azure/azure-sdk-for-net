namespace Azure.Storage.DataMovement.Blobs
{
    public partial class BlobTransferManager : Azure.Storage.DataMovement.StorageTransferManager
    {
        protected internal BlobTransferManager() { }
        public BlobTransferManager(Azure.Storage.DataMovement.StorageTransferManagerOptions options) { }
        public BlobTransferManager(string transferStateDirectoryPath, Azure.Storage.DataMovement.StorageTransferManagerOptions options) { }
        public override System.Threading.Tasks.Task CancelAllTransferJobsAsync() { throw null; }
        public override System.Threading.Tasks.Task CleanAsync() { throw null; }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties GetJobProperties(string jobId) { throw null; }
        public override System.Threading.Tasks.Task PauseAllTransferJobsAsync() { throw null; }
        public override System.Threading.Tasks.Task PauseTransferJobAsync(string jobId) { throw null; }
        public override System.Threading.Tasks.Task ResumeTransferJobAsync(string jobId, Azure.Storage.DataMovement.ResumeTransferCredentials transferCredentials) { throw null; }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties ScheduleCopy(System.Uri sourceUri, Azure.Storage.Blobs.BlobClient destinationClient, Azure.Storage.DataMovement.Blobs.Models.BlobCopyMethod copyMethod, Azure.Storage.Blobs.Models.BlobCopyFromUriOptions copyOptions = null) { throw null; }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties ScheduleCopyDirectory(Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceClient, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationClient, Azure.Storage.DataMovement.Blobs.Models.BlobCopyMethod copyMethod, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryCopyFromUriOptions copyOptions = null) { throw null; }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties ScheduleDownload(Azure.Storage.Blobs.BlobClient sourceClient, string destinationLocalPath, Azure.Storage.Blobs.Models.BlobDownloadToOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties ScheduleDownloadDirectory(Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceClient, string destinationLocalPath, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryDownloadOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties ScheduleUpload(string sourceLocalPath, Azure.Storage.Blobs.BlobClient destinationClient, Azure.Storage.Blobs.Models.BlobUploadOptions uploadOptions = null) { throw null; }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferJobProperties ScheduleUploadDirectory(string sourceLocalPath, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationClient, bool overwrite = false, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryUploadOptions options = null) { throw null; }
    }
    public partial class BlobVirtualDirectoryClient
    {
        protected BlobVirtualDirectoryClient() { }
        public BlobVirtualDirectoryClient(Azure.Storage.Blobs.BlobContainerClient client, string directoryPath) { }
        public BlobVirtualDirectoryClient(Azure.Storage.Blobs.BlobServiceClient client, string containerName, string directoryPath) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string BlobContainerName { get { throw null; } }
        public virtual string DirectoryPath { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual System.Collections.Generic.IEnumerable<Azure.Response> DownloadTo(string targetPath) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Response> DownloadTo(string targetPath, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryDownloadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Response> DownloadTo(string targetPath, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Response>> DownloadToAsync(string targetPath) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Response>> DownloadToAsync(string targetPath, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryDownloadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Response>> DownloadToAsync(string targetPath, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Storage.Blobs.BlobClient GetBlobClient(string blobName) { throw null; }
        protected internal virtual Azure.Storage.Blobs.BlobClient GetBlobClientCore(string blobName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobs(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string additionalPrefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobsAsync(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string additionalPrefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchy(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string delimiter = null, string additionalPrefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchyAsync(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string delimiter = null, string additionalPrefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.Specialized.BlockBlobClient GetBlockBlobClient(string blobName) { throw null; }
        protected internal virtual Azure.Storage.Blobs.Specialized.BlockBlobClient GetBlockBlobClientCore(string blobName) { throw null; }
        protected static Azure.Storage.Blobs.BlobClientOptions GetClientOptions(Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient client) { throw null; }
        protected static Azure.Core.Pipeline.HttpPipeline GetHttpPipeline(Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient client) { throw null; }
        public virtual Azure.Storage.Blobs.BlobContainerClient GetParentBlobContainerClient() { throw null; }
        protected internal virtual Azure.Storage.Blobs.BlobContainerClient GetParentBlobContainerClientCore() { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Storage.DataMovement.Blobs.Models.SingleBlobContentInfo> Upload(string sourceDirectoryPath, bool overwrite = false, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryUploadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Storage.DataMovement.Blobs.Models.SingleBlobContentInfo>> UploadAsync(string sourceDirectoryPath, bool overwrite = false, Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryUploadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobCopySingleTransferFailedEventArgs> BlobFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobCopySingleTransferSuccessEventArgs> BlobTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobCopyDirectoryTransferFailedEventArgs> DirectoriesFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobCopyDirectoryTransferSuccessEventArgs> DirectoriesTransferred { add { } remove { } }
    }
    public partial class BlobCopyDirectoryProgress
    {
        public BlobCopyDirectoryProgress() { }
        public int BlobsFailedTransferred { get { throw null; } }
        public int BlobsSuccesfullyTransferred { get { throw null; } }
        public int DirectoriesFailedTranferred { get { throw null; } }
        public int DirectoriesSuccessfullyTranferred { get { throw null; } }
        public Azure.Storage.DataMovement.StorageJobTransferStatus TransferStatus { get { throw null; } }
    }
    public partial class BlobCopyDirectoryTransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobCopyDirectoryTransferFailedEventArgs(string jobId, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceDirectoryUri, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationDirectoryClient, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryClient { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient SourceDirectoryClient { get { throw null; } }
    }
    public partial class BlobCopyDirectoryTransferSuccessEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobCopyDirectoryTransferSuccessEventArgs(string jobId, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceDirectoryClient, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationDirectoryClient, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryClient { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient SourceDirectoryClient { get { throw null; } }
    }
    public enum BlobCopyMethod
    {
        ServiceSideAsyncCopy = 0,
        ServiceSideSyncCopy = 1,
        RoundTripCopy = 2,
        ServiceSideSyncUploadFromUriCopy = 3,
    }
    public partial class BlobCopySingleTransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobCopySingleTransferFailedEventArgs(string jobId, Azure.Storage.Blobs.Specialized.BlobBaseClient sourceClient, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationClient, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient SourceBlobClient { get { throw null; } }
    }
    public partial class BlobCopySingleTransferSuccessEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobCopySingleTransferSuccessEventArgs(string jobId, Azure.Storage.Blobs.Specialized.BlobBaseClient sourceClient, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationClient, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient SourceBlobClient { get { throw null; } }
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
        public Azure.Storage.DataMovement.Blobs.Models.DownloadOverwriteMethod OverwriteOptions { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadDirectoryProgress> ProgressHandler { get { throw null; } set { } }
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
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadTransferFailedEventArgs> BlobsFailedTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadTransferSuccessEventArgs> BlobTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadDirectoryTransferFailedEventArgs> DirectoriesFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Blobs.Models.BlobDownloadDirectoryTransferSuccessEventArgs> DirectoriesTransferred { add { } remove { } }
    }
    public partial class BlobDownloadDirectoryProgress
    {
        public BlobDownloadDirectoryProgress() { }
        public long BlobsFailedTransferred { get { throw null; } }
        public long BlobsSkippedTransferred { get { throw null; } }
        public long BlobsSuccesfullyTransferred { get { throw null; } }
        public long TotalBytesTransferred { get { throw null; } }
        public Azure.Storage.DataMovement.StorageJobTransferStatus TransferStatus { get { throw null; } }
    }
    public partial class BlobDownloadDirectoryTransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobDownloadDirectoryTransferFailedEventArgs(string jobId, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceBlobDirectoryClient, string destinationPath, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public string DestinationDirectoryPath { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient SourceDirectoryClient { get { throw null; } }
    }
    public partial class BlobDownloadDirectoryTransferSuccessEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobDownloadDirectoryTransferSuccessEventArgs(string jobId, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient sourceBlobDirectoryClient, string destinationPath, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public string DestinationDirectoryPath { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient SourceDirectoryClient { get { throw null; } }
    }
    public partial class BlobDownloadTransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobDownloadTransferFailedEventArgs(string jobId, Azure.Storage.Blobs.Specialized.BlobBaseClient sourceBlobClient, string destinationLocalPath, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public string DestinationLocalPath { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient SourceBlobClient { get { throw null; } }
    }
    public partial class BlobDownloadTransferSuccessEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobDownloadTransferSuccessEventArgs(string jobId, Azure.Storage.Blobs.Specialized.BlobBaseClient sourceBlobClient, string destinationLocalPath, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public string DestinationLocalPath { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient SourceBlobClient { get { throw null; } }
    }
    public partial class BlobTransferJobProperties
    {
        internal BlobTransferJobProperties() { }
        public System.Uri DestinationUri { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobTransferType TransferType { get { throw null; } }
    }
    public enum BlobTransferType
    {
        SingleUpload = 0,
        SingleDownload = 1,
        DirectoryUpload = 2,
        DirectoryDownload = 3,
        SingleSyncCopy = 4,
        DirectorySyncCopy = 5,
        SingleAsyncCopy = 6,
        DirectoryAsyncCopy = 7,
        SingleRoundTripCopy = 8,
        DirectoryRoundTripCopy = 9,
        SingleSyncUploadUriCopy = 10,
        DirectorySyncUploadUriCopy = 11,
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
        public int BlobsSkippedTransferring { get { throw null; } }
        public int BlobsSuccesfullyTransferred { get { throw null; } }
        public long TotalBytesTransferred { get { throw null; } }
        public Azure.Storage.DataMovement.StorageJobTransferStatus TransferStatus { get { throw null; } }
    }
    public partial class BlobUploadDirectoryTransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobUploadDirectoryTransferFailedEventArgs(string jobId, string sourcePath, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationBlobClient, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryClient { get { throw null; } }
        public string SourceDirectoryPath { get { throw null; } }
    }
    public partial class BlobUploadDirectoryTransferSuccessEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobUploadDirectoryTransferSuccessEventArgs(string jobId, string sourcePath, Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient destinationBlobClient, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryClient { get { throw null; } }
        public string SourceDirectoryPath { get { throw null; } }
    }
    public partial class BlobUploadTransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobUploadTransferFailedEventArgs(string jobId, string sourcePath, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string SourcePath { get { throw null; } }
    }
    public partial class BlobUploadTransferSkippedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobUploadTransferSkippedEventArgs(string jobId, string sourcePath, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string SourcePath { get { throw null; } }
    }
    public partial class BlobUploadTransferSuccessEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public BlobUploadTransferSuccessEventArgs(string jobId, string sourcePath, Azure.Storage.Blobs.Specialized.BlobBaseClient destinationBlobClient, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
        public string SourcePath { get { throw null; } }
    }
    public enum DownloadOverwriteMethod
    {
        Overwrite = 0,
        Fail = 1,
        Skip = 2,
    }
    public partial class SingleBlobContentInfo
    {
        internal SingleBlobContentInfo() { }
        public System.Uri BlobUri { get { throw null; } }
        public Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> ContentInfo { get { throw null; } }
    }
}
