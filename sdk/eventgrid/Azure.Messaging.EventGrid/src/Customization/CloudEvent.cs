// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;

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
        public object Data { get; set; }

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
    }
}
