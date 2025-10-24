// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.ClientModel.TestFramework.Mocks;
using System.Linq;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class SyncAsyncSamples
{
    #region Snippet:BasicSyncAsyncSetup
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
    #endregion

    #region Snippet:SyncAsyncMechanism
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
    #endregion

    #region Snippet:TestExplorerDemo
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
    #endregion

    #region Snippet:AsyncOnlyTests
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
    #endregion

    #region Snippet:SyncOnlyTests
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
    #endregion

    #region Snippet:CustomInstrumentation
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
    #endregion

    #region Snippet:ErrorScenarios
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
    #endregion

    #region Snippet:SyncAsyncWithRecording
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
    #endregion

    #region Snippet:SyncAsyncPerformanceTesting
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
    #endregion

    #region Snippet:VirtualMethodRequirement
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
    #endregion

    #region Snippet:ConsistentMethodPairs
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
    #endregion

    #region Snippet:TestOrganization
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
    #endregion

    #region Snippet:ExceptionTesting
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
    #endregion

    #region Snippet:TimeoutConfiguration
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
    #endregion

    #region Snippet:DebuggingTips
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
    #endregion
}

// Extension methods and helper classes for samples
public static class SampleClientSyncAsyncExtensions
{
    public static async Task<ClientResult<SampleData>> ProcessDataAsync(this SampleClient client, string data)
    {
        return await client.GetDataAsync(data);
    }

    public static async Task StreamDataAsync(this SampleClient client, Action<byte[]> callback)
    {
        // Mock streaming operation
        await Task.Delay(10);
        callback(new byte[] { 1, 2, 3 });
    }

    public static async Task<ClientResult<SampleData>> GetDataWithRetriesAsync(this SampleClient client)
    {
        return await client.GetDataAsync("with-retries");
    }

    public static Task<ClientResult<SampleResource>> GetNonExistentResourceAsync(this SampleClient client, string id)
    {
        // This would normally throw a 404 error
        throw new ClientResultException(new MockPipelineResponse(404, "Not Found"));
    }

    public static async Task<ClientResult<SampleData>> GetSlowDataAsync(this SampleClient client)
    {
        // Simulate a slow operation that times out
        await Task.Delay(1000);
        return await client.GetDataAsync("slow");
    }

    public static async Task<ClientResult<SampleData>> ProcessLargeDataAsync(this SampleClient client)
    {
        // Simulate processing large data
        await Task.Delay(100);
        return await client.GetDataAsync("large-data");
    }
}

// Additional client types for multi-client scenarios
public class DataClient
{
    public DataClient(Uri endpoint, ApiKeyCredential credential) { }

    public virtual async Task<ClientResult<SampleData>> GetDataAsync()
    {
        await Task.Delay(10);
        return ClientResult.FromValue(new SampleData { Id = "data", Success = true }, null!);
    }
}

public class ConfigurationClient
{
    public ConfigurationClient(Uri endpoint, ApiKeyCredential credential) { }

    public virtual async Task<ClientResult<Configuration>> GetSettingsAsync()
    {
        await Task.Delay(10);
        return ClientResult.FromValue(new Configuration { Theme = "dark" }, null!);
    }
}

public class Configuration
{
    public string Theme { get; set; } = "";
}

// Sample test environment for recorded sync/async tests
public class SampleTestEnvironment : TestEnvironment
{
    public string Endpoint => GetRecordedVariable("SAMPLE_ENDPOINT");
    public string ApiKey => GetRecordedVariable("SAMPLE_API_KEY", options => options.IsSecret());

    public override Dictionary<string, string> ParseEnvironmentFile()
    {
        return new Dictionary<string, string>
        {
            { "SAMPLE_ENDPOINT", "https://example.com" },
            { "SAMPLE_API_KEY", "test-key" }
        };
    }

    public override Task WaitForEnvironmentAsync()
    {
        return Task.CompletedTask;
    }
}
