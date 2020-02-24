namespace Azure.Storage.Queues
{
    public partial class QueueClient
    {
        protected QueueClient() { }
        public QueueClient(string connectionString, string queueName) { }
        public QueueClient(string connectionString, string queueName, Azure.Storage.Queues.QueueClientOptions options) { }
        public QueueClient(System.Uri queueUri, Azure.Core.TokenCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueClient(System.Uri queueUri, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueClient(System.Uri queueUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual int MaxPeekableMessages { get { throw null; } }
        public virtual int MessageMaxBytes { get { throw null; } }
        protected virtual System.Uri MessagesUri { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response ClearMessages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ClearMessagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateIfNotExists(System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateIfNotExistsAsync(System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteMessage(string messageId, string popReceipt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMessageAsync(string messageId, string popReceipt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier>> GetAccessPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier>>> GetAccessPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.PeekedMessage[]> PeekMessages(int? maxMessages = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.PeekedMessage[]>> PeekMessagesAsync(int? maxMessages = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]> ReceiveMessages() { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]> ReceiveMessages(int? maxMessages = default(int?), System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]> ReceiveMessages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]>> ReceiveMessagesAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]>> ReceiveMessagesAsync(int? maxMessages = default(int?), System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]>> ReceiveMessagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.SendReceipt> SendMessage(string messageText) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.SendReceipt> SendMessage(string messageText, System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.TimeSpan? timeToLive = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.SendReceipt> SendMessage(string messageText, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.SendReceipt>> SendMessageAsync(string messageText) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.SendReceipt>> SendMessageAsync(string messageText, System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.TimeSpan? timeToLive = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.SendReceipt>> SendMessageAsync(string messageText, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetAccessPolicy(System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier> permissions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetAccessPolicyAsync(System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier> permissions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.UpdateReceipt> UpdateMessage(string messageId, string popReceipt, string messageText = null, System.TimeSpan visibilityTimeout = default(System.TimeSpan), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.UpdateReceipt>> UpdateMessageAsync(string messageId, string popReceipt, string messageText = null, System.TimeSpan visibilityTimeout = default(System.TimeSpan), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueClientOptions : Azure.Core.ClientOptions
    {
        public QueueClientOptions(Azure.Storage.Queues.QueueClientOptions.ServiceVersion version = Azure.Storage.Queues.QueueClientOptions.ServiceVersion.V2019_07_07) { }
        public System.Uri GeoRedundantSecondaryUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Queues.QueueClientOptions.ServiceVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
            V2019_07_07 = 2,
        }
    }
    public partial class QueueServiceClient
    {
        protected QueueServiceClient() { }
        public QueueServiceClient(string connectionString) { }
        public QueueServiceClient(string connectionString, Azure.Storage.Queues.QueueClientOptions options) { }
        public QueueServiceClient(System.Uri serviceUri, Azure.Core.TokenCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueServiceClient(System.Uri serviceUri, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueServiceClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Queues.QueueClient> CreateQueue(string queueName, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.QueueClient>> CreateQueueAsync(string queueName, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteQueue(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueueAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Queues.QueueClient GetQueueClient(string queueName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Queues.Models.QueueItem> GetQueues(Azure.Storage.Queues.Models.QueueTraits traits = Azure.Storage.Queues.Models.QueueTraits.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Queues.Models.QueueItem> GetQueuesAsync(Azure.Storage.Queues.Models.QueueTraits traits = Azure.Storage.Queues.Models.QueueTraits.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics> GetStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics>> GetStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetProperties(Azure.Storage.Queues.Models.QueueServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(Azure.Storage.Queues.Models.QueueServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueUriBuilder
    {
        public QueueUriBuilder(System.Uri uri) { }
        public string AccountName { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public bool Messages { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string QueueName { get { throw null; } set { } }
        public Azure.Storage.Sas.SasQueryParameters Sas { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public override string ToString() { throw null; }
        public System.Uri ToUri() { throw null; }
    }
}
namespace Azure.Storage.Queues.Models
{
    public partial class PeekedMessage
    {
        internal PeekedMessage() { }
        public long DequeueCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? InsertedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string MessageId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string MessageText { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class QueueAccessPolicy
    {
        public QueueAccessPolicy() { }
        public System.DateTimeOffset? ExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Permissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset? StartsOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class QueueAnalyticsLogging
    {
        public QueueAnalyticsLogging() { }
        public bool Delete { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool Read { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Queues.Models.QueueRetentionPolicy RetentionPolicy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool Write { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class QueueCorsRule
    {
        public QueueCorsRule() { }
        public string AllowedHeaders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string AllowedMethods { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string AllowedOrigins { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ExposedHeaders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int MaxAgeInSeconds { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueueErrorCode : System.IEquatable<Azure.Storage.Queues.Models.QueueErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueueErrorCode(string value) { throw null; }
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountAlreadyExists { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountBeingCreated { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountIsDisabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthenticationFailed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationFailure { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationPermissionMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationProtocolMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationResourceTypeMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationServiceMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationSourceIPMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ConditionHeadersNotSupported { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ConditionNotMet { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode EmptyMetadataKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode FeatureVersionMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InsufficientAccountPermissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InternalError { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidAuthenticationInfo { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidHeaderValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidHttpVerb { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidInput { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMarker { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMd5 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMetadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidQueryParameterValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidResourceName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidXmlDocument { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidXmlNodeValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode Md5Mismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MessageNotFound { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MessageTooLarge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MetadataTooLarge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingContentLengthHeader { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredHeader { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredQueryParameter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredXmlNode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MultipleConditionHeadersNotSupported { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode OperationTimedOut { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode OutOfRangeInput { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode OutOfRangeQueryParameterValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode PopReceiptMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueAlreadyExists { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueBeingDeleted { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueDisabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueNotEmpty { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueNotFound { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode RequestBodyTooLarge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode RequestUrlFailedToParse { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceAlreadyExists { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceNotFound { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceTypeMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ServerBusy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedHeader { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedHttpVerb { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedQueryParameter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedXmlNode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool Equals(Azure.Storage.Queues.Models.QueueErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Queues.Models.QueueErrorCode left, Azure.Storage.Queues.Models.QueueErrorCode right) { throw null; }
        public static implicit operator Azure.Storage.Queues.Models.QueueErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Queues.Models.QueueErrorCode left, Azure.Storage.Queues.Models.QueueErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueueGeoReplication
    {
        internal QueueGeoReplication() { }
        public System.DateTimeOffset? LastSyncedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Queues.Models.QueueGeoReplicationStatus Status { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum QueueGeoReplicationStatus
    {
        Live = 0,
        Bootstrap = 1,
        Unavailable = 2,
    }
    public partial class QueueItem
    {
        internal QueueItem() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class QueueMessage
    {
        internal QueueMessage() { }
        public long DequeueCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? InsertedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string MessageId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string MessageText { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? NextVisibleOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string PopReceipt { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Queues.Models.QueueMessage Update(Azure.Storage.Queues.Models.UpdateReceipt updated) { throw null; }
    }
    public partial class QueueMetrics
    {
        public QueueMetrics() { }
        public bool Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool? IncludeApis { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Queues.Models.QueueRetentionPolicy RetentionPolicy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class QueueProperties
    {
        public QueueProperties() { }
        public int ApproximateMessagesCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class QueueRetentionPolicy
    {
        public QueueRetentionPolicy() { }
        public int? Days { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class QueueServiceProperties
    {
        public QueueServiceProperties() { }
        public System.Collections.Generic.IList<Azure.Storage.Queues.Models.QueueCorsRule> Cors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Queues.Models.QueueMetrics HourMetrics { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Queues.Models.QueueAnalyticsLogging Logging { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Queues.Models.QueueMetrics MinuteMetrics { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class QueueServiceStatistics
    {
        internal QueueServiceStatistics() { }
        public Azure.Storage.Queues.Models.QueueGeoReplication GeoReplication { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class QueueSignedIdentifier
    {
        public QueueSignedIdentifier() { }
        public Azure.Storage.Queues.Models.QueueAccessPolicy AccessPolicy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public static partial class QueuesModelFactory
    {
        public static Azure.Storage.Queues.Models.PeekedMessage PeekedMessage(string messageId, string messageText, long dequeueCount, System.DateTimeOffset? insertedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Storage.Queues.Models.QueueGeoReplication QueueGeoReplication(Azure.Storage.Queues.Models.QueueGeoReplicationStatus status, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Storage.Queues.Models.QueueItem QueueItem(string name, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.Storage.Queues.Models.QueueMessage QueueMessage(string messageId, string popReceipt, string messageText, long dequeueCount, System.DateTimeOffset? nextVisibleOn = default(System.DateTimeOffset?), System.DateTimeOffset? insertedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Storage.Queues.Models.QueueProperties QueueProperties(System.Collections.Generic.IDictionary<string, string> metadata, int approximateMessagesCount) { throw null; }
        public static Azure.Storage.Queues.Models.QueueServiceStatistics QueueServiceStatistics(Azure.Storage.Queues.Models.QueueGeoReplication geoReplication = null) { throw null; }
        public static Azure.Storage.Queues.Models.SendReceipt SendReceipt(string messageId, System.DateTimeOffset insertionTime, System.DateTimeOffset expirationTime, string popReceipt, System.DateTimeOffset timeNextVisible) { throw null; }
        public static Azure.Storage.Queues.Models.UpdateReceipt UpdateReceipt(string popReceipt, System.DateTimeOffset nextVisibleOn) { throw null; }
    }
    [System.FlagsAttribute]
    public enum QueueTraits
    {
        None = 0,
        Metadata = 1,
    }
    public partial class SendReceipt
    {
        internal SendReceipt() { }
        public System.DateTimeOffset ExpirationTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset InsertionTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string MessageId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string PopReceipt { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset TimeNextVisible { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class UpdateReceipt
    {
        internal UpdateReceipt() { }
        public System.DateTimeOffset NextVisibleOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string PopReceipt { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
}
namespace Azure.Storage.Sas
{
    [System.FlagsAttribute]
    public enum QueueAccountSasPermissions
    {
        All = -1,
        Read = 1,
        Write = 2,
        Delete = 4,
        List = 8,
        Add = 16,
        Update = 32,
        Process = 64,
    }
    public partial class QueueSasBuilder
    {
        public QueueSasBuilder() { }
        public System.DateTimeOffset ExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Identifier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Sas.SasIPRange IPRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Permissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Sas.SasProtocol Protocol { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string QueueName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset StartsOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Storage.Sas.QueueAccountSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.QueueSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public Azure.Storage.Sas.SasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum QueueSasPermissions
    {
        All = -1,
        Read = 1,
        Add = 2,
        Update = 4,
        Process = 8,
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class QueueClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
