// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    public class BlobCausalityManagerTests
    {
        [Test]
        public void SetWriter_IfValidGuid_AddsWriter()
        {
            // Arrange
            IDictionary<string, string> metadata = new Dictionary<string, string>();
            Guid g = Guid.NewGuid();

            // Act
            BlobCausalityManager.SetWriter(metadata, g);

            // Assert
            AssertWriterEqual(g, metadata);
        }

        [Test]
        public void SetWriter_IfNullObject_Throws()
        {
            // Arrange
            Guid g = Guid.NewGuid();

            // Act & Assert
            ExceptionAssert.ThrowsArgumentNull(() => BlobCausalityManager.SetWriter(null, g), "metadata");
        }

        [Test]
        public void GetWriter_IfMetadataDoesNotHaveWriterProperty_ReturnsNull()
        {
            // Arrange
            Mock<BlobBaseClient> blobMock = SetupBlobMock(isFetchSuccess: true);

            // Act
            Guid? writer = BlobCausalityManager.GetWriterAsync(blobMock.Object, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.Null(writer);
            blobMock.Verify();
        }

        [Test]
        public void GetWriter_IfFetchFails_ReturnsNull()
        {
            // Arrange
            Mock<BlobBaseClient> blobMock = SetupBlobMock(isFetchSuccess: false);

            // Act
            Guid? writer = BlobCausalityManager.GetWriterAsync(blobMock.Object, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.Null(writer);
            blobMock.Verify();
        }

        [Test]
        public void GetWriter_IfMetadataPropertyIsNotGuid_ReturnsNull()
        {
            // Arrange
            Mock<BlobBaseClient> blobMock = SetupBlobMock(
                isFetchSuccess: true,
                new Dictionary<string, string>() { { BlobMetadataKeys.ParentId, "abc" } });

            // Act
            Guid? writer = BlobCausalityManager.GetWriterAsync(blobMock.Object, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.Null(writer);
            blobMock.Verify();
        }

        [Test]
        public void GetWriter_IfMetadataPropertyIsGuid_ReturnsThatGuid()
        {
            // Arrange
            Guid expected = Guid.NewGuid();
            Mock<BlobBaseClient> blobMock = SetupBlobMock(
                isFetchSuccess: true,
                new Dictionary<string, string>() { { BlobMetadataKeys.ParentId, expected.ToString() } });

            // Act
            Guid? writer = BlobCausalityManager.GetWriterAsync(blobMock.Object, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.AreEqual(expected, writer);
            blobMock.Verify();
        }

        private static void AssertWriterEqual(Guid expectedWriter, IDictionary<string, string> metadata)
        {
            Guid? owner = GetWriter(metadata);
            Assert.AreEqual(expectedWriter, owner);
        }

        private static Mock<BlobBaseClient> SetupBlobMock(bool? isFetchSuccess = null, Dictionary<string, string> metadata = null)
        {
            if (metadata == null)
            {
                metadata = new Dictionary<string, string>();
            }
            var blobMock = new Mock<BlobBaseClient>(MockBehavior.Strict);

            if (isFetchSuccess.HasValue)
            {
                var fetchAttributesSetup = blobMock.Setup(s => s.GetPropertiesAsync(null, It.IsAny<CancellationToken>()));
                if (isFetchSuccess.Value)
                {
                    var blobProperties = BlobsModelFactory.BlobProperties(metadata: metadata);
                    fetchAttributesSetup.Returns(Task.FromResult(Response.FromValue(blobProperties, null)));
                }
                else
                {
                    var blobNotFoundException = new RequestFailedException(404, string.Empty);
                    fetchAttributesSetup.Throws(blobNotFoundException);
                }
                fetchAttributesSetup.Verifiable();
            }

            return blobMock;
        }

        private static Guid? GetWriter(IDictionary<string, string> metadata)
        {
            if (!metadata.ContainsKey(BlobMetadataKeys.ParentId))
            {
                return null;
            }

            string val = metadata[BlobMetadataKeys.ParentId];
            Guid result;
            if (Guid.TryParse(val, out result))
            {
                return result;
            }

            return null;
        }
    }
}
