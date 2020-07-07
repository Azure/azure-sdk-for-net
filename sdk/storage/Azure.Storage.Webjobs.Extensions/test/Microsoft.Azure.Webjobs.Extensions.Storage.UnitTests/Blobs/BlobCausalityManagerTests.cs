// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs
{
    public class BlobCausalityManagerTests
    {
        [Fact]
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

        [Fact]
        public void SetWriter_IfNullObject_Throws()
        {
            // Arrange
            Guid g = Guid.NewGuid();

            // Act & Assert
            ExceptionAssert.ThrowsArgumentNull(() => BlobCausalityManager.SetWriter(null, g), "metadata");
        }

        [Fact]
        public void GetWriter_IfMetadataDoesNotHaveWriterProperty_ReturnsNull()
        {
            // Arrange
            Mock<ICloudBlob> blobMock = SetupBlobMock(isFetchSuccess: true);

            // Act
            Guid? writer = BlobCausalityManager.GetWriterAsync(blobMock.Object, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.Null(writer);
            blobMock.Verify();
        }

        [Fact]
        public void GetWriter_IfFetchFails_ReturnsNull()
        {
            // Arrange
            Mock<ICloudBlob> blobMock = SetupBlobMock(isFetchSuccess: false);

            // Act
            Guid? writer = BlobCausalityManager.GetWriterAsync(blobMock.Object, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.Null(writer);
            blobMock.Verify();
        }

        [Fact]
        public void GetWriter_IfMetadataPropertyIsNotGuid_ReturnsNull()
        {
            // Arrange
            Mock<ICloudBlob> blobMock = SetupBlobMock(isFetchSuccess: true);
            blobMock.Object.Metadata[BlobMetadataKeys.ParentId] = "abc";

            // Act
            Guid? writer = BlobCausalityManager.GetWriterAsync(blobMock.Object, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.Null(writer);
            blobMock.Verify();
        }

        [Fact]
        public void GetWriter_IfMetadataPropertyIsGuid_ReturnsThatGuid()
        {
            // Arrange
            Guid expected = Guid.NewGuid();
            Mock<ICloudBlob> blobMock = SetupBlobMock(isFetchSuccess: true);
            blobMock.Object.Metadata[BlobMetadataKeys.ParentId] = expected.ToString();

            // Act
            Guid? writer = BlobCausalityManager.GetWriterAsync(blobMock.Object, CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            Assert.Equal(expected, writer);
            blobMock.Verify();
        }

        private static void AssertWriterEqual(Guid expectedWriter, IDictionary<string, string> metadata)
        {
            Guid? owner = GetWriter(metadata);
            Assert.Equal(expectedWriter, owner);
        }

        private static void AssertWriterIsNull(IDictionary<string, string> metadata)
        {
            Guid? writer = GetWriter(metadata);
            Assert.Null(writer);
        }

        private static Mock<ICloudBlob> SetupBlobMock(bool? isFetchSuccess = null)
        {
            Dictionary<string, string> metadata = new Dictionary<string, string>();
            var blobMock = new Mock<ICloudBlob>(MockBehavior.Strict);
            blobMock.Setup(s => s.Metadata).Returns(metadata);
            
            if (isFetchSuccess.HasValue)
            {
                var fetchAttributesSetup = blobMock.Setup(s => s.FetchAttributesAsync());
                if (isFetchSuccess.Value)
                {
                    fetchAttributesSetup.Returns(Task.FromResult(0));
                }
                else
                {
                    RequestResult requestResult = new RequestResult();
                    requestResult.HttpStatusCode = 404;
                    StorageException blobNotFoundException = new StorageException(requestResult, String.Empty, null);
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
