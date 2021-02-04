// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid
{
    /// <summary> Properties of an event published to an Event Grid topic using the EventGrid Schema. </summary>
    public class EventGridEvent
    {
        /// <summary> Initializes a new instance of <see cref="EventGridEvent"/>. </summary>
        /// <param name="subject"> A resource path relative to the topic path. </param>
        /// <param name="eventType"> The type of the event that occurred. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="dataVersion"> The schema version of the data object. </param>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="dataSerializationType">The type to use when serializing the data.
        /// If not specified, <see cref="object.GetType()"/> will be used on <paramref name="data"/>.</param>
        public EventGridEvent(string subject, string eventType, string dataVersion, object data, Type dataSerializationType = default)
        {
            Argument.AssertNotNull(subject, nameof(subject));
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(eventType, nameof(eventType));
            Argument.AssertNotNull(dataVersion, nameof(dataVersion));

            DataSerializationType = dataSerializationType ?? data?.GetType() ?? null;
            Subject = subject;
            Data = data;
            EventType = eventType;
            DataVersion = dataVersion;
        }

        internal EventGridEvent(EventGridEventInternal eventGridEventInternal)
        {
            Argument.AssertNotNull(eventGridEventInternal.Subject, nameof(eventGridEventInternal.Subject));
            Argument.AssertNotNull(eventGridEventInternal.EventType, nameof(eventGridEventInternal.EventType));
            Argument.AssertNotNull(eventGridEventInternal.DataVersion, nameof(eventGridEventInternal.DataVersion));
            Argument.AssertNotNull(eventGridEventInternal.Id, nameof(eventGridEventInternal.Id));

            Subject = eventGridEventInternal.Subject;
            SerializedData = eventGridEventInternal.Data;
            EventType = eventGridEventInternal.EventType;
            DataVersion = eventGridEventInternal.DataVersion;
            EventTime = eventGridEventInternal.EventTime;
            Id = eventGridEventInternal.Id;
            Topic = eventGridEventInternal.Topic;
        }

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

        /// <summary>Gets or sets the event data specific to the event type.</summary>
        internal object Data { get; set; }

        /// <summary>Gets or sets the serialized event data specific to the event type.</summary>
        internal JsonElement SerializedData { get; set; }

        private static readonly JsonObjectSerializer s_jsonSerializer = new JsonObjectSerializer();

        /// <summary>
        /// Gets whether or not the event is a System defined event and returns the deserialized
        /// system event via out parameter.
        /// </summary>
        /// <param name="eventData">If the event is a system event, this will be populated
        /// with the deserialized system event. Otherwise, this will be null.</param>
        /// <returns> Whether or not the event is a system event.</returns>
        public bool TryGetSystemEventData(out object eventData)
        {
            eventData = SystemEventExtensions.AsSystemEventData(EventType, SerializedData);
            return eventData != null;
        }

        /// <summary>
        /// Given JSON-encoded events, parses the event envelope and returns an array of EventGridEvents.
        /// </summary>
        /// <param name="requestContent"> The JSON-encoded representation of either a single event or an array or events,
        /// encoded in the EventGridEvent schema. </param>
        /// <returns> A list of <see cref="EventGridEvent"/>. </returns>
        public static EventGridEvent[] Parse(string requestContent)
        {
            Argument.AssertNotNull(requestContent, nameof(requestContent));

            EventGridEvent[] egEvents = null;
            JsonDocument requestDocument = JsonDocument.Parse(requestContent);

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
            return egEvents ?? Array.Empty<EventGridEvent>();
        }

        /// <summary>
        /// Deserializes the event payload into a specified event type using the default serializer, <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T"> Type of event to deserialize to. </typeparam>
        /// <param name="cancellationToken"> The cancellation token to use during deserialization. </param>
        /// <exception cref="InvalidOperationException"> Event was not created from EventGridEvent.Parse() method. </exception>
        /// <exception cref="InvalidCastException"> Event payload cannot be cast to the specified event type. </exception>
        /// <returns> Deserialized payload of the event, cast to the specified type. </returns>
        public T GetData<T>(CancellationToken cancellationToken = default) =>
            GetDataInternal<T>(s_jsonSerializer, false, cancellationToken).EnsureCompleted();

        private async Task<T> GetDataInternal<T>(ObjectSerializer serializer, bool async, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));

            if (Data != null)
            {
                return (T)Data;
            }
            else if (SystemEventExtensions.SystemEventDeserializers.TryGetValue(EventType, out Func<JsonElement, object> systemDeserializationFunction))
            {
                return (T)systemDeserializationFunction(SerializedData);
            }
            else
            {
                using (MemoryStream dataStream = SerializePayloadToStream(SerializedData, cancellationToken))
                {
                    if (async)
                    {
                        return (T)await serializer.DeserializeAsync(dataStream, typeof(T), cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        return (T)serializer.Deserialize(dataStream, typeof(T), cancellationToken);
                    }
                }
            }
        }

        /// <summary>
        /// Deserializes the event payload into a system event type or
        /// returns the payload of the event wrapped as <see cref="BinaryData"/>. Using BinaryData,
        /// one can deserialize the payload into rich data, or access the raw JSON data using <see cref="BinaryData.ToString()"/>.
        /// </summary>
        /// <returns>
        /// Deserialized payload of the event.
        /// Returns <see cref="BinaryData"/> for unknown event types.
        /// </returns>
        public BinaryData GetData() =>
            GetDataInternal();

        private BinaryData GetDataInternal()
        {
            if (Data != null)
            {
                return new BinaryData(Data, type: DataSerializationType);
            }
            else
            {
                return BinaryData.FromStream(SerializePayloadToStream(SerializedData));
            }
        }

        private static MemoryStream SerializePayloadToStream(JsonElement payload, CancellationToken cancellationToken = default)
        {
            MemoryStream dataStream = new MemoryStream();
            s_jsonSerializer.Serialize(dataStream, payload, payload.GetType(), cancellationToken);
            dataStream.Position = 0;
            return dataStream;
        }
    }
}
