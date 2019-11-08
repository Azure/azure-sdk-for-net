namespace Azure.Messaging.EventHubs.CheckpointStore.Blobs
{
    public sealed partial class BlobPartitionManager : Azure.Messaging.EventHubs.Processor.PartitionManager
    {
        public BlobPartitionManager(Azure.Storage.Blobs.BlobContainerClient blobContainerClient, System.Action<string> logger = null) { }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership>> ClaimOwnershipAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership> partitionOwnership) { throw null; }
        public override System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Messaging.EventHubs.Processor.PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace, string eventHubName, string consumerGroup) { throw null; }
        public override System.Threading.Tasks.Task UpdateCheckpointAsync(Azure.Messaging.EventHubs.Processor.Checkpoint checkpoint) { throw null; }
    }
}
