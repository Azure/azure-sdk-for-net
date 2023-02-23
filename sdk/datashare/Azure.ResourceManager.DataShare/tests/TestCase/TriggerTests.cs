// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DataShare.Models;
using Azure.ResourceManager.DataShare.Tests.Helper;
using NUnit.Framework;

namespace Azure.ResourceManager.DataShare.Tests.TestCase
{
    public class TriggerTests : DataShareManagementTestBase
    {
        public TriggerTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }
        private async Task<DataShareTriggerCollection> GetTriggerCollectionAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetDataShareAccounts();
            var accoutnName = Recording.GenerateAssetName("TestAccount-");
            var accountInput = ResourceDataHelpers.GetAccount();
            var lroa = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accoutnName, accountInput);
            DataShareAccountResource accountResource = lroa.Value;
            var subscriptionCollection = accountResource.GetShareSubscriptions();
            var setName = Recording.GenerateAssetName("TestShareSubscription-");
            var setInput = ResourceDataHelpers.GetSubscriptionData(new Guid());
            var lros = await subscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, setName, setInput);
            var setresource = lros.Value;
            return setresource.GetDataShareTriggers();
        }

        [TestCase]
        [RecordedTest]
        [Ignore("No invitation found for this tenant and objectId")]
        public async Task TriggerApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetTriggerCollectionAsync();
            var name = Recording.GenerateAssetName("TestTrigger-");
            var name2 = Recording.GenerateAssetName("TestTrigger-");
            var name3 = Recording.GenerateAssetName("TestTrigger-");
            var input = ResourceDataHelpers.GetTriggerData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataShareTriggerResource trigger1 = lro.Value;
            Assert.AreEqual(name, trigger1.Data.Name);
            //2.Get
            DataShareTriggerResource trigger2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertTriggerData(trigger1.Data, trigger2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //ResourceTests
            //5.Get
            DataShareTriggerResource trigger3 = await trigger1.GetAsync();
            ResourceDataHelpers.AssertTriggerData(trigger1.Data, trigger3.Data);
            //6.Delete
            await trigger1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
