namespace Azure.Messaging.EventHubs
{
    public partial class EventProcessorClient : Azure.Messaging.EventHubs.Primitives.EventProcessor<Azure.Messaging.EventHubs.Primitives.EventProcessorPartition>
    {
        protected EventProcessorClient() { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string connectionString) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string connectionString, Azure.Messaging.EventHubs.EventProcessorClientOptions clientOptions) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string connectionString, string eventHubName) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.AzureNamedKeyCredential credential, Azure.Messaging.EventHubs.EventProcessorClientOptions clientOptions = null) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.AzureSasCredential credential, Azure.Messaging.EventHubs.EventProcessorClientOptions clientOptions = null) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.EventProcessorClientOptions clientOptions = null) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string connectionString, string eventHubName, Azure.Messaging.EventHubs.EventProcessorClientOptions clientOptions) { }
        public new string ConsumerGroup { get { throw null; } }
        public new string EventHubName { get { throw null; } }
        public new string FullyQualifiedNamespace { get { throw null; } }
        public new string Identifier { get { throw null; } }
        public new bool IsRunning { get { throw null; } protected set { } }
        public event System.Func<Azure.Messaging.EventHubs.Processor.PartitionClosingEventArgs, System.Threading.Tasks.Task> PartitionClosingAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.EventHubs.Processor.PartitionInitializingEventArgs, System.Threading.Tasks.Task> PartitionInitializingAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.EventHubs.Processor.ProcessErrorEventArgs, System.Threading.Tasks.Task> ProcessErrorAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.EventHubs.Processor.ProcessEventArgs, System.Threading.Tasks.Task> ProcessEventAsync { add { } remove { } }
        protected override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ClaimOwnershipAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership> desiredOwnership, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override Azure.Messaging.EventHubs.EventHubConnection CreateConnection() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Primitives.EventProcessorCheckpoint> GetCheckpointAsync(string partitionId, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        protected override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ListOwnershipAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task OnInitializingPartitionAsync(Azure.Messaging.EventHubs.Primitives.EventProcessorPartition partition, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task OnPartitionProcessingStoppedAsync(Azure.Messaging.EventHubs.Primitives.EventProcessorPartition partition, Azure.Messaging.EventHubs.Processor.ProcessingStoppedReason reason, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task OnProcessingErrorAsync(System.Exception exception, Azure.Messaging.EventHubs.Primitives.EventProcessorPartition partition, string operationDescription, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task OnProcessingEventBatchAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.EventData> events, Azure.Messaging.EventHubs.Primitives.EventProcessorPartition partition, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override void StartProcessing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override System.Threading.Tasks.Task StartProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override void StopProcessing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override System.Threading.Tasks.Task StopProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        protected override System.Threading.Tasks.Task UpdateCheckpointAsync(string partitionId, Azure.Messaging.EventHubs.Processor.CheckpointPosition startingPosition, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Checkpoints created from a numeric offset may not work in all cases going forward. Please use a string-based offset via the overload accepting 'CheckpointPosition' instead.", false)]
        protected override System.Threading.Tasks.Task UpdateCheckpointAsync(string partitionId, long offset, long? sequenceNumber, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task ValidateProcessingPreconditions(System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class EventProcessorClientOptions
    {
        public EventProcessorClientOptions() { }
        public int CacheEventCount { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.Processor.LoadBalancingStrategy LoadBalancingStrategy { get { throw null; } set { } }
        public System.TimeSpan LoadBalancingUpdateInterval { get { throw null; } set { } }
        public System.TimeSpan? MaximumWaitTime { get { throw null; } set { } }
        public System.TimeSpan PartitionOwnershipExpirationInterval { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public long? PrefetchSizeInBytes { get { throw null; } set { } }
        public Azure.Messaging.EventHubs.EventHubsRetryOptions RetryOptions { get { throw null; } set { } }
        public bool TrackLastEnqueuedEventProperties { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
}
namespace Azure.Messaging.EventHubs.Primitives
{
    public partial class BlobCheckpointStore : Azure.Messaging.EventHubs.Primitives.CheckpointStore
    {
        public BlobCheckpointStore(Azure.Storage.Blobs.BlobContainerClient blobContainerClient) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ClaimOwnershipAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership> desiredOwnership, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Messaging.EventHubs.Primitives.EventProcessorCheckpoint> GetCheckpointAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Primitives.EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Checkpoints created from a numeric offset may not work in all cases going forward. Please use a string-based offset via the overload accepting 'CheckpointPosition' instead.", false)]
        public override System.Threading.Tasks.Task UpdateCheckpointAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, long offset, long? sequenceNumber, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task UpdateCheckpointAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, string clientIdentifier, Azure.Messaging.EventHubs.Processor.CheckpointPosition startingPosition, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
