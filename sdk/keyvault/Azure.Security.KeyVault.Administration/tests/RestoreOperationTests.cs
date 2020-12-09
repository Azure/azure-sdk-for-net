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
    public class RestoreOperationTests
    {
        private RestoreDetailsInternal failedRestore;
        private RestoreDetailsInternal incompleteRestore;
        private Mock<Response<RestoreDetailsInternal>> failedResponse;
        private const string JobId = "1233";
        private const string RestoreLocation = "https://foo.com/restore";

        [OneTimeSetUp]
        public void Setup()
        {
            DateTimeOffset now = DateTimeOffset.Now;

            failedRestore = new RestoreDetailsInternal(
                "failed",
                "failure details",
                new KeyVaultServiceError("500", "failed restore", null),
                JobId,
                DateTimeOffset.Now.AddMinutes(-5),
                now);
            incompleteRestore = new RestoreDetailsInternal(
                "in progress",
                "",
                null,
                JobId,
                DateTimeOffset.Now.AddMinutes(-5),
                null);

            failedResponse = new Mock<Response<RestoreDetailsInternal>>();
            failedResponse.SetupGet(m => m.Value).Returns(failedRestore);
        }

        [Test]
        public void UpdateStatusThrowsOnError()
        {
            // setup the GetRestoreDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetRestoreDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new RestoreOperation(mockClient.Object, JobId);

            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            operation = new RestoreOperation(mockClient.Object, JobId);

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
            // setup the GetRestoreDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetRestoreDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(ex);
            mockClient
                .Setup(m => m.GetRestoreDetails(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(ex);

            var operation = new RestoreOperation(mockClient.Object, JobId);

            Exception result = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            operation = new RestoreOperation(mockClient.Object, JobId);

            result = Assert.Throws<RequestFailedException>(() => operation.UpdateStatus(default));
        }

        [Test]
        public void ValueThrowsOnError()
        {
            // setup the GetRestoreDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetRestoreDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new RestoreOperation(mockClient.Object, JobId);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            Assert.Throws<RequestFailedException>(() => { RestoreResult x = operation.Value; });
            Assert.That(operation.StartTime, Is.EqualTo(failedRestore.StartTime));
            Assert.That(operation.EndTime, Is.EqualTo(failedRestore.EndTime));
        }

        [Test]
        public void ValueThrowsWhenOperationIsNotComplete()
        {
            // setup the GetRestoreDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetRestoreDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new RestoreOperation(incompleteRestore, Mock.Of<Response>(), Mock.Of<KeyVaultBackupClient>());

            Assert.Throws<InvalidOperationException>(() => { RestoreResult x = operation.Value; });
            Assert.That(operation.StartTime, Is.EqualTo(incompleteRestore.StartTime));
            Assert.That(operation.EndTime, Is.EqualTo(incompleteRestore.EndTime));
        }
    }
}
