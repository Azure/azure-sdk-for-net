// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.TrafficManager.Testing.ScenarioTests
{
    using System.Collections.Generic;
    using System.Linq;
    using global::TrafficManager.Tests.Helpers;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Testing.Helpers;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public partial class EndpointScenarioTests : TestBase
    {
        [Fact]
        public void CrudEndpointsFullCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string profileName = TestUtilities.GenerateName();
                string endpointName = TestUtilities.GenerateName();
                string resourceGroupName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                Profile profile = TrafficManagerHelper.GenerateDefaultEmptyProfile(profileName);

                // Create profile without endpoints
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    profile);

                // Create the endpoint
                Endpoint createEndpoint = trafficManagerClient.Endpoints.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpointName,
                    TrafficManagerHelper.GenerateDefaultEndpoint(endpointName));

                Assert.NotNull(createEndpoint);

                Endpoint getEndpoint = trafficManagerClient.Endpoints.Get(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpointName);

                Assert.NotNull(getEndpoint);

                Endpoint endpointToUpdate = getEndpoint;

                string oldTarget = endpointToUpdate.Target;
                string newTarget = "another." + oldTarget;
                endpointToUpdate.Target = newTarget;

                // Update the endpoint
                Endpoint updatedEndpoint = trafficManagerClient.Endpoints.Update(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpointName,
                    endpointToUpdate);

                Assert.NotNull(updatedEndpoint);
                Assert.Equal(newTarget, updatedEndpoint.Target);

                DeleteOperationResult deleteResponse = trafficManagerClient.Endpoints.Delete(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpointName);

                Assert.Throws<Microsoft.Rest.Azure.CloudException>(
                    () => trafficManagerClient.Endpoints.Get(
                        resourceGroup.Name,
                        profileName,
                        "ExternalEndpoints",
                        endpointName));
            }
        }
    }
}
