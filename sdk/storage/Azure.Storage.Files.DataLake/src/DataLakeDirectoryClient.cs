// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// A DirectoryClient represents a URI to the Azure DataLake service allowing you to manipulate a directory.
    /// </summary>
    public class DataLakeDirectoryClient : DataLakePathClient
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class for mocking.
        /// </summary>
        protected DataLakeDirectoryClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
        /// </param>
        public DataLakeDirectoryClient(Uri directoryUri)
            : this(directoryUri, (HttpPipelinePolicy)null, null, storageSharedKeyCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
        /// </param>
        /// <param name="options">
        /// Optional <see cref="DataLakeClientOptions"/> that define the transport
        /// pipeline policies for authentication, retries, etc., that are
        /// applied to every request.
        /// </param>
        public DataLakeDirectoryClient(Uri directoryUri, DataLakeClientOptions options)
            : this(directoryUri, (HttpPipelinePolicy)null, options, storageSharedKeyCredential: null)
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
        /// <param name="directoryPath">
        /// The path to the directory.
        /// </param>
        public DataLakeDirectoryClient(
            string connectionString,
            string fileSystemName,
            string directoryPath)
            : this(connectionString, fileSystemName, directoryPath, null)
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
        /// <param name="directoryPath">
        /// The path to the directory.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeDirectoryClient(
            string connectionString,
            string fileSystemName,
            string directoryPath,
            DataLakeClientOptions options)
            : base(connectionString, fileSystemName, directoryPath, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        public DataLakeDirectoryClient(Uri directoryUri, StorageSharedKeyCredential credential)
            : base(directoryUri, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeDirectoryClient(Uri directoryUri, StorageSharedKeyCredential credential, DataLakeClientOptions options)
            : this(directoryUri, credential.AsPolicy(), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public DataLakeDirectoryClient(Uri directoryUri, AzureSasCredential credential)
            : this(directoryUri, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
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
        public DataLakeDirectoryClient(Uri directoryUri, AzureSasCredential credential, DataLakeClientOptions options)
            : this(directoryUri, credential.AsPolicy<DataLakeUriBuilder>(directoryUri), options, credential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        public DataLakeDirectoryClient(Uri directoryUri, TokenCredential credential)
            : this(directoryUri, credential, new DataLakeClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeDirectoryClient(Uri directoryUri, TokenCredential credential, DataLakeClientOptions options)
            : this(
                directoryUri,
                credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? DataLakeAudience.DefaultAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                options,
                tokenCredential: credential)
        {
            Errors.VerifyHttpsTokenAuth(directoryUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
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
        internal DataLakeDirectoryClient
            (Uri directoryUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential)
            : base(
                  directoryUri,
                  authentication,
                  options,
                  storageSharedKeyCredential: storageSharedKeyCredential,
                  sasCredential: null,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
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
        internal DataLakeDirectoryClient
            (Uri directoryUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            AzureSasCredential sasCredential)
            : base(
                  directoryUri,
                  authentication,
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: sasCredential,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
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
        internal DataLakeDirectoryClient
            (Uri directoryUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            TokenCredential tokenCredential)
            : base(
                  directoryUri,
                  authentication,
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: tokenCredential)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class.
        /// </summary>
        /// <param name="directoryUri">
        /// A <see cref="Uri"/> referencing the directory that includes the
        /// name of the account, the name of the file system, and the path of the
        /// directory.
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="DataLakeClientConfiguration"/>.
        /// </param>
        internal DataLakeDirectoryClient(
            Uri directoryUri,
            DataLakeClientConfiguration clientConfiguration)
            : base(
                  directoryUri,
                  clientConfiguration)
        {
        }

        internal DataLakeDirectoryClient(
            Uri fileSystemUri,
            string directoryPath,
            DataLakeClientConfiguration clientConfiguration)
            : base(
                  fileSystemUri,
                  directoryPath,
                  clientConfiguration)
        {
        }
        #endregion ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeDirectoryClient"/>
        /// class with an identical <see cref="Uri"/> source but the specified
        /// <paramref name="customerProvidedKey"/>.
        ///
        /// </summary>
        /// <param name="customerProvidedKey">The customer provided key.</param>
        /// <returns>A new <see cref="DataLakeDirectoryClient"/> instance.</returns>
        /// <remarks>
        /// Pass null to remove the customer provide key in the returned <see cref="DataLakeDirectoryClient"/>.
        /// </remarks>
        public new DataLakeDirectoryClient WithCustomerProvidedKey(Models.DataLakeCustomerProvidedKey? customerProvidedKey)
        {
            DataLakeClientConfiguration newClientConfiguration = DataLakeClientConfiguration.DeepCopy(ClientConfiguration);
            newClientConfiguration.CustomerProvidedKey = customerProvidedKey;
            return new DataLakeDirectoryClient(
                directoryUri: Uri,
                clientConfiguration: newClientConfiguration);
        }

        /// <summary>
        /// Creates a new <see cref="DataLakeFileClient"/> object by appending
        /// <paramref name="fileName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="DataLakeFileClient"/> uses the same request policy
        /// pipeline as the <see cref="DataLakeDirectoryClient"/>.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>A new <see cref="DataLakeFileClient"/> instance.</returns>
        public virtual DataLakeFileClient GetFileClient(string fileName)
            => new DataLakeFileClient(
                Uri,
                $"{Path}/{fileName}",
                ClientConfiguration);

        /// <summary>
        /// Creates a new <see cref="DataLakeDirectoryClient"/> object by appending
        /// <paramref name="subdirectoryName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="DataLakeDirectoryClient"/> uses the same request policy
        /// pipeline as the <see cref="DataLakeDirectoryClient"/>.
        /// </summary>
        /// <param name="subdirectoryName">The name of the subdirectory.</param>
        /// <returns>A new <see cref="DataLakeDirectoryClient"/> instance.</returns>
        public virtual DataLakeDirectoryClient GetSubDirectoryClient(string subdirectoryName)
            => new DataLakeDirectoryClient(
                Uri,
                $"{Path}/{subdirectoryName}",
                ClientConfiguration);

        #region Create
        /// <summary>
        /// The <see cref="Create(DataLakePathCreateOptions, CancellationToken)"/> operation creates a directory.
        /// If the directory already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing directory, consider using the <see cref="CreateIfNotExists(DataLakePathCreateOptions, CancellationToken)"/> API.
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
        /// newly created directory.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return base.Create(
                    resourceType: PathResourceType.Directory,
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
        /// The <see cref="CreateAsync(DataLakePathCreateOptions, CancellationToken)"/> operation creates a directory.
        /// If the directory already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing directory, consider using the <see cref="CreateIfNotExistsAsync(DataLakePathCreateOptions, CancellationToken)"/> API.
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
        /// newly created directory.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return await base.CreateAsync(
                    resourceType: PathResourceType.Directory,
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
        /// The <see cref="Create(PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/>
        /// operation creates a directory.
        /// If the directory already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing directory, consider using the <see cref="CreateIfNotExists(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> API.
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
        /// newly created directory.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return base.Create(
                    PathResourceType.Directory,
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
        /// The <see cref="CreateAsync(PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/>
        /// operation creates a directory.
        /// If the directory already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing directory, consider using the <see cref="CreateIfNotExistsAsync(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> API.
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
        /// newly created directory.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(Create)}");

            try
            {
                scope.Start();

                return await base.CreateAsync(
                    PathResourceType.Directory,
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
        /// The <see cref="CreateIfNotExists(DataLakePathCreateOptions, CancellationToken)"/> operation creates a file or directory.
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
        /// newly created directory.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateIfNotExists)}");
            try
            {
                scope.Start();

                return base.CreateIfNotExists(
                    resourceType: PathResourceType.Directory,
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
        /// The <see cref="CreateIfNotExistsAsync(DataLakePathCreateOptions, CancellationToken)"/> operation creates a file or directory.
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
        /// newly created directory.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateIfNotExists)}");
            try
            {
                scope.Start();

                return await base.CreateIfNotExistsAsync(
                    resourceType: PathResourceType.Directory,
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
        /// The <see cref="CreateIfNotExists(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> operation creates a file or directory.
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
        /// newly created directory.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateIfNotExists)}");
            try
            {
                scope.Start();

                return base.CreateIfNotExists(
                    PathResourceType.Directory,
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
        /// The <see cref="CreateIfNotExistsAsync(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> operation creates a file or directory.
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
        /// newly created directory.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateIfNotExists)}");
            try
            {
                scope.Start();

                return await base.CreateIfNotExistsAsync(
                    PathResourceType.Directory,
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(Delete)}");

            try
            {
                scope.Start();

                return base.Delete(
                    recursive: true,
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(Delete)}");

            try
            {
                scope.Start();

                return await base.DeleteAsync(
                    recursive: true,
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
        /// The <see cref="DeleteIfExists"/> operation marks the specified directory
        /// for deletion, if the directory exists.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(DeleteIfExists)}");

            try
            {
                scope.Start();

                return base.DeleteIfExists(
                    recursive: true,
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
        /// The <see cref="DeleteIfExistsAsync"/> operation marks the specified directory
        /// for deletion, if the directory exists.
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(DeleteIfExists)}");

            try
            {
                scope.Start();

                return await base.DeleteIfExistsAsync(
                    recursive: true,
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
        #endregion Delete If Exists

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
        /// A <see cref="Response{DataLakeDirectoryClient}"/> for the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public new virtual Response<DataLakeDirectoryClient> Rename(
            string destinationPath,
            string destinationFileSystem = default,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(Rename)}");

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
                    new DataLakeDirectoryClient(response.Value.DfsUri, response.Value.ClientConfiguration),
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
        /// A <see cref="Response{DataLakeDirectoryClient}"/> for
        /// the newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public new virtual async Task<Response<DataLakeDirectoryClient>> RenameAsync(
            string destinationPath,
            string destinationFileSystem = default,
            DataLakeRequestConditions sourceConditions = default,
            DataLakeRequestConditions destinationConditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(Rename)}");

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
                    new DataLakeDirectoryClient(response.Value.DfsUri, response.Value.ClientConfiguration),
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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(GetAccessControl)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(GetAccessControl)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(SetAccessControlList)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(SetAccessControlList)}");

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
            PathPermissions permissions = default,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(SetPermissions)}");

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
            PathPermissions permissions = default,
            string owner = default,
            string group = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(SetPermissions)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(GetProperties)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(GetProperties)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(SetHttpHeaders)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(SetHttpHeaders)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(SetMetadata)}");

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
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(SetMetadata)}");

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

        #region Create File
        /// <summary>
        /// The <see cref="CreateFile(string, DataLakePathCreateOptions, CancellationToken)"/> operation creates a file in this directory.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="DataLakeFileClient.CreateIfNotExistsAsync(DataLakePathCreateOptions, CancellationToken)"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file to create.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileClient}"/> for the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileClient> CreateFile(
            string fileName,
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateFile)}");

            try
            {
                scope.Start();

                DataLakeFileClient fileClient = GetFileClient(fileName);

                Response<PathInfo> response = fileClient.Create(
                    options: options,
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    fileClient,
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
        /// The <see cref="CreateFileAsync(string, DataLakePathCreateOptions, CancellationToken)"/> operation creates a new file in this directory.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="DataLakeFileClient.CreateIfNotExistsAsync(DataLakePathCreateOptions, CancellationToken)"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file to create.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeFileClient}"/> for the
        /// newly created file.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileClient>> CreateFileAsync(
            string fileName,
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateFile)}");

            try
            {
                scope.Start();

                DataLakeFileClient fileClient = GetFileClient(fileName);

                Response<PathInfo> response = await fileClient.CreateAsync(
                    options: options,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    fileClient,
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
        /// The <see cref="CreateFile(string, PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/> operation creates a file in this directory.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="DataLakeFileClient.CreateIfNotExists(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file to create.
        /// </param>
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
        /// A <see cref="Response{DataLakeFileClient}"/> for the
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
        public virtual Response<DataLakeFileClient> CreateFile(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string fileName,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateFile)}");

            try
            {
                scope.Start();

                DataLakeFileClient fileClient = GetFileClient(fileName);

                Response<PathInfo> response = fileClient.Create(
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    fileClient,
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
        /// The <see cref="CreateFileAsync(string, PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/> operation creates a new file in this directory.
        /// If the file already exists, it will be overwritten.  If you don't intent to overwrite
        /// an existing file, consider using the <see cref="DataLakeFileClient.CreateIfNotExistsAsync(PathHttpHeaders, Metadata, string, string, CancellationToken)"/> API.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="fileName">
        /// Name of the file to create.
        /// </param>
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
        /// A <see cref="Response{DataLakeFileClient}"/> for the
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
        public virtual async Task<Response<DataLakeFileClient>> CreateFileAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string fileName,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateFile)}");

            try
            {
                scope.Start();

                DataLakeFileClient fileClient = GetFileClient(fileName);

                Response<PathInfo> response = await fileClient.CreateAsync(
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    fileClient,
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
        #endregion Create File

        #region Delete File
        /// <summary>
        /// The <see cref="DeleteFile"/> operation deletes a file
        /// in this directory.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file to delete.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response DeleteFile(
            string fileName,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(DeleteFile)}");

            try
            {
                scope.Start();

                return GetFileClient(fileName).Delete(
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
        /// The <see cref="DeleteFileAsync"/> operation deletes a file
        /// in this directory.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file to delete.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response> DeleteFileAsync(
            string fileName,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(DeleteFile)}");

            try
            {
                scope.Start();

                return await GetFileClient(fileName).DeleteAsync(
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
        #endregion Delete File

        #region Create Sub Directory
        /// <summary>
        /// The <see cref="CreateSubDirectory(string, DataLakePathCreateOptions, CancellationToken)"/>
        /// operation creates a sub directory in this directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to create.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeDirectoryClient}"/> for the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeDirectoryClient> CreateSubDirectory(
            string path,
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateSubDirectory)}");

            try
            {
                scope.Start();

                DataLakeDirectoryClient directoryClient = GetSubDirectoryClient(path);

                Response<PathInfo> response = directoryClient.Create(
                    resourceType: PathResourceType.Directory,
                    options: options,
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    directoryClient,
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
        /// The <see cref="CreateSubDirectoryAsync(string, DataLakePathCreateOptions, CancellationToken)"/>
        /// operation creates a sub directory in this directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to create.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeDirectoryClient}"/> for the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeDirectoryClient>> CreateSubDirectoryAsync(
            string path,
            DataLakePathCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateSubDirectory)}");

            try
            {
                scope.Start();

                DataLakeDirectoryClient directoryClient = GetSubDirectoryClient(path);

                Response<PathInfo> response = await directoryClient.CreateAsync(
                    resourceType: PathResourceType.Directory,
                    options: options,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    directoryClient,
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
        /// The <see cref="CreateSubDirectory(string, PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/>
        /// operation creates a sub directory in this directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to create.
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
        /// A <see cref="Response{DataLakeDirectoryClient}"/> for the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<DataLakeDirectoryClient> CreateSubDirectory(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string path,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateSubDirectory)}");

            try
            {
                scope.Start();

                DataLakeDirectoryClient directoryClient = GetSubDirectoryClient(path);

                Response<PathInfo> response = directoryClient.Create(
                    PathResourceType.Directory,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken);

                return Response.FromValue(
                    directoryClient,
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
        /// The <see cref="CreateSubDirectoryAsync(string, PathHttpHeaders, Metadata, string, string, DataLakeRequestConditions, CancellationToken)"/>
        /// operation creates a sub directory in this directory.
        ///
        /// For more information, see https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/create.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to create.
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
        /// A <see cref="Response{DataLakeDirectoryClient}"/> for the
        /// newly created directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<DataLakeDirectoryClient>> CreateSubDirectoryAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string path,
            PathHttpHeaders httpHeaders,
            Metadata metadata,
            string permissions,
            string umask,
            DataLakeRequestConditions conditions,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(CreateSubDirectory)}");

            try
            {
                scope.Start();

                DataLakeDirectoryClient directoryClient = GetSubDirectoryClient(path);

                Response<PathInfo> response = await directoryClient.CreateAsync(
                    PathResourceType.Directory,
                    httpHeaders,
                    metadata,
                    permissions,
                    umask,
                    conditions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    directoryClient,
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
        #endregion Create Sub Directory

        #region Delete Sub Directory
        /// <summary>
        /// The <see cref="DeleteSubDirectory"/> deletes a sub directory in this directory.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to delete.
        /// </param>
        /// <param name="continuation">
        /// Optional. When deleting a directory, the number of paths that are deleted with each invocation is limited.
        /// If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.
        /// When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete
        /// operation to continue deleting the directory.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response DeleteSubDirectory(
            string path,
            string continuation = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(DeleteSubDirectory)}");

            try
            {
                scope.Start();

                return GetSubDirectoryClient(path).Delete(
                    recursive: true,
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
        /// The <see cref="DeleteSubDirectoryAsync"/> deletes a sub directory in this directory.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/path/delete">
        /// Delete Path</see>.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to delete.
        /// </param>
        /// <param name="continuation">
        /// Optional. When deleting a directory, the number of paths that are deleted with each invocation is limited.
        /// If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.
        /// When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete
        /// operation to continue deleting the directory.
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
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response> DeleteSubDirectoryAsync(
            string path,
            string continuation = default,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeDirectoryClient)}.{nameof(DeleteSubDirectory)}");

            try
            {
                scope.Start();

                return await GetSubDirectoryClient(path).DeleteAsync(
                    recursive: true,
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
        #endregion Delete Sub Directory

        #region Get Paths
        /// <summary>
        /// The <see cref="GetPaths(DataLakeGetPathsOptions, CancellationToken)"/> operation returns an async sequence
        /// of paths in this directory.  Enumerating the paths may make
        /// multiple requests to the service while fetching all the values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/datalakestoragegen2/path/list">
        /// List Path(s)</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{PathItem}"/>
        /// describing the paths in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Pageable<PathItem> GetPaths(
            DataLakeGetPathsOptions options = default,
            CancellationToken cancellationToken = default) =>
            new GetPathsAsyncCollection(
                FileSystemClient,
                Path,
                options?.Recursive,
                options?.UserPrincipalName,
                options?.StartFrom,
                $"{nameof(DataLakeDirectoryClient)}.{nameof(GetPaths)}")
            .ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetPathsAsync(DataLakeGetPathsOptions, CancellationToken)"/> operation returns an async sequence
        /// of paths in this directory.  Enumerating the paths may make
        /// multiple requests to the service while fetching all the values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/datalakestoragegen2/path/list">
        /// List Path(s)</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{PathItem}"/>
        /// describing the paths in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual AsyncPageable<PathItem> GetPathsAsync(
            DataLakeGetPathsOptions options = default,
            CancellationToken cancellationToken = default) =>
            new GetPathsAsyncCollection(
                FileSystemClient,
                Path,
                options?.Recursive,
                options?.UserPrincipalName,
                options?.StartFrom,
                $"{nameof(DataLakeDirectoryClient)}.{nameof(GetPaths)}")
            .ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetPathsAsync(bool, bool, CancellationToken)"/> operation returns an async sequence
        /// of paths in this directory.  Enumerating the paths may make
        /// multiple requests to the service while fetching all the values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/datalakestoragegen2/path/list">
        /// List Path(s)</see>.
        /// </summary>
        /// <param name="recursive">
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </param>
        /// <param name="userPrincipalName">
        /// Optional. Valid only when Hierarchical Namespace is enabled for the account. If
        /// "true", the user identity values returned in the owner and group fields of each list
        /// entry will be transformed from Azure Active Directory Object IDs to User Principal
        /// Names. If "false", the values will be returned as Azure Active Directory Object IDs.
        /// The default value is false. Note that group and application Object IDs are not translated
        /// because they do not have unique friendly names.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{PathItem}"/>
        /// describing the paths in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<PathItem> GetPaths(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            bool recursive,
            bool userPrincipalName,
            CancellationToken cancellationToken) =>
            new GetPathsAsyncCollection(
                FileSystemClient,
                Path,
                recursive,
                userPrincipalName,
                beginFrom: default,
                $"{nameof(DataLakeDirectoryClient)}.{nameof(GetPaths)}")
            .ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetPathsAsync(bool, bool, CancellationToken)"/> operation returns an async sequence
        /// of paths in this directory.  Enumerating the paths may make
        /// multiple requests to the service while fetching all the values.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/datalakestoragegen2/path/list">
        /// List Path(s)</see>.
        /// </summary>
        /// <param name="recursive">
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </param>
        /// <param name="userPrincipalName">
        /// Optional. Valid only when Hierarchical Namespace is enabled for the account. If
        /// "true", the user identity values returned in the owner and group fields of each list
        /// entry will be transformed from Azure Active Directory Object IDs to User Principal
        /// Names. If "false", the values will be returned as Azure Active Directory Object IDs.
        /// The default value is false. Note that group and application Object IDs are not translated
        /// because they do not have unique friendly names.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="Pageable{PathItem}"/>
        /// describing the paths in the directory.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual AsyncPageable<PathItem> GetPathsAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            bool recursive,
            bool userPrincipalName,
            CancellationToken cancellationToken) =>
            new GetPathsAsyncCollection(
                FileSystemClient,
                Path,
                recursive,
                userPrincipalName,
                beginFrom: default,
                $"{nameof(DataLakeDirectoryClient)}.{nameof(GetPaths)}")
            .ToAsyncCollection(cancellationToken);
        #endregion Get Paths

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateSasUri(DataLakeSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Directory Service
        /// Shared Access Signature (SAS) Uri based on the Client properties and
        /// parameters passed. The SAS is signed by the shared key credential
        /// of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="DataLakePathClient.CanGenerateSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a service SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="DataLakeSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Uri GenerateSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn)
            => GenerateSasUri(permissions, expiresOn, out _);

        /// <summary>
        /// The <see cref="GenerateSasUri(DataLakeSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Directory Service
        /// Shared Access Signature (SAS) Uri based on the Client properties and
        /// parameters passed. The SAS is signed by the shared key credential
        /// of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="DataLakePathClient.CanGenerateSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a service SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="DataLakeSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Uri GenerateSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn, out string stringToSign) =>
            GenerateSasUri(new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = FileSystemName,
                Path = Path,
                IsDirectory = true
            }, out stringToSign);

        /// <summary>
        /// The <see cref="GenerateSasUri(DataLakeSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a DataLake Directory Service
        /// Shared Access Signature (SAS) Uri based on the Client properties
        /// and and builder. The SAS is signed by the shared key credential
        /// of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="DataLakePathClient.CanGenerateSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Uri GenerateSasUri(DataLakeSasBuilder builder)
            => GenerateSasUri(builder, out _);

        /// <summary>
        /// The <see cref="GenerateSasUri(DataLakeSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a DataLake Directory Service
        /// Shared Access Signature (SAS) Uri based on the Client properties
        /// and and builder. The SAS is signed by the shared key credential
        /// of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="DataLakePathClient.CanGenerateSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Uri GenerateSasUri(DataLakeSasBuilder builder, out string stringToSign)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));

            // Deep copy of builder so we don't modify the user's original DataLakeSasBuilder.
            builder = DataLakeSasBuilder.DeepCopy(builder);

            SetBuilderAndValidate(builder);
            DataLakeUriBuilder sasUri = new DataLakeUriBuilder(Uri)
            {
                Sas = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential, out stringToSign)
            };
            return sasUri.ToUri();
        }
        #endregion

        #region GenerateUserDelegationSas
        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(DataLakeSasPermissions, DateTimeOffset, UserDelegationKey)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Directory Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and parameter passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="DataLakeSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Uri GenerateUserDelegationSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn, UserDelegationKey userDelegationKey)
            => GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out _);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(DataLakeSasPermissions, DateTimeOffset, UserDelegationKey, out string)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Directory Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and parameter passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="DataLakeSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Uri GenerateUserDelegationSasUri(DataLakeSasPermissions permissions, DateTimeOffset expiresOn, UserDelegationKey userDelegationKey, out string stringToSign) =>
            GenerateUserDelegationSasUri(new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = FileSystemName,
                Path = Path,
                IsDirectory = true
            }, userDelegationKey, out stringToSign);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(DataLakeSasBuilder, UserDelegationKey)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Directory Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and builder passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Required. Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Uri GenerateUserDelegationSasUri(DataLakeSasBuilder builder, UserDelegationKey userDelegationKey)
            => GenerateUserDelegationSasUri(builder, userDelegationKey, out _);

        /// <summary>
        /// The <see cref="GenerateUserDelegationSasUri(DataLakeSasBuilder, UserDelegationKey, out string)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Directory Service Shared Access Signature (SAS)
        /// Uri based on the Client properties and builder passed. The SAS is signed by the user delegation key passed in.
        ///
        /// For more information, see
        /// <see href="https://learn.microsoft.com/en-us/rest/api/storageservices/create-user-delegation-sas">
        /// Creating an user delegation SAS</see>.
        /// </summary>
        /// <param name="builder">
        /// Required. Used to generate a Shared Access Signature (SAS).
        /// </param>
        /// <param name="userDelegationKey">
        /// Required. A <see cref="UserDelegationKey"/> returned from
        /// <see cref="DataLakeServiceClient.GetUserDelegationKeyAsync"/>.
        /// </param>
        /// <param name="stringToSign">
        /// For debugging purposes only.  This string will be overwritten with the string to sign that was used to generate the SAS Uri.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public override Uri GenerateUserDelegationSasUri(DataLakeSasBuilder builder, UserDelegationKey userDelegationKey, out string stringToSign)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            userDelegationKey = userDelegationKey ?? throw Errors.ArgumentNull(nameof(userDelegationKey));

            // Deep copy of builder so we don't modify the user's original DataLakeSasBuilder.
            builder = DataLakeSasBuilder.DeepCopy(builder);

            SetBuilderAndValidate(builder);
            if (string.IsNullOrEmpty(AccountName))
            {
                throw Errors.SasClientMissingData(nameof(AccountName));
            }

            DataLakeUriBuilder sasUri = new DataLakeUriBuilder(Uri)
            {
                Sas = builder.ToSasQueryParameters(userDelegationKey, AccountName, out stringToSign)
            };
            return sasUri.ToUri();
        }
        #endregion

        private void SetBuilderAndValidate(DataLakeSasBuilder builder)
        {
            // Assign builder's IsDirectory, FileSystemName, and Path, if they are null.
            builder.IsDirectory ??= GetType() == typeof(DataLakeDirectoryClient);
            builder.FileSystemName ??= FileSystemName;
            builder.Path ??= Path;

            // Validate that builder is properly set
            if (!builder.IsDirectory.GetValueOrDefault(false))
            {
                throw Errors.SasIncorrectResourceType(
                    nameof(builder),
                    nameof(builder.IsDirectory),
                    Constants.TrueName,
                    nameof(this.GetType));
            }
            if (!builder.FileSystemName.Equals(FileSystemName, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.FileSystemName),
                    nameof(DataLakeSasBuilder),
                    nameof(FileSystemName));
            }
            if (!builder.Path.Equals(Path, StringComparison.InvariantCulture))
            {
                throw Errors.SasNamesNotMatching(
                    nameof(builder.Path),
                    nameof(DataLakeSasBuilder),
                    nameof(Path));
            }
        }
    }
}
