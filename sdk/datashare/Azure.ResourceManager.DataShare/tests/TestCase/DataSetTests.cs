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
    public class DataSetTests : DataShareManagementTestBase
    {
        public DataSetTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ShareDataSetCollection> GetDataSetCollectionAsync()
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
            var setCollection = shareresource.GetShareDataSets();
            return setCollection;
        }

        private async Task<ShareDataSetResource> GetDataSetResourceAsync()
        {
            var collection =await GetDataSetCollectionAsync();
            var setName = Recording.GenerateAssetName("TestSet-");
            var setInput = ResourceDataHelpers.GetDataSetData();
            var lros = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName, setInput);
            var setresource = lros.Value;
            return setresource;
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Missing permissions for DatashareAccount on BlobStorage Account")]
        public async Task DataSetApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetDataSetCollectionAsync();
            var name = Recording.GenerateAssetName("TestSet-");
            var name2 = Recording.GenerateAssetName("TestSet-");
            var name3 = Recording.GenerateAssetName("TestSet-");
            var input = ResourceDataHelpers.GetDataSetData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            ShareDataSetResource set1 = lro.Value;
            Assert.AreEqual(name, set1.Data.Name);
            //2.Get
            ShareDataSetResource set2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertDataSet(set1.Data, set2.Data);
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
            ShareDataSetResource set3 = await set1.GetAsync();
            ResourceDataHelpers.AssertDataSet(set1.Data, set3.Data);
            //6.Delete
            await set1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
