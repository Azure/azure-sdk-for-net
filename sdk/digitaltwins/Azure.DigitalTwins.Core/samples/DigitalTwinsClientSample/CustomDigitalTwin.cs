// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Samples
{
    /// <summary>
    /// Custom type for a sample illustrating how someone can create their own class to match a digital twin model type
    /// for serialization, instead of using <see cref="BasicDigitalTwin"/>.
    /// </summary>
    internal class CustomDigitalTwin : IDigitalTwin
    {
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinId)]
        public string Id { get; set; }

        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinETag)]
        public ETag ETag { get; set; }

        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)]
        public DigitalTwinMetadata Metadata { get; set; } = new DigitalTwinMetadata();

        [JsonPropertyName("Prop1")]
        public string Prop1 { get; set; }

        [JsonPropertyName("Prop2")]
        public int Prop2 { get; set; }

        [JsonPropertyName("Component1")]
        public MyCustomComponent Component1 { get; set; }
    }

    internal class MyCustomComponent
    {
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)]
        public DigitalTwinMetadata Metadata { get; set; } = new DigitalTwinMetadata();

        [JsonPropertyName("ComponentProp1")]
        public string ComponentProp1 { get; set; }

        [JsonPropertyName("ComponentProp2")]
        public int ComponentProp2 { get; set; }
    }
}
