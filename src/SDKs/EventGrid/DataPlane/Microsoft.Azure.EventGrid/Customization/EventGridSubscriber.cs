// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.EventGrid.Models;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.EventGrid
{
    public class EventGridSubscriber : IEventGridEventDeserializer, ICustomEventTypeMapper
    {
        static readonly JsonSerializer defaultJsonSerializer;
        readonly ConcurrentDictionary<string, Type> customEventTypeMapping;

        static EventGridSubscriber()
        {
            defaultJsonSerializer = GetJsonSerializerWithPolymorphicSupport();
        }

        public EventGridSubscriber()
        {
            customEventTypeMapping = new ConcurrentDictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Deserializes the provided event data using a default JSON serializer that supports all system event types.
        /// A webhook/function that is consuming events can call this function to deserialize EventGrid events.
        /// For system events, the Data property of each event in the returned array will be set to the appropriate
        /// type (e.g. StorageBlobCreatedEventData). For events on custom topics where the type of the Data property
        /// can be of any type, the calling function will have to first add a custom event mapping before calling this function.
        /// </summary>
        /// <param name="requestContent">The JSON string containing an array of EventGrid events</param>
        /// <returns>A list of EventGrid Events</returns>
        public EventGridEvent[] DeserializeEventGridEvents(string requestContent)
        {
            return this.DeserializeEventGridEvents(requestContent, defaultJsonSerializer);
        }

        /// <summary>
        /// Deserializes the provided event data using a custom JSON serializer.
        /// A webhook/function that is consuming events can call this function to deserialize EventGrid events.
        /// For system events, the Data property of each event in the returned array will be set to the appropriate
        /// type (e.g. StorageBlobCreatedEventData). For events on custom topics where the type of the Data property
        /// can be of any type, the calling function will have to first add a custom event mapping before calling this function.
        /// </summary>
        /// <param name="requestContent">The JSON string containing an array of EventGrid events</param>
        /// <param name="jsonSerializer">JsonSerializer to use for the deserialization.</param>
        /// <returns>A list of EventGrid Events</returns>
        public EventGridEvent[] DeserializeEventGridEvents(string requestContent, JsonSerializer jsonSerializer)
        {
            EventGridEvent[] eventGridEvents = JsonConvert.DeserializeObject<EventGridEvent[]>(requestContent, jsonSerializer.GetJsonSerializerSettings());
            return DeserializeEventGridEventData(eventGridEvents, jsonSerializer);
        }

        /// <summary>
        /// Deserializes the provided stream using a default JSON serializer that supports all system event types.
        /// A webhook/function that is consuming events can call this function to deserialize EventGrid events.
        /// For system events, the Data property of each event in the returned array will be set to the appropriate
        /// type (e.g. StorageBlobCreatedEventData). For events on custom topics where the type of the Data property
        /// can be of any type, the calling function will have to first add a custom event mapping before calling this function.
        /// </summary>
        /// <param name="requestStream">Request Stream</param>
        /// <returns>A list of EventGrid Events</returns>
        public EventGridEvent[] DeserializeEventGridEvents(Stream requestStream)
        {
            return this.DeserializeEventGridEvents(requestStream, defaultJsonSerializer);
        }

        /// <summary>
        /// Deserializes the provided stream using a custom JSON serializer.
        /// A webhook/function that is consuming events can call this function to deserialize EventGrid events.
        /// For system events, the Data property of each event in the returned array will be set to the appropriate
        /// type (e.g. StorageBlobCreatedEventData). For events on custom topics where the type of the Data property
        /// can be of any type, the calling function will have to first add a custom event mapping before calling this function.
        /// </summary>
        /// <param name="requestStream">Request Stream</param>
        /// <param name="jsonSerializer">JsonSerializer to use for the deserialization.</param>
        /// <returns>A list of EventGrid Events</returns>
        public EventGridEvent[] DeserializeEventGridEvents(Stream requestStream, JsonSerializer jsonSerializer)
        {
            EventGridEvent[] eventGridEvents = null;

            using (var streamReader = new StreamReader(requestStream))
            {
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    eventGridEvents = (EventGridEvent[])jsonSerializer.Deserialize(jsonTextReader, typeof(EventGridEvent[]));
                }
            }

            return DeserializeEventGridEventData(eventGridEvents, jsonSerializer);
        }

        /// <summary>
        /// Adds or updates a custom event mapping that associates an eventType string with the corresponding type of event data.
        /// </summary>
        /// <param name="eventType">The event type to register, such as "Contoso.Items.ItemReceived"</param>
        /// <param name="eventDataType">The type of eventdata corresponding to this eventType, such as typeof(ContosoItemReceivedEventData)</param>
        public void AddOrUpdateCustomEventMapping(string eventType, Type eventDataType)
        {
            this.ValidateEventType(eventType);

            if (eventDataType == null)
            {
                throw new ArgumentNullException(nameof(eventDataType));
            }

            this.customEventTypeMapping.AddOrUpdate(
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
            this.ValidateEventType(eventType);

            return this.customEventTypeMapping.TryGetValue(eventType, out eventDataType);
        }

        /// <summary>
        /// List all registered custom event mappings.
        /// </summary>
        /// <returns>An IEnumerable of mappings</returns>
        public IEnumerable<KeyValuePair<string, Type>> ListAllCustomEventMappings()
        {
            foreach (KeyValuePair<string, Type> kvp in this.customEventTypeMapping)
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
            this.ValidateEventType(eventType);
            return this.customEventTypeMapping.TryRemove(eventType, out eventDataType);
        }

        void ValidateEventType(string eventType)
        {
            if (string.IsNullOrEmpty(eventType))
            {
                throw new ArgumentNullException(nameof(eventType));
            }
        }

        EventGridEvent[] DeserializeEventGridEventData(EventGridEvent[] eventGridEvents, JsonSerializer jsonSerializer)
        {
            foreach (EventGridEvent receivedEvent in eventGridEvents)
            {
                Type typeOfEventData = null;

                // First, let's attempt to find the mapping for the event type in the system event type mapping.
                // Note that system event data would always be of type JObject.
                if (SystemEventTypeMappings.SystemEventMappings.TryGetValue(receivedEvent.EventType, out typeOfEventData))
                {
                    JObject dataObject = receivedEvent.Data as JObject;
                    if (dataObject != null)
                    {
                        var eventData = dataObject.ToObject(typeOfEventData, jsonSerializer);
                        receivedEvent.Data = eventData;
                    }
                }
                // If not a system event, let's attempt to find the mapping for the event type in the custom event mapping.
                else if (this.TryGetCustomEventMapping(receivedEvent.EventType, out typeOfEventData))
                {
                    JToken dataToken = receivedEvent.Data as JToken;
                    if (dataToken == null)
                    {
                        // Nothing to do (e.g. this will happen if Data is a primitive/string type).
                        continue;
                    }

                    switch (dataToken.Type)
                    {
                        case JTokenType.Object:
                            var eventData = dataToken.ToObject(typeOfEventData, jsonSerializer);
                            receivedEvent.Data = eventData;
                            break;
                        case JTokenType.Array:
                            var arrayEventData = JsonConvert.DeserializeObject(
                                dataToken.ToString(),
                                typeOfEventData,
                                jsonSerializer.GetJsonSerializerSettings());
                            receivedEvent.Data = arrayEventData;
                            break;
                        default:
                            break;
                    }
                }
            }

            return eventGridEvents;
        }

        static JsonSerializer GetJsonSerializerWithPolymorphicSupport()
        {
            JsonSerializerSettings deserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                Converters = new List<JsonConverter>
                {
                    new Iso8601TimeSpanConverter()
                }
            };

            JsonSerializer jsonSerializer = JsonSerializer.Create(deserializationSettings);

            // Note: If any of the events have polymorphic data, add converters for them here.
            // This enables the polymorphic deserialization for the event data.
            // For example, MediaJobCompletedEventData's JobOutput type is polymorphic 
            // based on the @odata.type property in the data.

            // Example usage: jsonSerializer.Converters.Add(new PolymorphicDeserializeJsonConverter<JobOutput>("@odata.type"));

            return jsonSerializer;
        }
    }
}
