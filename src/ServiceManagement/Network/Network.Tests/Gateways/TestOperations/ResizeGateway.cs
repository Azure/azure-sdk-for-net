// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Network.Tests.Gateways.TestOperations
{
    using System;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;

    public class ResizeGateway : TestOperation
    {
        private readonly IGatewayOperations gatewayClient;
        private readonly string virtualNetworkSiteName;
        private readonly ResizeGatewayParameters parameters;

        private readonly GatewayGetResponse oldGetResponse;

        public GatewayGetOperationStatusResponse InvokeResponse { get; private set; }

        public ResizeGateway(IGatewayOperations gatewayClient, string virtualNetworkSiteName, ResizeGatewayParameters parameters)
        {
            this.gatewayClient = gatewayClient;
            this.virtualNetworkSiteName = virtualNetworkSiteName;
            this.parameters = parameters;

            if (string.IsNullOrWhiteSpace(virtualNetworkSiteName) == false)
            {
                oldGetResponse = gatewayClient.Get(virtualNetworkSiteName);
            }
        }

        public void Invoke()
        {
            InvokeResponse = gatewayClient.Resize(virtualNetworkSiteName, parameters);
        }

        public void Undo()
        {
            if (parameters != null &&
                oldGetResponse != null &&
                oldGetResponse.State == GatewayProvisioningEventStates.Provisioned &&
                string.Equals(oldGetResponse.GatewaySKU, parameters.GatewaySKU, StringComparison.InvariantCultureIgnoreCase) == false)
            {
                ResizeGatewayParameters oldResizeParameters = new ResizeGatewayParameters()
                {
                    GatewaySKU = oldGetResponse.GatewaySKU,
                };

                gatewayClient.Resize(virtualNetworkSiteName, oldResizeParameters);
            }
        }
    }
}
