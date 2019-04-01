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
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Xunit;

namespace OperationalInsights.Tests.Helpers
{
    public static class TestHelper
    {
        public const string ResourceGroupNameParameter = "resourceGroupName";
        public const string WorkspaceNameParameter = "workspaceName";
        public const string ParametersParameter = "parameters";
        public const string WorkspaceResourceType = "Microsoft.OperationalInsights/workspaces";
        public const string StorageInsightResourceType = "Microsoft.OperationalInsights/workspaces/storageinsightconfigs";
        public const string DataSourceResourceType = "Microsoft.OperationalInsights/workspaces/datasources";
        public const string LinkedServiceResourceType = "Microsoft.OperationalInsights/workspaces/linkedServices";

        /// <summary>
        /// Generate a Resource Management client from the test base to use for managing resource groups.
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourceManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        /// <summary>
        /// Generate an Operational Insights client from the test base to use for managing Operational Insights resources.
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>Operational Insights client</returns>
        public static OperationalInsightsManagementClient GetOperationalInsightsManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>();
        }

        /// <summary>
        /// Creates a resource group for use in Operational Insights tests
        /// </summary>
        /// <param name="resourceGroupName">Name to give the resource group</param>
        /// <param name="client">Resource management client</param>
        /// <param name="location">Location for the resource group</param>
        /// <returns>A resource group</returns>
        public static ResourceGroup CreateResourceGroup(string resourceGroupName, ResourceManagementClient client, string location = "Australia Southeast")
        {
            var resourceGroup = client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));

            Assert.NotNull(resourceGroup);
            Assert.Equal(resourceGroupName, resourceGroup.Name);
            Assert.Equal(location.Replace(" ", string.Empty), resourceGroup.Location, StringComparer.OrdinalIgnoreCase);

            return resourceGroup;
        }

        /// <summary>
        /// Delete a resourceGroup by name
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="client">Resource management client</param>
        public static void DeleteResourceGroup(string resourceGroupName, ResourceManagementClient client)
        {
            client.ResourceGroups.Delete(resourceGroupName);
        }

        /// <summary>
        /// Validates a workspace matches the expected properties.  Throws assertion exceptions if validation fails.
        /// </summary>
        /// <param name="expected">Expected workspace</param>
        /// <param name="actual">Actual workspace</param>
        internal static void ValidateWorkspace(Workspace expected, Workspace actual)
        {
            Assert.NotNull(actual);
            Assert.NotNull(actual.Id);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(WorkspaceResourceType, actual.Type);
            if (expected.RetentionInDays.HasValue)
            {
                Assert.Equal(expected.RetentionInDays, actual.RetentionInDays);
            }

            if (expected.Tags != null)
            {
                Assert.Equal(expected.Tags.Count, actual.Tags.Count);
                foreach (var tag in expected.Tags)
                {
                    Assert.True(actual.Tags.Contains(tag));
                }
            }
            else
            {
                Assert.Null(actual.Tags);
            }

            Assert.Equal(
                expected != null && expected.Sku != null ? expected.Sku.Name : SkuNameEnum.Free,
                actual.Sku.Name, 
                StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(actual.PortalUrl);
            Assert.Equal("Succeeded", actual.ProvisioningState, StringComparer.OrdinalIgnoreCase);
            Assert.Equal("Azure", actual.Source, StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(actual.CustomerId);
        }

        /// <summary>
        /// Validates a storage insight matches the expected properties.  Throws assertion exceptions if validation fails.
        /// </summary>
        /// <param name="expected">Expected data source</param>
        /// <param name="actual">Actual data source</param>
        internal static void ValidateDatasource(DataSource expected, DataSource actual)
        {
            Assert.NotNull(actual);
            Assert.NotNull(actual.Id);
            Assert.Equal(expected.Kind, actual.Kind);
            Assert.Equal(DataSourceResourceType, actual.Type);

            Assert.NotNull(actual.Properties);
        }

        /// <summary>
        /// Validates a linked service matches the expected properties. Throws assertion exceptions if validation fails.
        /// </summary>
        /// <param name="expected">Expected linked service</param>
        /// <param name="actual">Actual linked service</param>
        internal static void ValidateLinkedService(LinkedService expected, LinkedService actual)
        {
            Assert.NotNull(actual);
            Assert.NotNull(actual.Id);
            Assert.Equal(LinkedServiceResourceType.ToLower(), actual.Type.ToLower());

            Assert.Equal(expected.ResourceId.ToLower(), actual.ResourceId.ToLower());
        }

        /// <summary>
        /// Validates a storage insight matches the expected properties.  Throws assertion exceptions if validation fails.
        /// </summary>
        /// <param name="expected">Expected storage insight</param>
        /// <param name="actual">Actual storage insight</param>
        internal static void ValidateStorageInsight(StorageInsight expected, StorageInsight actual)
        {
            Assert.NotNull(actual);
            Assert.NotNull(actual.Id);
            Assert.Equal(StorageInsightResourceType, actual.Type);
            if (expected.Tags != null)
            {
                Assert.Equal(expected.Tags.Count, actual.Tags.Count);
                foreach (var tag in expected.Tags)
                {
                    Assert.True(actual.Tags.Contains(tag));
                }
            }
            else
            {
                Assert.Null(actual.Tags);
            }

            Assert.NotNull(actual);
            Assert.Equal("OK", actual.Status.State);
            Assert.Equal(expected.StorageAccount.Id, actual.StorageAccount.Id);
            Assert.Null(actual.StorageAccount.Key);

            if (expected.Containers != null)
            {
                Assert.Equal(expected.Containers.Count, actual.Containers.Count);
                foreach (var container in expected.Containers)
                {
                    Assert.Contains(container, actual.Containers);
                }
            }
            else
            {
                Assert.Empty(actual.Containers);
            }

            if (expected.Tables != null)
            {
                Assert.Equal(expected.Tables.Count, actual.Tables.Count);

                foreach (var table in expected.Tables)
                {
                    Assert.Contains(table, actual.Tables);
                }   
            }
            else
            {
                Assert.Empty(actual.Tables);
            }
        }

        internal static void VerifyCloudException(HttpStatusCode expectedStatusCode, Action testAction)
        {
            Assert.Throws<CloudException>(() =>
            {
                try
                {
                    testAction();
                }
                catch (CloudException ex)
                {
                    Assert.Equal(expectedStatusCode, ex.Response.StatusCode);
                    throw;
                }
            });
        }
    }
}