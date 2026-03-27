namespace Azure.Storage.Files.Shares.ChangeFeed
{
    public partial class ShareChangeFeedClient
    {
        protected ShareChangeFeedClient() { }
        public ShareChangeFeedClient(string connectionString, string shareName, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedClientOptions changeFeedOptions = null) { }
        public ShareChangeFeedClient(System.Uri fileServiceUri, string shareName, Azure.Core.TokenCredential credential, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedClientOptions changeFeedOptions = null) { }
        public ShareChangeFeedClient(System.Uri fileServiceUri, string shareName, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedClientOptions changeFeedOptions = null) { }
        public ShareChangeFeedClient(System.Uri fileServiceUri, string shareName, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedClientOptions changeFeedOptions = null) { }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChanges() { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChanges(System.DateTimeOffset? start, System.DateTimeOffset? end) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChanges(string continuationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesAsync() { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesAsync(System.DateTimeOffset? start, System.DateTimeOffset? end) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesAsync(string continuationToken) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesBetweenSnapshots(string beginSnapshot, string endSnapshot) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesBetweenSnapshotsAsync(string beginSnapshot, string endSnapshot) { throw null; }
        public virtual System.DateTimeOffset? GetLastConsumable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.DateTimeOffset?> GetLastConsumableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShareChangeFeedClientOptions
    {
        public ShareChangeFeedClientOptions() { }
        public long? MaximumTransferSize { get { throw null; } set { } }
    }
    public partial class ShareChangeFeedEvent
    {
        internal ShareChangeFeedEvent() { }
        public long ContainerVersionNumber { get { throw null; } }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventData EventData { get { throw null; } }
        public System.DateTimeOffset EventTime { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol Protocol { get { throw null; } }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType Reason { get { throw null; } }
        public long SchemaVersion { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class ShareChangeFeedEventData
    {
        internal ShareChangeFeedEventData() { }
        public string Description { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string FileId { get { throw null; } }
        public string FileName { get { throw null; } }
        public string FullFilePath { get { throw null; } }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventIdentity Identity { get { throw null; } }
        public string Initiator { get { throw null; } }
        public bool IsDirectory { get { throw null; } }
        public string ParentFileId { get { throw null; } }
    }
    public partial class ShareChangeFeedEventIdentity
    {
        internal ShareChangeFeedEventIdentity() { }
        public string EntraObjectId { get { throw null; } }
        public string SecurityIdentifier { get { throw null; } }
    }
    public static partial class ShareChangeFeedExtensions
    {
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedClient GetShareChangeFeedClient(this Azure.Storage.Files.Shares.ShareClient shareClient, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedClientOptions options = null) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedClient GetShareChangeFeedClient(this Azure.Storage.Files.Shares.ShareServiceClient serviceClient, string shareName, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedClientOptions options = null) { throw null; }
    }
    public static partial class ShareChangeFeedModelFactory
    {
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent ShareChangeFeedEvent(long schemaVersion = (long)0, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType reason = default(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType), Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol protocol = default(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol), System.DateTimeOffset eventTime = default(System.DateTimeOffset), string id = null, long containerVersionNumber = (long)0, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventData eventData = null) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventData ShareChangeFeedEventData(string fileId = null, string parentFileId = null, Azure.ETag? eTag = default(Azure.ETag?), string fileName = null, string fullFilePath = null, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventIdentity identity = null, string description = null, string initiator = null, bool isDirectory = false) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventIdentity ShareChangeFeedEventIdentity(string entraObjectId = null, string securityIdentifier = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareChangeFeedProtocol : System.IEquatable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareChangeFeedProtocol(string value) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol Rest { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol Smb { get { throw null; } }
        public bool Equals(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol right) { throw null; }
        public static implicit operator Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareChangeFeedReasonType : System.IEquatable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareChangeFeedReasonType(string value) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType AsyncCopyFile { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType ControlEvent { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType RestCreate { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType RestCreateTruncate { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType RestDelete { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType RestRename { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType RestSetInfo { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType RestSetSecurityInfo { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType RestWrite { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SetInfo { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SetSecurityInfo { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SmbCreate { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SmbCreateTruncate { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SmbDelete { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SmbExtend { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SmbRename { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SmbWrite { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType SyncCopyFile { get { throw null; } }
        public bool Equals(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType right) { throw null; }
        public static implicit operator Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
