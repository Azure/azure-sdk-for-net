// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApplicationInsights.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests
{
    public class WorkbookCollectionTest : ApplicationInsightsManagementTestBase
    {
        public WorkbookCollectionTest(bool isAsync)
            :base(isAsync)//,RecordedTestMode.Record)
        {
        }

        public async Task<ResourceGroupResource> GetResourceGroup()
        {
            var resourceGroupName = Recording.GenerateAssetName("RG_ApplicationInsight");
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(),resourceGroupName,AzureLocation.EastUS);
        }

        [TestCase]
        [RecordedTest]
        public async Task Create()
        {
            var resourceGroup = await GetResourceGroup();
            var workbookCollection = resourceGroup.GetWorkbooks();
            var resourceName = "123e4567-e89b-12d3-a456-426614174000";
            var workbookData = new WorkbookData(AzureLocation.EastUS)
            {
                DisplayName = "Sample workbook",
                SerializedData = "etg",
                Category = "workbook",
                Description = "Sample workbook",
                Kind = WorkbookSharedTypeKind.Shared,
                Tags =
                    {
                        ["TagSample01"] = "sample01",
                        ["TagSample02"] = "sample02",
                    },
                Identity = new ManagedServiceIdentity("none"),
            };
            var workbook = (await workbookCollection.CreateOrUpdateAsync(WaitUntil.Completed,resourceName,workbookData)).Value;
            Assert.AreEqual(workbook.Data.Name,resourceName);
            Assert.AreEqual(workbook.Data.DisplayName, "Sample workbook");
            Assert.AreEqual(workbook.Data.Location,AzureLocation.EastUS);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await GetResourceGroup();
            var workbookCollection = resourceGroup.GetWorkbooks();
            var resourceName = "123e4567-e89b-12d3-a456-426614174000";
            var workbookData = new WorkbookData(AzureLocation.EastUS)
            {
                DisplayName = "Sample workbook",
                SerializedData = "etg",
                Category = "workbook",
                Description = "Sample workbook",
                Kind = WorkbookSharedTypeKind.Shared,
                Tags =
                    {
                        ["TagSample01"] = "sample01",
                        ["TagSample02"] = "sample02",
                    },
                Identity = new ManagedServiceIdentity("none"),
            };
            var workbook1 = (await workbookCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, workbookData)).Value;
            var workbook2 = (await workbookCollection.GetAsync(resourceName)).Value;
            Assert.AreEqual(workbook1.Data.Name,workbook2.Data.Name);
            Assert.AreEqual(workbook1.Id, workbook2.Id);
            Assert.IsNotNull(workbook1.Id);
            Assert.IsNotEmpty(workbook1.Id);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await GetResourceGroup();
            var workbookCollection = resourceGroup.GetWorkbooks();
            var resourceName1 = "123e4567-e89b-12d3-a456-426614174000";
            var resourceName2 = "123e4568-e89b-12d3-a456-426614174000";
            var workbookData1 = new WorkbookData(AzureLocation.EastUS)
            {
                DisplayName = "Sample workbook1",
                SerializedData = "etg",
                Category = "workbook",
                Description = "Sample workbook",
                Kind = WorkbookSharedTypeKind.Shared,
                Tags =
                    {
                        ["TagSample01"] = "sample01",
                        ["TagSample02"] = "sample02",
                    },
                Identity = new ManagedServiceIdentity("none"),
            };
            var workbookData2 = new WorkbookData(AzureLocation.EastUS)
            {
                DisplayName = "Sample workbook2",
                SerializedData = "etg",
                Category = "workbook",
                Description = "Sample workbook",
                Kind = WorkbookSharedTypeKind.Shared,
                Tags =
                    {
                        ["TagSample01"] = "sample01",
                        ["TagSample02"] = "sample02",
                    },
                Identity = new ManagedServiceIdentity("none"),
            };
            _ = (await workbookCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName1, workbookData1)).Value;
            _ = (await workbookCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName2, workbookData2)).Value;
            var count = 0;
            var workbooks = workbookCollection.GetAllAsync(CategoryType.Workbook);
            await foreach (var workbook in workbooks)
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            var resourceGroup = await GetResourceGroup();
            var workbookCollection = resourceGroup.GetWorkbooks();
            var resourceName = "123e4567-e89b-12d3-a456-426614174000";
            var workbookData = new WorkbookData(AzureLocation.EastUS)
            {
                DisplayName = "Sample workbook",
                SerializedData = "etg",
                Category = "workbook",
                Description = "Sample workbook",
                Kind = WorkbookSharedTypeKind.Shared,
                Tags =
                    {
                        ["TagSample01"] = "sample01",
                        ["TagSample02"] = "sample02",
                    },
                Identity = new ManagedServiceIdentity("none"),
            };
            _ = await workbookCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, workbookData);
            Assert.IsTrue(await workbookCollection.ExistsAsync(resourceName));
            Assert.IsFalse(await workbookCollection.ExistsAsync(resourceName + 1));
        }
    }
}
