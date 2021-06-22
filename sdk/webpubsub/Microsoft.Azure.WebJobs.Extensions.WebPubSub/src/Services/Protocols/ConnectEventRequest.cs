// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public sealed class ConnectEventRequest : ServiceRequest
    {
        public IDictionary<string, string[]> Claims { get; }

        public IDictionary<string, string[]> Query { get; }

        public string[] Subprotocols { get; }

        public ClientCertificateInfo[] ClientCertificates { get; }
    }
}
