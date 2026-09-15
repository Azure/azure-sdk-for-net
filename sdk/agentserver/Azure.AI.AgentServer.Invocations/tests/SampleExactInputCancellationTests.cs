// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Reflection;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Invocations.Tests.Snippets;
using NUnit.Framework;
using ResearchRequest = Azure.AI.AgentServer.Invocations.Tests.Snippets.SampleResilientResearchSnippets.ResearchRequest;
using ResearchResult = Azure.AI.AgentServer.Invocations.Tests.Snippets.SampleResilientResearchSnippets.ResearchResult;

namespace Azure.AI.AgentServer.Invocations.Tests;

public partial class SampleEndToEndTests
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task ResilientResearch_CancelCapturedQueuedHandle_NeverCancelsSuccessor(bool completeBeforeRequest)
    {
        var firstStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var secondStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var successorStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseFirst = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseSecond = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseSuccessor = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskContext<ResearchRequest>? secondContext = null;
        TaskContext<ResearchRequest>? successorContext = null;
        TimeSpan timeout = TimeSpan.FromSeconds(10);

        await using var env = await CreateControlledResilientResearchServerAsync(
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(new SseItem<string>("started", "token") { EventId = "1" });
                switch (context.Input.Topic)
                {
                    case "first":
                        firstStarted.TrySetResult();
                        await releaseFirst.Task.WaitAsync(timeout);
                        break;
                    case "second":
                        secondContext = context;
                        secondStarted.TrySetResult();
                        await releaseSecond.Task.WaitAsync(timeout);
                        break;
                    case "successor":
                        successorContext = context;
                        successorStarted.TrySetResult();
                        await releaseSuccessor.Task.WaitAsync(timeout);
                        break;
                    default:
                        throw new AssertionException("Unexpected research input.");
                }

                await context.Stream.EmitAsync(new SseItem<string>("completed", "done") { EventId = "2" });
                return new ResearchResult("completed", Array.Empty<string>());
            });

        string session = "captured-cancel-" + Guid.NewGuid().ToString("N");
        string firstId = session + "-a";
        string secondId = session + "-b";
        string successorId = session + "-c";
        if (typeof(SampleResilientResearchSnippets.ResilientResearchHandler)
            .GetField("s_queuedRunsByInvocation", BindingFlags.Static | BindingFlags.NonPublic)
            ?.GetValue(null) is not ConcurrentDictionary<string, TaskRun<ResearchResult>> queuedRuns)
        {
            throw new AssertionException("The sample's retained queued-run lookup was not found.");
        }

        CapturedResearchCancellation? captured = null;
        Task<HttpResponseMessage>? pendingCancel = null;
        TaskRun<ResearchResult>? second = null;
        TaskRun<ResearchResult>? successor = null;
        try
        {
            using HttpResponseMessage firstPost = await PostResearchAsync(env.Client, session, firstId, "first");
            Assert.That(firstPost.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            await firstStarted.Task.WaitAsync(timeout);
            using HttpResponseMessage secondPost = await PostResearchAsync(env.Client, session, secondId, "second");
            using HttpResponseMessage successorPost = await PostResearchAsync(env.Client, session, successorId, "successor");
            Assert.That(secondPost.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            Assert.That(successorPost.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            if (!queuedRuns.TryGetValue(secondId, out second) || !queuedRuns.TryGetValue(successorId, out successor))
            {
                throw new AssertionException("Both inputs must be retained as real queued Core handles.");
            }

            // Pause the actual HTTP handler after lookup but before forwarding to the real
            // Core handle. This reproduces a captured lookup surviving completion/cleanup.
            captured = new CapturedResearchCancellation(second);
            queuedRuns[secondId] = captured;
            releaseFirst.TrySetResult();
            await secondStarted.Task.WaitAsync(timeout);
            pendingCancel = env.Client.PostAsync(
                $"/invocations/{secondId}/cancel?agent_session_id={session}", content: null);
            await captured.Entered.Task.WaitAsync(timeout);

            if (completeBeforeRequest)
            {
                releaseSecond.TrySetResult();
                await second.Completion.WaitAsync(timeout);
                await successorStarted.Task.WaitAsync(timeout);
            }

            captured.Release.TrySetResult();
            using HttpResponseMessage cancelled = await pendingCancel.WaitAsync(timeout);
            Assert.That(cancelled.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            if (!completeBeforeRequest)
            {
                Assert.That(secondContext!.CancelRequested, Is.True);
                Assert.That(secondContext.Cancellation.IsCancellationRequested, Is.True);
                releaseSecond.TrySetResult();
                await second.Completion.WaitAsync(timeout);
                await successorStarted.Task.WaitAsync(timeout);
            }

            Assert.That(successorContext!.CancelRequested, Is.False);
            Assert.That(successorContext.Cancellation.IsCancellationRequested, Is.False);
            string replay = await ReadResilientResearchStreamAsync(env.Client, secondId).WaitAsync(timeout);
            Assert.That(ParseSseEvents(replay), Has.Count.EqualTo(2));
            Assert.That(replay, Does.Contain("event: done"));

            releaseSuccessor.TrySetResult();
            Assert.That((await successor.Completion.WaitAsync(timeout)).Status, Is.EqualTo("completed"));
        }
        finally
        {
            captured?.Release.TrySetResult();
            releaseFirst.TrySetResult();
            releaseSecond.TrySetResult();
            releaseSuccessor.TrySetResult();
            queuedRuns.TryRemove(secondId, out _);
            if (pendingCancel is not null)
            {
                (await pendingCancel.WaitAsync(timeout)).Dispose();
            }
            if (second is not null)
            {
                await second.Completion.WaitAsync(timeout);
            }
            if (successor is not null)
            {
                await successor.Completion.WaitAsync(timeout);
            }
        }
    }

    private sealed class CapturedResearchCancellation(TaskRun<ResearchResult> run) : TaskRun<ResearchResult>
    {
        public TaskCompletionSource Entered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource Release { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public override async Task RequestCancellationAsync()
        {
            Entered.TrySetResult();
            await Release.Task.WaitAsync(TimeSpan.FromSeconds(10));
            await run.RequestCancellationAsync();
        }
    }
}
