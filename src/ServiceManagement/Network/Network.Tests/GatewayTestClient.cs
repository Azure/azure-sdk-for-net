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

namespace Network.Tests
{
    using System;
    using System.Threading;
    using Gateways.TestOperations;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Microsoft.Azure;

    public class GatewayTestClient
    {
        private readonly NetworkTestClient testClient;
        private readonly IGatewayOperations gatewayClient;

        public GatewayTestClient(NetworkTestClient testClient, IGatewayOperations gatewayClient)
        {
            this.testClient = testClient;
            this.gatewayClient = gatewayClient;
        }

        public void EnsureNoGatewayExists()
        {
            EnsureNoGatewayExists(NetworkTestConstants.VirtualNetworkSiteName);
        }

        public void EnsureNoGatewayExists(string virtualNetworkSiteName)
        {
            string configuration = testClient.GetNetworkConfigurationSafe();
            if (testClient.IsEmptyConfiguration(configuration) == false)
            {
                bool gatewayDoesntExist = false;
                while (gatewayDoesntExist == false)
                {
                    GatewayGetResponse getGatewayResponse = GetGateway(virtualNetworkSiteName);
                    switch (getGatewayResponse.State)
                    {
                        case GatewayProvisioningEventStates.NotProvisioned:
                            gatewayDoesntExist = true;
                            break;

                        case GatewayProvisioningEventStates.Provisioning:
                        case GatewayProvisioningEventStates.Deprovisioning:
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            break;

                        case GatewayProvisioningEventStates.Provisioned:
                            DeleteGateway(virtualNetworkSiteName);
                            break;
                    }
                }
            }
        }

        public void EnsureStaticRoutingGatewayExists()
        {
            testClient.EnsureSiteToSiteNetworkConfigurationExists();

            EnsureGatewayExists(NetworkTestConstants.CreateStaticRoutingGatewayParameters());
        }
        public void EnsureDynamicRoutingGatewayExists(string sku = GatewaySKU.Default)
        {
            testClient.EnsurePointToSiteNetworkConfigurationExists();

            EnsureGatewayExists(NetworkTestConstants.CreateDynamicRoutingGatewayParameters(sku));
        }
        private void EnsureGatewayExists(GatewayCreateParameters createGatewayParameters)
        {
            bool gatewayExists = false;
            while (gatewayExists == false)
            {
                GatewayGetResponse getGatewayResponse = GetGateway(NetworkTestConstants.VirtualNetworkSiteName);
                switch (getGatewayResponse.State)
                {
                    case GatewayProvisioningEventStates.NotProvisioned:
                        CreateGateway(NetworkTestConstants.VirtualNetworkSiteName, createGatewayParameters);
                        break;

                    case GatewayProvisioningEventStates.Provisioning:
                    case GatewayProvisioningEventStates.Deprovisioning:
                        Thread.Sleep(TimeSpan.FromSeconds(10));
                        break;

                    case GatewayProvisioningEventStates.Provisioned:
                        gatewayExists = true;
                        break;
                }
            }
        }

        public GatewayGetResponse GetGateway(string virtualNetworkSiteName)
        {
            return gatewayClient.Get(virtualNetworkSiteName);
        }

