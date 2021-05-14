﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Azure.Messaging.WebPubSub;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class RevokeGroupPermission : WebPubSubOperation
    {
        public string ConnectionId { get; set; }

        public WebPubSubPermission Permission { get; set; }

        public string TargetName { get; set; }
    }
}
