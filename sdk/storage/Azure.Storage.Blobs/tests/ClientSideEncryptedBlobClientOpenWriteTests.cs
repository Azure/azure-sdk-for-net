// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    /// <summary>
    /// Runs <see cref="BlobClientOpenWriteTests"/> but with client-side encryption enabled.
    /// Requires a derived class instead of parameterizing the parent class because
    /// client-side encryption tests require a <see cref="LiveOnlyAttribute"/>, which is
    /// difficult to add onto only one test fixture parameter value and not others.
    /// </summary>
    [LiveOnly]
    public class ClientSideEncryptedBlobClientOpenWriteTests : BlobClientOpenWriteTests
    {
        public ClientSideEncryptedBlobClientOpenWriteTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            // Validate every test actually used client-side encryption when writing a blob.
            AdditionalAssertions += async (client) =>
            {
                IDictionary<string, string> metadata = (await client.GetPropertiesAsync()).Value.Metadata;
                Assert.IsTrue(metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
            };
        }

        protected override BlobClient GetResourceClient(BlobContainerClient container, string resourceName = null, BlobClientOptions options = null)
        {
            options ??= ClientBuilder.GetOptions();
            options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(expectedCancellationToken: default).Object,
                KeyWrapAlgorithm = ClientSideEncryptionTestExtensions.s_algorithmName
            };

            return base.GetResourceClient(container, resourceName, options);
        }

        #region Test Overrides
        /// <summary>
        /// Need to change assertions for a metadata test.
        /// Client-side encryption alters metadata.
        /// </summary>
        [Test]
        public override async Task OpenWriteAsync_CreateEmptyBlob_WithMetadata()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            BlobClient client = GetResourceClient(disposingContainer.Container);
            await InitializeResourceAsync(client);

            Dictionary<string, string> metadata = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            // Act
            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                bufferSize: bufferSize,
                metadata: metadata))
            {
            }

            // Assert
            var downloadedMetadata = await GetMetadataAsync(client);
            Assert.AreEqual(metadata.Count + 1, downloadedMetadata.Count);
            CollectionAssert.IsSubsetOf(metadata, downloadedMetadata);
            Assert.IsTrue(downloadedMetadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        /// <summary>
        /// Need to change assertions for a metadata test.
        /// Client-side encryption alters metadata.
        /// </summary>
        [Test]
        public override async Task OpenWriteAsync_NewBlob_WithMetadata()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            BlobClient client = GetResourceClient(disposingContainer.Container);
            await InitializeResourceAsync(client);

            Dictionary<string, string> metadata = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                bufferSize: bufferSize,
                metadata: metadata))
            {
                // Act
                await stream.FlushAsync();
            }

            // Assert
            var downloadedMetadata = await GetMetadataAsync(client);
            Assert.AreEqual(metadata.Count + 1, downloadedMetadata.Count);
            CollectionAssert.IsSubsetOf(metadata, downloadedMetadata);
            Assert.IsTrue(downloadedMetadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        /// <summary>
        /// Need to change assertions for a progress reporting test.
        /// Client-side encryption alters data length.
        /// </summary>
        [Test]
        public override async Task OpenWriteAsync_ProgressReporting()
        {
            const int bufferSize = 256;

            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            BlobClient client = GetResourceClient(disposingContainer.Container);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            TestProgress progress = new TestProgress();

            // Act
            using (Stream openWriteStream = await OpenWriteAsync(
                client,
                overwrite: true,
                bufferSize: bufferSize,
                progressHandler: progress))
            {
                await stream.CopyToAsync(openWriteStream);
                await openWriteStream.FlushAsync();
            }

            // Assert
            Assert.IsTrue(progress.List.Count > 0);
            Assert.AreEqual(data.Length - (data.Length % 16) + 16, progress.List[progress.List.Count - 1]);

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }
        #endregion
    }
}
