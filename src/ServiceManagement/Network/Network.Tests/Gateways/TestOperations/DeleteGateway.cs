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
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;

    public class DeleteGateway : TestOperation
    {
        private readonly IGatewayOperations gatewayClient;
        private readonly string virtualNetworkSiteName;

        private readonly GatewayGetResponse oldGetGatewayResponse;

        public GatewayGetOperationStatusResponse InvokeResponse { get; private set; }

        public DeleteGateway(IGatewayOperations gatewayClient, string virtualNetworkSiteName)
        {
            this.gatewayClient = gatewayClient;
            this.virtualNetworkSiteName = virtualNetworkSiteName;

            oldGetGatewayResponse = gatewayClient.Get(virtualNetworkSiteName);
        }

        public void Invoke()
        {
            InvokeResponse = gatewayClient.Delete(virtualNetworkSiteName);
        }

        public void Undo()
        {
            if (oldGetGatewayResponse.State == GatewayProvisioningEventStates.Provisioned)
            {
                GatewayCreateParameters createParameters = new GatewayCreateParameters()
                {
                    GatewayType = oldGetGatewayResponse.GatewayType,
                };
                gatewayClient.Create(virtualNetworkSiteName, createParameters);
            }
        }
    }
}
