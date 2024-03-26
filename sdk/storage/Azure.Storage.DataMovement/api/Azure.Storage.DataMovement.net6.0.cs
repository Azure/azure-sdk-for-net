namespace Azure.Storage.DataMovement
{
    public partial class DataTransfer
    {
        internal DataTransfer() { }
        public bool HasCompleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Storage.DataMovement.TransferManager TransferManager { get { throw null; } }
        public Azure.Storage.DataMovement.DataTransferStatus TransferStatus { get { throw null; } }
        public virtual System.Threading.Tasks.Task PauseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public void WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.Tasks.Task WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.FlagsAttribute]
    public enum DataTransferErrorMode
    {
        StopOnAnyFailure = 0,
        ContinueOnFailure = 1,
    }
    public abstract partial class DataTransferEventArgs : Azure.SyncAsyncEventArgs
    {
        protected DataTransferEventArgs(string transferId, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public string TransferId { get { throw null; } }
    }
    public partial class DataTransferOptions : System.IEquatable<Azure.Storage.DataMovement.DataTransferOptions>
    {
        public DataTransferOptions() { }
        public Azure.Storage.DataMovement.StorageResourceCreationPreference CreationPreference { get { throw null; } set { } }
        public long? InitialTransferSize { get { throw null; } set { } }
        public long? MaximumTransferChunkSize { get { throw null; } set { } }
        public Azure.Storage.DataMovement.ProgressHandlerOptions ProgressHandlerOptions { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.TransferItemCompletedEventArgs> ItemTransferCompleted { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.TransferItemFailedEventArgs> ItemTransferFailed { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.TransferItemSkippedEventArgs> ItemTransferSkipped { add { } remove { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.DataMovement.TransferStatusEventArgs> TransferStatusChanged { add { } remove { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Storage.DataMovement.DataTransferOptions obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.Storage.DataMovement.DataTransferOptions left, Azure.Storage.DataMovement.DataTransferOptions right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.Storage.DataMovement.DataTransferOptions left, Azure.Storage.DataMovement.DataTransferOptions right) { throw null; }
    }
    public enum DataTransferOrder
    {
        Unordered = 0,
        Sequential = 1,
    }
    public partial class DataTransferProgress
    {
        protected internal DataTransferProgress() { }
        public long? BytesTransferred { get { throw null; } }
        public long CompletedCount { get { throw null; } }
        public long FailedCount { get { throw null; } }
        public long InProgressCount { get { throw null; } }
        public long QueuedCount { get { throw null; } }
        public long SkippedCount { get { throw null; } }
    }
    public partial class DataTransferProperties
    {
        protected internal DataTransferProperties() { }
        public virtual byte[] DestinationCheckpointData { get { throw null; } }
        public virtual string DestinationProviderId { get { throw null; } }
        public virtual System.Uri DestinationUri { get { throw null; } }
        public virtual bool IsContainer { get { throw null; } }
        public virtual byte[] SourceCheckpointData { get { throw null; } }
        public virtual string SourceProviderId { get { throw null; } }
        public virtual System.Uri SourceUri { get { throw null; } }
        public virtual string TransferId { get { throw null; } }
    }
    public abstract partial class DataTransferProperty
    {
        public DataTransferProperty() { }
        public DataTransferProperty(bool preserve) { }
        public virtual bool Preserve { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string? ToString() { throw null; }
    }
    public partial class DataTransferProperty<T> : Azure.Storage.DataMovement.DataTransferProperty where T : notnull
    {
        public DataTransferProperty(bool preserve) { }
        public DataTransferProperty(T value) { }
        public virtual T? Value { get { throw null; } }
    }
    public enum DataTransferState
    {
        None = 0,
        Queued = 1,
        InProgress = 2,
        Pausing = 3,
        Stopping = 4,
        Paused = 5,
        Completed = 6,
    }
    public partial class DataTransferStatus : System.IEquatable<Azure.Storage.DataMovement.DataTransferStatus>
    {
        protected internal DataTransferStatus() { }
        protected internal DataTransferStatus(Azure.Storage.DataMovement.DataTransferState state, bool hasFailureItems, bool hasSkippedItems) { }
        public bool HasCompletedSuccessfully { get { throw null; } }
        public bool HasFailedItems { get { throw null; } }
        public bool HasSkippedItems { get { throw null; } }
        public Azure.Storage.DataMovement.DataTransferState State { get { throw null; } }
        public bool Equals(Azure.Storage.DataMovement.DataTransferStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.DataMovement.DataTransferStatus left, Azure.Storage.DataMovement.DataTransferStatus right) { throw null; }
        public static bool operator !=(Azure.Storage.DataMovement.DataTransferStatus left, Azure.Storage.DataMovement.DataTransferStatus right) { throw null; }
    }
    public partial class LocalFilesStorageResourceProvider : Azure.Storage.DataMovement.StorageResourceProvider
    {
        public LocalFilesStorageResourceProvider() { }
        protected internal override string ProviderId { get { throw null; } }
        protected internal override System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromDestinationAsync(Azure.Storage.DataMovement.DataTransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
        public Azure.Storage.DataMovement.StorageResourceContainer FromDirectory(string directoryPath) { throw null; }
        public Azure.Storage.DataMovement.StorageResourceItem FromFile(string filePath) { throw null; }
        protected internal override System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromSourceAsync(Azure.Storage.DataMovement.DataTransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class ProgressHandlerOptions
    {
        public ProgressHandlerOptions(System.IProgress<Azure.Storage.DataMovement.DataTransferProgress> progressHandler, bool trackBytesTransferred = false) { }
        public System.IProgress<Azure.Storage.DataMovement.DataTransferProgress> ProgressHandler { get { throw null; } set { } }
        public bool TrackBytesTransferred { get { throw null; } set { } }
    }
    public abstract partial class StorageResource
    {
        protected StorageResource() { }
        protected internal abstract bool IsContainer { get; }
        public abstract string ProviderId { get; }
        public abstract System.Uri Uri { get; }
        protected internal abstract Azure.Storage.DataMovement.StorageResourceCheckpointData GetDestinationCheckpointData();
        protected internal abstract Azure.Storage.DataMovement.StorageResourceCheckpointData GetSourceCheckpointData();
    }
    public abstract partial class StorageResourceCheckpointData
    {
        protected StorageResourceCheckpointData() { }
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
        protected internal abstract Azure.Storage.DataMovement.StorageResourceItem GetStorageResourceReference(string path);
        protected internal abstract System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> GetStorageResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial class StorageResourceCopyFromUriOptions
    {
        public StorageResourceCopyFromUriOptions() { }
        public string BlockId { get { throw null; } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
        public Azure.Storage.DataMovement.StorageResourceItemProperties SourceProperties { get { throw null; } set { } }
    }
    public enum StorageResourceCreationPreference
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
        protected internal abstract string ResourceId { get; }
        protected Azure.Storage.DataMovement.StorageResourceItemProperties ResourceProperties { get { throw null; } set { } }
        protected internal abstract Azure.Storage.DataMovement.DataTransferOrder TransferType { get; }
        protected internal abstract System.Threading.Tasks.Task CompleteTransferAsync(bool overwrite, Azure.Storage.DataMovement.StorageResourceCompleteTransferOptions completeTransferOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task CopyBlockFromUriAsync(Azure.Storage.DataMovement.StorageResourceItem sourceResource, Azure.HttpRange range, bool overwrite, long completeLength, Azure.Storage.DataMovement.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task CopyFromStreamAsync(System.IO.Stream stream, long streamLength, bool overwrite, long completeLength, Azure.Storage.DataMovement.StorageResourceWriteToOffsetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task CopyFromUriAsync(Azure.Storage.DataMovement.StorageResourceItem sourceResource, bool overwrite, long completeLength, Azure.Storage.DataMovement.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<bool> DeleteIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<Azure.HttpAuthorization> GetCopyAuthorizationHeaderAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResourceItemProperties> GetPropertiesAsync(System.Threading.CancellationToken token = default(System.Threading.CancellationToken));
        protected internal abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResourceReadStreamResult> ReadStreamAsync(long position = (long)0, long? length = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial class StorageResourceItemProperties
    {
        protected StorageResourceItemProperties() { }
        public StorageResourceItemProperties(long? resourceLength, Azure.ETag? eTag, System.DateTimeOffset? lastModifiedTime, System.Collections.Generic.Dictionary<string, object> properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public System.Collections.Generic.Dictionary<string, object> RawProperties { get { throw null; } }
        public long? ResourceLength { get { throw null; } }
    }
    public abstract partial class StorageResourceProvider
    {
        protected StorageResourceProvider() { }
        protected internal abstract string ProviderId { get; }
        protected internal abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromDestinationAsync(Azure.Storage.DataMovement.DataTransferProperties properties, System.Threading.CancellationToken cancellationToken);
        protected internal abstract System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromSourceAsync(Azure.Storage.DataMovement.DataTransferProperties properties, System.Threading.CancellationToken cancellationToken);
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
        public long? Position { get { throw null; } set { } }
        public Azure.Storage.DataMovement.StorageResourceItemProperties SourceProperties { get { throw null; } set { } }
    }
    public partial class TransferCheckpointStoreOptions
    {
        public TransferCheckpointStoreOptions(string localCheckpointerPath) { }
        public string CheckpointerPath { get { throw null; } }
    }
    public partial class TransferItemCompletedEventArgs : Azure.Storage.DataMovement.DataTransferEventArgs
    {
        public TransferItemCompletedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResourceItem sourceResource, Azure.Storage.DataMovement.StorageResourceItem destinationResource, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResourceItem DestinationResource { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResourceItem SourceResource { get { throw null; } }
    }
    public partial class TransferItemFailedEventArgs : Azure.Storage.DataMovement.DataTransferEventArgs
    {
        public TransferItemFailedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResourceItem sourceResource, Azure.Storage.DataMovement.StorageResourceItem destinationResource, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResourceItem DestinationResource { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResourceItem SourceResource { get { throw null; } }
    }
    public partial class TransferItemSkippedEventArgs : Azure.Storage.DataMovement.DataTransferEventArgs
    {
        public TransferItemSkippedEventArgs(string transferId, Azure.Storage.DataMovement.StorageResourceItem sourceResource, Azure.Storage.DataMovement.StorageResourceItem destinationResource, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.StorageResourceItem DestinationResource { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResourceItem SourceResource { get { throw null; } }
    }
    public partial class TransferManager : System.IAsyncDisposable
    {
        protected TransferManager() { }
        public TransferManager(Azure.Storage.DataMovement.TransferManagerOptions options = null) { }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.DataTransferProperties> GetResumableTransfersAsync() { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.DataTransfer> GetTransfersAsync(params Azure.Storage.DataMovement.DataTransferStatus[] filterByStatus) { throw null; }
        public virtual System.Threading.Tasks.Task PauseTransferIfRunningAsync(string transferId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.List<Azure.Storage.DataMovement.DataTransfer>> ResumeAllTransfersAsync(Azure.Storage.DataMovement.DataTransferOptions transferOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> ResumeTransferAsync(string transferId, Azure.Storage.DataMovement.DataTransferOptions transferOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> StartTransferAsync(Azure.Storage.DataMovement.StorageResource sourceResource, Azure.Storage.DataMovement.StorageResource destinationResource, Azure.Storage.DataMovement.DataTransferOptions transferOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Threading.Tasks.ValueTask System.IAsyncDisposable.DisposeAsync() { throw null; }
    }
    public partial class TransferManagerOptions
    {
        public TransferManagerOptions() { }
        public Azure.Storage.DataMovement.TransferCheckpointStoreOptions CheckpointerOptions { get { throw null; } set { } }
        public Azure.Core.DiagnosticsOptions Diagnostics { get { throw null; } }
        public Azure.Storage.DataMovement.DataTransferErrorMode ErrorHandling { get { throw null; } set { } }
        public int? MaximumConcurrency { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Storage.DataMovement.StorageResourceProvider> ResumeProviders { get { throw null; } set { } }
    }
    public partial class TransferStatusEventArgs : Azure.Storage.DataMovement.DataTransferEventArgs
    {
        public TransferStatusEventArgs(string transferId, Azure.Storage.DataMovement.DataTransferStatus transferStatus, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(string), default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.DataMovement.DataTransferStatus TransferStatus { get { throw null; } }
    }
}
