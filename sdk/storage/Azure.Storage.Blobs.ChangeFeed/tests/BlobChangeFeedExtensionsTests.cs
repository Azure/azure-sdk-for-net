// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    /// <summary>
    /// Verifies that the public <see cref="BlobChangeFeedExtensions.GetChangeFeedClient"/>
    /// extension constructs a working <see cref="BlobChangeFeedClient"/> regardless of
    /// the credential the source <see cref="BlobServiceClient"/> was built with.
    /// </summary>
    public class BlobChangeFeedExtensionsTests : ChangeFeedTestBase
    {
        private static readonly Uri BlobServiceUri = new Uri("https://account.blob.core.windows.net");

        public BlobChangeFeedExtensionsTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        [Test]
        public void BlobServiceClient_SharedKey_PropagatesCredentialToChangeFeedClient()
        {
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(
                "account",
                Convert.ToBase64String(new byte[64]));
            BlobServiceClient serviceClient = new BlobServiceClient(BlobServiceUri, credential);

            BlobChangeFeedClient changeFeedClient = serviceClient.GetChangeFeedClient();

            Assert.IsNotNull(changeFeedClient);
            Assert.AreSame(serviceClient, changeFeedClient._blobServiceClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/$blobchangefeed",
                changeFeedClient._containerClient.Uri.ToString());
        }

        [Test]
        public void BlobServiceClient_TokenCredential_PropagatesCredentialToChangeFeedClient()
        {
            BlobServiceClient serviceClient = new BlobServiceClient(BlobServiceUri, new MockCredential());

            BlobChangeFeedClient changeFeedClient = serviceClient.GetChangeFeedClient();

            Assert.IsNotNull(changeFeedClient);
            Assert.AreSame(serviceClient, changeFeedClient._blobServiceClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/$blobchangefeed",
                changeFeedClient._containerClient.Uri.ToString());
        }

        [Test]
        public void BlobServiceClient_SasToken_PreservesSasInContainerEndpoint()
        {
            Uri serviceUriWithSas = new Uri("https://account.blob.core.windows.net?sv=2024-01-01&ss=b&srt=sco&sig=fakesig");
            BlobServiceClient serviceClient = new BlobServiceClient(serviceUriWithSas);

            BlobChangeFeedClient changeFeedClient = serviceClient.GetChangeFeedClient();

            Assert.IsNotNull(changeFeedClient);
            string containerUri = changeFeedClient._containerClient.Uri.ToString();
            Assert.That(containerUri, Does.StartWith("https://account.blob.core.windows.net/$blobchangefeed"));
            Assert.That(containerUri, Does.Contain("sig=fakesig"));
        }

        [Test]
        public void BlobServiceClient_NullOptions_StillReturnsClient()
        {
            BlobServiceClient serviceClient = new BlobServiceClient(BlobServiceUri);

            // Calling GetChangeFeedClient without options should produce a client with default options.
            BlobChangeFeedClient changeFeedClient = serviceClient.GetChangeFeedClient(options: null);

            Assert.IsNotNull(changeFeedClient);
            Assert.IsFalse(changeFeedClient._includeNonFinalizedEvents);
            Assert.IsNull(changeFeedClient._maxTransferSize);
        }

        [Test]
        public void BlobServiceClient_OptionsFlowThroughToChangeFeedClient()
        {
            BlobServiceClient serviceClient = new BlobServiceClient(BlobServiceUri);
            BlobChangeFeedClientOptions options = new BlobChangeFeedClientOptions
            {
                IncludeNonFinalizedEvents = true,
                MaximumTransferSize = 8 * 1024 * 1024,
            };

            BlobChangeFeedClient changeFeedClient = serviceClient.GetChangeFeedClient(options);

            Assert.IsTrue(changeFeedClient._includeNonFinalizedEvents);
            Assert.AreEqual(8 * 1024 * 1024L, changeFeedClient._maxTransferSize);
        }
    }
}
