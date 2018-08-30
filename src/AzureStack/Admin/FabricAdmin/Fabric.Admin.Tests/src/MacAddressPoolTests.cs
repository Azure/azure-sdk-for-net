// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class MacAddressPoolTests : FabricTestBase
    {
        private void AssertMacAddressPoolsAreSame(MacAddressPool expected, MacAddressPool found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.NumberOfAllocatedMacAddresses, found.NumberOfAllocatedMacAddresses);
                Assert.Equal(expected.NumberOfAvailableMacAddresses, found.NumberOfAvailableMacAddresses);
                Assert.Equal(expected.StartMacAddress, found.StartMacAddress);
                Assert.Equal(expected.EndMacAddress, found.EndMacAddress);

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

        private void ValidateMacAddressPool(MacAddressPool macAddressPool) {
            FabricCommon.ValidateResource(macAddressPool);

            Assert.NotNull(macAddressPool.NumberOfAllocatedMacAddresses);
            Assert.NotNull(macAddressPool.NumberOfAvailableMacAddresses);
            Assert.NotNull(macAddressPool.StartMacAddress);
            Assert.NotNull(macAddressPool.EndMacAddress);
        }

        [Fact]
        public void TestListMacAddressPools() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var macAddressPools = client.MacAddressPools.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(macAddressPools, client.MacAddressPools.ListNext, ValidateMacAddressPool);
                    Common.WriteIPagesToFile(macAddressPools, client.MacAddressPools.ListNext, "ListMacAddressPools.txt", (macAddressPool) => macAddressPool.Name);
                });
            });
        }

        [Fact]
        public void TestGetMacAddressPool() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var macAddressPool = client.MacAddressPools.List(ResourceGroupName, fabricLocationName).GetFirst();
                if (macAddressPool != null)
                {
                    var macAddressPoolName = ExtractName(macAddressPool.Name);
                    var retrieved = client.MacAddressPools.Get(ResourceGroupName, fabricLocationName, macAddressPoolName);
                    AssertMacAddressPoolsAreSame(macAddressPool, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllMacAddressPools() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var macAddressPools = client.MacAddressPools.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(macAddressPools, client.MacAddressPools.ListNext, (macAddressPool) => {
                        var macAddressPoolName = ExtractName(macAddressPool.Name);
                        var retrieved = client.MacAddressPools.Get(ResourceGroupName, fabricLocationName, macAddressPoolName);
                        AssertMacAddressPoolsAreSame(macAddressPool, retrieved);
                    });
                });
            });
        }
    }
}
