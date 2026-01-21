// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class SyncAsyncSamples
{
    #region Snippet:BasicSyncAsyncSetup
    public class MapsClientTests : ClientTestBase
    {
        public MapsClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CanPerformBasicOperation()
        {
            MapsClientOptions options = new();

#if !SNIPPET
            MockPipelineTransport transport = new MockPipelineTransport(message =>
            {
                var request = (MockPipelineRequest)message.Request;

                // AddCountryCode
                if (request.Method == "PATCH" && request.Uri!.PathAndQuery.Contains("countries"))
                {
                    return new MockPipelineResponse(200)
                        .WithContent("""{"isoCode": "TS"}""")
                        .WithHeader("Content-Type", "application/json");
                }

                // GetCountryCode
                if (request.Method == "GET" && request.Uri!.PathAndQuery.Contains("geolocation/ip"))
                {
                    return new MockPipelineResponse(200)
                        .WithContent("""
                {
                    "countryRegion": {"isoCode": "TS"},
                    "ipAddress": "203.0.113.1"
                }
                """)
                        .WithHeader("Content-Type", "application/json");
                }

                return new MockPipelineResponse(404);
            });
            transport.ExpectSyncPipeline = !IsAsync;
            options.Transport = transport;
#endif

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
    #endregion

    public class SpecializedTests : ClientTestBase
    {
        private MockPipelineTransport _transport;

        public SpecializedTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            _transport = new(message =>
            {
                var request = (MockPipelineRequest)message.Request;

                // AddCountryCode
                if (request.Method == "PATCH" && request.Uri!.PathAndQuery.Contains("countries"))
                {
                    return new MockPipelineResponse(200)
                        .WithContent("""{"isoCode": "TS"}""")
                        .WithHeader("Content-Type", "application/json");
                }

                // GetCountryCode
                if (request.Method == "GET" && request.Uri!.PathAndQuery.Contains("geolocation/ip"))
                {
                    return new MockPipelineResponse(200)
                        .WithContent("""
                {
                    "countryRegion": {"isoCode": "TS"},
                    "ipAddress": "203.0.113.1"
                }
                """)
                        .WithHeader("Content-Type", "application/json");
                }

                return new MockPipelineResponse(404);
            });
            _transport.ExpectSyncPipeline = !IsAsync;
        }

        #region Snippet:AsyncOnlyTests
        [Test]
        [AsyncOnly]
        public async Task AsyncOnlyFeature()
        {
            // No need to proxy since this is async-only, but also works the same way if proxied,
            // so existing helper methods can be used as needed
            MapsClientOptions options = new();
#if !SNIPPET
            options.Transport = _transport;
#endif
            MapsClient client = new(new Uri("https://atlas.microsoft.com"),
                new ApiKeyCredential("test-key"),
                options);

            // Test async-specific functionality
            string[] ipAddresses = ["8.8.8.8", "1.1.1.1", "208.67.222.222"];
            IEnumerable<Task<ClientResult>> tasks = ipAddresses.Select(ip => client.GetCountryCodeAsync(ip));
            ClientResult[] results = await Task.WhenAll(tasks);
        }
        #endregion

        #region Snippet:SyncOnlyTests
        [Test]
        [SyncOnly]
        public void SyncOnlyFeature()
        {
            // No need to proxy since this is sync-only, but also works the same way if proxied,
            // so existing helper methods can be used as needed
            MapsClientOptions options = new();
#if !SNIPPET
            options.Transport = _transport;
#endif
            MapsClient client = CreateProxyFromClient(new MapsClient(
                new Uri("https://atlas.microsoft.com"),
                new ApiKeyCredential("test-key"),
                options));

            // Test sync-specific behavior
            IPAddressCountryPair result = client.GetCountryCode(IPAddress.Parse("8.8.8.8"));
        }
        #endregion

        [Test]
        public async Task ErrorScenarioTest()
        {
            #region Snippet:ErrorScenario
            MapsClientOptions options = new();
#if !SNIPPET
            MockPipelineTransport transport = new MockPipelineTransport(message =>
              new MockPipelineResponse(401));
            transport.ExpectSyncPipeline = !IsAsync;
            options.Transport = transport;
#endif
            MapsClient client = CreateProxyFromClient(new MapsClient(
            new Uri("https://atlas.microsoft.com"),
            new ApiKeyCredential("invalid-key"),
            options));

            // Test error handling in both sync and async modes
            ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
                async () => await client.GetCountryCodeAsync("8.8.8.8"));
            #endregion
        }
    }

    #region Snippet:SyncAsyncWithRecording
    public class RecordedSyncAsyncTests : RecordedTestBase<MapsTestEnvironment>
    {
        public RecordedSyncAsyncTests(bool isAsync) : base(isAsync)
        {
        }

#if !SNIPPET
        private MockPipelineTransport _transport;

        [SetUp]
        public void Setup()
        {
            _transport = new(message =>
            {
                var request = (MockPipelineRequest)message.Request;

                // AddCountryCode
                if (request.Method == "PATCH" && request.Uri!.PathAndQuery.Contains("countries"))
                {
                    return new MockPipelineResponse(200)
                        .WithContent("""{"isoCode": "TS"}""")
                        .WithHeader("Content-Type", "application/json");
                }

                // GetCountryCode
                if (request.Method == "GET" && request.Uri!.PathAndQuery.Contains("geolocation/ip"))
                {
                    return new MockPipelineResponse(200)
                        .WithContent("""
                {
                    "countryRegion": {"isoCode": "TS"},
                    "ipAddress": "203.0.113.1"
                }
                """)
                        .WithHeader("Content-Type", "application/json");
                }

                return new MockPipelineResponse(404);
            });
            _transport.ExpectSyncPipeline = !IsAsync;
        }
#endif

        [RecordedTest]
        public async Task RecordedSyncAsyncTest()
        {
            // Combine recording with sync/async testing
            MapsClientOptions options = new();
#if !SNIPPET
            options.Transport = _transport;
#endif
            MapsClientOptions instrumentedOptions = InstrumentClientOptions(options);
            MapsClient client = CreateProxyFromClient(new MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                instrumentedOptions));

            // This will be recorded for both sync and async modes
            IPAddressCountryPair result = await client.GetCountryCodeAsync(IPAddress.Parse("8.8.8.8"));
        }
    }
    #endregion

    #region Snippet:TimeoutConfiguration
    public class TimeoutTests : ClientTestBase
    {
        public TimeoutTests(bool isAsync) : base(isAsync)
        {
            // Increase timeout for complex operations
            TestTimeoutInSeconds = 30;
        }
    }
    #endregion

}

public class MapsTestEnvironment : TestEnvironment
{
    public string Endpoint => GetOptionalVariable("MAPS_ENDPOINT") ?? "";
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
