// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class RemoteDeviceAdapter
    {
        /// <summary>
        ///  Deserialize RemoteDeviceAdapter.
        /// </summary>
        /// <param name="json">The json to be deserialized.</param>
        /// <returns>A RemoteDeviceAdapter.</returns>
        public static RemoteDeviceAdapter Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            return DeserializeRemoteDeviceAdapter(element);
        }
    }
}
