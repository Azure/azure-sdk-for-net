// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
            indexer.ActionFailedAsync +=
                (IndexDocumentsAction<T> doc,
                 IndexingResult result,
                 Exception ex,
                 CancellationToken cancellationToken) =>
                {
                    StringBuilder message = new StringBuilder();
                    if (result != null)
                    {
                        Assert.IsFalse(result.Succeeded);
                        message.AppendLine($"key {result.Key} failed with {result.Status}: {result.ErrorMessage}");
                    }
                    if (message != null)
                    {
                        message.AppendLine(ex.ToString());
                    }
                    Assert.Fail(message.ToString());
                    return Task.CompletedTask;
                };
        }

        private static ConcurrentQueue<IndexDocumentsAction<T>> TrackFailures<T>(SearchIndexingBufferedSender<T> indexer)
        {
            ConcurrentQueue<IndexDocumentsAction<T>> failures = new ConcurrentQueue<IndexDocumentsAction<T>>();
            indexer.ActionFailedAsync +=
                (IndexDocumentsAction<T> doc,
                 IndexingResult result,
                 Exception ex,
                 CancellationToken cancellationToken) =>
                {
                    failures.Enqueue(doc);
                    return Task.CompletedTask;
                };
            return failures;
        }

        private static ConcurrentDictionary<int, IndexDocumentsAction<T>> TrackPending<T>(SearchIndexingBufferedSender<T> indexer)
        {
            ConcurrentDictionary<int, IndexDocumentsAction<T>> pending = new ConcurrentDictionary<int, IndexDocumentsAction<T>>();
            indexer.ActionAddedAsync +=
                (IndexDocumentsAction<T> doc,
                 CancellationToken cancellationToken) =>
                {
                    pending[doc.GetHashCode()] = doc;
                    return Task.CompletedTask;
                };
            indexer.ActionCompletedAsync +=
                (IndexDocumentsAction<T> doc,
                 IndexingResult result,
                 CancellationToken cancellationToken) =>
                {
                    pending.TryRemove(doc.GetHashCode(), out IndexDocumentsAction<T> _);
                    return Task.CompletedTask;
                };
            indexer.ActionFailedAsync +=
                (IndexDocumentsAction<T> doc,
                 IndexingResult result,
                 Exception ex,
                 CancellationToken cancellationToken) =>
                {
                    pending.TryRemove(doc.GetHashCode(), out IndexDocumentsAction<T> _);
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
        public async Task Champion_OneShotUpload()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
            SimpleDocument[] data = SimpleDocument.GetDocuments(50000);

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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            indexer.ActionFailedAsync +=
                (IndexDocumentsAction<SimpleDocument> doc,
                 IndexingResult result,
                 Exception ex,
                 CancellationToken cancellationToken) =>
                {
                    failures.Add(result);
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
        public async Task Champion_BasicCheckpointing()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
            SimpleDocument[] data = SimpleDocument.GetDocuments(1000);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>
                    {
                        AutoFlush = true,
                        AutoFlushInterval = null
                    });

            List<IndexDocumentsAction<SimpleDocument>> pending = new List<IndexDocumentsAction<SimpleDocument>>();
            indexer.ActionAddedAsync +=
                (IndexDocumentsAction<SimpleDocument> doc, CancellationToken cancellationToken) =>
                {
                    pending.Add(doc);
                    return Task.CompletedTask;
                };
            indexer.ActionCompletedAsync +=
                (IndexDocumentsAction<SimpleDocument> doc,
                 IndexingResult result,
                 CancellationToken cancellationToken) =>
                {
                    pending.Remove(doc);
                    return Task.CompletedTask;
                };
            indexer.ActionFailedAsync +=
                (IndexDocumentsAction<SimpleDocument> doc,
                 IndexingResult result,
                 Exception ex,
                 CancellationToken cancellationToken) =>
                {
                    pending.Remove(doc);
                    return Task.CompletedTask;
                };

            await indexer.UploadDocumentsAsync(data.Take(500));
            await indexer.MergeDocumentsAsync(new[] { new SimpleDocument { Id = "Fake" } });
            await indexer.UploadDocumentsAsync(data.Skip(500));

            await DelayAsync(TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(250));
            Assert.AreEqual(1001 - BatchSize, pending.Count);

            await indexer.FlushAsync();
            Assert.AreEqual(0, pending.Count);
        }
        #endregion

        #region KeyFieldAccessor
        [Test]
        public async Task KeyFieldAccessor_Custom()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
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

            await using SearchIndexingBufferedSender<LessSimpleDocument> indexer =
                client.CreateIndexingBufferedSender<LessSimpleDocument>();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
        public async Task Flush_Blocks()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
        public async Task Dispose_Blocks()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>()
                    {
                        AutoFlush = false
                    });
            AssertNoFailures(indexer);
            await indexer.UploadDocumentsAsync(data);
        }
        #endregion

        #region Conveniences
        [Test]
        public async Task Convenience_Delete()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
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
            SearchClient client = resources.GetSearchClient();
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            int adds = 0;
            indexer.ActionAddedAsync += (a, c) => { adds++; return Task.CompletedTask; };
            await indexer.UploadDocumentsAsync(data);
            await DelayAsync(EventDelay, EventDelay);
            Assert.AreEqual(data.Length, adds);
        }

        [Test]
        public async Task Notifications_Sent()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            int sent = 0;
            indexer.ActionSentAsync += (a, c) => { sent++; return Task.CompletedTask; };
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await DelayAsync(EventDelay, EventDelay);
            Assert.LessOrEqual(data.Length, sent);
        }

        [Test]
        public async Task Notifications_Completed()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            int completed = 0;
            indexer.ActionCompletedAsync += (a, r, c) => { completed++; return Task.CompletedTask; };
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
            await DelayAsync(EventDelay, EventDelay);
            Assert.LessOrEqual(data.Length, completed);
        }

        [Test]
        public async Task Notifications_Failed()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
            SimpleDocument[] data = SimpleDocument.GetDocuments((int)(BatchSize * 1.5));

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());
            int failed = 0;
            indexer.ActionFailedAsync += (a, r, e, c) => { failed++; return Task.CompletedTask; };
            await indexer.MergeDocumentsAsync(data);
            await indexer.FlushAsync();
            await DelayAsync(EventDelay, EventDelay);
            Assert.AreEqual(data.Length, failed);
        }

        [Test]
        public async Task Notifications_ExceptionsGetSwallowed()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyIndexAsync<SimpleDocument>(this);
            SearchClient client = resources.GetSearchClient();
            SimpleDocument[] data = SimpleDocument.GetDocuments(BatchSize);

            await using SearchIndexingBufferedSender<SimpleDocument> indexer =
                client.CreateIndexingBufferedSender(
                    new SearchIndexingBufferedSenderOptions<SimpleDocument>());

            // Throw from every handler
            bool added = false, sent = false, completed = false, failed = false;
            indexer.ActionAddedAsync += (a, c) => { added = true; throw new InvalidOperationException("ActionAddedAsync: Should not be seen!"); };
            indexer.ActionSentAsync += (a, c) => { sent = true; throw new InvalidOperationException("ActionSentAsync: Should not be seen!"); };
            indexer.ActionCompletedAsync += (a, r, c) => { completed = true; throw new InvalidOperationException("ActionCompletedAsync: Should not be seen!"); };
            indexer.ActionFailedAsync += (a, r, e, c) => { failed = true; throw new InvalidOperationException("ActionFailedAsync: Should not be seen!"); };

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
            await indexer.UploadDocumentsAsync(data);
            await indexer.FlushAsync();
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
            indexer.ActionSentAsync += (a, c) => { sent++; return Task.CompletedTask; };
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
                        MaxRetries = 5,
                        MaxRetryDelay = TimeSpan.FromSeconds(1)
                    });

            // Keep 503ing to count the retries
            client.ResponseTransformer = (IndexingResult result) =>
                new IndexingResult(result.Key, false, 503);

            int attempts = 0;
            indexer.ActionSentAsync += (a, c) => { attempts++; return Task.CompletedTask; };
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
                        MaxRetries = 1,
                        RetryDelay = TimeSpan.FromSeconds(3)
                    });

            // Keep 503ing to trigger delays
            client.ResponseTransformer = (IndexingResult result) =>
                new IndexingResult(result.Key, false, 503);

            watch.Start();
            await indexer.MergeOrUploadDocumentsAsync(data);
            await indexer.FlushAsync();
            watch.Stop();

            Assert.IsTrue(
                2000 <= watch.ElapsedMilliseconds && watch.ElapsedMilliseconds <= 10000,
                $"Expected a delay between 2000ms and 10000ms, not {watch.ElapsedMilliseconds}");
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
                        MaxRetries = 10,
                        MaxRetryDelay = TimeSpan.FromSeconds(1)
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
