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
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Management.TrafficManager.Testing.Helpers
{
    using Microsoft.Azure.Management.TrafficManager.Models;

    public static class TrafficManagerHelper
    {
        public static TrafficManagerManagementClient GetTrafficManagerClient()
        {
            return TestBase.GetServiceClient<TrafficManagerManagementClient>(new CSMTestEnvironmentFactory());
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

        public static Profile BuildProfile(string id, string name, string type, string location, Dictionary<string, string> tags, string profileStatus, string trafficRoutingMethod, DnsConfig dnsConfig, MonitorConfig monitorConfig, Endpoint[] endpoints)
        {
            return new Microsoft.Azure.Management.TrafficManager.Models.Profile
            {
                Id = id,
                Name = name,
                Type = type,
                Location = location,
                Tags = tags,
                Properties = new Microsoft.Azure.Management.TrafficManager.Models.ProfileProperties
                {
                    ProfileStatus = profileStatus,
                    TrafficRoutingMethod = trafficRoutingMethod,
                    DnsConfig = dnsConfig,
                    MonitorConfig = monitorConfig,
                    Endpoints = endpoints
                }
            };
        }

        public static Profile GenerateDefaultProfile(string profileName, string relativeName = null)
        {
            return TrafficManagerHelper.BuildProfile(
                id: null,
                name: profileName,
                type: "microsoft.network/trafficmanagerprofiles",
                location: "global",
                tags: null,
                profileStatus: "Enabled",
                trafficRoutingMethod: "Performance",
                dnsConfig: new DnsConfig
                {
                    RelativeName = relativeName ?? TestUtilities.GenerateName("foohydratestrelativeName"),
                    Ttl = 35
                }, 
                monitorConfig: new MonitorConfig
                {
                    Protocol = "http",
                    Port = 80,
                    Path = "/testpath.aspx"
                }, 
                endpoints: new []
                {
                    GenerateDefaultEndpoint()
                });
        }

        public static Endpoint GenerateDefaultEndpoint(string name = null)
        {
            return new Endpoint
            {
                Id = null,
                Name = name ?? "My external endpoint",
                Type = "Microsoft.network/TrafficManagerProfiles/ExternalEndpoints",
                Properties = new EndpointProperties
                {
                    TargetResourceId = null,
                    Target = "foobar.contoso.com",
                    EndpointLocation = "North Europe",
                    EndpointStatus = "Enabled"
                }
            };
        }

        public static string ExtractResourceGroupFromId(string id)
        {
            return id.Split('/')[4];
        }
    }
}
