// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using System.ClientModel.Primitives;
using System.Threading;
using Maps;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class RecordedTestsSamples
{
    #region Snippet:BasicRecordedTestSetup
    public class MapsTestEnvironment : TestEnvironment
    {
        // Environment variables for connecting to the Azure Maps service
        public string Endpoint => GetRecordedVariable("MAPS_ENDPOINT");

        // Secret values should be marked as such for sanitization
        public string SubscriptionKey => GetRecordedVariable("MAPS_SUBSCRIPTION_KEY", options => options.IsSecret("subscription-key"));

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            // Read environment variables or parse from a .env file as needed
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

    public class MapsRecordedTests : RecordedTestBase<MapsTestEnvironment>
    {
        public MapsRecordedTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetCountryCode()
        {
            // Create a client with instrumented options for recording
            var options = InstrumentClientOptions(new Maps.MapsClientOptions());
            var client = CreateProxyFromClient(new Maps.MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                options));

            // Get country code for a known IP address
            var ipAddress = System.Net.IPAddress.Parse("8.8.8.8");
            var result = await client.GetCountryCodeAsync(ipAddress);
        }
    }
    #endregion

    #region Snippet:TestModeExample
    public class TestModeExamples : RecordedTestBase<MapsTestEnvironment>
    {
        // Can explicitly specify a mode in the constructor
        public TestModeExamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }
    }
    #endregion

    #region Snippet:CustomSanitization
    public class CustomSanitizedTests : RecordedTestBase<MapsTestEnvironment>
    {
        public CustomSanitizedTests(bool isAsync) : base(isAsync)
        {
            // Sanitize subscription key headers
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("subscription-key") { Value = "SANITIZED" }));

            // Sanitize parts of URIs containing account info
            UriRegexSanitizers.Add(new UriRegexSanitizer(new UriRegexSanitizerBody("atlas.microsoft.com", @"[^.]+\.microsoft\.com", null, null, null)));

            // Sanitize IP addresses in request/response bodies
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(new BodyRegexSanitizerBody(@"""ipAddress"": ""127.0.0.1""", @"""ipAddress""\s*:\s*""[^""]+""", null, null, null)));

            // Sanitize specific keys in request/response bodies
            BodyKeySanitizers.Add(new BodyKeySanitizer(new BodyKeySanitizerBody("subscriptionKey") { Value = "SANITIZED" }));
        }
    }
    #endregion

    #region Snippet:StandardSanitization
    public class StandardSanitizedTests : RecordedTestBase<MapsTestEnvironment>
    {
        public StandardSanitizedTests(bool isAsync) : base(isAsync)
        {
            // Sanitize specific headers by name
            SanitizedHeaders.Add("x-client-secret");
            SanitizedQueryParameters.Add("client_secret");
        }
    }
    #endregion

    #region Snippet:JsonPathSanitization
    public class JsonSanitizedTests : RecordedTestBase<MapsTestEnvironment>
    {
        public JsonSanitizedTests(bool isAsync) : base(isAsync)
        {
            // Sanitize specific JSON paths
            JsonPathSanitizers.Add("$.subscriptionKey");
            JsonPathSanitizers.Add("$.ipAddress");
            JsonPathSanitizers.Add("$.countryRegion.isoCode");
        }
    }
    #endregion

    #region Snippet:RequestMatching
    public class CustomMatchingTests : RecordedTestBase<MapsTestEnvironment>
    {
        public CustomMatchingTests(bool isAsync) : base(isAsync)
        {
            // Ignore headers that vary between requests
            IgnoredHeaders.Add("x-ms-client-request-id");
            IgnoredHeaders.Add("User-Agent");
            IgnoredHeaders.Add("x-request-timestamp");

            // Ignore query parameters that shouldn't affect matching
            IgnoredQueryParameters.Add("timestamp");
            IgnoredQueryParameters.Add("nonce");
        }
    }
    #endregion

    #region Snippet:DebugMode
    public class DebuggingTests : RecordedTestBase<MapsTestEnvironment>
    {
        public DebuggingTests(bool isAsync) : base(isAsync)
        {
            // Enable debug mode for detailed proxy logging
            UseLocalDebugProxy = true;
        }
    }
    #endregion

    #region Snippet:CustomSessionNames
    [TestFixture]
    public class CustomSessionTests : RecordedTestBase<MapsTestEnvironment>
    {
        public CustomSessionTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CustomNamedTest()
        {
            // The recording will be saved with the default test name
            await StartTestRecordingAsync();
            // Note: Custom session naming not directly supported in Microsoft.ClientModel.TestFramework
            // Recording names are derived from test method names automatically

            var client = CreateInstrumentedClient();
            var result = await client.GetCountryCodeAsync("8.8.8.8");
            Assert.That(result, Is.Not.Null);
        }

        private MapsClient CreateInstrumentedClient()
        {
            var options = InstrumentClientOptions(new MapsClientOptions());
            return CreateProxyFromClient(new MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                options));
        }
    }
    #endregion

    #region Snippet:LiveOnlyTests
    [LiveOnly]
    public class LargeDataTests : RecordedTestBase<MapsTestEnvironment>
    {
        public LargeDataTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task TestManyIpAddresses()
        {
            // This test will only run in Live mode due to the volume of requests
            var client = CreateInstrumentedClient();
            
            // Test multiple IP addresses (this would generate too many recordings)
            var ipAddresses = new[] { "8.8.8.8", "1.1.1.1", "208.67.222.222" };
            
            foreach (var ip in ipAddresses)
            {
                var result = await client.GetCountryCodeAsync(ip);
                Assert.That(result, Is.Not.Null);
            }
        }

        private MapsClient CreateInstrumentedClient()
        {
            var options = InstrumentClientOptions(new MapsClientOptions());
            return CreateProxyFromClient(new MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                options));
        }
    }

    // Or mark individual tests as live-only
    public class MixedTests : RecordedTestBase<MapsTestEnvironment>
    {
        public MixedTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task NormalTest()
        {
            // This test can be recorded
            var client = CreateInstrumentedClient();
            var result = await client.GetCountryCodeAsync("8.8.8.8");
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [LiveOnly]
        public async Task LiveOnlyTest()
        {
            // This test will only run live - perhaps testing rate limits
            var client = CreateInstrumentedClient();
            var result = await client.GetCountryCodeAsync("127.0.0.1");
            Assert.That(result, Is.Not.Null);
        }

        private MapsClient CreateInstrumentedClient()
        {
            var options = InstrumentClientOptions(new MapsClientOptions());
            return CreateProxyFromClient(new MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                options));
        }
    }
    #endregion

    #region Snippet:TestEnvironmentBestPractices
    public class WellOrganizedTestEnvironment : TestEnvironment
    {
        // Group related settings
        public string MapsEndpoint => GetRecordedVariable("MAPS_ENDPOINT");
        public string MapsRegion => GetRecordedVariable("MAPS_REGION");

        // Use descriptive names for secrets
        public string MapsPrimaryKey => GetRecordedVariable("MAPS_PRIMARY_KEY",
            options => options.IsSecret());
        public string MapsSecondaryKey => GetRecordedVariable("MAPS_SECONDARY_KEY",
            options => options.IsSecret());

        // Provide helper methods for common client creation
        public MapsClient CreateClient() => new MapsClient(
            new Uri(MapsEndpoint),
            new ApiKeyCredential(MapsPrimaryKey)
        );

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            throw new NotImplementedException();
        }

        public override Task WaitForEnvironmentAsync()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Snippet:EfficientTestStructure
    public class EfficientTests : RecordedTestBase<MapsTestEnvironment>
    {
        private MapsClient _client;

        public EfficientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            var options = InstrumentClientOptions(new MapsClientOptions());
            _client = CreateProxyFromClient(new MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                options));
        }

        [Test]
        public async Task MultipleOperationsTest()
        {
            // Group related operations in single test to reduce recording size
            var result1 = await _client.GetCountryCodeAsync("8.8.8.8");
            var result2 = await _client.GetCountryCodeAsync("1.1.1.1");

            // Verify both operations succeeded
            Assert.That(result1.Value, Is.Not.Null);
            Assert.That(result2.Value, Is.Not.Null);
            Assert.That(result1.Value.CountryRegion, Is.Not.Null);
            Assert.That(result2.Value.CountryRegion, Is.Not.Null);
        }
    }
    #endregion

    #region Snippet:DebuggingTechniques
    public class DebuggingTechniquesTests : RecordedTestBase<MapsTestEnvironment>
    {
        public DebuggingTechniquesTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task DiagnosticTest()
        {
            // Enable detailed logging
            UseLocalDebugProxy = true;

            // Add custom diagnostics - sanitizers are configured through properties
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("x-debug-info") { Value = "DEBUG" }));

            var client = CreateInstrumentedClient();

            // Use recording's random for deterministic values
            var testIps = new[] { "8.8.8.8", "1.1.1.1", "208.67.222.222" };
            var randomIndex = Recording?.Random?.Next(0, testIps.Length) ?? 0;
            var selectedIp = testIps[randomIndex];

            var result = await client.GetCountryCodeAsync(selectedIp);
            Assert.That(result, Is.Not.Null);
        }

        private MapsClient CreateInstrumentedClient()
        {
            var options = InstrumentClientOptions(new MapsClientOptions());
            return CreateProxyFromClient(new MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                options));
        }
    }
    #endregion
}

// Extensions to support sample snippets are no longer needed 
// since we're using the real MapsClient with actual operations

// ApiKeyCredential is now provided by System.ClientModel
// No need to define our own implementation

public class ApiKeyAuthenticationTokenProvider : AuthenticationTokenProvider
{
    private readonly ApiKeyCredential _credential;

    public ApiKeyAuthenticationTokenProvider(ApiKeyCredential credential)
    {
        _credential = credential;
    }

    public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
    {
        throw new NotImplementedException();
    }

    public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
    {
        return _credential.GetToken(options, cancellationToken);
    }

    public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
    {
        return _credential.GetTokenAsync(options, cancellationToken);
    }
}
