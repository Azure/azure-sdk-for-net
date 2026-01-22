# Recorded tests with Microsoft.ClientModel.TestFramework

This sample demonstrates how to use the test framework's recording capabilities to create fast, deterministic tests that can run against live services or recorded interactions.

## Overview

Recorded tests can run in three different modes:
- **Live** - The requests in the tests are run against live service resources.
- **Record** - The requests in the tests are run against live resources and HTTP interactions are recorded for later playback.
- **Playback** - The requests that your library generates when running a test are compared against the requests in the recording for that test. For each matched request, the corresponding response is extracted from the recording and "played back" as the response.

Under the hood, when tests are run in `Playback` or `Record` mode, requests are forwarded to the [Test Proxy](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md). The test proxy is a proxy server that runs locally on your machine automatically when in `Record` or `Playback` mode.

## Basic recorded test setup

The foundation of recorded testing is the `RecordedTestBase<T>` class and a custom `TestEnvironment` class:

```C# Snippet:TestEnvironmentSetup
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
```

```C# Snippet:BasicRecordedTest
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
```

## Test modes

By default tests are run in playback mode. To change the mode, use the `SYSTEM_CLIENTMODEL_TEST_MODE` environment variable and set it to one of the following values: `Live`, `Playback`, `Record`.

In development scenarios where it's required to change mode quickly without restarting Visual Studio, use the two-parameter constructor of `RecordedTestBase` to change the mode, or use the `.runsettings` file as described [here](#test-settings).

Recorded tests can be attributed with the `RecordedTestAttribute` in lieu of the standard `TestAttribute` to enable functionality to automatically re-record tests that fail due to recording session file mismatches.
Tests that are auto-rerecorded will fail with the following error and succeed if re-run.

```text
Error Message:
   Test failed playback, but was successfully re-recorded (it should pass if re-run).
```

```C# Snippet:TestModeExample
public TestModeExamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
{
}
```

## Sanitization

### Built-in sanitizers

Secrets that are part of requests, responses, headers, or connections strings should be sanitized before saving the record. Do not check in session records containing secrets. Common headers like `"Authentication"` are sanitized automatically, but if custom logic is required and/or if request or response body need to be sanitized, several properties of RecordedTestBase can be used to customize the sanitization process.

### Standard custom sanitization

```C# Snippet:StandardSanitization
// Sanitize specific headers by name
SanitizedHeaders.Add("x-client-secret");
SanitizedQueryParameters.Add("client_secret");
```

### JSON path sanitizers

Another sanitization feature that is available involves sanitizing Json payloads. By adding a Json Path formatted string to the JsonPathSanitizers property, you can sanitize the value for a specific JSON property in request/response bodies.

```C# Snippet:JsonPathSanitization
// Sanitize specific JSON paths
JsonPathSanitizers.Add("$.subscriptionKey");
JsonPathSanitizers.Add("$.ipAddress");
JsonPathSanitizers.Add("$.countryRegion.isoCode");
```

### Advanced sanitizers

If more advanced sanitization is needed, you can use any of the regex-based sanitizer properties of RecordedTestBase.

_Note that when using any of the regex sanitizers, you must take care to ensure that the regex is specific enough to not match unintended values. When a regex is too broad and matches unintended values, this can result in the request or response being corrupted which may manifest in a JsonReaderException._

```C# Snippet:CustomSanitization
// Sanitize subscription key headers
HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("subscription-key") { Value = "SANITIZED" }));

// Sanitize parts of URIs containing account info
UriRegexSanitizers.Add(new UriRegexSanitizer(new UriRegexSanitizerBody("atlas.microsoft.com", @"[^.]+\.microsoft\.com", null, null, null)));

// Sanitize IP addresses in request/response bodies
BodyRegexSanitizers.Add(new BodyRegexSanitizer(new BodyRegexSanitizerBody(@"""ipAddress"": ""127.0.0.1""", @"""ipAddress""\s*:\s*""[^""]+""", null, null, null)));

// Sanitize specific keys in request/response bodies
BodyKeySanitizers.Add(new BodyKeySanitizer(new BodyKeySanitizerBody("subscriptionKey") { Value = "SANITIZED" }));
```

## Request matching

Customize how recorded requests are matched during playback:

```C# Snippet:RequestMatching
// Ignore headers that vary between requests
IgnoredHeaders.Add("x-ms-client-request-id");
IgnoredHeaders.Add("User-Agent");
IgnoredHeaders.Add("x-request-timestamp");

// Ignore query parameters that shouldn't affect matching
IgnoredQueryParameters.Add("timestamp");
IgnoredQueryParameters.Add("nonce");
```

## Working with Test Proxy

### Debug mode

Enable debug logging for troubleshooting recording issues:

```C# Snippet:DebugMode
public DebuggingTests(bool isAsync) : base(isAsync)
{
    // Enable debug mode for detailed proxy logging
    UseLocalDebugProxy = true;
}
```

Note: A user can set the environment variable PROXY_DEBUG_MODE to a truthy value prior to invoking, just like if they set UseLocalDebugProxy in their code.

In order to debug the test proxy, you will need to clone the azure-sdk-tools repo. The best practice is to first create a fork of the repo, and then clone your fork locally.

Once you have cloned the repo, open the Test Proxy solution in your IDE.

If you are attempting to debug Playback mode, set a breakpoint in the HandlePlaybackRequest method of RecordingHandler. If you are attempting to debug Record mode, set a breakpoint in the HandleRecordRequestAsync method of RecordingHandler. It may also be helpful to put breakpoints in Admin.cs to verify that your sanitizers are being added as expected.

With your breakpoints set, run the test proxy project, and then run your test that you are trying to debug. You should see your breakpoints hit.

## Live-Only tests

Some tests should never be recorded (e.g., due to size or content). The test framework provides a `[LiveOnly]` attribute that can be applied to entire test classes or to individual tests.

## Troubleshooting

### Common issues

1. **Recording Mismatches**: Ensure sanitizers don't over-sanitize and break request matching
2. **Credential Issues**: Use `TestEnvironment.Credential` for consistent authentication
3. **Issues with random values**: Use `TestRandom` for deterministic values instead of `Random`