// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Moq;
using NUnit.Framework;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class BlobsCheckpointStoreTests
    {
        private readonly string _eventHubName = "TestEventHubName";
        private readonly string _consumerGroup = "TestConsumerGroup";
        private readonly string _namespace = "TestNamespace";
        private readonly string _functionId = "EventHubsTriggerFunction";

        [Test]
        public void ListCheckpointsAsync_LogsOnRequestErrors()
        {
            var testLoggerProvider = new TestLoggerProvider();
            Mock<BlobContainerClient> containerClientMock = new Mock<BlobContainerClient>(MockBehavior.Strict);
            containerClientMock.Setup(c => c.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException("Uh oh"));

            BlobsCheckpointStore store = new BlobsCheckpointStore(
                containerClientMock.Object,
                new BasicRetryPolicy(new EventHubsRetryOptions()),
                _functionId,
                testLoggerProvider.CreateLogger("TestLogger")
            );

            Assert.ThrowsAsync<RequestFailedException>(async () => await store.ListCheckpointsAsync(_namespace, _eventHubName, _consumerGroup, CancellationToken.None));

            var warning = testLoggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
            var expectedWarning = "Function 'EventHubsTriggerFunction': An exception occurred when listing checkpoints for " +
                                  "FullyQualifiedNamespace: 'TestNamespace'; EventHubName: 'TestEventHubName'; ConsumerGroup: 'TestConsumerGroup'.";
            Assert.AreEqual(expectedWarning, warning.FormattedMessage);
            testLoggerProvider.ClearAllLogMessages();
        }

        [Test]
        public async Task ListCheckpointsAsync_LogsOnInvalidCheckpoints()
        {
            var testLoggerProvider = new TestLoggerProvider();
            Mock<BlobContainerClient> containerClientMock = new Mock<BlobContainerClient>(MockBehavior.Strict);
            containerClientMock.Setup(c => c.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(AsyncPageable<BlobItem>.FromPages(new[]
                    {
                        Page<BlobItem>.FromValues(new[]
                        {
                            BlobsModelFactory.BlobItem("testnamespace/testeventhubname/testconsumergroup/checkpoint/0", false, BlobsModelFactory.BlobItemProperties(false, contentLength: 0), metadata: new Dictionary<string, string>())
                        }, null, Mock.Of<Response>())
                    }));

            BlobsCheckpointStore store = new BlobsCheckpointStore(
                containerClientMock.Object,
                new BasicRetryPolicy(new EventHubsRetryOptions()),
                _functionId,
                testLoggerProvider.CreateLogger("TestLogger")
            );

            await store.ListCheckpointsAsync(_namespace, _eventHubName, _consumerGroup, CancellationToken.None);

            var warning = testLoggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
            var expectedWarning = "Function 'EventHubsTriggerFunction': An invalid checkpoint was found for partition: '0' of " +
                                  "FullyQualifiedNamespace: 'TestNamespace'; EventHubName: 'TestEventHubName'; ConsumerGroup: 'TestConsumerGroup'.  " +
                                  "This checkpoint is not valid and will be ignored.";
            Assert.AreEqual(expectedWarning, warning.FormattedMessage);
            testLoggerProvider.ClearAllLogMessages();
        }
    }
}