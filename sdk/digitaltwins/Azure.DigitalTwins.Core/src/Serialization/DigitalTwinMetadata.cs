// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// The $metadata class on a <see cref="BasicDigitalTwin" />.
    /// </summary>
    public class DigitalTwinMetadata
    {
        /// <summary>
        /// The Id of the model that this digital twin is modeled by.
        /// </summary>
        [JsonPropertyName("$model")]
        public string ModelId { get; set; }

        /// <summary>
        /// Additional, model-defined properties.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> ModelProperties { get; set; } = new Dictionary<string, object>();
    }
}
