// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Invocations Sample4_MultiTurn.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample4Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Invocations_Sample4_StartServer

AgentHost.Run<TravelPlannerHandler>();

            #endregion
        }

        [Test]
        public void Implement_TravelPlannerHandler()
        {
            var handler = new TravelPlannerHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_Sample4_TravelPlannerHandler

        public class TravelPlannerHandler : InvocationHandler
        {
            private readonly List<string> _history = new();

            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var input = await request.ReadFromJsonAsync<TravelInput>(cancellationToken);
                var message = input?.Message ?? "";

                _history.Add($"User: {message}");

                // Build a reply based on conversation state.
                string reply;
                if (_history.Count == 1)
                {
                    reply = $"Great, let's plan a trip! You said: \"{message}\". " +
                            "Where would you like to go, and for how many days?";
                }
                else
                {
                    var turn = _history.Count / 2 + 1;
                    reply = $"Got it — turn {turn}. " +
                            $"So far we've discussed {_history.Count / 2} topic(s). " +
                            $"You said: \"{message}\". What else would you like to add?";
                }

                _history.Add($"Agent: {reply}");

                await response.WriteAsJsonAsync(new
                {
                    invocation_id = context.InvocationId,
                    session_id = context.SessionId,
                    turn = _history.Count / 2,
                    reply
                }, cancellationToken);
            }
        }

        public record TravelInput(string Message);

        #endregion
    }
}
