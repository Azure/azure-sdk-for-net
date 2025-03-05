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
        /// <param name="clientConfiguration">
        /// <see cref="BlobClientConfiguration"/>.
        /// </param>
        /// <param name="clientSideEncryption">
        /// Client-side encryption options.
        /// </param>
        internal BlobClient(
            Uri blobUri,
            BlobClientConfiguration clientConfiguration,
            ClientSideEncryptionOptions clientSideEncryption)
            : base(blobUri, clientConfiguration, clientSideEncryption)
        {
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
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
                ClientConfiguration,
                ClientSideEncryption);
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
                ClientConfiguration,
                ClientSideEncryption);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/>.
        ///
        /// </summary>
        /// <param name="customerProvidedKey">The customer provided key.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the customer provide key in the returned <see cref="BlobClient"/>.
        /// </remarks>
        public new BlobClient WithCustomerProvidedKey(CustomerProvidedKey? customerProvidedKey)
        {
            BlobClientConfiguration newClientConfiguration = BlobClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.CustomerProvidedKey = customerProvidedKey;
            return new BlobClient(
                blobUri: Uri,
                clientConfiguration: newClientConfiguration,
                clientSideEncryption: ClientSideEncryption?.Clone());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="encryptionScope"/>.
        ///
        /// </summary>
        /// <param name="encryptionScope">The encryption scope.</param>
        /// <returns>A new <see cref="BlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the encryption scope in the returned <see cref="BlobClient"/>.
        /// </remarks>
        public new BlobClient WithEncryptionScope(string encryptionScope)
        {
            BlobClientConfiguration newClientConfiguration = BlobClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.EncryptionScope = encryptionScope;
            return new BlobClient(
                blobUri: Uri,
                clientConfiguration: newClientConfiguration,
                clientSideEncryption: ClientSideEncryption?.Clone());
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
                ClientConfiguration,
                clientSideEncryptionOptions);
        }

        #region Upload
        /// <summary>
        /// The <see cref="Upload(Stream)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(Stream content) =>
            Upload(content, CancellationToken.None);

        /// <summary>
        /// The <see cref="Upload(BinaryData)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="BinaryData"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(BinaryData content) =>
            Upload(content, CancellationToken.None);

        /// <summary>
        /// The <see cref="Upload(string)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(string path) =>
            Upload(path, CancellationToken.None);

        /// <summary>
        /// The <see cref="UploadAsync(Stream)"/> operation creates a new block blob
        /// or throws an exception if the blob already exists.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(Stream content) =>
            await UploadAsync(content, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadAsync(BinaryData)"/> operation creates a new block blob
        /// or throws an exception if the blob already exists.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="BinaryData"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(BinaryData content) =>
            await UploadAsync(content, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadAsync(string)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(string path) =>
            await UploadAsync(path, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Upload(Stream, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            CancellationToken cancellationToken) =>
            Upload(
                content,
                overwrite: false,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="Upload(BinaryData, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="BinaryData"/> containing the content to upload.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(
            BinaryData content,
            CancellationToken cancellationToken) =>
            Upload(
                content,
                overwrite: false,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="Upload(string, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            CancellationToken cancellationToken) =>
            UploadAsync(
                content,
                overwrite: false,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(BinaryData, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="BinaryData"/> containing the content to upload.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            BinaryData content,
            CancellationToken cancellationToken) =>
            UploadAsync(
                content,
                overwrite: false,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(string, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// The <see cref="Upload(BinaryData, bool, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        /// Setting <paramref name="overwrite"/> to true allows updating the
        /// content of an existing block blob.  Updating an existing block blob
        /// overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(
            BinaryData content,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            Upload(
                content,
                options: overwrite ? null : new BlobUploadOptions() { Conditions = new BlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) } },
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="Upload(string, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// The <see cref="UploadAsync(Stream, bool, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        /// Setting <paramref name="overwrite"/> to true allows updating the
        /// content of an existing block blob.  Updating an existing block blob
        /// overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// The <see cref="UploadAsync(BinaryData, bool, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        /// Setting <paramref name="overwrite"/> to true allows updating the
        /// content of an existing block blob.  Updating an existing block blob
        /// overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="BinaryData"/> containing the content to upload.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            BinaryData content,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            UploadAsync(
                content,
                options: overwrite ? null : new BlobUploadOptions(){ Conditions = new BlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) }},
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(string, CancellationToken)"/> operation
        /// creates a new block blob or throws if the blob already exists.
        /// Setting <paramref name="overwrite"/> to true allows updating the
        /// content of an existing block blob.  Updating an existing block blob
        /// overwrites any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// The <see cref="Upload(BinaryData, BlobUploadOptions, CancellationToken)"/>
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="BinaryData"/> containing the content to upload.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(
            BinaryData content,
            BlobUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            using (var stream = content.ToStream())
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
        /// The <see cref="Upload(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, IProgress{long}, AccessTier?, StorageTransferOptions, CancellationToken)"/>
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobRequestConditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobRequestConditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// The <see cref="UploadAsync(Stream, BlobUploadOptions, CancellationToken)"/>
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// The <see cref="UploadAsync(BinaryData, BlobUploadOptions, CancellationToken)"/>
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="BinaryData"/> containing the content to upload.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            BinaryData content,
            BlobUploadOptions options,
            CancellationToken cancellationToken = default)
        {
            using (var stream = content.ToStream())
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
        /// The <see cref="UploadAsync(Stream, BlobHttpHeaders, Metadata, BlobRequestConditions, IProgress{long}, AccessTier?, StorageTransferOptions, CancellationToken)"/>
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobRequestConditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobUploadOptions.Conditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// operation overwrites the contents of the blob, creating a new block
        /// blob if none exists.  Overwriting an existing block blob replaces
        /// any existing metadata on the blob.
        ///
        /// Set <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations">
        /// access conditions</see> through <see cref="BlobRequestConditions"/>
        /// to avoid overwriting existing data.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="Azure.Storage.Blobs.Specialized.BlockBlobClient"/>.  To create or modify page or
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<BlobContentInfo>> StagedUploadInternal(
            Stream content,
            BlobUploadOptions options,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            UploadTransferValidationOptions validationOptions = options?.TransferValidation ?? ClientConfiguration.TransferValidation.Upload;

            long? expectedContentLength = null;
            if (UsingClientSideEncryption)
            {
                options ??= new BlobUploadOptions();

                // if content length was known, we retain that for dividing REST requests appropriately
                expectedContentLength = content.GetLengthOrDefault();
                IClientSideEncryptor encryptor = ClientSideEncryption.GetClientSideEncryptor();
                if (expectedContentLength.HasValue)
                {
                    expectedContentLength = encryptor.ExpectedOutputContentLength(expectedContentLength.Value);
                }
                (content, options.Metadata) = await new BlobClientSideEncryptor(encryptor)
                    .ClientSideEncryptInternal(content, options.Metadata, async, cancellationToken).ConfigureAwait(false);
            }

            var uploader = GetPartitionedUploader(
                transferOptions: options?.TransferOptions ?? default,
                validationOptions,
                operationName: $"{nameof(BlobClient)}.{nameof(Upload)}");

            return await uploader.UploadInternal(
                content,
                expectedContentLength,
                options,
                options?.ProgressHandler,
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<BlobContentInfo>> StagedUploadInternal(
            string path,
            BlobUploadOptions options,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
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

        #region OpenWrite
        /// <summary>
        /// Opens a stream for writing to the blob. If the blob exists,
        /// it will be overwritten.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// The only valid value for this operation is true.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the Append Blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [ForwardsClientCalls]
        public virtual Stream OpenWrite(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            BlobOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => OpenWriteInternal(
                overwrite,
                options,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Opens a stream for writing to the blob. If the blob exists,
        /// it will be overwritten.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// The only valid value for this operation is true.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the Append Blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        [ForwardsClientCalls]
        public virtual async Task<Stream> OpenWriteAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            BlobOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => await OpenWriteInternal(
                overwrite,
                options,
                async: true,
                cancellationToken).ConfigureAwait(false);

        internal async Task<Stream> OpenWriteInternal(
            bool overwrite,
            BlobOpenWriteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            if (UsingClientSideEncryption)
            {
                IClientSideEncryptor encryptor = ClientSideEncryption.GetClientSideEncryptor();
                return await new BlobClientSideEncryptor(encryptor)
                    .ClientSideEncryptionOpenWriteInternal(
                        BlockBlobClient,
                        overwrite,
                        options?.ToBlockBlobOpenWriteOptions(),
                        async,
                        cancellationToken).ConfigureAwait(false);
            }

            return await BlockBlobClient.OpenWriteInternal(
                overwrite,
                options?.ToBlockBlobOpenWriteOptions(),
                async,
                cancellationToken).ConfigureAwait(false);
        }
        #endregion

        private BlockBlobClient _blockBlobClient;

        private BlockBlobClient BlockBlobClient
        {
            get
            {
                if (_blockBlobClient == null)
                {
                    _blockBlobClient = new BlockBlobClient(Uri, ClientConfiguration, ClientSideEncryption);
                }
                return _blockBlobClient;
            }
        }

        internal PartitionedUploader<BlobUploadOptions, BlobContentInfo> GetPartitionedUploader(
            StorageTransferOptions transferOptions,
            UploadTransferValidationOptions validationOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
            => BlockBlobClient.GetPartitionedUploader(transferOptions, validationOptions, arrayPool, operationName);
    }
}
