// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

public partial class SampleEndToEndTests
{
    [TestCase(false, false, false)]
    [TestCase(false, false, true)]
    [TestCase(false, true, false)]
    [TestCase(false, true, true)]
    [TestCase(true, false, false)]
    [TestCase(true, false, true)]
    [TestCase(true, true, false)]
    [TestCase(true, true, true)]
    [NonParallelizable]
    public async Task TaskDeletionKeepsHttpStreamsOpenUntilConfirmedAndUnwound(
        bool fileBacked, bool unwindFirst, bool failDelete)
    {
        TimeSpan timeout = TimeSpan.FromSeconds(10);
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked);
        var deleteEntered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseDelete = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        probe.Store.BeforeDelete = async token =>
        {
            deleteEntered.TrySetResult();
            await releaseDelete.Task.WaitAsync(timeout, token);
            if (failDelete)
            {
                throw new IOException("Injected deletion failure.");
            }
        };
        Task<string> active = probe.PostSseAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(timeout);
        Task<string> queued = probe.PostSseAsync("b");
        await probe.WaitForStreamAsync("b");
        Task deleting = probe.Engine.DeleteAsync("research", probe.TaskId);
        try
        {
            await deleteEntered.Task.WaitAsync(timeout);
            Assert.That(probe.Contexts["a"].CancelRequested, Is.True);
            await probe.AssertStreamStillOpenAsync("a");
            await probe.AssertStreamStillOpenAsync("b");
            if (unwindFirst)
            {
                probe.Backend.FirstRelease.TrySetResult();
                await probe.WaitUntilInactiveAsync();
                Assert.That(active.IsCompleted, Is.False);
                Assert.That(queued.IsCompleted, Is.False);
            }

            releaseDelete.TrySetResult();
            if (failDelete)
            {
                Assert.ThrowsAsync<IOException>(async () => await deleting.WaitAsync(timeout));
            }
            else
            {
                await deleting.WaitAsync(timeout);
                Assert.That(await queued.WaitAsync(timeout), Does.Contain("event: done"));
                if (!unwindFirst)
                {
                    Assert.That(active.IsCompleted, Is.False);
                }
            }

            probe.Backend.FirstRelease.TrySetResult();
            await probe.WaitUntilInactiveAsync();
            Assert.That(probe.Starts.ContainsKey("b"), Is.False);
            if (failDelete)
            {
                await probe.AssertStreamStillOpenAsync("a");
                await probe.AssertStreamStillOpenAsync("b");
                Assert.That(active.IsCompleted, Is.False);
                Assert.That(queued.IsCompleted, Is.False);
                Assert.That(await probe.Store.GetAsync(probe.TaskId), Is.Not.Null);
                probe.Store.BeforeDelete = null;
                await probe.Engine.DeleteAsync("research", probe.TaskId).WaitAsync(timeout);
            }

            Assert.That(await active.WaitAsync(timeout), Does.Contain("event: done"));
            Assert.That(await queued.WaitAsync(timeout), Does.Contain("event: done"));
            Assert.That(await probe.Store.GetAsync(probe.TaskId), Is.Null);
        }
        finally
        {
            releaseDelete.TrySetResult();
            probe.Backend.FirstRelease.TrySetResult();
            try
            {
                await deleting.WaitAsync(timeout);
            }
            catch (IOException) when (failDelete)
            {
                TestContext.WriteLine("Observed the injected deletion failure during cleanup.");
            }
        }
    }
}
