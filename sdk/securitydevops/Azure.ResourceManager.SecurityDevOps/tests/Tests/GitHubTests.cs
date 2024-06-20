// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.SecurityDevOps.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityDevOps.Tests
{
    /// <summary>
    /// These tests have been written against test resources that were either created manually or via other test methods.
    /// Tests will pass during playback, but will not necessarily (almost certainly will not) pass during re-recording without manual intervention/debugging.
    /// Resource creation (i.e. Repository Connectors) depends on having a valid OAuth token to a real, existing code repository (Azure DevOps, GitHub, etc.)
    /// and is therefore difficult to create tests that can create arbitrary resources automatically.
    /// The repositories discovered via Connectors also depend on the real repositories in the organization/account connected to.
    ///
    /// Because of this, the tests were at one time run against real resources, and recordings have been slightly modified to ensure they always pass during replay,
    /// but rerunning tests in record mode will almost certainly result in failures without forcing test conditions to meet what is already deployed.
    /// </summary>
    public class GitHubTests : SecurityDevOpsManagementTestBase
    {
        public GitHubTests(bool async)
            : base(async)//, RecordedTestMode.Record)
        {
            // Sanitize GitHub OAuth code for Connector creation
            BodyKeySanitizers.Add(new BodyKeySanitizer("properties.code"));
        }

        [Test]
        [RecordedTest]
        public async Task CreateGitHubConnector()
        {
            var gitHubConnectorCollection = (await DefaultSubscription.GetResourceGroupAsync(TestEnvironment.ResourceGroup)).Value.GetGitHubConnectors();

            var connectorName = Recording.GenerateAssetName("securitydevops-ghconnector");
            var connectorData = new GitHubConnectorData(TestEnvironment.Location)
            {
                // Requires getting an OAuth code for GitHub and replacing here.
                // Each OAuth code will only work one time, so async version of test will require a separate code from sync version.
                // Code is sanitized from test recording so credential doesn't leak.
                Properties = new GitHubConnectorProperties { Code = "GitHubOAuthCode" }
            };

            var gitHubConnector = (await gitHubConnectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, connectorName, connectorData)).Value;

            Assert.IsNotNull(gitHubConnector);
            Assert.AreEqual(ProvisioningState.Succeeded, gitHubConnector.Data.Properties.ProvisioningState);
            Assert.AreEqual(connectorName, gitHubConnector.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, gitHubConnector.Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetGitHubConnectors()
        {
            var connectors = await DefaultSubscription.GetGitHubConnectorsAsync().ToEnumerableAsync();
            Assert.IsNotNull(connectors);
            Assert.AreEqual(1, connectors.Count);

            var connector = connectors[0];
            Assert.AreEqual("securitydevops-ghconnector5440", connector.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, connector.Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetGitHubConnector()
        {
            var subscriptionId = await Client.GetDefaultSubscriptionAsync();
            var gitHubConnectorId = GitHubConnectorResource.CreateResourceIdentifier(
                subscriptionId.Data.SubscriptionId,
                TestEnvironment.ResourceGroup,
                "securitydevops-ghconnector5440");

            GitHubConnectorResource gitHubConnector = await Client.GetGitHubConnectorResource(gitHubConnectorId).GetAsync();

            Assert.IsNotNull(gitHubConnector);
            Assert.AreEqual(gitHubConnectorId.Name, gitHubConnector.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, gitHubConnector.Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetGitHubRepositories()
        {
            var subscriptionId = await Client.GetDefaultSubscriptionAsync();
            var gitHubConnectorId = GitHubConnectorResource.CreateResourceIdentifier(
                subscriptionId.Data.SubscriptionId,
                TestEnvironment.ResourceGroup,
                "securitydevops-ghconnector1741");

            GitHubConnectorResource gitHubConnector = await Client.GetGitHubConnectorResource(gitHubConnectorId).GetAsync();

            var gitHubRepos = await gitHubConnector.GetGitHubReposByConnectorAsync().ToEnumerableAsync();

            Assert.AreEqual(1, gitHubRepos.Count);
            var repo = gitHubRepos[0];
            Assert.AreEqual("azure-sdk-for-net", repo.Data.Name);
            Assert.AreEqual("https://github.com/Azure/azure-sdk-for-net", repo.Data.Properties.RepoUri.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task DeleteGitHubConnector()
        {
            var subscriptionId = await Client.GetDefaultSubscriptionAsync();
            var connectorId = GitHubConnectorResource.CreateResourceIdentifier(
                subscriptionId.Data.SubscriptionId,
                TestEnvironment.ResourceGroup,
                "securitydevops-ghconnector5440");

            // Get connector and verify it exists
            GitHubConnectorResource connector = await Client.GetGitHubConnectorResource(connectorId).GetAsync();
            Assert.IsNotNull(connector);

            // Delete
            await connector.DeleteAsync(WaitUntil.Completed);

            // Verify it no longer exists
            try
            {
                connector = await Client.GetGitHubConnectorResource(connectorId).GetAsync();
                Assert.Fail("Expected RequestFailedException, but Get request succeeded anyway.");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
                Assert.AreEqual("ResourceNotFound", e.ErrorCode);
            }
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        [RecordedTest]
        [Ignore("Tag manipulation not working (errors about sync method called within async method).  Needs investigation.")]
        public async Task AddUpdateDeleteGitHubConnectorTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);

            var subscriptionId = await Client.GetDefaultSubscriptionAsync();
            var gitHubConnectorId = GitHubConnectorResource.CreateResourceIdentifier(
                subscriptionId: subscriptionId.Data.SubscriptionId,
                resourceGroupName: TestEnvironment.ResourceGroup,
                gitHubConnectorName: "securitydevops-ghconnector1741");

            GitHubConnectorResource gitHubConnector = await Client.GetGitHubConnectorResource(gitHubConnectorId).GetAsync();

            // Save existing tags to replace later
            var originalTags = gitHubConnector.Data.Tags;

            // Verify test tags do not already exist
            Assert.IsFalse(gitHubConnector.Data.Tags.ContainsKey("test1"));
            Assert.IsFalse(gitHubConnector.Data.Tags.ContainsKey("test2"));

            // Add tags
            gitHubConnector = await gitHubConnector.AddTagAsync("test1", "value1");

            // Verify test tags were added
            Assert.AreEqual("value1", gitHubConnector.Data.Tags["test1"]);

            // Replace all tags
            gitHubConnector = await gitHubConnector.SetTagsAsync(new Dictionary<string, string>
            {
                { "test2", "value2" },
                { "test3", "value3" }
            });

            // Verify all tags are replaced with test tags
            Assert.AreEqual(2, gitHubConnector.Data.Tags.Count);
            Assert.AreEqual("value2", gitHubConnector.Data.Tags["test2"]);
            Assert.AreEqual("value3", gitHubConnector.Data.Tags["test3"]);

            // Delete tag
            gitHubConnector = await gitHubConnector.RemoveTagAsync("test3");

            // Verify test tag no longer exists
            Assert.AreEqual(1, gitHubConnector.Data.Tags.Count);
            Assert.IsFalse(gitHubConnector.Data.Tags.ContainsKey("test3"));
            Assert.AreEqual("value2", gitHubConnector.Data.Tags["test2"]);

            // Replace original tags
            await gitHubConnector.SetTagsAsync(originalTags);
        }
    }
}
