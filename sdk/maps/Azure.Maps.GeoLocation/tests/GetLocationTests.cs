// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Maps.GeoLocation;
using NUnit.Framework;

namespace Azure.Maps.GeoLocation.Tests
{
    public class GetLocationTests : GeoLocationClientLiveTestsBase
    {
        public GetLocationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetLocation()
        {
            var client = CreateClient();
            var ipAddress = "2001:4898:80e8:b::189";
            var result = await client.GetLocationAsync(ipAddress);

            Assert.AreEqual("US", result.Value.IsoCode);
            Assert.AreEqual("2001:4898:80e8:b::189", result.Value.IpAddress);
        }
    }
}
