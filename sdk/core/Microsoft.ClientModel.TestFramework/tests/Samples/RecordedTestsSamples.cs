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

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class RecordedTestsSamples
{
    #region Snippet:BasicRecordedTestSetup
    public class SampleTestEnvironment : TestEnvironment
    {
        // Environment variables for connecting to the service
        public string Endpoint => GetRecordedVariable("SAMPLE_ENDPOINT");

        // Secret values should be marked as such for sanitization
        public string ApiKey => GetRecordedVariable("SAMPLE_API_KEY", options => options.IsSecret());

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            throw new NotImplementedException();
        }

        public override Task WaitForEnvironmentAsync()
        {
            throw new NotImplementedException();
        }
    }

    [ClientTestFixture]
    public class SampleRecordedTests : RecordedTestBase<SampleTestEnvironment>
    {
        public SampleRecordedTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CanCreateAndRetrieveResource()
        {
            // Create a client with instrumented options for recording
            var options = InstrumentClientOptions(new SampleClientOptions());
            var client = CreateProxyFromClient(new SampleClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.ApiKey),
                options));

            // Create a resource
            var resource = new SampleResource("test-resource");
            var createResult = await client.CreateResourceAsync(resource);

            Assert.That(createResult, Is.Not.Null);
            Assert.That("test-resource", Is.EqualTo(createResult.Value.Id));

            // Retrieve the resource
            var getResult = await client.GetResourceAsync(createResult.Value.Id);

            Assert.That(getResult, Is.Not.Null);
            Assert.That(createResult.Value.Id, Is.EqualTo(getResult.Value.Id));
        }
    }
