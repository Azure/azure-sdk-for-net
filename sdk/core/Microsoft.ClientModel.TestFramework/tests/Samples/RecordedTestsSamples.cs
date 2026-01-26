// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class RecordedTestsSamples
{
    #region Snippet:TestEnvironmentReadme
    public class SimpleTestEnvironment : TestEnvironment
    {
        // Variables retrieved using GetRecordedVariable will be recorded in recorded tests
        public string Endpoint => GetRecordedVariable("SAMPLE_ENDPOINT");
        #region Snippet:SecretVariable
        public string SecretKey => GetRecordedVariable("SAMPLE_SECRET_KEY", options => options.IsSecret());
        #endregion

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            // Read environment variables or parse and decrypt from an encrypted .env file as needed
            return new Dictionary<string, string>
            {
#if SNIPPET
                { "SAMPLE_ENDPOINT", Environment.GetEnvironmentVariable("MAPS_ENDPOINT") },
                { "SAMPLE_SECRET_KEY", Environment.GetEnvironmentVariable("MAPS_SUBSCRIPTION_KEY") }
#else
                { "SAMPLE_ENDPOINT", "https://example.com" },
                { "SAMPLE_SECRET_KEY", "your_subscription_key_here" }
#endif
            };
        }

        public override Task WaitForEnvironmentAsync()
        {
            return Task.CompletedTask;
        }
    }
    #endregion

    #region Snippet:RecordedTestReadme
    public class ConfigurationTests : RecordedTestBase<SimpleTestEnvironment>
    {
        public ConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndDeleteConfiguration()
        {
            MockClientOptions options = InstrumentClientOptions(new MockClientOptions());
            MockClient client = CreateProxyFromClient(new MockClient(
                new Uri(TestEnvironment.Endpoint),
                options
            ));

            // Test implementation here
        }
    }
    #endregion

    #region Snippet:TestEnvironmentSetup
    public class MapsTestEnvironment : TestEnvironment
    {
        // Environment variables for connecting to the demonstrative "Maps" service (disclaimer: not a real service)
        public string Endpoint => GetRecordedVariable("MAPS_ENDPOINT");

        // Secret values should be marked as such for sanitization
        public string SubscriptionKey => GetRecordedVariable("MAPS_SUBSCRIPTION_KEY", options => options.IsSecret("subscription-key"));

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            // Read environment variables or parse and decrypt from an encrypted .env file as needed
            return new Dictionary<string, string>
            {
#if SNIPPET
                { "MAPS_ENDPOINT", Environment.GetEnvironmentVariable("MAPS_ENDPOINT") },
                { "MAPS_SUBSCRIPTION_KEY", Environment.GetEnvironmentVariable("MAPS_SUBSCRIPTION_KEY") }
#else
                { "MAPS_ENDPOINT", "https://example.com" },
                { "MAPS_SUBSCRIPTION_KEY", "your_subscription_key_here" }
#endif
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

#if !SNIPPET
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
#endif

        [RecordedTest]
        public async Task CanGetCountryCode()
        {
            // Create a client with instrumented options for recording
            MapsClientOptions options = InstrumentClientOptions(new MapsClientOptions());

#if !SNIPPET
            options.Transport = _transport;
#endif

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
