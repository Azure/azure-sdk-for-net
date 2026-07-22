// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class ProjectCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string WorkspaceName = "sanitized-workspace";
        private const string ProjectName = "sanitized-project";

        public ProjectCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private ProjectCollection GetProjectCollection()
            => Client.GetWorkspaceResource(WorkspaceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, WorkspaceName)).GetProjects();

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<ProjectResource> operation = await GetProjectCollection().CreateOrUpdateAsync(WaitUntil.Completed, ProjectName, new ProjectData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(ProjectName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<ProjectResource> response = await GetProjectCollection().GetAsync(ProjectName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(ProjectName));
        }

        [RecordedTest]
        public async Task ListByWorkspace()
        {
            List<ProjectResource> items = new List<ProjectResource>();
            await foreach (ProjectResource item in GetProjectCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }
    }
}
