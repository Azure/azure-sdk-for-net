// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class ImportJobCollectionTest : StorageCacheManagementTestBase
    {
        private AmlFileSystemResource DefaultAmlFS { get; set; }
        public ImportJobCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ImportJobSetup()
        {
            // it's very heavy to create amlFS (~20 minutes), so provide an option to use precreated resource
            //   set preCreated to true and updated the resourceGroup, cacheName below to use pre created resource
            //   set preCreated to false to create new one
            bool preCreated = true;
            this.DefaultAmlFS = preCreated ?
                await this.RetrieveExistingAmlFS(
                    resourceGroupName: this.DefaultResourceGroup.Id.Name,
                    amlFSName: @"testamlFS3768") :
                await this.CreateOrUpdateAmlFilesystem();
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testamlFS");
            StorageCacheImportJobResource importJobResource = await this.CreateOrUpdateImportJob(DefaultAmlFS, name, verifyResult: true);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Get()
        {
            string job = "jobTest";
            StorageCacheImportJobResource importJobResource = await this.CreateOrUpdateImportJob(DefaultAmlFS, name: job);
            StorageCacheImportJobResource result = await this.DefaultAmlFS.GetStorageCacheImportJobs().GetAsync(job);

            this.VerifyImportJob(result, importJobResource.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Exists()
        {
            string name = Recording.GenerateAssetName("testImportJob");
            await AzureResourceTestHelper.TestExists<StorageCacheImportJobResource>(
                async () => await this.CreateOrUpdateImportJob(DefaultAmlFS, name),
                async () => await this.DefaultAmlFS.GetStorageCacheImportJobs().ExistsAsync(name));
        }
    }
}
