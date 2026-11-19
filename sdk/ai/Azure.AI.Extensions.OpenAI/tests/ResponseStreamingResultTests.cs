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

# pragma warning disable AAIP001
namespace Azure.AI.Extensions.OpenAI.Tests
{
    public class ResponseStreamingResultTests
    {
        private const string RequestId = "request_streaming_customer";

        private static string GetSteamContent(ResponseItemKind discriminator)
        {
            // AgentStructuredOutputsResponseItem models a required `output` payload that its serializer
            // writes back verbatim; include it so the round-trip write has valid content to emit.
            string extraFields = discriminator.ToString() switch
            {
                "oauth_consent_request" => ",\"consent_link\": \"http://www.microsoft.com\"",
                "structured_outputs" => ",\"output\": {\"foo\": \"bar\"}",
                _ => ""
            };

            string item =  $$"""
            {"type": "{{discriminator}}","id": "item_1","agent_reference": { "name": "theAgent", "version": "1.0" },"response_id": "resp_1","status": "completed"{{extraFields}}}
            """;

            return $$$"""
                event: response.output_item.added
                data: {"type":"response.output_item.added","sequence_number":1,"output_index":0,"item":{"type":"message","id":"msg_1","role":"assistant","status":"in_progress","content":[]}}
        
                event: response.completed
                data: {"type":"response.completed","sequence_number":2,"response":{"id":"resp_1","object":"response","created_at":0,"status":"completed","model":"mock","output":[{{{item}}}],"tools":[]}}

                data: [DONE]


                """;
        }
        private const string StreamPayload = """
        event: response.output_item.added
        data: {"type":"response.output_item.added","sequence_number":1,"output_index":0,"item":{"type":"message","id":"msg_1","role":"assistant","status":"in_progress","content":[]}}
        
        event: response.completed
        data: {"type":"response.completed","sequence_number":2,"response":{"id":"resp_1","object":"response","created_at":0,"status":"completed","model":"mock","output":[],"tools":[]}}

        data: [DONE]


        """;

        private static IEnumerable<TestCaseData> AttributionItemKinds()
        {
            yield return Case(ResponseItemKind.A2APreviewCall, typeof(A2AToolCall));
            yield return Case(ResponseItemKind.A2APreviewCallOutput, typeof(A2AToolCallOutput));
            yield return Case(ResponseItemKind.StructuredOutputs, typeof(AgentStructuredOutputsResponseItem));
            yield return Case(ResponseItemKind.WorkflowAction, typeof(AgentWorkflowPreviewActionResponseItem));
            yield return Case(ResponseItemKind.AzureAISearchCall, typeof(AzureAISearchToolCall));
            yield return Case(ResponseItemKind.AzureAISearchCallOutput, typeof(AzureAISearchToolCallOutput));
            yield return Case(ResponseItemKind.AzureFunctionCall, typeof(AzureFunctionToolCall));
            yield return Case(ResponseItemKind.AzureFunctionCallOutput, typeof(AzureFunctionToolCallOutput));
            yield return Case(ResponseItemKind.BingCustomSearchPreviewCall, typeof(BingCustomSearchToolCall));
            yield return Case(ResponseItemKind.BingCustomSearchPreviewCallOutput, typeof(BingCustomSearchToolCallOutput));
            yield return Case(ResponseItemKind.BingGroundingCall, typeof(BingGroundingToolCall));
            yield return Case(ResponseItemKind.BingGroundingCallOutput, typeof(BingGroundingToolCallOutput));
            yield return Case(ResponseItemKind.BrowserAutomationPreviewCall, typeof(BrowserAutomationToolCall));
            yield return Case(ResponseItemKind.BrowserAutomationPreviewCallOutput, typeof(BrowserAutomationToolCallOutput));
            yield return Case(ResponseItemKind.FabricDataAgentPreviewCall, typeof(FabricDataAgentToolCall));
            yield return Case(ResponseItemKind.FabricDataAgentPreviewCallOutput, typeof(FabricDataAgentToolCallOutput));
            yield return Case(ResponseItemKind.MemoryCommandPreviewCall, typeof(MemoryCommandToolCall));
            yield return Case(ResponseItemKind.MemoryCommandPreviewCallOutput, typeof(MemoryCommandToolCallOutput));
            yield return Case(ResponseItemKind.MemorySearchCall, typeof(MemorySearchToolCall));
            yield return Case(ResponseItemKind.OAuthConsentRequest, typeof(OAuthConsentRequestResponseItem));
            yield return Case(ResponseItemKind.OpenApiCall, typeof(OpenApiToolCall));
            yield return Case(ResponseItemKind.OpenApiCallOutput, typeof(OpenApiToolCallOutput));
            yield return Case(ResponseItemKind.SharepointGroundingPreviewCall, typeof(SharePointGroundingToolCall));
            yield return Case(ResponseItemKind.SharepointGroundingPreviewCallOutput, typeof(SharePointGroundingToolCallOutput));

            static TestCaseData Case(ResponseItemKind discriminator, Type expectedType)
                => new TestCaseData(discriminator, expectedType).SetName($"{{m}}({discriminator} => {expectedType.Name})");
        }

