// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// Properties on a component that adhere to a specific model.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This helper class will only work with <see cref="System.Text.Json"/>. When used with the <see cref="Azure.Core.Serialization.ObjectSerializer"/>,
    /// parameter to <see cref="DigitalTwinsClientOptions" /> it will only work with the default (<see cref="Azure.Core.Serialization.JsonObjectSerializer"/>).
    /// </para>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    [JsonConverter(typeof(BasicDigitalTwinComponentJsonConverter))]
    public class BasicDigitalTwinComponent
    {
        /// <summary>
        /// The date and time the component was last updated.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.MetadataLastUpdateTime)]
        public DateTimeOffset? LastUpdatedOn { get; internal set; }

        /// <summary>
        /// The component metadata.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)]
#pragma warning disable CA2227 // Collection properties should be readonly
        public IDictionary<string, DigitalTwinPropertyMetadata> Metadata { get; set; } = new Dictionary<string, DigitalTwinPropertyMetadata>();
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// This field will contain properties and components as defined in the contents section of the DTDL definition of the twin.
        /// </summary>
        [JsonExtensionData]
#pragma warning disable CA2227 // Collection properties should be readonly
        public IDictionary<string, object> Contents { get; set; } = new Dictionary<string, object>();
#pragma warning restore CA2227 // Collection properties should be readonly
    }
}
