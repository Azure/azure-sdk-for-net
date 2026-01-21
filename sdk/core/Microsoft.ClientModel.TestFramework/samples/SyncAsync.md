# Sync/Async Testing with Microsoft.ClientModel.TestFramework

This sample demonstrates how to write tests that automatically validate both synchronous and asynchronous code paths with a single test implementation using the test framework's sync/async testing capabilities.

## Requirements

For the sync/async interceptor to work, your client methods must follow these patterns:

- **Method naming**: Async methods must end with `Async` suffix; sync methods must have the same name without the suffix (e.g., `GetData()` and `GetDataAsync()`)
- **Method signatures**: Both versions must have identical parameters in the same order, including `CancellationToken`
- **Return types**: Must follow supported patterns:
  - `T` ↔ `Task<T>` or `ValueTask<T>` (for any type `T`)
  - `ClientResult<T>` ↔ `Task<ClientResult<T>>` or `ValueTask<ClientResult<T>>`
  - `CollectionResult<T>` ↔ `Task<AsyncCollectionResult<T>>`
  - `CollectionResult` ↔ `Task<AsyncCollectionResult>`
- **Virtual methods**: All intercepted async methods and properties must be marked as `virtual` to allow Castle DynamicProxy to intercept them



## Basic Sync/Async Test Setup

The foundation is the `ClientTestBase` class:

```C# Snippet:BasicSyncAsyncSetup
public class MapsClientTests : ClientTestBase
{
    public MapsClientTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanPerformBasicOperation()
    {
        MapsClientOptions options = new();


        // Create and proxy the client
        MapsClient client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key"),
            options));

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
    MapsClientOptions options = new();
    MapsClient client = new(new Uri("https://atlas.microsoft.com"),
        new ApiKeyCredential("test-key"),
        options);

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
    MapsClientOptions options = new();
    MapsClient client = CreateProxyFromClient(new MapsClient(
        new Uri("https://atlas.microsoft.com"),
        new ApiKeyCredential("test-key"),
        options));

    // Test sync-specific behavior
    IPAddressCountryPair result = client.GetCountryCode(IPAddress.Parse("8.8.8.8"));
}
```

### Testing Error Scenarios

Sync/async testing works well with error scenarios:

```C# Snippet:ErrorScenario
MapsClientOptions options = new();
MapsClient client = CreateProxyFromClient(new MapsClient(
new Uri("https://atlas.microsoft.com"),
new ApiKeyCredential("invalid-key"),
options));

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


    [RecordedTest]
    public async Task RecordedSyncAsyncTest()
    {
        // Combine recording with sync/async testing
        MapsClientOptions options = new();
        MapsClientOptions instrumentedOptions = InstrumentClientOptions(options);
        MapsClient client = CreateProxyFromClient(new MapsClient(
            new Uri(TestEnvironment.Endpoint),
            new ApiKeyCredential(TestEnvironment.SubscriptionKey),
            instrumentedOptions));

        // This will be recorded for both sync and async modes
        IPAddressCountryPair result = await client.GetCountryCodeAsync(IPAddress.Parse("8.8.8.8"));
    }
}
```

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