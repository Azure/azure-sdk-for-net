// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.DigitalTwins.Core.Serialization;

namespace Azure.DigitalTwins.Core.Samples
{
    /// <summary>
    /// Custom type for a sample illustrating how someone can create their own class to match a relationship type
    /// for serialization, instead of using <see cref="BasicRelationship"/>.
    /// </summary>
    internal class CustomRelationship
    {
        [JsonPropertyName("$relationshipId")]
        public string Id { get; set; }

        [JsonPropertyName("$targetId")]
        public string TargetId { get; set; }

        [JsonPropertyName("$sourceId")]
        public string SourceId { get; set; }

        [JsonPropertyName("$relationshipName")]
        public string Name { get; set; }

        [JsonPropertyName("Prop1")]
        public string Prop1 { get; set; }

        [JsonPropertyName("Prop2")]
        public int Prop2 { get; set; }
    }
}
