// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// <summary> Properties of an event published to an Event Grid topic using the CloudEvent 1.0 Schema. </summary>
    public class CloudEvent
    {
        /// <summary> Initializes a new instance of the <see cref="CloudEvent"/> class. </summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. </param>
        public CloudEvent(string source, string type)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));

            Source = source;
            Type = type;
            ExtensionAttributes = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudEvent"/> class.
        /// </summary>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. </param>
        public CloudEvent(object data, string source, string type)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));
            Argument.AssertNotNull(data, nameof(data));

            Source = source;
            Type = type;
            Data = data;
            ExtensionAttributes = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudEvent"/> class.
        /// </summary>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. </param>
        public CloudEvent(BinaryData data, string source, string type)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));

            Source = source;
            Type = type;
            DataBase64 = data.Bytes.ToArray();
            ExtensionAttributes = new Dictionary<string, object>();
        }

        /// <summary> An identifier for the event. The combination of id and source must be unique for each distinct event. </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </summary>
        public string Source { get; set; }

        /// <summary> Deserialized system event data, null if data is custom event payload. </summary>
        public object SystemData { get; set; }

        /// <summary> Deserialized event data specific to the event type. </summary>
        internal object Data { get; set; }

        /// <summary> Custom serializer used to deserialize the payload. </summary>
        internal ObjectSerializer DataSerializer { get; set; }

        /// <summary> Serialized event data specific to the event type. </summary>
        internal JsonElement? SerializedData { get; set; }

        /// <summary> Event data specific to the event type, encoded as a base64 string. </summary>
        internal byte[] DataBase64 { get; set; }

        /// <summary> Type of event related to the originating occurrence. </summary>
        public string Type { get; set; }

        /// <summary> The time (in UTC) the event was generated, in RFC3339 format. </summary>
        public DateTimeOffset? Time { get; set; } = DateTimeOffset.UtcNow;

        /// <summary> Identifies the schema that data adheres to. </summary>
        public string DataSchema { get; set; }

        /// <summary> Content type of data value. </summary>
        public string DataContentType { get; set; }

        /// <summary> This describes the subject of the event in the context of the event producer (identified by source). </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Extension attributes that can be additionally added to the CloudEvent envelope.
        /// </summary>
        public Dictionary<string, object> ExtensionAttributes { get; }

        /// <summary>
        /// Parses JSON encoded events and returns an array of events encoded in the CloudEvent schema.
        /// </summary>
        /// <param name="requestContent"> The JSON encoded representation of either a single event or an array or events, encoded in the CloudEvent schema. </param>
        /// <returns> A list of CloudEvents. </returns>
        public static CloudEvent[] Parse(string requestContent)
            => Parse(requestContent, new JsonObjectSerializer());

        /// <summary>
        /// Parses JSON encoded events and returns an array of events encoded in the CloudEvent schema.
        /// </summary>
        /// <param name="requestContent"> The JSON encoded representation of either a single event or an array or events, encoded in the CloudEvent schema. </param>
        /// /// <param name="dataSerializer"> Custom serializer used to deserialize the payload. Note: the serializer will not be used when parsing the event from JSON. </param>
        /// <returns> A list of CloudEvents. </returns>
        public static CloudEvent[] Parse(string requestContent, ObjectSerializer dataSerializer)
        {
            List<CloudEventInternal> cloudEventsInternal = new List<CloudEventInternal>();
            List<CloudEvent> cloudEvents = new List<CloudEvent>();

            // Parse raw JSON string into separate events, deserialize event envelope properties
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            JsonDocument requestDocument = JsonDocument.Parse(stream);
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                cloudEventsInternal.Add(CloudEventInternal.DeserializeCloudEventInternal(requestDocument.RootElement));
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    cloudEventsInternal.Add(CloudEventInternal.DeserializeCloudEventInternal(property));
                }
            }

            // Try to deserialize if system event data, otherwise set the serialized data property
            foreach (CloudEventInternal cloudEventInternal in cloudEventsInternal)
            {
                if (cloudEventInternal.Type == null) // case where data/type is null?
                {
                    cloudEventInternal.Type = "";
                }

                CloudEvent cloudEvent = new CloudEvent(
                    cloudEventInternal.Source,
                    cloudEventInternal.Type)
                {
                    Id = cloudEventInternal.Id,
                    Time = cloudEventInternal.Time,
                    DataBase64 = cloudEventInternal.DataBase64,
                    DataSchema = cloudEventInternal.Dataschema,
                    DataContentType = cloudEventInternal.Datacontenttype,
                    Subject = cloudEventInternal.Subject,
                    DataSerializer = dataSerializer ?? new JsonObjectSerializer()
                };

                if (cloudEventInternal.Data.HasValue && cloudEventInternal.Data.Value.ValueKind != JsonValueKind.Null)
                {
                    if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(cloudEventInternal.Type, out Func<JsonElement, object> systemDeserializationFunction))
                    {
                        cloudEvent.SystemData = systemDeserializationFunction(cloudEventInternal.Data.Value);
                    }
                    else
                    {
                        cloudEvent.SerializedData = cloudEventInternal.Data.Value;
                    }
                }
                else // Event has null data
                {
                    cloudEvent.SerializedData = null;
                }

                cloudEvents.Add(cloudEvent);
            }

            return cloudEvents.ToArray();
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
            else if (SerializedData.HasValue && SerializedData.Value.ValueKind != JsonValueKind.Null)
            {
                // Try to deserialize if system event data
                if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(Type, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    Data = systemDeserializationFunction(SerializedData.Value);
                }
                else if (!TryGetPrimitiveFromJsonElement(SerializedData.Value, out object cloudEventData))
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
            else // Both Data and SerializedData is null
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to deserialize the event payload into a system event type or as binary data.
        /// </summary>
        /// <returns> Deserialized payload of the event. </returns>
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
            else if (DataBase64 != null)
            {
                return new BinaryData(DataBase64);
            }
            else if (SerializedData.HasValue && SerializedData.Value.ValueKind != JsonValueKind.Null) // data is stored as JsonElement
            {
                return BinaryData.FromStream(SerializePayloadToStream(SerializedData, new JsonObjectSerializer()));
            }
            else
            {
                return new BinaryData();
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
