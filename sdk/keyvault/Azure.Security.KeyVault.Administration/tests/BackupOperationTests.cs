// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Security.KeyVault.Administration.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    [TestFixture]
    public class BackupOperationTests
    {
        private FullBackupDetailsInternal failedBackup;
        private FullBackupDetailsInternal incompleteBackup;
        private Mock<Response<FullBackupDetailsInternal>> failedResponse;
        private const string JobId = "1233";
        private const string BackupLocation = "https://foo.com/backup";

        [OneTimeSetUp]
        public void Setup()
        {
            DateTimeOffset now = DateTimeOffset.Now;

            failedBackup = new FullBackupDetailsInternal(
                "failed",
                "failure details",
                new KeyVaultServiceError("500", "failed backup", null),
                DateTimeOffset.Now.AddMinutes(-5),
                now, JobId, BackupLocation);

            incompleteBackup = new FullBackupDetailsInternal(
                "in progress",
                "",
                null,
                DateTimeOffset.Now.AddMinutes(-5),
                null, JobId, BackupLocation);

            failedResponse = new Mock<Response<FullBackupDetailsInternal>>();
            failedResponse.SetupGet(m => m.Value).Returns(failedBackup);
        }

        [Test]
        public void UpdateStatusThrowsOnError()
        {
            // setup the GetBackupDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetBackupDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new BackupOperation(mockClient.Object, JobId);

            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            operation = new BackupOperation(mockClient.Object, JobId);

            Assert.Throws<RequestFailedException>(() => operation.UpdateStatus(default));
        }

        private static object[] exceptions = new object[]
        {
            new object []{new Exception()},
            new object []{new RequestFailedException("error")},
        };

        [Test]
        [TestCaseSource("exceptions")]
        public void UpdateStatusThrowsIfServiceCallThrows(Exception ex)
        {
            // setup the GetBackupDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetBackupDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(ex);
            mockClient
                .Setup(m => m.GetBackupDetails(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(ex);

            var operation = new BackupOperation(mockClient.Object, JobId);

            Exception result = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            operation = new BackupOperation(mockClient.Object, JobId);

            result = Assert.Throws<RequestFailedException>(() => operation.UpdateStatus(default));
        }

        [Test]
        public void ValueThrowsOnError()
        {
            // setup the GetBackupDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetBackupDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new BackupOperation(mockClient.Object, JobId);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            Assert.Throws<RequestFailedException>(() => { BackupResult x = operation.Value; });
            Assert.That(operation.StartTime, Is.EqualTo(failedBackup.StartTime));
            Assert.That(operation.EndTime, Is.EqualTo(failedBackup.EndTime));
        }

        [Test]
        public void ValueThrowsWhenOperationIsNotComplete()
        {
            // setup the GetBackupDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetBackupDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new BackupOperation(incompleteBackup, Mock.Of<Response>(), Mock.Of<KeyVaultBackupClient>());

            Assert.Throws<InvalidOperationException>(() => { BackupResult x = operation.Value; });
            Assert.That(operation.StartTime, Is.EqualTo(incompleteBackup.StartTime));
            Assert.That(operation.EndTime, Is.EqualTo(incompleteBackup.EndTime));
        }
    }
}
