// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using Xunit;

namespace Fabric.Tests {

    public class StoragePoolTests : FabricTestBase {

        private void AssertStoragePoolsAreSame(StoragePool expected, StoragePool found) {
            if (expected == null) {
                Assert.Null(found);
            } else {
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
                var subSystems = client.StorageSystems.List(Location);
                Common.MapOverIPage(subSystems, client.StorageSystems.ListNext, (subSystem) => {
                    var storagePools = client.StoragePools.List(Location, subSystem.Name);
                    Common.MapOverIPage(storagePools, client.StoragePools.ListNext, ValidateStoragePool);
                    Common.WriteIPagesToFile(storagePools, client.StoragePools.ListNext, "ListStoragePools.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetStoragePool() {
            RunTest((client) => {
                var subSystem = client.StorageSystems.List(Location).GetFirst();
                var storagePool = client.StoragePools.List(Location, subSystem.Name).GetFirst();
                var retrieved = client.StoragePools.Get(Location, subSystem.Name, storagePool.Name);
                AssertStoragePoolsAreSame(storagePool, retrieved);
            });
        }

        [Fact]
        public void TestGetAllStoragePools() {
            RunTest((client) => {
                var subSystems = client.StorageSystems.List(Location);
                Common.MapOverIPage(subSystems, client.StorageSystems.ListNext, (subSystem) => {
                    var StoragePools = client.StoragePools.List(Location, subSystem.Name);
                    Common.MapOverIPage(StoragePools, client.StoragePools.ListNext, (StoragePool) => {
                        var retrieved = client.StoragePools.Get(Location, subSystem.Name, StoragePool.Name);
                        AssertStoragePoolsAreSame(StoragePool, retrieved);
                    });
                });
            });
        }
        
    }
}
