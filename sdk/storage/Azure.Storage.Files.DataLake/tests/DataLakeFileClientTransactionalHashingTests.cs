// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.DataLake.Tests
{
    [DataLakeClientTestFixture]
    public class DataLakeFileClientTransactionalHashingTests : TransactionalHashingTestBase<
        DataLakeServiceClient,
        DataLakeFileSystemClient,
        DataLakeFileClient,
        DataLakeClientOptions,
        DataLakeTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";

        public DataLakeFileClientTransactionalHashingTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewDataLakeClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<DataLakeFileSystemClient>> GetDisposingContainerAsync(
            DataLakeServiceClient service = null,
            string containerName = null)
            => await ClientBuilder.GetNewFileSystem(service: service, fileSystemName: containerName);

        protected override async Task<DataLakeFileClient> GetResourceClientAsync(
            DataLakeFileSystemClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = null,
            DataLakeClientOptions options = null)
        {
            container = InstrumentClient(new DataLakeFileSystemClient(container.Uri, Tenants.GetNewHnsSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            var file = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(resourceName ?? GetNewResourceName()));
            if (createResource)
            {
                await file.CreateAsync();
            }
            return file;
        }

        protected override async Task<Response> UploadPartitionAsync(DataLakeFileClient client, Stream source, UploadTransactionalHashingOptions hashingOptions)
        {
            return await client.AppendAsync(source, 0, new DataLakeFileAppendOptions
            {
                TransactionalHashingOptions = hashingOptions
            });
        }

        protected override async Task<Response> DownloadPartitionAsync(DataLakeFileClient client, Stream destination, DownloadTransactionalHashingOptions hashingOptions, HttpRange range = default)
        {
            var response = await client.ReadAsync(new DataLakeFileReadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = range
            });

            await response.Value.Content.CopyToAsync(destination);
            return response.GetRawResponse();
        }

        protected override async Task ParallelUploadAsync(DataLakeFileClient client, Stream source, UploadTransactionalHashingOptions hashingOptions, StorageTransferOptions transferOptions)
        {
            await client.UploadAsync(source, new DataLakeFileUploadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions
            });
        }

        protected override async Task ParallelDownloadAsync(DataLakeFileClient client, Stream destination, DownloadTransactionalHashingOptions hashingOptions, StorageTransferOptions transferOptions)
        {
            await client.ReadToAsync(destination, new DataLakeFileReadToOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions
            });
        }

        protected override async Task<Stream> OpenWriteAsync(DataLakeFileClient client, UploadTransactionalHashingOptions hashingOptions, int internalBufferSize)
        {
            return await client.OpenWriteAsync(true, new DataLakeFileOpenWriteOptions
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task<Stream> OpenReadAsync(DataLakeFileClient client, DownloadTransactionalHashingOptions hashingOptions, int internalBufferSize)
        {
            return await client.OpenReadAsync(new DataLakeOpenReadOptions(false)
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task SetupDataAsync(DataLakeFileClient client, Stream data)
        {
            await client.AppendAsync(data, 0);
            await client.FlushAsync(data.Length);
        }

        protected override bool ParallelUploadIsHashExpected(Request request)
        {
            return request.Uri.Query.Contains("action=append");
        }
    }
}
