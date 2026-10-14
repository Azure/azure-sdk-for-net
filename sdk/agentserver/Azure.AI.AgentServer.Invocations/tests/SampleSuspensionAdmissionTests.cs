// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

public partial class SampleEndToEndTests
{
    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    [NonParallelizable]
    public async Task SampleInputSurvivesAdmissionRacingSuspension(bool fileBacked, bool suspensionWins)
    {
        TimeSpan timeout = TimeSpan.FromSeconds(10);
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked);
        var writeEntered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseWrite = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Task<System.Net.Http.HttpResponseMessage>? cancellation = null;
        await probe.PostAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(timeout);
        if (!suspensionWins)
        {
            await probe.PostAsync("b");
        }
        probe.Store.BeforePatch = async (patch, token) =>
        {
            bool target = suspensionWins
                ? patch.Status == TaskWireKeys.StatusSuspended
                : patch.Status is null
                    && patch.Payload?[TaskWireKeys.PayloadSteering]?[TaskWireKeys.SteeringPendingInputs] is System.Text.Json.Nodes.JsonArray pending
                    && pending.Count == 0;
            if (target)
            {
                writeEntered.TrySetResult();
                await releaseWrite.Task.WaitAsync(timeout, token);
            }
        };
        try
        {
            if (suspensionWins)
            {
                probe.Backend.FirstRelease.TrySetResult();
            }
            else
            {
                cancellation = probe.CancelAsync("b");
            }
            await writeEntered.Task.WaitAsync(timeout);
            Task<string> c = probe.PostSseAsync("c");
            await WaitForSampleWriters(probe, 2, timeout);
            if (!suspensionWins)
            {
                probe.Backend.FirstRelease.TrySetResult();
                await WaitForSampleWriters(probe, 3, timeout);
            }
            releaseWrite.TrySetResult();
            if (cancellation is not null)
            {
                using var response = await cancellation.WaitAsync(timeout);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            }
            await probe.Backend.SecondEntered.Task.WaitAsync(timeout);
            Assert.That(probe.Starts.ContainsKey("c"), Is.True);
            Assert.That(probe.Starts.ContainsKey("b"), Is.False);
            Assert.That(probe.Contexts["c"].InputId, Is.EqualTo(probe.Id("c")));
            Assert.That(probe.Contexts["c"].IsSteeredTurn, Is.EqualTo(!suspensionWins));
            probe.Backend.SecondRelease.TrySetResult();
            Assert.That(await c.WaitAsync(timeout), Does.Contain("event: done"));
            await probe.WaitUntilInactiveAsync();
            TaskRecord record = (await probe.Store.GetAsync(probe.TaskId))!;
            Assert.That(record.Status, Is.EqualTo(TaskWireKeys.StatusSuspended));
            Assert.That((string?)record.Payload[TaskWireKeys.PayloadLastInputId], Is.EqualTo(probe.Id("c")));
        }
        finally
        {
            releaseWrite.TrySetResult();
            probe.Backend.FirstRelease.TrySetResult();
            probe.Backend.SecondRelease.TrySetResult();
            if (cancellation is not null)
            {
                (await cancellation.WaitAsync(timeout)).Dispose();
            }
        }
    }

    private static async Task WaitForSampleWriters(CoreStreamHost probe, int count, TimeSpan timeout)
    {
        var entry = probe.Engine.Serializer.GetOrAddEntry(probe.TaskId);
        using var stop = new CancellationTokenSource(timeout);
        while (true)
        {
            lock (entry.ReapLock)
            {
                if (entry.RefCount >= count)
                { return; }
            }
            await Task.Delay(10, stop.Token);
        }
    }
}
