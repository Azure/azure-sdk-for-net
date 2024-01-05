// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [ShareClientTestFixture(true)]
    [ShareClientTestFixture(false)]
    internal class ShareDirectoryStartTransferUploadTests : StartTransferUploadDirectoryTestBase<
        ShareServiceClient,
        ShareDirectoryClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        /// <summary>
        /// A <see cref="DisposingShare"/> but exposes a directory client within that share.
        /// Still cleans up the whole share. Helpful for parameterizing tests to use a root
        /// directory vs a subdir.
        /// </summary>
        private class DisposingShareDirectory : IDisposingContainer<ShareDirectoryClient>
        {
            private readonly DisposingShare _disposingShare;
            public ShareDirectoryClient Container { get; }

            public DisposingShareDirectory(DisposingShare disposingShare, ShareDirectoryClient dirClient)
            {
                _disposingShare = disposingShare;
                Container = dirClient;
            }

            public async ValueTask DisposeAsync()
            {
                if (_disposingShare != default)
                {
                    await _disposingShare.DisposeAsync();
                }
            }
        }

        public bool UseNonRootDirectory { get; }

        public ShareDirectoryStartTransferUploadTests(bool async, ShareClientOptions.ServiceVersion serviceVersion, bool useNonRootDirectory)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
            UseNonRootDirectory = useNonRootDirectory;
        }

        protected override async Task<IDisposingContainer<ShareDirectoryClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
        {
            DisposingShare disposingShare = await ClientBuilder.GetTestShareAsync(service, containerName);
            ShareDirectoryClient directoryClient = disposingShare.Container.GetRootDirectoryClient();
            if (UseNonRootDirectory)
            {
                foreach (var _ in Enumerable.Range(0, 2))
                {
                    directoryClient = directoryClient.GetSubdirectoryClient(GetNewObjectName());
                    await directoryClient.CreateAsync();
                }
            }
            return new DisposingShareDirectory(disposingShare, directoryClient);
        }

        protected override StorageResourceContainer GetStorageResourceContainer(ShareDirectoryClient containerClient)
        {
            return new ShareDirectoryStorageResourceContainer(containerClient, null);
        }

        protected override TransferValidator.ListFilesAsync GetStorageResourceLister(ShareDirectoryClient containerClient)
        {
            return TransferValidator.GetShareFileLister(containerClient);
        }

        protected override async Task InitializeDestinationDataAsync(ShareDirectoryClient containerClient, List<(string FilePath, long Size)> fileSizes, CancellationToken cancellationToken)
        {
            foreach ((string filePath, long size) in fileSizes)
            {
                ShareDirectoryClient directory = containerClient;

                string[] pathSegments = filePath.Split('/');
                foreach (string pathSegment in pathSegments.Take(pathSegments.Length - 1))
                {
                    directory = directory.GetSubdirectoryClient(pathSegment);
                    await directory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
                }
                ShareFileClient file = directory.GetFileClient(pathSegments.Last());
                await file.CreateAsync(size, cancellationToken: cancellationToken);
                await file.UploadAsync(await CreateLimitedMemoryStream(size), cancellationToken: cancellationToken);
            }
        }
    }
}
