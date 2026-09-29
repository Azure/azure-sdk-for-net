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

        private DiscoveryProjectCollection GetDiscoveryProjectCollection()
            => Client.GetDiscoveryWorkspaceResource(DiscoveryWorkspaceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, WorkspaceName)).GetDiscoveryProjects();

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<DiscoveryProjectResource> operation = await GetDiscoveryProjectCollection().CreateOrUpdateAsync(WaitUntil.Completed, ProjectName, new DiscoveryProjectData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(ProjectName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoveryProjectResource> response = await GetDiscoveryProjectCollection().GetAsync(ProjectName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(ProjectName));
        }

        [RecordedTest]
        public async Task ListByWorkspace()
        {
            List<DiscoveryProjectResource> items = new List<DiscoveryProjectResource>();
            await foreach (DiscoveryProjectResource item in GetDiscoveryProjectCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }
    }
}
