// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class AmlFileSystemExpansionJobCollectionTest : StorageCacheManagementTestBase
    {
        private AmlFileSystemResource DefaultAmlFS { get; set; }
        public AmlFileSystemExpansionJobCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ExpansionJobSetup()
        {
            // it's very heavy to create amlFS (~20 minutes), so provide an option to use precreated resource
            //   set preCreated to true and updated the resourceGroup, cacheName below to use pre created resource
            //   set preCreated to false to create new one
            bool preCreated = true;
            this.DefaultAmlFS = preCreated ?
                await this.RetrieveExistingAmlFS(
                    resourceGroupName: this.DefaultResourceGroup.Id.Name,
                    amlFSName: @"testamlFS2729") :
                await this.CreateOrUpdateAmlFilesystem();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testexpansionjob1");
            AmlFileSystemExpansionJobResource expansionJobResource = null;

            // Check if an expansion job already exists
            var expansionJobs = DefaultAmlFS.GetAmlFileSystemExpansionJobs().GetAllAsync();
            await foreach (var expansionJob in expansionJobs)
            {
                if (expansionJob.Data.Name.Contains(name))
                {
                    expansionJobResource = expansionJob;
                }
            }

            if (null == expansionJobResource)
            {
                AmlFileSystemExpansionJobData dataVar = new AmlFileSystemExpansionJobData(this.DefaultLocation)
                {
                    NewStorageCapacityTiB = 64,
                };
                expansionJobResource = await this.CreateOrUpdateExpansionJob(DefaultAmlFS, name, dataVar, verifyResult: false);
            }

            Assert.IsNotNull(expansionJobResource);
            Assert.IsNotNull(expansionJobResource.Data.ProvisioningState);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string job = "testexpansionjob1";
            AmlFileSystemExpansionJobResource expansionJobResource = null;
            var expansionJobs = DefaultAmlFS.GetAmlFileSystemExpansionJobs().GetAllAsync();

            await foreach (var expansionJob in expansionJobs)
            {
                if (expansionJob.Data.Name.Contains(job))
                {
                    expansionJobResource = expansionJob;
                }
            }

            if (null == expansionJobResource)
            {
                AmlFileSystemExpansionJobData dataVar = new AmlFileSystemExpansionJobData(this.DefaultLocation)
                {
                    NewStorageCapacityTiB = 64,
                };
                expansionJobResource = await this.CreateOrUpdateExpansionJob(DefaultAmlFS, name: job, dataVar: dataVar);
            }

            AmlFileSystemExpansionJobResource result = await this.DefaultAmlFS.GetAmlFileSystemExpansionJobs().GetAsync(expansionJobResource.Data.Name);

            this.VerifyExpansionJob(result, expansionJobResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            string name = "testexpansionjob1";

            // Check if an expansion job already exists
            bool alreadyExists = false;
            var expansionJobs = DefaultAmlFS.GetAmlFileSystemExpansionJobs().GetAllAsync();
            await foreach (var expansionJob in expansionJobs)
            {
                if (expansionJob.Data.Name.Contains(name))
                {
                    alreadyExists = true;
                }
            }

            if (!alreadyExists)
            {
                AmlFileSystemExpansionJobData dataVar = new AmlFileSystemExpansionJobData(this.DefaultLocation)
                {
                    NewStorageCapacityTiB = 64,
                };
                await this.CreateOrUpdateExpansionJob(DefaultAmlFS, name, dataVar);
            }

            bool exists = await this.DefaultAmlFS.GetAmlFileSystemExpansionJobs().ExistsAsync(name);
            Assert.IsTrue(exists);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var expansionJobs = DefaultAmlFS.GetAmlFileSystemExpansionJobs().GetAllAsync();

            int count = 0;
            await foreach (var expansionJob in expansionJobs)
            {
                count++;
            }

            Assert.IsTrue(count >= 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string name = "testexpansionjob1";
            AmlFileSystemExpansionJobResource expansionJobResource = null;

            // Check if an expansion job already exists
            var expansionJobs = DefaultAmlFS.GetAmlFileSystemExpansionJobs().GetAllAsync();
            await foreach (var expansionJob in expansionJobs)
            {
                if (expansionJob.Data.Name.Contains(name))
                {
                    expansionJobResource = expansionJob;
                }
            }

            if (null == expansionJobResource)
            {
                AmlFileSystemExpansionJobData dataVar = new AmlFileSystemExpansionJobData(this.DefaultLocation)
                {
                    NewStorageCapacityTiB = 64,
                };
                expansionJobResource = await this.CreateOrUpdateExpansionJob(DefaultAmlFS, name, dataVar);
            }

            await this.WaitForExpansionJobCompletion(DefaultAmlFS, expansionJobResource.Data.Name);

            // Verify the job exists before deleting
            AmlFileSystemExpansionJobResource gotBeforeDelete = await this.DefaultAmlFS.GetAmlFileSystemExpansionJobs().GetAsync(expansionJobResource.Data.Name);
            Assert.IsNotNull(gotBeforeDelete);

            await expansionJobResource.DeleteAsync(WaitUntil.Completed);

            bool exists = await this.DefaultAmlFS.GetAmlFileSystemExpansionJobs().ExistsAsync(expansionJobResource.Data.Name);
            Assert.IsFalse(exists);
        }
    }
}
