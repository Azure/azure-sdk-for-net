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
    /// Code snippets backing Sample11_NonStreamingOpenAIUpstream.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample11Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample11_StartServer
            ResponsesServer.Run<NonStreamingUpstreamHandler>(configure: builder =>
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
        public void Implement_NonStreamingUpstreamHandler()
        {
            var handler = new NonStreamingUpstreamHandler(new ResponsesClient("test-key"));
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample11_NonStreamingUpstreamHandler
        public class NonStreamingUpstreamHandler : ResponseHandler
        {
            private readonly ResponsesClient _upstream;

            public NonStreamingUpstreamHandler(ResponsesClient upstream) => _upstream = upstream;

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
                };

                // Input items are already OpenAI ResponseItem instances, so
                // they can be forwarded to the upstream as-is.
                foreach (ResponseItem item in await context.GetInputItemsAsync(cancellationToken: cancellationToken))
                {
                    options.InputItems.Add(item);
                }

                // Call upstream without streaming and get the complete response.
                var result = await _upstream.CreateResponseAsync(options, cancellationToken);

                // Build a standard SSE event stream, emitting every upstream
                // output item.
                var stream = new ResponseEventStream(context, request);
                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                foreach (ResponseItem upstreamItem in result.Value.OutputItems)
                {
                    var builder = stream.AddOutputItem<ResponseItem>(upstreamItem.Id);
                    yield return builder.EmitAdded(upstreamItem);
                    yield return builder.EmitDone(upstreamItem);
                }

                yield return stream.EmitCompleted();
            }
        }
        #endregion
    }
}
