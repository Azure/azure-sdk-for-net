// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ConnectResponse : ServiceResponse
    {
        [JsonProperty(Required = Required.Default)]
        public string UserId { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string[] Groups { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string Subprotocol { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string[] Roles { get; set; }
    }
}
