// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ConnectionContext
    {
        /// <summary>
        /// The type of the message.
        /// </summary>
        public WebPubSubEventType EventType { get; internal set; }

        /// <summary>
        /// The event name of the message.
        /// </summary>
        public string EventName { get; internal set; }

        /// <summary>
        /// The hub which the message belongs to.
        /// </summary>
        public string Hub { get; internal set; }

        /// <summary>
        /// The connection-id of the client which send the message.
        /// </summary>
        public string ConnectionId { get; internal set; }

        /// <summary>
        /// The user identity of the client which send the message.
        /// </summary>
        public string UserId { get; internal set; }

        /// <summary>
        /// The signature for validation
        /// </summary>
        public string Signature { get; internal set; }

        /// <summary>
        /// The headers of request.
        /// </summary>
        public Dictionary<string, StringValues> Headers { get; internal set; }
    }
}
