// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    internal class EndpointConnectionInfo : LiteServiceEndpoint
    {
        public EndpointConnectionInfo(ServiceEndpoint endpoint) : base(endpoint)
        {
        }

        public SignalRConnectionInfo ConnectionInfo { get; set; }
    }
}