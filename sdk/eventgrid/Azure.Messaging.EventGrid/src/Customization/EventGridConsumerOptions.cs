// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Options for configuring deserialization in EventGridConsumer.
    /// </summary>
    public class EventGridConsumerOptions
    {
        /// <summary>
        /// Serializer used to decode custom payloads from JSON.
        /// </summary>
        public ObjectSerializer DataSerializer { get; set; } = new JsonObjectSerializer();

        /// <summary>
        /// Contains the mappings for custom event types. For example,
        /// "Contoso.Items.ItemReceived" mapping to type ContosoItemReceivedEventData.
        /// </summary>
        public IDictionary<string, Type> CustomEventTypeMappings { get; private set; } = new Dictionary<string, Type>();
    }
}
