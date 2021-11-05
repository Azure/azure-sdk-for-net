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
    public class AFDOriginGroupTest
    {
        public const int MaximumAfdOriginCountPerOriginGroup = 10;

        [Fact]
        public void AFDOriginGroupCreateTest()
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
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDOriginGroupUpdateTest()
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
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);
                    Assert.NotNull(originGroup);

                    var originGroupUpdateProperties = new AFDOriginGroupUpdateParameters
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
                    var updateOriginGroup = cdnMgmtClient.AFDOriginGroups.Update(resourceGroupName, profileName, originGroupName, originGroupUpdateProperties);
                    VerifyOriginGroupUpdated(originGroupUpdateProperties, updateOriginGroup);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDOriginGroupDeleteTest()
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
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);
                    Assert.NotNull(originGroup);

                    cdnMgmtClient.AFDOriginGroups.Delete(resourceGroupName, profileName, originGroupName);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }


        [Fact]
        public void AFDOriginGroupGetListTest()
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

                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);
                    Assert.NotNull(originGroup);
                    var getOriginGroup = cdnMgmtClient.AFDOriginGroups.Get(resourceGroupName, profileName, originGroupName);
                    Assert.NotNull(getOriginGroup);
                    Assert.Equal(originGroupName, getOriginGroup.Name);

                    string originGroupName2 = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters2 = new AFDOriginGroup(name: originGroupName)
                    {
                    };
                    var originGroup2 = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName2, originGroupCreateParameters2);
                    Assert.NotNull(originGroup2);
                    var getOriginGroup2 = cdnMgmtClient.AFDOriginGroups.Get(resourceGroupName, profileName, originGroupName2);
                    Assert.NotNull(getOriginGroup2);
                    Assert.Equal(originGroupName2, getOriginGroup2.Name);

                    var groupList = cdnMgmtClient.AFDOriginGroups.ListByProfile(resourceGroupName, profileName);
                    Assert.Equal(2, groupList.Count());
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDOriginGroupListResourceUsageTest()
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

                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);

                    var usageList = cdnMgmtClient.AFDOriginGroups.ListResourceUsage(resourceGroupName, profileName, originGroupName);
                    Assert.Single(usageList);
                    var usage = usageList.First();
                    Assert.Equal(MaximumAfdOriginCountPerOriginGroup, usage.Limit);
                    Assert.Equal(0, usage.CurrentValue);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }


        private static void VerifyOriginGroupUpdated(AFDOriginGroupUpdateParameters parameters, AFDOriginGroup originGroup)
        {
            Assert.Equal(parameters.LoadBalancingSettings.SampleSize, originGroup.LoadBalancingSettings.SampleSize);
            Assert.Equal(parameters.LoadBalancingSettings.SuccessfulSamplesRequired, originGroup.LoadBalancingSettings.SuccessfulSamplesRequired);
            Assert.Equal(parameters.LoadBalancingSettings.AdditionalLatencyInMilliseconds, originGroup.LoadBalancingSettings.AdditionalLatencyInMilliseconds);


            Assert.Equal(parameters.HealthProbeSettings.ProbeIntervalInSeconds, originGroup.HealthProbeSettings.ProbeIntervalInSeconds);
            Assert.Equal(parameters.HealthProbeSettings.ProbePath, originGroup.HealthProbeSettings.ProbePath);
            Assert.Equal(parameters.HealthProbeSettings.ProbeProtocol, originGroup.HealthProbeSettings.ProbeProtocol);
            Assert.Equal(parameters.HealthProbeSettings.ProbeRequestType, originGroup.HealthProbeSettings.ProbeRequestType);
        }
    }
}
