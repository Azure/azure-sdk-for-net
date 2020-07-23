namespace Azure.Storage.Blobs.ChangeFeed
{
    public partial class BlobChangeFeedClient
    {
        protected BlobChangeFeedClient() { }
        public BlobChangeFeedClient(string connectionString) { }
        public BlobChangeFeedClient(string connectionString, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual Azure.Pageable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent> GetChanges() { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent> GetChanges(System.DateTimeOffset start = default(System.DateTimeOffset), System.DateTimeOffset end = default(System.DateTimeOffset)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent> GetChanges(string continuationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent> GetChangesAsync() { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent> GetChangesAsync(System.DateTimeOffset start = default(System.DateTimeOffset), System.DateTimeOffset end = default(System.DateTimeOffset)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent> GetChangesAsync(string continuationToken) { throw null; }
    }
    public static partial class BlobChangeFeedExtensions
    {
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClient GetChangeFeedClient(this Azure.Storage.Blobs.BlobServiceClient serviceClient) { throw null; }
    }
}
namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    public partial class BlobChangeFeedEvent
    {
        internal BlobChangeFeedEvent() { }
        public Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventData EventData { get { throw null; } }
        public System.DateTimeOffset EventTime { get { throw null; } }
        public Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType EventType { get { throw null; } }
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
        public Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName BlobOperationName { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobType BlobType { get { throw null; } }
        public System.Guid ClientRequestId { get { throw null; } }
        public long ContentLength { get { throw null; } }
        public long? ContentOffset { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.Uri DestinationUri { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public bool? Recursive { get { throw null; } }
        public System.Guid RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobChangeFeedEventType : System.IEquatable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobChangeFeedEventType(string value) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType BlobAsyncOperationInitiated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType BlobCreated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType BlobDeleted { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType BlobPropertiesUpdated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType BlobSnapshotCreated { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType BlobTierChanged { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType Control { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType UnspecifiedEventType { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType left, Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType left, Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class BlobChangeFeedModelFactory
    {
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent BlobChangeFeedEvent(string topic, string subject, Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType eventType, System.DateTimeOffset eventTime, System.Guid id, Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventData eventData, long dataVersion, string metadataVersion) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventData BlobChangeFeedEventData(string api, System.Guid clientRequestId, System.Guid requestId, Azure.ETag eTag, string contentType, long contentLength, Azure.Storage.Blobs.Models.BlobType blobType, long contentOffset, System.Uri destinationUri, System.Uri sourceUri, System.Uri uri, bool recursive, string sequencer) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobOperationName : System.IEquatable<Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobOperationName(string value) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName AbortCopyBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName ControlEvent { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName CopyBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName DeleteBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName PutBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName PutBlockList { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName SetBlobMetadata { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName SetBlobProperties { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName SetBlobTier { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName SnapshotBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName UndeleteBlob { get { throw null; } }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName UnspecifiedApi { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName left, Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName left, Azure.Storage.Blobs.ChangeFeed.Models.BlobOperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
}
