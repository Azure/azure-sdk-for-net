// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
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

            ResponsesServer.Run<QnAHandler>();

            #endregion
        }

        [Test]
        public void Implement_QnAHandler()
        {
            var handler = new QnAHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample1_QnAHandler

        public class QnAHandler : IResponseHandler
        {
            public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                IResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();

                var text = message.AddTextContent();
                yield return text.EmitAdded();

                // In a real agent, call your model or knowledge base here.
                var question = request.GetInputText();
                var answer = $"You asked: \"{question}\". " +
                             "This is where your agent logic produces an answer.";

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
