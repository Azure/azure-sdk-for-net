// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Operation to remove a user from group.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class RemoveUserFromGroupAction : WebPubSubAction
    {
        /// <summary>
        /// Target userId.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Target group name.
        /// </summary>
        public string Group { get; set; }
    }
}
