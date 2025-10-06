// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="AppendBlobClient"/> allows you to manipulate Azure
    /// Storage append blobs.
    ///
    /// An append blob is comprised of blocks and is optimized for append
    /// operations.  When you modify an append blob, blocks are added to the
    /// end of the blob only, via the <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/>
    /// operation.  Updating or deleting of existing blocks is not supported.
    /// Unlike a block blob, an append blob does not expose its block IDs.
    ///
    /// Each block in an append blob can be a different size.
    /// Beginning with x-ms-version 2022-11-02, the maximum append size is 100 MB.
    /// For previous versions, the maximum append size is 4 MB.
    /// Append blobs can include up to 50,000 blocks.
    /// </summary>
    public class AppendBlobClient : BlobBaseClient
    {
        /// <summary>
        /// Gets the maximum number of bytes that can be sent in a call
        /// to AppendBlock.
        /// </summary>
        public virtual int AppendBlobMaxAppendBlockBytes => ClientConfiguration.Version < BlobClientOptions.ServiceVersion.V2022_11_02
            ? Constants.Blob.Append.Pre_2022_11_02_MaxAppendBlockBytes
            : Constants.Blob.Append.MaxAppendBlockBytes;

        /// <summary>
        /// Gets the maximum number of blocks allowed in an append blob.
        /// </summary>
        public virtual int AppendBlobMaxBlocks => Constants.Blob.Append.MaxBlocks;

        /// <summary>
        /// AppendBlobRestClient.
        /// </summary>
        private readonly AppendBlobRestClient _appendBlobRestClient;

        /// <summary>
        /// AppendBlobRestClient.
        /// </summary>
        internal virtual AppendBlobRestClient AppendBlobRestClient => _appendBlobRestClient;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class for mocking.
        /// </summary>
        protected AppendBlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this append blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this append blob.
        /// </param>
        public AppendBlobClient(string connectionString, string blobContainerName, string blobName)
            : base(connectionString, blobContainerName, blobName)
        {
            _appendBlobRestClient = BuildAppendBlobRestClient(_uri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this append blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this append blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public AppendBlobClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            : base(connectionString, blobContainerName, blobName, options)
        {
            _appendBlobRestClient = BuildAppendBlobRestClient(_uri);
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public AppendBlobClient(Uri blobUri, BlobClientOptions options = default)
            : base(blobUri, options)
        {
            AssertNoClientSideEncryption(options);
            _appendBlobRestClient = BuildAppendBlobRestClient(blobUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
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
        public AppendBlobClient(Uri blobUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            AssertNoClientSideEncryption(options);
            _appendBlobRestClient = BuildAppendBlobRestClient(blobUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
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
        public AppendBlobClient(Uri blobUri, AzureSasCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            AssertNoClientSideEncryption(options);
            _appendBlobRestClient = BuildAppendBlobRestClient(blobUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
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
        public AppendBlobClient(Uri blobUri, TokenCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            AssertNoClientSideEncryption(options);
            _appendBlobRestClient = BuildAppendBlobRestClient(blobUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the append blob that includes the
        /// name of the account, the name of the container, and the name of
        /// the blob.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net/{container_name}/{blob_name}".
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="BlobClientConfiguration"/>.
        /// </param>
        internal AppendBlobClient(
            Uri blobUri,
            BlobClientConfiguration clientConfiguration)
            : base(
                  blobUri,
                  clientConfiguration,
                  clientSideEncryption: default)
        {
            _appendBlobRestClient = BuildAppendBlobRestClient(blobUri);
        }

        private static void AssertNoClientSideEncryption(BlobClientOptions options)
        {
            if (options?._clientSideEncryptionOptions != default)
            {
                throw Errors.ClientSideEncryption.TypeNotSupported(typeof(AppendBlobClient));
            }
        }

        private AppendBlobRestClient BuildAppendBlobRestClient(Uri blobUri)
        {
            return new AppendBlobRestClient(
                clientDiagnostics: _clientConfiguration.ClientDiagnostics,
                pipeline: _clientConfiguration.Pipeline,
                url: blobUri.AbsoluteUri,
                version: _clientConfiguration.Version.ToVersionString());
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="snapshot"/> timestamp.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="AppendBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public new AppendBlobClient WithSnapshot(string snapshot)
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                Snapshot = snapshot
            };

            return new AppendBlobClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="versionId"/> timestamp.
        ///
        /// </summary>
        /// <param name="versionId">The version identifier.</param>
        /// <returns>A new <see cref="AppendBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the version returning a URL
        /// to the base blob.
        /// </remarks>
        public new AppendBlobClient WithVersion(string versionId)
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                VersionId = versionId
            };

            return new AppendBlobClient(
                blobUriBuilder.ToUri(),
                ClientConfiguration);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/>.
        ///
        /// </summary>
        /// <param name="customerProvidedKey">The customer provided key.</param>
        /// <returns>A new <see cref="AppendBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the customer provide key in the returned <see cref="AppendBlobClient"/>.
        /// </remarks>
        public new AppendBlobClient WithCustomerProvidedKey(CustomerProvidedKey? customerProvidedKey)
        {
            BlobClientConfiguration newClientConfiguration = BlobClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.CustomerProvidedKey = customerProvidedKey;
            return new AppendBlobClient(
                blobUri: Uri,
                clientConfiguration: newClientConfiguration);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="encryptionScope"/>.
        ///
        /// </summary>
        /// <param name="encryptionScope">The encryption scope.</param>
        /// <returns>A new <see cref="AppendBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the encryption scope in the returned <see cref="AppendBlobClient"/>.
        /// </remarks>
        public new AppendBlobClient WithEncryptionScope(string encryptionScope)
        {
            BlobClientConfiguration newClientConfiguration = BlobClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.EncryptionScope = encryptionScope;
            return new AppendBlobClient(
                blobUri: Uri,
                clientConfiguration: newClientConfiguration);
        }

        #region Create
        /// <summary>
        /// The <see cref="Create(AppendBlobCreateOptions, CancellationToken)"/>
        /// operation creates a new 0-length append blob.  The content of any existing
        /// blob is overwritten with the newly initialized append blob.  To add content
        /// to the append blob, call the <see cref="AppendBlock(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Create(
            AppendBlobCreateOptions options,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                tags: options?.Tags,
                conditions: options?.Conditions,
                immutabilityPolicy: options?.ImmutabilityPolicy,
                legalHold: options?.HasLegalHold,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync(AppendBlobCreateOptions, CancellationToken)"/>
        /// operation creates a new 0-length append blob.  The content of any existing
        /// blob is overwritten with the newly initialized append blob.  To add content
        /// to the append blob, call the <see cref="AppendBlock(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CreateAsync(
            AppendBlobCreateOptions options,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                tags: options?.Tags,
                conditions: options?.Conditions,
                immutabilityPolicy: options?.ImmutabilityPolicy,
                legalHold: options?.HasLegalHold,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Create(BlobHttpHeaders, Metadata, AppendBlobRequestConditions, CancellationToken)"/>
        /// operation creates a new 0-length append blob.  The content of any existing blob is overwritten with
        /// the newly initialized append blob.  To add content to the append
        /// blob, call the <see cref="AppendBlock(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the creation of this new append blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContentInfo> Create(
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            AppendBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                httpHeaders: httpHeaders,
                metadata: metadata,
                tags: default,
                conditions: conditions,
                immutabilityPolicy: default,
                legalHold: default,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync(BlobHttpHeaders, Metadata, AppendBlobRequestConditions, CancellationToken)"/>
        /// operation creates a new 0-length append blob.  The content of any existing blob is overwritten with
        /// the newly initialized append blob.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the creation of this new append blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContentInfo>> CreateAsync(
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            AppendBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                httpHeaders: httpHeaders,
                metadata: metadata,
                tags: default,
                conditions: conditions,
                async: true,
                immutabilityPolicy: default,
                legalHold: default,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExists(AppendBlobCreateOptions, CancellationToken)"/>
        /// operation creates a new 0-length append blob.  If the append blob already exists,
        /// the content of the existing append blob will remain unchanged.  To add content to
        /// the append blob, call the <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the append blob does not already exist, a <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created append blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> CreateIfNotExists(
            AppendBlobCreateOptions options,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                immutabilityPolicy: options?.ImmutabilityPolicy,
                legalHold: options?.HasLegalHold,
                tags: options?.Tags,
                async: false,
                cancellationToken: cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync(AppendBlobCreateOptions, CancellationToken)"/>
        /// operation creates a new 0-length append blob.  If the append blob already exists,
        /// the content of the existing append blob will remain unchanged.  To add content to
        /// the append blob, call the <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the append blob does not already exist, a <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created append blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CreateIfNotExistsAsync(
            AppendBlobCreateOptions options,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                httpHeaders: options?.HttpHeaders,
                metadata: options?.Metadata,
                tags: options?.Tags,
                immutabilityPolicy: options?.ImmutabilityPolicy,
                legalHold: options?.HasLegalHold,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExists(BlobHttpHeaders, Metadata, CancellationToken)"/>
        /// operation creates a new 0-length append blob.  If the append blob already exists,
        /// the content of the existing append blob will remain unchanged.  To add content to
        /// the append blob, call the <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the append blob does not already exist, a <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created append blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContentInfo> CreateIfNotExists(
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                httpHeaders: httpHeaders,
                metadata: metadata,
                tags: default,
                immutabilityPolicy: default,
                legalHold: default,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync(BlobHttpHeaders, Metadata, CancellationToken)"/>
        /// operation creates a new 0-length append blob.  If the append blob already exists,
        /// the content of the existing append blob will remain unchanged.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the append blob does not already exist, a <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created append blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContentInfo>> CreateIfNotExistsAsync(
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                httpHeaders: httpHeaders,
                metadata: metadata,
                tags: default,
                immutabilityPolicy: default,
                legalHold: default,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExistsInternal"/> operation creates a new 0-length
        /// append blob.  If the append blob already exists, the content of
        /// the existing append blob will remain unchanged.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="tags">
        /// The tags to set on this append blob.
        /// </param>
        /// <param name="immutabilityPolicy">
        /// Optional <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </param>
        /// <param name="legalHold">
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the append blob does not already exist, a <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created append blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobContentInfo>> CreateIfNotExistsInternal(
            BlobHttpHeaders httpHeaders,
            Metadata metadata,
            Tags tags,
            BlobImmutabilityPolicy immutabilityPolicy,
            bool? legalHold,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");

                string operationName = $"{nameof(AppendBlobClient)}.{nameof(CreateIfNotExists)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                AppendBlobRequestConditions conditions = new AppendBlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) };

                try
                {
                    scope.Start();

                    Response<BlobContentInfo> response = await CreateInternal(
                        httpHeaders,
                        metadata,
                        tags,
                        conditions,
                        immutabilityPolicy,
                        legalHold,
                        async,
                        cancellationToken,
                        operationName)
                        .ConfigureAwait(false);

                    return response;
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.BlobAlreadyExists)
                {
                    return default;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(AppendBlobClient));
                    scope.Dispose();
                }
            }
        }

        /// <summary>
        /// The <see cref="CreateInternal"/> operation creates a new 0-length
        /// append blob.  The content of any existing blob is overwritten with
        /// the newly initialized append blob.  To add content to the append
        /// blob, call the <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-blob">
        /// Put Blob</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this append blob.
        /// </param>
        /// <param name="tags">
        /// The tags to set on this append blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the creation of this new append blob.
        /// </param>
        /// <param name="immutabilityPolicy">
        /// Optional <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </param>
        /// <param name="legalHold">
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="operationName">
        /// Optional. To indicate if the name of the operation.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobContentInfo>> CreateInternal(
            BlobHttpHeaders httpHeaders,
            Metadata metadata,
            Tags tags,
            AppendBlobRequestConditions conditions,
            BlobImmutabilityPolicy immutabilityPolicy,
            bool? legalHold,
            bool async,
            CancellationToken cancellationToken,
#pragma warning disable CA1801 // Review unused parameters
            string operationName = null)
#pragma warning restore CA1801 // Review unused parameters
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(AppendBlobClient)}.{nameof(Create)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfAppendPositionEqual
                        | BlobRequestConditionProperty.IfMaxSizeLessThanOrEqual,
                    operationName: nameof(AppendBlobClient.Create),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<AppendBlobCreateHeaders> response;

                    if (async)
                    {
                        response = await AppendBlobRestClient.CreateAsync(
                            contentLength: 0,
                            blobContentType: httpHeaders?.ContentType,
                            blobContentEncoding: httpHeaders?.ContentEncoding,
                            blobContentLanguage: httpHeaders?.ContentLanguage,
                            blobContentMD5: httpHeaders?.ContentHash,
                            blobCacheControl: httpHeaders?.CacheControl,
                            metadata: metadata,
                            leaseId: conditions?.LeaseId,
                            blobContentDisposition: httpHeaders?.ContentDisposition,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            blobTagsString: tags?.ToTagsString(),
                            immutabilityPolicyExpiry: immutabilityPolicy?.ExpiresOn,
                            immutabilityPolicyMode: immutabilityPolicy?.PolicyMode,
                            legalHold: legalHold,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = AppendBlobRestClient.Create(
                            contentLength: 0,
                            blobContentType: httpHeaders?.ContentType,
                            blobContentEncoding: httpHeaders?.ContentEncoding,
                            blobContentLanguage: httpHeaders?.ContentLanguage,
                            blobContentMD5: httpHeaders?.ContentHash,
                            blobCacheControl: httpHeaders?.CacheControl,
                            metadata: metadata,
                            leaseId: conditions?.LeaseId,
                            blobContentDisposition: httpHeaders?.ContentDisposition,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            blobTagsString: tags?.ToTagsString(),
                            immutabilityPolicyExpiry: immutabilityPolicy?.ExpiresOn,
                            immutabilityPolicyMode: immutabilityPolicy?.PolicyMode,
                            legalHold: legalHold,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobContentInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(AppendBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Create

        #region AppendBlock
        /// <summary>
        /// The <see cref="AppendBlock(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation commits a new block
        /// of data, represented by the <paramref name="content"/> <see cref="Stream"/>,
        /// to the end of the existing append blob.  The <see cref="AppendBlock(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/>
        /// operation is only permitted if the blob was created as an append
        /// blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/append-block">
        /// Append Block</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the block to
        /// append.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the block content.  This hash is used to
        /// verify the integrity of the block during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the blob.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on appending content to this append blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<BlobAppendInfo> AppendBlock(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            byte[] transactionalContentHash,
            AppendBlobRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            return AppendBlockInternal(
                content,
                transactionalContentHash.ToValidationOptions(),
                conditions,
                progressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation commits a new block
        /// of data, represented by the <paramref name="content"/> <see cref="Stream"/>,
        /// to the end of the existing append blob.  The <see cref="AppendBlockAsync(Stream, byte[], AppendBlobRequestConditions, IProgress{long}, CancellationToken)"/>
        /// operation is only permitted if the blob was created as an append
        /// blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/append-block">
        /// Append Block</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the block to
        /// append.
        /// </param>
        /// <param name="transactionalContentHash">
        /// Optional MD5 hash of the block content.  This hash is used to
        /// verify the integrity of the block during transport. When this hash
        /// is specified, the storage service compares the hash of the content
        /// that has arrived with this value.  Note that this MD5 hash is not
        /// stored with the blob.  If the two hashes do not match, the
        /// operation will fail with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on appending content to this append blob.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<BlobAppendInfo>> AppendBlockAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            byte[] transactionalContentHash,
            AppendBlobRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            return await AppendBlockInternal(
                content,
                transactionalContentHash.ToValidationOptions(),
                conditions,
                progressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="AppendBlock(Stream, AppendBlobAppendBlockOptions, CancellationToken)"/> operation commits a new block
        /// of data, represented by the <paramref name="content"/> <see cref="Stream"/>,
        /// to the end of the existing append blob.  The <see cref="AppendBlock(Stream, AppendBlobAppendBlockOptions, CancellationToken)"/>
        /// operation is only permitted if the blob was created as an append
        /// blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/append-block">
        /// Append Block</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the block to
        /// append.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobAppendInfo> AppendBlock(
            Stream content,
            AppendBlobAppendBlockOptions options = default,
            CancellationToken cancellationToken = default) =>
            AppendBlockInternal(
                content,
                options?.TransferValidation,
                options?.Conditions,
                options?.ProgressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AppendBlockAsync(Stream, AppendBlobAppendBlockOptions, CancellationToken)"/> operation commits a new block
        /// of data, represented by the <paramref name="content"/> <see cref="Stream"/>,
        /// to the end of the existing append blob.  The <see cref="AppendBlockAsync(Stream, AppendBlobAppendBlockOptions, CancellationToken)"/>
        /// operation is only permitted if the blob was created as an append
        /// blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/append-block">
        /// Append Block</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the block to
        /// append.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobAppendInfo>> AppendBlockAsync(
            Stream content,
            AppendBlobAppendBlockOptions options = default,
            CancellationToken cancellationToken = default) =>
            await AppendBlockInternal(
                content,
                options?.TransferValidation,
                options?.Conditions,
                options?.ProgressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AppendBlockInternal"/> operation commits a new block
        /// of data, represented by the <paramref name="content"/> <see cref="Stream"/>,
        /// to the end of the existing append blob.  The <see cref="AppendBlockInternal"/>
        /// operation is only permitted if the blob was created as an append
        /// blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/append-block">
        /// Append Block</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the block to
        /// append.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Validation options for content verification.
        /// </param>
        /// <param name="conditions">
        /// Request conditions for append operation.
        /// </param>
        /// <param name="progressHandler">
        /// Progress handler for append progress.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<BlobAppendInfo>> AppendBlockInternal(
            Stream content,
            UploadTransferValidationOptions transferValidationOverride,
            AppendBlobRequestConditions conditions,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            UploadTransferValidationOptions validationOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Upload;

            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                Argument.AssertNotNull(content, nameof(content));

                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(AppendBlobClient)}.{nameof(AppendBlock)}");

                // All AppendBlobRequestConditions are valid.
                conditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(AppendBlobClient.AppendBlock),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    BlobErrors.VerifyHttpsCustomerProvidedKey(Uri, ClientConfiguration.CustomerProvidedKey);
                    Errors.VerifyStreamPosition(content, nameof(content));

                    // compute hash BEFORE attaching progress handler
                    ContentHasher.GetHashResult hashResult = await ContentHasher.GetHashOrDefaultInternal(
                        content,
                        validationOptions,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    content = content.WithNoDispose().WithProgress(progressHandler);

                    ResponseWithHeaders<AppendBlobAppendBlockHeaders> response;

                    if (async)
                    {
                        response = await AppendBlobRestClient.AppendBlockAsync(
                            contentLength: (content.Length - content.Position),
                            body: content,
                            transactionalContentCrc64: hashResult?.StorageCrc64AsArray,
                            transactionalContentMD5: hashResult?.MD5AsArray,
                            leaseId: conditions?.LeaseId,
                            maxSize: conditions?.IfMaxSizeLessThanOrEqual,
                            appendPosition: conditions?.IfAppendPositionEqual,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = AppendBlobRestClient.AppendBlock(
                            contentLength: (content.Length - content.Position),
                            body: content,
                            transactionalContentCrc64: hashResult?.StorageCrc64AsArray,
                            transactionalContentMD5: hashResult?.MD5AsArray,
                            leaseId: conditions?.LeaseId,
                            maxSize: conditions?.IfMaxSizeLessThanOrEqual,
                            appendPosition: conditions?.IfAppendPositionEqual,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobAppendInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(AppendBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion AppendBlock

        #region AppendBlockFromUri
        /// <summary>
        /// The <see cref="AppendBlockFromUri(Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken)"/>
        /// operation commits a new block of data, represented by the <paramref name="sourceUri"/>,
        /// to the end of the existing append blob.  The
        /// <see cref="AppendBlockFromUri(Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken)"/>
        /// operation is only permitted if the blob was created as an append blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/append-block-from-url">
        /// Append Block From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri"/> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="options">
        /// Optional parameters.  <see cref="AppendBlobAppendBlockFromUriOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobAppendInfo> AppendBlockFromUri(
            Uri sourceUri,
            AppendBlobAppendBlockFromUriOptions options = default,
            CancellationToken cancellationToken = default) =>
            AppendBlockFromUriInternal(
                sourceUri,
                options?.SourceRange ?? default,
                options?.SourceContentHash,
                options?.DestinationConditions,
                options?.SourceConditions,
                options?.SourceAuthentication,
                options?.SourceShareTokenIntent,
                options?.SourceCustomerProvidedKey,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AppendBlockFromUriAsync(Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken)"/>
        /// operation commits a new block of data, represented by the <paramref name="sourceUri"/>,
        /// to the end of the existing append blob.  The
        /// <see cref="AppendBlockFromUriAsync(Uri, AppendBlobAppendBlockFromUriOptions, CancellationToken)"/>
        /// operation is only permitted if the blob was created as an append blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/append-block-from-url">
        /// Append Block From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri"/> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="options">
        /// Optional parameters.  <see cref="AppendBlobAppendBlockFromUriOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobAppendInfo>> AppendBlockFromUriAsync(
            Uri sourceUri,
            AppendBlobAppendBlockFromUriOptions options = default,
            CancellationToken cancellationToken = default) =>
            await AppendBlockFromUriInternal(
                sourceUri,
                options?.SourceRange ?? default,
                options?.SourceContentHash,
                options?.DestinationConditions,
                options?.SourceConditions,
                options?.SourceAuthentication,
                options?.SourceShareTokenIntent,
                options?.SourceCustomerProvidedKey,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AppendBlockFromUriAsync(Uri, HttpRange, byte[], AppendBlobRequestConditions, AppendBlobRequestConditions, CancellationToken)"/>
        /// operation commits a new block of data, represented by the <paramref name="sourceUri"/>,
        /// to the end of the existing append blob.  The
        /// <see cref="AppendBlockFromUriAsync(Uri, HttpRange, byte[], AppendBlobRequestConditions, AppendBlobRequestConditions, CancellationToken)"/>
        /// operation is only permitted if the blob was created as an append blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/append-block-from-url">
        /// Append Block From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri"/> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single append block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the append block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data to this append blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<BlobAppendInfo> AppendBlockFromUri(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange sourceRange,
            byte[] sourceContentHash,
            AppendBlobRequestConditions conditions,
            AppendBlobRequestConditions sourceConditions,
            CancellationToken cancellationToken) =>
            AppendBlockFromUriInternal(
                sourceUri,
                sourceRange,
                sourceContentHash,
                conditions,
                sourceConditions,
                sourceAuthentication: default,
                sourceShareTokenIntent: default,
                sourceCustomerProvidedKey: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AppendBlockFromUriAsync(Uri, HttpRange, byte[], AppendBlobRequestConditions, AppendBlobRequestConditions, CancellationToken)"/>
        /// operation commits a new block of data, represented by the <paramref name="sourceUri"/>,
        /// to the end of the existing append blob.  The
        /// <see cref="AppendBlockFromUriAsync(Uri, HttpRange, byte[], AppendBlobRequestConditions, AppendBlobRequestConditions, CancellationToken)"/>
        /// operation is only permitted if the blob was created as an append blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/append-block-from-url">
        /// Append Block From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri"/> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single append block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the append block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data to this append blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<BlobAppendInfo>> AppendBlockFromUriAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange sourceRange,
            byte[] sourceContentHash,
            AppendBlobRequestConditions conditions,
            AppendBlobRequestConditions sourceConditions,
            CancellationToken cancellationToken) =>
            await AppendBlockFromUriInternal(
                sourceUri,
                sourceRange,
                sourceContentHash,
                conditions,
                sourceConditions,
                sourceAuthentication: default,
                sourceShareTokenIntent: default,
                sourceCustomerProvidedKey: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AppendBlockFromUriInternal"/> operation commits a new
        /// block of data, represented by the <paramref name="sourceUri"/>,
        /// to the end of the existing append blob.  The
        /// <see cref="AppendBlockFromUriInternal"/> operation is only permitted
        /// if the blob was created as an append blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/append-block-from-url">
        /// Append Block From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri"/> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// <paramref name="sourceUri"/> in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single append block.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the append block content from the
        /// <paramref name="sourceUri"/>.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the <paramref name="sourceUri"/>
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data to this append blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="sourceAuthentication">
        /// Optional. Source authentication used to access the source blob.
        /// </param>
        /// <param name="sourceShareTokenIntent">
        /// Optional, only applicable (but required) when the source is Azure Storage Files and using token authentication.
        /// Used to indicate the intent of the request.
        /// </param>
        /// <param name="sourceCustomerProvidedKey">
        /// Optional. Specifies the source customer provided key to use to encrypt the source blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobAppendInfo}"/> describing the
        /// state of the updated append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobAppendInfo>> AppendBlockFromUriInternal(
            Uri sourceUri,
            HttpRange sourceRange,
            byte[] sourceContentHash,
            AppendBlobRequestConditions conditions,
            AppendBlobRequestConditions sourceConditions,
            HttpAuthorization sourceAuthentication,
            FileShareTokenIntent? sourceShareTokenIntent,
            CustomerProvidedKey? sourceCustomerProvidedKey,
            bool async,
            CancellationToken cancellationToken = default)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(AppendBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(AppendBlobClient)}.{nameof(AppendBlockFromUri)}");

                // All destination AppendBlobRequestConditions are valid.
                conditions.ValidateConditionsNotPresent(
                    invalidConditions: BlobRequestConditionProperty.None,
                    operationName: nameof(AppendBlobClient.AppendBlockFromUri),
                    parameterName: nameof(conditions));

                sourceConditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.LeaseId
                        | BlobRequestConditionProperty.TagConditions
                        | BlobRequestConditionProperty.IfAppendPositionEqual
                        | BlobRequestConditionProperty.IfMaxSizeLessThanOrEqual,
                    operationName: nameof(AppendBlobClient.AppendBlockFromUri),
                    parameterName: nameof(sourceConditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<AppendBlobAppendBlockFromUrlHeaders> response;

                    if (async)
                    {
                        response = await AppendBlobRestClient.AppendBlockFromUrlAsync(
                            sourceUrl: sourceUri.AbsoluteUri,
                            contentLength: 0,
                            sourceRange: sourceRange.ToString(),
                            sourceContentMD5: sourceContentHash,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            leaseId: conditions?.LeaseId,
                            maxSize: conditions?.IfMaxSizeLessThanOrEqual,
                            appendPosition: conditions?.IfAppendPositionEqual,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                            sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                            sourceIfMatch: sourceConditions?.IfMatch?.ToString(),
                            sourceIfNoneMatch: sourceConditions?.IfNoneMatch?.ToString(),
                            copySourceAuthorization: sourceAuthentication?.ToString(),
                            fileRequestIntent: sourceShareTokenIntent,
                            sourceEncryptionKey: sourceCustomerProvidedKey?.EncryptionKey,
                            sourceEncryptionKeySha256: sourceCustomerProvidedKey?.EncryptionKeyHash,
                            sourceEncryptionAlgorithm: sourceCustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = AppendBlobRestClient.AppendBlockFromUrl(
                            sourceUrl: sourceUri.AbsoluteUri,
                            contentLength: 0,
                            sourceRange: sourceRange.ToString(),
                            sourceContentMD5: sourceContentHash,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            leaseId: conditions?.LeaseId,
                            maxSize: conditions?.IfMaxSizeLessThanOrEqual,
                            appendPosition: conditions?.IfAppendPositionEqual,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                            sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                            sourceIfMatch: sourceConditions?.IfMatch?.ToString(),
                            sourceIfNoneMatch: sourceConditions?.IfNoneMatch?.ToString(),
                            copySourceAuthorization: sourceAuthentication?.ToString(),
                            fileRequestIntent: sourceShareTokenIntent,
                            sourceEncryptionKey: sourceCustomerProvidedKey?.EncryptionKey,
                            sourceEncryptionKeySha256: sourceCustomerProvidedKey?.EncryptionKeyHash,
                            sourceEncryptionAlgorithm: sourceCustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobAppendInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(AppendBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion AppendBlockFromUri

        #region Seal
        /// <summary>
        /// Seals the append blob, making it read only.
        /// Any subsequent appends will fail.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the sealing of this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the
        /// state of the sealed append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobInfo> Seal(
            AppendBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => SealInternal(
                conditions,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Seals the append blob, making it read only.
        /// Any subsequent appends will fail.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the sealing of this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the
        /// state of the sealed append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobInfo>> SealAsync(
            AppendBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => await SealInternal(
                conditions,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Seals the append blob, making it read only.
        /// Any subsequent appends will fail.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the sealing of this blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the
        /// state of the sealed append blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobInfo>> SealInternal(
            AppendBlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(AppendBlobClient)))
            {
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(AppendBlobClient)}.{nameof(Seal)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfMaxSizeLessThanOrEqual
                        | BlobRequestConditionProperty.TagConditions,
                    operationName: nameof(AppendBlobClient.Seal),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<AppendBlobSealHeaders> response;

                    if (async)
                    {
                        response = await AppendBlobRestClient.SealAsync(
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            appendPosition: conditions?.IfAppendPositionEqual,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = AppendBlobRestClient.Seal(
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            appendPosition: conditions?.IfAppendPositionEqual,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobInfo(),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(AppendBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Seal

        #region OpenWrite
        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
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
        ///
        /// During the disposal of the returned write stream, an exception may be thrown.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenWrite(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            AppendBlobOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => OpenWriteInternal(
                overwrite: overwrite,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
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
        ///
        /// During the disposal of the returned write stream, an exception may be thrown.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenWriteAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            AppendBlobOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => await OpenWriteInternal(
                overwrite: overwrite,
                options: options,
                async: true,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
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
        /// A stream to write to the Append Blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        ///
        /// During the disposal of the returned write stream, an exception may be thrown.
        /// </remarks>
        private async Task<Stream> OpenWriteInternal(
            bool overwrite,
            AppendBlobOpenWriteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(AppendBlobClient)}.{nameof(OpenWrite)}");

            try
            {
                scope.Start();

                long position;
                ETag? etag;

                if (overwrite)
                {
                    Response<BlobContentInfo> createResponse = await CreateInternal(
                        httpHeaders: default,
                        metadata: default,
                        tags: default,
                        conditions: options?.OpenConditions,
                        immutabilityPolicy: default,
                        legalHold: default,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    position = 0;
                    etag = createResponse.Value.ETag;
                }
                else
                {
                    try
                    {
                        Response<BlobProperties> propertiesResponse = await GetPropertiesInternal(
                            conditions: options?.OpenConditions,
                            async: async,
                            context: new RequestContext() { CancellationToken = cancellationToken })
                            .ConfigureAwait(false);

                        position = propertiesResponse.Value.ContentLength;
                        etag = propertiesResponse.Value.ETag;
                    }
                    catch (RequestFailedException ex)
                    when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
                    {
                        Response<BlobContentInfo> createResponse = await CreateInternal(
                            httpHeaders: default,
                            metadata: default,
                            tags: default,
                            conditions: options?.OpenConditions,
                            immutabilityPolicy: default,
                            legalHold: default,
                            async: async,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

                        position = 0;
                        etag = createResponse.Value.ETag;
                    }
                }

                AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
                {
                    IfMatch = etag,
                    LeaseId = options?.OpenConditions?.LeaseId,
                };

                return new AppendBlobWriteStream(
                    appendBlobClient: this,
                    bufferSize: options?.BufferSize ?? Constants.DefaultBufferSize,
                    position: position,
                    conditions: conditions,
                    progressHandler: options?.ProgressHandler,
                    options?.TransferValidation ?? ClientConfiguration.TransferValidation.Upload
                    );
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
        #endregion OpenWrite
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> for
    /// creating <see cref="AppendBlobClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="AppendBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <paramref name="client"/>'s
        /// <see cref="BlobContainerClient.Uri"/>. The new
        /// <see cref="AppendBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="blobName">The name of the append blob.</param>
        /// <returns>A new <see cref="AppendBlobClient"/> instance.</returns>
        public static AppendBlobClient GetAppendBlobClient(
            this BlobContainerClient client,
            string blobName)
        {
            return client.GetAppendBlobClientCore(blobName);
        }
    }
}
