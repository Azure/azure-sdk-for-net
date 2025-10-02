// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class BlobLogListenerTests
    {
        [TestCase("write", 1, null, 0, true, TestName = "HasBlobWritesAsync_WriteLogPresent_ReturnsTrue")]
        [TestCase("read", 1, null, 0, false, TestName = "HasBlobWritesAsync_NonWriteLogPresent_ReturnsFalse")]
        [TestCase(null, 1, null, 0, false, TestName = "HasBlobWritesAsync_NoBlobs_ReturnsFalse")]
        [TestCase("read", 100, "write", 1, true, TestName = "HasBlobWritesAsync_WriteLogPresentMultipleLogBlobs_ReturnsTrue")]
        [TestCase("delete", 100, "read", 100, false, TestName = "HasBlobWritesAsync_NonWriteLogPresentMultipleLogBlobs_ReturnsFalse")]
        public async Task HasBlobWritesAsync_VariousCases(string logType1, int logType1Count, string logType2, int logType2Count, bool expected)
        {
            // Arrange
            var blobServiceClientMock = new Mock<BlobServiceClient>(MockBehavior.Strict);
            var containerClientMock = new Mock<BlobContainerClient>(MockBehavior.Strict);

            TestAsyncPageable<BlobItem> pageable;
            var blobItems = new List<BlobItem>();
            if (logType1 != null)
            {
                for (int i = 0; i < logType1Count; i++)
                {
                    var blobItem = BlobItemFactory.Create(
                        name: Guid.NewGuid().ToString(),
                        metadata: new Dictionary<string, string> { { "LogType", logType1 } });
                    blobItems.Add(blobItem);
                }
            }
            if (logType2 != null)
            {
                for (int i = 0; i < logType2Count; i++)
                {
                    var blobItem = BlobItemFactory.Create(
                        name: Guid.NewGuid().ToString(),
                        metadata: new Dictionary<string, string> { { "LogType", logType2 } });
                    blobItems.Add(blobItem);
                }
            }

            if (blobItems.Count == 0)
            {
                pageable = new TestAsyncPageable<BlobItem>(Enumerable.Empty<BlobItem>());
            }
            else
            {
                pageable = new TestAsyncPageable<BlobItem>(blobItems);
            }

            containerClientMock
                .Setup(c => c.GetBlobsAsync(
                    It.IsAny<BlobTraits>(),
                    It.IsAny<BlobStates>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(pageable);

            blobServiceClientMock
                .Setup(c => c.GetBlobContainerClient("$logs"))
                .Returns(containerClientMock.Object);

            var listener = new BlobLogListener(blobServiceClientMock.Object, NullLogger<BlobListener>.Instance);

            // Act
            bool result = await listener.HasBlobWritesAsync(CancellationToken.None, hoursWindow: 1);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetPathsForValidBlobWrites_Returns_ValidBlobWritesOnly()
        {
            StorageAnalyticsLogEntry[] entries = new[]
            {
                new StorageAnalyticsLogEntry
                {
                    ServiceType = StorageServiceType.Blob,
                    OperationType = StorageServiceOperationType.PutBlob,
                    RequestedObjectKey = @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt"
                },
                new StorageAnalyticsLogEntry
                {
                    ServiceType = StorageServiceType.Blob,
                    OperationType = StorageServiceOperationType.PutBlob,
                    RequestedObjectKey = "/"
                },
                new StorageAnalyticsLogEntry
                {
                    ServiceType = StorageServiceType.Blob,
                    OperationType = null,
                    RequestedObjectKey = @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt"
                }
            };

            IEnumerable<BlobPath> validPaths = BlobLogListener.GetPathsForValidBlobWrites(entries);

            BlobPath singlePath = validPaths.Single();
            Assert.AreEqual("sample-container", singlePath.ContainerName);
            Assert.AreEqual(@"""0x8D199A96CB71468""/sample-blob.txt", singlePath.BlobName);
        }

        private static class BlobItemFactory
        {
            private static readonly Type BlobItemType = typeof(BlobItem);
            private static readonly System.Reflection.PropertyInfo NameProp = BlobItemType.GetProperty(nameof(BlobItem.Name))!;
            private static readonly System.Reflection.PropertyInfo MetadataProp = BlobItemType.GetProperty(nameof(BlobItem.Metadata))!;

            public static BlobItem Create(string name, IDictionary<string, string> metadata)
            {
                var ctor = BlobItemType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, binder: null, types: Type.EmptyTypes, modifiers: null)
                          ?? throw new InvalidOperationException("BlobItem internal constructor not found.");
                object raw = ctor.Invoke(null);

                NameProp.SetValue(raw, name);
                var dict = new Dictionary<string, string>(metadata, StringComparer.OrdinalIgnoreCase);
                MetadataProp.SetValue(raw, dict);

                return (BlobItem)raw;
            }
        }

        private sealed class TestAsyncPageable<T> : AsyncPageable<T>
        {
            private readonly IReadOnlyList<Page<T>> _pages;

            public TestAsyncPageable(IEnumerable<T> items)
            {
                var list = items.ToList();
                var responseMock = new Mock<Response>();
                responseMock.Setup(r => r.Status).Returns(200);
                responseMock.Setup(r => r.ClientRequestId).Returns(Guid.NewGuid().ToString());

                _pages = new[]
                {
                    Page<T>.FromValues(list, continuationToken: null, response: responseMock.Object)
                };
            }

            public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (var p in _pages)
                {
                    yield return p;
                    await Task.Yield();
                }
            }
        }
    }
}