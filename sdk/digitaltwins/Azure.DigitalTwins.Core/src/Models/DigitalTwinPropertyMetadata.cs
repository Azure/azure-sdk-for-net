// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// Contain metadata about changes on properties on a digital twin or component.
    /// </summary>
    public class DigitalTwinPropertyMetadata
    {
        /// <summary>
        /// The date and time the property was last updated.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.MetadataPropertyLastUpdateTime)]
        public DateTimeOffset LastUpdatedOn { get; set; }

        /// <summary>
        /// The date and time the value of the property was sourced.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.MetadataPropertySourceTime)]
        public DateTimeOffset? SourceTime { get; set; }
    }
}
