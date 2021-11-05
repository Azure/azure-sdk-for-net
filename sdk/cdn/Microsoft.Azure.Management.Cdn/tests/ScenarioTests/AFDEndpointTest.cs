// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Cdn.Tests.Helpers;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Cdn.Tests.ScenarioTests
{
    public class AFDEndpointTest
    {
        private const long usageLimit = 25L;

        [Fact]
        public void AFDEndpointCreateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, endpoint);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDEndpointUpdateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, endpoint);

                    AFDEndpointUpdateParameters endpointUpdateProperties = new AFDEndpointUpdateParameters
                    {
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1updated"},
                            {"key2","value2updated"}
                        },
                        OriginResponseTimeoutSeconds = 80,
                        EnabledState = EnabledState.Disabled,
                    };
                    var updatedEndpoint = cdnMgmtClient.AFDEndpoints.Update(resourceGroupName, profileName, endpointName, endpointUpdateProperties);
                    VerifyEndpointUpdated(endpointUpdateProperties, updatedEndpoint);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDEndpointDeleteTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, endpoint);

                    cdnMgmtClient.AFDEndpoints.Delete(resourceGroupName, profileName, endpointName);

                    Assert.ThrowsAny<AfdErrorResponseException>(() =>
                    {
                        var deletedOrigin = cdnMgmtClient.AFDEndpoints.Get(resourceGroupName, profileName, endpointName);
                        _ = deletedOrigin;
                    });
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDEndpointGetListTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        },
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, endpoint);

                    var getEndPoint = cdnMgmtClient.AFDEndpoints.Get(resourceGroupName, profileName, endpointName);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, getEndPoint);

                    var listEndpoints = cdnMgmtClient.AFDEndpoints.ListByProfile(resourceGroupName, profileName);
                    Assert.Single(listEndpoints);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, listEndpoints.First());
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDEndpointPurgeTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        },
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, endpoint);

                    var contentPaths = new List<string>()
                    {
                        "/a"
                    };
                    var domains = new List<string>()
                    {
                        endpoint.HostName
                    };

                    //cdnMgmtClient.AFDEndpoints.PurgeContent(resourceGroupName, profileName, endpointName, contentPaths, domains);
                    //cdnMgmtClient.AFDEndpoints.ListResourceUsage
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDEndpointValidateCustomDomainTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        },
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, endpoint);

                    string hostName = "hello.happy.test.com";
                    var validateResult = cdnMgmtClient.AFDEndpoints.ValidateCustomDomain(resourceGroupName, profileName, endpointName, hostName);
                    Assert.False(validateResult.CustomDomainValidated);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDEndpointListResourceUsageTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        },
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);
                    VerifyEndpointCreated(endpointName, endpointCreateParameters, endpoint);

                    var usages = cdnMgmtClient.AFDEndpoints.ListResourceUsage(resourceGroupName, profileName, endpointName);
                    Assert.NotNull(usages);
                    foreach (var usage in usages)
                    {
                        Assert.NotNull(usage);
                        Assert.Equal(0L, usage.CurrentValue);
                        Assert.Equal(usageLimit, usage.Limit);
                    }
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        private static void VerifyEndpointCreated(string endpointName, AFDEndpoint endpointCreateParameters, AFDEndpoint endpoint)
        {
            Assert.NotNull(endpoint);
            Assert.Equal(endpointName, endpoint.Name);
            Assert.Equal(endpointCreateParameters.EnabledState, endpoint.EnabledState);
            Assert.Equal(endpointCreateParameters.OriginResponseTimeoutSeconds, endpoint.OriginResponseTimeoutSeconds);

            Assert.Equal(endpointCreateParameters.Tags, endpoint.Tags);
        }

        private static void VerifyEndpointUpdated(AFDEndpointUpdateParameters endpointUpdateProperties, AFDEndpoint endpoint)
        {
            Assert.NotNull(endpoint);
            Assert.Equal(endpointUpdateProperties.EnabledState, endpoint.EnabledState);
            Assert.Equal(endpointUpdateProperties.OriginResponseTimeoutSeconds, endpoint.OriginResponseTimeoutSeconds);
            Assert.Equal(endpointUpdateProperties.Tags, endpoint.Tags);
        }
    }
}
