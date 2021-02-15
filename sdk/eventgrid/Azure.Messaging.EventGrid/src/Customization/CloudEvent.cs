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
    /// <summary> Properties of an event published to an Event Grid topic using the CloudEvent 1.0 Schema. </summary>
    public class CloudEvent
    {
        /// <summary> Initializes a new instance of the <see cref="CloudEvent"/> class with an object payload that will
        /// be serialized as JSON. </summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="data"> Event data specific to the event type. </param>
        /// <param name="dataSerializationType">The type to use when serializing the data.
        /// If not specified, <see cref="object.GetType()"/> will be used on <paramref name="data"/>.</param>
        public CloudEvent(string source, string type, object data, Type dataSerializationType = default)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));

            Source = source;
            Type = type;
            DataSerializationType = dataSerializationType ?? data?.GetType() ?? null;
            Data = data;
            ExtensionAttributes = new Dictionary<string, object>();
        }

        /// <summary> Initializes a new instance of the <see cref="CloudEvent"/> class using binary event data.</summary>
        /// <param name="source"> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </param>
        /// <param name="type"> Type of event related to the originating occurrence. For example, "Contoso.Items.ItemReceived". </param>
        /// <param name="data"> Binary event data specific to the event type. </param>
        /// <param name="dataContentType"> Content type of the payload. A content type different from "application/json" should be specified if payload is not JSON. </param>
        public CloudEvent(string source, string type, ReadOnlyMemory<byte> data, string dataContentType)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(type, nameof(type));

            Source = source;
            Type = type;
            DataContentType = dataContentType;
            DataBase64 = data.ToArray();
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
        /// Gets whether or not the event is a System defined event and returns the deserialized
        /// system event data via out parameter.
        /// </summary>
        /// <param name="eventData">If the event is a system event, this will be populated
        /// with the deserialized system event data. Otherwise, this will be null.</param>
        /// <returns> Whether or not the event is a system event.</returns>
        public bool TryGetSystemEventData(out object eventData)
        {
            eventData = SystemEventExtensions.AsSystemEventData(Type, SerializedData);
            return eventData != null;
        }

        /// <summary>
        /// Given JSON-encoded events, parses the event envelope and returns an array of CloudEvents.
        /// </summary>
        /// <param name="requestContent"> The JSON-encoded representation of either a single event or an array or events, in the CloudEvent schema. </param>
        /// <returns> A list of <see cref="CloudEvent"/>. </returns>
        public static CloudEvent[] Parse(string requestContent)
        {
            Argument.AssertNotNull(requestContent, nameof(requestContent));

            CloudEvent[] cloudEvents = null;
            JsonDocument requestDocument = JsonDocument.Parse(requestContent);

            // Parse JsonElement into separate events, deserialize event envelope properties
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                cloudEvents = new CloudEvent[1];
                cloudEvents[0] = (new CloudEvent(CloudEventInternal.DeserializeCloudEventInternal(requestDocument.RootElement)));
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                cloudEvents = new CloudEvent[requestDocument.RootElement.GetArrayLength()];
                int i = 0;
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    cloudEvents[i++] = new CloudEvent(CloudEventInternal.DeserializeCloudEventInternal(property));
                }
            }
            return cloudEvents ?? Array.Empty<CloudEvent>();
        }

        /// <summary>
        /// Deserializes the event payload into a specified event type using the default serializer, <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T"> Type of event to deserialize to. </typeparam>
        /// <param name="cancellationToken"> The cancellation token to use during deserialization. </param>
        /// <exception cref="InvalidOperationException"> Event was not created from CloudEvent.Parse() method. </exception>
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
    }
}
