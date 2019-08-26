// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.TrafficManager.Testing.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::TrafficManager.Tests.Helpers;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Testing.Helpers;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class ProfileScenarioTests : TestBase
    {
        [Fact]
        public void CrudProfileFullCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                string profileName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                TrafficManagerHelper.CreateOrUpdateDefaultProfileWithExternalEndpoint(
                    trafficManagerClient,
                    resourceGroup.Name,
                    profileName);

                // Get the profile
                trafficManagerClient.Profiles.Get(
                    resourceGroup.Name,
                    profileName);

                // Delete the profile
                trafficManagerClient.Profiles.Delete(resourceGroup.Name, profileName);
                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }

        [Fact]
        public void TrafficViewEnableDisableQuerySizeScope()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GetPersistentResourceGroupName();
                string profileName = TrafficManagerHelper.GetPersistentTrafficViewProfile();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                Profile profile = TrafficManagerHelper.CreateOrUpdateDefaultProfileWithExternalEndpoint(
                    trafficManagerClient,
                    resourceGroup.Name,
                    profileName);

                bool authorized = true;
                bool found = true;
                try
                {
                    trafficManagerClient.HeatMap.Get(resourceGroupName, profileName);
                }
                catch (Microsoft.Rest.Azure.CloudException e)
                {
                    authorized = !e.Body.Code.Contains("NotAuthorized");

                    // 'NotFound' can happen if there were no queries to the endpoint since it was provisioned.
                    found = !(authorized && e.Body.Code.Contains("NotFound")); // Let's hope you were paying attention in that math logic class.
                }

                if (!found)
                {
                    // Pause, then retry once.
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(120));
                    try
                    {
                        trafficManagerClient.HeatMap.Get(resourceGroupName, profileName);
                    }
                    catch (Microsoft.Rest.Azure.CloudException e)
                    {
                        authorized = !e.Body.Code.Contains("NotAuthorized");
                    }
                }

                Assert.False(authorized);

                // Change the enrollment status and update the profile.
                // Clear the endpoints first; those are not serializable as child objects because they have their own resource info.
                profile.TrafficViewEnrollmentStatus = "Enabled";
                profile.Endpoints = null;
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroupName,
                    profileName,
                    profile);

                HeatMapModel heatMapModel = trafficManagerClient.HeatMap.Get(resourceGroupName, profileName);

                Assert.True(heatMapModel.StartTime.Value.CompareTo(System.DateTime.MinValue) > 0, "Invalid start time");
                Assert.True(heatMapModel.StartTime.Value.CompareTo(heatMapModel.EndTime.Value) <= 0, "Start time smaller than end time");
                Assert.True(heatMapModel.Endpoints.Count > 0, "Endpoint list empty, Not really an error but can not run test with no heatmap data.");
                foreach(HeatMapEndpoint ep in heatMapModel.Endpoints)
                {
                    Assert.True((ep.EndpointId ?? -1) >= 0, "Endpoint id null or out of range");
                    Assert.False(string.IsNullOrWhiteSpace(ep.ResourceId), "Resource Id undefined");
                }
                foreach(TrafficFlow tf in heatMapModel.TrafficFlows)
                {
                    Assert.False(string.IsNullOrWhiteSpace(tf.SourceIp), "SourceIp is undefined");
                    foreach(QueryExperience qe in tf.QueryExperiences)
                    {
                        Assert.True(heatMapModel.Endpoints.Where(ep => ep.EndpointId == qe.EndpointId).Count() > 0, "Query Experience does not match an existing endpoint");
                    }
                }

                IList<TrafficFlow> trafficFlowList = heatMapModel.TrafficFlows; 


                foreach(TrafficFlow tf in trafficFlowList)
                {
                    if((tf.Latitude-.1 >= -90.0) && (tf.Latitude +.1 <= 90.0) && (tf.Longitude -.1 >= -180.0) && (tf.Longitude + .1 <= 180.0))
                    {
                        heatMapModel = trafficManagerClient.HeatMap.Get(resourceGroupName, profileName, new List<double?>(){ (tf.Latitude+.10), (tf.Longitude-.10)}, new List<double?>(){ (tf.Latitude-0.10), (tf.Longitude+0.10)});
                        Assert.True(heatMapModel.TrafficFlows.Where(currentTF => (currentTF.Latitude == tf.Latitude && currentTF.Longitude == tf.Longitude)).Count() > 0, "Subset of coordinates not found");

                        heatMapModel = trafficManagerClient.HeatMap.Get(resourceGroupName, profileName, new List<double?>(){ (tf.Latitude+.10), (tf.Longitude-.10)}, new List<double?>(){ (tf.Latitude+0.05), (tf.Longitude-0.05)});
                        Assert.True(heatMapModel.TrafficFlows.Where(currentTF => (currentTF.Latitude == tf.Latitude && currentTF.Longitude == tf.Longitude)).Count() == 0, "Subset of coordinates not expected");
                    }

                }

                
            }
        }

        [Fact]
        public void EmptyHeatMapData()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                string profileName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                TrafficManagerHelper.CreateOrUpdateDefaultProfileWithExternalEndpoint(
                    trafficManagerClient,
                    resourceGroup.Name,
                    profileName,
                    "Performance",
                    "Enabled");

                try
                {
                    trafficManagerClient.HeatMap.Get(resourceGroupName, profileName);
                }
                catch (Microsoft.Rest.Azure.CloudException e)
                {
                    Assert.Contains("NotFound", e.Body.Code);
                }
            }
        }
        
        [Fact]
        public void CrudProfileWithoutEndpoints_ThenUpdate()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                string profileName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                // Create the profile
                Profile profile = TrafficManagerHelper.CreateOrUpdateDefaultEmptyProfile(
                    trafficManagerClient,
                    resourceGroupName,
                    profileName);

                Assert.Equal(0, profile.Endpoints.Count);

                // Create the endpoint and associate it with the resource group and profile.
                TrafficManagerHelper.CreateOrUpdateDefaultEndpoint(trafficManagerClient, resourceGroupName, profileName);

                // Confirm the endpoint is associated with the profile.
                Profile updatedProfile = trafficManagerClient.Profiles.Get(
                    resourceGroup.Name,
                    profileName);

                Assert.Equal(1, updatedProfile.Endpoints.Count);

                // Delete the profile. The associated endpoint will also be deleted.
                trafficManagerClient.Profiles.DeleteWithHttpMessagesAsync(resourceGroup.Name, profileName);
                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }
        
        [Fact]
        public void ListProfilesByResourceGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);
                List<string> profileNames = new List<string>();

                for (int i = 0; i < 5; ++i)
                {
                    string profileName = TrafficManagerHelper.GenerateName();
                    profileNames.Add(profileName);

                    TrafficManagerHelper.CreateOrUpdateDefaultProfileWithExternalEndpoint(
                        trafficManagerClient,
                        resourceGroupName,
                        profileName);
                }

                IEnumerable<Profile> listResponse = trafficManagerClient.Profiles.ListByResourceGroupWithHttpMessagesAsync(resourceGroup.Name).Result.Body;

                Assert.Equal(5, listResponse.Count());

                // Delete the profiles
                foreach (var profileName in profileNames)
                {
                    trafficManagerClient.Profiles.DeleteWithHttpMessagesAsync(resourceGroup.Name, profileName);
                }

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }

        [Fact]
        public void ListAllProfiles()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);
                List<string> profileNames = new List<string>();

                for (int i = 0; i < 5; ++i)
                {
                    string profileName = TrafficManagerHelper.GenerateName();
                    profileNames.Add(profileName);

                    TrafficManagerHelper.CreateOrUpdateDefaultProfileWithExternalEndpoint(
                        trafficManagerClient,
                        resourceGroupName,
                        profileName);
                }

                IEnumerable<Profile> listResponse = trafficManagerClient.Profiles.ListBySubscriptionWithHttpMessagesAsync().Result.Body;

                // Just in case the subscription had some other profiles
                Assert.True(5 <= listResponse.Count());

                // Delete the profiles
                foreach (var profileName in profileNames)
                {
                    trafficManagerClient.Profiles.DeleteWithHttpMessagesAsync(resourceGroup.Name, profileName);
                }

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }

        [Fact]
        public void CrudProfileWithCustomHeaders()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                string profileName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                // Create the profile
                var expectedProfile = TrafficManagerHelper.CreateOrUpdateProfileWithCustomHeadersAndStatusCodeRanges(
                    trafficManagerClient,
                    resourceGroupName,
                    profileName);

                // Get the profile
                var actualProfile = trafficManagerClient.Profiles.Get(
                    resourceGroup.Name,
                    profileName);

                Assert.Equal(expectedProfile.MonitorConfig.CustomHeaders.Count, actualProfile.MonitorConfig.CustomHeaders.Count);
                for (var i = 0; i < expectedProfile.MonitorConfig.CustomHeaders.Count; ++i)
                {
                    Assert.Equal(expectedProfile.MonitorConfig.CustomHeaders[i].Name, actualProfile.MonitorConfig.CustomHeaders[i].Name);
                    Assert.Equal(expectedProfile.MonitorConfig.CustomHeaders[i].Value, actualProfile.MonitorConfig.CustomHeaders[i].Value);
                }

                for (var i = 0; i < expectedProfile.MonitorConfig.ExpectedStatusCodeRanges.Count; ++i)
                {
                    Assert.Equal(expectedProfile.MonitorConfig.ExpectedStatusCodeRanges[i].Min, actualProfile.MonitorConfig.ExpectedStatusCodeRanges[i].Min);
                    Assert.Equal(expectedProfile.MonitorConfig.ExpectedStatusCodeRanges[i].Max, actualProfile.MonitorConfig.ExpectedStatusCodeRanges[i].Max);
                }

                for (var i = 0; i < expectedProfile.Endpoints.Count; ++i)
                {
                    for (var j = 0; j < expectedProfile.Endpoints[i].CustomHeaders.Count; ++j)
                    {
                        Assert.Equal(expectedProfile.Endpoints[i].CustomHeaders[j].Name, actualProfile.Endpoints[i].CustomHeaders[j].Name);
                        Assert.Equal(expectedProfile.Endpoints[i].CustomHeaders[j].Value, actualProfile.Endpoints[i].CustomHeaders[j].Value);
                    }
                }

                // Delete the profile
                trafficManagerClient.Profiles.Delete(resourceGroup.Name, profileName);

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }

        [Fact]
        public void CrudProfileWithCustomSubnets()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                string profileName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                // Create the profile
                var expectedProfile = TrafficManagerHelper.CreateOrUpdateProfileWithSubnets(
                    trafficManagerClient,
                    resourceGroupName,
                    profileName);

                // Get the profile
                var actualProfile = trafficManagerClient.Profiles.Get(
                    resourceGroup.Name,
                    profileName);

                for (var i = 0; i < expectedProfile.Endpoints.Count; ++i)
                {
                    Assert.Equal(2, expectedProfile.Endpoints[i].Subnets.Count);
                    Assert.Equal($"1.2.{i}.0", expectedProfile.Endpoints[i].Subnets[0].First);
                    Assert.Equal($"1.2.{i}.250", expectedProfile.Endpoints[i].Subnets[0].Last);
                    Assert.Equal($"3.4.{i}.0", expectedProfile.Endpoints[i].Subnets[1].First);
                    Assert.Equal(24, expectedProfile.Endpoints[i].Subnets[1].Scope);
                }

                // Delete the profile
                trafficManagerClient.Profiles.Delete(resourceGroup.Name, profileName);

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }

        [Fact]
        public void CrudProfileWithMultiValue()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                string resourceGroupName = TrafficManagerHelper.GenerateName();
                string profileName = TrafficManagerHelper.GenerateName();
                ResourceGroup resourceGroup = this.CreateResourceGroup(context, resourceGroupName);

                // Create the profile
                var expectedProfile = TrafficManagerHelper.CreateOrUpdateProfileWithMultiValue(
                    trafficManagerClient,
                    resourceGroupName,
                    profileName,
                    3);

                // Get the profile
                var actualProfile = trafficManagerClient.Profiles.Get(
                    resourceGroup.Name,
                    profileName);

                Assert.Equal(3, expectedProfile.MaxReturn);

                // Delete the profile
                trafficManagerClient.Profiles.Delete(resourceGroup.Name, profileName);

                this.DeleteResourceGroup(context, resourceGroupName);
            }
        }
    }
}
