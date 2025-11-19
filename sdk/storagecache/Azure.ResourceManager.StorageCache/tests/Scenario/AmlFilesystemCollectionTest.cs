// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class AmlFilesystemCollectionTest : StorageCacheManagementTestBase
    {
        public AmlFilesystemCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testamlFS");
            AmlFileSystemResource amlFSResource = await this.CreateOrUpdateAmlFilesystem(name, verifyResult: true);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Get()
        {
            AmlFileSystemResource amlFSResource = await this.CreateOrUpdateAmlFilesystem();
            AmlFileSystemResource result = await this.DefaultResourceGroup.GetAmlFileSystems().GetAsync(amlFileSystemName: amlFSResource.Id.Name);

            this.VerifyAmlFileSystem(result, amlFSResource.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Exists()
        {
            string name = Recording.GenerateAssetName("testamlFS");
            await AzureResourceTestHelper.TestExists<AmlFileSystemResource>(
                async () => await this.CreateOrUpdateAmlFilesystem(name),
                async () => await this.DefaultResourceGroup.GetAmlFileSystems().ExistsAsync(name));
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task GetAll()
        {
            await AzureResourceTestHelper.TestGetAll<AmlFileSystemResource>(
                count: 2,
                async (i) => await this.CreateOrUpdateAmlFilesystem(),
                () => this.DefaultResourceGroup.GetAmlFileSystems().GetAllAsync());
        }
    }
}
