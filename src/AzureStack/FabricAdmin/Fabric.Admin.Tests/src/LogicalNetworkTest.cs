// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using Xunit;

namespace Fabric.Tests {
    
    public class LogicalNetworkTest : FabricTestBase {

        private void AssertLogicalNetworksAreSame(LogicalNetwork expected, LogicalNetwork found) {
            if (expected == null) {
                Assert.Null(found);
            } else {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.NetworkVirtualizationEnabled, found.NetworkVirtualizationEnabled);
                if (expected.Subnets != null) {
                    Assert.Equal(expected.Subnets.Count, found.Subnets.Count);
                } else {
                    Assert.Null(found.Subnets);
                }

                if (expected.Metadata != null) {
                    Assert.Equal(expected.Metadata.Count, found.Metadata.Count);
                } else {
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
                var logicalNetworks = client.LogicalNetworks.List(Location);
                Common.MapOverIPage(logicalNetworks, client.LogicalNetworks.ListNext, ValidateLogicalNetwork);
                Common.WriteIPagesToFile(logicalNetworks, client.LogicalNetworks.ListNext, "ListLogicalNetworks.txt", (logicalNetwork) => logicalNetwork.Name);
            });
        }

        [Fact]
        public void TestGetLogicalNetwork() {
            RunTest((client) => {
                foreach(var logicalNetwork in client.LogicalNetworks.List(Location) ) { 
                    var retrieved = client.LogicalNetworks.Get(Location, logicalNetwork.Name);
                    AssertLogicalNetworksAreSame(logicalNetwork, retrieved);
                    break;
                }
            });
        }

        [Fact]
        public void TestGetAllLogicalNetworks() {
            RunTest((client) => {
                var logicalNetworks = client.LogicalNetworks.List(Location);
                Common.MapOverIPage(logicalNetworks, client.LogicalNetworks.ListNext, (logicalNetwork) => {
                    var retrieved = client.LogicalNetworks.Get(Location, logicalNetwork.Name);
                    AssertLogicalNetworksAreSame(logicalNetwork, retrieved);
                });

            });
        }
        
    }
}
