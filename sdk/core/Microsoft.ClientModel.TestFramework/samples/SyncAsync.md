# Sync/Async Testing with Microsoft.ClientModel.TestFramework

This sample demonstrates how to write tests that automatically validate both synchronous and asynchronous code paths with a single test implementation using the Test Framework's sync/async testing capabilities.

## Overview

The Test Framework's sync/async testing feature allows you to:
- Write tests once and run them for both sync and async methods
- Automatically forward async calls to their sync counterparts 
- Test client libraries thoroughly with minimal code duplication
- Ensure consistent behavior between sync and async overloads

## Basic Sync/Async Test Setup

The foundation is the `ClientTestBase` class with the `[ClientTestFixture]` attribute:

```C# Snippet:BasicSyncAsyncSetup
public class MapsClientTests : ClientTestBase
{
    public MapsClientTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanPerformBasicOperation()
    {
        // Create and proxy the client
        MapsClient client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key")));

        // Write the test using async methods - the framework will automatically
        // test both sync and async versions
        IPAddressCountryPair result = await client.GetCountryCodeAsync(IPAddress.Parse("8.8.8.8"));

        Assert.That(result, Is.Not.Null);
        Assert.That(result.CountryRegion, Is.Not.Null);
    }
}
```

## How It Works

The `InstrumentClient` method wraps your client in a proxy that:
- In async mode (`IsAsync = true`): Calls async methods as written
- In sync mode (`IsAsync = false`): Intercepts async calls and forwards them to sync overloads

## Test Explorer Integration

In the test explorer, you'll see both versions of each test:
- `SampleClientTests(True)` - Runs async methods as written
- `SampleClientTests(False)` - Runs sync versions via interception

## Controlling Test Execution

### Async-Only Tests

Use `[AsyncOnly]` for tests that should only run in async mode:

```C# Snippet:AsyncOnlyTests
[Test]
[AsyncOnly]
public async Task AsyncOnlyFeature()
{
    // No need to proxy since this is async-only, but also works the same way if proxied,
    // so existing helper methods can be used as needed
    MapsClient client = new(new Uri("https://atlas.microsoft.com"),
        new ApiKeyCredential("test-key"));

    // Test async-specific functionality
    string[] ipAddresses = ["8.8.8.8", "1.1.1.1", "208.67.222.222"];
    IEnumerable<Task<ClientResult>> tasks = ipAddresses.Select(ip => client.GetCountryCodeAsync(ip));
    ClientResult[] results = await Task.WhenAll(tasks);
}
```

### Sync-Only Tests

Use `[SyncOnly]` for tests that should only run in sync mode:

```C# Snippet:SyncOnlyTests
[Test]
[SyncOnly]
public void SyncOnlyFeature()
{
    // No need to proxy since this is sync-only, but also works the same way if proxied,
    // so existing helper methods can be used as needed
    MapsClient client = CreateProxyFromClient(new MapsClient(
        new Uri("https://atlas.microsoft.com"),
        new ApiKeyCredential("test-key")));

    // Test sync-specific behavior
    IPAddressCountryPair result = client.GetCountryCode(IPAddress.Parse("8.8.8.8"));
}
```

### Testing Error Scenarios

Sync/async testing works well with error scenarios:

```C# Snippet:ErrorScenario
var client = CreateProxyFromClient(new MapsClient(
new Uri("https://atlas.microsoft.com"),
new ApiKeyCredential("invalid-key")));

// Test error handling in both sync and async modes
ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
    async () => await client.GetCountryCodeAsync("8.8.8.8"));
```

## Testing with Recorded Tests

Sync/async testing integrates seamlessly with recorded tests:

```C# Snippet:SyncAsyncWithRecording
public class RecordedSyncAsyncTests : RecordedTestBase<MapsTestEnvironment>
{
    public RecordedSyncAsyncTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task RecordedSyncAsyncTest()
    {
        // Combine recording with sync/async testing
        MapsClientOptions options = InstrumentClientOptions(new MapsClientOptions());
        MapsClient client = CreateProxyFromClient(new MapsClient(
            new Uri(TestEnvironment.Endpoint),
            new ApiKeyCredential(TestEnvironment.SubscriptionKey),
            options));

        // This will be recorded for both sync and async modes
        IPAddressCountryPair result = await client.GetCountryCodeAsync(IPAddress.Parse("8.8.8.8"));
    }
}
```

## Client Requirements

For sync/async testing to work properly, your client must meet these requirements:

### 1. Virtual Methods

All async methods and properties must be marked as `virtual`:

### 2. Consistent Method Pairs

Ensure sync and async methods have consistent signatures:

## Timeout Configuration

```C# Snippet:TimeoutConfiguration
public class TimeoutTests : ClientTestBase
{
    public TimeoutTests(bool isAsync) : base(isAsync)
    {
        // Increase timeout for complex operations
        TestTimeoutInSeconds = 30;
    }
}
```

## Troubleshooting

### Common Issues

1. **Non-Virtual Methods**: Ensure all methods are marked as `virtual`
2. **Missing Sync Overloads**: Each async method should have a corresponding sync method
3. **Inconsistent Signatures**: Sync and async method signatures should match except for return type
4. **Instrumentation Issues**: Always use `CreateProxyFromClient()` to wrap your client instances