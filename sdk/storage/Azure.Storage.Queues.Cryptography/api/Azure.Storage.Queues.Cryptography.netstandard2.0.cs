namespace Azure.Storage.Queues.Specialized
{
    public partial class EncryptedQueueClient : Azure.Storage.Queues.QueueClient
    {
        protected EncryptedQueueClient() { }
        public EncryptedQueueClient(string connectionString, string queueName) { }
        public EncryptedQueueClient(string connectionString, string queueName, Azure.Storage.Queues.QueueClientOptions options) { }
        public EncryptedQueueClient(System.Uri queueUri, Azure.Core.TokenCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public EncryptedQueueClient(System.Uri queueUri, Azure.Storage.Queues.QueueClientOptions options = null) { }
        public EncryptedQueueClient(System.Uri queueUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Queues.QueueClientOptions options = null) { }
    }
    public static partial class SpecializedBlobExtensions
    {
        public static Azure.Storage.Queues.Specialized.EncryptedQueueClient GetEncryptedQueueClient(this Azure.Storage.Queues.QueueServiceClient client, string queueName) { throw null; }
    }
}
