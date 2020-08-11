// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure.Messaging.EventGrid
{
    /// <summary> Properties of an event published to an Event Grid topic using the CloudEvent 1.0 Schema. </summary>
    public class CloudEvent
    {
        /// <summary> Initializes a new instance of CloudEvent. </summary>
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

        /// <summary> An identifier for the event. The combination of id and source must be unique for each distinct event. </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary> Identifies the context in which an event happened. The combination of id and source must be unique for each distinct event. </summary>
        public string Source { get; set; }

        /// <summary> Event data specific to the event type. </summary>
        private JsonElement? Data { get; set; }

        /// <summary> Event data specific to the event type, encoded as a base64 string. </summary>
        private string DataBase64 { get; set; }

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
        /// Deserializes the event payload into a specified event type.
        /// </summary>
        /// <typeparam name="T"> Describing the type of the event. </typeparam>
        /// <param name="serializer"> Custom serializer used to deserialize the payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Deserialized payload of the event. </returns>
        public async Task<T> GetDataAsync<T>(ObjectSerializer serializer, CancellationToken cancellationToken = default)
            => await GetDataInternal<T>(serializer, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deserializes the event payload into a specified event type.
        /// </summary>
        /// <typeparam name="T"> Describing the type of the event. </typeparam>
        /// <param name="serializer"> Custom serializer used to deserialize the payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Deserialized payload of the event. </returns>
        public T GetData<T>(ObjectSerializer serializer, CancellationToken cancellationToken = default)
            => GetDataInternal<T>(serializer, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Deserializes the event payload into a specified event type.
        /// </summary>
        /// <typeparam name="T"> Describing the type of the event. </typeparam>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Deserialized payload of the event. </returns>
        public async Task<T> GetDataAsync<T>(CancellationToken cancellationToken = default)
            => await GetDataInternal<T>(new JsonObjectSerializer(), true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deserializes the event payload into a specified event type.
        /// </summary>
        /// <typeparam name="T"> Describing the type of the event. </typeparam>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> Deserialized payload of the event. </returns>
        public T GetData<T>(CancellationToken cancellationToken = default)
            => GetDataInternal<T>(new JsonObjectSerializer(), false, cancellationToken).EnsureCompleted();

        private async Task<T> GetDataInternal<T>(ObjectSerializer serializer, bool async, CancellationToken cancellationToken = default)
        {
            //if (DataBase64 != null)
            //{
            //    return Convert.FromBase64String(DataBase64);
            //}
            if (Data.HasValue && Data.Value.ValueKind != JsonValueKind.Null)
            {
                MemoryStream dataStream = SerializePayloadToStream(Data, new JsonObjectSerializer(), cancellationToken);
                if (!TryGetPrimitiveFromJsonElement(Data.Value, out object cloudEventData))
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
                else
                {
                    return (T)cloudEventData;
                }
            }
            else // Event has null data
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to deserialize the event payload into a system event type.
        /// </summary>
        /// <returns> Deserialized payload of the event. </returns>
        public object GetData(CancellationToken cancellationToken = default)
        {
            MemoryStream dataStream = SerializePayloadToStream(Data, new JsonObjectSerializer(), cancellationToken);
            if (Data.HasValue && Data.Value.ValueKind != JsonValueKind.Null)
            {
                if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(Type, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    return systemDeserializationFunction(Data.Value);
                }
                // If event data is not a primitive/string, return as BinaryData
                else if (!TryGetPrimitiveFromJsonElement(Data.Value, out object cloudEventData))
                {
                    return BinaryData.FromStream(dataStream);
                }
                else
                {
                    return cloudEventData;
                }
            }
            else // Event has null data
            {
                return default;
            }
        }

        /// <summary>
        /// Sets the event data specific to the event type.
        /// </summary>
        /// <typeparam name="T"> Describing the type of the event. </typeparam>
        /// <param name="serializer"> Custom serializer used to serialize the payload when sending events. </param>
        /// <param name="data"> The event payload. </param>
        public void SetData<T>(T data, ObjectSerializer serializer)
        {
            if (data is IEnumerable<byte> enumerable)
            {
                DataBase64 = Convert.ToBase64String(enumerable.ToArray());
            }
            else if (data is ReadOnlyMemory<byte> memory)
            {
                DataBase64 = Convert.ToBase64String(memory.ToArray());
            }
            else
            {
                MemoryStream dataStream = SerializePayloadToStream<T>(data, serializer);
                Data = JsonDocument.Parse(dataStream).RootElement;
            }
        }

        /// <summary>
        /// Sets the event data specific to the event type.
        /// </summary>
        /// <typeparam name="T"> Describing the type of the event. </typeparam>
        /// <param name="data"> The event payload. </param>
        public void SetData<T>(T data)
        {
            if (data is IEnumerable<byte> enumerable)
            {
                DataBase64 = Convert.ToBase64String(enumerable.ToArray());
            }
            else if (data is ReadOnlyMemory<byte> memory)
            {
                DataBase64 = Convert.ToBase64String(memory.ToArray());
            }
            else
            {
                MemoryStream dataStream = SerializePayloadToStream<T>(data, new JsonObjectSerializer());
                Data = JsonDocument.Parse(dataStream).RootElement;
            }
        }

        private static MemoryStream SerializePayloadToStream<T>(T payload, ObjectSerializer serializer, CancellationToken cancellationToken = default)
        {
            MemoryStream dataStream = new MemoryStream();
            serializer.Serialize(dataStream, payload, typeof(T), cancellationToken);
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
