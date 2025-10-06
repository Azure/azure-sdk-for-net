// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Reflection;
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
        private readonly TokenCredential _tokenCredential;
        private readonly Func<Uri, CancellationToken, ValueTask<StorageSharedKeyCredential>> _getStorageSharedKeyCredential;
        private readonly Func<Uri, CancellationToken, ValueTask<AzureSasCredential>> _getAzureSasCredential;

        /// <summary>
        /// <para>
        /// Constructs this provider to use no credentials when making a new Blob Storage
        /// <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will NOT use any credential when constructing the underlying
        /// Azure.Storage.Blobs client, e.g. <see cref="BlockBlobClient(Uri, BlobClientOptions)"/>.
        /// This is for the purpose of either anonymous access when constructing the client.
        /// </para>
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
            _getStorageSharedKeyCredential = (_, _) => new ValueTask<StorageSharedKeyCredential>(credential);
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
            _tokenCredential = credential;
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
            _getAzureSasCredential = (_, _) => new ValueTask<AzureSasCredential>(credential);
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given delegate for acquiring a credential when making a new Blob
        /// Storage <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given callback to fetch a credential
        /// when constructing the underlying Azure.Storage.Blobs client, e.g.
        /// <see cref="BlockBlobClient(Uri, StorageSharedKeyCredential, BlobClientOptions)"/>.
        /// The callback will only be used when the provider needs to construct a client in the first place. It will
        /// not be used when creating a <see cref="StorageResource"/> from a pre-existing client, e.g.
        /// <see cref="FromClient(BlockBlobClient, BlockBlobStorageResourceOptions)"/>.
        /// </para>
        /// </summary>
        /// <param name="getStorageSharedKeyCredentialAsync">
        /// Callback for acquiring a credential for the given Uri.
        /// </param>
        public BlobsStorageResourceProvider(Func<Uri, CancellationToken, ValueTask<StorageSharedKeyCredential>> getStorageSharedKeyCredentialAsync)
        {
            _credentialType = CredentialType.SharedKey;
            _getStorageSharedKeyCredential = getStorageSharedKeyCredentialAsync;
        }

        /// <summary>
        /// <para>
        /// Constructs this provider to use the given callback for acquiring a credential when making a new Blob
        /// Storage <see cref="StorageResource"/>.
        /// </para>
        /// <para>
        /// This instance will use the given callback to fetch a credential
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
        /// Callback for acquiring a credential for the given Uri and required set of permissions.
        /// </param>
        public BlobsStorageResourceProvider(Func<Uri, CancellationToken, ValueTask<AzureSasCredential>> getAzureSasCredentialAsync)
        {
            _credentialType = CredentialType.Sas;
            _getAzureSasCredential = getAzureSasCredentialAsync;
        }

        #region Abstract Class Implementation
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override async ValueTask<StorageResource> FromSourceAsync(TransferProperties properties, CancellationToken cancellationToken)
            => await FromTransferPropertiesAsync(properties, getSource: true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override async ValueTask<StorageResource> FromDestinationAsync(TransferProperties properties, CancellationToken cancellationToken)
            => await FromTransferPropertiesAsync(properties, getSource: false, cancellationToken).ConfigureAwait(false);

        private async ValueTask<StorageResource> FromTransferPropertiesAsync(
            TransferProperties properties,
            bool getSource,
            CancellationToken cancellationToken)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
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
                    await _getStorageSharedKeyCredential(uri, cancellationToken).ConfigureAwait(false),
                    cancellationToken),
                CredentialType.Token => rehydrator.Rehydrate(
                    properties,
                    checkpointDetails as BlobDestinationCheckpointDetails,
                    getSource,
                    _tokenCredential,
                    cancellationToken),
                CredentialType.Sas => rehydrator.Rehydrate(
                    properties,
                    checkpointDetails as BlobDestinationCheckpointDetails,
                    getSource,
                    await _getAzureSasCredential(uri, cancellationToken).ConfigureAwait(false),
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public async ValueTask<StorageResource> FromContainerAsync(
            Uri containerUri,
            BlobStorageResourceContainerOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            BlobClientOptions clientOptions = GetUserAgentClientOptions();
            BlobContainerClient client = _credentialType switch
            {
                CredentialType.None => new BlobContainerClient(containerUri, clientOptions),
                CredentialType.SharedKey => new BlobContainerClient(containerUri, await _getStorageSharedKeyCredential(containerUri, cancellationToken).ConfigureAwait(false), clientOptions),
                CredentialType.Token => new BlobContainerClient(containerUri, _tokenCredential, clientOptions),
                CredentialType.Sas => new BlobContainerClient(containerUri, await _getAzureSasCredential(containerUri, cancellationToken).ConfigureAwait(false), clientOptions),
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
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public async ValueTask<StorageResource> FromBlobAsync(
            Uri blobUri,
            BlobStorageResourceOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            BlobClientOptions clientOptions = GetUserAgentClientOptions();
            if (options is BlockBlobStorageResourceOptions)
            {
                BlockBlobClient blockClient = _credentialType switch
                {
                    CredentialType.None => new BlockBlobClient(blobUri, clientOptions),
                    CredentialType.SharedKey => new BlockBlobClient(blobUri, await _getStorageSharedKeyCredential(blobUri, cancellationToken).ConfigureAwait(false), clientOptions),
                    CredentialType.Token => new BlockBlobClient(blobUri, _tokenCredential, clientOptions),
                    CredentialType.Sas => new BlockBlobClient(blobUri, await _getAzureSasCredential(blobUri, cancellationToken).ConfigureAwait(false), clientOptions),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new BlockBlobStorageResource(blockClient, options as BlockBlobStorageResourceOptions);
            }
            if (options is PageBlobStorageResourceOptions)
            {
                PageBlobClient pageClient = _credentialType switch
                {
                    CredentialType.None => new PageBlobClient(blobUri, clientOptions),
                    CredentialType.SharedKey => new PageBlobClient(blobUri, await _getStorageSharedKeyCredential(blobUri, cancellationToken).ConfigureAwait(false), clientOptions),
                    CredentialType.Token => new PageBlobClient(blobUri, _tokenCredential, clientOptions),
                    CredentialType.Sas => new PageBlobClient(blobUri, await _getAzureSasCredential(blobUri, cancellationToken).ConfigureAwait(false), clientOptions),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new PageBlobStorageResource(pageClient, options as PageBlobStorageResourceOptions);
            }
            if (options is AppendBlobStorageResourceOptions)
            {
                AppendBlobClient appendClient = _credentialType switch
                {
                    CredentialType.None => new AppendBlobClient(blobUri, clientOptions),
                    CredentialType.SharedKey => new AppendBlobClient(blobUri, await _getStorageSharedKeyCredential(blobUri, cancellationToken).ConfigureAwait(false), clientOptions),
                    CredentialType.Token => new AppendBlobClient(blobUri, _tokenCredential, clientOptions),
                    CredentialType.Sas => new AppendBlobClient(blobUri, await _getAzureSasCredential(blobUri, cancellationToken).ConfigureAwait(false), clientOptions),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new AppendBlobStorageResource(appendClient, options as AppendBlobStorageResourceOptions);
            }
            BlockBlobClient client = _credentialType switch
            {
                CredentialType.None => new BlockBlobClient(blobUri, clientOptions),
                CredentialType.SharedKey => new BlockBlobClient(blobUri, await _getStorageSharedKeyCredential(blobUri, cancellationToken).ConfigureAwait(false), clientOptions),
                CredentialType.Token => new BlockBlobClient(blobUri, _tokenCredential, clientOptions),
                CredentialType.Sas => new BlockBlobClient(blobUri, await _getAzureSasCredential(blobUri, cancellationToken).ConfigureAwait(false), clientOptions    ),
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
        public static StorageResource FromClient(
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
        public static StorageResource FromClient(
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
        public static StorageResource FromClient(
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
        public static StorageResource FromClient(
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
                        BlobPrefix = GetPrefix(transferProperties, isSource)
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

        private static BlobClientOptions GetUserAgentClientOptions()
        {
            BlobClientOptions options = new BlobClientOptions();

            // We grab the assembly of BlobsStorageResourceProvider which is Azure.Storage.DataMovement.Blobs.
            // From there we can grab the version of the Assembly.
            Assembly assembly = typeof(BlobsStorageResourceProvider).Assembly;
            AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw Errors.RequiredVersionClientAssembly(assembly, versionAttribute);
            }
            // Now using a policy, update the user agent string with the version and add the policy
            // to the client options.
            DataMovementUserAgentPolicy policy = new(versionAttribute.InformationalVersion);
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            return options;
        }
    }
}
