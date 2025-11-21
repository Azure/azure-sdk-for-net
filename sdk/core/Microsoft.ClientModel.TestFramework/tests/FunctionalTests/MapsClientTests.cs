// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
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

    public MapsClientTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
    {
    }

    [RecordedTest]
    public async Task GetCountryCodeReturnsCountryCode()
    {
        MapsClientOptions options = new MapsClientOptions(MapsClientOptions.ServiceVersion.V1)
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
}
