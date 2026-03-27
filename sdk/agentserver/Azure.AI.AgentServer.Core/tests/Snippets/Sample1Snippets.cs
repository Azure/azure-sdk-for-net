// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Core Sample1_GettingStarted.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample1Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Hosting_Sample1_StartServer

            ResponsesServer.Run<QnAHandler>();

            #endregion
        }

        [Test]
        public void Implement_QnAHandler()
        {
            var handler = new QnAHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Hosting_Sample1_QnAHandler

        public class QnAHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();

                var text = message.AddTextContent();
                yield return text.EmitAdded();

                // In a real agent, call your model or knowledge base here.
                var answer = "The Azure AI Foundry is a platform for building, " +
                             "deploying, and managing AI agents.";

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
