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

    public class AvailableProvidersListTests
    {
        [Fact(Skip = "Test can be run after fixes for this API will be deployed in every region")]
        public void AvailableProvidersListAzureLocationCountrySpecifiedTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                AvailableProvidersListParameters parameters = new AvailableProvidersListParameters();
                parameters.AzureLocations = new List<string>();
                parameters.AzureLocations.Add("West US");
                parameters.Country = "United States";

                var providersList = networkManagementClient.NetworkWatchers.ListAvailableProviders("NetworkWatcherRG", "NetworkWatcher", parameters);

                Assert.Equal("United States", providersList.Countries[0].CountryName);
            }
        }

        [Fact(Skip = "Test can be run after fixes for this API will be deployed in every region")]
        public void AvailableProvidersListAzureLocationCountryStateSpecifiedTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                AvailableProvidersListParameters parameters = new AvailableProvidersListParameters();
                parameters.AzureLocations = new List<string>();
                parameters.AzureLocations.Add("West US");
                parameters.Country = "United States";
                parameters.State = "washington";

                var providersList = networkManagementClient.NetworkWatchers.ListAvailableProviders("NetworkWatcherRG", "NetworkWatcher", parameters);

                Assert.Equal("United States", providersList.Countries[0].CountryName);
                Assert.Equal("washington", providersList.Countries[0].States[0].StateName);
            }
        }

        [Fact(Skip = "Test can be run after fixes for this API will be deployed in every region")]
        public void AvailableProvidersListAzureLocationCountryStateCitySpecifiedTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                AvailableProvidersListParameters parameters = new AvailableProvidersListParameters();
                parameters.AzureLocations = new List<string>();
                parameters.AzureLocations.Add("West US");
                parameters.Country = "United States";
                parameters.State = "washington";
                parameters.City = "seattle";

                var providersList = networkManagementClient.NetworkWatchers.ListAvailableProviders("NetworkWatcherRG", "NetworkWatcher", parameters);

                Assert.Equal("United States", providersList.Countries[0].CountryName);
                Assert.Equal("washington", providersList.Countries[0].States[0].StateName);
                Assert.Equal("seattle", providersList.Countries[0].States[0].Cities[0].CityName);
            }
        }
    }
}

