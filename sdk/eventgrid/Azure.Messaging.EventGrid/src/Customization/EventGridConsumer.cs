// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
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
        /// <param name="options"></param>
        public EventGridConsumer(EventGridConsumerOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));
            _objectSerializer = options.ObjectSerializer;
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
        {
            List<EventGridEventInternal> egInternalEvents = new List<EventGridEventInternal>();
            List<EventGridEvent> egEvents = new List<EventGridEvent>();

            // Deserialize raw JSON string into separate events, deserialize event envelope properties
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            JsonDocument requestDocument = JsonDocument.Parse(stream, default);
            foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
            {
                egInternalEvents.Add(EventGridEventInternal.DeserializeEventGridEventInternal(property));
            }

            // Deserialize 'Data' property from JsonElement for each event
            foreach (EventGridEventInternal egEventInternal in egInternalEvents)
            {
                JsonElement dataElement = egEventInternal.Data;
                object egEventData = null;
                // better to use ObjectSerializer?
                MemoryStream dataStream = new MemoryStream(Encoding.UTF8.GetBytes(dataElement.ToString()));

                // First, let's attempt to find the mapping for the deserialization function in the system event type mapping.
                if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(egEventInternal.EventType, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    egEventData = systemDeserializationFunction(dataElement);
                }
                // If not a system event, let's attempt to find the mapping for the event type in the custom event mapping.
                else if (_customEventTypeMappings.TryGetValue(egEventInternal.EventType, out Type typeOfEventData))
                {
                    if (dataElement.ValueKind == JsonValueKind.True || dataElement.ValueKind == JsonValueKind.False)
                    {
                        egEventData = dataElement.GetBoolean();
                    }
                    else if (dataElement.ValueKind == JsonValueKind.Number)
                    {
                        var oki = dataElement.TryGetInt32(out var vali);
                        if (oki)
                        {
                            egEventData = vali;
                        }
                        var okl = dataElement.TryGetInt64(out var vall);
                        if (okl)
                        {
                            egEventData = vall;
                        }
                        var okd = dataElement.TryGetDouble(out var val);
                        if (okd)
                        {
                            egEventData = val;
                        }
                    }
                    else if (dataElement.ValueKind == JsonValueKind.String)
                    {
                        egEventData = dataElement.GetString();
                    }
                    else
                    {
                        egEventData = _objectSerializer.Deserialize(dataStream, typeOfEventData, cancellationToken);
                    }
                }
                else
                {
                    // perhaps return as BinaryData?
                    //MemoryStream dataStream = new MemoryStream();
                    //ObjectSerializer.Serialize(dataStream, egEvent.Data, egEvent.Data.GetType(), cancellationToken);
                    //dataStream.Seek(0, SeekOrigin.Begin);
                    //egEvent.Data = BinaryData.FromStream(dataStream);

                    egEventData = egEventInternal.Data.ToString();
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
        {
            List<CloudEventInternal> cloudEventsInternal = new List<CloudEventInternal>();
            List<CloudEvent> cloudEvents = new List<CloudEvent>();

            // Deserialize raw JSON string into separate events, deserialize event envelope properties
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(requestContent));
            JsonDocument requestDocument = JsonDocument.Parse(stream, default);
            foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
            {
                cloudEventsInternal.Add(CloudEventInternal.DeserializeCloudEventInternal(property));
            }

            // Deserialize 'Data' property from JsonElement for each event
            foreach (CloudEventInternal cloudEventInternal in cloudEventsInternal)
            {
                JsonElement dataElement = cloudEventInternal.Data;
                object cloudEventData = null;
                MemoryStream dataStream = new MemoryStream(Encoding.UTF8.GetBytes(dataElement.ToString()));

                if (cloudEventInternal.DataBase64 != null)
                {
                    cloudEventData = Convert.FromBase64String(cloudEventInternal.DataBase64);
                }
                // First, let's attempt to find the mapping for the deserialization function in the system event type mapping.
                else if (SystemEventTypeMappings.SystemEventDeserializers.TryGetValue(cloudEventInternal.Type, out Func<JsonElement, object> systemDeserializationFunction))
                {
                    cloudEventData = systemDeserializationFunction(dataElement);
                }
                // If not a system event, let's attempt to find the mapping for the event type in the custom event mapping.
                else if (_customEventTypeMappings.TryGetValue(cloudEventInternal.Type, out Type typeOfEventData))
                {
                    if (dataElement.ValueKind == JsonValueKind.True || dataElement.ValueKind == JsonValueKind.False)
                    {
                        cloudEventData = dataElement.GetBoolean();
                    }
                    else if (dataElement.ValueKind == JsonValueKind.Number)
                    {
                        var oki = dataElement.TryGetInt32(out var vali);
                        if (oki)
                        {
                            cloudEventData = vali;
                        }
                        var okl = dataElement.TryGetInt64(out var vall);
                        if (okl)
                        {
                            cloudEventData = vall;
                        }
                        var okd = dataElement.TryGetDouble(out var val);
                        if (okd)
                        {
                            cloudEventData = val;
                        }
                    }
                    else if (dataElement.ValueKind == JsonValueKind.String)
                    {
                        cloudEventData = dataElement.GetString();
                    }
                    else
                    {
                        cloudEventData = _objectSerializer.Deserialize(dataStream, typeOfEventData, cancellationToken);
                    }
                }

                cloudEvents.Add(new CloudEvent(
                    cloudEventInternal.Source,
                    cloudEventInternal.Type)
                {
                    Id = cloudEventInternal.Id,
                    Data = cloudEventData,
                    Time = cloudEventInternal.Time,
                    SpecVersion = cloudEventInternal.Specversion,
                    DataSchema = cloudEventInternal.Dataschema,
                    DataContentType = cloudEventInternal.Datacontenttype,
                    Subject = cloudEventInternal.Subject
                });
            }

            return cloudEvents.ToArray();
        }
    }
}
