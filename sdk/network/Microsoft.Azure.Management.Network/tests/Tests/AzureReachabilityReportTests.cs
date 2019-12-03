using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Network.Tests.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class AzureReachabilityReportTests
    {
        [Fact(Skip = "Test can be run after fixes for this API will be deployed in every region")]
        public void AzureReachabilityReportCountryLevelAggregationTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                AzureReachabilityReportParameters parameters = new AzureReachabilityReportParameters();
                parameters.AzureLocations = new List<string>();
                parameters.AzureLocations.Add("West US");

                parameters.ProviderLocation = new AzureReachabilityReportLocation();
                parameters.ProviderLocation.Country = "United States";

                parameters.StartTime = DateTime.Now.AddDays(-10);
                parameters.EndTime = DateTime.Now.AddDays(-5);

                var report = networkManagementClient.NetworkWatchers.GetAzureReachabilityReport("NetworkWatcherRG", "NetworkWatcher", parameters);

                //Validation
                Assert.Equal("Country", report.AggregationLevel);
                Assert.Equal("United States", report.ProviderLocation.Country);
                Assert.Equal("West US", report.ReachabilityReport[0].AzureLocation);
            }
        }

        [Fact(Skip = "Test can be run after fixes for this API will be deployed in every region")]
        public void AzureReachabilityReportStateLevelAggregationTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                AzureReachabilityReportParameters parameters = new AzureReachabilityReportParameters();
                parameters.AzureLocations = new List<string>();
                parameters.AzureLocations.Add("West US");

                parameters.ProviderLocation = new AzureReachabilityReportLocation();
                parameters.ProviderLocation.Country = "United States";
                parameters.ProviderLocation.State = "washington";

                parameters.StartTime = DateTime.Now.AddDays(-10);
                parameters.EndTime = DateTime.Now.AddDays(-5);

                var report = networkManagementClient.NetworkWatchers.GetAzureReachabilityReport("NetworkWatcherRG", "NetworkWatcher", parameters);

                //Validation
                Assert.Equal("State", report.AggregationLevel);
                Assert.Equal("United States", report.ProviderLocation.Country);
                Assert.Equal("washington", report.ProviderLocation.State);
                Assert.Equal("West US", report.ReachabilityReport[0].AzureLocation);
            }
        }

        [Fact(Skip = "Test can be run after fixes for this API will be deployed in every region")]
        public void AzureReachabilityReportCityLevelAggregationTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                AzureReachabilityReportParameters parameters = new AzureReachabilityReportParameters();
                parameters.AzureLocations = new List<string>();
                parameters.AzureLocations.Add("West US");

                parameters.ProviderLocation = new AzureReachabilityReportLocation();
                parameters.ProviderLocation.Country = "United States";
                parameters.ProviderLocation.State = "washington";
                parameters.ProviderLocation.City = "seattle";

                parameters.StartTime = DateTime.Now.AddDays(-10);
                parameters.EndTime = DateTime.Now.AddDays(-5);

                var report = networkManagementClient.NetworkWatchers.GetAzureReachabilityReport("NetworkWatcherRG", "NetworkWatcher", parameters);

                //Validation
                Assert.Equal("City", report.AggregationLevel);
                Assert.Equal("United States", report.ProviderLocation.Country);
                Assert.Equal("washington", report.ProviderLocation.State);
                Assert.Equal("seattle", report.ProviderLocation.City);
                Assert.Equal("West US", report.ReachabilityReport[0].AzureLocation);
            }
        }
    }
}

