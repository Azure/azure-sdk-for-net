# Test Utilities with Microsoft.ClientModel.TestFramework

This sample demonstrates the advanced utilities and helpers available in the Test Framework for specialized testing scenarios and common testing patterns.

## Overview

The Test Framework provides various utilities to help with:
- Environment variable and configuration management
- Test randomization and deterministic values
- Async testing helpers and extensions
- Custom assertions and validation helpers
- Debugging and diagnostics tools

## Environment Variable Management

### TestEnvVar Utility

The `TestEnvVar` utility provides a structured way to manage environment variables in tests:

```C# Snippet:TestEnvVarUsage
[TestFixture]
public class EnvironmentVariableTests
{
    [Test]
    public void CanSetAndRetrieveEnvironmentVariable()
    {
        // Use TestEnvVar to temporarily set environment variables
        using var testEnvVar = new TestEnvVar("TEST_SAMPLE_VALUE", "test-value");

        // Retrieve the value that was set
        var value = Environment.GetEnvironmentVariable("TEST_SAMPLE_VALUE");
        Assert.That(value, Is.EqualTo("test-value"));

        // Variable will be automatically restored when disposed
    }

    [Test]
    public void CanSetMultipleEnvironmentVariables()
    {
        // Set multiple environment variables for testing
        var variables = new Dictionary<string, string>
        {
            { "TEST_VAR_1", "value1" },
            { "TEST_VAR_2", "value2" }
        };

        using var testEnvVar = new TestEnvVar(variables);

        Assert.That(Environment.GetEnvironmentVariable("TEST_VAR_1"), Is.EqualTo("value1"));
        Assert.That(Environment.GetEnvironmentVariable("TEST_VAR_2"), Is.EqualTo("value2"));
    }

    [Test]
    public void EnvironmentVariablesAreRestoredAfterDispose()
    {
        // Store original value
        var originalValue = Environment.GetEnvironmentVariable("TEST_RESTORE_VAR");

        using (var testEnvVar = new TestEnvVar("TEST_RESTORE_VAR", "temporary-value"))
        {
            Assert.That(Environment.GetEnvironmentVariable("TEST_RESTORE_VAR"), Is.EqualTo("temporary-value"));
        }

        // Value should be restored
        Assert.That(Environment.GetEnvironmentVariable("TEST_RESTORE_VAR"), Is.EqualTo(originalValue));
    }
}
```

## Test Randomization

### TestRandom for Deterministic Values

Use `TestRandom` to generate deterministic random values in tests:

```C# Snippet:TestRandomUsage
[TestFixture]
public class TestRandomTests
{
    [Test]
    public void TestRandomProvidesDeterministicValues()
    {
        // Create a TestRandom with a known seed for deterministic behavior
        var testRandom = new TestRandom(RecordedTestMode.Playback, 42);

        // Generate deterministic values
        var randomInt = testRandom.Next(1, 100);
        var randomGuid = testRandom.NewGuid();

        // Values should be deterministic based on seed
        Assert.That(randomInt >= 1 && randomInt < 100);
        Assert.That(randomGuid, Is.Not.EqualTo(Guid.Empty));

        // Reset with same seed should produce same values
        var testRandom2 = new TestRandom(RecordedTestMode.Playback, 42);
        Assert.That(randomInt, Is.EqualTo(testRandom2.Next(1, 100)));
        Assert.That(randomGuid, Is.EqualTo(testRandom2.NewGuid()));
    }

    [Test]
    public void TestRandomInLiveMode()
    {
        // In Live mode, TestRandom behaves like standard Random
        var testRandom = new TestRandom(RecordedTestMode.Live);

        // Generate test data
        var testIds = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            testIds.Add($"test-{testRandom.NewGuid().ToString().Substring(0, 8)}");
        }

        Assert.That(testIds.Count, Is.EqualTo(5));
        Assert.That(testIds.Distinct().Count(), Is.EqualTo(5)); // All unique
    }

    [Test]
    public void TestRandomWithExtensions()
    {
        // Test with extension methods for Random
        var random = new Random(123); // Regular Random with seed

        var guid1 = random.NewGuid(); // Uses extension method
        var guid2 = random.NewGuid();

        Assert.That(guid1, Is.Not.EqualTo(guid2));
        Assert.That(guid1, Is.Not.EqualTo(Guid.Empty));
    }
}
```

## Async Testing Extensions

