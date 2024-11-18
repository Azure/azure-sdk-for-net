// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Blobs.Tests
{
    public class AzureBlobXmlRepositoryTests
    {
        [Test]
        public void StoreCreatesBlobWhenNotExist()
        {
            BlobRequestConditions uploadConditions = null;
            byte[] bytes = null;
            string contentType = null;

            var mock = new Mock<BlobClient>();

            mock.Setup(c => c.Upload(
                    It.IsAny<Stream>(),
                    It.IsAny<BlobHttpHeaders>(),
                    It.IsAny<IDictionary<string, string>>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<IProgress<long>>(),
                    It.IsAny<AccessTier?>(),
                    It.IsAny<StorageTransferOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns((Stream strm, BlobHttpHeaders headers, IDictionary<string, string> metaData, BlobRequestConditions conditions, IProgress<long> progress, AccessTier? access, StorageTransferOptions transfer, CancellationToken token) =>
                {
                    using var memoryStream = new MemoryStream();
                    strm.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                    uploadConditions = conditions;
                    contentType = headers?.ContentType;

                    var mockResponse = new Mock<Response<BlobContentInfo>>();
                    var blobContentInfo = BlobsModelFactory.BlobContentInfo(ETag.All, DateTimeOffset.Now.AddDays(-1), Array.Empty<byte>(), "", 1);

                    mockResponse.Setup(c => c.Value).Returns(blobContentInfo);
                    return mockResponse.Object;
                });

            var repository = new AzureBlobXmlRepository(mock.Object);
            repository.StoreElement(new XElement("Element"), null);

            Assert.AreEqual("*", uploadConditions.IfNoneMatch.ToString());
            Assert.AreEqual("application/xml; charset=utf-8", contentType);
            var element = "<Element />";

            Assert.AreEqual(bytes, GetEnvelopedContent(element));
        }

        [Test]
        public void StoreUpdatesWhenExistsAndNewerExists()
        {
            byte[] bytes = null;

            var mock = new Mock<BlobClient>();

            mock.Setup(c => c.DownloadTo(
                    It.IsAny<Stream>(),
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<StorageTransferOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns((Stream target, BlobRequestConditions conditions, StorageTransferOptions options, CancellationToken token) =>
                {
                    var data = GetEnvelopedContent("<Element1 />");
                    target.Write(data, 0, data.Length);

                    var response = new MockResponse(200);
                    response.AddHeader(new HttpHeader("ETag", "*"));
                    return response;
                })
                .Verifiable();

            mock.Setup(c => c.Upload(
                    It.IsAny<Stream>(),
                    It.IsAny<BlobHttpHeaders>(),
                    It.IsAny<IDictionary<string, string>>(),
                    It.Is((BlobRequestConditions conditions) => conditions.IfNoneMatch == ETag.All),
                    It.IsAny<IProgress<long>>(),
                    It.IsAny<AccessTier?>(),
                    It.IsAny<StorageTransferOptions>(),
                    It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(status: 412, message: ""))
                .Verifiable();

            mock.Setup(c => c.Upload(
                    It.IsAny<Stream>(),
                    It.IsAny<BlobHttpHeaders>(),
                    It.IsAny<IDictionary<string, string>>(),
                    It.Is((BlobRequestConditions conditions) => conditions.IfNoneMatch != ETag.All),
                    It.IsAny<IProgress<long>>(),
                    It.IsAny<AccessTier?>(),
                    It.IsAny<StorageTransferOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns((Stream strm, BlobHttpHeaders headers, IDictionary<string, string> metaData, BlobRequestConditions conditions, IProgress<long> progress, AccessTier? access, StorageTransferOptions transfer, CancellationToken token) =>
                {
                    using var memoryStream = new MemoryStream();
                    strm.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();

                    var mockResponse = new Mock<Response<BlobContentInfo>>();
                    var blobContentInfo = BlobsModelFactory.BlobContentInfo(ETag.All, DateTimeOffset.Now.AddDays(-1), Array.Empty<byte>(), "", 1);
                    mockResponse.Setup(c => c.Value).Returns(blobContentInfo);
                    return mockResponse.Object;
                })
                .Verifiable();

            var repository = new AzureBlobXmlRepository(mock.Object);
            repository.StoreElement(new XElement("Element2"), null);

            mock.Verify();
            Assert.AreEqual(bytes, GetEnvelopedContent("<Element1 /><Element2 />"));
        }

        private static byte[] GetEnvelopedContent(string element)
        {
            return Encoding.UTF8.GetBytes($"﻿<?xml version=\"1.0\" encoding=\"utf-8\"?><repository>{element}</repository>");
        }
    }
}
