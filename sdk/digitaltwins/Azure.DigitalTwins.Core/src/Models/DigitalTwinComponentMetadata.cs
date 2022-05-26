// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// The $metadata class on a <see cref="BasicDigitalTwinComponent"/>.
    /// </summary>
    /// <remarks>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    [JsonConverter(typeof(DigitalTwinComponentMetadataJsonConverter))]
    public class DigitalTwinComponentMetadata
    {
        /// <summary>
        /// The date and time the component was last updated.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.MetadataLastUpdateTime)]
        public string LastUpdatedOn { get; set; }

        /// <summary>
        /// This field will contain metadata about changes on properties on the component.
        /// The key will be the property name, and the value is the metadata.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IDictionary<string, DigitalTwinPropertyMetadata> PropertyMetadata { get; set; } = new Dictionary<string, DigitalTwinPropertyMetadata>();
#pragma warning restore CA2227 // Collection properties should be readonly
    }
}
