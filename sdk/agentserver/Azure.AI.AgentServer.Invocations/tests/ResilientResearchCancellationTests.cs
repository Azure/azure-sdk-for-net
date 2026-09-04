// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Invocations.Tests.Snippets;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
[NonParallelizable]
public sealed class ResilientResearchCancellationTests
{
    [Test]
    public async Task InvocationInputIdLocatesAndCancelsTheActiveTurn()
    {
        string stateRoot = Path.Combine(
            Path.GetTempPath(),
            "resilient-research-cancel-" + Guid.NewGuid().ToString("N"));
        string? previousRoot =
            Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        string? previousHosting =
            Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT");
        var started = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);

        try
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", stateRoot);
            Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", null);
            FoundryEnvironment.Reload();

            var services = new ServiceCollection();
            services.AddLogging();
            services.AddResilientMultiTurnTask<
                SampleResilientResearchSnippets.ResearchRequest,
                SampleResilientResearchSnippets.ResearchResult>(
                "research",
                async (context, cancellationToken) =>
                {
                    started.TrySetResult();
                    await Task.Delay(Timeout.Infinite, context.Cancellation);
                    return new("completed", Array.Empty<string>());
                },
                steerable: true);

            await using ServiceProvider provider = services.BuildServiceProvider();
            TaskDefinition<
                SampleResilientResearchSnippets.ResearchRequest,
                SampleResilientResearchSnippets.ResearchResult> research =
                provider.GetResilientTask<
                    SampleResilientResearchSnippets.ResearchRequest,
                    SampleResilientResearchSnippets.ResearchResult>("research");

            const string taskId = "research-session";
            const string invocationId = "invocation-1";
            TaskRun<SampleResilientResearchSnippets.ResearchResult> startedRun =
                await research.StartAsync(
                    new(
                        "topic",
                        invocationId,
                        "session",
                        CallId: null),
                    new RunOptions
                    {
                        TaskId = taskId,
                        InputId = invocationId,
                    });
            await started.Task.WaitAsync(TimeSpan.FromSeconds(5));

            TaskRun<SampleResilientResearchSnippets.ResearchResult>? active =
                await research.GetActiveRunAsync(taskId, invocationId);
            Assert.That(active, Is.Not.Null);

            await active!.RequestCancellationAsync();
            Assert.ThrowsAsync<OperationCanceledException>(
                async () => await startedRun.Completion);
            await research.DeleteAsync(taskId);
        }
        finally
        {
            Environment.SetEnvironmentVariable(
                "AGENTSERVER_STATE_ROOT",
                previousRoot);
            Environment.SetEnvironmentVariable(
                "FOUNDRY_HOSTING_ENVIRONMENT",
                previousHosting);
            FoundryEnvironment.Reload();
            if (Directory.Exists(stateRoot))
            {
                Directory.Delete(stateRoot, recursive: true);
            }
        }
    }
}
