namespace Azure.Storage.Blobs.ChangeFeed
{
    public partial class BlobChangeFeedClient
    {
        protected BlobChangeFeedClient() { }
        public BlobChangeFeedClient(string connectionString) { }
        public BlobChangeFeedClient(string connectionString, Azure.Storage.Blobs.BlobClientOptions options, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClientOptions changeFeedOptions) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClientOptions changeFeedOptions = null) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClientOptions changeFeedOptions = null) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Storage.Blobs.BlobClientOptions options = null, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClientOptions changeFeedOptions = null) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClientOptions changeFeedOptions = null) { }
        public virtual Azure.Pageable<Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEvent> GetChanges() { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEvent> GetChanges(System.DateTimeOffset? start = default(System.DateTimeOffset?), System.DateTimeOffset? end = default(System.DateTimeOffset?)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEvent> GetChanges(string continuationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEvent> GetChangesAsync() { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEvent> GetChangesAsync(System.DateTimeOffset? start = default(System.DateTimeOffset?), System.DateTimeOffset? end = default(System.DateTimeOffset?)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEvent> GetChangesAsync(string continuationToken) { throw null; }
        public virtual System.DateTimeOffset? GetLastConsumable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.DateTimeOffset?> GetLastConsumableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobChangeFeedClientOptions
    {
        public BlobChangeFeedClientOptions() { }
        public long? MaximumTransferSize { get { throw null; } set { } }
    }
    public partial class BlobChangeFeedEvent
    {
        internal BlobChangeFeedEvent() { }
        public Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventData EventData { get { throw null; } }
        public System.DateTimeOffset EventTime { get { throw null; } }
        public Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType EventType { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public string MetadataVersion { get { throw null; } }
        public long SchemaVersion { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Topic { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class BlobChangeFeedEventData
    {
        internal BlobChangeFeedEventData() { }
        public Azure.Storage.Blobs.Models.AccessTier? BlobAccessTier { get { throw null; } }
        public Azure.Storage.Blobs.ChangeFeed.BlobOperationName BlobOperationName { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobType BlobType { get { throw null; } }
        public string BlobVersion { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string ContainerVersion { get { throw null; } }
        public long ContentLength { get { throw null; } }
        public long? ContentOffset { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.Uri DestinationUri { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public Azure.Storage.Blobs.ChangeFeed.BlobOperationResult LongRunningOperationInfo { get { throw null; } }
        public Azure.Storage.Blobs.ChangeFeed.ChangeFeedEventPreviousInfo PreviousInfo { get { throw null; } }
        public bool? Recursive { get { throw null; } }
        public System.Guid RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public string Snapshot { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
        public System.Collections.Generic.Dictionary<string, Azure.Storage.Blobs.ChangeFeed.BlobPropertyChange> UpdatedBlobProperties { get { throw null; } }
        public Azure.Storage.Blobs.ChangeFeed.BlobTagsChange UpdatedBlobTags { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobChangeFeedEventType : System.IEquatable<Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobChangeFeedEventType(string value) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType BlobAsyncOperationInitiated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType BlobCreated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType BlobDeleted { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType BlobPropertiesUpdated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType BlobSnapshotCreated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType BlobTierChanged { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType Control { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType RestorePointMarkerCreated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType UnspecifiedEventType { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType left, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType left, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class BlobChangeFeedExtensions
    {
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClient GetChangeFeedClient(this Azure.Storage.Blobs.BlobServiceClient serviceClient, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClientOptions options = null) { throw null; }
    }
    public static partial class BlobChangeFeedModelFactory
    {
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEvent BlobChangeFeedEvent(string topic, string subject, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventType eventType, System.DateTimeOffset eventTime, System.Guid id, Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventData eventData, long dataVersion, string metadataVersion) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationResult BlobChangeFeedEventAsyncOperationInfo(Azure.Storage.Blobs.Models.AccessTier? destinationAccessTier, bool wasAsyncOperation, string copyId) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedEventData BlobChangeFeedEventData(string blobOperationName, string clientRequestId, System.Guid requestId, Azure.ETag eTag, string contentType, long contentLength, Azure.Storage.Blobs.Models.BlobType blobType, string blobVersion, string containerVersion, Azure.Storage.Blobs.Models.AccessTier? blobAccessTier, long contentOffset, System.Uri destinationUri, System.Uri sourceUri, System.Uri uri, bool recursive, string sequencer, Azure.Storage.Blobs.ChangeFeed.ChangeFeedEventPreviousInfo previousInfo, string snapshot, System.Collections.Generic.Dictionary<string, Azure.Storage.Blobs.ChangeFeed.BlobPropertyChange> updatedBlobProperties, Azure.Storage.Blobs.ChangeFeed.BlobOperationResult asyncOperationInfo, Azure.Storage.Blobs.ChangeFeed.BlobTagsChange updatedBlobTags) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.BlobPropertyChange BlobChangeFeedEventUpdatedBlobProperty(string propertyName, string previousValue, string newValue) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.BlobTagsChange BlobChangeFeedEventUpdatedBlobTags(System.Collections.Generic.Dictionary<string, string> previousTags, System.Collections.Generic.Dictionary<string, string> newTags) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.ChangeFeedEventPreviousInfo ChangeFeedEventPreviousInfo(string softDeleteSnapshot, bool wasBlobSoftDeleted, string blobVersion, string lastVersion, Azure.Storage.Blobs.Models.AccessTier? previousTier) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobOperationName : System.IEquatable<Azure.Storage.Blobs.ChangeFeed.BlobOperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobOperationName(string value) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName AbortCopyBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName ControlEvent { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName CopyBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName CreateRestorePointMarker { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName DeleteBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName PutBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName PutBlockList { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName SetBlobMetadata { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName SetBlobProperties { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName SetBlobTags { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName SetBlobTier { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName SnapshotBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName UndeleteBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.BlobOperationName UnspecifiedApi { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.ChangeFeed.BlobOperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.ChangeFeed.BlobOperationName left, Azure.Storage.Blobs.ChangeFeed.BlobOperationName right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.ChangeFeed.BlobOperationName (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.ChangeFeed.BlobOperationName left, Azure.Storage.Blobs.ChangeFeed.BlobOperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobOperationResult
    {
        internal BlobOperationResult() { }
        public string CopyId { get { throw null; } }
        public Azure.Storage.Blobs.Models.AccessTier? DestinationAccessTier { get { throw null; } }
        public bool IsAsync { get { throw null; } }
    }
    public partial class BlobPropertyChange
    {
        internal BlobPropertyChange() { }
        public string NewValue { get { throw null; } }
        public string OldValue { get { throw null; } }
        public string PropertyName { get { throw null; } }
    }
    public partial class BlobTagsChange
    {
        internal BlobTagsChange() { }
        public System.Collections.Generic.Dictionary<string, string> NewTags { get { throw null; } }
        public System.Collections.Generic.Dictionary<string, string> OldTags { get { throw null; } }
    }
    public partial class ChangeFeedEventPreviousInfo
    {
        internal ChangeFeedEventPreviousInfo() { }
        public string NewBlobVersion { get { throw null; } }
        public string OldBlobVersion { get { throw null; } }
        public Azure.Storage.Blobs.Models.AccessTier? PreviousTier { get { throw null; } }
        public string SoftDeleteSnapshot { get { throw null; } }
        public bool WasBlobSoftDeleted { get { throw null; } }
    }
}
