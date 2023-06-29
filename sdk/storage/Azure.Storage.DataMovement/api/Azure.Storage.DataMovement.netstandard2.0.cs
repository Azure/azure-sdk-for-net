namespace Azure.Storage.DataMovement
{
    public partial class DataTransfer
    {
        internal DataTransfer() { }
        public bool HasCompleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Storage.DataMovement.StorageTransferStatus TransferStatus { get { throw null; } }
        public System.Threading.Tasks.Task AwaitCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public void EnsureCompleted(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task PauseIfRunningAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.FlagsAttribute]
    public enum ErrorHandlingOptions
    {
        StopOnAllFailures = 0,
        ContinueOnFailure = 1,
    }
    public partial class LocalDirectoryStorageResourceContainer : Azure.Storage.DataMovement.StorageResourceContainer
    {
        public LocalDirectoryStorageResourceContainer(string path) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override string Path { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override Azure.Storage.DataMovement.StorageResourceSingle GetChildStorageResource(string childPath) { throw null; }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> GetStorageResourcesAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalFileStorageResource : Azure.Storage.DataMovement.StorageResourceSingle
    {
        public LocalFileStorageResource(string path) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override long? Length { get { throw null; } }
        public override long MaxChunkSize { get { throw null; } }
        public override string Path { get { throw null; } }
        public override string ResourceId { get { throw null; } }
        public override Azure.Storage.DataMovement.TransferType TransferType { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override System.Threading.Tasks.Task CompleteTransferAsync(bool overwrite, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyBlockFromUriAsync(Azure.Storage.DataMovement.StorageResourceSingle sourceResource, Azure.HttpRange range, bool overwrite, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyFromUriAsync(Azure.Storage.DataMovement.StorageResourceSingle sourceResource, bool overwrite, long completeLength, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<bool> DeleteIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceResult> ReadStreamAsync(long position = (long)0, long? length = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, long streamLength, bool overwrite, long position = (long)0, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalStorageResourceProvider
    {
        internal LocalStorageResourceProvider() { }
        public Azure.Storage.DataMovement.StorageResource MakeResource() { throw null; }
    }
    public static partial class LocalStorageResources
    {
        public static bool TryGetResourceProviders(Azure.Storage.DataMovement.Models.DataTransferProperties info, out Azure.Storage.DataMovement.LocalStorageResourceProvider sourceProvider, out Azure.Storage.DataMovement.LocalStorageResourceProvider destinationProvider) { throw null; }
    }
    [System.FlagsAttribute]
    public enum ProduceUriType
    {
        NoUri = 0,
        ProducesUri = 1,
    }
    public abstract partial class StorageResource
    {
        protected StorageResource() { }
        public abstract Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get; }
        public abstract bool IsContainer { get; }
        public abstract string Path { get; }
        public abstract System.Uri Uri { get; }
    }
    public abstract partial class StorageResourceContainer : Azure.Storage.DataMovement.StorageResource
    {
        protected StorageResourceContainer() { }
        public override bool IsContainer { get { throw null; } }
        public abstract Azure.Storage.DataMovement.StorageResourceSingle GetChildStorageResource(string path);
        public abstract System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> GetStorageResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public enum StorageResourceCreateMode
    {
        None = 0,
        Overwrite = 1,
        Fail = 2,
        Skip = 3,
    }
    public abstract partial class StorageResourceSingle : Azure.Storage.DataMovement.StorageResource
    {
        protected StorageResourceSingle() { }
        public override bool IsContainer { get { throw null; } }
        public abstract long? Length { get; }
        public abstract long MaxChunkSize { get; }
        public abstract string ResourceId { get; }
        public abstract Azure.Storage.DataMovement.TransferType TransferType { get; }
        public abstract System.Threading.Tasks.Task CompleteTransferAsync(bool overwrite, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task CopyBlockFromUriAsync(Azure.Storage.DataMovement.StorageResourceSingle sourceResource, Azure.HttpRange range, bool overwrite, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task CopyFromUriAsync(Azure.Storage.DataMovement.StorageResourceSingle sourceResource, bool overwrite, long completeLength, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<bool> DeleteIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken token = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceResult> ReadStreamAsync(long position = (long)0, long? length = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, long streamLength, bool overwrite, long position = (long)0, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public enum StorageResourceType
    {
        LocalFile = 0,
        BlockBlob = 1,
        PageBlob = 2,
        AppendBlob = 3,
    }
    public abstract partial class StorageTransferEventArgs : Azure.SyncAsyncEventArgs
    {
        protected StorageTransferEventArgs(string transferId, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string TransferId { get { throw null; } }
    }
    public partial class StorageTransferProgress
    {
        public StorageTransferProgress() { }
        public long? BytesTransferred { get { throw null; } }
        public long CompletedCount { get { throw null; } }
        public long FailedCount { get { throw null; } }
        public long InProgressCount { get { throw null; } }
        public long QueuedCount { get { throw null; } }
        public long SkippedCount { get { throw null; } }
    }
    public enum StorageTransferStatus
    {
        None = 0,
        Queued = 1,
        InProgress = 2,
        Paused = 3,
        Completed = 4,
        CompletedWithSkippedTransfers = 5,
        CompletedWithFailedTransfers = 6,
        PauseInProgress = 7,
        CancellationInProgress = 8,
    }
    public partial class TransferManager : System.IAsyncDisposable
    {
        protected TransferManager() { }
        public TransferManager(Azure.Storage.DataMovement.TransferManagerOptions options = null) { }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.DataTransfer> GetTransfersAsync(params Azure.Storage.DataMovement.StorageTransferStatus[] filterByStatus) { throw null; }
        public virtual System.Threading.Tasks.Task PauseTransferIfRunningAsync(Azure.Storage.DataMovement.DataTransfer transfer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task PauseTransferIfRunningAsync(string transferId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> StartTransferAsync(Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, Azure.Storage.DataMovement.Models.TransferOptions transferOptions = null) { throw null; }
        System.Threading.Tasks.ValueTask System.IAsyncDisposable.DisposeAsync() { throw null; }
    }
    public partial class TransferManagerOptions
    {
        public TransferManagerOptions() { }
        public Azure.Storage.DataMovement.Models.TransferCheckpointerOptions CheckpointerOptions { get { throw null; } set { } }
        public Azure.Storage.DataMovement.ErrorHandlingOptions ErrorHandling { get { throw null; } set { } }
        public int? MaximumConcurrency { get { throw null; } set { } }
    }
    public enum TransferType
    {
        Concurrent = 0,
        Sequential = 1,
    }
}
namespace Azure.Storage.DataMovement.Models
{
    public partial class DataTransferProperties
    {
        protected DataTransferProperties() { }
        public virtual Azure.Storage.DataMovement.Models.TransferCheckpointerOptions Checkpointer { get { throw null; } }
        public virtual string DestinationPath { get { throw null; } }
        public virtual string DestinationScheme { get { throw null; } }
        public virtual bool IsContainer { get { throw null; } }
        public virtual string SourcePath { get { throw null; } }
        public virtual string SourceScheme { get { throw null; } }
        public virtual string TransferId { get { throw null; } }
    }
    public partial class ProgressHandlerOptions
    {
        public ProgressHandlerOptions() { }
        public bool TrackBytesTransferred { get { throw null; } set { } }
    }
    public partial class ReadStreamStorageResourceResult
    {
        public ReadStreamStorageResourceResult(System.IO.Stream content) { }
        public ReadStreamStorageResourceResult(System.IO.Stream content, string contentRange, string acceptRanges, byte[] rangeContentHash, Azure.Storage.DataMovement.Models.StorageResourceProperties properties) { }
    }
    public enum ServiceCopyStatus
    {
        Pending = 0,
        Success = 1,
        Aborted = 2,
        Failed = 3,
    }
    public partial class SingleTransferCompletedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public SingleTransferCompletedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResourceSingle sourceResource, Azure.Storage.DataMovement.StorageResourceSingle destinationResource, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResourceSingle DestinationResource { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResourceSingle SourceResource { get { throw null; } }
    }
    public partial class StorageResourceCopyFromUriOptions
    {
        public StorageResourceCopyFromUriOptions() { }
        public string BlockId { get { throw null; } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
    }
    public partial class StorageResourceProperties
    {
        protected StorageResourceProperties() { }
        public StorageResourceProperties(System.DateTimeOffset lastModified, System.DateTimeOffset createdOn, System.Collections.Generic.IDictionary<string, string> metadata, System.DateTimeOffset copyCompletedOn, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.DataMovement.Models.ServiceCopyStatus? copyStatus, long contentLength, string contentType, Azure.ETag eTag, byte[] contentHash, long blobSequenceNumber, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256, string encryptionScope, string versionId, bool isLatestVersion, System.DateTimeOffset expiresOn, System.DateTimeOffset lastAccessed, Azure.Storage.DataMovement.StorageResourceType resourceType) { }
        public StorageResourceProperties(System.DateTimeOffset lastModified, System.DateTimeOffset createdOn, long contentLength, System.DateTimeOffset lastAccessed, Azure.Storage.DataMovement.StorageResourceType resourceType) { }
        public Azure.Storage.DataMovement.StorageResourceType ResourceType { get { throw null; } }
    }
    public partial class StorageResourceWriteToOffsetOptions
    {
        public StorageResourceWriteToOffsetOptions() { }
        public string BlockId { get { throw null; } }
    }
    public partial class TransferCheckpointerOptions
    {
        public TransferCheckpointerOptions(string localCheckpointerPath) { }
        public string CheckpointerPath { get { throw null; } }
    }
    public enum TransferCopyMethod
    {
        None = 0,
        SyncCopy = 1,
        AsyncCopy = 2,
    }
    public partial class TransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public TransferFailedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResourceSingle sourceResource, Azure.Storage.DataMovement.StorageResourceSingle destinationResource, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResourceSingle DestinationResource { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResourceSingle SourceResource { get { throw null; } }
    }
    public partial class TransferOptions : System.IEquatable<Azure.Storage.DataMovement.Models.TransferOptions>
    {
        public TransferOptions() { }
        public Azure.Storage.DataMovement.StorageResourceCreateMode CreateMode { get { throw null; } set { } }
        public long? InitialTransferSize { get { throw null; } set { } }
        public long? MaximumTransferChunkSize { get { throw null; } set { } }
        public System.IProgress<Azure.Storage.DataMovement.StorageTransferProgress> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Models.ProgressHandlerOptions ProgressHandlerOptions { get { throw null; } set { } }
        public string ResumeFromCheckpointId { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.SingleTransferCompletedEventArgs> SingleTransferCompleted { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferFailedEventArgs> TransferFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferSkippedEventArgs> TransferSkipped { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferStatusEventArgs> TransferStatus { add { } remove { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Storage.DataMovement.Models.TransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Storage.DataMovement.Models.TransferOptions left, Azure.Storage.DataMovement.Models.TransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Storage.DataMovement.Models.TransferOptions left, Azure.Storage.DataMovement.Models.TransferOptions right) { throw null; }
    }
    public partial class TransferSkippedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public TransferSkippedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResourceSingle sourceResource, Azure.Storage.DataMovement.StorageResourceSingle destinationResource, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResourceSingle DestinationResource { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResourceSingle SourceResource { get { throw null; } }
    }
    public partial class TransferStatusEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public TransferStatusEventArgs(string transferId, Azure.Storage.DataMovement.StorageTransferStatus transferStatus, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageTransferStatus StorageTransferStatus { get { throw null; } }
    }
}
