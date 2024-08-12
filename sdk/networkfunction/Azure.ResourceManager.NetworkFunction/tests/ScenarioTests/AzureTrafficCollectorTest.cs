// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkFunction;
using Azure.ResourceManager.NetworkFunction.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkFunction.Tests
{
    public class AzureTrafficCollectorTest : NetworkFunctionManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.WestUS;
        private AzureTrafficCollectorCollection _collection;
        public AzureTrafficCollectorTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        { }

        [SetUp]
        public async Task SetUp()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "AzureTraffic-test", _location);
            _collection = _resourceGroup.GetAzureTrafficCollectors();
        }

        [Test]
        public async Task AzureTrafficCollectorCollection_Create()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            Assert.IsNotNull(azureTrafficCollectorResource);
            Assert.AreEqual(_location, azureTrafficCollectorResource.Data.Location);
            Assert.AreEqual(accountName, azureTrafficCollectorResource.Data.Name);
        }

        [Test]
        public async Task AzureTrafficCollectorCollection_Exist()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            var exist  = await _collection.ExistsAsync(azureTrafficCollectorResource.Data.Name);
            Assert.IsNotNull(exist);
            Assert.IsTrue(exist.Value);
        }

        [Test]
        public async Task AzureTrafficCollectorCollection_Get()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            AzureTrafficCollectorResource result = await _collection.GetAsync(azureTrafficCollectorResource.Data.Name);
            Assert.IsNotEmpty(result.Data.Id);
            Assert.AreEqual(result.Data.Name, azureTrafficCollectorResource.Data.Name);
        }

        [Test]
        public async Task AzureTrafficCollectorCollection_GetAll()
        {
            var accountName1 = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource1 = await CreateAzureTrafficCollector(accountName1);
            var accountName2 = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource2 = await CreateAzureTrafficCollector(accountName2);
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count >= 2);
            Assert.IsTrue(list.Exists(item => item.Data.Name == azureTrafficCollectorResource1.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == azureTrafficCollectorResource2.Data.Name));
        }

        [Test]
        public async Task AzureTrafficCollectorResource_CreateResourceIdentifier()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            var resourceId = AzureTrafficCollectorResource.CreateResourceIdentifier(_subscription.Id.SubscriptionId,_resourceGroup.Data.Name,accountName);
            var azureTrafficCollectorAccount = Client.GetAzureTrafficCollectorResource(resourceId);
            AzureTrafficCollectorResource result =await azureTrafficCollectorAccount.GetAsync();
            Assert.IsNotEmpty(result.Data.Id);
            Assert.AreEqual(result.Data.Id, azureTrafficCollectorResource.Data.Id);
            Assert.AreEqual(result.Data.Name, azureTrafficCollectorResource.Data.Name);
        }

        [Test]
        public async Task AzureTrafficCollectorResource_Get()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            AzureTrafficCollectorResource getResult = await azureTrafficCollectorResource.GetAsync();
            Assert.IsNotEmpty(getResult.Data.Id);
            Assert.AreEqual(accountName, getResult.Data.Name);
        }

        [Test]
        public async Task AzureTrafficCollectorResource_Update()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            var data = new TagsObject()
            {
                Tags =
                {
                    ["key1"] = "azureTrafficCollector",
                    ["key2"] = "updateTest"
                }
            };
            AzureTrafficCollectorResource result = await azureTrafficCollectorResource.UpdateAsync(data);
            Assert.IsNotEmpty(result.Data.Tags);
            Assert.AreEqual(result.Data.Tags, data.Tags);
        }

        [Test]
        public async Task AzureTrafficCollectorResource_GetCollectorPolicy()
        {
            var azureTrafficName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(azureTrafficName);
            var expressRouteName = Recording.GenerateAssetName("expressRouteCircuit");
            string ingestionResourceId = $"/subscriptions/{_subscription.Data.SubscriptionId}/resourceGroups/{_resourceGroup.Data.Name}/providers/Microsoft.NetworkFunction/expressRouteCircuits/{expressRouteName}";
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollectorResource,collectorPolicyName, ingestionResourceId);
            CollectorPolicyResource getPolicy = await azureTrafficCollectorResource.GetCollectorPolicyAsync(collectorPolicy.Data.Name);
            Assert.IsNotEmpty(getPolicy.Data.Id);
            Assert.AreEqual(collectorPolicy.Data.Id,getPolicy.Data.Id);
            Assert.AreEqual(collectorPolicyName, collectorPolicy.Data.Name);
            Assert.AreEqual(collectorPolicy.Data.Name, getPolicy.Data.Name);
        }

        [Test]
        public async Task AzureTrafficCollectorResource_TagOperation()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            AzureTrafficCollectorResource addTags = await azureTrafficCollectorResource.AddTagAsync("key2","AddTags");
            Assert.IsTrue(addTags.Data.Tags.ContainsKey("key2"));
            var SetDic = new Dictionary<string, string>()
            {
                ["key1"] = "azureTrafficCollector",
                ["key2"] = "TagsOperate",
                ["key3"] = "SetTags"
            };
            AzureTrafficCollectorResource setTags = await azureTrafficCollectorResource.SetTagsAsync(SetDic);
            Assert.AreEqual(SetDic["key1"], setTags.Data.Tags["key1"]);
            Assert.IsTrue(setTags.Data.Tags["key1"] != "value1");
            Assert.IsTrue(setTags.Data.Tags["key2"] != "AddTags");
            string removekey = "key3";
            AzureTrafficCollectorResource removeTags = await azureTrafficCollectorResource.RemoveTagAsync(removekey);
            Assert.IsNotEmpty(removeTags.Data.Tags);
            Assert.IsTrue(!removeTags.Data.Tags.ContainsKey(removekey));
        }

        [Test]
        public async Task AzureTrafficCollectorResource_Delete()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            var deleted = await azureTrafficCollectorResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleted.HasCompleted);
            var exist = await _collection.ExistsAsync(accountName);
            Assert.IsFalse(exist.Value);
        }

        public async Task<AzureTrafficCollectorResource> CreateAzureTrafficCollector(string accountname)
        {
            var data = new AzureTrafficCollectorData(_location)
            {
                Tags =
                {
                    ["key1"]= "value"
                },
            };
            return (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, accountname, data)).Value;
        }

        public async Task<CollectorPolicyResource> CreateCollectorPolicy(AzureTrafficCollectorResource resource,string collectorPolicyName,string resourceId)
        {
            var collection = resource.GetCollectorPolicies();
            var data = new CollectorPolicyData(_location)
            {
                IngestionPolicy = new IngestionPolicyPropertiesFormat()
                {
                    IngestionType = IngestionType.Ipfix,
                    IngestionSources =
                    {
                        new IngestionSourcesPropertiesFormat()
                        {
                            SourceType = IngestionSourceType.Resource,
                            ResourceId = resourceId
                        }
                    }
                },
                EmissionPolicies =
                {
                    new EmissionPoliciesPropertiesFormat()
                    {
                        EmissionType = EmissionType.Ipfix,
                        EmissionDestinations =
                        {
                            new EmissionPolicyDestination()
                            {
                                DestinationType = EmissionDestinationType.AzureMonitor
                            }
                        }
                    }
                }
            };
            return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, collectorPolicyName, data)).Value;
        }
    }
}
