// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests
{
    public class ResponseStreamingResultTests
    {
        private const string RequestId = "request_streaming_customer";
        private const string StreamPayload = """
        event: response.output_item.added
        data: {"type":"response.output_item.added","sequence_number":1,"output_index":0,"item":{"type":"message","id":"msg_1","role":"assistant","status":"in_progress","content":[]}}

        event: response.completed
        data: {"type":"response.completed","sequence_number":2,"response":{"id":"resp_1","object":"response","created_at":0,"status":"completed","model":"mock","output":[],"tools":[]}}

        data: [DONE]


        """;

        [Test]
        [Ignore("Returning Raw pages is nor yet supported.")]
        public void SyncRawPagesContainHttpResponse()
        {
            using var handler = new StreamingHandler();
            using var http = new HttpClient(handler);
            var client = CreateClient(http);
            var pages = new List<ClientResult>();
            foreach (ClientResult page in client.CreateResponseStreaming(
                model: "mock", userInputText: "hello").GetRawPages())
            {
                pages.Add(page);
            }

            AssertRawResponse(pages, handler);
        }

        [Test]
        [Ignore("Returning Raw pages is nor yet supported.")]
        public async Task AsyncRawPagesContainHttpResponse()
        {
            using var handler = new StreamingHandler();
            using var http = new HttpClient(handler);
            var client = CreateClient(http);
            var pages = new List<ClientResult>();
            await foreach (ClientResult page in client.CreateResponseStreamingAsync(
                model: "mock", userInputText: "hello").GetRawPagesAsync())
            {
                pages.Add(page);
            }

            AssertRawResponse(pages, handler);
        }

        [Test]
        public void SyncTypedStreamingSendsOneRequest()
        {
            using var handler = new StreamingHandler();
            using var http = new HttpClient(handler);
            var client = CreateClient(http);
            int updates = 0;
            foreach (StreamingResponseUpdate update in client.CreateResponseStreaming(
                model: "mock", userInputText: "hello"))
            {
                Assert.That(update, Is.Not.Null);
                updates++;
            }

            AssertTypedResult(updates, handler.RequestCount);
        }

        [Test]
        public async Task AsyncTypedStreamingSendsOneRequest()
        {
            using var handler = new StreamingHandler();
            using var http = new HttpClient(handler);
            var client = CreateClient(http);
            int updates = 0;
            await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(
                model: "mock", userInputText: "hello"))
            {
                Assert.That(update, Is.Not.Null);
                updates++;
            }

            AssertTypedResult(updates, handler.RequestCount);
        }

        private static void AssertRawResponse(List<ClientResult> pages, StreamingHandler handler)
        {
            TestContext.WriteLine($"pages={pages.Count}; requests={handler.RequestCount}");
            Assert.That(pages, Has.Count.EqualTo(1));
            Assert.That(pages[0], Is.Not.Null,
                $"The raw-page API returned a null sentinel; requests={handler.RequestCount}.");
            using PipelineResponse response = pages[0].GetRawResponse();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(response.Headers.TryGetValue("x-request-id", out string requestId), Is.True);
            Assert.That(requestId, Is.EqualTo(RequestId));
            Assert.That(handler.RequestCount, Is.EqualTo(1));
            TestContext.WriteLine($"status={response.Status}; requestId={requestId}");
        }

        private static void AssertTypedResult(int updates, int requests)
        {
            TestContext.WriteLine($"updates={updates}; requests={requests}");
            Assert.That(updates, Is.EqualTo(2));
            Assert.That(requests, Is.EqualTo(1));
        }

        private static ProjectResponsesClient CreateClient(HttpClient http)
            => new(new Uri("https://example.test/api/projects/project"), new TestTokenProvider(),
                new ProjectResponsesClientOptions { Transport = new HttpClientPipelineTransport(http) });

        private sealed class TestTokenProvider : AuthenticationTokenProvider
        {
            public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
                => new(properties);

            public override AuthenticationToken GetToken(
                GetTokenOptions options, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AuthenticationToken("test-only-placeholder", "Bearer", DateTimeOffset.MaxValue);
            }

            public override ValueTask<AuthenticationToken> GetTokenAsync(
                GetTokenOptions options, CancellationToken cancellationToken)
            {
                return new(GetToken(options, cancellationToken));
            }
        }

        private class StreamingHandler : HttpMessageHandler
        {
            public int RequestCount { get; private set; }
#if NET6_0_OR_GREATER
            protected override HttpResponseMessage Send(
#else
            protected HttpResponseMessage Send(
#endif
            HttpRequestMessage request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                RequestCount++;
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(StreamPayload, Encoding.UTF8, "text/event-stream"),
                };
                response.Headers.Add("x-request-id", RequestId);
                return response;
            }

            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
                => Task.FromResult(Send(request, cancellationToken));
        }
    }
}
