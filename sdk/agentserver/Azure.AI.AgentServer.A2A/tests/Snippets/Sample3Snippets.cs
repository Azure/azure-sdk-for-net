// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample3Snippets
{
    #region Snippet:A2A_Sample3_Handler
    public class ClarificationAgent : IAgentHandler
    {
        public async Task ExecuteAsync(
            global::A2A.RequestContext context,
            AgentEventQueue eventQueue,
            CancellationToken cancellationToken)
        {
            var task = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
            if (context.Task is null)
            {
                await task.SubmitAsync(cancellationToken: cancellationToken);
                await task.RequireInputAsync(new Message
                {
                    MessageId = Guid.NewGuid().ToString("N"),
                    Role = Role.Agent,
                    Parts = [Part.FromText("Who should I greet?")],
                }, cancellationToken: cancellationToken);
                return;
            }

            if (string.IsNullOrWhiteSpace(context.UserText))
            {
                throw new A2AException("Provide a name as text.", A2AErrorCode.InvalidParams);
            }

            await task.StartWorkAsync(cancellationToken: cancellationToken);
            await task.AddArtifactAsync(
                [Part.FromText($"Hello, {context.UserText}!")],
                cancellationToken: cancellationToken);
            await task.CompleteAsync(cancellationToken: cancellationToken);
        }
    }
    #endregion

    [Test]
    [Explicit("Starts a server; the handler is exercised by SampleEndToEndTests.")]
    public void StartServer()
    {
        #region Snippet:A2A_Sample3_Start
        A2AAgentServer.Run<ClarificationAgent>(CreateCard());
        #endregion
    }
}
