// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class IpPoolTests : FabricTestBase
    {

        private const string SUCCESS_MSG = "Succeeded";

        private void AssertIpPoolsAreSame(IpPool expected, IpPool found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.AddressPrefix, found.AddressPrefix);
                Assert.Equal(expected.EndIpAddress, found.EndIpAddress);
                Assert.Equal(expected.NumberOfAllocatedIpAddresses, found.NumberOfAllocatedIpAddresses);
                Assert.Equal(expected.NumberOfIpAddresses, found.NumberOfIpAddresses);
                Assert.Equal(expected.NumberOfIpAddressesInTransition, found.NumberOfIpAddressesInTransition);
                Assert.Equal(expected.StartIpAddress, found.StartIpAddress);
            }
        }

        private void ValidateIpPool(IpPool pool) {
            FabricCommon.ValidateResource(pool);

            // TODO: Can we test on when this is not supposed to be null?
            // This is allowed to be null
            //Assert.Null(pool.AddressPrefix, "AddressPrefix is null");

            Assert.NotNull(pool.EndIpAddress);
            Assert.NotNull(pool.NumberOfAllocatedIpAddresses);
            Assert.NotNull(pool.NumberOfIpAddresses);
            Assert.NotNull(pool.NumberOfIpAddressesInTransition);
            Assert.NotNull(pool.StartIpAddress);
        }

        [Fact]
        public void TestListIpPools() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var ipPools = client.IpPools.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(ipPools, client.IpPools.ListNext, ValidateIpPool);
                    Common.WriteIPagesToFile(ipPools, client.IpPools.ListNext, "ListIpPools.txt", (pool) => pool.Name);
                });
            });
        }

        [Fact]
        public void TestGetIpPool() {
            RunTest((client) => {
                var locationName = GetLocation(client);

                var ipPool = client.IpPools.List(ResourceGroupName, locationName).GetFirst();
                if (ipPool != null)
                {
                    var ipPoolName = ExtractName(ipPool.Name);
                    var retrieved = client.IpPools.Get(ResourceGroupName, locationName, ipPoolName);
                    AssertIpPoolsAreSame(ipPool, retrieved);
                }
            });
        }
        [Fact]
        public void TestGetAllIpPools() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var ipPools = client.IpPools.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(ipPools, client.IpPools.ListNext, (pool) => {

                        var poolName = ExtractName(pool.Name);
                        var retrieved = client.IpPools.Get(ResourceGroupName, fabricLocationName, poolName);
                        AssertIpPoolsAreSame(pool, retrieved);
                    });
                });
            });
        }


        private IpPool CreateNewIpPool(string ipPoolName, string first = "66", string second = "66") {
            var ipPool = new IpPool()
            {
                StartIpAddress = first + "." + second + ".9.1",
                EndIpAddress = first + "." + second + ".9.255",
                AddressPrefix = first + "." + second + ".9.0/24"
            };
            return ipPool;
        }

        [Fact]
        public void TestCreateIpPool() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);

                var first = "199";
                var second = "196";
                var ipPoolName = "TestIpPool" + first + second;
                var ipPool = CreateNewIpPool(ipPoolName, first, second);

                var status = client.IpPools.CreateOrUpdate(ResourceGroupName, fabricLocationName, ipPoolName, ipPool);
                Assert.NotNull(status);
                Assert.Equal(SUCCESS_MSG, status.ProvisioningStateProperty);

            });
        }

        [Fact]
        public void TestUpdateIpPool() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);

                var first = "199";
                var second = "4";
                var ipPoolName = "TestIpPool" + first + "" + second;
                var ipPool = CreateNewIpPool(ipPoolName, first, second);

                var status = client.IpPools.CreateOrUpdate(ResourceGroupName, fabricLocationName, ipPoolName, ipPool);
                Assert.NotNull(status);
                Assert.Equal(SUCCESS_MSG, status.ProvisioningStateProperty);

            });
        }
    }
}
