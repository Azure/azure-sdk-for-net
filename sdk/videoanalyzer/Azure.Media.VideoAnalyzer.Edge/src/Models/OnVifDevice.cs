// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class OnvifDevice
    {
        /// <summary>
        ///  Deserialize OnvifDevice.
        /// </summary>
        /// <param name="json">The json to be deserialized.</param>
        /// <returns>A OnvifDevice.</returns>
        public static OnvifDevice Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            return DeserializeOnvifDevice(element);
        }
    }
}
