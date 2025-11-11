// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

# nullable enable

using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Storage.Blobs;

namespace Azure.AI.Projects
{
    public partial class AIProjectDatasetsOperations
    {
        private readonly AuthenticationTokenProvider _tokenProvider;

        /// <summary> Initializes a new instance of Datasets with TokenProvider. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="apiVersion"> API version. </param>
        /// <param name="tokenProvider"> Token Provider for authentication. </param>
        internal AIProjectDatasetsOperations(ClientPipeline pipeline, Uri endpoint, string apiVersion, AuthenticationTokenProvider tokenProvider)
            : this(pipeline, endpoint, apiVersion)
        {
            _tokenProvider = tokenProvider;
        }

        /// <summary>
        /// Uploads a file to blob storage and creates a dataset that references this file.
        /// </summary>
        public ClientResult<FileDataset> UploadFile(string name, string version, string filePath, string? connectionName = null)
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

                FileDataset fileDataset = new FileDataset(dataUri: dataUri);
                BinaryContent content = BinaryContent.Create(fileDataset);

                ClientResult result = CreateOrUpdate(name, outputVersion, content);

                return ClientResult.FromValue((FileDataset)result, result.GetRawResponse());
            }
        }

        /// <summary>
        /// Uploads all files in a folder to blob storage and creates a dataset that references this folder.
        /// </summary>
        public ClientResult<FolderDataset> UploadFolder(string name, string version, string folderPath, string? connectionName = null, Regex? filePattern = null)
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

            FolderDataset folderDataset = new FolderDataset(dataUri: dataUri);
            BinaryContent content = BinaryContent.Create(folderDataset);

            ClientResult result = CreateOrUpdate(name, outputVersion, content);
            return ClientResult.FromValue((FolderDataset)result, result.GetRawResponse());
        }

        /// <summary>
        /// Uploads a file to blob storage and creates a dataset that references this file.
        /// </summary>
        public async Task<ClientResult<FileDataset>> UploadFileAsync(string name, string version, string filePath, string? connectionName = null)
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

                FileDataset fileDataset = new FileDataset(dataUri: dataUri);
                BinaryContent content = BinaryContent.Create(fileDataset);

                ClientResult result = await CreateOrUpdateAsync(name, outputVersion, content).ConfigureAwait(false);

                return ClientResult.FromValue((FileDataset)result, result.GetRawResponse());
            }
        }

        /// <summary>
        /// Uploads all files in a folder to blob storage and creates a dataset that references this folder.
        /// </summary>
        public async Task<ClientResult<FolderDataset>> UploadFolderAsync(string name, string version, string folderPath, string? connectionName = null, Regex? filePattern = null)
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

            FolderDataset folderDataset = new FolderDataset(dataUri: dataUri);
            BinaryContent content = BinaryContent.Create(folderDataset);
            ClientResult result = await CreateOrUpdateAsync(name, outputVersion, content).ConfigureAwait(false);

            return ClientResult.FromValue((FolderDataset)result, result.GetRawResponse());
        }

        /// <summary>
        /// Internal helper method to create a new dataset and return a BlobContainerClient to the dataset's blob storage.
        /// </summary>
        private (BlobContainerClient ContainerClient, string OutputVersion) CreateDatasetAndGetContainerClient(string name, string inputVersion, string? connectionName = null)
        {
            var pendingUploadConfiguration = new PendingUploadConfiguration(
                pendingUploadId: null,
                connectionName: connectionName,
                pendingUploadType: PendingUploadType.BlobReference,
                additionalBinaryDataProperties: null);

            PendingUploadResult pendingUploadResult = PendingUpload(
                name: name,
                version: inputVersion,
                configuration: pendingUploadConfiguration
            );

            string outputVersion = inputVersion;

            return (GetContainerClientOrRaise(pendingUploadResult), outputVersion);
        }

        /// <summary>
        /// The convenience method to get the container client.
        /// </summary>
        /// <param name="pendingUploadResult">The pending upload request.</param>
        /// <returns></returns>
        private BlobContainerClient GetContainerClientOrRaise(PendingUploadResult pendingUploadResult)
        {
            bool isSasEmpty = false;

            if (pendingUploadResult.BlobReference == null)
            {
                throw new InvalidOperationException("Blob reference is not present.");
            }
            if (pendingUploadResult.BlobReference.Credential == null)
            {
                throw new InvalidOperationException("SAS credential is not present.");
            }
            if (pendingUploadResult.BlobReference.Credential.SasUri == null)
            {
                isSasEmpty = true;
            }

            BlobContainerClient containerClient;
            if (isSasEmpty)
            {
                if (_tokenProvider is TokenCredential tokenCredential)
                {
                    containerClient = new BlobContainerClient(
                        blobContainerUri: pendingUploadResult.BlobReference.BlobUri,
                        credential: tokenCredential,
                        options: null);
                }
                else
                {
                    throw new InvalidOperationException("SAS URI is empty and no TokenCredential is provided for authentication.");
                }
            }
            else
            {
                containerClient = new BlobContainerClient(pendingUploadResult.BlobReference.Credential.SasUri);
            }
            return containerClient;
        }

        /// <summary>
        /// Internal helper method to create a new dataset and return a BlobContainerClient to the dataset's blob storage.
        /// </summary>
        private async Task<(BlobContainerClient ContainerClient, string OutputVersion)> CreateDatasetAndGetContainerClientAsync(string name, string inputVersion, string? connectionName = null)
        {
            PendingUploadConfiguration pendingUploadRequest = new(
                pendingUploadId: null,
                connectionName: connectionName,
                pendingUploadType: PendingUploadType.BlobReference,
                additionalBinaryDataProperties: null);

            PendingUploadResult pendingUploadResult = await PendingUploadAsync(
                name: name,
                version: inputVersion,
                configuration: pendingUploadRequest
            ).ConfigureAwait(false);

            string outputVersion = inputVersion;

            return (GetContainerClientOrRaise(pendingUploadResult), outputVersion);
        }
    }
}
