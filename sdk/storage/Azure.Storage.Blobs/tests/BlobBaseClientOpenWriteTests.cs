// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [BlobsClientTestFixture]
    public abstract class BlobBaseClientOpenWriteTests<TBlobClient> : OpenWriteTestBase<
        BlobServiceClient,
        BlobContainerClient,
        TBlobClient,
        BlobClientOptions,
        BlobRequestConditions,
        BlobTestEnvironment>
        where TBlobClient : BlobBaseClient
    {
        private const string _blobResourcePrefix = "test-blob-";

        /// <summary>
        /// Supplies <see cref="BlobRequestConditions"/> instances for tests.
        /// </summary>
        public BlobAccessConditionConfigs BlobConditions { get; }

        /// <inheritdoc/>
        public override AccessConditionConfigs Conditions => BlobConditions;

        public BlobBaseClientOpenWriteTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion,
            RecordedTestMode? mode = null)
            : base(async, _blobResourcePrefix, mode)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
            BlobConditions = new BlobAccessConditionConfigs(this);
        }

        #region Client-Specific Impl
        public override string ConditionNotMetErrorCode => BlobErrorCode.ConditionNotMet.ToString();

        public override string ContainerNotFoundErrorCode => BlobErrorCode.ContainerNotFound.ToString();

        protected override async Task<BinaryData> DownloadAsync(TBlobClient client)
            => (await client.DownloadContentAsync()).Value.Content;

        protected override BlobContainerClient GetUninitializedContainerClient(BlobServiceClient service = null, string containerName = null)
        {
            containerName ??= ClientBuilder.GetNewContainerName();
            service ??= ClientBuilder.GetServiceClient_SharedKey();

            return ClientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetBlobContainerClient(containerName));
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<IDictionary<string, string>> GetMetadataAsync(TBlobClient client)
            => (await client.GetPropertiesAsync()).Value.Metadata;

        protected override async Task<Response> GetPropertiesAsync(TBlobClient client)
            => (await client.GetPropertiesAsync()).GetRawResponse();

        protected override async Task<IDictionary<string, string>> GetTagsAsync(TBlobClient client)
            => (await client.GetTagsAsync()).Value.Tags;

        protected override BlobRequestConditions BuildRequestConditions(AccessConditionParameters parameters, bool lease = true)
            => BlobConditions.BuildAccessConditions(parameters, lease);

        protected override async Task<string> GetMatchConditionAsync(TBlobClient client, string match)
        {
            if (match == Conditions.ReceivedETag)
            {
                Response<BlobProperties> headers = await client.GetPropertiesAsync();
                return headers.GetRawResponse().Headers.ETag.ToString();
            }
            else
            {
                return match;
            }
        }

        protected override async Task<string> SetupLeaseAsync(TBlobClient client, string leaseId, string garbageLeaseId)
        {
            BlobLease lease = null;
            if (leaseId == Conditions.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(client.GetBlobLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync(BlobLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == Conditions.ReceivedLeaseId ? lease.LeaseId : leaseId;
        }
        #endregion

        #region Blob-Specific Tests
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task OpenWriteAsync_NewBlob_WithTags()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TBlobClient client = GetResourceClient(disposingContainer.Container);
            await InitializeResourceAsync(client);

            Dictionary<string, string> tags = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                bufferSize: bufferSize,
                tags: tags);

            // Act
            await stream.FlushAsync();

            // Assert
            CollectionAssert.AreEqual(tags, await GetTagsAsync(client));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task OpenWriteAsync_CreateEmptyBlob_WithTags()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TBlobClient client = GetResourceClient(disposingContainer.Container);
            await InitializeResourceAsync(client);

            Dictionary<string, string> tags = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            // Act
            Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                bufferSize: bufferSize,
                tags: tags);

            // Assert
            CollectionAssert.AreEqual(tags, await GetTagsAsync(client));
        }
        #endregion
    }
}
