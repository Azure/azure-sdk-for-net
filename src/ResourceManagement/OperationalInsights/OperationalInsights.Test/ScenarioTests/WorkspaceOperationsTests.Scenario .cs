using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.OperationalInsights.Models;
using OperationalInsights.Tests.Helpers;
using System.Net;

namespace OperationalInsights.Test.ScenarioTests
{
    public class WorkspaceOperationsTests : TestBase
    {
        [Fact]
        public void CanCreateListDeleteWorkspace()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var resourceClient = TestHelper.GetResourceManagementClient(this, context);
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = TestUtilities.GenerateName("OIAutoRest");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                string workspaceName = TestUtilities.GenerateName("AzTest");
                var workspace = new Workspace()
                {
                    Name = workspaceName,
                    Location = resourceGroup.Location,
                    Tags = new Dictionary<string, string> { { "tag1", "val1" } },
                    Sku = new Sku(SkuNameEnum.PerNode),
                    RetentionInDays = 30
                };

                var workspaceResponse = client.Workspaces.CreateOrUpdate(
                    resourceGroupName,
                    workspaceName,
                    workspace);

                TestHelper.ValidateWorkspace(workspace, workspaceResponse);
            }
        }

        [Fact]
        public void CanPerformWorkspaceActions()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var resourceClient = TestHelper.GetResourceManagementClient(this, context);
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = TestUtilities.GenerateName("OIAutoRest");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Query link targets for an identity
                var linkTargetsResponse = client.Workspaces.ListLinkTargets();
                Assert.Equal(0, linkTargetsResponse.Count);

                // Attempt to link a workspace to an invalid account
                string workspaceName = TestUtilities.GenerateName("AzTest");

                var workspace = new Workspace()
                {
                    Name = workspaceName,
                    Location = resourceGroup.Location,
                    CustomerId = Guid.NewGuid().ToString(),
                };

                TestHelper.VerifyCloudException(
                    HttpStatusCode.BadRequest,
                    () => client.Workspaces.CreateOrUpdate(resourceGroupName, workspaceName, workspace));

                // Create a real workspace
                workspace = new Workspace()
                {
                    Name = workspaceName,
                    Location = resourceGroup.Location,
                    Sku = new Sku(SkuNameEnum.Free)
                };

                var workspaceResponse = client.Workspaces.CreateOrUpdate(
                    resourceGroupName,
                    workspaceName,
                    workspace);
                TestHelper.ValidateWorkspace(workspace, workspaceResponse);

                // Get the shared keys for a workspace
                var getKeysResponse = client.Workspaces.GetSharedKeys(resourceGroupName, workspaceName);
                Assert.NotNull(getKeysResponse.PrimarySharedKey);
                Assert.NotNull(getKeysResponse.SecondarySharedKey);

                // List the management groups connected to the workspace
                var managementGroupsResponse = client.Workspaces.ListManagementGroups(resourceGroupName, workspaceName);
                Assert.Equal(0, managementGroupsResponse.Value.Count());

                // List the usage for a workspace
                var usagesResponse = client.Workspaces.ListUsages(resourceGroupName, workspaceName);
                Assert.Equal(1, usagesResponse.Count());

                var metric = usagesResponse.Single();
                Assert.Equal("DataAnalyzed", metric.Name.Value);
                Assert.NotNull(metric.NextResetTime);
                Assert.Equal("Bytes", metric.Unit);
                Assert.Equal("P1D", metric.QuotaPeriod);
            }
        }

        [Fact]
        public async void CanEnableDisableListIntelligencePacks()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var resourceClient = TestHelper.GetResourceManagementClient(this, context);
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = TestUtilities.GenerateName("OIAutoRest");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // create a test workspace
                string workspaceName = TestUtilities.GenerateName("AzTest");
                var workspace = new Workspace()
                {
                    Name = workspaceName,
                    Location = resourceGroup.Location,
                    Tags = new Dictionary<string, string> { { "tag1", "val1" } },
                    Sku = new Sku(SkuNameEnum.PerNode),
                    RetentionInDays = 30
                };

                var workspaceResponse = client.Workspaces.CreateOrUpdate(
                    resourceGroupName,
                    workspaceName,
                    workspace);
                TestHelper.ValidateWorkspace(workspace, workspaceResponse);

                // Enable an intelligence pack
                await client.Workspaces.EnableIntelligencePackAsync(
                    resourceGroupName,
                    workspaceName,
                    "ChangeTracking");
                await client.Workspaces.EnableIntelligencePackAsync(
                    resourceGroupName,
                    workspaceName,
                    "SiteRecovery");

                var listResponse = client.Workspaces.ListIntelligencePacks(resourceGroupName, workspaceName);
                Assert.NotNull(listResponse);

                foreach (var ip in listResponse)
                {
                    if (ip.Name.Equals("ChangeTracking"))
                    {
                        Assert.True(ip.Enabled);
                    }
                    else if (ip.Name.Equals("SiteRecovery"))
                    {
                        Assert.True(ip.Enabled);
                    }
                    else if (ip.Name.Equals("LogManagement"))
                    {
                        Assert.True(ip.Enabled);
                    }
                    else
                    {
                        Assert.False(ip.Enabled);
                    }
                }

                // Disable an intelligence pack
                await client.Workspaces.DisableIntelligencePackAsync(
                    resourceGroupName,
                    workspaceName,
                    "ChangeTracking");

                await client.Workspaces.DisableIntelligencePackAsync(
                    resourceGroupName,
                    workspaceName,
                    "SiteRecovery");

                listResponse = client.Workspaces.ListIntelligencePacks(resourceGroupName, workspaceName);
                Assert.NotNull(listResponse);

                foreach (var ip in listResponse)
                {
                    if (ip.Name.Equals("ChangeTracking"))
                    {
                        Assert.False(ip.Enabled);
                    }
                    else if (ip.Name.Equals("SiteRecovery"))
                    {
                        Assert.False(ip.Enabled);
                    }
                    else if (ip.Name.Equals("LogManagement"))
                    {
                        Assert.True(ip.Enabled);
                    }
                    else
                    {
                        Assert.False(ip.Enabled);
                    }
                }
            }
        }
    }
}

