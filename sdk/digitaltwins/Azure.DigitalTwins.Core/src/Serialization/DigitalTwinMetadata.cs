// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// The $metadata class on a <see cref="BasicDigitalTwin"/> and <see cref="ModelProperties"/>.
    /// </summary>
    /// <remarks>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    public class DigitalTwinMetadata
    {
        /// <summary>
        /// The Id of the model that the digital twin or component is modeled by.
        /// </summary>
        [JsonPropertyName("$model")]
        public string ModelId { get; set; }

        /// <summary>
        /// Model-defined writable properties' request state.
        /// </summary>
        /// <remarks>For your convenience, the value of each dictionary object can be turned into an instance of <see cref="WritableProperty"/>.</remarks>
        [JsonExtensionData]
        public IDictionary<string, object> WriteableProperties { get; } = new Dictionary<string, object>();
    }
}
