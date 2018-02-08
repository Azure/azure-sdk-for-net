// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using Xunit;

namespace Fabric.Tests {

    public class VolumeTests : FabricTestBase {

        private void AssertVolumesAreSame(Volume expected, Volume found) {
            if (expected == null) {
                Assert.Null(found);
            } else {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.FileSystem, found.FileSystem);
                Assert.Equal(expected.RemainingSizeGB, found.RemainingSizeGB);
                Assert.Equal(expected.SizeGB, found.SizeGB);
                Assert.Equal(expected.VolumeLabel, found.VolumeLabel);
            }
        }

        private void ValidateVolume(Volume instance) {
            FabricCommon.ValidateResource(instance);


            Assert.NotNull(instance.FileSystem);
            Assert.NotNull(instance.RemainingSizeGB);
            Assert.NotNull(instance.SizeGB);
            Assert.NotNull(instance.VolumeLabel);
        }


        [Fact]
        public void TestListVolumes() {
            RunTest((client) => {
                var subSystems = client.StorageSystems.List(Location);
                Common.MapOverIPage(subSystems, client.StorageSystems.ListNext, (subSystem) => {
                    var storagePools = client.StoragePools.List(Location, subSystem.Name);
                    Common.MapOverIPage(storagePools, client.StoragePools.ListNext, (storagePool) => {
                        var volumes = client.Volumes.List(Location, subSystem.Name, storagePool.Name);
                        Common.MapOverIPage(volumes, client.Volumes.ListNext, ValidateVolume);
                        Common.WriteIPagesToFile(volumes, client.Volumes.ListNext, "ListVolumes.txt", ResourceName);
                    });
                });
            });
        }

        [Fact]
        public void TestGetVolume() {
            RunTest((client) => {
                var subSystem = client.StorageSystems.List(Location).GetFirst();
                var storagePool = client.StoragePools.List(Location, subSystem.Name).GetFirst();
                var volume = client.Volumes.List(Location, subSystem.Name, storagePool.Name).GetFirst();
                var retrieved = client.Volumes.Get(Location, subSystem.Name, storagePool.Name, volume.Name);
                AssertVolumesAreSame(volume, retrieved);
            });
        }

        [Fact]
        public void TestGetAllVolumes() {
            RunTest((client) => {
                var subSystems = client.StorageSystems.List(Location);
                Common.MapOverIPage(subSystems, client.StorageSystems.ListNext, (subSystem) => {
                    var storagePools = client.StoragePools.List(Location, subSystem.Name);
                    Common.MapOverIPage(storagePools, client.StoragePools.ListNext, (storagePool) => {
                        var volumes = client.Volumes.List(Location, subSystem.Name, storagePool.Name);
                        Common.MapOverIPage(volumes, client.Volumes.ListNext, (volume) => {
                            var retrieved = client.Volumes.Get(Location, subSystem.Name, storagePool.Name, volume.Name);
                            AssertVolumesAreSame(volume, retrieved);
                        });
                    });
                });
            });
        }
    }
}
