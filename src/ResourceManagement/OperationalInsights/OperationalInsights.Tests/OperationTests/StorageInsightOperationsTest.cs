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
    public class StorageInsightOperationsTest : TestBase
    {
        private const string StorageAccountIdFormat = "/subscriptions/{0}/resourcegroups/{1}/providers/microsoft.storage/storageaccounts/{2}";

        [Fact]
        public void CanCreateUpdateDeleteStorageInsight()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                string resourceGroupName = TestUtilities.GenerateName("OIHyak");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a workspace that will house the storage insights
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

                // Create a storage insight
                string storageInsightName = TestUtilities.GenerateName("AzTestSI");
                string storageAccountName = TestUtilities.GenerateName("AzTestFakeSA");
                var createParameters = new StorageInsightCreateOrUpdateParameters
                {
                    StorageInsight = new StorageInsight
                    {
                        Location = resourceGroup.Location,
                        Name = storageInsightName,
                        Properties = new StorageInsightProperties
                        {
                            Tables = new[] { "WADWindowsEventLogsTable", "LinuxSyslogVer2v0" },
                            Containers = new[] { "wad-iis-logfiles" },
                            StorageAccount =
                                new StorageAccount
                                {
                                    Id = string.Format(StorageAccountIdFormat, client.Credentials.SubscriptionId, resourceGroupName, storageAccountName),
                                    Key = "1234"
                                }
                        }
                    }
                };
                var createResponse = client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, createParameters);
                Assert.True(HttpStatusCode.Created == createResponse.StatusCode || HttpStatusCode.OK == createResponse.StatusCode);
                TestHelper.ValidateStorageInsight(createParameters.StorageInsight, createResponse.StorageInsight);

                // Get the storage insight
                var getResponse = client.StorageInsights.Get(resourceGroupName, workspaceName, storageInsightName);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                TestHelper.ValidateStorageInsight(createParameters.StorageInsight, getResponse.StorageInsight);

                // Create a second storage insight for list testing
                var storageInsightNameTwo = TestUtilities.GenerateName("AzTestSI");
                createParameters.StorageInsight.Name = storageInsightNameTwo;
                createParameters.StorageInsight.Properties.Containers = null;
                createResponse = client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, createParameters);
                Assert.True(HttpStatusCode.Created == createResponse.StatusCode || HttpStatusCode.OK == createResponse.StatusCode);
                TestHelper.ValidateStorageInsight(createParameters.StorageInsight, createResponse.StorageInsight);

                // List the storage insights in the workspace
                var listResponse = client.StorageInsights.ListInWorkspace(resourceGroupName, workspaceName);
                Assert.True(HttpStatusCode.OK == listResponse.StatusCode);
                Assert.Equal(2, listResponse.StorageInsights.Count);
                Assert.Null(listResponse.NextLink);
                Assert.Single(listResponse.StorageInsights.Where(w => w.Name.Equals(storageInsightName, StringComparison.OrdinalIgnoreCase)));
                Assert.Single(listResponse.StorageInsights.Where(w => w.Name.Equals(storageInsightNameTwo, StringComparison.OrdinalIgnoreCase)));

                // Perform an update on one of the storage insights
                createResponse.StorageInsight.Properties.StorageAccount.Key = "9876";
                createResponse.StorageInsight.Properties.Tables = new[] { "WADWindowsEventLogsTable" };
                createResponse.StorageInsight.Properties.Containers = new[] { "wad-iis-logfiles" };
                var updateParameters = new StorageInsightCreateOrUpdateParameters { StorageInsight= createResponse.StorageInsight };
                var updateResponse = client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, updateParameters);
                Assert.True(HttpStatusCode.OK == updateResponse.StatusCode);
                TestHelper.ValidateStorageInsight(updateParameters.StorageInsight, updateResponse.StorageInsight);

                // Delete a storage insight
                var deleteResponse = client.StorageInsights.Delete(resourceGroupName, workspaceName, storageInsightName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // Verify the storageinsight is gone
                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.StorageInsights.Get(resourceGroupName, workspaceName, storageInsightName));
            }
        }

        [Fact]
        public void StorageInsightCreateFailsWithoutWorkspace()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                string resourceGroupName = TestUtilities.GenerateName("OIHyak");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a storage insight on a non-existent workspace
                string storageInsightName = TestUtilities.GenerateName("AzTestSI");
                string storageAccountName = TestUtilities.GenerateName("AzTestFakeSA");
                string workspaceName = TestUtilities.GenerateName("AzTest");
                var createParameters = new StorageInsightCreateOrUpdateParameters
                {
                    StorageInsight = new StorageInsight
                    {
                        Location = resourceGroup.Location,
                        Name = storageInsightName,
                        Properties = new StorageInsightProperties
                        {
                            StorageAccount =
                                new StorageAccount
                                {
                                    Id = string.Format(StorageAccountIdFormat, client.Credentials.SubscriptionId, resourceGroupName, storageAccountName),
                                    Key = "1234"
                                }
                        }
                    }
                };

                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, createParameters));
            }
        }
    }
}
