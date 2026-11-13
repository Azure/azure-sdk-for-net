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

/// <summary>
/// Functional tests for the RemoveDefaultSanitizers feature in RecordedTestBase.
/// </summary>
public class RemoveDefaultSanitizersTests : RecordedTestBase<MapsClientTestEnvironment>
{
    private MockPipelineTransport _transport;

    [SetUp]
    public void Setup()
    {
        _transport = new(message =>
        {
            var request = (MockPipelineRequest)message.Request;

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

    public RemoveDefaultSanitizersTests(bool isAsync) : base(isAsync)
    {
        UseDefaultSanitizers = false;
    }

    [RecordedTest]
    public async Task RemoveDefaultSanitizers_RemovesDefaultSanitizersFromTestProxy()
    {
        // Need a recording to exist in order to get the sanitizers to be applied
        MapsClientOptions options = new() { Transport = _transport };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        var adminClient = TestProxy?.AdminClient;
        Assert.That(adminClient, Is.Not.Null);

        // Attempting to remove sanitizers that have already been removed should not return anything
        var sanitizersToRemove = new SanitizerList(new List<string> { "AZSDK1000", "AZSDK2001", "AZSDK3400" });
        var removeResult = await adminClient.RemoveSanitizersAsync(sanitizersToRemove, Recording.RecordingId);

        Assert.That(removeResult.Value, Is.Not.Null);
        Assert.That(removeResult.Value.Removed, Is.Not.Null);

        // The removed list should not contain these sanitizers because they were already removed
        Assert.That(removeResult.Value.Removed, Does.Not.Contain("AZSDK1000"));
        Assert.That(removeResult.Value.Removed, Does.Not.Contain("AZSDK2001"));
        Assert.That(removeResult.Value.Removed, Does.Not.Contain("AZSDK3400"));
    }

    [RecordedTest]
    public async Task RemoveDefaultSanitizers_AuthorizationHeaderSanitizerIsNotRemoved()
    {
        // Need a recording to exist in order to get the sanitizers to be applied
        MapsClientOptions options = new() { Transport = _transport };
        MapsClient client = CreateProxyFromClient(new MapsClient(new Uri("https://example.com"),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options: InstrumentClientOptions(options)));

        var adminClient = TestProxy?.AdminClient;
        Assert.That(adminClient, Is.Not.Null);

        // This one should not have been removed by RemoveDefaultSanitizers
        var authSanitizer = new SanitizerList(new List<string> { "AZSDK0000" });
        var removeResult = await adminClient.RemoveSanitizersAsync(authSanitizer, Recording.RecordingId);

        // AZSDK0000 should still be present and can be removed now
        Assert.That(removeResult.Value.Removed, Does.Contain("AZSDK0000"));
    }
}
