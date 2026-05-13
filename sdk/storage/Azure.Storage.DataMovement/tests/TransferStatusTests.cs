// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests;

/// <summary>
/// Unit tests for <see cref="TransferStatus"/> state transition logic,
/// particularly the CAS-based `SetTransferStateChange` method that
/// prevents invalid concurrent transitions such as multiple pause requests.
/// </summary>
public class TransferStatusTests
{
    #region SetTransferStateChange Unit Tests

    [Test]
    public void SetTransferStateChange_QueuedToInProgress_Succeeds()
    {
        TransferStatus status = new();
        Assert.That(status.State, Is.EqualTo(TransferState.Queued));

        bool changed = status.SetTransferStateChange(TransferState.InProgress);

        Assert.IsTrue(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.InProgress));
    }

    [Test]
    public void SetTransferStateChange_InProgressToPausing_Succeeds()
    {
        TransferStatus status = new(TransferState.InProgress, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Pausing);

        Assert.IsTrue(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Pausing));
    }

    [Test]
    public void SetTransferStateChange_InProgressToStopping_Succeeds()
    {
        TransferStatus status = new(TransferState.InProgress, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Stopping);

        Assert.IsTrue(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Stopping));
    }

    [Test]
    public void SetTransferStateChange_PausingToPaused_Succeeds()
    {
        TransferStatus status = new(TransferState.Pausing, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Paused);

        Assert.IsTrue(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Paused));
    }

    [Test]
    public void SetTransferStateChange_StoppingToCompleted_Succeeds()
    {
        TransferStatus status = new(TransferState.Stopping, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Completed);

        Assert.IsTrue(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Completed));
    }

    [Test]
    public void SetTransferStateChange_PausingToInProgress_Rejected()
    {
        TransferStatus status = new(TransferState.Pausing, false, false);
        bool changed = status.SetTransferStateChange(TransferState.InProgress);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Pausing));
    }

    [Test]
    public void SetTransferStateChange_PausingToCompleted_Succeeds()
    {
        // Pausing -> Completed is valid: when all parts finish before
        // the pause takes effect, the transfer should complete normally.
        TransferStatus status = new(TransferState.Pausing, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Completed);

        Assert.IsTrue(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Completed));
    }

    [Test]
    public void SetTransferStateChange_PausingToStopping_Rejected()
    {
        TransferStatus status = new(TransferState.Pausing, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Stopping);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Pausing));
    }

    [Test]
    public void SetTransferStateChange_StoppingToInProgress_Rejected()
    {
        TransferStatus status = new(TransferState.Stopping, false, false);
        bool changed = status.SetTransferStateChange(TransferState.InProgress);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Stopping));
    }

    [Test]
    public void SetTransferStateChange_StoppingToPaused_Rejected()
    {
        TransferStatus status = new(TransferState.Stopping, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Paused);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Stopping));
    }

    [Test]
    public void SetTransferStateChange_PausedToInProgress_Rejected()
    {
        TransferStatus status = new(TransferState.Paused, false, false);
        bool changed = status.SetTransferStateChange(TransferState.InProgress);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Paused));
    }

    [Test]
    public void SetTransferStateChange_CompletedToInProgress_Rejected()
    {
        TransferStatus status = new(TransferState.Completed, false, false);
        bool changed = status.SetTransferStateChange(TransferState.InProgress);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Completed));
    }

    [Test]
    public void SetTransferStateChange_PausedToQueued_Succeeds()
    {
        // Resuming a paused transfer resets to Queued
        TransferStatus status = new(TransferState.Paused, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Queued);

        Assert.IsTrue(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Queued));
    }

    [Test]
    public void SetTransferStateChange_CompletedToQueued_Succeeds()
    {
        // Resuming a completed transfer resets to Queued
        TransferStatus status = new(TransferState.Completed, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Queued);

        Assert.IsTrue(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Queued));
    }

    [Test]
    public void SetTransferStateChange_PausingToQueued_Rejected()
    {
        TransferStatus status = new(TransferState.Pausing, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Queued);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Pausing));
    }

    [Test]
    public void SetTransferStateChange_StoppingToQueued_Rejected()
    {
        TransferStatus status = new(TransferState.Stopping, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Queued);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Stopping));
    }

    [Test]
    public void SetTransferStateChange_SameState_ReturnsFalse()
    {
        TransferStatus status = new(TransferState.InProgress, false, false);
        bool changed = status.SetTransferStateChange(TransferState.InProgress);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.InProgress));
    }

    #endregion

    #region Stress Tests - Concurrent State Transitions

    [Test]
    [Repeat(5)]
    public async Task ConcurrentPauseRequests_OnlyOneSucceeds()
    {
        // Simulate multiple threads trying to set Pausing on an InProgress transfer.
        // Exactly one should succeed since CAS ensures atomicity.
        TransferStatus status = new(TransferState.InProgress, false, false);
        int successCount = 0;
        int threadCount = 50;

        using ManualResetEventSlim gate = new(false);
        Task[] tasks = Enumerable.Range(0, threadCount).Select(_ => Task.Run(() =>
        {
            gate.Wait();
            if (status.SetTransferStateChange(TransferState.Pausing))
            {
                Interlocked.Increment(ref successCount);
            }
        })).ToArray();

        gate.Set();
        await Task.WhenAll(tasks);

        Assert.That(successCount, Is.EqualTo(1),
            "Only one thread should win the CAS race to set Pausing");
        Assert.That(status.State, Is.EqualTo(TransferState.Pausing));
    }

    [Test]
    [Repeat(5)]
    public async Task ConcurrentPauseAndStop_OnlyOneSucceeds()
    {
        // Simulate concurrent Pausing and Stopping on InProgress.
        // Only one transition should succeed.
        TransferStatus status = new(TransferState.InProgress, false, false);
        int pausingWins = 0;
        int stoppingWins = 0;
        int threadCount = 50;

        using ManualResetEventSlim gate = new(false);
        Task[] tasks = Enumerable.Range(0, threadCount).Select(i => Task.Run(() =>
        {
            gate.Wait();
            TransferState target = (i % 2 == 0) ? TransferState.Pausing : TransferState.Stopping;
            if (status.SetTransferStateChange(target))
            {
                if (target == TransferState.Pausing)
                    Interlocked.Increment(ref pausingWins);
                else
                    Interlocked.Increment(ref stoppingWins);
            }
        })).ToArray();

        gate.Set();
        await Task.WhenAll(tasks);

        Assert.That(pausingWins + stoppingWins, Is.EqualTo(1),
            "Only one transition from InProgress should succeed");
        Assert.That(status.State, Is.AnyOf(TransferState.Pausing, TransferState.Stopping));
    }

    [Test]
    [Repeat(5)]
    public async Task ConcurrentCompletedTransitions_OnlyOneSucceeds()
    {
        // From Stopping, many threads try to set Completed.
        TransferStatus status = new(TransferState.Stopping, false, false);
        int successCount = 0;
        int threadCount = 50;

        using ManualResetEventSlim gate = new(false);
        Task[] tasks = Enumerable.Range(0, threadCount).Select(_ => Task.Run(() =>
        {
            gate.Wait();
            if (status.SetTransferStateChange(TransferState.Completed))
            {
                Interlocked.Increment(ref successCount);
            }
        })).ToArray();

        gate.Set();
        await Task.WhenAll(tasks);

        Assert.That(successCount, Is.EqualTo(1),
            "Only one thread should win the CAS race to set Completed");
        Assert.That(status.State, Is.EqualTo(TransferState.Completed));
    }

    [Test]
    [Repeat(3)]
    public async Task StressRapidStateTransitions_NoCorruption()
    {
        // Rapidly cycle through valid state transitions from multiple threads.
        // Verify final state is always a valid TransferState value.
        TransferStatus status = new();
        int iterations = 1000;

        Task[] tasks = Enumerable.Range(0, 10).Select(_ => Task.Run(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                // Try various transitions; some will succeed, some won't
                status.SetTransferStateChange(TransferState.InProgress);
                status.SetTransferStateChange(TransferState.Pausing);
                status.SetTransferStateChange(TransferState.Paused);
                status.SetTransferStateChange(TransferState.Queued);
                status.SetTransferStateChange(TransferState.InProgress);
                status.SetTransferStateChange(TransferState.Stopping);
                status.SetTransferStateChange(TransferState.Completed);
                status.SetTransferStateChange(TransferState.Queued);
            }
        })).ToArray();

        await Task.WhenAll(tasks);

        // Verify the state is a valid enum value (no torn reads)
        TransferState finalState = status.State;
        Assert.That(Enum.IsDefined(typeof(TransferState), finalState), Is.True,
            $"Final state {finalState} is not a valid TransferState value");
    }

    [Test]
    [Repeat(3)]
    public async Task ConcurrentSetFailedAndSkipped_AllRecorded()
    {
        // Verify that concurrent SetFailedItem and SetSkippedItem calls work correctly.
        TransferStatus status = new(TransferState.InProgress, false, false);
        int threadCount = 50;

        using ManualResetEventSlim gate = new(false);
        Task[] tasks = Enumerable.Range(0, threadCount).Select(i => Task.Run(() =>
        {
            gate.Wait();
            if (i % 2 == 0)
                status.SetFailedItem();
            else
                status.SetSkippedItem();
        })).ToArray();

        gate.Set();
        await Task.WhenAll(tasks);

        Assert.IsTrue(status.HasFailedItems);
        Assert.IsTrue(status.HasSkippedItems);
    }

    #endregion

    #region Integration Tests - CheckAndUpdateStatusAsync Race Condition

    /// <summary>
    /// Creates a minimal <see cref="TransferJobInternal"/> wired up enough to
    /// call `CheckAndUpdateStatusAsync` and `JobPartStatusEventAsync`.
    /// </summary>
    private static TransferJobInternal CreateMinimalJob(TransferState initialJobState)
    {
        TransferStatus status = new(initialJobState, false, false);
        TransferOperation transferOp = new("test-transfer-id", status);
        // TransferInternalState.SetTransferState requires TransferManager to be non-null.
        // Use a minimal mock that satisfies the null check.
        Mock<TransferManager> mockManager = new();
        transferOp.TransferManager = mockManager.Object;

        TransferJobInternal job = new();
        job._transferOperation = transferOp;
        job._jobParts = new List<JobPartInternal>();
        job._enumerationComplete = true;
        job._checkpointer = new Mock<ITransferCheckpointer>().Object;
        job._cancellationToken = CancellationToken.None;

        return job;
    }

    /// <summary>
    /// Verifies that when a job is in `Pausing` state but all parts have
    /// already completed (no part was actually paused), the job transitions
    /// to `Completed` rather than getting stuck in `Pausing` forever.
    ///
    /// This scenario occurs when a pause is requested but all parts finish
    /// before the cancellation is observed. Since no part will ever report
    /// `Paused`, the `_jobPartPaused` flag remains false and
    /// `CheckAndUpdateStatusAsync` must allow `Pausing -> Completed`.
    /// </summary>
    [Test]
    public async Task CheckAndUpdateStatusAsync_PausingJob_CompletedPartsOnly_CompletesNormally()
    {
        // Build a TransferJobInternal in Pausing state with 2 parts, both "completed"
        // and _jobPartPaused still false — the exact interleaving from the bug.
        TransferJobInternal job = CreateMinimalJob(TransferState.Pausing);

        // Add 2 dummy job parts (InProgress so AppendJobPart increments _pendingJobParts)
        Mock<JobPartInternal> part1 = new();
        part1.Object.JobPartStatus = new TransferStatus(TransferState.InProgress, false, false);
        Mock<JobPartInternal> part2 = new();
        part2.Object.JobPartStatus = new TransferStatus(TransferState.InProgress, false, false);

        job.AppendJobPart(part1.Object);
        job.AppendJobPart(part2.Object);
        // _pendingJobParts is now 2

        // Simulate: both parts finished. Set _pendingJobParts to 0
        // (normally this happens in JobPartStatusEventAsync, but we're isolating
        //  CheckAndUpdateStatusAsync to test just the decision logic)
        job.SetPendingJobPartsForTest(0);

        // _jobPartPaused is still false — this is the crux of the race.
        // In the real race, Thread B hasn't set _jobPartPaused = true yet
        // when Thread A calls CheckAndUpdateStatusAsync.

        // Call CheckAndUpdateStatusAsync — all parts completed before pause took effect.
        // Pausing -> Completed is now allowed to prevent the transfer from getting
        // stuck in Pausing state when no paused-part signal will ever arrive.
        await job.CheckAndUpdateStatusAsync();

        // The job should complete normally since all parts finished.
        Assert.That(job._transferOperation.Status.State, Is.EqualTo(TransferState.Completed),
            "Job in Pausing state should transition to Completed when all parts " +
            "finished before the pause took effect.");
    }

    /// <summary>
    /// Verifies the correct path: when `_jobPartPaused` is true and
    /// `_pendingJobParts == 0`, `CheckAndUpdateStatusAsync` correctly
    /// transitions the job from `Pausing -> Paused`.
    /// </summary>
    [Test]
    public async Task CheckAndUpdateStatusAsync_PausingJob_WithPausedParts_TransitionsToPaused()
    {
        TransferJobInternal job = CreateMinimalJob(TransferState.Pausing);

        Mock<JobPartInternal> part1 = new();
        part1.Object.JobPartStatus = new TransferStatus(TransferState.InProgress, false, false);
        job.AppendJobPart(part1.Object);

        // Simulate: part finished and was paused
        job.SetPendingJobPartsForTest(0);
        job.SetJobPartPausedForTest(true);

        await job.CheckAndUpdateStatusAsync();

        Assert.That(job._transferOperation.Status.State, Is.EqualTo(TransferState.Paused),
            "Job should transition from Pausing to Paused when _jobPartPaused is true");
    }

    /// <summary>
    /// Concurrent version: fires `JobPartStatusEventAsync` from multiple
    /// threads simultaneously — one with Completed status, one with Paused status —
    /// while the job is in Pausing state. This is the closest reproduction of
    /// the production race where serialized processing does not occur.
    /// </summary>
    [Test]
    [Repeat(10)]
    public async Task ConcurrentJobPartStatusEvents_PausingJob_ReachesValidFinalState()
    {
        TransferJobInternal job = CreateMinimalJob(TransferState.Pausing);

        // Add 2 parts (InProgress -> _pendingJobParts = 2)
        Mock<JobPartInternal> part1 = new();
        part1.Object.JobPartStatus = new TransferStatus(TransferState.InProgress, false, false);
        Mock<JobPartInternal> part2 = new();
        part2.Object.JobPartStatus = new TransferStatus(TransferState.InProgress, false, false);
        job.AppendJobPart(part1.Object);
        job.AppendJobPart(part2.Object);

        string transferId = job._transferOperation.Id;

        // Concurrently send: one Completed part event, one Paused part event
        JobPartStatusEventArgs completedArgs = new(
            transferId, 0,
            new TransferStatus(TransferState.Completed, false, false),
            false, CancellationToken.None);
        JobPartStatusEventArgs pausedArgs = new(
            transferId, 1,
            new TransferStatus(TransferState.Paused, false, false),
            false, CancellationToken.None);

        using ManualResetEventSlim gate = new(false);
        Task task1 = Task.Run(async () =>
        {
            gate.Wait();
            await job.JobPartStatusEventAsync(completedArgs);
        });
        Task task2 = Task.Run(async () =>
        {
            gate.Wait();
            await job.JobPartStatusEventAsync(pausedArgs);
        });

        gate.Set();
        await Task.WhenAll(task1, task2);

        // After both JobPartStatusEventAsync calls complete, _pendingJobParts
        // is 0 and CheckAndUpdateStatusAsync has been called. The job should
        // be in a terminal state: Completed (all parts finished before pause)
        // or Paused (at least one part reported Paused).
        TransferState finalState = job._transferOperation.Status.State;
        Assert.That(finalState, Is.AnyOf(
            TransferState.Completed, TransferState.Paused),
            "Job should reach a terminal state after all part events are processed.");
    }

    #endregion
}
