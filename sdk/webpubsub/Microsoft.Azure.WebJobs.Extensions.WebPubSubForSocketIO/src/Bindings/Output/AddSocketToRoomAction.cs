// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Operation to add socket to a room.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AddSocketToRoomAction : SocketIOAction
    {
        /// <summary>
        /// Target socketID.
        /// </summary>
        public string SocketId { get; set; }

        /// <summary>
        /// Target room name.
        /// </summary>
        public string Room { get; set; }
    }
}
