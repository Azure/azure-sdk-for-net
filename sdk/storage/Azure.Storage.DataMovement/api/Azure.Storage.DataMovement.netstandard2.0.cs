namespace Azure.Storage.DataMovement
{
    public partial class DataMovementFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public DataMovementFailedEventArgs(Azure.Storage.DataMovement.StorageTransferJob job, Azure.RequestFailedException exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.RequestFailedException Exception { get { throw null; } }
        public Azure.Storage.DataMovement.StorageTransferJob Job { get { throw null; } }
        public Azure.RequestFailedException ReceivedMessage { get { throw null; } }
    }
    public partial class PathTransferFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public PathTransferFailedEventArgs(Azure.Storage.DataMovement.StorageTransferJob job, Azure.Storage.DataMovement.Models.TransferJobRequestFailedException exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.Models.TransferJobRequestFailedException Exception { get { throw null; } }
        public Azure.Storage.DataMovement.StorageTransferJob Job { get { throw null; } }
    }
    public partial class PathTransferSkippedEventArgs : Azure.SyncAsyncEventArgs
    {
        public PathTransferSkippedEventArgs(Azure.Storage.DataMovement.StorageTransferJob job, System.IO.IOException exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public System.IO.IOException Exception { get { throw null; } }
        public Azure.Storage.DataMovement.StorageTransferJob Job { get { throw null; } }
    }
    public partial class PathTransferSuccessEventArgs : Azure.SyncAsyncEventArgs
    {
        public PathTransferSuccessEventArgs(Azure.Storage.DataMovement.StorageTransferJob job, Azure.Response response, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageTransferJob Job { get { throw null; } }
        public Azure.Response Response { get { throw null; } }
    }
    public partial class StorageTransferJob
    {
        public StorageTransferJob(string jobId, string loggerFolderPath = null) { }
        public System.Threading.CancellationTokenSource CancellationTokenSource { get { throw null; } set { } }
        public string JobId { get { throw null; } set { } }
        public virtual Azure.Storage.DataMovement.Models.StorageJobTransferStatus GetTransferStatus() { throw null; }
    }
    public partial class StorageTransferManager
    {
        public StorageTransferManager(Azure.Storage.DataMovement.Models.StorageTransferManagerOptions options = null) { }
        protected internal System.Collections.Generic.List<Azure.Storage.DataMovement.StorageTransferJob> TotalJobs { get { throw null; } }
        public virtual void CancelTransfers() { }
        public virtual void Clean() { }
        public virtual Azure.Storage.DataMovement.StorageTransferJob GetJob(string jobId) { throw null; }
        public virtual System.Collections.Generic.IList<string> ListJobs() { throw null; }
        public virtual void PauseTransfers() { }
    }
    public partial class StorageTransferResults
    {
        public StorageTransferResults() { }
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
        CompletedSuccessful = 2,
        Failed = 3,
    }
    public partial class StorageTransferManagerOptions
    {
        public StorageTransferManagerOptions() { }
        public int ConcurrencyForLocalFilesystemListing { get { throw null; } set { } }
        public int ConcurrencyForServiceListing { get { throw null; } set { } }
        public bool ContinueOnLocalFilesystemFailure { get { throw null; } set { } }
        public bool ContinueOnStorageFailure { get { throw null; } set { } }
        public string TransferLoggerDirectoryPath { get { throw null; } set { } }
        public Azure.Storage.DataMovement.StorageTransferResults TransferResults { get { throw null; } set { } }
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
