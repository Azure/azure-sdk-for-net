// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// The <see cref="BlobClient"/> allows you to manipulate Azure Storage
    /// blobs.
    /// </summary>
	public class BlobClient : BlobBaseClient
    {
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
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="containerName">
        /// The name of the container containing this blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this blob.
        /// </param>
        public BlobClient(string connectionString, string containerName, string blobName)
            : base(connectionString, containerName, blobName)
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
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="containerName">
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
        public BlobClient(string connectionString, string containerName, string blobName, BlobClientOptions options)
            : base(connectionString, containerName, blobName, options)
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
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal BlobClient(Uri blobUri, HttpPipeline pipeline)
            : base(blobUri, pipeline)
        {
        }

        /// <summary>
        /// The <see cref="Upload"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        /// 
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(Stream content) =>
            this.Upload(content, CancellationToken.None);

        /// <summary>
        /// The <see cref="UploadAsync"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        /// 
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobContentInfo}}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(Stream content) =>
            await this.UploadAsync(content, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Upload"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        /// 
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            CancellationToken cancellationToken) =>
            this.Upload(
                content,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        /// 
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobContentInfo}}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            CancellationToken cancellationToken) =>
            await this.UploadAsync(
                content,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Upload"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        /// 
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            this.UploadAsync(
                content,
                blobAccessConditions: blobAccessConditions,
                blobHttpHeaders: blobHttpHeaders,
                metadata: metadata,
                progressHandler: progressHandler,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadAsync"/> operation creates a new block blob
        /// or updates the content of an existing block blob.  Updating an
        /// existing block blob overwrites any existing metadata on the blob.
        /// 
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="blobHttpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// block blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this block blob.
        /// </param>
        /// <param name="blobAccessConditions">
        /// Optional <see cref="BlobAccessConditions"/> to add conditions on
        /// the creation of this new block blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobContentInfo}}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            IProgress<StorageProgress> progressHandler = default,
            CancellationToken cancellationToken = default) =>
            await new BlockBlobClient(this.Uri, this.Pipeline)
                .UploadAsync(
                    content,
                    blobAccessConditions: blobAccessConditions,
                    blobHttpHeaders: blobHttpHeaders,
                    metadata: metadata,
                    progressHandler: progressHandler,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
    }
}
