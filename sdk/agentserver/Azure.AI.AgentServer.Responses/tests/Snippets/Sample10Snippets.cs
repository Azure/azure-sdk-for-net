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
                    new OpenAIClientOptions
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

            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
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

                // Translate every input item. Both model stacks share the
                // same JSON wire contract, so .Translate().To<T>() round-trips
                // through JSON: our Item → JSON → OpenAI ResponseItem.
                foreach (Item item in await context.GetInputItemsAsync(cancellationToken: cancellationToken))
                {
                    options.InputItems.Add(item.Translate().To<ResponseItem>());
                }

                // This handler owns the response lifecycle — construct
                // lifecycle events directly instead of forwarding the
                // upstream's. This gives full control over the response
                // envelope (ID, metadata, status) while the upstream only
                // contributes content.
                int seq = 0;
                var conversationId = request.GetConversationId();
                var response = new ResponseObject(context.ResponseId, request.Model ?? "")
                {
                    Status = Models.ResponseStatus.InProgress,
                    Metadata = request.Metadata!,
                    AgentReference = request.AgentReference,
                    Background = request.Background,
                    Conversation = conversationId != null
                        ? new ConversationReference(conversationId) : null,
                    PreviousResponseId = request.PreviousResponseId,
                };
                yield return new ResponseCreatedEvent(seq++, response);
                yield return new ResponseInProgressEvent(seq++, response);

                // Stream from the upstream. Translate content events (output
                // items, deltas, etc.) and yield them directly. Skip upstream
                // lifecycle events — we own the response envelope.
                // Track completed output items for the terminal event.
                var outputItems = new List<OutputItem>();
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

                    // Translate content events via JSON round-trip.
                    ResponseStreamEvent evt = update.Translate().To<ResponseStreamEvent>();

                    // Clear upstream response_id on output items so the
                    // orchestrator's auto-stamp fills in this server's ID.
                    if (evt is ResponseOutputItemAddedEvent added)
                        added.Item.ResponseId = null;
                    else if (evt is ResponseOutputItemDoneEvent done)
                    {
                        done.Item.ResponseId = null;
                        outputItems.Add(done.Item);
                    }

                    yield return evt;
                }

                // Emit terminal event — the handler decides the outcome.
                if (upstreamFailed)
                {
                    response.Status = Models.ResponseStatus.Failed;
                    response.Error = new ResponseErrorInfo(
                        Models.ResponseErrorCode.ServerError, "Upstream request failed");
                    yield return new ResponseFailedEvent(seq++, response);
                }
                else
                {
                    response.Status = Models.ResponseStatus.Completed;
                    foreach (var item in outputItems)
                        response.Output.Add(item);
                    yield return new ResponseCompletedEvent(seq++, response);
                }
            }
        }
        #endregion
    }
}
