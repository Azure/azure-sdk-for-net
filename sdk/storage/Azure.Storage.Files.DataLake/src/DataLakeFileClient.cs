// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeFileClient"/> allows you to manipulate Azure Data Lake files.
    /// </summary>
    public class DataLakeFileClient : DataLakePathClient
    {
        /// <summary>
        /// Gets the maximum number of bytes that can be sent in each append call in
        /// to <see cref="UploadAsync(Stream, PathHttpHeaders, DataLakeRequestConditions, IProgress{long}, StorageTransferOptions, CancellationToken)"/>.
        /// Supported value is now larger than <see cref="int.MaxValue"/>; please use
        /// <see cref="MaxUploadLongBytes"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int MaxUploadBytes => ClientConfiguration.ClientOptions.Version < DataLakeClientOptions.ServiceVersion.V2019_12_12
            ? Constants.DataLake.Pre_2019_12_12_MaxAppendBytes
            : int.MaxValue;  // value is larger than can be represented by an int

        /// <summary>
        /// Gets the maximum number of bytes that can be sent in each append call in
        /// <see cref="UploadAsync(Stream, PathHttpHeaders, DataLakeRequestConditions, IProgress{long}, StorageTransferOptions, CancellationToken)"/>.
        /// </summary>
        public virtual long MaxUploadLongBytes => ClientConfiguration.ClientOptions.Version < DataLakeClientOptions.ServiceVersion.V2019_12_12
            ? Constants.DataLake.Pre_2019_12_12_MaxAppendBytes
            : Constants.DataLake.MaxAppendBytes;

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
            : this(fileUri, (HttpPipelinePolicy)null, null, storageSharedKeyCredential:null)
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
            : this(fileUri, (HttpPipelinePolicy)null, options, storageSharedKeyCredential:null)
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
        public DataLakeFileClient(
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
        public DataLakeFileClient(
            string connectionString,
            string fileSystemName,
            string filePath,
            DataLakeClientOptions options)
            : base(connectionString, fileSystemName, filePath, options)
        {
            Argument.AssertNotNullOrWhiteSpace(filePath, nameof(filePath));
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
            : base(fileUri, credential)
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
        public DataLakeFileClient(Uri fileUri, AzureSasCredential credential)
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
        public DataLakeFileClient(Uri fileUri, AzureSasCredential credential, DataLakeClientOptions options)
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
        public DataLakeFileClient(Uri fileUri, TokenCredential credential)
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
        public DataLakeFileClient(Uri fileUri, TokenCredential credential, DataLakeClientOptions options)
            : this(
                fileUri,
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
        internal DataLakeFileClient(
            Uri fileUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
            : base(
                  fileUri,
                  authentication,
                  options,
                  storageSharedKeyCredential: storageSharedKeyCredential,
                  sasCredential: null,
                  tokenCredential: null)
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
        /// <param name="sasCredential">
        /// The shared key credential used to sign requests.
        /// </param>
        internal DataLakeFileClient(
            Uri fileUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            AzureSasCredential sasCredential)
            : base(fileUri,
                  authentication,
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: sasCredential,
                  tokenCredential: null)
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
        /// <param name="tokenCredential">
        /// Token credential.
        /// </param>
        internal DataLakeFileClient(
            Uri fileUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            TokenCredential tokenCredential)
            : base(fileUri,
                  authentication,
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: null,
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
        internal DataLakeFileClient(
            Uri fileUri,
            DataLakeClientConfiguration clientConfiguration)
            : base(fileUri, clientConfiguration)
        {
        }

        internal DataLakeFileClient(
            Uri fileSystemUri,
            string filePath,
            DataLakeClientConfiguration clientConfiguration)
            : base(
                  fileSystemUri,
                  filePath,
                  clientConfiguration)
        {
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/>.
        ///
        /// </summary>
        /// <param name="customerProvidedKey">The customer provided key.</param>
        /// <returns>A new <see cref="DataLakeFileClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the customer provide key in the returned <see cref="DataLakeFileClient"/>.
        /// </remarks>
        public new DataLakeFileClient WithCustomerProvidedKey(Models.DataLakeCustomerProvidedKey? customerProvidedKey)
        {
            DataLakeClientConfiguration newClientConfiguration = DataLakeClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.CustomerProvidedKey = customerProvidedKey;
            return new DataLakeFileClient(
                fileUri: Uri,
                clientConfiguration: newClientConfiguration);
        }

        #region Create
        /// <summary>
        /// The <see cref="Create(DataLakePathCreateOptions, CancellationToken)"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExists(DataLakePathCreateOptions, CancellationToken)"/> API.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> Create(
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return base.Create(
                    resourceType: PathResourceType.File,
                    options: options,
                    cancellationToken: cancellationToken);
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
        /// The <see cref="CreateAsync(DataLakePathCreateOptions, CancellationToken)"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExistsAsync(DataLakePathCreateOptions, CancellationToken)"/> API.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> CreateAsync(
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return await base.CreateAsync(
                    resourceType: PathResourceType.File,
                    options: options,
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

        /// <summary>
        /// The <see cref="Create(PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExists(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> API.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PathInfo> Create(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return base.Create(
                    PathResourceType.File,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken);
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
        /// The <see cref="CreateAsync(PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/> operation creates a file.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="CreateIfNotExistsAsync(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> API.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<PathInfo>> CreateAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return await base.CreateAsync(
                    PathResourceType.File,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
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
        #endregion Create

        #region Create If Not Exists
        /// <summary>
        /// The <see cref="CreateIfNotExists(DataLakePathCreateOptions, CancellationToken)"/> operation creates a file.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> CreateIfNotExists(
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return base.CreateIfNotExists(
                    resourceType: PathResourceType.File,
                    options: options,
                    cancellationToken: cancellationToken);
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
        /// The <see cref="CreateIfNotExistsAsync(DataLakePathCreateOptions, CancellationToken)"/> operation creates a file.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> CreateIfNotExistsAsync(
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return await base.CreateIfNotExistsAsync(
                    resourceType: PathResourceType.File,
                    options: options,
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

        /// <summary>
        /// The <see cref="CreateIfNotExists(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> operation creates a file.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PathInfo> CreateIfNotExists(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return base.CreateIfNotExists(
                    PathResourceType.File,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    cancellationToken);
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
        /// The <see cref="CreateIfNotExistsAsync(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> operation creates a file.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<PathInfo>> CreateIfNotExistsAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(CreateIfNotExists)}");

            try
            {
                scope.Start();

                return await base.CreateIfNotExistsAsync(
                    PathResourceType.File,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
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

        #region Delete
        /// <summary>
        /// The <see cref="Delete"/> operation marks the specified path
        /// deletion.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response Delete(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Delete)}");

            try
            {
                scope.Start();

                return base.Delete(
                    recursive: null,
                    conditions,
                    cancellationToken);
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
        /// The <see cref="DeleteAsync"/> operation marks the specified path
        /// deletion.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response> DeleteAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Delete)}");

            try
            {
                scope.Start();

                return await base.DeleteAsync(
                    recursive: null,
                    conditions,
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
        #endregion Delete

        #region Delete If Exists
        /// <summary>
        /// The <see cref="DeleteIfExists"/> operation marks the specified file
        /// for deletion, if the file exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<bool> DeleteIfExists(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(DeleteIfExists)}");

            try
            {
                scope.Start();

                return base.DeleteIfExists(
                    recursive: null,
                    conditions,
                    cancellationToken);
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
        /// The <see cref="DeleteIfExistsAsync"/> operation marks the specified file
        /// for deletion, if the file exists.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
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
        /// A <see cref="Response"/> on successfully marking for deletion.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<bool>> DeleteIfExistsAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(DeleteIfExists)}");

            try
            {
                scope.Start();

                return await base.DeleteIfExistsAsync(
                    recursive: null,
                    conditions,
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
        #endregion Delete If Not Exists

        #region Rename
        /// <summary>
        /// The <see cref="Rename"/> operation renames a Directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the path to.
        /// </param>
        /// <param name="destinationFileSystem">
        /// Optional destination file system.  If null, path will be renamed within the
        /// current file system.
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
        /// A <see cref="Response{DataLakeFileClient}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public new virtual Response<DataLakeFileClient> Rename(
            string destinationPath,
            string destinationFileSystem = default,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Rename)}");

            try
            {
                scope.Start();

                Response<DataLakePathClient> response = base.Rename(
                    destinationPath: destinationPath,
                    destinationFileSystem: destinationFileSystem,
                    sourceConditions: sourceConditions,
                    destinationConditions: destinationConditions,
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    new DataLakeFileClient(response.Value.DfsUri, response.Value.ClientConfiguration),
                    response.GetRawResponse());
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
        /// The <see cref="RenameAsync"/> operation renames a file or directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="destinationPath">
        /// The destination path to rename the path to.
        /// </param>
        /// <param name="destinationFileSystem">
        /// Optional destination file system.  If null, path will be renamed within the
        /// current file system.
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
        /// A <see cref="Response{DataLakeFileClient}"/> describing the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public new virtual async Task<Response<DataLakeFileClient>> RenameAsync(
            string destinationPath,
            string destinationFileSystem = default,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Rename)}");

            try
            {
                scope.Start();

                Response<DataLakePathClient> response = await base.RenameAsync(
                    destinationPath: destinationPath,
                    destinationFileSystem: destinationFileSystem,
                    sourceConditions: sourceConditions,
                    destinationConditions: destinationConditions,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    new DataLakeFileClient(response.Value.DfsUri, response.Value.ClientConfiguration),
                    response.GetRawResponse());
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
        #endregion Rename

        #region Get Access Control
        /// <summary>
        /// The <see cref="GetAccessControl"/> operation returns the
        /// access control data for a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/getproperties">
        /// Get Properties</see>.
        /// </summary>
        /// <param name="userPrincipalName">
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public override Response<PathAccessControl> GetAccessControl(
            bool? userPrincipalName = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(GetAccessControl)}");

            try
            {
                scope.Start();

                return base.GetAccessControl(
                    userPrincipalName,
                    conditions,
                    cancellationToken);
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
        /// The <see cref="GetAccessControlAsync"/> operation returns the
        /// access control data for a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/getproperties">
        /// Get Properties</see>.
        /// </summary>
        /// <param name="userPrincipalName">
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public override async Task<Response<PathAccessControl>> GetAccessControlAsync(
            bool? userPrincipalName = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(GetAccessControl)}");

            try
            {
                scope.Start();

                return await base.GetAccessControlAsync(
                    userPrincipalName,
                    conditions,
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
        #endregion Get Access Control

        #region Set Access Control
        /// <summary>
        /// The <see cref="SetAccessControlList"/> operation sets the
        /// Access Control on a path
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Response<PathInfo> SetAccessControlList(
            IList<PathAccessControlItem> accessControlList,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(SetAccessControlList)}");

            try
            {
                scope.Start();

                return base.SetAccessControlList(
                    accessControlList,
                    owner,
                    group,
                    conditions,
                    cancellationToken);
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
        /// The <see cref="SetAccessControlListAsync"/> operation sets the
        /// Access Control on a path
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
        /// </summary>
        /// <param name="accessControlList">
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override async Task<Response<PathInfo>> SetAccessControlListAsync(
            IList<PathAccessControlItem> accessControlList,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(SetAccessControlList)}");

            try
            {
                scope.Start();

                return await base.SetAccessControlListAsync(
                    accessControlList,
                    owner,
                    group,
                    conditions,
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
        #endregion Set Access Control

        #region Set Permissions
        /// <summary>
        /// The <see cref="SetPermissions"/> operation sets the
        /// file permissions on a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Response<PathInfo> SetPermissions(
            PathPermissions permissions,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(SetPermissions)}");

            try
            {
                scope.Start();

                return base.SetPermissions(
                    permissions,
                    owner,
                    group,
                    conditions,
                    cancellationToken);
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
        /// The <see cref="SetPermissionsAsync"/> operation sets the
        /// file permissions on a path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override async Task<Response<PathInfo>> SetPermissionsAsync(
            PathPermissions permissions,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(SetPermissions)}");

            try
            {
                scope.Start();

                return await base.SetPermissionsAsync(
                    permissions,
                    owner,
                    group,
                    conditions,
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
        #endregion Set Permissions

        #region Get Properties
        /// <summary>
        /// The <see cref="GetProperties"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the path. It does not return the content of the
        /// path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties">
        /// Get Properties</see>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public virtual Response<PathProperties> GetProperties(
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(GetProperties)}");

            try
            {
                scope.Start();

                return base.GetProperties(
                    conditions,
                    cancellationToken);
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
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata, standard HTTP properties, and system
        /// properties for the path. It does not return the content of the
        /// path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob-properties">
        /// Get Properties</see>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public override async Task<Response<PathProperties>> GetPropertiesAsync(
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(GetProperties)}");

            try
            {
                scope.Start();

                return await base.GetPropertiesAsync(
                    conditions,
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
        #endregion Get Properties

        #region Set Http Headers
        /// <summary>
        /// The <see cref="SetHttpHeaders"/> operation sets system
        /// properties on the path.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.
        /// If not specified, existing values will be cleared.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public override Response<PathInfo> SetHttpHeaders(
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(SetHttpHeaders)}");

            try
            {
                scope.Start();

                return base.SetHttpHeaders(
                    httpHeaders,
                    conditions,
                    cancellationToken);
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
        /// The <see cref="SetHttpHeadersAsync"/> operation sets system
        /// properties on the PATH.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-properties">
        /// Set Blob Properties</see>.
        /// </summary>
        /// <param name="httpHeaders">
        /// Optional. The standard HTTP header system properties to set.
        /// If not specified, existing values will be cleared.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public override async Task<Response<PathInfo>> SetHttpHeadersAsync(
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(SetHttpHeaders)}");

            try
            {
                scope.Start();

                return await base.SetHttpHeadersAsync(
                        httpHeaders,
                        conditions,
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
        #endregion Set Http Headers

        #region Set Metadata
        /// <summary>
        /// The <see cref="SetMetadata"/> operation sets user-defined
        /// metadata for the specified path as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata">
        /// Set Metadata</see>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public override Response<PathInfo> SetMetadata(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(SetMetadata)}");

            try
            {
                scope.Start();

                return base.SetMetadata(
                    metadata,
                    conditions,
                    cancellationToken);
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
        /// The <see cref="SetMetadataAsync"/> operation sets user-defined
        /// metadata for the specified path as one or more name-value pairs.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-metadata">
        /// Set Metadata</see>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public override async Task<Response<PathInfo>> SetMetadataAsync(
            Metadata metadata,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(SetMetadata)}");

            try
            {
                scope.Start();

                return await base.SetMetadataAsync(
                    metadata,
                    conditions,
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
        #endregion Set Metadata

        #region Append Data
        /// <summary>
        /// The <see cref="Append(Stream, long, DataLakeFileAppendOptions, CancellationToken)"/> operation uploads data to be appended to a file.
        /// Data can only be appended to a file.
        /// To apply previously uploaded data to a file, call Flush Data.
        /// Append is currently limited to 4000 MB per request.  To upload large files all at once, consider using <see cref="Upload(Stream)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response Append(
            Stream content,
            long offset,
            DataLakeFileAppendOptions options = default,
            CancellationToken cancellationToken = default) =>
            AppendInternal(
                content,
                offset,
                options?.TransferValidation,
                options?.LeaseId,
                options?.LeaseAction,
                options?.LeaseDuration,
                options?.ProposedLeaseId,
                options?.ProgressHandler,
                options?.Flush,
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="AppendAsync(Stream, long, DataLakeFileAppendOptions, CancellationToken)"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        /// Append is currently limited to 4000 MB per request.  To upload large files all at once, consider using <see cref="UploadAsync(Stream)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response> AppendAsync(
            Stream content,
            long offset,
            DataLakeFileAppendOptions options = default,
            CancellationToken cancellationToken = default) =>
            await AppendInternal(
                content,
                offset,
                options?.TransferValidation,
                options?.LeaseId,
                options?.LeaseAction,
                options?.LeaseDuration,
                options?.ProposedLeaseId,
                options?.ProgressHandler,
                options?.Flush,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="Append(Stream, long, byte[], string, IProgress{long}, CancellationToken)"/> operation uploads data to be appended to a file.
        /// Data can only be appended to a file.
        /// To apply previously uploaded data to a file, call Flush Data.
        /// Append is currently limited to 4000 MB per request.  To upload large files all at once, consider using <see cref="Upload(Stream)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response Append(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            long offset,
            byte[] contentHash,
            string leaseId,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            return AppendInternal(
                content,
                offset,
                contentHash != default
                    ? new UploadTransferValidationOptions()
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                        PrecalculatedChecksum = contentHash
                    }
                    : default,
                leaseId,
                leaseAction: null,
                leaseDuration: null,
                proposedLeaseId: null,
                progressHandler,
                flush: null,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="AppendAsync(Stream, long, byte[], string, IProgress{long}, CancellationToken)"/> operation uploads data to be appended to a file.  Data can only be appended to a file.
        /// To apply perviously uploaded data to a file, call Flush Data.
        /// Append is currently limited to 4000 MB per request.  To upload large files all at once, consider using <see cref="UploadAsync(Stream)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update">
        /// Update Path</see>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response> AppendAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content,
            long offset,
            byte[] contentHash,
            string leaseId,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            return await AppendInternal(
                content,
                offset,
                contentHash != default
                    ? new UploadTransferValidationOptions()
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                        PrecalculatedChecksum = contentHash
                    }
                    : default,
                leaseId,
                leaseAction: null,
                leaseDuration: null,
                proposedLeaseId: null,
                progressHandler,
                flush: null,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
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
        /// <param name="offset">
        /// This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.
        /// It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.
        /// The value must be the position where the data is to be appended. Uploaded data is not immediately flushed, or written, to the file.
        /// To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length
        /// of the file after all data has been written, and there must not be a request entity body included with the request.
        /// </param>
        /// <param name="validationOptionsOverride">
        /// Optional settings for transfer validation.
        /// </param>
        /// <param name="leaseId">
        /// Lease id for operation.
        /// </param>
        /// <param name="leaseAction">
        /// Lease action.
        /// <see cref="DataLakeLeaseAction.Acquire"/> will attempt to aquire a new lease on the file, with <see cref="DataLakeFileAppendOptions.ProposedLeaseId"/> as the lease ID.
        /// <see cref="DataLakeLeaseAction.AcquireRelease"/> will attempt to aquire a new lease on the file, with <see cref="DataLakeFileAppendOptions.ProposedLeaseId"/> as the lease ID.  The lease will be released once the Append operation is complete.  Only applicable if <see cref="DataLakeFileAppendOptions.Flush"/> is set to true.
        /// <see cref="DataLakeLeaseAction.AutoRenew"/> will attempt to renew the lease specified by <see cref="DataLakeFileAppendOptions.LeaseId"/>.
        /// <see cref="DataLakeLeaseAction.Release"/> will attempt to release the least speified by <see cref="DataLakeFileAppendOptions.LeaseId"/>.  Only applicable if <see cref="DataLakeFileAppendOptions.Flush"/> is set to true.
        /// </param>
        /// <param name="leaseDuration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="DataLakeLeaseClient.InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// </param>
        /// <param name="proposedLeaseId">
        /// Proposed lease ID. Valid with <see cref="DataLakeLeaseAction.Acquire"/> and <see cref="DataLakeLeaseAction.AcquireRelease"/>.
        /// </param>
        /// <param name="progressHandler">
        /// Progress handler for append operation.
        /// </param>
        /// <param name="flush">
        /// Optional.  If true, the file will be flushed after the append.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal virtual async Task<Response> AppendInternal(
            Stream content,
            long? offset,
            UploadTransferValidationOptions validationOptionsOverride,
            string leaseId,
            DataLakeLeaseAction? leaseAction,
            TimeSpan? leaseDuration,
            string proposedLeaseId,
            IProgress<long> progressHandler,
            bool? flush,
            bool async,
            CancellationToken cancellationToken)
        {
            UploadTransferValidationOptions validationOptions = validationOptionsOverride ?? ClientConfiguration.TransferValidation.Upload;

            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakeFileClient)))
            {
                // compute hash BEFORE attaching progress handler
                ContentHasher.GetHashResult hashResult = await ContentHasher.GetHashOrDefaultInternal(
                    content,
                    validationOptions,
                    async,
                    cancellationToken).ConfigureAwait(false);

                content = content?.WithNoDispose().WithProgress(progressHandler);
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakeFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(offset)}: {offset}\n" +
                    $"{nameof(leaseId)}: {leaseId}\n");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Append)}");

                try
                {
                    scope.Start();
                    Errors.VerifyStreamPosition(content, nameof(content));
                    ResponseWithHeaders<PathAppendDataHeaders> response;

                    long? leaseDurationLong = null;
                    if (leaseDuration.HasValue)
                    {
                        leaseDurationLong = leaseDuration < TimeSpan.Zero
                            ? Constants.Blob.Lease.InfiniteLeaseDuration
                            : Convert.ToInt64(leaseDuration.Value.TotalSeconds);
                    }

                    if (async)
                    {
                        response = await PathRestClient.AppendDataAsync(
                            body: content,
                            position: offset,
                            contentLength: content?.Length - content?.Position ?? 0,
                            transactionalContentHash: hashResult?.MD5AsArray,
                            transactionalContentCrc64: hashResult?.StorageCrc64AsArray,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            leaseId: leaseId,
                            leaseAction: leaseAction,
                            leaseDuration: leaseDurationLong,
                            proposedLeaseId: proposedLeaseId,
                            flush: flush,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PathRestClient.AppendData(
                            body: content,
                            position: offset,
                            contentLength: content?.Length - content?.Position ?? 0,
                            transactionalContentHash: hashResult?.MD5AsArray,
                            transactionalContentCrc64: hashResult?.StorageCrc64AsArray,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            leaseId: leaseId,
                            leaseAction: leaseAction,
                            leaseDuration: leaseDurationLong,
                            proposedLeaseId: proposedLeaseId,
                            flush: flush,
                            cancellationToken: cancellationToken);
                    }

                    return response.GetRawResponse();
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
        #endregion Append Data

        #region Flush Data
        /// <summary>
        /// The <see cref="Flush(long, DataLakeFileFlushOptions, CancellationToken)"/> operation flushes (writes) previously
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> Flush(
            long position,
            DataLakeFileFlushOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return FlushInternal(
                position: position,
                retainUncommittedData: options?.RetainUncommittedData,
                close: options?.Close,
                httpHeaders: options?.HttpHeaders,
                conditions: options?.Conditions,
                leaseAction: options?.LeaseAction,
                leaseDuration: options?.LeaseDuration,
                proposedLeaseId: options?.ProposedLeaseId,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="Flush(long, bool?, bool?, PathHttpHeaders, DataLakeRequestConditions, CancellationToken)"/> operation flushes (writes) previously
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PathInfo> Flush(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long position,
            bool? retainUncommittedData,
            bool? close,
            PathHttpHeaders httpHeaders,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            return FlushInternal(
                position,
                retainUncommittedData,
                close,
                httpHeaders,
                conditions,
                leaseAction: null,
                leaseDuration: null,
                proposedLeaseId: null,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="FlushAsync(long, DataLakeFileFlushOptions, CancellationToken)"/> operation flushes (writes) previously
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
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> FlushAsync(
            long position,
            DataLakeFileFlushOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return await FlushInternal(
                position: position,
                retainUncommittedData: options?.RetainUncommittedData,
                close: options?.Close,
                httpHeaders: options?.HttpHeaders,
                conditions: options?.Conditions,
                leaseAction: options?.LeaseAction,
                leaseDuration: options?.LeaseDuration,
                proposedLeaseId: options?.ProposedLeaseId,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The <see cref="FlushAsync(long, bool?, bool?, PathHttpHeaders, DataLakeRequestConditions, CancellationToken)"/> operation flushes (writes) previously
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<PathInfo>> FlushAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            long position,
            bool? retainUncommittedData,
            bool? close,
            PathHttpHeaders httpHeaders,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            return await FlushInternal(
                position,
                retainUncommittedData,
                close,
                httpHeaders,
                conditions,
                leaseAction: null,
                leaseDuration: null,
                proposedLeaseId: null,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

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
        /// the file stream has been closed.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        ///</param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the flush of this file.
        /// </param>
        /// <param name="leaseAction">
        /// Lease action.
        /// <see cref="DataLakeLeaseAction.Acquire"/> will attempt to aquire a new lease on the file, with <see cref="DataLakeFileFlushOptions.ProposedLeaseId"/> as the lease ID.
        /// <see cref="DataLakeLeaseAction.AcquireRelease"/> will attempt to aquire a new lease on the file, with <see cref="DataLakeFileFlushOptions.ProposedLeaseId"/> as the lease ID.  The lease will be released once the Append operation is complete.
        /// <see cref="DataLakeLeaseAction.AutoRenew"/> will attempt to renew the lease specified by <see cref="DataLakeRequestConditions.LeaseId"/>.
        /// <see cref="DataLakeLeaseAction.Release"/> will attempt to release the least speified by <see cref="DataLakeRequestConditions.LeaseId"/>.
        /// </param>
        /// <param name="leaseDuration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="DataLakeLeaseClient.InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// </param>
        /// <param name="proposedLeaseId">
        /// Proposed lease ID. Valid with <see cref="DataLakeLeaseAction.Acquire"/> and <see cref="DataLakeLeaseAction.AcquireRelease"/>.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal virtual async Task<Response<PathInfo>> FlushInternal(
            long position,
            bool? retainUncommittedData,
            bool? close,
            PathHttpHeaders httpHeaders,
            DataLakeRequestConditions conditions,
            DataLakeLeaseAction? leaseAction,
            TimeSpan? leaseDuration,
            string proposedLeaseId,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakeFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                nameof(DataLakeFileClient),
                message:
                $"{nameof(Uri)}: {Uri}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Flush)}");

                try
                {
                    scope.Start();
                    ResponseWithHeaders<PathFlushDataHeaders> response;

                    long? leaseDurationLong = null;
                    if (leaseDuration.HasValue)
                    {
                        leaseDurationLong = leaseDuration < TimeSpan.Zero
                            ? Constants.Blob.Lease.InfiniteLeaseDuration
                            : Convert.ToInt64(leaseDuration.Value.TotalSeconds);
                    }

                    if (async)
                    {
                        response = await PathRestClient.FlushDataAsync(
                            position: position,
                            retainUncommittedData: retainUncommittedData,
                            close: close,
                            contentLength: 0,
                            contentMD5: httpHeaders?.ContentHash,
                            leaseId: conditions?.LeaseId,
                            leaseAction: leaseAction,
                            leaseDuration: leaseDurationLong,
                            proposedLeaseId: proposedLeaseId,
                            cacheControl: httpHeaders?.CacheControl,
                            contentType: httpHeaders?.ContentType,
                            contentDisposition: httpHeaders?.ContentDisposition,
                            contentEncoding: httpHeaders?.ContentEncoding,
                            contentLanguage: httpHeaders?.ContentLanguage,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = PathRestClient.FlushData(
                            position: position,
                            retainUncommittedData: retainUncommittedData,
                            close: close,
                            contentLength: 0,
                            contentMD5: httpHeaders?.ContentHash,
                            leaseId: conditions?.LeaseId,
                            leaseAction: leaseAction,
                            leaseDuration: leaseDurationLong,
                            proposedLeaseId: proposedLeaseId,
                            cacheControl: httpHeaders?.CacheControl,
                            contentType: httpHeaders?.ContentType,
                            contentDisposition: httpHeaders?.ContentDisposition,
                            contentEncoding: httpHeaders?.ContentEncoding,
                            contentLanguage: httpHeaders?.ContentLanguage,
                            ifMatch: conditions?.IfMatch?.ToString(),
                            ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                            ifModifiedSince: conditions?.IfModifiedSince,
                            ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                            encryptionKey: ClientConfiguration.CustomerProvidedKey?.EncryptionKey,
                            encryptionKeySha256: ClientConfiguration.CustomerProvidedKey?.EncryptionKeyHash,
                            encryptionAlgorithm: ClientConfiguration.CustomerProvidedKey?.EncryptionAlgorithm == null ? null : EncryptionAlgorithmTypeInternal.AES256,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPathInfo(),
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
        #endregion

        #region Read Data

        #region Deprecated
        /// <summary>
        /// The <see cref="Read()"/> operation downloads a file from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="FileDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<FileDownloadInfo> Read()
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Read)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = _blockBlobClient.DownloadStreaming();

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadAsync()"/> operation downloads a file from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="FileDownloadInfo.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<FileDownloadInfo>> ReadAsync()
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Read)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response
                    = await _blockBlobClient.DownloadStreamingAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        /// The <see cref="Read(CancellationToken)"/> operation downloads a file from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/> describing the
        /// downloaded file.  <see cref="FileDownloadInfo.Content"/> contains
        /// the blob's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<FileDownloadInfo> Read(
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Read)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = _blockBlobClient.DownloadStreaming(cancellationToken: cancellationToken);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadAsync(CancellationToken)"/> operation downloads a file from
        /// the service, including its metadata and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<FileDownloadInfo>> ReadAsync(
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Read)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response
                    = await _blockBlobClient.DownloadStreamingAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        /// The <see cref="Read(HttpRange, DataLakeRequestConditions?, Boolean, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="range">
        /// If provided, only download the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// downloading this file.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<FileDownloadInfo> Read(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            DataLakeRequestConditions conditions,
            bool rangeGetContentHash,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Read)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = _blockBlobClient.DownloadStreaming(
                    range: range,
                    conditions: conditions.ToBlobRequestConditions(),
                    rangeGetContentHash: rangeGetContentHash,
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadAsync(HttpRange, DataLakeRequestConditions?, Boolean, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="range">
        /// If provided, only download the bytes of the file in the specified
        /// range.  If not provided, download the entire file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// downloading this file.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<FileDownloadInfo>> ReadAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            HttpRange range,
            DataLakeRequestConditions conditions,
            bool rangeGetContentHash,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Read)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = await _blockBlobClient.DownloadStreamingAsync(
                    range: range,
                    conditions: conditions.ToBlobRequestConditions(),
                    rangeGetContentHash: rangeGetContentHash,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        /// The <see cref="Read(DataLakeFileReadOptions, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<FileDownloadInfo> Read(
            DataLakeFileReadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Read)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = _blockBlobClient.DownloadStreaming(
                    options: options.ToBlobBaseDownloadOptions(),
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadAsync(DataLakeFileReadOptions, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<FileDownloadInfo>> ReadAsync(
            DataLakeFileReadOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Read)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = await _blockBlobClient.DownloadStreamingAsync(
                    options: options.ToBlobBaseDownloadOptions(),
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        #endregion Deprecated

        /// <summary>
        /// The <see cref="ReadStreaming()"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadStreamingResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadStreamingResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileReadStreamingResult> ReadStreaming()
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadStreaming)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = _blockBlobClient.DownloadStreaming();

                return Response.FromValue(
                    response.ToDataLakeFileReadStreamingResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadStreamingAsync()"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadStreamingResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadStreamingResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileReadStreamingResult>> ReadStreamingAsync()
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadStreaming)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = await _blockBlobClient.DownloadStreamingAsync()
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToDataLakeFileReadStreamingResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadStreaming(CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadStreamingResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadStreamingResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileReadStreamingResult> ReadStreaming(
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadStreaming)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = _blockBlobClient.DownloadStreaming(
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    response.ToDataLakeFileReadStreamingResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadStreamingAsync(CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadStreamingResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadStreamingResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileReadStreamingResult>> ReadStreamingAsync(
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadStreaming)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = await _blockBlobClient.DownloadStreamingAsync(
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToDataLakeFileReadStreamingResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadStreaming(DataLakeFileReadOptions, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadStreamingResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadStreamingResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileReadStreamingResult> ReadStreaming(
            DataLakeFileReadOptions options,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadStreaming)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = _blockBlobClient.DownloadStreaming(
                    options: options.ToBlobBaseDownloadOptions(),
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    response.ToDataLakeFileReadStreamingResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadStreamingAsync(DataLakeFileReadOptions, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadStreamingResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadStreamingResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileReadStreamingResult>> ReadStreamingAsync(
            DataLakeFileReadOptions options,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadStreaming)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadStreamingResult> response = await _blockBlobClient.DownloadStreamingAsync(
                    options: options.ToBlobBaseDownloadOptions(),
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToDataLakeFileReadStreamingResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadContent()"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileReadResult> ReadContent()
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadContent)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadResult> response = _blockBlobClient.DownloadContent();

                return Response.FromValue(
                    response.ToDataLakeFileReadResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadContentAsync()"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileReadResult>> ReadContentAsync()
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadContent)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadResult> response = await _blockBlobClient.DownloadContentAsync()
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToDataLakeFileReadResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadContent(CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileReadResult> ReadContent(
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadContent)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadResult> response = _blockBlobClient.DownloadContent(
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    response.ToDataLakeFileReadResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadContentAsync(CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileReadResult>> ReadContentAsync(
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadContent)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadResult> response = await _blockBlobClient.DownloadContentAsync(
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToDataLakeFileReadResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadContent(DataLakeFileReadOptions, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileReadResult> ReadContent(
            DataLakeFileReadOptions options,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadContent)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadResult> response = _blockBlobClient.DownloadContent(
                    options: options.ToBlobBaseDownloadOptions(),
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    response.ToDataLakeFileReadResult(),
                    response.GetRawResponse());
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
        /// The <see cref="ReadContentAsync(DataLakeFileReadOptions, CancellationToken)"/>
        /// operation downloads a file from the service, including its metadata
        /// and properties.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/get-blob">
        /// Get Blob</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileReadResult}"/> describing the
        /// downloaded file.  <see cref="DataLakeFileReadResult.Content"/> contains
        /// the file's data.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileReadResult>> ReadContentAsync(
            DataLakeFileReadOptions options,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadContent)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.BlobDownloadResult> response = await _blockBlobClient.DownloadContentAsync(
                    options: options.ToBlobBaseDownloadOptions(),
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToDataLakeFileReadResult(),
                    response.GetRawResponse());
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
        #endregion Read Data

        #region Read To
        /// <summary>
        /// The <see cref="ReadTo(Stream, DataLakeFileReadToOptions, CancellationToken)"/>
        /// operation downloads an entire file using parallel requests,
        /// and writes the content to the provided stream.
        /// </summary>
        /// <param name="destination">
        /// Destination stream for writing read contents.
        /// </param>
        /// <param name="options">
        /// Options for reading this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response ReadTo(
            Stream destination,
            DataLakeFileReadToOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadTo)}");

            try
            {
                scope.Start();

                return _blockBlobClient.DownloadTo(
                    destination,
                    options.ToBlobBaseDownloadToOptions(),
                    cancellationToken: cancellationToken);
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
        /// The <see cref="ReadTo(string, DataLakeFileReadToOptions, CancellationToken)"/>
        /// operation downloads an entire file using parallel requests,
        /// and writes the content to the provided file path.
        /// </summary>
        /// <param name="path">
        /// File path to write read contents to.
        /// </param>
        /// <param name="options">
        /// Options for reading this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response ReadTo(
            string path,
            DataLakeFileReadToOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadTo)}");

            try
            {
                scope.Start();

                return _blockBlobClient.DownloadTo(
                    path,
                    options.ToBlobBaseDownloadToOptions(),
                    cancellationToken: cancellationToken);
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
        /// The <see cref="ReadToAsync(Stream, DataLakeFileReadToOptions, CancellationToken)"/>
        /// operation downloads an entire file using parallel requests,
        /// and writes the content to the provided destination stream.
        /// </summary>
        /// <param name="destination">
        /// Stream to write read contents to.
        /// </param>
        /// <param name="options">
        /// Options for reading this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response> ReadToAsync(
            Stream destination,
            DataLakeFileReadToOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadTo)}");

            try
            {
                scope.Start();

                return await _blockBlobClient.DownloadToAsync(
                    destination,
                    options.ToBlobBaseDownloadToOptions(),
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

        /// <summary>
        /// The <see cref="ReadToAsync(string, DataLakeFileReadToOptions, CancellationToken)"/>
        /// operation downloads an entire file using parallel requests,
        /// and writes the content to the provided file path.
        /// </summary>
        /// <param name="path">
        /// File path to write the read contents to.
        /// </param>
        /// <param name="options">
        /// Options for reading this blob.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response> ReadToAsync(
            string path,
            DataLakeFileReadToOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadTo)}");

            try
            {
                scope.Start();

                return await _blockBlobClient.DownloadToAsync(
                    path,
                    options.ToBlobBaseDownloadToOptions(),
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

        /// <summary>
        /// The <see cref="ReadTo(Stream, DataLakeRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads an entire file using parallel requests,
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of this file.
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
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response ReadTo(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream destination,
            DataLakeRequestConditions conditions,
            //IProgress<long> progressHandler,
            StorageTransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadTo)}");

            try
            {
                scope.Start();

                BlobRequestConditions blobRequestConditions = conditions.ToBlobRequestConditions();

                return _blockBlobClient.DownloadTo(
                    destination,
                    blobRequestConditions,
                    //progressHandler, // TODO: #8506
                    transferOptions: transferOptions,
                    cancellationToken: cancellationToken);
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
        /// The <see cref="ReadTo(string, DataLakeRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads an entire file using parallel requests,
        /// and writes the content to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of this file.
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
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response ReadTo(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string path,
            DataLakeRequestConditions conditions,
            //IProgress<long> progressHandler,
            StorageTransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadTo)}");

            try
            {
                scope.Start();

                BlobRequestConditions blobRequestConditions = conditions.ToBlobRequestConditions();

                return _blockBlobClient.DownloadTo(
                    path,
                    blobRequestConditions,
                    //progressHandler, // TODO: #8506
                    transferOptions: transferOptions,
                    cancellationToken: cancellationToken);
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
        /// The <see cref="ReadToAsync(Stream, DataLakeRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads an entire file using parallel requests,
        /// and writes the content to <paramref name="destination"/>.
        /// </summary>
        /// <param name="destination">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of this file.
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
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response> ReadToAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream destination,
            DataLakeRequestConditions conditions,
            //IProgress<long> progressHandler,
            StorageTransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ReadTo)}");

            try
            {
                scope.Start();

                BlobRequestConditions blobRequestConditions = conditions.ToBlobRequestConditions();

                return await _blockBlobClient.DownloadToAsync(
                    destination,
                    blobRequestConditions,
                    //progressHandler, // TODO: #8506
                    transferOptions: transferOptions,
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

        /// <summary>
        /// The <see cref="ReadToAsync(string, DataLakeRequestConditions, StorageTransferOptions, CancellationToken)"/>
        /// operation downloads an entire file using parallel requests,
        /// and writes the content to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of this file.
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
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response> ReadToAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string path,
            DataLakeRequestConditions conditions,
            //IProgress<long> progressHandler,
            StorageTransferOptions transferOptions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($".{nameof(DataLakeFileClient)}.{nameof(ReadTo)}");

            try
            {
                scope.Start();

                BlobRequestConditions blobRequestConditions = conditions.ToBlobRequestConditions();

                return await _blockBlobClient.DownloadToAsync(
                    path,
                    blobRequestConditions,
                    //progressHandler, // TODO: #8506
                    transferOptions: transferOptions,
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
        #endregion Read To

        #region Upload
        /// <summary>
        /// The <see cref="Upload(Stream, DataLakeFileUploadOptions, CancellationToken)"/>
        /// operation creates and uploads content to a file.  If the file already exists, its content will be overwritten,
        /// unless otherwise specified in the <see cref="DataLakeFileUploadOptions.Conditions"/> or alternatively use
        /// <see cref="Upload(Stream)"/>, <see cref="Upload(Stream, bool, CancellationToken)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
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
        /// state of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> Upload(
            Stream content,
            DataLakeFileUploadOptions options,
            CancellationToken cancellationToken = default) =>
            StagedUploadInternal(
                content,
                options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Upload(Stream, PathHttpHeaders, DataLakeRequestConditions, IProgress{long}, StorageTransferOptions, CancellationToken)"/>
        /// operation creates and uploads content to a file.  If the file already exists, its content will be overwritten,
        /// unless otherwise specified in the <see cref="DataLakeRequestConditions"/> or alternatively use
        /// <see cref="Upload(Stream)"/>, <see cref="Upload(Stream, bool, CancellationToken)"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" />.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to apply to the request.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
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
        /// state of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PathInfo> Upload(
            Stream content,
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default) =>
            Upload(
                content,
                new DataLakeFileUploadOptions
                {
                    HttpHeaders = httpHeaders,
                    Conditions = conditions,
                    ProgressHandler = progressHandler,
                    TransferOptions = transferOptions
                },
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="Upload(Stream, bool, CancellationToken)"/>
        /// operation creates and uploads content to a file.
        ///
        /// If the file already exists, then its content will not be overwritten.
        /// The request will be sent with If-None-Match Header with the value of
        /// the special wildcard. So if the file already exists a
        /// <see cref="RequestFailedException"/> is expected to be thrown.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// state of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PathInfo> Upload(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content) =>
            Upload(
                content,
                overwrite: false);

        /// <summary>
        /// The <see cref="Upload(Stream, bool, CancellationToken)"/>
        /// operation creates and uploads content to a file.
        ///
        /// If the overwrite parameter is not specified and
        /// the file already exists, then its content will not be overwritten.
        /// The request will be sent with If-None-Match Header with the value of
        /// the special wildcard. So if the file already exists a
        /// <see cref="RequestFailedException"/> is expected to be thrown.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite an existing file.  The
        /// default value is false.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// state of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Response<PathInfo> Upload(
            Stream content,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            Upload(
                content,
                conditions: overwrite ? null : new DataLakeRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) },
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, DataLakeFileUploadOptions, CancellationToken)"/>
        /// operation creates and uploads content to a file. If the file already exists, its content will be overwritten,
        /// unless otherwise specified in the <see cref="DataLakeFileUploadOptions.Conditions"/> or alternatively use
        /// <see cref="UploadAsync(Stream)"/>, <see cref="UploadAsync(Stream, bool, CancellationToken)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
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
        [ForwardsClientCalls]
        public virtual Task<Response<PathInfo>> UploadAsync(
            Stream content,
            DataLakeFileUploadOptions options,
            CancellationToken cancellationToken = default) =>
            StagedUploadInternal(
                content,
                options,
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, PathHttpHeaders, DataLakeRequestConditions, IProgress{long}, StorageTransferOptions, CancellationToken)"/>
        /// operation creates and uploads content to a file.  If the file already exists, its content will be overwritten,
        /// unless otherwise specified in the <see cref="DataLakeRequestConditions"/> or alternatively use
        /// <see cref="UploadAsync(Stream)"/>, <see cref="UploadAsync(Stream, bool, CancellationToken)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        ///</param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to apply to the request.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
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
        public virtual Task<Response<PathInfo>> UploadAsync(
            Stream content,
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default) =>
            StagedUploadInternal(
                content,
                new DataLakeFileUploadOptions
                {
                    HttpHeaders = httpHeaders,
                    Conditions = conditions,
                    ProgressHandler = progressHandler,
                    TransferOptions = transferOptions
                },
                async: true,
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, bool, CancellationToken)"/>
        /// operation creates and uploads content to a file.
        ///
        /// If the file already exists, then its content will not be overwritten.
        /// The request will be sent with If-None-Match Header with the value of
        /// the special wildcard. So if the file already exists a
        /// <see cref="RequestFailedException"/> is expected to be thrown.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
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
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Task<Response<PathInfo>> UploadAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            Stream content) =>
            UploadAsync(
                content,
                overwrite: false);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, bool, CancellationToken)"/>
        /// operation creates and uploads content to a file.
        ///
        /// If the overwrite parameter is not specified and
        /// the file already exists, then its content will not be overwritten.
        /// The request will be sent with If-None-Match Header with the value of
        /// the special wildcard. So if the file already exists a
        /// <see cref="RequestFailedException"/> is expected to be thrown.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite an existing file.  The
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
        [ForwardsClientCalls]
        public virtual Task<Response<PathInfo>> UploadAsync(
            Stream content,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            UploadAsync(
                content,
                conditions: overwrite ? null : new DataLakeRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) },
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="Upload(string, DataLakeFileUploadOptions, CancellationToken)"/>
        /// operation creates and uploads content to a file.If the file already exists, its content will be overwritten,
        /// unless otherwise specified in the <see cref="DataLakeFileUploadOptions.Conditions"/> or alternatively use
        /// <see cref="Upload(Stream)"/>, <see cref="Upload(Stream, bool, CancellationToken)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param> of this new block blob.
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
        [ForwardsClientCalls]
        public virtual Response<PathInfo> Upload(
            string path,
            DataLakeFileUploadOptions options,
            CancellationToken cancellationToken = default)
            => StagedUploadInternal(
                    path,
                    options,
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();

        /// <summary>
        /// The <see cref="Upload(string, PathHttpHeaders, DataLakeRequestConditions, IProgress{long}, StorageTransferOptions, CancellationToken)"/>
        /// operation creates and uploads content to a file.If the file already exists, its content will be overwritten,
        /// unless otherwise specified in the <see cref="DataLakeRequestConditions"/> or alternatively use
        /// <see cref="Upload(Stream)"/>, <see cref="Upload(Stream, bool, CancellationToken)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param> of this new block blob.
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        ///</param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to apply to the request.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
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
        [ForwardsClientCalls]
        public virtual Response<PathInfo> Upload(
            string path,
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return StagedUploadInternal(
                    stream,
                    new DataLakeFileUploadOptions
                    {
                        HttpHeaders = httpHeaders,
                        Conditions = conditions,
                        ProgressHandler = progressHandler,
                        TransferOptions = transferOptions
                    },
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
            }
        }

        /// <summary>
        /// The <see cref="Upload(Stream, bool, CancellationToken)"/>
        /// operation creates and uploads content to a file.
        ///
        /// If the file already exists, then its content will not be overwritten.
        /// The request will be sent with If-None-Match Header with the value of
        /// the special wildcard. So if the file already exists a
        /// <see cref="RequestFailedException"/> is expected to be thrown.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param> of this new block blob.
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
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<PathInfo> Upload(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string path) =>
            Upload(
                path,
                overwrite: false);

        /// <summary>
        /// The <see cref="Upload(Stream, bool, CancellationToken)"/>
        /// operation creates and uploads content to a file.
        ///
        /// If the overwrite parameter is not specified and
        /// the file already exists, then its content will not be overwritten.
        /// The request will be sent with If-None-Match Header with the value of
        /// the special wildcard. So if the file already exists a
        /// <see cref="RequestFailedException"/> is expected to be thrown.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param> of this new block blob.
        /// <param name="overwrite">
        /// Whether the upload should overwrite an existing file.  The
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
        [ForwardsClientCalls]
        public virtual Response<PathInfo> Upload(
            string path,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
            Upload(
                path,
                conditions: overwrite ? null : new DataLakeRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) },
                cancellationToken: cancellationToken);

        /// <summary>
        /// The <see cref="UploadAsync(string, DataLakeFileUploadOptions, CancellationToken)"/>
        /// operation creates and uploads content to a file.  If the file already exists, its content will be overwritten,
        /// unless otherwise specified in the <see cref="DataLakeFileUploadOptions.Conditions"/> or alternatively use
        /// <see cref="UploadAsync(Stream)"/>, <see cref="UploadAsync(Stream, bool, CancellationToken)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
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
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> UploadAsync(
            string path,
            DataLakeFileUploadOptions options,
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
        /// The <see cref="UploadAsync(string, PathHttpHeaders, DataLakeRequestConditions, IProgress{long}, StorageTransferOptions, CancellationToken)"/>
        /// operation creates and uploads content to a file.  If the file already exists, its content will be overwritten,
        /// unless otherwise specified in the <see cref="DataLakeRequestConditions"/> or alternatively use
        /// <see cref="Upload(Stream)"/>, <see cref="Upload(Stream, bool, CancellationToken)"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional standard HTTP header properties that can be set for the file.
        ///</param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to apply to the request.
        /// </param>
        /// <param name="progressHandler">
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
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
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> UploadAsync(
            string path,
            PathHttpHeaders httpHeaders = default,
            DataLakeRequestConditions conditions = default,
            IProgress<long> progressHandler = default,
            StorageTransferOptions transferOptions = default,
            CancellationToken cancellationToken = default)
            => await UploadAsync(
                path,
                new DataLakeFileUploadOptions
                {
                    HttpHeaders = httpHeaders,
                    Conditions = conditions,
                    ProgressHandler = progressHandler,
                    TransferOptions = transferOptions
                },
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, bool, CancellationToken)"/>
        /// operation creates and uploads content to a file.
        ///
        /// If the file already exists, then its content will not be overwritten.
        /// The request will be sent with If-None-Match Header with the value of
        /// the special wildcard. So if the file already exists a
        /// <see cref="RequestFailedException"/> is expected to be thrown.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
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
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<PathInfo>> UploadAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string path) =>
                await UploadAsync(
                    path,
                    overwrite: false).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="UploadAsync(Stream, bool, CancellationToken)"/>
        /// operation creates and uploads content to a file.
        ///
        /// If the overwrite parameter is not specified and
        /// the file already exists, then its content will not be overwritten.
        /// The request will be sent with If-None-Match Header with the value of
        /// the special wildcard. So if the file already exists a
        /// <see cref="RequestFailedException"/> is expected to be thrown.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/update" >
        /// Update Path</see>.
        /// </summary>
        /// <param name="path">
        /// A file path containing the content to upload.
        /// </param>
        /// <param name="overwrite">
        /// Whether the upload should overwrite an existing file.  The
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
        [ForwardsClientCalls]
        public virtual async Task<Response<PathInfo>> UploadAsync(
            string path,
            bool overwrite = false,
            CancellationToken cancellationToken = default) =>
                await UploadAsync(
                    path,
                    conditions: overwrite ? null : new DataLakeRequestConditions { IfNoneMatch = new ETag(Constants.Wildcard) },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// This operation will upload data as indiviually staged
        /// blocks if it's larger than the
        /// <paramref name="options"/> <see cref="StorageTransferOptions.InitialTransferSize"/>.
        /// </summary>
        /// <param name="content">
        /// A <see cref="Stream"/> containing the content to upload.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="async">
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the
        /// state of the updated file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        internal async Task<Response<PathInfo>> StagedUploadInternal(
            Stream content,
            DataLakeFileUploadOptions options,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            DataLakeFileClient client = new DataLakeFileClient(Uri, ClientConfiguration);

            var uploader = GetPartitionedUploader(
                options.TransferOptions,
                validationOptions: options?.TransferValidation ?? ClientConfiguration.TransferValidation.Upload,
                operationName: $"{nameof(DataLakeFileClient)}.{nameof(Upload)}");

            return await uploader.UploadInternal(
                content,
                expectedContentLength: default,
                options,
                options.ProgressHandler,
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This operation will upload data it as individually staged
        /// blocks if it's larger than the
        /// <paramref name="options"/> <see cref="StorageTransferOptions.InitialTransferSize"/>.
        /// </summary>
        /// <param name="path">
        /// A file path of the file to upload.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
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
        internal async Task<Response<PathInfo>> StagedUploadInternal(
            string path,
            DataLakeFileUploadOptions options,
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

        #region ScheduleDeletion
        /// <summary>
        /// Schedules the file for deletion.
        /// </summary>
        /// <param name="options">
        /// Schedule deletion parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<PathInfo> ScheduleDeletion(
            DataLakeFileScheduleDeletionOptions options,
            CancellationToken cancellationToken = default)
            => ScheduleDeletionInternal(
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Schedules the file for deletion.
        /// </summary>
        /// <param name="options">
        /// Schedule deletion parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{PathInfo}"/> describing the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<PathInfo>> ScheduleDeletionAsync(
            DataLakeFileScheduleDeletionOptions options,
            CancellationToken cancellationToken = default)
            => await ScheduleDeletionInternal(
                options,
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Schedules the file for deletion.
        /// </summary>
        /// <param name="options">
        /// Schedule deletion parameters.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobInfo}"/> describing the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<PathInfo>> ScheduleDeletionInternal(
            DataLakeFileScheduleDeletionOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            using (ClientConfiguration.Pipeline.BeginLoggingScope(nameof(DataLakeFileClient)))
            {
                ClientConfiguration.Pipeline.LogMethodEnter(
                    nameof(DataLakeFileClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(options.TimeToExpire)}: {options.TimeToExpire}\n" +
                    $"{nameof(options.SetExpiryRelativeTo)}: {options.SetExpiryRelativeTo}\n" +
                    $"{nameof(options.ExpiresOn)}: {options.ExpiresOn}");

                DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(ScheduleDeletion)}");

                try
                {
                    scope.Start();
                    PathExpiryOptions blobExpiryOptions;
                    string expiresOn = null;

                    // Relative
                    if (options.TimeToExpire.HasValue)
                    {
                        if (options.SetExpiryRelativeTo.Value == DataLakeFileExpirationOrigin.CreationTime)
                        {
                            blobExpiryOptions = PathExpiryOptions.RelativeToCreation;
                        }
                        else
                        {
                            blobExpiryOptions = PathExpiryOptions.RelativeToNow;
                        }
                        expiresOn = options.TimeToExpire.Value.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
                    }
                    // Absolute
                    else
                    {
                        if (options.ExpiresOn.HasValue)
                        {
                            blobExpiryOptions = PathExpiryOptions.Absolute;
                            expiresOn = options.ExpiresOn?.ToString("R", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            blobExpiryOptions = PathExpiryOptions.NeverExpire;
                        }
                    }

                    ResponseWithHeaders<PathSetExpiryHeaders> response;

                    if (async)
                    {
                        response = await BlobPathRestClient.SetExpiryAsync(
                            expiryOptions: blobExpiryOptions,
                            expiresOn: expiresOn,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        response = BlobPathRestClient.SetExpiry(
                            expiryOptions: blobExpiryOptions,
                            expiresOn: expiresOn,
                            cancellationToken: cancellationToken);
                    }

                    return Response.FromValue(
                        response.ToPathInfo(),
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

        #endregion ScheduleDeletion

        #region Query
        /// <summary>
        /// The <see cref="Query"/> API returns the
        /// result of a query against the file.
        /// </summary>
        /// <param name="querySqlExpression">
        /// The query. For a sample SQL query expression, see <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/data-lake-storage-query-acceleration-how-to?tabs=dotnet%2Cpowershell#retrieve-data-by-using-a-filter">this </see>article.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/>.
        /// </returns>
        public virtual Response<FileDownloadInfo> Query(
            string querySqlExpression,
            DataLakeQueryOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Query)}");
            try
            {
                scope.Start();
                Response<BlobDownloadInfo> response = _blockBlobClient.Query(
                    querySqlExpression,
                    options.ToBlobQueryOptions(),
                    cancellationToken);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        /// The <see cref="Query"/> API returns the
        /// result of a query against the file.
        /// </summary>
        /// <param name="querySqlExpression">
        /// The query. For a sample SQL query expression, see <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/data-lake-storage-query-acceleration-how-to?tabs=dotnet%2Cpowershell#retrieve-data-by-using-a-filter">this </see>article.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        /// <returns>
        /// A <see cref="Response{FileDownloadInfo}"/>.
        /// </returns>
        public virtual async Task<Response<FileDownloadInfo>> QueryAsync(
            string querySqlExpression,
            DataLakeQueryOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(Query)}");
            try
            {
                scope.Start();
                Response<BlobDownloadInfo> response = await _blockBlobClient.QueryAsync(
                    querySqlExpression,
                    options.ToBlobQueryOptions(),
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    response.ToFileDownloadInfo(),
                    response.GetRawResponse());
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
        #endregion Query

        #region OpenRead
        /// <summary>
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            DataLakeOpenReadOptions options,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(OpenRead)}");
            try
            {
                scope.Start();
                return _blockBlobClient.OpenRead(
                    options.ToBlobOpenReadOptions(),
                    cancellationToken);
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
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            DataLakeOpenReadOptions options,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(OpenRead)}");
            try
            {
                scope.Start();
                return await _blockBlobClient.OpenReadAsync(
                options.ToBlobOpenReadOptions(),
                cancellationToken).ConfigureAwait(false);
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
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size (in bytes) to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of this file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            long position = 0,
            int? bufferSize = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(OpenRead)}");
            try
            {
                scope.Start();
                return _blockBlobClient.OpenRead(
                    position,
                    bufferSize,
                    conditions.ToBlobRequestConditions(),
                    cancellationToken);
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
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="allowfileModifications">
        /// If true, you can continue streaming a blob even if it has been modified.
        /// </param>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size (in bytes) to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenRead(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool allowfileModifications,
            long position = 0,
            int? bufferSize = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(OpenRead)}");
            try
            {
                scope.Start();
                return _blockBlobClient.OpenRead(
                allowfileModifications,
                position,
                bufferSize,
                cancellationToken);
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
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size (in bytes) to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            long position = 0,
            int? bufferSize = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(OpenRead)}");
            try
            {
                scope.Start();
                return await _blockBlobClient.OpenReadAsync(
                position,
                bufferSize,
                conditions?.ToBlobRequestConditions(),
                cancellationToken).ConfigureAwait(false);
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
        /// Opens a stream for reading from the file.  The stream will only download
        /// the file as the stream is read from.
        /// </summary>
        /// <param name="allowfileModifications">
        /// If true, you can continue streaming a blob even if it has been modified.
        /// </param>
        /// <param name="position">
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </param>
        /// <param name="bufferSize">
        /// The buffer size (in bytes) to use when the stream downloads parts
        /// of the file.  Defaults to 1 MB.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Returns a stream that will download the file as the stream
        /// is read from.
        /// </returns>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenReadAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool allowfileModifications,
            long position = 0,
            int? bufferSize = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(OpenRead)}");
            try
            {
                scope.Start();
                return await _blockBlobClient.OpenReadAsync(
                allowfileModifications,
                position,
                bufferSize,
                cancellationToken).ConfigureAwait(false);
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
        #endregion OpenRead

        #region OpenWrite
        /// <summary>
        /// Opens a stream for writing to the file.
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
        /// A stream to write to the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Stream OpenWrite(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            DataLakeFileOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => OpenWriteInternal(
                overwrite: overwrite,
                options: options,
                async: false,
                cancellationToken: cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Opens a stream for writing to the file..
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
        /// A stream to write to the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Stream> OpenWriteAsync(
#pragma warning restore AZC0015 // Unexpected client method return type.
            bool overwrite,
            DataLakeFileOpenWriteOptions options = default,
            CancellationToken cancellationToken = default)
            => await OpenWriteInternal(
                overwrite: overwrite,
                options: options,
                async: true,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Opens a stream for writing to the file.
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
        /// A stream to write to the file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Stream> OpenWriteInternal(
            bool overwrite,
            DataLakeFileOpenWriteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeFileClient)}.{nameof(OpenWrite)}");

            try
            {
                scope.Start();

                long position;
                ETag? eTag;

                if (overwrite)
                {
                    Response<PathInfo> createResponse = await CreateInternal(
                        resourceType: PathResourceType.File,
                        httpHeaders: default,
                        metadata: default,
                        permissions: default,
                        umask: default,
                        owner: default,
                        group: default,
                        accessControlList: default,
                        leaseId: default,
                        leaseDuration: default,
                        timeToExpire: default,
                        expiresOn: default,
                        encryptionContext: default,
                        conditions: options?.OpenConditions,
                        async: async,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);

                    position = 0;
                    eTag = createResponse.Value.ETag;
                }
                else
                {
                    try
                    {
                        Response<PathProperties> propertiesResponse;

                        if (async)
                        {
                            propertiesResponse = await GetPropertiesAsync(
                                conditions: options?.OpenConditions,
                                cancellationToken: cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            propertiesResponse = GetProperties(
                                conditions: options?.OpenConditions,
                                cancellationToken: cancellationToken);
                        }

                        position = propertiesResponse.Value.ContentLength;
                        eTag = propertiesResponse.Value.ETag;
                    }
                    catch (RequestFailedException ex)
                    when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
                    {
                        Response<PathInfo> createResponse = await CreateInternal(
                            resourceType: PathResourceType.File,
                            httpHeaders: default,
                            metadata: default,
                            permissions: default,
                            umask: default,
                            owner: default,
                            group: default,
                            accessControlList: default,
                            leaseId: default,
                            leaseDuration: default,
                            timeToExpire: default,
                            expiresOn: default,
                            encryptionContext: default,
                            conditions: options?.OpenConditions,
                            async: async,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

                        position = 0;
                        eTag = createResponse.Value.ETag;
                    }
                }

                DataLakeRequestConditions conditions = new DataLakeRequestConditions
                {
                    IfMatch = eTag,
                    LeaseId = options?.OpenConditions?.LeaseId
                };

                return new DataLakeFileWriteStream(
                    fileClient: this,
                    bufferSize: options?.BufferSize ?? Constants.DefaultBufferSize,
                    position: position,
                    conditions: conditions,
                    progressHandler: options?.ProgressHandler,
                    validationOptions: options?.TransferValidation ?? ClientConfiguration.TransferValidation.Upload,
                    closeEvent: options?.Close);
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

        #region PartitionedUploader
        internal PartitionedUploader<DataLakeFileUploadOptions, PathInfo> GetPartitionedUploader(
            StorageTransferOptions transferOptions,
            UploadTransferValidationOptions validationOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
            => new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>(
                GetPartitionedUploaderBehaviors(this),
                transferOptions,
                validationOptions,
                arrayPool,
                operationName);

        // static because it makes mocking easier in tests
        internal static PartitionedUploader<DataLakeFileUploadOptions, PathInfo>.Behaviors GetPartitionedUploaderBehaviors(DataLakeFileClient client)
            => new PartitionedUploader<DataLakeFileUploadOptions, PathInfo>.Behaviors
            {
                InitializeDestination = async (args, async, cancellationToken)
                    => await client.CreateInternal(
                        resourceType: PathResourceType.File,
                        httpHeaders: args.HttpHeaders,
                        metadata: args.Metadata,
                        permissions: args.Permissions,
                        umask: args.Umask,
                        owner: default,
                        group: default,
                        accessControlList: default,
                        leaseId: default,
                        leaseDuration: default,
                        timeToExpire: default,
                        expiresOn: default,
                        encryptionContext: args.EncryptionContext,
                        conditions: args.Conditions,
                        async: async,
                        cancellationToken: cancellationToken).ConfigureAwait(false),
                SingleUploadStreaming = async (stream, args, progressHandler, validationOptions, operationName, async, cancellationToken) =>
                {
                    // After the File is Create, Lease ID is the only valid request parameter.
                    if (args?.Conditions != null)
                        args.Conditions = new DataLakeRequestConditions { LeaseId = args.Conditions.LeaseId };

                    long newPosition = stream.Length - stream.Position;

                    // Append data
                    await client.AppendInternal(
                        stream,
                        offset: 0,
                        validationOptions,
                        args?.Conditions?.LeaseId,
                        leaseAction: null,
                        leaseDuration: null,
                        proposedLeaseId: null,
                        progressHandler,
                        flush: null,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    // Flush data
                    return await client.FlushInternal(
                        position: newPosition,
                        retainUncommittedData: default,
                        close: args.Close,
                        args.HttpHeaders,
                        args.Conditions,
                        leaseAction: null,
                        leaseDuration: null,
                        proposedLeaseId: null,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                },
                SingleUploadBinaryData = async (content, args, progressHandler, validationOptions, operationName, async, cancellationToken) =>
                {
                    // After the File is Create, Lease ID is the only valid request parameter.
                    if (args?.Conditions != null)
                        args.Conditions = new DataLakeRequestConditions { LeaseId = args.Conditions.LeaseId };

                    long newPosition = content.ToMemory().Length;

                    // Append data
                    await client.AppendInternal(
                        content.ToStream(),
                        offset: 0,
                        validationOptions,
                        args?.Conditions?.LeaseId,
                        leaseAction: null,
                        leaseDuration: null,
                        proposedLeaseId: null,
                        progressHandler,
                        flush: null,
                        async,
                        cancellationToken).ConfigureAwait(false);

                    // Flush data
                    return await client.FlushInternal(
                        position: newPosition,
                        retainUncommittedData: default,
                        close: args.Close,
                        args.HttpHeaders,
                        args.Conditions,
                        leaseAction: null,
                        leaseDuration: null,
                        proposedLeaseId: null,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                },
                UploadPartitionStreaming = async (stream, offset, args, progressHandler, validationOptions, async, cancellationToken)
                    => await client.AppendInternal(
                        stream,
                        offset,
                        validationOptions,
                        args?.Conditions?.LeaseId,
                        leaseAction: null,
                        leaseDuration: null,
                        proposedLeaseId: null,
                        progressHandler,
                        flush: null,
                        async,
                        cancellationToken).ConfigureAwait(false),
                UploadPartitionBinaryData = async (content, offset, args, progressHandler, validationOptions, async, cancellationToken)
                    => await client.AppendInternal(
                        content.ToStream(),
                        offset,
                        validationOptions,
                        args?.Conditions?.LeaseId,
                        leaseAction: null,
                        leaseDuration: null,
                        proposedLeaseId: null,
                        progressHandler,
                        flush: null,
                        async,
                        cancellationToken).ConfigureAwait(false),
                CommitPartitionedUpload = async (partitions, args, async, cancellationToken) =>
                {
                    (var offset, var size) = partitions.LastOrDefault();

                    // After the File is Create, Lease ID is the only valid request parameter.
                    if (args?.Conditions != null)
                        args.Conditions = new DataLakeRequestConditions { LeaseId = args.Conditions.LeaseId };

                    return await client.FlushInternal(
                        offset + size,
                        retainUncommittedData: default,
                        close: args.Close,
                        httpHeaders: args.HttpHeaders,
                        conditions: args.Conditions,
                        leaseAction: null,
                        leaseDuration: null,
                        proposedLeaseId: null,
                        async,
                        cancellationToken).ConfigureAwait(false);
                },
                Scope = operationName => client.ClientConfiguration.ClientDiagnostics.CreateScope(operationName ??
                    $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Files)}.{nameof(DataLake)}.{nameof(DataLakeFileClient)}.{nameof(DataLakeFileClient.Upload)}")
            };
        #endregion
    }
}
