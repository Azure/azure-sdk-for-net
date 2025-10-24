// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using PublicAccessType = Azure.Storage.Files.DataLake.Models.PublicAccessType;
using UserDelegationKey = Azure.Storage.Files.DataLake.Models.UserDelegationKey;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// The <see cref="DataLakeServiceClient"/> allows you to manipulate Azure
    /// Data Lake service resources and file systems. The storage account provides
    /// the top-level namespace for the Data Lake service.
    /// </summary>
    public class DataLakeServiceClient
    {
        /// <summary>
        /// The <see cref="BlobServiceClient"/> associated with the file system.
        /// </summary>
        private readonly BlobServiceClient _blobServiceClient;

        /// <summary>
        /// The Data Lake service's customer-provided <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// The Data Lake service's blob <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _blobUri;

        /// <summary>
        /// Gets the Data Lake service's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// <see cref="DataLakeClientConfiguration"/>.
        /// </summary>
        private readonly DataLakeClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="DataLakeClientConfiguration"/>.
        /// </summary>
        internal virtual DataLakeClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// The Storage account name corresponding to the file service client.
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Gets the Storage account name corresponding to the file service client.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                if (_accountName == null)
                {
                    _accountName = new DataLakeUriBuilder(Uri).AccountName;
                }
                return _accountName;
            }
        }

        /// <summary>
        /// Determines whether the client is able to generate a SAS.
        /// If the client is authenticated with a <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        public virtual bool CanGenerateAccountSasUri => ClientConfiguration.SharedKeyCredential != null;

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected DataLakeServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri)
            : this(
                  serviceUri,
                  (HttpPipelinePolicy)null,
                  options: null,
                  storageSharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, DataLakeClientOptions options)
            : this(
                  serviceUri,
                  (HttpPipelinePolicy)null,
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: null,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">Configure Azure Storage connection strings</see>.
        /// </param>
        public DataLakeServiceClient(string connectionString)
            : this(connectionString, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">Configure Azure Storage connection strings</see>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeServiceClient(string connectionString, DataLakeClientOptions options)
        {
            StorageConnectionString conn = StorageConnectionString.Parse(connectionString);
            StorageSharedKeyCredential sharedKeyCredential = conn.Credentials as StorageSharedKeyCredential;
            options ??= new DataLakeClientOptions();
            HttpPipelinePolicy authPolicy = sharedKeyCredential.AsPolicy();

            _clientConfiguration = new DataLakeClientConfiguration(
                pipeline: options.Build(authPolicy),
                sharedKeyCredential: sharedKeyCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                clientOptions: options,
                customerProvidedKey: options.CustomerProvidedKey);

            _uri = conn.BlobEndpoint;
            _accountName = conn.AccountName;
            _blobUri = new DataLakeUriBuilder(_uri).ToBlobUri();

            _blobServiceClient = BlobServiceClientInternals.Create(
                _blobUri,
                _clientConfiguration,
                authPolicy);

            DataLakeErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, StorageSharedKeyCredential credential)
            : this(serviceUri, credential, default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, StorageSharedKeyCredential credential, DataLakeClientOptions options)
            : this(
                  serviceUri,
                  credential.AsPolicy(),
                  options,
                  storageSharedKeyCredential: credential,
                  sasCredential: null,
                  tokenCredential: null)
        {
            _accountName ??= credential?.AccountName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public DataLakeServiceClient(Uri serviceUri, AzureSasCredential credential)
            : this(serviceUri, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
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
        public DataLakeServiceClient(Uri serviceUri, AzureSasCredential credential, DataLakeClientOptions options)
            : this(
                  serviceUri,
                  credential.AsPolicy<DataLakeUriBuilder>(serviceUri),
                  options,
                  storageSharedKeyCredential: null,
                  sasCredential: credential,
                  tokenCredential: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, TokenCredential credential)
            : this(serviceUri, credential, new DataLakeClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public DataLakeServiceClient(Uri serviceUri, TokenCredential credential, DataLakeClientOptions options)
            : this(
                serviceUri,
                credential.AsPolicy(
                    string.IsNullOrEmpty(options?.Audience?.ToString()) ? DataLakeAudience.DefaultAudience.CreateDefaultScope() : options.Audience.Value.CreateDefaultScope(),
                    options),
                options,
                storageSharedKeyCredential:null,
                sasCredential: null,
                tokenCredential: credential)
        {
            Errors.VerifyHttpsTokenAuth(serviceUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeFileSystemClient"/>
        /// class.
        /// </summary>
        /// <param name="fileSystemUri">
        /// A <see cref="Uri"/> referencing the file system that includes the
        /// name of the account and the name of the file system.
        /// </param>
        /// <param name="clientConfiguration">
        /// <see cref="DataLakeClientConfiguration"/>.
        /// </param>
        internal DataLakeServiceClient(
            Uri fileSystemUri,
            DataLakeClientConfiguration clientConfiguration)
        {
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemUri);
            _uri = fileSystemUri;
            _blobUri = uriBuilder.ToBlobUri();

            _clientConfiguration = clientConfiguration;

            _blobServiceClient = BlobServiceClientInternals.Create(
                _blobUri,
                _clientConfiguration,
                // auth is included in pipeline in client configuration.
                // blobs keeps it separate for niche use cases that are inaccessible from datalake clients
                authentication: default);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeServiceClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the Data Lake service.
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
        /// <param name="sasCredential">
        /// The SAS credential used to sign requests.
        /// </param>
        /// <param name="tokenCredential">
        /// The token credential used to sign requests.
        /// </param>
        internal DataLakeServiceClient(
            Uri serviceUri,
            HttpPipelinePolicy authentication,
            DataLakeClientOptions options,
            StorageSharedKeyCredential storageSharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(serviceUri, nameof(serviceUri));
            options ??= new DataLakeClientOptions();

            _uri = serviceUri;
            _blobUri = new DataLakeUriBuilder(serviceUri).ToBlobUri();

            _clientConfiguration = new DataLakeClientConfiguration(
                pipeline: options.Build(authentication),
                sharedKeyCredential: storageSharedKeyCredential,
                sasCredential: sasCredential,
                tokenCredential: tokenCredential,
                clientDiagnostics: new ClientDiagnostics(options),
                clientOptions: options,
                customerProvidedKey: options.CustomerProvidedKey);

            _blobServiceClient = BlobServiceClientInternals.Create(
                _blobUri,
                _clientConfiguration,
                authentication);

            DataLakeErrors.VerifyHttpsCustomerProvidedKey(_uri, _clientConfiguration.CustomerProvidedKey);
        }

        /// <summary>
        /// Helper to access protected static members of BlobServiceClient
        /// that should not be exposed directly to customers.
        /// </summary>
        private class BlobServiceClientInternals : BlobServiceClient
        {
            public static BlobServiceClient Create(
                Uri uri,
                DataLakeClientConfiguration clientConfiguration,
                HttpPipelinePolicy authentication)
            {
                return BlobServiceClient.CreateClient(
                    uri,
                    new BlobClientOptions(clientConfiguration.ClientOptions.Version.AsBlobsVersion())
                    {
                        Diagnostics = { IsDistributedTracingEnabled = clientConfiguration.ClientDiagnostics.IsActivityEnabled }
                    },
                    authentication,
                    clientConfiguration.Pipeline,
                    clientConfiguration.SharedKeyCredential,
                    clientConfiguration.SasCredential,
                    clientConfiguration.TokenCredential);
            }
        }
        #endregion ctors

        /// <summary>
        /// Create a new <see cref="DataLakeFileSystemClient"/> object by appending
        /// <paramref name="fileSystemName"/> to the end of <see cref="Uri"/>.
        /// The new <see cref="DataLakeFileSystemClient"/> uses the same request
        /// policy pipeline as the <see cref="DataLakeFileSystemClient"/>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the share to reference.
        /// </param>
        /// <returns>
        /// A <see cref="DataLakeFileSystemClient"/> for the desired share.
        /// </returns>
        public virtual DataLakeFileSystemClient GetFileSystemClient(string fileSystemName)
            => new DataLakeFileSystemClient(
                Uri.AppendToPath(fileSystemName),
                ClientConfiguration);

        #region Get User Delegation Key
        /// <summary>
        /// The <see cref="GetUserDelegationKey(DateTimeOffset, DataLakeGetUserDelegationKeyOptions, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.DataLakeSasBuilder"/>.
        /// </summary>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{UserDelegationKey}"/> describing
        /// the use delegation key.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
            DateTimeOffset expiresOn,
            DataLakeGetUserDelegationKeyOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(GetUserDelegationKey)}");

            try
            {
                scope.Start();

                BlobGetUserDelegationKeyOptions blobOptions = MapOptions(options);

                Response<Blobs.Models.UserDelegationKey> response = _blobServiceClient.GetUserDelegationKey(
                    expiresOn,
                    blobOptions,
                    cancellationToken);

                return Response.FromValue(
                    new UserDelegationKey(response.Value),
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
        /// The <see cref="GetUserDelegationKeyAsync(DateTimeOffset, DataLakeGetUserDelegationKeyOptions, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.DataLakeSasBuilder"/>.
        /// </summary>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{UserDelegationKey}"/> describing
        /// the use delegation key.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
            DateTimeOffset expiresOn,
            DataLakeGetUserDelegationKeyOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(GetUserDelegationKey)}");

            try
            {
                scope.Start();

                BlobGetUserDelegationKeyOptions blobOptions = MapOptions(options);

                Response<Blobs.Models.UserDelegationKey> response = await _blobServiceClient.GetUserDelegationKeyAsync(
                    expiresOn,
                    blobOptions,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    new UserDelegationKey(response.Value),
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
        /// The <see cref="GetUserDelegationKey(DateTimeOffset?, DateTimeOffset, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.DataLakeSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{UserDelegationKey}"/> describing
        /// the use delegation key.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called 'cancellationToken' or a RequestContext parameter called 'context'.
        public virtual Response<UserDelegationKey> GetUserDelegationKey(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called 'cancellationToken' or a RequestContext parameter called 'context'.
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(GetUserDelegationKey)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.UserDelegationKey> response = _blobServiceClient.GetUserDelegationKey(
                    startsOn,
                    expiresOn,
                    cancellationToken);

                return Response.FromValue(
                    new UserDelegationKey(response.Value),
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
        /// The <see cref="GetUserDelegationKeyAsync(DateTimeOffset?, DateTimeOffset, CancellationToken)"/> operation retrieves a
        /// key that can be used to delegate Active Directory authorization to
        /// shared access signatures created with <see cref="Sas.DataLakeSasBuilder"/>.
        /// </summary>
        /// <param name="startsOn">
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
        /// </param>
        /// <param name="expiresOn">
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{UserDelegationKey}"/> describing
        /// the use delegation key.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called 'cancellationToken' or a RequestContext parameter called 'context'.
        public virtual async Task<Response<UserDelegationKey>> GetUserDelegationKeyAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called 'cancellationToken' or a RequestContext parameter called 'context'.
            DateTimeOffset? startsOn,
            DateTimeOffset expiresOn,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(GetUserDelegationKey)}");

            try
            {
                scope.Start();

                Response<Blobs.Models.UserDelegationKey> response = await _blobServiceClient.GetUserDelegationKeyAsync(
                    startsOn,
                    expiresOn,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(
                    new UserDelegationKey(response.Value),
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

        private static BlobGetUserDelegationKeyOptions MapOptions(DataLakeGetUserDelegationKeyOptions options)
        {
            if (options == null)
                return null;
            return new BlobGetUserDelegationKeyOptions
            {
                StartsOn = options.StartsOn,
                DelegatedUserTenantId = options.DelegatedUserTenantId
            };
        }
        #endregion Get User Delegation Key

        #region Get File Systems
        /// <summary>
        /// The <see cref="GetFileSystems(FileSystemTraits, FileSystemStates, string, CancellationToken)"/>
        /// operation returns an async sequence of file systems in the storage account.  Enumerating the
        /// file systems may make multiple requests to the service while fetching
        /// all the values.  File systems are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the file systems.
        /// </param>
        /// <param name="states">
        /// Specifies state options for shaping the file systems.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only file systems
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{FileSystemItem}"/>
        /// describing the file systems in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual Pageable<FileSystemItem> GetFileSystems(
            FileSystemTraits traits = FileSystemTraits.None,
            FileSystemStates states = FileSystemStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetFileSystemsAsyncCollection(_blobServiceClient, traits, states, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetFileSystemsAsync(FileSystemTraits, FileSystemStates, string, CancellationToken)"/>
        /// operation returns an async sequence of file systems in the storage account.  Enumerating the
        /// files systems may make multiple requests to the service while fetching
        /// all the values.  File systems are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the file systems.
        /// </param>
        /// <param name="states">
        /// Specifies state options for shaping the file systems.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only file systems
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// file systems in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [ForwardsClientCalls]
        public virtual AsyncPageable<FileSystemItem> GetFileSystemsAsync(
            FileSystemTraits traits = FileSystemTraits.None,
            FileSystemStates states = FileSystemStates.None,
            string prefix = default,
            CancellationToken cancellationToken = default) =>
            new GetFileSystemsAsyncCollection(_blobServiceClient, traits, states, prefix).ToAsyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetFileSystems(FileSystemTraits, string, CancellationToken)"/>
        /// operation returns an async sequence of file systems in the storage account.
        /// Enumerating the file systems may make multiple requests to the service while fetching
        /// all the values.  File systems are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the file systems.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only file systems
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Response{FileSystemItem}"/>
        /// describing the file systems in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<FileSystemItem> GetFileSystems(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            FileSystemTraits traits,
            string prefix,
            CancellationToken cancellationToken) =>
            new GetFileSystemsAsyncCollection(_blobServiceClient, traits, default, prefix).ToSyncCollection(cancellationToken);

        /// <summary>
        /// The <see cref="GetFileSystemsAsync(FileSystemTraits, string, CancellationToken)"/>
        /// operation returns an async sequence of file systems in the storage account.
        /// Enumerating the files systems may make multiple requests to the service while fetching
        /// all the values.  File systems are ordered lexicographically by name.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/list-containers2">
        /// List Containers</see>.
        /// </summary>
        /// <param name="traits">
        /// Specifies trait options for shaping the file systems.
        /// </param>
        /// <param name="prefix">
        /// Specifies a string that filters the results to return only file systems
        /// whose name begins with the specified <paramref name="prefix"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> describing the
        /// file systems in the storage account.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual AsyncPageable<FileSystemItem> GetFileSystemsAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            FileSystemTraits traits,
            string prefix,
            CancellationToken cancellationToken) =>
            new GetFileSystemsAsyncCollection(_blobServiceClient, traits, default, prefix).ToAsyncCollection(cancellationToken);
        #endregion Get File Systems

        #region Create File System
        /// <summary>
        /// The <see cref="CreateFileSystem(string, DataLakeFileSystemCreateOptions, CancellationToken)"/>
        /// operation creates a new file system under the specified account. If the file systen with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to create.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemClient}"/> referencing the
        /// newly created file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileSystemClient> CreateFileSystem(
            string fileSystemName,
            DataLakeFileSystemCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(CreateFileSystem)}");

            try
            {
                scope.Start();

                DataLakeFileSystemClient fileSystem = GetFileSystemClient(fileSystemName);
                Response<FileSystemInfo> response = fileSystem.Create(
                    options,
                    cancellationToken);
                return Response.FromValue(fileSystem, response.GetRawResponse());
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
        /// The <see cref="CreateFileSystem(string, DataLakeFileSystemCreateOptions, CancellationToken)"/>
        /// operation creates a new
        /// file system under the specified account. If the file system with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to create.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemClient}"/> referencing the
        /// newly created file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileSystemClient>> CreateFileSystemAsync(
            string fileSystemName,
            DataLakeFileSystemCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(CreateFileSystem)}");

            try
            {
                scope.Start();

                DataLakeFileSystemClient fileSystem = GetFileSystemClient(fileSystemName);
                Response<FileSystemInfo> response = await fileSystem.CreateAsync(
                    options,
                    cancellationToken).ConfigureAwait(false);
                return Response.FromValue(fileSystem, response.GetRawResponse());
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
        /// The <see cref="CreateFileSystem(string, PublicAccessType, Metadata, CancellationToken)"/>
        /// operation creates a new file system under the specified account. If the file systen with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to create.
        /// </param>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file systems within the storage
        /// account.  <see cref="PublicAccessType.Path"/> specifies public
        /// read access for paths.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate paths within the file system via anonymous
        /// request.  <see cref="PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file system.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemClient}"/> referencing the
        /// newly created file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<DataLakeFileSystemClient> CreateFileSystem(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string fileSystemName,
            PublicAccessType publicAccessType,
            Metadata metadata,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(CreateFileSystem)}");

            try
            {
                scope.Start();

                DataLakeFileSystemClient fileSystem = GetFileSystemClient(fileSystemName);
                Response<FileSystemInfo> response = fileSystem.Create(
                    publicAccessType,
                    metadata,
                    cancellationToken);
                return Response.FromValue(fileSystem, response.GetRawResponse());
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
        /// The <see cref="CreateFileSystemAsync(string, DataLakeFileSystemCreateOptions, CancellationToken)"/>
        /// operation creates a new file system under the specified account. If the file system with the
        /// same name already exists, the operation fails.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-container">
        /// Create Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to create.
        /// </param>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file systems within the storage
        /// account.  <see cref="PublicAccessType.Path"/> specifies public
        /// read access for paths.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate paths within the file system via anonymous
        /// request.  <see cref="PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this file system.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{FileSystemClient}"/> referencing the
        /// newly created file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<DataLakeFileSystemClient>> CreateFileSystemAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            string fileSystemName,
            PublicAccessType publicAccessType,
            Metadata metadata,
            CancellationToken cancellationToken)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(CreateFileSystem)}");

            try
            {
                scope.Start();

                DataLakeFileSystemClient fileSystem = GetFileSystemClient(fileSystemName);
                Response<FileSystemInfo> response = await fileSystem.CreateAsync(
                    publicAccessType,
                    metadata,
                    cancellationToken).ConfigureAwait(false);
                return Response.FromValue(fileSystem, response.GetRawResponse());
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
        #endregion Create File System

        #region Delete File System
        /// <summary>
        /// The <see cref="DeleteFileSystem"/> operation marks the
        /// specified file system for deletion.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to delete.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the deletion of this file system.
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
        public virtual Response DeleteFileSystem(
            string fileSystemName,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(DeleteFileSystem)}");

            try
            {
                scope.Start();

                return GetFileSystemClient(fileSystemName)
                    .Delete(
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
        /// The <see cref="DeleteFileSystemAsync"/> operation marks the
        /// specified file system for deletion.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container">
        /// Delete Container</see>.
        /// </summary>
        /// <param name="fileSystemName">
        /// The name of the file system to delete.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the deletion of this file system.
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
        public virtual async Task<Response> DeleteFileSystemAsync(
            string fileSystemName,
            DataLakeRequestConditions conditions = default,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(DeleteFileSystem)}");

            try
            {
                scope.Start();

                return await GetFileSystemClient(fileSystemName)
                    .DeleteAsync(
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
        #endregion Delete File System

        #region Undelete File System
        /// <summary>
        /// Restores a previously deleted file system.
        /// This API is only functional is Container Soft Delete is enabled
        /// for the storage account associated with the filesystem.
        /// </summary>
        /// <param name="deletedFileSystemName">
        /// The name of the previously deleted file system.
        /// </param>
        /// <param name="deleteFileSystemVersion">
        /// The version of the previously deleted file system.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> pointed at the undeleted file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeFileSystemClient> UndeleteFileSystem(
            string deletedFileSystemName,
            string deleteFileSystemVersion,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(UndeleteFileSystem)}");

            try
            {
                scope.Start();

                Response<BlobContainerClient> response = _blobServiceClient.UndeleteBlobContainer(
                    deletedFileSystemName,
                    deleteFileSystemVersion,
                    cancellationToken);

                DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(
                    response.Value.Uri,
                    ClientConfiguration);

                return Response.FromValue(
                    fileSystemClient,
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
        /// Restores a previously deleted file system.
        /// This API is only functional is Container Soft Delete is enabled
        /// for the storage account associated with the filesystem.
        /// </summary>
        /// <param name="deletedFileSystemName">
        /// The name of the previously deleted file system.
        /// </param>
        /// <param name="deleteFileSystemVersion">
        /// The version of the previously deleted file system.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{BlobContainerClient}"/> pointed at the undeleted file system.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeFileSystemClient>> UndeleteFileSystemAsync(
            string deletedFileSystemName,
            string deleteFileSystemVersion,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(UndeleteFileSystem)}");

            try
            {
                scope.Start();

                Response<BlobContainerClient> response = await _blobServiceClient.UndeleteBlobContainerAsync(
                    deletedFileSystemName,
                    deleteFileSystemVersion,
                    cancellationToken)
                    .ConfigureAwait(false);

                DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(
                    response.Value.Uri,
                    ClientConfiguration);

                return Response.FromValue(
                    fileSystemClient,
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
        #endregion Undelete File System

        #region Rename File System
        ///// <summary>
        ///// Renames an existing Blob File System.
        ///// </summary>
        ///// <param name="sourceFileSystemName">
        ///// The name of the source File System.
        ///// </param>
        ///// <param name="destinationFileSystemName">
        ///// The name of the destination File System.
        ///// </param>
        ///// <param name="sourceConditions">
        ///// Optional <see cref="DataLakeRequestConditions"/> that
        ///// source file system has to meet to proceed with rename.
        ///// Note that LeaseId is the only request condition enforced by
        ///// this API.
        ///// </param>
        ///// <param name="cancellationToken">
        ///// Optional <see cref="CancellationToken"/> to propagate
        ///// notifications that the operation should be cancelled.
        ///// </param>
        ///// <returns>
        ///// A <see cref="Response{BlobContainerClient}"/> pointed at the renamed file system.
        ///// </returns>
        ///// <remarks>
        ///// A <see cref="RequestFailedException"/> will be thrown if
        ///// a failure occurs.
        ///// </remarks>
        //internal virtual Response<DataLakeFileSystemClient> RenameFileSystem(
        //    string sourceFileSystemName,
        //    string destinationFileSystemName,
        //    DataLakeRequestConditions sourceConditions = default,
        //    CancellationToken cancellationToken = default)
        //{
        //    DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(RenameFileSystem)}");

        //    try
        //    {
        //        scope.Start();

        //        Response<BlobContainerClient> response = _blobServiceClient.RenameBlobContainer(
        //            sourceFileSystemName,
        //            destinationFileSystemName,
        //            sourceConditions.ToBlobRequestConditions(),
        //            cancellationToken);

        //        DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(
        //            response.Value.Uri,
        //            Pipeline,
        //            SharedKeyCredential,
        //            Version,
        //            ClientDiagnostics);

        //        return Response.FromValue(
        //            fileSystemClient,
        //            response.GetRawResponse());
        //    }
        //    catch (Exception ex)
        //    {
        //        scope.Failed(ex);
        //        throw;
        //    }
        //    finally
        //    {
        //        scope.Dispose();
        //    }
        //}

        ///// <summary>
        ///// Renames an existing Blob File System.
        ///// </summary>
        ///// <param name="sourceFileSystemName">
        ///// The name of the source File System.
        ///// </param>
        ///// <param name="destinationFileSystemName">
        ///// The name of the destination File System.
        ///// </param>
        ///// <param name="sourceConditions">
        ///// Optional <see cref="DataLakeRequestConditions"/> that
        ///// source file system has to meet to proceed with rename.
        ///// Note that LeaseId is the only request condition enforced by
        ///// this API.
        ///// </param>
        ///// <param name="cancellationToken">
        ///// Optional <see cref="CancellationToken"/> to propagate
        ///// notifications that the operation should be cancelled.
        ///// </param>
        ///// <returns>
        ///// A <see cref="Response{BlobContainerClient}"/> pointed at the renamed file system.
        ///// </returns>
        ///// <remarks>
        ///// A <see cref="RequestFailedException"/> will be thrown if
        ///// a failure occurs.
        ///// </remarks>
        //internal virtual async Task<Response<DataLakeFileSystemClient>> RenameFileSystemAsync(
        //    string sourceFileSystemName,
        //    string destinationFileSystemName,
        //    DataLakeRequestConditions sourceConditions = default,
        //    CancellationToken cancellationToken = default)
        //{
        //    DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(RenameFileSystem)}");

        //    try
        //    {
        //        scope.Start();

        //        Response<BlobContainerClient> response = await _blobServiceClient.RenameBlobContainerAsync(
        //            sourceFileSystemName,
        //            destinationFileSystemName,
        //            sourceConditions.ToBlobRequestConditions(),
        //            cancellationToken)
        //            .ConfigureAwait(false);

        //        DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(
        //            response.Value.Uri,
        //            Pipeline,
        //            SharedKeyCredential,
        //            Version,
        //            ClientDiagnostics);

        //        return Response.FromValue(
        //            fileSystemClient,
        //            response.GetRawResponse());
        //    }
        //    catch (Exception ex)
        //    {
        //        scope.Failed(ex);
        //        throw;
        //    }
        //    finally
        //    {
        //        scope.Dispose();
        //    }
        //}
        #endregion Rename File System

        #region GenerateSas
        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasPermissions, DateTimeOffset, AccountSasResourceTypes)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Account
        /// Shared Access Signature (SAS) based on the Client properties
        /// and parameters passed. The SAS is signed by the
        /// shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateAccountSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing an Account SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Specifies the list of permissions that can be set in the SasBuilder
        /// See <see cref="DataLakeSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Specifies when to set the expires time in the sas builder.
        /// </param>
        /// <param name="resourceTypes">
        /// Specifies the resource types associated with the shared access signature.
        /// The user is restricted to operations on the specified resources.
        /// See <see cref="AccountSasResourceTypes"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the SAS Uri.
        /// </returns>
        /// <remarks>
        /// A <see cref="Exception"/> will be thrown if a failure occurs.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes)
            => GenerateAccountSasUri(permissions, expiresOn, resourceTypes, out _);

        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasPermissions, DateTimeOffset, AccountSasResourceTypes)"/>
        /// returns a <see cref="Uri"/> that generates a DataLake Account
        /// Shared Access Signature (SAS) based on the Client properties
        /// and parameters passed. The SAS is signed by the
        /// shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateAccountSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing an Account SAS</see>.
        /// </summary>
        /// <param name="permissions">
        /// Specifies the list of permissions that can be set in the SasBuilder
        /// See <see cref="DataLakeSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Specifies when to set the expires time in the sas builder.
        /// </param>
        /// <param name="resourceTypes">
        /// Specifies the resource types associated with the shared access signature.
        /// The user is restricted to operations on the specified resources.
        /// See <see cref="AccountSasResourceTypes"/>.
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
        public Uri GenerateAccountSasUri(
            AccountSasPermissions permissions,
            DateTimeOffset expiresOn,
            AccountSasResourceTypes resourceTypes,
            out string stringToSign) =>
            GenerateAccountSasUri(new AccountSasBuilder(
                permissions,
                expiresOn,
                AccountSasServices.Blobs,
                resourceTypes),
                out stringToSign);

        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a DataLake Account Shared Access Signature (SAS)
        /// based on the Client properties and builder passed.
        /// The SAS is signed by the shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateAccountSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing an Account SAS</see>.
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
        public Uri GenerateAccountSasUri(
            AccountSasBuilder builder)
            => GenerateAccountSasUri(builder, out _);

        /// <summary>
        /// The <see cref="GenerateAccountSasUri(AccountSasBuilder)"/> returns a <see cref="Uri"/>
        /// that generates a DataLake Account Shared Access Signature (SAS)
        /// based on the Client properties and builder passed.
        /// The SAS is signed by the shared key credential of the client.
        ///
        /// To check if the client is able to sign a Service Sas see
        /// <see cref="CanGenerateAccountSasUri"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas">
        /// Constructing an Account SAS</see>.
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
        public Uri GenerateAccountSasUri(
            AccountSasBuilder builder,
            out string stringToSign)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.Services.HasFlag(AccountSasServices.Blobs))
            {
                throw Errors.SasServiceNotMatching(
                    nameof(builder.Services),
                    nameof(builder),
                    nameof(AccountSasServices.Blobs));
            }
            DataLakeUriBuilder sasUri = new DataLakeUriBuilder(Uri);
            sasUri.Query = builder.ToSasQueryParameters(ClientConfiguration.SharedKeyCredential, out stringToSign).ToString();
            return sasUri.ToUri();
        }
        #endregion

        #region Get Service Properties
        /// <summary>
        /// The <see cref="GetProperties"/> operation gets the properties
        /// of a storage account’s Data Lake service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-properties">
        /// Get Blob Service Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<DataLakeServiceProperties> GetProperties(
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(GetProperties)}");
            try
            {
                scope.Start();
                Response<Azure.Storage.Blobs.Models.BlobServiceProperties> response = _blobServiceClient.GetProperties(cancellationToken);
                return Response.FromValue(
                    response.Value.ToDataLakeServiceProperties(),
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
        /// The <see cref="GetPropertiesAsync"/> operation gets the properties
        /// of a storage account’s Data Lake service, including properties for
        /// Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob-service-properties">
        /// Get Blob Service Properties</see>.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{DataLakeServiceProperties}"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<DataLakeServiceProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(GetProperties)}");
            try
            {
                scope.Start();
                Response<Azure.Storage.Blobs.Models.BlobServiceProperties> response
                    = await _blobServiceClient.GetPropertiesAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(
                    response.Value.ToDataLakeServiceProperties(),
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
        #endregion Get Service Properties

        #region Set Service Properties
        /// <summary>
        /// The <see cref="SetProperties"/> operation sets properties for
        /// a storage account’s Data Lake service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the Blob
        /// service that do not have a version specified.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-service-properties">
        /// Set Blob Service Properties</see>.
        /// </summary>
        /// <param name="properties">The Data Lake service properties.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual Response SetProperties(
            DataLakeServiceProperties properties,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(SetProperties)}");
            try
            {
                scope.Start();
                return _blobServiceClient.SetProperties(
                    properties.ToBlobServiceProperties(),
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
        /// The <see cref="SetPropertiesAsync"/> operation sets properties for
        /// a storage account’s Data Lake service endpoint, including properties
        /// for Storage Analytics, CORS (Cross-Origin Resource Sharing) rules
        /// and soft delete settings.  You can also use this operation to set
        /// the default request version for all incoming requests to the Blob
        /// service that do not have a version specified.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/set-blob-service-properties">
        /// Set Blob Service Properties</see>.
        /// </summary>
        /// <param name="properties">The Data Lake service properties.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing
        /// the service properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/storage-files-datalake")]
        public virtual async Task<Response> SetPropertiesAsync(
            DataLakeServiceProperties properties,
            CancellationToken cancellationToken = default)
        {
            DiagnosticScope scope = ClientConfiguration.ClientDiagnostics.CreateScope($"{nameof(DataLakeServiceClient)}.{nameof(SetProperties)}");
            try
            {
                scope.Start();
                return await _blobServiceClient.SetPropertiesAsync(
                    properties.ToBlobServiceProperties(),
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
        #endregion Set Service Properties
    }
}
