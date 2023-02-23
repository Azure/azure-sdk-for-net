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
    public class DataShareTests : DataShareManagementTestBase
    {
        public DataShareTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DataShareCollection> GetDataShareCollectionAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetDataShareAccounts();
            var accoutnName = Recording.GenerateAssetName("TestAccount-");
            var accountInput = ResourceDataHelpers.GetAccount();
            var lroa = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accoutnName, accountInput);
            DataShareAccountResource accountResource = lroa.Value;
            return accountResource.GetDataShares();
        }

        private async Task<DataShareResource> GetDataShareResourceAsync()
        {
            var collection = await GetDataShareCollectionAsync();
            var shareName = Recording.GenerateAssetName("TestShare-");
            var shareInput = ResourceDataHelpers.GetShareData();
            var lros = await collection.CreateOrUpdateAsync(WaitUntil.Completed, shareName, shareInput);
            var setresource = lros.Value;
            return setresource;
        }

        [TestCase]
        [RecordedTest]
        public async Task DaataShareApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetDataShareCollectionAsync();
            var name = Recording.GenerateAssetName("TestDataShare-");
            var name2 = Recording.GenerateAssetName("TestDataShare-");
            var name3 = Recording.GenerateAssetName("TestDataShare-");
            var input = ResourceDataHelpers.GetShareData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataShareResource share1 = lro.Value;
            Assert.AreEqual(name, share1.Data.Name);
            //2.Get
            DataShareResource share2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertShareData(share1.Data, share2.Data);
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
            DataShareResource share3 = await share1.GetAsync();
            ResourceDataHelpers.AssertShareData(share1.Data, share3.Data);
            //6.Delete
            await share1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
