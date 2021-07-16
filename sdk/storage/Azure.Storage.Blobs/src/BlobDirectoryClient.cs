// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Cryptography;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized
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
    public class BlobDirectoryClient
    {
        /// <summary>
        /// The blob directory's primary <see cref="Uri"/> endpoint.
        /// TODO: better docs
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the blob directory's primary <see cref="Uri"/> endpoint.
        /// TODO: better docs
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// TODO: better docs
        /// </summary>
        internal readonly BlobClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// TODO: better docs
        /// </summary>
        internal virtual BlobClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        private readonly ClientSideEncryptionOptions _clientSideEncryption;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        internal virtual ClientSideEncryptionOptions ClientSideEncryption => _clientSideEncryption;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
        /// class for mocking.
        /// </summary>
        protected BlobDirectoryClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this blob directory.
        /// </param>
        /// <param name="blobDirectoryPath">
        /// The path of the blob directory.
        /// </param>
        public BlobDirectoryClient(string connectionString, string blobContainerName, string blobDirectoryPath)
            : this(connectionString, blobContainerName, blobDirectoryPath, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this blob directory.
        /// </param>
        /// <param name="blobDirectoryPath">
        /// The path of this blob directory.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobDirectoryClient(string connectionString, string blobContainerName, string blobDirectoryPath, BlobClientOptions options)
        {
            options ??= new BlobClientOptions();
            var conn = StorageConnectionString.Parse(connectionString);
            var builder =
                new BlobUriBuilder(conn.BlobEndpoint)
                {
                    BlobContainerName = blobContainerName,
                    BlobName = blobDirectoryPath
                };
            _uri = builder.ToUri();

            _clientConfiguration = new BlobClientConfiguration(
                pipeline: options.Build(conn.Credentials),
                sharedKeyCredential: conn.Credentials as StorageSharedKeyCredential,
                clientDiagnostics: new StorageClientDiagnostics(options),
                version: options.Version,
                customerProvidedKey: options.CustomerProvidedKey,
                encryptionScope: options.EncryptionScope);

            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="blobDirectoryUri">
        /// A <see cref="Uri"/> referencing the blob directory that includes the
        /// name of the account, the name of the container, and the path to
        /// the blob directory.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_directory}".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobDirectoryClient(Uri blobDirectoryUri, BlobClientOptions options = default)
            : this(blobDirectoryUri, (HttpPipelinePolicy)null, options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="blobDirectoryUri">
        /// A <see cref="Uri"/> referencing the blob directory that includes the
        /// name of the account, the name of the container, and the path of
        /// the blob directory.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_directory}".
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobDirectoryClient(Uri blobDirectoryUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : this(blobDirectoryUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="blobDirectoryUri">
        /// A <see cref="Uri"/> referencing the blob directory that includes the
        /// name of the account, the name of the container, and the path of
        /// the blob directory.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_directory}".
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public BlobDirectoryClient(Uri blobDirectoryUri, AzureSasCredential credential, BlobClientOptions options = default)
            : this(blobDirectoryUri, credential.AsPolicy<BlobUriBuilder>(blobDirectoryUri), options, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="blobDirectoryUri">
        /// A <see cref="Uri"/> referencing the blob directory that includes the
        /// name of the account, the name of the container, and the path of
        /// the blob directory.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_directory}".
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobDirectoryClient(Uri blobDirectoryUri, TokenCredential credential, BlobClientOptions options = default)
            : this(blobDirectoryUri, credential.AsPolicy(), options, null)
        {
            Errors.VerifyHttpsTokenAuth(blobDirectoryUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
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
        internal BlobDirectoryClient(
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

            _clientSideEncryption = options._clientSideEncryptionOptions?.Clone();

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="blobDirectoryUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the path of
        /// the blob directory.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_directory}".
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="BlobClientConfiguration"/>.
        /// </param>
        /// <param name="clientSideEncryption">
        /// Client-side encryption options.
        /// </param>
        internal BlobDirectoryClient(
            Uri blobDirectoryUri,
            BlobClientConfiguration clientConfiguration,
            ClientSideEncryptionOptions clientSideEncryption)
        {
            _uri = blobDirectoryUri;
            if (!string.IsNullOrEmpty(blobDirectoryUri.Query))
            {
                UriQueryParamsCollection queryParamsCollection = new UriQueryParamsCollection(blobDirectoryUri.Query);
            }

            _clientConfiguration = clientConfiguration;
            _clientSideEncryption = clientSideEncryption?.Clone();

            BlobErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
            BlobErrors.VerifyCpkAndEncryptionScopeNotBothSet(_clientConfiguration.CustomerProvidedKey, _clientConfiguration.EncryptionScope);
        }
        #endregion

        /// <summary>
        /// Create a new <see cref="BlobClient"/> object by appending
        /// <paramref name="blobName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="BlobClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        public virtual BlobClient GetBlobClient(string blobName)
        {
            return new BlobClient(
                Uri.AppendToPath(blobName),
                ClientConfiguration,
                ClientSideEncryption);
        }

        #region Upload
        /// <summary>
        /// The <see cref="Upload(string, StorageTransferOptions, BlobDirectoryUploadOptions, CancellationToken)"/>
        /// operation overwrites the contents of the blob directory, creating a new blob
        /// if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For now this will only do block blobs. For the future, we can have in BlobUploadDirectoryOptions
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="localPath">
        /// A <see cref="Directory"/> containing the content to upload.
        /// </param>
        /// <param name="transferOptions">
        /// A <see cref="StorageTransferOptions"/> item containing settings for upload.
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
            string localPath,
            StorageTransferOptions transferOptions,
            BlobDirectoryUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            return UploadInternal(
                localPath,
                null,
                transferOptions,
                options,
                async: false,
                cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="UploadAsync(string, StorageTransferOptions, BlobDirectoryUploadOptions, CancellationToken)"/>
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
        /// <param name="localPath">
        /// The path of the local directory to upload.
        /// </param>
        /// <param name="transferOptions">
        /// A <see cref="StorageTransferOptions"/> item containing settings for upload.
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
        ///
        [ForwardsClientCalls]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<IEnumerable<Response<BlobContentInfo>>> UploadAsync(
#pragma warning disable AZC0015 // Unexpected client method return type.
            string localPath,
            StorageTransferOptions transferOptions,
            BlobDirectoryUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            return await UploadInternal(
                localPath,
                null,
                transferOptions,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="Upload(string, StorageTransferOptions, BlobDirectoryUploadOptions, CancellationToken)"/>
        /// operation overwrites the contents of the blob directory, creating a new blob
        /// if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
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
        /// <param name="localPath">
        /// A string of the path to the local directory containing the local files to upload.
        /// </param>
        /// <param name="remotePath">
        /// A string of the path to the remote virtual directory where files will be uploaded.
        /// </param>
        /// <param name="transferOptions">
        /// A <see cref="StorageTransferOptions"/> item containing settings for upload.
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
            string localPath,
            string remotePath,
            StorageTransferOptions transferOptions,
            BlobDirectoryUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            return UploadInternal(
                localPath,
                remotePath,
                transferOptions,
                options,
                async: false,
                cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="UploadAsync(string, StorageTransferOptions, BlobDirectoryUploadOptions, CancellationToken)"/>
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
        /// <param name="localPath">
        /// A string of the path to the local directory containing the local files to upload.
        /// </param>
        /// <param name="remotePath">
        /// A string of the path to the remote virtual directory where files will be uploaded.
        /// </param>
        /// <param name="transferOptions">
        /// A <see cref="StorageTransferOptions"/> item containing settings for upload.
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
            string localPath,
            string remotePath,
            StorageTransferOptions transferOptions,
            BlobDirectoryUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            return await UploadInternal(
                localPath,
                remotePath,
                transferOptions,
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
        /// <param name="localPath">
        /// The path of the local directory to upload.
        /// </param>
        /// <param name="remotePath">
        /// The remote path of the virtual directory to which to upload.
        /// </param>
        /// <param name="transferOptions">
        /// A <see cref="StorageTransferOptions"/> item containing settings for upload.
        /// </param>
        /// <param name="options">
        /// Optional Parameters <see cref="BlobDirectoryUploadOptions"/>
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
        /// TODO: remove pragma warning after adding await operators
        internal async Task<IEnumerable<Response<BlobContentInfo>>> UploadInternal(
            string localPath,
            string remotePath,
            StorageTransferOptions transferOptions,
            BlobDirectoryUploadOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobDirectoryClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobDirectoryClient),
                    message:
                    $"{nameof(localPath)}: {localPath}\n" +
                    $"{nameof(options)}: {options}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobDirectoryClient)}.{nameof(Upload)}");

                try
                {
                    scope.Start();

                    Uri targetUri = Uri;

                    if (remotePath != null)
                        targetUri = targetUri.AppendToPath(remotePath);

                    targetUri = options.UploadToSubdirectory.HasValue && (bool)options.UploadToSubdirectory
                        ? targetUri.AppendToPath(localPath.Split('\\').Last())
                        : targetUri;

                    BlobUploadScheduler scheduler = new BlobUploadScheduler(targetUri, ClientConfiguration, ClientSideEncryption);

                    return await scheduler.StartTransfer(
                        localPath,
                        transferOptions,
                        options,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobDirectoryClient));
                    scope.Dispose();
                }
            }
        }
        #endregion

        #region Download
        /// <summary>
        /// The <see cref="Download(string)"/> operation downloads a blob using parallel requests,
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
        public virtual Response Download(string targetPath) =>
            Download(targetPath, CancellationToken.None);

        /// <summary>
        /// The <see cref="DownloadAsync(string)"/> downloads all the blobs
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
        public virtual async Task<Response> DownloadAsync(string targetPath) =>
            await DownloadAsync(targetPath, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Download(string, CancellationToken)"/> downloads all the blobs
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
        public virtual Response Download(
            string targetPath,
            CancellationToken cancellationToken) =>
            Download(
                targetPath,
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="DownloadAsync(string, CancellationToken)"/> downloads all the blobs
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
        public virtual async Task<Response> DownloadAsync(
            string targetPath,
            CancellationToken cancellationToken) =>
            await DownloadAsync(
                targetPath,
                conditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Download(string, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// downloads all the blobs within a blob directory using parallel requests,
        /// and writes the content to the local <paramref name="targetPath"/>.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
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
        public virtual Response Download(
            string targetPath,
            BlobRequestConditions conditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{Long}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(targetPath);
            return StagedDownloadAsync(
                targetPath,
                conditions,
                //progressHandler, // TODO: #8506
                transferOptions: transferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadAsync(string, BlobRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// downloads all the blobs within a blob directory using parallel requests,
        /// and writes the content to the local <paramref name="targetPath"/>.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
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
        public virtual async Task<Response> DownloadAsync(
            string targetPath,
            BlobRequestConditions conditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{Long}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            return await StagedDownloadAsync(
                targetPath,
                conditions,
                //progressHandler, // TODO: #8506
                transferOptions: transferOptions,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This operation will download a blob of arbitrary size by downloading it as individually staged
        /// partitions if it's larger than the
        /// <paramref name="transferOptions"/> MaximumTransferLength.
        /// </summary>
        /// <param name="targetPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
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
        /// TODO: remove static
        internal static async Task<Response> StagedDownloadAsync(
            string targetPath,
            BlobRequestConditions conditions = default,
            ///// <param name="progressHandler">
            ///// Optional <see cref="IProgress{Long}"/> to provide
            ///// progress updates about data transfers.
            ///// </param>
            //IProgress<long> progressHandler, // TODO: #8506
            StorageTransferOptions transferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            //TODO: implement directory download
            BlobBaseClient client = new BlobBaseClient(new Uri("fakeUri"));
            using Stream destination = File.Create(targetPath);
            PartitionedDownloader downloader = new PartitionedDownloader(client, transferOptions);

            if (async)
            {
                return await downloader.DownloadToAsync(destination, conditions, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return downloader.DownloadTo(destination, conditions, cancellationToken);
            }
        }
        #endregion Download
    }
}
