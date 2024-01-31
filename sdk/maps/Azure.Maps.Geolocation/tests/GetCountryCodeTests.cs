// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Maps.Geolocation;
using NUnit.Framework;

namespace Azure.Maps.Geolocation.Tests
{
    public class GetCountryCodeTests : GeolocationClientLiveTestsBase
    {
        public GetCountryCodeTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetCountryCode()
        {
            var client = CreateClient();
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            var result = await client.GetCountryCodeAsync(ipAddress);

            Assert.AreEqual("US", result.Value.IsoCode);
            Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), result.Value.IpAddress);
        }
    }
}
