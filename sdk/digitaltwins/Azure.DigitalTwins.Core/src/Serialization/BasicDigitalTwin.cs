// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// </summary>
    public class BasicDigitalTwin
    {
        /// <summary>
        /// The unique Id of the digital twin in a digital twins instance. This field is present on every digital twin.
        /// </summary>
        [JsonPropertyName("$dtId")]
        public string Id { get; set; }

        /// <summary>
        /// Information about the model a digital twin conforms to. This field is present on every digital twin.
        /// </summary>
        [JsonPropertyName("$metadata")]
        public DigitalTwinMetadata Metadata { get; set; }

        /// <summary>
        /// Additional properties of the digital twin. This field will contain any properties of the digital twin that are not already defined by the other strong types of this class.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> CustomProperties { get; set; } = new Dictionary<string, object>();
    }
}
