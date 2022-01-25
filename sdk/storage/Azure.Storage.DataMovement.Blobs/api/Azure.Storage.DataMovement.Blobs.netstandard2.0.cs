namespace Azure.Storage.DataMovement.Blobs
{
    public partial class BlobTransferManager : Azure.Storage.DataMovement.StorageTransferManager
    {
        protected internal BlobTransferManager() { }
        public BlobTransferManager(Azure.Storage.DataMovement.Models.StorageTransferManagerOptions options) { }
        public override Azure.Storage.DataMovement.Models.StorageTransferJobDetails GetJob(string jobId) { throw null; }
        public static System.Collections.Generic.IList<Azure.Storage.DataMovement.Blobs.Models.BlobTransferCopyDirectoryJobDetails> ListCopyDirectoryJobs() { throw null; }
        public static System.Collections.Generic.IList<Azure.Storage.DataMovement.Blobs.Models.BlobTransferDownloadDirectoryJobDetails> ListDownloadDirectoryJobs() { throw null; }
        public static System.Collections.Generic.IList<Azure.Storage.DataMovement.Blobs.Models.BlobTransferCopyJobDetails> ListSingleCopyJobs() { throw null; }
        public static System.Collections.Generic.IList<Azure.Storage.DataMovement.Blobs.Models.BlobTransferDownloadJobDetails> ListSingleDownloadJobs() { throw null; }
        public static System.Collections.Generic.IList<Azure.Storage.DataMovement.Blobs.Models.BlobTransferUploadJobDetails> ListSingleUploadJobs() { throw null; }
        public static System.Collections.Generic.IList<Azure.Storage.DataMovement.Blobs.Models.BlobTransferUploadDirectoryJobDetails> ListUploadDirectoryJobs() { throw null; }
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
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy DestinationImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } set { } }
        public bool? ShouldSealDestination { get { throw null; } set { } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryRequestConditions SourceConditions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class BlobDirectoryDownloadOptions
    {
        public BlobDirectoryDownloadOptions() { }
        public bool ContentsOnly { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryRequestConditions DirectoryRequestConditions { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.TransferProgressHandler> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions TransferOptions { get { throw null; } set { } }
    }
    public partial class BlobDirectoryHttpHeaders
    {
        public BlobDirectoryHttpHeaders() { }
        public string CacheControl { get { throw null; } set { } }
        public string ContentDisposition { get { throw null; } set { } }
        public string ContentEncoding { get { throw null; } set { } }
        public string ContentLanguage { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class BlobDirectoryRequestConditions
    {
        public BlobDirectoryRequestConditions() { }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
    }
    public partial class BlobDirectoryUploadOptions
    {
        public BlobDirectoryUploadOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public bool ContentsOnly { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryHttpHeaders HttpHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.TransferProgressHandler> ProgressHandler { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions TransferOptions { get { throw null; } set { } }
    }
    public enum BlobServiceCopyMethod
    {
        ServiceSideAsyncCopy = 0,
        ServiceSideSyncCopy = 1,
    }
    public partial class BlobTransferCopyDirectoryJobDetails : Azure.Storage.DataMovement.Models.StorageTransferJobDetails
    {
        internal BlobTransferCopyDirectoryJobDetails() { }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryCopyFromUriOptions CopyFromUriOptions { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobServiceCopyMethod CopyMethod { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationDirectoryClient { get { throw null; } }
        public System.Uri SourceDirectoryUri { get { throw null; } }
    }
    public partial class BlobTransferCopyJobDetails : Azure.Storage.DataMovement.Models.StorageTransferJobDetails
    {
        internal BlobTransferCopyJobDetails() { }
        public Azure.Storage.Blobs.Models.BlobCopyFromUriOptions CopyFromUriOptions { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobServiceCopyMethod CopyMethod { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
    }
    public partial class BlobTransferDownloadDirectoryJobDetails : Azure.Storage.DataMovement.Models.StorageTransferJobDetails
    {
        internal BlobTransferDownloadDirectoryJobDetails() { }
        public string DestinationLocalPath { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryDownloadOptions Options { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient SourceBlobClient { get { throw null; } }
    }
    public partial class BlobTransferDownloadJobDetails : Azure.Storage.DataMovement.Models.StorageTransferJobDetails
    {
        internal BlobTransferDownloadJobDetails() { }
        public string DestinationLocalPath { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobDownloadToOptions Options { get { throw null; } }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient SourceBlobClient { get { throw null; } }
    }
    public partial class BlobTransferUploadDirectoryJobDetails : Azure.Storage.DataMovement.Models.StorageTransferJobDetails
    {
        internal BlobTransferUploadDirectoryJobDetails() { }
        public Azure.Storage.DataMovement.Blobs.BlobVirtualDirectoryClient DestinationBlobClient { get { throw null; } }
        public string SourceLocalPath { get { throw null; } }
        public Azure.Storage.DataMovement.Blobs.Models.BlobDirectoryUploadOptions UploadOptions { get { throw null; } }
    }
    public partial class BlobTransferUploadJobDetails : Azure.Storage.DataMovement.Models.StorageTransferJobDetails
    {
        internal BlobTransferUploadJobDetails() { }
        public Azure.Storage.Blobs.Specialized.BlobBaseClient DestinationBlobClient { get { throw null; } }
        public string SourceLocalPath { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobUploadOptions UploadOptions { get { throw null; } }
    }
}
