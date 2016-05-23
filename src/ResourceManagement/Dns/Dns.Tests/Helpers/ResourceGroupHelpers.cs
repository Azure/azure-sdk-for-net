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
using System.Linq;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Management.Dns.Testing
{
    public static class ResourceGroupHelper
    {
        public static DnsManagementClient GetDnsClient()
        {
            return TestBase.GetServiceClient<DnsManagementClient>(new CSMTestEnvironmentFactory());
        }

        public static ResourceManagementClient GetResourcesClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
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
                    location = resource.Locations.FirstOrDefault(loca => !string.IsNullOrEmpty(loca));
                }
            }

            return location;
        }

        public static ResourceGroupExtended CreateResourceGroup()
        {
            string resourceGroupName = TestUtilities.GenerateName("hydratestdnsrg");
            ResourceManagementClient resourcesClient = GetResourcesClient();

            // DNS resources are in location "global" but resource groups can't be in that same location
            string location = "Central US"; //ResourceGroupHelper.GetResourceLocation(resourcesClient, "microsoft.compute/locations");

            Assert.False(string.IsNullOrEmpty(location), "CSM did not return any valid locations for DNS resources");

            var response = resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                new ResourceGroup
                {
                    Location = location
                });

            return response.ResourceGroup;
        }

        public static ZoneCreateOrUpdateResponse CreateZone(DnsManagementClient dnsClient, string zoneName, string location, ResourceGroupExtended resourceGroup)
        {
            ZoneCreateOrUpdateResponse response = dnsClient.Zones.CreateOrUpdate(
                resourceGroup.Name,
                zoneName,
                ifMatch: null,
                ifNoneMatch: null,
                parameters: new ZoneCreateOrUpdateParameters
                    {
                        Zone = new Microsoft.Azure.Management.Dns.Models.Zone
                        {
                            Location = location,
                            Name = zoneName,
                            ETag = null,
                            Properties = new Microsoft.Azure.Management.Dns.Models.ZoneProperties
                            {
                            }
                        }
                    });

            return response;
        }
    }
}
