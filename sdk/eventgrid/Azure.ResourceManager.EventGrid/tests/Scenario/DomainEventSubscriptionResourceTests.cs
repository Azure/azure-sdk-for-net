// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.EventGrid;
using Azure.ResourceManager.EventGrid.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests.Scenario
{
    [TestFixture(true)]
    [TestFixture(false)]
    internal class DomainEventSubscriptionResourceTests
    {
        private readonly bool _isAsync;

        private string _subscriptionId;
        private string _resourceGroupName;
        private string _domainName;
        private string _topicName;
        private string _eventSubscriptionName;

        private ArmClient _armClient;
        private ResourceIdentifier _topicResourceId;
        private ResourceIdentifier _eventSubResourceId;

        public DomainEventSubscriptionResourceTests(bool isAsync)
        {
            _isAsync = isAsync;
        }

        [SetUp]
        public void SetUp()
        {
            _subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            _resourceGroupName = "sdk-eventgrid-test-rg";
            _domainName = "sdk-eventgrid-test-domainName";
            _topicName = "sdk-eventgrid-test-eventGridTopic";
            _eventSubscriptionName = "sdk-eventgrid-test-EventSubscription";

            _topicResourceId = DomainTopicResource.CreateResourceIdentifier(_subscriptionId, _resourceGroupName, _domainName, _topicName);
            _eventSubResourceId = DomainTopicEventSubscriptionResource.CreateResourceIdentifier(_subscriptionId, _resourceGroupName, _domainName, _topicName, _eventSubscriptionName);

            _armClient = new ArmClient(new Azure.Identity.DefaultAzureCredential(), _subscriptionId);
        }

        [Test]
        public async Task DomainTopicResource_GetDomainTopicEventSubscriptionAsync_ThrowsRequestFailedException()
        {
            var topicResource = new DomainTopicResource(_armClient, _topicResourceId);

            if (_isAsync)
            {
                Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await topicResource.GetDomainTopicEventSubscriptionAsync(_eventSubscriptionName);
                });
            }
            else
            {
                Assert.Throws<RequestFailedException>(() =>
                {
                    topicResource.GetDomainTopicEventSubscription(_eventSubscriptionName);
                });
            }

            await Task.CompletedTask;
        }

        [Test]
        public async Task DomainTopicResource_GetAsync_ThrowsRequestFailedException()
        {
            var topicResource = new DomainTopicResource(_armClient, _topicResourceId);

            if (_isAsync)
            {
                Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await topicResource.GetAsync();
                });
            }
            else
            {
                Assert.Throws<RequestFailedException>(() =>
                {
                    topicResource.Get();
                });
            }

            await Task.CompletedTask;
        }

        [Test]
        public async Task DomainTopicEventSubscriptionResource_UpdateAsync_ThrowsRequestFailedException()
        {
            var eventSubResource = new DomainTopicEventSubscriptionResource(_armClient, _eventSubResourceId);
            var patch = new EventGridSubscriptionPatch();

            if (_isAsync)
            {
                Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                    await eventSubResource.UpdateAsync(WaitUntil.Completed, patch);
                });
            }
            else
            {
                Assert.Throws<RequestFailedException>(() =>
                {
                    eventSubResource.Update(WaitUntil.Completed, patch);
                });
            }

            await Task.CompletedTask;
        }
    }
}
