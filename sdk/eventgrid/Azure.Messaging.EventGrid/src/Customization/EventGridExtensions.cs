// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using Azure.Core.Serialization;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Extension methods for BinaryData to use for parsing JSON-encoded events.
    /// </summary>
    public static class EventGridExtensions
    {
        /// <summary>
        /// Given a single JSON-encoded event, parses the event envelope and returns an EventGridEvent.
        /// </summary>
        /// <param name="binaryData"> Specifies the instance of <see cref="BinaryData"/>. </param>
        /// <returns> An <see cref="EventGridEvent"/>. </returns>
        public static EventGridEvent ToEventGridEvent(this BinaryData binaryData)
        {
            // Deserialize JsonElement to single event, parse event envelope properties
            JsonDocument requestDocument = JsonDocument.Parse(binaryData.ToMemory());
            EventGridEventInternal egEventInternal = EventGridEventInternal.DeserializeEventGridEventInternal(requestDocument.RootElement);

            EventGridEvent egEvent = new EventGridEvent(egEventInternal);

            return egEvent;
        }

        /// <summary>
        /// Gets whether or not the event is a System defined event and returns the deserialized
        /// system event data via out parameter.
        /// </summary>
        /// <param name="cloudEvent"></param>
        /// <param name="eventData">If the event is a system event, this will be populated
        /// with the deserialized system event data. Otherwise, this will be null.</param>
        /// <returns> Whether or not the event is a system event.</returns>
        public static bool TryGetSystemEventData(this CloudEvent cloudEvent, out object eventData)
        {
            BinaryData data = cloudEvent.EventData;
            try
            {
                JsonDocument requestDocument = JsonDocument.Parse(data.ToMemory());
                eventData = SystemEventExtensions.AsSystemEventData(cloudEvent.Type, requestDocument.RootElement);
                return eventData != null;
            }
            catch
            {
                eventData = null;
                return false;
            }
        }
    }
}
