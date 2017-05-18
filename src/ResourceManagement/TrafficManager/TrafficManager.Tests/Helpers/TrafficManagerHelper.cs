// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.TrafficManager.Testing.Helpers
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public static class TrafficManagerHelper
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <param name="context"></param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static TrafficManagerManagementClient GetTrafficManagerManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<TrafficManagerManagementClient>();
        }

        public static Profile BuildProfile(string id, string name, string type, string location, Dictionary<string, string> tags, string profileStatus, string trafficRoutingMethod, DnsConfig dnsConfig, MonitorConfig monitorConfig, Endpoint[] endpoints)
        {
            return new Profile(
                id: id,
                name: name,
                type: type,
                location: location,
                tags: tags,
                profileStatus: profileStatus,
                trafficRoutingMethod: trafficRoutingMethod,
                dnsConfig: dnsConfig,
                monitorConfig: monitorConfig,
                endpoints: endpoints);
        }

        public static Profile GenerateDefaultProfileWithExternalEndpoint(string profileName, string trafficRoutingMethod = "Performance")
        {
            Profile defaultProfile = GenerateDefaultEmptyProfile(profileName, trafficRoutingMethod);
            defaultProfile.Endpoints = new[]
            {
                new Endpoint
                {
                    Id = null,
                    Name = "My external endpoint",
                    Type = "Microsoft.network/TrafficManagerProfiles/ExternalEndpoints",
                    TargetResourceId = null,
                    Target = "foobar.contoso.com",
                    EndpointLocation = "North Europe",
                    EndpointStatus = "Enabled"
                }
            };

            return defaultProfile;
        }

        public static Profile GenerateDefaultEmptyProfile(string profileName, string trafficRoutingMethod = "Performance")
        {
            return TrafficManagerHelper.BuildProfile(
                id: null,
                name: profileName,
                type: "microsoft.network/trafficmanagerprofiles",
                location: "global",
                tags: null,
                profileStatus: "Enabled",
                trafficRoutingMethod: trafficRoutingMethod,
                dnsConfig: new DnsConfig
                {
                    RelativeName = profileName,
                    Ttl = 35
                },
                monitorConfig: new MonitorConfig
                {
                    Protocol = "http",
                    Port = 80,
                    Path = "/testpath.aspx"
                },
                endpoints: null);
        }

        public static string GenerateName()
        {
            return TestUtilities.GenerateName("azuresdkfornetautoresttrafficmanager");
        }
    }
}
