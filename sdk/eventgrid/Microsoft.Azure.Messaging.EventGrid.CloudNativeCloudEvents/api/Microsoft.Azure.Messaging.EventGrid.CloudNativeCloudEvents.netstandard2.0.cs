namespace Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents
{
    public static partial class EventGridPublisherClientExtensions
    {
        public static Azure.Response SendCloudNativeCloudEvent(this Azure.Messaging.EventGrid.EventGridPublisherClient client, CloudNative.CloudEvents.CloudEvent cloudEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> SendCloudNativeCloudEventAsync(this Azure.Messaging.EventGrid.EventGridPublisherClient client, CloudNative.CloudEvents.CloudEvent cloudEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response SendCloudNativeCloudEvents(this Azure.Messaging.EventGrid.EventGridPublisherClient client, System.Collections.Generic.IEnumerable<CloudNative.CloudEvents.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> SendCloudNativeCloudEventsAsync(this Azure.Messaging.EventGrid.EventGridPublisherClient client, System.Collections.Generic.IEnumerable<CloudNative.CloudEvents.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
