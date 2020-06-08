namespace Azure.Storage.Blobs.ChangeFeed
{
    public partial class BlobChangeFeedAsyncPagable : Azure.AsyncPageable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent>
    {
        internal BlobChangeFeedAsyncPagable() { }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.Page<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent>> AsPages(string continuationToken = null, int? pageSizeHint = default(int?)) { throw null; }
    }
    public partial class BlobChangeFeedClient
    {
        protected BlobChangeFeedClient() { }
        public BlobChangeFeedClient(string connectionString) { }
        public BlobChangeFeedClient(string connectionString, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobChangeFeedClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedPagable GetChanges() { throw null; }
        public virtual Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedPagable GetChanges(System.DateTimeOffset start = default(System.DateTimeOffset), System.DateTimeOffset end = default(System.DateTimeOffset)) { throw null; }
        public virtual Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedPagable GetChanges(string continuation) { throw null; }
        public virtual Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedAsyncPagable GetChangesAsync() { throw null; }
        public virtual Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedAsyncPagable GetChangesAsync(System.DateTimeOffset start = default(System.DateTimeOffset), System.DateTimeOffset end = default(System.DateTimeOffset)) { throw null; }
        public virtual Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedAsyncPagable GetChangesAsync(string continuation) { throw null; }
    }
    public static partial class BlobChangeFeedExtensions
    {
        public static Azure.Storage.Blobs.ChangeFeed.BlobChangeFeedClient GetChangeFeedClient(this Azure.Storage.Blobs.BlobServiceClient serviceClient) { throw null; }
    }
    public partial class BlobChangeFeedPagable : Azure.Pageable<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent>
    {
        internal BlobChangeFeedPagable() { }
        public override System.Collections.Generic.IEnumerable<Azure.Page<Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent>> AsPages(string continuationToken = null, int? pageSizeHint = default(int?)) { throw null; }
    }
}
namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    public partial class BlobChangeFeedEvent
    {
        internal BlobChangeFeedEvent() { }
        public long? DataVersion { get { throw null; } }
        public Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventData EventData { get { throw null; } }
        public System.DateTimeOffset EventTime { get { throw null; } }
        public Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType EventType { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        public string MetadataVersion { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Topic { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class BlobChangeFeedEventData
    {
        internal BlobChangeFeedEventData() { }
        public string Api { get { throw null; } }
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
    public enum BlobChangeFeedEventType
    {
        BlobCreated = 0,
        BlobDeleted = 1,
    }
    public static partial class BlobChangeFeedModelFactory
    {
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEvent BlobChangeFeedEvent(string topic, string subject, Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventType eventType, System.DateTimeOffset eventTime, System.Guid id, Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventData eventData, long dataVersion, string metadataVersion) { throw null; }
        public static Azure.Storage.Blobs.ChangeFeed.Models.BlobChangeFeedEventData BlobChangeFeedEventData(string api, System.Guid clientRequestId, System.Guid requestId, Azure.ETag eTag, string contentType, long contentLength, Azure.Storage.Blobs.Models.BlobType blobType, long contentOffset, System.Uri destinationUri, System.Uri sourceUri, System.Uri uri, bool recursive, string sequencer) { throw null; }
    }
}
