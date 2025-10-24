# Recorded Tests with Microsoft.ClientModel.TestFramework

This sample demonstrates how to use the Test Framework's recording capabilities to create fast, deterministic tests that can run against live services or recorded interactions.

## Overview

Recorded tests are functional tests that can run in three different modes:
- **Live** - The requests in the tests are run against live service resources.
- **Record** - The requests in the tests are run against live resources and HTTP interactions are recorded for later playback.
- **Playback** - The requests that your library generates when running a test are compared against the requests in the recording for that test. For each matched request, the corresponding response is extracted from the recording and "played back" as the response.

Under the hood, when tests are run in `Playback` or `Record` mode, requests are forwarded to the [Test Proxy](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md). The test proxy is a proxy server that runs locally on your machine automatically when in `Record` or `Playback` mode.

By default tests are run in playback mode. To change the mode use the `SYSTEM_CLIENTMODEL_TEST_MODE` environment variable and set it to one of the following values: `Live`, `Playback`, `Record`.

## Test Resource Setup

In order to actually run recorded tests in `Live` or `Record` mode, you will need service resources that the test can run against. Follow the [live test resources management](https://github.com/azure/azure-sdk-for-net/tree/main/eng/common/TestResources/README.md) to create a live test resources deployment template and get it deployed.

## Key Benefits

Recorded tests allow you to:
- Record HTTP interactions during live testing for later playback
- Run tests quickly without making actual HTTP requests
- Create deterministic tests that aren't affected by service availability
- Sanitize sensitive data in recordings

## Basic Recorded Test Setup

The foundation of recorded testing is the `RecordedTestBase<T>` class and a custom `TestEnvironment` class:

```C# Snippet:BasicRecordedTestSetup
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
```

## Test Modes

The Test Framework supports three different modes for running recorded tests:

### Live Mode
Tests run against actual service endpoints with real HTTP requests.

```C# Snippet:LiveModeExample
// Set via environment variable: SYSTEM_CLIENTMODEL_TEST_MODE=Live
// Or in constructor for development:
public class LiveModeTests : RecordedTestBase<SampleTestEnvironment>
{
    public LiveModeTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
    {
    }
}
```

### Record Mode
Tests run against live services but HTTP interactions are saved for later playback.

```C# Snippet:RecordModeExample
// Set via environment variable: SYSTEM_CLIENTMODEL_TEST_MODE=Record
// Or in constructor:
public class RecordModeTests : RecordedTestBase<SampleTestEnvironment>
{
    public RecordModeTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
    {
    }
}
```

### Playback Mode (Default)
Tests use previously recorded interactions instead of making real HTTP requests.

```C# Snippet:PlaybackModeExample
// Default mode - no configuration needed
// Set via environment variable: SYSTEM_CLIENTMODEL_TEST_MODE=Playback
public class PlaybackModeTests : RecordedTestBase<SampleTestEnvironment>
{
    public PlaybackModeTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback)
    {
    }
}
```

## Advanced Test Environment Features

### Environment Variable Types

```C# Snippet:AdvancedTestEnvironment
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
```

### Environment Readiness Checking

For services that need time to become available after resource creation:

```C# Snippet:EnvironmentReadinessCheck
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
```

## Sanitization

### Built-in Sanitizers

The Test Framework automatically sanitizes common sensitive headers, but you can add custom sanitization:

```C# Snippet:CustomSanitization
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
```

### JSON Path Sanitizers

For sanitizing specific JSON properties in request/response bodies:

```C# Snippet:JsonPathSanitization
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
```

## Request Matching

Customize how recorded requests are matched during playback:

```C# Snippet:RequestMatching
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
```

## Working with Test Proxy

### Debug Mode

Enable debug logging for troubleshooting recording issues:

```C# Snippet:DebugMode
public class DebuggingTests : RecordedTestBase<SampleTestEnvironment>
{
    public DebuggingTests(bool isAsync) : base(isAsync)
    {
        // Enable debug mode for detailed proxy logging
        UseLocalDebugProxy = true;
    }
}
```

### Custom Recording Session Names

Control how recording sessions are named:

```C# Snippet:CustomSessionNames
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
```

## Live-Only Tests

Some tests should never be recorded (e.g., due to size or content):

```C# Snippet:LiveOnlyTests
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
```

## Best Practices

### 1. Test Environment Organization

```C# Snippet:TestEnvironmentBestPractices
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
```

### 2. Efficient Test Structure

```C# Snippet:EfficientTestStructure
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
```

## Troubleshooting

### Common Issues

1. **Recording Mismatches**: Ensure sanitizers don't over-sanitize and break request matching
2. **Credential Issues**: Use `TestEnvironment.Credential` for consistent authentication
3. **Timing Issues**: Use `TestRandom` for deterministic values instead of `Random`
4. **Large Recordings**: Consider splitting large tests or using `[LiveOnly]`

### Debug Techniques

```C# Snippet:DebuggingTechniques
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
```