### TaskExtensions for Testing

The framework provides extensions for working with async operations in tests:

```C# Snippet:TaskExtensionsUsage
[TestFixture]
public class TaskExtensionTests
{
    [Test]
    public async Task TaskExtensionsHelpWithTiming()
    {
        var startTime = DateTimeOffset.UtcNow;

        // Use extension methods for better async testing with timeout
        var result = await SomeAsyncOperation().TimeoutAfter(TimeSpan.FromSeconds(5));

        var elapsed = DateTimeOffset.UtcNow - startTime;
        Assert.That(elapsed, Is.LessThan(TimeSpan.FromSeconds(5)));
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task CanUseDefaultTimeout()
    {
        // Use the default timeout (10 seconds)
        var result = await SomeAsyncOperation().TimeoutAfterDefault();
        Assert.That(result, Is.EqualTo("completed"));
    }

    [Test]
    public async Task CanTestAsyncEnumerable()
    {
        var items = GetAsyncItems();

        // Use extension to collect async enumerable items
        var collectedItems = await items.ToEnumerableAsync();

        Assert.That(collectedItems.Count, Is.EqualTo(3));
        Assert.That(collectedItems, Contains.Item("item1"));
        Assert.That(collectedItems, Contains.Item("item2"));
        Assert.That(collectedItems, Contains.Item("item3"));
    }

    private async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(100);
        return "completed";
    }

    private async IAsyncEnumerable<string> GetAsyncItems()
    {
        yield return "item1";
        await Task.Delay(10);
        yield return "item2";
        await Task.Delay(10);
        yield return "item3";
    }
}
```

## Custom Test Assertions

### Advanced Assertion Helpers

```C# Snippet:CustomAssertions
[TestFixture]
public class CustomAssertionTests
{
    [Test]
    public async Task AsyncAssertHelpers()
    {
        // Test that async operations complete successfully
        await AsyncAssert.DoesNotThrowAsync(async () =>
        {
            await SomeAsyncOperation();
        });

        // Test async operations with specific exceptions
        await AsyncAssert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await ThrowingAsyncOperation();
        });
    }

    [Test]
    public void CollectionAssertions()
    {
        var items = new[] { "apple", "banana", "cherry" };

        // Custom collection assertions
        Assert.That(items, Is.All.Not.Null);
        Assert.That(items, Is.All.Unique);
        Assert.That(items, Is.Not.Empty);

        var numbers = new[] { 1, 2, 3, 4, 5 };
        Assert.That(numbers.All(n => n > 0), "All numbers should be positive");
    }

    [Test]
    public void StringAssertions()
    {
        var jsonString = """{"id":"test","value":42}""";

        // JSON-specific assertions
        Assert.That(jsonString, Does.Contain("\"id\":"));
        Assert.That(jsonString, Does.Contain("\"value\":42"));

        // Validate JSON structure
        Assert.That(IsValidJson(jsonString), Is.True, "Should be valid JSON");
    }

    private async Task SomeAsyncOperation()
    {
        await Task.Delay(10);
    }

    private async Task ThrowingAsyncOperation()
    {
        await Task.Delay(10);
        throw new InvalidOperationException("Test exception");
    }

    private bool IsValidJson(string json)
    {
        try
        {
            JsonDocument.Parse(json);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
```

## Test Timing and Performance

### Performance Measurement Utilities

