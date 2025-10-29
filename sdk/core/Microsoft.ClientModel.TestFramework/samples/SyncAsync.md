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
public class MapsClientTests : ClientTestBase
{
    public MapsClientTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanPerformBasicOperation()
    {
        // Create and instrument the client
        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key")));

        // Write the test using async methods - the framework will automatically
        // test both sync and async versions
        var result = await client.GetCountryCodeAsync("8.8.8.8");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value.CountryRegion, Is.Not.Null);
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
        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key")));

        // This call will be:
        // - Async mode: client.GetCountryCodeAsync(ipAddress)
        // - Sync mode: client.GetCountryCode(ipAddress)
        var ipAddress = System.Net.IPAddress.Parse("8.8.8.8");
        var result = await client.GetCountryCodeAsync(ipAddress);

        // Verify the result contains expected data
        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.CountryRegion, Is.Not.Null);
        Assert.That(result.Value.IpAddress, Is.EqualTo(ipAddress));
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

        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key")));

        var result = await client.GetCountryCodeAsync("1.1.1.1");
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
        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key")));

        // Test async-specific functionality - batch processing multiple IPs
        var ipAddresses = new[] { "8.8.8.8", "1.1.1.1", "208.67.222.222" };
        var tasks = ipAddresses.Select(ip => client.GetCountryCodeAsync(ip));
        var results = await Task.WhenAll(tasks);

        Assert.That(results.Length, Is.EqualTo(3));
        Assert.That(results.All(r => r.Value != null), Is.True);
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
        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key")));

        // Test sync-specific behavior - immediate response processing
        var result = await client.GetCountryCodeAsync("8.8.8.8");

        // Verify we got a proper response
        Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
        Assert.That(result.Value.CountryRegion, Is.Not.Null);
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
        var options = new MapsClientOptions();
        // Configure service version or other options as needed

        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key"),
            options));

        // Test with custom configuration
        var result = await client.GetCountryCodeAsync("8.8.8.8");
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task MultipleClientTypes()
    {
        // Test when using multiple Maps client instances
        var primaryMapsClient = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("primary-key")));

        var secondaryMapsClient = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("secondary-key")));

        var result1 = await primaryMapsClient.GetCountryCodeAsync("8.8.8.8");
        var result2 = await secondaryMapsClient.GetCountryCodeAsync("1.1.1.1");

        Assert.That(result1, Is.Not.Null);
        Assert.That(result2, Is.Not.Null);
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
    public void HandlesInvalidApiKey()
    {
        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("invalid-key")));

        // Test error handling in both sync and async modes
        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            async () => await client.GetCountryCodeAsync("8.8.8.8"));

        Assert.That(exception.Status, Is.EqualTo(401));
    }

    [Test]
    public void HandlesTimeout()
    {
        var options = new MapsClientOptions();
        options.NetworkTimeout = TimeSpan.FromMilliseconds(100);

        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key"),
            options));

        TaskCanceledException exception = Assert.ThrowsAsync<TaskCanceledException>(
            async () => await client.GetCountryCodeAsync("8.8.8.8"));

        Assert.That(exception, Is.Not.Null);
    }
}
```

## Testing with Recorded Tests

Sync/async testing integrates seamlessly with recorded tests:

```C# Snippet:SyncAsyncWithRecording
[ClientTestFixture]
public class RecordedSyncAsyncTests : RecordedTestBase<MapsTestEnvironment>
{
    public RecordedSyncAsyncTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task RecordedSyncAsyncTest()
    {
        // Combine recording with sync/async testing
        var options = InstrumentClientOptions(new MapsClientOptions());
        var client = CreateProxyFromClient(new MapsClient(
            new Uri(TestEnvironment.Endpoint),
            new ApiKeyCredential(TestEnvironment.SubscriptionKey),
            options));

        // This will be recorded for both sync and async modes
        var ipAddress = System.Net.IPAddress.Parse("8.8.8.8");
        var result = await client.GetCountryCodeAsync(ipAddress);

        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.CountryRegion, Is.Not.Null);
        Assert.That(result.Value.IpAddress, Is.EqualTo(ipAddress));
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
        var client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key")));

        var stopwatch = Stopwatch.StartNew();

        // Measure performance for both sync and async - test multiple IP lookups
        var ipAddresses = new[] { "8.8.8.8", "1.1.1.1", "208.67.222.222", "4.4.4.4", "9.9.9.9" };
        var tasks = new List<Task<ClientResult<IPAddressCountryPair>>>();
        for (int i = 0; i < 5; i++)
        {
            tasks.Add(client.GetCountryCodeAsync(ipAddresses[i]));
        }

        var results = await Task.WhenAll(tasks);
        stopwatch.Stop();

        Assert.That(results.Length, Is.EqualTo(5));
        Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(10000)); // Should complete within 10 seconds

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
public class MapsClientVirtualMethods
{
    // ✅ Correct - virtual async method (from actual MapsClient)
    public virtual async Task<ClientResult<IPAddressCountryPair>> GetCountryCodeAsync(System.Net.IPAddress ipAddress)
    {
        // Implementation
        await Task.Delay(10);
        return ClientResult.FromValue(
            new IPAddressCountryPair(new CountryRegion("US"), ipAddress), 
            null!);
    }

    // ✅ Correct - virtual sync method (from actual MapsClient)
    public virtual ClientResult<IPAddressCountryPair> GetCountryCode(System.Net.IPAddress ipAddress)
    {
        // Implementation
        return ClientResult.FromValue(
            new IPAddressCountryPair(new CountryRegion("US"), ipAddress), 
            null!);
    }

    // ❌ Wrong - non-virtual method cannot be intercepted
    public async Task<ClientResult<IPAddressCountryPair>> GetCountryCodeAsyncWrong(System.Net.IPAddress ipAddress)
    {
        // This won't work with sync/async testing
        await Task.Delay(10);
        return ClientResult.FromValue(
            new IPAddressCountryPair(new CountryRegion("US"), ipAddress), 
            null!);
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
    private MapsClient _client;

    public WellOrganizedTests(bool isAsync) : base(isAsync)
    {
    }

    [SetUp]
    public void Setup()
    {
        _client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("test-key")));
    }

    [Test]
    public async Task BasicOperations()
    {
        var result = await _client.GetCountryCodeAsync("8.8.8.8");
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task ComplexOperations()
    {
        var ipAddresses = new[] { "8.8.8.8", "1.1.1.1" };
        var result1 = await _client.GetCountryCodeAsync(ipAddresses[0]);
        var result2 = await _client.GetCountryCodeAsync(ipAddresses[1]);

        Assert.That(result1.Value, Is.Not.Null);
        Assert.That(result2.Value, Is.Not.Null);
        Assert.That(result1.Value.CountryRegion, Is.Not.Null);
        Assert.That(result2.Value.CountryRegion, Is.Not.Null);
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