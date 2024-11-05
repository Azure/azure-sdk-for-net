// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.BaseActions
{
    /// <summary>
    /// Operation to close connections in a group.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    internal class CloseGroupConnectionsAction : WebPubSubAction
    {
        /// <summary>
        /// Target group name.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// ConnectionIds to exclude.
        /// </summary>
        public IList<string> Excluded { get; set; } = new List<string>();

        /// <summary>
        /// Reason to close the connections.
        /// </summary>
        public string Reason { get; set; }
    }
}
