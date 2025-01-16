// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for an Azure Blob Storage resource.
    /// </summary>
    public class BlobsStorageResourceProvider : StorageResourceProvider
    {
        /// <summary>
        /// Delegate for fetching a shared key credential for a given URI.
        /// </summary>
        /// <param name="uri">
        /// URI of resource to fetch credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the permission can be read-only.
        /// </param>
        public delegate StorageSharedKeyCredential GetStorageSharedKeyCredential(Uri uri, bool readOnly);

        /// <summary>
        /// Delegate for fetching a token credential for a given URI.
        /// </summary>
        /// <param name="uri">
        /// URI of resource to fetch credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the permission can be read-only.
        /// </param>
        public delegate TokenCredential GetTokenCredential(Uri uri, bool readOnly);

        /// <summary>
        /// Delegate for fetching a SAS credential for a given URI.
        /// </summary>
        /// <param name="uri">
        /// URI of resource to fetch credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the permission can be read-only.
        /// </param>
        public delegate AzureSasCredential GetAzureSasCredential(Uri uri, bool readOnly);

        private enum ResourceType
        {
            Unknown = 0,
            BlockBlob = 1,
            PageBlob = 2,
            AppendBlob = 3,
            BlobContainer = 4,
        }

        private enum CredentialType
        {
            None = 0,
            SharedKey = 1,
            Token = 2,
            Sas = 4
        }

        /// <inheritdoc/>
        protected override string ProviderId => "blob";

        private readonly CredentialType _credentialType;
        private readonly GetStorageSharedKeyCredential _getStorageSharedKeyCredential;
        private readonly GetTokenCredential _getTokenCredential;
        private readonly GetAzureSasCredential _getAzureSasCredential;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlobsStorageResourceProvider()
        {
            _credentialType = CredentialType.None;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given credential when making a new Blob Storage
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="StorageSharedKeyCredential"/> when constructing the underlying
        /// Azure.Storage.Blobs client, e.g. <see cref="BlockBlobClient(Uri, StorageSharedKeyCredential, BlobClientOptions)"/>.
        /// The credential will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(BlockBlobClient, BlockBlobStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="credential">
        /// Shared key credential to use when constructing resources.
        /// </param>
        public BlobsStorageResourceProvider(StorageSharedKeyCredential credential)
        {
            _credentialType = CredentialType.SharedKey;
            _getStorageSharedKeyCredential = (_, _) => credential;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given credential when making a new Blob Storage
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="TokenCredential"/> when constructing the underlying
        /// Azure.Storage.Blobs client, e.g. <see cref="BlockBlobClient(Uri, TokenCredential, BlobClientOptions)"/>.
        /// The credential will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(BlockBlobClient, BlockBlobStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="credential">
        /// Token credential to use when constructing resources.
        /// </param>
        public BlobsStorageResourceProvider(TokenCredential credential)
        {
            _credentialType = CredentialType.Token;
            _getTokenCredential = (_, _) => credential;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given credential when making a new Blob Storage
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="AzureSasCredential"/> when constructing the underlying
        /// Azure.Storage.Blobs client, e.g. <see cref="BlockBlobClient(Uri, AzureSasCredential, BlobClientOptions)"/>.
        /// The credential will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(BlockBlobClient, BlockBlobStorageResourceOptions)"/>.
        /// Additionally, if the given target blob resource already has a SAS token in the URI, that token will be
        /// preferred over this credential.
        /// </para>
        /// </summary>
        /// <param name="credential">
        /// SAS credential to use when constructing resources.
        /// </param>
        public BlobsStorageResourceProvider(AzureSasCredential credential)
        {
            _credentialType = CredentialType.Sas;
            _getAzureSasCredential = (_, _) => credential;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given delegate for acquiring a credential when making a new Blob
        /// Storage <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="GetStorageSharedKeyCredential"/> to fetch a credential
        /// when constructing the underlying Azure.Storage.Blobs client, e.g.
        /// <see cref="BlockBlobClient(Uri, StorageSharedKeyCredential, BlobClientOptions)"/>.
        /// The delegate will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(BlockBlobClient, BlockBlobStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="getStorageSharedKeyCredentialAsync">
        /// Delegate for acquiring a credential.
        /// </param>
        public BlobsStorageResourceProvider(GetStorageSharedKeyCredential getStorageSharedKeyCredentialAsync)
        {
            _credentialType = CredentialType.SharedKey;
            _getStorageSharedKeyCredential = getStorageSharedKeyCredentialAsync;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given delegate for acquiring a credential when making a new Blob
        /// Storage <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="GetTokenCredential"/> to fetch a credential
        /// when constructing the underlying Azure.Storage.Blobs client, e.g.
        /// <see cref="BlockBlobClient(Uri, TokenCredential, BlobClientOptions)"/>.
        /// The delegate will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(BlockBlobClient, BlockBlobStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="getTokenCredentialAsync">
        /// Delegate for acquiring a credential.
        /// </param>
        public BlobsStorageResourceProvider(GetTokenCredential getTokenCredentialAsync)
        {
            _credentialType = CredentialType.SharedKey;
            _getTokenCredential = getTokenCredentialAsync;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given delegate for acquiring a credential when making a new Blob
        /// Storage <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given <see cref="GetAzureSasCredential"/> to fetch a credential
        /// when constructing the underlying Azure.Storage.Blobs client, e.g.
        /// <see cref="BlockBlobClient(Uri, AzureSasCredential, BlobClientOptions)"/>.
        /// The delegate will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(BlockBlobClient, BlockBlobStorageResourceOptions)"/>.
        /// Additionally, if the given target blob resource already has a SAS token in the URI, that token will be
        /// preferred over this delegate.
        /// </para>
        /// </summary>
        /// <param name="getAzureSasCredentialAsync">
        /// Delegate for acquiring a credential.
        /// </param>
        public BlobsStorageResourceProvider(GetAzureSasCredential getAzureSasCredentialAsync)
        {
            _credentialType = CredentialType.SharedKey;
            _getAzureSasCredential = getAzureSasCredentialAsync;
        }

        #region Abstract Class Implementation
        /// <inheritdoc/>
        protected override Task<StorageResource> FromSourceAsync(TransferProperties properties, CancellationToken cancellationToken)
            => Task.FromResult(FromTransferProperties(properties, getSource: true, cancellationToken));

        /// <inheritdoc/>
        protected override Task<StorageResource> FromDestinationAsync(TransferProperties properties, CancellationToken cancellationToken)
            => Task.FromResult(FromTransferProperties(properties, getSource: false, cancellationToken));

        private StorageResource FromTransferProperties(
            TransferProperties properties,
            bool getSource,
            CancellationToken cancellationToken)
        {
            StorageResourceCheckpointDetails checkpointDetails = properties.GetCheckpointDetails(getSource);

            ResourceType type = GetType(checkpointDetails, properties.IsContainer);
            Uri uri = getSource ? properties.SourceUri : properties.DestinationUri;
            IBlobResourceRehydrator rehydrator = getSource ?
                type == ResourceType.BlobContainer ? new BlobContainerResourceRehydrator() : new BlockBlobResourceRehydrator()
                : type switch
                {
                    ResourceType.BlockBlob => new BlockBlobResourceRehydrator(),
                    ResourceType.PageBlob => new PageBlobResourceRehydrator(),
                    ResourceType.AppendBlob => new AppendBlobResourceRehydrator(),
                    ResourceType.BlobContainer => new BlobContainerResourceRehydrator(),
                    _ => throw BadResourceTypeException(type)
                };
            return _credentialType switch
            {
                CredentialType.None => rehydrator.Rehydrate(
                    properties,
                    checkpointDetails as BlobDestinationCheckpointDetails,
                    getSource,
                    cancellationToken),
                CredentialType.SharedKey => rehydrator.Rehydrate(
                    properties,
                    checkpointDetails as BlobDestinationCheckpointDetails,
                    getSource,
                    _getStorageSharedKeyCredential(uri, getSource),
                    cancellationToken),
                CredentialType.Token => rehydrator.Rehydrate(
                    properties,
                    checkpointDetails as BlobDestinationCheckpointDetails,
                    getSource,
                    _getTokenCredential(uri, getSource),
                    cancellationToken),
                CredentialType.Sas => rehydrator.Rehydrate(
                    properties,
                    checkpointDetails as BlobDestinationCheckpointDetails,
                    getSource,
                    _getAzureSasCredential(uri, getSource),
                    cancellationToken),
                _ => throw BadCredentialTypeException(_credentialType),
            };
        }

        /// <summary>
        /// For use in testing. Internal wrapper for protected member
        /// <see cref="StorageResourceProvider.FromSourceAsync(TransferProperties, CancellationToken)"/>.
        /// </summary>
        internal async Task<StorageResource> FromSourceInternalHookAsync(
            TransferProperties props,
            CancellationToken cancellationToken = default)
            => await FromSourceAsync(props, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// For use in testing. Internal wrapper for protected member
        /// <see cref="StorageResourceProvider.FromDestinationAsync(TransferProperties, CancellationToken)"/>.
        /// </summary>
        internal async Task<StorageResource> FromDestinationInternalHookAsync(
            TransferProperties props,
            CancellationToken cancellationToken = default)
            => await FromDestinationAsync(props, cancellationToken).ConfigureAwait(false);
        #endregion

        #region From Uri
        /// <summary>
        /// Creates a storage resource pointing towards the given container URI.
        /// </summary>
        /// <param name="containerUri">
        /// Target location.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromContainer(Uri containerUri, BlobStorageResourceContainerOptions options = default)
        {
            BlobContainerClient client = _credentialType switch
            {
                CredentialType.None => new BlobContainerClient(containerUri),
                CredentialType.SharedKey => new BlobContainerClient(containerUri, _getStorageSharedKeyCredential(containerUri, false)),
                CredentialType.Token => new BlobContainerClient(containerUri, _getTokenCredential(containerUri, false)),
                CredentialType.Sas => new BlobContainerClient(containerUri, _getAzureSasCredential(containerUri, false)),
                _ => throw BadCredentialTypeException(_credentialType),
            };
            return new BlobStorageResourceContainer(client, options);
        }

        /// <summary>
        /// Creates a storage resource pointing towards the given container URI.
        /// </summary>
        /// <param name="blobUri">
        /// Target location.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource. You may supply a
        /// <see cref="BlobStorageResourceOptions"/>, but you may also supply
        /// type-specific options instead:
        /// <list type="bullet">
        /// <item><see cref="BlockBlobStorageResourceOptions"/></item>
        /// <item><see cref="PageBlobStorageResourceOptions"/></item>
        /// <item><see cref="AppendBlobStorageResourceOptions"/></item>
        /// </list>
        /// When making a destination storage resource, the corresponding blob
        /// type of the options class will be used to determine the intended
        /// blob type of the destination. If only the base options type is
        /// provided, block blob will be the default used.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromBlob(Uri blobUri, BlobStorageResourceOptions options = default)
        {
            if (options is BlockBlobStorageResourceOptions)
            {
                BlockBlobClient blockClient = _credentialType switch
                {
                    CredentialType.None => new BlockBlobClient(blobUri),
                    CredentialType.SharedKey => new BlockBlobClient(blobUri, _getStorageSharedKeyCredential(blobUri, false)),
                    CredentialType.Token => new BlockBlobClient(blobUri, _getTokenCredential(blobUri, false)),
                    CredentialType.Sas => new BlockBlobClient(blobUri, _getAzureSasCredential(blobUri, false)),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new BlockBlobStorageResource(blockClient, options as BlockBlobStorageResourceOptions);
            }
            if (options is PageBlobStorageResourceOptions)
            {
                PageBlobClient pageClient = _credentialType switch
                {
                    CredentialType.None => new PageBlobClient(blobUri),
                    CredentialType.SharedKey => new PageBlobClient(blobUri, _getStorageSharedKeyCredential(blobUri, false)),
                    CredentialType.Token => new PageBlobClient(blobUri, _getTokenCredential(blobUri, false)),
                    CredentialType.Sas => new PageBlobClient(blobUri, _getAzureSasCredential(blobUri, false)),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new PageBlobStorageResource(pageClient, options as PageBlobStorageResourceOptions);
            }
            if (options is AppendBlobStorageResourceOptions)
            {
                AppendBlobClient appendClient = _credentialType switch
                {
                    CredentialType.None => new AppendBlobClient(blobUri),
                    CredentialType.SharedKey => new AppendBlobClient(blobUri, _getStorageSharedKeyCredential(blobUri, false)),
                    CredentialType.Token => new AppendBlobClient(blobUri, _getTokenCredential(blobUri, false)),
                    CredentialType.Sas => new AppendBlobClient(blobUri, _getAzureSasCredential(blobUri, false)),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new AppendBlobStorageResource(appendClient, options as AppendBlobStorageResourceOptions);
            }
            BlockBlobClient client = _credentialType switch
            {
                CredentialType.None => new BlockBlobClient(blobUri),
                CredentialType.SharedKey => new BlockBlobClient(blobUri, _getStorageSharedKeyCredential(blobUri, false)),
                CredentialType.Token => new BlockBlobClient(blobUri, _getTokenCredential(blobUri, false)),
                CredentialType.Sas => new BlockBlobClient(blobUri, _getAzureSasCredential(blobUri, false)),
                _ => throw BadCredentialTypeException(_credentialType),
            };
            return new BlockBlobStorageResource(client, options as BlockBlobStorageResourceOptions);
        }
        #endregion

        #region From Client
        /// <summary>
        /// Creates a storage resource pointing towards the given Azure SDK client.
        /// </summary>
        /// <param name="client">
        /// Target resource presented within an Azure SDK client.
        /// Note: It is NOT guaranteed that properties set within the client's <see cref="BlobClientOptions"/>
        /// will be respected when resuming a transfer.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromClient(
            BlobContainerClient client,
            BlobStorageResourceContainerOptions options = default)
        {
            return new BlobStorageResourceContainer(client, options);
        }

        /// <summary>
        /// Creates a storage resource pointing towards the given Azure SDK client.
        /// </summary>
        /// <param name="client">
        /// Target resource presented within an Azure SDK client.
        /// Note: It is NOT guaranteed that properties set within the client's <see cref="BlobClientOptions"/>
        /// will be respected when resuming a transfer.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromClient(
            BlockBlobClient client,
            BlockBlobStorageResourceOptions options = default)
        {
            return new BlockBlobStorageResource(client, options);
        }

        /// <summary>
        /// Creates a storage resource pointing towards the given Azure SDK client.
        /// </summary>
        /// <param name="client">
        /// Target resource presented within an Azure SDK client.
        /// Note: It is NOT guaranteed that properties set within the client's <see cref="BlobClientOptions"/>
        /// will be respected when resuming a transfer.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromClient(
            PageBlobClient client,
            PageBlobStorageResourceOptions options = default)
        {
            return new PageBlobStorageResource(client, options);
        }

        /// <summary>
        /// Creates a storage resource pointing towards the given Azure SDK client.
        /// </summary>
        /// <param name="client">
        /// Target resource presented within an Azure SDK client.
        /// Note: It is NOT guaranteed that properties set within the client's <see cref="BlobClientOptions"/>
        /// will be respected when resuming a transfer.
        /// </param>
        /// <param name="options">
        /// Options for creating the storage resource.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromClient(
            AppendBlobClient client,
            AppendBlobStorageResourceOptions options = default)
        {
            return new AppendBlobStorageResource(client, options);
        }
        #endregion

        #region Rehydration Abstraction
        /// <summary>
        /// Abstraction to call into the correct static methods to
        /// rehydrate based on properties and a credential.
        /// </summary>
        private interface IBlobResourceRehydrator
        {
            StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                CancellationToken cancellationToken);
            StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken);
            StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken);
            StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken);
        }

        private class BlobContainerResourceRehydrator : IBlobResourceRehydrator
        {
            private BlobStorageResourceContainerOptions GetOptions(
                TransferProperties transferProperties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource)
            {
                Argument.AssertNotNull(transferProperties, nameof(transferProperties));

                if (isSource)
                {
                    return new BlobStorageResourceContainerOptions()
                    {
                        BlobDirectoryPrefix = GetPrefix(transferProperties, isSource)
                    };
                }
                else
                {
                    return destinationCheckpointDetails.GetBlobContainerOptions(GetPrefix(transferProperties, isSource));
                }
            }

            private Uri GetUri(TransferProperties properties, bool getSource)
                => getSource ? properties.SourceUri : properties.DestinationUri;

            private string GetPrefix(TransferProperties properties, bool getSource)
                => new BlobUriBuilder(GetUri(properties, getSource)).BlobName;

            private Uri GetContainerUri(TransferProperties properties, bool getSource)
                => new BlobUriBuilder(GetUri(properties, getSource))
                {
                    BlobName = ""
                }.ToUri();

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                CancellationToken cancellationToken)
                => new BlobStorageResourceContainer(
                    new BlobContainerClient(GetContainerUri(properties, isSource)),
                    GetOptions(properties, destinationCheckpointDetails, isSource));

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => new BlobStorageResourceContainer(
                    new BlobContainerClient(GetContainerUri(properties, isSource), credential),
                    GetOptions(properties, destinationCheckpointDetails, isSource));

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => new BlobStorageResourceContainer(
                    new BlobContainerClient(GetContainerUri(properties, isSource), credential),
                    GetOptions(properties, destinationCheckpointDetails, isSource));

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => new BlobStorageResourceContainer(
                    new BlobContainerClient(GetContainerUri(properties, isSource), credential),
                    GetOptions(properties, destinationCheckpointDetails, isSource));
        }

        private class BlockBlobResourceRehydrator : IBlobResourceRehydrator
        {
            private Uri GetUri(TransferProperties properties, bool getSource)
                => getSource ? properties.SourceUri : properties.DestinationUri;

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                CancellationToken cancellationToken)
                => new BlockBlobStorageResource(
                    new BlockBlobClient(GetUri(properties, isSource)),
                    !isSource ? destinationCheckpointDetails.GetBlockBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => new BlockBlobStorageResource(
                    new BlockBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetBlockBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => new BlockBlobStorageResource(
                    new BlockBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetBlockBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => new BlockBlobStorageResource(
                    new BlockBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetBlockBlobResourceOptions() : default);
        }

        private class PageBlobResourceRehydrator : IBlobResourceRehydrator
        {
            private Uri GetUri(TransferProperties properties, bool getSource)
                => getSource ? properties.SourceUri : properties.DestinationUri;

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                CancellationToken cancellationToken)
                => new PageBlobStorageResource(
                    new PageBlobClient(GetUri(properties, isSource)),
                    !isSource ? destinationCheckpointDetails.GetPageBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => new PageBlobStorageResource(
                    new PageBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetPageBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => new PageBlobStorageResource(
                    new PageBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetPageBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => new PageBlobStorageResource(
                    new PageBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetPageBlobResourceOptions() : default);
        }

        private class AppendBlobResourceRehydrator : IBlobResourceRehydrator
        {
            private Uri GetUri(TransferProperties properties, bool getSource)
                => getSource ? properties.SourceUri : properties.DestinationUri;

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                CancellationToken cancellationToken)
                => new AppendBlobStorageResource(
                    new AppendBlobClient(GetUri(properties, isSource)),
                    !isSource ? destinationCheckpointDetails.GetAppendBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => new AppendBlobStorageResource(
                    new AppendBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetAppendBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => new AppendBlobStorageResource(
                    new AppendBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetAppendBlobResourceOptions() : default);

            public StorageResource Rehydrate(
                TransferProperties properties,
                BlobDestinationCheckpointDetails destinationCheckpointDetails,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => new AppendBlobStorageResource(
                    new AppendBlobClient(GetUri(properties, isSource), credential),
                    !isSource ? destinationCheckpointDetails.GetAppendBlobResourceOptions() : default);
        }
        #endregion

        private static ResourceType GetType(StorageResourceCheckpointDetails checkpointDetails, bool isContainer)
        {
            if (isContainer)
            {
                return ResourceType.BlobContainer;
            }

            BlobDestinationCheckpointDetails destinationCheckpointDetails = checkpointDetails as BlobDestinationCheckpointDetails;

            if (null != destinationCheckpointDetails && destinationCheckpointDetails.BlobType != default)
            {
                return destinationCheckpointDetails.BlobType switch
                {
                    BlobType.Block => ResourceType.BlockBlob,
                    BlobType.Page => ResourceType.PageBlob,
                    BlobType.Append => ResourceType.AppendBlob,
                    _ => ResourceType.Unknown
                };
            }
            return ResourceType.Unknown;
        }

        private static ArgumentException BadResourceTypeException(ResourceType resourceType)
            => new ArgumentException(
                $"No support for resource type {Enum.GetName(typeof(ResourceType), resourceType)}.");

        private static ArgumentException BadCredentialTypeException(CredentialType credentialType)
            => new ArgumentException(
                $"No support for credential type {Enum.GetName(typeof(CredentialType), credentialType)}.");
    }
}
