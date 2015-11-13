﻿using System;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Networks.Tests
{
    public class CheckDnsAvailabilityTests
    {
        [Fact]
        public void CheckDnsAvailabilityTest()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {               
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

                var location = GetNrpServiceEndpoint(NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualNetworks"));

                string domainNameLabel = TestUtilities.GenerateName("domainnamelabel");

                var dnsNameAvailability = networkResourceProviderClient.CheckDnsNameAvailability(location, domainNameLabel);

                Assert.True(dnsNameAvailability.Available.Value);
            }
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