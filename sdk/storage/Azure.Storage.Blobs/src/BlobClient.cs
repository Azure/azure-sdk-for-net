// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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
        #endregion ctors

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
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobContentInfo> Upload(Stream content) =>
            Upload(content, CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Upload(FileInfo)"/> operation creates a new block blob
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
        /// A <see cref="FileInfo"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobContentInfo> Upload(FileInfo content) =>
            Upload(content, CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

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
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Task<Response<BlobContentInfo>> UploadAsync(Stream content) =>
            UploadAsync(content, CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="UploadAsync(FileInfo)"/> operation creates a new block blob
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
        /// A <see cref="FileInfo"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// state of the updated block blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Task<Response<BlobContentInfo>> UploadAsync(FileInfo content) =>
            UploadAsync(content, CancellationToken.None);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

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
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            CancellationToken cancellationToken) =>
            Upload(
                content,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Upload(FileInfo, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="FileInfo"/> containing the content to upload.
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
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Response<BlobContentInfo> Upload(
            FileInfo content,
            CancellationToken cancellationToken) =>
            Upload(
                content,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

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
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            CancellationToken cancellationToken) =>
            UploadAsync(
                content,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="UploadAsync(FileInfo, CancellationToken)"/> operation
        /// creates a new block blob or updates the content of an existing
        /// block blob.  Updating an existing block blob overwrites any
        /// existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="FileInfo"/> containing the content to upload.
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
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            FileInfo content,
            CancellationToken cancellationToken) =>
            UploadAsync(
                content,
                blobAccessConditions: default, // Pass anything else so we don't recurse on this overload
                cancellationToken: cancellationToken);
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Upload(Stream, BlobHttpHeaders?, Metadata, BlobAccessConditions?, IProgress{StorageProgress}, AccessTier?, ParallelTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
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
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<BlobContentInfo> Upload(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            IProgress<StorageProgress> progressHandler = default,
            AccessTier? accessTier = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            StagedUploadAsync(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                progressHandler,
                accessTier,
                parallelTransferOptions: parallelTransferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Upload(FileInfo, BlobHttpHeaders?, Metadata, BlobAccessConditions?, IProgress{StorageProgress}, AccessTier?, ParallelTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="FileInfo"/> containing the content to upload.
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
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<BlobContentInfo> Upload(
            FileInfo content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            IProgress<StorageProgress> progressHandler = default,
            AccessTier? accessTier = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            StagedUploadAsync(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                progressHandler,
                accessTier,
                parallelTransferOptions: parallelTransferOptions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadAsync(Stream, BlobHttpHeaders?, Metadata, BlobAccessConditions?, IProgress{StorageProgress}, AccessTier?, ParallelTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
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
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{StorageProgress}"/> to provide
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            IProgress<StorageProgress> progressHandler = default,
            AccessTier? accessTier = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            StagedUploadAsync(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                progressHandler,
                accessTier,
                parallelTransferOptions: parallelTransferOptions,
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(FileInfo, BlobHttpHeaders?, Metadata, BlobAccessConditions?, IProgress{StorageProgress}, AccessTier?, ParallelTransferOptions, CancellationToken)"/>
        /// operation creates a new block blob or updates the content of an
        /// existing block blob.  Updating an existing block blob overwrites
        /// any existing metadata on the blob.
        ///
        /// For partial block blob updates and other advanced features, please
        /// see <see cref="BlockBlobClient"/>.  To create or modify page or
        /// append blobs, please see <see cref="PageBlobClient"/> or
        /// <see cref="AppendBlobClient"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="FileInfo"/> containing the content to upload.
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
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<BlobContentInfo>> UploadAsync(
            FileInfo content,
            BlobHttpHeaders? blobHttpHeaders = default,
            Metadata metadata = default,
            BlobAccessConditions? blobAccessConditions = default,
            IProgress<StorageProgress> progressHandler = default,
            AccessTier? accessTier = default,
            ParallelTransferOptions parallelTransferOptions = default,
            CancellationToken cancellationToken = default) =>
            StagedUploadAsync(
                content,
                blobHttpHeaders,
                metadata,
                blobAccessConditions,
                progressHandler,
                accessTier,
                parallelTransferOptions: parallelTransferOptions,
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// This operation will create a new
        /// block blob of arbitrary size by uploading it as indiviually staged
        /// blocks if it's larger than the
        /// <paramref name="singleBlockThreshold"/>.
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
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="singleBlockThreshold">
        /// The maximum size stream that we'll upload as a single block.  The
        /// default value is 256MB.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<BlobContentInfo>> StagedUploadAsync(
            Stream content,
            BlobHttpHeaders? blobHttpHeaders,
            Metadata metadata,
            BlobAccessConditions? blobAccessConditions,
            IProgress<StorageProgress> progressHandler,
            AccessTier? accessTier = default,
            long singleBlockThreshold = BlockBlobClient.BlockBlobMaxUploadBlobBytes,
            ParallelTransferOptions parallelTransferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            Debug.Assert(singleBlockThreshold <= BlockBlobClient.BlockBlobMaxUploadBlobBytes);

            var client = new BlockBlobClient(Uri, Pipeline);
            var blockMap = new ConcurrentDictionary<long, string>();
            var blockName = 0;
            Task<Response<BlobContentInfo>> uploadTask = PartitionedUploader.UploadAsync(
                UploadStreamAsync,
                StageBlockAsync,
                CommitBlockListAsync,
                threshold => TryGetStreamLength(content, out var length) && length < threshold,
                memoryPool => new StreamPartitioner(content, memoryPool),
                singleBlockThreshold,
                parallelTransferOptions,
                async,
                cancellationToken);
            return async ?
                await uploadTask.ConfigureAwait(false) :
                uploadTask.EnsureCompleted();

            bool TryGetStreamLength(Stream stream, out long length)
            {
                length = 0;
                try
                {
                    length = stream.Length;
                    return true;
                }
                catch
                {
                }
                return false;
            }

            // Upload the entire stream
            Task<Response<BlobContentInfo>> UploadStreamAsync()
                =>
                client.UploadInternal(
                    content,
                    blobHttpHeaders,
                    metadata,
                    blobAccessConditions,
                    accessTier,
                    progressHandler,
                    async,
                    cancellationToken);

            string GetNewBase64BlockId(long blockOrdinal)
            {
                // Create and record a new block ID, storing the order information 
                // (nominally the block's start position in the original stream)

                var newBlockName = Interlocked.Increment(ref blockName);
                var blockId = Constants.BlockNameFormat;
                blockId = String.Format(CultureInfo.InvariantCulture, blockId, newBlockName);
                blockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(blockId));
                var success = blockMap.TryAdd(blockOrdinal, blockId);

                Debug.Assert(success);

                return blockId;
            }

            // Upload a single partition of the stream
            Task<Response<BlockInfo>> StageBlockAsync(
                Stream partition,
                long blockOrdinal,
                bool async,
                CancellationToken cancellation)
            {
                var base64BlockId = GetNewBase64BlockId(blockOrdinal);

                //var bytes = new byte[10];
                //partition.Read(bytes, 0, 10);
                partition.Position = 0;
                //Console.WriteLine($"Commiting partition {blockOrdinal} => {base64BlockId}, {String.Join(" ", bytes)}");

                // Upload the block
                return client.StageBlockInternal(
                    base64BlockId,
                    partition,
                    null,
                    blobAccessConditions?.LeaseAccessConditions,
                    progressHandler,
                    async,
                    cancellationToken);
            }

            // Commit a series of partitions
            Task<Response<BlobContentInfo>> CommitBlockListAsync(
                bool async,
                CancellationToken cancellation)
            {
                var base64BlockIds = blockMap.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value).ToArray();
                //Console.WriteLine($"Commiting block list:\n{String.Join("\n", base64BlockIds)}");

                return
                    client.CommitBlockListInternal(
                        base64BlockIds,
                        blobHttpHeaders,
                        metadata,
                        blobAccessConditions,
                        accessTier,
                        async,
                        cancellationToken);
            }
        }

        /// <summary>
        /// This operation will create a new
        /// block blob of arbitrary size by uploading it as indiviually staged
        /// blocks if it's larger than the
        /// <paramref name="singleBlockThreshold"/>.
        /// </summary>
        /// <param name="file">
        /// A <see cref="FileInfo"/> of the file to upload.
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
        /// <param name="accessTier">
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="singleBlockThreshold">
        /// The maximum size stream that we'll upload as a single block.  The
        /// default value is 256MB.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal async Task<Response<BlobContentInfo>> StagedUploadAsync(
            FileInfo file,
            BlobHttpHeaders? blobHttpHeaders,
            Metadata metadata,
            BlobAccessConditions? blobAccessConditions,
            IProgress<StorageProgress> progressHandler,
            AccessTier? accessTier = default,
            long singleBlockThreshold = BlockBlobClient.BlockBlobMaxUploadBlobBytes,
            ParallelTransferOptions parallelTransferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            Debug.Assert(singleBlockThreshold <= BlockBlobClient.BlockBlobMaxUploadBlobBytes);

            var client = new BlockBlobClient(Uri, Pipeline);
            var blockMap = new ConcurrentDictionary<long, string>();
            var blockName = 0;
            Task<Response<BlobContentInfo>> uploadTask = PartitionedUploader.UploadAsync(
                UploadStreamAsync,
                StageBlockAsync,
                CommitBlockListAsync,
                threshold => file.Length < threshold,
                memoryPool => new StreamPartitioner(file, memoryPool),
                singleBlockThreshold,
                parallelTransferOptions,
                async,
                cancellationToken);
            return async ?
                await uploadTask.ConfigureAwait(false) :
                uploadTask.EnsureCompleted();

            string GetNewBase64BlockId(long blockOrdinal)
            {
                // Create and record a new block ID, storing the order information 
                // (nominally the block's start position in the original stream)

                var newBlockName = Interlocked.Increment(ref blockName);
                var blockId = Constants.BlockNameFormat;
                blockId = String.Format(CultureInfo.InvariantCulture, blockId, newBlockName);
                blockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(blockId));
                var success = blockMap.TryAdd(blockOrdinal, blockId);

                Debug.Assert(success);

                return blockId;
            }

            // Upload the entire stream
            async Task<Response<BlobContentInfo>> UploadStreamAsync()
            {
                using (FileStream stream = file.OpenRead())
                {
                    return
                        await client.UploadInternal(
                            stream,
                            blobHttpHeaders,
                            metadata,
                            blobAccessConditions,
                            accessTier,
                            progressHandler,
                            async,
                            cancellationToken)
                        .ConfigureAwait(false);
                }
            }

            // Upload a single partition of the stream
            Task<Response<BlockInfo>> StageBlockAsync(
                Stream partition,
                long blockOrdinal,
                bool async,
                CancellationToken cancellation)
            {
                var base64BlockId = GetNewBase64BlockId(blockOrdinal);

                //var bytes = new byte[10];
                //partition.Read(bytes, 0, 10);
                partition.Position = 0;
                //Console.WriteLine($"Commiting partition {blockOrdinal} => {base64BlockId}, {String.Join(" ", bytes)}");

                // Upload the block
                return client.StageBlockInternal(
                    base64BlockId,
                    partition,
                    null,
                    blobAccessConditions?.LeaseAccessConditions,
                    progressHandler,
                    async,
                    cancellationToken);
            }

            // Commit a series of partitions
            Task<Response<BlobContentInfo>> CommitBlockListAsync(
                bool async,
                CancellationToken cancellation)
            {
                var base64BlockIds = blockMap.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value).ToArray();
                //Console.WriteLine($"Commiting block list:\n{String.Join("\n", base64BlockIds)}");

                return
                    client.CommitBlockListInternal(
                        base64BlockIds,
                        blobHttpHeaders,
                        metadata,
                        blobAccessConditions,
                        accessTier,
                        async,
                        cancellationToken);
            }
        }
        #endregion Upload
    }
}
