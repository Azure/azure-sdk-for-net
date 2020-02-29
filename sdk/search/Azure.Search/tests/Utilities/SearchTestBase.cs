// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Net.Http;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Search.Tests
{
    /// <summary>
    /// Base class for Search unit tests that adds shared infrastructure on top
    /// of the Azure.Core testing framework.
    /// </summary>
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2019_05_06)]
    public abstract partial class SearchTestBase : RecordedTestBase
    {
        /// <summary>
        /// The maximum number of retries for service requests.
        /// </summary>
        private const int MaxRetries = 5;

        /// <summary>
        /// The default timeout for HTTP requests.  It's gratuitously long for
        /// the sake of live tests in a hammered environment.
        /// </summary>
        private static TimeSpan TestHttpTimeout { get; } = TimeSpan.FromSeconds(1000);

        /// <summary>
        /// The version of the REST API to test against.  This will be passed
        /// to the .ctor via ClientTestFixture's values.
        /// </summary>
        protected SearchClientOptions.ServiceVersion ServiceVersion { get; }

        /// <summary>
        /// Creates a new SearchTestBase instance.
        /// </summary>
        /// <param name="async">
        /// When false, we'll rewrite our tests methods to call the sync
        /// versions of async APIs.
        /// </param>
        /// <param name="serviceVersion">
        /// Version of the REST API to test against.
        /// </param>
        /// <param name="mode">
        /// Whether to run in Playback, Record, or Live mode.  The default
        /// value is pulled from the AZURE_TEST_MODE environment variable.
        /// </param>
        public SearchTestBase(bool async, SearchClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode ?? RecordedTestUtilities.GetModeFromEnvironment())
        {
            ServiceVersion = serviceVersion;
            Sanitizer = new SearchRecordedTestSanitizer();
            Matcher = new RecordMatcher(Sanitizer);
        }

        /// <summary>
        /// Create default client options for testing (and instrument them with
        /// the recording transports).
        /// </summary>
        /// <returns>SearchClientOptions for testing</returns>
        public SearchClientOptions GetSearchClientOptions() =>
            Recording.InstrumentClientOptions(
                new SearchClientOptions(ServiceVersion)
                {
                    Diagnostics = { IsLoggingEnabled = true },
                    Retry =
                    {
                        Mode = RetryMode.Exponential,
                        MaxRetries = MaxRetries,
                        Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                        MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 10)
                    },
                    Transport = new HttpClientTransport(new HttpClient() { Timeout = TestHttpTimeout })
                });

        #region Log Failures
        /// <summary>
        /// Add a static TestEventListener which will redirect SDK logging
        /// to Console.Out for easy debugging.
        /// </summary>
        private static TestLogger Logger { get; set; }

        /// <summary>
        /// Start logging events to the console if debugging or in Live mode.
        /// This will run once before any tests.
        /// </summary>
        [OneTimeSetUp]
        public void StartLoggingEvents()
        {
            if (Debugger.IsAttached || Mode == RecordedTestMode.Live)
            {
                Logger = new TestLogger();
            }
        }

        /// <summary>
        /// Stop logging events and do necessary cleanup.
        /// This will run once after all tests have finished.
        /// </summary>
        [OneTimeTearDown]
        public void StopLoggingEvents()
        {
            Logger?.Dispose();
            Logger = null;
        }

        /// <summary>
        /// Sets up the Event listener buffer for the test about to run.
        /// This will run prior to the start of each test.
        /// </summary>
        [SetUp]
        public void SetupEventsForTest() => Logger?.SetupEventsForTest();

        /// <summary>
        /// Output the Events to the console in the case of test failure.
        /// This will include the HTTP requests and responses.
        /// This will run after each test finishes.
        /// </summary>
        [TearDown]
        public void OutputEventsForTest() => Logger?.OutputEventsForTest();
        #endregion Log Failures
    }
}
