// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventGrid;
using CloudNative.CloudEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CloudNative.CloudEvents.SystemTextJson;
using CloudEvent = CloudNative.CloudEvents.CloudEvent;

namespace Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents
{
    /// <summary>
    /// This class contains extension methods to enable usage of the CloudNative.CloudEvent
    /// library with the Azure Event Grid library.
    /// </summary>
    public static class EventGridPublisherClientExtensions
    {
        private static readonly JsonEventFormatter s_eventFormatter = new JsonEventFormatter();
        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="client">The <see cref="EventGridPublisherClient"/> instance to extend.</param>
        /// <param name="cloudEvent"> The event to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public static Response SendCloudNativeCloudEvent(
            this EventGridPublisherClient client,
            CloudEvent cloudEvent,
            CancellationToken cancellationToken = default) =>
            SendCloudNativeCloudEvents(client, new CloudEvent[] { cloudEvent }, cancellationToken);

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="client">The <see cref="EventGridPublisherClient"/> instance to extend.</param>
        /// <param name="cloudEvent"> The event to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public static async Task<Response> SendCloudNativeCloudEventAsync(
            this EventGridPublisherClient client,
            CloudEvent cloudEvent,
            CancellationToken cancellationToken = default) =>
            await SendCloudNativeCloudEventsAsync(client, new CloudEvent[] { cloudEvent }, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="client">The <see cref="EventGridPublisherClient"/> instance to extend.</param>
        /// <param name="cloudEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public static Response SendCloudNativeCloudEvents(
            this EventGridPublisherClient client,
            IEnumerable<CloudEvent> cloudEvents,
            CancellationToken cancellationToken = default) =>
            SendCloudEventsInternalAsync(client, cloudEvents, false, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="client">The <see cref="EventGridPublisherClient"/> instance to extend.</param>
        /// <param name="cloudEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public static async Task<Response> SendCloudNativeCloudEventsAsync(
            this EventGridPublisherClient client,
            IEnumerable<CloudEvent> cloudEvents,
            CancellationToken cancellationToken = default) =>
            await SendCloudEventsInternalAsync(client, cloudEvents, true, cancellationToken).ConfigureAwait(false);

        private static async Task<Response> SendCloudEventsInternalAsync(
            EventGridPublisherClient client,
            IEnumerable<CloudEvent> cloudEvents,
            bool async,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            string activityId = null;
            string traceState = null;
            Activity currentActivity = Activity.Current;
            if (currentActivity != null && (currentActivity.IdFormat == ActivityIdFormat.W3C))
            {
                activityId = currentActivity.Id;
                traceState = currentActivity.TraceStateString;
            }

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (var cloudEvent in cloudEvents)
            {
                if (activityId != null &&
                    !cloudEvent.GetPopulatedAttributes().Any(
                        pair => pair.Key.Name is TraceParentHeaderName or TraceStateHeaderName))
                {
                    cloudEvent.SetAttributeFromString(TraceParentHeaderName, activityId);
                    if (traceState != null)
                    {
                        cloudEvent.SetAttributeFromString(TraceStateHeaderName, traceState);
                    }
                }

                ReadOnlyMemory<byte> bytes = s_eventFormatter.EncodeStructuredModeMessage(cloudEvent, out var _);
                using JsonDocument document = JsonDocument.Parse(bytes);
                document.RootElement.WriteTo(writer);
            }
            writer.WriteEndArray();
            writer.Flush();
            if (async)
            {
                return await client.SendEncodedCloudEventsAsync(stream.GetBuffer().AsMemory(0, (int)stream.Position), cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return client.SendEncodedCloudEvents(stream.GetBuffer().AsMemory(0, (int)stream.Position), cancellationToken);
            }
        }
    }
}
