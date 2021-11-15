// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Operation to remove user from all groups.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class RemoveUserFromAllGroupsAction : WebPubSubAction
    {
        /// <summary>
        /// Target UserId.
        /// </summary>
        public string UserId { get; set; }
    }
}
