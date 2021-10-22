// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Operations
{
    /// <summary>
    /// Operation to close connections in a group.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CloseGroupConnections : WebPubSubOperation
    {
        /// <summary>
        /// Target group name.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// ConnectionIds to exclude.
        /// </summary>
        public string[] Excluded { get; set; }

        /// <summary>
        /// Reason to close the connections.
        /// </summary>
        public string Reason { get; set; }
    }
}
