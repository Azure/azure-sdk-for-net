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
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkFunction.Tests
{
    public class CollectorPolicyTest : NetworkFunctionManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.WestUS;
        private AzureTrafficCollectorCollection _collection;
        public CollectorPolicyTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        { }

        [SetUp]
        public async Task SetUp()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "CollectorPolicy-test", _location);
            _collection = _resourceGroup.GetAzureTrafficCollectors();
        }

        [Test]
        public async Task CollectorPolicyCollection_Create()
        {
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector = await CreateAzureTrafficCollector();
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollector, collectorPolicyName);
            Assert.That(collectorPolicy, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(collectorPolicy.Data.Name, Is.EqualTo(collectorPolicyName));
                Assert.That(collectorPolicy.Data.Location, Is.EqualTo(_location));
            });
        }

        [Test]
        public async Task CollectorPolicyCollection_Exist()
        {
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector = await CreateAzureTrafficCollector();
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollector, collectorPolicyName);
            var collection = azureTrafficCollector.GetCollectorPolicies();
            var exist = await collection.ExistsAsync(collectorPolicy.Data.Name);
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.Not.Null);
                Assert.That((bool)exist, Is.True);
            });
        }

        [Test]
        public async Task CollectorPolicyCollection_Get()
        {
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector = await CreateAzureTrafficCollector();
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollector, collectorPolicyName);
            var collection = azureTrafficCollector.GetCollectorPolicies();
            CollectorPolicyResource result = await collection.GetAsync(collectorPolicy.Data.Name);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(collectorPolicy.Data.Name, Is.EqualTo(result.Data.Name));
            });
        }

        [Test]
        public async Task CollectorPolicyCollection_GetAll()
        {
            var collectorPolicyName1 = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector1 = await CreateAzureTrafficCollector();
            var collectorPolicy1 = await CreateCollectorPolicy(azureTrafficCollector1, collectorPolicyName1);
            var collectorPolicyName2 = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector2 = await CreateAzureTrafficCollector();
            var collectorPolicy2 = await CreateCollectorPolicy(azureTrafficCollector2, collectorPolicyName2);
            var collection = azureTrafficCollector1.GetCollectorPolicies();
            var collection2 = azureTrafficCollector2.GetCollectorPolicies();
            var list1 = await collection.GetAllAsync().ToEnumerableAsync();
            var list2 = await collection2.GetAllAsync().ToEnumerableAsync();
            var listre = list1.Concat(list2).ToList();
            Assert.That(listre, Is.Not.Empty);
            Assert.That(listre, Has.Count.GreaterThanOrEqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(listre.Exists(item => item.Data.Name == collectorPolicy1.Data.Name), Is.True);
                Assert.That(listre.Exists(item => item.Data.Name == collectorPolicy2.Data.Name), Is.True);
            });
        }

        [Test]
        public async Task CollectorPolicyResource_CreateResourceIdentifier()
        {
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector = await CreateAzureTrafficCollector();
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollector, collectorPolicyName);
            var collectorPolicyresourceId = CollectorPolicyResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, azureTrafficCollector.Data.Name, collectorPolicy.Data.Name);
            var collectorPolicyAccount = Client.GetCollectorPolicyResource(collectorPolicyresourceId);
            CollectorPolicyResource result = await collectorPolicyAccount.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(collectorPolicy.Data.Id, Is.EqualTo(result.Data.Id));
                Assert.That(collectorPolicy.Data.Name, Is.EqualTo(result.Data.Name));
            });
        }

        [Test]
        public async Task CollectorPolicyResource_Get()
        {
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector = await CreateAzureTrafficCollector();
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollector, collectorPolicyName);
            CollectorPolicyResource getResult = await collectorPolicy.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That((string)getResult.Data.Id, Is.Not.Empty);
                Assert.That(collectorPolicy.Data.Name, Is.EqualTo(collectorPolicyName));
            });
        }

        [Test]
        [Ignore("Only verifying that the testcase builds")]
        public async Task CollectorPolicyResource_Update()
        {
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector = await CreateAzureTrafficCollector();
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollector, collectorPolicyName);
            var tagsObject = new TagsObject()
            {
                Tags =
                {
                    ["key1"] = "collectorPolicy",
                    ["key2"] = "updateTest"
                }
            };
            CollectorPolicyResource result = await collectorPolicy.UpdateAsync(tagsObject);
            Assert.That(result.Data.Tags, Is.Not.Empty);
            Assert.That(result.Data.Tags, Is.EqualTo(tagsObject.Tags));
        }

        [Test]
        [Ignore("Only verifying that the testcase builds")]
        public async Task CollectorPolicyResource_TagOperation()
        {
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector = await CreateAzureTrafficCollector();
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollector, collectorPolicyName);
            CollectorPolicyResource addTags = await collectorPolicy.AddTagAsync("key1", "AddTags");
            Assert.That(addTags.Data.Tags.ContainsKey("key1"), Is.True);
            var SetDic = new Dictionary<string, string>()
            {
                ["key1"] = "collectorPolicy",
                ["key2"] = "TagsOperate",
                ["key3"] = "SetTags"
            };
            CollectorPolicyResource setTags = await collectorPolicy.SetTagsAsync(SetDic);
            Assert.That(setTags.Data.Tags["key1"], Is.EqualTo(SetDic["key1"]));
            Assert.That(setTags.Data.Tags["key1"], Is.Not.EqualTo("AddTags"));
            string removekey = "key3";
            CollectorPolicyResource removeTags = await collectorPolicy.RemoveTagAsync(removekey);
            Assert.Multiple(() =>
            {
                Assert.That(removeTags.Data.Tags, Is.Not.Empty);
                Assert.That(!removeTags.Data.Tags.ContainsKey(removekey), Is.True);
            });
        }

        [Test]
        public async Task CollectorPolicyResource_Delete()
        {
            var collectorPolicyName = Recording.GenerateAssetName("collectorPolicy");
            var azureTrafficCollector = await CreateAzureTrafficCollector();
            var collectorPolicy = await CreateCollectorPolicy(azureTrafficCollector, collectorPolicyName);
            var deleted = await collectorPolicy.DeleteAsync(WaitUntil.Completed);
            Assert.That(deleted.HasCompleted, Is.True);
            var exist = await _collection.ExistsAsync(collectorPolicyName);
            Assert.That(exist.Value, Is.False);
        }

        public async Task<AzureTrafficCollectorResource> CreateAzureTrafficCollector()
        {
            var azureTrafficCollectorName = Recording.GenerateAssetName("azureTrafficCollector");
            var data = new AzureTrafficCollectorData(_location)
            {
                Tags =
                {
                    ["key1"] = "value1"
                }
            };
            return (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, azureTrafficCollectorName, data)).Value;
        }

        public async Task<CollectorPolicyResource> CreateCollectorPolicy(AzureTrafficCollectorResource azureTrafficCollectorResource, string collectorPolicyName)
        {
            var collection = azureTrafficCollectorResource.GetCollectorPolicies();
            var data = new CollectorPolicyData(_location)
            {
                Tags =
                {
                    ["key1"] = "value1"
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
        public async Task<ExpressRouteCircuitResource> CreateDefaultExpressRouteCircuit(string circuitName)
        {
            var sku = new ExpressRouteCircuitSku
            {
                Name = "Premium_MeteredData",
                Tier = "Premium",
                Family = "MeteredData"
            };

            var provider = new ExpressRouteCircuitServiceProviderProperties
            {
                BandwidthInMbps = 200,
                PeeringLocation = _location,
                ServiceProviderName = "bvtazureixp01"
            };

            var circuit = new ExpressRouteCircuitData()
            {
                Location = _location,
                Tags = { { "key", "value" } },
                Sku = sku,
                ServiceProviderProperties = provider
            };
            var circuitCollection = _resourceGroup.GetExpressRouteCircuits();
            return (await circuitCollection.CreateOrUpdateAsync(WaitUntil.Completed, circuitName, circuit)).Value;
        }
    }
}
