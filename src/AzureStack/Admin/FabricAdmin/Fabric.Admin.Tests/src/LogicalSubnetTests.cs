// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class LogicalSubnetTests : FabricTestBase
    {
        private void AssertLogicalSubnetsAreSame(LogicalSubnet expected, LogicalSubnet found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.IsPublic, found.IsPublic);
                if (expected.IpPools != null)
                {
                    Assert.Equal(expected.IpPools.Count, found.IpPools.Count);
                }
                else
                {
                    Assert.Null(found.IpPools);
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

        private void ValidateLogicalSubnet(LogicalSubnet logicalSubnet) {
            FabricCommon.ValidateResource(logicalSubnet);

            Assert.NotNull(logicalSubnet.IpPools);
            Assert.NotNull(logicalSubnet.IsPublic);
        }

        [Fact]
        public void TestListLogicalSubnets() {
            RunTest((client) => {
                OverLogicalNetworks(client, (fabricLocationName, logicalNetworkName) => {
                    var logicalSubnets = client.LogicalSubnets.List(ResourceGroupName, fabricLocationName, logicalNetworkName);
                    Common.MapOverIPage(logicalSubnets, client.LogicalSubnets.ListNext, ValidateLogicalSubnet);
                    Common.WriteIPagesToFile(logicalSubnets, client.LogicalSubnets.ListNext, "ListLogicalSubnets.txt", (logicalSubnet) => logicalSubnet.Name);
                });
            });
        }

        [Fact]
        public void TestGetLogicalSubnet() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var logicalNetworkName = GetLogicalNetwork(client, fabricLocationName);
                var logicalSubnet = client.LogicalSubnets.List(ResourceGroupName, fabricLocationName, logicalNetworkName).GetFirst();
                if (logicalSubnet != null)
                {
                    var logicalSubnetName = ExtractName(logicalSubnet.Name);
                    var retrieved = client.LogicalSubnets.Get(ResourceGroupName, fabricLocationName, logicalNetworkName, logicalSubnetName);
                    AssertLogicalSubnetsAreSame(logicalSubnet, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllLogicalSubnets() {
            RunTest((client) => {
                OverLogicalNetworks(client, (fabricLocationName, logicalNetworkName) => {
                    var logicalSubnets = client.LogicalSubnets.List(ResourceGroupName, fabricLocationName, logicalNetworkName);
                    Common.MapOverIPage(logicalSubnets, client.LogicalSubnets.ListNext, (logicalSubnet) => {
                        var logicalSubnetName = ExtractName(logicalSubnet.Name);
                        var retrieved = client.LogicalSubnets.Get(ResourceGroupName, fabricLocationName, logicalNetworkName, logicalSubnetName);
                        AssertLogicalSubnetsAreSame(logicalSubnet, retrieved);
                    });
                });
            });
        }
    }
}
