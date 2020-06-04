// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// Properties on a digital twin that adhere to a specific model.
    /// </summary>
    public class ModelProperties
    {
        /// <summary>
        /// Information about the model a digital twin conforms to. This field is present on every digital twin.
        /// </summary>
        [JsonPropertyName("$metadata")]
        public DigitalTwinMetadata Metadata { get; set; } = new DigitalTwinMetadata();

        /// <summary>
        /// Additional properties of the digital twin. This field will contain any properties of the digital twin that are not already defined by the other strong types of this class.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> CustomProperties { get; set; } = new Dictionary<string, object>();
    }
}
