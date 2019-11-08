// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class DriveTests : FabricTestBase
    {

        private void AssertDrivesAreSame(Drive expected, Drive found)
        {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.StorageNode, found.StorageNode);
                Assert.Equal(expected.SerialNumber, found.SerialNumber);
                Assert.Equal(expected.HealthStatus, found.HealthStatus);
                Assert.Equal(expected.OperationalStatus, found.OperationalStatus);
                Assert.Equal(expected.Usage, found.Usage);
                Assert.Equal(expected.PhysicalLocation, found.PhysicalLocation);
                Assert.Equal(expected.Model, found.Model);
                Assert.Equal(expected.FirmwareVersion, found.FirmwareVersion);
                Assert.Equal(expected.IsIndicationEnabled, found.IsIndicationEnabled);
                Assert.Equal(expected.Manufacturer, found.Manufacturer);
                Assert.Equal(expected.StoragePool, found.StoragePool);
                Assert.Equal(expected.MediaType, found.MediaType);
                Assert.Equal(expected.CapacityGB, found.CapacityGB);
                Assert.Equal(expected.Description, found.Description);
                Assert.Equal(expected.Action, found.Action);
            }
        }

        private void ValidateDrive(Drive instance)
        {
            FabricCommon.ValidateResource(instance);

            Assert.NotNull(instance.StorageNode);
            Assert.NotNull(instance.SerialNumber);
            Assert.NotNull(instance.HealthStatus);
            Assert.NotNull(instance.OperationalStatus);
            Assert.NotNull(instance.Usage);
            Assert.NotNull(instance.PhysicalLocation);
            Assert.NotNull(instance.Model);
            Assert.NotNull(instance.FirmwareVersion);
            Assert.NotNull(instance.IsIndicationEnabled);
            Assert.NotNull(instance.Manufacturer);
            Assert.NotNull(instance.StoragePool);
            Assert.NotNull(instance.MediaType);
            Assert.NotNull(instance.CapacityGB);
            Assert.NotNull(instance.Description);
            Assert.NotNull(instance.Action);
        }


        [Fact]
        public void TestListDrives()
        {
            RunTest((client) => {
                OverStorageSubSystems(client, (fabricLocationName, scaleUnitName, storageSubSystemName) => {
                    var drives = client.Drives.List(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName);
                    Common.MapOverIPage(drives, client.Drives.ListNext, ValidateDrive);
                    Common.WriteIPagesToFile(drives, client.Drives.ListNext, "ListDrives.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetDrive()
        {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitName = GetScaleUnit(client, fabricLocationName);
                var storageSubSystemName = GetStorageSubSystem(client, fabricLocationName, scaleUnitName);
                var drive = client.Drives.List(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName).GetFirst();
                var driveName = ExtractName(drive.Name);
                var retrieved = client.Drives.Get(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName, driveName);
                AssertDrivesAreSame(drive, retrieved);
            });
        }

        [Fact]
        public void TestGetAllDrives()
        {
            RunTest((client) => {
                OverStorageSubSystems(client, (fabricLocationName, scaleUnitName, storageSubSystemName) => {
                    var drives = client.Drives.List(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName);
                    Common.MapOverIPage(drives, client.Drives.ListNext, (drive) => {
                        var driveName = ExtractName(drive.Name);
                        var retrieved = client.Drives.Get(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName, driveName);
                        AssertDrivesAreSame(drive, retrieved);
                    });
                });
            });
        }

        [Fact]
        public void TestGetInvaildDrive()
        {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitName = GetScaleUnit(client, fabricLocationName);
                var storageSubSystemName = GetStorageSubSystem(client, fabricLocationName, scaleUnitName);
                var invaildDriveName = "invailddrivename";
                var retrieved = client.Drives.GetWithHttpMessagesAsync(ResourceGroupName, fabricLocationName, scaleUnitName, storageSubSystemName, invaildDriveName).GetAwaiter().GetResult();
                var httpResponseMsg = retrieved.Response;
                Assert.Equal(System.Net.HttpStatusCode.NotFound, httpResponseMsg.StatusCode);
                Assert.Null(retrieved.Body);
            });
        }
    }
}
