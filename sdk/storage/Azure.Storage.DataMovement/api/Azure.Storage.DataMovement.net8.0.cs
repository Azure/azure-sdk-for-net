namespace Azure.Storage.DataMovement
{
    public partial class LocalFilesStorageResourceProvider : Azure.Storage.DataMovement.StorageResourceProvider
    {
        public LocalFilesStorageResourceProvider() { }
        protected internal override string ProviderId { get { throw null; } }
        protected internal override System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromDestinationAsync(Azure.Storage.DataMovement.TransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
        public Azure.Storage.DataMovement.StorageResourceContainer FromDirectory(string directoryPath) { throw null; }
        public Azure.Storage.DataMovement.StorageResourceItem FromFile(string filePath) { throw null; }
        protected internal override System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromSourceAsync(Azure.Storage.DataMovement.TransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public abstract partial class StorageResource
    {
        protected StorageResource() { }
        protected internal abstract bool IsContainer { get; }
        public abstract string ProviderId { get; }
        public abstract System.Uri Uri { get; }
        protected internal abstract Azure.Storage.DataMovement.StorageResourceCheckpointDetails GetDestinationCheckpointDetails();
        protected internal abstract Azure.Storage.DataMovement.StorageResourceCheckpointDetails GetSourceCheckpointDetails();
    }
    public abstract partial class StorageResourceCheckpointDetails
    {
        protected StorageResourceCheckpointDetails() { }
        public abstract int Length { get; }
        protected internal abstract void Serialize(System.IO.Stream stream);
    }
    public partial class StorageResourceCompleteTransferOptions
    {
        public StorageResourceCompleteTransferOptions() { }
        public Azure.Storage.DataMovement.StorageResourceItemProperties SourceProperties { get { throw null; } set { } }
    }
    public abstract partial class StorageResourceContainer : Azure.Storage.DataMovement.StorageResource
    {
        protected StorageResourceContainer() { }
        protected internal override bool IsContainer { get { throw null; } }
        protected internal abstract System.Threading.Tasks.Task CreateIfNotExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract Azure.Storage.DataMovement.StorageResourceContainer GetChildStorageResourceContainer(string path);
        protected internal abstract Azure.Storage.DataMovement.StorageResourceItem GetStorageResourceReference(string path, string resourceId);
        protected internal abstract System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> GetStorageResourcesAsync(Azure.Storage.DataMovement.StorageResourceContainer destinationContainer = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial class StorageResourceCopyFromUriOptions
    {
        public StorageResourceCopyFromUriOptions() { }
        public string BlockId { get { throw null; } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
        public Azure.Storage.DataMovement.StorageResourceItemProperties SourceProperties { get { throw null; } set { } }
    }
    public enum StorageResourceCreationMode
    {
        Default = 0,
        FailIfExists = 1,
        OverwriteIfExists = 2,
        SkipIfExists = 3,
    }
    public abstract partial class StorageResourceItem : Azure.Storage.DataMovement.StorageResource
    {
        protected StorageResourceItem() { }
        protected internal override bool IsContainer { get { throw null; } }
        protected internal abstract long? Length { get; }
        protected internal abstract long MaxSupportedChunkSize { get; }
        protected internal abstract long MaxSupportedSingleTransferSize { get; }
        protected internal abstract string ResourceId { get; }
        protected internal Azure.Storage.DataMovement.StorageResourceItemProperties ResourceProperties { get { throw null; } set { } }
        protected internal abstract Azure.Storage.DataMovement.TransferOrder TransferType { get; }
        protected internal abstract System.Threading.Tasks.Task CompleteTransferAsync(bool overwrite, Azure.Storage.DataMovement.StorageResourceCompleteTransferOptions completeTransferOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task CopyBlockFromUriAsync(Azure.Storage.DataMovement.StorageResourceItem sourceResource, Azure.HttpRange range, bool overwrite, long completeLength, Azure.Storage.DataMovement.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task CopyFromStreamAsync(System.IO.Stream stream, long streamLength, bool overwrite, long completeLength, Azure.Storage.DataMovement.StorageResourceWriteToOffsetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task CopyFromUriAsync(Azure.Storage.DataMovement.StorageResourceItem sourceResource, bool overwrite, long completeLength, Azure.Storage.DataMovement.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<bool> DeleteIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<Azure.HttpAuthorization> GetCopyAuthorizationHeaderAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<string> GetPermissionsAsync(Azure.Storage.DataMovement.StorageResourceItemProperties properties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResourceItemProperties> GetPropertiesAsync(System.Threading.CancellationToken token = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResourceReadStreamResult> ReadStreamAsync(long position = (long)0, long? length = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task SetPermissionsAsync(Azure.Storage.DataMovement.StorageResourceItem sourceResource, Azure.Storage.DataMovement.StorageResourceItemProperties sourceProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial class StorageResourceItemProperties
    {
        public StorageResourceItemProperties() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> RawProperties { get { throw null; } set { } }
        public long? ResourceLength { get { throw null; } set { } }
    }
    public abstract partial class StorageResourceProvider
    {
        protected StorageResourceProvider() { }
        protected internal abstract string ProviderId { get; }
        protected internal abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromDestinationAsync(Azure.Storage.DataMovement.TransferProperties properties, System.Threading.CancellationToken cancellationToken);
        protected internal abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromSourceAsync(Azure.Storage.DataMovement.TransferProperties properties, System.Threading.CancellationToken cancellationToken);
    }
    public partial class StorageResourceReadStreamResult
    {
        public readonly System.IO.Stream Content;
        public readonly long? ContentLength;
        public readonly Azure.ETag? ETag;
        public readonly long? ResourceLength;
        public StorageResourceReadStreamResult(System.IO.Stream content, Azure.HttpRange range, Azure.Storage.DataMovement.StorageResourceItemProperties properties) { }
    }
    public partial class StorageResourceWriteToOffsetOptions
    {
        public StorageResourceWriteToOffsetOptions() { }
        public string BlockId { get { throw null; } set { } }
        public bool Initial { get { throw null; } set { } }
        public long? Position { get { throw null; } set { } }
        public Azure.Storage.DataMovement.StorageResourceItemProperties SourceProperties { get { throw null; } set { } }
    }
    public partial class TransferCheckpointStoreOptions
    {
        internal TransferCheckpointStoreOptions() { }
        public static Azure.Storage.DataMovement.TransferCheckpointStoreOptions CreateLocalStore(string localCheckpointPath) { throw null; }
        public static Azure.Storage.DataMovement.TransferCheckpointStoreOptions DisableCheckpoint() { throw null; }
    }
    [System.FlagsAttribute]
    public enum TransferErrorMode
    {
        StopOnAnyFailure = 0,
        ContinueOnFailure = 1,
    }
    public abstract partial class TransferEventArgs : Azure.SyncAsyncEventArgs
    {
        protected TransferEventArgs(string transferId, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string TransferId { get { throw null; } }
    }
    public partial class TransferItemCompletedEventArgs : Azure.Storage.DataMovement.TransferEventArgs
    {
        public TransferItemCompletedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResourceItem sourceResource, Azure.Storage.DataMovement.StorageResourceItem destinationResource, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResourceItem Destination { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResourceItem Source { get { throw null; } }
    }
    public partial class TransferItemFailedEventArgs : Azure.Storage.DataMovement.TransferEventArgs
    {
        public TransferItemFailedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResource Destination { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResource Source { get { throw null; } }
    }
    public partial class TransferItemSkippedEventArgs : Azure.Storage.DataMovement.TransferEventArgs
    {
        public TransferItemSkippedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResourceItem sourceResource, Azure.Storage.DataMovement.StorageResourceItem destinationResource, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResourceItem Destination { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResourceItem Source { get { throw null; } }
    }
    public partial class TransferManager : System.IAsyncDisposable
    {
        protected TransferManager() { }
        public TransferManager(Azure.Storage.DataMovement.TransferManagerOptions options = null) { }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.TransferProperties> GetResumableTransfersAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.TransferOperation> GetTransfersAsync(System.Collections.Generic.ICollection<Azure.Storage.DataMovement.TransferStatus> filterByStatus = null, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task PauseTransferAsync(string transferId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.List<Azure.Storage.DataMovement.TransferOperation>> ResumeAllTransfersAsync(Azure.Storage.DataMovement.TransferOptions transferOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.DataMovement.TransferOperation> ResumeTransferAsync(string transferId, Azure.Storage.DataMovement.TransferOptions transferOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.DataMovement.TransferOperation> StartTransferAsync(Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, Azure.Storage.DataMovement.TransferOptions transferOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Threading.Tasks.ValueTask System.IAsyncDisposable.DisposeAsync() { throw null; }
    }
    public partial class TransferManagerOptions
    {
        public TransferManagerOptions() { }
        public Azure.Storage.DataMovement.TransferCheckpointStoreOptions CheckpointStoreOptions { get { throw null; } set { } }
        public Azure.Core.DiagnosticsOptions Diagnostics { get { throw null; } }
        public Azure.Storage.DataMovement.TransferErrorMode ErrorMode { get { throw null; } set { } }
        public int? MaximumConcurrency { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Storage.DataMovement.StorageResourceProvider> ResumeProviders { get { throw null; } set { } }
    }
    public partial class TransferOperation
    {
        internal TransferOperation() { }
        public bool HasCompleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Storage.DataMovement.TransferStatus Status { get { throw null; } }
        public Azure.Storage.DataMovement.TransferManager TransferManager { get { throw null; } }
        public virtual System.Threading.Tasks.Task PauseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TransferOptions : System.IEquatable<Azure.Storage.DataMovement.TransferOptions>
    {
        public TransferOptions() { }
        public Azure.Storage.DataMovement.StorageResourceCreationMode CreationPreference { get { throw null; } set { } }
        public long? InitialTransferSize { get { throw null; } set { } }
        public long? MaximumTransferChunkSize { get { throw null; } set { } }
        public Azure.Storage.DataMovement.TransferProgressHandlerOptions ProgressHandlerOptions { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.TransferItemCompletedEventArgs> ItemTransferCompleted { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.TransferItemFailedEventArgs> ItemTransferFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.TransferItemSkippedEventArgs> ItemTransferSkipped { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.TransferStatusEventArgs> TransferStatusChanged { add { } remove { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Storage.DataMovement.TransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Storage.DataMovement.TransferOptions left, Azure.Storage.DataMovement.TransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Storage.DataMovement.TransferOptions left, Azure.Storage.DataMovement.TransferOptions right) { throw null; }
    }
    public enum TransferOrder
    {
        Unordered = 0,
        Sequential = 1,
    }
    public partial class TransferProgress
    {
        internal TransferProgress() { }
        public long? BytesTransferred { get { throw null; } }
        public long CompletedCount { get { throw null; } }
        public long FailedCount { get { throw null; } }
        public long InProgressCount { get { throw null; } }
        public long QueuedCount { get { throw null; } }
        public long SkippedCount { get { throw null; } }
    }
    public partial class TransferProgressHandlerOptions
    {
        public TransferProgressHandlerOptions() { }
        public System.IProgress<Azure.Storage.DataMovement.TransferProgress> ProgressHandler { get { throw null; } set { } }
        public bool TrackBytesTransferred { get { throw null; } set { } }
    }
    public partial class TransferProperties
    {
        protected internal TransferProperties() { }
        public virtual byte[] DestinationCheckpointDetails { get { throw null; } }
        public virtual string DestinationProviderId { get { throw null; } }
        public virtual System.Uri DestinationUri { get { throw null; } }
        public virtual bool IsContainer { get { throw null; } }
        public virtual byte[] SourceCheckpointDetails { get { throw null; } }
        public virtual string SourceProviderId { get { throw null; } }
        public virtual System.Uri SourceUri { get { throw null; } }
        public virtual string TransferId { get { throw null; } }
    }
    public enum TransferState
    {
        None = 0,
        Queued = 1,
        InProgress = 2,
        Pausing = 3,
        Stopping = 4,
        Paused = 5,
        Completed = 6,
    }
    public partial class TransferStatus : System.IEquatable<Azure.Storage.DataMovement.TransferStatus>
    {
        protected internal TransferStatus() { }
        protected internal TransferStatus(Azure.Storage.DataMovement.TransferState state, bool hasFailureItems, bool hasSkippedItems) { }
        public bool HasCompletedSuccessfully { get { throw null; } }
        public bool HasFailedItems { get { throw null; } }
        public bool HasSkippedItems { get { throw null; } }
        public Azure.Storage.DataMovement.TransferState State { get { throw null; } }
        public bool Equals(Azure.Storage.DataMovement.TransferStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.DataMovement.TransferStatus left, Azure.Storage.DataMovement.TransferStatus right) { throw null; }
        public static bool operator !=(Azure.Storage.DataMovement.TransferStatus left, Azure.Storage.DataMovement.TransferStatus right) { throw null; }
    }
    public partial class TransferStatusEventArgs : Azure.Storage.DataMovement.TransferEventArgs
    {
        public TransferStatusEventArgs(string transferId, Azure.Storage.DataMovement.TransferStatus transferStatus, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.TransferStatus TransferStatus { get { throw null; } }
    }
}
