namespace Azure.Storage.DataMovement
{
    public abstract partial class StorageTransferManager
    {
        protected internal StorageTransferManager() { }
        public StorageTransferManager(Azure.Storage.DataMovement.Models.StorageTransferManagerOptions options) { }
        public abstract System.Threading.Tasks.Task CancelTransfersAsync();
        public abstract System.Threading.Tasks.Task CleanAsync();
        public abstract System.Threading.Tasks.Task PauseJobAsync(string jobId);
        public abstract System.Threading.Tasks.Task PauseTransfersAsync();
        public abstract System.Threading.Tasks.Task ResumeJobAsync(string jobId);
    }
    public partial class StorageTransferProgress
    {
        public StorageTransferProgress() { }
        public int FilesFailedTransferred { get { throw null; } }
        public int FilesSkippedTransfering { get { throw null; } }
        public int FilesSuccesfullyTransferred { get { throw null; } }
    }
}
namespace Azure.Storage.DataMovement.Models
{
    public enum DataMovementLogLevel
    {
        None = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Panic = 5,
        Fatal = 6,
    }
    public enum ServiceCopyMethod
    {
        ServiceSideAsyncCopy = 0,
        ServiceSideSyncCopy = 1,
    }
    public enum StorageJobTransferStatus
    {
        Queued = 0,
        InProgress = 1,
        Completed = 2,
        CompletedWithErrors = 3,
        CompletedWithFailures = 4,
        CompletedWithErrorsAndSkipped = 5,
    }
    public partial class StorageTransferJobDetails
    {
        protected internal StorageTransferJobDetails() { }
        protected internal StorageTransferJobDetails(string jobId, Azure.Storage.DataMovement.Models.StorageJobTransferStatus status, System.DateTimeOffset? jobStartTime) { }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset? JobStartTime { get { throw null; } }
        public Azure.Storage.DataMovement.Models.StorageJobTransferStatus Status { get { throw null; } }
    }
    public partial class StorageTransferManagerOptions
    {
        public StorageTransferManagerOptions() { }
        public int ConcurrencyForLocalFilesystemListing { get { throw null; } set { } }
        public int ConcurrencyForServiceListing { get { throw null; } set { } }
        public bool ContinueOnLocalFilesystemFailure { get { throw null; } set { } }
        public bool ContinueOnStorageFailure { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.StorageTransferProgress> ProgressHandler { get { throw null; } set { } }
        public string TransferLoggerDirectoryPath { get { throw null; } set { } }
        public string TransferStateDirectoryPath { get { throw null; } set { } }
    }
}
