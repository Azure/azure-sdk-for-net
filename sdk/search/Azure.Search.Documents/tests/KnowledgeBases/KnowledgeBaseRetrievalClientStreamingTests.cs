# if AZURE_SEARCH_PREVIEW
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class KnowledgeBaseRetrievalClientStreamingTests
    {
        [Test]
        public async Task RetrieveStreamAsyncEnumeratesEventsIncrementally()
        {
            const string content = """
                event: retrieval.started
                id: event-1
                retry: 2500
                data: {"requestId":"request-id","knowledgeBaseName":"fake-knowledge-base","outputMode":"answerSynthesis","reasoningEffort":{"kind":"minimal"}}

                event: activity.started
                data: {"id":1,"type":"searchIndex","startedAt":"2026-08-06T20:00:00Z","knowledgeSourceName":"products"}

                event: activity.completed
                data: {"id":1,"type":"searchIndex","startedAt":"2026-08-06T20:00:00Z","completedAt":"2026-08-06T20:00:01Z","elapsedMs":1000,"knowledgeSourceName":"products","count":2}

                event: answer.completed
                data: {"messageIndex":0,"message":{"role":"assistant","content":[{"type":"text","text":"The answer."}]}}

                event: references.completed
                data: [{"type":"searchIndex","id":"reference-1","activitySource":1,"docKey":"product-1","citationUrl":"https://example.com/products/1"}]

                event: future.event
                data: {"value":true}

                event: response.completed
                data: {"statusCode":200,"response":{}}

                event: ignored
                data: {"value":true}

                """;
            MockResponse response = new(200);
            response.SetContent(content);
            response.AddHeader("Content-Type", "text/event-stream");
            MockTransport transport = new(response);
            KnowledgeBaseRetrievalClient client = CreateClient(transport);

            IAsyncEnumerable<SseItem<KnowledgeBaseRetrievalStreamEvent>> events = client.RetrieveStreamAsync(new KnowledgeBaseRetrievalRequest());

            Assert.That(transport.Requests, Is.Empty);

            List<SseItem<KnowledgeBaseRetrievalStreamEvent>> items = new();
            await foreach (SseItem<KnowledgeBaseRetrievalStreamEvent> item in events)
            {
                items.Add(item);
            }

            Assert.That(
                items.Select(item => item.EventType),
                Is.EqualTo(new[]
                {
                    "retrieval.started",
                    "activity.started",
                    "activity.completed",
                    "answer.completed",
                    "references.completed",
                    "future.event",
                    "response.completed",
                }));

            KnowledgeBaseRetrievalStartedEvent started = items[0].Data as KnowledgeBaseRetrievalStartedEvent;
            Assert.That(started, Is.Not.Null);
            Assert.That(started.RequestId, Is.EqualTo("request-id"));
            Assert.That(started.KnowledgeBaseName, Is.EqualTo("fake-knowledge-base"));
            Assert.That(started.OutputMode, Is.EqualTo(KnowledgeRetrievalOutputMode.AnswerSynthesis));
            Assert.That(items[0].EventId, Is.EqualTo("event-1"));
            Assert.That(items[0].ReconnectionInterval, Is.EqualTo(TimeSpan.FromMilliseconds(2500)));

            KnowledgeBaseActivityStartedEvent activityStarted = items[1].Data as KnowledgeBaseActivityStartedEvent;
            Assert.That(activityStarted, Is.Not.Null);
            Assert.That(activityStarted.Id, Is.EqualTo(1));
            Assert.That(activityStarted.Type, Is.EqualTo(KnowledgeBaseActivityRecordType.SearchIndex));
            Assert.That(activityStarted.KnowledgeSourceName, Is.EqualTo("products"));

            KnowledgeBaseSearchIndexActivityRecord activityCompleted = items[2].Data as KnowledgeBaseSearchIndexActivityRecord;
            Assert.That(activityCompleted, Is.Not.Null);
            Assert.That(activityCompleted.Id, Is.EqualTo(1));
            Assert.That(activityCompleted.ElapsedMs, Is.EqualTo(1000));
            Assert.That(activityCompleted.KnowledgeSourceName, Is.EqualTo("products"));
            Assert.That(activityCompleted.Count, Is.EqualTo(2));

            KnowledgeBaseAnswerCompletedEvent answerCompleted = items[3].Data as KnowledgeBaseAnswerCompletedEvent;
            Assert.That(answerCompleted, Is.Not.Null);
            Assert.That(answerCompleted.MessageIndex, Is.EqualTo(0));
            Assert.That(answerCompleted.Message.Role, Is.EqualTo("assistant"));
            Assert.That(answerCompleted.Message.Content, Has.Count.EqualTo(1));
            KnowledgeBaseMessageTextContent answerText = answerCompleted.Message.Content[0] as KnowledgeBaseMessageTextContent;
            Assert.That(answerText, Is.Not.Null);
            Assert.That(answerText.Text, Is.EqualTo("The answer."));

            KnowledgeBaseReferencesCompletedEvent referencesCompleted = items[4].Data as KnowledgeBaseReferencesCompletedEvent;
            Assert.That(referencesCompleted, Is.Not.Null);
            Assert.That(referencesCompleted.References, Has.Count.EqualTo(1));
            KnowledgeBaseSearchIndexReference reference = referencesCompleted.References[0] as KnowledgeBaseSearchIndexReference;
            Assert.That(reference, Is.Not.Null);
            Assert.That(reference.Id, Is.EqualTo("reference-1"));
            Assert.That(reference.ActivitySource, Is.EqualTo(1));
            Assert.That(reference.DocKey, Is.EqualTo("product-1"));
            Assert.That(reference.CitationUrl, Is.EqualTo(new Uri("https://example.com/products/1")));

            UnknownKnowledgeBaseRetrievalStreamEvent unknown = items[5].Data as UnknownKnowledgeBaseRetrievalStreamEvent;
            Assert.That(unknown, Is.Not.Null);
            Assert.That(unknown.Data.ToString(), Is.EqualTo("""{"value":true}"""));

            KnowledgeBaseResponseCompletedEvent completed = items[6].Data as KnowledgeBaseResponseCompletedEvent;
            Assert.That(completed, Is.Not.Null);
            Assert.That(completed.StatusCode, Is.EqualTo(KnowledgeBaseRetrievalStatusCode.OK));
            Assert.That(response.IsDisposed, Is.True);
            Assert.That(transport.Requests.Single().Headers.TryGetValue("Accept", out string accept), Is.True);
            Assert.That(accept, Is.EqualTo("text/event-stream"));
        }

        [Test]
        public async Task RetrieveStreamAsyncYieldsEventsAcrossServerPauses()
        {
            PausableSseStream contentStream = new();
            MockResponse response = new(200)
            {
                ContentStream = contentStream,
            };
            response.AddHeader("Content-Type", "text/event-stream");
            MockTransport transport = new(response);
            KnowledgeBaseRetrievalClient client = CreateClient(transport);

            await using IAsyncEnumerator<SseItem<KnowledgeBaseRetrievalStreamEvent>> enumerator =
                client.RetrieveStreamAsync(new KnowledgeBaseRetrievalRequest()).GetAsyncEnumerator();

            Task<bool> firstMove = enumerator.MoveNextAsync().AsTask();
            await contentStream.WaitForBlockedReadAsync();
            Assert.That(firstMove.IsCompleted, Is.False);

            contentStream.Append("""
                event: retrieval.started
                data: {"requestId":"request-id","knowledgeBaseName":"fake-knowledge-base","outputMode":"answerSynthesis","reasoningEffort":{"kind":"minimal"}}


                """);

            Assert.That(await firstMove, Is.True);
            Assert.That(enumerator.Current.EventType, Is.EqualTo("retrieval.started"));
            Assert.That(enumerator.Current.Data, Is.TypeOf<KnowledgeBaseRetrievalStartedEvent>());

            Task<bool> secondMove = enumerator.MoveNextAsync().AsTask();
            await contentStream.WaitForBlockedReadAsync();
            Assert.That(secondMove.IsCompleted, Is.False);

            contentStream.Append("""
                event: response.completed
                data: {"statusCode":200,"response":{}}


                """);

            Assert.That(await secondMove, Is.True);
            Assert.That(enumerator.Current.EventType, Is.EqualTo("response.completed"));
            Assert.That(enumerator.Current.Data, Is.TypeOf<KnowledgeBaseResponseCompletedEvent>());
            Assert.That(await enumerator.MoveNextAsync(), Is.False);
            Assert.That(response.IsDisposed, Is.True);
        }

        private static KnowledgeBaseRetrievalClient CreateClient(MockTransport transport)
        {
            SearchClientOptions options = new()
            {
                Transport = transport,
            };

            return new KnowledgeBaseRetrievalClient(
                new Uri("https://fake-search.search.windows.net"),
                "fake-knowledge-base",
                new AzureKeyCredential("fake-api-key"),
                options);
        }

        private sealed class PausableSseStream : Stream
        {
            private readonly Queue<byte[]> _chunks = new();
            private readonly SemaphoreSlim _dataAvailable = new(0);
            private TaskCompletionSource<object> _blockedRead = CreateCompletionSource();
            private byte[] _currentChunk;
            private int _currentOffset;

            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();

            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public void Append(string content)
            {
                lock (_chunks)
                {
                    _chunks.Enqueue(Encoding.UTF8.GetBytes(content));
                    _blockedRead = CreateCompletionSource();
                }

                _dataAvailable.Release();
            }

            public Task WaitForBlockedReadAsync()
            {
                lock (_chunks)
                {
                    return _blockedRead.Task;
                }
            }

            public override async Task<int> ReadAsync(
                byte[] buffer,
                int offset,
                int count,
                CancellationToken cancellationToken)
            {
                while (_currentChunk is null || _currentOffset == _currentChunk.Length)
                {
                    lock (_chunks)
                    {
                        if (_chunks.Count > 0)
                        {
                            _currentChunk = _chunks.Dequeue();
                            _currentOffset = 0;
                            break;
                        }

                        _blockedRead.TrySetResult(null);
                    }

                    await _dataAvailable.WaitAsync(cancellationToken).ConfigureAwait(false);
                }

                int bytesToCopy = Math.Min(count, _currentChunk.Length - _currentOffset);
                Buffer.BlockCopy(_currentChunk, _currentOffset, buffer, offset, bytesToCopy);
                _currentOffset += bytesToCopy;
                return bytesToCopy;
            }

            public override int Read(byte[] buffer, int offset, int count) =>
                throw new InvalidOperationException("This test stream only supports asynchronous reads.");

            public override void Flush()
            {
            }

            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

            private static TaskCompletionSource<object> CreateCompletionSource() =>
                new(TaskCreationOptions.RunContinuationsAsynchronously);
        }
    }
}
# endif