```C# Snippet:PerformanceTestingUtilities
[TestFixture]
public class PerformanceTestingUtilities
{
    [Test]
    public async Task MeasureOperationPerformance()
    {
        var stopwatch = Stopwatch.StartNew();

        // Measure async operation
        await PerformOperationAsync();

        stopwatch.Stop();

        // Assert performance characteristics
        Assert.That(stopwatch.ElapsedMilliseconds < 1000,
            $"Operation took {stopwatch.ElapsedMilliseconds}ms, expected < 1000ms");

        TestContext.WriteLine($"Operation completed in {stopwatch.ElapsedMilliseconds}ms");
    }

    [Test]
    public async Task MeasureThroughput()
    {
        const int operationCount = 100;
        var stopwatch = Stopwatch.StartNew();

        // Perform multiple operations
        var tasks = new List<Task>();
        for (int i = 0; i < operationCount; i++)
        {
            tasks.Add(FastOperationAsync());
        }

        await Task.WhenAll(tasks);
        stopwatch.Stop();

        var operationsPerSecond = operationCount / stopwatch.Elapsed.TotalSeconds;

        Assert.That(operationsPerSecond > 10,
            $"Throughput was {operationsPerSecond:F2} ops/sec, expected > 10");

        TestContext.WriteLine($"Throughput: {operationsPerSecond:F2} operations/second");
    }

    [Test]
    public void MeasureMemoryUsage()
    {
        var initialMemory = GC.GetTotalMemory(true);

        // Perform memory-intensive operation
        var data = CreateLargeDataStructure();

        var finalMemory = GC.GetTotalMemory(false);
        var memoryUsed = finalMemory - initialMemory;

        Assert.That(memoryUsed < 10 * 1024 * 1024, // 10MB limit
            $"Operation used {memoryUsed / (1024 * 1024)}MB, expected < 10MB");

        // Clean up
        data = null;
        GC.Collect();
    }

    private async Task PerformOperationAsync()
    {
        await Task.Delay(100);
    }

    private async Task FastOperationAsync()
    {
        await Task.Delay(1);
    }

    private object CreateLargeDataStructure()
    {
        return new byte[1024 * 1024]; // 1MB array
    }
}
```

## Test Configuration and Setup

### Configuration Management

```C# Snippet:TestConfigurationManagement
[TestFixture]
public class TestConfigurationTests
{
    private TestConfiguration? _config;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // Initialize test configuration
        _config = new TestConfiguration();
        _config.LoadFromEnvironment();
        _config.LoadFromFile("test-settings.json");
    }

    [Test]
    public void CanLoadConfiguration()
    {
        Assert.That(_config, Is.Not.Null);
        Assert.That(_config!.Timeout, Is.GreaterThan(TimeSpan.Zero));
        Assert.That(_config!.BaseUri, Is.Not.Empty);
    }

    [Test]
    public void ConfigurationOverridesWork()
    {
        var customConfig = new TestConfiguration();
        customConfig.Timeout = TimeSpan.FromSeconds(30);
        customConfig.BaseUri = "https://custom.example.com";

        Assert.That(customConfig.Timeout, Is.EqualTo(TimeSpan.FromSeconds(30)));
        Assert.That(customConfig.BaseUri, Is.EqualTo("https://custom.example.com"));
    }

    // Example test configuration class
    public class TestConfiguration
    {
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(10);
        public string BaseUri { get; set; } = "https://example.com";
        public bool EnableDebugLogging { get; set; } = false;
        public Dictionary<string, string> CustomHeaders { get; set; } = new();

        public void LoadFromEnvironment()
        {
            if (int.TryParse(Environment.GetEnvironmentVariable("TEST_TIMEOUT_SECONDS"), out int timeout))
            {
                Timeout = TimeSpan.FromSeconds(timeout);
            }

            var baseUri = Environment.GetEnvironmentVariable("TEST_BASE_URI");
            if (!string.IsNullOrEmpty(baseUri))
            {
                BaseUri = baseUri;
            }

            EnableDebugLogging = Environment.GetEnvironmentVariable("TEST_DEBUG") == "true";
        }

        public void LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                var config = JsonSerializer.Deserialize<TestConfiguration>(json);
                if (config != null)
                {
                    Timeout = config.Timeout;
                    BaseUri = config.BaseUri;
                    EnableDebugLogging = config.EnableDebugLogging;
                    CustomHeaders = config.CustomHeaders;
                }
            }
        }
    }
}
```

## Debugging and Diagnostics

### Debug Helpers

