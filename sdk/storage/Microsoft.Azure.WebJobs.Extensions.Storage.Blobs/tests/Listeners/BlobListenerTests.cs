// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class BlobListenerTests
    {
        [Test]
        public void GetMonitor_ReturnsSharedMonitor()
        {
            var queueListener = new QueueListener();

            var watcherMock = new Mock<IBlobWrittenWatcher>(MockBehavior.Strict);
            var executor = new BlobQueueTriggerExecutor(BlobTriggerSource.LogsAndContainerScan, watcherMock.Object, NullLogger<BlobListener>.Instance);
            var sharedBlobQueueListener = new SharedBlobQueueListener(queueListener, executor);
            var sharedListenerMock = new Mock<ISharedListener>(MockBehavior.Strict);
            var blobListener1 = new BlobListener(sharedBlobQueueListener);
            var blobListener2 = new BlobListener(sharedBlobQueueListener);

            var monitor1 = blobListener1.GetMonitor();
            var monitor2 = blobListener1.GetMonitor();

            Assert.That(monitor2, Is.SameAs(monitor1));
            Assert.That(queueListener.GetMonitor(), Is.SameAs(monitor1));

            var targetScaler1 = blobListener1.GetTargetScaler();
            var targetScaler2 = blobListener1.GetTargetScaler();

            Assert.That(targetScaler2, Is.SameAs(targetScaler1));
            Assert.That(queueListener.GetTargetScaler(), Is.SameAs(targetScaler1));
        }
    }
}
