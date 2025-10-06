// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

// This is intentionally in the Azure.Messaging.EventGrid namespace to support type forwarding
namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Extension methods for BinaryData to use for parsing JSON-encoded events.
    /// </summary>
    public static class EventGridExtensions
    {
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
            BinaryData data = cloudEvent.Data;
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
