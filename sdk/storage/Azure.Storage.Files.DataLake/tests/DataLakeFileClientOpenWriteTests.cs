// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.DataLake.Tests
{
    [DataLakeClientTestFixture]
    public class DataLakeFileClientOpenWriteTests : OpenWriteTestBase<
        DataLakeServiceClient,
        DataLakeFileSystemClient,
        DataLakeFileClient,
        DataLakeClientOptions,
        DataLakeRequestConditions,
        DataLakeTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";

        public DataLakeAccessConditionConfigs FileConditions { get; }

        public override AccessConditionConfigs Conditions => FileConditions;

        public override string ConditionNotMetErrorCode => BlobErrorCode.ConditionNotMet.ToString();

        public override string ContainerNotFoundErrorCode => "FilesystemNotFound";

        public DataLakeFileClientOpenWriteTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewDataLakeClientBuilder(Tenants, serviceVersion);
            FileConditions = new DataLakeAccessConditionConfigs(this);
        }

        #region Client-Specific Impl
        protected override DataLakeRequestConditions BuildRequestConditions(AccessConditionParameters parameters, bool lease = true)
            => FileConditions.BuildAccessConditions(parameters, lease);

        protected override async Task<BinaryData> DownloadAsync(DataLakeFileClient client)
            => await BinaryData.FromStreamAsync((await client.ReadAsync()).Value.Content);

        protected override async Task<IDisposingContainer<DataLakeFileSystemClient>> GetDisposingContainerAsync(DataLakeServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetNewFileSystem(service, containerName);

        protected override async Task<string> GetMatchConditionAsync(DataLakeFileClient client, string match)
        {
            if (match == Conditions.ReceivedETag)
            {
                Response<PathProperties> headers = await client.GetPropertiesAsync();
                return headers.GetRawResponse().Headers.ETag.ToString();
            }
            else
            {
                return match;
            }
        }

        protected override async Task<IDictionary<string, string>> GetMetadataAsync(DataLakeFileClient client)
            => (await client.GetPropertiesAsync()).Value.Metadata;

        protected override async Task<Response> GetPropertiesAsync(DataLakeFileClient client)
            => (await client.GetPropertiesAsync()).GetRawResponse();

        protected override DataLakeFileClient GetResourceClient(DataLakeFileSystemClient container, string resourceName = null, DataLakeClientOptions options = null)
        {
            Argument.AssertNotNull(container, nameof(container));

            string fileName = resourceName ?? GetNewResourceName();

            if (options == null)
            {
                return container.GetRootDirectoryClient().GetFileClient(fileName);
            }

            container = InstrumentClient(new DataLakeFileSystemClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            return InstrumentClient(container.GetRootDirectoryClient().GetFileClient(fileName));
        }

        protected override DataLakeFileSystemClient GetUninitializedContainerClient(DataLakeServiceClient service = null, string containerName = null)
        {
            containerName ??= ClientBuilder.GetNewFileSystemName();
            service ??= ClientBuilder.GetServiceClient_Hns();

            return ClientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetFileSystemClient(containerName));
        }

        protected override async Task ModifyAsync(DataLakeFileClient client, Stream data)
        {
            long position = (await client.GetPropertiesAsync()).Value.ContentLength;
            await client.AppendAsync(data, position);
            await client.FlushAsync(position + data.Length);
        }

        protected override Task<Stream> OpenWriteAsync(DataLakeFileClient client, bool overwrite, long? maxDataSize, int? bufferSize = null, DataLakeRequestConditions conditions = null, Dictionary<string, string> metadata = null, HttpHeaderParameters httpHeaders = null, IProgress<long> progressHandler = null)
        {
            if (metadata != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "DataLakeFileClient.OpenWriteAsync() does not support metadata.");
            }
            if (httpHeaders != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "DataLakeFileClient.OpenWriteAsync() does not support httpHeaders.");
            }

            return client.OpenWriteAsync(overwrite, new DataLakeFileOpenWriteOptions
            {
                BufferSize = bufferSize,
                OpenConditions = conditions,
                ProgressHandler = progressHandler
            });
        }

        protected override async Task<string> SetupLeaseAsync(DataLakeFileClient client, string leaseId, string garbageLeaseId)
        {
            DataLakeLease lease = null;
            if (leaseId == Conditions.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(client.GetDataLakeLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync(DataLakeLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == Conditions.ReceivedLeaseId ? lease.LeaseId : leaseId;
        }
        #endregion
    }
}
