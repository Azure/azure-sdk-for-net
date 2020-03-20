namespace Azure.Messaging.EventHubs
{
    public partial class EventProcessorClient
    {
        protected EventProcessorClient() { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string connectionString) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string connectionString, Azure.Messaging.EventHubs.EventProcessorClientOptions clientOptions) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string connectionString, string eventHubName) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string fullyQualifiedNamespace, string eventHubName, Azure.Core.TokenCredential credential, Azure.Messaging.EventHubs.EventProcessorClientOptions clientOptions = null) { }
        public EventProcessorClient(Azure.Storage.Blobs.BlobContainerClient checkpointStore, string consumerGroup, string connectionString, string eventHubName, Azure.Messaging.EventHubs.EventProcessorClientOptions clientOptions) { }
        public string ConsumerGroup { get { throw null; } }
        public string EventHubName { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public bool IsRunning { get { throw null; } protected set { } }
        public event System.Func<Azure.Messaging.EventHubs.Processor.PartitionClosingEventArgs, System.Threading.Tasks.Task> PartitionClosingAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.EventHubs.Processor.PartitionInitializingEventArgs, System.Threading.Tasks.Task> PartitionInitializingAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.EventHubs.Processor.ProcessErrorEventArgs, System.Threading.Tasks.Task> ProcessErrorAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.EventHubs.Processor.ProcessEventArgs, System.Threading.Tasks.Task> ProcessEventAsync { add { } remove { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual void StartProcessing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task StartProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void StopProcessing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task StopProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class EventProcessorClientOptions
    {
        public EventProcessorClientOptions() { }
        public Azure.Messaging.EventHubs.EventHubConnectionOptions ConnectionOptions { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public System.TimeSpan? MaximumWaitTime { get { throw null; } set { } }
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
