// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class ServerTimeoutTests
    {
        private const int ServerTimeoutSeconds = 15;
        private static TimeSpan ServerTimeout = TimeSpan.FromSeconds(ServerTimeoutSeconds);
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
            _transport = new MockTransport(r => new MockResponse(404));
            _clientOptions = new BlobClientOptions()
            {
                Transport = _transport
            };
        }

        [Test]
        public void AddsTimeoutToQuery()
        {
            // Arrange
            var client = new BlobServiceClient(_endpoint, _credentials, _clientOptions);

            // Act
            using (StorageExtensions.CreateServiceTimeoutScope(ServerTimeout))
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetPropertiesAsync());
            }

            // Assert
            StringAssert.Contains($"timeout={ServerTimeoutSeconds}", _transport.SingleRequest.Uri.ToString());
        }
    }
}
