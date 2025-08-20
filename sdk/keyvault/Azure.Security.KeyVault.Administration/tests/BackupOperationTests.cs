// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
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

            var operation = new KeyVaultBackupOperation(mockClient.Object, JobId);

            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            operation = new KeyVaultBackupOperation(mockClient.Object, JobId);

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

            var operation = new KeyVaultBackupOperation(mockClient.Object, JobId);

            Exception result = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            operation = new KeyVaultBackupOperation(mockClient.Object, JobId);

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

            var operation = new KeyVaultBackupOperation(mockClient.Object, JobId);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            Assert.Throws<RequestFailedException>(() => { KeyVaultBackupResult x = operation.Value; });
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

            var operation = new KeyVaultBackupOperation(incompleteBackup, Mock.Of<Response>(), Mock.Of<KeyVaultBackupClient>());

            Assert.Throws<InvalidOperationException>(() => { KeyVaultBackupResult x = operation.Value; });
            Assert.That(operation.StartTime, Is.EqualTo(incompleteBackup.StartTime));
            Assert.That(operation.EndTime, Is.EqualTo(incompleteBackup.EndTime));
        }

        [Test(Description = "https://github.com/Azure/azure-sdk-for-net/issues/41855")]
        public void BackupOperationThrowsOnBadRequest()
        {
            const string jobId = "c79735efd41d4b8a8ef23634b7f3dd0d";
            var response = new MockResponse(200, "OK").WithJson($$"""
                    {
                        "endTime": 1704409031,
                        "error": {
                            "code": "BadRequest",
                            "innererror": null,
                            "message": "Invalid backup: Reason: Cannot read backup status document"
                        },
                        "jobId": "c79735efd41d4b8a8ef23634b7f3dd0d",
                        "startTime": 1704409030,
                        "status": "Failed",
                        "statusDetails": "Invalid backup: Reason: Cannot read backup status document"
                    }
                    """);

            using var doc = JsonDocument.Parse(response.Content.ToStream());
            var detail = FullBackupDetailsInternal.DeserializeFullBackupDetailsInternal(doc.RootElement);

            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetBackupDetails(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(detail, response));

            var operation = new KeyVaultBackupOperation(mockClient.Object, jobId);
            var ex = Assert.Throws<RequestFailedException>(() => operation.WaitForCompletion());
            Assert.AreEqual(ex.Status, 200);

            dynamic error = ex.GetRawResponse()?.Content.ToDynamicFromJson(JsonPropertyNames.UseExact).error;
            Assert.NotNull(error);
            Assert.AreEqual("BadRequest", (string)error.code);
            Assert.AreEqual("Invalid backup: Reason: Cannot read backup status document", (string)error.message);
        }

        [Test(Description = "https://github.com/Azure/azure-sdk-for-net/issues/41855")]
        public void RestoreOperationThrowsOnBadRequest()
        {
            const string jobId = "c79735efd41d4b8a8ef23634b7f3dd0d";
            var response = new MockResponse(200, "OK").WithJson($$"""
                    {
                        "endTime": 1704409031,
                        "error": {
                            "code": "BadRequest",
                            "innererror": null,
                            "message": "Invalid backup: Reason: Cannot read backup status document"
                        },
                        "jobId": "c79735efd41d4b8a8ef23634b7f3dd0d",
                        "startTime": 1704409030,
                        "status": "Failed",
                        "statusDetails": "Invalid backup: Reason: Cannot read backup status document"
                    }
                    """);

            using var doc = JsonDocument.Parse(response.Content.ToStream());
            var detail = RestoreDetailsInternal.DeserializeRestoreDetailsInternal(doc.RootElement);

            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetRestoreDetails(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(detail, response));

            var operation = new KeyVaultRestoreOperation(mockClient.Object, jobId);
            var ex = Assert.Throws<RequestFailedException>(() => operation.WaitForCompletion());
            Assert.AreEqual(ex.Status, 200);

            dynamic error = ex.GetRawResponse()?.Content.ToDynamicFromJson(JsonPropertyNames.UseExact).error;
            Assert.NotNull(error);
            Assert.AreEqual("BadRequest", (string)error.code);
            Assert.AreEqual("Invalid backup: Reason: Cannot read backup status document", (string)error.message);
        }
    }
}