        [TestCaseSource(nameof(AttributionItemKinds))]
        public async Task AsyncTypedStreamingSendsOneRequest(ResponseItemKind discriminator, Type expectedType)
        {
            using var handler = new StreamingHandler(GetSteamContent(discriminator));
            using var http = new HttpClient(handler);
            var client = CreateClient(http);
            int updates = 0;
            await foreach (StreamingResponseUpdate update in await client.CreateResponseStreamingAsync(
                model: "mock", userInputText: "hello"))
            {
                if (update is StreamingResponseCompletedUpdate streamResponseCompletedUpdate)
                {
                    Assert.That(streamResponseCompletedUpdate.Response.OutputItems.Count, Is.EqualTo(1));
                    Assert.That(streamResponseCompletedUpdate.Response.OutputItems[0], Is.InstanceOf(expectedType));
                }
                Assert.That(update, Is.Not.Null);
                updates++;
            }

            AssertTypedResult(updates, handler.RequestCount);
        }

        [TestCaseSource(nameof(AttributionItemKinds))]
        public async Task AsyncTypedGetStreamingAsync(ResponseItemKind discriminator, Type expectedType)
        {
            using var handler = new StreamingHandler(GetSteamContent(discriminator));
            using var http = new HttpClient(handler);
            ProjectResponsesClient client = CreateClient(http);
            int updates = 0;
            await foreach (StreamingResponseUpdate update in await client.GetResponseStreamingAsync(new GetResponseOptions(responseId: "123")
            {
                StreamingEnabled = true
            }))
            {
                if (update is StreamingResponseCompletedUpdate streamResponseCompletedUpdate)
                {
                    Assert.That(streamResponseCompletedUpdate.Response.OutputItems.Count, Is.EqualTo(1));
                    Assert.That(streamResponseCompletedUpdate.Response.OutputItems[0], Is.InstanceOf(expectedType));
                }
                Assert.That(update, Is.Not.Null);
                updates++;
            }

            AssertTypedResult(updates, handler.RequestCount);
        }

        [Test]
        public async Task StreamingResultExposesRawResponse()
        {
            using var handler = new StreamingHandler(StreamPayload);
            using var http = new HttpClient(handler);
            var client = CreateClient(http);

            await using AsyncStreamingResult<StreamingResponseUpdate> result =
                await client.CreateResponseStreamingAsync(model: "mock", userInputText: "hello");

            Assert.That(result.Status, Is.EqualTo(200));
            Assert.That(result.Headers.TryGetValue("x-request-id", out string requestId), Is.True);
            Assert.That(requestId, Is.EqualTo(RequestId));
            Assert.That(handler.RequestCount, Is.EqualTo(1));
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
            private readonly string _payload;
            public StreamingHandler(string payload)
            {
                _payload = payload;
            }
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
                    Content = new StringContent(_payload, Encoding.UTF8, "text/event-stream"),
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
