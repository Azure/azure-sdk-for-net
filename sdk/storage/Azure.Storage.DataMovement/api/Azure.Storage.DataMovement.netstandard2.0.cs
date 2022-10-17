namespace Azure.Storage.DataMovement
{
    public partial class BlobDataController : Azure.Storage.DataMovement.DataController
    {
        public BlobDataController(Azure.Storage.DataMovement.DataControllerOptions options) { }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> StartTransferAsync(Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, Azure.Storage.DataMovement.Models.SingleTransferOptions transferOptions = null) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> StartTransferAsync(Azure.Storage.DataMovement.StorageResourceContainer sourceResource, Azure.Storage.DataMovement.StorageResourceContainer destinationResource, Azure.Storage.DataMovement.Models.ContainerTransferOptions transferOptions = null) { throw null; }
    }
    public abstract partial class DataController
    {
        protected DataController() { }
        public System.Buffers.ArrayPool<byte> UploadArrayPool { get { throw null; } }
        public System.Threading.Tasks.Task<bool> TryPauseAllTransfersAsync() { throw null; }
        public System.Threading.Tasks.Task<bool> TryPauseTransferAsync(string id) { throw null; }
        public System.Threading.Tasks.Task<bool> TryRemoveTransferAsync(string id) { throw null; }
    }
    public partial class DataControllerOptions
    {
        public DataControllerOptions() { }
        public string CheckPointFolderPath { get { throw null; } set { } }
        public Azure.Storage.DataMovement.ErrorHandlingOptions ErrorHandling { get { throw null; } set { } }
        public int? MaximumConcurrency { get { throw null; } set { } }
    }
    public partial class DataTransfer
    {
        internal DataTransfer() { }
        public string Id { get { throw null; } }
        public bool IsCompleted { get { throw null; } }
    }
    public static partial class DataTransferExtensions
    {
        public static System.Threading.Tasks.Task AwaitCompletion(this Azure.Storage.DataMovement.DataTransfer dataTransfer, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static void EnsureCompleted(this Azure.Storage.DataMovement.DataTransfer dataTransfer) { }
    }
    [System.FlagsAttribute]
    public enum ErrorHandlingOptions
    {
        PauseOnAllFailures = -1,
        ContinueOnFailure = 1,
    }
    public enum ListStorageResourcesType
    {
        ListingUnavailable = -1,
        SingleListCall = 1,
        PageableListCall = 2,
    }
    public static partial class LocalStorageResourceFactory
    {
        public static Azure.Storage.DataMovement.StorageResourceContainer GetDirectory(string path) { throw null; }
        public static Azure.Storage.DataMovement.StorageResource GetFile(string path) { throw null; }
    }
    [System.FlagsAttribute]
    public enum ProduceUriType
    {
        NoUri = -1,
        ProducesUri = 1,
    }
    public abstract partial class StorageResource
    {
        protected StorageResource() { }
        public abstract Azure.Storage.DataMovement.Models.CanCommitListType CanCommitBlockListType();
        public abstract Azure.Storage.DataMovement.StreamConsumableType CanConsumeReadableStream();
        public abstract Azure.Storage.DataMovement.ProduceUriType CanProduceUri();
        public abstract System.Threading.Tasks.Task CommitBlockList(System.Collections.Generic.IEnumerable<string> base64BlockIds, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task ConsumePartialOffsetReadableStream(long offset, long length, System.IO.Stream stream, Azure.Storage.DataMovement.Models.ConsumePartialReadableStreamOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task ConsumeReadableStream(System.IO.Stream stream, Azure.Storage.DataMovement.Models.ConsumeReadableStreamOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task ConsumeUri(System.Uri sasUri);
        public abstract System.IO.Stream GetConsumableStream();
        public abstract System.Collections.Generic.List<string> GetPath();
        public abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken token);
        public abstract System.IO.Stream GetReadableInputStream();
        public abstract System.Uri GetUri();
    }
    public abstract partial class StorageResourceContainer
    {
        protected StorageResourceContainer() { }
        public abstract Azure.Storage.DataMovement.ListStorageResourcesType CanList();
        public abstract Azure.Storage.DataMovement.ProduceUriType CanProduceUri();
        public abstract System.Collections.Generic.List<string> GetPath();
        public abstract Azure.Storage.DataMovement.StorageResource GetStorageResource(System.Collections.Generic.List<string> path);
        public abstract Azure.Storage.DataMovement.StorageResourceContainer GetStorageResourceContainer(System.Collections.Generic.List<string> path);
        public abstract System.Uri GetUri();
        public abstract System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> ListStorageResources(Azure.Storage.DataMovement.Models.ListStorageResourceOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public enum StorageResourceCreateMode
    {
        Overwrite = 0,
        Fail = 1,
        Skip = 2,
    }
    public abstract partial class StorageTransferEventArgs : Azure.SyncAsyncEventArgs
    {
        public StorageTransferEventArgs(string transferId, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string TransferId { get { throw null; } }
    }
    public enum StorageTransferStatus
    {
        Queued = 1,
        InProgress = 2,
        Paused = 3,
        Completed = 4,
    }
    [System.FlagsAttribute]
    public enum StreamConsumableType
    {
        NotConsumable = -1,
        Consumable = 1,
    }
}
namespace Azure.Storage.DataMovement.Models
{
    public enum CanCommitListType
    {
        None = -1,
        CanCommitBlockList = 0,
    }
    public partial class ConsumePartialReadableStreamOptions
    {
        public ConsumePartialReadableStreamOptions() { }
        public string BlockId { get { throw null; } }
    }
    public partial class ConsumeReadableStreamOptions
    {
        public ConsumeReadableStreamOptions() { }
        public string LeaseId { get { throw null; } set { } }
    }
    public partial class ContainerTransferOptions : System.IEquatable<Azure.Storage.DataMovement.Models.ContainerTransferOptions>
    {
        public ContainerTransferOptions() { }
        public string CheckpointTransferId { get { throw null; } set { } }
        public long? InitialTransferSize { get { throw null; } set { } }
        public long? MaximumTransferChunkSize { get { throw null; } set { } }
        public Azure.Storage.DataMovement.StorageResourceCreateMode OverwriteOptions { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferFailedEventArgs> TransferFailedEventHandler { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.StorageTransferStatusEventArgs> TransferStatusEventHandler { add { } remove { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Storage.DataMovement.Models.ContainerTransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Storage.DataMovement.Models.ContainerTransferOptions left, Azure.Storage.DataMovement.Models.ContainerTransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Storage.DataMovement.Models.ContainerTransferOptions left, Azure.Storage.DataMovement.Models.ContainerTransferOptions right) { throw null; }
    }
    public partial class ListStorageResourceOptions
    {
        public ListStorageResourceOptions() { }
        public Azure.Storage.DataMovement.Models.StorageResourceListStates States { get { throw null; } }
        public Azure.Storage.DataMovement.Models.StorageResourceListTraits Traits { get { throw null; } }
    }
    public enum ServiceCopyStatus
    {
        Pending = 0,
        Success = 1,
        Aborted = 2,
        Failed = 3,
    }
    public partial class SingleTransferOptions : System.IEquatable<Azure.Storage.DataMovement.Models.SingleTransferOptions>
    {
        public SingleTransferOptions() { }
        public string CheckpointTransferId { get { throw null; } set { } }
        public long? InitialTransferSize { get { throw null; } set { } }
        public long? MaximumTransferChunkSize { get { throw null; } set { } }
        public Azure.Storage.DataMovement.StorageResourceCreateMode OverwriteOptions { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferFailedEventArgs> TransferFailedEventHandler { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.StorageTransferStatusEventArgs> TransferStatusEventHandler { add { } remove { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Storage.DataMovement.Models.SingleTransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Storage.DataMovement.Models.SingleTransferOptions left, Azure.Storage.DataMovement.Models.SingleTransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Storage.DataMovement.Models.SingleTransferOptions left, Azure.Storage.DataMovement.Models.SingleTransferOptions right) { throw null; }
    }
    [System.FlagsAttribute]
    public enum StorageResourceListStates
    {
        All = -1,
        None = 0,
        Snapshots = 1,
        Uncommitted = 2,
        Deleted = 4,
        Version = 8,
        DeletedWithVersions = 16,
    }
    [System.FlagsAttribute]
    public enum StorageResourceListTraits
    {
        All = -1,
        None = 0,
        CopyStatus = 1,
        Metadata = 2,
        Tags = 4,
        ImmutabilityPolicy = 8,
        LegalHold = 16,
    }
    public partial class StorageResourceProperties
    {
        public StorageResourceProperties() { }
        public StorageResourceProperties(System.DateTimeOffset lastModified, System.DateTimeOffset createdOn, System.Collections.Generic.IDictionary<string, string> metadata, System.DateTimeOffset copyCompletedOn, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.DataMovement.Models.ServiceCopyStatus? copyStatus, long contentLength, string contentType, Azure.ETag eTag, byte[] contentHash, long blobSequenceNumber, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256, string encryptionScope, string versionId, bool isLatestVersion, System.DateTimeOffset expiresOn, System.DateTimeOffset lastAccessed) { }
        public StorageResourceProperties(System.DateTimeOffset lastModified, System.DateTimeOffset createdOn, long contentLength, System.DateTimeOffset lastAccessed) { }
    }
    public partial class StorageTransferStatusEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public StorageTransferStatusEventArgs(string transferId, Azure.Storage.DataMovement.StorageTransferStatus transferStatus, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageTransferStatus StorageTransferStatus { get { throw null; } }
    }
    public partial class TransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public TransferFailedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResource DestinationResource { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResource SourceResource { get { throw null; } }
    }
}
