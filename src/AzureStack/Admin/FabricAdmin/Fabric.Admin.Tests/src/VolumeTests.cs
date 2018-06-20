// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class VolumeTests : FabricTestBase
    {

        private void AssertVolumesAreSame(Volume expected, Volume found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
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
                OverStoragePools(client, (fabricLocationName, storageSystemName, storagePoolName) => {
                    var volumes = client.Volumes.List(ResourceGroupName, fabricLocationName, storageSystemName, storagePoolName);
                    Common.MapOverIPage(volumes, client.Volumes.ListNext, ValidateVolume);
                    Common.WriteIPagesToFile(volumes, client.Volumes.ListNext, "ListVolumes.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetVolume() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var storageSystemName = GetStorageSystem(client, fabricLocationName);
                var storagePoolName = GetStoragePool(client, fabricLocationName, storageSystemName);
                var volume = client.Volumes.List(ResourceGroupName, fabricLocationName, storageSystemName, storagePoolName).GetFirst();
                var volumeName = ExtractName(volume.Name);
                var retrieved = client.Volumes.Get(ResourceGroupName, fabricLocationName, storageSystemName, storagePoolName, volumeName);
                AssertVolumesAreSame(volume, retrieved);
            });
        }

        [Fact]
        public void TestGetAllVolumes() {
            RunTest((client) => {
                OverStoragePools(client, (fabricLocationName, storageSystemName, storagePoolName) => {
                    var volumes = client.Volumes.List(ResourceGroupName, fabricLocationName, storageSystemName, storagePoolName);
                    Common.MapOverIPage(volumes, client.Volumes.ListNext, (volume) => {
                        var volumeName = ExtractName(volume.Name);
                        var retrieved = client.Volumes.Get(ResourceGroupName, fabricLocationName, storageSystemName, storagePoolName, volumeName);
                        AssertVolumesAreSame(volume, retrieved);
                    });
                });
            });
        }
    }
}
