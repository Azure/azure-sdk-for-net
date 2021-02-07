// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.GeoJson;
#endif
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using Microsoft.Spatial;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Base class for Search unit tests that adds shared infrastructure on top
    /// of the Azure.Core testing framework.
    /// </summary>
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2020_06_30)]
    public abstract partial class SearchTestBase : RecordedTestBase<SearchTestEnvironment>
    {
        /// <summary>
        /// Shared HTTP client instance with a longer timeout.  It's
        /// gratuitously long for the sake of live tests in a hammered
        /// environment.
        /// </summary>
        private static readonly HttpClient s_httpClient =
            new HttpClient() { Timeout = TimeSpan.FromMinutes(5) };

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
            Matcher = new RecordMatcher(compareBodies: false);
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
            options.Retry.MaxRetries = 10;
            options.Retry.Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1);
            options.Retry.MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 600);
            options.Transport = new HttpClientTransport(s_httpClient);
            return InstrumentClientOptions(options);
        }

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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to check.</param>
        /// <returns>A task that will (optionally) delay.</returns>
        /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/> was signaled.</exception>
        public async Task DelayAsync(TimeSpan? delay = null, TimeSpan? playbackDelay = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

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
        /// <param name="expected">The expected document.</param>
        /// <param name="actual">The actual document.</param>
        /// <param name="path">Optional expression path.</param>
        public static void AssertApproximate(object expected, object actual, string path = null)
        {
            if (expected is SearchDocument e && actual is SearchDocument a)
            {
                foreach (string key in e.Keys)
                {
                    object eValue = e[key];
                    object aValue =
                        (eValue is DateTimeOffset) ? a.GetDateTimeOffset(key) :
                        (eValue is double) ? a.GetDouble(key) :
                        a[key];
                    AssertApproximate(eValue, aValue, path != null ? path + "." + key : key);
                }
            }
#if EXPERIMENTAL_SPATIAL
            else if (expected is GeoPoint ePt && actual is GeoPoint aPt)
            {
                AssertEqual(ePt.Position, aPt.Position, path != null ? $"{path}.{nameof(GeoPoint.Position)}" : nameof(GeoPoint.Position));
            }
#endif
            else if (expected is GeographyPoint eGpt && actual is GeographyPoint aGpt)
            {
                AssertEqual(eGpt, aGpt, path);
            }
            else
            {
                AssertEqual(expected, actual, path);
            }

            static void AssertEqual(object e, object a, string path)
            {
                string location = path != null ? " at path " + path : "";
                Assert.AreEqual(e, a, $"Expected value `{e}`{location}, not `{a}`.");
            }
        }

        /// <summary>
        /// Waits for an indexer to complete up to the given <paramref name="timeout"/>.
        /// </summary>
        /// <param name="client">The <see cref="SearchIndexerClient"/> to use for requests.</param>
        /// <param name="indexerName">The name of the <see cref="SearchIndexer"/> to check.</param>
        /// <param name="timeout">The amount of time before being canceled. The default is 10 minutes.</param>
        /// <returns>A <see cref="Task"/> to await.</returns>
        protected async Task WaitForIndexingAsync(
            SearchIndexerClient client,
            string indexerName,
            TimeSpan? timeout = null)
        {
            TimeSpan delay = TimeSpan.FromSeconds(10);
            TimeSpan maxDelay = TimeSpan.FromMinutes(1);

            timeout ??= TimeSpan.FromMinutes(10);

            using CancellationTokenSource cts = new CancellationTokenSource(timeout.Value);

            while (true)
            {
                SearchIndexerStatus status = null;
                try
                {
                    await DelayAsync(delay, cancellationToken: cts.Token);

                    status = await client.GetIndexerStatusAsync(
                        indexerName,
                        cancellationToken: cts.Token);
                }
                catch (TaskCanceledException)
                {
                    // TODO: Remove this when we figure out a more correlative way of checking status.
                    Assert.Inconclusive("Timed out while waiting for the indexer to complete");
                }

                if (status.Status == IndexerStatus.Running)
                {
                    if (status.LastResult?.Status == IndexerExecutionStatus.Success)
                    {
                        return;
                    }
                    else if (status.LastResult?.Status == IndexerExecutionStatus.TransientFailure &&
                        status.LastResult is IndexerExecutionResult lastResult)
                    {
                        TestContext.WriteLine($"Transient error: {lastResult.ErrorMessage}");
                    }
                }
                else if (status.Status == IndexerStatus.Error &&
                    status.LastResult is IndexerExecutionResult lastResult)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Error: {lastResult.ErrorMessage}");

                    if (lastResult.Errors?.Count > 0)
                    {
                        foreach (SearchIndexerError error in lastResult.Errors)
                        {
                            sb.AppendLine($" ---> {error.ErrorMessage}");
                        }
                    }

                    Assert.Fail(sb.ToString());
                }

                // Exponentially increase the delay to mitigate server throttling.
                delay = TimeSpan.FromSeconds(Math.Min(delay.TotalSeconds * 2, maxDelay.TotalSeconds));
            }
        }

        /// <summary>
        /// Wait until the document count for a given search index has crossed
        /// a minimum value.  This only does simple linear retries for a fixed
        /// number of attempts.
        /// </summary>
        /// <param name="searchClient">Client for the index.</param>
        /// <param name="minimumCount">Minimum document count to verify indexing.</param>
        /// <param name="attempts">Maximum number of attempts to retry.</param>
        /// <param name="delay">Delay between attempts.</param>
        /// <returns>A <see cref="Task"/> to await.</returns>
        protected async Task WaitForDocumentCountAsync(
            SearchClient searchClient,
            int minimumCount,
            int attempts = 10,
            TimeSpan? delay = null)
        {
            delay ??= TimeSpan.FromSeconds(1);
            int count = 0;
            for (int i = 0; i < attempts; i++)
            {
                count = (int)await searchClient.GetDocumentCountAsync();
                if (count >= minimumCount)
                {
                    // When using the free SKU, there may be enough load to prevent
                    // immediately replication to all replicas and we get back the
                    // wrong count. Wait a bit longer before checking again. We may
                    // also upgrade to a basic SKU, but that will take longer to
                    // provision.
                    await DelayAsync(delay);

                    return;
                }
                await DelayAsync(delay);
            }

            if (count == 0)
            {
                Assert.Inconclusive("Indexing failed to start.");
            }
            else
            {
                Assert.Fail($"Indexing only reached {count} documents and not the expected {minimumCount}!");
            }
        }
    }
}
