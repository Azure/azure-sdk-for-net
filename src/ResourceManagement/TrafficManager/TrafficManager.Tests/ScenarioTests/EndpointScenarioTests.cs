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

using System.Net;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.TrafficManager.Models;
using Microsoft.Azure.Management.TrafficManager.Testing.Helpers;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Management.TrafficManager.Testing.ScenarioTests
{
    public class EndpointScenarioTests
    {
        public EndpointScenarioTests()
        {
            // Cleanup
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();

                ProfileListResponse listResponse = trafficManagerClient.Profiles.ListAll();

                foreach (Profile profile in listResponse.Profiles)
                {
                    string resourceGroup = TrafficManagerHelper.ExtractResourceGroupFromId(profile.Id);
                    trafficManagerClient.Profiles.Delete(resourceGroup, profile.Name);
                }
            }
        }

        [Fact]
        public void CrudEndpointsFullCycle()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();

                string profileName = TestUtilities.GenerateName("hydratestwatmv2profile");
                string endpointName = TestUtilities.GenerateName("hydratestwatmv2endpoint");

                ResourceGroupExtended resourceGroup = TrafficManagerHelper.CreateResourceGroup();

                Profile profile = TrafficManagerHelper.GenerateDefaultProfile(profileName);
                profile.Properties.Endpoints = null;

                // Create profile without endpoints
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    new ProfileCreateOrUpdateParameters
                    {
                        Profile = profile
                    });

                // Create the endpoint
                EndpointCreateOrUpdateResponse createEndpoint = trafficManagerClient.Endpoints.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpointName,
                    new EndpointCreateOrUpdateParameters
                    {
                        Endpoint = TrafficManagerHelper.GenerateDefaultEndpoint(endpointName)
                    });

                Assert.Equal(HttpStatusCode.Created, createEndpoint.StatusCode);

                EndpointGetResponse getEndpoint = trafficManagerClient.Endpoints.Get(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpointName);

                Assert.Equal(HttpStatusCode.OK, getEndpoint.StatusCode);

                Endpoint endpointToUpdate = getEndpoint.Endpoint;

                string oldTarget = endpointToUpdate.Properties.Target;
                string newTarget = "another." + oldTarget;
                endpointToUpdate.Properties.Target = newTarget;

                // Create the endpoint
                EndpointUpdateResponse updateEndpoint = trafficManagerClient.Endpoints.Update(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpointName,
                    new EndpointUpdateParameters
                    {
                        Endpoint = endpointToUpdate
                    });

                Assert.Equal(HttpStatusCode.Created, updateEndpoint.StatusCode);
                Assert.Equal(newTarget, updateEndpoint.Endpoint.Properties.Target);

                AzureOperationResponse deleteResponse = trafficManagerClient.Endpoints.Delete(
                    resourceGroup.Name,
                    profileName,
                    "ExternalEndpoints",
                    endpointName);

                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
            }
        }
    }
}
