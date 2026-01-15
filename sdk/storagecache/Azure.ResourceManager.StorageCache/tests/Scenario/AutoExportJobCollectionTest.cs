// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class AutoExportJobCollectionTest : StorageCacheManagementTestBase
    {
        private AmlFileSystemResource DefaultAmlFS { get; set; }
        public AutoExportJobCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task AutoExportJobSetup()
        {
            // it's very heavy to create amlFS (~20 minutes), so provide an option to use precreated resource
            //   set preCreated to true and updated the resourceGroup, cacheName below to use pre created resource
            //   set preCreated to false to create new one
            bool preCreated = true;
            this.DefaultAmlFS = preCreated ?
                await this.RetrieveExistingAmlFS(
                    resourceGroupName: this.DefaultResourceGroup.Id.Name,
                    amlFSName: @"testamlFS1458") :
                await this.CreateOrUpdateAmlFilesystem();
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testautoexportjob");
            AutoExportJobData dataVar = new AutoExportJobData(this.DefaultLocation)
            {
                AutoExportPrefixes = { "/path" },
                AdminStatus = AutoExportJobAdminStatus.Enable
            };
            AutoExportJobResource autoExportJobResource = await this.CreateOrUpdateAutoExportJob(DefaultAmlFS, name, dataVar, verifyResult: true);
            dataVar.AdminStatus = AutoExportJobAdminStatus.Disable;
            autoExportJobResource = await this.CreateOrUpdateAutoExportJob(DefaultAmlFS, name, dataVar, verifyResult: true);

            await Task.Delay(TimeSpan.FromSeconds(20));

            // Ensure the job is disabled before next test
            // Poll till the job is disabled
            AutoExportJobResource autoExportJob = await this.DefaultAmlFS.GetAutoExportJobs().GetAsync(name);
            Assert.IsNotNull(autoExportJob);
            while (autoExportJob.Data.State != AutoExportStatusType.Disabled)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                autoExportJob = await this.DefaultAmlFS.GetAutoExportJobs().GetAsync(name);
            }

            Assert.IsTrue(autoExportJob.Data.State == AutoExportStatusType.Disabled);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Get()
        {
            string job = "testautoexportjob";
            AutoExportJobResource autoExportJobResource = null;
            var autoExportJobs = DefaultAmlFS.GetAutoExportJobs().GetAllAsync();

            await foreach (var autoExportJob in autoExportJobs)
            {
                if (autoExportJob.Data.Name.Contains(job))
                {
                    autoExportJobResource = autoExportJob;
                }
            }

            if (null == autoExportJobResource)
            {
                AutoExportJobData dataVar = new AutoExportJobData(this.DefaultLocation)
                {
                    AutoExportPrefixes = { "/path" },
                    AdminStatus = AutoExportJobAdminStatus.Enable
                };
                autoExportJobResource = await this.CreateOrUpdateAutoExportJob(DefaultAmlFS, name: job, dataVar: dataVar);
            }

            AutoExportJobResource result = await this.DefaultAmlFS.GetAutoExportJobs().GetAsync(autoExportJobResource.Data.Name);

            this.VerifyAutoExportJob(result, autoExportJobResource.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Exists()
        {
            string name = Recording.GenerateAssetName("testAutoExportJob");
            AutoExportJobData dataVar = new AutoExportJobData(this.DefaultLocation)
            {
                AutoExportPrefixes = { "/path" },
                AdminStatus = AutoExportJobAdminStatus.Enable
            };
            await AzureResourceTestHelper.TestExists<AutoExportJobResource>(
                async () => await this.CreateOrUpdateAutoExportJob(DefaultAmlFS, name, dataVar),
                async () => await this.DefaultAmlFS.GetAutoExportJobs().ExistsAsync(name));

            await Task.Delay(TimeSpan.FromSeconds(20));

            // Ensure the job is Disabled before next test
            AutoExportJobResource autoExportJob = await this.DefaultAmlFS.GetAutoExportJobs().GetAsync(name);
            AutoExportJobData updateData = autoExportJob.Data;
            updateData.AdminStatus = AutoExportJobAdminStatus.Disable;
            await this.CreateOrUpdateAutoExportJob(DefaultAmlFS, name, updateData);

            // Poll till the job is disabled
            while (autoExportJob.Data.State != AutoExportStatusType.Disabled)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                autoExportJob = await this.DefaultAmlFS.GetAutoExportJobs().GetAsync(name);
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task GetAll()
        {
            var autoExportJobs = DefaultAmlFS.GetAutoExportJobs().GetAllAsync();

            int count = 0;
            await foreach (var autoExportJob in autoExportJobs)
            {
                count++;
            }

            Assert.IsTrue(count >= 0);
        }
    }
}
