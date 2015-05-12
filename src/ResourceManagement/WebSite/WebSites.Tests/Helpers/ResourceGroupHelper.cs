//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Test;

namespace WebSites.Tests.Helpers
{
    public static class ResourceGroupHelper
    {

        public static WebSiteManagementClient GetWebSitesClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<WebSiteManagementClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        public static ResourceManagementClient GetResourcesClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        /// <summary>
        /// Get a default resource location for a given resource type
        /// </summary>
        /// <param name="client">The resource management client</param>
        /// <param name="resourceType">The type of resource to create</param>
        /// <returns>A location where this resource type is supported for the current subscription</returns>
        public static string GetResourceLocation(ResourceManagementClient client, string resourceType)
        {
            var supportedLocations = new HashSet<string>(new[] { "East Asia", "West US", "North Central US", "North Europe", "West Europe", "South Central US", "East US" }, StringComparer.OrdinalIgnoreCase);

            string location = null;
            string[] parts = resourceType.Split('/');
            string providerName = parts[0];
            var provider = client.Providers.Get(providerName);
            foreach (var resource in provider.Provider.ResourceTypes)
            {
                if (string.Equals(resource.Name, parts[1], StringComparison.OrdinalIgnoreCase))
                {
                    location = resource.Locations.FirstOrDefault(supportedLocations.Contains);
                }
            }

            return location;
        }
    }
}
