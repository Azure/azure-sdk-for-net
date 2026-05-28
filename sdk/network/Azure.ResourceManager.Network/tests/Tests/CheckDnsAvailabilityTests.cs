// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network.Tests
{
    [ClientTestFixture(true, "2021-04-01", "2018-11-01")]
    public class CheckDnsAvailabilityTests : NetworkServiceClientTestBase
    {
        public CheckDnsAvailabilityTests(bool isAsync, string apiVersion)
            : base(isAsync, "Microsoft.Network/locations/CheckDnsNameAvailability", apiVersion)
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
        [RecordedTest]
        public async Task CheckDnsAvailabilityTest()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string domainNameLabel = Recording.GenerateAssetName("domainnamelabel");
            Response<Models.DnsNameAvailabilityResult> dnsNameAvailability = await subscription.CheckDnsNameAvailabilityAsync(TestEnvironment.Location, domainNameLabel);

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
