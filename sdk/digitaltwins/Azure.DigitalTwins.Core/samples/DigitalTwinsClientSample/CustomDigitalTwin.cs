// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.DigitalTwins.Core.Serialization;

namespace Azure.DigitalTwins.Core.Samples
{
    /// <summary>
    /// Custom type for a sample illustrating how someone can create their own class to match a digital twin model type
    /// for serialization, instead of using <see cref="BasicDigitalTwin"/>.
    /// </summary>
    internal class CustomDigitalTwin
    {
        [JsonPropertyName("$dtId")]
        public string Id { get; set; }

        [JsonPropertyName("$etag")]
        public string ETag { get; set; }

        [JsonPropertyName("$metadata")]
        public CustomDigitalTwinMetadata Metadata { get; set; } = new CustomDigitalTwinMetadata();

        [JsonPropertyName("Prop1")]
        public string Prop1 { get; set; }

        [JsonPropertyName("Prop2")]
        public int Prop2 { get; set; }

        [JsonPropertyName("Component1")]
        public Component1 Component1 { get; set; }
    }

    internal class Component1
    {
        [JsonPropertyName("$metadata")]
        public Component1Metadata Metadata { get; set; } = new Component1Metadata();

        [JsonPropertyName("ComponentProp1")]
        public string ComponentProp1 { get; set; }

        [JsonPropertyName("ComponentProp2")]
        public int ComponentProp2 { get; set; }
    }

    internal class Metadata
    {
        [JsonPropertyName("$model")]
        public string ModelId { get; set; }
    }

    internal class CustomDigitalTwinMetadata : Metadata
    {
        [JsonPropertyName("Prop1")]
        public WritableProperty Prop1 { get; set; }

        [JsonPropertyName("Prop2")]
        public WritableProperty Prop2 { get; set; }
    }

    internal class Component1Metadata
    {
        [JsonPropertyName("ComponentProp1")]
        public WritableProperty ComponentProp1 { get; set; }

        [JsonPropertyName("ComponentProp2")]
        public WritableProperty ComponentProp2 { get; set; }
    }
}
