// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.Redis
{
#pragma warning disable CS0618 // RedisPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
    internal partial class RedisProperties
    {
        private BicepList<RedisPrivateEndpointConnectionData> _privateEndpointConnections;

        internal BicepList<RedisPrivateEndpointConnectionData> PrivateEndpointConnections
        {
            get
            {
                Initialize();
                return _privateEndpointConnections;
            }
        }

        partial void DefineAdditionalProperties()
        {
            _privateEndpointConnections = DefineListProperty<RedisPrivateEndpointConnectionData>("PrivateEndpointConnections", new string[] { "privateEndpointConnections" }, isOutput: true);
        }
    }
#pragma warning restore CS0618
}
