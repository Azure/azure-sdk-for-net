﻿//
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
    public class ProfileScenarioTests
    {
        [Fact]
        public void CrudProfileFullCycle()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();

                string profileName = TestUtilities.GenerateName("hydratestwatmv2profile");
                ResourceGroupExtended resourceGroup = TrafficManagerHelper.CreateResourceGroup();

                // Create the profile
                ProfileCreateOrUpdateResponse createResponse = trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name, 
                    profileName, 
                    new ProfileCreateOrUpdateParameters
                    {
                        Profile = TrafficManagerHelper.GenerateDefaultProfile(profileName)
                    });

                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // Get the profile
                ProfileGetResponse getResponse = trafficManagerClient.Profiles.Get(
                    resourceGroup.Name,
                    profileName);

                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

                // Delete the profile
                AzureOperationResponse deleteResponse = trafficManagerClient.Profiles.Delete(resourceGroup.Name, profileName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
            }
        }

        [Fact]
        public void CrudProfileWithoutEndpoints_ThenUpdate()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();

                string profileName = TestUtilities.GenerateName("hydratestwatmv2profile");
                ResourceGroupExtended resourceGroup = TrafficManagerHelper.CreateResourceGroup();

                Profile profile = TrafficManagerHelper.GenerateDefaultProfile(profileName);
                profile.Properties.Endpoints = null;

                // Create the profile
                ProfileCreateOrUpdateResponse createResponse = trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    new ProfileCreateOrUpdateParameters
                    {
                        Profile = profile
                    });

                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                profile.Properties.Endpoints = new[]
                {
                    new Endpoint
                    {
                        Id = null,
                        Name = "My external endpoint",
                        Type = "Microsoft.network/TrafficManagerProfiles/ExternalEndpoints",
                        Properties = new EndpointProperties
                        {
                            TargetResourceId = null,
                            Target = "foobar.contoso.com",
                            EndpointLocation = "North Europe",
                            EndpointStatus = "Enabled"
                        }
                    } 
                };

                // Create the profile
                ProfileCreateOrUpdateResponse updateResponse = trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    new ProfileCreateOrUpdateParameters
                    {
                        Profile = profile
                    });

                Assert.Equal(HttpStatusCode.Created, updateResponse.StatusCode);
            }
        }

        [Fact]
        public void ListProfilesByResourceGroup()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();
                
                ResourceGroupExtended resourceGroup = TrafficManagerHelper.CreateResourceGroup();

                for (int i = 0; i < 5; ++i)
                {
                    string profileName = TestUtilities.GenerateName("watmv2profilehydratest");

                    trafficManagerClient.Profiles.CreateOrUpdate(
                        resourceGroup.Name,
                        profileName,
                        new ProfileCreateOrUpdateParameters
                        {
                            Profile = TrafficManagerHelper.GenerateDefaultProfile(profileName)
                        });
                }

                ProfileListResponse listResponse = trafficManagerClient.Profiles.ListAllInResourceGroup(resourceGroup.Name);

                Assert.Equal(5, listResponse.Profiles.Count);
            }
        }

        [Fact(Skip = "Garbage on the storage")]
        public void ListAllProfiles()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();

                ResourceGroupExtended resourceGroup = TrafficManagerHelper.CreateResourceGroup();

                for (int i = 0; i < 5; ++i)
                {
                    string profileName = TestUtilities.GenerateName("hydratestwatmv2profile");

                    trafficManagerClient.Profiles.CreateOrUpdate(
                        resourceGroup.Name,
                        profileName,
                        new ProfileCreateOrUpdateParameters
                        {
                            Profile = TrafficManagerHelper.GenerateDefaultProfile(profileName)
                        });
                }

                ProfileListResponse listResponse = trafficManagerClient.Profiles.ListAll();

                Assert.Equal(5, listResponse.Profiles.Count);
            }
        }
    }
}
