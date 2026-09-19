// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using BasicTypeSpec;
using NUnit.Framework;

#pragma warning disable SCME0005 // Streaming APIs are experimental.

namespace TestProjects.Local.Tests
{
    public class StreamingCancellationTests
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(10);
        private const string ItemJson = "{\"message\":\"first\"}";

        [Test]
        public async Task ProtocolObservesCancellationAfterResponse(
            [Values(false, true)] bool sse,
            [Values(false, true)] bool operationCancellation,
            [Values(false, true)] bool beforeEnumeration)
        {
            using var operation = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            using var stream = new BlockingStream(EncodeItem(sse));
            using var httpClient = new HttpClient(new StreamingHandler(stream, sse));
            var client = CreateClient(httpClient);
            var context = new RequestContext { CancellationToken = operation.Token };
            var cancellationSource = operationCancellation ? operation : enumeration;

            if (sse)
            {
                var result = await client.ReceiveSseAsync(context);
                await VerifyCancellation(result, stream, cancellationSource, enumeration.Token, beforeEnumeration);
            }
            else
            {
                var result = await client.ReceiveJsonLinesAsync(context);
                await VerifyCancellation(result, stream, cancellationSource, enumeration.Token, beforeEnumeration);
            }
        }

        [Test]
        public async Task ConveniencePreservesOperationCancellation(
            [Values(false, true)] bool sse,
            [Values(false, true)] bool beforeEnumeration)
        {
            using var operation = new CancellationTokenSource();
            using var stream = new BlockingStream(EncodeItem(sse));
            using var httpClient = new HttpClient(new StreamingHandler(stream, sse));
            var client = CreateClient(httpClient);

            if (sse)
            {
                var result = await client.ReceiveSseAsync(operation.Token);
                await VerifyCancellation(result, stream, operation, default, beforeEnumeration);
            }
            else
            {
                var result = await client.ReceiveJsonLinesAsync(operation.Token);
                await VerifyCancellation(result, stream, operation, default, beforeEnumeration);
            }
        }

        [Test]
        public async Task ProtocolStreamsWithoutCancellation(
            [Values(false, true)] bool sse,
            [Values(false, true)] bool nullContext)
        {
            var payload = EncodeItem(sse) + (sse ? "data: [DONE]\n\n" : "");
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(payload));
            using var httpClient = new HttpClient(new StreamingHandler(stream, sse));
            var client = CreateClient(httpClient);
            RequestContext context = nullContext ? null! : new RequestContext();
            var items = new List<string>();

            if (sse)
            {
                await using var result = await client.ReceiveSseAsync(context);
                await foreach (var item in result)
                {
                    Assert.AreEqual("item", item.EventType);
                    items.Add(item.Data.ToString());
                }
            }
            else
            {
                await using var result = await client.ReceiveJsonLinesAsync(context);
                await foreach (var item in result)
                {
                    items.Add(item.ToString());
                }
            }

            CollectionAssert.AreEqual(new[] { ItemJson }, items);
        }

        private static async Task VerifyCancellation<T>(
            AsyncStreamingResult<T> result,
            BlockingStream stream,
            CancellationTokenSource cancellationSource,
            CancellationToken enumerationToken,
            bool beforeEnumeration)
        {
            await using var ownedResult = result;
            Assert.AreEqual(200, result.Status);
            if (beforeEnumeration)
            {
                cancellationSource.Cancel();
            }
            await using var enumerator = ((IAsyncEnumerable<T>)result).GetAsyncEnumerator(enumerationToken);
            try
            {
                if (!beforeEnumeration)
                {
                    Assert.IsTrue(await enumerator.MoveNextAsync());
                }

                Task<bool> moveNext = enumerator.MoveNextAsync().AsTask();
                if (!beforeEnumeration)
                {
                    await stream.ReadStarted.Task.WaitAsync(TestTimeout);
                    cancellationSource.Cancel();
                }

                Assert.That(
                    async () => await moveNext.WaitAsync(TestTimeout),
                    Throws.InstanceOf<OperationCanceledException>());
            }
            finally
            {
                // Unblock a pending read even when cancellation forwarding regresses.
                await result.DisposeAsync();
            }
        }

        private static string EncodeItem(bool sse)
            => sse ? $"event: item\ndata: {ItemJson}\n\n" : $"{ItemJson}\n";

        private static BasicTypeSpecClient CreateClient(HttpClient httpClient)
            => new(new Uri("https://example.test"), new AzureKeyCredential("test-key"), new BasicTypeSpecClientOptions
            {
                Transport = new HttpClientTransport(httpClient)
            });

        private sealed class StreamingHandler(Stream stream, bool sse) : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var content = new StreamContent(stream);
                content.Headers.ContentType = new MediaTypeHeaderValue(sse ? "text/event-stream" : "application/jsonl");
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = content });
            }
        }

        private sealed class BlockingStream(string firstItem) : MemoryStream(Encoding.UTF8.GetBytes(firstItem))
        {
            public TaskCompletionSource ReadStarted { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

            public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
            {
                if (Position < Length)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return base.Read(buffer.Span);
                }

                ReadStarted.TrySetResult();
                await Task.Delay(Timeout.Infinite, cancellationToken);
                return 0;
            }

            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
                => ReadAsync(buffer.AsMemory(offset, count), cancellationToken).AsTask();
        }
    }
}

#pragma warning restore SCME0005
