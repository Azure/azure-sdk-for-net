// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Messaging.EventHubs.Primitives;
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
        private readonly string _partitionId = "0";

        [Test]
        public void GetCheckpointsAsync_LogsOnRequestErrors()
        {
            var testLoggerProvider = new TestLoggerProvider();
            Mock<BlobContainerClient> containerClientMock = new Mock<BlobContainerClient>(MockBehavior.Strict);
            containerClientMock.Setup(c => c.GetBlobClient(It.IsAny<string>()))
                .Throws(new RequestFailedException("Uh oh"));

            BlobCheckpointStoreInternal store = new BlobCheckpointStoreInternal(
                containerClientMock.Object,
                _functionId,
                testLoggerProvider.CreateLogger("TestLogger")
            );

            Assert.ThrowsAsync<RequestFailedException>(async () => await store.GetCheckpointAsync(_namespace, _eventHubName, _consumerGroup, _partitionId, CancellationToken.None));

            var warning = testLoggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
            var expectedWarning = "Function 'EventHubsTriggerFunction': An exception occurred when retrieving a checkpoint for " +
                                  "FullyQualifiedNamespace: 'TestNamespace'; EventHubName: 'TestEventHubName'; ConsumerGroup: 'TestConsumerGroup'; PartitionId: '0'.";
            Assert.AreEqual(expectedWarning, warning.FormattedMessage);
            testLoggerProvider.ClearAllLogMessages();
        }

        [Test]
        public async Task ListCheckpointsAsync_LogsOnInvalidCheckpoints()
        {
            var testLoggerProvider = new TestLoggerProvider();
            var blobClientMock = new Mock<BlobClient>(MockBehavior.Strict);
            var containerClientMock = new Mock<BlobContainerClient>(MockBehavior.Strict);

            blobClientMock.Setup(c => c.GetPropertiesAsync(default, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(
                    Response.FromValue(
                        BlobsModelFactory.BlobProperties(metadata: new Dictionary<string, string>()),
                        Mock.Of<Response>())));

            containerClientMock.Setup(c => c.GetBlobClient("testnamespace/testeventhubname/testconsumergroup/checkpoint/0"))
                .Returns(blobClientMock.Object);

            BlobCheckpointStoreInternal store = new BlobCheckpointStoreInternal(
                containerClientMock.Object,
                _functionId,
                testLoggerProvider.CreateLogger("TestLogger")
            );

            await store.GetCheckpointAsync(_namespace, _eventHubName, _consumerGroup, _partitionId, CancellationToken.None);

            var warning = testLoggerProvider.GetAllLogMessages().Single(p => p.Level == LogLevel.Warning);
            var expectedWarning = "Function 'EventHubsTriggerFunction': An invalid checkpoint was found for partition: '0' of " +
                                  "FullyQualifiedNamespace: 'TestNamespace'; EventHubName: 'TestEventHubName'; ConsumerGroup: 'TestConsumerGroup'.  " +
                                  "This checkpoint is not valid and will be ignored.";
            Assert.AreEqual(expectedWarning, warning.FormattedMessage);
            testLoggerProvider.ClearAllLogMessages();
        }
    }
}