// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class ImportJobResourceTest : StorageCacheManagementTestBase
    {
        private AmlFileSystemResource DefaultAmlFS { get; set; }
        public ImportJobResourceTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ImportJobSetup()
        {
            // it's very heavy to create storage cache (~20 minutes), so provide an option to use precreated resource
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
        public async Task Delete()
        {
            await AzureResourceTestHelper.TestDelete(
                async () => await this.CreateOrUpdateImportJob(this.DefaultAmlFS),
                async (res) => await res.DeleteAsync(WaitUntil.Completed),
                async (res) => await res.GetAsync());
        }
    }
}
