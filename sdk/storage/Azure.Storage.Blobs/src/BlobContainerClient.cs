// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// The <see cref="BlobContainerClient"/> allows you to manipulate Azure
    /// Storage containers and their blobs.
    /// </summary>
	public class BlobContainerClient
    {
        /// <summary>
        /// The Azure Storage name used to identify a storage account's root container.
        /// </summary>
        public const string RootContainerName = "$root";

        /// <summary>
        /// The Azure Storage name used to identify a storage account's logs container.
        /// </summary>
        public const string LogsContainerName = "$logs";

        /// <summary>
        /// Gets the container's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send 
        /// every request.
        /// </summary>
        internal readonly HttpPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        protected BlobContainerClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
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
        /// The name of the container in the storage account to reference.
        /// </param>
        public BlobContainerClient(string connectionString, string containerName)
            : this(connectionString, containerName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
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
        /// The name of the container in the storage account to reference.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobContainerClient(string connectionString, string containerName, BlobClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            var builder = new BlobUriBuilder(conn.BlobEndpoint) { ContainerName = containerName };
            this.Uri = builder.ToUri();
            this._pipeline = (options ?? new BlobClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="containerUri">
        /// A <see cref="Uri"/> referencing the container that includes the
        /// name of the account and the name of the container.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobContainerClient(Uri containerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            : this(containerUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="containerUri">
        /// A <see cref="Uri"/> referencing the container that includes the
        /// name of the account and the name of the container.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobContainerClient(Uri containerUri, TokenCredential credential, BlobClientOptions options = default)
            : this(containerUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="containerUri">
        /// A <see cref="Uri"/> referencing the container that includes the
        /// name of the account and the name of the container.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal BlobContainerClient(Uri containerUri, HttpPipelinePolicy authentication, BlobClientOptions options)
        {
            this.Uri = containerUri;
            this._pipeline = (options ?? new BlobClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerClient"/>
        /// class.
        /// </summary>
        /// <param name="containerUri">
        /// A <see cref="Uri"/> referencing the container that includes the
        /// name of the account and the name of the container.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal BlobContainerClient(Uri containerUri, HttpPipeline pipeline)
        {
            this.Uri = containerUri;
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Create a new <see cref="BlockBlobClient"/> object by appending
        /// <paramref name="blobName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="BlockBlobClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobName">The name of the block blob.</param>
        /// <returns>A new <see cref="BlockBlobClient"/> instance.</returns>
        public BlockBlobClient GetBlockBlobClient(string blobName) => new BlockBlobClient(this.Uri.AppendToPath(blobName), this._pipeline);

        /// <summary>
        /// The <see cref="CreateAsync"/> operation creates a new container
        /// under the specified account. If the container with the same name
        /// already exists, the operation fails.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/create-container"/>.
        /// </summary>
        /// <param name="publicAccessType">
        /// Optionally specifies whether data in the container may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.Container"/>
        /// specifies full public read access for container and blob data.
        /// Clients can enumerate blobs within the container via anonymous
        /// request, but cannot enumerate containers within the storage
        /// account.  <see cref="PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this container can be
        /// read via anonymous request, but container data is not available.
        /// Clients cannot enumerate blobs within the container via anonymous
        /// request.  If this parameter is null, container data is private to
        /// the account owner.
        /// </param>
        /// <param name="metadata">
        /// Optional custom metadata to set for this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ContainerInfo}}"/> describing the newly
        /// created container.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<ContainerInfo>> CreateAsync(
            PublicAccessType? publicAccessType = default,
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(publicAccessType)}: {publicAccessType}");
                try
                {
                    return await BlobRestClient.Container.CreateAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        access: publicAccessType,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="DeleteAsync"/> operation marks the specified
        /// container for deletion. The container and any blobs contained
        /// within it are later deleted during garbage collection.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/delete-container" />.
        /// </summary>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response}}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response> DeleteAsync(
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    if (accessConditions?.HttpAccessConditions?.IfMatch != default ||
                        accessConditions?.HttpAccessConditions?.IfNoneMatch != default)
                    {
                        throw Errors.BlobConditionsMustBeDefault(nameof(HttpAccessConditions.IfMatch), nameof(HttpAccessConditions.IfNoneMatch));
                    }

                    return await BlobRestClient.Container.DeleteAsync(
                        this._pipeline,
                        this.Uri,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetAccountInfoAsync"/> operation returns the sku
        /// name and account kind for the account of the container.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-account-information" />.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{AccountInfo}}"/> describing the account.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if a
        /// failure occurs.
        /// </remarks>
        public async Task<Response<AccountInfo>> GetAccountInfoAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(nameof(BlobContainerClient), message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await BlobRestClient.Container.GetAccountInfoAsync(
                        this._pipeline,
                        this.Uri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetPropertiesAsync"/> operation returns all
        /// user-defined metadata and system properties for the specified
        /// container. The data returned does not include the container's 
        /// list of blobs.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-properties" />.
        /// </summary>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on getting the container's properties.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ContainerItem}}"/> describing the
        /// container and its properties.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<ContainerItem>> GetPropertiesAsync(
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    // GetProperties returns a flattened set of properties
                    var response =
                        await BlobRestClient.Container.GetPropertiesAsync(
                            this._pipeline,
                            this.Uri,
                            leaseId: leaseAccessConditions?.LeaseId,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

                    // Turn the flattened properties into a ContainerItem
                    var uri = new BlobUriBuilder(this.Uri);
                    return new Response<ContainerItem>(
                        response.GetRawResponse(),
                        new ContainerItem(false)
                        {
                            Name = uri.ContainerName,
                            Metadata = response.Value.Metadata,
                            Properties = new ContainerProperties()
                            {
                                LastModified = response.Value.LastModified,
                                ETag = response.Value.ETag,
                                LeaseStatus = response.Value.LeaseStatus,
                                LeaseState = response.Value.LeaseState,
                                LeaseDuration = response.Value.LeaseDuration,
                                PublicAccess = response.Value.BlobPublicAccess,
                                HasImmutabilityPolicy = response.Value.HasImmutabilityPolicy,
                                HasLegalHold = response.Value.HasLegalHold
                            }
                        });
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="SetMetadataAsync"/> operation sets one or more
        /// user-defined name-value pairs for the specified container.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/set-container-metadata" />.
        /// </summary>
        /// <param name="metadata">
        /// Custom metadata to set for this container.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on the deletion of this container.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ContainerInfo}}}"/> if successful.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<ContainerInfo>> SetMetadataAsync(
            Metadata metadata,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    if (accessConditions?.HttpAccessConditions?.IfUnmodifiedSince != default ||
                        accessConditions?.HttpAccessConditions?.IfMatch != default ||
                        accessConditions?.HttpAccessConditions?.IfNoneMatch != default)
                    {
                        throw Errors.BlobConditionsMustBeDefault(
                            nameof(HttpAccessConditions.IfUnmodifiedSince),
                            nameof(HttpAccessConditions.IfMatch),
                            nameof(HttpAccessConditions.IfNoneMatch));
                    }

                    return await BlobRestClient.Container.SetMetadataAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="GetAccessPolicyAsync"/> operation gets the
        /// permissions for this container. The permissions indicate whether
        /// container data may be accessed publicly.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-container-acl" />.
        /// </summary>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="LeaseAccessConditions"/> to add
        /// conditions on getting the container's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ContainerAccessPolicy}}"/> describing
        /// the container's access policy.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<ContainerAccessPolicy>> GetAccessPolicyAsync(
            LeaseAccessConditions? leaseAccessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(leaseAccessConditions)}: {leaseAccessConditions}");
                try
                {
                    return await BlobRestClient.Container.GetAccessPolicyAsync(
                        this._pipeline,
                        this.Uri,
                        leaseId: leaseAccessConditions?.LeaseId,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }
        
        /// <summary>
        /// The <see cref="SetAccessPolicyAsync"/> operation sets the
        /// permissions for the specified container. The permissions indicate
        /// whether container data may be accessed publicly.
        /// 
        /// For more information, see <see href=" https://docs.microsoft.com/rest/api/storageservices/set-container-acl" />.
        /// </summary>
        /// <param name="accessType">
        /// Optionally specifies whether data in the container may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.Container"/>
        /// specifies full public read access for container and blob data.
        /// Clients can enumerate blobs within the container via anonymous
        /// request, but cannot enumerate containers within the storage
        /// account.  <see cref="PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this container can be
        /// read via anonymous request, but container data is not available.
        /// Clients cannot enumerate blobs within the container via anonymous
        /// request.  If this parameter is null, container data is private to
        /// the account owner.
        /// </param>
        /// <param name="permissions">
        /// Stored access policies that you can use to provide fine grained
        /// control over container permissions.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on setting this container's access policy.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ContainerInfo}}"/> describing the
        /// updated container.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<ContainerInfo>> SetAccessPolicyAsync(
            PublicAccessType? accessType = default,
            IEnumerable<SignedIdentifier> permissions = default,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(accessType)}: {accessType}");
                try
                {
                    if (accessConditions?.HttpAccessConditions?.IfMatch != default ||
                        accessConditions?.HttpAccessConditions?.IfNoneMatch != default)
                    {
                        throw Errors.BlobConditionsMustBeDefault(nameof(HttpAccessConditions.IfMatch), nameof(HttpAccessConditions.IfNoneMatch));
                    }

                    return await BlobRestClient.Container.SetAccessPolicyAsync(
                        this._pipeline,
                        this.Uri,
                        permissions: permissions,
                        leaseId: accessConditions?.LeaseAccessConditions?.LeaseId,
                        access: accessType ?? null,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="AcquireLeaseAsync"/> operation acquires a lease on
        /// the container for delete operations.  The lease
        /// <paramref name="duration"/> must be between 15 to 60 seconds, or
        /// infinite (-1).
        /// 
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the container and returns it.  If the container
        /// has an active lease, you can only request a new lease using the
        /// active lease ID as <paramref name="proposedId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or -1 for a lease
        /// that never expires.  A non-infinite lease can be between 15 and
        /// 60 seconds. A lease duration cannot be changed using
        /// <see cref="RenewLeaseAsync"/> or <see cref="ChangeLeaseAsync"/>.
        /// </param>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="StorageRequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{Lease}}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<Lease>> AcquireLeaseAsync(
            int duration,
            string proposedId = default,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(duration)}: {duration}\n" +
                    $"{nameof(proposedId)}: {proposedId}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    if (accessConditions?.HttpAccessConditions?.IfMatch != default ||
                        accessConditions?.HttpAccessConditions?.IfNoneMatch != default)
                    {
                        throw Errors.BlobConditionsMustBeDefault(nameof(HttpAccessConditions.IfMatch), nameof(HttpAccessConditions.IfNoneMatch));
                    }
                    return await BlobRestClient.Container.AcquireLeaseAsync(
                        this._pipeline,
                        this.Uri,
                        duration: duration,
                        proposedLeaseId: proposedId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="RenewLeaseAsync"/> operation renews the container's
        /// previously-acquired lease.
        /// 
        /// The lease can be renewed if the <paramref name="leaseId"/> 
        /// matches that associated with the container.  Note that the lease
        /// may be renewed even if it has expired as long as the container has
        /// not been leased again since the expiration of that lease.  When
        /// you renew a lease, the lease duration clock resets.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="leaseId">
        /// The ID of the lease to be renewed.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on renewing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{Lease}}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<Lease>> RenewLeaseAsync(
            string leaseId,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(leaseId)}: {leaseId}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    if (accessConditions?.HttpAccessConditions?.IfMatch != default ||
                        accessConditions?.HttpAccessConditions?.IfNoneMatch != default)
                    {
                        throw Errors.BlobConditionsMustBeDefault(nameof(HttpAccessConditions.IfMatch), nameof(HttpAccessConditions.IfNoneMatch));
                    }
                    return await BlobRestClient.Container.RenewLeaseAsync(
                        this._pipeline,
                        this.Uri,
                        leaseId: leaseId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ReleaseLeaseAsync"/> operation releases the 
        /// container's previously-acquired lease.
        /// 
        /// The lease may be released if the <paramref name="leaseId"/>
        /// matches that associated with the container.  Releasing the lease
        /// allows another client to immediately acquire the lease for the
        /// container as soon as the release is complete.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="leaseId">
        /// The ID of the lease to be released.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on releasing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{ContainerInfo}}"/> describing the
        /// updated container.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<ContainerInfo>> ReleaseLeaseAsync(
            string leaseId,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(leaseId)}: {leaseId}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    if (accessConditions?.HttpAccessConditions?.IfMatch != default ||
                        accessConditions?.HttpAccessConditions?.IfNoneMatch != default)
                    {
                        throw Errors.BlobConditionsMustBeDefault(nameof(HttpAccessConditions.IfMatch), nameof(HttpAccessConditions.IfNoneMatch));
                    }
                    return await BlobRestClient.Container.ReleaseLeaseAsync(
                        this._pipeline,
                        this.Uri,
                        leaseId: leaseId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="BreakLeaseAsync"/> operation breaks the container's
        /// previously-acquired lease (if it exists).
        /// 
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="period"/> is allowed to elapse, during which
        /// time no lease operation except <see cref="BreakLeaseAsync"/> and
        /// <see cref="ReleaseLeaseAsync"/> can be performed on the container.
        /// When a lease is successfully broken, the response indicates the
        /// interval in seconds until a new lease can be acquired.
        /// 
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a container lease that has been released.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="period">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on breaking a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{Lease}}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<Lease>> BreakLeaseAsync(
            int? period = default,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(period)}: {period}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    if (accessConditions?.HttpAccessConditions?.IfMatch != default ||
                        accessConditions?.HttpAccessConditions?.IfNoneMatch != default)
                    {
                        throw Errors.BlobConditionsMustBeDefault(nameof(HttpAccessConditions.IfMatch), nameof(HttpAccessConditions.IfNoneMatch));
                    }
                    return (await BlobRestClient.Container.BreakLeaseAsync(
                        this._pipeline,
                        this.Uri,
                        breakPeriod: period,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false))
                        .ToLease();
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ChangeLeaseAsync"/> operation changes the lease 
        /// of an active lease.  A change must include the current
        /// <paramref name="leaseId"/> and a new
        /// <paramref name="proposedId"/>.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="leaseId">
        /// The ID of the lease to be changed.
        /// </param>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="StorageRequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="accessConditions">
        /// Optional <see cref="ContainerAccessConditions"/> to add
        /// conditions on changing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{Lease}}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<Lease>> ChangeLeaseAsync(
            string leaseId,
            string proposedId,
            ContainerAccessConditions? accessConditions = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(leaseId)}: {leaseId}\n" +
                    $"{nameof(proposedId)}: {proposedId}\n" +
                    $"{nameof(accessConditions)}: {accessConditions}");
                try
                {
                    if (accessConditions?.HttpAccessConditions?.IfMatch != default ||
                        accessConditions?.HttpAccessConditions?.IfNoneMatch != default)
                    {
                        throw Errors.BlobConditionsMustBeDefault(nameof(HttpAccessConditions.IfMatch), nameof(HttpAccessConditions.IfNoneMatch));
                    }
                    return await BlobRestClient.Container.ChangeLeaseAsync(
                        this._pipeline,
                        this.Uri,
                        leaseId: leaseId,
                        proposedLeaseId: proposedId,
                        ifModifiedSince: accessConditions?.HttpAccessConditions?.IfModifiedSince,
                        ifUnmodifiedSince: accessConditions?.HttpAccessConditions?.IfUnmodifiedSince,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ListBlobsFlatSegmentAsync"/> operation returns a
        /// single segment of blobs in this container, starting
        /// from the specified <paramref name="marker"/>.  Use an empty
        /// <paramref name="marker"/> to start enumeration from the beginning
        /// and the <see cref="BlobsFlatSegment.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="ListBlobsFlatSegmentAsync"/>
        /// to continue enumerating the blobs segment by segment. Blobs are
        /// ordered lexicographically by name.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs"/>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of blobs to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="BlobsFlatSegment.NextMarker"/>
        /// if the listing operation did not return all blobs remaining to be
        /// listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the
        /// blobs.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobsFlatSegment}}"/> describing a
        /// segment of the blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobsFlatSegment>> ListBlobsFlatSegmentAsync(
            string marker = default,
            BlobsSegmentOptions? options = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await BlobRestClient.Container.ListBlobsFlatSegmentAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        prefix: options?.Prefix,
                        maxresults: options?.MaxResults,
                        include: options?.Details?.ToArray(),
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }

        /// <summary>
        /// The <see cref="ListBlobsHierarchySegmentAsync"/> operation returns
        /// a single segment of blobs in this container, starting
        /// from the specified <paramref name="marker"/>.  Use an empty
        /// <paramref name="marker"/> to start enumeration from the beginning
        /// and the <see cref="BlobsHierarchySegment.NextMarker"/> if it's not
        /// empty to make subsequent calls to <see cref="ListBlobsHierarchySegmentAsync"/>
        /// to continue enumerating the blobs segment by segment. Blobs are
        /// ordered lexicographically by name.   A <paramref name="delimiter"/>
        /// can be used to traverse a virtual hierarchy of blobs as though
        /// it were a file system.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/list-blobs"/>.
        /// </summary>
        /// <param name="marker">
        /// An optional string value that identifies the segment of the list
        /// of blobs to be returned with the next listing operation.  The
        /// operation returns a non-empty <see cref="BlobsHierarchySegment.NextMarker"/>
        /// if the listing operation did not return all blobs remaining to be
        /// listed with the current segment.  The NextMarker value can
        /// be used as the value for the <paramref name="marker"/> parameter
        /// in a subsequent call to request the next segment of list items.
        /// </param>
        /// <param name="delimiter">
        /// A <paramref name="delimiter"/> that can be used to traverse a
        /// virtual hierarchy of blobs as though it were a file system.  The
        /// delimiter may be a single character or a string.
        /// <see cref="BlobsHierarchySegment.BlobPrefixes"/> will be returned
        /// in place of all blobs whose names begin with the same substring up
        /// to the appearance of the delimiter character.  The value of a
        /// <see cref="BlobPrefix.Name"/> is substring+delimiter, where
        /// substring is the common substring that begins one or more blob 
        /// names, and delimiter is the value of <paramref name="delimiter"/>.
        /// You can use the value of BlobPrefix to make a subsequent call to
        /// list the blobs that begin with this prefix, by specifying the 
        /// value of the BlobPrefix for the <see cref="BlobsSegmentOptions.Prefix"/>.
        /// Note that each BlobPrefix element returned counts toward the
        /// maximum result, just as each Blob element does.
        /// </param>
        /// <param name="options">
        /// Specifies options for listing, filtering, and shaping the
        /// blobs.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Task{Response{BlobsHierarchySegment}}"/> describing a
        /// segment of the blobs in the container.
        /// </returns>
        /// <remarks>
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public async Task<Response<BlobsHierarchySegment>> ListBlobsHierarchySegmentAsync(
            string marker = default,
            string delimiter = default,
            BlobsSegmentOptions? options = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(BlobContainerClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(BlobContainerClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(marker)}: {marker}\n" +
                    $"{nameof(delimiter)}: {delimiter}\n" +
                    $"{nameof(options)}: {options}");
                try
                {
                    return await BlobRestClient.Container.ListBlobsHierarchySegmentAsync(
                        this._pipeline,
                        this.Uri,
                        marker: marker,
                        prefix: options?.Prefix,
                        maxresults: options?.MaxResults,
                        include: options?.Details?.ToArray(),
                        delimiter: delimiter,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(BlobContainerClient));
                }
            }
        }
    }
}

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies options for listing blobs with the 
    /// <see cref="BlobContainerClient.ListBlobsFlatSegmentAsync"/> and
    /// <see cref="BlobContainerClient.ListBlobsHierarchySegmentAsync"/>
    /// operations.
    /// </summary>
    public struct BlobsSegmentOptions : IEquatable<BlobsSegmentOptions>
    {
        /// <summary>
        /// Gets or sets the details about each blob that should be
        /// returned with the request.
        /// </summary>
        public BlobListingDetails? Details { get; set; } // No IncludeType header is produced if ""

        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// blobs whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }             // No Prefix header is produced if ""

        /// <summary>
        /// Gets or sets the maximum number of blobs to return. If the
        /// request does not specify <see cref="MaxResults"/>, or specifies a
        /// value greater than 5000, the server will return up to 5000 items.
        /// 
        /// Note that if the listing operation crosses a partition boundary,
        /// then the service will return a <see cref="BlobsFlatSegment.NextMarker"/>
        /// or <see cref="BlobsHierarchySegment.NextMarker"/> for retrieving
        /// the remainder of the results.  For this reason, it is possible that
        /// the service will return fewer results than specified by
        /// <see cref="MaxResults"/>, or than the default of 5000. 
        /// 
        /// If the parameter is set to a value less than or equal to zero, 
        /// a <see cref="StorageRequestFailedException"/> will be thrown.
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// Check if two BlobsSegmentOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is BlobsSegmentOptions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the BlobsSegmentOptions.
        /// </summary>
        /// <returns>Hash code for the BlobsSegmentOptions.</returns>
        public override int GetHashCode()
            => this.Details.GetHashCode()
            ^ this.Prefix.GetHashCode()
            ^ this.MaxResults.GetHashCode()
            ;

        /// <summary>
        /// Check if two BlobsSegmentOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobsSegmentOptions left, BlobsSegmentOptions right) => left.Equals(right);

        /// <summary>
        /// Check if two BlobsSegmentOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobsSegmentOptions left, BlobsSegmentOptions right) => !(left == right);

        /// <summary>
        /// Check if two BlobsSegmentOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobsSegmentOptions other)
            => this.Details == other.Details
            && this.Prefix == other.Prefix
            && this.MaxResults == other.MaxResults
            ;
    }

    /// <summary>
    /// Specifies the additional details about each blob that should be
    /// returned from the <see cref="BlobContainerClient.ListBlobsFlatSegmentAsync"/>
    /// and <see cref="BlobContainerClient.ListBlobsHierarchySegmentAsync"/>
    /// operations.
    /// </summary>
	public struct BlobListingDetails : IEquatable<BlobListingDetails>
    {
        /// <summary>
        /// Gets or sets a flag specifing that metadata related to any current
        /// or previous <see cref="Specialized.BlobClient.StartCopyFromUriAsync"/>
        /// operation should be included.
        /// </summary>
        public bool Copy { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that the blob's metadata should be
        /// included.
        /// </summary>
        public bool Metadata { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that the blob's snapshots should be
        /// included.  Snapshots are listed from oldest to newest.
        /// </summary>
        public bool Snapshots { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that blobs for which blocks have
        /// been uploaded, but which have not been committed using
        /// <see cref="BlockBlobClient.CommitBlockListAsync"/> should be
        /// included.
        /// </summary>
        public bool UncommittedBlobs { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that soft deleted blobs should be
        /// included in the response.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Convert the details into ListBlobsIncludeItem values.
        /// </summary>
        /// <returns>ListBlobsIncludeItem values</returns>
        internal ListBlobsIncludeItem[] ToArray()
        {
            // NOTE: Multiple strings MUST be appended in alphabetic order or signing the string for authentication fails!
            // TODO: Remove this requirement by pushing it closer to header generation. 

            var items = new List<ListBlobsIncludeItem>();

            if (this.Copy)
            {
                items.Add(ListBlobsIncludeItem.Copy);
            }

            if (this.Deleted)
            {
                items.Add(ListBlobsIncludeItem.Deleted);
            }

            if (this.Metadata)
            {
                items.Add(ListBlobsIncludeItem.Metadata);
            }

            if (this.Snapshots)
            {
                items.Add(ListBlobsIncludeItem.Snapshots);
            }

            if (this.UncommittedBlobs)
            {
                items.Add(ListBlobsIncludeItem.Uncommittedblobs);
            }

            return items.ToArray();
        }

        /// <summary>
        /// Check if two BlobListingDetails instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is BlobListingDetails other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the BlobListingDetails.
        /// </summary>
        /// <returns>Hash code for the BlobListingDetails.</returns>
        public override int GetHashCode()
            => (this.Copy ? 0b00001 : 0)
             + (this.Deleted ? 0b00010 : 0)
             + (this.Metadata ? 0b00100 : 0)
             + (this.Snapshots ? 0b01000 : 0)
             + (this.UncommittedBlobs ? 0b10000 : 0)
            ;

        /// <summary>
        /// Check if two BlobListingDetails instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobListingDetails left, BlobListingDetails right) => left.Equals(right);

        /// <summary>
        /// Check if two BlobListingDetails instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobListingDetails left, BlobListingDetails right) => !(left == right);

        /// <summary>
        /// Check if two BlobListingDetails instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobListingDetails other)
            => this.Copy == other.Copy
            && this.Deleted == other.Deleted
            && this.Metadata == other.Metadata
            && this.Snapshots == other.Snapshots
            && this.UncommittedBlobs == other.UncommittedBlobs
            ;
    }
}
