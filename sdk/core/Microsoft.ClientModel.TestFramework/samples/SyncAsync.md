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
[ClientTestFixture]
public class SampleClientTests : ClientTestBase
{
    public SampleClientTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanPerformBasicOperation()
    {
        // Create and instrument the client
        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test-key")));

        // Write the test using async methods - the framework will automatically
        // test both sync and async versions
        var result = await client.GetDataAsync("test-id");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value.Success, Is.True);
    }
}
```

## How It Works

The `InstrumentClient` method wraps your client in a proxy that:
- In async mode (`IsAsync = true`): Calls async methods as written
- In sync mode (`IsAsync = false`): Intercepts async calls and forwards them to sync overloads

```C# Snippet:SyncAsyncMechanism
[ClientTestFixture]
public class MechanismDemo : ClientTestBase
{
    public MechanismDemo(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task DemonstrateCallForwarding()
    {
        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));

        // This call will be:
        // - Async mode: client.GetResourceAsync(id)
        // - Sync mode: client.GetResource(id)
        var resource = await client.GetResourceAsync("test-id");

        // This call will be:
        // - Async mode: client.UpdateResourceAsync(resource)
        // - Sync mode: client.UpdateResource(resource)
        var updated = await client.UpdateResourceAsync(resource.Value.Id, "updated-name");

        Assert.That(updated.Value.Id, Is.EqualTo(resource.Value.Id));
    }
}
```

## Test Explorer Integration

In the test explorer, you'll see both versions of each test:
- `SampleClientTests(True)` - Runs async methods as written
- `SampleClientTests(False)` - Runs sync versions via interception

```C# Snippet:TestExplorerDemo
[ClientTestFixture]
public class TestExplorerDemo : ClientTestBase
{
    public TestExplorerDemo(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task ThisTestAppearsTwice()
    {
        // This single test method will appear as:
        // - TestExplorerDemo(True).ThisTestAppearsTwice
        // - TestExplorerDemo(False).ThisTestAppearsTwice

        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));

