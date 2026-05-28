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
    public class DataSetMappingTests : DataShareManagementTestBase
    {
        public DataSetMappingTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ShareDataSetMappingCollection> GetDataSetMappingCollectionAsync()
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
            return setresource.GetShareDataSetMappings();
        }

        private async Task<ShareDataSetMappingResource> GetDataSetMappingResourceAsync()
        {
            var collection = await GetDataSetMappingCollectionAsync();
            var setName = Recording.GenerateAssetName("TestSetMapping-");
            var setInput = ResourceDataHelpers.GetSetMapping();
            var lros = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName, setInput);
            var setresource = lros.Value;
            return setresource;
        }

        [TestCase]
        [RecordedTest]
        [Ignore("No invitation found for this tenant and objectId")]
        public async Task DataSetMappingApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetDataSetMappingCollectionAsync();
            var name = Recording.GenerateAssetName("TestSetMapping-");
            var name2 = Recording.GenerateAssetName("TestSetMapping-");
            var name3 = Recording.GenerateAssetName("TestSetMapping-");
            var input = ResourceDataHelpers.GetSetMapping();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            ShareDataSetMappingResource mapping1 = lro.Value;
            Assert.AreEqual(name, mapping1.Data.Name);
            //2.Get
            ShareDataSetMappingResource mapping2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertMappingSet(mapping1.Data, mapping2.Data);
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
            ShareDataSetMappingResource mapping3 = await mapping1.GetAsync();
            ResourceDataHelpers.AssertMappingSet(mapping1.Data, mapping3.Data);
            //6.Delete
            await mapping1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
