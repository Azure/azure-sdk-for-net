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

        private ChatModelDeploymentCollection GetChatModelDeploymentCollection()
            => Client.GetWorkspaceResource(WorkspaceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, WorkspaceName)).GetChatModelDeployments();

        private ChatModelDeploymentResource GetChatModelDeploymentReference()
            => Client.GetChatModelDeploymentResource(ChatModelDeploymentResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, WorkspaceName, ChatModelDeploymentName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<ChatModelDeploymentResource> operation = await GetChatModelDeploymentCollection().CreateOrUpdateAsync(WaitUntil.Completed, ChatModelDeploymentName, new ChatModelDeploymentData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(ChatModelDeploymentName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<ChatModelDeploymentResource> response = await GetChatModelDeploymentCollection().GetAsync(ChatModelDeploymentName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(ChatModelDeploymentName));
        }

        [RecordedTest]
        public async Task ListByWorkspace()
        {
            List<ChatModelDeploymentResource> items = new List<ChatModelDeploymentResource>();
            await foreach (ChatModelDeploymentResource item in GetChatModelDeploymentCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<ChatModelDeploymentResource> operation = await GetChatModelDeploymentReference().UpdateAsync(WaitUntil.Completed, new ChatModelDeploymentData(AzureLocation.UKSouth));

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
