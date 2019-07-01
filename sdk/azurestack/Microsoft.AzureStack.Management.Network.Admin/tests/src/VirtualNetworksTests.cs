// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Network.Admin;
using Microsoft.AzureStack.Management.Network.Admin.Models;
using Xunit;

namespace Network.Tests
{
    public class VirtualNetworksTests : NetworkTestBase
    {
        private bool ValidateBaseResourceTenant(VirtualNetwork tenant)
        {
            return tenant != null &&
                tenant.SubscriptionId == null &&
                tenant.TenantResourceUri != null;
        }

        private void AssertVirtualNetworksAreSame(VirtualNetwork expected, VirtualNetwork found)
        {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(NetworkCommon.CheckBaseResourcesAreSame(expected, found));
            }
        }

        private void ValidateConfigurationState(VirtualNetworkConfigurationState state) 
        {
            Assert.NotNull(state);
            Assert.NotNull(state.Status);
            Assert.NotNull(state.LastUpdatedTime);
            Assert.NotNull(state.VirtualNetworkInterfaceErrors);
            Assert.NotNull(state.HostErrors);
        }

        [Fact]
        public void TestGetAllVirtualNetworks()
        {
            RunTest((client) =>
            {
                var networks = client.VirtualNetworks.List();
                Common.MapOverIPage(networks, client.VirtualNetworks.ListNext, (network) =>
                {
                    NetworkCommon.ValidateBaseResources(network);

                    ValidateBaseResourceTenant(network);

                    ValidateConfigurationState(network.ConfigurationState);
                });

            });
        }
        
        [Fact]
        public void TestGetAllVirtualNetworksOData()
        {
            RunTest((client) =>
            {
                Microsoft.Rest.Azure.OData.ODataQuery<VirtualNetwork> odataQuery = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualNetwork>();
                odataQuery.Top = 10;

                var networks = client.VirtualNetworks.List(odataQuery);
                Common.MapOverIPage(networks, client.VirtualNetworks.ListNext, (network) =>
                {
                    NetworkCommon.ValidateBaseResources(network);

                    ValidateBaseResourceTenant(network);

                    ValidateConfigurationState(network.ConfigurationState);
                });
            });
        }
    }
}
