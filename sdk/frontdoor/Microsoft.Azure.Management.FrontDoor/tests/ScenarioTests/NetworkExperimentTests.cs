// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using FrontDoor.Tests.Helpers;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.Azure.Management.FrontDoor.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace FrontDoor.Tests.ScenarioTests
{
    public class NetworkExperimentTests
    {
        [Fact]
        public void NetworkExperimentCRUDTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var frontDoorMgmtClient = FrontDoorTestUtilities.GetFrontDoorManagementClient(context, handler1);
                var resourcesClient = FrontDoorTestUtilities.GetResourceManagementClient(context, handler2);

                // Get subscription id
                string subid = frontDoorMgmtClient.SubscriptionId;

                // Create resource group
                var resourceGroupName = FrontDoorTestUtilities.CreateResourceGroup(resourcesClient);

                // Create profile and experiment names
                string profileName = TestUtilities.GenerateName("networkExperimentProfile");
                string experimentName = TestUtilities.GenerateName("experiment");

                Profile profile = new Profile(
                    enabledState: "Enabled",
                    location: "EastUS",
                    tags: new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    });

                Experiment experiment = new Experiment(
                    endpointA: new Endpoint(
                        endpointProperty: "www.bing.com",
                        name: "bing"),
                    endpointB: new Endpoint(
                        endpointProperty: "www.constoso.com",
                        name: "contoso"));

                var createdProfile = frontDoorMgmtClient.NetworkExperimentProfiles.CreateOrUpdate(profileName, resourceGroupName, profile);

                // validate that correct profile is created
                VerifyProfile(profile, createdProfile);

                // Retrieve profile 
                var retrievedProfile = frontDoorMgmtClient.NetworkExperimentProfiles.Get(resourceGroupName, profileName);

                // validate that correct profile is retrieved
                VerifyProfile(profile, retrievedProfile);

                // update profile
                retrievedProfile.Tags = new Dictionary<string, string>
                        {
                            {"key3","value3"},
                            {"key4","value4"}
                        };

                var updatedProfile = frontDoorMgmtClient.NetworkExperimentProfiles.CreateOrUpdate(profileName, resourceGroupName, retrievedProfile);

                // validate that profile is correctly updated
                VerifyProfile(retrievedProfile, updatedProfile);

                // add experiment to profile
                var createdExperiment = frontDoorMgmtClient.Experiments.CreateOrUpdate(resourceGroupName, profileName, experimentName, experiment);

                // validate experiment
                VerifyExperiment(experiment, createdExperiment);

                // get experiment
                var retrievedExperiment = frontDoorMgmtClient.Experiments.Get(resourceGroupName, profileName, experimentName);

                // validate experiment
                VerifyExperiment(experiment, retrievedExperiment);

                // delete experiment
                frontDoorMgmtClient.Experiments.Delete(resourceGroupName, profileName, experimentName);

                // verify experiment is deleted
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    frontDoorMgmtClient.Experiments.Get(resourceGroupName, profileName, experimentName);
                });

                // delete profile
                frontDoorMgmtClient.NetworkExperimentProfiles.Delete(resourceGroupName, profileName);

                // Verify that profile is deleted
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    frontDoorMgmtClient.NetworkExperimentProfiles.Get(resourceGroupName, profileName);
                });

                FrontDoorTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        private static void VerifyProfile(Profile expectedProfile, Profile actualProfile)
        {
            Assert.Equal(expectedProfile.EnabledState, actualProfile.EnabledState);
            Assert.Equal(expectedProfile.Location.ToLower(), actualProfile.Location.ToLower());
            Assert.Equal(expectedProfile.Tags.Count, actualProfile.Tags.Count);
            Assert.True(expectedProfile.Tags.SequenceEqual(actualProfile.Tags));
        }

        private static void VerifyExperiment(Experiment expectedExperiment, Experiment actualExperiment)
        {
            Assert.Equal(expectedExperiment.EndpointA.EndpointProperty, actualExperiment.EndpointA.EndpointProperty);
            Assert.Equal(expectedExperiment.EndpointA.Name, actualExperiment.EndpointA.Name);
            Assert.Equal(expectedExperiment.EndpointB.EndpointProperty, actualExperiment.EndpointB.EndpointProperty);
            Assert.Equal(expectedExperiment.EndpointB.Name, actualExperiment.EndpointB.Name);
        }
    }
}
