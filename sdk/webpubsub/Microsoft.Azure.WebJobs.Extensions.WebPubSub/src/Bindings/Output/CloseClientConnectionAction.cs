// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Operation to close a connection.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CloseClientConnectionAction : WebPubSubAction
    {
        /// <summary>
        /// Target connectionId.
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// Reason to close the connection.
        /// </summary>
        public string Reason { get; set; }
    }
}
