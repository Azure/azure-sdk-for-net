namespace Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents
{
    public static partial class EventGridPublisherClientExtensions
    {
        public static Azure.Response SendCloudEvents(this Azure.Messaging.EventGrid.EventGridPublisherClient client, System.Collections.Generic.IEnumerable<CloudNative.CloudEvents.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> SendCloudEventsAsync(this Azure.Messaging.EventGrid.EventGridPublisherClient client, System.Collections.Generic.IEnumerable<CloudNative.CloudEvents.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
