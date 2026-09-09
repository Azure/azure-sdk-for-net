// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class AppendBlobWriteStreamTests
    {
        private static readonly UploadTransferValidationOptions s_validationOptions = new UploadTransferValidationOptions
        {
            ChecksumAlgorithm = StorageChecksumAlgorithm.None
        };

        [TestCase(0)]
        [TestCase(Constants.Blob.Append.MaxAppendBlockBytes + 1)]
        public void ConstructorRejectsInvalidBufferSize(long bufferSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CreateStream(bufferSize));
        }

        [Test]
        public void FlushWithEmptyBufferDoesNotAppend()
        {
            var transport = new MockTransport(_ => throw new AssertionException("The empty buffer should not be appended."));
            AppendBlobWriteStream stream = CreateStream(1024, transport, position: 5);

            stream.Flush();

            Assert.AreEqual(5, stream.Position);
        }

        [Test]
        public void FlushAppendsBufferAndUpdatesConditions()
        {
            const string expectedEtag = "\"etag\"";
            var transport = new MockTransport(_ => new MockResponse(201)
                .WithHeader("ETag", expectedEtag)
                .WithHeader("x-ms-blob-committed-block-count", "1"));
            var conditions = new AppendBlobRequestConditions();
            AppendBlobWriteStream stream = CreateStream(1024, transport, conditions: conditions);

            stream.Write(new byte[] { 1, 2, 3 }, 0, 3);
            stream.Flush();

            Assert.AreEqual(3, stream.Position);
            Assert.AreEqual(expectedEtag, conditions.IfMatch.ToString());
        }

        private static AppendBlobWriteStream CreateStream(
            long bufferSize,
            MockTransport transport = null,
            long position = 0,
            AppendBlobRequestConditions conditions = null)
        {
            var options = new BlobClientOptions();
            options.Transport = transport ?? new MockTransport(_ => new MockResponse(201)
                .WithHeader("ETag", "\"etag\"")
                .WithHeader("x-ms-blob-committed-block-count", "1"));
            var client = new AppendBlobClient(new Uri("https://account.blob.core.windows.net/container/blob"), options);
            return new AppendBlobWriteStream(client, bufferSize, position, conditions, progressHandler: null, s_validationOptions);
        }
    }
}
