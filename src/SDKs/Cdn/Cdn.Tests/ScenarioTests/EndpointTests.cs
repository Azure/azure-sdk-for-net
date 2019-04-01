// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

                // Create a cdn endpoint with minimum requirements should succeed
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
                var existingEndpoint = cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpointName);

                // Create endpoint with same name should fail
                endpointCreateParameters = new Endpoint
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
                    cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                });

                // Create a cdn endpoint with full properties should succeed
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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
                    },
                    GeoFilters = new List<GeoFilter>
                    {
                        new GeoFilter {
                            RelativePath = "/mycar",
                            Action = GeoFilterActions.Block,
                            CountryCodes = new List<string>
                            {
                                "AT"
                            }
                        }
                    },
                    DeliveryPolicy = new EndpointPropertiesUpdateParametersDeliveryPolicy
                    {
                        Description = "Test description for a policy.",
                        Rules = new List<DeliveryRule>
                        {
                            new DeliveryRule
                            {
                                Order = 1,
                                Actions = new List<DeliveryRuleAction>
                                {
                                    new DeliveryRuleCacheExpirationAction
                                    {
                                       Parameters = new CacheExpirationActionParameters
                                       {
                                           CacheBehavior = "Override",
                                           CacheDuration = "10:10:09"
                                       }
                                    }
                                },
                                Conditions = new List<DeliveryRuleCondition>
                                {
                                    new DeliveryRuleUrlPathCondition
                                    {
                                        Parameters = new UrlPathConditionParameters
                                        {
                                            Path = "/folder",
                                            MatchType = "Literal"
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                endpoint = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                Assert.NotNull(endpoint);

                // Create a cdn endpoint with DSA should succeed
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
                {
                    Location = "WestUs",
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    IsCompressionEnabled = false,
                    OriginHostHeader = "azurecdn-files.azureedge.net",
                    OriginPath = "/dsa-test",
                    QueryStringCachingBehavior = QueryStringCachingBehavior.NotSet,
                    OptimizationType = OptimizationType.DynamicSiteAcceleration,
                    ProbePath = "/probe-v.txt",
                    ContentTypesToCompress = new List<string>(),
                    Tags = new Dictionary<string, string> { { "kay1", "value1" } },
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin1",
                            HostName = "host1.hello.com"
                        }
                    },
                    GeoFilters = new List<GeoFilter>
                    {
                        new GeoFilter {
                            RelativePath = "/mycar",
                            Action = GeoFilterActions.Block,
                            CountryCodes = new List<string>
                            {
                                "AT"
                            }
                        }
                    }
                };

                endpoint = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                Assert.NotNull(endpoint);

                // Create a cdn endpoint with Large File Download should succeed
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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
                    },
                    OptimizationType = OptimizationType.LargeFileDownload,
                    Tags = new Dictionary<string, string> { { "kay1", "value1" } },
                    GeoFilters = new List<GeoFilter>
                    {
                        new GeoFilter {
                            RelativePath = "/mycar",
                            Action = GeoFilterActions.Block,
                            CountryCodes = new List<string>
                            {
                                "AT"
                            }
                        }
                    }
                };

                endpoint = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                Assert.NotNull(endpoint);

                // Create a cdn endpoint with Delivery Policy should succeed
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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
                    },
                    DeliveryPolicy = new EndpointPropertiesUpdateParametersDeliveryPolicy
                    {
                        Description = "Test description for a policy.",
                        Rules = new List<DeliveryRule>
                        {
                            new DeliveryRule
                            {
                                Order = 1,
                                Actions = new List<DeliveryRuleAction>
                                {
                                    new DeliveryRuleCacheExpirationAction
                                    {
                                       Parameters = new CacheExpirationActionParameters
                                       {
                                           CacheBehavior = "BypassCache",
                                           CacheDuration = null
                                       }
                                    }
                                },
                                Conditions = new List<DeliveryRuleCondition>
                                {
                                    new DeliveryRuleUrlPathCondition
                                    {
                                        Parameters = new UrlPathConditionParameters
                                        {
                                            Path = "/folder",
                                            MatchType = "Literal"
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                endpoint = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                Assert.NotNull(endpoint);

                // Create a cdn endpoint with an invalid Delivery Policy should fail
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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
                    },
                    DeliveryPolicy = new EndpointPropertiesUpdateParametersDeliveryPolicy
                    {
                        Description = "Test description for a policy.",
                        Rules = new List<DeliveryRule>
                        {
                            new DeliveryRule
                            {
                                Order = 1,
                                Actions = new List<DeliveryRuleAction>
                                {
                                    new DeliveryRuleCacheExpirationAction
                                    {
                                       Parameters = new CacheExpirationActionParameters
                                       {
                                           CacheBehavior = "BypassCache",
                                           CacheDuration = "10:10:09"
                                       }
                                    }
                                },
                                Conditions = new List<DeliveryRuleCondition>
                                {
                                    new DeliveryRuleUrlPathCondition
                                    {
                                        Parameters = new UrlPathConditionParameters
                                        {
                                            Path = "/folder",
                                            MatchType = "Literal"
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                });

                // Create a cdn endpoint with no origins should fail
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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
                    cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                });

                // Create a cdn endpoint with both http and https disallowed should fail
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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
                    cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
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

                // Create a cdn endpoint with minimum requirements should succeed
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
                    },
                    GeoFilters = new List<GeoFilter>
                    {
                        new GeoFilter {
                            RelativePath = "/mypicture",
                            Action = GeoFilterActions.Block,
                            CountryCodes = new List<string>
                            {
                                "AT"
                            }
                        }
                    }
                };

                cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                // Update endpoint with invalid origin path should fail
                var endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginPath = "\\&123invalid_path/.",
                    OriginHostHeader = "www.bing.com"
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateParameters);
                });

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
                    cdnMgmtClient.Endpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateParameters);
                });

                // Update endpoint with invalid geo filter should fail
                endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginPath = "/path/valid",
                    OriginHostHeader = "www.bing.com",
                    IsCompressionEnabled = true,
                    QueryStringCachingBehavior = QueryStringCachingBehavior.IgnoreQueryString,
                    GeoFilters = new List<GeoFilter>
                    {
                        new GeoFilter {
                            RelativePath = "/mycar",
                            Action = GeoFilterActions.Allow,
                            CountryCodes = new List<string>()
                        }
                    }
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateParameters);
                });

                // Update endpoint with an invalid cache duration in a delivery policy should fail
                endpointUpdateParameters = new EndpointUpdateParameters
                {
                    DeliveryPolicy = new EndpointPropertiesUpdateParametersDeliveryPolicy
                    {
                        Description = "Test description for a policy.",
                        Rules = new List<DeliveryRule>
                        {
                            new DeliveryRule
                            {
                                Order = 1,
                                Actions = new List<DeliveryRuleAction>
                                {
                                    new DeliveryRuleCacheExpirationAction
                                    {
                                       Parameters = new CacheExpirationActionParameters
                                       {
                                           CacheBehavior = "BypassCache",
                                           CacheDuration = "10:10:09"
                                       }
                                    }
                                },
                                Conditions = new List<DeliveryRuleCondition>
                                {
                                    new DeliveryRuleUrlPathCondition
                                    {
                                        Parameters = new UrlPathConditionParameters
                                        {
                                            Path = "/folder",
                                            MatchType = "Literal"
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateParameters);
                });

                // Update endpoint with DSA and no probe path should fail
                endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginHostHeader = "azurecdn-files.azureedge.net",
                    OriginPath = "/dsa-test",
                    IsCompressionEnabled = false,
                    QueryStringCachingBehavior = QueryStringCachingBehavior.NotSet,
                    OptimizationType = OptimizationType.DynamicSiteAcceleration,
                    ContentTypesToCompress = new List<string>(),
                    GeoFilters = new List<GeoFilter>
                    {
                        new GeoFilter {
                            RelativePath = "/mycar",
                            Action = GeoFilterActions.Allow,
                            CountryCodes = new List<string>()
                        }
                    }
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateParameters);
                });

                // Update endpoint with valid properties should succeed
                endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginPath = "/path/valid",
                    OriginHostHeader = "www.bing.com",
                    IsCompressionEnabled = true,
                    ContentTypesToCompress = new List<string> { "text/html", "application/octet-stream" },
                    QueryStringCachingBehavior = QueryStringCachingBehavior.IgnoreQueryString,
                    GeoFilters = new List<GeoFilter>
                    {
                        new GeoFilter {
                            RelativePath = "/mycar",
                            Action = GeoFilterActions.Allow,
                            CountryCodes = new List<string>
                            {
                                "AU"
                            }
                        }
                    },
                    DeliveryPolicy = new EndpointPropertiesUpdateParametersDeliveryPolicy
                    {
                        Description = "Test description for a policy.",
                        Rules = new List<DeliveryRule>
                        {
                            new DeliveryRule
                            {
                                Order = 1,
                                Actions = new List<DeliveryRuleAction>
                                {
                                    new DeliveryRuleCacheExpirationAction
                                    {
                                       Parameters = new CacheExpirationActionParameters
                                       {
                                           CacheBehavior = "BypassCache",
                                           CacheDuration = null
                                       }
                                    }
                                },
                                Conditions = new List<DeliveryRuleCondition>
                                {
                                    new DeliveryRuleUrlPathCondition
                                    {
                                        Parameters = new UrlPathConditionParameters
                                        {
                                            Path = "/folder",
                                            MatchType = "Literal"
                                        }
                                    }
                                }
                            }
                        }
                    }   
                };

                var endpoint = cdnMgmtClient.Endpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateParameters);
                Assert.Equal(1, endpoint.GeoFilters.Count);
                Assert.Equal("/mycar", endpoint.GeoFilters[0].RelativePath);
                Assert.Equal(1, endpoint.GeoFilters[0].CountryCodes.Count);

                // Create a cdn endpoint but don't wait for creation to complete
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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

                cdnMgmtClient.Endpoints.BeginCreateAsync(resourceGroupName, profileName, endpointName, endpointCreateParameters)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // Update endpoint in creating state should fail
                endpointUpdateParameters = new EndpointUpdateParameters
                {
                    IsHttpAllowed = false,
                    OriginHostHeader = "www.bing.com"
                };

                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateParameters);
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

                // Create a cdn endpoint with minimum requirements should succeed
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

                cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                // List endpoints should return one
                var endpoints = cdnMgmtClient.Endpoints.ListByProfile(resourceGroupName, profileName);
                Assert.Single(endpoints);

                // Delete existing endpoint should succeed
                cdnMgmtClient.Endpoints.Delete(resourceGroupName, profileName, endpointName);

                // Delete non-existing endpoint should succeed
                cdnMgmtClient.Endpoints.Delete(resourceGroupName, profileName, endpointName);

                // List endpoints should return none
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(resourceGroupName, profileName);
                Assert.Empty(endpoints);

                // Create a cdn endpoint and don't wait for creation to finish
                endpointName = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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

                cdnMgmtClient.Endpoints.BeginCreateAsync(resourceGroupName, profileName, endpointName, endpointCreateParameters)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // Delete endpoint in creating state should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Delete(resourceGroupName, profileName, endpointName);
                });

                // Wait for second endpoint to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Delete endpoint should succeed
                cdnMgmtClient.Endpoints.Delete(resourceGroupName, profileName, endpointName);

                // List endpoints should return none
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(resourceGroupName, profileName);
                Assert.Empty(endpoints);

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

                // List endpoints should return none
                var endpoints = cdnMgmtClient.Endpoints.ListByProfile(resourceGroupName, profileName);
                Assert.Empty(endpoints);

                // Create a cdn endpoint should succeed
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

                // Get endpoint returns the created endpoint
                var existingEndpoint = cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpointName);
                Assert.NotNull(existingEndpoint);
                Assert.Equal(existingEndpoint.ResourceState, EndpointResourceState.Running);

                // List endpoints should return one endpoint
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(resourceGroupName, profileName);
                Assert.Single(endpoints);

                // Create a cdn endpoint and don't wait for creation to finish
                string endpointName2 = TestUtilities.GenerateName("endpoint");
                endpointCreateParameters = new Endpoint
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

                cdnMgmtClient.Endpoints.BeginCreateAsync(resourceGroupName, profileName, endpointName2, endpointCreateParameters)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // List endpoints should return two endpoints
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(resourceGroupName, profileName);
                Assert.Equal(2, endpoints.Count());

                // Delete first endpoint should succeed
                cdnMgmtClient.Endpoints.Delete(resourceGroupName, profileName, endpointName);

                // Get deleted endpoint fails
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpointName);
                });

                // List endpoints should return 1 endpoint
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(resourceGroupName, profileName);
                Assert.Single(endpoints);

                // Wait for second endpoint to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // Delete second endpoint but don't wait for operation to complete
                cdnMgmtClient.Endpoints.BeginDeleteAsync(resourceGroupName, profileName, endpointName2)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                // Get second endpoint returns endpoint in Deleting state
                existingEndpoint = cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpointName2);
                Assert.Equal(existingEndpoint.ResourceState, EndpointResourceState.Deleting);

                // Wait for second endpoint deletion to complete
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                // List endpoints should return none
                endpoints = cdnMgmtClient.Endpoints.ListByProfile(resourceGroupName, profileName);
                Assert.Empty(endpoints);

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

                // Create a cdn endpoint with minimum requirements should succeed
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

                cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                // Stop a running endpoint should succeed
                cdnMgmtClient.Endpoints.Stop(resourceGroupName, profileName, endpointName);
                var endpoint = cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpointName);
                Assert.Equal(endpoint.ResourceState, EndpointResourceState.Stopped);

                // Start a stopped endpoint should succeed
                cdnMgmtClient.Endpoints.Start(resourceGroupName, profileName, endpointName);
                endpoint = cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpointName);
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

                // Create a cdn endpoint with minimum requirements should succeed
                string endpointName = TestUtilities.GenerateName("endpoint");
                var endpointParameter = new Endpoint
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

                cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointParameter);

                // Purge content on endpoint should succeed
                var purgeContentPaths = new List<string>
                {
                    "/movies/*",
                    "/pictures/pic1.jpg"
                };
                cdnMgmtClient.Endpoints.PurgeContent(
                    resourceGroupName,
                    profileName,
                    endpointName,
                    purgeContentPaths);

                // Purge content on non-existing endpoint should fail
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.PurgeContent(
                        resourceGroupName,
                        profileName,
                        "fakeEndpoint",
                        purgeContentPaths);
                });

                // Purge content on endpoint with invalid content paths should fail
                var invalidPurgeContentPaths = new List<string> { "invalidpath!" };
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.PurgeContent(
                        resourceGroupName,
                        profileName,
                        endpointName,
                        invalidPurgeContentPaths);
                });

                // Load content on endpoint should succeed
                var loadContentPaths = new List<string>
                {
                    "/movies/amazing.mp4",
                    "/pictures/pic1.jpg"
                };
                cdnMgmtClient.Endpoints.LoadContent(
                    resourceGroupName,
                    profileName,
                    endpointName,
                    loadContentPaths);

                // Load content on non-existing endpoint should fail
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.LoadContent(
                        resourceGroupName,
                        profileName,
                        "fakeEndpoint",
                        loadContentPaths);
                });

                // Load content on endpoint with invalid content paths should fail
                var invalidLoadContentPaths = new List<string> { "/movies/*" };
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.LoadContent(
                        resourceGroupName,
                        profileName,
                        endpointName,
                        invalidLoadContentPaths);
                });

                // Stop the running endpoint
                cdnMgmtClient.Endpoints.Stop(resourceGroupName, profileName, endpointName);
                var endpoint = cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpointName);
                Assert.Equal(endpoint.ResourceState, EndpointResourceState.Stopped);

                // Purge content on stopped endpoint should fail
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.PurgeContent(
                        resourceGroupName,
                        profileName,
                        endpointName,
                        purgeContentPaths);
                });

                // Load content on stopped endpoint should fail
                Assert.Throws<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.LoadContent(
                        resourceGroupName,
                        profileName,
                        endpointName,
                        loadContentPaths);
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

                var profile = cdnMgmtClient.Profiles.Create(
                    resourceGroupName,
                    profileName,
                    createParameters);

                // Create a cdn endpoint with minimum requirements
                string endpointName = "endpoint-8e02deffed3c";
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

                var endpoint = cdnMgmtClient.Endpoints.Create(
                    resourceGroupName,
                    profileName,
                    endpointName,
                    endpointCreateParameters);

                //NOTE: There is a CName mapping already created for this custom domain and endpoint hostname
                // "customdomain34.azureedge-test.net" maps to "endpoint-8e02deffed3c.azureedge.net"

                // Validate exisiting custom domain should return true
                var output = cdnMgmtClient.Endpoints.ValidateCustomDomain(
                    resourceGroupName,
                    profileName,
                    endpointName,
                    "customdomain34.azureedge-test.net");
                Assert.True(output.CustomDomainValidated);

                // Validate non-exisiting custom domain should return false
                output = cdnMgmtClient.Endpoints.ValidateCustomDomain(
                    resourceGroupName,
                    profileName,
                    endpointName,
                    "customdomain4.hello.com");
                Assert.False(output.CustomDomainValidated);

                // Validate invalid custom domain should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.Endpoints.ValidateCustomDomain(
                        resourceGroupName,
                        profileName,
                        endpointName,
                        "invalid\\custom/domain");
                });

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void EndpointCheckUsageTest()
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

                // Check usage should return one with current value being zero
                var endpointLevelUsage = cdnMgmtClient.Endpoints.ListResourceUsage(resourceGroupName, profileName, endpointName);
                Assert.Equal(2, endpointLevelUsage.Count());

                var defaultEndpointLevelGeoFilterUsage = endpointLevelUsage.First(u => u.ResourceType.Equals("geofilter"));
                Assert.Equal(25, defaultEndpointLevelGeoFilterUsage.Limit);
                Assert.Equal(0, defaultEndpointLevelGeoFilterUsage.CurrentValue);

                //Update endpoint to have geo filters
                var endpointUpdateParameters = new EndpointUpdateParameters
                {
                    GeoFilters = new List<GeoFilter>
                    {
                        new GeoFilter {
                            RelativePath = "/mycar",
                            Action = GeoFilterActions.Allow,
                            CountryCodes = new List<string>
                            {
                                "AU"
                            }
                        },
                        new GeoFilter {
                            RelativePath = "/mycars",
                            Action = GeoFilterActions.Allow,
                            CountryCodes = new List<string>
                            {
                                "AU"
                            }
                        }
                    }
                };

                endpoint = cdnMgmtClient.Endpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateParameters);

                // Check usage again
                endpointLevelUsage = cdnMgmtClient.Endpoints.ListResourceUsage(resourceGroupName, profileName, endpointName);
                Assert.Equal(2, endpointLevelUsage.Count());

                var endpointLevelGeoFilterUsage = endpointLevelUsage.First(u => u.ResourceType.Equals("geofilter"));
                Assert.Equal(25, endpointLevelGeoFilterUsage.Limit);
                Assert.Equal(2, endpointLevelGeoFilterUsage.CurrentValue);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}