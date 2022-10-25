namespace Azure.Storage.DataMovement
{
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
        StopOnAllFailures = 0,
        ContinueOnFailure = 1,
    }
    public partial class LocalDirectoryStorageResourceContainer : Azure.Storage.DataMovement.StorageResourceContainer
    {
        public LocalDirectoryStorageResourceContainer(string path) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override System.Collections.Generic.List<string> Path { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override Azure.Storage.DataMovement.StorageResource GetChildStorageResource(System.Collections.Generic.List<string> path) { throw null; }
        public override Azure.Storage.DataMovement.StorageResourceContainer GetParentStorageResourceContainer(System.Collections.Generic.List<string> path) { throw null; }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> GetStorageResources([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalFileStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public LocalFileStorageResource(string path) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override System.Collections.Generic.List<string> Path { get { throw null; } }
        public override Azure.Storage.DataMovement.Models.RequiresCompleteTransferType RequiresCompleteTransfer { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override System.Threading.Tasks.Task CompleteTransferAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task CopyBlockFromUriAsync(System.Uri sourceUri, Azure.HttpRange range, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyFromUriAsync(System.Uri sourceUri, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceInfo> ReadPartialStreamAsync(long offset, long length, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceInfo> ReadStreamAsync(long? position = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task WriteStreamToOffsetAsync(long offset, long length, System.IO.Stream stream, Azure.Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalTransferCheckpointer : Azure.Storage.DataMovement.TransferCheckpointer
    {
        public LocalTransferCheckpointer(string folderPath) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.List<string>> GetStoredTransfersAsync() { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> ReadCheckPointStreamAsync(string id) { throw null; }
        public override System.Threading.Tasks.Task<bool> TryRemoveStoredTransferAsync(string id) { throw null; }
        public override System.Threading.Tasks.Task WriteToCheckpointAsync(string id, long offset, byte[] buffer) { throw null; }
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
        public abstract System.Collections.Generic.List<string> Path { get; }
        public abstract Azure.Storage.DataMovement.Models.RequiresCompleteTransferType RequiresCompleteTransfer { get; }
        public abstract System.Uri Uri { get; }
        public abstract System.Threading.Tasks.Task CompleteTransferAsync(System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task CopyBlockFromUriAsync(System.Uri sourceUri, Azure.HttpRange range, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task CopyFromUriAsync(System.Uri sourceUri, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken token);
        public abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceInfo> ReadPartialStreamAsync(long offset, long length, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceInfo> ReadStreamAsync(long? position = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task WriteStreamToOffsetAsync(long offset, long length, System.IO.Stream stream, Azure.Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public abstract partial class StorageResourceContainer
    {
        protected StorageResourceContainer() { }
        public abstract Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get; }
        public abstract System.Collections.Generic.List<string> Path { get; }
        public abstract System.Uri Uri { get; }
        public abstract Azure.Storage.DataMovement.StorageResource GetChildStorageResource(System.Collections.Generic.List<string> path);
        public abstract Azure.Storage.DataMovement.StorageResourceContainer GetParentStorageResourceContainer(System.Collections.Generic.List<string> path);
        public abstract System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> GetStorageResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public enum StorageResourceCreateMode
    {
        Overwrite = 0,
        Fail = 1,
        Skip = 2,
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
        public StorageTransferEventArgs(string transferId, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string TransferId { get { throw null; } }
    }
    public enum StorageTransferStatus
    {
        Queued = 0,
        InProgress = 1,
        Paused = 2,
        Completed = 3,
    }
    [System.FlagsAttribute]
    public enum StreamConsumableType
    {
        NotConsumable = 0,
        Consumable = 1,
    }
    public abstract partial class TransferCheckpointer
    {
        protected TransferCheckpointer() { }
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.List<string>> GetStoredTransfersAsync();
        public abstract System.Threading.Tasks.Task<System.IO.Stream> ReadCheckPointStreamAsync(string id);
        public abstract System.Threading.Tasks.Task<bool> TryRemoveStoredTransferAsync(string id);
        public abstract System.Threading.Tasks.Task WriteToCheckpointAsync(string id, long offset, byte[] buffer);
    }
    public partial class TransferManager
    {
        protected TransferManager() { }
        public TransferManager(Azure.Storage.DataMovement.TransferManagerOptions options) { }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> StartTransferAsync(Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, Azure.Storage.DataMovement.Models.SingleTransferOptions transferOptions = null) { throw null; }
        public System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> StartTransferAsync(Azure.Storage.DataMovement.StorageResourceContainer sourceResource, Azure.Storage.DataMovement.StorageResourceContainer destinationResource, Azure.Storage.DataMovement.Models.ContainerTransferOptions transferOptions = null) { throw null; }
        public System.Threading.Tasks.Task<bool> TryPauseAllTransfersAsync() { throw null; }
        public System.Threading.Tasks.Task<bool> TryPauseTransferAsync(string id) { throw null; }
        public System.Threading.Tasks.Task<bool> TryRemoveTransferAsync(string id) { throw null; }
    }
    public partial class TransferManagerOptions
    {
        public TransferManagerOptions() { }
        public Azure.Storage.DataMovement.TransferCheckpointer Checkpointer { get { throw null; } set { } }
        public Azure.Storage.DataMovement.ErrorHandlingOptions ErrorHandling { get { throw null; } set { } }
        public int? MaximumConcurrency { get { throw null; } set { } }
    }
}
namespace Azure.Storage.DataMovement.Models
{
    public partial class ContainerTransferOptions : System.IEquatable<Azure.Storage.DataMovement.Models.ContainerTransferOptions>
    {
        public ContainerTransferOptions() { }
        public Azure.Storage.DataMovement.StorageResourceCreateMode CreateMode { get { throw null; } set { } }
        public long? InitialTransferSize { get { throw null; } set { } }
        public long? MaximumTransferChunkSize { get { throw null; } set { } }
        public string ResumeFromCheckpointId { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.SingleTransferCompletedEventArgs> SingleTransferCompletedEventHandler { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferFailedEventArgs> TransferFailedEventHandler { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferSkippedEventArgs> TransferSkippedEventHandler { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferStatusEventArgs> TransferStatusEventHandler { add { } remove { } }
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
    public partial class ReadStreamStorageResourceInfo
    {
        public ReadStreamStorageResourceInfo(System.IO.Stream content) { }
        public ReadStreamStorageResourceInfo(System.IO.Stream content, string contentRange, string acceptRanges, byte[] rangeContentHash, Azure.Storage.DataMovement.Models.StorageResourceProperties properties) { }
    }
    public enum RequiresCompleteTransferType
    {
        None = 0,
        RequiresCompleteCall = 1,
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
        public SingleTransferCompletedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResource DestinationResource { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResource SourceResource { get { throw null; } }
    }
    public partial class SingleTransferOptions : System.IEquatable<Azure.Storage.DataMovement.Models.SingleTransferOptions>
    {
        public SingleTransferOptions() { }
        public Azure.Storage.DataMovement.StorageResourceCreateMode CreateMode { get { throw null; } set { } }
        public long? InitialTransferSize { get { throw null; } set { } }
        public long? MaximumTransferChunkSize { get { throw null; } set { } }
        public string ResumeFromCheckpointId { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferFailedEventArgs> TransferFailedEventHandler { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.Models.TransferStatusEventArgs> TransferStatusEventHandler { add { } remove { } }
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
    public enum TransferCopyMethod
    {
        SyncCopy = 0,
        AsyncCopy = 1,
        UploadFromUriCopy = 2,
    }
    public partial class TransferFailedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public TransferFailedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResource DestinationResource { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResource SourceResource { get { throw null; } }
    }
    public partial class TransferSkippedEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public TransferSkippedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResource DestinationResource { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResource SourceResource { get { throw null; } }
    }
    public partial class TransferStatusEventArgs : Azure.Storage.DataMovement.StorageTransferEventArgs
    {
        public TransferStatusEventArgs(string transferId, Azure.Storage.DataMovement.StorageTransferStatus transferStatus, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageTransferStatus StorageTransferStatus { get { throw null; } }
    }
}
