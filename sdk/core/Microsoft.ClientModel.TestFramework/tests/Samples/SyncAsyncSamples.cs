// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

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
    #endregion

    [ClientTestFixture]
    public class SpecializedTests : ClientTestBase
    {
        public SpecializedTests(bool isAsync) : base(isAsync)
        {
        }

        #region Snippet:AsyncOnlyTests
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
        #endregion

        #region Snippet:SyncOnlyTests
        [Test]
        [SyncOnly]
        public async Task SyncOnlyFeature()
        {
            // No need to proxy since this is sync-only, but also works the same way if proxied,
            // so existing helper methods can be used as needed
            MapsClient client = CreateProxyFromClient(new MapsClient(
                new Uri("https://atlas.microsoft.com"),
                new ApiKeyCredential("test-key")));

            // Test sync-specific behavior
            IPAddressCountryPair result = await client.GetCountryCodeAsync(IPAddress.Parse("8.8.8.8"));
        }
        #endregion
    }

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
            MapsClientOptions options = InstrumentClientOptions(new MapsClientOptions());
            MapsClient client = CreateProxyFromClient(new MapsClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.SubscriptionKey),
                options));

            // This will be recorded for both sync and async modes
            IPAddressCountryPair result = await client.GetCountryCodeAsync(IPAddress.Parse("8.8.8.8"));
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
    }
    #endregion

}

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
