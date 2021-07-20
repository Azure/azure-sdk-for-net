namespace Azure.Storage.DataMovement
{
    public partial class StorageTransferManager
    {
        public StorageTransferManager(string transferStateDirectoryPath = null) { }
        public static void CancelTransfers() { }
        public static void PauseTransfers() { }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleDownloadAsync(Azure.Storage.Blobs.BlobClient sourceClient, string destinationLocalPath, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleDownloadDirectoryAsync(Azure.Storage.Blobs.Specialized.BlobDirectoryClient sourceClient, string destinationLocalPath, Azure.Storage.Blobs.Models.BlobDirectoryDownloadOptions options = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleUploadAsync(string sourceLocalPath, Azure.Storage.Blobs.BlobClient destinationClient, Azure.Storage.Blobs.Models.BlobUploadOptions uploadOptions = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageTransferResults> ScheduleUploadDirectoryAsync(string sourceLocalPath, Azure.Storage.Blobs.Specialized.BlobDirectoryClient destinationClient, Azure.Storage.Blobs.Models.BlobDirectoryUploadOptions uploadOptions = null, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageTransferResults
    {
        public StorageTransferResults() { }
    }
}
namespace Azure.Storage.DataMovement.Models
{
    public partial class BlobSyncCopyOptions
    {
        public BlobSyncCopyOptions() { }
        public Azure.Storage.Blobs.Models.BlobUploadOptions BlobUploadOptions { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions DownloadTransferOptions { get { throw null; } set { } }
        public long? MaximumBufferSize { get { throw null; } set { } }
    }
    public enum ServiceCopyMethod
    {
        ServiceSideAsyncCopy = 0,
        ServiceSideSyncCopy = 1,
    }
}
