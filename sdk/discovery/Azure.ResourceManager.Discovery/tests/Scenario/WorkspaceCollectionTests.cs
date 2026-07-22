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

        private WorkspaceCollection GetWorkspaceCollection()
            => GetResourceGroupReference(ResourceGroupName).GetWorkspaces();

        private WorkspaceResource GetWorkspaceReference()
            => Client.GetWorkspaceResource(WorkspaceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, WorkspaceName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            WorkspaceData data = new WorkspaceData(AzureLocation.UKSouth);
            ArmOperation<WorkspaceResource> operation = await GetWorkspaceCollection().CreateOrUpdateAsync(WaitUntil.Completed, WorkspaceName, data);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(WorkspaceName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<WorkspaceResource> response = await GetWorkspaceCollection().GetAsync(WorkspaceName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(WorkspaceName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<WorkspaceResource> workspaces = new List<WorkspaceResource>();
            await foreach (WorkspaceResource workspace in GetWorkspaceCollection().GetAllAsync())
            {
                workspaces.Add(workspace);
            }

            Assert.That(workspaces, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<WorkspaceResource> workspaces = new List<WorkspaceResource>();
            await foreach (WorkspaceResource workspace in GetSubscriptionReference().GetWorkspacesAsync())
            {
                workspaces.Add(workspace);
            }

            Assert.That(workspaces, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            WorkspaceData data = new WorkspaceData(AzureLocation.UKSouth);
            ArmOperation<WorkspaceResource> operation = await GetWorkspaceReference().UpdateAsync(WaitUntil.Completed, data);

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
