// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Options for configuring deserialization in EventGridConsumer.
    /// </summary>
    public class EventGridConsumerOptions
    {
        /// <summary>
        /// Serializer used to decode events and custom payloads from JSON.
        /// </summary>
        public ObjectSerializer ObjectSerializer { get; set; } = new JsonObjectSerializer();

        /// <summary>
        /// Contains the mappings for custom event types. For example, "Contoso.Items.ItemReceived" mapping to ContosoItemReceivedEventData.
        /// </summary>
        public IDictionary<string, Type> CustomEventTypeMappings => new Dictionary<string, Type>();
    }
}
