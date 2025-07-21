// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid
{
    /// <summary> Properties of an event published to an Event Grid topic using the EventGrid Schema. </summary>
    [JsonConverter(typeof(EventGridEventConverter))]
    public class EventGridEvent
    {
        /// <summary> Initializes a new instance of <see cref="EventGridEvent"/>. </summary>
        /// <param name="subject"> A resource path relative to the topic path. </param>
        /// <param name="eventType"> The type of the event that occurred. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="dataVersion"> The schema version of the data object. </param>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="dataSerializationType">The type to use when serializing the data.
        /// If not specified, <see cref="object.GetType()"/> will be used on <paramref name="data"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="subject"/>, <paramref name="data"/>, <paramref name="eventType"/>, or <paramref name="dataVersion"/> was null.
        /// </exception>
        public EventGridEvent(string subject, string eventType, string dataVersion, object data, Type dataSerializationType = default)
        {
            Argument.AssertNotNull(subject, nameof(subject));
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(eventType, nameof(eventType));
            Argument.AssertNotNull(dataVersion, nameof(dataVersion));
            if (data is BinaryData)
            {
                throw new InvalidOperationException("This constructor does not support BinaryData. Use the constructor that takes a BinaryData instance.");
            }

            DataSerializationType = dataSerializationType ?? data?.GetType() ?? null;
            Subject = subject;
            Data = new BinaryData(data, type: dataSerializationType ?? data?.GetType());
            EventType = eventType;
            DataVersion = dataVersion;
        }

        /// <summary> Initializes a new instance of <see cref="EventGridEvent"/>. </summary>
        /// <param name="subject"> A resource path relative to the topic path. </param>
        /// <param name="eventType"> The type of the event that occurred. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="dataVersion"> The schema version of the data object. </param>
        /// <param name="data"> Pre-serialized JSON event data specific to the event type. </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="subject"/>, <paramref name="data"/>, <paramref name="eventType"/>, or <paramref name="dataVersion"/> was null.
        /// </exception>
        public EventGridEvent(string subject, string eventType, string dataVersion, BinaryData data)
        {
            Argument.AssertNotNull(subject, nameof(subject));
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(eventType, nameof(eventType));
            Argument.AssertNotNull(dataVersion, nameof(dataVersion));

            Subject = subject;
            EventType = eventType;
            DataVersion = dataVersion;
            Data = data;
        }

        internal EventGridEvent(EventGridEventInternal eventGridEventInternal)
        {
            Argument.AssertNotNull(eventGridEventInternal.Subject, nameof(eventGridEventInternal.Subject));
            Argument.AssertNotNull(eventGridEventInternal.EventType, nameof(eventGridEventInternal.EventType));
            Argument.AssertNotNull(eventGridEventInternal.DataVersion, nameof(eventGridEventInternal.DataVersion));
            Argument.AssertNotNull(eventGridEventInternal.Id, nameof(eventGridEventInternal.Id));

            Subject = eventGridEventInternal.Subject;
            EventType = eventGridEventInternal.EventType;
            DataVersion = eventGridEventInternal.DataVersion;
            EventTime = eventGridEventInternal.EventTime;
            Id = eventGridEventInternal.Id;
            Topic = eventGridEventInternal.Topic;
            Data = new BinaryData(eventGridEventInternal.Data);
        }

        /// <summary>
        /// Gets or sets the event payload as <see cref="BinaryData"/>. Using BinaryData,
        /// one can deserialize the payload into rich data, or access the raw JSON data using <see cref="BinaryData.ToString()"/>.
        /// </summary>
        public BinaryData Data { get; set; }

        /// <summary> Gets or sets a unique identifier for the event. </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>Gets or sets the resource path of the event source.
        /// This must be set when publishing the event to a domain, and must not be set when publishing the event to a topic.
        /// </summary>
        public string Topic { get; set; }
        internal Type DataSerializationType { get; }

        /// <summary>Gets or sets a resource path relative to the topic path.</summary>
        public string Subject { get; set; }

        /// <summary>Gets or sets the type of the event that occurred.</summary>
        public string EventType { get; set; }

        /// <summary>Gets or sets the time (in UTC) the event was generated.</summary>
        public DateTimeOffset EventTime { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>Gets or sets the schema version of the data object.</summary>
        public string DataVersion { get; set; }

        /// <summary>
        /// Gets whether or not the event is a System defined event and returns the deserialized
        /// system event via out parameter.
        /// </summary>
        /// <param name="eventData">If the event is a system event, this will be populated
        /// with the deserialized system event. Otherwise, this will be null.</param>
        /// <returns> Whether or not the event is a system event.</returns>
        public bool TryGetSystemEventData(out object eventData)
        {
            // the property can be set to null after the creation of the event.
            if (Data == null)
            {
                eventData = null;
                return false;
            }

            // We use a dummy CloudEvent to deserialize the system event data. This is necessary so that we can
            // avoid maintaining two sets of system events in both Azure.Messaging.EventGrid and Azure.Messaging.EventGrid.SystemEvents
            // libraries.
            var cloudEvent = new CloudEvent("source", EventType, Data, null, CloudEventDataFormat.Json);
            return cloudEvent.TryGetSystemEventData(out eventData);
        }

        /// <summary>
        /// Given JSON-encoded events, parses the event envelope and returns an array of EventGridEvents.
        /// If the content is not valid JSON, or events are missing required properties, an exception is thrown.
        /// </summary>
        /// <param name="json">An instance of <see cref="BinaryData"/> containing the JSON for one or more EventGridEvents.</param>
        /// <returns> An array of <see cref="EventGridEvent"/> instances.</returns>
        public static EventGridEvent[] ParseMany(BinaryData json)
        {
            Argument.AssertNotNull(json, nameof(json));

            EventGridEvent[] egEvents = null;
            using JsonDocument requestDocument = JsonDocument.Parse(json);

            // Parse JsonElement into separate events, deserialize event envelope properties
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                egEvents = new EventGridEvent[1];
                egEvents[0] = (new EventGridEvent(EventGridEventInternal.DeserializeEventGridEventInternal(requestDocument.RootElement)));
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                egEvents = new EventGridEvent[requestDocument.RootElement.GetArrayLength()];
                int i = 0;
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    egEvents[i++] = new EventGridEvent(EventGridEventInternal.DeserializeEventGridEventInternal(property));
                }
            }
            return egEvents ?? [];
        }

        /// <summary>
        /// Given a single JSON-encoded event, parses the event envelope and returns an EventGridEvent.
        /// If the specified event is not valid JSON, or the event is missing required properties, an exception is thrown.
        /// </summary>
        /// <param name="json">An instance of <see cref="BinaryData"/> containing the JSON for the EventGridEvent.</param>
        /// <returns> An <see cref="EventGridEvent"/>. </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="json"/> contained multiple events. <see cref="ParseMany"/> should be used instead.
        /// </exception>
        public static EventGridEvent Parse(BinaryData json)
        {
            Argument.AssertNotNull(json, nameof(json));
            EventGridEvent[] events = ParseMany(json);
            return events.Length switch
            {
                0 => null,
                > 1 => throw new ArgumentException(
                    "The BinaryData instance contains JSON from multiple event grid events. This method " +
                    "should only be used with BinaryData containing a single event grid event. " + Environment.NewLine +
                    $"To parse multiple events, use the {nameof(ParseMany)} overload."),
                _ => events[0]
            };
        }
    }
}
