namespace Azure.Storage.DataMovement
{
    public partial class StorageTransferManager
    {
        public StorageTransferManager(string progressLogDirectoryPath = null) { }
        public static void CancelTransfer() { }
        public static void PauseTransfer() { }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleDownloadJobAsync(Azure.Storage.Blobs.BlobClient sourceClient, string destinationLocalPath, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.IProgress<Azure.Storage.StorageTransferStatus> progressTracker = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleUploadDirectoryJobAsync(string sourceLocalPath, Azure.Storage.Blobs.Specialized.BlobDirectoryClient destinationClient, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), Azure.Storage.Blobs.Models.BlobUploadOptions uploadOptions = null, System.IProgress<Azure.Storage.StorageTransferStatus> progressTracker = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleUploadJobAsync(string sourceLocalPath, Azure.Storage.Blobs.BlobClient destinationClient, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), Azure.Storage.Blobs.Models.BlobUploadOptions uploadOptions = null, System.IProgress<Azure.Storage.StorageTransferStatus> progressTracker = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageTransferResults
    {
        public StorageTransferResults() { }
    }
}
namespace Azure.Storage.DataMovement.Models
{
    public enum CopyMethod
    {
        SyncCopy = 0,
        ServiceSideAyncCopy = 1,
        ServiceSideSyncCopy = 2,
    }
}
