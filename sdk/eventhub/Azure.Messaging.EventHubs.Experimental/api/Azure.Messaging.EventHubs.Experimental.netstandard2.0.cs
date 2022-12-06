namespace Azure.Messaging.EventHubs.Producer
{
    public partial class IdempotentProducer : Azure.Messaging.EventHubs.Producer.EventHubProducerClient
    {
        protected IdempotentProducer() { }
        public IdempotentProducer(Azure.Messaging.EventHubs.EventHubConnection connection, Azure.Messaging.EventHubs.Producer.IdempotentProducerOptions clientOptions = null) { }
        public IdempotentProducer(string connectionString) { }
        public IdempotentProducer(string connectionString, Azure.Messaging.EventHubs.Producer.IdempotentProducerOptions clientOptions) { }
        public IdempotentProducer(string connectionString, string eventHubName) { }
        public IdempotentProducer(string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.Producer.IdempotentProducerOptions clientOptions = null) { }
        public IdempotentProducer(string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.Producer.IdempotentProducerOptions clientOptions = null) { }
        public IdempotentProducer(string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.Producer.IdempotentProducerOptions clientOptions = null) { }
        public IdempotentProducer(string connectionString, string eventHubName, Azure.Messaging.EventHubs.Producer.IdempotentProducerOptions clientOptions) { }
        public virtual new System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Producer.PartitionPublishingProperties> GetPartitionPublishingPropertiesAsync(string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IdempotentProducerOptions : Azure.Messaging.EventHubs.Producer.EventHubProducerClientOptions
    {
        public IdempotentProducerOptions() { }
        public new bool EnableIdempotentPartitions { get { throw null; } set { } }
        public new System.Collections.Generic.Dictionary<string, Azure.Messaging.EventHubs.Producer.PartitionPublishingOptions> PartitionOptions { get { throw null; } }
    }
}
