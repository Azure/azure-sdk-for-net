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

    public class SetDefaultSites : TestOperation
    {
        private readonly IGatewayOperations gatewayClient;
        private readonly string virtualNetworkSiteName;
        private readonly GatewaySetDefaultSiteListParameters parameters;

        private readonly string oldDefaultSite;

        public GatewayGetOperationStatusResponse InvokeResponse { get; private set; }

        public SetDefaultSites(IGatewayOperations gatewayClient, string virtualNetworkSiteName, GatewaySetDefaultSiteListParameters parameters)
        {
            this.gatewayClient = gatewayClient;
            this.virtualNetworkSiteName = virtualNetworkSiteName;
            this.parameters = parameters;

            GatewayGetResponse getGatewayResponse = gatewayClient.Get(virtualNetworkSiteName);
            if (getGatewayResponse.DefaultSite == null || string.IsNullOrEmpty(getGatewayResponse.DefaultSite.Name))
            {
                oldDefaultSite = "";
            }
            else
            {
                oldDefaultSite = getGatewayResponse.DefaultSite.Name;    
            }
        }

        public void Invoke()
        {
            InvokeResponse = gatewayClient.SetDefaultSites(virtualNetworkSiteName, parameters);
        }

        public void Undo()
        {
            if (oldDefaultSite != parameters.DefaultSite)
            {
                if (string.IsNullOrEmpty(oldDefaultSite))
                {
                    gatewayClient.RemoveDefaultSites(virtualNetworkSiteName);
                }
                else
                {
                    gatewayClient.SetDefaultSites(virtualNetworkSiteName,
                    new GatewaySetDefaultSiteListParameters()
                    {
                        DefaultSite = oldDefaultSite,
                    });   
                }
            }
        }
    }
}
