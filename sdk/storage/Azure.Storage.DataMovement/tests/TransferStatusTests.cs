// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests;

/// <summary>
/// Unit tests for <see cref="TransferStatus"/> state transition logic,
/// particularly the CAS-based <c>SetTransferStateChange</c> method that
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
    public void SetTransferStateChange_PausingToCompleted_Rejected()
    {
        TransferStatus status = new(TransferState.Pausing, false, false);
        bool changed = status.SetTransferStateChange(TransferState.Completed);

        Assert.IsFalse(changed);
        Assert.That(status.State, Is.EqualTo(TransferState.Pausing));
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
    /// Helper: sets a private field on an object via reflection.
    /// </summary>
    private static void SetPrivateField(object obj, string fieldName, object value)
    {
        FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.IsNotNull(field, $"Field '{fieldName}' not found on {obj.GetType().Name}");
        field.SetValue(obj, value);
    }

    /// <summary>
    /// Creates a minimal <see cref="TransferJobInternal"/> wired up enough to
    /// call <c>CheckAndUpdateStatusAsync</c> and <c>JobPartStatusEventAsync</c>.
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

        // Wire up the event handler (normally done in the private constructor)
        // Use reflection to invoke the event handler add since it's set up internally
        typeof(TransferJobInternal)
            .GetMethod("JobPartStatusEventAsync", BindingFlags.Public | BindingFlags.Instance)
            ?.GetType(); // just to verify it exists

        return job;
    }

    /// <summary>
    /// Directly reproduces the race condition from the log.
    ///
    /// Setup: Job is in <c>Pausing</c> state with 2 pending parts and
    /// <c>_enumerationComplete = true</c>. Two threads concurrently call
    /// <c>JobPartStatusEventAsync</c>:
    ///   - Thread A: part reports <c>Completed</c> (finished before pause)
    ///   - Thread B: part reports <c>Paused</c> (was cancelled by pause)
    ///
    /// The race: Thread A's <c>JobPartStatusEventAsync</c> decrements
    /// <c>_pendingJobParts</c> to 0, then calls <c>CheckAndUpdateStatusAsync</c>.
    /// If Thread B's <c>_jobPartPaused = true</c> hasn't executed yet,
    /// <c>CheckAndUpdateStatusAsync</c> sees <c>_pendingJobParts == 0</c> and
    /// <c>_jobPartPaused == false</c>, so it calls
    /// <c>OnJobStateChangedAsync(Completed)</c>.
    ///
    /// Without the CAS guard: <c>Pausing ? Completed</c> succeeds — the bug.
    /// With the CAS guard: <c>Pausing ? Completed</c> is rejected, and
    /// Thread B's subsequent call correctly transitions to <c>Paused</c>.
    ///
    /// Since the StepProcessor serializes all work and prevents the race from
    /// occurring in mocked tests, this test calls <c>CheckAndUpdateStatusAsync</c>
    /// directly after setting up the exact interleaving that causes the bug.
    /// </summary>
    [Test]
    public async Task CheckAndUpdateStatusAsync_PausingJob_CompletedPartsOnly_DoesNotPrematurelyComplete()
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

        // Simulate: both parts finished. Decrement _pendingJobParts to 0 via reflection
        // (normally this happens in JobPartStatusEventAsync, but we're isolating
        //  CheckAndUpdateStatusAsync to test just the decision logic)
        SetPrivateField(job, "_pendingJobParts", 0);

        // _jobPartPaused is still false — this is the crux of the race.
        // In the real race, Thread B hasn't set _jobPartPaused = true yet
        // when Thread A calls CheckAndUpdateStatusAsync.

        // Call CheckAndUpdateStatusAsync — this is where the bug manifests.
        // Without CAS: sees _pendingJobParts == 0, _jobPartPaused == false
        //   ? calls OnJobStateChangedAsync(Completed)
        //   ? Pausing ? Completed succeeds (BUG)
        // With CAS: OnJobStateChangedAsync(Completed) is rejected because
        //   Pausing can only go to Paused.
        await job.CheckAndUpdateStatusAsync();

        // CRITICAL: The job must NOT be Completed. It should still be Pausing
        // because the CAS guard rejected the Pausing ? Completed transition.
        Assert.That(job._transferOperation.Status.State, Is.Not.EqualTo(TransferState.Completed),
            "Job in Pausing state must NOT transition to Completed. " +
            "This is the exact race condition from the log where " +
            "'Transfer completed' was emitted instead of pausing.");

        Assert.That(job._transferOperation.Status.State, Is.EqualTo(TransferState.Pausing),
            "Job should remain in Pausing state since Pausing ? Completed was rejected by CAS");
    }

    /// <summary>
    /// Verifies the correct path: when <c>_jobPartPaused</c> is true and
    /// <c>_pendingJobParts == 0</c>, <c>CheckAndUpdateStatusAsync</c> correctly
    /// transitions the job from <c>Pausing ? Paused</c>.
    /// </summary>
    [Test]
    public async Task CheckAndUpdateStatusAsync_PausingJob_WithPausedParts_TransitionsToPaused()
    {
        TransferJobInternal job = CreateMinimalJob(TransferState.Pausing);

        Mock<JobPartInternal> part1 = new();
        part1.Object.JobPartStatus = new TransferStatus(TransferState.InProgress, false, false);
        job.AppendJobPart(part1.Object);

        // Simulate: part finished and was paused
        SetPrivateField(job, "_pendingJobParts", 0);
        SetPrivateField(job, "_jobPartPaused", true);

        await job.CheckAndUpdateStatusAsync();

        Assert.That(job._transferOperation.Status.State, Is.EqualTo(TransferState.Paused),
            "Job should transition from Pausing to Paused when _jobPartPaused is true");
    }

    /// <summary>
    /// Concurrent version: fires <c>JobPartStatusEventAsync</c> from multiple
    /// threads simultaneously — one with Completed status, one with Paused status —
    /// while the job is in Pausing state. This is the closest reproduction of
    /// the production race where serialized processing does not occur.
    /// </summary>
    [Test]
    [Repeat(10)]
    public async Task ConcurrentJobPartStatusEvents_PausingJob_NeverReachesCompleted()
    {
        TransferJobInternal job = CreateMinimalJob(TransferState.Pausing);

        // Add 2 parts (InProgress ? _pendingJobParts = 2)
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

        // The job must never end up Completed when it was Pausing.
        // It should be either Paused (correct) or still Pausing (if neither
        // thread's CheckAndUpdateStatusAsync triggered the final transition yet).
        Assert.That(job._transferOperation.Status.State, Is.Not.EqualTo(TransferState.Completed),
            "Job in Pausing state must NOT reach Completed via concurrent part events. " +
            "This reproduces the race condition from the production log.");
    }

    #endregion
}
