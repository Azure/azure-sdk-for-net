namespace Azure.Storage.DataMovement
{
    public enum StorageJobTransferStatus
    {
        Queued = 0,
        InProgress = 1,
        Completed = 2,
        CompletedWithErrors = 3,
        CompletedWithFailures = 4,
        CompletedWithErrorsAndSkipped = 5,
    }
    public partial class StorageTransferEventArgs : Azure.SyncAsyncEventArgs
    {
        public StorageTransferEventArgs(string jobId, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string JobId { get { throw null; } }
    }
    public partial class StorageTransferJobDetails
    {
        protected internal StorageTransferJobDetails() { }
        protected internal StorageTransferJobDetails(string jobId, Azure.Storage.DataMovement.StorageJobTransferStatus status, System.DateTimeOffset? jobStartTime) { }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset? JobStartTime { get { throw null; } }
        public Azure.Storage.DataMovement.StorageJobTransferStatus Status { get { throw null; } }
    }
    public abstract partial class StorageTransferManager
    {
        protected internal StorageTransferManager() { }
        protected StorageTransferManager(Azure.Storage.DataMovement.StorageTransferManagerOptions options) { }
        protected StorageTransferManager(string transferStateDirectoryPath, Azure.Storage.DataMovement.StorageTransferManagerOptions options) { }
        protected internal string TransferStateLocalDirectoryPath { get { throw null; } }
        public abstract System.Threading.Tasks.Task CancelAllTransferJobsAsync();
        public abstract System.Threading.Tasks.Task CleanAsync();
        public abstract System.Threading.Tasks.Task PauseAllTransferJobsAsync();
        public abstract System.Threading.Tasks.Task PauseTransferJobAsync(string jobId);
        public abstract System.Threading.Tasks.Task ResumeAllTransferJobsAsync();
        public abstract System.Threading.Tasks.Task ResumeTransferJobAsync(string jobId);
    }
    public partial class StorageTransferManagerOptions
    {
        public StorageTransferManagerOptions() { }
        public int ConcurrencyForLocalFilesystemListing { get { throw null; } set { } }
        public int ConcurrencyForServiceListing { get { throw null; } set { } }
        public bool ContinueOnLocalFilesystemFailure { get { throw null; } set { } }
        public bool ContinueOnStorageFailure { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.StorageTransferProgress> ProgressHandler { get { throw null; } set { } }
    }
    public partial class StorageTransferProgress
    {
        public StorageTransferProgress() { }
        public int FailedTransferred { get { throw null; } }
        public int QueuedTransfers { get { throw null; } }
        public int SkippedTransferring { get { throw null; } }
        public int SuccesfullyTransferred { get { throw null; } }
        public int TransfersInProgress { get { throw null; } }
    }
}
