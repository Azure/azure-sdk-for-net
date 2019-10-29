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
using Microsoft.Rest.Azure.OData;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using OperationalInsights.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace OperationalInsights.Test.ScenarioTests
{
    public class DataSourceOperationsTests : TestBase
    {
        [Fact]
        public void CanCreateUpdateDeleteDataSource()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = TestHelper.GetResourceManagementClient(this, context);
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = TestUtilities.GenerateName("OIAutoRest");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a workspace that will house the data source
                string workspaceName = TestUtilities.GenerateName("AzTest");

                var workspace = new Workspace()
                {
                    Location = resourceGroup.Location,
                    Sku = new Sku(SkuNameEnum.Standard)
                };

                var workspaceResponse = client.Workspaces.CreateOrUpdate(
                    resourceGroupName,
                    workspaceName,
                    workspace);

                TestHelper.ValidateWorkspace(workspace, workspaceResponse);

                // Create a dataSource
                string dataSourceName = TestUtilities.GenerateName("AzTestDS");
                var createParameters = new DataSource
                {
                    Kind = "AzureAuditLog",
                    Properties = JToken.Parse("{\"LinkedResourceId\":\"/subscriptions/0b88dfdb-55b3-4fb0-b474-5b6dcbe6b2ef/providers/microsoft.insights/eventtypes/management\"}")
                };

                var createResponse = client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, dataSourceName, createParameters);
                TestHelper.ValidateDatasource(createParameters, createResponse);

                // Get the data source
                var getResponse = client.DataSources.Get(resourceGroupName, workspaceName, dataSourceName);
                TestHelper.ValidateDatasource(createParameters, getResponse);

                // Create a second data source for list testing
                var dataSourceNameTwo = TestUtilities.GenerateName("AzTestDS");
                //createParameters.Name = dataSourceNameTwo;
                createParameters.Properties = JToken.Parse("{'LinkedResourceId':'/subscriptions/a6383be3-f0e8-4968-93d5-10f2625f5bb5/providers/microsoft.insights/eventtypes/management'}");
                createResponse = client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, dataSourceNameTwo, createParameters);
                TestHelper.ValidateDatasource(createParameters, createResponse);

                // List the data sources in the workspace
                var listResponse = client.DataSources.ListByWorkspace(new ODataQuery<DataSourceFilter>(ds=> ds.Kind == "AzureAuditLog" ), resourceGroupName, workspaceName);
                Assert.Equal(2, listResponse.Count());
                Assert.Null(listResponse.NextPageLink);
                Assert.Single(listResponse.Where(w => w.Name.Equals(dataSourceName, StringComparison.OrdinalIgnoreCase)));
                Assert.Single(listResponse.Where(w => w.Name.Equals(dataSourceNameTwo, StringComparison.OrdinalIgnoreCase)));

                // Perform an update on one of the data sources
                createResponse.Properties = JToken.Parse("{'LinkedResourceId':'/subscriptions/1b51d7a0-d97f-456f-914e-18cdcbedf1ce/providers/microsoft.insights/eventtypes/management'}");
                //createResponse.Name = dataSourceNameTwo;
                var updateResponse = client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, createResponse.Name, createResponse);
                TestHelper.ValidateDatasource(createResponse, updateResponse);

                // Delete a data source
                client.DataSources.Delete(resourceGroupName, workspaceName, dataSourceName);

                // Verify the data source is gone
                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.DataSources.Get(resourceGroupName, workspaceName, dataSourceName));
            }
        }

        [Fact]
        public void CanPageThroughDataSourceList()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = TestHelper.GetResourceManagementClient(this, context);
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = TestUtilities.GenerateName("OIAutoRest");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a workspace that will house the data source
                string workspaceName = TestUtilities.GenerateName("AzTest");

                var workspace = new Workspace()
                {
                    Location = resourceGroup.Location,
                    Sku = new Sku(SkuNameEnum.Standard)
                };

                var workspaceResponse = client.Workspaces.CreateOrUpdate(
                    resourceGroupName,
                    workspaceName,
                    workspace);

                TestHelper.ValidateWorkspace(workspace, workspaceResponse);

                // Create 200+ dataSource
                for (int i = 0; i < 300; i++)
                {
                    string windowsEventDataSourceName = TestUtilities.GenerateName("AzTestDSWE");
                    var createParameters = new DataSource
                    {
                        Kind = DataSourceKind.WindowsEvent,
                        Properties = JToken.Parse("{\"eventLogName\": \"" + ("windowsEvent" + i) + "\", \"eventTypes\": [{\"eventType\": \"Error\"}]}")
                    };

                    var createResponse = client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, windowsEventDataSourceName, createParameters);
                    TestHelper.ValidateDatasource(createParameters, createResponse);
                }

                // List the data sources in the workspace
                var listResponse = client.DataSources.ListByWorkspace(new ODataQuery<DataSourceFilter>(ds => ds.Kind == "WindowsEvent"), resourceGroupName, workspaceName);
                Assert.Equal(200, listResponse.Count());
                Assert.NotNull(listResponse.NextPageLink);

                // Get the next page
                var listResponseNextPage = client.DataSources.ListByWorkspaceNext(listResponse.NextPageLink);
                Assert.Null(listResponseNextPage.NextPageLink);
                Assert.Equal(100, listResponseNextPage.Count());
            }
        }

        [Fact]
        public void DataSourceCreateFailsWithoutWorkspace()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = TestHelper.GetResourceManagementClient(this, context);
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = TestUtilities.GenerateName("OIAutoRest");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a data source on a non-existent workspace
                string dataSourceName = TestUtilities.GenerateName("AzTestDS");
                string workspaceName = TestUtilities.GenerateName("AzTest");

                var createParameters = new DataSource
                {
                    Kind = "AzureAuditLog",
                    Properties = JToken.Parse("{'LinkedResourceId':'/subscriptions/a6383be3-f0e8-4968-93d5-10f2625f5bb5/providers/microsoft.insights/eventtypes/management'}")
                };

                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.DataSources.CreateOrUpdate(resourceGroupName, workspaceName, dataSourceName, createParameters));
            }
        }
    }
}