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
    /// <summary>
    /// Class used to decode events from the Event Grid service.
    /// </summary>
    public class EventGridConsumer
    {
        private readonly ObjectSerializer _objectSerializer;
        private readonly IDictionary<string, Type> _customEventTypeMappings;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridConsumer"/> class.
        /// </summary>
        public EventGridConsumer() :
            this(new EventGridConsumerOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridConsumer"/> class.
        /// </summary>
        /// <param name="options"> Options for configuring deserialization. </param>
        public EventGridConsumer(EventGridConsumerOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));
            _objectSerializer = options.DataSerializer;
            _customEventTypeMappings = options.CustomEventTypeMappings;
        }

        /// <summary>
        /// Deserializes JSON encoded events and returns an array of events encoded in the EventGrid event schema.
        /// </summary>
        /// <param name="requestContent">
        /// The JSON encoded representation of either a single event or an array or events, encoded in the EventGrid event schema.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A list of EventGrid Events.</returns>
        public virtual EventGridEvent[] DeserializeEventGridEvents(string requestContent, CancellationToken cancellationToken = default)
            => DeserializeEventGridEventsInternal(requestContent, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Deserializes JSON encoded events and returns an array of events encoded in the EventGrid event schema.
        /// </summary>
        /// <param name="requestContent">
        /// The JSON encoded representation of either a single event or an array or events, encoded in the EventGrid event schema.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A list of EventGrid Events.</returns>
        public virtual async Task<EventGridEvent[]> DeserializeEventGridEventsAsync(string requestContent, CancellationToken cancellationToken = default)
            => await DeserializeEventGridEventsInternal(requestContent, true /*async*/, cancellationToken).ConfigureAwait(false);

        private async Task<EventGridEvent[]> DeserializeEventGridEventsInternal(string requestContent, bool async, CancellationToken cancellationToken = default)
        {
            List<EventGridEventInternal> egInternalEvents = new List<EventGridEventInternal>();
            List<EventGridEvent> egEvents = new List<EventGridEvent>();

            // Deserialize raw JSON string into separate events, deserialize event envelope properties
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            JsonDocument requestDocument;
            if (async)
            {
                requestDocument = await JsonDocument.ParseAsync(stream, default, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                requestDocument = JsonDocument.Parse(stream, default);
            }
            foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
            {
                egInternalEvents.Add(EventGridEventInternal.DeserializeEventGridEventInternal(property));
            }

            // Deserialize 'Data' property from JsonElement for each event
            foreach (EventGridEventInternal egEventInternal in egInternalEvents)
            {
                JsonElement dataElement = egEventInternal.Data;
                object egEventData = null;

                // Reserialize JsonElement to stream
                MemoryStream dataStream = new MemoryStream();
                JsonObjectSerializer serializer = new JsonObjectSerializer();
                serializer.Serialize(dataStream, dataElement, dataElement.GetType(), cancellationToken);
                dataStream.Position = 0;

                // First, let's attempt to find the mapping for the event type in the custom event mapping.
                if (_customEventTypeMappings.TryGetValue(egEventInternal.EventType, out Type typeOfEventData))
                {
                    if (!TryGetPrimitiveFromJsonElement(dataElement, out egEventData))
                    {
                        if (async)
                        {
                            egEventData = await _objectSerializer.DeserializeAsync(dataStream, typeOfEventData, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            egEventData = _objectSerializer.Deserialize(dataStream, typeOfEventData, cancellationToken);
                        }
                    }
                }
                // If a custom mapping doesn't exist, let's attempt to find the mapping for the deserialization function in the system event type mapping.
                else if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(egEventInternal.EventType, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    egEventData = systemDeserializationFunction(dataElement);
                }
                else
                {
                    // If event data is not a primitive/string, return as BinaryData
                    if (!TryGetPrimitiveFromJsonElement(dataElement, out egEventData))
                    {
                        egEventData = BinaryData.FromStream(dataStream);
                    }
                }

                egEvents.Add(new EventGridEvent(
                    egEventInternal.Subject,
                    egEventData,
                    egEventInternal.EventType,
                    egEventInternal.DataVersion)
                {
                    Id = egEventInternal.Id,
                    EventTime = egEventInternal.EventTime
                });
            }

            return egEvents.ToArray();
        }

        /// <summary>
        /// Deserializes JSON encoded events and returns an array of events encoded in the CloudEvent schema.
        /// </summary>
        /// <param name="requestContent">
        /// The JSON encoded representation of either a single event or an array or events, encoded in the CloudEvent schema.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A list of CloudEvents.</returns>
        public virtual CloudEvent[] DeserializeCloudEvents(string requestContent, CancellationToken cancellationToken = default)
            => DeserializeCloudEventsInternal(requestContent, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Deserializes JSON encoded events and returns an array of events encoded in the CloudEvent schema.
        /// </summary>
        /// <param name="requestContent">
        /// The JSON encoded representation of either a single event or an array or events, encoded in the CloudEvent schema.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A list of CloudEvents.</returns>
        public virtual async Task<CloudEvent[]> DeserializeCloudEventsAsync(string requestContent, CancellationToken cancellationToken = default)
            => await DeserializeCloudEventsInternal(requestContent, true /*async*/, cancellationToken).ConfigureAwait(false);

        private async Task<CloudEvent[]> DeserializeCloudEventsInternal(string requestContent, bool async, CancellationToken cancellationToken = default)
        {
            List<CloudEventInternal> cloudEventsInternal = new List<CloudEventInternal>();
            List<CloudEvent> cloudEvents = new List<CloudEvent>();

            // Deserialize raw JSON string into separate events, deserialize event envelope properties
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            JsonDocument requestDocument;
            if (async)
            {
                requestDocument = await JsonDocument.ParseAsync(stream, default, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                requestDocument = JsonDocument.Parse(stream, default);
            }
            foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
            {
                cloudEventsInternal.Add(CloudEventInternal.DeserializeCloudEventInternal(property));
            }

            // Deserialize 'Data' property from JsonElement for each event
            foreach (CloudEventInternal cloudEventInternal in cloudEventsInternal)
            {
                object cloudEventData = null;
                if (cloudEventInternal.DataBase64 != null)
                {
                    cloudEventData = Convert.FromBase64String(cloudEventInternal.DataBase64);
                }
                else
                {
                    JsonElement? dataElement = cloudEventInternal.Data;

                    if (dataElement.HasValue && dataElement.Value.ValueKind != JsonValueKind.Null)
                    {
                        // Reserialize JsonElement to stream
                        MemoryStream dataStream = new MemoryStream();
                        JsonObjectSerializer serializer = new JsonObjectSerializer();
                        serializer.Serialize(dataStream, dataElement, dataElement.GetType(), cancellationToken);
                        dataStream.Position = 0;

                        // First, let's attempt to find the mapping for the event type in the custom event mapping.
                        if (_customEventTypeMappings.TryGetValue(cloudEventInternal.Type, out Type typeOfEventData))
                        {
                            if (!TryGetPrimitiveFromJsonElement(dataElement.Value, out cloudEventData))
                            {
                                if (async)
                                {
                                    cloudEventData = await _objectSerializer.DeserializeAsync(dataStream, typeOfEventData, cancellationToken).ConfigureAwait(false);
                                }
                                else
                                {
                                    cloudEventData = _objectSerializer.Deserialize(dataStream, typeOfEventData, cancellationToken);
                                }
                            }
                        }
                        // If a custom mapping doesn't exist, let's attempt to find the mapping for the deserialization function in the system event type mapping.
                        else if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(cloudEventInternal.Type, out Func<JsonElement, object> systemDeserializationFunction))
                        {
                            cloudEventData = systemDeserializationFunction(dataElement.Value);
                        }
                        // If no custom mapping was added, either return a primitive/string, or an object wrapped as BinaryData
                        else
                        {
                            // If event data is not a primitive/string, return as BinaryData
                            if (!TryGetPrimitiveFromJsonElement(dataElement.Value, out cloudEventData))
                            {
                                cloudEventData = BinaryData.FromStream(dataStream);
                            }
                        }
                    }
                    else if (dataElement?.ValueKind == JsonValueKind.Null) // Event has null data
                    {
                        cloudEventData = null;
                        cloudEventInternal.Type = "";
                    }
                    else // Event has no data
                    {
                        cloudEventData = "";
                        cloudEventInternal.Type = "";
                    }
                }

                cloudEvents.Add(new CloudEvent(
                    cloudEventInternal.Source,
                    cloudEventInternal.Type)
                {
                    Id = cloudEventInternal.Id,
                    Data = cloudEventData,
                    Time = cloudEventInternal.Time,
                    DataSchema = cloudEventInternal.Dataschema,
                    DataContentType = cloudEventInternal.Datacontenttype,
                    Subject = cloudEventInternal.Subject
                });
            }

            return cloudEvents.ToArray();
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
                var oki = jsonElement.TryGetInt32(out var vali);
                if (oki)
                {
                    elementValue = vali;
                }
                var okl = jsonElement.TryGetInt64(out var vall);
                if (okl)
                {
                    elementValue = vall;
                }
                var okd = jsonElement.TryGetDouble(out var val);
                if (okd)
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
