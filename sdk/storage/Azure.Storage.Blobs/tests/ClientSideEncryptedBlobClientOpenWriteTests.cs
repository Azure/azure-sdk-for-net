// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Cryptography;
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
#pragma warning disable CS0618 // obsolete
    [BlobsClientTestFixture(ClientSideEncryptionVersion.V1_0, ClientSideEncryptionVersion.V2_0)]
#pragma warning restore CS0618 // obsolete
    public class ClientSideEncryptedBlobClientOpenWriteTests : BlobClientOpenWriteTests
    {
        private readonly ClientSideEncryptionVersion _version;

        public ClientSideEncryptedBlobClientOpenWriteTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion,
            ClientSideEncryptionVersion version)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            _version = version;
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
            options._clientSideEncryptionOptions = new ClientSideEncryptionOptions(_version)
            {
                KeyEncryptionKey = this.GetIKeyEncryptionKey(expectedCancellationToken: default).Object,
                KeyWrapAlgorithm = ClientSideEncryptionTestExtensions.s_algorithmName
            };

            return base.GetResourceClient(container, resourceName, options);
        }

        protected override long GetExpectedDataLength(long dataLength) => _version switch
        {
#pragma warning disable CS0618 // obsolete
            ClientSideEncryptionVersion.V1_0 => ClientSideEncryptorV1_0.CalculateExpectedOutputContentLength(dataLength),
#pragma warning restore CS0618 // obsolete
            ClientSideEncryptionVersion.V2_0 => ClientSideEncryptorV2_0.CalculateExpectedOutputContentLength(dataLength),
            _ => dataLength
        };

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

            Dictionary<string, string> metadata = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            // Act
            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: Constants.KB,
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

            Dictionary<string, string> metadata = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: Constants.KB,
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
        #endregion
    }
}
