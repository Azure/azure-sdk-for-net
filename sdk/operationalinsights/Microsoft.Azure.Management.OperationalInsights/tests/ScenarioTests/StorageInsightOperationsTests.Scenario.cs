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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using OperationalInsights.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace OperationalInsights.Test.ScenarioTests
{
    public class StorageInsightOperationsTests : TestBase
    {
        private const string StorageAccountIdFormat = "/subscriptions/{0}/resourcegroups/{1}/providers/microsoft.storage/storageaccounts/{2}";

        [Fact]
        public void CanCreateUpdateDeleteStorageInsight()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = TestHelper.GetResourceManagementClient(this, context);
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                 string resourceGroupName = TestUtilities.GenerateName("OIAutoRest");
                 var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient, "East US");

                // Create a workspace that will house the storage insights
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

                // Create a storage insight
                string storageInsightName = TestUtilities.GenerateName("AzTestSI");
                string storageAccountName = TestUtilities.GenerateName("AzTestFakeSA");

                var storageInsight = new StorageInsight
                {
                    Tables = new[] { "WADWindowsEventLogsTable", "LinuxSyslogVer2v0" },
                    Containers = new[] { "wad-iis-logfiles" },
                    StorageAccount =
                        new StorageAccount
                        {
                            Id = string.Format(StorageAccountIdFormat, client.SubscriptionId, resourceGroupName, storageAccountName),
                            Key = "1234"
                        }
                };

                var createResponse = client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, storageInsightName, storageInsight);
                TestHelper.ValidateStorageInsight(storageInsight, createResponse);

                // Get the storage insight
                var getResponse = client.StorageInsights.Get(resourceGroupName, workspaceName, storageInsightName);
                TestHelper.ValidateStorageInsight(storageInsight, getResponse);

                // Create a second storage insight for list testing
                var storageInsightNameTwo = TestUtilities.GenerateName("AzTestSI");
                var storageInsightTwo = new StorageInsight
                {
                    Tables = new[] { "WADWindowsEventLogsTable", "LinuxSyslogVer2v0" },
                    Containers = null,
                    StorageAccount =
                        new StorageAccount
                        {
                            Id = string.Format(StorageAccountIdFormat, client.SubscriptionId, resourceGroupName, storageAccountName),
                            Key = "1234"
                        }
                };

                createResponse = client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, storageInsightNameTwo, storageInsightTwo);
                TestHelper.ValidateStorageInsight(storageInsightTwo, createResponse);

                // List the storage insights in the workspace
                var listResponse = client.StorageInsights.ListByWorkspace(resourceGroupName, workspaceName);
                Assert.Equal(2, listResponse.Count());
                Assert.Null(listResponse.NextPageLink);
                Assert.Single(listResponse.Where(w => w.Name.Equals(storageInsightName, StringComparison.OrdinalIgnoreCase)));
                Assert.Single(listResponse.Where(w => w.Name.Equals(storageInsightNameTwo, StringComparison.OrdinalIgnoreCase)));

                // Perform an update on one of the storage insights
                createResponse.StorageAccount.Key = "9876";
                createResponse.Tables = new[] { "WADWindowsEventLogsTable" };
                createResponse.Containers = new[] { "wad-iis-logfiles" };

                //var updateResponse = client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, storageInsightNameTwo, storageInsightTwo);
                var updateResponse = client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, storageInsightNameTwo, createResponse);

                storageInsightTwo.StorageAccount.Key = "9876";
                storageInsightTwo.Tables = new[] { "WADWindowsEventLogsTable" };
                storageInsightTwo.Containers = new[] { "wad-iis-logfiles" };
                TestHelper.ValidateStorageInsight(storageInsightTwo, updateResponse);

                // Delete a storage insight
                client.StorageInsights.Delete(resourceGroupName, workspaceName, storageInsightName);

                // Verify the storageinsight is gone
                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.StorageInsights.Get(resourceGroupName, workspaceName, storageInsightName));
            }
        }

        [Fact]
        public void StorageInsightCreateFailsWithoutWorkspace()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = TestHelper.GetResourceManagementClient(this, context);
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = TestUtilities.GenerateName("OIAutoRest");
                var resourceGroup = TestHelper.CreateResourceGroup(resourceGroupName, resourceClient);

                // Create a storage insight on a non-existent workspace
                string storageInsightName = TestUtilities.GenerateName("AzTestSI");
                string storageAccountName = TestUtilities.GenerateName("AzTestFakeSA");
                string workspaceName = TestUtilities.GenerateName("AzTest");
                var storageInsight = new StorageInsight
                {
                    StorageAccount =
                            new StorageAccount
                            {
                                Id = string.Format(StorageAccountIdFormat, client.SubscriptionId, resourceGroupName, storageAccountName),
                                Key = "1234"
                            }
                };

                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, 
                    () => client.StorageInsights.CreateOrUpdate(resourceGroupName, workspaceName, storageInsightName, storageInsight));
            }
        }
    }
}
