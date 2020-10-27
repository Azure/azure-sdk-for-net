// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin component metadata object.
    /// The $metadata object on a <see cref="BasicDigitalTwinComponent"/>.
    /// </summary>
    /// <remarks>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    public class BasicDigitalTwinComponentMetadata
    {
        /// <summary>
        /// This field will contain metadata about changes on properties on a component.
        /// For your convenience, the value can be deserialized into <see cref="BasicDigitalTwinPropertyMetadata"/>.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> PropertyMetadata { get; set; } = new Dictionary<string, object>();
    }
}
