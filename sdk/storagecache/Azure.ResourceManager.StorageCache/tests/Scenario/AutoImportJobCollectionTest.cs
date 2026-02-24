// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class AutoImportJobCollectionTest : StorageCacheManagementTestBase
    {
        private AmlFileSystemResource DefaultAmlFS { get; set; }
        public AutoImportJobCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task AutoImportJobSetup()
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
            string name = Recording.GenerateAssetName("testautoimportjob");
            AutoImportJobData dataVar = new AutoImportJobData(this.DefaultLocation)
            {
                AutoImportPrefixes = { "/path" },
                ConflictResolutionMode = ConflictResolutionMode.Fail,
                MaximumErrors = 2,
                EnableDeletions = false,
                AdminStatus = AutoImportJobPropertiesAdminStatus.Enable
            };
            AutoImportJobResource autoImportJobResource = await this.CreateOrUpdateAutoImportJob(DefaultAmlFS, name, dataVar, verifyResult: true);

            await Task.Delay(TimeSpan.FromSeconds(60));

            dataVar.AdminStatus = AutoImportJobPropertiesAdminStatus.Disable;
            autoImportJobResource = await this.CreateOrUpdateAutoImportJob(DefaultAmlFS, name, dataVar, verifyResult: true);

            // Ensure the job is disabled before next test
            // Poll till the job is disabled
            AutoImportJobResource autoImportJob = await this.DefaultAmlFS.GetAutoImportJobs().GetAsync(name);
            Assert.IsNotNull(autoImportJob);
            while (autoImportJob.Data.State != AutoImportJobState.Disabled)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                autoImportJob = await this.DefaultAmlFS.GetAutoImportJobs().GetAsync(name);
            }

            Assert.IsTrue(autoImportJob.Data.State == AutoImportJobState.Disabled);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Get()
        {
            string job = "testautoimportjob";
            AutoImportJobResource autoImportJobResource = null;
            var autoImportJobs = DefaultAmlFS.GetAutoImportJobs().GetAllAsync();

            await foreach (var autoImportJob in autoImportJobs)
            {
                if (autoImportJob.Data.Name.Contains(job))
                {
                    autoImportJobResource = autoImportJob;
                }
            }

            if (null == autoImportJobResource)
            {
                AutoImportJobData dataVar = new AutoImportJobData(this.DefaultLocation)
                {
                    AutoImportPrefixes = { "/path" },
                    ConflictResolutionMode = ConflictResolutionMode.Fail,
                    MaximumErrors = 2,
                    EnableDeletions = false,
                    AdminStatus = AutoImportJobPropertiesAdminStatus.Enable
                };
                autoImportJobResource = await this.CreateOrUpdateAutoImportJob(DefaultAmlFS, name: job, dataVar: dataVar);
            }

            AutoImportJobResource result = await this.DefaultAmlFS.GetAutoImportJobs().GetAsync(autoImportJobResource.Data.Name);

            this.VerifyAutoImportJob(result, autoImportJobResource.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Exists()
        {
            string name = Recording.GenerateAssetName("testAutoImportJob");
            AutoImportJobData dataVar = new AutoImportJobData(this.DefaultLocation)
            {
                AutoImportPrefixes = { "/path" },
                ConflictResolutionMode = ConflictResolutionMode.Fail,
                MaximumErrors = 2,
                EnableDeletions = false,
                AdminStatus = AutoImportJobPropertiesAdminStatus.Enable
            };
            await AzureResourceTestHelper.TestExists<AutoImportJobResource>(
                async () => await this.CreateOrUpdateAutoImportJob(DefaultAmlFS, name, dataVar),
                async () => await this.DefaultAmlFS.GetAutoImportJobs().ExistsAsync(name));

            // Ensure the job is Disabled before next test
            AutoImportJobResource autoImportJob = await this.DefaultAmlFS.GetAutoImportJobs().GetAsync(name);
            AutoImportJobData updateData = autoImportJob.Data;
            updateData.AdminStatus = AutoImportJobPropertiesAdminStatus.Disable;
            await this.CreateOrUpdateAutoImportJob(DefaultAmlFS, name, updateData);

            // Poll till the job is disabled
            while (autoImportJob.Data.State != AutoImportJobState.Disabled)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                autoImportJob = await this.DefaultAmlFS.GetAutoImportJobs().GetAsync(name);
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task GetAll()
        {
            var autoImportJobs = DefaultAmlFS.GetAutoImportJobs().GetAllAsync();

            int count = 0;
            await foreach (var autoImportJob in autoImportJobs)
            {
                count++;
            }

            Assert.IsTrue(count >= 0);
        }
    }
}
