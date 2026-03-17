// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    // Avoid running these tests in parallel with anything else that's sharing the event source
    [NonParallelizable]
    public class BatchingTests : SearchTestBase
    {
        public BatchingTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Utilities
        private const int BatchSize = SearchIndexingBufferedSenderOptions<object>.DefaultInitialBatchActionCount;
        private readonly TimeSpan EventDelay = TimeSpan.FromMilliseconds(250);

        public class SimpleDocument
        {
            [SimpleField(IsKey = true)]
            public string Id { get; set; }

            [SearchableField]
            public string Name { get; set; }

            public static SimpleDocument[] GetDocuments(int count) =>
                Enumerable.Range(1, count)
                .Select(i => new SimpleDocument { Id = $"{i}", Name = $"Document #{i}" })
                .ToArray();

            public static SimpleDocument[] GetLargeDocuments(int count, int size = 4092) =>
                Enumerable.Range(1, count)
                .Select(i =>
                    new SimpleDocument
                    {
                        Id = $"{i}",
                        Name = new string('!', size)
                    })
                .ToArray();
        }

        private static void AssertNoFailures<T>(SearchIndexingBufferedSender<T> indexer)
        {
            indexer.ActionFailed +=
                (IndexActionFailedEventArgs<T> e) =>
                {
                    StringBuilder message = new StringBuilder();
                    if (e.Result != null)
                    {
                        Assert.IsFalse(e.Result.Succeeded);
                        message.AppendLine($"key {e.Result.Key} failed with {e.Result.Status}: {e.Result.ErrorMessage}");
                    }
                    if (e.Exception != null)
                    {
                        message.AppendLine(e.Exception.ToString());
                    }
                    Assert.Fail(message.ToString());
                    return Task.CompletedTask;
                };
        }

        private static ConcurrentQueue<IndexDocumentsAction<T>> TrackFailures<T>(SearchIndexingBufferedSender<T> indexer)
        {
            ConcurrentQueue<IndexDocumentsAction<T>> failures = new ConcurrentQueue<IndexDocumentsAction<T>>();
            indexer.ActionFailed +=
                (IndexActionFailedEventArgs<T> e) =>
                {
                    failures.Enqueue(e.Action);
                    return Task.CompletedTask;
                };
            return failures;
        }

        private static ConcurrentDictionary<int, IndexDocumentsAction<T>> TrackPending<T>(SearchIndexingBufferedSender<T> indexer)
        {
            ConcurrentDictionary<int, IndexDocumentsAction<T>> pending = new ConcurrentDictionary<int, IndexDocumentsAction<T>>();
            indexer.ActionAdded +=
                (IndexActionEventArgs<T> e) =>
                {
                    pending[e.Action.GetHashCode()] = e.Action;
                    return Task.CompletedTask;
                };
            indexer.ActionCompleted +=
                (IndexActionCompletedEventArgs<T> e) =>
                {
                    pending.TryRemove(e.Action.GetHashCode(), out IndexDocumentsAction<T> _);
                    return Task.CompletedTask;
                };
            indexer.ActionFailed +=
                (IndexActionFailedEventArgs<T> e) =>
                {
                    pending.TryRemove(e.Action.GetHashCode(), out IndexDocumentsAction<T> _);
                    return Task.CompletedTask;
                };
            return pending;
        }

        public class BatchingSearchClient : SearchClient
        {
            private TaskCompletionSource<object> _notifier = new TaskCompletionSource<object>(
                TaskCreationOptions.RunContinuationsAsynchronously);

            public virtual bool SplitNextBatch { get; set; }
            public virtual Task<object> BatchSubmitted => _notifier.Task;
            public virtual bool CollectSubmissions { get; set; }
            public virtual IList<Response<IndexDocumentsResult>> Submissions { get; } =
                new List<Response<IndexDocumentsResult>>();
            public virtual Func<IndexingResult, IndexingResult> ResponseTransformer { get; set; }

            public BatchingSearchClient() : base()
            {
            }

            public BatchingSearchClient(Uri endpoint, string indexName, AzureKeyCredential credential, SearchClientOptions options)
                : base(endpoint, indexName, credential, options)
            {
            }

            private void SplitWhenRequested()
            {
                if (SplitNextBatch)
                {
                    SplitNextBatch = false;
                    throw new RequestFailedException(413, "Split");
                }
            }

            private Response<IndexDocumentsResult> ProcessResponse(Response<IndexDocumentsResult> response)
            {
                if (CollectSubmissions)
                {
                    Submissions.Add(response);
                }
                if (ResponseTransformer != null)
                {
                    List<IndexingResult> results = response.Value.Results.ToList();
                    for (int i = 0; i < results.Count; i++)
                    {
                        results[i] = ResponseTransformer(results[i]);
                    }
                    response = Response.FromValue(
                        new IndexDocumentsResult(results),
                        response.GetRawResponse());
                }
                return response;
            }

            private void RaiseNotification()
            {
                TaskCompletionSource<object> previous = _notifier;
                _notifier = new TaskCompletionSource<object>(
                    TaskCreationOptions.RunContinuationsAsynchronously);
                previous.SetResult(null);
            }

            public override Response<IndexDocumentsResult> IndexDocuments<T>(IndexDocumentsBatch<T> batch, IndexDocumentsOptions options = null, CancellationToken cancellationToken = default)
            {
                try
                {
                    SplitWhenRequested();
                    return ProcessResponse(base.IndexDocuments(batch, options, cancellationToken));
                }
                finally
                {
                    RaiseNotification();
                }
            }

            public override async Task<Response<IndexDocumentsResult>> IndexDocumentsAsync<T>(IndexDocumentsBatch<T> batch, IndexDocumentsOptions options = null, CancellationToken cancellationToken = default)
            {
                try
                {
                    SplitWhenRequested();
                    return ProcessResponse(await base.IndexDocumentsAsync(batch, options, cancellationToken).ConfigureAwait(false));
                }
                finally
                {
                    RaiseNotification();
                }
            }

            public virtual SearchIndexingBufferedSender<T> CreateIndexingBufferedSender<T>(
                SearchIndexingBufferedSenderOptions<T> options = null) =>
                new SearchIndexingBufferedSender<T>(this, options);
        }

        public BatchingSearchClient GetBatchingSearchClient(SearchResources resources)
        {
            return InstrumentClient(
                new BatchingSearchClient(
                    resources.Endpoint,
                    resources.IndexName,
                    new AzureKeyCredential(resources.PrimaryApiKey),
                    GetSearchClientOptions()));
        }
        #endregion

        #region Champion
        [Test]
        [LiveOnly]
        public async Task Champion_OneShotUpload()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(10000);

            // Wrap in a block so we DisposeAsync before getting the Count below
            {
                await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                    client.CreateIndexingBufferedSender<SimpleDocument>();
                AssertNoFailures(indexer);
                await indexer.UploadDocumentsAsync(data);
            }

            // Check that we have the correct number of documents
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Champion_ContinueAddingWhileSending()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(1000);

            // Wrap in a block so we DisposeAsync before getting the Count below
            {
                await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                    client.CreateIndexingBufferedSender<SimpleDocument>();
                AssertNoFailures(indexer);

                // Trickle documents in
                for (int i = 0; i < data.Length; i++)
                {
                    await indexer.UploadDocumentsAsync(new[] { data[i] });
                    await DelayAsync(TimeSpan.FromMilliseconds(5));
                }
            }

            // Check that we have the correct number of documents
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Champion_ManualFlushing()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(1000);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender<SimpleDocument>(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);

            await indexer.UploadDocumentsAsync(data);
            Assert.Zero((int)await resources.GetSearchClient().GetDocumentCountAsync());

            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Champion_FlushAfterInterval()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(20);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender<SimpleDocument>(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        AutoFlushInterval = TimeSpan.FromMilliseconds(100)
                    });
            AssertNoFailures(indexer);

            await indexer.UploadDocumentsAsync(data);
            Assert.Zero((int)await resources.GetSearchClient().GetDocumentCountAsync());

            await DelayAsync(TimeSpan.FromMilliseconds(500));
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Champion_FineGrainedErrors()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(1000);

            // Don't touch the failures outside of the event handler until
            // we've finished flushing
            List<IndexingResult> failures = new List<IndexingResult>();

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender<SimpleDocument>(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        AutoFlush = false
                    });
            indexer.ActionFailed +=
                (IndexActionFailedEventArgs<SimpleDocument> e) =>
                {
                    failures.Add(e.Result);
                    return Task.CompletedTask;
                };

            await indexer.UploadDocumentsAsync(data.Take(500));
            await indexer.MergeDocumentsAsync(new[] { new SimpleDocument { Id = "Fake" } });
            await indexer.UploadDocumentsAsync(data.Skip(500));

            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), 1000);

            Assert.AreEqual(1, failures.Count);
            Assert.AreEqual("Fake", failures[0].Key);
            Assert.AreEqual(404, failures[0].Status);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/25444")]
        public async Task Champion_BasicCheckpointing()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(1000);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        AutoFlush = true,
                        AutoFlushInterval = null
                    });

            int removeFailedCount = 0;

            List<IndexDocumentsAction<SimpleDocument>> pending = new List<IndexDocumentsAction<SimpleDocument>>();
            indexer.ActionAdded +=
                (IndexActionEventArgs<SimpleDocument> e) =>
                {
                    pending.Add(e.Action);
                    return Task.CompletedTask;
                };
            indexer.ActionCompleted +=
                (IndexActionCompletedEventArgs<SimpleDocument> e) =>
                {
                    if (!pending.Remove(e.Action))
                    { removeFailedCount++; }
                    return Task.CompletedTask;
                };
            indexer.ActionFailed +=
                (IndexActionFailedEventArgs<SimpleDocument> e) =>
                {
                    if (!pending.Remove(e.Action))
                    { removeFailedCount++; }
                    return Task.CompletedTask;
                };

            await indexer.UploadDocumentsAsync(data.Take(500));
            await indexer.MergeDocumentsAsync(new[] { new SimpleDocument { Id = "Fake" } });
            await indexer.UploadDocumentsAsync(data.Skip(500));

            int expectedPendingQueueSize = 1001 - BatchSize;

            await ConditionallyDelayAsync(() => (pending.Count == expectedPendingQueueSize), TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(250), 5);
            Assert.AreEqual(expectedPendingQueueSize, pending.Count);
            Assert.AreEqual(0, removeFailedCount);

            await indexer.FlushAsync();
            Assert.AreEqual(0, pending.Count);
            Assert.AreEqual(0, removeFailedCount);
        }
        #endregion

        #region KeyFieldAccessor
        [Test]
        public async Task KeyFieldAccessor_Custom()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(10);

            bool customAccessorInvoked = false;
            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender<SimpleDocument>(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        KeyFieldAccessor = (SimpleDocument doc) =>
                        {
                            customAccessorInvoked = true;
                            return doc.Id;
                        }
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);

            Assert.IsTrue(customAccessorInvoked);
        }

        public class LessSimpleDocument
        {
            [SimpleField(IsKey = true)]
            [JsonPropertyName("Id")]
            public string Foo { get; set; }

            [SearchableField]
            [JsonPropertyName("Name")]
            public string Bar { get; set; }

            public static LessSimpleDocument[] GetDocuments(int count) =>
                Enumerable.Range(1, count)
                .Select(i => new LessSimpleDocument { Foo = $"{i}", Bar = $"Document #{i}" })
                .ToArray();
        }

        [Test]
        public async Task KeyFieldAccessor_FieldBuilder()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();

            LessSimpleDocument[] data = LessSimpleDocument.GetDocuments(10);

            await using SearchIndexingBufferedSender<LessSimpleDocument> indexer = new(GetOriginal(client));
            AssertNoFailures(indexer);

            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        public class UnbuildableDocument
        {
            [FieldBuilderIgnore]
            public string Id { get; set; }

            [FieldBuilderIgnore]
            public string Name { get; set; }

            public static UnbuildableDocument[] GetDocuments(int count) =>
                Enumerable.Range(1, count)
                .Select(i => new UnbuildableDocument { Id = $"{i}", Name = $"Document #{i}" })
                .ToArray();
        }

        [Test]
        public async Task KeyFieldAccessor_FetchIndex()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            UnbuildableDocument[] data = UnbuildableDocument.GetDocuments(10);

            await using SearchIndexingBufferedSender<UnbuildableDocument> indexer =
                client.CreateIndexingBufferedSender<UnbuildableDocument>();
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task KeyFieldAccessor_Error()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            Hotel[] data = SearchResources.TestDocuments;

            await using SearchIndexingBufferedSender<Hotel> indexer =
                client.CreateIndexingBufferedSender<Hotel>();
            AssertNoFailures(indexer);
            try
            {
                await indexer.UploadDocumentsAsync(data);
            }
            catch (InvalidOperationException ex)
            {
                StringAssert.Contains(nameof(Hotel), ex.Message);
            }
        }
        #endregion

        #region AutoFlush
        [Test]
        public async Task AutoFlush_PartialBatch()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(BatchSize / 2);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlushInterval = null
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);

            await DelayAsync(TimeSpan.FromSeconds(5), EventDelay);
            Assert.Zero((int)await resources.GetSearchClient().GetDocumentCountAsync());

            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task AutoFlush_FullBatch()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlushInterval = null
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);
            await DelayAsync(EventDelay, EventDelay);
            await WaitForDocumentCountAsync(resources.GetSearchClient(), BatchSize, delay: TimeSpan.FromSeconds(2));

            // Check that we have the correct number of documents
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task AutoFlush_MultipleBatches()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 3.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlushInterval = null
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);
            await DelayAsync(TimeSpan.FromSeconds(10), EventDelay);
            await WaitForDocumentCountAsync(resources.GetSearchClient(), 3 * BatchSize, delay: TimeSpan.FromSeconds(5));

            // Check that we have the correct number of documents
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }
        #endregion

        #region AutoFlushInterval
        [Test]
        public async Task AutoFlushInterval_PartialBatch()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(20);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        AutoFlushInterval = TimeSpan.FromMilliseconds(500)
                    });
            AssertNoFailures(indexer);

            await indexer.UploadDocumentsAsync(data);
            Assert.Zero((int)await resources.GetSearchClient().GetDocumentCountAsync());

            await DelayAsync(TimeSpan.FromMilliseconds(500), EventDelay);
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task AutoFlushInterval_FullBatch()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        AutoFlushInterval = TimeSpan.FromMilliseconds(500)
                    });
            AssertNoFailures(indexer);
            ConcurrentDictionary<int, IndexDocumentsAction<SimpleDocument>> pending = TrackPending(indexer);

            Task<object> submitted = client.BatchSubmitted;
            await indexer.UploadDocumentsAsync(data);
            await submitted;
            await DelayAsync(TimeSpan.FromMilliseconds(500), EventDelay);
            Assert.AreEqual(data.Length - BatchSize, pending.Count);

            await DelayAsync(TimeSpan.FromSeconds(5), EventDelay);
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task AutoFlushInterval_TinyInterval()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        AutoFlushInterval = TimeSpan.FromMilliseconds(10)
                    });
            AssertNoFailures(indexer);

            await indexer.UploadDocumentsAsync(data);
            await DelayAsync(TimeSpan.FromSeconds(5), EventDelay);
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        [TestCase(null)]
        [TestCase(0)]
        [TestCase(-1)]
        public async Task AutoFlushInterval_DoesNotFire(int? interval)
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(BatchSize / 2);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlushInterval = interval != null ?
                            (TimeSpan?) TimeSpan.FromMilliseconds(interval.Value) :
                            null
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);

            await DelayAsync(TimeSpan.FromSeconds(3), EventDelay);
            Assert.Zero((int)await resources.GetSearchClient().GetDocumentCountAsync());
        }
        #endregion

        #region Flush
        [Test]
        public async Task Flush_SubmitsEverything()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);

            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/25727")]
        public async Task Flush_Blocks()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);
            ConcurrentDictionary<int, IndexDocumentsAction<SimpleDocument>> pending = TrackPending(indexer);

            await indexer.UploadDocumentsAsync(data);
            await DelayAsync(EventDelay, EventDelay);
            Assert.AreEqual(data.Length, pending.Count);

            await indexer.FlushAsync();
            await DelayAsync(EventDelay, EventDelay);
            Assert.Zero(pending.Count);
        }
        #endregion

        #region Dispose
        [Test]
        public async Task Dispose_Flushes()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);

            await ((IAsyncDisposable)indexer).DisposeAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21515")]
        public async Task Dispose_Blocks()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);
            ConcurrentDictionary<int, IndexDocumentsAction<SimpleDocument>> pending = TrackPending(indexer);

            await indexer.UploadDocumentsAsync(data);
            await DelayAsync(TimeSpan.FromMilliseconds(500), EventDelay);
            Assert.AreEqual(data.Length, pending.Count);

            await ((IAsyncDisposable)indexer).DisposeAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Dispose_DoubleDisposeIsSafe()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);

            await ((IAsyncDisposable)indexer).DisposeAsync();
            await ((IAsyncDisposable)indexer).DisposeAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Dispose_ThrowsAfterDispose()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);

            await ((IAsyncDisposable)indexer).DisposeAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
            Assert.ThrowsAsync<ObjectDisposedException>(async () => await indexer.UploadDocumentsAsync(data));
        }

        [Test]
        public async Task Dispose_UndisposedNoCrash()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);

            // To verify the developer experience, debug this test with first
            // chance exceptions enabled and you'll see an exception raised
            // from the SearchIndexingBufferedSender finalizer like:
            // "Azure.Core.ObjectNotDisposedException: 'SearchIndexingBufferedSender has 768 unsent indexing actions.'"
            if (Debugger.IsAttached)
            {
                indexer = null;
                int maxAttempts = 10;
                for (int i = 0; i < maxAttempts; i++)
                {
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
                    GC.WaitForPendingFinalizers();
                    await DelayAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
                }
            }
        }
        #endregion

        #region Conveniences
        [Test]
        public async Task Convenience_Delete()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            AssertNoFailures(indexer);
            await indexer.DeleteDocumentsAsync(data);
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), 0);
        }

        [Test]
        public async Task Convenience_Merge()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            ConcurrentQueue<IndexDocumentsAction<SimpleDocument>> failures = TrackFailures(indexer);
            await indexer.MergeDocumentsAsync(data);
            await indexer.FlushAsync();
            Assert.AreEqual(data.Length, failures.Count);
        }

        [Test]
        public async Task Convenience_MergeOrUpload()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            AssertNoFailures(indexer);
            await indexer.MergeOrUploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Convenience_Upload()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Convenience_None()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(3);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            AssertNoFailures(indexer);
            IndexDocumentsBatch<SimpleDocument> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Delete<SimpleDocument>(data[0]),
                IndexDocumentsAction.Upload<SimpleDocument>(data[1]),
                IndexDocumentsAction.MergeOrUpload<SimpleDocument>(data[2]));
            await indexer.IndexDocumentsAsync(batch);
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), 2);
        }
        #endregion

        #region Notifications
        [Test]
        public async Task Notifications_Added()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            int adds = 0;
            indexer.ActionAdded += e => { adds++; return Task.CompletedTask; };
            await indexer.UploadDocumentsAsync(data);
            await DelayAsync(EventDelay, EventDelay);
            Assert.AreEqual(data.Length, adds);
        }

        [Test]
        public async Task Notifications_Sent()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            int sent = 0;
            indexer.ActionSent += e => { sent++; return Task.CompletedTask; };
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await DelayAsync(EventDelay, EventDelay);
            Assert.LessOrEqual(data.Length, sent);
        }

        [Test]
        public async Task Notifications_Completed()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            int completed = 0;
            indexer.ActionCompleted += e => { completed++; return Task.CompletedTask; };
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await DelayAsync(EventDelay, EventDelay);
            Assert.LessOrEqual(data.Length, completed);
        }

        [Test]
        public async Task Notifications_Failed()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            int failed = 0;
            indexer.ActionFailed += e => { failed++; return Task.CompletedTask; };
            await indexer.MergeDocumentsAsync(data);
            await indexer.FlushAsync();
            await DelayAsync(EventDelay, EventDelay);
            Assert.AreEqual(data.Length, failed);
        }

        [Test]
        public async Task Notifications_ExceptionsGetSwallowed()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(2);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());

            // Throw from every handler
            bool added = false, sent = false, completed = false, failed = false;
            indexer.ActionAdded += e => { added = true; throw new InvalidOperationException("ActionAddedAsync: Should not be seen!"); };
            indexer.ActionSent += e => { sent = true; throw new InvalidOperationException("ActionSentAsync: Should not be seen!"); };
            indexer.ActionCompleted += e => { completed = true; throw new InvalidOperationException("ActionCompletedAsync: Should not be seen!"); };
            indexer.ActionFailed += e => { failed = true; throw new InvalidOperationException("ActionFailedAsync: Should not be seen!"); };

            // Try to merge first for Failed to fire
            await indexer.MergeDocumentsAsync(data);
            await indexer.FlushAsync();

            // Do a regular Upload the second time for Completed to fire
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();

            Assert.IsTrue(added, "ActionAddedAsync was not fired!");
            Assert.IsTrue(sent, "ActionSentAsync was not fired!");
            Assert.IsTrue(completed, "ActionCompletedAsync was not fired!");
            Assert.IsTrue(failed, "ActionFailedAsync was not fired!");
        }
        #endregion

        #region EventSource
        [Test]
        public void EventSourceMatchesNameAndGuid()
        {
            Type eventSourceType = typeof(AzureSearchDocumentsEventSource);

            Assert.NotNull(eventSourceType);
            Assert.AreEqual("Azure-Search-Documents", EventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("ecf8d17a-8cd1-5cb8-7adb-5d7d3221a642"), EventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }
        #endregion

        #region Behavior
        [Test]
        public async Task Behavior_Split()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(BatchSize);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender<SimpleDocument>();
            AssertNoFailures(indexer);

            client.SplitNextBatch = true;

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureSearchDocumentsEventSource.Instance, EventLevel.Verbose);

            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();

            List<EventWrittenEventArgs> eventData = listener.EventData.ToList();

            Assert.AreEqual(10, eventData.Count);
            Assert.AreEqual("PendingQueueResized", eventData[0].EventName);         // 1. All events are pushed into the pending queue.
            Assert.AreEqual(512, eventData[0].GetProperty<int>("queueSize"));
            Assert.AreEqual("PublishingDocuments", eventData[1].EventName);         // 2. Documents are being published.
            Assert.IsTrue(eventData[1].GetProperty<bool>("flush"));
            Assert.AreEqual("PendingQueueResized", eventData[2].EventName);         // 3. All events are pulled out of the pending queue.
            Assert.AreEqual(0, eventData[2].GetProperty<int>("queueSize"));
            Assert.AreEqual("BatchSubmitted", eventData[3].EventName);              // 4. A batch is created for submission and contains all events.
            Assert.NotNull(eventData[3].GetProperty<string>("endPoint"));
            Assert.AreEqual(512, eventData[3].GetProperty<int>("batchSize"));
            Assert.AreEqual("BatchActionPayloadTooLarge", eventData[4].EventName);  // 5. Service responded to the index request with a 'payload too large' exception.
            Assert.AreEqual(EventLevel.Warning, eventData[4].Level);                //    This event is logged at 'Warning' level.
            Assert.AreEqual(512, eventData[4].GetProperty<int>("batchActionCount"));
            Assert.AreEqual("BatchActionCountUpdated", eventData[5].EventName);     // 6. Batch is split up and default action count is updated.
            Assert.AreEqual(EventLevel.Warning, eventData[5].Level);                //    This event is logged at 'Warning' level.
            Assert.NotNull(eventData[5].GetProperty<string>("endPoint"));
            Assert.AreEqual(512, eventData[5].GetProperty<int>("oldBatchCount"));
            Assert.AreEqual(256, eventData[5].GetProperty<int>("newBatchCount"));
            Assert.AreEqual("RetryQueueResized", eventData[6].EventName);           // 7. Second part of the batch is pushed into the retry queue.
            Assert.AreEqual(256, eventData[6].GetProperty<int>("queueSize"));
            Assert.AreEqual("BatchSubmitted", eventData[7].EventName);              // 8. First part of the batch is submitted.
            Assert.NotNull(eventData[7].GetProperty<string>("endPoint"));
            Assert.AreEqual(256, eventData[7].GetProperty<int>("batchSize"));
            Assert.AreEqual("RetryQueueResized", eventData[8].EventName);           // 9. Remaining events are pulled out of the retry queue.
            Assert.AreEqual(0, eventData[8].GetProperty<int>("queueSize"));
            Assert.AreEqual("BatchSubmitted", eventData[9].EventName);              // 10. Second part of the batch is submitted.
            Assert.NotNull(eventData[9].GetProperty<string>("endPoint"));
            Assert.AreEqual(256, eventData[9].GetProperty<int>("batchSize"));

            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
        }

        [Test]
        public async Task Behavior_BatchSize()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(5);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        InitialBatchActionCount = 1
                    });
            AssertNoFailures(indexer);
            client.CollectSubmissions = true;
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await WaitForDocumentCountAsync(resources.GetSearchClient(), data.Length);
            Assert.AreEqual(5, client.Submissions.Count);
        }

        [Test]
        public async Task Behavior_SplitBatchByDocumentKey()
        {
            int numberOfDocuments = 5;

            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);

            SimpleDocument[] data = new SimpleDocument[numberOfDocuments];
            for (int i = 0; i < numberOfDocuments; i++)
            {
                data[i] = new SimpleDocument() { Id = $"{i}", Name = $"Document #{i}" };
            }

            // 'SimpleDocument' has 'Id' set as its key field.
            // Set the Ids of 2 documents in the group to be the same.
            // We expect the batch to be split at this index, even though the size of the set is smaller than the batch size.
            data[3].Id = data[0].Id;

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        // Set the expected batch action count to be larger than the number of documents in the set.
                        InitialBatchActionCount = numberOfDocuments + 1,
                    });

            int sent = 0, completed = 0;
            indexer.ActionSent += e =>
            {
                sent++;

                // Batch will be split at the 4th document.
                // So, 3 documents will be sent before any are submitted, but 3 submissions will be made before the last 2 are sent
                Assert.AreEqual((sent <= 3) ? 0 : 3, completed);

                return Task.CompletedTask;
            };

            indexer.ActionCompleted += e =>
            {
                completed++;

                // Batch will be split at the 4th document.
                // So, 3 documents will be submitted after 3 are sent, and the last 2 submissions will be made after all 5 are sent
                Assert.AreEqual((completed <= 3) ? 3 : 5, sent);

                return Task.CompletedTask;
            };

            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();

            Assert.AreEqual(5, sent);
            Assert.AreEqual(5, completed);
        }

        [Test]
        public async Task Behavior_SplitBatchByDocumentKeyIgnoreCaseDifferences()
        {
            int numberOfDocuments = 5;

            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);

            // 'SimpleDocument' has 'Id' set as its key field.
            // Set the Ids of 2 documents in the group to differ only in case from another 2.
            // We expect the batch to NOT be split because keys are case-sensitive and the publisher should consider them all unique.
            SimpleDocument[] data = new SimpleDocument[]
            {
                new SimpleDocument() { Id = "a", Name = "Document a" },
                new SimpleDocument() { Id = "b", Name = "Document b" },
                new SimpleDocument() { Id = "c", Name = "Document c" },
                new SimpleDocument() { Id = "A", Name = "Document A" },
                new SimpleDocument() { Id = "B", Name = "Document B" },
            };

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        // Make sure the expected batch action is larger than the number of documents in the set.
                        InitialBatchActionCount = numberOfDocuments + 1,
                    });

            int sent = 0, completed = 0;
            indexer.ActionSent += e =>
            {
                sent++;

                // Batch will not be split. So, no document will be submitted before all are sent.
                Assert.AreEqual(0, completed);

                return Task.CompletedTask;
            };

            indexer.ActionCompleted += e =>
            {
                completed++;

                // Batch will not be split. So, all documents will be sent before any are submitted.
                Assert.AreEqual(5, sent);

                return Task.CompletedTask;
            };

            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();

            Assert.AreEqual(5, sent);
            Assert.AreEqual(5, completed);
        }

        [Test]
        [TestCase(409)]
        [TestCase(422)]
        [TestCase(503)]
        public async Task Behavior_Retry(int status)
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(1);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender<SimpleDocument>();
            client.ResponseTransformer = (IndexingResult result) =>
            {
                client.ResponseTransformer = null;
                return new IndexingResult(result.Key, false, status);
            };
            AssertNoFailures(indexer);
            int sent = 0;
            indexer.ActionSent += e => { sent++; return Task.CompletedTask; };
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            Assert.Less(1, sent);
        }

        [Test]
        public async Task Behavior_MaxRetries()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(1);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        MaxRetriesPerIndexAction = 5,
                        MaxThrottlingDelay = Mode == RecordedTestMode.Playback ? TimeSpan.Zero : TimeSpan.FromSeconds(1)
                    });

            // Keep 503ing to count the retries
            client.ResponseTransformer = (IndexingResult result) =>
                new IndexingResult(result.Key, false, 503);

            int attempts = 0;
            indexer.ActionSent += e => { attempts++; return Task.CompletedTask; };
            await indexer.MergeOrUploadDocumentsAsync(data);
            await indexer.FlushAsync();
            Assert.AreEqual(6, attempts);
        }

        [Test]
        public async Task Behavior_RetryDelay()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(1);
            Stopwatch watch = new Stopwatch();

            // The default max delay is a minute so dropping this and triggering
            // failures should be noticeable
            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        MaxRetriesPerIndexAction = 1,
                        ThrottlingDelay = Mode == RecordedTestMode.Playback ? TimeSpan.Zero : TimeSpan.FromSeconds(3)
                    });

            // Keep 503ing to trigger delays
            client.ResponseTransformer = (IndexingResult result) =>
                new IndexingResult(result.Key, false, 503);

            watch.Start();
            await indexer.MergeOrUploadDocumentsAsync(data);
            await indexer.FlushAsync();
            watch.Stop();

            if (Mode != RecordedTestMode.Playback)
            {
                Assert.IsTrue(
                    2000 <= watch.ElapsedMilliseconds && watch.ElapsedMilliseconds <= 10000,
                    $"Expected a delay between 2000ms and 10000ms, not {watch.ElapsedMilliseconds}");
            }
            else
            {
                Assert.IsTrue(watch.ElapsedMilliseconds < 1000);
            }
        }

        [Test]
        public async Task Behavior_MaxRetryDelay()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            BatchingSearchClient client = GetBatchingSearchClient(resources);
            SimpleDocument[] data = SimpleDocument.GetDocuments(1);
            Stopwatch watch = new Stopwatch();

            // The default max delay is a minute so dropping this and triggering
            // failures should be noticeable
            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        MaxRetriesPerIndexAction = 10,
                        MaxThrottlingDelay = Mode == RecordedTestMode.Playback ? TimeSpan.Zero : TimeSpan.FromSeconds(1)
                    });

            // Keep 503ing to trigger delays
            client.ResponseTransformer = (IndexingResult result) =>
                new IndexingResult(result.Key, false, 503);

            watch.Start();
            await indexer.MergeOrUploadDocumentsAsync(data);
            await indexer.FlushAsync();
            watch.Stop();

            Assert.IsTrue(
                watch.Elapsed <= TimeSpan.FromSeconds(30),
                $"Expected a max delay of 30s, not {watch.Elapsed}");
        }
        #endregion
    }
}
