// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using Xunit;

namespace Fabric.Tests {
    public class EdgeGatewayPoolTests : FabricTestBase {

        private void AssertEdgeGatewayPoolAreSame(EdgeGatewayPool expected, EdgeGatewayPool found) {
            if (expected == null) {
                Assert.Null(found);
            } else {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.Name, found.Name);
                Assert.Equal(expected.Id, found.Id);
                Assert.Equal(expected.Location, found.Location);
                Assert.Equal(expected.GatewayType, found.GatewayType);
                Assert.Equal(expected.PublicIpAddress, found.PublicIpAddress);
                Assert.Equal(expected.NumberOfGateways, found.NumberOfGateways);
            }
        }

        private void ValidateEdgeGatewayPool(EdgeGatewayPool pool) {
            FabricCommon.ValidateResource(pool);
            Assert.NotNull(pool.Id);
            Assert.NotNull(pool.Location);
            Assert.NotNull(pool.Name);
            Assert.NotNull(pool.Type);
            Assert.NotNull(pool.GatewayType);
            Assert.NotNull(pool.PublicIpAddress);
        }

        [Fact]
        public void TestListEdgeGatewayPools() {
            RunTest((client) => {
                var pools = client.EdgeGatewayPools.List(Location);
                Common.MapOverIPage(pools, client.EdgeGatewayPools.ListNext, ValidateEdgeGatewayPool);
                Common.WriteIPagesToFile(pools, client.EdgeGatewayPools.ListNext, "ListEdgeGatewayPools.txt", (pool) => pool.Name);

            });
        }

        [Fact]
        public void TestGetEdgeGatewayPool() {
            RunTest((client) => {
                var pool = client.EdgeGatewayPools.List(Location).GetFirst();
                if (pool != null) {
                    var retrieved = client.EdgeGatewayPools.Get(Location, pool.Name);
                    AssertEdgeGatewayPoolAreSame(pool, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllEdgeGatewayPools() {
            RunTest((client) => {
                var pools = client.EdgeGatewayPools.List(Location);
                Common.MapOverIPage(pools, client.EdgeGatewayPools.ListNext, (EdgeGatewayPool pool) => {
                    var retrieved = client.EdgeGatewayPools.Get(Location, pool.Name);
                    AssertEdgeGatewayPoolAreSame(pool, retrieved);
                });
            });
        }
        
    }
}
