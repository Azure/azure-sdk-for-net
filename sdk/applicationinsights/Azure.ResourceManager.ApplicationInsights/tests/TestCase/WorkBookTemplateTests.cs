// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApplicationInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests.TestCase
{
    public class WorkBookTemplateTests : ApplicationInsightsManagementTestBase
    {
        public WorkBookTemplateTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<WorkbookTemplateCollection> GetWorkbookTemplateCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetWorkbookTemplates();
            return collection;
        }

        [TestCase]
        public async Task TemplateApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetWorkbookTemplateCollectionAsync();
            var name = Recording.GenerateAssetName("template");
            var name2 = Recording.GenerateAssetName("template");
            var name3 = Recording.GenerateAssetName("template");
            var input = ResourceDataHelpers.GetWorkbookTemplateData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            WorkbookTemplateResource template = lro.Value;
            Assert.AreEqual(name, template.Data.Name);
            //2.Get
            WorkbookTemplateResource template2 = await template.GetAsync();
            //ResourceDataHelpers.AssertTemplateData(template.Data, template2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            AsyncPageable<WorkbookTemplateResource> workbookTemplateResources = collection.GetAllAsync();
            await foreach (var num in workbookTemplateResources)
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            WorkbookTemplateResource template3 = await template.GetAsync();
            ResourceDataHelpers.AssertTemplateData(template.Data, template3.Data);
            //6.Delete
            await template.DeleteAsync(WaitUntil.Completed);
        }
    }
}
