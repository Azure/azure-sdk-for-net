// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class AvailableProvidersListTests : NetworkTestsManagementClientBase
    {
        public AvailableProvidersListTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AvailableProvidersListAzureLocationCountrySpecifiedTest()
        {
            AvailableProvidersListParameters parameters = new AvailableProvidersListParameters
            {
                AzureLocations = new List<string> { "West US" },
                Country = "United States"
            };
            Operation<AvailableProvidersList> providersListOperation =
                await NetworkManagementClient.NetworkWatchers.StartListAvailableProvidersAsync("NetworkWatcherRG", "NetworkWatcher_westus", parameters);
            Response<AvailableProvidersList> providersList = await WaitForCompletionAsync(providersListOperation);
            Assert.AreEqual("United States", providersList.Value.Countries[0].CountryName);
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AvailableProvidersListAzureLocationCountryStateSpecifiedTest()
        {
            AvailableProvidersListParameters parameters = new AvailableProvidersListParameters
            {
                AzureLocations = new List<string> { "West US" },
                Country = "United States",
                State = "washington"
            };
            Operation<AvailableProvidersList> providersListOperation = await NetworkManagementClient.NetworkWatchers.StartListAvailableProvidersAsync("NetworkWatcherRG", "NetworkWatcher_westus", parameters);
            Response<AvailableProvidersList> providersList = await WaitForCompletionAsync(providersListOperation);
            Assert.AreEqual("United States", providersList.Value.Countries[0].CountryName);
            Assert.AreEqual("washington", providersList.Value.Countries[0].States[0].StateName);
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AvailableProvidersListAzureLocationCountryStateCitySpecifiedTest()
        {
            AvailableProvidersListParameters parameters = new AvailableProvidersListParameters
            {
                AzureLocations = new List<string> { "West US" },
                Country = "United States",
                State = "washington",
                City = "seattle"
            };
            Operation<AvailableProvidersList> providersListOperation = await NetworkManagementClient.NetworkWatchers.StartListAvailableProvidersAsync("NetworkWatcherRG", "NetworkWatcher_westus", parameters);
            Response<AvailableProvidersList> providersList = await WaitForCompletionAsync(providersListOperation);
            Assert.AreEqual("United States", providersList.Value.Countries[0].CountryName);
            Assert.AreEqual("washington", providersList.Value.Countries[0].States[0].StateName);
            Assert.AreEqual("seattle", providersList.Value.Countries[0].States[0].Cities[0].CityName);
        }
    }
}
