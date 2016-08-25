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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading;
using Microsoft.Rest;

namespace Cdn.Tests.ScenarioTests
{
    public class EndpointTests
    {
        [Fact]
        public void EndpointCreateTest()
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

                // Create a cdn endpoint with minimum requirements should succeed
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
                var existingEndpoint = cdnMgmtClient.Endpoints.Get(endpointName, profileName, resourceGroupName);

                // Create endpoint with same name should fail
                endpointCreateParameters = new EndpointCreateParameters
                {
                    Location = "EastUs",
                    IsHttpAllowed = false,
                    IsHttpsAllowed = true,
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin2",
                            HostName = "host2.hello.com"
                        }
                    }
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);
                });

                // Create a cdn endpoint with full properties should succeed
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new EndpointCreateParameters
                {
                    Location = "WestUs",
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    IsCompressionEnabled = true,
                    OriginHostHeader = "www.bing.com",
                    OriginPath = "/photos",
                    QueryStringCachingBehavior = QueryStringCachingBehavior.BypassCaching,
                    ContentTypesToCompress = new List<string> { "text/html", "application/octet-stream" },
                    Tags = new Dictionary<string, string> { { "kay1", "value1" } },
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin1",
                            HostName = "host1.hello.com"
                        }
                    }
                };

                endpoint = cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);
                Assert.NotNull(endpoint);

                // Create a cdn endpoint with no origins should fail
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new EndpointCreateParameters
                {
                    Location = "WestUs",
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    IsCompressionEnabled = true,
                    OriginHostHeader = "www.bing.com",
                    OriginPath = "/photos",
                    QueryStringCachingBehavior = QueryStringCachingBehavior.BypassCaching,
                    ContentTypesToCompress = new List<string> { "text/html", "application/octet-stream" },
                    Tags = new Dictionary<string, string> { { "kay1", "value1" } }
                };

                Assert.ThrowsAny<ValidationException>(() => {
                    cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName); });

                // Create a cdn endpoint with both http and https disallowed should fail
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new EndpointCreateParameters
                {
                    Location = "WestUs",
                    IsHttpAllowed = false,
                    IsHttpsAllowed = false,
                    IsCompressionEnabled = true,
                    OriginHostHeader = "www.bing.com",
                    OriginPath = "/photos",
                    QueryStringCachingBehavior = QueryStringCachingBehavior.BypassCaching,
                    ContentTypesToCompress = new List<string> { "text/html", "application/octet-stream" },
                    Tags = new Dictionary<string, string> { { "kay1", "value1" } }
                };

                Assert.ThrowsAny<ValidationException>(() => {
                    cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);
                });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void EndpointUpdateTest()
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

                // Create a cdn endpoint with minimum requirements should succeed
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

                cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // Update endpoint with invalid origin path should fail
                var endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginPath = "\\&123invalid_path/.",
                    OriginHostHeader = "www.bing.com"
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Update(endpointName, endpointUpdateParameters, profileName, resourceGroupName); });

                // Update endpoint to enable compression without specifying compression types should fail
                endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginPath = "/path/valid",
                    OriginHostHeader = "www.bing.com",
                    IsCompressionEnabled = true,
                    QueryStringCachingBehavior = QueryStringCachingBehavior.IgnoreQueryString
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Update(endpointName, endpointUpdateParameters, profileName, resourceGroupName); });

                // Update endpoint with valid properties should succeed
                endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginPath = "/path/valid",
                    OriginHostHeader = "www.bing.com",
                    IsCompressionEnabled = true,
                    ContentTypesToCompress = new List<string> { "text/html", "application/octet-stream" },
                    QueryStringCachingBehavior = QueryStringCachingBehavior.IgnoreQueryString
                };

                var endpoint = cdnMgmtClient.Endpoints.Update(endpointName, endpointUpdateParameters, profileName, resourceGroupName);

                // Create a cdn endpoint but don't wait for creation to complete
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
                            HostName = "host1.hello.com"
                        }
                    }
                };

                cdnMgmtClient.Endpoints.BeginCreateAsync(endpointName, endpointCreateParameters, profileName, resourceGroupName).Wait(5000);

                // Update endpoint in creating state should fail
                endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginHostHeader = "www.bing.com"
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Update(endpointName, endpointUpdateParameters, profileName, resourceGroupName);
                });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void EndpointDeleteTest()
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

                // Create a cdn endpoint with minimum requirements should succeed
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

                cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // List endpoints should return one
                var endpoints = cdnMgmtClient.Endpoints.ListByProfile(profileName, resourceGroupName);
                Assert.Equal(1, endpoints.Count());

                // Delete existing endpoint should succeed
                cdnMgmtClient.Endpoints.DeleteIfExists(endpointName, profileName, resourceGroupName);

                // Delete non-existing endpoint should succeed
                cdnMgmtClient.Endpoints.DeleteIfExists(endpointName, profileName, resourceGroupName);

                // List endpoints should return none
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(profileName, resourceGroupName);
                Assert.Equal(0, endpoints.Count());

                // Create a cdn endpoint and don't wait for creation to finish
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
                            HostName = "host1.hello.com"
                        }
                    }
                };

                cdnMgmtClient.Endpoints.BeginCreateAsync(endpointName, endpointCreateParameters, profileName, resourceGroupName).Wait(5000);

                // Delete endpoint in creating state should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.DeleteIfExists(endpointName, profileName, resourceGroupName); });

                // Wait for second endpoint to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Delete endpoint should succeed
                cdnMgmtClient.Endpoints.DeleteIfExists(endpointName, profileName, resourceGroupName);

                // List endpoints should return none
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(profileName, resourceGroupName);
                Assert.Equal(0, endpoints.Count());

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void EndpointGetListTest()
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

                // List endpoints should return none
                var endpoints = cdnMgmtClient.Endpoints.ListByProfile(profileName, resourceGroupName);
                Assert.Equal(0, endpoints.Count());

                // Create a cdn endpoint should succeed
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

                // Get endpoint returns the created endpoint
                var existingEndpoint = cdnMgmtClient.Endpoints.Get(endpointName, profileName, resourceGroupName);
                Assert.NotNull(existingEndpoint);
                Assert.Equal(existingEndpoint.ResourceState, EndpointResourceState.Running);

                // List endpoints should return one endpoint
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(profileName, resourceGroupName);
                Assert.Equal(1, endpoints.Count());

                // Create a cdn endpoint and don't wait for creation to finish
                string endpointName2 = TestUtilities.GenerateName("endpoint");
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
                            HostName = "host1.hello.com"
                        }
                    }
                };

                cdnMgmtClient.Endpoints.BeginCreateAsync(endpointName2, endpointCreateParameters, profileName, resourceGroupName).Wait(5000);

                // List endpoints should return two endpoints
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(profileName, resourceGroupName);
                Assert.Equal(2, endpoints.Count());

                // Delete first endpoint should succeed
                cdnMgmtClient.Endpoints.DeleteIfExists(endpointName, profileName, resourceGroupName);

                // Get deleted endpoint fails
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Get(endpointName, profileName, resourceGroupName);
                });

                // List endpoints should return 1 endpoint
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(profileName, resourceGroupName);
                Assert.Equal(1, endpoints.Count());

                // Wait for second endpoint to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Delete second endpoint but don't wait for operation to complete
                cdnMgmtClient.Endpoints.BeginDeleteIfExistsAsync(endpointName2, profileName, resourceGroupName).Wait(2000);

                // Get second endpoint returns endpoint in Deleting state
                existingEndpoint = cdnMgmtClient.Endpoints.Get(endpointName2, profileName, resourceGroupName);
                Assert.Equal(existingEndpoint.ResourceState, EndpointResourceState.Deleting);

                // Wait for second endpoint deletion to complete
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // List endpoints should return none
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(profileName, resourceGroupName);
                Assert.Equal(0, endpoints.Count());

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void EndpointStartStopTest()
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

                // Create a cdn endpoint with minimum requirements should succeed
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

                cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // Stop a running endpoint should succeed
                cdnMgmtClient.Endpoints.Stop(endpointName, profileName, resourceGroupName);
                var endpoint = cdnMgmtClient.Endpoints.Get(endpointName, profileName, resourceGroupName);
                Assert.Equal(endpoint.ResourceState, EndpointResourceState.Stopped);

                // Start a stopped endpoint should succeed
                cdnMgmtClient.Endpoints.Start(endpointName, profileName, resourceGroupName);
                endpoint = cdnMgmtClient.Endpoints.Get(endpointName, profileName, resourceGroupName);
                Assert.Equal(endpoint.ResourceState, EndpointResourceState.Running);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void EndpointPurgeLoadTest()
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

                // Create a cdn endpoint with minimum requirements should succeed
                string endpointName = TestUtilities.GenerateName("endpoint");
                var endpointCreateParameters = new EndpointCreateParameters
                {
                    Location = "WestUs",
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    IsCompressionEnabled = true,
                    OriginHostHeader = "www.bing.com",
                    OriginPath = "/photos",
                    QueryStringCachingBehavior = QueryStringCachingBehavior.IgnoreQueryString,
                    ContentTypesToCompress = new List<string> { "text/html", "text/css" },
                    Tags = new Dictionary<string, string> { { "kay1", "value1" } },
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = TestUtilities.GenerateName("origin"),
                            HostName = "custom.hello.com"
                        }
                    }
                };

                cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // Purge content on endpoint should succeed
                var purgeContentPaths = new List<string>
                {
                    "/movies/*",
                    "/pictures/pic1.jpg"
                };
                cdnMgmtClient.Endpoints.PurgeContent(endpointName, profileName, resourceGroupName, purgeContentPaths);

                // Purge content on non-existing endpoint should fail
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.PurgeContent("fakeEndpoint", profileName, resourceGroupName, purgeContentPaths);
                });

                // Purge content on endpoint with invalid content paths should fail
                var invalidPurgeContentPaths = new List<string> { "invalidpath!" };
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.PurgeContent(endpointName, profileName, resourceGroupName, invalidPurgeContentPaths); });

                // Load content on endpoint should succeed
                var loadContentPaths = new List<string>
                {
                    "/movies/amazing.mp4",
                    "/pictures/pic1.jpg"
                };
                cdnMgmtClient.Endpoints.LoadContent(endpointName, profileName, resourceGroupName, loadContentPaths);

                // Load content on non-existing endpoint should fail
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.LoadContent("fakeEndpoint", profileName, resourceGroupName, loadContentPaths);
                });

                // Load content on endpoint with invalid content paths should fail
                var invalidLoadContentPaths = new List<string> { "/movies/*" };
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.LoadContent(endpointName, profileName, resourceGroupName, invalidLoadContentPaths);
                });

                // Stop the running endpoint
                cdnMgmtClient.Endpoints.Stop(endpointName, profileName, resourceGroupName);
                var endpoint = cdnMgmtClient.Endpoints.Get(endpointName, profileName, resourceGroupName);
                Assert.Equal(endpoint.ResourceState, EndpointResourceState.Stopped);

                // Purge content on stopped endpoint should fail
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.PurgeContent(endpointName, profileName, resourceGroupName, purgeContentPaths);
                });

                // Load content on stopped endpoint should fail
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.LoadContent(endpointName, profileName, resourceGroupName, loadContentPaths);
                });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void ValidateCustomDomainTest()
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
                string endpointName = "endpoint-5b4f5e6b9ea6";
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

                //NOTE: There is a CName mapping already created for this custom domain and endpoint hostname
                // "customdomain31.azureedge-test.net" maps to "endpoint-5b4f5e6b9ea6.azureedge-test.net"

                // Validate exisiting custom domain should return true
                var output = cdnMgmtClient.Endpoints.ValidateCustomDomain(endpointName, profileName, resourceGroupName, "customdomain31.azureedge-test.net");
                Assert.Equal(output.CustomDomainValidated, true);

                // Validate non-exisiting custom domain should return false
                output = cdnMgmtClient.Endpoints.ValidateCustomDomain(endpointName, profileName, resourceGroupName, "customdomain4.hello.com");
                Assert.Equal(output.CustomDomainValidated, false);

                // Validate invalid custom domain should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.ValidateCustomDomain(endpointName, profileName, resourceGroupName, "invalid\\custom/domain"); });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}