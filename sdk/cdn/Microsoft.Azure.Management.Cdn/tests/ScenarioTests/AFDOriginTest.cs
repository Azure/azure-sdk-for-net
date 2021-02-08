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
    public class AFDOriginTest
    {
        [Fact]
        public void AFDOriginCreateTest()
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

                    string originGroupName = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters = new AFDOriginGroup(name: originGroupName)
                    {
                        LoadBalancingSettings = new LoadBalancingSettingsParameters
                        {
                            SampleSize = 5,
                            SuccessfulSamplesRequired = 4,
                            AdditionalLatencyInMilliseconds = 200,
                        },
                        HealthProbeSettings = new HealthProbeParameters
                        {
                            ProbeIntervalInSeconds = 1,
                            ProbePath = "/",
                            ProbeProtocol = ProbeProtocol.Https,
                            ProbeRequestType = HealthProbeRequestType.GET
                        },
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);
                    Assert.NotNull(originGroup);
                    Assert.Equal(originGroupName, originGroup.Name);

                    string originName = TestUtilities.GenerateName("originName");
                    var hostName = "en.wikipedia.org";
                    var originCreateParameters = new AFDOrigin(hostName: hostName)
                    {
                        OriginHostHeader = hostName,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName, originCreateParameters);
                    VerifyOriginCreated(originName, originCreateParameters, origin);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDOriginUpdateTest()
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

                    string originGroupName = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters = new AFDOriginGroup(name: originGroupName)
                    {
                        LoadBalancingSettings = new LoadBalancingSettingsParameters
                        {
                            SampleSize = 5,
                            SuccessfulSamplesRequired = 4,
                            AdditionalLatencyInMilliseconds = 200,
                        },
                        HealthProbeSettings = new HealthProbeParameters
                        {
                            ProbeIntervalInSeconds = 1,
                            ProbePath = "/",
                            ProbeProtocol = ProbeProtocol.Https,
                            ProbeRequestType = HealthProbeRequestType.GET
                        },
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);
                    Assert.NotNull(originGroup);
                    Assert.Equal(originGroupName, originGroup.Name);

                    string originName = TestUtilities.GenerateName("originName");
                    var hostName = "en.wikipedia.org";
                    var originCreateParameters = new AFDOrigin(hostName: hostName)
                    {
                        OriginHostHeader = hostName,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName, originCreateParameters);
                    VerifyOriginCreated(originName, originCreateParameters, origin);

                    var originUpdateProperties = new AFDOriginUpdateParameters
                    {
                        HostName = "update." + hostName,
                        OriginHostHeader = "update." + hostName,
                        HttpPort = 81,
                        HttpsPort = 443,
                        Priority = 2,
                        Weight = 100,
                    };
                    var updatedOrigin = cdnMgmtClient.AFDOrigins.Update(resourceGroupName, profileName, originGroupName, originName, originUpdateProperties);
                    VerifyOriginUpdated(originUpdateProperties, updatedOrigin);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }


        [Fact]
        public void AFDOriginDeleteTest()
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

                    // Create a standard Azure frontdoor originGroup
                    string originGroupName = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters = new AFDOriginGroup(name: originGroupName)
                    {
                        LoadBalancingSettings = new LoadBalancingSettingsParameters
                        {
                            SampleSize = 5,
                            SuccessfulSamplesRequired = 4,
                            AdditionalLatencyInMilliseconds = 200,
                        },
                        HealthProbeSettings = new HealthProbeParameters
                        {
                            ProbeIntervalInSeconds = 1,
                            ProbePath = "/",
                            ProbeProtocol = ProbeProtocol.Https,
                            ProbeRequestType = HealthProbeRequestType.GET
                        },
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);
                    Assert.NotNull(originGroup);
                    Assert.Equal(originGroupName, originGroup.Name);

                    // Create a standard Azure frontdoor origin
                    string originName = TestUtilities.GenerateName("originName");
                    var hostName = "en.wikipedia.org";
                    var originCreateParameters = new AFDOrigin(hostName: hostName)
                    {
                        OriginHostHeader = hostName,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName, originCreateParameters);
                    VerifyOriginCreated(originName, originCreateParameters, origin);

                    cdnMgmtClient.AFDOrigins.Delete(resourceGroupName, profileName, originGroupName, originName);

                    Assert.ThrowsAny<AfdErrorResponseException>(() =>
                    {
                        var deletedOrigin = cdnMgmtClient.AFDOrigins.Get(resourceGroupName, profileName, originGroupName, originName);
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
        public void AFDOriginGetListTest()
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

                    // Create a originGroup
                    string originGroupName = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters = new AFDOriginGroup(name: originGroupName)
                    {
                        LoadBalancingSettings = new LoadBalancingSettingsParameters
                        {
                            SampleSize = 5,
                            SuccessfulSamplesRequired = 4,
                            AdditionalLatencyInMilliseconds = 200,
                        },
                        HealthProbeSettings = new HealthProbeParameters
                        {
                            ProbeIntervalInSeconds = 1,
                            ProbePath = "/",
                            ProbeProtocol = ProbeProtocol.Https,
                            ProbeRequestType = HealthProbeRequestType.GET
                        },
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);

                    // Create an origin
                    string originName = TestUtilities.GenerateName("originName");
                    var hostName = "en.wikipedia.org";
                    var originCreateParameters = new AFDOrigin(hostName: hostName)
                    {
                        OriginHostHeader = hostName,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName, originCreateParameters);

                    // Get the origin
                    var getOrigin = cdnMgmtClient.AFDOrigins.Get(resourceGroupName, profileName, originGroupName, originName);
                    VerifyOriginCreated(originName, originCreateParameters, getOrigin);
                    // List origins in the originGroup
                    var originList = cdnMgmtClient.AFDOrigins.ListByOriginGroup(resourceGroupName, profileName, originGroupName);
                    Assert.Single(originList);

                    // Create an origin
                    string originName2 = TestUtilities.GenerateName("originName2");
                    var hostName2 = "2.en.wikipedia.org";
                    var originCreateParameters2 = new AFDOrigin(hostName: hostName2)
                    {
                        OriginHostHeader = hostName2,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin2 = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName2, originCreateParameters2);
                    // List origins in the originGroup
                    originList = cdnMgmtClient.AFDOrigins.ListByOriginGroup(resourceGroupName, profileName, originGroupName);
                    Assert.Equal(2, originList.Count());

                    // Delete one origin
                    cdnMgmtClient.AFDOrigins.Delete(resourceGroupName, profileName, originGroupName, originName2);
                    // List origins in the originGroup
                    originList = cdnMgmtClient.AFDOrigins.ListByOriginGroup(resourceGroupName, profileName, originGroupName);
                    Assert.Single(originList);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }


        private static void VerifyOriginCreated(string originName, AFDOrigin originCreateParameters, AFDOrigin origin)
        {
            Assert.NotNull(origin);
            Assert.Equal(originName, origin.Name);
            Assert.Equal(originCreateParameters.HostName, origin.HostName);
            Assert.Equal(originCreateParameters.OriginHostHeader, origin.OriginHostHeader);
            Assert.Equal(originCreateParameters.HttpPort, origin.HttpPort);
            Assert.Equal(originCreateParameters.HttpsPort, origin.HttpsPort);
            Assert.Equal(originCreateParameters.Priority, origin.Priority);
            Assert.Equal(originCreateParameters.Weight, origin.Weight);
        }

        private static void VerifyOriginUpdated(AFDOriginUpdateParameters originUpdateProperties, AFDOrigin origin)
        {
            Assert.NotNull(origin);
            Assert.Equal(originUpdateProperties.HostName, origin.HostName);
            Assert.Equal(originUpdateProperties.OriginHostHeader, origin.OriginHostHeader);
            Assert.Equal(originUpdateProperties.HttpPort, origin.HttpPort);
            Assert.Equal(originUpdateProperties.HttpsPort, origin.HttpsPort);
            Assert.Equal(originUpdateProperties.Priority, origin.Priority);
            Assert.Equal(originUpdateProperties.Weight, origin.Weight);
        }
    }
}
