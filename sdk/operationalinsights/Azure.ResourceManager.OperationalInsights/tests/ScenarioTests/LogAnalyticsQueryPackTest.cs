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
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class LogAnalyticsQueryPackTest : OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public LogAnalyticsQueryPackTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task LogAnalyticsQueryPackTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "AnalyticsPack-test", _location);

            //LogAnalyticsQueryPackCollection_Create
            var queryPackName = Recording.GenerateAssetName("analyticsQueryPack");
            var queryPackResource = await CreateLogAnalyticsQueryPack(queryPackName);
            Assert.IsNotNull(queryPackResource);
            Assert.AreEqual(queryPackName, queryPackResource.Data.Name);

            //LogAnalyticsQueryPackCollection_Exist
            var _collection = _resourceGroup.GetLogAnalyticsQueryPacks();
            var exist = await _collection.ExistsAsync(queryPackName);
            Assert.IsTrue(exist);

            //LogAnalyticsQueryPackCollection_Get
            var getResult = (await _collection.GetAsync(queryPackName)).Value;
            Assert.IsNotEmpty(getResult.Data.Id);
            Assert.AreEqual(getResult.Data.Name, queryPackResource.Data.Name);

            //LogAnalyticsQueryPackCollection_GetAll
            var queryPackName2 = Recording.GenerateAssetName("analyticsQueryPack");
            var queryPackResource2 = await CreateLogAnalyticsQueryPack(queryPackName2);
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == queryPackResource.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == queryPackResource2.Data.Name));
            await queryPackResource2.DeleteAsync(WaitUntil.Completed);

            //LogAnalyticsQueryPackCollection_GetIfExistsAsync
            var getIfExists = (await _collection.GetIfExistsAsync(queryPackName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(queryPackResource.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(queryPackResource.Data.Id, getIfExists.Data.Id);
            Assert.AreEqual(queryPackResource.Data.QueryPackId, getIfExists.Data.QueryPackId);

            //LogAnalyticsQueryPackResource_CreateResourceIdentifier and Get
            var resourceId = LogAnalyticsQueryPackResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, queryPackResource.Data.Name);
            var identifierResource = Client.GetLogAnalyticsQueryPackResource(resourceId);
            Assert.IsNotNull(identifierResource);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(queryPackResource.Data.Id, verify.Data.Id);
            Assert.AreEqual(queryPackResource.Data.Name, verify.Data.Name);

            //LogAnalyticsQueryPackResource_TagOperation
            var addTag = (await queryPackResource.AddTagAsync("key2","AddTags")).Value; //AddTags
            Assert.IsNotEmpty(addTag.Data.Tags);
            Assert.IsTrue(addTag.Data.Tags.ContainsKey("key2"));
            var setDic = new Dictionary<string, string>() //SetTags
            {
                ["key1"] = "LogAnalyticsQueryPackTest",
                ["key2"] = "TagOperation",
                ["key3"] = "SetTagsTest"
            };
            var setTag = (await queryPackResource.SetTagsAsync(setDic)).Value;
            Assert.AreEqual(setTag.Data.Tags["key1"], setDic["key1"]);
            Assert.IsTrue(setTag.Data.Tags["key2"] != "AddTags");
            string removeKey = "key3";
            var removeTag = await queryPackResource.RemoveTagAsync(removeKey); //RemoveTags
            Assert.IsFalse(removeTag.Value.Data.Tags.ContainsKey(removeKey));

            //LogAnalyticsQueryPackResource_Update
            var updateData = new LogAnalyticsQueryPackPatch()
            {
                Tags =
                {
                    ["key4"] = "updateTest",
                    ["key5"] = "A container holding only the Tags for a resource",
                    ["key6"] = "testdata"
                }
            };
            var update = (await queryPackResource.UpdateAsync(updateData)).Value;
            Assert.IsNotNull(update);
            var verifyDic = new Dictionary<string, string>();
            foreach (var item in update.Data.Tags)
            {
                verifyDic.Add(item.Key, item.Value);
            }
            foreach (var item in updateData.Tags)
            {
                Assert.IsTrue(verifyDic.ContainsKey(item.Key));
                Assert.IsTrue(verifyDic.ContainsValue(item.Value));
            }

            //LogAnalyticsQueryPackResource_SearchQueries
            var searchlist = new List<string>() { "SearchQueries","TagTest","TestData" };
            var searchData = new LogAnalyticsQuerySearchProperties()
            {
                Tags =
                {
                    ["key1"] = searchlist
                }
            };
            var search =queryPackResource.SearchQueriesAsync(searchData);
            Assert.IsNotNull(search);

            //LogAnalyticsQueryPackResource_Delete
            var delete = await queryPackResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(queryPackName));
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        public async Task<LogAnalyticsQueryPackResource> CreateLogAnalyticsQueryPack(string queryPackName)
        {
            var data = new LogAnalyticsQueryPackData(_location)
            {
                Tags =
                {
                    ["key1"] = "value"
                }
            };
            return (await _resourceGroup.GetLogAnalyticsQueryPacks().CreateOrUpdateAsync(WaitUntil.Completed, queryPackName, data)).Value;
        }
    }
}
