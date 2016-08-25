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

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Cdn.Tests.Helpers;
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
                ProfileCreateParameters createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName);
                VerifyProfileCreated(profile, createParameters);

                // Create a premium cdn profile
                profileName = TestUtilities.GenerateName("profile");
                createParameters = new ProfileCreateParameters
                {
                    Location = "EastUs",
                    Sku = new Sku { Name = SkuName.PremiumVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                profile = cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName);
                VerifyProfileCreated(profile, createParameters);

                // Create profile with same name but different params should fail
                createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>()
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName); });

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
                ProfileCreateParameters createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName);
                VerifyProfileCreated(profile, createParameters);

                // Update profile with new tags
                var newTags = new Dictionary<string, string>
                {
                    { "newkey1","newValue1"}
                };

                var updatedProfile = cdnMgmtClient.Profiles.Update(profileName, resourceGroupName, newTags);
                VerifyProfileUpdated(profile, updatedProfile, newTags);

                // Create a standard cdn profile and don't wait for creation to finish
                profileName = TestUtilities.GenerateName("profile");
                createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                cdnMgmtClient.Profiles.BeginCreateAsync(profileName, createParameters, resourceGroupName).Wait(2000);

                // Update profile in creating state should fail
                var tags = new Dictionary<string, string>
                {
                    { "key", "value" }
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Profiles.Update(profileName, resourceGroupName, tags);
                });

                // Wait for second profile to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Update profile now should succeed
                cdnMgmtClient.Profiles.Update(profileName, resourceGroupName, tags);

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
                ProfileCreateParameters createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName);
                VerifyProfileCreated(profile, createParameters);

                // Delete existing profile should succeed
                cdnMgmtClient.Profiles.DeleteIfExists(profile.Name, resourceGroupName);

                // List profiles should return none
                var profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(0, profiles.Count());

                // Delete non-existing profile should succeed
                cdnMgmtClient.Profiles.DeleteIfExists(profile.Name, resourceGroupName);

                // Create a standard cdn profile and don't wait for creation to finish
                profileName = TestUtilities.GenerateName("profile");
                createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                cdnMgmtClient.Profiles.BeginCreateAsync(profileName, createParameters, resourceGroupName).Wait(2000);

                // Delete profile in creating state should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Profiles.DeleteIfExists(profileName, resourceGroupName); });

                // Wait for second profile to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Delete profile should succeed
                cdnMgmtClient.Profiles.DeleteIfExists(profileName, resourceGroupName);

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
                ProfileCreateParameters createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName);
                VerifyProfileCreated(profile, createParameters);

                // Get profile returns the created profile
                var existingProfile = cdnMgmtClient.Profiles.Get(profileName, resourceGroupName);
                VerifyProfilesEqual(profile, existingProfile);

                // List profiles should return one profile
                profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(1, profiles.Count());

                // Create a second cdn profile and don't wait for creation to finish
                var profileName2 = TestUtilities.GenerateName("profile");
                createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                cdnMgmtClient.Profiles.BeginCreateAsync(profileName2, createParameters, resourceGroupName).Wait(2000);
                
                // List profiles should return two profiles
                profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(2, profiles.Count());

                // Delete first profile
                cdnMgmtClient.Profiles.DeleteIfExists(profileName, resourceGroupName);

                // Get deleted profile should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                   cdnMgmtClient.Profiles.Get(profileName, resourceGroupName); });

                // List profiles should return only one profile
                profiles = cdnMgmtClient.Profiles.ListByResourceGroup(resourceGroupName);
                Assert.Equal(1, profiles.Count());

                // Wait for second profile to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Delete second profile but don't wait for operation to complete
                cdnMgmtClient.Profiles.BeginDeleteIfExistsAsync(profileName2, resourceGroupName).Wait(2000);

                // Get second profile returns profile in Deleting state
                existingProfile = cdnMgmtClient.Profiles.Get(profileName2, resourceGroupName);
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
                var profiles = cdnMgmtClient.Profiles.ListBySubscriptionId();
                Assert.Equal(0, profiles.Count());

                // Create resource group
                var resourceGroupName1 = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                ProfileCreateParameters createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName1);
                VerifyProfileCreated(profile, createParameters);

                // Get profile returns the created profile
                var existingProfile = cdnMgmtClient.Profiles.Get(profileName, resourceGroupName1);
                VerifyProfilesEqual(profile, existingProfile);

                // List profiles should return one profile
                profiles = cdnMgmtClient.Profiles.ListBySubscriptionId();
                Assert.Equal(1, profiles.Count());

                // Create another resource group
                var resourceGroupName2 = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a second cdn profile and don't wait for creation to finish
                var profileName2 = TestUtilities.GenerateName("profile");
                createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                profile = cdnMgmtClient.Profiles.Create(profileName2, createParameters, resourceGroupName2);
                VerifyProfileCreated(profile, createParameters);

                // List profiles should return two profiles
                profiles = cdnMgmtClient.Profiles.ListBySubscriptionId();
                Assert.Equal(2, profiles.Count());

                // Delete first profile
                cdnMgmtClient.Profiles.DeleteIfExists(profileName, resourceGroupName1);

                // List profiles should return only one profile
                profiles = cdnMgmtClient.Profiles.ListBySubscriptionId();
                Assert.Equal(1, profiles.Count());

                // Delete second profile
                cdnMgmtClient.Profiles.DeleteIfExists(profileName2, resourceGroupName2);

                // List profiles should none
                profiles = cdnMgmtClient.Profiles.ListBySubscriptionId();
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
                ProfileCreateParameters createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                var profile = cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName);
                VerifyProfileCreated(profile, createParameters);

                // Generate Sso Uri on created profile should succeed
                var ssoUri = cdnMgmtClient.Profiles.GenerateSsoUri(profileName, resourceGroupName);
                Assert.NotNull(ssoUri);
                Assert.False(string.IsNullOrWhiteSpace(ssoUri.SsoUriValue));

                // Create a cdn profile and don't wait for creation to finish
                profileName = TestUtilities.GenerateName("profile");
                createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                cdnMgmtClient.Profiles.BeginCreateAsync(profileName, createParameters, resourceGroupName).Wait(2000);

                // Generate Sso Uri on creating profile should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Profiles.GenerateSsoUri(profileName, resourceGroupName); });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        private static void VerifyProfileCreated(Profile profile, ProfileCreateParameters parameters)
        {
            Assert.Equal(profile.Location, parameters.Location);
            Assert.Equal(profile.Sku.Name, parameters.Sku.Name);
            Assert.Equal(profile.Tags.Count, parameters.Tags.Count);
            Assert.True(profile.Tags.SequenceEqual(parameters.Tags));
            Assert.Equal(profile.ProvisioningState, ProvisioningState.Succeeded);
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