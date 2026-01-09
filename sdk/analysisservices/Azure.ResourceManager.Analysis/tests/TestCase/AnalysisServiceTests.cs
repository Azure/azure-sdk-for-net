// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Analysis.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Analysis.Tests
{
    public class AnalysisServiceTests : AnalysisManagementTestBase
    {
        public AnalysisServiceTests(bool isAsync):
            base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private AnalysisServerData GetServerData()
        {
            var sku = new AnalysisResourceSku("S1")
            {
                Tier = AnalysisSkuTier.Standard
            };
            var data = new AnalysisServerData(DefaultLocation, sku)
            {
                AsAdministrators = new ServerAdministrators()
                {
                },
                BackupBlobContainerUri = new Uri("https://aassdk1.blob.core.windows.net/azsdktest?dummykey1")
            };
            return data;
        }

        private async Task<AnalysisServerCollection> GetCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetAnalysisServers();
            return collection;
        }

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.Multiple(() =>
            {
                Assert.That(r2.Name, Is.EqualTo(r1.Name));
                Assert.That(r2.Id, Is.EqualTo(r1.Id));
                Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
            });
        }

        private void AssertService(AnalysisServerData data1, AnalysisServerData data2)
        {
            AssertResource(data1, data2);
            Assert.Multiple(() =>
            {
                Assert.That(data2.State, Is.EqualTo(data1.State));
                Assert.That(data2.AnalysisServerSku, Is.EqualTo(data1.AnalysisServerSku));
                Assert.That(data2.BackupBlobContainerUri, Is.EqualTo(data1.BackupBlobContainerUri));
                Assert.That(data2.Location, Is.EqualTo(data1.Location));
            });
        }

        [TestCase]
        public async Task AnalysticServiceTests()
        {
            var collection = await GetCollection();
            var name = Recording.GenerateAssetName("analysisservice");
            var name2 = Recording.GenerateAssetName("analysisservice");
            var name3 = Recording.GenerateAssetName("analysisservice");
            var input = GetServerData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AnalysisServerResource account = lro.Value;
            Assert.That(account.Data.Name, Is.EqualTo(name));
            //2.Get
            AnalysisServerResource account2 = await account.GetAsync();
            AssertService(account.Data, account2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }

            Assert.Multiple(async () =>
            {
                Assert.That(count, Is.GreaterThanOrEqualTo(3));
                //4.Exists
                Assert.That((bool)await collection.ExistsAsync(name), Is.True);
                Assert.That((bool)await collection.ExistsAsync(name + "1"), Is.False);
            });

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            AnalysisServerResource account3 = await account.GetAsync();
            AssertService(account.Data, account3.Data);
            //6.CheckAnalysisServerNameAvailability
            AnalysisServerNameAvailabilityContent content = new AnalysisServerNameAvailabilityContent()
            {
                Name = name,
                ResourceType = "Microsoft.AnalysisServices/servers",
            };
            AnalysisServerNameAvailabilityResult result = await DefaultSubscription.CheckAnalysisServerNameAvailabilityAsync(DefaultLocation, content);
            //7.suspend
            await account.SuspendAsync(WaitUntil.Completed);
            //8.Resume
            await account.ResumeAsync(WaitUntil.Completed);
            //9.Delete
            await account.DeleteAsync(WaitUntil.Completed);
        }
    }
}
