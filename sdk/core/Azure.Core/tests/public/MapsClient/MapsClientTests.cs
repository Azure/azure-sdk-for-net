// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Maps;
using NUnit.Framework;
using System;
using System.Net;

public class MapsClientTests
{
    // This is a "TestSupportProject", so these tests will never be run as part of CIs.
    // It's here now for quick manual validation of client functionality, but we can revisit
    // this story going forward.
    [Test]
    public void TestClientSync()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
        AzureKeyCredential credential = new AzureKeyCredential(key);
        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
        Response<IPAddressCountryPair> output = client.GetCountryCode(ipAddress);

        Assert.AreEqual("US", output.Value.CountryRegion.IsoCode);
        Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), output.Value.IpAddress);
    }
}
