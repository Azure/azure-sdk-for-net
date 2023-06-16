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
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testamlFS");
            AmlFilesystemResource amlFSResource = await this.CreateOrUpdateAmlFilesystem(name, verifyResult: true);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            AmlFilesystemResource amlFSResource = await this.CreateOrUpdateAmlFilesystem();
            AmlFilesystemResource result = await this.DefaultResourceGroup.GetAmlFilesystems().GetAsync(amlFilesystemName: amlFSResource.Id.Name);

            this.VerifyAmlFilesystem(result, amlFSResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            string name = Recording.GenerateAssetName("testamlFS");
            await AzureResourceTestHelper.TestExists<AmlFilesystemResource>(
                async () => await this.CreateOrUpdateAmlFilesystem(name),
                async () => await this.DefaultResourceGroup.GetAmlFilesystems().ExistsAsync(name));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            await AzureResourceTestHelper.TestGetAll<AmlFilesystemResource>(
                count: 2,
                async (i) => await this.CreateOrUpdateAmlFilesystem(),
                () => this.DefaultResourceGroup.GetAmlFilesystems().GetAllAsync());
        }
    }
}
