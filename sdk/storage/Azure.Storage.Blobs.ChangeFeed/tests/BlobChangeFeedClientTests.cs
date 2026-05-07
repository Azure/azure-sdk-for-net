// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    /// <summary>
    /// Verifies that <see cref="BlobChangeFeedClient"/> constructors correctly
    /// create the internal <see cref="BlobServiceClient"/> for each supported
    /// authentication type, that options flow through, and that public methods
    /// validate inputs.
    /// </summary>
    public class BlobChangeFeedClientTests : ChangeFeedTestBase
    {
        private static readonly Uri BlobServiceUri = new Uri("https://account.blob.core.windows.net");
        private static readonly Uri BlobServiceUriWithSas = new Uri("https://account.blob.core.windows.net?sv=2024-01-01&ss=b&srt=sco&sig=fakesig");

        public BlobChangeFeedClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        [Test]
        public void Constructor_SharedKey_CreatesContainerClientPointingAtChangeFeedContainer()
        {
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(
                "account",
                Convert.ToBase64String(new byte[64]));

            BlobChangeFeedClient client = new BlobChangeFeedClient(
                BlobServiceUri,
                credential);

            Assert.IsNotNull(client._blobServiceClient);
            Assert.IsNotNull(client._containerClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/$blobchangefeed",
                client._containerClient.Uri.ToString());
        }

        [Test]
        public void Constructor_TokenCredential_CreatesContainerClientPointingAtChangeFeedContainer()
        {
            MockCredential credential = new MockCredential();

            BlobChangeFeedClient client = new BlobChangeFeedClient(
                BlobServiceUri,
                credential);

            Assert.IsNotNull(client._blobServiceClient);
            Assert.IsNotNull(client._containerClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/$blobchangefeed",
                client._containerClient.Uri.ToString());
        }

        [Test]
        public void Constructor_SasCredential_CreatesContainerClientPointingAtChangeFeedContainer()
        {
            AzureSasCredential credential = new AzureSasCredential("sv=2024-01-01&ss=b&srt=sco&sig=fakesig");

            BlobChangeFeedClient client = new BlobChangeFeedClient(
                BlobServiceUri,
                credential);

            Assert.IsNotNull(client._blobServiceClient);
            Assert.IsNotNull(client._containerClient);
            string containerUri = client._containerClient.Uri.ToString();
            Assert.That(containerUri, Does.StartWith("https://account.blob.core.windows.net/$blobchangefeed"));
        }

        [Test]
        public void Constructor_SasUri_CreatesContainerClientPointingAtChangeFeedContainer()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(BlobServiceUriWithSas);

            Assert.IsNotNull(client._blobServiceClient);
            Assert.IsNotNull(client._containerClient);
            string containerUri = client._containerClient.Uri.ToString();
            Assert.That(containerUri, Does.StartWith("https://account.blob.core.windows.net/$blobchangefeed"));
            Assert.That(containerUri, Does.Contain("sig=fakesig"));
        }

        [Test]
        public void Constructor_ConnectionString_CreatesContainerClient()
        {
            string connectionString =
                "DefaultEndpointsProtocol=https;" +
                "AccountName=account;" +
                "AccountKey=" + Convert.ToBase64String(new byte[64]) + ";" +
                "EndpointSuffix=core.windows.net";

            BlobChangeFeedClient client = new BlobChangeFeedClient(connectionString);

            Assert.IsNotNull(client._blobServiceClient);
            Assert.IsNotNull(client._containerClient);
            Assert.AreEqual(
                "https://account.blob.core.windows.net/$blobchangefeed",
                client._containerClient.Uri.ToString());
        }

        [Test]
        public void Constructor_NullUri_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new BlobChangeFeedClient((Uri)null));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_NullOrEmptyConnectionString_Throws(string connectionString)
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new BlobChangeFeedClient(connectionString));
            Assert.AreEqual("connectionString", ex.ParamName);
        }

        [Test]
        public void Constructor_IncludeNonFinalizedEvents_DefaultsToFalse()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(BlobServiceUriWithSas);

            Assert.IsFalse(client._includeNonFinalizedEvents);
        }

        [Test]
        public void Constructor_IncludeNonFinalizedEvents_FlowsFromOptions()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(
                BlobServiceUriWithSas,
                options: default,
                changeFeedOptions: new BlobChangeFeedClientOptions { IncludeNonFinalizedEvents = true });

            Assert.IsTrue(client._includeNonFinalizedEvents);
        }

        [Test]
        public void Constructor_MaximumTransferSize_DefaultsToNull()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(BlobServiceUriWithSas);

            Assert.IsNull(client._maxTransferSize);
        }

        [Test]
        public void Constructor_MaximumTransferSize_FlowsFromOptions()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(
                BlobServiceUriWithSas,
                options: default,
                changeFeedOptions: new BlobChangeFeedClientOptions { MaximumTransferSize = 4 * 1024 * 1024 });

            Assert.AreEqual(4 * 1024 * 1024L, client._maxTransferSize);
        }

        // GetChanges(continuationToken) must reject any non-null continuation when
        // IncludeNonFinalizedEvents is enabled, since pages produced in that mode
        // never carry a continuation token.

        [Test]
        public void GetChanges_WithContinuation_IncludeNonFinalizedEventsTrue_Throws()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(
                BlobServiceUriWithSas,
                options: default,
                changeFeedOptions: new BlobChangeFeedClientOptions { IncludeNonFinalizedEvents = true });

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => client.GetChanges("any-continuation-token"));

            StringAssert.Contains(nameof(BlobChangeFeedClientOptions.IncludeNonFinalizedEvents), ex.Message);
            Assert.AreEqual("continuationToken", ex.ParamName);
        }

        [Test]
        public void GetChangesAsync_WithContinuation_IncludeNonFinalizedEventsTrue_Throws()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(
                BlobServiceUriWithSas,
                options: default,
                changeFeedOptions: new BlobChangeFeedClientOptions { IncludeNonFinalizedEvents = true });

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => client.GetChangesAsync("any-continuation-token"));

            StringAssert.Contains(nameof(BlobChangeFeedClientOptions.IncludeNonFinalizedEvents), ex.Message);
            Assert.AreEqual("continuationToken", ex.ParamName);
        }

        [Test]
        public void GetChanges_WithContinuation_IncludeNonFinalizedEventsFalse_DoesNotThrow()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(
                BlobServiceUriWithSas,
                options: default,
                changeFeedOptions: new BlobChangeFeedClientOptions { IncludeNonFinalizedEvents = false });

            // Constructing the pageable should not throw; we deliberately do not enumerate
            // (which would issue a service call against the synthetic SAS URI).
            Assert.DoesNotThrow(() => client.GetChanges("any-continuation-token"));
            Assert.DoesNotThrow(() => client.GetChangesAsync("any-continuation-token"));
        }

        [Test]
        public void GetChanges_StartGreaterThanEnd_Throws()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(BlobServiceUriWithSas);

            DateTimeOffset start = new DateTimeOffset(2024, 6, 1, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset end = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => client.GetChanges(start, end));

            Assert.AreEqual("start", ex.ParamName);
            StringAssert.Contains(start.ToString("O"), ex.Message);
            StringAssert.Contains(end.ToString("O"), ex.Message);
        }

        [Test]
        public void GetChangesAsync_StartGreaterThanEnd_Throws()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(BlobServiceUriWithSas);

            DateTimeOffset start = new DateTimeOffset(2024, 6, 1, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset end = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => client.GetChangesAsync(start, end));

            Assert.AreEqual("start", ex.ParamName);
            StringAssert.Contains(start.ToString("O"), ex.Message);
            StringAssert.Contains(end.ToString("O"), ex.Message);
        }

        [Test]
        public void GetChanges_StartEqualsEnd_DoesNotThrow()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(BlobServiceUriWithSas);

            DateTimeOffset boundary = new DateTimeOffset(2024, 3, 15, 12, 0, 0, TimeSpan.Zero);

            // A zero-duration interval is well-formed (will return empty); the public-API
            // guard rejects only strict start > end.
            Assert.DoesNotThrow(() => client.GetChanges(boundary, boundary));
            Assert.DoesNotThrow(() => client.GetChangesAsync(boundary, boundary));
        }

        [Test]
        public void GetChanges_StartOrEndNull_DoesNotThrow()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(BlobServiceUriWithSas);

            DateTimeOffset t = new DateTimeOffset(2024, 3, 15, 12, 0, 0, TimeSpan.Zero);

            // Either-side-null cases bypass the guard entirely; this protects the
            // HasValue short-circuit from being tightened by accident.
            Assert.DoesNotThrow(() => client.GetChanges(null, null));
            Assert.DoesNotThrow(() => client.GetChanges(t, null));
            Assert.DoesNotThrow(() => client.GetChanges(null, t));
            Assert.DoesNotThrow(() => client.GetChangesAsync(null, null));
            Assert.DoesNotThrow(() => client.GetChangesAsync(t, null));
            Assert.DoesNotThrow(() => client.GetChangesAsync(null, t));
        }
    }
}
