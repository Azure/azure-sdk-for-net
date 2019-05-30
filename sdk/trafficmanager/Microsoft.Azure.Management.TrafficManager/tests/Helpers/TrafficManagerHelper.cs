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

        public static Profile BuildProfile(
            string id,
            string name,
            string type,
            string location,
            Dictionary<string, string> tags,
            string profileStatus,
            string trafficRoutingMethod,
            string trafficViewEnrollmentStatus,
            long? maxReturn,
            DnsConfig dnsConfig,
            MonitorConfig monitorConfig,
            Endpoint[] endpoints)
        {
            return new Profile(
                id: id,
                name: name,
                type: type,
                location: location,
                tags: tags,
                profileStatus: profileStatus,
                trafficRoutingMethod: trafficRoutingMethod,
                trafficViewEnrollmentStatus: trafficViewEnrollmentStatus,
                maxReturn: maxReturn,
                dnsConfig: dnsConfig,
                monitorConfig: monitorConfig,
                endpoints: endpoints);
        }

        public static Profile CreateOrUpdateDefaultProfileWithExternalEndpoint(
            TrafficManagerManagementClient trafficManagerClient,
            string resourceGroupName,
            string profileName,
            string trafficRoutingMethod = "Performance",
            string trafficViewEnrollmentStatus = "Disabled",
            string target = "foobar.contoso.com")
        {

            Profile profile = TrafficManagerHelper.CreateOrUpdateDefaultEmptyProfile(
                trafficManagerClient,
                resourceGroupName,
                profileName,
                trafficRoutingMethod,
                trafficViewEnrollmentStatus);

            // Create the endpoint and associate it with the resource group and profile.
            TrafficManagerHelper.CreateOrUpdateDefaultEndpoint(
                trafficManagerClient,
                resourceGroupName,
                profileName,
                target);

            return trafficManagerClient.Profiles.Get(resourceGroupName, profileName);
        }

        public static Profile CreateOrUpdateDefaultEmptyProfile(
            TrafficManagerManagementClient trafficManagerClient,
            string resourceGroupName,
            string profileName,
            string trafficRoutingMethod = "Performance",
            string trafficViewEnrollmentStatus = "Disabled",
            long? maxReturn = null)
        {
            return trafficManagerClient.Profiles.CreateOrUpdate(
                resourceGroupName,
                profileName,
                GenerateDefaultEmptyProfile(profileName, trafficRoutingMethod, trafficViewEnrollmentStatus, maxReturn));
        }

        public static Endpoint CreateOrUpdateDefaultEndpoint(
            TrafficManagerManagementClient trafficManagerClient,
            string resourceGroupName,
            string profileName,
            string target = "foobar.contoso.com")
        {
            string endpointName = "My external endpoint";
            return trafficManagerClient.Endpoints.CreateOrUpdate(
                resourceGroupName,
                profileName,
                "ExternalEndpoints",
                endpointName,
                GenerateDefaultEndpoint(endpointName, target));
        }

        public static Profile GenerateDefaultEmptyProfile(
            string profileName,
            string trafficRoutingMethod = "Performance",
            string trafficViewEnrollmentStatus = "Disabled",
            long? maxReturn = null)
        {
            return TrafficManagerHelper.BuildProfile(
                id: null,
                name: profileName,
                type: "microsoft.network/trafficmanagerprofiles",
                location: "global",
                tags: null,
                profileStatus: "Enabled",
                trafficRoutingMethod: trafficRoutingMethod,
                trafficViewEnrollmentStatus: trafficViewEnrollmentStatus,
                maxReturn: maxReturn,
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

        public static Endpoint GenerateDefaultEndpoint(string name = "My external endpoint", string target = "foobar.contoso.com")
        {
            Endpoint endpoint = new Endpoint(
                null,
                name,
                "Microsoft.Network/trafficManagerProfiles/ExternalEndpoints");
            endpoint.TargetResourceId = null;
            endpoint.Target = target;
            endpoint.EndpointLocation = "North Europe";
            endpoint.EndpointStatus = "Enabled";
            return endpoint;
        }

        public static string GenerateName()
        {
            return TestUtilities.GenerateName("azuresdkfornetautoresttrafficmanager");
        }


        public static string GetPersistentResourceGroupName()
        {
            return "azuresdkpersistentheatmapdata";

        }


        public static string GetPersistentTrafficViewProfile()
        {
            return "persistentHeatMap";
        }

        public static Profile CreateOrUpdateProfileWithCustomHeadersAndStatusCodeRanges(
            TrafficManagerManagementClient trafficManagerClient,
            string resourceGroupName,
            string profileName)
        {
            Profile expectedProfile = GenerateDefaultEmptyProfile(profileName);
            expectedProfile.MonitorConfig.CustomHeaders = new List<MonitorConfigCustomHeadersItem>
            {
                new MonitorConfigCustomHeadersItem("host", "www.contoso.com"),
                new MonitorConfigCustomHeadersItem("custom-name", "custom-value")
            };

            expectedProfile.MonitorConfig.ExpectedStatusCodeRanges = new List<MonitorConfigExpectedStatusCodeRangesItem>
            {
                new MonitorConfigExpectedStatusCodeRangesItem(200, 499)
            };

            trafficManagerClient.Profiles.CreateOrUpdate(
                resourceGroupName,
                profileName,
                expectedProfile);


            expectedProfile.Endpoints = new List<Endpoint>();
            for (int ndx = 0; ndx < 3; ndx++)
            {
                Endpoint endpoint = TrafficManagerHelper.GenerateDefaultEndpoint(
                    $"My external endpoint {ndx}",
                    $"foobar.Contoso{ndx}.com");

                endpoint.CustomHeaders = new List<EndpointPropertiesCustomHeadersItem>
                {
                    new EndpointPropertiesCustomHeadersItem("custom-name", "custom-value-overriden")
                };

                trafficManagerClient.Endpoints.CreateOrUpdate(
                    resourceGroupName,
                    profileName,
                    "ExternalEndpoints",
                    endpoint.Name,
                    endpoint);

                expectedProfile.Endpoints.Add(endpoint);
            }

            return expectedProfile;
        }

        public static Profile CreateOrUpdateProfileWithSubnets(
            TrafficManagerManagementClient trafficManagerClient,
            string resourceGroupName,
            string profileName)
        {
            Profile expectedProfile = CreateOrUpdateDefaultEmptyProfile(trafficManagerClient, resourceGroupName, profileName, "Subnet");

            expectedProfile.Endpoints = new List<Endpoint>();
            for (int ndx = 0; ndx < 4; ndx++)
            {
                Endpoint endpoint = TrafficManagerHelper.GenerateDefaultEndpoint(
                    $"My external endpoint {ndx}",
                    $"foobar.Contoso{ndx}.com");

                EndpointPropertiesSubnetsItem range = new EndpointPropertiesSubnetsItem($"1.2.{ndx}.0", $"1.2.{ndx}.250");
                EndpointPropertiesSubnetsItem subnet = new EndpointPropertiesSubnetsItem($"3.4.{ndx}.0", null, 24);
                endpoint.Subnets = new List<EndpointPropertiesSubnetsItem> { range, subnet };

                trafficManagerClient.Endpoints.CreateOrUpdate(
                    resourceGroupName,
                    profileName,
                    "ExternalEndpoints",
                    endpoint.Name,
                    endpoint);

                expectedProfile.Endpoints.Add(endpoint);
            }

            return expectedProfile;
        }

        public static Profile CreateOrUpdateProfileWithMultiValue(
            TrafficManagerManagementClient trafficManagerClient,
            string resourceGroupName,
            string profileName,
            long? maxReturn = 2)
        {
            Profile expectedProfile = CreateOrUpdateDefaultEmptyProfile(trafficManagerClient, resourceGroupName, profileName, "MultiValue", "Disabled", maxReturn);

            expectedProfile.Endpoints = new List<Endpoint>();
            for (int ndx = 0; ndx < 5; ndx++)
            {
                Endpoint endpoint = TrafficManagerHelper.GenerateDefaultEndpoint(
                    $"My external endpoint {ndx}",
                    $"1.2.3.{ndx}");

                EndpointPropertiesSubnetsItem range = new EndpointPropertiesSubnetsItem($"1.2.{ndx}.0", $"1.2.{ndx}.250");
                EndpointPropertiesSubnetsItem subnet = new EndpointPropertiesSubnetsItem($"3.4.{ndx}.0", null, 24);
                endpoint.Subnets = new List<EndpointPropertiesSubnetsItem> { range, subnet };

                trafficManagerClient.Endpoints.CreateOrUpdate(
                    resourceGroupName,
                    profileName,
                    "ExternalEndpoints",
                    endpoint.Name,
                    endpoint);

                expectedProfile.Endpoints.Add(endpoint);
            }

            return expectedProfile;
        }
    }
}
