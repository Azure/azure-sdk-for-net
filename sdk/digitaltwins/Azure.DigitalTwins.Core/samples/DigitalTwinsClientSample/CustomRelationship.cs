// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Samples
{
    /// <summary>
    /// Custom type for a sample illustrating how someone can create their own class to match a relationship type
    /// for serialization, instead of using <see cref="BasicRelationship"/>.
    /// </summary>
    internal class CustomRelationship
    {
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.RelationshipId)]
        public string Id { get; set; }

        [JsonPropertyName(DigitalTwinsJsonPropertyNames.RelationshipTargetId)]
        public string TargetId { get; set; }

        [JsonPropertyName(DigitalTwinsJsonPropertyNames.RelationshipSourceId)]
        public string SourceId { get; set; }

        [JsonPropertyName(DigitalTwinsJsonPropertyNames.RelationshipName)]
        public string Name { get; set; }

        [JsonPropertyName("Prop1")]
        public string Prop1 { get; set; }

        [JsonPropertyName("Prop2")]
        public int Prop2 { get; set; }
    }
}
