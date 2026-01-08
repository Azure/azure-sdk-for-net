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
            var workbookTemplateCollection = resourceGroup.GetApplicationInsightsWorkbookTemplates();
            var resourceName = Recording.GenerateAssetName("testname");
            var data = new ApplicationInsightsWorkbookTemplateData(AzureLocation.EastUS);
            var lro = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            var workbookTemplate = lro.Value;
            Assert.That(workbookTemplate.Data.Name, Is.EqualTo(resourceName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workbookTemplateCollection = resourceGroup.GetApplicationInsightsWorkbookTemplates();
            var resourceName = Recording.GenerateAssetName("workbookTemplate");
            var data = new ApplicationInsightsWorkbookTemplateData(AzureLocation.EastUS);
            var lro = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            var workbookTemplate1 = lro.Value;
            var workbookTemplate2 = (await workbookTemplateCollection.GetAsync(resourceName)).Value;
            Assert.That(workbookTemplate2.Data.Name, Is.EqualTo(workbookTemplate1.Data.Name));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workbookTemplateCollection = resourceGroup.GetApplicationInsightsWorkbookTemplates();
            var resourceName1 = Recording.GenerateAssetName("workbook1");
            var resourceName2 = Recording.GenerateAssetName("workbook2");
            var data1 = new ApplicationInsightsWorkbookTemplateData(AzureLocation.EastUS);
            var data2 = new ApplicationInsightsWorkbookTemplateData(AzureLocation.EastUS);
            _ = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName1, data1);
            _ = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName2, data2);
            int count = 0;
            await foreach (var gallery in workbookTemplateCollection.GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(2));
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var workbookTemplateCollection = resourceGroup.GetApplicationInsightsWorkbookTemplates();
            var resourceName = Recording.GenerateAssetName("workbookTemplate");
            var data = new ApplicationInsightsWorkbookTemplateData(AzureLocation.EastUS);
            _ = await workbookTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data);
            Assert.Multiple(async () =>
            {
                Assert.That((bool)await workbookTemplateCollection.ExistsAsync(resourceName), Is.True);
                Assert.That((bool)await workbookTemplateCollection.ExistsAsync(resourceName + "1"), Is.False);
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await workbookTemplateCollection.ExistsAsync(null));
        }
    }
}
