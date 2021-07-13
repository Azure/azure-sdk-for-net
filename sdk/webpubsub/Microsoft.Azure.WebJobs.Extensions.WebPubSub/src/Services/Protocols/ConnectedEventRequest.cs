// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Azure.Messaging.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ConnectedEventRequest : ServiceRequest
    {
        public override string Name => nameof(ConnectEventRequest);

        public ConnectedEventRequest() : base(false, true)
        {
        }
    }
}
