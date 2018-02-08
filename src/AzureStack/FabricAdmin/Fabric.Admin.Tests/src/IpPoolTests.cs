// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using Xunit;

namespace Fabric.Tests
{

    public class IpPoolTests : FabricTestBase
    {

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
                var ipPools = client.IpPools.List(Location);
                Common.MapOverIPage(ipPools, client.IpPools.ListNext, ValidateIpPool);
                Common.WriteIPagesToFile(ipPools, client.IpPools.ListNext, "ListIpPools.txt", (pool) => pool.Name);
            });
        }

        [Fact]
        public void TestGetIpPool() {
            RunTest((client) => {
                var ipPool = client.IpPools.List(Location).GetFirst();
                if (ipPool != null)
                {
                    var retrieved = client.IpPools.Get(Location, ipPool.Name);
                    AssertIpPoolsAreSame(ipPool, retrieved);
                }
            });
        }
        [Fact]
        public void TestGetAllIpPools() {
            RunTest((client) => {
                var ipPools = client.IpPools.List(Location);
                Common.MapOverIPage(ipPools, client.IpPools.ListNext, (pool) => {
                    var retrieved = client.IpPools.Get(Location, pool.Name);
                    AssertIpPoolsAreSame(pool, retrieved);
                });
            });
        }


        private IpPool CreateNewIpPool(string ipPoolName, string first = "66" , string second = "66") {
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

                var first = "199";
                var second = "198";
                var ipPoolName = "TestIpPool" + first + second;
                var ipPool = CreateNewIpPool(ipPoolName, first, second);

                var retrieved = client.IpPools.Create(Location, ipPoolName, ipPool);
                Assert.NotNull(retrieved);
                Assert.Equal("Succeeded", retrieved.ProvisioningState);

                var test = client.IpPools.Get(Location, ipPoolName);
                Assert.NotNull(test);
                Assert.NotNull(test.StartIpAddress);
                Assert.NotNull(test.EndIpAddress);
                Assert.NotNull(test.EndIpAddress);

                Assert.Equal(ipPool.StartIpAddress, test.StartIpAddress);
                Assert.Equal(ipPool.EndIpAddress, test.EndIpAddress);

            });
        }

        [Fact]
        public void TestUpdateIpPool() {
            RunTest((client) => {

                var first = "199";
                var second = "2";
                var ipPoolName = "TestIpPool" + first + "" + second;
                var ipPool = CreateNewIpPool(ipPoolName, first, second);

                var retrieved = client.IpPools.Create(Location, ipPoolName, ipPool);
                Assert.NotNull(retrieved);
                Assert.Equal("Succeeded", retrieved.ProvisioningState);

                var test = client.IpPools.Get(Location, ipPoolName);
                Assert.NotNull(test);
                Assert.NotNull(test.StartIpAddress);
                Assert.NotNull(test.EndIpAddress);
                Assert.NotNull(test.EndIpAddress);

                Assert.Equal(ipPool.StartIpAddress, test.StartIpAddress);
                Assert.Equal(ipPool.EndIpAddress, test.EndIpAddress);

            });
        }
    }
}
