// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable OPENAI001 // Responses API is experimental in the OpenAI SDK

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample10_StreamingOpenAIUpstream.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample10Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample10_StartServer
            ResponsesServer.Run<StreamingUpstreamHandler>(configure: builder =>
            {
                builder.Services.AddSingleton(new ResponsesClient(
                    new ApiKeyCredential(
                        Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "your-api-key"),
                    new ResponsesClientOptions
                    {
                        Endpoint = new Uri(
                            Environment.GetEnvironmentVariable("UPSTREAM_ENDPOINT")
                                ?? "https://api.openai.com/v1")
                    }));
            });
            #endregion
        }

        [Test]
        public void Implement_StreamingUpstreamHandler()
        {
            var handler = new StreamingUpstreamHandler(new ResponsesClient("test-key"));
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample10_StreamingUpstreamHandler
        public class StreamingUpstreamHandler : ResponseHandler
        {
            private readonly ResponsesClient _upstream;

            public StreamingUpstreamHandler(ResponsesClient upstream) => _upstream = upstream;

            public override async IAsyncEnumerable<StreamingResponseUpdate> CreateAsync(
                CreateResponseOptions request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                // Build the upstream request using the OpenAI .NET SDK.
                var options = new CreateResponseOptions()
                {
                    Model = request.Model,
                    Instructions = request.Instructions,
                    StreamingEnabled = true,
                };

                // Input items are already OpenAI ResponseItem instances, so
                // they can be forwarded to the upstream as-is.
                foreach (ResponseItem item in await context.GetInputItemsAsync(cancellationToken: cancellationToken))
                {
                    options.InputItems.Add(item);
                }

                // This handler owns the response lifecycle — construct
                // lifecycle events directly instead of forwarding the
                // upstream's. This gives full control over the response
                // envelope (ID, metadata, status) while the upstream only
                // contributes content.
                int seq = 0;
                var conversationId = request.GetConversationId();
                var response = new ResponseResult { Id = context.ResponseId, Model = request.Model ?? "", Status = ResponseStatus.InProgress, AgentReference = request.AgentReference, BackgroundModeEnabled = request.BackgroundModeEnabled, ConversationOptions = conversationId != null ? new ResponseConversationOptions(conversationId) : null, PreviousResponseId = request.PreviousResponseId };
                yield return new StreamingResponseCreatedUpdate { SequenceNumber = (int)(seq++), Response = response };
                yield return new StreamingResponseInProgressUpdate { SequenceNumber = (int)(seq++), Response = response };

                // Stream from the upstream. Forward content events (output
                // items, deltas, etc.) directly. Skip upstream
                // lifecycle events — we own the response envelope.
                // Track completed output items for the terminal event.
                var outputItems = new List<ResponseItem>();
                bool upstreamFailed = false;

                await foreach (StreamingResponseUpdate update in
                    _upstream.CreateResponseStreamingAsync(options, cancellationToken))
                {
                    // Skip lifecycle events — we own the response envelope.
                    if (update is StreamingResponseCreatedUpdate
                        or StreamingResponseInProgressUpdate)
                    {
                        continue;
                    }

                    if (update is StreamingResponseCompletedUpdate)
                    {
                        break;
                    }

                    if (update is StreamingResponseFailedUpdate)
                    {
                        upstreamFailed = true;
                        break;
                    }

                    // Clear upstream response_id on output items so the
                    // orchestrator's auto-stamp fills in this server's ID.
                    if (update is StreamingResponseOutputItemAddedUpdate added)
                        added.Item.ResponseId = null;
                    else if (update is StreamingResponseOutputItemDoneUpdate done)
                    {
                        done.Item.ResponseId = null;
                        outputItems.Add(done.Item);
                    }

                    yield return update;
                }

                // Emit terminal event — the handler decides the outcome.
                if (upstreamFailed)
                {
                    response.Status = ResponseStatus.Failed;
                    response.Error = OpenAIModelFactory.CreateError(ResponseErrorCode.ServerError.ToString(), "Upstream request failed");
                    yield return new StreamingResponseFailedUpdate { SequenceNumber = (int)(seq++), Response = response };
                }
                else
                {
                    response.Status = ResponseStatus.Completed;
                    foreach (var item in outputItems)
                        response.OutputItems.Add(item);
                    yield return new StreamingResponseCompletedUpdate { SequenceNumber = (int)(seq++), Response = response };
                }
            }
        }
        #endregion
    }
}
