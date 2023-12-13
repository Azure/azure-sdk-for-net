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
using Azure.ResourceManager.Models;
using Microsoft.Identity.Client.AppConfig;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class OperationalInsightsLinkedServiceTest : OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public OperationalInsightsLinkedServiceTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        [Ignore("issue:https://github.com/Azure/azure-sdk-for-net/issues/40606")]
        public async Task OperationalInsightsLinkedServiceTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsLinkedService-test", _location);

            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            var _collection = workSpace.GetOperationalInsightsLinkedServices();
            var cluster = await Createcluster();

            //OperationalInsightsLinkedServiceCollection_Create
            var linkedName = Recording.GenerateAssetName("OpLinkedService");
            var linkedData = new OperationalInsightsLinkedServiceData()
            {
                WriteAccessResourceId = cluster.Data.Id,
                Tags =
                {
                    ["key1"] = "value"
                }
            };
            var linkedService = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, linkedName, linkedData)).Value;
            Assert.IsNotNull(linkedService);
            Assert.AreEqual(linkedName, linkedService.Data.Name);

            //OperationalInsightsLinkedServiceCollection_Exist
            var exist = await _collection.ExistsAsync(linkedName);
            Assert.IsTrue(exist);

            //OperationalInsightsLinkedServiceCollection_Get
            var getResult = await _collection.GetAsync(linkedName);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.Name, linkedService.Data.Name);

            //OperationalInsightsLinkedServiceCollection_GetAll
            var linkedName2 = Recording.GenerateAssetName("OpLinkedService2nd");
            var linkedData2 = new OperationalInsightsLinkedServiceData();
            var linkedService2 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, linkedName2, linkedData2)).Value;
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == linkedService.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == linkedService2.Data.Name));
            await linkedService2.DeleteAsync(WaitUntil.Completed);

            //OperationalInsightsLinkedServiceCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(linkedName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(linkedService.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(linkedService.Data.Id, getIfExists.Data.Id);

            //OperationalInsightsLinkedServiceResource_CreateResourceIdentifier and Get
            var resourceId = OperationalInsightsLinkedServiceResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, workSpace.Data.Name, linkedService.Data.Name);
            var identifierResource = Client.GetOperationalInsightsLinkedServiceResource(resourceId);
            Assert.IsNotNull(identifierResource);
            Assert.AreEqual(identifierResource.Data.Name, linkedService.Data.Name);
            Assert.AreEqual(identifierResource.Data.Id, linkedService.Data.Id);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(linkedService.Data.Id, verify.Data.Id);
            Assert.AreEqual(linkedService.Data.Name, verify.Data.Name);

            //OperationalInsightsLinkedServiceResource_TagsOperation
            var addTag = (await linkedService.AddTagAsync("key2", "AddTags")).Value; //AddTags
            Assert.IsNotEmpty(addTag.Data.Tags);
            Assert.IsTrue(addTag.Data.Tags.ContainsKey("key2"));
            var setDic = new Dictionary<string, string>() //SetTags
            {
                ["key1"] = "OperationalInsightsLinkedServiceTest",
                ["key2"] = "TagOperation",
                ["key3"] = "SetTagsTest"
            };
            var setTag = (await linkedService.SetTagsAsync(setDic)).Value;
            Assert.AreEqual(setTag.Data.Tags["key1"], setDic["key1"]);
            Assert.IsTrue(setTag.Data.Tags["key2"] != "AddTags");
            string removeKey = "key3";
            var removeTag = await linkedService.RemoveTagAsync(removeKey); //RemoveTags
            Assert.IsFalse(removeTag.Value.Data.Tags.ContainsKey(removeKey));

            //OperationalInsightsLinkedServiceResource_Update
            var updateData = new OperationalInsightsLinkedServiceData()
            {
                Tags =
                {
                    ["key4"] = "updateTest",
                    ["key5"] = "testdata"
                }
            };
            var update = (await linkedService.UpdateAsync(WaitUntil.Completed, updateData)).Value;
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

            //OperationalInsightsLinkedServiceResource_Delete
            var delete = await linkedService.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(linkedName));
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        public async Task<OperationalInsightsClusterResource> Createcluster()
        {
            var clusterName = Recording.GenerateAssetName("InsightsCluster");
            var clusterData = new OperationalInsightsClusterData(_location)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Sku = new OperationalInsightsClusterSku()
                {
                    Capacity = OperationalInsightsClusterCapacity.TenHundred,
                    Name = OperationalInsightsClusterSkuName.CapacityReservation,
                },
                Tags =
                {
                    ["key1"] = "value"
                }
            };
            return (await _resourceGroup.GetOperationalInsightsClusters().CreateOrUpdateAsync(WaitUntil.Completed,clusterName,clusterData)).Value;
        }
    }
}
