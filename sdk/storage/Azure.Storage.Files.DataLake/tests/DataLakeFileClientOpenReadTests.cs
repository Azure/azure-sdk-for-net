// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Common;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    [DataLakeClientTestFixture]
    public class DataLakeFileClientOpenReadTests
        : OpenReadTestBase<
        DataLakeServiceClient,
        DataLakeFileSystemClient,
        DataLakeFileClient,
        DataLakeClientOptions,
        DataLakeRequestConditions,
        DataLakeTestEnvironment>
    {
        private const string _blobResourcePrefix = "test-blob-";

        public DataLakeAccessConditionConfigs FileConditions { get; }

        /// <inheritdoc/>
        public override AccessConditionConfigs Conditions => FileConditions;

        protected override string OpenReadAsync_Error_Code => "BlobNotFound";

        public DataLakeFileClientOpenReadTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewDataLakeClientBuilder(Tenants, serviceVersion);
            FileConditions = new DataLakeAccessConditionConfigs(this);
        }

        #region Client-Specific Impl
        protected override async Task<IDisposingContainer<DataLakeFileSystemClient>> GetDisposingContainerAsync(DataLakeServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetNewFileSystem(service, containerName);

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

        protected override DataLakeRequestConditions BuildRequestConditions(AccessConditionParameters parameters, bool lease = true)
            => FileConditions.BuildAccessConditions(parameters, lease);

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

        protected override async Task<string> SetupLeaseAsync(DataLakeFileClient client, string leaseId, string garbageLeaseId)
        {
            DataLakeLease lease = null;
            if (leaseId == Conditions.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(client.GetDataLakeLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync(DataLakeLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == Conditions.ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        protected override async Task<Stream> OpenReadAsync(DataLakeFileClient client, int? bufferSize = null, long position = 0, DataLakeRequestConditions conditions = null, bool allowModifications = false)
            => await client.OpenReadAsync(new DataLakeOpenReadOptions(allowModifications)
            {
                BufferSize = bufferSize,
                Position = position,
                Conditions = conditions
            });

        protected override async Task<Stream> OpenReadAsyncOverload(DataLakeFileClient client, int? bufferSize = null, long position = 0, bool allowModifications = false)
            => await client.OpenReadAsync(allowModifications, position, bufferSize);

        protected override async Task StageDataAsync(DataLakeFileClient client, Stream data)
        {
            using Stream writeStream = await client.OpenWriteAsync( overwrite: true);
            await data.CopyToAsync(writeStream);
        }

        protected override async Task ModifyDataAsync(DataLakeFileClient client, Stream data, ModifyDataMode mode)
        {
            using Stream writeStream = mode switch
            {
                ModifyDataMode.Replace => await client.OpenWriteAsync(overwrite: true),
                ModifyDataMode.Append => await client.OpenWriteAsync(overwrite: false), // method automatically sets position to end
                _ => throw Errors.InvalidArgument(nameof(mode))
            };
            await data.CopyToAsync(writeStream);
        }

        public override async Task AssertExpectedExceptionOpenReadModifiedAsync(Task readTask)
            => await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                readTask,
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        #endregion
    }
}
