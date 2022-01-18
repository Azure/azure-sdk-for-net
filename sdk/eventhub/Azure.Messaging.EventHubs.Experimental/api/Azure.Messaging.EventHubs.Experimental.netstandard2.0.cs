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
        public virtual System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Producer.PartitionPublishingProperties> GetPartitionPublishingPropertiesAsync(string partitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IdempotentProducerOptions
    {
        public IdempotentProducerOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public bool EnableIdempotentPartitions { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public System.Collections.Generic.Dictionary<string, Azure.Messaging.EventHubs.Producer.PartitionPublishingOptions> PartitionOptions { get { throw null; } }
        public Azure.Messaging.EventHubs.EventHubsRetryOptions RetryOptions { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class PartitionPublishingOptions
    {
        public PartitionPublishingOptions() { }
        public short? OwnerLevel { get { throw null; } set { } }
        public long? ProducerGroupId { get { throw null; } set { } }
        public int? StartingSequenceNumber { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class PartitionPublishingProperties
    {
        public PartitionPublishingProperties(bool isIdempotentPublishingEnabled, long? producerGroupId, short? ownerLevel, int? lastPublishedSequenceNumber) { }
        public bool IsIdempotentPublishingEnabled { get { throw null; } }
        public int? LastPublishedSequenceNumber { get { throw null; } }
        public short? OwnerLevel { get { throw null; } }
        public long? ProducerGroupId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
}
