// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class StorageInsightTest : OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public StorageInsightTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        [Ignore("issue:https://github.com/Azure/azure-rest-api-specs/issues/27057")]
        public async Task StorageInsightTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "StorageInsight-test", _location);

            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            var _collection = workSpace.GetStorageInsights();

            //StorageInsightCollection_Create
            var stAccount = await CreateStorageAccount();
            var stKey = stAccount.GetKeysAsync().ToEnumerableAsync().Result.ToList()[0];
            var inStName = Recording.GenerateAssetName("OpStInsight");
            var inStData = new StorageInsightData()
            {
                StorageAccount = new OperationalInsightsStorageAccount(stAccount.Data.Id, stKey.Value),
                Tags =
                {
                    ["key1"] = "value"
                },
                Containers =
                {
                    "wad-iis-logfiles"
                },
                Tables =
                {
                "WADWindowsEventLogsTable","LinuxSyslogVer2v0"
                },
            };

            var inStorage = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, inStName, inStData)).Value;
            Assert.IsNotNull(inStorage);
            Assert.AreEqual(inStName, inStorage.Data.Name);

            //StorageInsightCollection_Exist
            var exist = await _collection.ExistsAsync(inStName);
            Assert.IsTrue(exist);

            //StorageInsightCollection_Get
            var getResult = await _collection.GetAsync(inStName);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.Name, inStorage.Data.Name);

            //StorageInsightCollection_GetAll
            var inStName2 = Recording.GenerateAssetName("OpStInsight2nd");
            var inStData2 = new StorageInsightData()
            {
                StorageAccount = new OperationalInsightsStorageAccount(stAccount.Data.Id, stKey.Value),
            };
            var inStorage2 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, inStName2, inStData2)).Value;
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == inStorage.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == inStorage2.Data.Name));
            await inStorage2.DeleteAsync(WaitUntil.Completed);

            //StorageInsightCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(inStName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(inStorage.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(inStorage.Data.Id, getIfExists.Data.Id);

            //StorageInsightResource_CreateResourceIdentifier and Get
            var resourceId = StorageInsightResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, workSpace.Data.Name, inStorage.Data.Name);
            var identifierResource = Client.GetStorageInsightResource(resourceId);
            Assert.IsNotNull(identifierResource);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(inStorage.Data.Id, verify.Data.Id);
            Assert.AreEqual(inStorage.Data.Name, verify.Data.Name);

            //StorageInsightResource_TagsOperation
            var addTag = (await inStorage.AddTagAsync("key2", "AddTags")).Value; //AddTags
            Assert.IsNotEmpty(addTag.Data.Tags);
            Assert.IsTrue(addTag.Data.Tags.ContainsKey("key2"));
            var setDic = new Dictionary<string, string>() //SetTags
            {
                ["key1"] = "OperationalInsightsLinkedServiceTest",
                ["key2"] = "TagOperation",
                ["key3"] = "SetTagsTest"
            };
            var setTag = (await inStorage.SetTagsAsync(setDic)).Value;
            Assert.AreEqual(setTag.Data.Tags["key1"], setDic["key1"]);
            Assert.IsTrue(setTag.Data.Tags["key2"] != "AddTags");
            string removeKey = "key3";
            var removeTag = await inStorage.RemoveTagAsync(removeKey); //RemoveTags
            Assert.IsFalse(removeTag.Value.Data.Tags.ContainsKey(removeKey));

            //StorageInsightResource_Update
            var updateData = new StorageInsightData()
            {
                StorageAccount = new OperationalInsightsStorageAccount(stAccount.Data.Id, stKey.Value),
                Tags =
                {
                    ["key4"] = "updateTest",
                    ["key5"] = "testdata"
                }
            };
            var update = (await inStorage.UpdateAsync(WaitUntil.Completed, updateData)).Value;
            Assert.IsNotNull(update);
            var verifyTagDic = new Dictionary<string, string>();
            foreach (var item in update.Data.Tags)
            {
                verifyTagDic.Add(item.Key, item.Value);
            }
            foreach (var item in updateData.Tags)
            {
                Assert.IsTrue(verifyTagDic.ContainsKey(item.Key));
                Assert.IsTrue(verifyTagDic.ContainsValue(item.Value));
            }

            //StorageInsightResource_Delete
            var delete = await inStorage.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(inStName));
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        public async Task<StorageAccountResource> CreateStorageAccount()
        {
            var stName = Recording.GenerateAssetName("stinsight");
            var stData = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardGrs), StorageKind.Storage, _location);
            return (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, stName, stData)).Value;
        }
    }
}
