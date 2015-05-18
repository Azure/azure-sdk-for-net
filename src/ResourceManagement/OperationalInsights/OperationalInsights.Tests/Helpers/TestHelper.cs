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
using System.Net.Http;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace OperationalInsights.Tests.Helpers
{
    using System;
    using System.Linq;

    internal class TestHelper
    {
        public const string ResourceGroupNameParameter = "resourceGroupName";
        public const string WorkspaceNameParameter = "workspaceName";
        public const string ParametersParameter = "parameters";
        public const string WorkspaceResourceType = "Microsoft.OperationalInsights/workspaces";

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
    }
}