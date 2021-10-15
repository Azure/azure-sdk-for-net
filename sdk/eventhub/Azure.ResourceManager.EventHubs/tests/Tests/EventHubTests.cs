// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.EventHubs.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using KeyType = Azure.ResourceManager.EventHubs.Models.KeyType;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class EventhubTests : EventHubTestBase
    {
        private ResourceGroup _resourceGroup;
        private EventhubContainer _eventhubContainer;
        public EventhubTests(bool isAsync) : base(isAsync)
        {
        }
        [SetUp]
        public async Task CreateNamespaceAndGetEventhubContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            _eventhubContainer = eHNamespace.GetEventhubs();
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
                List<EHNamespace> namespaceList = await namespaceContainer.GetAllAsync().ToEnumerableAsync();
                foreach (EHNamespace eHNamespace in namespaceList)
                {
                    await eHNamespace.DeleteAsync();
                }
                _resourceGroup = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteEventHub()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            Eventhub eventhub = (await _eventhubContainer.CreateOrUpdateAsync(eventhubName, new EventhubData())).Value;
            Assert.NotNull(eventhub);
            Assert.AreEqual(eventhub.Id.Name, eventhubName);

            //validate if created successfully
            eventhub = await _eventhubContainer.GetIfExistsAsync(eventhubName);
            Assert.NotNull(eventhub);
            Assert.IsTrue(await _eventhubContainer.CheckIfExistsAsync(eventhubName));

            //delete eventhub
            await eventhub.DeleteAsync();

            //validate
            eventhub = await _eventhubContainer.GetIfExistsAsync(eventhubName);
            Assert.Null(eventhub);
            Assert.IsFalse(await _eventhubContainer.CheckIfExistsAsync(eventhubName));
        }

        [Test]
        [RecordedTest]
        public async Task CreateEventhubWithParameter()
        {
            //prepare a storage account
            string accountName = Recording.GenerateAssetName("storage");
            Storage.Models.Sku sku = new Storage.Models.Sku("Standard_LRS");
            var storageAccountCreateParameters = new StorageAccountCreateParameters(sku, Kind.StorageV2, "eastus2")
            {
                AccessTier = AccessTier.Hot
            };
            StorageAccount account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(accountName, storageAccountCreateParameters)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }

            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            EventhubData parameter = new EventhubData()
            {
                MessageRetentionInDays = 4,
                PartitionCount = 4,
                Status = EntityStatus.Active,
                CaptureDescription = new CaptureDescription()
                {
                    Enabled = true,
                    Encoding = EncodingCaptureDescription.Avro,
                    IntervalInSeconds = 120,
                    SizeLimitInBytes = 10485763,
                    Destination = new Destination()
                    {
                        Name = "EventHubArchive.AzureBlockBlob",
                        BlobContainer = "container",
                        ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
                        StorageAccountResourceId = account.Id.ToString()
                    }
                }
            };
            Eventhub eventhub = (await _eventhubContainer.CreateOrUpdateAsync(eventhubName, parameter)).Value;

            //validate
            Assert.NotNull(eventhub);
            Assert.AreEqual(eventhub.Id.Name, eventhubName);
            Assert.AreEqual(eventhub.Data.Status, parameter.Status);
            Assert.AreEqual(eventhub.Data.MessageRetentionInDays, parameter.MessageRetentionInDays);
            Assert.AreEqual(eventhub.Data.PartitionCount, parameter.PartitionCount);
            Assert.AreEqual(eventhub.Data.CaptureDescription.IntervalInSeconds, parameter.CaptureDescription.IntervalInSeconds);
            Assert.AreEqual(eventhub.Data.CaptureDescription.SizeLimitInBytes, parameter.CaptureDescription.SizeLimitInBytes);
            Assert.AreEqual(eventhub.Data.CaptureDescription.Destination.Name, parameter.CaptureDescription.Destination.Name);
            Assert.AreEqual(eventhub.Data.CaptureDescription.Destination.BlobContainer, parameter.CaptureDescription.Destination.BlobContainer);
            Assert.AreEqual(eventhub.Data.CaptureDescription.Destination.StorageAccountResourceId, parameter.CaptureDescription.Destination.StorageAccountResourceId);
            Assert.AreEqual(eventhub.Data.CaptureDescription.Destination.ArchiveNameFormat, parameter.CaptureDescription.Destination.ArchiveNameFormat);

            await account.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task GetAllEventhubs()
        {
            //create two eventhubs
            string eventhubName1 = Recording.GenerateAssetName("eventhub1");
            string eventhubName2 = Recording.GenerateAssetName("eventhub2");
            _ = (await _eventhubContainer.CreateOrUpdateAsync(eventhubName1, new EventhubData())).Value;
            _ = (await _eventhubContainer.CreateOrUpdateAsync(eventhubName2, new EventhubData())).Value;

            //validate
            int count = 0;
            Eventhub eventhub1 = null;
            Eventhub eventhub2 = null;
            await foreach (Eventhub eventhub in _eventhubContainer.GetAllAsync())
            {
                count++;
                if (eventhub.Id.Name == eventhubName1)
                    eventhub1 = eventhub;
                if (eventhub.Id.Name == eventhubName2)
                    eventhub2 = eventhub;
            }
            Assert.AreEqual(count, 2);
            Assert.NotNull(eventhub1);
            Assert.NotNull(eventhub2);
        }

        [Test]
        [RecordedTest]
        public async Task EventhubCreateGetUpdateDeleteAuthorizationRule()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            Eventhub eventhub = (await _eventhubContainer.CreateOrUpdateAsync(eventhubName, new EventhubData())).Value;

            //create an authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            AuthorizationRuleEventHubContainer ruleContainer = eventhub.GetAuthorizationRuleEventHubs();
            AuthorizationRuleData parameter = new AuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            AuthorizationRuleEventHub authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleContainer.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<AuthorizationRuleEventHub> rules = await ruleContainer.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (AuthorizationRuleEventHub rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.True(isContainAuthorizationRuleName);

            //update authorization rule
            parameter.Rights.Add(AccessRights.Manage);
            authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync();

            //validate if deleted
            Assert.IsFalse(await ruleContainer.CheckIfExistsAsync(ruleName));
            rules = await ruleContainer.GetAllAsync().ToEnumerableAsync();
            Assert.True(rules.Count == 0);
        }

        [Test]
        [RecordedTest]
        public async Task EventhubAuthorizationRuleRegenerateKey()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            Eventhub eventhub = (await _eventhubContainer.CreateOrUpdateAsync(eventhubName, new EventhubData())).Value;
            AuthorizationRuleEventHubContainer ruleContainer = eventhub.GetAuthorizationRuleEventHubs();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            AuthorizationRuleData parameter = new AuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            AuthorizationRuleEventHub authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            AccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            AccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyParameters(KeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            AccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyParameters(KeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }
        }
    }
}
