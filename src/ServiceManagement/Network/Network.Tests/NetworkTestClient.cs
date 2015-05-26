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

using Microsoft.Azure;

namespace Network.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Microsoft.Azure.Test;
    using Networks.TestOperations;
    using Xunit;

    public class NetworkTestClient : IDisposable
    {
        private readonly UndoContext undoContext;
        private readonly IList<TestOperation> testOperations;
        private readonly NetworkManagementClient networkClient;
        public ApplicationGatewayTestClient ApplicationGateways
        {
            get
            {
                if (applicationGateways == null)
                {
                    applicationGateways = new ApplicationGatewayTestClient(this, networkClient.ApplicationGateways);
                }
                return applicationGateways;
            }
        }
        private ApplicationGatewayTestClient applicationGateways;

        public GatewayTestClient Gateways
        {
            get
            {
                if (gateways == null)
                {
                    gateways = new GatewayTestClient(this, networkClient.Gateways);
                }
                return gateways;
            }
        }
        private GatewayTestClient gateways;

        public RouteTestClient Routes
        {
            get
            {
                if (routes == null)
                {
                    routes = new RouteTestClient(this, networkClient.Routes);
                }
                return routes;
            }
        }
        private RouteTestClient routes;

        public NetworkTestClient()
        {
            undoContext = UndoContext.Current;
            undoContext.Start(4);

            networkClient = TestBase.GetServiceClient<NetworkManagementClient>();

            testOperations = new List<TestOperation>();
        }

        public void Dispose()
        {
            for (int i = testOperations.Count - 1; 0 <= i; --i)
            {
                testOperations[i].Undo();
            }

            undoContext.Dispose();
        }

        public void EnsureNoNetworkConfigurationExists()
        {
            EnsureNoNetworkConfigurationExists(NetworkTestConstants.VirtualNetworkSiteName);
        }

        public void EnsureNoNetworkConfigurationExists(string virtualNetworkSiteName)
        {
            string configuration = GetNetworkConfigurationSafe();
            if (IsEmptyConfiguration(configuration) == false)
            {
                Gateways.EnsureNoGatewayExists(virtualNetworkSiteName);

                SetNetworkConfiguration(NetworkTestConstants.EmptyNetworkConfigurationParameters);
            }

            Assert.True(IsEmptyConfiguration(GetNetworkConfigurationSafe()), "Unable to ensure that the current network configuration is empty.");
        }
        public void EnsureSiteToSiteNetworkConfigurationExists()
        {
            string configuration = GetNetworkConfigurationSafe();
            if (IsSiteToSiteConfiguration(configuration) == false)
            {
                Gateways.EnsureNoGatewayExists();

                SetNetworkConfiguration(NetworkTestConstants.SiteToSiteNetworkConfigurationParameters);
            }

            Assert.True(IsSiteToSiteConfiguration(GetNetworkConfigurationSafe()), "Unable to ensure that the current network configuration was a site to site network configuration.");
        }
        public void EnsurePointToSiteNetworkConfigurationExists()
        {
            string configuration = GetNetworkConfigurationSafe();
            if (IsPointToSiteConfiguration(configuration) == false)
            {
                Gateways.EnsureNoGatewayExists();

                SetNetworkConfiguration(NetworkTestConstants.PointToSiteNetworkConfigurationParameters);
            }

            Assert.True(IsPointToSiteConfiguration(GetNetworkConfigurationSafe()), "Unable to ensure that the current network configuration was a point to site network configuration.");
        }

        public void EnsureWideVNetNetworkConfigurationExists()
        {
            string configuration = GetNetworkConfigurationSafe();
            if (IsWideVNetConfiguration(configuration) == false)
            {
                Gateways.EnsureNoGatewayExists();

                SetNetworkConfiguration(NetworkTestConstants.WideVNetNetworkConfigurationParameters);
            }

            Assert.True(IsWideVNetConfiguration(GetNetworkConfigurationSafe()), "Unable to ensure that the current network configuration was a wide vnet network configuration.");
        }

        public bool IsEmptyConfiguration(string configuration)
        {
            return configuration.Contains("<VirtualNetworkSites>") == false;
        }

        public bool IsSiteToSiteConfiguration(string configuration)
        {
            return configuration.Contains("<LocalNetworkSites>") &&
                   configuration.Contains("<VirtualNetworkSites>") &&
                   configuration.Contains("<Gateway") &&
                   configuration.Contains("<VPNClientAddressPool>") == false;

        }

        public bool IsPointToSiteConfiguration(string configuration)
        {
            return configuration.Contains("<LocalNetworkSites>") &&
                   configuration.Contains("<VirtualNetworkSites>") &&
                   configuration.Contains("<Gateway") &&
                   configuration.Contains("<VPNClientAddressPool>");
        }

        public bool IsWideVNetConfiguration(string configuration)
        {
            return configuration.Contains("<VirtualNetworkSites>") &&
                   configuration.Contains(string.Format("Location=\"{0}\"", NetworkTestConstants.WideVNetLocation));
        }

        public NetworkGetConfigurationResponse GetNetworkConfiguration()
        {
            return networkClient.Networks.GetConfiguration();
        }
        public string GetNetworkConfigurationSafe()
        {
            string configuration;
            try
            {
                configuration = networkClient.Networks.GetConfiguration().Configuration;
            }
            catch (Hyak.Common.CloudException e)
            {
                if (e.Error.Code == "ResourceNotFound")
                {
                    configuration = File.ReadAllText(@"TestData\DeleteNetworkConfiguration.xml");
                }
                else
                {
                    throw;
                }
            }
            return configuration;
        }
        public NetworkListResponse ListNetworkConfigurations()
        {
            return networkClient.Networks.List();
        }

        public OperationStatusResponse SetNetworkConfiguration(NetworkSetConfigurationParameters parameters)
        {
            SetNetworkConfiguration testOperation = new SetNetworkConfiguration(networkClient, parameters);

            InvokeTestOperation(testOperation);

            return testOperation.InvokeResponse;
        }

        public void InvokeTestOperation(TestOperation testOperation)
        {
            testOperation.Invoke();
            testOperations.Add(testOperation);
        }
    }
}
