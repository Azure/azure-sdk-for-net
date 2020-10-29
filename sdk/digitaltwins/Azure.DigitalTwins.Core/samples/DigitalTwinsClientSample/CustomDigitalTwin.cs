// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Samples
{
    /// <summary>
    /// Custom type for a sample illustrating how someone can create their own class to match a digital twin model type
    /// for serialization, instead of using <see cref="BasicDigitalTwin"/>.
    /// </summary>
    internal class CustomDigitalTwin
    {
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinId)]
        public string Id { get; set; }

        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinETag)]
        public string ETag { get; set; }

        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)]
        public BasicDigitalTwinMetadata Metadata { get; set; } = new BasicDigitalTwinMetadata();

        [JsonPropertyName("Prop1")]
        public string Prop1 { get; set; }

        [JsonPropertyName("Prop2")]
        public int Prop2 { get; set; }

        [JsonPropertyName("Component1")]
        public MyCustomComponent Component1 { get; set; }
    }

    internal class MyCustomComponent
    {
        /// <summary>
        /// A component must have a property named $metadata with no client-supplied properties, to be distinguished from other properties as a component.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.DigitalTwinMetadata)]
        public Dictionary<string, DigitalTwinPropertyMetadata> Metadata { get; set; } = new Dictionary<string, DigitalTwinPropertyMetadata>();

        [JsonPropertyName("ComponentProp1")]
        public string ComponentProp1 { get; set; }

        [JsonPropertyName("ComponentProp2")]
        public int ComponentProp2 { get; set; }
    }
}
