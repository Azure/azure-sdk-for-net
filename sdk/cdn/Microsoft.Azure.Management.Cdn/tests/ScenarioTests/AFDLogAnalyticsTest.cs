// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
    public class AFDLogAnalyticsTest
    {
        [Fact]
        public void GetLogAnalyticsMetricsTest()
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
                    var domain = $"{endpointName}.z01.azurefd.net";

                    IList<string> metrics = new List<string>() {
                        LogMetric.ClientRequestCount
                    };
                    DateTime dateTimeBegin = new DateTime(2021, 1, 27, 0, 0, 0);
                    DateTime dateTimeEnd = new DateTime(2021, 1, 27, 0, 0, 1);
                    string granularity = LogMetricsGranularity.PT5M;
                    IList<string> customDomains = new List<string>(){
                        domain
                    };
                    IList<string> protocols = new List<string>(){
                        "http"
                    };
                    MetricsResponse response = cdnMgmtClient.LogAnalytics.GetLogAnalyticsMetrics(resourceGroupName, profileName, metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols);
                    Assert.NotNull(response);
                    Assert.Equal(dateTimeBegin, response.DateTimeBegin);
                    Assert.Equal(dateTimeEnd, response.DateTimeEnd);
                    Assert.Equal(granularity, response.Granularity);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }


        [Fact]
        public void GetLogAnalyticsRankingsTest()
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


                    IList<string> rankings = new List<string>() {
                        LogRanking.Url
                    };
                    IList<string> metrics = new List<string>() {
                        LogRankingMetric.ClientRequestCount
                    };
                    int maxRanking = 50;
                    DateTime dateTimeBegin = new DateTime(2021, 1, 27, 0, 0, 0);
                    DateTime dateTimeEnd = new DateTime(2021, 1, 27, 0, 0, 1);
                    RankingsResponse response = cdnMgmtClient.LogAnalytics.GetLogAnalyticsRankings(resourceGroupName, profileName, rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd);
                    Assert.NotNull(response);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void GetLogAnalyticsLocationsTest()
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


                    ContinentsResponse response = cdnMgmtClient.LogAnalytics.GetLogAnalyticsLocations(resourceGroupName, profileName);
                    Assert.NotNull(response);
                    Assert.NotEmpty(response.Continents);
                    Assert.NotEmpty(response.CountryOrRegions);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void GetLogAnalyticsResourcesTest()
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

                    ResourcesResponse response = cdnMgmtClient.LogAnalytics.GetLogAnalyticsResources(resourceGroupName, profileName);
                    Assert.NotNull(response);
                    Assert.NotNull(response.CustomDomains);
                    Assert.NotNull(response.Endpoints);
                    Assert.NotEmpty(response.Endpoints);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void GetWafLogAnalyticsMetricsTest()
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
                    // Create a premium Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.PremiumAzureFrontDoor },
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
                    var domain = $"{endpointName}.z01.azurefd.net";

                    IList<string> metrics = new List<string>() {
                        LogMetric.ClientRequestCount
                    };
                    DateTime dateTimeBegin = new DateTime(2021, 1, 27, 0, 0, 0);
                    DateTime dateTimeEnd = new DateTime(2021, 1, 27, 0, 0, 1);
                    string granularity = LogMetricsGranularity.PT5M;

                    WafMetricsResponse response = cdnMgmtClient.LogAnalytics.GetWafLogAnalyticsMetrics(resourceGroupName, profileName, metrics, dateTimeBegin, dateTimeEnd, granularity);
                    Assert.NotNull(response);
                    Assert.NotNull(response.Series);
                    Assert.Equal(dateTimeBegin, response.DateTimeBegin);
                    Assert.Equal(dateTimeEnd, response.DateTimeEnd);
                    Assert.Equal(granularity, response.Granularity);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }


        [Fact]
        public void GetWafLogAnalyticsRankingsTest()
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

                    IList<string> rankings = new List<string>() {
                        LogRanking.Url
                    };
                    IList<string> metrics = new List<string>() {
                        LogRankingMetric.ClientRequestCount
                    };
                    int maxRanking = 50;
                    DateTime dateTimeBegin = new DateTime(2021, 1, 27, 0, 0, 0);
                    DateTime dateTimeEnd = new DateTime(2021, 1, 27, 0, 0, 1);
                    WafRankingsResponse response = cdnMgmtClient.LogAnalytics.GetWafLogAnalyticsRankings(resourceGroupName, profileName, metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings);
                    Assert.NotNull(response);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }
    }
}
