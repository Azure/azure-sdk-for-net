// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class DigitalTwinMetadata
    {
        /// <summary>
        /// The Id of the model that the digital twin or component is modeled by.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.MetadataModel)]
        public string ModelId { get; set; }
    }
}
