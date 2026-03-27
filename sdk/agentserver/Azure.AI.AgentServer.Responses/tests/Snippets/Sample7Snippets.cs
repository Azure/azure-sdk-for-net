// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable OPENAI001 // Responses API is experimental in the OpenAI SDK

using System.ClientModel;
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
    public class Sample7Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample7_StartServer
            ResponsesServer.Run<NonStreamingProxyHandler>(configure: builder =>
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
        public void Implement_NonStreamingProxyHandler()
        {
            var handler = new NonStreamingProxyHandler(new ResponsesClient("test-key"));
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample7_NonStreamingProxyHandler
        public class NonStreamingProxyHandler : ResponseHandler
        {
            private readonly ResponsesClient _upstream;

            public NonStreamingProxyHandler(ResponsesClient upstream) => _upstream = upstream;

            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                // Call the upstream server without streaming.
                var options = new CreateResponseOptions()
                {
                    Model = request.Model,
                    Instructions = request.Instructions,
                };
                options.InputItems.Add(
                    ResponseItem.CreateUserMessageItem(request.GetInputText()));

                var result = await _upstream.CreateResponseAsync(options, cancellationToken);
                string answer = result.Value.GetOutputText();

                // Build a standard SSE event stream from the completed response.
                var stream = new ResponseEventStream(context, request);
                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();

                var text = message.AddTextContent();
                yield return text.EmitAdded();

                yield return text.EmitDelta(answer);
                yield return text.EmitDone(answer);

                yield return message.EmitContentDone(text);
                yield return message.EmitDone();
                yield return stream.EmitCompleted();
            }
        }
        #endregion
    }
}
