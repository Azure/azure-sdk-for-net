// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceResourceGovernorTests
{
    [Test]
    public void ConnectionAdmissionIsSharedAndReleasedExactlyOnce()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxConnections = 1,
        });

        var first = governor.AcquireConnection();
        Assert.That(
            governor.AcquireConnection,
            Throws.TypeOf<VoiceResourceExhaustedException>());

        first.Dispose();
        first.Dispose();

        using var second = governor.AcquireConnection();
        Assert.That(governor.ConnectionCount, Is.EqualTo(1));
    }

    [Test]
    public async Task CustomerTaskAdmissionLivesUntilOriginalTaskCompletes()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxCustomerTasks = 1,
        });
        var completion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var firstInvoked = false;
        var secondInvoked = false;

        var first = governor.InvokeCustomerTask(() =>
        {
            firstInvoked = true;
            return completion.Task;
        });
        var second = governor.InvokeCustomerTask(() =>
        {
            secondInvoked = true;
            return Task.CompletedTask;
        });
        try
        {
            Assert.Multiple(() =>
            {
                Assert.That(firstInvoked, Is.True);
                Assert.That(secondInvoked, Is.False);
                Assert.That(governor.CustomerTaskCount, Is.EqualTo(1));
            });
            Assert.That(
                async () => await second,
                Throws.TypeOf<VoiceResourceExhaustedException>());

            completion.TrySetResult();
            await first;
            Assert.That(governor.CustomerTaskCount, Is.Zero);

            await governor.InvokeCustomerTask(() =>
            {
                secondInvoked = true;
                return Task.CompletedTask;
            });
            Assert.That(secondInvoked, Is.True);
        }
        finally
        {
            completion.TrySetResult();
            try
            {
                await first;
            }
            catch
            {
                _ = first.Exception;
            }
            if (second.IsFaulted)
            {
                _ = second.Exception;
            }
        }
    }

    [Test]
    public async Task TerminalCustomerTaskUsesProtectedReserve()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxCustomerTasks = 1,
            MaxTerminalCustomerTasks = 1,
        });
        var ordinaryCompletion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var terminalCompletion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        var ordinary = governor.InvokeCustomerTask(() => ordinaryCompletion.Task);
        var terminal = governor.InvokeCustomerTask(() => terminalCompletion.Task, terminal: true);

        Assert.Multiple(() =>
        {
            Assert.That(governor.CustomerTaskCount, Is.EqualTo(1));
            Assert.That(governor.TerminalCustomerTaskCount, Is.EqualTo(1));
        });

        ordinaryCompletion.TrySetResult();
        terminalCompletion.TrySetResult();
        await Task.WhenAll(ordinary, terminal);
        Assert.Multiple(() =>
        {
            Assert.That(governor.CustomerTaskCount, Is.Zero);
            Assert.That(governor.TerminalCustomerTaskCount, Is.Zero);
        });
    }

    [Test]
    public void CleanupTaskAdmissionIsBoundedAndReleased()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxCleanupTasks = 1,
        });

        var first = governor.AcquireCleanupTask();
        Assert.That(
            governor.AcquireCleanupTask,
            Throws.TypeOf<VoiceResourceExhaustedException>());

        first.Dispose();
        using var second = governor.AcquireCleanupTask();
        Assert.That(governor.CleanupTaskCount, Is.EqualTo(1));
    }

    [Test]
    public void PendingOperationAdmissionIsBoundedAndReleased()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxPendingOperations = 1,
        });

        var first = governor.AcquirePendingOperation();
        Assert.That(
            governor.AcquirePendingOperation,
            Throws.TypeOf<VoiceResourceExhaustedException>());

        first.Dispose();
        using var second = governor.AcquirePendingOperation();
        Assert.That(governor.PendingOperationCount, Is.EqualTo(1));
    }

    [Test]
    public void PreparedFrameAdmissionHappensBeforeAllocationAndSurvivesTransfer()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxPreparedFrameBytes = VoiceProtocolConstants.MaxFrameBytes,
            MaxPreparedFrames = 1,
        });

        var first = governor.AcquirePreparedFrames(
            frameCount: 1,
            reservedBytes: VoiceProtocolConstants.MaxFrameBytes,
            control: false);
        Assert.That(
            () => governor.AcquirePreparedFrames(
                frameCount: 1,
                reservedBytes: VoiceProtocolConstants.MaxFrameBytes,
                control: false),
            Throws.TypeOf<VoiceResourceExhaustedException>());

        var transferred = first.Transfer();
        first.Dispose();
        Assert.That(governor.PreparedFrameBytes, Is.EqualTo(VoiceProtocolConstants.MaxFrameBytes));

        transferred.Dispose();
        Assert.Multiple(() =>
        {
            Assert.That(governor.PreparedFrameBytes, Is.Zero);
            Assert.That(governor.PreparedFrameCount, Is.Zero);
        });
    }

    [Test]
    public void ResponseReservationRollsBackAndTerminalReleaseReturnsAggregateCapacity()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxRetainedOutputBytes = 8,
            MaxRetainedOutputItems = 1,
            MaxRetainedOutputChunks = 1,
            MaxOutputWrites = 2,
            MaxResponseOutputBytes = 8,
            MaxResponseOutputItems = 1,
            MaxResponseOutputChunks = 1,
            MaxResponseOutputWrites = 2,
        });
        var first = governor.CreateResponseResources();
        var second = governor.CreateResponseResources();

        using (first.Reserve(bytes: 4, items: 1, chunks: 1, writes: 1))
        {
        }
        Assert.Multiple(() =>
        {
            Assert.That(governor.RetainedOutputBytes, Is.Zero);
            Assert.That(governor.RetainedOutputChunks, Is.Zero);
        });

        using (var reservation = first.Reserve(bytes: 4, items: 1, chunks: 1, writes: 1))
        {
            reservation.Commit();
        }
        Assert.That(
            () => second.Reserve(bytes: 1, items: 1, chunks: 1, writes: 1),
            Throws.TypeOf<VoiceResourceExhaustedException>());

        first.ReleaseAll();
        using (var reservation = second.Reserve(bytes: 1, items: 1, chunks: 1, writes: 1))
        {
            reservation.Commit();
        }
        Assert.Multiple(() =>
        {
            Assert.That(governor.RetainedOutputBytes, Is.EqualTo(1));
            Assert.That(governor.RetainedOutputItems, Is.EqualTo(1));
            Assert.That(governor.RetainedOutputChunks, Is.EqualTo(1));
            Assert.That(governor.OutputWriteCount, Is.EqualTo(1));
        });

        second.ReleaseAll();
    }

    [Test]
    public void EncodedReservationCannotCommitAfterContentRelease()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxEncodedOutputBytes = 1,
            MaxResponseEncodedOutputBytes = 1,
        });
        var first = governor.CreateResponseResources();
        var second = governor.CreateResponseResources();
        var staged = first.Reserve(encodedBytes: 1);

        first.ReleaseContent();
        Assert.That(() => staged.Commit(), Throws.TypeOf<VoiceBridgeConnectionClosedException>());
        staged.Dispose();
        Assert.That(governor.EncodedOutputBytes, Is.Zero);

        using var replacement = second.Reserve(encodedBytes: 1);
        replacement.Commit();
        second.ReleaseAll();
        Assert.That(governor.EncodedOutputBytes, Is.Zero);
    }

    [Test]
    public void CallbackQueueAdmissionIsAggregateAndSymmetric()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxCallbackQueueBytes = 10,
            MaxCallbackQueueItems = 1,
        });

        var first = governor.AcquireCallbackQueueItem(10);
        Assert.That(
            () => governor.AcquireCallbackQueueItem(1),
            Throws.TypeOf<VoiceResourceExhaustedException>());

        first.Dispose();
        using var second = governor.AcquireCallbackQueueItem(10);
        Assert.Multiple(() =>
        {
            Assert.That(governor.CallbackQueueBytes, Is.EqualTo(10));
            Assert.That(governor.CallbackQueueItems, Is.EqualTo(1));
        });
    }
}
