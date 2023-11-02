// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [ShareClientTestFixture(true)]
    [ShareClientTestFixture(false)]
    internal class ShareDirectoryStartTransferUploadTests : StartTransferUploadDirectoryTestBase<
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        public bool UseNonRootDirectory { get; }

        public ShareDirectoryStartTransferUploadTests(bool async, ShareClientOptions.ServiceVersion serviceVersion, bool useNonRootDirectory)
            : base(async, Core.TestFramework.RecordedTestMode.Record /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
            UseNonRootDirectory = useNonRootDirectory;
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
        {
            return await ClientBuilder.GetTestShareAsync(service, containerName);
        }

        protected override StorageResourceContainer GetStorageResourceContainer(ShareClient containerClient)
        {
            ShareDirectoryClient directory = containerClient.GetRootDirectoryClient();
            if (UseNonRootDirectory)
            {
                directory = directory.GetSubdirectoryClient(GetNewObjectName());
            }
            return new ShareDirectoryStorageResourceContainer(directory, null);
        }

        protected override TransferValidator.ListFilesAsync GetStorageResourceLister(ShareClient containerClient)
        {
            return TransferValidator.GetShareFileLister(containerClient.GetRootDirectoryClient());
        }

        protected override async Task InitializeDestinationDataAsync(ShareClient containerClient, List<(string FilePath, long Size)> fileSizes, CancellationToken cancellationToken)
        {
            foreach ((string filePath, long size) in fileSizes)
            {
                ShareDirectoryClient directory = containerClient.GetRootDirectoryClient();
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
