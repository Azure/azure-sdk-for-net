// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// The $metadata class on a <see cref="BasicDigitalTwin"/>.
    /// </summary>
    /// <remarks>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    [JsonConverter(typeof(DigitalTwinMetadataJsonConverter))]
    public class DigitalTwinMetadata
    {
        /// <summary>
        /// The Id of the model that the digital twin or component is modeled by.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.MetadataModel)]
        public string ModelId { get; set; }

        /// <summary>
        /// This field will contain metadata about changes on properties on the digital twin.
        /// The key will be the property name, and the value is the metadata.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IDictionary<string, DigitalTwinPropertyMetadata> PropertyMetadata { get; set; } = new Dictionary<string, DigitalTwinPropertyMetadata>();
#pragma warning restore CA2227 // Collection properties should be readonly
    }
}
