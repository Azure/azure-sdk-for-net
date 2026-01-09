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

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class ConsumerGroupTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventHubResource _eventHub;
        private EventHubsConsumerGroupCollection _consumerGroupCollection;

        public ConsumerGroupTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eHNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
            EventHubCollection eventhubCollection = eHNamespace.GetEventHubs();
            string eventhubName = Recording.GenerateAssetName("eventhub");
            _eventHub = (await eventhubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;
            _consumerGroupCollection = _eventHub.GetEventHubsConsumerGroups();
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteConsumerGroup()
        {
            //create consumer group
            string consumerGroupName = Recording.GenerateAssetName("testconsumergroup");
            EventHubsConsumerGroupResource consumerGroup = (await _consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, new EventHubsConsumerGroupData())).Value;
            Assert.Multiple(async () =>
            {
                Assert.That(consumerGroup, Is.Not.Null);
                Assert.That(consumerGroupName, Is.EqualTo(consumerGroup.Id.Name));

                //validate if created successfully
                Assert.That((bool)await _consumerGroupCollection.ExistsAsync(consumerGroupName), Is.True);
            });
            consumerGroup = await _consumerGroupCollection.GetAsync(consumerGroupName);

            //delete consumer group
            await consumerGroup.DeleteAsync(WaitUntil.Completed);

            //validate
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _consumerGroupCollection.GetAsync(consumerGroupName); });
            Assert.Multiple(async () =>
            {
                Assert.That(exception.Status, Is.EqualTo(404));
                Assert.That((bool)await _consumerGroupCollection.ExistsAsync(consumerGroupName), Is.False);
            });
        }

        [Test]
        [RecordedTest]
        public async Task GetAllConsumerGroups()
        {
            //create ten consumer groups
            for (int i = 0; i < 10; i++)
            {
                string consumerGroupName = Recording.GenerateAssetName("testconsumergroup" + i.ToString());
                _ = (await _consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, new EventHubsConsumerGroupData())).Value;
            }

            //validate
            List<EventHubsConsumerGroupResource> list = await _consumerGroupCollection.GetAllAsync().ToEnumerableAsync();
            // the count should be 11 because there is a default consumergroup
            Assert.That(list, Has.Count.EqualTo(11));
            list = await _consumerGroupCollection.GetAllAsync(5, 5).ToEnumerableAsync();
            Assert.That(list, Has.Count.EqualTo(6));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateConsumerGroup()
        {
            //create consumer group
            string consumerGroupName = Recording.GenerateAssetName("testconsumergroup");
            EventHubsConsumerGroupResource consumerGroup = (await _consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, new EventHubsConsumerGroupData())).Value;
            Assert.Multiple(() =>
            {
                Assert.That(consumerGroup, Is.Not.Null);
                Assert.That(consumerGroupName, Is.EqualTo(consumerGroup.Id.Name));
            });

            //update consumer group and validate
            consumerGroup.Data.UserMetadata = "update the user meta data";
            consumerGroup = (await _consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, consumerGroup.Data)).Value;
            Assert.That(consumerGroup.Data.UserMetadata, Is.EqualTo("update the user meta data"));
        }
    }
}