        var result = await client.ProcessDataAsync("test-data");
        Assert.That(result, Is.Not.Null);
    }
}
```

## Controlling Test Execution

### Async-Only Tests

Use `[AsyncOnly]` for tests that should only run in async mode:

```C# Snippet:AsyncOnlyTests
[ClientTestFixture]
public class SpecializedTests : ClientTestBase
{
    public SpecializedTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [AsyncOnly]
    public async Task AsyncOnlyFeature()
    {
        // This test only runs for async clients
        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));

        // Test async-specific functionality
        await client.StreamDataAsync(HandleDataCallback);
    }

    private void HandleDataCallback(byte[] data)
    {
        // Handle streaming data
    }
}
```

### Sync-Only Tests

Use `[SyncOnly]` for tests that should only run in sync mode:

```C# Snippet:SyncOnlyTests
[ClientTestFixture]
public class SyncSpecializedTests : ClientTestBase
{
    public SyncSpecializedTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [SyncOnly]
    public async Task SyncOnlyFeature()
    {
        // This test only runs for sync clients
        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));

        // Test sync-specific behavior
        var result = await client.GetDataAsync("test-id");

        // Verify synchronous completion
        Assert.That(result.GetRawResponse().Headers.Any(h => h.Key == "x-sync-processed"), Is.True);
    }
}
```

## Advanced Scenarios

### Custom Client Instrumentation

For complex clients, you may need custom instrumentation logic:

```C# Snippet:CustomInstrumentation
[ClientTestFixture]
public class CustomInstrumentationTests : ClientTestBase
{
    public CustomInstrumentationTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CustomClientCreation()
    {
        // Create client with custom configuration
        var options = new SampleClientOptions();
        // System.ClientModel.ClientPipelineOptions doesn't have Retry configuration

        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test"),
            options));

        // Test with custom configuration
        var result = await client.GetDataWithRetriesAsync();
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task MultipleClientTypes()
    {
        // Test when using multiple client types
        var dataClient = CreateProxyFromClient(new DataClient(
            new Uri("https://data.example.com"),
            new ApiKeyCredential("test")));

        var configClient = CreateProxyFromClient(new ConfigurationClient(
            new Uri("https://config.example.com"),
            new ApiKeyCredential("test")));

        var data = await dataClient.GetDataAsync();
        var config = await configClient.GetSettingsAsync();

        Assert.That(data, Is.Not.Null);
        Assert.That(config, Is.Not.Null);
    }
}
```

### Testing Error Scenarios

Sync/async testing works well with error scenarios:

```C# Snippet:ErrorScenarios
[ClientTestFixture]
public class ErrorHandlingTests : ClientTestBase
{
    public ErrorHandlingTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void HandlesNotFoundError()
    {
        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));

        // Test error handling in both sync and async modes
        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetNonExistentResourceAsync("invalid"));

        Assert.That(exception.Status, Is.EqualTo(404));
    }

    [Test]
    public void HandlesTimeout()
    {
        var options = new SampleClientOptions();
        options.NetworkTimeout = TimeSpan.FromMilliseconds(100);

        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://slow-endpoint.example.com"),
            new ApiKeyCredential("test"),
            options));

        TaskCanceledException exception = Assert.ThrowsAsync<TaskCanceledException>(
            async () => await client.GetSlowDataAsync());

        Assert.That(exception, Is.Not.Null);
    }
}
```

## Testing with Recorded Tests

Sync/async testing integrates seamlessly with recorded tests:

```C# Snippet:SyncAsyncWithRecording
[ClientTestFixture]
public class RecordedSyncAsyncTests : RecordedTestBase<SampleTestEnvironment>
{
    public RecordedSyncAsyncTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task RecordedSyncAsyncTest()
    {
        // Combine recording with sync/async testing
        var options = InstrumentClientOptions(new SampleClientOptions());
        var client = CreateProxyFromClient(new SampleClient(
            new Uri(TestEnvironment.Endpoint),
            new ApiKeyCredential(TestEnvironment.ApiKey),
            options));

        // This will be recorded for both sync and async modes
        var resource = await client.CreateResourceAsync(new SampleResource("test"));
        var retrieved = await client.GetResourceAsync(resource.Value.Id);

        Assert.That(retrieved.Value.Id, Is.EqualTo(resource.Value.Id));
    }
}
```

## Performance Testing

Test performance differences between sync and async implementations:

```C# Snippet:SyncAsyncPerformanceTesting
[ClientTestFixture]
public class PerformanceTests : ClientTestBase
{
    public PerformanceTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task MeasureOperationPerformance()
    {
        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));

        var stopwatch = Stopwatch.StartNew();

        // Measure performance for both sync and async
        var tasks = new List<Task<ClientResult<SampleData>>>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(client.GetDataAsync($"item-{i}"));
        }

        var results = await Task.WhenAll(tasks);
        stopwatch.Stop();

        Assert.That(results.Length, Is.EqualTo(10));
        Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(5000)); // Should complete within 5 seconds

        // Log performance info for analysis
        TestContext.WriteLine($"Mode: {(IsAsync ? "Async" : "Sync")}, " +
                            $"Time: {stopwatch.ElapsedMilliseconds}ms");
    }
}
```

## Client Requirements

For sync/async testing to work properly, your client must meet these requirements:

### 1. Virtual Methods

All async methods and properties must be marked as `virtual`:

```C# Snippet:VirtualMethodRequirement
public class SampleClientVirtualMethods
{
    // ✅ Correct - virtual async method
    public virtual async Task<ClientResult<SampleData>> GetDataAsync(string id)
    {
        // Implementation
        await Task.Delay(10);
        return ClientResult.FromValue(new SampleData { Id = id, Success = true }, null!);
    }

    // ✅ Correct - virtual sync method
    public virtual ClientResult<SampleData> GetData(string id)
    {
        // Implementation
        return ClientResult.FromValue(new SampleData { Id = id, Success = true }, null!);
    }

