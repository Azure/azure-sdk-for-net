namespace Azure.Storage.Queues
{
    public partial class QueueClient
    {
        protected QueueClient() { }
        public QueueClient(string connectionString, string queueName) { }
        public QueueClient(string connectionString, string queueName, Azure.Storage.Queues.QueueClientOptions options) { }
        public QueueClient(System.Uri queueUri, Azure.AzureSasCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueClient(System.Uri queueUri, Azure.Core.TokenCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueClient(System.Uri queueUri, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueClient(System.Uri queueUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual bool CanGenerateSasUri { get { throw null; } }
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
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.QueueSasBuilder builder) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.QueueSasBuilder builder, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.QueueSasPermissions permissions, System.DateTimeOffset expiresOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.QueueSasPermissions permissions, System.DateTimeOffset expiresOn, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.QueueSasBuilder builder, Azure.Storage.Queues.Models.UserDelegationKey userDelegationKey) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.QueueSasBuilder builder, Azure.Storage.Queues.Models.UserDelegationKey userDelegationKey, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.QueueSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Queues.Models.UserDelegationKey userDelegationKey) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.QueueSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Queues.Models.UserDelegationKey userDelegationKey, out string stringToSign) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier>> GetAccessPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier>>> GetAccessPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual Azure.Storage.Queues.QueueServiceClient GetParentQueueServiceClientCore() { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual System.Threading.Tasks.Task OnMessageDecodingFailedAsync(Azure.Storage.Queues.Models.QueueMessage receivedMessage, Azure.Storage.Queues.Models.PeekedMessage peekedMessage, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.PeekedMessage> PeekMessage(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.PeekedMessage>> PeekMessageAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.PeekedMessage[]> PeekMessages(int? maxMessages = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.PeekedMessage[]>> PeekMessagesAsync(int? maxMessages = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueMessage> ReceiveMessage(System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage>> ReceiveMessageAsync(System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]> ReceiveMessages() { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]> ReceiveMessages(int? maxMessages = default(int?), System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]> ReceiveMessages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]>> ReceiveMessagesAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]>> ReceiveMessagesAsync(int? maxMessages = default(int?), System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage[]>> ReceiveMessagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.SendReceipt> SendMessage(System.BinaryData message, System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.TimeSpan? timeToLive = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.SendReceipt> SendMessage(string messageText) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.SendReceipt> SendMessage(string messageText, System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.TimeSpan? timeToLive = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.SendReceipt> SendMessage(string messageText, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.SendReceipt>> SendMessageAsync(System.BinaryData message, System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.TimeSpan? timeToLive = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.SendReceipt>> SendMessageAsync(string messageText) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.SendReceipt>> SendMessageAsync(string messageText, System.TimeSpan? visibilityTimeout = default(System.TimeSpan?), System.TimeSpan? timeToLive = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.SendReceipt>> SendMessageAsync(string messageText, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetAccessPolicy(System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier> permissions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetAccessPolicyAsync(System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier> permissions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.UpdateReceipt> UpdateMessage(string messageId, string popReceipt, System.BinaryData message, System.TimeSpan visibilityTimeout = default(System.TimeSpan), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.UpdateReceipt> UpdateMessage(string messageId, string popReceipt, string messageText = null, System.TimeSpan visibilityTimeout = default(System.TimeSpan), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.UpdateReceipt>> UpdateMessageAsync(string messageId, string popReceipt, System.BinaryData message, System.TimeSpan visibilityTimeout = default(System.TimeSpan), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.UpdateReceipt>> UpdateMessageAsync(string messageId, string popReceipt, string messageText = null, System.TimeSpan visibilityTimeout = default(System.TimeSpan), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual Azure.Storage.Queues.QueueClient WithClientSideEncryptionOptionsCore(Azure.Storage.ClientSideEncryptionOptions clientSideEncryptionOptions) { throw null; }
    }
    public partial class QueueClientOptions : Azure.Core.ClientOptions
    {
        public QueueClientOptions(Azure.Storage.Queues.QueueClientOptions.ServiceVersion version = Azure.Storage.Queues.QueueClientOptions.ServiceVersion.V2026_02_06) { }
        public Azure.Storage.Queues.Models.QueueAudience? Audience { get { throw null; } set { } }
        public bool EnableTenantDiscovery { get { throw null; } set { } }
        public System.Uri GeoRedundantSecondaryUri { get { throw null; } set { } }
        public Azure.Storage.Queues.QueueMessageEncoding MessageEncoding { get { throw null; } set { } }
        public Azure.Storage.Queues.QueueClientOptions.ServiceVersion Version { get { throw null; } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Storage.Queues.QueueMessageDecodingFailedEventArgs> MessageDecodingFailed { add { } remove { } }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
            V2019_07_07 = 2,
            V2019_12_12 = 3,
            V2020_02_10 = 4,
            V2020_04_08 = 5,
            V2020_06_12 = 6,
            V2020_08_04 = 7,
            V2020_10_02 = 8,
            V2020_12_06 = 9,
            V2021_02_12 = 10,
            V2021_04_10 = 11,
            V2021_06_08 = 12,
            V2021_08_06 = 13,
            V2021_10_04 = 14,
            V2021_12_02 = 15,
            V2022_11_02 = 16,
            V2023_01_03 = 17,
            V2023_05_03 = 18,
            V2023_08_03 = 19,
            V2023_11_03 = 20,
            V2024_02_04 = 21,
            V2024_05_04 = 22,
            V2024_08_04 = 23,
            V2024_11_04 = 24,
            V2025_01_05 = 25,
            V2025_05_05 = 26,
            V2025_07_05 = 27,
            V2025_11_05 = 28,
            V2026_02_06 = 29,
            V2026_04_06 = 30,
        }
    }
    public partial class QueueMessageDecodingFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public QueueMessageDecodingFailedEventArgs(Azure.Storage.Queues.QueueClient queueClient, Azure.Storage.Queues.Models.QueueMessage receivedMessage, Azure.Storage.Queues.Models.PeekedMessage peekedMessage, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public Azure.Storage.Queues.Models.PeekedMessage PeekedMessage { get { throw null; } }
        public Azure.Storage.Queues.QueueClient Queue { get { throw null; } }
        public Azure.Storage.Queues.Models.QueueMessage ReceivedMessage { get { throw null; } }
    }
    public enum QueueMessageEncoding
    {
        None = 0,
        Base64 = 1,
    }
    public partial class QueueServiceClient
    {
        protected QueueServiceClient() { }
        public QueueServiceClient(string connectionString) { }
        public QueueServiceClient(string connectionString, Azure.Storage.Queues.QueueClientOptions options) { }
        public QueueServiceClient(System.Uri serviceUri, Azure.AzureSasCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueServiceClient(System.Uri serviceUri, Azure.Core.TokenCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueServiceClient(System.Uri serviceUri, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public QueueServiceClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual bool CanGenerateAccountSasUri { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Queues.QueueClient> CreateQueue(string queueName, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.QueueClient>> CreateQueueAsync(string queueName, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteQueue(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueueAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Uri GenerateAccountSasUri(Azure.Storage.Sas.AccountSasBuilder builder) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Uri GenerateAccountSasUri(Azure.Storage.Sas.AccountSasBuilder builder, out string stringToSign) { throw null; }
        public System.Uri GenerateAccountSasUri(Azure.Storage.Sas.AccountSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Sas.AccountSasResourceTypes resourceTypes) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Uri GenerateAccountSasUri(Azure.Storage.Sas.AccountSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Sas.AccountSasResourceTypes resourceTypes, out string stringToSign) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Queues.QueueClient GetQueueClient(string queueName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Queues.Models.QueueItem> GetQueues(Azure.Storage.Queues.Models.QueueTraits traits = Azure.Storage.Queues.Models.QueueTraits.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Queues.Models.QueueItem> GetQueuesAsync(Azure.Storage.Queues.Models.QueueTraits traits = Azure.Storage.Queues.Models.QueueTraits.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics> GetStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics>> GetStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Queues.Models.UserDelegationKey> GetUserDelegationKey(System.DateTimeOffset expiresOn, Azure.Storage.Queues.Models.QueueGetUserDelegationKeyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Queues.Models.UserDelegationKey> GetUserDelegationKey(System.DateTimeOffset? startsOn, System.DateTimeOffset expiresOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.UserDelegationKey>> GetUserDelegationKeyAsync(System.DateTimeOffset expiresOn, Azure.Storage.Queues.Models.QueueGetUserDelegationKeyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.UserDelegationKey>> GetUserDelegationKeyAsync(System.DateTimeOffset? startsOn, System.DateTimeOffset expiresOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.BinaryData Body { get { throw null; } }
        public long DequeueCount { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.DateTimeOffset? InsertedOn { get { throw null; } }
        public string MessageId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string MessageText { get { throw null; } }
    }
    public partial class QueueAccessPolicy
    {
        public QueueAccessPolicy() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public string Permissions { get { throw null; } set { } }
        public System.DateTimeOffset? StartsOn { get { throw null; } set { } }
    }
    public partial class QueueAnalyticsLogging
    {
        public QueueAnalyticsLogging() { }
        public bool Delete { get { throw null; } set { } }
        public bool Read { get { throw null; } set { } }
        public Azure.Storage.Queues.Models.QueueRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public bool Write { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueueAudience : System.IEquatable<Azure.Storage.Queues.Models.QueueAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueueAudience(string value) { throw null; }
        public static Azure.Storage.Queues.Models.QueueAudience PublicAudience { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueAudience CreateQueueServiceAccountAudience(string storageAccountName) { throw null; }
        public bool Equals(Azure.Storage.Queues.Models.QueueAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Queues.Models.QueueAudience left, Azure.Storage.Queues.Models.QueueAudience right) { throw null; }
        public static implicit operator Azure.Storage.Queues.Models.QueueAudience (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Queues.Models.QueueAudience left, Azure.Storage.Queues.Models.QueueAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueueCorsRule
    {
        public QueueCorsRule() { }
        public string AllowedHeaders { get { throw null; } set { } }
        public string AllowedMethods { get { throw null; } set { } }
        public string AllowedOrigins { get { throw null; } set { } }
        public string ExposedHeaders { get { throw null; } set { } }
        public int MaxAgeInSeconds { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueueErrorCode : System.IEquatable<Azure.Storage.Queues.Models.QueueErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueueErrorCode(string value) { throw null; }
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountAlreadyExists { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountBeingCreated { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountIsDisabled { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthenticationFailed { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationFailure { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationPermissionMismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationProtocolMismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationResourceTypeMismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationServiceMismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationSourceIPMismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ConditionHeadersNotSupported { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ConditionNotMet { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode EmptyMetadataKey { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode FeatureVersionMismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InsufficientAccountPermissions { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InternalError { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidAuthenticationInfo { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidHeaderValue { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidHttpVerb { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidInput { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMarker { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMd5 { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMetadata { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidQueryParameterValue { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidRange { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidResourceName { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidUri { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidXmlDocument { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidXmlNodeValue { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode Md5Mismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MessageNotFound { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MessageTooLarge { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MetadataTooLarge { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingContentLengthHeader { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredHeader { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredQueryParameter { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredXmlNode { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode MultipleConditionHeadersNotSupported { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode OperationTimedOut { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode OutOfRangeInput { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode OutOfRangeQueryParameterValue { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode PopReceiptMismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueAlreadyExists { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueBeingDeleted { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueDisabled { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueNotEmpty { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueNotFound { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode RequestBodyTooLarge { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode RequestUrlFailedToParse { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceAlreadyExists { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceNotFound { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceTypeMismatch { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode ServerBusy { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedHeader { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedHttpVerb { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedQueryParameter { get { throw null; } }
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedXmlNode { get { throw null; } }
        public bool Equals(Azure.Storage.Queues.Models.QueueErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public bool Equals(string value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Queues.Models.QueueErrorCode left, Azure.Storage.Queues.Models.QueueErrorCode right) { throw null; }
        public static bool operator ==(Azure.Storage.Queues.Models.QueueErrorCode code, string value) { throw null; }
        public static bool operator ==(string value, Azure.Storage.Queues.Models.QueueErrorCode code) { throw null; }
        public static implicit operator Azure.Storage.Queues.Models.QueueErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Queues.Models.QueueErrorCode left, Azure.Storage.Queues.Models.QueueErrorCode right) { throw null; }
        public static bool operator !=(Azure.Storage.Queues.Models.QueueErrorCode code, string value) { throw null; }
        public static bool operator !=(string value, Azure.Storage.Queues.Models.QueueErrorCode code) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueueGeoReplication
    {
        internal QueueGeoReplication() { }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public Azure.Storage.Queues.Models.QueueGeoReplicationStatus Status { get { throw null; } }
    }
    public enum QueueGeoReplicationStatus
    {
        Live = 0,
        Bootstrap = 1,
        Unavailable = 2,
    }
    public partial class QueueGetUserDelegationKeyOptions
    {
        public QueueGetUserDelegationKeyOptions() { }
        public string DelegatedUserTenantId { get { throw null; } set { } }
        public System.DateTimeOffset? StartsOn { get { throw null; } set { } }
    }
    public partial class QueueItem
    {
        internal QueueItem() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class QueueMessage
    {
        internal QueueMessage() { }
        public System.BinaryData Body { get { throw null; } }
        public long DequeueCount { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.DateTimeOffset? InsertedOn { get { throw null; } }
        public string MessageId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string MessageText { get { throw null; } }
        public System.DateTimeOffset? NextVisibleOn { get { throw null; } }
        public string PopReceipt { get { throw null; } }
        public Azure.Storage.Queues.Models.QueueMessage Update(Azure.Storage.Queues.Models.UpdateReceipt updated) { throw null; }
    }
    public partial class QueueMetrics
    {
        public QueueMetrics() { }
        public bool Enabled { get { throw null; } set { } }
        public bool? IncludeApis { get { throw null; } set { } }
        public Azure.Storage.Queues.Models.QueueRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class QueueProperties
    {
        public QueueProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int ApproximateMessagesCount { get { throw null; } }
        public long ApproximateMessagesCountLong { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class QueueRetentionPolicy
    {
        public QueueRetentionPolicy() { }
        public int? Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
    }
    public partial class QueueServiceProperties
    {
        public QueueServiceProperties() { }
        public System.Collections.Generic.IList<Azure.Storage.Queues.Models.QueueCorsRule> Cors { get { throw null; } set { } }
        public Azure.Storage.Queues.Models.QueueMetrics HourMetrics { get { throw null; } set { } }
        public Azure.Storage.Queues.Models.QueueAnalyticsLogging Logging { get { throw null; } set { } }
        public Azure.Storage.Queues.Models.QueueMetrics MinuteMetrics { get { throw null; } set { } }
    }
    public partial class QueueServiceStatistics
    {
        internal QueueServiceStatistics() { }
        public Azure.Storage.Queues.Models.QueueGeoReplication GeoReplication { get { throw null; } }
    }
    public partial class QueueSignedIdentifier
    {
        public QueueSignedIdentifier() { }
        public Azure.Storage.Queues.Models.QueueAccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public static partial class QueuesModelFactory
    {
        public static Azure.Storage.Queues.Models.PeekedMessage PeekedMessage(string messageId, System.BinaryData message, long dequeueCount, System.DateTimeOffset? insertedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Queues.Models.PeekedMessage PeekedMessage(string messageId, string messageText, long dequeueCount, System.DateTimeOffset? insertedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Storage.Queues.Models.QueueGeoReplication QueueGeoReplication(Azure.Storage.Queues.Models.QueueGeoReplicationStatus status, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Storage.Queues.Models.QueueItem QueueItem(string name, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.Storage.Queues.Models.QueueMessage QueueMessage(string messageId, string popReceipt, System.BinaryData body, long dequeueCount, System.DateTimeOffset? nextVisibleOn = default(System.DateTimeOffset?), System.DateTimeOffset? insertedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Queues.Models.QueueMessage QueueMessage(string messageId, string popReceipt, string messageText, long dequeueCount, System.DateTimeOffset? nextVisibleOn = default(System.DateTimeOffset?), System.DateTimeOffset? insertedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Queues.Models.QueueProperties QueueProperties(System.Collections.Generic.IDictionary<string, string> metadata, int approximateMessagesCount) { throw null; }
        public static Azure.Storage.Queues.Models.QueueProperties QueueProperties(System.Collections.Generic.IDictionary<string, string> metadata, long approximateMessagesCount) { throw null; }
        public static Azure.Storage.Queues.Models.QueueServiceStatistics QueueServiceStatistics(Azure.Storage.Queues.Models.QueueGeoReplication geoReplication = null) { throw null; }
        public static Azure.Storage.Queues.Models.SendReceipt SendReceipt(string messageId, System.DateTimeOffset insertionTime, System.DateTimeOffset expirationTime, string popReceipt, System.DateTimeOffset timeNextVisible) { throw null; }
        public static Azure.Storage.Queues.Models.UpdateReceipt UpdateReceipt(string popReceipt, System.DateTimeOffset nextVisibleOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Queues.Models.UserDelegationKey UserDelegationKey(string signedObjectId = null, string signedTenantId = null, System.DateTimeOffset signedStartsOn = default(System.DateTimeOffset), System.DateTimeOffset signedExpiresOn = default(System.DateTimeOffset), string signedService = null, string signedVersion = null, string value = null) { throw null; }
        public static Azure.Storage.Queues.Models.UserDelegationKey UserDelegationKey(string signedObjectId = null, string signedTenantId = null, System.DateTimeOffset signedStartsOn = default(System.DateTimeOffset), System.DateTimeOffset signedExpiresOn = default(System.DateTimeOffset), string signedService = null, string signedVersion = null, string signedDelegatedUserTenantId = null, string value = null) { throw null; }
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
        public System.DateTimeOffset ExpirationTime { get { throw null; } }
        public System.DateTimeOffset InsertionTime { get { throw null; } }
        public string MessageId { get { throw null; } }
        public string PopReceipt { get { throw null; } }
        public System.DateTimeOffset TimeNextVisible { get { throw null; } }
    }
    public partial class UpdateReceipt
    {
        internal UpdateReceipt() { }
        public System.DateTimeOffset NextVisibleOn { get { throw null; } }
        public string PopReceipt { get { throw null; } }
    }
    public partial class UserDelegationKey
    {
        internal UserDelegationKey() { }
        public string SignedDelegatedUserTenantId { get { throw null; } }
        public System.DateTimeOffset SignedExpiresOn { get { throw null; } }
        public string SignedObjectId { get { throw null; } }
        public string SignedService { get { throw null; } }
        public System.DateTimeOffset SignedStartsOn { get { throw null; } }
        public string SignedTenantId { get { throw null; } }
        public string SignedVersion { get { throw null; } }
        public string Value { get { throw null; } }
    }
}
namespace Azure.Storage.Queues.Specialized
{
    public partial class ClientSideDecryptionFailureEventArgs
    {
        internal ClientSideDecryptionFailureEventArgs() { }
        public System.Exception Exception { get { throw null; } }
    }
    public partial class QueueClientSideEncryptionOptions : Azure.Storage.ClientSideEncryptionOptions
    {
        public QueueClientSideEncryptionOptions(Azure.Storage.ClientSideEncryptionVersion version) : base (default(Azure.Storage.ClientSideEncryptionVersion)) { }
        public event System.EventHandler<Azure.Storage.Queues.Specialized.ClientSideDecryptionFailureEventArgs> DecryptionFailed { add { } remove { } }
    }
    public partial class SpecializedQueueClientOptions : Azure.Storage.Queues.QueueClientOptions
    {
        public SpecializedQueueClientOptions(Azure.Storage.Queues.QueueClientOptions.ServiceVersion version = Azure.Storage.Queues.QueueClientOptions.ServiceVersion.V2026_02_06) : base (default(Azure.Storage.Queues.QueueClientOptions.ServiceVersion)) { }
        public Azure.Storage.ClientSideEncryptionOptions ClientSideEncryption { get { throw null; } set { } }
    }
    public static partial class SpecializedQueueExtensions
    {
        public static Azure.Storage.Queues.QueueServiceClient GetParentQueueServiceClient(this Azure.Storage.Queues.QueueClient client) { throw null; }
        public static Azure.Storage.Queues.QueueClient WithClientSideEncryptionOptions(this Azure.Storage.Queues.QueueClient client, Azure.Storage.ClientSideEncryptionOptions clientSideEncryptionOptions) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public QueueSasBuilder() { }
        public QueueSasBuilder(Azure.Storage.Sas.QueueAccountSasPermissions permissions, System.DateTimeOffset expiresOn) { }
        public QueueSasBuilder(Azure.Storage.Sas.QueueSasPermissions permissions, System.DateTimeOffset expiresOn) { }
        public string DelegatedUserObjectId { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Storage.Sas.SasIPRange IPRange { get { throw null; } set { } }
        public string Permissions { get { throw null; } }
        public Azure.Storage.Sas.SasProtocol Protocol { get { throw null; } set { } }
        public string QueueName { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Version { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Storage.Sas.QueueAccountSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.QueueSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public void SetPermissions(string rawPermissions, bool normalize = false) { }
        public Azure.Storage.Sas.QueueSasQueryParameters ToSasQueryParameters(Azure.Storage.Queues.Models.UserDelegationKey userDelegationKey, string accountName) { throw null; }
        public Azure.Storage.Sas.QueueSasQueryParameters ToSasQueryParameters(Azure.Storage.Queues.Models.UserDelegationKey userDelegationKey, string accountName, out string stringToSign) { throw null; }
        public Azure.Storage.Sas.SasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) { throw null; }
        public Azure.Storage.Sas.SasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential, out string stringToSign) { throw null; }
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
    public sealed partial class QueueSasQueryParameters : Azure.Storage.Sas.SasQueryParameters
    {
        internal QueueSasQueryParameters() { }
        public static new Azure.Storage.Sas.QueueSasQueryParameters Empty { get { throw null; } }
        public string KeyDelegatedUserTenantId { get { throw null; } }
        public System.DateTimeOffset KeyExpiresOn { get { throw null; } }
        public string KeyObjectId { get { throw null; } }
        public string KeyService { get { throw null; } }
        public System.DateTimeOffset KeyStartsOn { get { throw null; } }
        public string KeyTenantId { get { throw null; } }
        public string KeyVersion { get { throw null; } }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class QueueClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.AzureSasCredential sasCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.Core.TokenCredential tokenCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Queues.QueueServiceClient, Azure.Storage.Queues.QueueClientOptions> AddQueueServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
