// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.DeviceUpdate
{
    public partial class DeviceManagementClient
    {
        /// <summary> Initializes a new instance of <see cref="DeviceManagementClient"/>. </summary>
        /// <param name="endpoint"> The Device Update for IoT Hub account endpoint. </param>
        /// <param name="instanceId"> The Device Update for IoT Hub account instance identifier. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        public DeviceManagementClient(Uri endpoint, string instanceId, TokenCredential credential)
            : this(new BearerTokenAuthenticationPolicy(credential, AuthorizationScopes), endpoint, instanceId, null)
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeviceManagementClient"/>. </summary>
        /// <param name="endpoint"> The Device Update for IoT Hub account endpoint. </param>
        /// <param name="instanceId"> The Device Update for IoT Hub account instance identifier. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public DeviceManagementClient(Uri endpoint, string instanceId, TokenCredential credential, DeviceUpdateClientOptions options)
            : this(new BearerTokenAuthenticationPolicy(credential, AuthorizationScopes), endpoint, instanceId, options)
        {
        }
    }
}