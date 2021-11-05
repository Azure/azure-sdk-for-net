// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.DeviceUpdate
{
    /// <summary>
    /// Device management service client.
    /// </summary>
    public partial class DevicesClient
    {
        protected DevicesClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesClient"/>.
        /// </summary>
        public DevicesClient(string accountEndpoint, string instanceId, TokenCredential credential)
            : this(accountEndpoint, instanceId, credential, new DeviceUpdateClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesClient"/>.
        /// </summary>
        public DevicesClient(string accountEndpoint, string instanceId, TokenCredential credential, DeviceUpdateClientOptions options)
            : this(
                new ClientDiagnostics(options),
                HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "6ee392c4-d339-4083-b04d-6b7947c6cf78/.default")),
                accountEndpoint,
                instanceId)
        { }
    }
}