```C# Snippet:DebuggingHelpers
[TestFixture]
public class DebuggingHelpers
{
    [Test]
    public async Task DiagnosticLogging()
    {
        using var diagnosticScope = new DiagnosticScope("TestOperation");
        diagnosticScope.Start();

        try
        {
            // Perform operation with detailed logging
            diagnosticScope.AddAttribute("operation.type", "data-retrieval");
            diagnosticScope.AddAttribute("request.id", Guid.NewGuid().ToString());

            await PerformDiagnosticOperationAsync();

            diagnosticScope.AddAttribute("result.status", "success");
        }
        catch (Exception ex)
        {
            diagnosticScope.AddAttribute("result.status", "error");
            diagnosticScope.AddAttribute("error.message", ex.Message);
            throw;
        }
    }

    [Test]
    public void RequestResponseLogging()
    {
        var logger = new TestLogger();

        // Log request details
        logger.LogRequest("GET", "https://example.com/api/data",
            headers: new Dictionary<string, string> { ["Authorization"] = "Bearer ***" });

        // Simulate response
        logger.LogResponse(200, "OK", responseTime: TimeSpan.FromMilliseconds(150));

        // Verify logging occurred
        Assert.That(logger.LogEntries.Any(e => e.Contains("GET")));
        Assert.That(logger.LogEntries.Any(e => e.Contains("200")));
    }

    [Test]
    public async Task ConditionalDebugging()
    {
        var isDebugMode = Debugger.IsAttached ||
                         Environment.GetEnvironmentVariable("TEST_DEBUG") == "true";

        if (isDebugMode)
        {
            // Additional debug information
            TestContext.WriteLine("Debug mode enabled - collecting detailed metrics");

            var diagnostics = new OperationDiagnostics();
            diagnostics.Start();

            await PerformDiagnosticOperationAsync();

            diagnostics.Stop();

            TestContext.WriteLine($"Operation metrics: {diagnostics}");
        }
        else
        {
            // Normal test execution
            await PerformDiagnosticOperationAsync();
        }
    }

    private async Task PerformDiagnosticOperationAsync()
    {
        await Task.Delay(100);
    }

    // Example diagnostic scope implementation
    public class DiagnosticScope : IDisposable
    {
        private readonly string _operationName;
        private readonly Dictionary<string, object> _attributes = new();
        private readonly Stopwatch _stopwatch = new();

        public DiagnosticScope(string operationName)
        {
            _operationName = operationName;
        }

        public void Start()
        {
            _stopwatch.Start();
            TestContext.WriteLine($"Starting operation: {_operationName}");
        }

        public void AddAttribute(string key, object value)
        {
            _attributes[key] = value;
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            TestContext.WriteLine($"Completed operation: {_operationName} in {_stopwatch.ElapsedMilliseconds}ms");

            foreach (var attr in _attributes)
            {
                TestContext.WriteLine($"  {attr.Key}: {attr.Value}");
            }
        }
    }

    // Example test logger
    public class TestLogger
    {
        public List<string> LogEntries { get; } = new();

        public void LogRequest(string method, string uri, Dictionary<string, string>? headers = null)
        {
            var entry = $"REQUEST: {method} {uri}";
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    entry += $"\n  {header.Key}: {header.Value}";
                }
            }
            LogEntries.Add(entry);
            TestContext.WriteLine(entry);
        }

        public void LogResponse(int statusCode, string reasonPhrase, TimeSpan responseTime)
        {
            var entry = $"RESPONSE: {statusCode} {reasonPhrase} ({responseTime.TotalMilliseconds}ms)";
            LogEntries.Add(entry);
            TestContext.WriteLine(entry);
        }
    }

    // Example operation diagnostics
    public class OperationDiagnostics
    {
        private Stopwatch _stopwatch = new();
        private long _initialMemory;

        public void Start()
        {
            _initialMemory = GC.GetTotalMemory(false);
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
        }

        public override string ToString()
        {
            var currentMemory = GC.GetTotalMemory(false);
            var memoryDelta = currentMemory - _initialMemory;

            return $"Time: {_stopwatch.ElapsedMilliseconds}ms, Memory: {memoryDelta} bytes";
        }
    }
}
```

## Test Data Management

### Test Data Generation and Management

