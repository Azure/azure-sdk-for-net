﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeFileClient"/> allows you to manipulate Azure Data Lake append blob-based files.
    /// </summary>
    public class DataLakeAppendFileClient : DataLakeFileClient
    {
        //TODO possible need to check that DataLakeFileClientOptions.ServiceVersion >= 2020-02-10.
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
            : this(fileUri, (HttpPipelinePolicy)null, null, null)
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
            : this(fileUri, (HttpPipelinePolicy)null, options, null)
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
        public DataLakeAppendFileClient(Uri fileUri, AzureSasCredential credential, DataLakeClientOptions options)
            : this(fileUri, credential.AsPolicy<DataLakeUriBuilder>(fileUri), options, null)
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
        public DataLakeAppendFileClient(Uri fileUri, TokenCredential credential)
            : this(fileUri, credential.AsPolicy(new DataLakeClientOptions()), null, null)
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
        public DataLakeAppendFileClient(Uri fileUri, TokenCredential credential, DataLakeClientOptions options)
            : this(fileUri, credential.AsPolicy(options), options, null)
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
            : base(fileUri, authentication, options, storageSharedKeyCredential)
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

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExists"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory.
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
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
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return base.CreateInternal(
                    resourceType: PathResourceType.File,
                    blobType: BlobType.Appendblob,
                    httpHeaders: httpHeaders,
                    metadata: metadata,
                    permissions: permissions,
                    umask: umask,
                    conditions: conditions,
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
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory.
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
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
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return await base.CreateInternal(
                    resourceType: PathResourceType.File,
                    blobType: BlobType.Appendblob,
                    httpHeaders: httpHeaders,
                    metadata: metadata,
                    permissions: permissions,
                    umask: umask,
                    conditions: conditions,
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
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory..
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
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
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return base.CreateIfNotExistsInternal(
                    PathResourceType.File,
                    BlobType.Appendblob,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    async: false,
                    cancellationToken)
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
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory..
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file or directory..
        /// </param>
        /// <param name="permissions">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </param>
        /// <param name="umask">
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
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
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return await base.CreateIfNotExistsInternal(
                    PathResourceType.File,
                    BlobType.Appendblob,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    async: true,
                    cancellationToken)
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
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(Append)}");

            try
            {
                scope.Start();

                return AppendInternal(
                    content,
                    createIfNotExists,
                    contentHash,
                    progressHandler,
                    async: false,
                    cancellationToken)
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
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeAppendFileClient)}.{nameof(Append)}");

            try
            {
                scope.Start();

                return await AppendInternal(
                    content,
                    createIfNotExists,
                    contentHash,
                    progressHandler,
                    async: true,
                    cancellationToken)
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
