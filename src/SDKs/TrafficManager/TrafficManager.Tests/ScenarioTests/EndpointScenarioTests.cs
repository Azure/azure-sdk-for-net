// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.TrafficManager.Testing.ScenarioTests
{
    using System.Collections.Generic;
    using System.Linq;
    using global::TrafficManager.Tests.Helpers;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Testing.Helpers;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class EndpointScenarioTests : TestBase
    {
        [Fact]
        public void CrudEndpointGeographicProfile()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                string profileName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                // Create the profile
                Profile profile = trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    TrafficManagerHelper.GenerateDefaultEmptyProfile(profileName, "Geographic"));

                Assert.Equal("Geographic", profile.TrafficRoutingMethod);

                Endpoint endpoint = new Endpoint(
                    null,
                    "My external endpoint",
                    "Microsoft.Network/trafficManagerProfiles/ExternalEndpoints");
                endpoint.TargetResourceId = null;
                endpoint.Target = "foobar.contoso.com";
                endpoint.EndpointStatus = "Enabled";
                endpoint.GeoMapping = new[] { "GEO-AS", "GEO-AF" };

                // Create the endpoint
                Endpoint createEndpointResponse = trafficManagerClient.Endpoints.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpoint.Name,
                    endpoint);

                Assert.Equal("GEO-AS", createEndpointResponse.GeoMapping[0]);
                Assert.Equal("GEO-AF", createEndpointResponse.GeoMapping[1]);

                // Get the endpoint
                Endpoint endpointGetResponse = trafficManagerClient.Endpoints.Get(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpoint.Name);

                Assert.Equal("GEO-AS", endpointGetResponse.GeoMapping[0]);
                Assert.Equal("GEO-AF", endpointGetResponse.GeoMapping[1]);

                // Delete the profile
                trafficManagerClient.Profiles.Delete(resourceGroup.Name, profileName);
                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }
    }
}
