
using Xunit;

using Microsoft.AzureStack.TestFramework;

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;


namespace Fabric.Tests
{
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
                var macAddressPools = client.MacAddressPools.List(Location);
                Common.MapOverIPage(macAddressPools, client.MacAddressPools.ListNext, ValidateMacAddressPool);
                Common.WriteIPagesToFile(macAddressPools, client.MacAddressPools.ListNext, "ListMacAddressPools.txt", (macAddressPool) => macAddressPool.Name);
            });
        }

        [Fact]
        public void TestGetMacAddressPool() {
            RunTest((client) => {
                var macAddressPool = client.MacAddressPools.List(Location).GetFirst();
                if (macAddressPool != null)
                {
                    var retrieved = client.MacAddressPools.Get(Location, macAddressPool.Name);
                    AssertMacAddressPoolsAreSame(macAddressPool, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllMacAddressPools() {
            RunTest((client) => {
                var macAddressPools = client.MacAddressPools.List(Location);
                Common.MapOverIPage(macAddressPools, client.MacAddressPools.ListNext, (macAddressPool) => {
                    var retrieved = client.MacAddressPools.Get(Location, macAddressPool.Name);
                    AssertMacAddressPoolsAreSame(macAddressPool, retrieved);
                });
            });
        }

    }
}
