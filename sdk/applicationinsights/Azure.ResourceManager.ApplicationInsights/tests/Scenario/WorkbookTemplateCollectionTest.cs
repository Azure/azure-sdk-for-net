// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests.Scenario
{
    public class WorkbookTemplateCollectionTest : ApplicationInsightsManagementTestBase
    {
        public WorkbookTemplateCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "RG_Application", AzureLocation.EastAsia);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workbookTemplateCollection = resourceGroup.GetWorkbookTemplates();
            var resourceName = Recording.GenerateAssetName("testname");
            var data = new WorkbookTemplateData(AzureLocation.EastUS);
            var lro = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            var workbookTemplate = lro.Value;
            Assert.AreEqual(resourceName, workbookTemplate.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workbookTemplateCollection = resourceGroup.GetWorkbookTemplates();
            var resourceName = Recording.GenerateAssetName("workbookTemplate");
            var data = new WorkbookTemplateData(AzureLocation.EastUS);
            var lro = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            var workbookTemplate1 = lro.Value;
            var workbookTemplate2 = (await workbookTemplateCollection.GetAsync(resourceName)).Value;
            Assert.AreEqual(workbookTemplate1.Data.Name, workbookTemplate2.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workbookTemplateCollection = resourceGroup.GetWorkbookTemplates();
            var resourceName1 = Recording.GenerateAssetName("workbook1");
            var resourceName2 = Recording.GenerateAssetName("workbook2");
            var data1 = new WorkbookTemplateData(AzureLocation.EastUS);
            var data2 = new WorkbookTemplateData(AzureLocation.EastUS);
            _ = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName1, data1);
            _ = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName2, data2);
            int count = 0;
            await foreach (var gallery in workbookTemplateCollection.GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workbookTemplateCollection = resourceGroup.GetWorkbookTemplates();
            var resourceName = Recording.GenerateAssetName("workbookTemplate");
            var data = new WorkbookTemplateData(AzureLocation.EastUS);
            _ = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            Assert.IsTrue(await workbookTemplateCollection.ExistsAsync(resourceName));
            Assert.IsFalse(await workbookTemplateCollection.ExistsAsync(resourceName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await workbookTemplateCollection.ExistsAsync(null));
        }
    }
}
