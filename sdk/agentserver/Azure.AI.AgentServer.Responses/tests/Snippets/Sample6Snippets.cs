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
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample6Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample6_StartServer
            ResponsesServer.Run<StreamingProxyHandler>(configure: builder =>
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
        public void Implement_StreamingProxyHandler()
        {
            var handler = new StreamingProxyHandler(new ResponsesClient("test-key"));
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample6_StreamingProxyHandler
        public class StreamingProxyHandler : ResponseHandler
        {
            private readonly ResponsesClient _upstream;

            public StreamingProxyHandler(ResponsesClient upstream) => _upstream = upstream;

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
                };

                // Translate every input item with full fidelity. Both model
                // stacks share the same JSON wire contract, so
                // .Translate().To<T>() round-trips through JSON to convert:
                //   our Item → JSON → OpenAI ResponseItem.
                foreach (Item item in request.GetInputExpanded())
                {
                    options.InputItems.Add(item.Translate().To<ResponseItem>());
                }

                // Stream from the upstream server. Each event is translated back
                // using the same pattern in reverse.
                await foreach (StreamingResponseUpdate update in
                    _upstream.CreateResponseStreamingAsync(options, cancellationToken))
                {
                    yield return update.Translate().To<ResponseStreamEvent>();
                }
            }
        }
        #endregion
    }
}
