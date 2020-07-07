// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.UnitTests.Blobs.Listeners
{
    public class BlobListenerTests
    {
        [Fact]
        public void GetMonitor_ReturnsSharedMonitor()
        {
            var queueListener = new QueueListener();
            var watcherMock = new Mock<IBlobWrittenWatcher>(MockBehavior.Strict);
            var executor = new BlobQueueTriggerExecutor(watcherMock.Object, NullLogger<BlobListener>.Instance);
            var sharedBlobQueueListener = new SharedBlobQueueListener(queueListener, executor);
            var sharedListenerMock = new Mock<ISharedListener>(MockBehavior.Strict);
            var blobListener1 = new BlobListener(sharedBlobQueueListener);
            var blobListener2 = new BlobListener(sharedBlobQueueListener);

            var monitor1 = blobListener1.GetMonitor();
            var monitor2 = blobListener1.GetMonitor();

            Assert.Same(monitor1, monitor2);
            Assert.Same(monitor1, queueListener);
        }
    }
}
