// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample3_ConversationHistory.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample3Snippets
    {
        [Test]
        public void BuilderWithOptions()
        {
            #region Snippet:Responses_Sample3_BuilderConfig

var builder = AgentHost.CreateBuilder();
            builder.AddResponses<StudyTutorHandler>(options =>
            {
                options.DefaultFetchHistoryCount = 20;
            });
            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void Implement_StudyTutorHandler()
        {
            var handler = new StudyTutorHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample3_StudyTutorHandler

        public class StudyTutorHandler : IResponseHandler
        {
            public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                IResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Resolve conversation history from previous responses.
                // Returns empty list if no previous_response_id is set.
                var history = await context.GetHistoryAsync(cancellationToken);

                var currentInput = request.GetInputText();
                var turnNumber = history.OfType<OutputItemOutputMessage>().Count() + 1;

                // In a real agent, pass the history + current question to a model.
                string reply;
                if (history.Count == 0)
                {
                    reply = $"Welcome! I'm your study tutor. You asked: \"{currentInput}\". " +
                            "Let me help you understand that topic.";
                }
                else
                {
                    var lastMessage = history.OfType<OutputItemOutputMessage>().LastOrDefault();
                    var lastText = lastMessage?.Content
                        .OfType<OutputMessageContentOutputTextContent>()
                        .FirstOrDefault()?.Text ?? "(none)";

                    reply = $"[Turn {turnNumber}] Building on our previous discussion " +
                            $"(last answer: \"{lastText[..Math.Min(50, lastText.Length)]}...\"), " +
                            $"you asked: \"{currentInput}\".";
                }

                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();

                var text = message.AddTextContent();
                yield return text.EmitAdded();

                yield return text.EmitDelta(reply);
                yield return text.EmitDone(reply);

                yield return message.EmitContentDone(text);
                yield return message.EmitDone();

                yield return stream.EmitCompleted();
            }
        }

        #endregion
    }
}
