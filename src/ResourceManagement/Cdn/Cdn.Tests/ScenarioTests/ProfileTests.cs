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

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Cdn.Tests.Helpers;
using Microsoft.Azure.Management.Resources.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Cdn.Tests.ScenarioTests
{
    public class ProfileTests
    {
        [Fact]
        public void ProfileCreateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);
                VerifyProfileCreated(profile, createParameters);

                // Create a premium cdn profile
                profileName = TestUtilities.GenerateName("profile");
                createParameters = new Profile
                {
                    Location = "EastUs",
                    Sku = new Sku { Name = SkuName.PremiumVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);
                VerifyProfileCreated(profile, createParameters);

                // Create profile with same name but different params should fail
                createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>()
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters); });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void ProfileUpdateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardAkamai },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);
                VerifyProfileCreated(profile, createParameters);

                // Update profile with new tags
                var newTags = new Dictionary<string, string>
                {
                    { "newkey1","newValue1"}
                };

                var updatedProfile = cdnMgmtClient.Profiles.Update(
                    resourceGroupName,
                    profileName,
                    newTags);
                VerifyProfileUpdated(profile, updatedProfile, newTags);

                // Create a standard cdn profile and don't wait for creation to finish
                profileName = TestUtilities.GenerateName("profile");
                createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                cdnMgmtClient.Profiles.BeginCreateAsync(resourceGroupName, profileName, createParameters)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // Update profile in creating state should fail
                var tags = new Dictionary<string, string>
                {
                    { "key", "value" }
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Profiles.Update(resourceGroupName, profileName, tags);
                });

                // Wait for second profile to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode(2);

                // Update profile now should succeed
                cdnMgmtClient.Profiles.Update(resourceGroupName, profileName, tags);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void ProfileDeleteTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);
                VerifyProfileCreated(profile, createParameters);

                // Delete existing profile should succeed
                cdnMgmtClient.Profiles.Delete(resourceGroupName, profile.Name);

                // List profiles should return none
                var profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(0, profiles.Count());

                // Delete non-existing profile should succeed
                cdnMgmtClient.Profiles.Delete(resourceGroupName, profile.Name);

                // Create a standard cdn profile and don't wait for creation to finish
                profileName = TestUtilities.GenerateName("profile");
                createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                cdnMgmtClient.Profiles.BeginCreateAsync(resourceGroupName, profileName, createParameters)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // Delete profile in creating state should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Profiles.Delete(resourceGroupName, profileName); });

                // Wait for second profile to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Delete profile should succeed
                cdnMgmtClient.Profiles.Delete(resourceGroupName, profileName);

                // List profiles should return none
                profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(0, profiles.Count());

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void ProfileGetListTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // List profiles should return none
                var profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(0, profiles.Count());

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);
                VerifyProfileCreated(profile, createParameters);

                // Get profile returns the created profile
                var existingProfile = cdnMgmtClient.Profiles.Get(resourceGroupName, profileName);
                VerifyProfilesEqual(profile, existingProfile);

                // List profiles should return one profile
                profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(1, profiles.Count());

                // Create a second cdn profile and don't wait for creation to finish
                var profileName2 = TestUtilities.GenerateName("profile");
                createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                cdnMgmtClient.Profiles.BeginCreateAsync(resourceGroupName, profileName2, createParameters)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // List profiles should return two profiles
                profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(2, profiles.Count());

                // Delete first profile
                cdnMgmtClient.Profiles.Delete(resourceGroupName, profileName);

                // Get deleted profile should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                   cdnMgmtClient.Profiles.Get(resourceGroupName, profileName); });

                // List profiles should return only one profile
                profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(1, profiles.Count());

                // Wait for second profile to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Delete second profile but don't wait for operation to complete
                cdnMgmtClient.Profiles.BeginDeleteAsync(resourceGroupName, profileName2)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // Get second profile returns profile in Deleting state
                existingProfile = cdnMgmtClient.Profiles.Get(resourceGroupName, profileName2);
                Assert.Equal(existingProfile.ResourceState, ProfileResourceState.Deleting);

                // Wait for second profile to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // List profiles should none
                profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(0, profiles.Count());

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void ProfileListBySubcriptionTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // List profiles should return none
                var profiles = cdnMgmtClient.Profiles.List();
                Assert.Equal(0, profiles.Count());

                // Create resource group
                var resourceGroupName1 = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName1, profileName, createParameters);
                VerifyProfileCreated(profile, createParameters);

                // Get profile returns the created profile
                var existingProfile = cdnMgmtClient.Profiles.Get(resourceGroupName1, profileName);
                VerifyProfilesEqual(profile, existingProfile);

                // List profiles should return one profile
                profiles = cdnMgmtClient.Profiles.List();
                Assert.Equal(1, profiles.Count());

                // Create another resource group
                var resourceGroupName2 = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a second cdn profile and don't wait for creation to finish
                var profileName2 = TestUtilities.GenerateName("profile");
                createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                profile = cdnMgmtClient.Profiles.Create(resourceGroupName2, profileName2, createParameters);
                VerifyProfileCreated(profile, createParameters);

                // List profiles should return two profiles
                profiles = cdnMgmtClient.Profiles.List();
                Assert.Equal(2, profiles.Count());

                // Delete first profile
                cdnMgmtClient.Profiles.Delete(resourceGroupName1, profileName);

                // List profiles should return only one profile
                profiles = cdnMgmtClient.Profiles.List();
                Assert.Equal(1, profiles.Count());

                // Delete second profile
                cdnMgmtClient.Profiles.Delete(resourceGroupName2, profileName2);

                // List profiles should none
                profiles = cdnMgmtClient.Profiles.List();
                Assert.Equal(0, profiles.Count());

                // Delete resource groups
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName1);
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName2);
            }
        }

        [Fact]
        public void GenerateSsoUriTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);
                VerifyProfileCreated(profile, createParameters);

                // Generate Sso Uri on created profile should succeed
                var ssoUri = cdnMgmtClient.Profiles.GenerateSsoUri(resourceGroupName, profileName);
                Assert.NotNull(ssoUri);
                Assert.False(string.IsNullOrWhiteSpace(ssoUri.SsoUriValue));

                // Create a cdn profile and don't wait for creation to finish
                profileName = TestUtilities.GenerateName("profile");
                createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                cdnMgmtClient.Profiles.BeginCreateAsync(resourceGroupName, profileName, createParameters)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // Generate Sso Uri on creating profile should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Profiles.GenerateSsoUri(resourceGroupName, profileName); });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void ProfileCheckUsageTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // CheckUsage on subscription should return zero profiles
                var subscriptionLevelUsages = cdnMgmtClient.CheckResourceUsage();
                Assert.Equal(1, subscriptionLevelUsages.Count());

                var defaultUsage = subscriptionLevelUsages.First();
                Assert.Equal(8, defaultUsage.Limit);
                Assert.Equal(0, defaultUsage.CurrentValue);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);
                VerifyProfileCreated(profile, createParameters);

                subscriptionLevelUsages = cdnMgmtClient.CheckResourceUsage();
                Assert.Equal(1, subscriptionLevelUsages.Count());

                var usageAfterCreation = subscriptionLevelUsages.First();
                Assert.Equal(8, usageAfterCreation.Limit);
                Assert.Equal(1, usageAfterCreation.CurrentValue);

                // test Profile level usage
                var profileLevelUsages = cdnMgmtClient.Profiles.ListResourceUsage(resourceGroupName, profileName);
                Assert.Equal(1, profileLevelUsages.Count());

                var profileLevelUsage = profileLevelUsages.First();
                Assert.Equal(10, profileLevelUsage.Limit);
                Assert.Equal(0, profileLevelUsage.CurrentValue);

                //Create an endpoint under this profile
                string endpointName = TestUtilities.GenerateName("endpoint");
                var endpointCreateParameters = new Endpoint
                {
                    Location = "WestUs",
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin1",
                            HostName = "host1.hello.com"
                        }
                    }
                };

                var endpoint = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                profileLevelUsages = cdnMgmtClient.Profiles.ListResourceUsage(resourceGroupName, profileName);
                Assert.Equal(1, profileLevelUsages.Count());

                var profileLevelUsageAfterEndpointCreation = profileLevelUsages.First();
                Assert.Equal(10, profileLevelUsageAfterEndpointCreation.Limit);
                Assert.Equal(1, profileLevelUsageAfterEndpointCreation.CurrentValue);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        private static void VerifyProfileCreated(Profile profile, Profile parameters)
        {
            Assert.Equal(profile.Location, parameters.Location);
            Assert.Equal(profile.Sku.Name, parameters.Sku.Name);
            Assert.Equal(profile.Tags.Count, parameters.Tags.Count);
            Assert.True(profile.Tags.SequenceEqual(parameters.Tags));
            Assert.Equal(profile.ProvisioningState, "Succeeded");
            Assert.Equal(profile.ResourceState, ProfileResourceState.Active);
        }

        private static void VerifyProfileUpdated(Profile oldProfile, Profile updatedProfile, Dictionary<string, string> newTags)
        {
            Assert.Equal(oldProfile.Location, updatedProfile.Location);
            Assert.Equal(oldProfile.Sku.Name, updatedProfile.Sku.Name);
            Assert.Equal(updatedProfile.Tags.Count, newTags.Count);
            Assert.True(updatedProfile.Tags.SequenceEqual(newTags));
        }

        private void VerifyProfilesEqual(Profile expectedProfile, Profile actualProfile)
        {
            Assert.Equal(expectedProfile.Name, actualProfile.Name);
            Assert.Equal(expectedProfile.Location, actualProfile.Location);
            Assert.Equal(expectedProfile.Sku.Name, actualProfile.Sku.Name);
            Assert.Equal(expectedProfile.Tags.Count, actualProfile.Tags.Count);
            Assert.True(expectedProfile.Tags.SequenceEqual(actualProfile.Tags));
        }
    }
}