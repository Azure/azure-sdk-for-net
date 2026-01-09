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
            Assert.That(azureTrafficCollectorResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(azureTrafficCollectorResource.Data.Location, Is.EqualTo(_location));
                Assert.That(azureTrafficCollectorResource.Data.Name, Is.EqualTo(accountName));
            });
        }

        [Test]
        public async Task AzureTrafficCollectorCollection_Exist()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            var exist  = await _collection.ExistsAsync(azureTrafficCollectorResource.Data.Name);
            Assert.That(exist, Is.Not.Null);
            Assert.That(exist.Value, Is.True);
        }

        [Test]
        public async Task AzureTrafficCollectorCollection_Get()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            AzureTrafficCollectorResource result = await _collection.GetAsync(azureTrafficCollectorResource.Data.Name);
            Assert.Multiple(() =>
            {
                Assert.That((string)result.Data.Id, Is.Not.Empty);
                Assert.That(azureTrafficCollectorResource.Data.Name, Is.EqualTo(result.Data.Name));
            });
        }

        [Test]
        public async Task AzureTrafficCollectorCollection_GetAll()
        {
            var accountName1 = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource1 = await CreateAzureTrafficCollector(accountName1);
            var accountName2 = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource2 = await CreateAzureTrafficCollector(accountName2);
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Has.Count.GreaterThanOrEqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(list.Exists(item => item.Data.Name == azureTrafficCollectorResource1.Data.Name), Is.True);
                Assert.That(list.Exists(item => item.Data.Name == azureTrafficCollectorResource2.Data.Name), Is.True);
            });
        }

        [Test]
        public async Task AzureTrafficCollectorResource_CreateResourceIdentifier()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            var resourceId = AzureTrafficCollectorResource.CreateResourceIdentifier(_subscription.Id.SubscriptionId,_resourceGroup.Data.Name,accountName);
            var azureTrafficCollectorAccount = Client.GetAzureTrafficCollectorResource(resourceId);
            AzureTrafficCollectorResource result =await azureTrafficCollectorAccount.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That((string)result.Data.Id, Is.Not.Empty);
                Assert.That(azureTrafficCollectorResource.Data.Id, Is.EqualTo(result.Data.Id));
                Assert.That(azureTrafficCollectorResource.Data.Name, Is.EqualTo(result.Data.Name));
            });
        }

        [Test]
        public async Task AzureTrafficCollectorResource_Get()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            AzureTrafficCollectorResource getResult = await azureTrafficCollectorResource.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That((string)getResult.Data.Id, Is.Not.Empty);
                Assert.That(getResult.Data.Name, Is.EqualTo(accountName));
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(result.Data.Tags, Is.Not.Empty);
                Assert.That(data.Tags, Is.EqualTo(result.Data.Tags));
            });
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
            Assert.Multiple(() =>
            {
                Assert.That((string)getPolicy.Data.Id, Is.Not.Empty);
                Assert.That(getPolicy.Data.Id, Is.EqualTo(collectorPolicy.Data.Id));
                Assert.That(collectorPolicy.Data.Name, Is.EqualTo(collectorPolicyName));
                Assert.That(getPolicy.Data.Name, Is.EqualTo(collectorPolicy.Data.Name));
            });
        }

        [Test]
        public async Task AzureTrafficCollectorResource_TagOperation()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            AzureTrafficCollectorResource addTags = await azureTrafficCollectorResource.AddTagAsync("key2","AddTags");
            Assert.That(addTags.Data.Tags.ContainsKey("key2"), Is.True);
            var SetDic = new Dictionary<string, string>()
            {
                ["key1"] = "azureTrafficCollector",
                ["key2"] = "TagsOperate",
                ["key3"] = "SetTags"
            };
            AzureTrafficCollectorResource setTags = await azureTrafficCollectorResource.SetTagsAsync(SetDic);
            Assert.That(setTags.Data.Tags["key1"], Is.EqualTo(SetDic["key1"]));
            Assert.Multiple(() =>
            {
                Assert.That(setTags.Data.Tags["key1"], Is.Not.EqualTo("value1"));
                Assert.That(setTags.Data.Tags["key2"], Is.Not.EqualTo("AddTags"));
            });
            string removekey = "key3";
            AzureTrafficCollectorResource removeTags = await azureTrafficCollectorResource.RemoveTagAsync(removekey);
            Assert.Multiple(() =>
            {
                Assert.That(removeTags.Data.Tags, Is.Not.Empty);
                Assert.That(!removeTags.Data.Tags.ContainsKey(removekey), Is.True);
            });
        }

        [Test]
        public async Task AzureTrafficCollectorResource_Delete()
        {
            var accountName = Recording.GenerateAssetName("azureTrafficCollector");
            var azureTrafficCollectorResource = await CreateAzureTrafficCollector(accountName);
            var deleted = await azureTrafficCollectorResource.DeleteAsync(WaitUntil.Completed);
            Assert.That(deleted.HasCompleted, Is.True);
            var exist = await _collection.ExistsAsync(accountName);
            Assert.That(exist.Value, Is.False);
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
