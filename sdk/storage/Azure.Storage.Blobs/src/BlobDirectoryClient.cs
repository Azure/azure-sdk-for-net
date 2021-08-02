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
        /// The name of the virtual blob directory.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the virtual blob directory.
        /// </summary>
        public virtual string Name
        {
            get
            {
                SetNameFieldsIfNull();
                return _name;
            }
        }

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
            : this(blobDirectoryUri, credential.AsPolicy(options), options, null)
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
        /// pipeline as the <see cref="BlobDirectoryClient"/>.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        public virtual BlobClient GetBlobClient(string blobName)
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                BlobName = $"{Name}/{blobName}"
            };

            return new BlobClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration,
                ClientSideEncryption);
        }

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobDirectoryClient"/>'s parent container.
        /// The new <see cref="BlobContainerClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobDirectoryClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        public virtual BlobContainerClient GetParentBlobContainerClient()
        {
            return GetParentBlobContainerClientCore();
        }

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        private void SetNameFieldsIfNull()
        {
            if (_name == null || _containerName == null || _accountName == null)
            {
                var builder = new BlobUriBuilder(Uri);
                _name = builder.BlobName;
                _containerName = builder.BlobContainerName;
                _accountName = builder.AccountName;
            }
        }

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
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="prefix"/>.
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
        public virtual Pageable<BlobItem> GetBlobs(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default)
        {
            prefix = prefix != null ? $"{Name}/{prefix}" : Name;

            return GetParentBlobContainerClient()
                .GetBlobs(traits, states, prefix, cancellationToken);
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
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified <paramref name="prefix"/>.
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
        public virtual AsyncPageable<BlobItem> GetBlobsAsync(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default)
        {
            prefix = prefix != null ? $"{Name}/{prefix}" : Name;

            return GetParentBlobContainerClient()
                .GetBlobsAsync(traits, states, prefix, cancellationToken);
        }
        #endregion GetBlobs

        #region Upload
        /// <summary>
        /// The <see cref="Upload(string, BlobDirectoryUploadOptions, CancellationToken)"/>
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
            BlobDirectoryUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            return UploadInternal(
                localPath,
                null,
                options,
                async: false,
                cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="UploadAsync(string, BlobDirectoryUploadOptions, CancellationToken)"/>
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
            BlobDirectoryUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            return await UploadInternal(
                localPath,
                null,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="Upload(string, BlobDirectoryUploadOptions, CancellationToken)"/>
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
            BlobDirectoryUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            return UploadInternal(
                localPath,
                remotePath,
                options,
                async: false,
                cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="UploadAsync(string, BlobDirectoryUploadOptions, CancellationToken)"/>
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
            BlobDirectoryUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            return await UploadInternal(
                localPath,
                remotePath,
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
        /// <param name="options">
        /// Optional Parameters <see cref="BlobDirectoryUploadOptions"/>.
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

                    string fullPath = Path.GetFullPath(localPath);

                    PathScannerFactory scannerFactory = new PathScannerFactory(fullPath);
                    PathScanner scanner = scannerFactory.BuildPathScanner();
                    IEnumerable<FileSystemInfo> fileList = scanner.Scan();

                    int concurrency = options.TransferOptions.MaximumConcurrency.HasValue && options.TransferOptions.MaximumConcurrency > 0 ?
                        options.TransferOptions.MaximumConcurrency.GetValueOrDefault() : 1;
                    TaskThrottler throttler = new TaskThrottler(concurrency);

                    List<Response<BlobContentInfo>> responses = new List<Response<BlobContentInfo>>();

                    foreach (FileSystemInfo file in fileList)
                    {
                        if (file.GetType() == typeof(DirectoryInfo))
                        {
                            continue;
                        }

                        throttler.AddTask(async () =>
                        {
                            string blobName = remotePath != null ?
                                $"{remotePath}/{file.FullName.Substring(fullPath.Length + 1)}" :
                                file.FullName.Substring(fullPath.Length + 1);

                            responses.Add(await GetBlobClient(blobName)
                               .UploadAsync(
                                   file.FullName,
                                   cancellationToken)
                               .ConfigureAwait(false));
                        });
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
        [ForwardsClientCalls]
        public virtual IEnumerable<Response> Download(string targetPath) =>
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
        [ForwardsClientCalls]
        public virtual async Task<IEnumerable<Response>> DownloadAsync(string targetPath) =>
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
        [ForwardsClientCalls]
        public virtual IEnumerable<Response> Download(
            string targetPath,
            CancellationToken cancellationToken) =>
            Download(
                targetPath,
                options: default, // Pass anything else so we don't recurse on this overload
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
        [ForwardsClientCalls]
        public virtual async Task<IEnumerable<Response>> DownloadAsync(
            string targetPath,
            CancellationToken cancellationToken) =>
            await DownloadAsync(
                targetPath,
                options: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Download(string, BlobDirectoryDownloadOptions, CancellationToken)"/>
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
        public virtual IEnumerable<Response> Download(
            string targetPath,
            BlobDirectoryDownloadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return StagedDownloadAsync(
                targetPath,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadAsync(string, BlobDirectoryDownloadOptions, CancellationToken)"/>
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
        public virtual async Task<IEnumerable<Response>> DownloadAsync(
            string targetPath,
            BlobDirectoryDownloadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await StagedDownloadAsync(
                targetPath,
                options: options,
                async: true,
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
        /// <param name="options">
        /// Optional Parameters <see cref="BlobDirectoryDownloadOptions"/>.
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
        internal async Task<IEnumerable<Response>> StagedDownloadAsync(
            string targetPath,
            BlobDirectoryDownloadOptions options,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobDirectoryClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(BlobDirectoryClient),
                    message:
                    $"{nameof(targetPath)}: {targetPath}\n" +
                    $"{nameof(options)}: {options}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobDirectoryClient)}.{nameof(Download)}");

                try
                {
                    scope.Start();

                    string fullPath = Path.GetFullPath(targetPath);

                    BlobContainerClient containerClient = GetParentBlobContainerClient();

                    Pageable<BlobItem> blobs = GetBlobs(cancellationToken: cancellationToken);

                    BlobRequestConditions conditions = new BlobRequestConditions()
                    {
                        IfModifiedSince = options.DirectoryRequestConditions.IfModifiedSince ?? null,
                        IfUnmodifiedSince = options.DirectoryRequestConditions.IfUnmodifiedSince ?? null,
                    };

                    int concurrency = options.TransferOptions.MaximumConcurrency.HasValue && options.TransferOptions.MaximumConcurrency > 0 ?
                        options.TransferOptions.MaximumConcurrency.GetValueOrDefault() : 1;
                    TaskThrottler throttler = new TaskThrottler(concurrency);

                    List<Response> responses = new List<Response>();

                    foreach (BlobItem blob in blobs)
                    {
                        BlobBaseClient client = containerClient.GetBlobBaseClient(blob.Name);
                        string downloadPath = Path.Combine(fullPath, blob.Name.Substring(Name.Length + 1));

                        throttler.AddTask(async () =>
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));
                            using (Stream destination = File.Create(downloadPath))
                            {
                                responses.Add(await client.DownloadToAsync(
                                    destination,
                                    conditions,
                                    options.TransferOptions,
                                    cancellationToken)
                                    .ConfigureAwait(false));
                            }
                        });
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobDirectoryClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Download

        #region StartCopyFromUri
        /// <summary>
        /// The <see cref="StartCopyFromUri(Uri, BlobDirectoryCopyFromUriOptions, CancellationToken)"/>
        /// operation begins an asynchronous copy of the data from the <paramref name="sourceDirectoryUri"/> to this
        /// blob directory. It will make a <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">
        /// Copy Blob</see>. for each blob in the source blob directory.
        ///
        /// TODO: Proper response type for copy from directory uri
        /// </summary>
        /// <param name="sourceDirectoryUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  A source blob in the same storage account can be
        /// authenticated via Shared Key.  However, if the source is a blob in
        /// another account, the source blob must either be public or must be
        /// authenticated via a shared access signature. If the source blob
        /// is public, no authentication is required to perform the copy
        /// operation.
        ///
        /// The source object may be a file in the Azure File service.  If the
        /// source object is a file that is to be copied to a blob, then the
        /// source file must be authenticated using a shared access signature,
        /// whether it resides in the same account or in a different account.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="CopyFromUriOperation"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual CopyFromUriOperation StartCopyFromUri(
            Uri sourceDirectoryUri,
            BlobDirectoryCopyFromUriOptions options,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = StartCopyFromUriInternal(
                sourceDirectoryUri,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();
            // TODO: Create actual return type specific to DirectoryCopyResults
            // CopyFromUriOperation will be exchanged the progress tracking in the options bag.
            // TODO: remove stub.
            return default;
        }

        /// <summary>
        /// The <see cref="StartCopyFromUriAsync(Uri, BlobDirectoryCopyFromUriOptions, CancellationToken)"/>
        /// operation begins an asynchronous copy of the data from the <paramref name="sourceDirectoryUri"/> to this
        /// blob directory. It will make a <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">
        /// Copy Blob</see>. for each blob in the source blob directory.
        ///
        /// TODO: Proper response type for copy from directory uri
        /// </summary>
        /// <param name="sourceDirectoryUri">
        /// Specifies the <see cref="Uri"/> of the source blob directory.
        /// The value may be a <see cref="Uri" /> of up to 2 KB in length that
        /// specifies a diretory blob.  A source directory blob in the same
        /// storage account can be authenticated via Shared Key.
        /// However, if the source is a directory blob in another account,
        /// the source directory blob must either be public or must be
        /// authenticated via a shared access signature. If the source directory
        /// blob is public, no authentication is required to perform the copy
        /// operation.
        ///
        /// The source object may be a file in the Azure File service.  If the
        /// source object is a file that is to be copied to a blob, then the
        /// source file must be authenticated using a shared access signature,
        /// whether it resides in the same account or in a different account.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="CopyFromUriOperation"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<CopyFromUriOperation> StartCopyFromUriAsync(
            Uri sourceDirectoryUri,
            BlobDirectoryCopyFromUriOptions options,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = await StartCopyFromUriInternal(
                sourceDirectoryUri,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
            // TODO: Create actual return type specific to DirectoryCopyResults
            // CopyFromUriOperation will be exchanged the progress tracking in the options bag.
            // TODO: remove stub.
            return default;
        }

        /// <summary>
        /// The <see cref="StartCopyFromUriInternal"/> operation begins an
        /// asynchronous copy of the data from the <paramref name="sourceDirectoryUri"/> to this
        /// blob directory. It will make a
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">
        /// Copy Blob</see>. for each blob in the source blob directory.
        ///
        /// TODO: Proper response type for copy from directory uri
        /// </summary>
        /// <param name="sourceDirectoryUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  A source blob in the same storage account can be
        /// authenticated via Shared Key.  However, if the source is a blob in
        /// another account, the source blob must either be public or must be
        /// authenticated via a shared access signature. If the source blob
        /// is public, no authentication is required to perform the copy
        /// operation.
        ///
        /// The source object may be a file in the Azure File service.  If the
        /// source object is a file that is to be copied to a blob, then the
        /// source file must be authenticated using a shared access signature,
        /// whether it resides in the same account or in a different account.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobCopyInfo}"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        /// TODO; remove supression for unused parameters after implementation.
        /// TODO: remove static and async supression
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private static async Task<Response<BlobCopyInfo>> StartCopyFromUriInternal(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CA1801 // Review unused parameters
            Uri sourceDirectoryUri,
            BlobDirectoryCopyFromUriOptions options,
            bool async,
            CancellationToken cancellationToken)
#pragma warning restore CA1801 // Review unused parameters
        {
            //TODO: Implement directory copy
            ResponseWithHeaders<BlobCopyInfo> response = ResponseWithHeaders.FromValue((BlobCopyInfo)default, default);
            return Response.FromValue(response.Headers, response.GetRawResponse());
        }
        #endregion

        #region CopyFromUri
        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MB.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">
        /// Copy Blob From URL</see>.
        /// </summary>
        /// <param name="source">
        /// Required. Specifies the URL of the source blob. The value may be a URL of up to 2 KB in length
        /// that specifies a blob. The value should be URL-encoded as it would appear in a request URI. The
        /// source blob must either be public or must be authorized via a shared access signature. If the
        /// source blob is public, no authorization is required to perform the operation. If the size of the
        /// source blob is greater than 256 MB, the request will fail with 409 (Conflict). The blob type of
        /// the source blob has to be block blob.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobCopyInfo}"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual IEnumerable<Response<BlobCopyInfo>> SyncCopyFromUri(
            Uri source,
            BlobDirectoryCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
            => SyncCopyFromUriInternal(
                source: source,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MB.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">
        /// Copy Blob From URL</see>.
        /// </summary>
        /// <param name="source">
        /// Required. Specifies the URL of the source blob. The value may be a URL of up to 2 KB in length
        /// that specifies a blob. The value should be URL-encoded as it would appear in a request URI. The
        /// source blob must either be public or must be authorized via a shared access signature. If the
        /// source blob is public, no authorization is required to perform the operation. If the size of the
        /// source blob is greater than 256 MB, the request will fail with 409 (Conflict). The blob type of
        /// the source blob has to be block blob.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobCopyInfo}"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<IEnumerable<Response<BlobCopyInfo>>> SyncCopyFromUriAsync(
            Uri source,
            BlobDirectoryCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
            => await SyncCopyFromUriInternal(
                source: source,
                options: options,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The Copy Blob From URL operation copies a blob to a destination within the storage account synchronously
        /// for source blob sizes up to 256 MB. This API is available starting in version 2018-03-28.
        /// The source for a Copy Blob From URL operation can be any committed block blob in any Azure storage account
        /// which is either public or authorized with a shared access signature.
        ///
        /// The size of the source blob can be a maximum length of up to 256 MB.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">
        /// Copy Blob From URL</see>.
        /// </summary>
        /// <param name="source">
        /// Required. Specifies the URL of the source blob. The value may be a URL of up to 2 KB in length
        /// that specifies a blob. The value should be URL-encoded as it would appear in a request URI. The
        /// source blob must either be public or must be authorized via a shared access signature. If the
        /// source blob is public, no authorization is required to perform the operation. If the size of the
        /// source blob is greater than 256 MB, the request will fail with 409 (Conflict). The blob type of
        /// the source blob has to be block blob.
        /// </param>
        /// <param name="options">
        /// <see cref="BlobDirectoryCopyFromUriOptions"/> specifying
        /// options for this transfer.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobCopyInfo}"/> describing the
        /// state of the copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<IEnumerable<Response<BlobCopyInfo>>> SyncCopyFromUriInternal(
            Uri source,
            BlobDirectoryCopyFromUriOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(BlobDirectoryClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                nameof(BlobDirectoryClient),
                message:
                $"{nameof(Uri)}: {Uri}\n" +
                $"{nameof(options)}: {options}\n");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(BlobDirectoryClient)}.{nameof(SyncCopyFromUri)}");

                try
                {
                    scope.Start();

                    BlobDirectoryClient sourceDirectory = new BlobDirectoryClient(source, ClientConfiguration, ClientSideEncryption);

                    Pageable<BlobItem> sourceBlobs = sourceDirectory.GetBlobs(cancellationToken: cancellationToken);

                    BlobCopyFromUriOptions blobOptions = new BlobCopyFromUriOptions()
                    {
                        Tags = options.Tags,
                        Metadata = options.Metadata,
                        AccessTier = options.AccessTier,
                        SourceConditions = new BlobRequestConditions()
                        {
                            IfModifiedSince = options.SourceConditions.IfModifiedSince ?? null,
                            IfUnmodifiedSince = options.SourceConditions.IfUnmodifiedSince ?? null,
                        },
                        DestinationConditions = new BlobRequestConditions()
                        {
                            IfModifiedSince = options.DestinationConditions.IfModifiedSince ?? null,
                            IfUnmodifiedSince = options.DestinationConditions.IfUnmodifiedSince ?? null,
                        },
                        RehydratePriority = options.RehydratePriority
                    };

                    int concurrency = options.TransferOptions.MaximumConcurrency.HasValue && options.TransferOptions.MaximumConcurrency > 0 ?
                        options.TransferOptions.MaximumConcurrency.GetValueOrDefault() : 1;
                    TaskThrottler throttler = new TaskThrottler(concurrency);

                    List<Response<BlobCopyInfo>> responses = new List<Response<BlobCopyInfo>>();

                    foreach (BlobItem sourceBlob in sourceBlobs)
                    {
                        BlobUriBuilder builder = new BlobUriBuilder(source)
                        {
                            BlobName = sourceBlob.Name
                        };
                        Uri sourceBlobUri = builder.ToUri();

                        string destBlobName = sourceBlobUri.AbsoluteUri.Substring(source.AbsoluteUri.Length + 1);

                        throttler.AddTask(async () =>
                        {
                            responses.Add(await GetBlobClient(destBlobName)
                               .SyncCopyFromUriAsync(
                                   sourceBlobUri,
                                   blobOptions,
                                   cancellationToken)
                               .ConfigureAwait(false));
                        });
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(BlobBaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion CopyFromUri

        #region GetParentBlobContainerClientCore

        private BlobContainerClient _parentBlobContainerClient;

        /// <summary>
        /// Create a new <see cref="BlobContainerClient"/> that pointing to this <see cref="BlobDirectoryClient"/>'s parent container.
        /// The new <see cref="BlobContainerClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobDirectoryClient"/>.
        /// </summary>
        /// <returns>A new <see cref="BlobContainerClient"/> instance.</returns>
        protected internal virtual BlobContainerClient GetParentBlobContainerClientCore()
        {
            if (_parentBlobContainerClient == null)
            {
                BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
                {
                    // erase parameters unrelated to container
                    BlobName = null,
                    VersionId = null,
                    Snapshot = null,
                };

                _parentBlobContainerClient = new BlobContainerClient(
                    blobUriBuilder.ToUri(),
                    ClientConfiguration,
                    ClientSideEncryption);
            }

            return _parentBlobContainerClient;
        }
        #endregion
    }
}
