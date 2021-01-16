// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Cryptography;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// The <see cref="BlobClient"/> allows you to manipulate Azure Storage
    /// blobs.
    /// </summary>
    public class BlobClient : BlobBaseClient
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class for mocking.
        /// </summary>
        protected BlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this blob.
        /// </param>
        public BlobClient(string connectionString, string blobContainerName, string blobName)
            : base(connectionString, blobContainerName, blobName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            : base(connectionString, blobContainerName, blobName, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobClient(Uri blobUri, BlobClientOptions options = default)
            : base(blobUri, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobClient(Uri blobUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
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
        public BlobClient(Uri blobUri, AzureSasCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobClient(Uri blobUri, TokenCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="storageSharedKeyCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="version">
        /// The version of the service to use when sending requests.
        /// </param>
        /// <param name="clientDiagnostics">Client diagnostics.</param>
        /// <param name="customerProvidedKey">Customer provided key.</param>
        /// <param name="clientSideEncryption">Client-side encryption options.</param>
        /// <param name="encryptionScope">Encryption scope.</param>
        internal BlobClient(
            Uri blobUri,
            HttpPipeline pipeline,
            StorageSharedKeyCredential storageSharedKeyCredential,
            BlobClientOptions.ServiceVersion version,
            ClientDiagnostics clientDiagnostics,
            CustomerProvidedKey? customerProvidedKey,
            ClientSideEncryptionOptions clientSideEncryption,
            string encryptionScope)
            : base(blobUri, pipeline, storageSharedKeyCredential, version, clientDiagnostics, customerProvidedKey, clientSideEncryption, encryptionScope)
        {
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob" />.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public new BlobClient WithSnapshot(string snapshot)
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                Snapshot = snapshot
            };

            return new BlobClient(
                blobUriBuilder.ToUri(),
                Pipeline,
                SharedKeyCredential,
                Version,
                ClientDiagnostics,
                CustomerProvidedKey,
                ClientSideEncryption,
                EncryptionScope);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="versionId"/> timestamp.
        ///
        /// </summary>
        /// <param name="versionId">The version identifier.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the version returning a URL
        /// to the base blob.
        /// </remarks>
        public new BlobClient WithVersion(string versionId)
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                VersionId = versionId
            };

            return new BlobClient(
                blobUriBuilder.ToUri(),
                Pipeline,
                SharedKeyCredential,
                Version,
                ClientDiagnostics,
                CustomerProvidedKey,
                ClientSideEncryption,
                EncryptionScope);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BlobClient"/> class, maintaining all the same
        /// internals but specifying new <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="clientSideEncryptionOptions">New encryption options. Setting this to <code>default</code> will clear client-side encryption.</param>
        /// <returns>New instance with provided options and same internals otherwise.</returns>
        protected internal virtual BlobClient WithClientSideEncryptionOptionsCore(ClientSideEncryptionOptions clientSideEncryptionOptions)
        {
            return new BlobClient(
                Uri,
                Pipeline,
                SharedKeyCredential,
                Version,
                ClientDiagnostics,
                CustomerProvidedKey,
                clientSideEncryptionOptions,
                EncryptionScope);
        }

        #region Upload
        /// <summary>
        /// The <see cref="Upload(Stream)"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(Stream content) =>
            Upload(content, CancellationToken.None);

        /// <summary>
        /// The <see cref="Upload(string)"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(string path) =>
            Upload(path, CancellationToken.None);

        /// <summary>
        /// The <see cref="UploadAsync(Stream)"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(Stream content) =>
            await UploadAsync(content, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadAsync(string)"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(string path) =>
            await UploadAsync(path, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Upload(Stream, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
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
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            CancellationToken cancellationToken) =>
            Upload(
                content,
                overwrite: false,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="Upload(string, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
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
        public virtual Response<BlobContentInfo> Upload(
            string path,
            CancellationToken cancellationToken) =>
            Upload(
                path,
                overwrite: false,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
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
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            CancellationToken cancellationToken) =>
            UploadAsync(
                content,
                overwrite: false,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(string, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
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
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            string path,
            CancellationToken cancellationToken) =>
            await UploadAsync(
                path,
                overwrite: false,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Upload(Stream, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite any existing blobs.  The
        /// default value is false.
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
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            Upload(
                content,
                conditions: overwrite ? null : new BlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) },
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="Upload(string, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite any existing blobs.  The
        /// default value is false.
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
        public virtual Response<BlobContentInfo> Upload(
            string path,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            Upload(
                path,
                conditions: overwrite ? null : new BlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) },
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite any existing blobs.  The
        /// default value is false.
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
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            UploadAsync(
                content,
                conditions: overwrite ? null : new BlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) },
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(string, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite any existing blobs.  The
        /// default value is false.
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
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            string path,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            await UploadAsync(
                path,
                conditions: overwrite ? null : new BlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) },
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Upload(Stream, BlobUploadOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
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
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            BlobUploadOptions options,
            CancellationToken cancellationToken = default) =>
            StagedUploadInternal(
                content,
                options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Upload(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, IProgress{long}, AccessTier?, StorageTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
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
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            AccessTier? accessTier = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default) =>
            StagedUploadInternal(
                content,
                new BlobUploadOptions
                {
                    HttpHeaders = httpHeaders,
                    Metadata = metadata,
                    Conditions = conditions,
                    ProgressHandler = progressHandler,
                    AccessTier = accessTier,
                    TransferOptions = transferOptions
                },
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Upload(string, BlobUploadOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
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
        public virtual Response<BlobContentInfo> Upload(
            string path,
            BlobUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return StagedUploadInternal(
                    stream,
                    options,
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
            }
        }

        /// <summary>
        /// The <see cref="Upload(string, BlobHttpHeaders, Metadata, BlobRequestConditions, IProgress{long}, AccessTier?, StorageTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
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
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContentInfo> Upload(
            string path,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            AccessTier? accessTier = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return StagedUploadInternal(
                    stream,
                    new BlobUploadOptions
                    {
                        HttpHeaders = httpHeaders,
                        Metadata = metadata,
                        Conditions = conditions,
                        ProgressHandler = progressHandler,
                        AccessTier = accessTier,
                        TransferOptions = transferOptions
                    },
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
            }
        }

        /// <summary>
        /// The <see cref="UploadAsync(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, IProgress{long}, AccessTier?, StorageTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
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
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobUploadOptions options,
            CancellationToken cancellationToken = default) =>
            await StagedUploadInternal(
                content,
                options,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, IProgress{long}, AccessTier?, StorageTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            AccessTier? accessTier = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default) =>
            StagedUploadInternal(
                content,
                new BlobUploadOptions
                {
                    HttpHeaders = httpHeaders,
                    Metadata = metadata,
                    Conditions = conditions,
                    ProgressHandler = progressHandler,
                    AccessTier = accessTier,
                    TransferOptions = transferOptions
                },
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, BlobUploadOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>..
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
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
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            string path,
            BlobUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return await StagedUploadInternal(
                    stream,
                    options,
                    async: true,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// The <see cref="UploadAsync(string, BlobHttpHeaders, Metadata, BlobRequestConditions, IProgress{long}, AccessTier?, StorageTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
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
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            string path,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            BlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            AccessTier? accessTier = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return await StagedUploadInternal(
                    stream,
                    new BlobUploadOptions
                    {
                        HttpHeaders = httpHeaders,
                        Metadata = metadata,
                        Conditions = conditions,
                        ProgressHandler = progressHandler,
                        AccessTier = accessTier,
                        TransferOptions = transferOptions
                    },
                    async: true,
                    cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This operation will create a new
        /// block blob of arbitrary size by uploading it as indiviually staged
        /// blocks if it's larger than the
        /// <paramref name="options"/> MaximumTransferLength.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="options">
        /// Options for this upload.
        /// </param>
        /// <param name="async">
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
        internal async Task<Response<BlobContentInfo>> StagedUploadInternal(
            Stream content,
            BlobUploadOptions options,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            if (UsingClientSideEncryption)
            {
                // content is now unseekable, so PartitionedUploader will be forced to do a buffered multipart upload
                (content, options.Metadata) = await new BlobClientSideEncryptor(new ClientSideEncryptor(ClientSideEncryption))
                    .ClientSideEncryptInternal(content, options.Metadata, async, cancellationToken).ConfigureAwait(false);
            }

            var client = new BlockBlobClient(Uri, Pipeline, SharedKeyCredential, Version, ClientDiagnostics, CustomerProvidedKey, EncryptionScope);

            var uploader = GetPartitionedUploader(
                transferOptions: options?.TransferOptions ?? default,
                operationName: $"{nameof(BlobClient)}.{nameof(Upload)}");

            return await uploader.UploadInternal(
                content,
                options,
                options.ProgressHandler,
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This operation will create a new
        /// block blob of arbitrary size by uploading it as indiviually staged
        /// blocks if it's larger than the
        /// <paramref name="options"/>. MaximumTransferLength.
        /// </summary>
        /// <param name="path">
        /// A file path of the file to upload.
        /// </param>
        /// <param name="options">
        /// Options for this upload.
        /// </param>
        /// <param name="async">
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
        internal async Task<Response<BlobContentInfo>> StagedUploadInternal(
            string path,
            BlobUploadOptions options,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            // TODO Upload from file will get it's own implementation in the future that opens more
            //      than one stream at once. This is incompatible with .NET's CryptoStream. We will
            //      need to uncomment the below code and revert to upload from stream if client-side
            //      encryption is enabled.
            //if (ClientSideEncryption != default)
            //{
            //    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //    {
            //        return await StagedUploadAsync(
            //            stream,
            //            blobHttpHeaders,
            //            metadata,
            //            conditions,
            //            progressHandler,
            //            accessTier,
            //            transferOptions: transferOptions,
            //            async: async,
            //            cancellationToken: cancellationToken)
            //            .ConfigureAwait(false);
            //    }
            //}

            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return await StagedUploadInternal(
                    stream,
                    options,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
        }
        #endregion Upload

        internal PartitionedUploader<BlobUploadOptions, BlobContentInfo> GetPartitionedUploader(
            StorageTransferOptions transferOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
            => new BlockBlobClient(Uri, Pipeline, SharedKeyCredential, Version, ClientDiagnostics, CustomerProvidedKey, EncryptionScope)
                .GetPartitionedUploader(transferOptions, arrayPool, operationName);
    }
}
