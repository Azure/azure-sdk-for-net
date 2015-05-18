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

using System.Net;
using OperationalInsights.Tests.Helpers;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace OperationalInsights.Tests.OperationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.OperationalInsights;

    public class JobOperationsTest : TestBase
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
                Assert.NotNull(createResponse.Workspace);
                Assert.Equal(workspaceName, createResponse.Workspace.Name);
                Assert.Equal(resourceGroup.Location, createResponse.Workspace.Location);
                Assert.Equal("tag1", createResponse.Workspace.Tags.Keys.Single());
                Assert.Equal("val1", createResponse.Workspace.Tags["tag1"]);
                Assert.Equal(TestHelper.WorkspaceResourceType, createResponse.Workspace.Type);
                Assert.NotNull(createResponse.Workspace.Properties);

                var workspaceProperties = createResponse.Workspace.Properties;
                Assert.Equal(SkuNameEnum.Free, workspaceProperties.Sku.Name, StringComparer.OrdinalIgnoreCase);
                Assert.NotNull(workspaceProperties.PortalUrl);
                Assert.Equal("Succeeded", workspaceProperties.ProvisioningState, StringComparer.OrdinalIgnoreCase);
                Assert.Equal("Azure", workspaceProperties.Source, StringComparer.OrdinalIgnoreCase);
                Assert.NotNull(workspaceProperties.CustomerId);
            }
        }
    }
}
