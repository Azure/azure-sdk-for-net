// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample6_MultiOutput.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample6Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample6_StartServer

            ResponsesServer.Run<MathSolverHandler>();

            #endregion
        }

        [Test]
        public void Implement_MathSolverHandler()
        {
            var handler = new MathSolverHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_MathSolverHandlerFullControl()
        {
            var handler = new MathSolverHandlerFullControl();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample6_MathSolverHandlerConvenience

        public class MathSolverHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                var stream = new ResponseEventStream(context, request);
                var question = request.GetInputText();

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Output item 0: Reasoning — show the thought process.
                var thought = $"The user asked: \"{question}\". " +
                              "I need to identify the mathematical operation, " +
                              "compute the result, and explain the steps.";
                foreach (var evt in stream.OutputItemReasoningItem(thought))
                    yield return evt;

                // Output item 1: Message — the final answer.
                var answer = "The answer is 42. Here's how: " +
                             "6 × 7 = 42. The multiplication of 6 and 7 gives 42.";
                foreach (var evt in stream.OutputItemMessage(answer))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion

        #region Snippet:Responses_Sample6_MathSolverHandler

        public class MathSolverHandlerFullControl : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                var stream = new ResponseEventStream(context, request);
                var question = request.GetInputText();

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Output item 0: Reasoning — show the thought process.
                var reasoning = stream.AddOutputItemReasoningItem();
                yield return reasoning.EmitAdded();

                var summary = reasoning.AddSummaryPart();
                yield return summary.EmitAdded();

                // In a real agent, this would be the model's chain-of-thought.
                var thought = $"The user asked: \"{question}\". " +
                              "I need to identify the mathematical operation, " +
                              "compute the result, and explain the steps.";
                yield return summary.EmitTextDelta(thought);
                yield return summary.EmitTextDone(thought);
                yield return summary.EmitDone();
                reasoning.EmitSummaryPartDone(summary);

                yield return reasoning.EmitDone();

                // Output item 1: Message — the final answer.
                var message = stream.AddOutputItemMessage();
                yield return message.EmitAdded();

                var text = message.AddTextContent();
                yield return text.EmitAdded();

                var answer = "The answer is 42. Here's how: " +
                             "6 × 7 = 42. The multiplication of 6 and 7 gives 42.";
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
