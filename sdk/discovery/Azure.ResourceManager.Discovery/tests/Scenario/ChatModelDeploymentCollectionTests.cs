// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class ChatModelDeploymentCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string WorkspaceName = "sanitized-workspace";
        private const string ChatModelDeploymentName = "sanitized-chatdeployment";

        public ChatModelDeploymentCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private DiscoveryChatModelDeploymentCollection GetChatModelDeploymentCollection()
            => Client.GetDiscoveryWorkspaceResource(DiscoveryWorkspaceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, WorkspaceName)).GetDiscoveryChatModelDeployments();

        private DiscoveryChatModelDeploymentResource GetChatModelDeploymentReference()
            => Client.GetDiscoveryChatModelDeploymentResource(DiscoveryChatModelDeploymentResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, WorkspaceName, ChatModelDeploymentName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<DiscoveryChatModelDeploymentResource> operation = await GetChatModelDeploymentCollection().CreateOrUpdateAsync(WaitUntil.Completed, ChatModelDeploymentName, new DiscoveryChatModelDeploymentData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(ChatModelDeploymentName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoveryChatModelDeploymentResource> response = await GetChatModelDeploymentCollection().GetAsync(ChatModelDeploymentName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(ChatModelDeploymentName));
        }

        [RecordedTest]
        public async Task ListByWorkspace()
        {
            List<DiscoveryChatModelDeploymentResource> items = new List<DiscoveryChatModelDeploymentResource>();
            await foreach (DiscoveryChatModelDeploymentResource item in GetChatModelDeploymentCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<DiscoveryChatModelDeploymentResource> operation = await GetChatModelDeploymentReference().UpdateAsync(WaitUntil.Completed, new DiscoveryChatModelDeploymentData(AzureLocation.UKSouth));

            Assert.That(operation.Value.Data.Name, Is.EqualTo(ChatModelDeploymentName));
        }

        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation operation = await GetChatModelDeploymentReference().DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
