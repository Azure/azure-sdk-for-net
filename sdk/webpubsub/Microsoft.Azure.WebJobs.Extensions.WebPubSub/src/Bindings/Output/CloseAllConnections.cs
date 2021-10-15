// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Operation to close all connections.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CloseAllConnections : WebPubSubOperation
    {
        /// <summary>
        /// ConnectionIds to exclude.
        /// </summary>
        public string[] Excluded { get; set; }

        /// <summary>
        /// Reason to close the connection.
        /// </summary>
        public string Reason { get; set; }
    }
}
