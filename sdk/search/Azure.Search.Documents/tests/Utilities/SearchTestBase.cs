// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Base class for Search unit tests that adds shared infrastructure on top
    /// of the Azure.Core testing framework.
    /// </summary>
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2019_05_06_Preview)]
    public abstract partial class SearchTestBase : RecordedTestBase
    {
        /// <summary>
        /// The maximum number of retries for service requests.
        /// </summary>
        private const int MaxRetries = 5;

        /// <summary>
        /// Shared HTTP client instance with a longer timeout.  It's
        /// gratuitously long for the sake of live tests in a hammered
        /// environment.
        /// </summary>
        private static readonly HttpClient s_httpClient =
            new HttpClient() { Timeout = TimeSpan.FromSeconds(1000) };

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
        /// <param name="options">Optional client options.</param>
        /// <returns>SearchClientOptions for testing</returns>
        public SearchClientOptions GetSearchClientOptions(SearchClientOptions options = null)
        {
            options ??= new SearchClientOptions(ServiceVersion);
            options.Diagnostics.IsLoggingEnabled = true;
            options.Retry.Mode = RetryMode.Exponential;
            options.Retry.MaxRetries = MaxRetries;
            options.Retry.Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 0.5);
            options.Retry.MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 10);
            options.Transport = new HttpClientTransport(s_httpClient);
            return Recording.InstrumentClientOptions(options);
        }

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

        /// <summary>
        /// A number of our tests have built in delays while we wait an expected
        /// amount of time for a service operation to complete and this method
        /// allows us to wait (unless we're playing back recordings, which can
        /// complete immediately).
        /// </summary>
        /// <param name="delay">The time to wait.  Defaults to 1s.</param>
        /// <param name="playbackDelay">
        /// An optional time wait if we're playing back a recorded test.  This
        /// is useful for allowing client side events to get processed.
        /// </param>
        /// <returns>A task that will (optionally) delay.</returns>
        public async Task DelayAsync(TimeSpan? delay = null, TimeSpan? playbackDelay = null)
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(delay ?? TimeSpan.FromSeconds(1));
            }
            else if (playbackDelay != null)
            {
                await Task.Delay(playbackDelay.Value);
            }
        }

        /// <summary>
        /// Assert that we can catch the desired exception.  NUnit's default
        /// forces everything to be sync.
        /// </summary>
        /// <typeparam name="T">The type of the exception.</typeparam>
        /// <param name="action">An action that raises the exception.</param>
        /// <returns>The caught exception.</returns>
        public static async Task<T> CatchAsync<T>(Func<Task> action)
            where T : Exception
        {
            Assert.IsNotNull(action);
            try
            {
                await action().ConfigureAwait(false);
                Assert.Fail("Expected exception not found");
            }
            catch (T ex)
            {
                return ex;
            }
            catch (Exception other)
            {
                Assert.Fail($"Expected exception of type {typeof(T).Name}, not {other.ToString()}");
            }

            // The compiler doesn't realize Assert.Fail is a hard stop.
            throw new InvalidOperationException("Won't ever get here!");
        }

        /// <summary>
        /// Assert that two documents are the same.  This is a regular
        /// Assert.AreEqual check for statically typed documents.
        /// Dynamic documents will ignore any extra fields on the actual
        /// document that weren't present on the expected document.
        /// </summary>
        /// <typeparam name="T">The type of documents.</typeparam>
        /// <param name="expected">The expected document.</param>
        /// <param name="actual">The actual document.</param>
        public static void AssertApproximate<T>(T expected, T actual)
        {
            if (expected is SearchDocument e && actual is SearchDocument a)
            {
                foreach (string key in e.Keys)
                {
                    Assert.AreEqual(e[key], a[key]);
                }
            }
            else
            {
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
