// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.Redis
{
    internal partial class RedisProperties
    {
        // Backing storage for RedisResource.PrivateEndpointConnections compatibility. This stays on RedisProperties
        // because the public RedisResource property is flattened from the resource properties model.
#pragma warning disable CS0618 // RedisPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        private BicepList<RedisPrivateEndpointConnectionData> _privateEndpointConnections;
#pragma warning restore CS0618

#pragma warning disable CS0618 // RedisPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        internal BicepList<RedisPrivateEndpointConnectionData> PrivateEndpointConnections
#pragma warning restore CS0618
        {
            get
            {
                Initialize();
                return _privateEndpointConnections;
            }
        }

        partial void DefineAdditionalProperties()
        {
#pragma warning disable CS0618 // RedisPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
            _privateEndpointConnections = DefineListProperty<RedisPrivateEndpointConnectionData>("PrivateEndpointConnections", new string[] { "privateEndpointConnections" }, isOutput: true);
#pragma warning restore CS0618
        }
    }
}