#endregion

    #region Snippet:LiveModeExample
    // Set via environment variable: SYSTEM_CLIENTMODEL_TEST_MODE=Live
    // Or in constructor for development:
    public class LiveModeTests : RecordedTestBase<SampleTestEnvironment>
    {
        public LiveModeTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }
    }
    #endregion

    #region Snippet:RecordModeExample
    // Set via environment variable: SYSTEM_CLIENTMODEL_TEST_MODE=Record
    // Or in constructor:
    public class RecordModeTests : RecordedTestBase<SampleTestEnvironment>
    {
        public RecordModeTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }
    }
    #endregion

    #region Snippet:PlaybackModeExample
    // Default mode - no configuration needed
    // Set via environment variable: SYSTEM_CLIENTMODEL_TEST_MODE=Playback
    public class PlaybackModeTests : RecordedTestBase<SampleTestEnvironment>
    {
        public PlaybackModeTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback)
        {
        }
    }
    #endregion

    #region Snippet:AdvancedTestEnvironment
    public class AdvancedTestEnvironment : TestEnvironment
    {
        // Basic variable
        public string Endpoint => GetRecordedVariable("SERVICE_ENDPOINT");

        // Secret variable (will be sanitized in recordings)
        public string ApiKey => GetRecordedVariable("SERVICE_API_KEY", options => options.IsSecret());

        // Base64 secret (uses Base64-compatible sanitized value)
        public string Base64Secret => GetRecordedVariable("SERVICE_SECRET",
            options => options.IsSecret(SanitizedValue.Base64));

        // Optional variable with default
        public string OptionalSetting => GetRecordedOptionalVariable("OPTIONAL_SETTING") ?? "default-value";

        // Credential for authentication
        public override AuthenticationTokenProvider Credential =>
            new ApiKeyAuthenticationTokenProvider(new ApiKeyCredential(ApiKey));

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            // Parse test.env file or return empty dictionary
            return new Dictionary<string, string>
            {
                { "SERVICE_ENDPOINT", "https://example.com" },
                { "SERVICE_API_KEY", "test-key" },
                { "SERVICE_SECRET", "test-secret" }
            };
        }

        public override Task WaitForEnvironmentAsync()
        {
            // Wait for environment to be ready
            return Task.CompletedTask;
        }
    }
    #endregion

    #region Snippet:EnvironmentReadinessCheck
    public class ServiceTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("SERVICE_ENDPOINT");
        public string ApiKey => GetRecordedVariable("SERVICE_API_KEY", options => options.IsSecret());

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            // Parse test.env file or return empty dictionary
            return new Dictionary<string, string>();
        }

        public override async Task WaitForEnvironmentAsync()
        {
            // Wait for environment to be ready
            // This replaces the IsEnvironmentReadyAsync pattern from Azure.Core.TestFramework
            try
            {
                var client = new SampleClient(new Uri(Endpoint), new ApiKeyCredential(ApiKey));
                await client.HealthCheckAsync();
            }
            catch
            {
                // Environment not ready, but we'll continue anyway
            }
        }
    }
    #endregion

    #region Snippet:CustomSanitization
    public class CustomSanitizedTests : RecordedTestBase<SampleTestEnvironment>
    {
        public CustomSanitizedTests(bool isAsync) : base(isAsync)
        {
            // Sanitize custom headers
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("x-custom-key") { Value = "SANITIZED" }));

            // Sanitize parts of URIs
            UriRegexSanitizers.Add(new UriRegexSanitizer(new UriRegexSanitizerBody("accounts/SANITIZED", @"accounts/[^/]+", null, null, null)));

            // Sanitize request/response bodies
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(new BodyRegexSanitizerBody(@"""id"": ""SANITIZED""", @"""id""\s*:\s*""[^""]+""", null, null, null)));
        }
    }
    #endregion

    #region Snippet:JsonPathSanitization
    public class JsonSanitizedTests : RecordedTestBase<SampleTestEnvironment>
    {
        public JsonSanitizedTests(bool isAsync) : base(isAsync)
        {
            // Sanitize specific JSON paths
            JsonPathSanitizers.Add("$.connectionString");
            JsonPathSanitizers.Add("$.keys[*].value");
            JsonPathSanitizers.Add("$.properties.secrets");
        }
    }
    #endregion

    #region Snippet:RequestMatching
    public class CustomMatchingTests : RecordedTestBase<SampleTestEnvironment>
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
    public class DebuggingTests : RecordedTestBase<SampleTestEnvironment>
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
    public class CustomSessionTests : RecordedTestBase<SampleTestEnvironment>
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
            await client.PerformOperationAsync();
        }

        private SampleClient CreateInstrumentedClient()
        {
            var options = InstrumentClientOptions(new SampleClientOptions());
            return CreateProxyFromClient(new SampleClient(
                new Uri("https://example.com"),
                new MockCredential()));
        }
    }
    #endregion

    #region Snippet:LiveOnlyTests
    [LiveOnly]
    public class LargeDataTests : RecordedTestBase<SampleTestEnvironment>
    {
        public LargeDataTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task UploadLargeFile()
        {
            // This test will only run in Live mode
            var client = CreateInstrumentedClient();
            var largeData = new byte[1024 * 1024 * 100]; // 100MB
            await client.UploadDataAsync(largeData);
        }

        private SampleClient CreateInstrumentedClient()
        {
            var options = InstrumentClientOptions(new SampleClientOptions());
            return CreateProxyFromClient(new SampleClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.ApiKey),
                options));
        }
    }

    // Or mark individual tests as live-only
    public class MixedTests : RecordedTestBase<SampleTestEnvironment>
    {
        public MixedTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task NormalTest()
        {
            // This test can be recorded
            var client = CreateInstrumentedClient();
            await client.GetDataAsync("test");
        }

        [Test]
        [LiveOnly]
        public async Task LiveOnlyTest()
        {
            // This test will only run live
            var client = CreateInstrumentedClient();
            await client.GetDataAsync("live-only");
        }

        private SampleClient CreateInstrumentedClient()
        {
            var options = InstrumentClientOptions(new SampleClientOptions());
            return CreateProxyFromClient(new SampleClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.ApiKey),
                options));
        }
    }
    #endregion

    #region Snippet:TestEnvironmentBestPractices
    public class WellOrganizedTestEnvironment : TestEnvironment
    {
        // Group related settings
        public string ServiceEndpoint => GetRecordedVariable("SERVICE_ENDPOINT");
        public string ServiceRegion => GetRecordedVariable("SERVICE_REGION");

        // Use descriptive names for secrets
        public string ServicePrimaryKey => GetRecordedVariable("SERVICE_PRIMARY_KEY",
            options => options.IsSecret());
        public string ServiceSecondaryKey => GetRecordedVariable("SERVICE_SECONDARY_KEY",
            options => options.IsSecret());

        // Provide helper methods for common client creation
        public SampleClient CreateClient() => new SampleClient(
            new Uri(ServiceEndpoint),
            new ApiKeyCredential(ServicePrimaryKey)
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
    public class EfficientTests : RecordedTestBase<SampleTestEnvironment>
    {
        private SampleClient _client;

        public EfficientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            var options = InstrumentClientOptions(new SampleClientOptions());
            _client = CreateProxyFromClient(new SampleClient(
                new Uri(TestEnvironment.Endpoint),
                new MockCredential("test-api-key", DateTimeOffset.UtcNow.AddHours(1)),
                options));
        }

        [Test]
        public async Task MultipleOperationsTest()
        {
            // Group related operations in single test to reduce recording size
            var resource = await _client.CreateResourceAsync(new SampleResource("test"));
            var updated = await _client.UpdateResourceAsync(resource.Value.Id, "updated");
            await _client.DeleteResourceAsync(updated.Value.Id);

            // Verify the complete workflow
            Assert.That(resource.Value, Is.Not.Null);
            Assert.That(updated.Value.Name, Is.EqualTo("updated"));
        }
    }
    #endregion

    #region Snippet:DebuggingTechniques
    public class DebuggingTechniquesTests : RecordedTestBase<SampleTestEnvironment>
    {
        public DebuggingTechniquesTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task DiagnosticTest()
        {
            // Enable detailed logging
            UseLocalDebugProxy = true;

            // Add custom diagnostics - sanitizers are configured through SanitizedHeaders property
            // Recording?.AddSanitizer(new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("x-debug-info") { Value = "DEBUG" }));

            var client = CreateInstrumentedClient();

            // Use recording's random for deterministic values
            var randomValue = Recording?.Random?.Next(1000, 9999) ?? 1234;

            await client.ProcessValueAsync(randomValue);
        }

        private SampleClient CreateInstrumentedClient()
        {
            var options = InstrumentClientOptions(new SampleClientOptions());
            return CreateProxyFromClient(new SampleClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.ApiKey),
                options));
        }
    }
    #endregion
}

// Extensions to support sample snippets
public static class SampleClientExtensions
{
    public static async Task PerformOperationAsync(this SampleClient client)
    {
        await client.GetDataAsync("test");
    }

    public static async Task UploadDataAsync(this SampleClient client, byte[] data)
    {
        // Mock upload operation
        await Task.Delay(10);
    }

    public static async Task ProcessValueAsync(this SampleClient client, int value)
    {
        await client.GetDataAsync(value.ToString());
    }
}

public class ApiKeyCredential : AuthenticationTokenProvider
{
    private readonly string _key;

    public ApiKeyCredential(string key)
    {
        _key = key;
    }

    public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
    {
        throw new NotImplementedException();
    }

    public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
    {
        return new AuthenticationToken(_key, "Bearer", DateTimeOffset.UtcNow.AddHours(1));
    }

    public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
    {
        return new ValueTask<AuthenticationToken>(new AuthenticationToken(_key, "Bearer", DateTimeOffset.UtcNow.AddHours(1)));
    }
}

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
