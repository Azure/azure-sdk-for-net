// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Common;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareFileClientOpenWriteTests : OpenWriteTestBase<
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        ShareFileRequestConditions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";

        public override AccessConditionConfigs Conditions { get; }

        public override string ConditionNotMetErrorCode => ShareErrorCode.ConditionNotMet.ToString();

        public override string ContainerNotFoundErrorCode => ShareErrorCode.ShareNotFound.ToString();

        public ShareFileClientOpenWriteTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
            Conditions = new AccessConditionConfigs(this);
        }

        #region Client Impl
        protected override ShareFileRequestConditions BuildRequestConditions(AccessConditionParameters parameters, bool lease = true)
            => new ShareFileRequestConditions
            {
                LeaseId = lease ? parameters.LeaseId : default
            };

        protected override async Task<BinaryData> DownloadAsync(ShareFileClient client)
            => await BinaryData.FromStreamAsync((await client.DownloadAsync()).Value.Content);

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<string> GetMatchConditionAsync(ShareFileClient client, string match)
        {
            if (match == Conditions.ReceivedETag)
            {
                Response<ShareFileProperties> headers = await client.GetPropertiesAsync();
                return headers.GetRawResponse().Headers.ETag.ToString();
            }
            else
            {
                return match;
            }
        }

        protected override async Task<IDictionary<string, string>> GetMetadataAsync(ShareFileClient client)
            => (await client.GetPropertiesAsync()).Value.Metadata;

        protected override async Task<Response> GetPropertiesAsync(ShareFileClient client)
            => (await client.GetPropertiesAsync()).GetRawResponse();

        protected override ShareFileClient GetResourceClient(ShareClient container, string resourceName = null, ShareClientOptions options = null)
        {
            Argument.AssertNotNull(container, nameof(container));

            string fileName = resourceName ?? GetNewResourceName();

            if (options == null)
            {
                return container.GetRootDirectoryClient().GetFileClient(fileName);
            }

            container = InstrumentClient(new ShareClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            return InstrumentClient(container.GetRootDirectoryClient().GetFileClient(fileName));
        }

        protected override ShareClient GetUninitializedContainerClient(ShareServiceClient service = null, string containerName = null)
        {
            containerName ??= ClientBuilder.GetNewShareName();
            service ??= ClientBuilder.GetServiceClient_SharedKey();

            return ClientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetShareClient(containerName));
        }

        protected override async Task ModifyAsync(ShareFileClient client, Stream data)
        {
            long position = (await client.GetPropertiesAsync()).Value.ContentLength;
            await client.SetHttpHeadersAsync(new ShareFileSetHttpHeadersOptions() { NewSize = position + data.Length });
            await client.UploadRangeAsync(new HttpRange(offset: position, length: data.Length), data);
        }

        protected override async Task<Stream> OpenWriteAsync(ShareFileClient client, bool overwrite, long? maxDataSize, int? bufferSize = null, ShareFileRequestConditions conditions = null, Dictionary<string, string> metadata = null, HttpHeaderParameters httpHeaders = null, IProgress<long> progressHandler = null)
        {
            if (metadata != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "ShareFileClient.OpenWriteAsync() does not support metadata.");
            }
            if (httpHeaders != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "ShareFileClient.OpenWriteAsync() does not support httpHeaders.");
            }

            return await client.OpenWriteAsync(overwrite, 0, new ShareFileOpenWriteOptions
            {
                BufferSize = bufferSize,
                MaxSize = maxDataSize,
                OpenConditions = conditions,
                ProgressHandler = progressHandler
            });
        }

        protected override async Task<string> SetupLeaseAsync(ShareFileClient client, string leaseId, string garbageLeaseId)
        {
            ShareFileLease lease = null;
            if (leaseId == Conditions.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(new ShareLeaseClient(client, Recording.Random.NewGuid().ToString())).AcquireAsync(ShareLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == Conditions.ReceivedLeaseId ? lease.LeaseId : leaseId;
        }
        #endregion

        #region Tests
        [RecordedTest]
        public override Task OpenWriteAsync_AccessConditionsFail()
        {
            TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "Share Files don't support match/modified access conditions");
            return Task.CompletedTask;
        }

        public override Task OpenWriteAsync_ModifiedDuringWrite()
        {
            TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "Share Files don't support match/modified access conditions");
            return Task.CompletedTask;
        }
        #endregion
    }
}
