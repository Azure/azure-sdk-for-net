// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class TestUtilitiesSamples : RecordedTestBase
{
    public TestUtilitiesSamples(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void CanSetAndRetrieveEnvironmentVariable()
    {
        #region Snippet:TestEnvVarUsage
        // Use TestEnvVar to temporarily set environment variables
        using var testEnvVar = new TestEnvVar("TEST_SAMPLE_VALUE", "test-value");

        // Retrieve the value that was set
        var value = Environment.GetEnvironmentVariable("TEST_SAMPLE_VALUE");
        Assert.That(value, Is.EqualTo("test-value"));

        // Variable will be automatically restored to its original value when disposed
        #endregion
    }

    [RecordedTest]
    public async Task TestRandomProvidesDeterministicValues()
    {
        // Need to add fake call so the recording is initialized
        MockPipelineTransport transport = new(message =>
           new MockPipelineResponse(200)
                    .WithContent("""
                {
                    "countryRegion": {"isoCode": "TS"},
                    "ipAddress": "203.0.113.1"
                }
                """)
                    .WithHeader("Content-Type", "application/json"));
        transport.ExpectSyncPipeline = !IsAsync;

        MapsClientOptions options = new()
        {
            Transport = transport
        };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential("fake-key"),
            options: InstrumentClientOptions(options)));

        var testIp = IPAddress.Parse("203.0.113.1");
        var result = await client.GetCountryCodeAsync(testIp);

        #region Snippet:RandomId
        string repeatableRandomId = Recording!.GenerateId();
        #endregion

        #region Snippet:RandomGuid
        string repeatableGuid = Recording!.Random.NewGuid().ToString();
        #endregion

    }

    [Test]
    public async Task CanTestAsyncEnumerable()
    {
        #region Snippet:AsyncEnumerableExtension
        var items = GetAsyncItems();

        // Use extension to collect async enumerable items
        var collectedItems = await items.ToEnumerableAsync();
        #endregion
    }

    private async IAsyncEnumerable<string> GetAsyncItems()
    {
        yield return "item1";
        await Task.Delay(10);
        yield return "item2";
        await Task.Delay(10);
        yield return "item3";
    }
}
