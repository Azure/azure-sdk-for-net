// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Disconnect sockets
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class DisconnectSocketsAction : SocketIOAction
    {
        /// <summary>
        /// Target namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Optional target rooms. If not set, disconnect the whole namespace.
        /// </summary>
        public IList<string> Rooms { get; set; } = new List<string>();
    }
}
