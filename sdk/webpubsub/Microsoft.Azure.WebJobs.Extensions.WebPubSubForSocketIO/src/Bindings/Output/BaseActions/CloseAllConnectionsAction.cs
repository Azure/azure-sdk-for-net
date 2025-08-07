// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.BaseActions
{
    /// <summary>
    /// Operation to close all connections.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    internal class CloseAllConnectionsAction : WebPubSubAction
    {
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
