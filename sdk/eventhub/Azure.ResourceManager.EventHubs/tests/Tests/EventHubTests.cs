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
            Assert.That(eventHub, Is.Not.Null);
            Assert.That(eventhubName, Is.EqualTo(eventHub.Id.Name));

            //validate if created successfully
            Assert.That((bool)await _eventHubCollection.ExistsAsync(eventhubName), Is.True);
            eventHub = await _eventHubCollection.GetAsync(eventhubName);

            //delete eventhub
            await eventHub.DeleteAsync(WaitUntil.Completed);

            //validate
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _eventHubCollection.GetAsync(eventhubName); });
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await _eventHubCollection.ExistsAsync(eventhubName), Is.False);
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
            Assert.That(eventHub, Is.Not.Null);
            Assert.That(eventHubName, Is.EqualTo(eventHub.Id.Name));
            Assert.That(parameter.Status, Is.EqualTo(eventHub.Data.Status));
            Assert.That(parameter.PartitionCount, Is.EqualTo(eventHub.Data.PartitionCount));
            Assert.That(parameter.CaptureDescription.IntervalInSeconds, Is.EqualTo(eventHub.Data.CaptureDescription.IntervalInSeconds));
            Assert.That(parameter.CaptureDescription.SizeLimitInBytes, Is.EqualTo(eventHub.Data.CaptureDescription.SizeLimitInBytes));
            Assert.That(parameter.CaptureDescription.Destination.Name, Is.EqualTo(eventHub.Data.CaptureDescription.Destination.Name));
            Assert.That(parameter.CaptureDescription.Destination.BlobContainer, Is.EqualTo(eventHub.Data.CaptureDescription.Destination.BlobContainer));
            Assert.That(parameter.CaptureDescription.Destination.StorageAccountResourceId, Is.EqualTo(eventHub.Data.CaptureDescription.Destination.StorageAccountResourceId));
            Assert.That(parameter.CaptureDescription.Destination.ArchiveNameFormat, Is.EqualTo(eventHub.Data.CaptureDescription.Destination.ArchiveNameFormat));

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
            Assert.That(eventHub1, Is.Not.Null);
            Assert.That(eventHubName1, Is.EqualTo(eventHub1.Id.Name));
            Assert.That(parameter1.Status, Is.EqualTo(eventHub1.Data.Status));
            Assert.That(parameter1.PartitionCount, Is.EqualTo(eventHub1.Data.PartitionCount));
            Assert.That(parameter1.RetentionDescription.CleanupPolicy, Is.EqualTo(eventHub1.Data.RetentionDescription.CleanupPolicy));
            Assert.That(parameter1.RetentionDescription.RetentionTimeInHours, Is.EqualTo(eventHub1.Data.RetentionDescription.RetentionTimeInHours));

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
            Assert.That(eventHub2, Is.Not.Null);
            Assert.That(eventHubName2, Is.EqualTo(eventHub2.Id.Name));
            Assert.That(parameter2.Status, Is.EqualTo(eventHub2.Data.Status));
            Assert.That(parameter2.PartitionCount, Is.EqualTo(eventHub2.Data.PartitionCount));
            Assert.That(parameter2.RetentionDescription.CleanupPolicy, Is.EqualTo(eventHub2.Data.RetentionDescription.CleanupPolicy));
            Assert.That(eventHub2.Data.RetentionDescription.RetentionTimeInHours, Is.EqualTo(-1));
            Assert.That(parameter2.RetentionDescription.TombstoneRetentionTimeInHours, Is.EqualTo(eventHub2.Data.RetentionDescription.TombstoneRetentionTimeInHours));

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
            Assert.That(count, Is.EqualTo(2));
            Assert.That(eventHub1, Is.Not.Null);
            Assert.That(eventHub2, Is.Not.Null);
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
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.That(ruleName, Is.EqualTo(authorizationRule.Id.Name));
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //get all authorization rules
            List<EventHubAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.That(rules.Count, Is.EqualTo(1));
            bool isContainAuthorizationRuleName = false;
            foreach (EventHubAuthorizationRuleResource rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.That(isContainAuthorizationRuleName, Is.True);

            //update authorization rule
            parameter.Rights.Add(EventHubsAccessRight.Manage);
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //delete authorization rule
            await authorizationRule.DeleteAsync(WaitUntil.Completed);

            //validate if deleted
            Assert.That((bool)await ruleCollection.ExistsAsync(ruleName), Is.False);
            rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(rules.Count, Is.EqualTo(0));
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
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            EventHubsAccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.That(keys1, Is.Not.Null);
            Assert.That(keys1.PrimaryConnectionString, Is.Not.Null);
            Assert.That(keys1.SecondaryConnectionString, Is.Not.Null);

            EventHubsAccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(KeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys2.PrimaryKey, Is.Not.EqualTo(keys1.PrimaryKey));
                Assert.That(keys2.SecondaryKey, Is.EqualTo(keys1.SecondaryKey));
            }

            EventHubsAccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(KeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys3.PrimaryKey, Is.EqualTo(keys2.PrimaryKey));
                Assert.That(keys3.SecondaryKey, Is.Not.EqualTo(keys2.SecondaryKey));
            }

            var updatePrimaryKey = GenerateRandomKey();
            EventHubsAccessKeys currentKeys = keys3;

            EventHubsAccessKeys keys4 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.PrimaryKey)
            {
                Key = updatePrimaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys4.PrimaryKey, Is.EqualTo(updatePrimaryKey));
                Assert.That(keys4.SecondaryKey, Is.EqualTo(currentKeys.SecondaryKey));
            }

            currentKeys = keys4;
            var updateSecondaryKey = GenerateRandomKey();
            EventHubsAccessKeys keys5 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys5.SecondaryKey, Is.EqualTo(updateSecondaryKey));
                Assert.That(keys5.PrimaryKey, Is.EqualTo(currentKeys.PrimaryKey));
            }
        }
    }
}
