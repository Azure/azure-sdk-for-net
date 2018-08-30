// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class StorageSystemTests : FabricTestBase
    {

        private void AssertStorageSystemsAreSame(StorageSystem expected, StorageSystem found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));
                Assert.Equal(expected.TotalCapacityGB, found.TotalCapacityGB);
            }
        }

        private void ValidateStorageSystem(StorageSystem instance) {
            FabricCommon.ValidateResource(instance);

            Assert.NotNull(instance.TotalCapacityGB);
        }


        [Fact]
        public void TestListStorageSystems() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var subSystems = client.StorageSystems.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(subSystems, client.StorageSystems.ListNext, ValidateStorageSystem);
                    Common.WriteIPagesToFile(subSystems, client.StorageSystems.ListNext, "ListStorageSystems.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetStorageSystem() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var subSystem = client.StorageSystems.List(ResourceGroupName, fabricLocationName).GetFirst();
                var retrieved = client.StorageSystems.Get(ResourceGroupName, fabricLocationName, subSystem.Name);
                AssertStorageSystemsAreSame(subSystem, retrieved);
            });
        }

        [Fact]
        public void TestGetAllStorageSystems() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var subSystems = client.StorageSystems.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(subSystems, client.StorageSystems.ListNext, (storageSystem) => {
                        var storageSystemName = ExtractName(storageSystem.Name);
                        var retrieved = client.StorageSystems.Get(ResourceGroupName, fabricLocationName, storageSystemName);
                        AssertStorageSystemsAreSame(storageSystem, retrieved);
                    });
                });
            });
        }
    }
}
