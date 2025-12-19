// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class RecordedTestsSamples
{
    #region Snippet:TestEnvironmentSetup
    public class MapsTestEnvironment : TestEnvironment
    {
        // Environment variables for connecting to the demonstrative Azure Maps service (disclaimer: not a real service)
        public string Endpoint => GetRecordedVariable("MAPS_ENDPOINT");

        // Secret values should be marked as such for sanitization
        public string SubscriptionKey => GetRecordedVariable("MAPS_SUBSCRIPTION_KEY", options => options.IsSecret("subscription-key"));

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            // Read environment variables or parse and decrypt from an encrypted .env file as needed
            return new Dictionary<string, string>
            {
                { "MAPS_ENDPOINT", Environment.GetEnvironmentVariable("MAPS_ENDPOINT") },
                { "MAPS_SUBSCRIPTION_KEY", Environment.GetEnvironmentVariable("MAPS_SUBSCRIPTION_KEY") }
            };
        }

        public override Task WaitForEnvironmentAsync()
        {
            // Add any environment readiness checks here if needed
            return Task.CompletedTask;
        }
    }
    #endregion

    #region Snippet:BasicRecordedTest
    public class MapsRecordedTests : RecordedTestBase<MapsTestEnvironment>
    {
        public MapsRecordedTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetCountryCode()
        {
            // Create a client with instrumented options for recording
            MapsClientOptions options = InstrumentClientOptions(new MapsClientOptions());

            // Proxy the client to enable auto sync forwarding from async calls
            MapsClient client = CreateProxyFromClient(new MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                options));

            // Call async client method
            IPAddressCountryPair result = await client.GetCountryCodeAsync(IPAddress.Parse("8.8.8.8"));
        }
    }
    #endregion

    public class TestModeExamples : RecordedTestBase<MapsTestEnvironment>
    {
        #region Snippet:TestModeExample
        public TestModeExamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }
        #endregion
    }

    public class CustomSanitizedTests : RecordedTestBase<MapsTestEnvironment>
    {
        public CustomSanitizedTests(bool isAsync) : base(isAsync)
        {
            #region Snippet:CustomSanitization
            // Sanitize subscription key headers
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("subscription-key") { Value = "SANITIZED" }));

            // Sanitize parts of URIs containing account info
            UriRegexSanitizers.Add(new UriRegexSanitizer(new UriRegexSanitizerBody("atlas.microsoft.com", @"[^.]+\.microsoft\.com", null, null, null)));

            // Sanitize IP addresses in request/response bodies
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(new BodyRegexSanitizerBody(@"""ipAddress"": ""127.0.0.1""", @"""ipAddress""\s*:\s*""[^""]+""", null, null, null)));

            // Sanitize specific keys in request/response bodies
            BodyKeySanitizers.Add(new BodyKeySanitizer(new BodyKeySanitizerBody("subscriptionKey") { Value = "SANITIZED" }));
            #endregion

            #region Snippet:StandardSanitization
            // Sanitize specific headers by name
            SanitizedHeaders.Add("x-client-secret");
            SanitizedQueryParameters.Add("client_secret");
            #endregion

            #region Snippet:JsonPathSanitization
            // Sanitize specific JSON paths
            JsonPathSanitizers.Add("$.subscriptionKey");
            JsonPathSanitizers.Add("$.ipAddress");
            JsonPathSanitizers.Add("$.countryRegion.isoCode");
            #endregion

            #region Snippet:RequestMatching
            // Ignore headers that vary between requests
            IgnoredHeaders.Add("x-ms-client-request-id");
            IgnoredHeaders.Add("User-Agent");
            IgnoredHeaders.Add("x-request-timestamp");

            // Ignore query parameters that shouldn't affect matching
            IgnoredQueryParameters.Add("timestamp");
            IgnoredQueryParameters.Add("nonce");
            #endregion
        }
    }

    public class DebuggingTests : RecordedTestBase<MapsTestEnvironment>
    {
        #region Snippet:DebugMode
        public DebuggingTests(bool isAsync) : base(isAsync)
        {
            // Enable debug mode for detailed proxy logging
            UseLocalDebugProxy = true;
        }
        #endregion
    }
}
