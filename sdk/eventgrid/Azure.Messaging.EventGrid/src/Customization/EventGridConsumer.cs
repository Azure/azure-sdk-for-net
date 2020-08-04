// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Class used to decode events from the Event Grid service.
    /// </summary>
    public class EventGridConsumer
    {
        /// <summary>
        /// Serializer used to decode events and custom payloads from JSON.
        /// </summary>
        public ObjectSerializer ObjectSerializer { get; set; } = new JsonObjectSerializer(new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            AllowTrailingCommas = true
        });

        // Dictionary for custom event types
        private readonly ConcurrentDictionary<string, Type> _customEventTypeMappings = new ConcurrentDictionary<string, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridConsumer"/> class.
        /// </summary>
        public EventGridConsumer()
        {
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
        {
            // need to check if events are actually encoded in the eg schema
            List<EventGridEventInternal> egInternalEvents = new List<EventGridEventInternal>();
            List<EventGridEvent> egEvents = new List<EventGridEvent>();

            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            JsonDocument requestDocument = JsonDocument.Parse(stream, default);
            foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
            {
                egInternalEvents.Add(EventGridEventInternal.DeserializeEventGridEventInternal(property));
            }

            foreach (EventGridEventInternal egEventInternal in egInternalEvents)
            {
                // First, let's attempt to find the mapping for the deserialization function in the system event type mapping.
                if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(egEventInternal.EventType, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    if (egEventInternal.Data != null)
                    {
                        string eventDataContent = egEventInternal.Data.ToString();
                        JsonDocument document = JsonDocument.Parse(new MemoryStream(Encoding.UTF8.GetBytes(eventDataContent)), default);

                        egEventInternal.Data = systemDeserializationFunction(document.RootElement); // note: still need to generate setters for event grid event
                    }
                }
                // If not a system event, let's attempt to find the mapping for the event type in the custom event mapping.
                else if (TryGetCustomEventMapping(egEventInternal.EventType, out Type typeOfEventData))
                {
                    JsonElement element = (JsonElement)egEventInternal.Data;
                    MemoryStream dataStream = new MemoryStream(Encoding.UTF8.GetBytes(egEventInternal.Data.ToString()));

                    if (element.ValueKind == JsonValueKind.True || element.ValueKind == JsonValueKind.False)
                    {
                        egEventInternal.Data = element.GetBoolean();
                    }
                    else if (element.ValueKind == JsonValueKind.Number)
                    {
                        var oki = element.TryGetInt32(out var vali);
                        if (oki)
                        {
                            egEventInternal.Data = vali;
                        }
                        var okl = element.TryGetInt64(out var vall);
                        if (okl)
                        {
                            egEventInternal.Data = vall;
                        }
                        var okd = element.TryGetDouble(out var val);
                        if (okd)
                        {
                            egEventInternal.Data = val;
                        }
                    }
                    else if (element.ValueKind == JsonValueKind.String)
                    {
                        egEventInternal.Data = element.GetString();
                    }
                    else
                    {
                        egEventInternal.Data = ObjectSerializer.Deserialize(dataStream, typeOfEventData, cancellationToken);
                    }
                }
                else
                {
                    // perhaps return as BinaryData?
                    //MemoryStream dataStream = new MemoryStream();
                    //ObjectSerializer.Serialize(dataStream, egEvent.Data, egEvent.Data.GetType(), cancellationToken);
                    //dataStream.Seek(0, SeekOrigin.Begin);
                    //egEvent.Data = BinaryData.FromStream(dataStream);

                    egEventInternal.Data = egEventInternal.Data.ToString();
                }

                egEvents.Add(new EventGridEvent(
                    egEventInternal.Subject,
                    egEventInternal.Data,
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
        {
            // need to check if events are actually encoded in the cloudevent schema

            List<CloudEventInternal> cloudEventsInternal = new List<CloudEventInternal>();
            List<CloudEvent> cloudEvents = new List<CloudEvent>();

            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            JsonDocument requestDocument = JsonDocument.Parse(stream, default);
            foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
            {
                cloudEventsInternal.Add(CloudEventInternal.DeserializeCloudEventInternal(property));
            }

            foreach (CloudEventInternal cloudEventInternal in cloudEventsInternal)
            {
                if (cloudEventInternal.DataBase64 != null)
                {
                    cloudEventInternal.Data = Convert.FromBase64String(cloudEventInternal.DataBase64);
                }
                // First, let's attempt to find the mapping for the deserialization function in the system event type mapping.
                else if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(cloudEventInternal.Type, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    if (cloudEventInternal.Data != null)
                    {
                        string eventDataContent = cloudEventInternal.Data.ToString();
                        JsonDocument document = JsonDocument.Parse(new MemoryStream(Encoding.UTF8.GetBytes(eventDataContent)), default);

                        cloudEventInternal.Data = systemDeserializationFunction(document.RootElement);
                    }
                }
                // If not a system event, let's attempt to find the mapping for the event type in the custom event mapping.
                else if (TryGetCustomEventMapping(cloudEventInternal.Type, out Type typeOfEventData))
                {
                    JsonElement element = (JsonElement)cloudEventInternal.Data;
                    MemoryStream dataStream = new MemoryStream(Encoding.UTF8.GetBytes(cloudEventInternal.Data.ToString()));

                    if (element.ValueKind == JsonValueKind.True || element.ValueKind == JsonValueKind.False)
                    {
                        cloudEventInternal.Data = element.GetBoolean();
                    }
                    else if (element.ValueKind == JsonValueKind.Number)
                    {
                        var oki = element.TryGetInt32(out var vali);
                        if (oki)
                        {
                            cloudEventInternal.Data = vali;
                        }
                        var okl = element.TryGetInt64(out var vall);
                        if (okl)
                        {
                            cloudEventInternal.Data = vall;
                        }
                        var okd = element.TryGetDouble(out var val);
                        if (okd)
                        {
                            cloudEventInternal.Data = val;
                        }
                    }
                    else if (element.ValueKind == JsonValueKind.String)
                    {
                        cloudEventInternal.Data = element.GetString();
                    }
                    else
                    {
                        cloudEventInternal.Data = ObjectSerializer.Deserialize(dataStream, typeOfEventData, cancellationToken);
                    }
                }

                cloudEvents.Add(new CloudEvent(
                    cloudEventInternal.Source,
                    cloudEventInternal.Type)
                {
                    Id = cloudEventInternal.Id,
                    Data = cloudEventInternal.Data,
                    Time = cloudEventInternal.Time,
                    SpecVersion = cloudEventInternal.Specversion,
                    DataSchema = cloudEventInternal.Dataschema,
                    DataContentType = cloudEventInternal.Datacontenttype,
                    Subject = cloudEventInternal.Subject
                });
            }

            return cloudEvents.ToArray();
        }

        /// <summary>
        /// Deserializes JSON encoded events and returns an array of events encoded in a custom event schema.
        /// </summary>
        /// <param name="requestContent">
        /// The JSON encoded representation of either a single event or an array or events, encoded in a custom event schema.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>A list of CloudEvents.</returns>
        public virtual T[] DeserializeCustomEvents<T>(string requestContent, CancellationToken cancellationToken = default)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            return (T[])ObjectSerializer.Deserialize(stream, typeof(T[]), cancellationToken);
        }

        /// <summary>
        /// Adds or updates a custom event mapping that associates an eventType string with the corresponding type of event data.
        /// </summary>
        /// <param name="eventType">The event type to register, such as "Contoso.Items.ItemReceived"</param>
        /// <param name="eventDataType">The type of eventdata corresponding to this eventType, such as typeof(ContosoItemReceivedEventData)</param>
        public void AddOrUpdateCustomEventMapping(string eventType, Type eventDataType)
        {
            ValidateEventType(eventType);

            if (eventDataType == null)
            {
                throw new ArgumentNullException(nameof(eventDataType));
            }

            _customEventTypeMappings.AddOrUpdate(
                eventType,
                eventDataType,
                (_, existingValue) => eventDataType);
        }

        /// <summary>
        /// Gets information about a custom event mapping.
        /// </summary>
        /// <param name="eventType">The registered event type, such as "Contoso.Items.ItemReceived"</param>
        /// <param name="eventDataType">The type of eventdata corresponding to this eventType, such as typeof(ContosoItemReceivedEventData)</param>
        /// <returns>True if the specified mapping exists.</returns>
        public bool TryGetCustomEventMapping(string eventType, out Type eventDataType)
        {
            ValidateEventType(eventType);

            return _customEventTypeMappings.TryGetValue(eventType, out eventDataType);
        }

        /// <summary>
        /// List all registered custom event mappings.
        /// </summary>
        /// <returns>An IEnumerable of mappings</returns>
        public IEnumerable<KeyValuePair<string, Type>> ListAllCustomEventMappings()
        {
            foreach (KeyValuePair<string, Type> kvp in _customEventTypeMappings)
            {
                yield return kvp;
            }
        }

        /// <summary>
        /// Removes a custom event mapping.
        /// </summary>
        /// <param name="eventType">The registered event type, such as "Contoso.Items.ItemReceived"</param>
        /// <param name="eventDataType">The type of eventdata corresponding to this eventType, such as typeof(ContosoItemReceivedEventData)</param>
        /// <returns>True if the specified mapping was removed successfully.</returns>
        public bool TryRemoveCustomEventMapping(string eventType, out Type eventDataType)
        {
            ValidateEventType(eventType);
            return _customEventTypeMappings.TryRemove(eventType, out eventDataType);
        }

        internal static void ValidateEventType(string eventType)
        {
            if (string.IsNullOrEmpty(eventType))
            {
                throw new ArgumentNullException(nameof(eventType));
            }
        }
    }
}
