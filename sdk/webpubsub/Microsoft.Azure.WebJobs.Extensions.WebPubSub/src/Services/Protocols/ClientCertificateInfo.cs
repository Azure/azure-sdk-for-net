// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Azure.Messaging.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public sealed class ClientCertificateInfo
    {
        public string Thumbprint { get; }

        public ClientCertificateInfo(string thumbprint)
        {
            Thumbprint = thumbprint;
        }
    }
}
