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
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CloudEvent = CloudNative.CloudEvents.CloudEvent;

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
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
        /// <param name="cloudEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public static Response SendCloudEvents(
            this EventGridPublisherClient client,
            IEnumerable<CloudEvent> cloudEvents,
            CancellationToken cancellationToken = default) =>
            SendCloudEventsInternalAsync(client, cloudEvents, false, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="client">The <see cref="EventGridPublisherClient"/> instance to extend.</param>
        /// <param name="cloudEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public static async Task<Response> SendCloudEventsAsync(
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
            if (currentActivity != null && currentActivity.IsW3CFormat())
            {
                activityId = currentActivity.Id;
                currentActivity.TryGetTraceState(out traceState);
            }

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (var cloudEvent in cloudEvents)
            {
                var attributes = cloudEvent.GetAttributes();
                if (activityId != null &&
                        !attributes.ContainsKey(TraceParentHeaderName) &&
                        !attributes.ContainsKey(TraceStateHeaderName))
                {
                    attributes.Add(TraceParentHeaderName, activityId);
                    if (traceState != null)
                    {
                        attributes.Add(TraceStateHeaderName, traceState);
                    }
                }

                byte[] bytes = s_eventFormatter.EncodeStructuredEvent(cloudEvent, out var _);
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
