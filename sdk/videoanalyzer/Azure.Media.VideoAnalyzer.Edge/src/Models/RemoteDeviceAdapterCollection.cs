// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    /// <summary>
    /// Extensions methods to RemoteDeviceAdapterCollection to add serialization and deserialization.
    /// </summary>
    public partial class RemoteDeviceAdapterCollection
    {
        /// <summary>
        ///  Deserialize RemoteDeviceAdapterCollection.
        /// </summary>
        /// <param name="json">The json data that is to be deserialized.</param>
        /// <returns>RemoteDeviceAdapterCollection.</returns>
        public static RemoteDeviceAdapterCollection Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            return DeserializeRemoteDeviceAdapterCollection(element);
        }
    }
}
