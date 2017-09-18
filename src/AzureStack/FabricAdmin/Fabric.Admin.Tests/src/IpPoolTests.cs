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


        private IpPool CreateNewIpPool(string ipPoolName) {
            var ipPool = new IpPool()
            {
                StartIpAddress = "9.9.9.1",
                EndIpAddress = "9.9.9.254",
                AddressPrefix = "9.9.9.0/24"
            };
            return ipPool;
        }

        // [BUG:13271901] : [FRP] Attempting to create an IP Pool Results in Service Offline error
        [Fact(Skip ="RP throws exception")]
        public void TestCreateIpPool() {
            RunTest((client) => {

                var ipPoolName = "myippoolwhichcanneverbedeleted";
                var ipPool = CreateNewIpPool(ipPoolName);

                var retrieved = client.IpPools.Create(Location, ipPoolName, ipPool);
                var test = client.IpPools.Get(Location, ipPoolName);

                Assert.False(test != null && retrieved == null);
                Assert.False(retrieved != null && test == null);

                Assert.Null(retrieved);
                Assert.Equal(ipPool.NumberOfIpAddresses, retrieved.NumberOfIpAddresses);
                Assert.Equal(ipPool.StartIpAddress, retrieved.StartIpAddress);
                Assert.Equal(ipPool.EndIpAddress, retrieved.EndIpAddress);


            });
        }
    }
}
