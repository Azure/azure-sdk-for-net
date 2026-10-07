// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class WorkspaceCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string WorkspaceName = "sanitized-workspace";

        public WorkspaceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private DiscoveryWorkspaceCollection GetDiscoveryWorkspaceCollection()
            => GetResourceGroupReference(ResourceGroupName).GetDiscoveryWorkspaces();

        private DiscoveryWorkspaceResource GetWorkspaceReference()
            => Client.GetDiscoveryWorkspaceResource(DiscoveryWorkspaceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, WorkspaceName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            DiscoveryWorkspaceData data = new DiscoveryWorkspaceData(AzureLocation.UKSouth);
            ArmOperation<DiscoveryWorkspaceResource> operation = await GetDiscoveryWorkspaceCollection().CreateOrUpdateAsync(WaitUntil.Completed, WorkspaceName, data);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(WorkspaceName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoveryWorkspaceResource> response = await GetDiscoveryWorkspaceCollection().GetAsync(WorkspaceName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(WorkspaceName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<DiscoveryWorkspaceResource> workspaces = new List<DiscoveryWorkspaceResource>();
            await foreach (DiscoveryWorkspaceResource workspace in GetDiscoveryWorkspaceCollection().GetAllAsync())
            {
                workspaces.Add(workspace);
            }

            Assert.That(workspaces, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<DiscoveryWorkspaceResource> workspaces = new List<DiscoveryWorkspaceResource>();
            await foreach (DiscoveryWorkspaceResource workspace in GetSubscriptionReference().GetDiscoveryWorkspacesAsync())
            {
                workspaces.Add(workspace);
            }

            Assert.That(workspaces, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            DiscoveryWorkspaceData data = new DiscoveryWorkspaceData(AzureLocation.UKSouth);
            ArmOperation<DiscoveryWorkspaceResource> operation = await GetWorkspaceReference().UpdateAsync(WaitUntil.Completed, data);

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(WorkspaceName));
        }

        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation operation = await GetWorkspaceReference().DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
