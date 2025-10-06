// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Operation to send message to a socket
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendToSocketAction : SocketIOAction
    {
        /// <summary>
        /// Target socketID.
        /// </summary>
        public string SocketId { get; set; }

        /// <summary>
        /// The event name.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Message parameters.
        /// </summary>
        public IList<object> Parameters { get; set; }
    }
}
