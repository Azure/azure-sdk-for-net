namespace Azure.Storage.DataMovement
{
    public partial class StorageTransferManager
    {
        public StorageTransferManager(string progressLogDirectoryPath = null) { }
        public static void CancelTransfers() { }
        public static void PauseTransfers() { }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleDownloadAsync(Azure.Storage.Blobs.BlobClient sourceClient, string destinationLocalPath, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.IProgress<Azure.Storage.StorageTransferStatus> progressTracker = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleDownloadDirectoryAsync(Azure.Storage.Blobs.Specialized.BlobDirectoryClient sourceClient, string destinationLocalPath, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.IProgress<Azure.Storage.StorageTransferStatus> progressTracker = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleUploadAsync(string sourceLocalPath, Azure.Storage.Blobs.BlobClient destinationClient, Azure.Storage.Blobs.Models.BlobUploadOptions uploadOptions = null, System.IProgress<Azure.Storage.StorageTransferStatus> progressTracker = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleUploadDirectoryAsync(string sourceLocalPath, Azure.Storage.Blobs.Specialized.BlobDirectoryClient destinationClient, Azure.Storage.Blobs.Models.BlobUploadDirectoryOptions uploadOptions = null, System.IProgress<Azure.Storage.StorageTransferStatus> progressTracker = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
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
        ServiceSideAsyncCopy = 1,
        ServiceSideSyncCopy = 2,
    }
}
