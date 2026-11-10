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
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesBetweenSnapshots(string continuationToken) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesBetweenSnapshots(string beginSnapshot, string endSnapshot) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesBetweenSnapshotsAsync(string continuationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent> GetChangesBetweenSnapshotsAsync(string beginSnapshot, string endSnapshot) { throw null; }
        public virtual System.DateTimeOffset? GetLastConsumable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.DateTimeOffset?> GetLastConsumableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus GetSnapshotStatus(string snapshotTimestamp, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus> GetSnapshotStatusAsync(string snapshotTimestamp, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShareChangeFeedClientOptions
    {
        public ShareChangeFeedClientOptions() { }
        public bool IncludeNonFinalizedEvents { get { throw null; } set { } }
        public long? MaximumTransferSizeInBytes { get { throw null; } set { } }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy? ResetPolicy { get { throw null; } set { } }
    }
    public partial class ShareChangeFeedEvent
    {
        internal ShareChangeFeedEvent() { }
        public long ContainerVersionNumber { get { throw null; } }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventData EventData { get { throw null; } }
        public System.DateTimeOffset EventOccurredOn { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol Protocol { get { throw null; } }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind Reason { get { throw null; } }
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
        public string NewFullFilePath { get { throw null; } }
        public string NewParentFileId { get { throw null; } }
        public string ParentFileId { get { throw null; } }
        public string ReplacedFileId { get { throw null; } }
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
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent ShareChangeFeedEvent(long schemaVersion = (long)0, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind reason = default(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind), Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol protocol = default(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedProtocol), System.DateTimeOffset eventTime = default(System.DateTimeOffset), string id = null, long containerVersionNumber = (long)0, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventData eventData = null) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventData ShareChangeFeedEventData(string fileId = null, string parentFileId = null, string newParentFileId = null, Azure.ETag? eTag = default(Azure.ETag?), string fileName = null, string fullFilePath = null, string newFullFilePath = null, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventIdentity identity = null, string description = null, string initiator = null, bool isDirectory = false, string replacedFileId = null) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEventIdentity ShareChangeFeedEventIdentity(string entraObjectId = null, string securityIdentifier = null) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetEvent ShareChangeFeedResetEvent(System.Guid resetId = default(System.Guid), long resetFileTime = (long)0, System.DateTimeOffset resetTimeUtc = default(System.DateTimeOffset), string accountName = null, string containerName = null, string resetReason = null, long schemaVersion = (long)1) { throw null; }
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
    public readonly partial struct ShareChangeFeedReasonKind : System.IEquatable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareChangeFeedReasonKind(string value) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind AsyncCopyFile { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind ControlEvent { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind Reset { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind RestCreate { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind RestCreateTruncate { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind RestDelete { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind RestRename { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind RestSetInfo { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind RestSetSecurityInfo { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind RestWrite { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SetInfo { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SetSecurityInfo { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SmbCreate { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SmbCreateTruncate { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SmbDelete { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SmbExtend { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SmbRename { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SmbWrite { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind SyncCopyFile { get { throw null; } }
        public bool Equals(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind right) { throw null; }
        public static implicit operator Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedReasonKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareChangeFeedResetEvent : Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedEvent
    {
        internal ShareChangeFeedResetEvent() { }
        public string AccountName { get { throw null; } }
        public string ContainerName { get { throw null; } }
        public long ResetFileTime { get { throw null; } }
        public System.Guid ResetId { get { throw null; } }
        public string ResetReason { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class ShareChangeFeedResetException : System.Exception
    {
        public ShareChangeFeedResetException(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetEvent resetEvent) { }
        public ShareChangeFeedResetException(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetEvent resetEvent, string message) { }
        public ShareChangeFeedResetException(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetEvent resetEvent, string message, System.Exception innerException) { }
        public Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetEvent ResetEvent { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareChangeFeedResetPolicy : System.IEquatable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareChangeFeedResetPolicy(string value) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy ContinueOnReset { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy ThrowOnReset { get { throw null; } }
        public bool Equals(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy right) { throw null; }
        public static implicit operator Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy (string value) { throw null; }
        public static implicit operator Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedResetPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareChangeFeedSnapshotStatus : System.IEquatable<Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareChangeFeedSnapshotStatus(string value) { throw null; }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus Finalized { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus NotFound { get { throw null; } }
        public static Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus Pending { get { throw null; } }
        public bool Equals(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus right) { throw null; }
        public static implicit operator Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus (string value) { throw null; }
        public static implicit operator Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus? (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus left, Azure.Storage.Files.Shares.ChangeFeed.ShareChangeFeedSnapshotStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
