// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeFileClient"/> allows you to manipulate Azure Data Lake files.
    /// </summary>
    public class DataLakeFileClient : DataLakePathClient
    {
        /// <summary>
        /// The name of the file.
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the name of the file.
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
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/>
        /// class for mocking.
        /// </summary>
        protected DataLakeFileClient()
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
        public DataLakeFileClient(Uri fileUri)
            : this(fileUri, (HttpPipelinePolicy)null, null)
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
        public DataLakeFileClient(Uri fileUri, DataLakeClientOptions options)
            : this(fileUri, (HttpPipelinePolicy)null, options)
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
        public DataLakeFileClient(Uri fileUri, StorageSharedKeyCredential credential)
            : this(fileUri, credential.AsPolicy(), null)
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
        public DataLakeFileClient(Uri fileUri, StorageSharedKeyCredential credential, DataLakeClientOptions options)
            : this(fileUri, credential.AsPolicy(), options)
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
        public DataLakeFileClient(Uri fileUri, TokenCredential credential)
            : this(fileUri, credential.AsPolicy(), null)
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
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DataLakeFileClient(Uri fileUri, TokenCredential credential, DataLakeClientOptions options)
            : this(fileUri, credential.AsPolicy(), options)
        {
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
        internal DataLakeFileClient(Uri fileUri, HttpPipelinePolicy authentication, DataLakeClientOptions options)
            : base(fileUri, authentication, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/> class.
        /// </summary>
        /// <param name="fileUri">
        /// A <see cref="Uri"/> referencing the file that includes the
        /// name of the account, the name of the file system, and the path of the file.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal DataLakeFileClient(Uri fileUri, HttpPipeline pipeline) : base(fileUri, pipeline)
        {
        }
        #endregion ctors

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        internal override void SetNameFieldsIfNull()
        {
            base.SetNameFieldsIfNull();
            if (_name == null)
            {
                var builder = new DataLakeUriBuilder(Uri);
                _name = builder.LastDirectoryOrFileName;
            }
        }

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a file or directory.
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
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory..
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathInfo> Create(
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            Create(
                PathResourceType.File,
                httpHeaders,
                metadata,
                permissions,
                umask,
                conditions,
                cancellationToken);

        /// <summary>
        /// The <see cref="Create"/> operation creates a file or directory.
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
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory..
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> CreateAsync(
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await CreateAsync(
                PathResourceType.File,
                httpHeaders,
                metadata,
                permissions,
                umask,
                conditions,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion Create

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response Delete(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => base.Delete(
                recursive: null,
                conditions,
                cancellationToken);

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
            => await base.DeleteAsync(
                recursive: null,
                conditions,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion Delete

        #region Move
        /// <summary>
        /// The <see cref="Rename"/> operation renames a Directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the path to.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the source on the creation of this file or directory.
        /// </param>
        /// <param name="destinationConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public new virtual Response<DataLakeFileClient> Rename(
            string destinationPath,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<DataLakePathClient> response = base.Rename(
                destinationPath,
                sourceConditions,
                destinationConditions,
                cancellationToken);

            return Response.FromValue(
                new DataLakeFileClient(response.Value.DfsUri, response.Value.Pipeline),
                response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="RenameAsync"/> operation renames a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the path to.
        /// </param>
        /// <param name="destinationConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </param>
        /// <param name="sourceConditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the source on the creation of this file or directory.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public new virtual async Task<Response<DataLakeFileClient>> RenameAsync(
            string destinationPath,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<DataLakePathClient> response = await base.RenameAsync(
                destinationPath,
                sourceConditions,
                destinationConditions,
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(
                new DataLakeFileClient(response.Value.DfsUri, response.Value.Pipeline),
                response.GetRawResponse());
        }
        #endregion Move

        #region Append Data
        /// <summary>
        /// The <see cref="Append"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="offset">
        /// This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.
        /// It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.
        /// The value must be the position where the data is to be appended. Uploaded data is not immediately flushed, or written, to the file.
        /// To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length
        /// of the file after all data has been written, and there must not be a request entity body included with the request.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </param>
        /// <param name="leaseId">
        /// Optional lease id.
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
        [ForwardsClientCalls]
        public virtual Response Append(
            Stream content,
            long offset,
            byte[] contentHash = default,
            string leaseId = default,
            CancellationToken cancellationToken = default) =>
            AppendInternal(
                content,
                offset,
                contentHash,
                leaseId,
                async: false,
                cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="AppendAsync"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="offset">
        /// This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.
        /// It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.
        /// The value must be the position where the data is to be appended. Uploaded data is not immediately flushed, or written, to the file.
        /// To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length
        /// of the file after all data has been written, and there must not be a request entity body included with the request.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </param>
        /// <param name="leaseId">
        /// Optional lease id.
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
        [ForwardsClientCalls]
        public virtual async Task<Response> AppendAsync(
            Stream content,
            long offset,
            byte[] contentHash = default,
            string leaseId = default,
            CancellationToken cancellationToken = default) =>
            await AppendInternal(
                content,
                offset,
                contentHash,
                leaseId,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="AppendInternal"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="offset">
        /// This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.
        /// It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.
        /// The value must be the position where the data is to be appended. Uploaded data is not immediately flushed, or written, to the file.
        /// To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length
        /// of the file after all data has been written, and there must not be a request entity body included with the request.
        /// </param>
        /// <param name="contentHash">
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </param>
        /// <param name="leaseId">
        /// Optional lease id.
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
        private async Task<Response> AppendInternal(
            Stream content,
            long? offset,
            byte[] contentHash,
            string leaseId,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakeFileClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakeFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(offset)}: {offset}\n" +
                    $"{nameof(leaseId)}: {leaseId}\n");
                try
                {
                    Response<PathAppendDataResult> response = await DataLakeRestClient.Path.AppendDataAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: DfsUri,
                        body: content,
                        position: offset,
                        contentLength: content.Length,
                        transactionalContentHash: contentHash,
                        leaseId: leaseId,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return response.GetRawResponse();
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakeFileClient));
                }
            }
        }
        #endregion Append Data

        #region Flush Data
        /// <summary>
        /// The <see cref="Flush"/> operation flushes (writes) previously
        /// appended data to a file.
        /// </summary>
        /// <param name="position">
        /// This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.
        /// It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.
        /// The value must be the position where the data is to be appended. Uploaded data is not immediately flushed, or written,
        /// to the file. To flush, the previously uploaded data must be contiguous, the position parameter must be specified and
        /// equal to the length of the file after all data has been written, and there must not be a request entity body included
        /// with the request.
        /// </param>
        /// <param name="retainUncommittedData">
        /// If "true", uncommitted data is retained after the flush operation completes; otherwise, the uncommitted data is deleted
        /// after the flush operation. The default is false. Data at offsets less than the specified position are written to the
        /// file when flush succeeds, but this optional parameter allows data after the flush position to be retained for a future
        /// flush operation.
        /// </param>
        /// <param name="close">
        /// Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled,
        /// a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the
        /// difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter
        /// is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the
        /// flush operation completes successfully, the service raises a file change notification with a property indicating that
        /// this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the
        /// file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that
        /// the file stream has been closed."
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        ///</param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the flush of this file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathInfo> Flush(
            long position,
            bool? retainUncommittedData = default,
            bool? close = default,
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            FlushInternal(
                position,
                retainUncommittedData,
                close,
                httpHeaders,
                conditions,
                async: false,
                cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="FlushAsync"/> operation flushes (writes) previously
        /// appended data to a file.
        /// </summary>
        /// <param name="position">
        /// This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.
        /// It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.
        /// The value must be the position where the data is to be appended. Uploaded data is not immediately flushed, or written,
        /// to the file. To flush, the previously uploaded data must be contiguous, the position parameter must be specified and
        /// equal to the length of the file after all data has been written, and there must not be a request entity body included
        /// with the request.
        /// </param>
        /// <param name="retainUncommittedData">
        /// If "true", uncommitted data is retained after the flush operation completes; otherwise, the uncommitted data is deleted
        /// after the flush operation. The default is false. Data at offsets less than the specified position are written to the
        /// file when flush succeeds, but this optional parameter allows data after the flush position to be retained for a future
        /// flush operation.
        /// </param>
        /// <param name="close">
        /// Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled,
        /// a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the
        /// difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter
        /// is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the
        /// flush operation completes successfully, the service raises a file change notification with a property indicating that
        /// this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the
        /// file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that
        /// the file stream has been closed."
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        ///</param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the flush of this file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> FlushAsync(
            long position,
            bool? retainUncommittedData = default,
            bool? close = default,
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await FlushInternal(
                position,
                retainUncommittedData,
                close,
                httpHeaders,
                conditions,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="FlushInternal"/> operation flushes (writes) previously
        /// appended data to a file.
        /// </summary>
        /// <param name="position">
        /// This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.
        /// It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.
        /// The value must be the position where the data is to be appended. Uploaded data is not immediately flushed, or written,
        /// to the file. To flush, the previously uploaded data must be contiguous, the position parameter must be specified and
        /// equal to the length of the file after all data has been written, and there must not be a request entity body included
        /// with the request.
        /// </param>
        /// <param name="retainUncommittedData">
        /// If "true", uncommitted data is retained after the flush operation completes; otherwise, the uncommitted data is deleted
        /// after the flush operation. The default is false. Data at offsets less than the specified position are written to the
        /// file when flush succeeds, but this optional parameter allows data after the flush position to be retained for a future
        /// flush operation.
        /// </param>
        /// <param name="close">
        /// Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled,
        /// a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the
        /// difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter
        /// is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the
        /// flush operation completes successfully, the service raises a file change notification with a property indicating that
        /// this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the
        /// file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that
        /// the file stream has been closed."
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        ///</param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the flush of this file.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathInfo>> FlushInternal(
            long position,
            bool? retainUncommittedData,
            bool? close,
            PathHttpHeaders httpHeaders,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakeFileClient)))
            {
                Pipeline.LogMethodEnter(
                nameof(DataLakeFileClient),
                message:
                $"{nameof(Uri)}: {Uri}");

                try
                {
                    Response<PathFlushDataResult> response = await DataLakeRestClient.Path.FlushDataAsync(
                        clientDiagnostics: ClientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: DfsUri,
                        position: position,
                        retainUncommittedData: retainUncommittedData,
                        close: close,
                        contentLength: 0,
                        contentHash: httpHeaders?.ContentHash,
                        leaseId: conditions?.LeaseId,
                        cacheControl: httpHeaders?.CacheControl,
                        contentType: httpHeaders?.ContentType,
                        contentDisposition: httpHeaders?.ContentDisposition,
                        contentEncoding: httpHeaders?.ContentEncoding,
                        contentLanguage: httpHeaders?.ContentLanguage,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        new PathInfo()
                        {
                            ETag = response.Value.ETag,
                            LastModified = response.Value.LastModified
                        },
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakeFileClient));
                }
            }
        }
        #endregion

        #region Read Data
        /// <summary>
        /// The <see cref="Read()"/> operation downloads a file from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="FileDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        [ForwardsClientCalls]
        public virtual Response<FileDownloadInfo> Read()
        {
            Response<Blobs.Models.BlobDownloadInfo> response = _blockBlobClient.Download();

            return Response.FromValue(
                response.Value.ToFileDownloadInfo(),
                response.GetRawResponse());
        }
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="ReadAsync()"/> operation downloads a file from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="FileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
#pragma warning disable AZC0002 // Client method should have cancellationToken as the last optional parameter
        [ForwardsClientCalls]
        public virtual async Task<Response<FileDownloadInfo>> ReadAsync()
        {
            Response<Blobs.Models.BlobDownloadInfo> response
                = await _blockBlobClient.DownloadAsync(CancellationToken.None).ConfigureAwait(false);

            return Response.FromValue(
                response.Value.ToFileDownloadInfo(),
                response.GetRawResponse());
        }
#pragma warning restore AZC0002 // Client method should have cancellationToken as the last optional parameter

        /// <summary>
        /// The <see cref="Read(CancellationToken)"/> operation downloads a file from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="FileDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<FileDownloadInfo> Read(
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobDownloadInfo> response = _blockBlobClient.Download(cancellationToken);

            return Response.FromValue(
                response.Value.ToFileDownloadInfo(),
                response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="ReadAsync(CancellationToken)"/> operation downloads a file from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded blob.  <see cref="FileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<FileDownloadInfo>> ReadAsync(
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobDownloadInfo> response
                = await _blockBlobClient.DownloadAsync(cancellationToken).ConfigureAwait(false);

            return Response.FromValue(
                response.Value.ToFileDownloadInfo(),
                response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="Read(HttpRange, DataLakeRequestConditions?, Boolean, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="range">
        /// If provided, only donwload the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// donwloading this file.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="FileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<FileDownloadInfo> Read(
            HttpRange range = default,
            DataLakeRequestConditions conditions = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobDownloadInfo> response = _blockBlobClient.Download(
                range: range,
                conditions: conditions.ToBlobRequestConditions(),
                rangeGetContentHash: rangeGetContentHash,
                cancellationToken: cancellationToken);

            return Response.FromValue(
                response.Value.ToFileDownloadInfo(),
                response.GetRawResponse());
        }
        /// <summary>
        /// The <see cref="ReadAsync(HttpRange, DataLakeRequestConditions?, Boolean, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob" />.
        /// </summary>
        /// <param name="range">
        /// If provided, only donwload the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// donwloading this file.
        /// </param>
        /// <param name="rangeGetContentHash">
        /// When set to true and specified together with the <paramref name="range"/>,
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <paramref name="range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
        /// is thrown.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="FileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<FileDownloadInfo>> ReadAsync(
            HttpRange range = default,
            DataLakeRequestConditions conditions = default,
            bool rangeGetContentHash = default,
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobDownloadInfo> response = await _blockBlobClient.DownloadAsync(
                range: range,
                conditions: conditions.ToBlobRequestConditions(),
                rangeGetContentHash: rangeGetContentHash,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(
                response.Value.ToFileDownloadInfo(),
                response.GetRawResponse());
        }
        #endregion Read Data
    }
}
