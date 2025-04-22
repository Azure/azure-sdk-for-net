// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.AI.Projects.OneDP;

namespace Azure.AI.Projects.OneDP
{
    public partial class Datasets
    {
        /// <summary>
        /// Internal helper method to create a new dataset and return a BlobContainerClient to the dataset's blob storage.
        /// </summary>
        private (BlobContainerClient ContainerClient, string OutputVersion) CreateDatasetAndGetContainerClient(string name, string inputVersion)
        {
            var pendingUploadResponse = StartPendingUploadVersion(
                name,
                inputVersion,
                new PendingUploadRequest(null, null, PendingUploadType.TemporaryBlobReference, null)
            );

            string outputVersion = inputVersion;

            //if (pendingUploadResponse.Value.BlobReferenceForConsumption == null ||
            //    pendingUploadResponse.Value.BlobReferenceForConsumption.Credential?.Type != CredentialType.SAS ||
            //    string.IsNullOrEmpty(pendingUploadResponse.Value.BlobReferenceForConsumption.BlobUri))
            //{
            //    throw new InvalidOperationException("Invalid blob reference for consumption.");
            //}

            var containerClient = new BlobContainerClient(new Uri(pendingUploadResponse.Value.BlobReferenceForConsumption.BlobUri));
            return (containerClient, outputVersion);
        }

        /// <summary>
        /// Uploads a file to blob storage and creates a dataset that references this file.
        /// </summary>
        public DatasetVersion UploadFileAndCreate(string name, string version, string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File path: {filePath}");
                throw new ArgumentException($"The provided file does not exist: {filePath}.");
            }

            var (containerClient, outputVersion) = CreateDatasetAndGetContainerClient(name, version);

            using (var fileStream = File.OpenRead(filePath))
            {
                var blobName = Path.GetFileName(filePath);
                var blobClient = containerClient.GetBlobClient(blobName);
                blobClient.Upload(fileStream);

                return CreateVersion(
                    name,
                    outputVersion,
                    new FileDatasetVersion
                    {
                        DatasetUri = blobClient.Uri.AbsoluteUri,
                        Type = DatasetType.UriFile
                    }
                );
            }
        }

        /// <summary>
        /// Uploads all files in a folder to blob storage and creates a dataset that references this folder.
        /// </summary>
        public DatasetVersion UploadFolderAndCreate(string name, string version, string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"File path: {folderPath}");
                throw new ArgumentException($"The provided folder does not exist: {folderPath}");
            }

            var (containerClient, outputVersion) = CreateDatasetAndGetContainerClient(name, version);

            var filesUploaded = false;
            foreach (var filePath in Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                var relativePath = GetRelativePath(folderPath, filePath);
                using (var fileStream = File.OpenRead(filePath))
                {
                    var blobClient = containerClient.GetBlobClient(relativePath);
                    blobClient.Upload(fileStream);
                    filesUploaded = true;
                }
            }

            if (!filesUploaded)
            {
                throw new ArgumentException("The provided folder is empty.");
            }

            return CreateVersion(
                name,
                outputVersion,
                new FolderDatasetVersion
                {
                    DatasetUri = containerClient.Uri.AbsoluteUri,
                    Type = DatasetType.UriFolder
                }
            );
        }
        public static string GetRelativePath(string folderPath, string filePath)
        {
            if (string.IsNullOrEmpty(folderPath))
                throw new ArgumentNullException(nameof(folderPath));
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            Uri folderUri = new Uri(folderPath);
            Uri fileUri = new Uri(filePath);

            if (folderUri.Scheme != fileUri.Scheme)
            { return filePath; } // path can't be made relative.

            Uri relativeUri = folderUri.MakeRelativeUri(fileUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.AbsoluteUri);

            if (fileUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase))
            {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }
    }
}
