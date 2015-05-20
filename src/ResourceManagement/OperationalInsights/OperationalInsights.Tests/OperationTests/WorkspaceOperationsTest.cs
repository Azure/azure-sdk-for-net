// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Azure.Test;
using OperationalInsights.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace OperationalInsights.Tests.OperationTests
{
    public class WorkspaceOperationsTest : TestBase
    {
        [Fact]
        public void CanCreateListDeleteWorkspace()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                string resourceGroupName = TestUtilities.GenerateName("OIHyak");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a workspace
                string workspaceName = TestUtilities.GenerateName("AzTest");
                var workspaceCreateParameters = new WorkspaceCreateOrUpdateParameters
                {
                    Workspace =
                        new Workspace
                        {
                            Name = workspaceName,
                            Location = resourceGroup.Location,
                            Tags = new Dictionary<string, string> { { "tag1", "val1" } },
                            Properties = new WorkspaceProperties { Sku = new Sku(SkuNameEnum.Free) }
                        }
                };

                var createResponse = client.Workspaces.CreateOrUpdate(resourceGroupName, workspaceCreateParameters);
                Assert.True(HttpStatusCode.Created == createResponse.StatusCode || HttpStatusCode.OK == createResponse.StatusCode);
                TestHelper.ValidateWorkspace(workspaceCreateParameters.Workspace, createResponse.Workspace);

                // Get the workspace
                var getResponse = client.Workspaces.Get(resourceGroupName, workspaceName);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                TestHelper.ValidateWorkspace(workspaceCreateParameters.Workspace, getResponse.Workspace);

                // Create a second workspace for list testing
                var workspaceNameTwo = TestUtilities.GenerateName("AzTest");
                workspaceCreateParameters.Workspace.Name = workspaceNameTwo;
                createResponse = client.Workspaces.CreateOrUpdate(resourceGroupName, workspaceCreateParameters);
                Assert.True(HttpStatusCode.Created == createResponse.StatusCode || HttpStatusCode.OK == createResponse.StatusCode);
                TestHelper.ValidateWorkspace(workspaceCreateParameters.Workspace, createResponse.Workspace);

                // List the workspace in the subscription
                var listResponse = client.Workspaces.ListInSubscription();
                Assert.True(HttpStatusCode.OK == listResponse.StatusCode);
                Assert.Equal(2, listResponse.Workspaces.Count);
                Assert.Null(listResponse.NextLink);
                Assert.Single(listResponse.Workspaces.Where(w => w.Name.Equals(workspaceName, StringComparison.OrdinalIgnoreCase)));
                Assert.Single(listResponse.Workspaces.Where(w => w.Name.Equals(workspaceNameTwo, StringComparison.OrdinalIgnoreCase)));

                // List the workspace in the resource group
                listResponse = client.Workspaces.ListInResourceGroup(resourceGroupName);
                Assert.True(HttpStatusCode.OK == listResponse.StatusCode);
                Assert.Equal(2, listResponse.Workspaces.Count);
                Assert.Null(listResponse.NextLink);
                Assert.Single(listResponse.Workspaces.Where(w => w.Name.Equals(workspaceName, StringComparison.OrdinalIgnoreCase)));
                Assert.Single(listResponse.Workspaces.Where(w => w.Name.Equals(workspaceNameTwo, StringComparison.OrdinalIgnoreCase)));

                // Perform an update on one of the workspaces
                createResponse.Workspace.Properties.Sku.Name = SkuNameEnum.Premium;
                var workspaceUpdateParameters = new WorkspaceCreateOrUpdateParameters { Workspace = createResponse.Workspace };
                var updateResponse = client.Workspaces.CreateOrUpdate(resourceGroupName, workspaceUpdateParameters);
                Assert.True(HttpStatusCode.OK == updateResponse.StatusCode);
                TestHelper.ValidateWorkspace(workspaceUpdateParameters.Workspace, updateResponse.Workspace);

                // Delete a workspace
                var deleteResponse = client.Workspaces.Delete(resourceGroupName, workspaceName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // Verify the workspace is gone
                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.Workspaces.Get(resourceGroupName, workspaceName));
            }
        }

        [Fact]
        public void CanPerformWorkspaceActions()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                string resourceGroupName = TestUtilities.GenerateName("OIHyak");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Query link targets for an identity
                var linkTargetsResponse = client.Workspaces.ListLinkTargets();
                Assert.True(HttpStatusCode.OK == linkTargetsResponse.StatusCode);
                Assert.Equal(0, linkTargetsResponse.Accounts.Count);

                // Attempt to link a workspace to an invalid account
                string workspaceName = TestUtilities.GenerateName("AzTest");
                var workspaceCreateParameters = new WorkspaceCreateOrUpdateParameters
                {
                    Workspace =
                        new Workspace
                        {
                            Name = workspaceName,
                            Location = resourceGroup.Location,
                            Properties = new WorkspaceProperties {  CustomerId = Guid.NewGuid() }
                        }
                };

                TestHelper.VerifyCloudException(HttpStatusCode.BadRequest, () => client.Workspaces.CreateOrUpdate(resourceGroupName, workspaceCreateParameters));

                // Create a real workspace
                workspaceCreateParameters.Workspace.Properties = null;
                var createResponse = client.Workspaces.CreateOrUpdate(resourceGroupName, workspaceCreateParameters);
                Assert.True(HttpStatusCode.Created == createResponse.StatusCode || HttpStatusCode.OK == createResponse.StatusCode);
                TestHelper.ValidateWorkspace(workspaceCreateParameters.Workspace, createResponse.Workspace);

                // Get the shared keys for a workspace
                var getKeysResponse = client.Workspaces.GetSharedKeys(resourceGroupName, workspaceName);
                Assert.True(HttpStatusCode.OK == getKeysResponse.StatusCode);
                Assert.NotNull(getKeysResponse.Keys.PrimarySharedKey);
                Assert.NotNull(getKeysResponse.Keys.SecondarySharedKey);

                // List the management groups connected to the workspace
                var managementGroupsResponse = client.Workspaces.ListManagementGroups(resourceGroupName, workspaceName);
                Assert.True(HttpStatusCode.OK == managementGroupsResponse.StatusCode);
                Assert.Null(managementGroupsResponse.NextLink);
                Assert.Equal(0, managementGroupsResponse.ManagementGroups.Count);

                // List the usage for a workspace
                var usagesResponse = client.Workspaces.ListUsages(resourceGroupName, workspaceName);
                Assert.True(HttpStatusCode.OK == usagesResponse.StatusCode);
                Assert.Equal(1, usagesResponse.UsageMetrics.Count);
                
                var metric = usagesResponse.UsageMetrics.Single();
                Assert.Equal("DataAnalyzed", metric.Name.Value);
                Assert.NotNull(metric.NextResetTime);
                Assert.Equal("Bytes", metric.Unit);
                Assert.Equal("P1D", metric.QuotaPeriod);
            }
        }
    }
}
