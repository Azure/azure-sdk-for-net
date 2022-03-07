﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Storage.Cryptography;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Represents a virtual directory of blobs, designated by a delimiter character.
    ///
    /// Blob Directories cannot be created to stand alone. In order to have a directory, there must be
    /// at least one blob within the virtual directory in order for the directory to exist.
    ///
    /// The concept of directories do not exist in the a standard account.
    /// If you are looking to organize your data in a collection into a hierarchy of
    /// directories and nested directories the same way a filesystem on your computer
    /// is organized see
    /// <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/data-lake-storage-namespace">
    /// Azure Data Lake Storage Gen2 Hierarchical Namespace</see>.
    /// </summary>
    public class BlobVirtualDirectoryClient
    {
        /// <summary>
        /// The virtual blob directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the virtual blob directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        internal virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        private readonly BlobClientOptions.ServiceVersion _version;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual BlobClientOptions.ServiceVersion Version => _version;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => _clientDiagnostics;

        /// <summary>
        /// The Storage account name corresponding to the blob directory client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the blob directory client.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                SetNameFieldsIfNull();
                return _accountName;
            }
        }

        /// <summary>
        /// The container name corresponding to the blob directory client.
        /// </summary>
        private string _containerName;

        /// <summary>
        /// Gets the container name corresponding to the blob directory client.
        /// </summary>
        public virtual string BlobContainerName
        {
            get
            {
                SetNameFieldsIfNull();
                return _containerName;
            }
        }

        /// <summary>
        /// The full path of the virtual blob directory which includes the name of the directory.
        /// </summary>
        private string _directoryPath;

        /// <summary>
        /// Gets the full path of the virtual blob directory which includes the name of the directory.
        /// </summary>
        public virtual string DirectoryPath
        {
            get
            {
                SetNameFieldsIfNull();
                return _directoryPath;
            }
        }

        /// <summary>
        /// The configuation<see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal readonly BlobClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal virtual BlobClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// A <see cref="BlobContainerClient"/> assoicated with the file system.
        /// </summary>
        internal readonly BlobContainerClient _containerClient;

        /// <summary>
        /// ContainerClient.
        /// </summary>
        internal virtual BlobContainerClient ContainerClient => _containerClient;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobVirtualDirectoryClient"/>
        /// class for mocking.
        /// </summary>
        protected BlobVirtualDirectoryClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobVirtualDirectoryClient"/>
        /// class for the same account as the <see cref="BlobServiceClient"/>.
        /// The new <see cref="BlobVirtualDirectoryClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobServiceClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobServiceClient"/>.</param>
        /// <param name="containerName">The name of the container containing the Blob Virtual Directory</param>
        /// <param name="directoryPath">The full directory path of the Blob Virtual Directory</param>
        public BlobVirtualDirectoryClient(
            BlobServiceClient client,
            string containerName,
            string directoryPath)
        {
            _uri = client.Uri;
            _pipeline = BlobServiceClientInternals.GetHttpPipeline(client);
            BlobClientOptions options = BlobServiceClientInternals.GetClientOptions(client);
            _version = options.Version;
            _directoryPath = directoryPath;
            _clientDiagnostics = new StorageClientDiagnostics(options);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(client.Uri)
            {
                BlobContainerName = containerName,
                BlobName = directoryPath
            };
            _uri = blobUriBuilder.ToUri();
            _containerClient = client.GetBlobContainerClient(containerName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobVirtualDirectoryClient"/>
        /// class for container associated with the <see cref="BlobContainerClient"/>.
        /// The new <see cref="BlobVirtualDirectoryClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="directoryPath">The full directory path of the Blob Virtual Directory</param>
        public BlobVirtualDirectoryClient(BlobContainerClient client, string directoryPath)
        {
            _directoryPath = directoryPath;
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(client.Uri)
            {
                BlobName = directoryPath
            };
            _uri = blobUriBuilder.ToUri();
            _containerClient = client;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobVirtualDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="blobDirectoryUri">
        /// A <see cref="Uri"/> referencing the blob directory that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob directory.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_directory}".
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        internal BlobVirtualDirectoryClient(
            Uri blobDirectoryUri,
            HttpPipelinePolicy authentication,
            BlobClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
        {
            Argument.AssertNotNull(blobDirectoryUri, nameof(blobDirectoryUri));
            options ??= new BlobClientOptions();
            _uri = blobDirectoryUri;

            _clientConfiguration = new BlobClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: storageSharedKeyCredential,
                clientDiagnostics: new StorageClientDiagnostics(options),
                version: options.Version,
                customerProvidedKey: options.CustomerProvidedKey,
                encryptionScope: options.EncryptionScope);

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }

        /// <summary>
        /// Helper to access protected static members of BlobServiceClient
        /// that should not be exposed directly to customers.
        /// </summary>
        private class BlobServiceClientInternals : BlobServiceClient
        {
            /// <summary>
            /// Prevent instantiation.
            /// </summary>
            private BlobServiceClientInternals() { }

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s <see cref="HttpPipeline"/>
            /// for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's HttpPipeline.</returns>
            public static new HttpPipeline GetHttpPipeline(BlobServiceClient client) =>
                BlobServiceClient.GetHttpPipeline(client);

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s authentication
            /// <see cref="HttpPipelinePolicy"/> for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's authentication policy.</returns>
            public static new HttpPipelinePolicy GetAuthenticationPolicy(BlobServiceClient client) =>
                BlobServiceClient.GetAuthenticationPolicy(client);

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s <see cref="BlobClientOptions"/>
            /// for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's BlobClientOptions.</returns>
            public static new BlobClientOptions GetClientOptions(BlobServiceClient client) =>
                BlobServiceClient.GetClientOptions(client);
        }

        /// <summary>
        /// Helper to access protected static members of BlobServiceClient
        /// that should not be exposed directly to customers.
        /// </summary>
        private class BlobContainerClientInternals : BlobContainerClient
        {
            /// <summary>
            /// Prevent instantiation.
            /// </summary>
            private BlobContainerClientInternals() { }

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s <see cref="HttpPipeline"/>
            /// for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's HttpPipeline.</returns>
            public static new HttpPipeline GetHttpPipeline(BlobContainerClient client) =>
                BlobContainerClient.GetHttpPipeline(client);

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s authentication
            /// <see cref="HttpPipelinePolicy"/> for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's authentication policy.</returns>
            public static new HttpPipelinePolicy GetAuthenticationPolicy(BlobContainerClient client) =>
                BlobContainerClient.GetAuthenticationPolicy(client);

            /// <summary>
            /// Get a <see cref="BlobServiceClient"/>'s <see cref="BlobClientOptions"/>
            /// for creating child clients.
            /// </summary>
            /// <param name="client">The BlobServiceClient.</param>
            /// <returns>The BlobServiceClient's BlobClientOptions.</returns>
            public static new BlobClientOptions GetClientOptions(BlobContainerClient client) =>
                BlobContainerClient.GetClientOptions(client);
        }
        #endregion

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobVirtualDirectoryClient"/>'s parent container.
        /// The new <see cref="BlobContainerClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobVirtualDirectoryClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        public virtual BlobContainerClient GetParentBlobContainerClient()
        {
            return GetParentBlobContainerClientCore();
        }

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobVirtualDirectoryClient"/>'s parent container.
        /// The new <see cref="BlobContainerClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobVirtualDirectoryClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        protected internal virtual BlobContainerClient GetParentBlobContainerClientCore()
        {
            //TODO: replace with proper clone of the container client
            return _containerClient;
        }

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobVirtualDirectoryClient"/>'s parent container.
        /// The new <see cref="BlobContainerClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobVirtualDirectoryClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        public virtual BlobClient GetBlobClient(string blobName)
        {
            return GetBlobClientCore(blobName);
        }

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobVirtualDirectoryClient"/>'s parent container.
        /// The new <see cref="BlobContainerClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobVirtualDirectoryClient"/>.
        /// </summary>
        /// <param name="blobName">Name of the blob</param>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        protected internal virtual BlobClient GetBlobClientCore(string blobName)
        {
            return _containerClient.GetBlobClient(blobName);
        }

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobVirtualDirectoryClient"/>'s parent container.
        /// The new <see cref="BlobContainerClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobVirtualDirectoryClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        public virtual BlockBlobClient GetBlockBlobClient(string blobName)
        {
            return GetBlockBlobClientCore(blobName);
        }

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobVirtualDirectoryClient"/>'s parent container.
        /// The new <see cref="BlobContainerClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobVirtualDirectoryClient"/>.
        /// </summary>
        /// <param name="blobName">Name of the blob</param>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        protected internal virtual BlockBlobClient GetBlockBlobClientCore(string blobName)
        {
            return _containerClient.GetBlockBlobClient(blobName);
        }

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_directoryPath == null || _containerName == null || _accountName == null)
            {
                var builder = new BlobUriBuilder(Uri);
                _directoryPath = builder.BlobName;
                _containerName = builder.BlobContainerName;
                _accountName = builder.AccountName;
            }
        }

        #region Upload
        /// <summary>
        /// The <see cref="Upload(string, bool, BlobDirectoryUploadOptions, CancellationToken)"/>
        /// operation overwrites the blobs contained in the blob directory, creating a
        /// blob if none exists.  Overwriting an existing blobs in the blob directory
        /// replaces any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For now this will only do block blobs. For the future, we can have in BlobUploadDirectoryOptions
        /// the option to set the blob type of page blobs and append blobs.
        ///
        /// TODO: implement overloads for overwrite parameter
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="sourceDirectoryPath">
        /// A string of the path to the local directory containing the local files to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether an existing blobs should be deleted and recreated.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual IEnumerable<Response<BlobContentInfo>> Upload(
#pragma warning restore AZC0015 // Unexpected client method return type.
            string sourceDirectoryPath,
            bool overwrite = false,
            BlobDirectoryUploadOptions options = default,
            CancellationToken cancellationToken = default) => UploadInternal(
                sourceDirectoryPath,
                overwrite,
                options,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadAsync(string, bool, BlobDirectoryUploadOptions, CancellationToken)"/>
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="sourceDirectoryPath">
        /// A string of the path to the local directory containing the local files to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether an existing blobs should be deleted and recreated.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<IEnumerable<Response<BlobContentInfo>>> UploadAsync(
#pragma warning disable AZC0015 // Unexpected client method return type.
            string sourceDirectoryPath,
            bool overwrite = false,
            BlobDirectoryUploadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await UploadInternal(
                sourceDirectoryPath,
                overwrite,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="UploadInternal"/>
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobRequestConditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="sourceDirectoryPath">
        /// The path of the local directory to upload.
        /// </param>
        /// <param name="options">
        /// Optional Parameters <see cref="BlobDirectoryUploadOptions"/>.
        /// </param>
        /// <param name="overwrite">
        /// Whether an existing blobs should be deleted and recreated.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<IEnumerable<Response<BlobContentInfo>>> UploadInternal(
            string sourceDirectoryPath,
            bool overwrite,
            BlobDirectoryUploadOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobVirtualDirectoryClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobVirtualDirectoryClient),
                    message:
                    $"{nameof(sourceDirectoryPath)}: {sourceDirectoryPath}\n" +
                    $"{nameof(options)}: {options}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobVirtualDirectoryClient)}.{nameof(Upload)}");

                try
                {
                    scope.Start();

                    string fullPath = Path.GetFullPath(sourceDirectoryPath);

                    PathScannerFactory scannerFactory = new PathScannerFactory(fullPath);
                    PathScanner scanner = scannerFactory.BuildPathScanner();
                    IEnumerable<FileSystemInfo> pathList = scanner.Scan();

                    int concurrency = options.TransferOptions.MaximumConcurrency.HasValue && options.TransferOptions.MaximumConcurrency > 0 ?
                        options.TransferOptions.MaximumConcurrency.GetValueOrDefault() : 1;
                    TaskThrottler throttler = new TaskThrottler(concurrency);

                    List<Response<BlobContentInfo>> responses = new List<Response<BlobContentInfo>>();

                    foreach (FileSystemInfo path in pathList)
                    {
                        if (path.GetType() == typeof(FileInfo))
                        {
                            // Replace backward slashes meant to be directory name separators
                            string blobName = path.FullName.Substring(fullPath.Length + 1);
                            blobName = blobName.Replace(@"\", "/");
                            BlobClient blobClient = ContainerClient.GetBlobClient(DirectoryPath + blobName);

                            throttler.AddTask(async () =>
                            {
                                responses.Add(await blobClient.UploadAsync(
                                       path.FullName.ToString(),
                                       overwrite,
                                       cancellationToken)
                                   .ConfigureAwait(false));
                            });
                        }
                    }

                    if (async)
                    {
                        await throttler.WaitAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        throttler.Wait();
                    }

                    return responses;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobVirtualDirectoryClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region Download
        /// <summary>
        /// The <see cref="DownloadTo(string)"/> operation downloads a blob using parallel requests,
        /// and writes the content to <paramref name="targetPath"/>.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual IEnumerable<Response> DownloadTo(string targetPath) =>
            DownloadTo(targetPath, CancellationToken.None);

        /// <summary>
        /// The <see cref="DownloadToAsync(string)"/> downloads all the blobs
        /// within a blob directory using parallel requests,
        /// and writes the content to the local <paramref name="targetPath"/>.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<IEnumerable<Response>> DownloadToAsync(string targetPath) =>
            await DownloadToAsync(targetPath, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadTo(string, CancellationToken)"/> downloads all the blobs
        /// within a blob directory using parallel requests,
        /// and writes the content to the local <paramref name="targetPath"/>.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual IEnumerable<Response> DownloadTo(
            string targetPath,
            CancellationToken cancellationToken) =>
            DownloadTo(
                targetPath,
                options: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="DownloadToAsync(string, CancellationToken)"/> downloads all the blobs
        /// within a blob directory using parallel requests,
        /// and writes the content to the local <paramref name="targetPath"/>.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<IEnumerable<Response>> DownloadToAsync(
            string targetPath,
            CancellationToken cancellationToken) =>
            await DownloadToAsync(
                targetPath,
                options: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadTo(string, BlobDirectoryDownloadOptions, CancellationToken)"/>
        /// downloads all the blobs within a blob directory using parallel requests,
        /// and writes the content to the local <paramref name="targetPath"/>.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="options">
        /// Optional Parameters <see cref="BlobDirectoryDownloadOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual IEnumerable<Response> DownloadTo(
            string targetPath,
            BlobDirectoryDownloadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(targetPath);
            return DownloadToInternal(
                targetPath,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadToAsync(string, BlobDirectoryDownloadOptions, CancellationToken)"/>
        /// downloads all the blobs within a blob directory using parallel requests,
        /// and writes the content to the local <paramref name="targetPath"/>.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="options">
        /// Optional Parameters <see cref="BlobDirectoryDownloadOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<IEnumerable<Response>> DownloadToAsync(
            string targetPath,
            BlobDirectoryDownloadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await DownloadToInternal(
                targetPath,
                async: true,
                options: options,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This operation will download a blob of arbitrary size by downloading it as individually staged
        /// partitions if it's larger than the
        /// <paramref name="options"/> MaximumTransferLength.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="options">
        /// Optional Parameters <see cref="BlobDirectoryDownloadOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<IEnumerable<Response>> DownloadToInternal(
            string targetPath,
            bool async,
            BlobDirectoryDownloadOptions options,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobVirtualDirectoryClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobVirtualDirectoryClient),
                    message:
                    $"{nameof(targetPath)}: {targetPath}\n" +
                    $"{nameof(options)}: {options}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobVirtualDirectoryClient)}.{nameof(DownloadTo)}");

                try
                {
                    scope.Start();

                    string fullPath = Path.GetFullPath(targetPath);

                    BlobContainerClient containerClient = GetParentBlobContainerClient();

                    int concurrency = options.TransferOptions.MaximumConcurrency.HasValue && options.TransferOptions.MaximumConcurrency > 0 ?
                        options.TransferOptions.MaximumConcurrency.GetValueOrDefault() : 1;
                    TaskThrottler throttler = new TaskThrottler(concurrency);

                    List<Response> responses = new List<Response>();

                    if (async)
                    {
                        long currentBlobsSuccesfullyTransferred = 0;
                        long currentBlobsSkippedTransferred = 0;
                        long currentBlobsFailedTransferred = 0;
                        //TODO: include back in after download progress handler merge
                        //long currentTotalBytesTransferred = 0;

                        // TODO: is this the best way to enumerate and then download as enumeration is happening?
                        await foreach (Page<BlobItem> page in GetBlobsAsync(cancellationToken: cancellationToken).AsPages().ConfigureAwait(false))
                        {
                            foreach (BlobItem blob in page.Values)
                            {
                                BlobBaseClient client = containerClient.GetBlobBaseClient(blob.Name);
                                string downloadPath = Path.Combine(fullPath, blob.Name.Substring(DirectoryPath.Length + 1));

                                throttler.AddTask(async () =>
                                {
                                    Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));

                                    // If the destination file doesn't exist
                                    // or it's specified to overwrite the existing file, then perform normal download
                                    if (options.OverwriteOptions == DownloadOverwriteMethod.Overwrite)
                                    {
                                        using (Stream destination = File.Create(downloadPath))
                                        {
                                            responses.Add(await client.DownloadToAsync(
                                                destination,
                                                default,
                                                options.TransferOptions,
                                                cancellationToken)
                                                .ConfigureAwait(false));
                                        }
                                    }
                                    else
                                    {
                                        bool fileExists = File.Exists(downloadPath);
                                        if (!fileExists)
                                        {
                                            using (Stream destination = File.Create(downloadPath))
                                            {
                                                responses.Add(await client.DownloadToAsync(
                                                    destination,
                                                    default,
                                                    options.TransferOptions,
                                                    cancellationToken)
                                                    .ConfigureAwait(false));
                                            }
                                        }
                                        else if (options.OverwriteOptions == DownloadOverwriteMethod.Skip)
                                        {
                                            options.ProgressHandler.Report(
                                                new BlobDownloadDirectoryProgress()
                                                {
                                                    BlobsSuccesfullyTransferred = currentBlobsSuccesfullyTransferred,
                                                    BlobsSkippedTransferred = currentBlobsSkippedTransferred,
                                                    BlobsFailedTransferred = currentBlobsFailedTransferred,
                                                    //TotalBytesTransferred = currentTotalBytesTransferred
                                                });
                                        }
                                    }
                                });
                            }
                        }
                    }
                    else
                    {
                        Pageable<BlobItem> blobs = GetBlobs(cancellationToken: cancellationToken);

                        foreach (BlobItem blob in blobs)
                        {
                            BlobBaseClient client = containerClient.GetBlobBaseClient(blob.Name);
                            string downloadPath = Path.Combine(fullPath, blob.Name.Substring(DirectoryPath.Length + 1));

                            throttler.AddTask(async () =>
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));
                                using (Stream destination = File.Create(downloadPath))
                                {
                                    responses.Add(await client.DownloadToAsync(
                                        destination,
                                        default,
                                        options.TransferOptions,
                                        cancellationToken)
                                        .ConfigureAwait(false));
                                }
                            });
                        }
                    }

                    if (async)
                    {
                        await throttler.WaitAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        throttler.Wait();
                    }

                    return responses;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobVirtualDirectoryClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Download

        #region GetBlobs
        /// <summary>
        /// The <see cref="GetBlobs"/> operation returns an async sequence
        /// of blobs in this container.  Enumerating the blobs may make
        /// multiple requests to the service while fetching all the values.
        /// Blobs are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="additionalPrefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <see cref="BlobVirtualDirectoryClient.DirectoryPath"/>
        /// <paramref name="additionalPrefix"/>. If not specified, it will list
        /// return only the blobs that begin with the <see cref="BlobVirtualDirectoryClient.DirectoryPath"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{T}"/> of <see cref="BlobItem"/>
        /// describing the blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Pageable<BlobItem> GetBlobs(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string additionalPrefix = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobVirtualDirectoryClient)}.{nameof(GetBlobs)}");
            try
            {
                scope.Start();

                additionalPrefix = additionalPrefix != null ? $"{DirectoryPath}/{additionalPrefix}" : DirectoryPath;

                return GetParentBlobContainerClient()
                    .GetBlobs(traits, states, additionalPrefix, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// The <see cref="GetBlobsAsync"/> operation returns an async
        /// sequence of blobs in this container.  Enumerating the blobs may
        /// make multiple requests to the service while fetching all the
        /// values.  Blobs are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="additionalPrefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="additionalPrefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual AsyncPageable<BlobItem> GetBlobsAsync(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string additionalPrefix = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobVirtualDirectoryClient)}.{nameof(GetBlobs)}");

            try
            {
                scope.Start();

                additionalPrefix = additionalPrefix != null ? $"{DirectoryPath}/{additionalPrefix}" : DirectoryPath;

                return GetParentBlobContainerClient()
                    .GetBlobsAsync(traits, states, additionalPrefix, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }
        #endregion GetBlobs

        #region GetBlobsByHierarchy
        /// <summary>
        /// The <see cref="GetBlobsByHierarchy"/> operation returns
        /// an async collection of blobs in this container.  Enumerating the
        /// blobs may make multiple requests to the service while fetching all
        /// the values.  Blobs are ordered lexicographically by name.   A
        /// <paramref name="delimiter"/> can be used to traverse a virtual
        /// hierarchy of blobs as though it were a file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="delimiter">
        /// A <paramref name="delimiter"/> that can be used to traverse a
        /// virtual hierarchy of blobs as though it were a file system.  The
        /// delimiter may be a single character or a string.
        /// <see cref="BlobHierarchyItem.Prefix"/> will be returned
        /// in place of all blobs whose names begin with the same substring up
        /// to the appearance of the delimiter character.  The value of a
        /// prefix is substring+delimiter, where substring is the common
        /// substring that begins one or more blob  names, and delimiter is the
        /// value of <paramref name="delimiter"/>. You can use the value of
        /// prefix to make a subsequent call to list the blobs that begin with
        /// this prefix, by specifying the value of the prefix for the
        /// <paramref name="additionalPrefix"/>.
        ///
        /// Note that each BlobPrefix element returned counts toward the
        /// maximum result, just as each Blob element does.
        /// </param>
        /// <param name="additionalPrefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="additionalPrefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{T}"/> of <see cref="BlobHierarchyItem"/>
        /// describing the blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Pageable<BlobHierarchyItem> GetBlobsByHierarchy(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string delimiter = default,
            string additionalPrefix = default,
            CancellationToken cancellationToken = default)
        {
            additionalPrefix = additionalPrefix != null ? $"{DirectoryPath}/{additionalPrefix}" : DirectoryPath;

            return GetParentBlobContainerClient().GetBlobsByHierarchy(traits, states, delimiter, additionalPrefix, cancellationToken);
        }

        /// <summary>
        /// The <see cref="GetBlobsByHierarchyAsync"/> operation returns
        /// an async collection of blobs in this container.  Enumerating the
        /// blobs may make multiple requests to the service while fetching all
        /// the values.  Blobs are ordered lexicographically by name.   A
        /// <paramref name="delimiter"/> can be used to traverse a virtual
        /// hierarchy of blobs as though it were a file system.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs">
        /// List Blobs</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the blobs.
        /// </param>
        /// <param name="states">
        /// Specifies state options for filtering the blobs.
        /// </param>
        /// <param name="delimiter">
        /// A <paramref name="delimiter"/> that can be used to traverse a
        /// virtual hierarchy of blobs as though it were a file system.  The
        /// delimiter may be a single character or a string.
        /// <see cref="BlobHierarchyItem.Prefix"/> will be returned
        /// in place of all blobs whose names begin with the same substring up
        /// to the appearance of the delimiter character.  The value of a
        /// prefix is substring+delimiter, where substring is the common
        /// substring that begins one or more blob  names, and delimiter is the
        /// value of <paramref name="delimiter"/>. You can use the value of
        /// prefix to make a subsequent call to list the blobs that begin with
        /// this prefix, by specifying the value of the prefix for the
        /// <paramref name="additionalPrefix"/>.
        ///
        /// Note that each BlobPrefix element returned counts toward the
        /// maximum result, just as each Blob element does.
        /// </param>
        /// <param name="additionalPrefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="additionalPrefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual AsyncPageable<BlobHierarchyItem> GetBlobsByHierarchyAsync(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string delimiter = default,
            string additionalPrefix = default,
            CancellationToken cancellationToken = default)
        {
            additionalPrefix = additionalPrefix != null ? $"{DirectoryPath}/{additionalPrefix}" : DirectoryPath;

            return GetParentBlobContainerClient().GetBlobsByHierarchyAsync(traits, states, delimiter, additionalPrefix, cancellationToken);
        }
        #endregion GetBlobsByHierarchy
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobServiceClient"/> for
    /// creating <see cref="BlobVirtualDirectoryClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="BlobVirtualDirectoryClient"/> object for the same
        /// account as the <see cref="BlobServiceClient"/>.  The new
        /// <see cref="BlobVirtualDirectoryClient"/> uses the same request policy pipeline
        /// as the <see cref="BlobServiceClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobServiceClient"/>.</param>
        /// <param name="containerName">The name of the container containing the Blob Virtual Directory</param>
        /// <param name="directoryPath">The full directory path of the Blob Virtual Directory</param>
        /// <returns>A new <see cref="BlobVirtualDirectoryClient"/> instance.</returns>
        public static BlobVirtualDirectoryClient GetBlobVirtualDirectoryClient(
            this BlobServiceClient client,
            string containerName,
            string directoryPath)
                => new BlobVirtualDirectoryClient(client, containerName, directoryPath);

    /// <summary>
    /// Create a new <see cref="BlobVirtualDirectoryClient"/> object for the
    /// container associated with the  <see cref="BlobContainerClient"/>.  The new
    /// <see cref="BlobVirtualDirectoryClient"/> uses the same request policy pipeline
    /// as the <see cref="BlobContainerClient"/>.
    /// </summary>
    /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
    /// <param name="directoryPath">The full directory path of the Blob Virtual Directory</param>
    /// <returns>A new <see cref="BlobVirtualDirectoryClient"/> instance.</returns>
    public static BlobVirtualDirectoryClient GetBlobVirtualDirectoryClient(
        this BlobContainerClient client,
        string directoryPath)
            => new BlobVirtualDirectoryClient(client, directoryPath);
    }
}
