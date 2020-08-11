// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class LogicalNetworkTest : FabricTestBase
    {

        private void AssertLogicalNetworksAreSame(LogicalNetwork expected, LogicalNetwork found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.NetworkVirtualizationEnabled, found.NetworkVirtualizationEnabled);
                if (expected.Subnets != null)
                {
                    Assert.Equal(expected.Subnets.Count, found.Subnets.Count);
                }
                else
                {
                    Assert.Null(found.Subnets);
                }

                if (expected.Metadata != null)
                {
                    Assert.Equal(expected.Metadata.Count, found.Metadata.Count);
                }
                else
                {
                    Assert.Null(found.Metadata);
                }

            }
        }

        private void ValidateLogicalNetwork(LogicalNetwork logicalNetwork) {
            FabricCommon.ValidateResource(logicalNetwork);

            Assert.NotNull(logicalNetwork.NetworkVirtualizationEnabled);
            Assert.NotNull(logicalNetwork.Subnets);
        }

        [Fact]
        public void TestListLogicalNetworks() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var logicalNetworks = client.LogicalNetworks.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(logicalNetworks, client.LogicalNetworks.ListNext, ValidateLogicalNetwork);
                    Common.WriteIPagesToFile(logicalNetworks, client.LogicalNetworks.ListNext, "ListLogicalNetworks.txt", (logicalNetwork) => logicalNetwork.Name);
                });
            });
        }

        [Fact]
        public void TestGetLogicalNetwork() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var logicalNetwork = client.LogicalNetworks.List(ResourceGroupName, fabricLocationName).GetFirst();
                if (logicalNetwork != null)
                {
                    var logicalNetworkName = ExtractName(logicalNetwork.Name);
                    var retrieved = client.LogicalNetworks.Get(ResourceGroupName, fabricLocationName, logicalNetworkName);
                    AssertLogicalNetworksAreSame(logicalNetwork, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllLogicalNetworks() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var logicalNetworks = client.LogicalNetworks.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(logicalNetworks, client.LogicalNetworks.ListNext, (logicalNetwork) => {

                        var logicalNetworkName = ExtractName(logicalNetwork.Name);
                        var retrieved = client.LogicalNetworks.Get(ResourceGroupName, fabricLocationName, logicalNetworkName);
                        AssertLogicalNetworksAreSame(logicalNetwork, retrieved);
                    });
                });
            });
        }

    }
}
