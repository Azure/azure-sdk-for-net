// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Tests.Helpers;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class ConsumerGroupTests : EventHubTestBase
    {
        private ResourceGroup _resourceGroup;
        private Eventhub _eventhub;
        private ConsumerGroupContainer _consumerGroupContainer;
        public ConsumerGroupTests(bool isAsync) : base(isAsync)
        {
        }
        [SetUp]
        public async Task CreateNamespaceAndGetEventhubContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            EventhubContainer eventhubContainer = eHNamespace.GetEventhubs();
            string eventhubName = Recording.GenerateAssetName("eventhub");
            _eventhub = (await eventhubContainer.CreateOrUpdateAsync(eventhubName, new EventhubData())).Value;
            _consumerGroupContainer = _eventhub.GetConsumerGroups();
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
        public async Task CreateDeleteConsumerGroup()
        {
            //create consumer group
            string consumerGroupName = Recording.GenerateAssetName("testconsumergroup");
            ConsumerGroup consumerGroup = (await _consumerGroupContainer.CreateOrUpdateAsync(consumerGroupName, new ConsumerGroupData())).Value;
            Assert.NotNull(consumerGroup);
            Assert.AreEqual(consumerGroup.Id.Name, consumerGroupName);

            //validate if created successfully
            consumerGroup = await _consumerGroupContainer.GetIfExistsAsync(consumerGroupName);
            Assert.NotNull(consumerGroup);
            Assert.IsTrue(await _consumerGroupContainer.CheckIfExistsAsync(consumerGroupName));

            //delete consumer group
            await consumerGroup.DeleteAsync();

            //validate
            consumerGroup = await _consumerGroupContainer.GetIfExistsAsync(consumerGroupName);
            Assert.Null(consumerGroup);
            Assert.IsFalse(await _consumerGroupContainer.CheckIfExistsAsync(consumerGroupName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllConsumerGroups()
        {
            //create ten consumer groups
            for (int i = 0; i < 10; i++)
            {
                string consumerGroupName = Recording.GenerateAssetName("testconsumergroup" + i.ToString());
                _ = (await _consumerGroupContainer.CreateOrUpdateAsync(consumerGroupName, new ConsumerGroupData())).Value;
            }

            //validate
            List<ConsumerGroup> list = await _consumerGroupContainer.GetAllAsync().ToEnumerableAsync();
            // the count should be 11 because there is a default consumergroup
            Assert.AreEqual(list.Count, 11);
            list = await _consumerGroupContainer.GetAllAsync(5, 5).ToEnumerableAsync();
            Assert.AreEqual(list.Count, 6);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateConsumerGroup()
        {
            //create consumer group
            string consumerGroupName = Recording.GenerateAssetName("testconsumergroup");
            ConsumerGroup consumerGroup = (await _consumerGroupContainer.CreateOrUpdateAsync(consumerGroupName, new ConsumerGroupData())).Value;
            Assert.NotNull(consumerGroup);
            Assert.AreEqual(consumerGroup.Id.Name, consumerGroupName);

            //update consumer group and validate
            consumerGroup.Data.UserMetadata = "update the user meta data";
            consumerGroup = (await _consumerGroupContainer.CreateOrUpdateAsync(consumerGroupName, consumerGroup.Data)).Value;
            Assert.AreEqual(consumerGroup.Data.UserMetadata, "update the user meta data");
        }
    }
}
