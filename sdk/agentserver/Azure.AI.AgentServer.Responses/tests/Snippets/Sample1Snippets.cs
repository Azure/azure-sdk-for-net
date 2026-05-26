// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample1_GettingStarted.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample1Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample1_StartServer

            ResponsesServer.Run<EchoHandler>();

            #endregion
        }

        [Test]
        public void Implement_EchoHandler()
        {
            var handler = new EchoHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample1_EchoHandler

        public class EchoHandler : ResponseHandler
        {
            public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                CancellationToken cancellationToken)
            {
                return new TextResponse(context, request,
                    createText: async ct =>
                    {
                        var input = await context.GetInputTextAsync(cancellationToken: ct);
                        return $"Echo: {input}";
                    });
            }
        }

        #endregion
    }
}
