// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="PageBlobClient"/> allows you to manipulate Azure
    /// Storage page blobs.
    ///
    /// Page blobs are a collection of 512-byte pages optimized for random
    /// read and write operations. To create a page blob, you initialize the
    /// page blob and specify the maximum size the page blob will grow. To add
    /// or update the contents of a page blob, you write a page or pages by
    /// specifying an offset and a range that align to 512-byte page
    /// boundaries.  A write to a page blob can overwrite just one page, some
    /// pages, or up to 4 MB of the page blob.  Writes to page blobs happen
    /// in-place and are immediately committed to the blob. The maximum size
    /// for a page blob is 8 TB.
    /// </summary>
    public class PageBlobClient : BlobBaseClient
    {
        /// <summary>
        /// Gets the number of bytes in a page (512).
        /// </summary>
		public virtual int PageBlobPageBytes => 512;

        /// <summary>
        /// Gets the maximum number of bytes that can be sent in a call
        /// to the <see cref="UploadPagesAsync(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        /// </summary>
        public virtual int PageBlobMaxUploadPagesBytes => 4 * Constants.MB; // 4MB

        /// <summary>
        /// PageBlobRestClient.
        /// </summary>
        private readonly PageBlobRestClient _pageBlobRestClient;

        /// <summary>
        /// PageBlobRestClient.
        /// </summary>
        internal virtual PageBlobRestClient PageBlobRestClient => _pageBlobRestClient;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class for mocking.
        /// </summary>
        protected PageBlobClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>
        /// </param>
        /// <param name="blobContainerName">
        /// The name of the container containing this page blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this page blob.
        /// </param>
        public PageBlobClient(string connectionString, string blobContainerName, string blobName)
            : base(connectionString, blobContainerName, blobName)
        {
            _pageBlobRestClient = BuildPageBlobRestClient(_uri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
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
        /// The name of the container containing this page blob.
        /// </param>
        /// <param name="blobName">
        /// The name of this page blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public PageBlobClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            : base(connectionString, blobContainerName, blobName, options)
        {
            _pageBlobRestClient = BuildPageBlobRestClient(_uri);
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
        /// name of the account, the name of the blob container, and the name of
        /// the blob.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public PageBlobClient(Uri blobUri, BlobClientOptions options = default)
            : base(blobUri, options)
        {
            _pageBlobRestClient = BuildPageBlobRestClient(blobUri);
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
        /// name of the account, the name of the blob container, and the name of
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
        public PageBlobClient(Uri blobUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            _pageBlobRestClient = BuildPageBlobRestClient(blobUri);
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
        /// name of the account, the name of the blob container, and the name of
        /// the blob.
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
        public PageBlobClient(Uri blobUri, AzureSasCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            _pageBlobRestClient = BuildPageBlobRestClient(blobUri);
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
        /// name of the account, the name of the blob container, and the name of
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
        public PageBlobClient(Uri blobUri, TokenCredential credential, BlobClientOptions options = default)
            : base(blobUri, credential, options)
        {
            _pageBlobRestClient = BuildPageBlobRestClient(blobUri);
            AssertNoClientSideEncryption(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class.
        /// </summary>
        /// <param name="blobUri">
        /// A <see cref="Uri"/> referencing the page blob that includes the
        /// name of the account, the name of the blob container, and the name of
        /// the blob.
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="BlobClientConfiguration"/>.
        /// </param>
        internal PageBlobClient(
            Uri blobUri,
            BlobClientConfiguration clientConfiguration)
            : base(
                  blobUri,
                  clientConfiguration,
                  clientSideEncryption: default)
        {
            _pageBlobRestClient = BuildPageBlobRestClient(blobUri);
        }

        private static void AssertNoClientSideEncryption(BlobClientOptions options)
        {
            if (options?._clientSideEncryptionOptions != default)
            {
                throw Errors.ClientSideEncryption.TypeNotSupported(typeof(PageBlobClient));
            }
        }

        private PageBlobRestClient BuildPageBlobRestClient(Uri blobUri)
        {
            return new PageBlobRestClient(
                clientDiagnostics: _clientConfiguration.ClientDiagnostics,
                pipeline: _clientConfiguration.Pipeline,
                url: blobUri.AbsoluteUri,
                version: _clientConfiguration.Version.ToVersionString());
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// snapshot timestamp.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null or empty string to remove the snapshot returning a URL
        /// to the base blob.
        /// </remarks>
        public new PageBlobClient WithSnapshot(string snapshot) => (PageBlobClient)WithSnapshotCore(snapshot);

        /// <summary>
        /// Creates a new instance of the <see cref="PageBlobClient"/> class
        /// with an identical <see cref="Uri"/> source but the specified
        /// snapshot timestamp.
        /// </summary>
        /// <param name="snapshot">The snapshot identifier.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        protected sealed override BlobBaseClient WithSnapshotCore(string snapshot)
        {
            var builder = new BlobUriBuilder(Uri)
            {
                Snapshot = snapshot
            };

            return new PageBlobClient(
                builder.ToUri(),
                ClientConfiguration);
        }

        /// <summary>
        /// Creates a new PageBlobClient object identical to the source but with the specified version ID.
        /// Pass "" to remove the version ID returning a URL to the base blob.
        /// </summary>
        /// <param name="versionId">version ID</param>
        /// <returns></returns>
        public new PageBlobClient WithVersion(string versionId)
        {
            var builder = new BlobUriBuilder(Uri)
            {
                VersionId = versionId
            };

            return new PageBlobClient(
                builder.ToUri(),
                ClientConfiguration);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/>.
        ///
        /// </summary>
        /// <param name="customerProvidedKey">The customer provided key.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the customer provide key in the returned <see cref="PageBlobClient"/>.
        /// </remarks>
        public new PageBlobClient WithCustomerProvidedKey(CustomerProvidedKey? customerProvidedKey)
        {
            BlobClientConfiguration newClientConfiguration = BlobClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.CustomerProvidedKey = customerProvidedKey;
            return new PageBlobClient(
                blobUri: Uri,
                clientConfiguration: newClientConfiguration);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBlobClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="encryptionScope"/>.
        ///
        /// </summary>
        /// <param name="encryptionScope">The encryption scope.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the encryption scope in the returned <see cref="PageBlobClient"/>.
        /// </remarks>
        public new PageBlobClient WithEncryptionScope(string encryptionScope)
        {
            BlobClientConfiguration newClientConfiguration = BlobClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.EncryptionScope = encryptionScope;
            return new PageBlobClient(
                blobUri: Uri,
                clientConfiguration: newClientConfiguration);
        }

        #region Create
        /// <summary>
        /// The <see cref="Create(long, PageBlobCreateOptions, CancellationToken)"/>
        /// operation creates a new page blob of the specified <paramref name="size"/>.
        /// The content of any existing blob is overwritten with the newly initialized page blob
        /// To add content to the page blob, call the
        /// <see cref="UploadPages(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
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
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> Create(
            long size,
            PageBlobCreateOptions options,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                size,
                options?.SequenceNumber,
                options?.HttpHeaders,
                options?.Metadata,
                options?.Tags,
                options?.Conditions,
                options?.ImmutabilityPolicy,
                options?.LegalHold,
                options?.PremiumPageBlobAccessTier,
                async: false,
                cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync(long, PageBlobCreateOptions, CancellationToken)"/>
        /// operation creates a new page blob of the specified <paramref name="size"/>.
        /// The content of any existing blob is overwritten with the newly initialized page blob
        /// To add content to the page blob, call the
        /// <see cref="UploadPages(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
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
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CreateAsync(
            long size,
            PageBlobCreateOptions options,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                size,
                options?.SequenceNumber,
                options?.HttpHeaders,
                options?.Metadata,
                options?.Tags,
                options?.Conditions,
                options?.ImmutabilityPolicy,
                options?.LegalHold,
                options?.PremiumPageBlobAccessTier,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Create(long, long?, BlobHttpHeaders, Metadata, PageBlobRequestConditions, CancellationToken)"/>
        /// operation creates a new page blob of the specified <paramref name="size"/>.  The content of any
        /// existing blob is overwritten with the newly initialized page blob
        /// To add content to the page blob, call the
        /// <see cref="UploadPages(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the creation of this new page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContentInfo> Create(
            long size,
            long? sequenceNumber = default,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                size: size,
                sequenceNumber: sequenceNumber,
                httpHeaders: httpHeaders,
                metadata: metadata,
                tags: default,
                conditions: conditions,
                immutabilityPolicy: default,
                legalHold: default,
                premiumPageBlobAccessTier: default,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateAsync(long, long?, BlobHttpHeaders, Metadata, PageBlobRequestConditions, CancellationToken)"/>
        /// operation creates a new page blob of the specified <paramref name="size"/>.  The content of any
        /// existing blob is overwritten with the newly initialized page blob
        /// To add content to the page blob, call the
        /// <see cref="UploadPagesAsync(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the creation of this new page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContentInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContentInfo>> CreateAsync(
            long size,
            long? sequenceNumber = default,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                size: size,
                sequenceNumber: sequenceNumber,
                httpHeaders: httpHeaders,
                metadata: metadata,
                tags: default,
                conditions: conditions,
                immutabilityPolicy: default,
                legalHold: default,
                premiumPageBlobAccessTier: default,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExists(long, PageBlobCreateOptions, CancellationToken)"/>
        /// operation creates a new page blob of the specified <paramref name="size"/>.  If the blob already
        /// exists, the content of the existing blob will remain unchanged. If the blob does not already exists,
        /// a new page blob with the specified <paramref name="size"/> will be created.
        /// <see cref="UploadPages(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the page blob does not already exist, A <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created page blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobContentInfo> CreateIfNotExists(
            long size,
            PageBlobCreateOptions options,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                size,
                options?.SequenceNumber,
                options?.HttpHeaders,
                options?.Metadata,
                options?.Tags,
                options?.ImmutabilityPolicy,
                options?.LegalHold,
                options?.PremiumPageBlobAccessTier,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync(long, PageBlobCreateOptions, CancellationToken)"/>
        /// operation creates a new page blob of the specified <paramref name="size"/>.  If the blob already
        /// exists, the content of the existing blob will remain unchanged. If the blob does not already exists,
        /// a new page blob with the specified <paramref name="size"/> will be created.
        /// <see cref="UploadPages(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the page blob does not already exist, A <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created page blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobContentInfo>> CreateIfNotExistsAsync(
            long size,
            PageBlobCreateOptions options,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                size,
                options?.SequenceNumber,
                options?.HttpHeaders,
                options?.Metadata,
                options?.Tags,
                options?.ImmutabilityPolicy,
                options?.LegalHold,
                options?.PremiumPageBlobAccessTier,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExists(long, long?, BlobHttpHeaders, Metadata, CancellationToken)"/>
        /// operation creates a new page blob of the specified <paramref name="size"/>.  If the blob already
        /// exists, the content of the existing blob will remain unchanged. If the blob does not already exists,
        /// a new page blob with the specified <paramref name="size"/> will be created.
        /// <see cref="UploadPages(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the page blob does not already exist, A <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created page blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobContentInfo> CreateIfNotExists(
            long size,
            long? sequenceNumber = default,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            CreateIfNotExistsInternal(
                size: size,
                sequenceNumber: sequenceNumber,
                httpHeaders: httpHeaders,
                metadata: metadata,
                tags: default,
                immutabilityPolicy: default,
                legalHold: default,
                premiumPageBlobAccessTier: default,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="CreateIfNotExistsAsync(long, long?, BlobHttpHeaders, Metadata, CancellationToken)"/>
        /// operation creates a new page blob of the specified <paramref name="size"/>.  If the blob already exists,
        /// the content of the existing blob will remain unchanged. If the blob does not already exists,
        /// a new page blob with the specified <paramref name="size"/> will be created.
        /// <see cref="UploadPagesAsync(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the page blob does not already exist, A <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created page blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobContentInfo>> CreateIfNotExistsAsync(
            long size,
            long? sequenceNumber = default,
            BlobHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default) =>
            await CreateIfNotExistsInternal(
                size: size,
                sequenceNumber: sequenceNumber,
                httpHeaders: httpHeaders,
                metadata: metadata,
                tags: default,
                immutabilityPolicy: default,
                legalHold: default,
                premiumPageBlobAccessTier: default,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="CreateIfNotExistsInternal"/> operation creates a new page blob
        /// of the specified <paramref name="size"/>.  If the blob already exists, the content of
        /// the existing blob will remain unchanged. If the blob does not already exists,
        /// a new page blob with the specified <paramref name="size"/> will be created.
        /// To add content to the page blob, call the
        /// <see cref="UploadPagesAsync(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// <param name="tags">
        /// Optional tags to set for this page blob.
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
        /// <param name="premiumPageBlobAccessTier">
        /// Optional.  Sets the page blob tiers on the blob.
        /// This is only supported for page blobs on premium accounts.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the page blob does not already exist, A <see cref="Response{BlobContentInfo}"/>
        /// describing the newly created page blob. Otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobContentInfo>> CreateIfNotExistsInternal(
            long size,
            long? sequenceNumber,
            BlobHttpHeaders httpHeaders,
            Metadata metadata,
            Tags tags,
            BlobImmutabilityPolicy immutabilityPolicy,
            bool? legalHold,
            PremiumPageBlobAccessTier? premiumPageBlobAccessTier,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(size)}: {size}\n" +
                    $"{nameof(sequenceNumber)}: {sequenceNumber}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");

                PageBlobRequestConditions conditions = new PageBlobRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) };
                try
                {
                    return await CreateInternal(
                        size,
                        sequenceNumber,
                        httpHeaders,
                        metadata,
                        tags,
                        conditions,
                        immutabilityPolicy,
                        legalHold,
                        premiumPageBlobAccessTier,
                        async,
                        cancellationToken,
                        $"{nameof(PageBlobClient)}.{nameof(CreateIfNotExists)}")
                        .ConfigureAwait(false);
                }
                catch (RequestFailedException storageRequestFailedException)
                when (storageRequestFailedException.ErrorCode == BlobErrorCode.BlobAlreadyExists)
                {
                    return default;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="CreateInternal"/> operation creates a new page blob
        /// of the specified <paramref name="size"/>.  The content of any
        /// existing blob is overwritten with the newly initialized page blob
        /// To add content to the page blob, call the
        /// <see cref="UploadPagesAsync(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation.
        ///
        /// For more information, see https://docs.microsoft.com/rest/api/storageservices/put-blob.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.
        /// </param>
        /// <param name="sequenceNumber">
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the <paramref name="sequenceNumber"/> must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this page blob.
        /// </param>
        /// <param name="tags">
        /// Optional tags to set for this page blob.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the creation of this new page blob.
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
        /// <param name="premiumPageBlobAccessTier">
        /// Optional.  Sets the page blob tiers on the blob.
        /// This is only supported for page blobs on premium accounts.
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
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobContentInfo>> CreateInternal(
            long size,
            long? sequenceNumber,
            BlobHttpHeaders httpHeaders,
            Metadata metadata,
            Tags tags,
            PageBlobRequestConditions conditions,
            BlobImmutabilityPolicy immutabilityPolicy,
            bool? legalHold,
            PremiumPageBlobAccessTier? premiumPageBlobAccessTier,
            bool async,
            CancellationToken cancellationToken,
            string operationName = null)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(size)}: {size}\n" +
                    $"{nameof(sequenceNumber)}: {sequenceNumber}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}");

                operationName ??= $"{nameof(PageBlobClient)}.{nameof(Create)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.Create),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageBlobCreateHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.CreateAsync(
                            contentLength: 0,
                            blobContentLength: size,
                            tier: premiumPageBlobAccessTier,
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
                            blobSequenceNumber: sequenceNumber,
                            blobTagsString: tags?.ToTagsString(),
                            immutabilityPolicyExpiry: immutabilityPolicy?.ExpiresOn,
                            immutabilityPolicyMode: immutabilityPolicy?.PolicyMode,
                            legalHold: legalHold,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PageBlobRestClient.Create(
                            contentLength: 0,
                            blobContentLength: size,
                            tier: premiumPageBlobAccessTier,
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
                            blobSequenceNumber: sequenceNumber,
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Create

        #region UploadPages
        /// <summary>
        /// The <see cref="UploadPages(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation writes
        /// <paramref name="content"/> to a range of pages in a page blob,
        /// starting at <paramref name="offset"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-page">
        /// Put Page</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the pages to
        /// upload.  The content can be up to 4 MB in size.
        /// </param>
        /// <param name="offset">
        /// Specifies the starting offset for the <paramref name="content"/>
        /// to be written as a page.  Given that pages must be aligned with
        /// 512-byte boundaries, the start offset must be a modulus of 512.
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
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on uploading pages to this page blob.
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
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PageInfo> UploadPages(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            long offset,
            byte[] transactionalContentHash,
            PageBlobRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            return UploadPagesInternal(
                content,
                offset,
                transactionalContentHash.ToValidationOptions(),
                conditions,
                progressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="UploadPagesAsync(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> operation writes
        /// <paramref name="content"/> to a range of pages in a page blob,
        /// starting at <paramref name="offset"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-page">
        /// Put Page</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the pages to
        /// upload.  The content can be up to 4 MB in size.
        /// </param>
        /// <param name="offset">
        /// Specifies the starting offset for the <paramref name="content"/>
        /// to be written as a page.  Given that pages must be aligned with
        /// 512-byte boundaries, the start offset must be a modulus of 512.
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
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on uploading pages to this page blob.
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
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<PageInfo>> UploadPagesAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            long offset,
            byte[] transactionalContentHash,
            PageBlobRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            return await UploadPagesInternal(
                content,
                offset,
                transactionalContentHash.ToValidationOptions(),
                conditions,
                progressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="UploadPages(Stream, long, PageBlobUploadPagesOptions, CancellationToken)"/> operation writes
        /// <paramref name="content"/> to a range of pages in a page blob,
        /// starting at <paramref name="offset"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-page">
        /// Put Page</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the pages to
        /// upload.  The content can be up to 4 MB in size.
        /// </param>
        /// <param name="offset">
        /// Specifies the starting offset for the <paramref name="content"/>
        /// to be written as a page.  Given that pages must be aligned with
        /// 512-byte boundaries, the start offset must be a modulus of 512.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PageInfo> UploadPages(
            Stream content,
            long offset,
            PageBlobUploadPagesOptions options = default,
            CancellationToken cancellationToken = default) =>
            UploadPagesInternal(
                content,
                offset,
                options?.TransferValidation,
                options?.Conditions,
                options?.ProgressHandler,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadPagesAsync(Stream, long, PageBlobUploadPagesOptions, CancellationToken)"/> operation writes
        /// <paramref name="content"/> to a range of pages in a page blob,
        /// starting at <paramref name="offset"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-page">
        /// Put Page</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the pages to
        /// upload.  The content can be up to 4 MB in size.
        /// </param>
        /// <param name="offset">
        /// Specifies the starting offset for the <paramref name="content"/>
        /// to be written as a page.  Given that pages must be aligned with
        /// 512-byte boundaries, the start offset must be a modulus of 512.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PageInfo>> UploadPagesAsync(
            Stream content,
            long offset,
            PageBlobUploadPagesOptions options = default,
            CancellationToken cancellationToken = default) =>
            await UploadPagesInternal(
                content,
                offset,
                options?.TransferValidation,
                options?.Conditions,
                options?.ProgressHandler,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadPagesInternal"/> operation writes
        /// <paramref name="content"/> to a range of pages in a page blob,
        /// starting at <paramref name="offset"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-page">
        /// Put Page</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content of the pages to
        /// upload.  The content can be up to 4 MB in size.
        /// </param>
        /// <param name="offset">
        /// Specifies the starting offset for the <paramref name="content"/>
        /// to be written as a page.  Given that pages must be aligned with
        /// 512-byte boundaries, the start offset must be a modulus of 512.
        /// </param>
        /// <param name="transferValidationOverride">
        /// Optional transfer validation options for uploading the page range.
        /// </param>
        /// <param name="conditions">
        /// Request conditions for page upload.
        /// </param>
        /// <param name="progressHandler">
        /// Progress handler for upload operation.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<PageInfo>> UploadPagesInternal(
            Stream content,
            long offset,
            UploadTransferValidationOptions transferValidationOverride,
            PageBlobRequestConditions conditions,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            UploadTransferValidationOptions validationOptions = transferValidationOverride ?? ClientConfiguration.TransferValidation.Upload;

            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(offset)}: {offset}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(UploadPages)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.UploadPages),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    Errors.VerifyStreamPosition(content, nameof(content));

                    // compute hash BEFORE attaching progress handler
                    ContentHasher.GetHashResult hashResult = await ContentHasher.GetHashOrDefaultInternal(
                        content,
                        validationOptions,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    content = content?.WithNoDispose().WithProgress(progressHandler);
                    HttpRange range = new HttpRange(offset, (content?.Length - content?.Position) ?? null);

                    ResponseWithHeaders<PageBlobUploadPagesHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.UploadPagesAsync(
                            contentLength: (content?.Length - content?.Position) ?? 0,
                            body: content,
                            transactionalContentCrc64: hashResult?.StorageCrc64AsArray,
                            transactionalContentMD5: hashResult?.MD5AsArray,
                            range: range.ToString(),
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifSequenceNumberLessThanOrEqualTo: conditions?.IfSequenceNumberLessThanOrEqual,
                            ifSequenceNumberLessThan: conditions?.IfSequenceNumberLessThan,
                            ifSequenceNumberEqualTo: conditions?.IfSequenceNumberEqual,
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
                        response = PageBlobRestClient.UploadPages(
                            contentLength: (content?.Length - content?.Position) ?? 0,
                            body: content,
                            transactionalContentCrc64: hashResult?.StorageCrc64AsArray,
                            transactionalContentMD5: hashResult?.MD5AsArray,
                            range: range.ToString(),
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifSequenceNumberLessThanOrEqualTo: conditions?.IfSequenceNumberLessThanOrEqual,
                            ifSequenceNumberLessThan: conditions?.IfSequenceNumberLessThan,
                            ifSequenceNumberEqualTo: conditions?.IfSequenceNumberEqual,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPageInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion UploadPages

        #region ClearPages
        /// <summary>
        /// The <see cref="ClearPages"/> operation clears one or more
        /// pages from the page blob, as specificed by the <paramref name="range"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-page">
        /// Put Page</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleared. Both the start and
        /// end of the range must be specified.  For a page clear operation,
        /// the page range can be up to the value of the blob's full size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on clearing pages from this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PageInfo> ClearPages(
            HttpRange range,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ClearPagesInternal(
                range,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ClearPagesAsync"/> operation clears one or more
        /// pages from the page blob, as specificed by the <paramref name="range"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-page">
        /// Put Page</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleared. Both the start and
        /// end of the range must be specified.  For a page clear operation,
        /// the page range can be up to the value of the blob's full size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on clearing pages from this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PageInfo>> ClearPagesAsync(
            HttpRange range,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await ClearPagesInternal(
                range,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ClearPagesInternal"/> operation clears one or more
        /// pages from the page blob, as specificed by the <paramref name="range"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/put-page">
        /// Put Page</see>.
        /// </summary>
        /// <param name="range">
        /// Specifies the range of bytes to be cleared. Both the start and
        /// end of the range must be specified.  For a page clear operation,
        /// the page range can be up to the value of the blob's full size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on clearing pages from this page blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PageInfo>> ClearPagesInternal(
            HttpRange range,
            PageBlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(ClearPages)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.ClearPages),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageBlobClearPagesHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.ClearPagesAsync(
                            contentLength: 0,
                            range: range.ToString(),
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifSequenceNumberLessThanOrEqualTo: conditions?.IfSequenceNumberLessThanOrEqual,
                            ifSequenceNumberLessThan: conditions?.IfSequenceNumberLessThan,
                            ifSequenceNumberEqualTo: conditions?.IfSequenceNumberEqual,
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
                        response = PageBlobRestClient.ClearPages(
                            contentLength: 0,
                            range: range.ToString(),
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            ifSequenceNumberLessThanOrEqualTo: conditions?.IfSequenceNumberLessThanOrEqual,
                            ifSequenceNumberLessThan: conditions?.IfSequenceNumberLessThan,
                            ifSequenceNumberEqualTo: conditions?.IfSequenceNumberEqual,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPageInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion ClearPages

        #region GetPageRanges
        /// <summary>
        /// The <see cref="GetAllPageRanges(GetPageRangesOptions, CancellationToken)"/> operation returns the list of
        /// valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Page{PageBlobRange}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Pageable<PageRangeItem> GetAllPageRanges(
            GetPageRangesOptions options = default,
            CancellationToken cancellationToken = default)
            => new GetPageRangesAsyncCollection(
                diff: false,
                client: this,
                range: options?.Range,
                snapshot: options?.Snapshot,
                previousSnapshot: null,
                previousSnapshotUri: null,
                requestConditions: options?.Conditions,
                operationName: $"{nameof(PageBlobClient)}.{nameof(GetAllPageRanges)}")
            .ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetAllPageRangesAsync(GetPageRangesOptions, CancellationToken)"/> operation returns the list of
        /// valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="AsyncPageable{PageBlobRange}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual AsyncPageable<PageRangeItem> GetAllPageRangesAsync(
            GetPageRangesOptions options = default,
            CancellationToken cancellationToken = default)
            => new GetPageRangesAsyncCollection(
                diff: false,
                client: this,
                range: options?.Range,
                snapshot: options?.Snapshot,
                previousSnapshot: null,
                previousSnapshotUri: null,
                requestConditions: options?.Conditions,
                operationName: $"{nameof(PageBlobClient)}.{nameof(GetAllPageRanges)}")
            .ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetAllPageRangesInteral"/> operation returns the list
        /// of valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of blobs to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="ListBlobsFlatSegmentResponse.NextMarker"/>
        /// if the listing operation did not return all blobs remaining to be
        /// listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="pageSizeHint">
        /// Gets or sets a value indicating the size of the page that should be
        /// requested.
        /// </param>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders>> GetAllPageRangesInteral(
            string marker,
            int? pageSizeHint,
            HttpRange? range,
            string snapshot,
            PageBlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(pageSizeHint)}: {pageSizeHint}\n" +
                    $"{nameof(range)}: {range}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(GetAllPageRanges)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.GetPageRanges),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.GetPageRangesAsync(
                            snapshot: snapshot,
                            range: range?.ToString(),
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            marker: marker,
                            maxresults: pageSizeHint,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PageBlobRestClient.GetPageRanges(
                            snapshot: snapshot,
                            range: range?.ToString(),
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            marker: marker,
                            maxresults: pageSizeHint,
                            cancellationToken: cancellationToken);
                    }

                    // Return an exploding Response on 304
                    if (response.IsUnavailable())
                    {
                        return response.GetRawResponse().AsNoBodyResponse<ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders>>();
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }

        /// <summary>
        /// The <see cref="GetPageRanges(HttpRange?, string, PageBlobRequestConditions, CancellationToken)"/>
        /// operation returns the list of valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PageRangesInfo> GetPageRanges(
            HttpRange? range = null,
            string snapshot = null,
            PageBlobRequestConditions conditions = null,
            CancellationToken cancellationToken = default) =>
            GetPageRangesInternal(
                range,
                snapshot,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPageRangesAsync(HttpRange?, string, PageBlobRequestConditions, CancellationToken)"/>
        /// operation returns the list of valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PageRangesInfo>> GetPageRangesAsync(
            HttpRange? range = null,
            string snapshot = null,
            PageBlobRequestConditions conditions = null,
            CancellationToken cancellationToken = default) =>
            await GetPageRangesInternal(
                range,
                snapshot,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPageRangesInternal"/> operation returns the list
        /// of valid page ranges for a page blob or snapshot of a page blob.
        ///
        /// For more information, see For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PageRangesInfo>> GetPageRangesInternal(
            HttpRange? range,
            string snapshot,
            PageBlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(GetPageRanges)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.GetPageRanges),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.GetPageRangesAsync(
                            snapshot: snapshot,
                            range: range?.ToString(),
                            leaseId: conditions?.LeaseId,
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
                        response = PageBlobRestClient.GetPageRanges(
                            snapshot: snapshot,
                            range: range?.ToString(),
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    // Return an exploding Response on 304
                    return response.IsUnavailable()
                        ? response.GetRawResponse().AsNoBodyResponse<PageRangesInfo>()
                        : Response.FromValue(
                            response.ToPageRangesInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetPageRanges

        #region GetPageRangesDiff
        /// <summary>
        /// The <see cref="GetAllPageRangesDiff(GetPageRangesDiffOptions, CancellationToken)"/>
        /// operation returns the list of page ranges that differ between a
        /// <see cref="GetPageRangesDiffOptions.PreviousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Pageable{PageBlobRange}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Pageable<PageRangeItem> GetAllPageRangesDiff(
            GetPageRangesDiffOptions options = default,
            CancellationToken cancellationToken = default)
            => new GetPageRangesAsyncCollection(
                diff: true,
                client: this,
                range: options?.Range,
                snapshot: options?.Snapshot,
                previousSnapshot: options?.PreviousSnapshot,
                previousSnapshotUri: null,
                requestConditions: options?.Conditions,
                operationName: $"{nameof(PageBlobClient)}.{nameof(GetAllPageRangesDiff)}")
            .ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetAllPageRangesDiffAsync(GetPageRangesDiffOptions, CancellationToken)"/>
        /// operation returns the list of page ranges that differ between a
        /// <see cref="GetPageRangesDiffOptions.PreviousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="AsyncPageable{PageBlobRange}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual AsyncPageable<PageRangeItem> GetAllPageRangesDiffAsync(
            GetPageRangesDiffOptions options = default,
            CancellationToken cancellationToken = default)
            => new GetPageRangesAsyncCollection(
                diff: true,
                client: this,
                range: options?.Range,
                snapshot: options?.Snapshot,
                previousSnapshot: options?.PreviousSnapshot,
                previousSnapshotUri: null,
                requestConditions: options?.Conditions,
                operationName: $"{nameof(PageBlobClient)}.{nameof(GetAllPageRangesDiff)}")
            .ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetAllPageRangesDiffInternal"/> operation returns the
        /// list of page ranges that differ between a
        /// <paramref name="previousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of blobs to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="ListBlobsFlatSegmentResponse.NextMarker"/>
        /// if the listing operation did not return all blobs remaining to be
        /// listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="pageSizeHint">
        /// Gets or sets a value indicating the size of the page that should be
        /// requested.
        /// </param>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="previousSnapshot">
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshot"/> is the older of the two.
        /// </param>
        /// <param name="previousSnapshotUri">
        /// This parameter only works with managed disk storage accounts.
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshotUri"/> is the older of the two.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="operationName">
        /// The name of the operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="ResponseWithHeaders{PageList, PageBlobGetPageRangesDiffHeaders}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<ResponseWithHeaders<PageList, PageBlobGetPageRangesDiffHeaders>> GetAllPageRangesDiffInternal(
            string marker,
            int? pageSizeHint,
            HttpRange? range,
            string snapshot,
            string previousSnapshot,
            Uri previousSnapshotUri,
            PageBlobRequestConditions conditions,
            bool async,
            string operationName,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(pageSizeHint)}: {pageSizeHint}\n" +
                    $"{nameof(range)}: {range}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(previousSnapshot)}: {previousSnapshot}\n" +
                    $"{nameof(previousSnapshotUri)}: {previousSnapshotUri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                operationName ??= $"{nameof(PageBlobClient)}.{nameof(GetAllPageRangesDiff)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.GetPageRanges),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageList, PageBlobGetPageRangesDiffHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.GetPageRangesDiffAsync(
                            snapshot: snapshot,
                            prevsnapshot: previousSnapshot,
                            prevSnapshotUrl: previousSnapshotUri?.AbsoluteUri,
                            range: range?.ToString(),
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            marker: marker,
                            maxresults: pageSizeHint,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PageBlobRestClient.GetPageRangesDiff(
                            snapshot: snapshot,
                            prevsnapshot: previousSnapshot,
                            prevSnapshotUrl: previousSnapshotUri?.AbsoluteUri,
                            range: range?.ToString(),
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            marker: marker,
                            maxresults: pageSizeHint,
                            cancellationToken: cancellationToken);
                    }

                    // Return an exploding Response on 304
                    if (response.IsUnavailable())
                    {
                        return response.GetRawResponse().AsNoBodyResponse<ResponseWithHeaders<PageList, PageBlobGetPageRangesDiffHeaders>>();
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    ClientConfiguration.Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }

        /// <summary>
        /// The <see cref="GetPageRangesDiff(HttpRange?, string, string, PageBlobRequestConditions, CancellationToken)"/>
        /// operation returns the list of page ranges that differ between a
        /// <paramref name="previousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="previousSnapshot">
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshot"/> is the older of the two.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PageRangesInfo> GetPageRangesDiff(
            HttpRange? range = null,
            string snapshot = null,
            string previousSnapshot = null,
            PageBlobRequestConditions conditions = null,
            CancellationToken cancellationToken = default) =>
            GetPageRangesDiffInternal(
                range,
                snapshot,
                previousSnapshot,
                previousSnapshotUri: default,
                conditions,
                async: false,
                operationName: $"{nameof(PageBlobClient)}.{nameof(GetPageRangesDiff)}",
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetPageRangesDiffAsync(HttpRange?, string, string, PageBlobRequestConditions, CancellationToken)"/>
        /// operation returns the list of page ranges that differ between a
        /// <paramref name="previousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="previousSnapshot">
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshot"/> is the older of the two.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PageRangesInfo>> GetPageRangesDiffAsync(
            HttpRange? range = null,
            string snapshot = null,
            string previousSnapshot = null,
            PageBlobRequestConditions conditions = null,
            CancellationToken cancellationToken = default) =>
            await GetPageRangesDiffInternal(
                range,
                snapshot,
                previousSnapshot,
                previousSnapshotUri: default,
                conditions,
                async: true,
                operationName: $"{nameof(PageBlobClient)}.{nameof(GetPageRangesDiff)}",
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetPageRangesDiffInternal"/> operation returns the
        /// list of page ranges that differ between a
        /// <paramref name="previousSnapshot"/> and this page blob. Changed pages
        /// include both updated and cleared pages.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="previousSnapshot">
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshot"/> is the older of the two.
        /// </param>
        /// <param name="previousSnapshotUri">
        /// This parameter only works with managed disk storage accounts.
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshotUri"/> is the older of the two.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="operationName">
        /// The name of the operation.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PageRangesInfo>> GetPageRangesDiffInternal(
            HttpRange? range,
            string snapshot,
            string previousSnapshot,
            Uri previousSnapshotUri,
            PageBlobRequestConditions conditions,
            bool async,
            string operationName,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(previousSnapshot)}: {previousSnapshot}\n" +
                    $"{nameof(previousSnapshotUri)}: {previousSnapshotUri}\n" +
                    $"{nameof(conditions)}: {conditions}");

                operationName ??= $"{nameof(PageBlobClient)}.{nameof(GetPageRangesDiff)}";
                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope(operationName);

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.GetPageRangesDiff),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageList, PageBlobGetPageRangesDiffHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.GetPageRangesDiffAsync(
                            snapshot: snapshot,
                            prevsnapshot: previousSnapshot,
                            prevSnapshotUrl: previousSnapshotUri?.AbsoluteUri,
                            range: range?.ToString(),
                            leaseId: conditions?.LeaseId,
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
                        response = PageBlobRestClient.GetPageRangesDiff(
                            snapshot: snapshot,
                            prevsnapshot: previousSnapshot,
                            prevSnapshotUrl: previousSnapshotUri?.AbsoluteUri,
                            range: range?.ToString(),
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    // Return an exploding Response on 304
                    return response.IsUnavailable() ?
                        response.GetRawResponse().AsNoBodyResponse<PageRangesInfo>() :
                        Response.FromValue(
                            response.ToPageRangesInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion GetPageRangesDiff

        #region GetManagedDiskPageRangesDiff
        /// <summary>
        /// The <see cref="GetManagedDiskPageRangesDiff"/>
        /// operation returns the list of page ranges that differ between a
        /// <paramref name="previousSnapshotUri"/> and this page blob. Changed pages
        /// include both updated and cleared pages.  This API only works with
        /// managed disk storage accounts.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="previousSnapshotUri">
        /// This parameter only works with managed disk storage accounts.
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshotUri"/> is the older of the two.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PageRangesInfo> GetManagedDiskPageRangesDiff(
            HttpRange? range = default,
            string snapshot = default,
            Uri previousSnapshotUri = default,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetPageRangesDiffInternal(
                range,
                snapshot,
                previousSnapshot: default,
                previousSnapshotUri,
                conditions,
                async: false,
                operationName: $"{nameof(PageBlobClient)}.{nameof(GetManagedDiskPageRangesDiff)}",
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetManagedDiskPageRangesDiffAsync"/>
        /// operation returns the list of page ranges that differ between a
        /// <paramref name="previousSnapshotUri"/> and this page blob. Changed pages
        /// include both updated and cleared pages.  This API only works with
        /// managed disk storage accounts.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-page-ranges">
        /// Get Page Ranges</see>.
        /// </summary>
        /// <param name="range">
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </param>
        /// <param name="snapshot">
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </param>
        /// <param name="previousSnapshotUri">
        /// This parameter only works with managed disk storage accounts.
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <paramref name="previousSnapshotUri"/> is the older of the two.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageRangesInfo}"/> describing the
        /// valid page ranges for this blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PageRangesInfo>> GetManagedDiskPageRangesDiffAsync(
            HttpRange? range = default,
            string snapshot = default,
            Uri previousSnapshotUri = default,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetPageRangesDiffInternal(
                range,
                snapshot,
                previousSnapshot: default,
                previousSnapshotUri,
                conditions,
                async: true,
                operationName: $"{nameof(PageBlobClient)}.{nameof(GetManagedDiskPageRangesDiff)}",
                cancellationToken)
                .ConfigureAwait(false);

        #endregion GetManagedDiskPageRangesDiff

        #region Resize
        /// <summary>
        /// The <see cref="Resize"/> operation resizes the page blob to
        /// the specified size (which must be a multiple of 512).  If the
        /// specified value is less than the current size of the blob, then
        /// all pages above the specified value are cleared.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.  If the specified
        /// value is less than the current size of the blob, then all pages
        /// above the specified value are cleared.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the resize of this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the resized
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PageBlobInfo> Resize(
            long size,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ResizeInternal(
                size,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ResizeAsync"/> operation resizes the page blob to
        /// the specified size (which must be a multiple of 512).  If the
        /// specified value is less than the current size of the blob, then
        /// all pages above the specified value are cleared.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.  If the specified
        /// value is less than the current size of the blob, then all pages
        /// above the specified value are cleared.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the resize of this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the resized
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PageBlobInfo>> ResizeAsync(
            long size,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await ResizeInternal(
                size,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ResizeAsync"/> operation resizes the page blob to
        /// the specified size (which must be a multiple of 512).  If the
        /// specified value is less than the current size of the blob, then
        /// all pages above the specified value are cleared.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="size">
        /// Specifies the maximum size for the page blob, up to 8 TB.  The
        /// size must be aligned to a 512-byte boundary.  If the specified
        /// value is less than the current size of the blob, then all pages
        /// above the specified value are cleared.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the resize of this page blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the resized
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PageBlobInfo>> ResizeInternal(
            long size,
            PageBlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(size)}: {size}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(Resize)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.Resize),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageBlobResizeHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.ResizeAsync(
                            blobContentLength: size,
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
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
                        response = PageBlobRestClient.Resize(
                            blobContentLength: size,
                            leaseId: conditions?.LeaseId,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPageBlobInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Resize

        #region UpdateSequenceNumber
        /// <summary>
        /// The <see cref="UpdateSequenceNumber"/> operation changes the
        /// sequence number <paramref name="action"/> and <paramref name="sequenceNumber"/>
        /// for this page blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="action">
        /// Specifies how the service should modify the blob's sequence number.
        /// <see cref="SequenceNumberAction.Max"/> sets the sequence number to
        /// be the higher of the value included with the request and the value
        /// currently stored for the blob.  <see cref="SequenceNumberAction.Update"/>
        /// sets the sequence number to the <paramref name="sequenceNumber"/>
        /// value.  <see cref="SequenceNumberAction.Increment"/> increments
        /// the value of the sequence number by 1.  If specifying
        /// <see cref="SequenceNumberAction.Increment"/>, do not include the
        /// <paramref name="sequenceNumber"/> because that will throw a
        /// <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="sequenceNumber">
        /// An updated sequence number of your choosing, if
        /// <paramref name="action"/> is <see cref="SequenceNumberAction.Max"/>
        /// or <see cref="SequenceNumberAction.Update"/>.  The value should
        /// not be provided if <paramref name="action"/> is
        /// <see cref="SequenceNumberAction.Increment"/>.  The sequence number
        /// is a user-controlled property that you can use to track requests
        /// and manage concurrency issues via <see cref="PageBlobRequestConditions"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add conditions
        /// on updating the sequence number of this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the updated
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PageBlobInfo> UpdateSequenceNumber(
            SequenceNumberAction action,
            long? sequenceNumber = default,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            UpdateSequenceNumberInternal(
                action,
                sequenceNumber,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UpdateSequenceNumberAsync"/> operation changes the
        /// sequence number <paramref name="action"/> and <paramref name="sequenceNumber"/>
        /// for this page blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="action">
        /// Specifies how the service should modify the blob's sequence number.
        /// <see cref="SequenceNumberAction.Max"/> sets the sequence number to
        /// be the higher of the value included with the request and the value
        /// currently stored for the blob.  <see cref="SequenceNumberAction.Update"/>
        /// sets the sequence number to the <paramref name="sequenceNumber"/>
        /// value.  <see cref="SequenceNumberAction.Increment"/> increments
        /// the value of the sequence number by 1.  If specifying
        /// <see cref="SequenceNumberAction.Increment"/>, do not include the
        /// <paramref name="sequenceNumber"/> because that will throw a
        /// <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="sequenceNumber">
        /// An updated sequence number of your choosing, if
        /// <paramref name="action"/> is <see cref="SequenceNumberAction.Max"/>
        /// or <see cref="SequenceNumberAction.Update"/>.  The value should
        /// not be provided if <paramref name="action"/> is
        /// <see cref="SequenceNumberAction.Increment"/>.  The sequence number
        /// is a user-controlled property that you can use to track requests
        /// and manage concurrency issues via <see cref="PageBlobRequestConditions"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add conditions
        /// on updating the sequence number of this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the updated
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PageBlobInfo>> UpdateSequenceNumberAsync(
            SequenceNumberAction action,
            long? sequenceNumber = default,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await UpdateSequenceNumberInternal(
                action,
                sequenceNumber,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UpdateSequenceNumberInternal"/> operation changes the
        /// sequence number <paramref name="action"/> and <paramref name="sequenceNumber"/>
        /// for this page blob.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="action">
        /// Specifies how the service should modify the blob's sequence number.
        /// <see cref="SequenceNumberAction.Max"/> sets the sequence number to
        /// be the higher of the value included with the request and the value
        /// currently stored for the blob.  <see cref="SequenceNumberAction.Update"/>
        /// sets the sequence number to the <paramref name="sequenceNumber"/>
        /// value.  <see cref="SequenceNumberAction.Increment"/> increments
        /// the value of the sequence number by 1.  If specifying
        /// <see cref="SequenceNumberAction.Increment"/>, do not include the
        /// <paramref name="sequenceNumber"/> because that will throw a
        /// <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="sequenceNumber">
        /// An updated sequence number of your choosing, if
        /// <paramref name="action"/> is <see cref="SequenceNumberAction.Max"/>
        /// or <see cref="SequenceNumberAction.Update"/>.  The value should
        /// not be provided if <paramref name="action"/> is
        /// <see cref="SequenceNumberAction.Increment"/>.  The sequence number
        /// is a user-controlled property that you can use to track requests
        /// and manage concurrency issues via <see cref="PageBlobRequestConditions"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add conditions
        /// on updating the sequence number of this page blob.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageBlobInfo}"/> describing the updated
        /// page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PageBlobInfo>> UpdateSequenceNumberInternal(
            SequenceNumberAction action,
            long? sequenceNumber,
            PageBlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(action)}: {action}\n" +
                    $"{nameof(sequenceNumber)}: {sequenceNumber}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(UpdateSequenceNumber)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.UpdateSequenceNumber),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageBlobUpdateSequenceNumberHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.UpdateSequenceNumberAsync(
                            sequenceNumberAction: action,
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            blobSequenceNumber: sequenceNumber,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PageBlobRestClient.UpdateSequenceNumber(
                            sequenceNumberAction: action,
                            leaseId: conditions?.LeaseId,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            blobSequenceNumber: sequenceNumber,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPageBlobInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion UpdateSequenceNumber

        #region StartCopyIncremental
        /// <summary>
        /// The <see cref="StartCopyIncremental(Uri, string, PageBlobRequestConditions, CancellationToken)"/>
        /// operation starts copying a snapshot of the sourceUri page blob to
        /// this page blob.  The snapshot is copied such that only the
        /// differential changes between the previously copied snapshot are
        /// transferred to the destination.  The copied snapshots are complete
        /// copies of the original snapshot and can be read or copied from as
        /// usual.  You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="BlobBaseClient.GetProperties"/> to
        /// determine if the copy has completed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/incremental-copy-blob">
        /// Incremental Copy Blob</see> and
        /// <see href="https://docs.microsoft.com/azure/virtual-machines/windows/incremental-snapshots">
        /// Back up Azure unmanaged VM disks with incremental snapshots</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the to the source page blob as a <see cref="Uri"/> up to
        /// 2 KB in length.  The source blob must either be public or must be
        /// authenticated via a shared access signature.
        /// </param>
        /// <param name="snapshot">
        /// The name of a snapshot to start copying from
        /// sourceUri.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the incremental copy into this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="CopyFromUriOperation"/> referencing the incremental
        /// copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        ///
        /// The destination of an incremental copy must either not exist, or
        /// must have been created with a previous incremental copy from the
        /// same source blob.  Once created, the destination blob is
        /// permanently associated with the source and may only be used for
        /// incremental copies.
        ///
        /// The <see cref="BlobBaseClient.GetProperties"/>,
        /// <see cref="BlobContainerClient.GetBlobsAsync(GetBlobsOptions, CancellationToken)"/>, and
        /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync(GetBlobsByHierarchyOptions, CancellationToken)"/>
        /// operations indicate whether the blob is an incremental copy blob
        /// created in this way.  Incremental copy blobs may not be downloaded
        /// directly.  The only supported operations are
        /// <see cref="BlobBaseClient.GetProperties"/>,
        /// <see cref="StartCopyIncremental(Uri, string, PageBlobRequestConditions, CancellationToken)"/>,
        /// and <see cref="BlobBaseClient.Delete"/>.  The copied snapshots may
        /// be read and deleted as usual.
        ///
        /// An incremental copy is performed asynchronously on the service and
        /// must be polled for completion.  You can poll
        /// <see cref="BlobBaseClient.GetProperties"/> and check
        /// <see cref="BlobProperties.CopyStatus"/> to determine when the copy
        /// has completed.  When the copy completes, the destination blob will
        /// contain a new snapshot.  The <see cref="BlobBaseClient.GetProperties"/>
        /// operation returns the snapshot time of the newly created snapshot.
        ///
        /// The first time an incremental copy is performed on a destination
        /// blob, a new blob is created with a snapshot that is fully copied
        /// from the source.  Each subsequent call to <see cref="StartCopyIncremental(Uri, string, PageBlobRequestConditions, CancellationToken)"/>
        /// will create a new snapshot by copying only the differential
        /// changes from the previously copied snapshot.  The differential
        /// changes are computed on the server by issuing a <see cref="GetAllPageRanges(GetPageRangesOptions, CancellationToken)"/>
        /// call on the source blob snapshot with prevSnapshot set to the most
        /// recently copied snapshot. Therefore, the same restrictions on
        /// <see cref="GetAllPageRanges(GetPageRangesOptions, CancellationToken)"/> apply to
        /// <see cref="StartCopyIncremental(Uri, string, PageBlobRequestConditions, CancellationToken)"/>.
        /// Specifically, snapshots must be copied in ascending order and if
        /// the source blob is recreated using <see cref="UploadPages(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> or
        /// <see cref="BlobBaseClient.StartCopyFromUri(Uri, Metadata, AccessTier?, BlobRequestConditions, BlobRequestConditions, RehydratePriority?, CancellationToken)"/>
        /// then  <see cref="StartCopyIncremental(Uri, string, PageBlobRequestConditions, CancellationToken)"/>
        /// on new snapshots will fail.
        ///
        /// The additional storage space consumed by the copied snapshot is
        /// the size of the differential data transferred during the copy.
        /// This can be determined by performing a
        /// <see cref="GetAllPageRangesDiff(GetPageRangesDiffOptions, CancellationToken)"/>
        /// call on the snapshot to compare it to the previous snapshot.
        /// </remarks>
        public virtual CopyFromUriOperation StartCopyIncremental(
            Uri sourceUri,
            string snapshot,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = StartCopyIncrementalInternal(
                sourceUri,
                snapshot,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();
            return new CopyFromUriOperation(
                this,
                response.Value.CopyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyIncrementalAsync(Uri, string, PageBlobRequestConditions, CancellationToken)"/>
        /// operation starts copying a snapshot of the sourceUri page blob to
        /// this page blob.  The snapshot is copied such that only the
        /// differential changes between the previously copied snapshot are
        /// transferred to the destination. The copied snapshots are complete
        /// copies of the original snapshot and can be read or copied from as
        /// usual.  You can check the <see cref="BlobProperties.CopyStatus"/>
        /// returned from the <see cref="BlobBaseClient.GetPropertiesAsync"/>
        /// to determine if thecopy has completed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/incremental-copy-blob">
        /// Incremental Copy Blob</see> and
        /// <see href="https://docs.microsoft.com/azure/virtual-machines/windows/incremental-snapshots">
        /// Back up Azure unmanaged VM disks with incremental snapshots</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the to the source page blob as a <see cref="Uri"/> up to
        /// 2 KB in length.  The source blob must either be public or must be
        /// authenticated via a shared access signature.
        /// </param>
        /// <param name="snapshot">
        /// The name of a snapshot to start copying from
        /// sourceUri.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the incremental copy into this page blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="CopyFromUriOperation"/> describing the
        /// state of the incremental copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        ///
        /// The destination of an incremental copy must either not exist, or
        /// must have been created with a previous incremental copy from the
        /// same source blob.  Once created, the destination blob is
        /// permanently associated with the source and may only be used for
        /// incremental copies.
        ///
        /// The <see cref="BlobBaseClient.GetPropertiesAsync"/>,
        /// <see cref="BlobContainerClient.GetBlobsAsync(GetBlobsOptions, CancellationToken)"/>, and
        /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync(GetBlobsByHierarchyOptions, CancellationToken)"/>
        /// operations indicate whether the blob is an incremental copy blob
        /// created in this way.  Incremental copy blobs may not be downloaded
        /// directly.  The only supported operations are
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/>,
        /// <see cref="StartCopyIncrementalAsync(Uri, string, PageBlobRequestConditions, CancellationToken)"/>,
        /// and  <see cref="BlobBaseClient.DeleteAsync"/>.  The copied
        /// snapshots may be read and deleted as usual.
        ///
        /// An incremental copy is performed asynchronously on the service and
        /// must be polled for completion.  You can poll
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/> and check
        /// <see cref="BlobProperties.CopyStatus"/> to determine when the copy
        /// has completed.  When the copy completes, the destination blob will
        /// contain a new snapshot.  The <see cref="BlobBaseClient.GetPropertiesAsync"/>
        /// operation returns the snapshot time of the newly created snapshot.
        ///
        /// The first time an incremental copy is performed on a destination
        /// blob, a new blob is created with a snapshot that is fully copied
        /// from the source.  Each subsequent call to <see cref="StartCopyIncrementalAsync(Uri, string, PageBlobRequestConditions, CancellationToken)"/>
        /// will create a new snapshot by copying only the differential
        /// changes from the previously copied snapshot.  The differential
        /// changes are computed on the server by issuing a <see cref="GetAllPageRangesAsync(GetPageRangesOptions, CancellationToken)"/>
        /// call on the source blob snapshot with prevSnapshot set to the most
        /// recently copied snapshot. Therefore, the same restrictions on
        /// <see cref="GetAllPageRangesAsync(GetPageRangesOptions, CancellationToken)"/> apply to
        /// <see cref="StartCopyIncrementalAsync(Uri, string, PageBlobRequestConditions, CancellationToken)"/>.
        /// Specifically, snapshots must be copied in ascending order and if
        /// the source blob is recreated using <see cref="UploadPagesAsync(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/> or
        /// <see cref="BlobBaseClient.StartCopyFromUriAsync(Uri, Metadata, AccessTier?, BlobRequestConditions, BlobRequestConditions, RehydratePriority?, CancellationToken)"/>
        /// then <see cref="StartCopyIncrementalAsync(Uri, string, PageBlobRequestConditions, CancellationToken)"/>
        /// on new snapshots will fail.
        ///
        /// The additional storage space consumed by the copied snapshot is
        /// the size of the differential data transferred during the copy.
        /// This can be determined by performing a
        /// <see cref="GetAllPageRangesDiffAsync(GetPageRangesDiffOptions, CancellationToken)"/>
        /// call on the snapshot to compare it to the previous snapshot.
        /// </remarks>
        public virtual async Task<CopyFromUriOperation> StartCopyIncrementalAsync(
            Uri sourceUri,
            string snapshot,
            PageBlobRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<BlobCopyInfo> response = await StartCopyIncrementalInternal(
                sourceUri,
                snapshot,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);
            return new CopyFromUriOperation(
                this,
                response.Value.CopyId,
                response.GetRawResponse(),
                cancellationToken);
        }

        /// <summary>
        /// The <see cref="StartCopyIncrementalInternal"/> operation starts
        /// copying a snapshot of the
        /// sourceUri page blob to this page blob.  The
        /// snapshot is copied such that only the differential changes between
        /// the previously copied snapshot are transferred to the destination.
        /// The copied snapshots are complete copies of the original snapshot
        /// and can be read or copied from as usual.  You can check the
        /// <see cref="BlobProperties.CopyStatus"/> returned from the
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/> to determine if the
        /// copy has completed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/incremental-copy-blob">
        /// Incremental Copy Blob</see> and
        /// <see href="https://docs.microsoft.com/azure/virtual-machines/windows/incremental-snapshots">
        /// Back up Azure unmanaged VM disks with incremental snapshots</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the to the source page blob as a <see cref="Uri"/> up to
        /// 2 KB in length.  The source blob must either be public or must be
        /// authenticated via a shared access signature.
        /// </param>
        /// <param name="snapshot">
        /// The name of a snapshot to start copying from
        /// sourceUri.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the incremental copy into this page blob.
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
        /// state of the incremental copy operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        ///
        /// The destination of an incremental copy must either not exist, or
        /// must have been created with a previous incremental copy from the
        /// same source blob.  Once created, the destination blob is
        /// permanently associated with the source and may only be used for
        /// incremental copies.
        ///
        /// The <see cref="BlobBaseClient.GetPropertiesAsync"/>,
        /// <see cref="BlobContainerClient.GetBlobsAsync(GetBlobsOptions, CancellationToken)"/>, and
        /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync(GetBlobsByHierarchyOptions, CancellationToken)"/>
        /// operations indicate whether the blob is an incremental copy blob
        /// created in this way.  Incremental copy blobs may not be downloaded
        /// directly.  The only supported operations are
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/>,
        /// <see cref="StartCopyIncremental(Uri, string, PageBlobRequestConditions, CancellationToken)"/>,
        /// and  <see cref="BlobBaseClient.DeleteAsync"/>.  The copied
        /// snapshots may be read and deleted as usual.
        ///
        /// An incremental copy is performed asynchronously on the service and
        /// must be polled for completion.  You can poll
        /// <see cref="BlobBaseClient.GetPropertiesAsync"/> and check
        /// <see cref="BlobProperties.CopyStatus"/> to determine when the copy
        /// has completed.  When the copy completes, the destination blob will
        /// contain a new snapshot.  The <see cref="BlobBaseClient.GetPropertiesAsync"/>
        /// operation returns the snapshot time of the newly created snapshot.
        ///
        /// The first time an incremental copy is performed on a destination
        /// blob, a new blob is created with a snapshot that is fully copied
        /// from the source.  Each subsequent call to <see cref="StartCopyIncrementalAsync(Uri, string, PageBlobRequestConditions, CancellationToken)"/>
        /// will create a new snapshot by copying only the differential
        /// changes from the previously copied snapshot.  The differential
        /// changes are computed on the server by issuing a <see cref="GetAllPageRangesAsync(GetPageRangesOptions, CancellationToken)"/>
        /// call on the source blob snapshot with prevSnapshot set to the most
        /// recently copied snapshot. Therefore, the same restrictions on
        /// <see cref="GetAllPageRangesAsync(GetPageRangesOptions, CancellationToken)"/> apply to
        /// <see cref="StartCopyIncrementalAsync(Uri, string, PageBlobRequestConditions, CancellationToken)"/>.
        /// Specifically, snapshots must be copied in ascending order and if
        /// the source blob is recreated using <see cref="UploadPagesAsync(Stream, long, byte[], PageBlobRequestConditions, IProgress{long}, CancellationToken)"/>
        /// or  <see cref="BlobBaseClient.StartCopyFromUriAsync(Uri, Metadata, AccessTier?, BlobRequestConditions, BlobRequestConditions, RehydratePriority?, CancellationToken)"/>
        /// then <see cref="StartCopyIncrementalAsync(Uri, string, PageBlobRequestConditions, CancellationToken)"/>
        /// on new snapshots will fail.
        ///
        /// The additional storage space consumed by the copied snapshot is
        /// the size of the differential data transferred during the copy.
        /// This can be determined by performing a
        /// <see cref="GetPageRangesDiffInternal"/>
        /// call on the snapshot to compare it to the previous snapshot.
        /// </remarks>
        private async Task<Response<BlobCopyInfo>> StartCopyIncrementalInternal(
            Uri sourceUri,
            string snapshot,
            PageBlobRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}\n" +
                    $"{nameof(snapshot)}: {snapshot}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(StartCopyIncremental)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.LeaseId
                        | BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.StartCopyIncremental),
                    parameterName: nameof(conditions));

                try
                {
                    scope.Start();

                    // Create copySource Uri
                    PageBlobClient sourcePageBlobClient = new PageBlobClient(
                        sourceUri,
                        ClientConfiguration).WithSnapshot(snapshot);

                    ResponseWithHeaders<PageBlobCopyIncrementalHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.CopyIncrementalAsync(
                            copySource: sourcePageBlobClient.Uri.AbsoluteUri,
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
                        response = PageBlobRestClient.CopyIncremental(
                            copySource: sourcePageBlobClient.Uri.AbsoluteUri,
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifTags: conditions?.TagConditions,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToBlobCopyInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion StartCopyIncremental

        #region UploadPagesFromUri
        /// <summary>
        /// The <see cref="UploadPagesFromUri(Uri, HttpRange, HttpRange, PageBlobUploadPagesFromUriOptions, CancellationToken)"/>
        /// operation writes a range of pages to a page blob where the contents are read from
        /// sourceUri.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-page-from-url">
        /// Put Page From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.
        /// </param>
        /// <param name="range">
        /// Specifies the range to be written as a page. Both the start and
        /// end of the range must be specified and can be up to 4MB in size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="options">
        /// Optional parameters.  <see cref="PageBlobUploadPagesFromUriOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PageInfo> UploadPagesFromUri(
            Uri sourceUri,
            HttpRange sourceRange,
            HttpRange range,
            PageBlobUploadPagesFromUriOptions options = default,
            CancellationToken cancellationToken = default) =>
            UploadPagesFromUriInternal(
                sourceUri,
                sourceRange,
                range,
                options?.SourceContentHash,
                options?.DestinationConditions,
                options?.SourceConditions,
                options?.SourceAuthentication,
                options?.SourceShareTokenIntent,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadPagesFromUriAsync(Uri, HttpRange, HttpRange, PageBlobUploadPagesFromUriOptions, CancellationToken)"/>
        /// operation writes a range of pages to a page blob where the contents are read from
        /// sourceUri.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-page-from-url">
        /// Put Page From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.
        /// </param>
        /// <param name="range">
        /// Specifies the range to be written as a page. Both the start and
        /// end of the range must be specified and can be up to 4MB in size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="options">
        /// Optional parameters.  <see cref="PageBlobUploadPagesFromUriOptions"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PageInfo>> UploadPagesFromUriAsync(
            Uri sourceUri,
            HttpRange sourceRange,
            HttpRange range,
            PageBlobUploadPagesFromUriOptions options = default,
            CancellationToken cancellationToken = default) =>
            await UploadPagesFromUriInternal(
                sourceUri,
                sourceRange,
                range,
                options?.SourceContentHash,
                options?.DestinationConditions,
                options?.SourceConditions,
                options?.SourceAuthentication,
                options?.SourceShareTokenIntent,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadPagesFromUri(Uri, HttpRange, HttpRange, byte[], PageBlobRequestConditions, PageBlobRequestConditions, CancellationToken)"/>
        /// operation writes a range of pages to a page blob where the contents are read from
        /// sourceUri.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-page-from-url">
        /// Put Page From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.
        /// </param>
        /// <param name="range">
        /// Specifies the range to be written as a page. Both the start and
        /// end of the range must be specified and can be up to 4MB in size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the page block content from the
        /// sourceUri.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the sourceUri
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the copying of data to this page blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PageInfo> UploadPagesFromUri(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange sourceRange,
            HttpRange range,
            byte[] sourceContentHash,
            PageBlobRequestConditions conditions,
            PageBlobRequestConditions sourceConditions,
            CancellationToken cancellationToken) =>
            UploadPagesFromUriInternal(
                sourceUri,
                sourceRange,
                range,
                sourceContentHash,
                conditions,
                sourceConditions,
                sourceAuthentication: default,
                sourceTokenIntent: default,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="UploadPagesFromUriAsync(Uri, HttpRange, HttpRange, byte[], PageBlobRequestConditions, PageBlobRequestConditions, CancellationToken)"/>
        /// operation writes a range of pages to a page blob where the contents are read from
        /// sourceUri.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-page-from-url">
        /// Put Page From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.
        /// </param>
        /// <param name="range">
        /// Specifies the range to be written as a page. Both the start and
        /// end of the range must be specified and can be up to 4MB in size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the page block content from the
        /// sourceUri.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the sourceUri
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the copying of data to this page blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<PageInfo>> UploadPagesFromUriAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Uri sourceUri,
            HttpRange sourceRange,
            HttpRange range,
            byte[] sourceContentHash,
            PageBlobRequestConditions conditions,
            PageBlobRequestConditions sourceConditions,
            CancellationToken cancellationToken) =>
            await UploadPagesFromUriInternal(
                sourceUri,
                sourceRange,
                range,
                sourceContentHash,
                conditions,
                sourceConditions,
                sourceAuthentication: default,
                sourceTokenIntent: default,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadPagesFromUriInternal"/> operation writes a
        /// range of pages to a page blob where the contents are read from
        /// sourceUri.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-page-from-url">
        /// Put Page From URL</see>.
        /// </summary>
        /// <param name="sourceUri">
        /// Specifies the <see cref="Uri"/> of the source blob.  The value may
        /// be a <see cref="Uri" /> of up to 2 KB in length that specifies a
        /// blob.  The source blob must either be public or must be
        /// authenticated via a shared access signature.  If the source blob
        /// is public, no authentication is required to perform the operation.
        /// </param>
        /// <param name="sourceRange">
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.
        /// </param>
        /// <param name="range">
        /// Specifies the range to be written as a page. Both the start and
        /// end of the range must be specified and can be up to 4MB in size.
        /// Given that pages must be aligned with 512-byte boundaries, the
        /// start of the range must be a modulus of 512 and the end of the
        /// range must be a modulus of 512 – 1.  Examples of valid byte ranges
        /// are 0-511, 512-1023, etc.
        /// </param>
        /// <param name="sourceContentHash">
        /// Optional MD5 hash of the page block content from the
        /// sourceUri.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the sourceUri
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the copying of data to this page blob.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </param>
        /// <param name="sourceAuthentication">
        /// Optional. Source authentication used to access the source blob.
        /// </param>
        /// <param name="sourceTokenIntent">
        /// Optional, only applicable (but required) when the source is Azure Storage Files and using token authentication.
        /// Used to indicate the intent of the request.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PageInfo}"/> describing the
        /// state of the updated pages.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PageInfo>> UploadPagesFromUriInternal(
            Uri sourceUri,
            HttpRange sourceRange,
            HttpRange range,
            byte[] sourceContentHash,
            PageBlobRequestConditions conditions,
            PageBlobRequestConditions sourceConditions,
            HttpAuthorization sourceAuthentication,
            FileShareTokenIntent? sourceTokenIntent,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(PageBlobClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(PageBlobClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(sourceUri)}: {sourceUri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(UploadPagesFromUri)}");

                conditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.UploadPagesFromUri),
                    parameterName: nameof(conditions));

                sourceConditions.ValidateConditionsNotPresent(
                    invalidConditions:
                        BlobRequestConditionProperty.LeaseId
                        | BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                        | BlobRequestConditionProperty.IfSequenceNumberLessThan
                        | BlobRequestConditionProperty.IfSequenceNumberEqual
                        | BlobRequestConditionProperty.TagConditions
                        | BlobRequestConditionProperty.AccessTierIfModifiedSince
                        | BlobRequestConditionProperty.AccessTierIfUnmodifiedSince,
                    operationName: nameof(PageBlobClient.UploadPagesFromUri),
                    parameterName: nameof(sourceConditions));

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PageBlobUploadPagesFromURLHeaders> response;

                    if (async)
                    {
                        response = await PageBlobRestClient.UploadPagesFromURLAsync(
                            sourceUrl: sourceUri.AbsoluteUri,
                            sourceRange: sourceRange.ToString(),
                            contentLength: 0,
                            range: range.ToString(),
                            sourceContentMD5: sourceContentHash,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            leaseId: conditions?.LeaseId,
                            ifSequenceNumberLessThanOrEqualTo: conditions?.IfSequenceNumberLessThanOrEqual,
                            ifSequenceNumberLessThan: conditions?.IfSequenceNumberLessThan,
                            ifSequenceNumberEqualTo: conditions?.IfSequenceNumberEqual,
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
                            fileRequestIntent: sourceTokenIntent,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PageBlobRestClient.UploadPagesFromURL(
                            sourceUrl: sourceUri.AbsoluteUri,
                            sourceRange: sourceRange.ToString(),
                            contentLength: 0,
                            range: range.ToString(),
                            sourceContentMD5: sourceContentHash,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            encryptionScope: ClientConfiguration.EncryptionScope,
                            leaseId: conditions?.LeaseId,
                            ifSequenceNumberLessThanOrEqualTo: conditions?.IfSequenceNumberLessThanOrEqual,
                            ifSequenceNumberLessThan: conditions?.IfSequenceNumberLessThan,
                            ifSequenceNumberEqualTo: conditions?.IfSequenceNumberEqual,
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
                            fileRequestIntent: sourceTokenIntent,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPageInfo(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(PageBlobClient));
                    scope.Dispose();
                }
            }
        }
        #endregion UploadPagesFromUri

        #region OpenWrite
        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="overwrite">
        /// Whether an existing blob should be deleted and recreated.
        /// </param>
        /// <param name="position">
        /// The offset within the blob to begin writing from.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the Page Blob.
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
            long position,
            PageBlobOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => OpenWriteInternal(
                overwrite: overwrite,
                position: position,
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
        /// <param name="position">
        /// The offset within the blob to begin writing from.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A stream to write to the Page Blob.
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
            long position,
            PageBlobOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => await OpenWriteInternal(
                overwrite: overwrite,
                position: position,
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
        /// <param name="position">
        /// The offset within the page blob to begin writing from.
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
        /// A stream to write to the Page Blob.
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
            long position,
            PageBlobOpenWriteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(PageBlobClient)}.{nameof(OpenWrite)}");

            try
            {
                scope.Start();

                ETag? etag;

                if (overwrite)
                {
                    if (options?.Size == null)
                    {
                        throw new ArgumentException($"{nameof(options)}.{nameof(options.Size)} must be set if {nameof(overwrite)} is set to true");
                    }

                    Response<BlobContentInfo> createResponse = await CreateInternal(
                        size: options.Size.Value,
                        sequenceNumber: default,
                        httpHeaders: default,
                        metadata: default,
                        tags: default,
                        conditions: options?.OpenConditions,
                        immutabilityPolicy: default,
                        legalHold: default,
                        premiumPageBlobAccessTier: default,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

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

                        etag = propertiesResponse.Value.ETag;
                    }
                    catch (RequestFailedException ex)
                    when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
                    {
                        if (options?.Size == null)
                        {
                            throw new ArgumentException($"{nameof(options)}.{nameof(options.Size)} must be set if the Page Blob is being created for the first time");
                        }

                        Response<BlobContentInfo> createResponse = await CreateInternal(
                            size: options.Size.Value,
                            sequenceNumber: default,
                            httpHeaders: default,
                            metadata: default,
                            tags: default,
                            conditions: options?.OpenConditions,
                            immutabilityPolicy: default,
                            legalHold: default,
                            premiumPageBlobAccessTier: default,
                            async: async,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

                        etag = createResponse.Value.ETag;
                    }
                }

                PageBlobRequestConditions conditions = new PageBlobRequestConditions()
                {
                    IfMatch = etag,
                    LeaseId = options?.OpenConditions?.LeaseId,
                };

                return new PageBlobWriteStream(
                    pageBlobClient: this,
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
    /// creating <see cref="PageBlobClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="PageBlobClient"/> object by
        /// concatenating <paramref name="blobName"/> to
        /// the end of the <paramref name="client"/>'s
        /// <see cref="BlobContainerClient.Uri"/>. The new
        /// <see cref="PageBlobClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="BlobContainerClient"/>.</param>
        /// <param name="blobName">The name of the page blob.</param>
        /// <returns>A new <see cref="PageBlobClient"/> instance.</returns>
        public static PageBlobClient GetPageBlobClient(
            this BlobContainerClient client,
            string blobName)
        {
            return client.GetPageBlobClientCore(blobName);
        }
    }
}
