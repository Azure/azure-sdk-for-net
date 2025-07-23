// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.EventGrid;
using Azure.ResourceManager.EventGrid.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    internal class TopicTypeTests : EventGridManagementTestBase
    {
        private TopicTypeCollection _topicTypeCollection;

        public TopicTypeTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenants.FirstOrDefault();
            if (tenant == null)
            {
                Assert.Fail("No tenants found.");
            }

            _topicTypeCollection = tenant.GetTopicTypes();
        }

        [Test]
        [Ignore("System.FormatException : The ResourceIdentifier must start with /subscriptions/ or /providers/")]
        public async Task TopicTypeCollectionGetAsync()
        {
            string topicTypeName = "Microsoft.Storage.StorageAccounts";
            Console.WriteLine($"Testing TopicType: {topicTypeName}");

            var response = await _topicTypeCollection.GetAsync(topicTypeName);

            // Validate response
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);

            var data = response.Value.Data;

            // Validate ID before using it
            Assert.IsFalse(string.IsNullOrEmpty(data.Id?.ToString()), "TopicTypeData.Id is null or empty.");
            Assert.IsTrue(data.Id.ToString().StartsWith("/providers/") || data.Id.ToString().StartsWith("/subscriptions/"),
                $"Invalid ResourceIdentifier: {data.Id}");

            // Validate name
            Assert.AreEqual(topicTypeName, data.Name);
        }

        [Ignore("This test is ignored because it requires a specific topic type to exist.")]
        [Test]
        public async Task TopicTypeCollectionGetAllAsync()
        {
            // actually: {providers/Microsoft.EventGrid/topicTypes/Microsoft.Eventhub.Namespaces}
            var list = await _topicTypeCollection.GetAllAsync().ToEnumerableAsync();

            Assert.IsNotNull(list);
            Assert.IsNotEmpty(list);

            foreach (var item in list)
            {
                Assert.IsNotNull(item);
                Assert.IsInstanceOf<TopicTypeResource>(item);
                Assert.IsInstanceOf<TopicTypeData>(item.Data);

                string id = item.Data.Id.ToString();
                Assert.IsTrue(id.StartsWith("/providers/") || id.StartsWith("/subscriptions/"),
                    $"Invalid ResourceIdentifier: {id}");
            }
        }

        [Ignore("This test is ignored because it requires a specific topic type to exist.")]
        [Test]
        public async Task TopicTypeResourceGetAsync()
        {
            string topicTypeName = "Microsoft.Storage.StorageAccounts";
            var response = await _topicTypeCollection.GetAsync(topicTypeName);
            var topicTypeResource = response.Value;

            var getResponse = await topicTypeResource.GetAsync();

            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value);

            var data = getResponse.Value.Data;
            Assert.AreEqual(topicTypeName, data.Name);

            string id = data.Id.ToString();
            Assert.IsTrue(id.StartsWith("/providers/") || id.StartsWith("/subscriptions/"),
                $"Invalid ResourceIdentifier: {id}");
        }

        [Ignore("This test is ignored because it requires a specific topic type to exist.")]
        [Test]
        public async Task TopicTypeResourceGetEventTypesAsync()
        {
            string topicTypeName = "Microsoft.Storage.StorageAccounts";
            var response = await _topicTypeCollection.GetAsync(topicTypeName);
            var topicTypeResource = response.Value;

            var eventTypes = await topicTypeResource.GetEventTypesAsync().ToEnumerableAsync();

            Assert.IsNotNull(eventTypes);
            Assert.IsNotEmpty(eventTypes);

            foreach (var eventType in eventTypes)
            {
                Assert.IsNotNull(eventType);
                Assert.IsFalse(string.IsNullOrEmpty(eventType.Name));
            }
        }
    }
}