```C# Snippet:TestDataManagement
[TestFixture]
public class TestDataManagement
{
    [Test]
    public void GenerateTestData()
    {
        var dataGenerator = new TestDataGenerator();

        // Generate realistic test data
        var users = dataGenerator.GenerateUsers(10);
        var orders = dataGenerator.GenerateOrders(users, 25);

        Assert.That(users.Count, Is.EqualTo(10));
        Assert.That(orders.Count, Is.EqualTo(25));
        Assert.That(orders.All(o => users.Any(u => u.Id == o.UserId)), Is.True);
    }

    [Test]
    public void LoadTestDataFromFile()
    {
        var testDataPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
        var dataLoader = new TestDataLoader(testDataPath);

        // Load structured test data
        var sampleData = dataLoader.LoadJson<SampleTestData>("sample-data.json");

        Assert.That(sampleData, Is.Not.Null);
        Assert.That(sampleData.Items.Count > 0);
    }

    [Test]
    public async Task GenerateLargeDataSet()
    {
        var generator = new TestDataGenerator();

        // Generate large dataset for performance testing
        var largeDataSet = await generator.GenerateLargeDataSetAsync(1000);

        Assert.That(largeDataSet.Count, Is.EqualTo(1000));
        Assert.That(largeDataSet.All(item => !string.IsNullOrEmpty(item.Id)), Is.True);
    }

    // Example test data generator
    public class TestDataGenerator
    {
        private readonly Random _random = new();

        public List<TestUser> GenerateUsers(int count)
        {
            var users = new List<TestUser>();
            for (int i = 0; i < count; i++)
            {
                users.Add(new TestUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"User{i:D3}",
                    Email = $"user{i}@example.com",
                    CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(365))
                });
            }
            return users;
        }

        public List<TestOrder> GenerateOrders(List<TestUser> users, int count)
        {
            var orders = new List<TestOrder>();
            for (int i = 0; i < count; i++)
            {
                var user = users[_random.Next(users.Count)];
                orders.Add(new TestOrder
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    Amount = _random.Next(10, 1000),
                    CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(30))
                });
            }
            return orders;
        }

        public async Task<List<TestDataItem>> GenerateLargeDataSetAsync(int count)
        {
            var items = new List<TestDataItem>();

            await Task.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    items.Add(new TestDataItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        Data = new byte[1024], // 1KB of data
                        Timestamp = DateTime.UtcNow
                    });
                }
            });

            return items;
        }
    }

    // Example test data loader
    public class TestDataLoader
    {
        private readonly string _basePath;

        public TestDataLoader(string basePath)
        {
            _basePath = basePath;
        }

        public T LoadJson<T>(string fileName)
        {
            var filePath = Path.Combine(_basePath, fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Test data file not found: {filePath}");
            }

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException("Failed to deserialize test data");
        }
    }

    // Example test data models
    public class TestUser
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }

    public class TestOrder
    {
        public string Id { get; set; } = "";
        public string UserId { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TestDataItem
    {
        public string Id { get; set; } = "";
        public byte[] Data { get; set; } = Array.Empty<byte>();
        public DateTime Timestamp { get; set; }
    }

    public class SampleTestData
    {
        public List<TestDataItem> Items { get; set; } = new();
    }
}
```

## Best Practices for Test Utilities

### Utility Organization

```C# Snippet:UtilityOrganization
[TestFixture]
public class UtilityBestPractices
{
    // Centralized test utilities
    private static readonly TestUtilities TestUtils = new();

    [Test]
    public void UseUtilitiesConsistently()
    {
        // Generate deterministic test data
        var testId = TestUtils.GenerateId("test-prefix");
        var testData = TestUtils.CreateSampleData(testId);

        Assert.That(testId.StartsWith("test-prefix"), Is.True);
        Assert.That(testId, Is.EqualTo(testData.Id));
    }

    [Test]
    public async Task UtilitiesWorkWithAsync()
    {
        var timeout = TimeSpan.FromSeconds(5);

        // Use utilities for async operations
        var result = await TestUtils.ExecuteWithTimeoutAsync(
            SomeAsyncOperation(),
            timeout);

        Assert.That(result, Is.Not.Null);
    }

    // Centralized test utilities class
    public class TestUtilities
    {
        private readonly Random _random = new(42); // Deterministic seed

        public string GenerateId(string prefix = "test")
        {
            return $"{prefix}-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }

        public SampleData CreateSampleData(string id)
        {
            return new SampleData
            {
                Id = id,
                Value = _random.Next(1, 1000),
                Timestamp = DateTime.UtcNow
            };
        }

        public async Task<T> ExecuteWithTimeoutAsync<T>(Task<T> operation, TimeSpan timeout)
        {
            using var cts = new CancellationTokenSource(timeout);
            await operation;
            return operation.Result;
        }

        public void WaitForCondition(Func<bool> condition, TimeSpan timeout)
        {
            var stopwatch = Stopwatch.StartNew();
            while (!condition() && stopwatch.Elapsed < timeout)
            {
                Thread.Sleep(100);
            }

            if (!condition())
            {
                throw new TimeoutException($"Condition not met within {timeout}");
            }
        }
    }

    public class SampleData
    {
        public string Id { get; set; } = "";
        public int Value { get; set; }
        public DateTime Timestamp { get; set; }
    }

    private async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(100);
        return "completed";
    }
}
```