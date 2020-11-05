// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        /// <summary> Initializes a new instance of the <see cref="CloudEvent"/> class.
        /// If the format and encoding of the data is not a JSON value, consider specifying the content type
        /// of the payload in <see cref="DataContentType"/>. For example, if passing in an XML payload, the
        /// consumer can be informed by this attribute being set to "application/xml".
        /// If the content type is omitted, then it is implied that the data is a JSON value conforming to the
        /// "application/json" media type. </summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="dataContentType"> Content type of the payload. A content type different from "application/json" should be specified if payload is not JSON. </param>
        public CloudEvent(string source, string type, object data, string dataContentType = default)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));
            Argument.AssertNotNull(data, nameof(data));

            Source = source;
            Type = type;
            DataContentType = dataContentType;

            if (data is IEnumerable<byte> enumerable)
            {
                DataBase64 = enumerable.ToArray();
            }
            else if (data is ReadOnlyMemory<byte> memory)
            {
                DataBase64 = memory.ToArray();
            }
            else
            {
                Data = data;
            }
            ExtensionAttributes = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudEvent"/> class.
        /// </summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="dataContentType"> Content type of the payload. A content type different from "application/json" should be specified when sending binary data. </param>
        public CloudEvent(string source, string type, BinaryData data, string dataContentType = default)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));

            Source = source;
            Type = type;
            DataContentType = dataContentType;
            DataBase64 = data.ToBytes().ToArray();
            ExtensionAttributes = new Dictionary<string, object>();
        }

        internal CloudEvent(string id, string source, string type, DateTimeOffset? time, string dataSchema, string dataContentType, string subject, JsonElement serializedData, byte[] dataBase64)
        {
            Id = id;
            Source = source;
            Type = type;
            Time = time;
            DataSchema = dataSchema;
            DataContentType = dataContentType;
            Subject = subject;
            SerializedData = serializedData;
            DataBase64 = dataBase64;
            ExtensionAttributes = new Dictionary<string, object>();
        }

        /// <summary> An identifier for the event. The combination of id and source must be unique for each distinct event. </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </summary>
        public string Source { get; set; }

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

        /// <summary> Deserialized event data specific to the event type. </summary>
        internal object Data { get; set; }

        /// <summary> Serialized event data specific to the event type. </summary>
        internal JsonElement SerializedData { get; set; }

        /// <summary> Event data specific to the event type, encoded as a base64 string. </summary>
        internal byte[] DataBase64 { get; set; }

        private static readonly JsonObjectSerializer s_jsonSerializer = new JsonObjectSerializer();

        /// <summary>
        /// Given JSON-encoded events, parses the event envelope and returns an array of CloudEvents.
        /// </summary>
        /// <param name="requestContent"> The JSON-encoded representation of either a single event or an array or events, in the CloudEvent schema. </param>
        /// <returns> A list of <see cref="CloudEvent"/>. </returns>
        public static CloudEvent[] Parse(BinaryData requestContent)
            => Parse(requestContent.ToString());

        /// <summary>
        /// Given JSON-encoded events, parses the event envelope and returns an array of CloudEvents.
        /// </summary>
        /// <param name="requestContent"> The JSON-encoded representation of either a single event or an array or events, in the CloudEvent schema. </param>
        /// <returns> A list of <see cref="CloudEvent"/>. </returns>
        public static CloudEvent[] Parse(string requestContent)
        {
            List<CloudEventInternal> cloudEventsInternal = new List<CloudEventInternal>();
            List<CloudEvent> cloudEvents = new List<CloudEvent>();
            JsonDocument requestDocument = JsonDocument.Parse(requestContent);

            // Parse JsonElement into separate events, deserialize event envelope properties
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

            foreach (CloudEventInternal cloudEventInternal in cloudEventsInternal)
            {
                CloudEvent cloudEvent = new CloudEvent(
                    cloudEventInternal.Id,
                    cloudEventInternal.Source,
                    cloudEventInternal.Type,
                    cloudEventInternal.Time,
                    cloudEventInternal.Dataschema,
                    cloudEventInternal.Datacontenttype,
                    cloudEventInternal.Subject,
                    cloudEventInternal.Data,
                    cloudEventInternal.DataBase64);

                if (cloudEventInternal.AdditionalProperties != null)
                {
                    foreach (KeyValuePair<string, object> kvp in cloudEventInternal.AdditionalProperties)
                    {
                        cloudEvent.ExtensionAttributes.Add(kvp.Key, kvp.Value);
                    }
                }

                cloudEvents.Add(cloudEvent);
            }

            return cloudEvents.ToArray();
        }

        /// <summary>
        /// Deserializes the event payload into a specified event type using the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T"> Type of event to deserialize to. </typeparam>
        /// <param name="serializer"> Custom serializer used to deserialize the payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use during deserialization. </param>
        /// <exception cref="InvalidOperationException"> Event was not created from CloudEvent.Parse() method. </exception>
        /// <exception cref="InvalidCastException"> Event payload cannot be cast to the specified event type. </exception>
        /// <returns> Deserialized payload of the event, cast to the specified type. </returns>
        public async Task<T> GetDataAsync<T>(ObjectSerializer serializer, CancellationToken cancellationToken = default)
        {
            if (Data != null)
            {
                throw new InvalidOperationException("Cannot pass in a custom deserializer if event was not created from CloudEvent.Parse(), " +
                    "as event data should already be deserialized and the custom deserializer will not be used.");
            }
            return await GetDataInternal<T>(serializer, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deserializes the event payload into a specified event type using the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T"> Type of event to deserialize to. </typeparam>
        /// <param name="serializer"> Custom serializer used to deserialize the payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use during deserialization. </param>
        /// <exception cref="InvalidOperationException"> Event was not created from CloudEvent.Parse() method. </exception>
        /// <exception cref="InvalidCastException"> Event payload cannot be cast to the specified event type. </exception>
        /// <returns> Deserialized payload of the event, cast to the specified type. </returns>
        public T GetData<T>(ObjectSerializer serializer, CancellationToken cancellationToken = default)
        {
            if (Data != null)
            {
                throw new InvalidOperationException("Cannot pass in a custom deserializer if event was not created from CloudEvent.Parse(), " +
                    "as event data should already be deserialized and the custom deserializer will not be used.");
            }
            return GetDataInternal<T>(serializer, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Deserializes the event payload into a specified event type using the provided <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T"> Type of event to deserialize to. </typeparam>
        /// <param name="cancellationToken"> The cancellation token to use during deserialization. </param>
        /// <exception cref="InvalidOperationException"> Event was not created from CloudEvent.Parse() method. </exception>
        /// <exception cref="InvalidCastException"> Event payload cannot be cast to the specified event type. </exception>
        /// <returns> Deserialized payload of the event, cast to the specified type. </returns>
        public T GetData<T>(CancellationToken cancellationToken = default)
            => GetDataInternal<T>(s_jsonSerializer, false, cancellationToken).EnsureCompleted();

        private async Task<T> GetDataInternal<T>(ObjectSerializer serializer, bool async, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));

            if (Data != null)
            {
                return (T)Data;
            }
            else if (SerializedData.ValueKind != JsonValueKind.Null && SerializedData.ValueKind != JsonValueKind.Undefined)
            {
                // Try to deserialize to system event
                if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(Type, out Func<JsonElement, object> systemDeserializationFunction))
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
            else // Both Data and SerializedData are null
            {
                return default;
            }
        }

        /// <summary>
        /// Deserializes the event payload into a system event type or
        /// returns the payload of the event wrapped as <see cref="BinaryData"/>. Using BinaryData,
        /// one can deserialize the payload into rich data, or access the raw JSON data using <see cref="BinaryData.ToString()"/>.
        /// </summary>
        /// <returns>
        /// Deserialized payload of the event. Returns null if there is no event data.
        /// Returns <see cref="BinaryData"/> for unknown event types.
        /// </returns>
        public object GetData()
        {
            if (Data == null)
            {
                if (DataBase64 != null)
                {
                    return new BinaryData(DataBase64);
                }
                else if (SerializedData.ValueKind != JsonValueKind.Null &&
                         SerializedData.ValueKind != JsonValueKind.Undefined)
                {
                    // Try to deserialize to system event
                    if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(Type, out Func<JsonElement, object> systemDeserializationFunction))
                    {
                        return systemDeserializationFunction(SerializedData);
                    }
                    else
                    {
                        // Return serialized event data as BinaryData
                        return BinaryData.FromStream(SerializePayloadToStream(SerializedData));
                    }
                }
            }
            return Data;
        }

        private static MemoryStream SerializePayloadToStream(object payload, CancellationToken cancellationToken = default)
        {
            MemoryStream dataStream = new MemoryStream();
            s_jsonSerializer.Serialize(dataStream, payload, payload.GetType(), cancellationToken);
            dataStream.Position = 0;
            return dataStream;
        }
    }
}
