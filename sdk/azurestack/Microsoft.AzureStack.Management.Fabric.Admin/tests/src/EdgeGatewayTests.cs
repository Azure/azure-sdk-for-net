// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class EdgeGatewayTests : FabricTestBase
    {

        private void AssertSameEdgeGateway(EdgeGateway expected, EdgeGateway found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.AvailableCapacity, found.AvailableCapacity);
                Assert.Equal(expected.NumberOfConnections, found.NumberOfConnections);
                Assert.Equal(expected.State, found.State);
                Assert.Equal(expected.TotalCapacity, found.TotalCapacity);
            }
        }

        private void ValidateEdgeGateway(EdgeGateway gateway) {
            FabricCommon.ValidateResource(gateway);
            Assert.NotNull(gateway.AvailableCapacity);
            Assert.NotNull(gateway.NumberOfConnections);
            Assert.NotNull(gateway.State);
            Assert.NotNull(gateway.TotalCapacity);
        }

        [Fact]
        public void TestListEdgeGateways() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var gateways = client.EdgeGateways.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(gateways, client.EdgeGateways.ListNext, ValidateEdgeGateway);
                    Common.WriteIPagesToFile(gateways, client.EdgeGateways.ListNext, "ListEdgeGateways.txt", (gateway) => gateway.Name);
                });
            });
        }

        [Fact]
        public void TestGetEdgeGateway() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var gateway = client.EdgeGateways.List(ResourceGroupName, fabricLocationName).GetFirst();
                if (gateway != null)
                {
                    var gName = ExtractName(gateway.Name);
                    var retrieved = client.EdgeGateways.Get(ResourceGroupName, fabricLocationName, gName);
                    AssertSameEdgeGateway(gateway, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllEdgeGateways() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var gateways = client.EdgeGateways.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(gateways, client.EdgeGateways.ListNext, (EdgeGateway gateway) => {
                        var gName = ExtractName(gateway.Name);
                        var retrieved = client.EdgeGateways.Get(ResourceGroupName, fabricLocationName, gName);
                        AssertSameEdgeGateway(gateway, retrieved);
                    });
                });
            });
        }
    }
}
