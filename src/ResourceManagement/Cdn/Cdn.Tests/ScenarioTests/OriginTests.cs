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
    public class OriginTests
    {
        [Fact]
        public void OriginCreateTest()
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

                // Create a cdn endpoint one origin should succeed
                string endpointName = TestUtilities.GenerateName("endpoint");
                var endpointCreateParameters = new EndpointCreateParameters
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

                var endpoint = cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // Create another origin on this endpoint should fail
                string originName = TestUtilities.GenerateName("origin1");
                var originParameters = new OriginParameters
                {
                    HostName = "host1.hello.com",
                    HttpPort = 9874,
                    HttpsPort = 9090
                };

                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.Origins.Create(originName, originParameters, endpointName, profileName, resourceGroupName);
                });

                // Create a cdn endpoint with invalid ports on origin should fail
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new EndpointCreateParameters
                {
                    Location = "WestUs",
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin1",
                            HostName = "host1.hello.com",
                            HttpPort = 99999,
                            HttpsPort = -1111
                        }
                    }
                };

                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.Origins.Create(originName, originParameters, endpointName, profileName, resourceGroupName);
                });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

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

                // Create a cdn endpoint with minimum requirements
                string endpointName = TestUtilities.GenerateName("endpoint");
                var endpointCreateParameters = new EndpointCreateParameters
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

                var endpoint = cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // Update origin on running endpoint should succeed
                var originParameters = new OriginParameters
                {
                    HostName = "www.bing.com",
                    HttpPort = 1234,
                    HttpsPort = 8081
                };

                cdnMgmtClient.Origins.Update("origin1", originParameters, endpointName, profileName, resourceGroupName);

                // Update origin with invalid hostname should fail
                originParameters = new OriginParameters
                {
                    HostName = "invalid!Hostname&",
                    HttpPort = 1234,
                    HttpsPort = 8081
                };

                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.Origins.Update("origin1", originParameters, endpointName, profileName, resourceGroupName);
                });

                // Stop endpoint should succeed
                cdnMgmtClient.Endpoints.Stop(endpointName, profileName, resourceGroupName);

                // Update origin on stopped endpoint should succeed
                originParameters = new OriginParameters
                {
                    HostName = "www.hello.com",
                    HttpPort = 1265
                };

                cdnMgmtClient.Origins.Update("origin1", originParameters, endpointName, profileName, resourceGroupName);

                // Update origin with invalid ports should fail
                originParameters = new OriginParameters
                {
                    HttpPort = 99999,
                    HttpsPort = -2000
                };

                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.Origins.Update("origin1", originParameters, endpointName, profileName, resourceGroupName);
                });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void OriginDeleteTest()
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

                // Create a cdn endpoint with minimum requirements
                string endpointName = TestUtilities.GenerateName("endpoint");
                var endpointCreateParameters = new EndpointCreateParameters
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

                var endpoint = cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // Delete only origin on endpoint should fail
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.Origins.DeleteIfExists("origin1", endpointName, profileName, resourceGroupName);
                });

                // Get origins on endpoint should return one
                var origins = cdnMgmtClient.Origins.ListByEndpoint(endpointName, profileName, resourceGroupName);
                Assert.Equal(1, origins.Count());

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

                // Create a cdn endpoint with minimum requirements
                string endpointName = TestUtilities.GenerateName("endpoint");
                var endpointCreateParameters = new EndpointCreateParameters
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

                var endpoint = cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // Get origin on endpoint should return the deep created origin
                var origin = cdnMgmtClient.Origins.Get("origin1", endpointName, profileName, resourceGroupName);
                Assert.NotNull(origin);

                // Get origins on endpoint should return one
                var origins = cdnMgmtClient.Origins.ListByEndpoint(endpointName, profileName, resourceGroupName);
                Assert.Equal(1, origins.Count());

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