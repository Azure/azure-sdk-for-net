// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Operation to send message to rooms
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendToRoomsAction : SocketIOAction
    {
        /// <summary>
        /// Target rooms.
        /// </summary>
        public IList<string> Rooms { get; set; } = new List<string>();

        /// <summary>
        /// The event name.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Message parameters.
        /// </summary>
        public IList<object> Parameters { get; set; }

        /// <summary>
        /// Except rooms
        /// </summary>
        public IList<string> ExceptRooms { get; set; }
    }
}
