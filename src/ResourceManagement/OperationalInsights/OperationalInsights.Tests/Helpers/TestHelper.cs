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

using Hyak.Common;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace OperationalInsights.Tests.Helpers
{
    internal class TestHelper
    {
        public const string ResourceGroupNameParameter = "resourceGroupName";
        public const string WorkspaceNameParameter = "workspaceName";
        public const string ParametersParameter = "parameters";
        public const string WorkspaceResourceType = "Microsoft.OperationalInsights/workspaces";
        public const string StorageInsightResourceType = "Microsoft.OperationalInsights/storageinsightconfigs";

        /// <summary>
        /// Generate a Resource Management client from the test base to use for managing resource groups.
        /// </summary>
        /// <returns>Resource Management client</returns>
        public static ResourceManagementClient GetResourceClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<ResourceManagementClient>(factory).WithHandler(handler);
        }

        /// <summary>
        /// Generate an Operational Insights client from the test base to use for managing Operational Insights resources.
        /// </summary>
        /// <returns>Operational Insights client</returns>
        public static OperationalInsightsManagementClient GetOperationalInsightsManagementClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<OperationalInsightsManagementClient>(factory).WithHandler(handler);
        }

        /// <summary>
        /// Gets a valid location for the operational insights resource provider
        /// </summary>
        /// <param name="client">Resource management client</param>
        /// <returns>A location name (i.e. 'East US')</returns>
        public static string GetOperationalInsightsLocation(ResourceManagementClient client)
        {
            return GetResourceLocation(client, WorkspaceResourceType);
        }

        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(ResourceManagementClient client, string resourceType)
        {
            string location = null;
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.Provider.ResourceTypes)
            {
                if (string.Equals(resource.Name, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.LastOrDefault<string>();
                }
            }

            return location;
        }

        /// <summary>
        /// Creates a resource group for use in Operational Insights tests
        /// </summary>
        /// <param name="resourceGroupName">Name to give the resource group</param>
        /// <param name="client">Resource management client</param>
        /// <returns>A resource group</returns>
        public static ResourceGroup CreateResourceGroup(string resourceGroupName, ResourceManagementClient client)
        {
            string location = GetOperationalInsightsLocation(client);
            var resourceGroupCreateResult = client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));

            Assert.True(resourceGroupCreateResult.StatusCode == HttpStatusCode.OK || resourceGroupCreateResult.StatusCode == HttpStatusCode.Created);
            Assert.NotNull(resourceGroupCreateResult.ResourceGroup);
            Assert.Equal(resourceGroupName, resourceGroupCreateResult.ResourceGroup.Name);
            Assert.Equal(location.Replace(" ", string.Empty), resourceGroupCreateResult.ResourceGroup.Location, StringComparer.OrdinalIgnoreCase);

            return resourceGroupCreateResult.ResourceGroup;
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
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(WorkspaceResourceType, actual.Type);
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

            Assert.NotNull(actual.Properties);

            var workspaceProperties = actual.Properties;
            Assert.Equal(
                expected.Properties != null && expected.Properties.Sku != null ? expected.Properties.Sku.Name : SkuNameEnum.Free,
                workspaceProperties.Sku.Name, 
                StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(workspaceProperties.PortalUrl);
            Assert.Equal("Succeeded", workspaceProperties.ProvisioningState, StringComparer.OrdinalIgnoreCase);
            Assert.Equal("Azure", workspaceProperties.Source, StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(workspaceProperties.CustomerId);
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
            Assert.Equal(expected.Name, actual.Name);
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

            Assert.NotNull(actual.Properties);
            Assert.Equal("OK", actual.Properties.Status.State);
            Assert.Equal(expected.Properties.StorageAccount.Id, actual.Properties.StorageAccount.Id);
            Assert.Null(actual.Properties.StorageAccount.Key);

            if (expected.Properties.Containers != null)
            {
                Assert.Equal(expected.Properties.Containers.Count, actual.Properties.Containers.Count);
                foreach (var container in expected.Properties.Containers)
                {
                    Assert.Contains(container, actual.Properties.Containers);
                }
            }
            else
            {
                Assert.Empty(actual.Properties.Containers);
            }

            if (expected.Properties.Tables != null)
            {
                Assert.Equal(expected.Properties.Tables.Count, actual.Properties.Tables.Count);

                foreach (var table in expected.Properties.Tables)
                {
                    Assert.Contains(table, actual.Properties.Tables);
                }   
            }
            else
            {
                Assert.Empty(actual.Properties.Tables);
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