// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class CheckDnsAvailabilityTests : NetworkTestsManagementClientBase
    {
        public CheckDnsAvailabilityTests(bool isAsync) : base(isAsync)
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
        public async Task CheckDnsAvailabilityTest()
        {
            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/publicIPAddresses");
            location = location.Replace(" ", "");

            string domainNameLabel = Recording.GenerateAssetName("domainnamelabel");

            Response<Models.DnsNameAvailabilityResult> dnsNameAvailability = await ServiceOperations.CheckDnsNameAvailabilityAsync(location, domainNameLabel);

            Assert.True(dnsNameAvailability.Value.Available);
        }

        // The CheckDnsAvailability api expects a location parameter which
        // is used to identify the nrp endpoint (uses "isHostBasedRouting" in CSM regsitration)
        // Currently, the NRP dogfood endpoints are nrp7 and nrp8. Hence they do not have the location prefix.
        // As a temporary fix, we need to assign the location when we run in dogfood environment
        private static string GetNrpServiceEndpoint(string nrpLocation)
        {
            if (string.Equals(nrpLocation, "West Europe", StringComparison.OrdinalIgnoreCase))
            {
                return "nrp7";
            }
            if (string.Equals(nrpLocation, "West US", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(nrpLocation, "Central US", StringComparison.OrdinalIgnoreCase))
            {
                return "nrp8";
            }

            return nrpLocation;
        }
    }
}
