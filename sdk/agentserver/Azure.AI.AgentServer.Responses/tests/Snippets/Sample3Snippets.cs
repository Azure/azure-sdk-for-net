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

        [Test]
        public void Implement_GreetingHandlerFullControl()
        {
            var handler = new GreetingHandlerFullControl();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_StreamingGreetingHandler()
        {
            var handler = new StreamingGreetingHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample3_GreetingHandlerConvenience

        public class GreetingHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                var stream = new ResponseEventStream(context, request);

                // Configure Response properties BEFORE EmitCreated().
                stream.Response.Temperature = 0.7;
                stream.Response.MaxOutputTokens = 1024;

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Emit a complete text message in one call.
                var input = request.GetInputText();
                foreach (var evt in stream.OutputItemMessage($"Hello! You said: \"{input}\""))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion

        #region Snippet:Responses_Sample3_StreamingGreetingHandler

        public class StreamingGreetingHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Stream tokens as they arrive — each chunk becomes a delta event.
                await foreach (var evt in stream.OutputItemMessage(
                    GenerateTokensAsync(request.GetInputText(), cancellationToken),
                    cancellationToken))
                {
                    yield return evt;
                }

                yield return stream.EmitCompleted();
            }

            private static async IAsyncEnumerable<string> GenerateTokensAsync(
                string input,
                [EnumeratorCancellation] CancellationToken ct)
            {
                // Replace with your actual LLM call.
                var tokens = new[] { "Hello! ", "You ", "said: ", $"\"{input}\"" };
                foreach (var token in tokens)
                {
                    await Task.Delay(100, ct);
                    yield return token;
                }
            }
        }

        #endregion

        #region Snippet:Responses_Sample3_GreetingHandler

        public class GreetingHandlerFullControl : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                var stream = new ResponseEventStream(context, request);

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
