// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample2_StreamingTextDeltas.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample2Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample2_StartServer

            ResponsesServer.Run<StreamingHandler>();

            #endregion
        }

        [Test]
        public void Implement_StreamingHandler()
        {
            var handler = new StreamingHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample2_StreamingHandler

        public class StreamingHandler : ResponseHandler
        {
            public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                CancellationToken cancellationToken)
            {
                return new TextResponse(context, request,
                    configure: response =>
                    {
                        response.Temperature = 0.7;
                    },
                    createTextStream: GenerateTokensAsync);
            }

            private static async IAsyncEnumerable<string> GenerateTokensAsync(
                [EnumeratorCancellation] CancellationToken ct)
            {
                // Simulate an LLM producing tokens one at a time.
                // Replace this with your actual model call.
                var tokens = new[] { "Hello", ", ", "world", "!" };
                foreach (var token in tokens)
                {
                    await Task.Delay(100, ct);
                    yield return token;
                }
            }
        }

        #endregion
    }
}
