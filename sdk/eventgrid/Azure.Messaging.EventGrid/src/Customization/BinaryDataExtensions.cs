// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Extension methods for BinaryData to use for parsing JSON-encoded events.
    /// </summary>
    public static class BinaryDataExtensions
    {
        /// <summary>
        /// Given a single JSON-encoded event, parses the event envelope and returns an EventGridEvent.
        /// </summary>
        /// <param name="binaryData"> Specifies the instance of <see cref="BinaryData"/>. </param>
        /// <returns> An <see cref="EventGridEvent"/>. </returns>
        public static EventGridEvent ToEventGridEvent(this BinaryData binaryData)
        {
            // Deserialize JsonElement to single event, parse event envelope properties
            JsonDocument requestDocument = JsonDocument.Parse(binaryData.ToBytes());
            EventGridEventInternal egEventInternal = EventGridEventInternal.DeserializeEventGridEventInternal(requestDocument.RootElement);

            EventGridEvent egEvent = new EventGridEvent()
            {
                Subject = egEventInternal.Subject,
                EventType = egEventInternal.EventType,
                DataVersion = egEventInternal.DataVersion,
                Id = egEventInternal.Id,
                EventTime = egEventInternal.EventTime,
                SerializedData = egEventInternal.Data
            };

            return egEvent;
        }

        /// <summary>
        /// Given a single JSON-encoded event, parses the event envelope and returns a CloudEvent.
        /// </summary>
        /// <param name="binaryData"> Specifies the instance of <see cref="BinaryData"/>. </param>
        /// <returns> A <see cref="CloudEvent"/>. </returns>
        public static CloudEvent ToCloudEvent(this BinaryData binaryData)
        {
            // Deserialize JsonElement to single event, parse event envelope properties
            JsonDocument requestDocument = JsonDocument.Parse(binaryData.ToBytes());
            CloudEventInternal cloudEventInternal = CloudEventInternal.DeserializeCloudEventInternal(requestDocument.RootElement);

            // Case where Data and Type are null - cannot pass null Type into CloudEvent constructor
            if (cloudEventInternal.Type == null)
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
                SerializedData = cloudEventInternal.Data
            };

            if (cloudEventInternal.AdditionalProperties != null)
            {
                foreach (KeyValuePair<string, object> kvp in cloudEventInternal.AdditionalProperties)
                {
                    cloudEvent.ExtensionAttributes.Add(kvp.Key, kvp.Value);
                }
            }

            return cloudEvent;
        }
    }
}
