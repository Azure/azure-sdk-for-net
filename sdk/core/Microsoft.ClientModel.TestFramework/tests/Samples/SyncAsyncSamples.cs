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
using Maps;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class SyncAsyncSamples
{
    #region Snippet:BasicSyncAsyncSetup
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

            var client = CreateProxyFromClient(new MapsClient(
                new Uri("https://atlas.microsoft.com"),
                new ApiKeyCredential("test-key")));

            var result = await client.GetCountryCodeAsync("1.1.1.1");
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
    #endregion

    #region Snippet:ErrorScenarios
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
    #endregion

    #region Snippet:SyncAsyncWithRecording
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
    #endregion

    #region Snippet:VirtualMethodRequirement
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

// No extension methods needed since MapsClient provides real operations

// No additional client types needed since we're using real MapsClient

// Maps test environment for recorded sync/async tests
public class MapsTestEnvironment : TestEnvironment
{
    public string Endpoint => GetRecordedVariable("MAPS_ENDPOINT");
    public string SubscriptionKey => GetRecordedVariable("MAPS_SUBSCRIPTION_KEY", options => options.IsSecret());

    public override Dictionary<string, string> ParseEnvironmentFile()
    {
        return new Dictionary<string, string>
        {
            { "MAPS_ENDPOINT", "https://atlas.microsoft.com" },
            { "MAPS_SUBSCRIPTION_KEY", "test-key" }
        };
    }

    public override Task WaitForEnvironmentAsync()
    {
        return Task.CompletedTask;
    }
}
