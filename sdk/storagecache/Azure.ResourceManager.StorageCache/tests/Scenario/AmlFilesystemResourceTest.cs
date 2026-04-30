// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class AmlFilesystemResourceTest : StorageCacheManagementTestBase
    {
        public AmlFilesystemResourceTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Delete()
        {
            await AzureResourceTestHelper.TestDelete<AmlFileSystemResource>(
                async () => await this.CreateOrUpdateAmlFilesystem(),
                async (cache) => await cache.DeleteAsync(WaitUntil.Completed),
                async (cache) => await cache.GetAsync());
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Update()
        {
            AmlFileSystemResource amlFSResource = await this.CreateOrUpdateAmlFilesystem();

            //create AMLFilesystemPatch object with random maintenance window
            AmlFileSystemPatch amlFilesystemPatch = new AmlFileSystemPatch()
            {
                MaintenanceWindow = new AmlFileSystemUpdatePropertiesMaintenanceWindow()
                {
                    DayOfWeek = MaintenanceDayOfWeekType.Tuesday,
                    TimeOfDayUTC = @"05:25"
                },
            };

            ArmOperation<AmlFileSystemResource> lro = await amlFSResource.UpdateAsync(
                waitUntil: WaitUntil.Completed,
                patch: amlFilesystemPatch);

            Assert.AreEqual(lro.Value.Data.MaintenanceWindow.DayOfWeek, amlFilesystemPatch.MaintenanceWindow.DayOfWeek);
            Assert.AreEqual(lro.Value.Data.MaintenanceWindow.TimeOfDayUTC, amlFilesystemPatch.MaintenanceWindow.TimeOfDayUTC);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task AmlFSArchiveOperations()
        {
            AmlFileSystemResource amlFSResource = await this.CreateOrUpdateAmlFilesystem();
            //archive
            AmlFileSystemArchiveContent amlFilesystemArchiveContent = new AmlFileSystemArchiveContent()
            {
                FilesystemPath = @"/",
            };
            Response response = await amlFSResource.ArchiveAsync(amlFilesystemArchiveContent);
            Assert.IsFalse(response.IsError);
            //cancelarchive
            response = await amlFSResource.CancelArchiveAsync();
            Assert.IsFalse(response.IsError);
        }
    }
}
