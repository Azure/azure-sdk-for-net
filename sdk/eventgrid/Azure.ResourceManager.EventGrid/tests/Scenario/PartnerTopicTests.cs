// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.EventGrid;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests.Scenario
{
    [TestFixture(true)]
    [TestFixture(false)]
    internal class PartnerTopicTests
    {
        private readonly bool _isAsync;
        private ArmClient _armClient;
        private ResourceGroupResource _resourceGroup;
        private PartnerTopicCollection _partnerTopicCollection;

        public PartnerTopicTests(bool isAsync)
        {
            _isAsync = isAsync;
        }

        [SetUp]
        public async Task SetUp()
        {
            _armClient = new ArmClient(new DefaultAzureCredential(), "5b4b650e-28b9-4790-b3ab-ddbd88d727c4");
            var subscription = _armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4"));

            var rgResponse = await subscription.GetResourceGroups().GetAsync("sdk-eventgrid-test-rg");
            _resourceGroup = rgResponse.Value;

            _partnerTopicCollection = _resourceGroup.GetPartnerTopics();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (_resourceGroup != null)
            {
                await _resourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<PartnerTopicResource> CreateTestPartnerTopic()
        {
            string topicName = "testtopic" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new PartnerTopicData(_resourceGroup.Id, topicName, PartnerTopicResource.ResourceType, new SystemData(), new Dictionary<string, string>(), AzureLocation.WestUS2, null, null, "source", null, null, null, null, null, null, null);
            var op = await _partnerTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, data);
            return op.Value;
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicCollection_CreateOrUpdateAsync_CreatesResource()
        {
            string topicName = "testtopic" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new PartnerTopicData(_resourceGroup.Id, topicName, PartnerTopicResource.ResourceType, new SystemData(), new Dictionary<string, string>(), AzureLocation.WestUS2, null, null, "source", null, null, null, null, null, null, null);
            var op = await _partnerTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, data);
            Assert.IsNotNull(op.Value);
            Assert.AreEqual(topicName, op.Value.Data.Name);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicCollection_GetAsync_GetsResource()
        {
            string topicName = "testtopic" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new PartnerTopicData(_resourceGroup.Id, topicName, PartnerTopicResource.ResourceType, new SystemData(), new Dictionary<string, string>(), AzureLocation.WestUS2, null, null, "source", null, null, null, null, null, null, null);
            await _partnerTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, data);
            var response = await _partnerTopicCollection.GetAsync(topicName);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(topicName, response.Value.Data.Name);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicCollection_GetAllAsync_ReturnsResources()
        {
            string topicName = "testtopic" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new PartnerTopicData(_resourceGroup.Id, topicName, PartnerTopicResource.ResourceType, new SystemData(), new Dictionary<string, string>(), AzureLocation.WestUS2, null, null, "source", null, null, null, null, null, null, null);
            await _partnerTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, data);
            var list = await _partnerTopicCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(list.Any());
            Assert.IsTrue(list.Any(t => t.Data.Name == topicName));
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicEventSubscriptionCollection_CreateOrUpdateAsync_CreatesResource()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            var op = await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            Assert.IsNotNull(op.Value);
            Assert.AreEqual(subName, op.Value.Data.Name);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicEventSubscriptionCollection_GetAsync_GetsResource()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            var response = await eventSubs.GetAsync(subName);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(subName, response.Value.Data.Name);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicEventSubscriptionCollection_GetAllAsync_ReturnsResources()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            var list = await eventSubs.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(list.Any());
            Assert.IsTrue(list.Any(s => s.Data.Name == subName));
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicEventSubscriptionResource_GetAsync_GetsResource()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            var op = await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            var resource = op.Value;
            var response = await resource.GetAsync();
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(subName, response.Value.Data.Name);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicEventSubscriptionResource_DeleteAsync_DeletesResource()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            var op = await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            var resource = op.Value;
            var deleteOp = await resource.DeleteAsync(WaitUntil.Completed);
            Assert.IsNotNull(deleteOp);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicEventSubscriptionResource_UpdateAsync_UpdatesResource()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            var op = await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            var resource = op.Value;
            var patch = new EventGridSubscriptionPatch(null, null, null, null, null, null, null, null, null, null);
            var updateOp = await resource.UpdateAsync(WaitUntil.Completed, patch);
            Assert.IsNotNull(updateOp);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicEventSubscriptionResource_GetFullUriAsync_ReturnsUri()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            var op = await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            var resource = op.Value;
            var uriResponse = await resource.GetFullUriAsync();
            Assert.IsNotNull(uriResponse);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicEventSubscriptionResource_GetDeliveryAttributesAsync_ReturnsAttributes()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            var op = await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            var resource = op.Value;
            var attributes = await resource.GetDeliveryAttributesAsync().ToEnumerableAsync();
            Assert.IsNotNull(attributes);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_GetPartnerTopicEventSubscriptionAsync_GetsResource()
        {
            var topic = await CreateTestPartnerTopic();
            var eventSubs = topic.GetPartnerTopicEventSubscriptions();
            string subName = "testsub" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var data = new EventGridSubscriptionData(topic.Id, subName, PartnerTopicEventSubscriptionResource.ResourceType, new SystemData(), topic.Id.ToString(), null, null, null, null, null, null, null, null, null, null, null);
            await eventSubs.CreateOrUpdateAsync(WaitUntil.Completed, subName, data);
            var response = await topic.GetPartnerTopicEventSubscriptionAsync(subName);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(subName, response.Value.Data.Name);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_GetAsync_GetsResource()
        {
            var topic = await CreateTestPartnerTopic();
            var response = await topic.GetAsync();
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(topic.Data.Name, response.Value.Data.Name);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_DeleteAsync_DeletesResource()
        {
            var topic = await CreateTestPartnerTopic();
            var deleteOp = await topic.DeleteAsync(WaitUntil.Completed);
            Assert.IsNotNull(deleteOp);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_UpdateAsync_UpdatesResource()
        {
            var topic = await CreateTestPartnerTopic();
            var patch = new PartnerTopicPatch();
            var updateResponse = await topic.UpdateAsync(patch);
            Assert.IsNotNull(updateResponse.Value);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_ActivateAsync_ActivatesResource()
        {
            var topic = await CreateTestPartnerTopic();
            var response = await topic.ActivateAsync();
            Assert.IsNotNull(response.Value);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_DeactivateAsync_DeactivatesResource()
        {
            var topic = await CreateTestPartnerTopic();
            var response = await topic.DeactivateAsync();
            Assert.IsNotNull(response.Value);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_AddTagAsync_AddsTag()
        {
            var topic = await CreateTestPartnerTopic();
            var response = await topic.AddTagAsync("env", "test");
            Assert.IsNotNull(response.Value);
            Assert.IsTrue(response.Value.Data.Tags.ContainsKey("env"));
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_SetTagsAsync_SetsTags()
        {
            var topic = await CreateTestPartnerTopic();
            var tags = new Dictionary<string, string> { { "env", "test" }, { "owner", "sdk" } };
            var response = await topic.SetTagsAsync(tags);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(2, response.Value.Data.Tags.Count);
        }

        [Ignore("This test is ignored because it requires a valid Partner Resource.")]
        [Test]
        public async Task PartnerTopicResource_RemoveTagAsync_RemovesTag()
        {
            var topic = await CreateTestPartnerTopic();
            await topic.AddTagAsync("env", "test");
            var response = await topic.RemoveTagAsync("env");
            Assert.IsNotNull(response.Value);
            Assert.IsFalse(response.Value.Data.Tags.ContainsKey("env"));
        }
    }
}
