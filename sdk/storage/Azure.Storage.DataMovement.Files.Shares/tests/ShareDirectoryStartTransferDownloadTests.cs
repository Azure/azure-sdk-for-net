// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareDirectoryStartTransferDownloadTests
        : StartTransferDirectoryDownloadTestBase<
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _dirResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";

        public ShareDirectoryStartTransferDownloadTests(
            bool async,
            ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, _dirResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task CreateObjectClientAsync(
            ShareClient container,
            long? objectLength,
            string objectName,
            bool createResource = false,
            ShareClientOptions options = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            await fileClient.CreateAsync(objectLength.Value, cancellationToken: cancellationToken);

            if (contents != default)
            {
                await fileClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        protected override TransferValidator.ListFilesAsync GetSourceLister(ShareClient container, string prefix)
            => TransferValidator.GetShareFileLister(container.GetDirectoryClient(prefix));

        protected override StorageResourceContainer GetStorageResourceContainer(ShareClient container, string directoryPath)
        {
            ShareDirectoryClient directory = string.IsNullOrEmpty(directoryPath) ?
                    container.GetRootDirectoryClient() :
                    container.GetDirectoryClient(directoryPath);
            return new ShareDirectoryStorageResourceContainer(directory, new ShareFileStorageResourceOptions());
        }

        protected override async Task SetupSourceDirectoryAsync(
            ShareClient container,
            string directoryPath,
            List<(string PathName, int Size)> fileSizes,
            CancellationToken cancellationToken)
        {
            ShareDirectoryClient parentDirectory = string.IsNullOrEmpty(directoryPath) ?
                    container.GetRootDirectoryClient() :
                    container.GetDirectoryClient(directoryPath);
            if (!string.IsNullOrEmpty(directoryPath))
            {
                await parentDirectory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
            }
            HashSet<string> subDirectoryNames = new() { directoryPath };
            foreach ((string filePath, long size) in fileSizes)
            {
                CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

                // Check if the parent subdirectory is already created,
                // if not create it before making the files
                int fileNameIndex = filePath.LastIndexOf('/');
                string subDirectoryName = fileNameIndex > 0 ? filePath.Substring(0, fileNameIndex) : "";
                string fileName = fileNameIndex > 0 ? filePath.Substring(fileNameIndex + 1) : filePath;

                // Create parent subdirectory if it does not currently exist.
                ShareDirectoryClient subdirectory = string.IsNullOrEmpty(subDirectoryName) ?
                    container.GetRootDirectoryClient() :
                    container.GetDirectoryClient(subDirectoryName);

                if (!string.IsNullOrEmpty(subDirectoryName) &&
                    !subDirectoryNames.Contains(subDirectoryName))
                {
                    await subdirectory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
                    subDirectoryNames.Add(subDirectoryName);
                }

                using (Stream data = await CreateLimitedMemoryStream(size))
                {
                    ShareFileClient fileClient = subdirectory.GetFileClient(fileName);
                    await fileClient.CreateAsync(size, cancellationToken: cancellationToken);
                    if (size > 0)
                    {
                        await fileClient.UploadAsync(data, cancellationToken: cancellationToken);
                    }
                }
            }
        }
    }
}
