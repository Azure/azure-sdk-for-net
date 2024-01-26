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
    public class AzDevOpsTests : SecurityDevOpsManagementTestBase
    {
        public AzDevOpsTests(bool async)
            : base(async)//, RecordedTestMode.Record)
        {
            // Sanitize Azure DevOps OAuth code for Connector creation
            BodyKeySanitizers.Add(new BodyKeySanitizer("Sanitized") { JsonPath = "properties.authorization.code" });
        }

        [Test]
        [RecordedTest]
        public async Task CreateAzureDevOpsConnector()
        {
            var azureDevOpsConnectorCollection = (await DefaultSubscription.GetResourceGroupAsync(TestEnvironment.ResourceGroup)).Value.GetAzureDevOpsConnectors();

            var connectorName = Recording.GenerateAssetName("secdevops-ado");
            var connectorData = new AzureDevOpsConnectorData(TestEnvironment.Location)
            {
                // Requires getting an OAuth code for Azure DevOps and replacing here.
                // Each OAuth code will only work one time, so async version of test will require a separate code from sync version.
                // Code is sanitized from test recording so credential doesn't leak.
                Properties = new AzureDevOpsConnectorProperties(
                    null,
                    new AuthorizationInfo("AzureDevOpsOAuthCode", null),
                    new List<AzureDevOpsOrgMetadata>
                    {
                        new AzureDevOpsOrgMetadata(
                            "MyOrg",
                            AutoDiscovery.Disabled,
                            new List<AzureDevOpsProjectMetadata>
                            {
                                new AzureDevOpsProjectMetadata("MyProject", AutoDiscovery.Disabled, repos: new List<string> { "ARepo", "AnotherRepo" }, null)
                            }, null)
                    }, null)
            };

            var azureDevOpsConnector = (await azureDevOpsConnectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, connectorName, connectorData)).Value;

            Assert.IsNotNull(azureDevOpsConnector);
            Assert.AreEqual(ProvisioningState.Succeeded, azureDevOpsConnector.Data.Properties.ProvisioningState);
            Assert.AreEqual(connectorName, azureDevOpsConnector.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, azureDevOpsConnector.Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAzureDevOpsConnectors()
        {
            var connectors = await (await DefaultSubscription.GetResourceGroupAsync(TestEnvironment.ResourceGroup)).Value.GetAzureDevOpsConnectors().ToEnumerableAsync();
            Assert.IsNotNull(connectors);
            Assert.AreEqual(1, connectors.Count);

            var connector = connectors[0];
            Assert.AreEqual("secdevops-ado1830", connector.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, connector.Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAzureDevOpsConnector()
        {
            var subscriptionId = await Client.GetDefaultSubscriptionAsync();
            var adoConnectorId = AzureDevOpsConnectorResource.CreateResourceIdentifier(
                subscriptionId.Data.SubscriptionId,
                TestEnvironment.ResourceGroup,
                "secdevops-ado1830");

            AzureDevOpsConnectorResource azDevopsConnector = await Client.GetAzureDevOpsConnectorResource(adoConnectorId).GetAsync();

            Assert.IsNotNull(azDevopsConnector);
            Assert.AreEqual(adoConnectorId.Name, azDevopsConnector.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, azDevopsConnector.Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAzureDevOpsRepositories()
        {
            var subscriptionId = await Client.GetDefaultSubscriptionAsync();
            var adoConnectorId = AzureDevOpsConnectorResource.CreateResourceIdentifier(
                subscriptionId.Data.SubscriptionId,
                TestEnvironment.ResourceGroup,
                "secdevops-ado1830");

            AzureDevOpsConnectorResource azDevopsConnector = await Client.GetAzureDevOpsConnectorResource(adoConnectorId).GetAsync();

            var azureDevOpsRepos = await azDevopsConnector.GetAzureDevOpsReposByConnectorAsync().ToEnumerableAsync();

            Assert.AreEqual(2, azureDevOpsRepos.Count);
            Assert.AreEqual("ARepo", azureDevOpsRepos[0].Data.Name);
            Assert.AreEqual("AnotherRepo", azureDevOpsRepos[1].Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task DeleteAzureDevOpsConnector()
        {
            var subscriptionId = await Client.GetDefaultSubscriptionAsync();
            var adoConnectorId = AzureDevOpsConnectorResource.CreateResourceIdentifier(
                subscriptionId.Data.SubscriptionId,
                TestEnvironment.ResourceGroup,
                "secdevops-ado7012");

            // Get connector and verify it exists
            AzureDevOpsConnectorResource azDevopsConnector = await Client.GetAzureDevOpsConnectorResource(adoConnectorId).GetAsync();
            Assert.IsNotNull(azDevopsConnector);

            // Delete
            await azDevopsConnector.DeleteAsync(WaitUntil.Completed);

            // Verify it no longer exists
            try
            {
                azDevopsConnector = await Client.GetAzureDevOpsConnectorResource(adoConnectorId).GetAsync();
                Assert.Fail("Expected RequestFailedException, but Get request succeeded anyway.");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
                Assert.AreEqual("ResourceNotFound", e.ErrorCode);
            }
        }
    }
}
