// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Runtime.InteropServices.ComTypes;

namespace Azure.AI.Projects
{
    public partial class Datasets
    {
        /// <summary>
        /// Internal helper method to create a new dataset and return a BlobContainerClient to the dataset's blob storage.
        /// </summary>
        private (BlobContainerClient ContainerClient, string OutputVersion) CreateDatasetAndGetContainerClient(string name, string inputVersion)
        {
            var pendingUploadResponse = PendingUpload(
                name,
                inputVersion,
                new PendingUploadRequest(null, null, PendingUploadType.BlobReference, null)
            );

            string outputVersion = inputVersion;

            //if (pendingUploadResponse.Value.BlobReferenceForConsumption == null ||
            //    pendingUploadResponse.Value.BlobReferenceForConsumption.Credential?.Type != CredentialType.SAS ||
            //    string.IsNullOrEmpty(pendingUploadResponse.Value.BlobReferenceForConsumption.BlobUri))
            //{
            //    throw new InvalidOperationException("Invalid blob reference for consumption.");
            //}

            var containerClient = new BlobContainerClient(
                blobContainerUri: new Uri(pendingUploadResponse.Value.BlobReference.BlobUri),
                credential: _tokenCredential,
                options: null);
            return (containerClient, outputVersion);
        }

        /// <summary>
        /// Uploads a file to blob storage and creates a dataset that references this file.
        /// </summary>
        public Response<FileDatasetVersion> UploadFile(string name, string version, string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File path: {filePath}");
                throw new ArgumentException($"The provided file does not exist: {filePath}.");
            }

            var (containerClient, outputVersion) = CreateDatasetAndGetContainerClient(name, version);

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                var blobName = Path.GetFileName(filePath);
                var blobClient = containerClient.GetBlobClient(blobName);
                blobClient.Upload(fileStream);

                RequestContent content = (new FileDatasetVersion(dataUri: blobClient.Uri.AbsoluteUri)).ToRequestContent();

                Response response = CreateOrUpdate(
                    name,
                    outputVersion,
                    content,
                    new RequestContext()
                );

                return Response.FromValue(FileDatasetVersion.FromResponse(response), response);
            }
        }

        /// <summary>
        /// Uploads all files in a folder to blob storage and creates a dataset that references this folder.
        /// </summary>
        public Response<FolderDatasetVersion> UploadFolder(string name, string version, string folderPath)
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
                string relativePath = GetRelativePath(folderPath, filePath);
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

            RequestContent content = (new FolderDatasetVersion(dataUri: containerClient.Uri.AbsoluteUri)).ToRequestContent();
            Response response = CreateOrUpdate(
                name,
                outputVersion,
                content
            );
            return Response.FromValue(FolderDatasetVersion.FromResponse(response), response);
        }
        public static string GetRelativePath(string folderPath, string filePath)
        {
            if (string.IsNullOrEmpty(folderPath))
                throw new ArgumentNullException(nameof(folderPath));
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            Uri folderUri = new(folderPath);
            Uri fileUri = new(filePath);

            if (folderUri.Scheme != fileUri.Scheme)
            { return filePath; } // path can't be made relative.

            Uri relativeUri = folderUri.MakeRelativeUri(fileUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.OriginalString);

            if (fileUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase))
            {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }
    }
}
