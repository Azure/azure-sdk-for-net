// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using KeyType = Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class EventhubTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventHubCollection _eventHubCollection;
        public EventhubTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation)
            {
                Sku = new EventHubsSku("Premium")
                {
                    Name = "Premium"
                }
            })).Value;
            _eventHubCollection = eventHubNamespace.GetEventHubs();
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteEventHub()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            EventHubResource eventHub = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;
            Assert.NotNull(eventHub);
            Assert.AreEqual(eventHub.Id.Name, eventhubName);

            //validate if created successfully
            Assert.IsTrue(await _eventHubCollection.ExistsAsync(eventhubName));
            eventHub = await _eventHubCollection.GetAsync(eventhubName);

            //delete eventhub
            await eventHub.DeleteAsync(WaitUntil.Completed);

            //validate
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _eventHubCollection.GetAsync(eventhubName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _eventHubCollection.ExistsAsync(eventhubName));
        }

        [Test]
        [RecordedTest]
        public async Task CreateEventhubWithParameter()
        {
            //prepare a storage account
            string accountName = Recording.GenerateAssetName("eventhubstorage");

            GenericResourceData input = new GenericResourceData(AzureLocation.EastUS2)
            {
                Sku = new ResourcesSku
                {
                    Name = "Standard_LRS"
                },
                Kind = "StorageV2",
                Properties = BinaryData.FromObjectAsJson(new JsonObject()
                {
                    {"accessTier", "Hot"}
                })
            };
            ResourceIdentifier storageAccountId = _resourceGroup.Id.AppendProviderResource("Microsoft.Storage", "storageAccounts", accountName);
            GenericResource account = (await Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountId, input)).Value;

            //create eventhub with Cleanup policy Compaction.
            string eventHubName = Recording.GenerateAssetName("eventhub");
            EventHubData parameter = new EventHubData()
            {
                PartitionCount = 4,
                Status = EventHubEntityStatus.Active,
                CaptureDescription = new CaptureDescription()
                {
                    Enabled = true,
                    Encoding = EncodingCaptureDescription.Avro,
                    IntervalInSeconds = 120,
                    SizeLimitInBytes = 10485763,
                    Destination = new EventHubDestination()
                    {
                        Name = "EventHubArchive.AzureBlockBlob",
                        BlobContainer = "container",
                        ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
                        StorageAccountResourceId = new ResourceIdentifier(account.Id.ToString())
                    }
                },
            };
            EventHubResource eventHub = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventHubName, parameter)).Value;

            //validate
            Assert.NotNull(eventHub);
            Assert.AreEqual(eventHub.Id.Name, eventHubName);
            Assert.AreEqual(eventHub.Data.Status, parameter.Status);
            Assert.AreEqual(eventHub.Data.PartitionCount, parameter.PartitionCount);
            Assert.AreEqual(eventHub.Data.CaptureDescription.IntervalInSeconds, parameter.CaptureDescription.IntervalInSeconds);
            Assert.AreEqual(eventHub.Data.CaptureDescription.SizeLimitInBytes, parameter.CaptureDescription.SizeLimitInBytes);
            Assert.AreEqual(eventHub.Data.CaptureDescription.Destination.Name, parameter.CaptureDescription.Destination.Name);
            Assert.AreEqual(eventHub.Data.CaptureDescription.Destination.BlobContainer, parameter.CaptureDescription.Destination.BlobContainer);
            Assert.AreEqual(eventHub.Data.CaptureDescription.Destination.StorageAccountResourceId, parameter.CaptureDescription.Destination.StorageAccountResourceId);
            Assert.AreEqual(eventHub.Data.CaptureDescription.Destination.ArchiveNameFormat, parameter.CaptureDescription.Destination.ArchiveNameFormat);

            //EventHub with Delete Cleanup Policy.
            string eventHubName1 = Recording.GenerateAssetName("eventhub");
            EventHubData parameter1 = new EventHubData()
            {
                PartitionCount = 2,
                Status = EventHubEntityStatus.Active,
                RetentionDescription = new RetentionDescription()
                {
                    CleanupPolicy = "Delete",
                    RetentionTimeInHours = 2
                }
            };
            EventHubResource eventHub1 = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventHubName1, parameter1)).Value;

            //validate
            Assert.NotNull(eventHub1);
            Assert.AreEqual(eventHub1.Id.Name, eventHubName1);
            Assert.AreEqual(eventHub1.Data.Status, parameter1.Status);
            Assert.AreEqual(eventHub1.Data.PartitionCount, parameter1.PartitionCount);
            Assert.AreEqual(eventHub1.Data.RetentionDescription.CleanupPolicy, parameter1.RetentionDescription.CleanupPolicy);
            Assert.AreEqual(eventHub1.Data.RetentionDescription.RetentionTimeInHours, parameter1.RetentionDescription.RetentionTimeInHours);

            //EventHub with Compact Cleanup Policy.
            string eventHubName2 = Recording.GenerateAssetName("eventhub");
            EventHubData parameter2 = new EventHubData()
            {
                PartitionCount = 2,
                Status = EventHubEntityStatus.Active,
                RetentionDescription = new RetentionDescription()
                {
                    CleanupPolicy = "Compact",
                    RetentionTimeInHours = 2,
                    TombstoneRetentionTimeInHours=4
                }
            };
            EventHubResource eventHub2 = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventHubName2, parameter2)).Value;

            //validate
            Assert.NotNull(eventHub2);
            Assert.AreEqual(eventHub2.Id.Name, eventHubName2);
            Assert.AreEqual(eventHub2.Data.Status, parameter2.Status);
            Assert.AreEqual(eventHub2.Data.PartitionCount, parameter2.PartitionCount);
            Assert.AreEqual(eventHub2.Data.RetentionDescription.CleanupPolicy, parameter2.RetentionDescription.CleanupPolicy);
            Assert.AreEqual(eventHub2.Data.RetentionDescription.RetentionTimeInHours, parameter2.RetentionDescription.RetentionTimeInHours);
            Assert.AreEqual(eventHub2.Data.RetentionDescription.TombstoneRetentionTimeInHours, parameter2.RetentionDescription.TombstoneRetentionTimeInHours);

            //Delete eventhub
            await eventHub1.DeleteAsync(WaitUntil.Completed);
            await eventHub.DeleteAsync(WaitUntil.Completed);
            await eventHub2.DeleteAsync(WaitUntil.Completed);
            await account.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllEventhubs()
        {
            //create two eventhubs
            string eventhubName1 = Recording.GenerateAssetName("eventhub1");
            string eventhubName2 = Recording.GenerateAssetName("eventhub2");
            _ = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName1, new EventHubData())).Value;
            _ = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName2, new EventHubData())).Value;

            //validate
            int count = 0;
            EventHubResource eventHub1 = null;
            EventHubResource eventHub2 = null;
            await foreach (EventHubResource eventHub in _eventHubCollection.GetAllAsync())
            {
                count++;
                if (eventHub.Id.Name == eventhubName1)
                    eventHub1 = eventHub;
                if (eventHub.Id.Name == eventhubName2)
                    eventHub2 = eventHub;
            }
            Assert.AreEqual(count, 2);
            Assert.NotNull(eventHub1);
            Assert.NotNull(eventHub2);
        }

        [Test]
        [RecordedTest]
        public async Task EventhubCreateGetUpdateDeleteAuthorizationRule()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            EventHubResource eventHub = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;

            //create an authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            EventHubAuthorizationRuleCollection ruleCollection = eventHub.GetEventHubAuthorizationRules();
            EventHubsAuthorizationRuleData parameter = new EventHubsAuthorizationRuleData()
            {
                Rights = { EventHubsAccessRight.Listen, EventHubsAccessRight.Send }
            };
            EventHubAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<EventHubAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (EventHubAuthorizationRuleResource rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.True(isContainAuthorizationRuleName);

            //update authorization rule
            parameter.Rights.Add(EventHubsAccessRight.Manage);
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync(WaitUntil.Completed);

            //validate if deleted
            Assert.IsFalse(await ruleCollection.ExistsAsync(ruleName));
            rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.True(rules.Count == 0);
        }

        [Test]
        [RecordedTest]
        public async Task EventhubAuthorizationRuleRegenerateKey()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            EventHubResource eventHub = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;
            EventHubAuthorizationRuleCollection ruleCollection = eventHub.GetEventHubAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            EventHubsAuthorizationRuleData parameter = new EventHubsAuthorizationRuleData()
            {
                Rights = { EventHubsAccessRight.Listen, EventHubsAccessRight.Send }
            };
            EventHubAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            EventHubsAccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            EventHubsAccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(KeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            EventHubsAccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(KeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }

            var updatePrimaryKey = GenerateRandomKey();
            EventHubsAccessKeys currentKeys = keys3;

            EventHubsAccessKeys keys4 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.PrimaryKey)
            {
                Key = updatePrimaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updatePrimaryKey, keys4.PrimaryKey);
                Assert.AreEqual(currentKeys.SecondaryKey, keys4.SecondaryKey);
            }

            currentKeys = keys4;
            var updateSecondaryKey = GenerateRandomKey();
            EventHubsAccessKeys keys5 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updateSecondaryKey, keys5.SecondaryKey);
                Assert.AreEqual(currentKeys.PrimaryKey, keys5.PrimaryKey);
            }
        }
    }
}
