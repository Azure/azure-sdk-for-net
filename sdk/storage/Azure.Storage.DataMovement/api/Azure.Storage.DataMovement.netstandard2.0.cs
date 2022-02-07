namespace Azure.Storage.DataMovement
{
    public partial class DataMovementFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public DataMovementFailedEventArgs(Azure.Storage.DataMovement.Models.StorageTransferJobDetails job, Azure.RequestFailedException exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.RequestFailedException Exception { get { throw null; } }
        public Azure.Storage.DataMovement.Models.StorageTransferJobDetails Job { get { throw null; } }
        public Azure.RequestFailedException ReceivedMessage { get { throw null; } }
    }
    public partial class PathTransferFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public PathTransferFailedEventArgs(Azure.Storage.DataMovement.Models.StorageTransferJobDetails job, Azure.Storage.DataMovement.Models.TransferJobRequestFailedException exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Models.TransferJobRequestFailedException Exception { get { throw null; } }
        public Azure.Storage.DataMovement.Models.StorageTransferJobDetails JobDetails { get { throw null; } }
    }
    public partial class PathTransferSkippedEventArgs : Azure.SyncAsyncEventArgs
    {
        public PathTransferSkippedEventArgs(Azure.Storage.DataMovement.Models.StorageTransferJobDetails job, System.IO.IOException exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public System.IO.IOException Exception { get { throw null; } }
        public Azure.Storage.DataMovement.Models.StorageTransferJobDetails Job { get { throw null; } }
    }
    public partial class PathTransferSuccessEventArgs : Azure.SyncAsyncEventArgs
    {
        public PathTransferSuccessEventArgs(Azure.Storage.DataMovement.Models.StorageTransferJobDetails job, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Models.StorageTransferJobDetails Job { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
    }
    public abstract partial class StorageTransferManager
    {
        protected internal StorageTransferManager() { }
        public StorageTransferManager(Azure.Storage.DataMovement.Models.StorageTransferManagerOptions options) { }
        public abstract void CancelTransfers();
        public abstract void Clean();
        public abstract System.Threading.Tasks.Task PauseJob(string jobId);
        public abstract void PauseTransfers();
        public abstract System.Threading.Tasks.Task ResumeJob(string jobId);
    }
    public partial class TransferProgressHandler
    {
        public TransferProgressHandler() { }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.PathTransferSkippedEventArgs> DirectoriesSkipped { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.PathTransferSuccessEventArgs> DirectoriesTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.PathTransferFailedEventArgs> FilesFailedTransferred { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.PathTransferSuccessEventArgs> FilesTransferred { add { } remove { } }
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
        public Azure.Storage.DataMovement.TransferProgressHandler ProgressHandler { get { throw null; } set { } }
        public string TransferLoggerDirectoryPath { get { throw null; } set { } }
        public string TransferStateDirectoryPath { get { throw null; } set { } }
    }
    public partial class TransferJobRequestFailedException : System.Exception, System.Runtime.Serialization.ISerializable
    {
        public TransferJobRequestFailedException(int status, string message) { }
        public TransferJobRequestFailedException(int status, string message, System.Exception innerException) { }
        public TransferJobRequestFailedException(int status, string message, string errorCode, System.Exception innerException) { }
        protected TransferJobRequestFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public TransferJobRequestFailedException(string message) { }
        public TransferJobRequestFailedException(string message, System.Exception innerException) { }
        public string BlockId { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public int Status { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
}
