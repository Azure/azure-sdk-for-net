// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test.Shared;
using SharesClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Files.Shares.ShareServiceClient,
    Azure.Storage.Files.Shares.ShareClientOptions>;
using System.IO;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public abstract class DataMovementShareTestBase : StorageTestBase<StorageTestEnvironment>
    {
        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        /// <summary>
        /// Source of clients.
        /// </summary>
        protected SharesClientBuilder SharesClientBuilder { get; }

        public DataMovementShareTestBase(bool async, ShareClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SharesClientBuilder = GetNewSharesClientBuilder(Tenants, _serviceVersion);
        }

        public string GetNewShareName() => SharesClientBuilder.GetNewShareName();
        public string GetNewDirectoryName() => SharesClientBuilder.GetNewDirectoryName();
        public string GetNewNonAsciiDirectoryName() => SharesClientBuilder.GetNewNonAsciiDirectoryName();
        public string GetNewFileName() => SharesClientBuilder.GetNewFileName();
        public string GetNewNonAsciiFileName() => SharesClientBuilder.GetNewNonAsciiFileName();

        /// <summary>
        /// Creates a new <see cref="ClientBuilder{TServiceClient, TServiceClientOptions}"/>
        /// setup to generate <see cref="BlobServiceClient"/>s.
        /// </summary>
        /// <param name="tenants"><see cref="TenantConfigurationBuilder"/> powering this client builder.</param>
        /// <param name="serviceVersion">Service version for clients to target.</param>
        public SharesClientBuilder GetNewSharesClientBuilder(TenantConfigurationBuilder tenants, ShareClientOptions.ServiceVersion serviceVersion)
            => new SharesClientBuilder(
                ServiceEndpoint.File,
                tenants,
                (uri, clientOptions) => new ShareServiceClient(uri, clientOptions),
                (uri, sharedKeyCredential, clientOptions) => new ShareServiceClient(uri, sharedKeyCredential, clientOptions),
                (uri, tokenCredential, clientOptions) => new ShareServiceClient(uri, tokenCredential, clientOptions),
                (uri, azureSasCredential, clientOptions) => new ShareServiceClient(uri, azureSasCredential, clientOptions),
                () => new ShareClientOptions(serviceVersion));

        public async Task<DisposingShare> GetTestShareAsync(
            ShareServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            ShareClientOptions options = default)
            => await SharesClientBuilder.GetTestShareAsync(service, containerName, metadata, options);

        internal async Task<ShareFileClient> CreateShareFile(
            ShareDirectoryClient directoryClient,
            string localSourceFile,
            string fileName,
            long size)
        {
            ShareFileClient fileClient = directoryClient.GetFileClient(fileName);

            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                // Copy source to a file, so we can verify the source against downloaded blob later
                await originalStream.CopyToAsync(fileStream);
                // Upload blob to storage account
                originalStream.Position = 0;
                await fileClient.CreateAsync(size);
                await fileClient.UploadAsync(originalStream);
            }
            return fileClient;
        }
    }
}
