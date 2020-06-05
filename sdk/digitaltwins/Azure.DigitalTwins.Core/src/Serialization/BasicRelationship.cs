// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// Although relationships have a user-defined schema, these properties should exist on every instance. This is
    /// useful to use as a base class to ensure your custom relationships have the necessary properties.
    /// </summary>
    public class BasicRelationship
    {
        /// <summary>
        /// The unique Id of the relationship. This field is present on every relationship.
        /// </summary>
        [JsonPropertyName("$relationshipId")]
        public string Id { get; set; }

        /// <summary>
        /// The unique Id of the target digital twin. This field is present on every relationship.
        /// </summary>
        [JsonPropertyName("$targetId")]
        public string TargetId { get; set; }

        /// <summary>
        /// The unique Id of the source digital twin. This field is present on every relationship.
        /// </summary>
        [JsonPropertyName("$sourceId")]
        public string SourceId { get; set; }

        /// <summary>
        /// The name of the relationship, which defines the type of link (e.g. Contains). This field is present on every relationship.
        /// </summary>
        [JsonPropertyName("$relationshipName")]
        public string Name { get; set; }

        /// <summary>
        /// Additional properties defined in the model. This field will contain any properties of the relationship that are not already defined by the other strong types of this class.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> CustomProperties { get; set; } = new Dictionary<string, object>();
    }
}
