// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

# nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection;

namespace Azure.AI.Projects
{
    public partial class Datasets
    {
        /// <summary>
        /// Internal helper method to create a new dataset and return a BlobContainerClient to the dataset's blob storage.
        /// </summary>
        private (BlobContainerClient ContainerClient, string OutputVersion) CreateDatasetAndGetContainerClient(string name, string inputVersion, string? connectionName = null)
        {
            var pendingUploadRequest = new PendingUploadRequest(
                pendingUploadId: null,
                connectionName: connectionName,
                pendingUploadType: PendingUploadType.BlobReference,
                serializedAdditionalRawData: null);

            PendingUploadResponse pendingUploadResponse = PendingUpload(
                name: name,
                version: inputVersion,
                body: pendingUploadRequest
            );

            string outputVersion = inputVersion;

            if (pendingUploadResponse.BlobReference == null)
            {
                throw new InvalidOperationException("Blob reference is not present.");
            }
            if (pendingUploadResponse.BlobReference.Credential == null)
            {
                throw new InvalidOperationException("SAS credential is not present.");
            }
            if (string.IsNullOrEmpty(pendingUploadResponse.BlobReference.Credential.SasUri))
            {
                throw new InvalidOperationException("SAS URI is missing or empty.");
            }

            var containerClient = new BlobContainerClient(new Uri(pendingUploadResponse.BlobReference.Credential.SasUri));
            return (containerClient, outputVersion);
        }

        /// <summary>
        /// Uploads a file to blob storage and creates a dataset that references this file.
        /// </summary>
        public DatasetVersion UploadFile(string name, string version, string filePath, string? connectionName = null)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File path: {filePath}");
                throw new ArgumentException($"The provided file does not exist: {filePath}.");
            }

            var (containerClient, outputVersion) = CreateDatasetAndGetContainerClient(name, version, connectionName);

            using (var fileStream = File.OpenRead(filePath))
            {
                var blobName = Path.GetFileName(filePath);
                var blobClient = containerClient.GetBlobClient(blobName);
                blobClient.Upload(fileStream);

                var uriBuilder = new UriBuilder(blobClient.Uri) { Query = "" };
                var dataUri = uriBuilder.Uri.AbsoluteUri;

                RequestContent content = new FileDatasetVersion(dataUri: dataUri).ToRequestContent();

                CreateOrUpdate(name, outputVersion, content);

                return GetDataset(name, outputVersion);
            }
        }

        /// <summary>
        /// Uploads all files in a folder to blob storage and creates a dataset that references this folder.
        /// </summary>
        public DatasetVersion UploadFolder(string name, string version, string folderPath, string? connectionName = null)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"File path: {folderPath}");
                throw new ArgumentException($"The provided folder does not exist: {folderPath}");
            }

            var (containerClient, outputVersion) = CreateDatasetAndGetContainerClient(name, version, connectionName);

            var filesUploaded = false;
            BlobClient? blobClient = null;
            foreach (var filePath in Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                var relativePath = new Uri(folderPath).MakeRelativeUri(new Uri(filePath));
                using (var fileStream = File.OpenRead(filePath))
                {
                    blobClient = containerClient.GetBlobClient(relativePath.OriginalString);
                    blobClient.Upload(fileStream);
                    filesUploaded = true;
                }
            }

            if (!filesUploaded)
            {
                throw new ArgumentException("The provided folder is empty.");
            }

            var uriBuilder = new UriBuilder(blobClient!.Uri) { Query = "" };
            var dataUri = uriBuilder.Uri.AbsoluteUri;

            RequestContent content = new FolderDatasetVersion(dataUri: dataUri).ToRequestContent();
            CreateOrUpdate(name, outputVersion, content);

            return GetDataset(name, outputVersion);
        }

        /// <summary>
        /// Internal helper method to create a new dataset and return a BlobContainerClient to the dataset's blob storage.
        /// </summary>
        private async Task<(BlobContainerClient ContainerClient, string OutputVersion)> CreateDatasetAndGetContainerClientAsync(string name, string inputVersion, string? connectionName = null)
        {
            var pendingUploadRequest = new PendingUploadRequest(
                pendingUploadId: null,
                connectionName: connectionName,
                pendingUploadType: PendingUploadType.BlobReference,
                serializedAdditionalRawData: null);

            PendingUploadResponse pendingUploadResponse = await PendingUploadAsync(
                name: name,
                version: inputVersion,
                body: pendingUploadRequest
            ).ConfigureAwait(false);

            string outputVersion = inputVersion;

            if (pendingUploadResponse.BlobReference == null)
            {
                throw new InvalidOperationException("Blob reference is not present.");
            }
            if (pendingUploadResponse.BlobReference.Credential == null)
            {
                throw new InvalidOperationException("SAS credential is not present.");
            }
            if (string.IsNullOrEmpty(pendingUploadResponse.BlobReference.Credential.SasUri))
            {
                throw new InvalidOperationException("SAS URI is missing or empty.");
            }

            var containerClient = new BlobContainerClient(new Uri(pendingUploadResponse.BlobReference.Credential.SasUri));
            return (containerClient, outputVersion);
        }

        /// <summary>
        /// Uploads a file to blob storage and creates a dataset that references this file.
        /// </summary>
        public async Task<DatasetVersion> UploadFileAsync(string name, string version, string filePath, string? connectionName = null)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"The provided file does not exist: {filePath}.");
            }

            var (containerClient, outputVersion) = await CreateDatasetAndGetContainerClientAsync(name, version, connectionName).ConfigureAwait(false);

            using (var fileStream = File.OpenRead(filePath))
            {
                var blobName = Path.GetFileName(filePath);
                var blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.UploadAsync(fileStream).ConfigureAwait(false);

                var uriBuilder = new UriBuilder(blobClient.Uri) { Query = "" };
                var dataUri = uriBuilder.Uri.AbsoluteUri;

                RequestContent content = new FileDatasetVersion(dataUri: dataUri).ToRequestContent();

                await CreateOrUpdateAsync(name, outputVersion, content).ConfigureAwait(false);

                return await GetDatasetAsync(name, outputVersion).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads all files in a folder to blob storage and creates a dataset that references this folder.
        /// </summary>
        public async Task<DatasetVersion> UploadFolderAsync(string name, string version, string folderPath, string? connectionName = null)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"File path: {folderPath}");
                throw new ArgumentException($"The provided folder does not exist: {folderPath}");
            }

            var (containerClient, outputVersion) = await CreateDatasetAndGetContainerClientAsync(name, version, connectionName).ConfigureAwait(false);

            var filesUploaded = false;
            BlobClient? blobClient = null;
            foreach (var filePath in Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                var relativePath = new Uri(folderPath).MakeRelativeUri(new Uri(filePath));
                using (var fileStream = File.OpenRead(filePath))
                {
                    blobClient = containerClient.GetBlobClient(relativePath.OriginalString);
                    await blobClient.UploadAsync(fileStream).ConfigureAwait(false);
                    filesUploaded = true;
                }
            }

            if (!filesUploaded)
            {
                throw new ArgumentException("The provided folder is empty.");
            }

            var uriBuilder = new UriBuilder(blobClient!.Uri) { Query = "" };
            var dataUri = uriBuilder.Uri.AbsoluteUri;

            RequestContent content = new FolderDatasetVersion(dataUri: dataUri).ToRequestContent();
            await CreateOrUpdateAsync(name, outputVersion, content).ConfigureAwait(false);

            return await GetDatasetAsync(name, outputVersion).ConfigureAwait(false);
        }
    }
}
