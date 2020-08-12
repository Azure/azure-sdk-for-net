// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventGrid
{
    /// <summary> Properties of an event published to an Event Grid topic using the EventGrid Schema. </summary>
    public class EventGridEvent
    {
        /// <summary> Initializes a new instance of EventGridEvent. </summary>
        /// <param name="subject"> A resource path relative to the topic path. </param>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="eventType"> The type of the event that occurred. </param>
        /// <param name="dataVersion"> The schema version of the data object. </param>
        public EventGridEvent(string subject, object data, string eventType, string dataVersion)
        {
            Argument.AssertNotNull(subject, nameof(subject));
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(eventType, nameof(eventType));
            Argument.AssertNotNull(dataVersion, nameof(dataVersion));

            Subject = subject;
            Data = data;
            EventType = eventType;
            DataVersion = dataVersion;
        }

        /// <summary> An unique identifier for the event. </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary> The resource path of the event source. </summary>
        public string Topic { get; set; }

        /// <summary> A resource path relative to the topic path. </summary>
        public string Subject { get; set; }

        /// <summary> Event data specific to the event type. </summary>
        public object Data { get; set; }

        /// <summary> The type of the event that occurred. </summary>
        public string EventType { get; set; }

        /// <summary> The time (in UTC) the event was generated. </summary>
        public DateTimeOffset EventTime { get; set; } = DateTimeOffset.UtcNow;

        /// <summary> The schema version of the data object. </summary>
        public string DataVersion { get; set; }
    }
}
