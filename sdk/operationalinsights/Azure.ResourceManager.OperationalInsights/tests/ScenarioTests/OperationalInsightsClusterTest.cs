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
using Azure.ResourceManager.ManagedServiceIdentities;
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.OperationalInsights.Tests.ScenarioTests
{
    public class OperationalInsightsClusterTest: OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.WestCentralUS;
        public OperationalInsightsClusterTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task OperationalInsightsClusterTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsCluster-test", _location);
            var _collection = _resourceGroup.GetOperationalInsightsClusters();

            var managedIdentityName = Recording.GenerateAssetName("managedIdentity");
            var managedIdentityData = new UserAssignedIdentityData(_location);
            var managedIdentity = (await _resourceGroup.GetUserAssignedIdentities().CreateOrUpdateAsync(WaitUntil.Completed,managedIdentityName, managedIdentityData)).Value;

            //OperationalInsightsClusterCollection_Create
            var clusterName = Recording.GenerateAssetName("InsightsCluster");
            var clusterData = new OperationalInsightsClusterData(_location)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
                {
                    UserAssignedIdentities =
                    {
                        [managedIdentity.Data.Id] = new UserAssignedIdentity()
                    }
                },
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
            var cluster = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData)).Value;
            Assert.IsNotNull(cluster);
            Assert.AreEqual(clusterName,cluster.Data.Name);
            Assert.AreEqual(_location, cluster.Data.Location);

            //OperationalInsightsClusterCollection_Exist
            var exist = await _collection.ExistsAsync(clusterName);
            Assert.IsTrue(exist);

            //OperationalInsightsClusterCollection_Get
            var getResult = await _collection.GetAsync(clusterName);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.Name, cluster.Data.Name);

            //OperationalInsightsClusterCollection_GetAll
            var clusterName2 = Recording.GenerateAssetName("InsightsCluster2nd");
            var clusterData2 = new OperationalInsightsClusterData(_location) { };
            var cluster2 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName2, clusterData2)).Value;
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == cluster.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == cluster2.Data.Name));
            await cluster2.DeleteAsync(WaitUntil.Completed);

            //OperationalInsightsClusterCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(clusterName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(cluster.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(cluster.Data.Id, getIfExists.Data.Id);

            //OperationalInsightsClusterResource_CreateResourceIdentifier and Get
            var resourceId = OperationalInsightsClusterResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, cluster.Data.Name);
            var identifierResource = Client.GetLogAnalyticsQueryResource(resourceId);
            Assert.IsNotNull(identifierResource);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(cluster.Data.Id, verify.Data.Id);
            Assert.AreEqual(cluster.Data.Name, verify.Data.Name);

            //OperationalInsightsClusterResource_TagsOperation
            var addTag = (await cluster.AddTagAsync("key2", "AddTags")).Value; //AddTags
            Assert.IsNotEmpty(addTag.Data.Tags);
            Assert.IsTrue(addTag.Data.Tags.ContainsKey("key2"));
            var setDic = new Dictionary<string, string>() //SetTags
            {
                ["key1"] = "OperationalInsightsClusterTest",
                ["key2"] = "TagOperation",
                ["key3"] = "SetTagsTest"
            };
            var setTag = (await cluster.SetTagsAsync(setDic)).Value;
            Assert.AreEqual(setTag.Data.Tags["key1"], setDic["key1"]);
            Assert.IsTrue(setTag.Data.Tags["key2"] != "AddTags");
            string removeKey = "key3";
            var removeTag = await cluster.RemoveTagAsync(removeKey); //RemoveTags
            Assert.IsFalse(removeTag.Value.Data.Tags.ContainsKey(removeKey));

            //OperationalInsightsClusterResource_Update
            var updateData = new OperationalInsightsClusterPatch()
            {
                Tags =
                {
                    ["key4"] = "updateTest",
                    ["key5"] = "testdata"
                }
            };
            var update = (await cluster.UpdateAsync(WaitUntil.Completed,updateData)).Value;
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

            //OperationalInsightsClusterResource_Delete
            var delete = await cluster.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(clusterName));
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
