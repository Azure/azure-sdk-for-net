// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Azure.Messaging.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public sealed class ConnectEventRequest : ServiceRequest
    {
        public IDictionary<string, string[]> Claims { get; }

        public IDictionary<string, string[]> Query { get; }

        public string[] Subprotocols { get; }

        public ClientCertificateInfo[] ClientCertificates { get; }

        public override string Name => nameof(ConnectEventRequest);

        public ConnectEventRequest(IDictionary<string, string[]> claims, IDictionary<string, string[]> query, string[] subprotocols, ClientCertificateInfo[] clientCertificateInfos)
            : base(false, true)
        {
            Claims = claims;
            Query = query;
            Subprotocols = subprotocols;
            ClientCertificates = clientCertificateInfos;
        }
    }
}
