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

                Assert.Equal(expected.TotalCapacityGB, found.TotalCapacityGB);
                Assert.Equal(expected.RemainingCapacityGB, found.RemainingCapacityGB);
                Assert.Equal(expected.HealthStatus, found.HealthStatus);
                Assert.Equal(expected.OperationalStatus, found.OperationalStatus);
                Assert.Equal(expected.RepairStatus, found.RepairStatus);
                Assert.Equal(expected.Description, found.Description);
                Assert.Equal(expected.Action, found.Action);
                Assert.Equal(expected.VolumeLabel, found.VolumeLabel);
            }
        }

        private void ValidateVolume(Volume instance) {
            FabricCommon.ValidateResource(instance);

            Assert.NotNull(instance.TotalCapacityGB);
            Assert.NotNull(instance.RemainingCapacityGB);
            Assert.NotNull(instance.HealthStatus);
            Assert.NotNull(instance.OperationalStatus);
            Assert.NotNull(instance.RepairStatus);
            Assert.NotNull(instance.Description);
            Assert.NotNull(instance.Action);
            Assert.NotNull(instance.VolumeLabel);
        }


        [Fact]
        public void TestListVolumes() {
            RunTest((client) => {
                OverStorageSubSystems(client, (fabricLocationName, scaleUnitName, storageSubSystemName) => {
                    var volumes = client.Volumes.List(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName);
                    Common.MapOverIPage(volumes, client.Volumes.ListNext, ValidateVolume);
                    Common.WriteIPagesToFile(volumes, client.Volumes.ListNext, "ListVolumes.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetVolume() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitName = GetScaleUnit(client, fabricLocationName);
                var storageSubSystemName = GetStorageSubSystem(client, fabricLocationName, scaleUnitName);
                var volume = client.Volumes.List(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName).GetFirst();
                var volumeName = ExtractName(volume.Name);
                var retrieved = client.Volumes.Get(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName, volumeName);
                AssertVolumesAreSame(volume, retrieved);
            });
        }

        [Fact]
        public void TestGetAllVolumes() {
            RunTest((client) => {
                OverStorageSubSystems(client, (fabricLocationName, scaleUnitName, storageSubSystemName) => {
                    var volumes = client.Volumes.List(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName);
                    Common.MapOverIPage(volumes, client.Volumes.ListNext, (volume) => {
                        var volumeName = ExtractName(volume.Name);
                        var retrieved = client.Volumes.Get(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName, volumeName);
                        AssertVolumesAreSame(volume, retrieved);
                    });
                });
            });
        }

        [Fact]
        public void TestGetInvaildVolume()
        {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitName = GetScaleUnit(client, fabricLocationName);
                var storageSubSystemName = GetStorageSubSystem(client, fabricLocationName, scaleUnitName);
                var invaildVolumeName = "invaildvolumename";
                var retrieved = client.Volumes.GetWithHttpMessagesAsync(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName, invaildVolumeName).GetAwaiter().GetResult();
                var httpResponseMsg = retrieved.Response;
                Assert.Equal(System.Net.HttpStatusCode.NotFound, httpResponseMsg.StatusCode);
                Assert.Null(retrieved.Body);
            });
        }
    }
}
