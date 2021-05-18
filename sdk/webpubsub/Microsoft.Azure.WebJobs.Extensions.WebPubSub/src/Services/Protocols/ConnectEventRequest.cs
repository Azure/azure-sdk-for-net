// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal sealed class ConnectEventRequest
    {
        [JsonProperty("claims")]
        public IDictionary<string, string[]> Claims { get; set; }

        [JsonProperty("query")]
        public IDictionary<string, string[]> Query { get; set; }

        [JsonProperty("subprotocols")]
        public string[] Subprotocols { get; set; }

        [JsonProperty("clientCertificates")]
        public ClientCertificateInfo[] ClientCertificates { get; set; }
    }
}
