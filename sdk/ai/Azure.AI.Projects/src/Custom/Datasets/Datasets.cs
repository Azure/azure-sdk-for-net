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
using System.Text.RegularExpressions;
using System.ClientModel;

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
                additionalBinaryDataProperties: null);

            PendingUploadResponse pendingUploadResponse = PendingUpload(
                name: name,
                version: inputVersion,
                pendingUploadRequest: pendingUploadRequest
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
            if (pendingUploadResponse.BlobReference.Credential.SasUri == null)
            {
                throw new InvalidOperationException("SAS URI is missing or empty.");
            }

            var containerClient = new BlobContainerClient(pendingUploadResponse.BlobReference.Credential.SasUri);
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

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                string blobName = Path.GetFileName(filePath);
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                blobClient.Upload(fileStream);

                var uriBuilder = new UriBuilder(blobClient.Uri) { Query = "" };
                Uri dataUri = uriBuilder.Uri;

                FileDatasetVersion fileDatasetVersion = new FileDatasetVersion(dataUri: dataUri);
                BinaryContent content = BinaryContent.Create(fileDatasetVersion);
                CreateOrUpdate(name, outputVersion, content);

                return Get(name, outputVersion);
            }
        }

        /// <summary>
        /// Uploads all files in a folder to blob storage and creates a dataset that references this folder.
        /// </summary>
        public DatasetVersion UploadFolder(string name, string version, string folderPath, string? connectionName = null, Regex? filePattern = null)
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
                string fileName = Path.GetFileName(filePath);
                if (filePattern != null && !filePattern.IsMatch(fileName))
                {
                    continue;
                }
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    blobClient = containerClient.GetBlobClient(fileName);
                    blobClient.Upload(fileStream);
                    filesUploaded = true;
                }
            }

            if (!filesUploaded)
            {
                throw new ArgumentException("The provided folder is empty.");
            }

            var uriBuilder = new UriBuilder(blobClient!.Uri) { Query = "" };
            Uri dataUri = uriBuilder.Uri;

            FolderDatasetVersion folderDatasetVersion = new FolderDatasetVersion(dataUri: dataUri);
            BinaryContent content = BinaryContent.Create(folderDatasetVersion);
            CreateOrUpdate(name, outputVersion, content);

            return Get(name, outputVersion);
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
                additionalBinaryDataProperties: null);

            PendingUploadResponse pendingUploadResponse = await PendingUploadAsync(
                name: name,
                version: inputVersion,
                pendingUploadRequest: pendingUploadRequest
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
            if (pendingUploadResponse.BlobReference.Credential.SasUri == null)
            {
                throw new InvalidOperationException("SAS URI is missing or empty.");
            }

            var containerClient = new BlobContainerClient(pendingUploadResponse.BlobReference.Credential.SasUri);
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

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                string blobName = Path.GetFileName(filePath);
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.UploadAsync(fileStream).ConfigureAwait(false);

                var uriBuilder = new UriBuilder(blobClient.Uri) { Query = "" };
                Uri dataUri = uriBuilder.Uri;

                FileDatasetVersion fileDatasetVersion = new FileDatasetVersion(dataUri: dataUri);
                BinaryContent content = BinaryContent.Create(fileDatasetVersion);
                await CreateOrUpdateAsync(name, outputVersion, content).ConfigureAwait(false);

                return await GetAsync(name, outputVersion).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads all files in a folder to blob storage and creates a dataset that references this folder.
        /// </summary>
        public async Task<DatasetVersion> UploadFolderAsync(string name, string version, string folderPath, string? connectionName = null, Regex? filePattern = null)
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
                string fileName = Path.GetFileName(filePath);
                if (filePattern != null && !filePattern.IsMatch(fileName))
                {
                    continue;
                }
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    blobClient = containerClient.GetBlobClient(fileName);
                    await blobClient.UploadAsync(fileStream).ConfigureAwait(false);
                    filesUploaded = true;
                }
            }

            if (!filesUploaded)
            {
                throw new ArgumentException("The provided folder is empty.");
            }

            var uriBuilder = new UriBuilder(blobClient!.Uri) { Query = "" };
            Uri dataUri = uriBuilder.Uri;

            FolderDatasetVersion folderDatasetVersion = new FolderDatasetVersion(dataUri: dataUri);
            BinaryContent content = BinaryContent.Create(folderDatasetVersion);
            await CreateOrUpdateAsync(name, outputVersion, content).ConfigureAwait(false);

            return await GetAsync(name, outputVersion).ConfigureAwait(false);
        }
    }
}
