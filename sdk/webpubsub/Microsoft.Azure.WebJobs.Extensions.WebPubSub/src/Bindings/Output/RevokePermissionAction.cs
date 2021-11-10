﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.WebPubSub;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Operation to remove permission.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class RevokePermissionAction : WebPubSubAction
    {
        /// <summary>
        /// Targe connectionId.
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// Target permission.
        /// </summary>
        public WebPubSubPermission Permission { get; set; }

        /// <summary>
        /// Target name.
        /// </summary>
        public string TargetName { get; set; }
    }
}
