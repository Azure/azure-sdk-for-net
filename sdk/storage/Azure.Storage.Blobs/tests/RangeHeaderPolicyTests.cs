// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class RangeHeaderPolicyTests
    {
        private StorageSharedKeyCredential _credentials;
        private Uri _endpoint;
        private MockTransport _transport;
        private BlobClientOptions _clientOptions;

        [SetUp]
        public void Setup()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            _endpoint = new Uri("http://127.0.0.1/" + accountName);
            _credentials = new StorageSharedKeyCredential(accountName, accountKey);
        }

        [Test]
        public async Task RangeHeader_IsTransformedTo_XMsRange()
        {
            _transport = new MockTransport(r =>
            {
                var response = new MockResponse(206);
                response.ContentStream = new MemoryStream(new byte[100]);
                response.AddHeader("Content-Range", "bytes 0-99/100");
                return response;
            });
            _clientOptions = new BlobClientOptions()
            {
                Transport = _transport
            };
            var containerName = "container";
            var blobName = "blob";
            var blobUri = new Uri(_endpoint, $"{containerName}/{blobName}");
            var client = new BlobBaseClient(blobUri, _credentials, _clientOptions);

            try
            {
                await client.DownloadContentAsync(new BlobDownloadOptions
                {
                    Range = new HttpRange(0, 100)
                });
            }
            catch (RequestFailedException)
            {
                // Expected — mock returns minimal response
            }

            // Assert
            var request = _transport.Requests.First();
            Assert.IsTrue(request.Headers.TryGetValue("x-ms-range", out string xmsRangeValue));
            Assert.AreEqual("bytes=0-99", xmsRangeValue);
            Assert.IsFalse(request.Headers.TryGetValue("Range", out _), "Range header should have been removed");
        }

        [Test]
        public async Task NoRangeHeader_IsNotModified()
        {
            // Arrange
            _transport = new MockTransport(r => new MockResponse(404));
            _clientOptions = new BlobClientOptions()
            {
                Transport = _transport
            };
            var client = new BlobServiceClient(_endpoint, _credentials, _clientOptions);

            try
            {
                await client.GetPropertiesAsync();
            }
            catch (RequestFailedException)
            {
                // Expected
            }

            // Assert
            var request = _transport.Requests.First();
            Assert.IsFalse(request.Headers.TryGetValue("x-ms-range", out _), "x-ms-range should not be present when Range was not set");
            Assert.IsFalse(request.Headers.TryGetValue("Range", out _), "Range should not be present when it was not set");
        }
    }
}
