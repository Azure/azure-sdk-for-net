// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Maps;
using System.Net.ClientModel.Core;

namespace System.Net.ClientModel.Tests;

public class MapsClientTests
{
    // This is a "TestSupportProject", so these tests will never be run as part of CIs.
    // It's here now for quick manual validation of client functionality, but we can revisit
    // this story going forward.
    [Test]
    public void TestClientSync()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY");

        KeyCredential credential = new KeyCredential(key);
        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
        Result<IPAddressCountryPair> result = client.GetCountryCode(ipAddress);

        //Result result = client.GetCountryCode((MessageBody)ipAddress);
        //IPAddressCountryPair value = (IPAddressCountryPair)result.Body;

        Assert.AreEqual("US", result.Value.CountryRegion.IsoCode);
        Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), result.Value.IpAddress);
    }
}
