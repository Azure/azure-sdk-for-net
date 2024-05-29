// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Azure.Storage.DataMovement.Tests
{
    public static class MockQueueInternalTasks
    {
        internal static Mock<TransferJobInternal.QueueChunkTaskInternal> GetQueueChunkTask()
        {
            var mock = new Mock<TransferJobInternal.QueueChunkTaskInternal>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsAny<Func<Task>>()))
                .Returns(Task.CompletedTask);
            return mock;
        }

        internal static Mock<JobPartInternal.QueueChunkDelegate> GetPartQueueChunkTask()
        {
            var mock = new Mock<JobPartInternal.QueueChunkDelegate>(MockBehavior.Strict);
            mock.Setup(del => del(It.IsAny<Func<Task>>()))
                .Callback<Func<Task>>(
                async (funcTask) =>
                {
                    await funcTask().ConfigureAwait(false);
                })
                .Returns(Task.CompletedTask);
            return mock;
        }
    }
}
