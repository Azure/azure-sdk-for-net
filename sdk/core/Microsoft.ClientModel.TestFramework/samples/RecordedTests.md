# Recorded tests with Microsoft.ClientModel.TestFramework

This sample demonstrates how to use the Test Framework's recording capabilities to create fast, deterministic tests that can run against live services or recorded interactions.

## Overview

Recorded tests are functional tests that can run in three different modes:
- **Live** - The requests in the tests are run against live service resources.
- **Record** - The requests in the tests are run against live resources and HTTP interactions are recorded for later playback.
- **Playback** - The requests that your library generates when running a test are compared against the requests in the recording for that test. For each matched request, the corresponding response is extracted from the recording and "played back" as the response.

Under the hood, when tests are run in `Playback` or `Record` mode, requests are forwarded to the [Test Proxy](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md). The test proxy is a proxy server that runs locally on your machine automatically when in `Record` or `Playback` mode.

By default tests are run in playback mode. To change the mode use the `SYSTEM_CLIENTMODEL_TEST_MODE` environment variable and set it to one of the following values: `Live`, `Playback`, `Record`.

## Basic recorded test setup

The foundation of recorded testing is the `RecordedTestBase<T>` class and a custom `TestEnvironment` class:

```C# Snippet:BasicRecordedTestSetup
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
```

## Test modes

By default tests are run in playback mode. To change the mode use the `SYSTEM_CLIENTMODEL_TEST_MODE` environment variable and set it to one of the following values: `Live`, `Playback`, `Record`.

In development scenarios where it's required to change mode quickly without restarting Visual Studio, use the two-parameter constructor of `RecordedTestBase` to change the mode, or use the `.runsettings` file as described [here](#test-settings).

Recorded tests can be attributed with the `RecordedTestAttribute` in lieu of the standard `TestAttribute` to enable functionality to automatically re-record tests that fail due to recording session file mismatches.
Tests that are auto-rerecorded will fail with the following error and succeed if re-run.

```text
Error Message:
   Test failed playback, but was successfully re-recorded (it should pass if re-run). Please copy updated recording to SessionFiles.
```

```C# Snippet:TestModeExample
public class TestModeExamples : RecordedTestBase<MapsTestEnvironment>
{
    // Can explicitly specify a mode in the constructor
    public TestModeExamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
    {
    }
}
```

## Sanitization

### Built-in sanitizers

Secrets that are part of requests, responses, headers, or connections strings should be sanitized before saving the record. Do not check session records containing secrets in to repositories. Common headers like Authentication are sanitized automatically, but if custom logic is required and/or if request or response body need to be sanitized, several properties of RecordedTestBase can be used to customize the sanitization process.

### Standard custom sanitization

```C# Snippet:StandardSanitization
public class StandardSanitizedTests : RecordedTestBase<MapsTestEnvironment>
{
    public StandardSanitizedTests(bool isAsync) : base(isAsync)
    {
        // Sanitize specific headers by name
        SanitizedHeaders.Add("x-client-secret");
        SanitizedQueryParameters.Add("client_secret");
    }
}
```

### JSON path sanitizers

Another sanitization feature that is available involves sanitizing Json payloads. By adding a Json Path formatted string to the JsonPathSanitizers property, you can sanitize the value for a specific JSON property in request/response bodies.

```C# Snippet:JsonPathSanitization
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
```

### Advanced sanitizers

If more advanced sanitization is needed, you can use any of the regex-based sanitizer properties of RecordedTestBase.

_Note that when using any of the regex sanitizers, you must take care to ensure that the regex is specific enough to not match unintended values. When a regex is too broad and matches unintended values, this can result in the request or response being corrupted which may manifest in a JsonReaderException._

```C# Snippet:CustomSanitization
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
```

## Request matching

Customize how recorded requests are matched during playback:

```C# Snippet:RequestMatching
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
```

## Working with Test Proxy

### Debug mode

Enable debug logging for troubleshooting recording issues:

```C# Snippet:DebugMode
public class DebuggingTests : RecordedTestBase<MapsTestEnvironment>
{
    public DebuggingTests(bool isAsync) : base(isAsync)
    {
        // Enable debug mode for detailed proxy logging
        UseLocalDebugProxy = true;
    }
}
```

### Custom recording session names

Control how recording sessions are named:

```C# Snippet:CustomSessionNames
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
```

## Live-Only tests

Some tests should never be recorded (e.g., due to size or content):

```C# Snippet:LiveOnlyTests
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
```

## Troubleshooting

### Common issues

1. **Recording Mismatches**: Ensure sanitizers don't over-sanitize and break request matching
2. **Credential Issues**: Use `TestEnvironment.Credential` for consistent authentication
3. **Timing Issues**: Use `TestRandom` for deterministic values instead of `Random`

### Debug Techniques

```C# Snippet:DebuggingTechniques
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
```