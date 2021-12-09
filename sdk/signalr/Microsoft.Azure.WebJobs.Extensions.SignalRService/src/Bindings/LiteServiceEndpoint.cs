// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Represents a Azure SignalR Service endpoint, a lite version of <see cref="ServiceEndpoint"/> for endpoints routing.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    internal class LiteServiceEndpoint
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EndpointType EndpointType { get; set; }

        public string Name { get; set; }

        public string Endpoint { get; set; }

        public bool Online { get; set; }

        public LiteServiceEndpoint(ServiceEndpoint e)
        {
            EndpointType = e.EndpointType;
            Name = e.Name;
            Endpoint = e.Endpoint;
            Online = e.Online;
        }

        //Used when deserializing
        public LiteServiceEndpoint()
        {
        }
    }
}