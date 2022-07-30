namespace Azure.Storage.DataMovement
{
    public partial class ResumeTransferCredentials
    {
        protected ResumeTransferCredentials() { }
        public ResumeTransferCredentials(Azure.Storage.DataMovement.StorageTransferCredential sourceTransferCredential, Azure.Storage.DataMovement.StorageTransferCredential destinationTransferCredential) { }
        public Azure.Storage.DataMovement.StorageTransferCredential DestinationTransferCredential { get { throw null; } }
        public Azure.Storage.DataMovement.StorageTransferCredential SourceTransferCredential { get { throw null; } }
    }
    public enum StorageJobTransferStatus
    {
        Queued = 1,
        InProgress = 2,
        Paused = 3,
        Completed = 4,
        CompletedWithErrors = 5,
    }
    public partial class StorageTransferCredential
    {
        protected StorageTransferCredential() { }
        public StorageTransferCredential(Azure.AzureSasCredential azureSasCredential) { }
        public StorageTransferCredential(Azure.Core.TokenCredential tokenCredential) { }
        public StorageTransferCredential(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) { }
        public StorageTransferCredential(string connectionString) { }
        public string ConnectionString { get { throw null; } }
        public Azure.AzureSasCredential SasCredential { get { throw null; } }
        public Azure.Storage.StorageSharedKeyCredential SharedKeyCredential { get { throw null; } }
        public Azure.Core.TokenCredential TokenCredential { get { throw null; } }
    }
    public partial class StorageTransferEventArgs : Azure.SyncAsyncEventArgs
    {
        public StorageTransferEventArgs(string jobId, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string JobId { get { throw null; } }
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
        public abstract System.Threading.Tasks.Task ResumeTransferJobAsync(string jobId, Azure.Storage.DataMovement.ResumeTransferCredentials transferCredentials);
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
        public int FilesCurrentlyTransferring { get { throw null; } }
        public int FilesQueuedForTransfer { get { throw null; } }
        public int FilesTransferredFailed { get { throw null; } }
        public int FilesTransferredSkipped { get { throw null; } }
        public int FilesTransferredSuccessfully { get { throw null; } }
    }
}
