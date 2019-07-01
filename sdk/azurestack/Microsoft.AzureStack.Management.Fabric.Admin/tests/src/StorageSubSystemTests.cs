// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class StorageSubSystemTests : FabricTestBase
    {

        private void AssertStorageSubSystemsAreSame(StorageSubSystem expected, StorageSubSystem found)
        {
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
                Assert.Equal(expected.RebalanceStatus, found.RebalanceStatus);
            }
        }

        private void ValidateStorageSubSystem(StorageSubSystem instance)
        {
            FabricCommon.ValidateResource(instance);

            Assert.NotNull(instance.TotalCapacityGB);
            Assert.NotNull(instance.RemainingCapacityGB);
            Assert.NotNull(instance.HealthStatus);
            Assert.NotNull(instance.OperationalStatus);
            Assert.NotNull(instance.RebalanceStatus);
        }


        [Fact]
        public void TestListStorageSubSystems()
        {
            RunTest((client) => {
                OverScaleUnits(client, (fabricLocationName, scaleUnitsName) => {
                    var storageSubSystems = client.StorageSubSystems.List(ResourceGroupName, fabricLocationName, scaleUnitsName);
                    Common.MapOverIPage(storageSubSystems, client.StorageSubSystems.ListNext, ValidateStorageSubSystem);
                    Common.WriteIPagesToFile(storageSubSystems, client.StorageSubSystems.ListNext, "ListStorageSubSystems.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetStorageSubSystem()
        {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitsName = GetScaleUnit(client, fabricLocationName);
                var storageSubSystem = client.StorageSubSystems.List(ResourceGroupName, fabricLocationName, scaleUnitsName).GetFirst();
                var storageSubSystemName = ExtractName(storageSubSystem.Name);
                var retrieved = client.StorageSubSystems.Get(ResourceGroupName, fabricLocationName, scaleUnitsName, storageSubSystemName);
                AssertStorageSubSystemsAreSame(storageSubSystem, retrieved);
            });
        }

        [Fact]
        public void TestGetAllStorageSubSystems()
        {
            RunTest((client) => {
                OverScaleUnits(client, (fabricLocationName, scaleUnitsName) => {
                    var storageSubSystems = client.StorageSubSystems.List(ResourceGroupName, fabricLocationName, scaleUnitsName);
                    Common.MapOverIPage(storageSubSystems, client.StorageSubSystems.ListNext, (storageSubSystem) => {
                        var storageSubSystemName = ExtractName(storageSubSystem.Name);
                        var retrieved = client.StorageSubSystems.Get(ResourceGroupName, fabricLocationName, scaleUnitsName, storageSubSystemName);
                        AssertStorageSubSystemsAreSame(storageSubSystem, retrieved);
                    });
                });
            });
        }

        [Fact]
        public void TestGetInvaildStorageSubSystem()
        {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnitsName = GetScaleUnit(client, fabricLocationName);
                var invaildStorageSubSystemName = "invaildstoragesubsystemname";
                var retrieved = client.StorageSubSystems.GetWithHttpMessagesAsync(ResourceGroupName, fabricLocationName, scaleUnitsName, invaildStorageSubSystemName).GetAwaiter().GetResult();
                var httpResponseMsg = retrieved.Response;
                Assert.Equal(System.Net.HttpStatusCode.NotFound, httpResponseMsg.StatusCode);
                Assert.Null(retrieved.Body);
            });
        }
    }
}
