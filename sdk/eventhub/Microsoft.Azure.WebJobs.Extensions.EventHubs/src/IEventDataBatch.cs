using Azure.Messaging.EventHubs;

namespace Microsoft.Azure.WebJobs
{
    /// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/9117 is fixed
    internal interface IEventDataBatch
    {
        int Count { get; }
        long MaximumSizeInBytes { get; }
        bool TryAdd(EventData eventData);
    }
}