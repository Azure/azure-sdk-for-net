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
    public void TestCustomPipeline()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY");

        KeyCredential credential = new KeyCredential(key);

        MapsClientOptions options = new MapsClientOptions();
        options.PerCallPolicies = new PipelinePolicy[1];
        options.PerCallPolicies[0] = new CustomPolicy();

        // TODO: Suboptimal that MapsClientOptions isn't obviously a PipelineOptions?

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential, options);

        // ^^ In this call, pipeline is created in PO and frozen.
        ClientPipeline pipeline = ClientPipeline.GetPipeline(client, options);
        Assert.IsNotNull(pipeline);

        RequestOptions requestOptions = new RequestOptions(options);

        IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
        Result result = client.GetCountryCode(ipAddress.ToString(), requestOptions);

        ClientPipeline requestPipeline = ClientPipeline.GetPipeline(client, requestOptions);
        Assert.IsNotNull(requestPipeline);

        // Since nothing changed in the RO pipeline, the pipelines should have reference equality.
        Assert.AreEqual(pipeline, requestPipeline);

        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(result.GetRawResponse());

        Assert.AreEqual("US", value.CountryRegion.IsoCode);
        Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), value.IpAddress);
    }

    [Test]
    public void TestCustomPipelineForMethodInvocation()
    {
        string key = Environment.GetEnvironmentVariable("MAPS_API_KEY");

        KeyCredential credential = new KeyCredential(key);

        MapsClient client = new MapsClient(new Uri("https://atlas.microsoft.com"), credential);

        // Add a custom policy to the pipeline just for the one method
        // This constructor is just a copy constructor;
        // copies *settings* from pipeline options into request options

        // Note: it does *not* copy the pipeline, only the options
        RequestOptions requestOptions = new RequestOptions();
        requestOptions.AddPolicy(new CustomPolicy(), PipelinePosition.PerCall);

        IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
        Result result = client.GetCountryCode(ipAddress.ToString(), requestOptions);

        // ^^ In this call, pipeline is created in RO and frozen.
        ClientPipeline requestPipeline = ClientPipeline.GetPipeline(client, requestOptions);
        Assert.IsNotNull(requestPipeline);

        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(result.GetRawResponse());

        Assert.AreEqual("US", value.CountryRegion.IsoCode);
        Assert.AreEqual(IPAddress.Parse("2001:4898:80e8:b::189"), value.IpAddress);
    }

    public class CustomPolicy : PipelinePolicy
    {
        public override void Process(PipelineMessage message, PipelineProcessor pipeline)
        {
            message.Request.Headers.Add("custom-header", "123");

            pipeline.ProcessNext();

            Debug.WriteLine($"Response status code: '{message.Response.Status}'");
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
        {
            message.Request.Headers.Add("custom-header", "123");

            await pipeline.ProcessNextAsync().ConfigureAwait(false);

            Debug.WriteLine($"Response status code: '{message.Response.Status}'");
        }
    }
}
