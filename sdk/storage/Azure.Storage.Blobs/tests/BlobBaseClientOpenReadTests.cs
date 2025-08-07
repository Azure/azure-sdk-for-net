// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [BlobsClientTestFixture]
    public abstract class BlobBaseClientOpenReadTests<TBlobClient> : OpenReadTestBase<
        BlobServiceClient,
        BlobContainerClient,
        TBlobClient,
        BlobClientOptions,
        BlobRequestConditions,
        BlobTestEnvironment> where TBlobClient : BlobBaseClient
    {
        private const string _blobResourcePrefix = "test-blob-";

        /// <summary>
        /// Supplies <see cref="BlobRequestConditions"/> instances for tests.
        /// </summary>
        public BlobAccessConditionConfigs BlobConditions { get; }

        /// <inheritdoc/>
        public override AccessConditionConfigs Conditions => BlobConditions;

        protected override string OpenReadAsync_Error_Code => "BlobNotFound";

        public BlobBaseClientOpenReadTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion,
            RecordedTestMode? mode = null)
            : base(async, _blobResourcePrefix, mode)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
            BlobConditions = new BlobAccessConditionConfigs(this);
        }

        #region Client-Specific Impl
        protected override BlobRequestConditions BuildRequestConditions(AccessConditionParameters parameters, bool lease = true)
            => BlobConditions.BuildAccessConditions(parameters, lease);

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

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

        protected override async Task<Stream> OpenReadAsync(TBlobClient client, int? bufferSize = null, long position = 0, BlobRequestConditions conditions = null, bool allowModifications = false)
            => await client.OpenReadAsync(new BlobOpenReadOptions(allowModifications)
            {
                BufferSize = bufferSize,
                Position = position,
                Conditions = conditions
            });

        protected override async Task<Stream> OpenReadAsyncOverload(TBlobClient client, int? bufferSize = null, long position = 0, bool allowModifications = false)
            => await client.OpenReadAsync(allowModifications, position, bufferSize);

        public override async Task AssertExpectedExceptionOpenReadModifiedAsync(Task readTask)
            => await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                readTask,
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        #endregion
    }
}
