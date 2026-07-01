// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DevHub.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevHub.Tests.Scenario
{
    [TestFixture]
    [Ignore("the Microsoft.DevHub preview API is not enabled and AKS provisioning is blocked by subscription policy.")]
    public class DevHubWorkflowCollectionTests : DevHubManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public DevHubWorkflowCollectionTests() : base(true)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            await CreateCommonClient();
            _resourceGroup = await CreateResourceGroup(DefaultSubscription, "dh-wf-rg", AzureLocation.EastUS);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        private DevHubWorkflowData GetWorkflowData()
        {
            return new DevHubWorkflowData(AzureLocation.EastUS)
            {
                Properties = new WorkflowProperties
                {
                    GithubWorkflowProfile = new GitHubWorkflowProfile
                    {
                        RepositoryOwner = "contoso",
                        RepositoryName = "contoso-app",
                        BranchName = "main",
                    },
                },
            };
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = _resourceGroup.GetDevHubWorkflows();
            string workflowName = Recording.GenerateAssetName("workflow");

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, workflowName, GetWorkflowData());
            DevHubWorkflowResource workflow = lro.Value;

            Assert.That(lro.HasCompleted, Is.True);
            Assert.That(workflow, Is.Not.Null);
            Assert.That(workflow.Data.Name, Is.EqualTo(workflowName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = _resourceGroup.GetDevHubWorkflows();
            string workflowName = Recording.GenerateAssetName("workflow");
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, workflowName, GetWorkflowData());

            DevHubWorkflowResource workflow = await collection.GetAsync(workflowName);

            Assert.That(workflow, Is.Not.Null);
            Assert.That(workflow.Data.Name, Is.EqualTo(workflowName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var collection = _resourceGroup.GetDevHubWorkflows();
            string workflowName = Recording.GenerateAssetName("workflow");
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, workflowName, GetWorkflowData());

            bool exists = await collection.ExistsAsync(workflowName);

            Assert.That(exists, Is.True);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = _resourceGroup.GetDevHubWorkflows();
            string workflowName = Recording.GenerateAssetName("workflow");
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, workflowName, GetWorkflowData());

            var workflows = new List<DevHubWorkflowResource>();
            await foreach (DevHubWorkflowResource workflow in collection.GetAllAsync())
            {
                workflows.Add(workflow);
            }

            Assert.That(workflows, Is.Not.Empty);
            Assert.That(workflows.Exists(w => w.Data.Name == workflowName), Is.True);
        }
    }
}
