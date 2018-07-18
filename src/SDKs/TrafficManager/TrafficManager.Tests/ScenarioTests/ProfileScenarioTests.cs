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

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name, 
                    profileName,
                    TrafficManagerHelper.GenerateDefaultProfileWithExternalEndpoint(profileName));

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

                Profile profile = TrafficManagerHelper.GenerateDefaultProfileWithExternalEndpoint(profileName);
                profile.Endpoints = null;
                profile.TrafficViewEnrollmentStatus = "Disabled";

                profile.Endpoints = new[]
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

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroupName,
                    profileName,
                    profile);




                try
                {
                    trafficManagerClient.HeatMap.Get(resourceGroupName, profileName);
                }
                catch (Microsoft.Rest.Azure.CloudException e)
                {
                    Assert.Contains("NotAuthorized", e.Body.Code);
                }

                profile.TrafficViewEnrollmentStatus = "Enabled";
                // Update the profile
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
                    Assert.True(ep.EndpointId >= 0, "Endpoint id out of range");
                    Assert.False(string.IsNullOrWhiteSpace(ep.ResourceId), "Resource Id undefined");
                }
                foreach(TrafficFlow tf in heatMapModel.TrafficFlows)
                {
                    Assert.False(string.IsNullOrWhiteSpace(tf.SourceIp), "SourceIp is undefined");
                    Assert.True(tf.Latitude >= -90.0 && tf.Latitude <= 90.0, "Latitude out of range");
                    Assert.True(tf.Longitude >= -180.0 && tf.Longitude <= 180.0, "Longitude out of range");
                    foreach(QueryExperience qe in tf.QueryExperiences)
                    {
                        Assert.True(heatMapModel.Endpoints.Where(ep => ep.EndpointId == qe.EndpointId).Count() > 0, "Query Experience does not match an existing endpoint");
                        Assert.True(qe.QueryCount > 0, "Query count is 0");
                        Assert.True(qe.Latency >= 0, "Latency out of range");

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

                Profile profile = TrafficManagerHelper.GenerateDefaultProfileWithExternalEndpoint(profileName);
                profile.Endpoints = null;
                profile.TrafficViewEnrollmentStatus = "Enabled";

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    profile);

                profile.Endpoints = new[]
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

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    profile);


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

                Profile profile = TrafficManagerHelper.GenerateDefaultProfileWithExternalEndpoint(profileName);
                profile.Endpoints = null;

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    profile);

                profile.Endpoints = new[]
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

                // Create the profile
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    profile);
                
                // Delete the profile
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

                    trafficManagerClient.Profiles.CreateOrUpdate(
                        resourceGroup.Name,
                        profileName,
                        TrafficManagerHelper.GenerateDefaultProfileWithExternalEndpoint(profileName));
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

                    trafficManagerClient.Profiles.CreateOrUpdate(
                        resourceGroup.Name,
                        profileName,
                        TrafficManagerHelper.GenerateDefaultProfileWithExternalEndpoint(profileName));
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
                var expectedProfile = TrafficManagerHelper.GenerateDefaultProfileWithCustomHeadersAndStatusCodeRanges(profileName);
                trafficManagerClient.Profiles.CreateOrUpdate(
                    resourceGroup.Name,
                    profileName,
                    expectedProfile);

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
    }
}
