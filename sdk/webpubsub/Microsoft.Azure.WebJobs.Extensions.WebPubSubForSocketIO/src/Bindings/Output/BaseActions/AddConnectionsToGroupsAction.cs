﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.BaseActions
{
    /// <summary>
    /// Add filtered connections to multiple groups.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    internal class AddConnectionsToGroupsAction : WebPubSubAction
    {
        /// <summary>
        /// Target groups
        /// </summary>
        public IList<string> Groups { get; set; }

        /// <summary>
        /// The filter
        /// </summary>
        public string Filter { get; set; }
    }
}
