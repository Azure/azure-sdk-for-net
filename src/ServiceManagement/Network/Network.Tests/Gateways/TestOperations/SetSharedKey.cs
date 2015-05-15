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

    public class SetSharedKey : TestOperation
    {
        private readonly IGatewayOperations gatewayClient;
        private readonly string virtualNetworkSiteName;
        private readonly string localNetworkSiteName;
        private readonly GatewaySetSharedKeyParameters parameters;

        private readonly string oldSharedKey;

        public GatewayGetOperationStatusResponse InvokeResponse { get; private set; }

        public SetSharedKey(IGatewayOperations gatewayClient, string virtualNetworkSiteName, string localNetworkSiteName, GatewaySetSharedKeyParameters parameters)
        {
            this.gatewayClient = gatewayClient;
            this.virtualNetworkSiteName = virtualNetworkSiteName;
            this.localNetworkSiteName = localNetworkSiteName;
            this.parameters = parameters;

            oldSharedKey = gatewayClient.GetSharedKey(virtualNetworkSiteName, localNetworkSiteName).SharedKey;
        }

        public void Invoke()
        {
            InvokeResponse = gatewayClient.SetSharedKey(virtualNetworkSiteName, localNetworkSiteName, parameters);
        }

        public void Undo()
        {
            GatewaySetSharedKeyParameters oldParameters = new GatewaySetSharedKeyParameters()
            {
                Value = oldSharedKey,
            };
            gatewayClient.SetSharedKey(virtualNetworkSiteName, localNetworkSiteName, oldParameters);
        }
    }
}
