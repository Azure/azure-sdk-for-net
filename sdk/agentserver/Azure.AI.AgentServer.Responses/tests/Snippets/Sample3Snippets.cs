// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample3_FullControlResponseStream.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample3Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample3_StartServer

            ResponsesServer.Run<GreetingHandler>();

            #endregion
        }

        [Test]
        public void Implement_GreetingHandler()
        {
            var handler = new GreetingHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample3_GreetingHandler

        public class GreetingHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                var stream = new ResponseEventStream(context, request);

                // ── Configure Response properties BEFORE EmitCreated() ──
                // Any property set here will appear in the response.created event
                // and every subsequent event that carries the Response snapshot.
                stream.Response.Temperature = 0.7;
                stream.Response.MaxOutputTokens = 1024;

                // Emit the opening lifecycle events.
                yield return stream.EmitCreated();   // response.created
                yield return stream.EmitInProgress(); // response.in_progress

                // Add a message output item.
                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();    // response.output_item.added

                // Add text content to the message.
                var text = message.AddTextContent();
                yield return text.EmitAdded();       // response.content_part.added

                // Emit the text body — delta first, then the final "done" with full text.
                var input = request.GetInputText();
                var reply = $"Hello! You said: \"{input}\"";
                yield return text.EmitDelta(reply);  // response.output_text.delta
                yield return text.EmitDone(reply);   // response.output_text.done

                // Close the content, message, and response.
                yield return message.EmitContentDone(text);  // response.content_part.done
                yield return message.EmitDone();              // response.output_item.done
                yield return stream.EmitCompleted();          // response.completed
            }
        }

        #endregion
    }
}
