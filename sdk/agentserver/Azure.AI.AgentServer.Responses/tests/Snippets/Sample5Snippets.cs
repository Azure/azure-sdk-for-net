// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample5_ConversationHistory.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample5Snippets
    {
        [Test]
        public void BuilderWithOptions()
        {
            #region Snippet:Responses_Sample5_BuilderConfig

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

        #region Snippet:Responses_Sample5_StudyTutorHandler

        public class StudyTutorHandler : ResponseHandler
        {
            public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                CancellationToken cancellationToken)
            {
                return new TextResponse(context, request,
                    createText: async ct =>
                    {
                        // Resolve conversation history from previous responses.
                        // Returns empty list if no previous_response_id is set.
                        var history = await context.GetHistoryAsync(ct);

                        var currentInput = await context.GetInputTextAsync(cancellationToken: ct);
                        var turnNumber = history.OfType<OutputItemMessage>().Count() + 1;

                        // In a real agent, pass the history + current question to a model.
                        if (history.Count == 0)
                        {
                            return $"Welcome! I'm your study tutor. You asked: \"{currentInput}\". " +
                                   "Let me help you understand that topic.";
                        }

                        var lastMessage = history.OfType<OutputItemMessage>().LastOrDefault();
                        var lastText = lastMessage?.Content
                            .OfType<MessageContentOutputTextContent>()
                            .FirstOrDefault()?.Text ?? "(none)";

                        return $"[Turn {turnNumber}] Building on our previous discussion " +
                               $"(last answer: \"{lastText[..Math.Min(50, lastText.Length)]}...\"), " +
                               $"you asked: \"{currentInput}\".";
                    });
            }
        }

        #endregion
    }
}
