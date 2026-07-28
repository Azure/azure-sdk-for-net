// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample — Resilient Multi-turn Steerable Agent.
    /// Demonstrates named-namespace metadata (session history + turn_count),
    /// "done" termination that clears session state, EntryMode.Recovered handling,
    /// and cooperative steering via PendingInputCount / OCE interception.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class SampleResilientMultiturnSnippets
    {
        [Test]
        public void Implement_Handler()
        {
            var handler = new ResilientMultiturnHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:ResilientMultiturn_ProducerTask

        /// <summary>
        /// The durable, steerable conversation task — one execution per turn.
        /// Uses TWO metadata namespaces:
        /// <list type="bullet">
        ///   <item><c>ctx.Metadata</c> (default) — per-invocation state (status, output).</item>
        ///   <item><c>ctx.Metadata.Namespace("session")</c> — session-level state that persists
        ///         across many invocations: conversation <c>history</c> and <c>turn_count</c>.</item>
        /// </list>
        /// On <c>EntryMode.Recovered</c>, the handler reads persisted session history from the
        /// named namespace and seamlessly continues. A message of "done" terminates and clears
        /// session history for future reuse.
        /// </summary>
        /// <remarks>
        /// The reply is produced by a <paramref name="respond"/> delegate so the same
        /// durable, steerable chain works with any backend: pass a real model in
        /// production, or a deterministic stub in tests. The delegate receives the full
        /// conversation history (as a JSON array) and the current user message.
        /// </remarks>
        public static async Task<ConversationOutput> RunConversationTurnAsync(
            TaskContext<ConversationInput> ctx,
            Func<List<ConversationMessage>, string, CancellationToken, Task<string>> respond,
            CancellationToken ct)
        {
            // Session-level state lives in a named namespace — logically separate from
            // per-invocation ephemeral state. Both survive crashes.
            TaskMetadata session = ctx.Metadata.Namespace("session");

            List<ConversationMessage> history;
            if (session.TryGetValue("history", out var histRaw) && histRaw is not null)
            {
                history = histRaw.ToObjectFromJson<List<ConversationMessage>>()
                    ?? new List<ConversationMessage>();
            }
            else
            {
                history = new List<ConversationMessage>();
            }

            int turnCount = 0;
            if (session.TryGetValue("turn_count", out var tcRaw) && tcRaw is not null)
            {
                turnCount = tcRaw.ToObjectFromJson<int>();
            }

            // Mark default namespace as running
            ctx.Metadata["status"] = BinaryData.FromObjectAsJson("running");
            await ctx.Metadata.FlushAsync(ct);

            if (ctx.EntryMode == EntryMode.Recovered)
            {
                // On crash recovery, session history was already flushed by a prior lifetime.
                // We simply continue from where we left off.
            }

            string message = ctx.Input.Message;

            // Handle explicit session end — "done" clears session history for reuse.
            if (string.Equals(message.Trim(), "done", StringComparison.OrdinalIgnoreCase))
            {
                string summary = $"Session complete after {turnCount} turns. " +
                    $"Total messages exchanged: {history.Count}.";
                session["history"] = BinaryData.FromObjectAsJson(new List<ConversationMessage>());
                session["turn_count"] = BinaryData.FromObjectAsJson(0);
                await session.FlushAsync(ct);

                var doneResult = new ConversationOutput(turnCount, summary, Finished: true);
                ctx.Metadata["status"] = BinaryData.FromObjectAsJson("completed");
                ctx.Metadata["output"] = BinaryData.FromObjectAsJson(doneResult);
                await ctx.Metadata.FlushAsync(ct);
                return doneResult;
            }

            // Process this turn
            history.Add(new ConversationMessage("user", message));
            turnCount++;

            // Simulate incremental work that a steering input can interrupt. A steering nudge
            // signals ctx.Cancellation (cooperatively) and bumps ctx.PendingInputCount, so any
            // ct-aware await throws OperationCanceledException.
            for (int step = 0; step < 10; step++)
            {
                if (ctx.PendingInputCount > 0)
                {
                    // A newer message is waiting — wrap up early so the next turn runs.
                    string partial = $"Turn {turnCount} (interrupted): \"{message}\"";
                    history.Add(new ConversationMessage("assistant", partial));
                    session["history"] = BinaryData.FromObjectAsJson(history);
                    session["turn_count"] = BinaryData.FromObjectAsJson(turnCount);
                    await session.FlushAsync(ct);
                    return new ConversationOutput(turnCount, partial);
                }

                try
                {
                    await Task.Delay(10, ct);
                }
                catch (OperationCanceledException) when (IsBareSteeringNudge(ctx))
                {
                    string partial = $"Turn {turnCount} (interrupted): \"{message}\"";
                    history.Add(new ConversationMessage("assistant", partial));
                    session["history"] = BinaryData.FromObjectAsJson(history);
                    session["turn_count"] = BinaryData.FromObjectAsJson(turnCount);
                    await session.FlushAsync(ct);
                    return new ConversationOutput(turnCount, partial);
                }
            }

            // Generate the reply (model call behind the injected delegate)
            string reply = await respond(history, message, ct);
            history.Add(new ConversationMessage("assistant", reply));

            // Checkpoint session state — survives crash.
            session["history"] = BinaryData.FromObjectAsJson(history);
            session["turn_count"] = BinaryData.FromObjectAsJson(turnCount);
            await session.FlushAsync(ct);

            // Persist invocation result BEFORE suspending.
            var output = new ConversationOutput(turnCount, reply);
            ctx.Metadata["status"] = BinaryData.FromObjectAsJson("completed");
            ctx.Metadata["output"] = BinaryData.FromObjectAsJson(output);
            await ctx.Metadata.FlushAsync(ct);

            return output;
        }

        // A bare steering nudge cancels ctx.Cancellation with no cancel cause: a newer input is
        // queued but the caller did not cancel, no timeout fired, and shutdown is not in progress.
        private static bool IsBareSteeringNudge(TaskContext<ConversationInput> ctx)
            => ctx.PendingInputCount > 0
               && !ctx.CancelRequested
               && !ctx.TimeoutExceeded
               && !ctx.Shutdown.IsCancellationRequested;

        #endregion

        #region Snippet:ResilientMultiturn_Handler

        /// <summary>
        /// A conversational multi-turn steerable agent that uses a durable task chain.
        /// Each HTTP invocation maps to one turn of the chain; the TaskId (derived from
        /// the session id) ties turns together across calls. Steering allows a new
        /// message to interrupt the current turn.
        /// </summary>
        public class ResilientMultiturnHandler : InvocationHandler
        {
            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var input = await request.ReadFromJsonAsync<ConversationInput>(cancellationToken)
                    ?? new ConversationInput("hello");

                var invoker = request.HttpContext.RequestServices
                    .GetRequiredService<ITaskInvoker>();

                // Use the session id as the durable TaskId for multi-turn convergence.
                string taskId = context.SessionId;

                // StartAsync with the same TaskId reuses the chain (new turn). While a
                // turn is running, this input is queued as steering (run.IsQueued == true).
                var run = await invoker.StartAsync<ConversationInput, ConversationOutput>(
                    "conversation", input,
                    new RunOptions { TaskId = taskId },
                    cancellationToken);

                ConversationOutput result = await run.GetResultAsync(cancellationToken);

                await response.WriteAsJsonAsync(new
                {
                    invocation_id = context.InvocationId,
                    session_id = context.SessionId,
                    task_id = run.TaskId,
                    turn = result.Turn,
                    reply = result.Reply,
                    finished = result.Finished,
                    is_queued = run.IsQueued
                }, cancellationToken);
            }
        }

        /// <summary>Input for the conversation task.</summary>
        public record ConversationInput(string Message);

        /// <summary>Output for a single conversation turn.</summary>
        public record ConversationOutput(int Turn, string Reply, bool Finished = false);

        /// <summary>A single message in conversation history.</summary>
        public record ConversationMessage(string Role, string Content);

        #endregion

        #region Snippet:ResilientMultiturn_DeleteChain

        /// <summary>
        /// Demonstrates ending a multi-turn chain with DeleteAsync.
        /// </summary>
        public static async Task EndConversation(IMultiTurnTask multiTurn, string taskId)
        {
            // End the multi-turn chain — cancels any in-flight turn and cleans up.
            await multiTurn.DeleteAsync(taskId);
        }

        #endregion
    }
}
