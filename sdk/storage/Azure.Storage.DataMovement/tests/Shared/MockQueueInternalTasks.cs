// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;

namespace Azure.Storage.DataMovement.Tests
{
    public static class MockQueueInternalTasks
    {
        internal static Mock<JobPartInternal.QueueChunkDelegate> GetPartQueueChunkTask()
        {
            var mock = new Mock<JobPartInternal.QueueChunkDelegate>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsAny<Func<Task>>()))
                .Callback<Func<Task>, CancellationToken>(
                async (funcTask, _) =>
                {
                    await funcTask().ConfigureAwait(false);
                })
                .Returns(new ValueTask(Task.CompletedTask));
            return mock;
        }
    }
}