        public GatewayGetOperationStatusResponse CreateGateway(string virtualNetworkSiteName, GatewayCreateParameters parameters)
        {
            CreateGateway operation = new CreateGateway(gatewayClient, virtualNetworkSiteName, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public GatewayGetOperationStatusResponse DeleteGateway(string virtualNetworkSiteName)
        {
            DeleteGateway operation = new DeleteGateway(gatewayClient, virtualNetworkSiteName);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public GatewayGetOperationStatusResponse GenerateVpnClientPackage(string virtualNetworkSiteName, GatewayGenerateVpnClientPackageParameters parameters)
        {
            return gatewayClient.GenerateVpnClientPackage(virtualNetworkSiteName, parameters);
        }

        public GatewayDiagnosticsStatus GetDiagnostics(string virtualNetworkSiteName)
        {
            return gatewayClient.GetDiagnostics(virtualNetworkSiteName);
        }

        public GatewayGetSharedKeyResponse GetSharedKey(string virtualNetworkSiteName, string localNetworkSiteName)
        {
            return gatewayClient.GetSharedKey(virtualNetworkSiteName, localNetworkSiteName);
        }

        public GatewayGetOperationStatusResponse ResetSharedKey(string virtualNetworkSiteName, string localNetworkSiteName, GatewayResetSharedKeyParameters parameters)
        {
            ResetSharedKey operation = new ResetSharedKey(gatewayClient, virtualNetworkSiteName, localNetworkSiteName, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public GatewayGetOperationStatusResponse SetSharedKey(string virtualNetworkSiteName, string localNetworkSiteName, GatewaySetSharedKeyParameters parameters)
        {
            SetSharedKey operation = new SetSharedKey(gatewayClient, virtualNetworkSiteName, localNetworkSiteName, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public GatewayGetOperationStatusResponse StartDiagnostics(string virtualNetworkSiteName, StartGatewayPublicDiagnosticsParameters parameters)
        {
            return gatewayClient.StartDiagnostics(virtualNetworkSiteName, parameters);
        }

        public GatewayOperationResponse StopDiagnostics(string virtualNetworkSiteName, StopGatewayPublicDiagnosticsParameters parameters)
        {
            return gatewayClient.StopDiagnostics(virtualNetworkSiteName, parameters);
        }

        public GatewayGetOperationStatusResponse SetDefaultSites(string virtualNetworkSiteName, GatewaySetDefaultSiteListParameters parameters)
        {
            SetDefaultSites operation = new SetDefaultSites(gatewayClient, virtualNetworkSiteName, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }
        public GatewayGetOperationStatusResponse RemoveDefaultSites(string virtualNetworkSiteName)
        {
            RemoveDefaultSites operation = new RemoveDefaultSites(gatewayClient, virtualNetworkSiteName);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public GatewayGetOperationStatusResponse ResizeGateway(string virtualNetworkSiteName, ResizeGatewayParameters parameters)
        {
            ResizeGateway operation = new ResizeGateway(gatewayClient, virtualNetworkSiteName, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public GatewayGetIPsecParametersResponse GetIPsecParameters(string virtualNetworkSiteName, string localNetworkSiteName)
        {
            return gatewayClient.GetIPsecParameters(virtualNetworkSiteName, localNetworkSiteName);
        }

        public GatewayGetOperationStatusResponse SetIPsecParameters(string virtualNetworkSiteName, string localNetworkSiteName, GatewaySetIPsecParametersParameters parameters)
        {
            SetIPsecParameters operation = new SetIPsecParameters(gatewayClient, virtualNetworkSiteName, localNetworkSiteName, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public GatewayGetOperationStatusResponse ResetGateway(string virtualNetworkSiteName, ResetGatewayParameters parameters)
        {
            return gatewayClient.Reset(virtualNetworkSiteName, parameters);
        }

        // Brooklyn Co-existance new APIs
        public GatewayGetOperationStatusResponse CreateVirtualNetworkGateway(string virtualNetworkSiteName, VirtualNetworkGatewayCreateParameters parameters)
        {
            return gatewayClient.CreateVirtualNetworkGateway(virtualNetworkSiteName, parameters);
        }

        public GatewayGetOperationStatusResponse ResizeVirtualNetworkGateway(string gatewayId, ResizeGatewayParameters parameters)
        {
            return gatewayClient.ResizeVirtualNetworkGateway(gatewayId, parameters);
        }

        public GatewayGetOperationStatusResponse ResetVirtualNetworkGateway(string gatewayId, ResetGatewayParameters parameters)
        {
            return gatewayClient.ResetVirtualNetworkGateway(gatewayId, parameters);
        }

        public VirtualNetworkGatewayGetResponse GetVirtualNetworkGateway(string gatewayId)
        {
            return gatewayClient.GetVirtualNetworkGateway(gatewayId);
        }

        public ListVirtualNetworkGatewaysResponse ListVirtualNetworkGateways()
        {
            return gatewayClient.ListVirtualNetworkGateways();
        }

        public GatewayGetOperationStatusResponse DeleteVirtualNetworkGateway(string gatewayId)
        {
            return gatewayClient.DeleteVirtualNetworkGateway(gatewayId);
        }

        public LocalNetworkGatewayCreateResponse CreateLocalNetworkGateway(LocalNetworkGatewayCreateParameters parameters)
        {
            return gatewayClient.CreateLocalNetworkGateway(parameters);
        }

        public AzureOperationResponse UpdateLocalNetworkGateway(string gatewayId, UpdateLocalNetworkGatewayParameters parameters)
        {
            return gatewayClient.UpdateLocalNetworkGateway(gatewayId, parameters);
        }

        public LocalNetworkGatewayGetResponse GetLocalNetworkGateway(string gatewayId)
        {
            return gatewayClient.GetLocalNetworkGateway(gatewayId);
        }

        public ListLocalNetworkGatewaysResponse ListLocalNetworkGateways()
        {
            return gatewayClient.ListLocalNetworkGateways();
        }

        public AzureOperationResponse DeleteLocalNetworkGateway(string gatewayId)
        {
            return gatewayClient.DeleteLocalNetworkGateway(gatewayId);
        }

        public GatewayGetOperationStatusResponse CreateGatewayConnection(GatewayConnectionCreateParameters parameters)
        {
            return gatewayClient.CreateGatewayConnection(parameters);
        }

        public GatewayGetOperationStatusResponse UpdateGatewayConnection(string gatewayId, string connectedentityId, UpdateGatewayConnectionParameters parameters)
        {
            return gatewayClient.UpdateGatewayConnection(gatewayId, connectedentityId, parameters);
        }

        public GatewayConnectionGetResponse GetGatewayConnection(string gatewayId, string connectedentityId)
        {
            return gatewayClient.GetGatewayConnection(gatewayId, connectedentityId);
        }

        public GatewayListGatewayConnectionsResponse ListGatewayConnections()
        {
            return gatewayClient.ListGatewayConnections();
        }

        public GatewayGetOperationStatusResponse DeleteGatewayConnection(string gatewayId, string connectedentityId)
        {
            return gatewayClient.DeleteGatewayConnection(gatewayId, connectedentityId);
        }

        public GatewayGetSharedKeyResponse GetSharedKeyV2(string gatewayId, string connectedentityId)
        {
            return gatewayClient.GetSharedKeyV2(gatewayId, connectedentityId);
        }

        public GatewayGetOperationStatusResponse ResetSharedKeyV2(string gatewayId, string connectedentityId, GatewayResetSharedKeyParameters parameters)
        {
            return gatewayClient.ResetSharedKeyV2(gatewayId, connectedentityId, parameters);
        }

        public GatewayGetOperationStatusResponse SetSharedKeyV2(string gatewayId, string connectedentityId, GatewaySetSharedKeyParameters parameters)
        {
            return gatewayClient.SetSharedKeyV2(gatewayId, connectedentityId, parameters);
        }

        public GatewayGetIPsecParametersResponse GetIPsecParametersV2(string gatewayId, string connectedentityId)
        {
            return gatewayClient.GetIPsecParametersV2(gatewayId, connectedentityId);
        }

        public GatewayGetOperationStatusResponse SetIPsecParametersV2(string gatewayId, string connectedentityId, GatewaySetIPsecParametersParameters parameters)
        {
            return gatewayClient.SetIPsecParametersV2(gatewayId, connectedentityId, parameters);
        }

        public GatewayGetOperationStatusResponse StartDiagnosticsV2(string gatewayId, StartGatewayPublicDiagnosticsParameters parameters)
        {
            return gatewayClient.StartDiagnosticsV2(gatewayId, parameters);
        }

        public GatewayOperationResponse StopDiagnosticsV2(string gatewayId, StopGatewayPublicDiagnosticsParameters parameters)
        {
            return gatewayClient.StopDiagnosticsV2(gatewayId, parameters);
        }

        public GatewayDiagnosticsStatus GetDiagnosticsV2(string gatewayId)
        {
            return gatewayClient.GetDiagnosticsV2(gatewayId);
        }
    }
}
