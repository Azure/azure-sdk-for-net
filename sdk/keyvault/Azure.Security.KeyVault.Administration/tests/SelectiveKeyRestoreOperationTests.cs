// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using Azure.Security.KeyVault.Tests;
using Moq;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    [TestFixture]
    public class SelectiveKeyRestoreOperationTests
    {
        private SelectiveKeyRestoreDetailsInternal failedRestore;
        private SelectiveKeyRestoreDetailsInternal incompleteRestore;
        private Mock<Response<SelectiveKeyRestoreDetailsInternal>> failedResponse;
        private const string JobId = "1233";
        private const string RestoreLocation = "https://foo.com/restore";

        [OneTimeSetUp]
        public void Setup()
        {
            DateTimeOffset now = DateTimeOffset.Now;

            failedRestore = new SelectiveKeyRestoreDetailsInternal(
                "failed",
                "failure details",
                new KeyVaultServiceError("500", "failed restore", null),
                JobId,
                DateTimeOffset.Now.AddMinutes(-5),
                now,
                new Dictionary<string, BinaryData>());
            incompleteRestore = new SelectiveKeyRestoreDetailsInternal(
                "in progress",
                "",
                null,
                JobId,
                DateTimeOffset.Now.AddMinutes(-5),
                null,
                new Dictionary<string, BinaryData>());

            failedResponse = new Mock<Response<SelectiveKeyRestoreDetailsInternal>>();
            failedResponse.SetupGet(m => m.Value).Returns(failedRestore);
        }

        [Test]
        public void UpdateStatusThrowsOnError()
        {
            // setup the GetSelectiveKeyRestoreDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetSelectiveKeyRestoreDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new KeyVaultSelectiveKeyRestoreOperation(mockClient.Object, JobId);

            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            operation = new KeyVaultSelectiveKeyRestoreOperation(mockClient.Object, JobId);

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
            // setup the GetSelectiveKeyRestoreDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetSelectiveKeyRestoreDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(ex);
            mockClient
                .Setup(m => m.GetSelectiveKeyRestoreDetails(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(ex);

            var operation = new KeyVaultSelectiveKeyRestoreOperation(mockClient.Object, JobId);

            Exception result = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            operation = new KeyVaultSelectiveKeyRestoreOperation(mockClient.Object, JobId);

            result = Assert.Throws<RequestFailedException>(() => operation.UpdateStatus(default));
        }

        [Test]
        public void ValueThrowsOnError()
        {
            // setup the GetSelectiveKeyRestoreDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetSelectiveKeyRestoreDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new KeyVaultSelectiveKeyRestoreOperation(mockClient.Object, JobId);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync(default));

            Assert.Throws<RequestFailedException>(() => { KeyVaultSelectiveKeyRestoreResult x = operation.Value; });
            Assert.That(operation.StartTime, Is.EqualTo(failedRestore.StartTime));
            Assert.That(operation.EndTime, Is.EqualTo(failedRestore.EndTime));
        }

        [Test]
        public void ValueThrowsWhenOperationIsNotComplete()
        {
            // setup the GetSelectiveKeyRestoreDetailsAsync to return a failed response
            var mockClient = new Mock<KeyVaultBackupClient>();
            mockClient
                .Setup(m => m.GetSelectiveKeyRestoreDetailsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(failedResponse.Object);

            var operation = new KeyVaultSelectiveKeyRestoreOperation(incompleteRestore, Mock.Of<Response>(), Mock.Of<KeyVaultBackupClient>());

            Assert.Throws<InvalidOperationException>(() => { KeyVaultSelectiveKeyRestoreResult x = operation.Value; });
            Assert.That(operation.StartTime, Is.EqualTo(incompleteRestore.StartTime));
            Assert.That(operation.EndTime, Is.EqualTo(incompleteRestore.EndTime));
        }

        [Test]
        public async Task ValueDoesNotThrowOnNullError()
        {
            DateTimeOffset endTime = DateTimeOffset.FromUnixTimeSeconds(1622154174);

            var transport = new MockTransport(
                new MockResponse(200)
                    .WithContent($@"{{
    ""jobId"": ""{JobId}"",
    ""status"": ""Succeeded"",
    ""startTime"": 1622154134,
    ""endTime"": {endTime.ToUnixTimeSeconds()},
    ""error"": null
}}"));

            var client = new KeyVaultBackupClient(
                new Uri("https://localhost"),
                new MockCredential(),
                new KeyVaultAdministrationClientOptions
                {
                    Transport = transport,
                });

            var operation = new KeyVaultSelectiveKeyRestoreOperation(client, JobId);

            Response response = await operation.UpdateStatusAsync();
            Assert.AreEqual(200, response.Status);

            KeyVaultSelectiveKeyRestoreResult result = operation.Value;
            Assert.AreEqual(endTime, result.EndTime);
        }

        [Test]
        public async Task ValueDoesNotThrowOnEmptyError()
        {
            DateTimeOffset endTime = DateTimeOffset.FromUnixTimeSeconds(1622154174);

            var transport = new MockTransport(
                new MockResponse(200)
                    .WithContent($@"{{
    ""jobId"": ""{JobId}"",
    ""status"": ""Succeeded"",
    ""startTime"": 1622154134,
    ""endTime"": {endTime.ToUnixTimeSeconds()},
    ""error"": {{}}
}}"));

            var client = new KeyVaultBackupClient(
                new Uri("https://localhost"),
                new MockCredential(),
                new KeyVaultAdministrationClientOptions
                {
                    Transport = transport,
                });

            var operation = new KeyVaultSelectiveKeyRestoreOperation(client, JobId);

            Response response = await operation.UpdateStatusAsync();
            Assert.AreEqual(200, response.Status);

            KeyVaultSelectiveKeyRestoreResult result = operation.Value;
            Assert.AreEqual(endTime, result.EndTime);
        }

        [Test]
        public async Task ValueDoesNotThrowOnErrorNullProperties()
        {
            DateTimeOffset endTime = DateTimeOffset.FromUnixTimeSeconds(1622154174);

            var transport = new MockTransport(
                new MockResponse(200)
                    .WithContent($@"{{
    ""jobId"": ""{JobId}"",
    ""status"": ""Succeeded"",
    ""startTime"": 1622154134,
    ""endTime"": {endTime.ToUnixTimeSeconds()},
    ""error"": {{
        ""code"": null,
        ""innererror"": null,
        ""message"": null
    }}
}}"));

            var client = new KeyVaultBackupClient(
                new Uri("https://localhost"),
                new MockCredential(),
                new KeyVaultAdministrationClientOptions
                {
                    Transport = transport,
                });

            var operation = new KeyVaultSelectiveKeyRestoreOperation(client, JobId);

            Response response = await operation.UpdateStatusAsync();
            Assert.AreEqual(200, response.Status);

            KeyVaultSelectiveKeyRestoreResult result = operation.Value;
            Assert.AreEqual(endTime, result.EndTime);
        }
    }
}
