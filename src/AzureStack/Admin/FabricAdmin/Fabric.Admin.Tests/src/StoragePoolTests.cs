// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class StoragePoolTests : FabricTestBase
    {

        private void AssertStoragePoolsAreSame(StoragePool expected, StoragePool found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));
                Assert.Equal(expected.SizeGB, found.SizeGB);
            }
        }

        private void ValidateStoragePool(StoragePool instance) {
            FabricCommon.ValidateResource(instance);

            Assert.NotNull(instance.SizeGB);
        }


        [Fact]
        public void TestListStoragePools() {
            RunTest((client) => {
                OverStorageSystems(client, (fabricLocationName, storageSystemName) => {
                    var storagePools = client.StoragePools.List(ResourceGroupName, fabricLocationName, storageSystemName);
                    Common.MapOverIPage(storagePools, client.StoragePools.ListNext, ValidateStoragePool);
                    Common.WriteIPagesToFile(storagePools, client.StoragePools.ListNext, "ListStoragePools.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetStoragePool() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var storageSystemName = GetStorageSystem(client, fabricLocationName);
                var storagePool = client.StoragePools.List(ResourceGroupName, fabricLocationName, storageSystemName).GetFirst();
                var retrieved = client.StoragePools.Get(ResourceGroupName, fabricLocationName, storageSystemName, storagePool.Name);
                AssertStoragePoolsAreSame(storagePool, retrieved);
            });
        }

        [Fact]
        public void TestGetAllStoragePools() {
            RunTest((client) => {
                OverStorageSystems(client, (fabricLocationName, storageSystemName) => {
                    var StoragePools = client.StoragePools.List(ResourceGroupName, fabricLocationName, storageSystemName);
                    Common.MapOverIPage(StoragePools, client.StoragePools.ListNext, (storagePool) => {
                        var storagePoolName = ExtractName(storagePool.Name);
                        var retrieved = client.StoragePools.Get(ResourceGroupName, fabricLocationName, storageSystemName, storagePoolName);
                        AssertStoragePoolsAreSame(storagePool, retrieved);
                    });
                });
            });
        }

    }
}
