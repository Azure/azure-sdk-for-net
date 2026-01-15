// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class AvailableProvidersListTests : NetworkServiceClientTestBase
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

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AvailableProvidersListAzureLocationCountrySpecifiedTest()
        {
            AvailableProvidersListContent parameters = new AvailableProvidersListContent
            {
                AzureLocations = { "West US" },
                Country = "United States"
            };
            Operation<AvailableProvidersList> providersListOperation =
                await GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus").Value.GetAvailableProvidersAsync(WaitUntil.Completed, parameters);
            Response<AvailableProvidersList> providersList = await providersListOperation.WaitForCompletionAsync();;
            Assert.That(providersList.Value.Countries[0].CountryName, Is.EqualTo("United States"));
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AvailableProvidersListAzureLocationCountryStateSpecifiedTest()
        {
            AvailableProvidersListContent parameters = new AvailableProvidersListContent
            {
                AzureLocations = { "West US" },
                Country = "United States",
                State = "washington"
            };
            Operation<AvailableProvidersList> providersListOperation = await GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus").Value.GetAvailableProvidersAsync(WaitUntil.Completed, parameters);
            Response<AvailableProvidersList> providersList = await providersListOperation.WaitForCompletionAsync();;
            Assert.That(providersList.Value.Countries[0].CountryName, Is.EqualTo("United States"));
            Assert.That(providersList.Value.Countries[0].States[0].StateName, Is.EqualTo("washington"));
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task AvailableProvidersListAzureLocationCountryStateCitySpecifiedTest()
        {
            AvailableProvidersListContent parameters = new AvailableProvidersListContent
            {
                AzureLocations = { "West US" },
                Country = "United States",
                State = "washington",
                City = "seattle"
            };
            Operation<AvailableProvidersList> providersListOperation = await GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus").Value.GetAvailableProvidersAsync(WaitUntil.Completed, parameters);
            Response<AvailableProvidersList> providersList = await providersListOperation.WaitForCompletionAsync();;
            Assert.That(providersList.Value.Countries[0].CountryName, Is.EqualTo("United States"));
            Assert.That(providersList.Value.Countries[0].States[0].StateName, Is.EqualTo("washington"));
            Assert.That(providersList.Value.Countries[0].States[0].Cities[0].CityName, Is.EqualTo("seattle"));
        }
    }
}
