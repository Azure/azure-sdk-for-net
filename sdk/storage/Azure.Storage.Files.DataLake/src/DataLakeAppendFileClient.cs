// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeFileClient"/> allows you to manipulate Azure Data Lake append blob-based files.
    /// </summary>
    public class DataLakeAppendFileClient : DataLakeFileClient
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/>
        /// class for mocking.
        /// </summary>
        protected DataLakeAppendFileClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// </param>
        public DataLakeAppendFileClient(Uri fileUri)
            : this(fileUri, (HttpPipelinePolicy)null, null, storageSharedKeyCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DataLakeAppendFileClient(Uri fileUri, DataLakeClientOptions options)
            : this(fileUri, (HttpPipelinePolicy)null, options, storageSharedKeyCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>.
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
        /// <param name="fileSystemName">
        /// The name of the file system containing this path.
        /// </param>
        /// <param name="filePath">
        /// The path to the file.
        /// </param>
        public DataLakeAppendFileClient(
            string connectionString,
            string fileSystemName,
            string filePath)
            : this(connectionString, fileSystemName, filePath, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>.
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
        /// <param name="fileSystemName">
        /// The name of the file system containing this path.
        /// </param>
        /// <param name="filePath">
        /// The path to the file.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeAppendFileClient(
            string connectionString,
            string fileSystemName,
            string filePath,
            DataLakeClientOptions options)
            : base(connectionString, fileSystemName, filePath, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        public DataLakeAppendFileClient(Uri fileUri, StorageSharedKeyCredential credential)
            : this(fileUri, credential.AsPolicy(), null, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DataLakeAppendFileClient(Uri fileUri, StorageSharedKeyCredential credential, DataLakeClientOptions options)
            : this(fileUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public DataLakeAppendFileClient(Uri fileUri, AzureSasCredential credential)
            : this(fileUri, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public DataLakeAppendFileClient
            (Uri fileUri,
            AzureSasCredential credential,
            DataLakeClientOptions options)
            : this(fileUri, credential.AsPolicy<DataLakeUriBuilder>(fileUri), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        public DataLakeAppendFileClient(
            Uri fileUri,
            TokenCredential credential)
            : this(fileUri, credential, new DataLakeClientOptions())
        {
            Errors.VerifyHttpsTokenAuth(fileUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DataLakeAppendFileClient(
            Uri fileUri,
            TokenCredential credential,
            DataLakeClientOptions options)
            : this(fileUri,
                credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? DataLakeAudience.DefaultAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                options,
                credential)
        {
            Errors.VerifyHttpsTokenAuth(fileUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/>
        /// class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
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
        internal DataLakeAppendFileClient(
            Uri fileUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
            : base(
                  fileUri,
                  authentication,
                  options,
                  storageSharedKeyCredential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeAppendFileClient"/>
        /// class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <param name="sasCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        internal DataLakeAppendFileClient(
            Uri fileUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            AzureSasCredential sasCredential)
            : base(fileUri,
                  authentication,
                  options,
                  sasCredential: sasCredential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeAppendFileClient"/>
        /// class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the
        /// file.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <param name="tokenCredential">
        /// Token credential.
        /// </param>
        internal DataLakeAppendFileClient(
            Uri fileUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            TokenCredential tokenCredential)
            : base(fileUri,
                  authentication,
                  options,
                  tokenCredential: tokenCredential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the file.
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="DataLakeClientConfiguration"/>.
        /// </param>
        internal DataLakeAppendFileClient(
            Uri fileUri,
            DataLakeClientConfiguration clientConfiguration)
            : base(fileUri, clientConfiguration)
        {
        }

        internal DataLakeAppendFileClient(
            Uri fileSystemUri,
            string filePath,
            DataLakeClientConfiguration clientConfiguration)
            : base(
                  fileSystemUri,
                  filePath,
                  clientConfiguration)
        {
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/>.
        ///
        /// </summary>
        /// <param name="customerProvidedKey">The customer provided key.</param>
        /// <returns>A new <see cref="DataLakeAppendFileClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the customer provide key in the returned <see cref="DataLakeFileClient"/>.
        /// </remarks>
        public new DataLakeAppendFileClient WithCustomerProvidedKey(Models.DataLakeCustomerProvidedKey? customerProvidedKey)
        {
            DataLakeClientConfiguration newClientConfiguration = DataLakeClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.CustomerProvidedKey = customerProvidedKey;
            return new DataLakeAppendFileClient(
                fileUri: Uri,
                clientConfiguration: newClientConfiguration);
        }

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public new virtual Response<PathInfo> Create(
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return base.CreateInternal(
                    resourceType: PathResourceType.File,
                    blobType: BlobType.Appendblob,
                    httpHeaders: options?.HttpHeaders,
                    metadata: options?.Metadata,
                    accessOptions:
                        (Permissions: options?.AccessOptions?.Permissions,
                        Umask: options?.AccessOptions?.Umask,
                        Owner: options?.AccessOptions?.Owner,
                        Group: options?.AccessOptions?.Group,
                        AccessControlList: options?.AccessOptions?.AccessControlList),
                    leaseId: options?.LeaseId,
                    leaseDuration: options?.LeaseDuration,
                    timeToExpire: options?.ScheduleDeletionOptions?.TimeToExpire,
                    expiresOn: options?.ScheduleDeletionOptions?.ExpiresOn,
                    encryptionContext: options?.EncryptionContext,
                    conditions: options?.Conditions,
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
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
        /// The <see cref="Create"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public new virtual async Task<Response<PathInfo>> CreateAsync(
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return await base.CreateInternal(
                    resourceType: PathResourceType.File,
                    blobType: BlobType.Appendblob,
                    httpHeaders: options?.HttpHeaders,
                    metadata: options?.Metadata,
                    accessOptions:
                        (Permissions: options?.AccessOptions?.Permissions,
                        Umask: options?.AccessOptions?.Umask,
                        Owner: options?.AccessOptions?.Owner,
                        Group: options?.AccessOptions?.Group,
                        AccessControlList: options?.AccessOptions?.AccessControlList),
                    leaseId: options?.LeaseId,
                    leaseDuration: options?.LeaseDuration,
                    timeToExpire: options?.ScheduleDeletionOptions?.TimeToExpire,
                    expiresOn: options?.ScheduleDeletionOptions?.ExpiresOn,
                    encryptionContext: options?.EncryptionContext,
                    conditions: options?.Conditions,
                    async: true,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
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
        #endregion Create

        #region Create If Not Exists
        /// <summary>
        /// The <see cref="CreateIfNotExists"/> operation creates a file.
        /// If the file already exists, it is not changed.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public new virtual Response<PathInfo> CreateIfNotExists(
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return base.CreateIfNotExistsInternal(
                    PathResourceType.File,
                    BlobType.Appendblob,
                    httpHeaders: options?.HttpHeaders,
                    metadata: options?.Metadata,
                    accessOptions:
                        (Permissions: options?.AccessOptions?.Permissions,
                        Umask: options?.AccessOptions?.Umask,
                        Owner: options?.AccessOptions?.Owner,
                        Group: options?.AccessOptions?.Group,
                        AccessControlList: options?.AccessOptions?.AccessControlList),
                    leaseId: options?.LeaseId,
                    leaseDuration: options?.LeaseDuration,
                    timeToExpire: options?.ScheduleDeletionOptions?.TimeToExpire,
                    expiresOn: options?.ScheduleDeletionOptions?.ExpiresOn,
                    encryptionContext: options?.EncryptionContext,
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
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
        /// The <see cref="CreateIfNotExists"/> operation creates a file.
        /// If the file already exists, it is not changed.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public new virtual async Task<Response<PathInfo>> CreateIfNotExistsAsync(
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return await base.CreateIfNotExistsInternal(
                    PathResourceType.File,
                    BlobType.Appendblob,
                    httpHeaders: options?.HttpHeaders,
                    metadata: options?.Metadata,
                    accessOptions:
                        (Permissions: options?.AccessOptions?.Permissions,
                        Umask: options?.AccessOptions?.Umask,
                        Owner: options?.AccessOptions?.Owner,
                        Group: options?.AccessOptions?.Group,
                        AccessControlList: options?.AccessOptions?.AccessControlList),
                    leaseId: options?.LeaseId,
                    leaseDuration: options?.LeaseDuration,
                    timeToExpire: options?.ScheduleDeletionOptions?.TimeToExpire,
                    expiresOn: options?.ScheduleDeletionOptions?.ExpiresOn,
                    encryptionContext: options?.EncryptionContext,
                    async: true,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
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
        #endregion Create If Not Exists

        #region Append
        /// <summary>
        /// The <see cref="Append"/> operation uploads data to be appended to a file.
        /// Data can only be appended to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="createIfNotExists">
        /// Specifies if the file should be created if it doesn't already exist.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
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
        /// A <see cref="Response"/> describing the state
        /// of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ConcurrentAppendResult> Append(
            Stream content,
            bool createIfNotExists = default,
            byte[] contentHash = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default)
            => AppendInternal(
                    content,
                    createIfNotExists,
                    contentHash,
                    progressHandler,
                    async: false,
                    cancellationToken)
                    .EnsureCompleted();

        /// <summary>
        /// The <see cref="AppendAsync"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="createIfNotExists">
        /// Specifies if the file should be created if it doesn't already exist.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
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
        /// A <see cref="Response"/> describing the state
        /// of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ConcurrentAppendResult>> AppendAsync(
            Stream content,
            bool createIfNotExists = default,
            byte[] contentHash = default,
            IProgress<long> progressHandler = default,
            CancellationToken cancellationToken = default)
            => await AppendInternal(
                    content,
                    createIfNotExists,
                    contentHash,
                    progressHandler,
                    async: true,
                    cancellationToken)
                    .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AppendInternal"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="createIfNotExists">
        /// Specifies if the file should be created if it doesn't already exist.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the state
        /// of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        internal virtual async Task<Response<ConcurrentAppendResult>> AppendInternal(
            Stream content,
            bool createIfNotExists,
            byte[] contentHash,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakeFileClient)))
            {
                content = content?.WithNoDispose().WithProgress(progressHandler);
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakeFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(Append)}");
                try
                {
                    scope.Start();
                    Errors.VerifyStreamPosition(content, nameof(content));
                    ResponseWithHeaders<PathConcurrentAppendHeaders> response;

                    if (async)
                    {
                        response = await PathRestClient.ConcurrentAppendAsync(
                            body: content,
                            appendMode: createIfNotExists ? AppendMode.AutoCreate : null,
                            timeout: null,
                            contentLength: content?.Length - content?.Position ?? 0,
                            transactionalContentHash: contentHash,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PathRestClient.ConcurrentAppend(
                            body: content,
                            appendMode: createIfNotExists ? AppendMode.AutoCreate : null,
                            timeout: null,
                            contentLength: content?.Length - content?.Position ?? 0,
                            transactionalContentHash: contentHash,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToConcurrentAppendResult(),
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
                    ClientConfiguration.Pipeline.LogMethodExit(nameof(DataLakeFileClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Append
    }
}