    // ❌ Wrong - non-virtual method cannot be intercepted
    public async Task<ClientResult<SampleData>> GetDataAsyncWrong(string id)
    {
        // This won't work with sync/async testing
        await Task.Delay(10);
        return ClientResult.FromValue(new SampleData { Id = id, Success = true }, null!);
    }
}
```

### 2. Consistent Method Pairs

Ensure sync and async methods have consistent signatures:

```C# Snippet:ConsistentMethodPairs
public class SampleClientMethodPairs
{
    // ✅ Correct - consistent pair
    public virtual ClientResult<SampleData> GetData(string id)
    {
        // Sync implementation
        return ClientResult.FromValue(new SampleData { Id = id, Success = true }, null!);
    }

    public virtual async Task<ClientResult<SampleData>> GetDataAsync(string id)
    {
        // Async implementation
        await Task.Delay(10);
        return ClientResult.FromValue(new SampleData { Id = id, Success = true }, null!);
    }

    // ✅ Correct - with CancellationToken
    public virtual ClientResult<SampleData> GetData(string id, CancellationToken cancellationToken = default)
    {
        // Sync implementation
        return ClientResult.FromValue(new SampleData { Id = id, Success = true }, null!);
    }

    public virtual async Task<ClientResult<SampleData>> GetDataAsync(string id, CancellationToken cancellationToken = default)
    {
        // Async implementation
        await Task.Delay(10, cancellationToken);
        return ClientResult.FromValue(new SampleData { Id = id, Success = true }, null!);
    }
}
```

## Best Practices

### 1. Test Organization

```C# Snippet:TestOrganization
[ClientTestFixture]
public class WellOrganizedTests : ClientTestBase
{
    private SampleClient _client;

    public WellOrganizedTests(bool isAsync) : base(isAsync)
    {
    }

    [SetUp]
    public void Setup()
    {
        _client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));
    }

    [Test]
    public async Task BasicOperations()
    {
        var result = await _client.GetDataAsync("test-id");
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task ComplexOperations()
    {
        var create = await _client.CreateResourceAsync(new SampleResource("test"));
        var update = await _client.UpdateResourceAsync(create.Value.Id, "updated");
        var delete = await _client.DeleteResourceAsync(update.Value.Id);

        Assert.That(create.Value, Is.Not.Null);
        Assert.That(update.Value, Is.Not.Null);
        Assert.That(delete.GetRawResponse().Status, Is.EqualTo(200)); // Check HTTP status for delete operation
    }
}
```

### 2. Proper Exception Testing

```C# Snippet:ExceptionTesting
[ClientTestFixture]
public class ExceptionTests : ClientTestBase
{
    public ExceptionTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void ProperExceptionHandling()
    {
        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("invalid")));

        // Use Assert.ThrowsAsync for both sync and async modes
        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetSecureDataAsync());

        Assert.That(exception.Status, Is.EqualTo(401));
    }
}
```

### 3. Timeout Configuration

```C# Snippet:TimeoutConfiguration
[ClientTestFixture]
public class TimeoutTests : ClientTestBase
{
    public TimeoutTests(bool isAsync) : base(isAsync)
    {
        // Increase timeout for complex operations
        TestTimeoutInSeconds = 30;
    }

    [Test]
    public async Task LongRunningOperation()
    {
        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));

        var result = await client.ProcessLargeDataAsync();
        Assert.That(result, Is.Not.Null);
    }
}
```

## Troubleshooting

### Common Issues

1. **Non-Virtual Methods**: Ensure all methods are marked as `virtual`
2. **Missing Sync Overloads**: Each async method should have a corresponding sync method
3. **Inconsistent Signatures**: Sync and async method signatures should match except for return type
4. **Instrumentation Issues**: Always use `InstrumentClient()` to wrap your client instances

### Debugging Tips

```C# Snippet:DebuggingTips
[ClientTestFixture]
public class DebuggingTests : ClientTestBase
{
    public DebuggingTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task DiagnosticTest()
    {
        // Log which mode we're testing
        TestContext.WriteLine($"Running in {(IsAsync ? "Async" : "Sync")} mode");

        var client = CreateProxyFromClient(new SampleClient(
            new Uri("https://example.com"),
            new ApiKeyCredential("test")));

        // Test a simple operation to verify instrumentation works
        var result = await client.GetDataAsync("test-id");

        TestContext.WriteLine($"Result type: {result.GetType().Name}");
        Assert.That(result, Is.Not.Null);
    }
}
```