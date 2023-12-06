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
using Azure.ResourceManager.ManagedServiceIdentities;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.OperationalInsights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class OperationalInsightsDataSourceTest: OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public OperationalInsightsDataSourceTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task OperationalInsightsDataSourceTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsDataSource-test", _location);
            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            var _collection = workSpace.GetOperationalInsightsDataSources();

            //OperationalInsightsDataSourceCollection_Create
            var dataSourcesName = Recording.GenerateAssetName("opDataSource");
            var sourcesData = new OperationalInsightsDataSourceData(BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
                ["LinkedResourceId"] = $"/subscriptions/{_subscription.Data.SubscriptionId}/providers/Microsoft.Insights/eventtypes/management"
            }), OperationalInsightsDataSourceKind.AzureActivityLog)
            {
                Tags =
                {
                    ["key1"] = "value"
                }
            };
            var dataSources = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, dataSourcesName, sourcesData)).Value;
            Assert.IsNotNull(dataSources);
            Assert.AreEqual(dataSourcesName, dataSources.Data.Name);

            //OperationalInsightsDataSourceCollection_Exist
            var exist = await _collection.ExistsAsync(dataSourcesName);
            Assert.IsTrue(exist);

            //OperationalInsightsDataSourceCollection_Get
            var getResult = await _collection.GetAsync(dataSourcesName);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.Name, dataSources.Data.Name);

            //OperationalInsightsDataSourceCollection_GetAll
            string filter = "$filter=kind eq 'AzureActivityLog'";
            var list = await _collection.GetAllAsync(filter).ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count >= 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == dataSources.Data.Name));

            //OperationalInsightsDataSourceCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(dataSourcesName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(dataSources.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(dataSources.Data.Id, getIfExists.Data.Id);

            //OperationalInsightsDataSourceResource_CreateResourceIdentifier and Get
            var resourceId = OperationalInsightsDataSourceResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name,workSpace.Data.Name, dataSources.Data.Name);
            var identifierResource = Client.GetOperationalInsightsDataSourceResource(resourceId);
            Assert.IsNotNull(identifierResource);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(dataSources.Data.Id, verify.Data.Id);
            Assert.AreEqual(dataSources.Data.Name, verify.Data.Name);

            //OperationalInsightsDataSourceResource_Delete
            var delete = await dataSources.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(dataSourcesName));
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [Ignore("Only verifying that the testcase builds")]
        public async Task TagOperationAndUpdate()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsDataSource-test", _location);
            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            var dataSourcesName = Recording.GenerateAssetName("opDataSource");
            var sourcesData = new OperationalInsightsDataSourceData(BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
                ["LinkedResourceId"] = $"/subscriptions/{_subscription.Data.SubscriptionId}/providers/Microsoft.Insights/eventtypes/management"
            }), OperationalInsightsDataSourceKind.AzureActivityLog)
            {
                Tags =
                {
                    ["key1"] = "value"
                }
            };
            var dataSources = (await workSpace.GetOperationalInsightsDataSources().CreateOrUpdateAsync(WaitUntil.Completed, dataSourcesName, sourcesData)).Value;

            //OperationalInsightsDataSourceResource_TagsOperation
            var addTag = (await dataSources.AddTagAsync("key2", "AddTags")).Value; //AddTags
            Assert.IsNotEmpty(addTag.Data.Tags);
            Assert.IsTrue(addTag.Data.Tags.ContainsKey("key2"));
            var setDic = new Dictionary<string, string>() //SetTags
            {
                ["key1"] = "OperationalInsightsDataSourceTest",
                ["key2"] = "TagOperation",
                ["key3"] = "SetTagsTest"
            };
            var setTag = (await dataSources.SetTagsAsync(setDic)).Value;
            Assert.AreEqual(setTag.Data.Tags["key1"], setDic["key1"]);
            Assert.IsTrue(setTag.Data.Tags["key2"] != "AddTags");
            string removeKey = "key3";
            var removeTag = await dataSources.RemoveTagAsync(removeKey); //RemoveTags
            Assert.IsFalse(removeTag.Value.Data.Tags.ContainsKey(removeKey));

            //OperationalInsightsDataSourceResource_Update
            var updateData = new OperationalInsightsDataSourceData(BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
                ["LinkedResourceId"] = $"/subscriptions/{_subscription.Data.SubscriptionId}/providers/microsoft.insights/eventtypes/management"
            }), OperationalInsightsDataSourceKind.AzureActivityLog)
            {
                Tags =
                {
                    ["key4"] = "updateTest",
                    ["key5"] = "testdata"
                }
            };
            var update = (await dataSources.UpdateAsync(WaitUntil.Completed, updateData)).Value;
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
        }
    }
}
