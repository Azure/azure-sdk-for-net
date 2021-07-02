// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal sealed class ConnectEventResponse
    {
        [JsonProperty("subprotocol")]
        public string Subprotocol { get; set; }

        [JsonProperty("roles")]
        public string[] Roles { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("groups")]
        public string[] Groups { get; set; }
    }
}
