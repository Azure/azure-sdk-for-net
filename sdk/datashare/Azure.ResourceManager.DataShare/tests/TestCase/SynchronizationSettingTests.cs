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
using System.Security.Cryptography.X509Certificates;

namespace Azure.ResourceManager.DataShare.Tests.TestCase
{
    public class SynchronizationSettingTests : DataShareManagementTestBase
    {
        public SynchronizationSettingTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DataShareSynchronizationSettingCollection> GetHronizationSettingCollectionAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetDataShareAccounts();
            var accoutnName = Recording.GenerateAssetName("TestAccount-");
            var accountInput = ResourceDataHelpers.GetAccount();
            var lroa = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accoutnName, accountInput);
            DataShareAccountResource accountResource = lroa.Value;
            DataShareCollection datashareCollection = accountResource.GetDataShares();
            var shareName = Recording.GenerateAssetName("TestShare-");
            var shareInput = ResourceDataHelpers.GetShareData();
            var lros = await datashareCollection.CreateOrUpdateAsync(WaitUntil.Completed, shareName, shareInput);
            var shareresource = lros.Value;
            var hronizationCollection = shareresource.GetDataShareSynchronizationSettings();
            return hronizationCollection;
        }

        [TestCase]
        [RecordedTest]
        public async Task HronizationSettingApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetHronizationSettingCollectionAsync();
            var name = Recording.GenerateAssetName("TestHronization-");
            var name2 = Recording.GenerateAssetName("TestHronization-");
            var name3 = Recording.GenerateAssetName("TestHronization-");
            var input = ResourceDataHelpers.GetSynchronizationData(Recording.UtcNow);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataShareSynchronizationSettingResource hronization1 = lro.Value;
            Assert.AreEqual(name, hronization1.Data.Name);
            //2.Get
            DataShareSynchronizationSettingResource hronization2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertSynchronizationData(hronization1.Data, hronization2.Data);
            //3.GetAll
            /*_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);*/
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //ResourceTests
            //5.Get
            DataShareSynchronizationSettingResource hronization3 = await hronization1.GetAsync();
            ResourceDataHelpers.AssertSynchronizationData(hronization1.Data, hronization3.Data);
            //6.Delete
            await hronization1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
