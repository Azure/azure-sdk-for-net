// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    /// <summary>
    /// Extensions methods to DiscoveredOnvifDeviceCollection to add serialization and deserialization.
    /// </summary>
    public partial class DiscoveredOnvifDeviceCollection
    {
        /// <summary>
        ///  Deserialize DiscoveredOnvifDeviceCollection.
        /// </summary>
        /// <param name="json">The json data that is to be deserialized.</param>
        /// <returns>A Json string representation of a list of DiscoveredOnVifDevices.</returns>
        public static DiscoveredOnvifDeviceCollection Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            return DeserializeDiscoveredOnvifDeviceCollection(element);
        }
    }
}
