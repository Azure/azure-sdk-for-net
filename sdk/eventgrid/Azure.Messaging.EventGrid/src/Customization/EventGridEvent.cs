// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        /// <summary> Initializes a new instance of EventGridEvent. </summary>
        /// <param name="subject"> A resource path relative to the topic path. </param>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="eventType"> The type of the event that occurred. </param>
        /// <param name="dataVersion"> The schema version of the data object. </param>
        public EventGridEvent(object data, string subject, string eventType, string dataVersion)
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

        /// <summary> Initializes a new instance of EventGridEvent. </summary>
        /// <param name="subject"> A resource path relative to the topic path. </param>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="eventType"> The type of the event that occurred. </param>
        /// <param name="dataVersion"> The schema version of the data object. </param>
        public EventGridEvent(BinaryData data, string subject, string eventType, string dataVersion)
        {
            Argument.AssertNotNull(subject, nameof(subject));
            Argument.AssertNotNull(eventType, nameof(eventType));
            Argument.AssertNotNull(dataVersion, nameof(dataVersion));

            Subject = subject;
            Data = data;
            EventType = eventType;
            DataVersion = dataVersion;
        }

        internal EventGridEvent()
        {
        }

        /// <summary> An unique identifier for the event. </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary> The resource path of the event source. </summary>
        public string Topic { get; set; }

        /// <summary> A resource path relative to the topic path. </summary>
        public string Subject { get; internal set; }

        /// <summary> Deserialized system event data, null if data is custom event payload. </summary>
        public object SystemData { get; set; }

        /// <summary> Event data specific to the event type. </summary>
        internal object Data { get; set; }

        /// <summary> Serialized event data specific to the event type. </summary>
        internal JsonElement SerializedData { get; set; }

        /// <summary> Custom serializer used to deserialize the payload. </summary>
        internal ObjectSerializer DataSerializer { get; set; }

        /// <summary> The type of the event that occurred. </summary>
        public string EventType { get; set; }

        /// <summary> The time (in UTC) the event was generated. </summary>
        public DateTimeOffset EventTime { get; set; } = DateTimeOffset.UtcNow;

        /// <summary> The schema version of the data object. </summary>
        public string DataVersion { get; set; }

        /// <summary>
        /// Parses JSON encoded events and returns an array of events encoded in the EventGridEvent schema.
        /// </summary>
        /// <param name="requestContent"> The JSON encoded representation of either a single event or an array or events, encoded in the EventGridEvent schema. </param>
        /// <returns> A list of EventGridEvents. </returns>
        public static EventGridEvent[] Parse(string requestContent)
            => Parse(requestContent, new JsonObjectSerializer());

        /// <summary>
        /// Parses JSON encoded events and returns an array of events encoded in the EventGridEvent schema.
        /// </summary>
        /// <param name="requestContent"> The JSON encoded representation of either a single event or an array or events, encoded in the EventGridEvent schema. </param>
        /// <param name="dataSerializer"> Custom serializer used to deserialize the payload. Note: the serializer will not be used when parsing the event from JSON. </param>
        /// <returns> A list of EventGridEvents. </returns>
        public static EventGridEvent[] Parse(string requestContent, ObjectSerializer dataSerializer)
        {
            List<EventGridEventInternal> egEventsInternal = new List<EventGridEventInternal>();
            List<EventGridEvent> egEvents = new List<EventGridEvent>();

            // Parse raw JSON string into separate events, deserialize event envelope properties
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            JsonDocument requestDocument = JsonDocument.Parse(stream);
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                egEventsInternal.Add(EventGridEventInternal.DeserializeEventGridEventInternal(requestDocument.RootElement));
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    egEventsInternal.Add(EventGridEventInternal.DeserializeEventGridEventInternal(property));
                }
            }

            // Try to deserialize if system event data, otherwise set the serialized data property
            foreach (EventGridEventInternal egEventInternal in egEventsInternal)
            {
                EventGridEvent egEvent = new EventGridEvent()
                {
                    Subject = egEventInternal.Subject,
                    EventType = egEventInternal.EventType,
                    DataVersion = egEventInternal.DataVersion,
                    Id = egEventInternal.Id,
                    EventTime = egEventInternal.EventTime,
                    DataSerializer = dataSerializer ?? new JsonObjectSerializer()
                };

                if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(egEventInternal.EventType, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    egEvent.SystemData = systemDeserializationFunction(egEventInternal.Data);
                }
                else
                {
                    egEvent.SerializedData = egEventInternal.Data;
                }
                egEvents.Add(egEvent);
            }

            return egEvents.ToArray();
        }

        /// <summary>
        /// Deserializes the event payload into a specified event type.
        /// </summary>
        /// <typeparam name="T"> Describing the type of the event. </typeparam>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Deserialized payload of the event. </returns>
        public async Task<T> GetDataAsync<T>(CancellationToken cancellationToken = default)
            => await GetDataInternal<T>(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deserializes the event payload into a specified event type.
        /// </summary>
        /// <typeparam name="T"> Describing the type of the event. </typeparam>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Deserialized payload of the event. </returns>
        public T GetData<T>(CancellationToken cancellationToken = default)
            => GetDataInternal<T>(false, cancellationToken).EnsureCompleted();

        private async Task<T> GetDataInternal<T>(bool async, CancellationToken cancellationToken = default)
        {
            if (Data != null)
            {
                return (T)Data;
            }
            else if (SystemData != null)
            {
                return (T)SystemData;
            }
            else
            {
                // Try to deserialize if system event data
                if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(EventType, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    Data = systemDeserializationFunction(SerializedData);
                }
                else if (!TryGetPrimitiveFromJsonElement(SerializedData, out object cloudEventData))
                {
                    // Reserialize JsonElement to stream
                    MemoryStream dataStream = SerializePayloadToStream(SerializedData, new JsonObjectSerializer(), cancellationToken);

                    if (async)
                    {
                        Data = await DataSerializer.DeserializeAsync(dataStream, typeof(T), cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        Data = DataSerializer.Deserialize(dataStream, typeof(T), cancellationToken);
                    }
                }
                else // Data is a string/primitive
                {
                    Data = cloudEventData;
                }
                return (T)Data;
            }
        }

        /// <summary>
        /// Returns payload of the event wrapped as BinaryData.
        /// </summary>
        /// <returns> Payload of the event wrapped as BinaryData. </returns>
        public BinaryData GetData()
        {
            if (Data != null)
            {
                return BinaryData.Serialize(Data);
            }
            else if (SystemData != null)
            {
                return BinaryData.Serialize(SystemData);
            }
            else // data is stored as JsonElement
            {
                return BinaryData.FromStream(SerializePayloadToStream(SerializedData, new JsonObjectSerializer()));
            }
        }

        private static MemoryStream SerializePayloadToStream(object payload, ObjectSerializer serializer, CancellationToken cancellationToken = default)
        {
            MemoryStream dataStream = new MemoryStream();
            serializer.Serialize(dataStream, payload, payload.GetType(), cancellationToken);
            dataStream.Position = 0;
            return dataStream;
        }

        private static bool TryGetPrimitiveFromJsonElement(JsonElement jsonElement, out object elementValue)
        {
            elementValue = null;
            if (jsonElement.ValueKind == JsonValueKind.True || jsonElement.ValueKind == JsonValueKind.False)
            {
                elementValue = jsonElement.GetBoolean();
            }
            else if (jsonElement.ValueKind == JsonValueKind.Number)
            {
                if (jsonElement.TryGetInt32(out var vali))
                {
                    elementValue = vali;
                }
                if (jsonElement.TryGetInt64(out var vall))
                {
                    elementValue = vall;
                }
                if (jsonElement.TryGetDouble(out var val))
                {
                    elementValue = val;
                }
            }
            else if (jsonElement.ValueKind == JsonValueKind.String)
            {
                elementValue = jsonElement.GetString();
            }
            else if (jsonElement.ValueKind == JsonValueKind.Undefined)
            {
                elementValue = "";
            }

            return elementValue != null;
        }
    }
}
