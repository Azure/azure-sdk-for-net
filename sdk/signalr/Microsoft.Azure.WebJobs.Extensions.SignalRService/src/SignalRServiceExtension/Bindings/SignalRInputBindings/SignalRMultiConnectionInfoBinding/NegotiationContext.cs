// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    internal class NegotiationContext
    {
        public EndpointConnectionInfo[] Endpoints { get; set; }
    }
}