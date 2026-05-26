// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class MapsClientTests : RecordedTestBase<MapsClientTestEnvironment>
{
    private MockPipelineTransport _transport;

    [SetUp]
    public void Setup()
    {
        _transport = new(message =>
        {
            var request = (MockPipelineRequest)message.Request;

            // AddCountryCode
            if (request.Method == "PATCH" && request.Uri!.PathAndQuery.Contains("countries"))
            {
                return new MockPipelineResponse(200)
                    .WithContent("""{"isoCode": "TS"}""")
                    .WithHeader("Content-Type", "application/json");
            }

            // GetCountryCode
            if (request.Method == "GET" && request.Uri!.PathAndQuery.Contains("geolocation/ip"))
            {
                return new MockPipelineResponse(200)
                    .WithContent("""
                {
                    "countryRegion": {"isoCode": "TS"},
                    "ipAddress": "203.0.113.1"
                }
                """)
                    .WithHeader("Content-Type", "application/json");
            }

            return new MockPipelineResponse(404);
        });
        _transport.ExpectSyncPipeline = !IsAsync;
    }

    public MapsClientTests(bool isAsync) : base(isAsync)
    {
        CustomSanitizers.Add(new ContentDispositionFilePathSanitizer());
    }

    [RecordedTest]
    public async Task GetCountryCodeReturnsCountryCode()
    {
        MapsClientOptions options = new()
        {
            Transport = _transport
        };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        var testIp = IPAddress.Parse("203.0.113.1");
        var result = await client.GetCountryCodeAsync(testIp);

        Assert.That(result.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));
    }

    [RecordedTest]
    public async Task CallsCorrectMethodBasedOnIsAsync()
    {
        MapsClientOptions options = new()
        {
            Transport = _transport
        };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        var testIp = IPAddress.Parse("203.0.113.1");
        var result = await client.GetCountryCodeAsync(testIp);

        // Verify the method executed successfully
        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));
        Assert.That(result.Value.IpAddress.ToString(), Is.EqualTo("203.0.113.1"));
    }

    [RecordedTest]
    public async Task InstrumentedClientHandlesMultipleCalls()
    {
        MapsClientOptions options = new()
        {
            Transport = _transport
        };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        // Make multiple calls to verify instrumentation doesn't break
        var testIp1 = IPAddress.Parse("203.0.113.1");
        var result1 = await client.GetCountryCodeAsync(testIp1);
        Assert.That(result1.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));

        var testIp2 = IPAddress.Parse("203.0.113.1");
        var result2 = await client.GetCountryCodeAsync(testIp2);
        Assert.That(result2.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));
    }

    [RecordedTest]
    public void InstrumentedClientPreservesExceptionBehavior()
    {
        var errorTransport = new MockPipelineTransport(message => new MockPipelineResponse(404));
        errorTransport.ExpectSyncPipeline = !IsAsync;

        MapsClientOptions options = new()
        {
            Transport = errorTransport
        };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        var testIp = IPAddress.Parse("203.0.113.1");

        // Verify that errors are propagated correctly through the proxy
        Assert.ThrowsAsync<ClientResultException>(async () => await client.GetCountryCodeAsync(testIp));
    }

    [RecordedTest]
    public async Task InstrumentClientOptionsPreservesTransport()
    {
        MapsClientOptions options = new()
        {
            Transport = _transport
        };

        var instrumentedOptions = InstrumentClientOptions(options);

        // Verify that the instrumented options still work
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: instrumentedOptions));

        var testIp = IPAddress.Parse("203.0.113.1");
        var result = await client.GetCountryCodeAsync(testIp);

        Assert.That(result.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));
    }

    [RecordedTest]
    public async Task ProxyHandlesResponseWithComplexObject()
    {
        MapsClientOptions options = new()
        {
            Transport = _transport
        };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        var testIp = IPAddress.Parse("203.0.113.1");
        var result = await client.GetCountryCodeAsync(testIp);

        // Verify complex response deserialization works through proxy
        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.CountryRegion, Is.Not.Null);
        Assert.That(result.Value.IpAddress, Is.Not.Null);
        Assert.That(result.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));
    }

    [RecordedTest]
    public async Task MultipleProxiesCanBeCreatedFromSameClient()
    {
        MapsClientOptions options = new()
        {
            Transport = _transport
        };

        var originalClient = new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options));

        // Create multiple proxies
        MapsClient proxy1 = CreateProxyFromClient(originalClient);
        MapsClient proxy2 = CreateProxyFromClient(originalClient);

        var testIp = IPAddress.Parse("203.0.113.1");

        var result1 = await proxy1.GetCountryCodeAsync(testIp);
        var result2 = await proxy2.GetCountryCodeAsync(testIp);

        Assert.That(result1.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));
        Assert.That(result2.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));
    }

    [RecordedTest]
    public async Task ProxyHandlesDifferentReturnTypes()
    {
        MapsClientOptions options = new()
        {
            Transport = _transport
        };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        var testIp = IPAddress.Parse("203.0.113.1");

        // Test ClientResult<T> return type
        var typedResult = await client.GetCountryCodeAsync(testIp);
        Assert.That(typedResult.Value, Is.Not.Null);
        Assert.That(typedResult.Value.CountryRegion.IsoCode, Is.EqualTo("TS"));

        // Test the response itself
        var response = typedResult.GetRawResponse();
        Assert.That(response.Status, Is.EqualTo(200));
    }

    [RecordedTest]
    public async Task DefaultSanitizers_AreStillPresentByDefault()
    {
        // Need a recording to exist in order to get the sanitizers to be applied
        MapsClientOptions options = new()
        {
            Transport = _transport
        };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        Assert.That(UseDefaultSanitizers, Is.True);

        var adminClient = TestProxy?.AdminClient;
        Assert.That(adminClient, Is.Not.Null);

        // Try to remove some default sanitizers - they should still be present
        var sanitizersToRemove = new SanitizerList(new List<string> { "AZSDK1000", "AZSDK2001", "AZSDK3400" });
        var removeResult = await adminClient.RemoveSanitizersAsync(sanitizersToRemove, Recording.RecordingId);

        Assert.That(removeResult.Value, Is.Not.Null);
        Assert.That(removeResult.Value.Removed, Is.Not.Null);

        // The removed list should contain these sanitizers because they were not removed by RemoveDefaultSanitizers
        Assert.That(removeResult.Value.Removed, Does.Contain("AZSDK1000"));
        Assert.That(removeResult.Value.Removed, Does.Contain("AZSDK2001"));
        Assert.That(removeResult.Value.Removed, Does.Contain("AZSDK3400"));
    }
}
