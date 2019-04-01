// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    public class OriginTests
    {
        [Fact]
        public void OriginUpdateTest()
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

                // Create a cdn endpoint with minimum requirements
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

                // Update origin on running endpoint should succeed
                var originParameters = new OriginUpdateParameters
                {
                    HostName = "www.bing.com",
                    HttpPort = 1234,
                    HttpsPort = 8081
                };

                cdnMgmtClient.Origins.Update(resourceGroupName, profileName, endpointName, "origin1", originParameters);

                // Update origin with invalid hostname should fail
                originParameters = new OriginUpdateParameters
                {
                    HostName = "invalid!Hostname&",
                    HttpPort = 1234,
                    HttpsPort = 8081
                };

                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.Origins.Update(resourceGroupName, profileName, endpointName, "origin1", originParameters);
                });

                // Stop endpoint should succeed
                cdnMgmtClient.Endpoints.Stop(resourceGroupName, profileName, endpointName);

                // Update origin on stopped endpoint should succeed
                originParameters = new OriginUpdateParameters
                {
                    HostName = "www.hello.com",
                    HttpPort = 1265
                };

                cdnMgmtClient.Origins.Update(resourceGroupName, profileName, endpointName, "origin1", originParameters);

                // Update origin with invalid ports should fail
                originParameters = new OriginUpdateParameters
                {
                    HttpPort = 99999,
                    HttpsPort = -2000
                };

                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.Origins.Update(resourceGroupName, profileName, endpointName, "origin1", originParameters);
                });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void OriginGetListTest()
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

                // Create a cdn endpoint with minimum requirements
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

                // Get origin on endpoint should return the deep created origin
                var origin = cdnMgmtClient.Origins.Get(resourceGroupName, profileName, endpointName, "origin1");
                Assert.NotNull(origin);

                // Get origins on endpoint should return one
                var origins = cdnMgmtClient.Origins.ListByEndpoint(resourceGroupName, profileName, endpointName);
                Assert.Single(origins);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
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