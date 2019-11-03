// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Files.DataLake.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// A PathClient represents a URI to the Azure DataLake service allowing you to manipulate a file or directory.
    /// </summary>
    public class DataLakePathClient
    {
        /// <summary>
        /// A <see cref="BlockBlobClient"/> associated with the path;
        /// </summary>
        internal readonly BlockBlobClient _blockBlobClient;

        /// <summary>
        /// BlobClient
        /// </summary>
        internal virtual BlockBlobClient BlobClient => _blockBlobClient;

        /// <summary>
        /// The paths's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// The paths's blob <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _blobUri;

        /// <summary>
        /// The path's dfs <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _dfsUri;

        /// <summary>
        /// DFS Uri
        /// </summary>
        internal Uri DfsUri => _dfsUri;

        /// <summary>
        /// Gets the directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Gets the <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        internal virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => _clientDiagnostics;

        /// <summary>
        /// The Storage account name corresponding to the directory client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the directory client.
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
        /// The file system name corresponding to the directory client.
        /// </summary>
        private string _fileSystemName;

        /// <summary>
        /// Gets the file system name name corresponding to the directory client.
        /// </summary>
        public virtual string FileSystemName
        {
            get
            {
                SetNameFieldsIfNull();
                return _fileSystemName;
            }
        }

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class for mocking.
        /// </summary>
        protected DataLakePathClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        public DataLakePathClient(Uri pathUri)
            : this(pathUri, (HttpPipelinePolicy)null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DataLakePathClient(Uri pathUri, DataLakeClientOptions options)
            : this(pathUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        public DataLakePathClient(Uri pathUri, StorageSharedKeyCredential credential)
            : this(pathUri, credential.AsPolicy(), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakePathClient(Uri pathUri, StorageSharedKeyCredential credential, DataLakeClientOptions options)
            : this(pathUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        public DataLakePathClient(Uri pathUri, TokenCredential credential)
            : this(pathUri, credential.AsPolicy(), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the resource that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakePathClient(Uri pathUri, TokenCredential credential, DataLakeClientOptions options)
            : this(pathUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the path that includes the
        /// name of the account, the name of the file system, and the path to
        /// the resource.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal DataLakePathClient(Uri pathUri, HttpPipelinePolicy authentication, DataLakeClientOptions options)
        {
            options ??= new DataLakeClientOptions();
            _uri = pathUri;
            _blobUri = GetBlobUri(pathUri);
            _dfsUri = GetDfsUri(pathUri);
            _pipeline = options.Build(authentication);
            _clientDiagnostics = new ClientDiagnostics(options);
            _blockBlobClient = new BlockBlobClient(_blobUri, _pipeline, _clientDiagnostics, null);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakePathClient"/>
        /// class.
        /// </summary>
        /// <param name="pathUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path to the
        /// resource.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// </param>
        internal DataLakePathClient(Uri pathUri, HttpPipeline pipeline, DataLakeClientOptions options = default)
        {
            _uri = pathUri;
            _blobUri = GetBlobUri(pathUri);
            _dfsUri = GetDfsUri(pathUri);
            _pipeline = pipeline;
            _clientDiagnostics = new ClientDiagnostics(options ?? new DataLakeClientOptions());
            _blockBlobClient = new BlockBlobClient(_blobUri, pipeline, _clientDiagnostics, null);
        }
        #endregion

        /// <summary>
        /// Gets the blob Uri.
        /// </summary>
        private static Uri GetBlobUri(Uri uri)
        {
            Uri blobUri;
            if (uri.Host.Contains(Constants.DataLake.DfsUriSuffix))
            {
                UriBuilder uriBuilder = new UriBuilder(uri);
                uriBuilder.Host = uriBuilder.Host.Replace(
                    Constants.DataLake.DfsUriSuffix,
                    Constants.DataLake.BlobUriSuffix);
                blobUri = uriBuilder.Uri;
            }
            else
            {
                blobUri = uri;
            }
            return blobUri;
        }

        /// <summary>
        /// Gets the dfs Uri.
        /// </summary>
        private static Uri GetDfsUri(Uri uri)
        {
            Uri dfsUri;
            if (uri.Host.Contains(Constants.DataLake.BlobUriSuffix))
            {
                UriBuilder uriBuilder = new UriBuilder(uri);
                uriBuilder.Host = uriBuilder.Host.Replace(
                    Constants.DataLake.BlobUriSuffix,
                    Constants.DataLake.DfsUriSuffix);
                dfsUri = uriBuilder.Uri;
            }
            else
            {
                dfsUri = uri;
            }
            return dfsUri;
        }

        /// <summary>
        /// Converts metadata in DFS metadata string
        /// </summary>
        internal static string BuildMetadataString(Metadata metadata)
        {
            if (metadata == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in metadata)
            {
                sb.Append(kv.Key);
                sb.Append("=");
                byte[] valueBytes = Encoding.UTF8.GetBytes(kv.Value);
                sb.Append(Convert.ToBase64String(valueBytes));
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// Sets the various name fields if they are currently null.
        /// </summary>
        internal virtual void SetNameFieldsIfNull()
        {
            if (_fileSystemName == null || _accountName == null)
            {
                var builder = new DataLakeUriBuilder(Uri);
                _fileSystemName = builder.FileSystemName;
                _accountName = builder.AccountName;
            }
        }

        #region Create
        /// <summary>
        /// The <see cref="Create"/> operation creates a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
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
        protected virtual Response<PathInfo> Create(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            CreateInternal(
                resourceType,
                httpHeaders,
                metadata,
                permissions,
                umask,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Create"/> operation creates a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory.
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
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders = default,
            Metadata metadata = default,
            string permissions = default,
            string umask = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await CreateInternal(
                resourceType,
                httpHeaders,
                metadata,
                permissions,
                umask,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Create"/> operation creates a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="resourceType">
        /// Resource type of this path - file or directory.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory.
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
        /// conditions on the creation of this file or directory..
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
        /// newly created page blob.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathInfo>> CreateInternal(
            PathResourceType resourceType,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(httpHeaders)}: {httpHeaders}\n" +
                    $"{nameof(metadata)}: {metadata}\n" +
                    $"{nameof(permissions)}: {permissions}\n" +
                    $"{nameof(umask)}: {umask}\n");
                try
                {

                    Response<PathCreateResult> createResponse = await DataLakeRestClient.Path.CreateAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: _dfsUri,
                        resource: resourceType,
                        cacheControl: httpHeaders?.CacheControl,
                        contentEncoding: httpHeaders?.ContentEncoding,
                        contentDisposition: httpHeaders?.ContentDisposition,
                        contentType: httpHeaders?.ContentType,
                        contentLanguage: httpHeaders?.ContentLanguage,
                        leaseId: conditions?.LeaseId,
                        properties: BuildMetadataString(metadata),
                        permissions: permissions,
                        umask: umask,
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
                            ETag = createResponse.Value.ETag,
                            LastModified = createResponse.Value.LastModified
                        },
                        createResponse.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Create

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
        /// </param>
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
        public virtual Response Delete(
            bool? recursive = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            DeleteInternal(
                recursive,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
        /// </param>
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
        public virtual async Task<Response> DeleteAsync(
            bool? recursive = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await DeleteInternal(
                recursive,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DeleteInternal"/> operation marks the specified path
        /// deletion. The path is later deleted during
        /// garbage collection.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete" />.
        /// </summary>
        /// <param name="recursive">
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
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
        private async Task<Response> DeleteInternal(
            bool? recursive,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobBaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(recursive)}: {recursive}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<PathDeleteResult> response = await DataLakeRestClient.Path.DeleteAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: _dfsUri,
                        recursive: recursive,
                        leaseId: conditions?.LeaseId,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
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
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Delete

        #region Rename
        /// <summary>
        /// The <see cref="Rename"/> operation renames a file or directory.
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
        public virtual Response<DataLakePathClient> Rename(
            string destinationPath,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default) =>
            RenameInternal(
                destinationPath,
                sourceConditions,
                destinationConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="RenameAsync"/> operation renames a file or directory.
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
        public virtual async Task<Response<DataLakePathClient>> RenameAsync(
            string destinationPath,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default) =>
            await RenameInternal(
                destinationPath,
                sourceConditions,
                destinationConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="RenameInternal"/> operation renames a file or directory.
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
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
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
        private async Task<Response<DataLakePathClient>> RenameInternal(
            string destinationPath,
            DataLakeRequestConditions sourceConditions,
            DataLakeRequestConditions destinationConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(destinationPath)}: {destinationPath}\n" +
                    $"{nameof(destinationConditions)}: {destinationConditions}\n" +
                    $"{nameof(sourceConditions)}: {sourceConditions}");
                try
                {
                    DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsUri);
                    string renameSource = "/" + uriBuilder.FileSystemName + "/" + uriBuilder.DirectoryOrFilePath;

                    uriBuilder.DirectoryOrFilePath = destinationPath;
                    DataLakePathClient destPathClient = new DataLakePathClient(uriBuilder.ToUri(), Pipeline);

                    Response<PathCreateResult> response = await DataLakeRestClient.Path.CreateAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: destPathClient.DfsUri,
                        mode: PathRenameMode.Legacy,
                        renameSource: renameSource,
                        leaseId: destinationConditions?.LeaseId,
                        sourceLeaseId: sourceConditions?.LeaseId,
                        ifMatch: destinationConditions?.IfMatch,
                        ifNoneMatch: destinationConditions?.IfNoneMatch,
                        ifModifiedSince: destinationConditions?.IfModifiedSince,
                        ifUnmodifiedSince: destinationConditions?.IfUnmodifiedSince,
                        sourceIfMatch: sourceConditions?.IfMatch,
                        sourceIfNoneMatch: sourceConditions?.IfNoneMatch,
                        sourceIfModifiedSince: sourceConditions?.IfModifiedSince,
                        sourceIfUnmodifiedSince: sourceConditions?.IfUnmodifiedSince,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        destPathClient,
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Rename

        #region Get Access Control
        /// <summary>
        /// The <see cref="GetAccessControlInternal"/> operation returns the
        /// access control data for a path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/getproperties" />.
        /// </summary>
        /// <param name="upn">
        /// Optional.Valid only when Hierarchical Namespace is enabled for the account.If "true",
        /// the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response
        /// headers will be transformed from Azure Active Directory Object IDs to User Principal Names.
        /// If "false", the values will be returned as Azure Active Directory Object IDs.The default
        /// value is false. Note that group and application Object IDs are not translated because they
        /// do not have unique friendly names.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathAccessControl}"/> describing the
        /// path's access control.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathAccessControl> GetAccessControl(
            bool? upn = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            GetAccessControlInternal(
                upn,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GetAccessControlInternal"/> operation returns the
        /// access control data for a path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/getproperties" />.
        /// </summary>
        /// <param name="upn">
        /// Optional.Valid only when Hierarchical Namespace is enabled for the account.If "true",
        /// the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response
        /// headers will be transformed from Azure Active Directory Object IDs to User Principal Names.
        /// If "false", the values will be returned as Azure Active Directory Object IDs.The default
        /// value is false. Note that group and application Object IDs are not translated because they
        /// do not have unique friendly names.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathAccessControl}"/> describing the
        /// path's access control.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<PathAccessControl>> GetAccessControlAsync(
            bool? upn = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await GetAccessControlInternal(
                upn,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="GetAccessControlInternal"/> operation returns the
        /// access control data for a path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/getproperties" />.
        /// </summary>
        /// <param name="upn">
        /// Optional.Valid only when Hierarchical Namespace is enabled for the account.If "true",
        /// the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response
        /// headers will be transformed from Azure Active Directory Object IDs to User Principal Names.
        /// If "false", the values will be returned as Azure Active Directory Object IDs.The default
        /// value is false. Note that group and application Object IDs are not translated because they
        /// do not have unique friendly names.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's access control.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathAccessControl}"/> describing the
        /// path's access control.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathAccessControl>> GetAccessControlInternal(
            bool? upn,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n");
                try
                {
                    Response<PathGetPropertiesResult> response = await DataLakeRestClient.Path.GetPropertiesAsync(
                        clientDiagnostics: _clientDiagnostics,
                        pipeline: Pipeline,
                        resourceUri: _dfsUri,
                        action: PathGetPropertiesAction.GetAccessControl,
                        upn: upn,
                        leaseId: conditions?.LeaseId,
                        ifMatch: conditions?.IfMatch,
                        ifNoneMatch: conditions?.IfNoneMatch,
                        ifModifiedSince: conditions?.IfModifiedSince,
                        ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    return Response.FromValue(
                        new PathAccessControl()
                        {
                            Owner = response.Value.Owner,
                            Group = response.Value.Group,
                            Permissions = response.Value.Permissions,
                            Acl = response.Value.ACL
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
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Get Access Control

        #region Set Access Control
        /// <summary>
        /// The <see cref="SetAccessControl"/> operation sets the
        /// Access Control on a path
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="acl">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathInfo> SetAccessControl(
            string acl,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetAccessControlInternal(
                acl,
                owner,
                group,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetAccessControlAsync"/> operation sets the
        /// Access Control on a path
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="acl">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> SetAccessControlAsync(
            string acl,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetAccessControlInternal(
                acl,
                owner,
                group,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetAccessControlInternal"/> operation sets the
        /// Access Control on a path
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="acl">
        /// The POSIX access control list for the file or directory.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathInfo>> SetAccessControlInternal(
            string acl,
            string owner,
            string group,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(acl)}: {acl}\n" +
                    $"{nameof(owner)}: {owner}\n" +
                    $"{nameof(group)}: {group}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<PathSetAccessControlResult> response =
                        await DataLakeRestClient.Path.SetAccessControlAsync(
                            clientDiagnostics: _clientDiagnostics,
                            pipeline: Pipeline,
                            resourceUri: _dfsUri,
                            leaseId: conditions?.LeaseId,
                            owner: owner,
                            group: group,
                            acl: acl,
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
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Set Access Control

        #region Set Permissions
        /// <summary>
        /// The <see cref="SetPermissions"/> operation sets the
        /// file permissions on a path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="permissions">
        ///  The POSIX access permissions for the file owner, the file owning group, and others.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathInfo> SetPermissions(
            string permissions,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            SetPermissionsInternal(
                permissions,
                owner,
                group,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="SetPermissionsAsync"/> operation sets the
        /// file permissions on a path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="permissions">
        ///  The POSIX access permissions for the file owner, the file owning group, and others.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> SetPermissionsAsync(
            string permissions,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await SetPermissionsInternal(
                permissions,
                owner,
                group,
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="SetPermissionsInternal"/> operation sets the
        /// file permissions on a path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="permissions">
        ///  The POSIX access permissions for the file owner, the file owning group, and others.
        /// </param>
        /// <param name="owner">
        /// The owner of the file or directory.
        /// </param>
        /// <param name="group">
        /// The owning group of the file or directory.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the the path's access control.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<PathInfo>> SetPermissionsInternal(
            string permissions,
            string owner,
            string group,
            DataLakeRequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(DataLakePathClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(DataLakePathClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(permissions)}: {permissions}\n" +
                    $"{nameof(owner)}: {owner}\n" +
                    $"{nameof(group)}: {group}\n" +
                    $"{nameof(conditions)}: {conditions}");
                try
                {
                    Response<PathSetAccessControlResult> response =
                        await DataLakeRestClient.Path.SetAccessControlAsync(
                            clientDiagnostics: _clientDiagnostics,
                            pipeline: Pipeline,
                            resourceUri: _dfsUri,
                            leaseId: conditions?.LeaseId,
                            owner: owner,
                            group: group,
                            permissions: permissions,
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
                    Pipeline.LogMethodExit(nameof(DataLakePathClient));
                }
            }
        }
        #endregion Set Permission

        #region Get Properties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the path. It does not return the content of the
        /// path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties" />.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathProperties}"/> describing the
        /// path's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathProperties> GetProperties(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobProperties> response = _blockBlobClient.GetProperties(
                conditions.ToBlobRequestConditions(),
                cancellationToken);

            return Response.FromValue(
                response.Value.ToPathProperties(),
                response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the path. It does not return the content of the
        /// path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties" />.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathProperties}"/> describing the
        /// paths's properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<PathProperties>> GetPropertiesAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobProperties> response = await _blockBlobClient.GetPropertiesAsync(
                conditions.ToBlobRequestConditions(),
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(
                response.Value.ToPathProperties(),
                response.GetRawResponse());
        }
        #endregion Get Properties

        #region Set Http Headers
        /// <summary>
        /// The <see cref="SetHttpHeaders"/> operation sets system
        /// properties on the path.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the paths's HTTP headers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{httpHeaders}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathInfo> SetHttpHeaders(
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobInfo> response = _blockBlobClient.SetHttpHeaders(
                httpHeaders.ToBlobHttpHeaders(),
                conditions.ToBlobRequestConditions(),
                cancellationToken);

            return Response.FromValue(
                new PathInfo()
                {
                    ETag = response.Value.ETag,
                    LastModified = response.Value.LastModified
                },
                response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="SetHttpHeadersAsync"/> operation sets system
        /// properties on the PATH.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties" />.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's HTTP headers.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> SetHttpHeadersAsync(
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobInfo> response = await _blockBlobClient.SetHttpHeadersAsync(
                httpHeaders.ToBlobHttpHeaders(),
                conditions.ToBlobRequestConditions(),
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(
                new PathInfo()
                {
                    ETag = response.Value.ETag,
                    LastModified = response.Value.LastModified
                },
                response.GetRawResponse());
        }
        #endregion Set Http Headers

        #region Set Metadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets user-defined
        /// metadata for the specified path as one or more name-value pairs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata" />.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this path.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's metadata.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathInfo> SetMetadata(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobInfo> response = _blockBlobClient.SetMetadata(
                metadata,
                conditions.ToBlobRequestConditions());

            return Response.FromValue(
                new PathInfo()
                {
                    ETag = response.Value.ETag,
                    LastModified = response.Value.LastModified
                },
                response.GetRawResponse());
        }

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined
        /// metadata for the specified path as one or more name-value pairs.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata" />.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this path.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's metadata.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the updated
        /// path.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> SetMetadataAsync(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            Response<Blobs.Models.BlobInfo> response = await _blockBlobClient.SetMetadataAsync(
                metadata,
                conditions.ToBlobRequestConditions())
                .ConfigureAwait(false);

            return Response.FromValue(
                new PathInfo()
                {
                    ETag = response.Value.ETag,
                    LastModified = response.Value.LastModified
                },
                response.GetRawResponse());
        }
        #endregion Set Metadata
    }
}
