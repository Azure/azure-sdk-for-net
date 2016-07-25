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
using System.Linq;
using System.Net;
using Xunit;

namespace OperationalInsights.Tests.OperationTests
{
    public class DataSourceOperationsTest : TestBase
    {
        [Fact]
        public void CanCreateUpdateDeleteDataSource()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                string resourceGroupName = TestUtilities.GenerateName("OIHyak");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a workspace that will house the data source
                string workspaceName = TestUtilities.GenerateName("AzTest");
                var workspaceCreateParameters = new WorkspaceCreateOrUpdateParameters
                {
                    Workspace =
                        new Workspace
                        {
                            Name = workspaceName,
                            Location = resourceGroup.Location
                        }
                };

                var workspaceCreateResponse = client.Workspaces.CreateOrUpdate(resourceGroupName, workspaceCreateParameters);
                Assert.True(HttpStatusCode.Created == workspaceCreateResponse.StatusCode || HttpStatusCode.OK == workspaceCreateResponse.StatusCode);

                // Create a dataSource
                string dataSourceName = TestUtilities.GenerateName("AzTestDS");
                var createParameters = new DataSourceCreateOrUpdateParameters
                {
                    DataSource = new DataSource
                    {
                        Name = dataSourceName,
                        Kind = "AzureAuditLog",
                        Properties = "{'LinkedResourceId':'/subscriptions/0b88dfdb-55b3-4fb0-b474-5b6dcbe6b2ef/providers/microsoft.insights/eventtypes/management'}"
                    }
                };
                var createResponse = client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, createParameters);
                Assert.True(HttpStatusCode.Created == createResponse.StatusCode || HttpStatusCode.OK == createResponse.StatusCode);
                TestHelper.ValidateDatasource(createParameters.DataSource, createResponse.DataSource);

                // Get the data source
                var getResponse = client.DataSources.Get(resourceGroupName, workspaceName, dataSourceName);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                TestHelper.ValidateDatasource(createParameters.DataSource, getResponse.DataSource);

                // Create a second data source for list testing
                var dataSourceNameTwo = TestUtilities.GenerateName("AzTestDS");
                createParameters.DataSource.Name = dataSourceNameTwo;
                createParameters.DataSource.Properties = "{'LinkedResourceId':'/subscriptions/a6383be3-f0e8-4968-93d5-10f2625f5bb5/providers/microsoft.insights/eventtypes/management'}";
                createResponse = client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, createParameters);
                Assert.True(HttpStatusCode.Created == createResponse.StatusCode || HttpStatusCode.OK == createResponse.StatusCode);
                TestHelper.ValidateDatasource(createParameters.DataSource, createResponse.DataSource);

                // List the data sources in the workspace
                var listResponse = client.DataSources.ListInWorkspace(resourceGroupName, workspaceName, "AzureAuditLog", string.Empty);
                Assert.True(HttpStatusCode.OK == listResponse.StatusCode);
                Assert.Equal(2, listResponse.DataSources.Count);
                Assert.Null(listResponse.NextLink);
                Assert.Single(listResponse.DataSources.Where(w => w.Name.Equals(dataSourceName, StringComparison.OrdinalIgnoreCase)));
                Assert.Single(listResponse.DataSources.Where(w => w.Name.Equals(dataSourceNameTwo, StringComparison.OrdinalIgnoreCase)));

                // Perform an update on one of the data sources
                createResponse.DataSource.Properties= "{'LinkedResourceId':'/subscriptions/bc8edd8f-a09f-499d-978d-6b5ed2f84852/providers/microsoft.insights/eventtypes/management'}";
                createResponse.DataSource.Name = dataSourceNameTwo;
                var updateParameters = new DataSourceCreateOrUpdateParameters { DataSource= createResponse.DataSource };
                var updateResponse = client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, updateParameters);
                Assert.True(HttpStatusCode.OK == updateResponse.StatusCode);
                TestHelper.ValidateDatasource(updateParameters.DataSource, updateResponse.DataSource);

                // Delete a data source
                var deleteResponse = client.DataSources.Delete(resourceGroupName, workspaceName, dataSourceName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // Verify the data source is gone
                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.DataSources.Get(resourceGroupName, workspaceName, dataSourceName));
            }
        }

        [Fact]
        public void DataSourceCreateFailsWithoutWorkspace()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                string resourceGroupName = TestUtilities.GenerateName("OIHyak");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a data source on a non-existent workspace
                string dataSourceName = TestUtilities.GenerateName("AzTestDS");
                string workspaceName = TestUtilities.GenerateName("AzTest");
                var createParameters = new DataSourceCreateOrUpdateParameters
                {
                    DataSource = new DataSource
                    {
                        Name = dataSourceName,
                        Kind = "AzureAuditLog",
                        Properties = "{'LinkedResourceId':'/subscriptions/bc8edd8f-a09f-499d-978d-6b5ed2f84852/providers/microsoft.insights/eventtypes/management'}"
                    }
                };

                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, createParameters));
            }
        }
    }
}
