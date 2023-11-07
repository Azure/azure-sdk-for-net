// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Maps;
using NUnit.Framework;
using System.Diagnostics;
using System.Net.ClientModel.Core;
using System.Threading.Tasks;

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

        Assert.AreEqual("US", result.Value.CountryRegion.IsoCode);
        Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), result.Value.IpAddress);
    }

    [Test]
    public void TestCustomPipelineForMethodInvocation()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY");

        KeyCredential credential = new KeyCredential(key);

        // We have to pass the pipeline options to the client constructor
        // so that the auth policy gets added, otherwise we won't have it later.
        PipelineOptions pipelineOptions = new PipelineOptions();

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, pipelineOptions);

        // Add a custom policy to the pipeline just for the one method
        pipelineOptions.PerCallPolicies = new PipelinePolicy[1];
        pipelineOptions.PerCallPolicies[0] = new CustomPolicy();
        RequestOptions options = new RequestOptions(pipelineOptions);

        IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
        Result result = client.GetCountryCode(ipAddress.ToString(), options);

        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(result.GetRawResponse());

        Assert.AreEqual("US", value.CountryRegion.IsoCode);
        Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), value.IpAddress);
    }

    public class CustomPolicy : PipelinePolicy
    {
        public override void Process(ClientMessage message, PipelineEnumerator pipeline)
        {
            message.Request.Headers.Add("custom-header", "123");

            pipeline.ProcessNext();

            Debug.WriteLine($"Response status code: '{message.Response.Status}'");
        }

        public override async ValueTask ProcessAsync(ClientMessage message, PipelineEnumerator pipeline)
        {
            message.Request.Headers.Add("custom-header", "123");

            await pipeline.ProcessNextAsync().ConfigureAwait(false);

            Debug.WriteLine($"Response status code: '{message.Response.Status}'");
        }
    }
}
