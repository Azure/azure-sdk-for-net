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
        /// <param name="dataSerializationType">The type to use when serializing the data.
        /// If not specified, <see cref="object.GetType()"/> will be used on <paramref name="data"/>.</param>
        public CloudEvent(string source, string type, object data, string dataContentType = default, Type dataSerializationType = default)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));

            Source = source;
            Type = type;
            DataContentType = dataContentType;
            DataSerializationType = dataSerializationType ?? data?.GetType() ?? null;

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

        internal CloudEvent(CloudEventInternal cloudEventInternal)
        {
            // we only validate that the type is required when deserializing since the service allows sending a CloudEvent without a Source.
            Argument.AssertNotNull(cloudEventInternal.Type, nameof(cloudEventInternal.Type));

            Id = cloudEventInternal.Id;
            Source = cloudEventInternal.Source;
            Type = cloudEventInternal.Type;
            Time = cloudEventInternal.Time;
            DataSchema = cloudEventInternal.Dataschema;
            DataContentType = cloudEventInternal.Datacontenttype;
            Subject = cloudEventInternal.Subject;
            SerializedData = cloudEventInternal.Data;
            DataBase64 = cloudEventInternal.DataBase64;
            ExtensionAttributes = new Dictionary<string, object>(cloudEventInternal.AdditionalProperties);
        }

        /// <summary>
        /// Gets or sets an identifier for the event. The combination of <see cref="Id"/> and <see cref="Source"/> must be unique for each distinct event.
        /// If not explicitly set, this will default to a <see cref="Guid"/>.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>Gets or sets the context in which an event happened. The combination of <see cref="Id"/> and <see cref="Source"/> must be unique for each distinct event.</summary>
        public string Source { get; set; }

        /// <summary>Gets or sets the type of event related to the originating occurrence.</summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the time (in UTC) the event was generated, in RFC3339 format.
        /// If not explicitly set, this will default to the time that the event is constructed.
        /// </summary>
        public DateTimeOffset? Time { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>Gets or sets the schema that the data adheres to.</summary>
        public string DataSchema { get; set; }

        /// <summary>Gets or sets the content type of the data.</summary>
        public string DataContentType { get; set; }

        internal Type DataSerializationType { get; }

        /// <summary>Gets or sets the subject of the event in the context of the event producer (identified by source). </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets extension attributes that can be additionally added to the CloudEvent envelope.
        /// </summary>
        public Dictionary<string, object> ExtensionAttributes { get; }

        /// <summary>Gets or sets the deserialized event data specific to the event type.</summary>
        internal object Data { get; set; }

        /// <summary>Gets or sets the serialized event data specific to the event type.</summary>
        internal JsonElement SerializedData { get; set; }

        /// <summary>Gets or sets the event data specific to the event type, encoded as a base64 string.</summary>
        internal byte[] DataBase64 { get; set; }

        private static readonly JsonObjectSerializer s_jsonSerializer = new JsonObjectSerializer();

        /// <summary>
        /// Gets whether or not the event is a System defined event.
        /// </summary>
        public bool IsSystemEvent =>
            SystemEventExtensions.SystemEventDeserializers.ContainsKey(Type);

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
                cloudEvents.Add(new CloudEvent(cloudEventInternal));
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
                if (SystemEventExtensions.SystemEventDeserializers.TryGetValue(Type, out Func<JsonElement, object> systemDeserializationFunction))
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
        public BinaryData GetData() =>
            GetDataInternal();

        /// <summary>
        /// Deserializes the event payload into a system event type or
        /// returns the payload of the event wrapped as <see cref="BinaryData"/>. Using BinaryData,
        /// one can deserialize the payload into rich data, or access the raw JSON data using <see cref="BinaryData.ToString()"/>.
        /// </summary>
        /// <returns>
        /// Deserialized payload of the event. Returns null if there is no event data.
        /// Returns <see cref="BinaryData"/> for unknown event types.
        /// </returns>
        public Task<BinaryData> GetDataAsync() =>
            Task.FromResult(GetDataInternal());

        private BinaryData GetDataInternal()
        {
            if (Data != null)
            {
                // The data has not been serialized yet, but we still return it as BinaryData
                // which uses System.Text.Json.
                return new BinaryData(Data, type: DataSerializationType);
            }
            else
            {
                if (DataBase64 != null)
                {
                    return new BinaryData(DataBase64);
                }
                // CloudEvent Data can be null, whereas EventGrid Data cannot be.
                // Hence we have this check here.
                else if (SerializedData.ValueKind != JsonValueKind.Null &&
                         SerializedData.ValueKind != JsonValueKind.Undefined)
                {
                    return BinaryData.FromStream(SerializePayloadToStream(SerializedData));
                }
                else
                {
                    // the CloudEvent Data was null
                    return null;
                }
            }
        }

        private static MemoryStream SerializePayloadToStream(JsonElement payload, CancellationToken cancellationToken = default)
        {
            MemoryStream dataStream = new MemoryStream();
            s_jsonSerializer.Serialize(dataStream, payload, payload.GetType(), cancellationToken);
            dataStream.Position = 0;
            return dataStream;
        }

        /// <summary>
        /// Deserializes a system event to its system event data payload. This will return null if the event is not a system event.
        /// To detect whether an event is a system event, use the <see cref="IsSystemEvent"/> property.
        /// </summary>
        /// <returns>The rich system model type.</returns>
        public object AsSystemEventData() =>
            SystemEventExtensions.AsSystemEventData(Type, SerializedData);
    }
}
