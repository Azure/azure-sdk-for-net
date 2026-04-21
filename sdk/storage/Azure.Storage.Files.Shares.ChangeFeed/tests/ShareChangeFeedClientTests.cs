// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Verifies that <see cref="ShareChangeFeedClient"/> constructors correctly
    /// create both the internal <see cref="Azure.Storage.Files.Shares.ShareClient"/>
    /// and <see cref="Azure.Storage.Blobs.BlobServiceClient"/> for each supported
    /// authentication type.
    /// </summary>
    public class ShareChangeFeedClientConstructorTests : ShareChangeFeedTestBase
    {
        private const string TestShareName = "myshare";
        private static readonly Uri FileServiceUri = new Uri("https://account.file.core.windows.net");
        private static readonly Uri FileServiceUriWithSas = new Uri("https://account.file.core.windows.net?sv=2024-01-01&ss=f&srt=sco&sig=fakesig");

        public ShareChangeFeedClientConstructorTests(
            bool async,
            ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        [Test]
        public void Constructor_SharedKey_CreatesBlobClientWithBlobEndpoint()
        {
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(
                "account",
                Convert.ToBase64String(new byte[64]));

            ShareChangeFeedClient client = new ShareChangeFeedClient(
                FileServiceUri,
                TestShareName,
                credential);

            Assert.IsNotNull(client._blobServiceClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/",
                client._blobServiceClient.Uri.ToString());
        }

        [Test]
        public void Constructor_TokenCredential_CreatesBlobClientWithBlobEndpoint()
        {
            MockCredential credential = new MockCredential();

            ShareChangeFeedClient client = new ShareChangeFeedClient(
                FileServiceUri,
                TestShareName,
                credential);

            Assert.IsNotNull(client._blobServiceClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/",
                client._blobServiceClient.Uri.ToString());
        }

        [Test]
        public void Constructor_SasUri_CreatesBlobClientWithSasPreserved()
        {
            ShareChangeFeedClient client = new ShareChangeFeedClient(
                FileServiceUriWithSas,
                TestShareName);

            Assert.IsNotNull(client._blobServiceClient);
            string blobUri = client._blobServiceClient.Uri.ToString();
            Assert.That(blobUri, Does.StartWith("https://account.blob.core.windows.net/"));
            Assert.That(blobUri, Does.Contain("sig=fakesig"));
        }

        [Test]
        public void Constructor_ConnectionString_CreatesBlobClient()
        {
            string connectionString =
                "DefaultEndpointsProtocol=https;" +
                "AccountName=account;" +
                "AccountKey=" + Convert.ToBase64String(new byte[64]) + ";" +
                "EndpointSuffix=core.windows.net";

            ShareChangeFeedClient client = new ShareChangeFeedClient(
                connectionString,
                TestShareName);

            Assert.IsNotNull(client._blobServiceClient);
        }

        [Test]
        public void Constructor_NullUri_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new ShareChangeFeedClient(
                    (Uri)null,
                    TestShareName));
        }

        [Test]
        public void Constructor_NullShareName_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new ShareChangeFeedClient(
                    FileServiceUri,
                    null));
        }

        [Test]
        public void Constructor_EmptyShareName_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new ShareChangeFeedClient(
                    FileServiceUri,
                    string.Empty));
        }
    }
}
