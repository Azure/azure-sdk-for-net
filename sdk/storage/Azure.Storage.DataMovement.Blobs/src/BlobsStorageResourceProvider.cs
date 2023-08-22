// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

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
        public delegate StorageSharedKeyCredential GetStorageSharedKeyCredential(string uri, bool readOnly);

        /// <summary>
        /// Delegate for fetching a token credential for a given URI.
        /// </summary>
        /// <param name="uri">
        /// URI of resource to fetch credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the permission can be read-only.
        /// </param>
        public delegate TokenCredential GetTokenCredential(string uri, bool readOnly);

        /// <summary>
        /// Delegate for fetching a SAS credential for a given URI.
        /// </summary>
        /// <param name="uri">
        /// URI of resource to fetch credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the permission can be read-only.
        /// </param>
        public delegate AzureSasCredential GetAzureSasCredential(string uri, bool readOnly);

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
        protected override string TypeId => "blob";

        private readonly CredentialType _credentialType;
        private readonly GetStorageSharedKeyCredential _getStorageSharedKeyCredential;
        private readonly GetTokenCredential _getTokenCredential;
        private readonly GetAzureSasCredential _getAzureSasCredential;

        /// <summary>
        /// Default constrctor.
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
        protected override async Task<StorageResource> FromSourceAsync(DataTransferProperties properties, CancellationToken cancellationToken)
            => await FromTransferPropertiesAsync(properties, getSource: true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc/>
        protected override async Task<StorageResource> FromDestinationAsync(DataTransferProperties properties, CancellationToken cancellationToken)
            => await FromTransferPropertiesAsync(properties, getSource: false, cancellationToken).ConfigureAwait(false);

        private async Task<StorageResource> FromTransferPropertiesAsync(
            DataTransferProperties properties,
            bool getSource,
            CancellationToken cancellationToken)
        {
            ResourceType type = GetType(getSource ? properties.SourceTypeId : properties.DestinationTypeId, properties.IsContainer);
            string uri = getSource ? properties.SourcePath : properties.DestinationPath;
            IBlobResourceRehydrator rehydrator = type switch
            {
                ResourceType.BlockBlob => new BlockBlobResourceRehydrator(),
                ResourceType.PageBlob => new PageBlobResourceRehydrator(),
                ResourceType.AppendBlob => new AppendBlobResourceRehydrator(),
                ResourceType.BlobContainer => new BlobContainerResourceRehydrator(),
                _ => throw BadResourceTypeException(type)
            };
            return _credentialType switch
            {
                CredentialType.None => await rehydrator.RehydrateAsync(
                    properties,
                    getSource,
                    cancellationToken)
                    .ConfigureAwait(false),
                CredentialType.SharedKey => await rehydrator.RehydrateAsync(
                    properties,
                    getSource,
                    _getStorageSharedKeyCredential(uri, getSource),
                    cancellationToken)
                    .ConfigureAwait(false),
                CredentialType.Token => await rehydrator.RehydrateAsync(
                    properties,
                    getSource,
                    _getTokenCredential(uri, getSource),
                    cancellationToken)
                    .ConfigureAwait(false),
                CredentialType.Sas => await rehydrator.RehydrateAsync(
                    properties,
                    getSource,
                    _getAzureSasCredential(uri, getSource),
                    cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadCredentialTypeException(_credentialType),
            };
        }

        /// <summary>
        /// For use in testing. Internal wrapper for protected member
        /// <see cref="StorageResourceProvider.FromSourceAsync(DataTransferProperties, CancellationToken)"/>.
        /// </summary>
        internal async Task<StorageResource> FromSourceInternalHookAsync(
            DataTransferProperties props,
            CancellationToken cancellationToken = default)
            => await FromSourceAsync(props, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// For use in testing. Internal wrapper for protected member
        /// <see cref="StorageResourceProvider.FromDestinationAsync(DataTransferProperties, CancellationToken)"/>.
        /// </summary>
        internal async Task<StorageResource> FromDestinationInternalHookAsync(
            DataTransferProperties props,
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
        public StorageResource FromContainer(string containerUri, BlobStorageResourceContainerOptions options = default)
        {
            BlobContainerClient client = _credentialType switch
            {
                CredentialType.None => new BlobContainerClient(new Uri(containerUri)),
                CredentialType.SharedKey => new BlobContainerClient(new Uri(containerUri), _getStorageSharedKeyCredential(containerUri, false)),
                CredentialType.Token => new BlobContainerClient(new Uri(containerUri), _getTokenCredential(containerUri, false)),
                CredentialType.Sas => new BlobContainerClient(new Uri(containerUri), _getAzureSasCredential(containerUri, false)),
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
        public StorageResource FromBlob(string blobUri, BlobStorageResourceOptions options = default)
        {
            if (options is BlockBlobStorageResourceOptions)
            {
                BlockBlobClient blockClient = _credentialType switch
                {
                    CredentialType.None => new BlockBlobClient(new Uri(blobUri)),
                    CredentialType.SharedKey => new BlockBlobClient(new Uri(blobUri), _getStorageSharedKeyCredential(blobUri, false)),
                    CredentialType.Token => new BlockBlobClient(new Uri(blobUri), _getTokenCredential(blobUri, false)),
                    CredentialType.Sas => new BlockBlobClient(new Uri(blobUri), _getAzureSasCredential(blobUri, false)),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new BlockBlobStorageResource(blockClient, options as BlockBlobStorageResourceOptions);
            }
            if (options is PageBlobStorageResourceOptions)
            {
                PageBlobClient pageClient = _credentialType switch
                {
                    CredentialType.None => new PageBlobClient(new Uri(blobUri)),
                    CredentialType.SharedKey => new PageBlobClient(new Uri(blobUri), _getStorageSharedKeyCredential(blobUri, false)),
                    CredentialType.Token => new PageBlobClient(new Uri(blobUri), _getTokenCredential(blobUri, false)),
                    CredentialType.Sas => new PageBlobClient(new Uri(blobUri), _getAzureSasCredential(blobUri, false)),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new PageBlobStorageResource(pageClient, options as PageBlobStorageResourceOptions);
            }
            if (options is AppendBlobStorageResourceOptions)
            {
                AppendBlobClient appendClient = _credentialType switch
                {
                    CredentialType.None => new AppendBlobClient(new Uri(blobUri)),
                    CredentialType.SharedKey => new AppendBlobClient(new Uri(blobUri), _getStorageSharedKeyCredential(blobUri, false)),
                    CredentialType.Token => new AppendBlobClient(new Uri(blobUri), _getTokenCredential(blobUri, false)),
                    CredentialType.Sas => new AppendBlobClient(new Uri(blobUri), _getAzureSasCredential(blobUri, false)),
                    _ => throw BadCredentialTypeException(_credentialType),
                };
                return new AppendBlobStorageResource(appendClient, options as AppendBlobStorageResourceOptions);
            }
            BlockBlobClient client = _credentialType switch
            {
                CredentialType.None => new BlockBlobClient(new Uri(blobUri)),
                CredentialType.SharedKey => new BlockBlobClient(new Uri(blobUri), _getStorageSharedKeyCredential(blobUri, false)),
                CredentialType.Token => new BlockBlobClient(new Uri(blobUri), _getTokenCredential(blobUri, false)),
                CredentialType.Sas => new BlockBlobClient(new Uri(blobUri), _getAzureSasCredential(blobUri, false)),
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
            Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken);
            Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken);
            Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken);
            Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken);
        }

        private class BlobContainerResourceRehydrator : IBlobResourceRehydrator
        {
            private async Task<BlobStorageResourceContainerOptions> GetOptionsAsync(
                DataTransferProperties transferProperties,
                bool isSource,
                CancellationToken cancellationToken)
            {
                Argument.AssertNotNull(transferProperties, nameof(transferProperties));
                TransferCheckpointer checkpointer = transferProperties.Checkpointer.GetCheckpointer();

                return await checkpointer.GetBlobContainerOptionsAsync(
                    GetPrefix(transferProperties, isSource),
                    transferProperties.TransferId,
                    isSource,
                    cancellationToken).ConfigureAwait(false);
            }

            private string GetPath(DataTransferProperties properties, bool getSource)
                => getSource ? properties.SourcePath : properties.DestinationPath;
            private string GetPrefix(DataTransferProperties properties, bool getSource)
                => new BlobUriBuilder(new Uri(GetPath(properties, getSource))).BlobName;

            private Uri GetContainerUri(DataTransferProperties properties, bool getSource)
                => new BlobUriBuilder(new Uri(GetPath(properties, getSource)))
                {
                    BlobName = ""
                }.ToUri();

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken)
                => new BlobStorageResourceContainer(
                    new BlobContainerClient(GetContainerUri(properties, isSource)),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => new BlobStorageResourceContainer(
                    new BlobContainerClient(GetContainerUri(properties, isSource), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => new BlobStorageResourceContainer(
                    new BlobContainerClient(GetContainerUri(properties, isSource), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => new BlobStorageResourceContainer(
                    new BlobContainerClient(GetContainerUri(properties, isSource), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));
        }

        private class BlockBlobResourceRehydrator : IBlobResourceRehydrator
        {
            private async Task<BlockBlobStorageResourceOptions> GetOptionsAsync(
                DataTransferProperties transferProperties,
                bool isSource,
                CancellationToken cancellationToken)
            {
                Argument.AssertNotNull(transferProperties, nameof(transferProperties));
                TransferCheckpointer checkpointer = transferProperties.Checkpointer.GetCheckpointer();

                return await checkpointer.GetBlockBlobResourceOptionsAsync(
                    transferProperties.TransferId,
                    isSource,
                    cancellationToken).ConfigureAwait(false);
            }

            private string GetPath(DataTransferProperties properties, bool getSource)
                => getSource ? properties.SourcePath : properties.DestinationPath;

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken)
                => new BlockBlobStorageResource(
                    new BlockBlobClient(new Uri(GetPath(properties, isSource))),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => new BlockBlobStorageResource(
                    new BlockBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => new BlockBlobStorageResource(
                    new BlockBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => new BlockBlobStorageResource(
                    new BlockBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));
        }

        private class PageBlobResourceRehydrator : IBlobResourceRehydrator
        {
            private async Task<PageBlobStorageResourceOptions> GetOptionsAsync(
                DataTransferProperties transferProperties,
                bool isSource,
                CancellationToken cancellationToken)
            {
                Argument.AssertNotNull(transferProperties, nameof(transferProperties));
                TransferCheckpointer checkpointer = transferProperties.Checkpointer.GetCheckpointer();

                return await checkpointer.GetPageBlobResourceOptionsAsync(
                    transferProperties.TransferId,
                    isSource,
                    cancellationToken).ConfigureAwait(false);
            }

            private string GetPath(DataTransferProperties properties, bool getSource)
                => getSource ? properties.SourcePath : properties.DestinationPath;

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken)
                => new PageBlobStorageResource(
                    new PageBlobClient(new Uri(GetPath(properties, isSource))),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => new PageBlobStorageResource(
                    new PageBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => new PageBlobStorageResource(
                    new PageBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => new PageBlobStorageResource(
                    new PageBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));
        }

        private class AppendBlobResourceRehydrator : IBlobResourceRehydrator
        {
            private async Task<AppendBlobStorageResourceOptions> GetOptionsAsync(
                DataTransferProperties transferProperties,
                bool isSource,
                CancellationToken cancellationToken)
            {
                Argument.AssertNotNull(transferProperties, nameof(transferProperties));
                TransferCheckpointer checkpointer = transferProperties.Checkpointer.GetCheckpointer();

                return new AppendBlobStorageResourceOptions(await checkpointer.GetBlobResourceOptionsAsync(
                    transferProperties.TransferId,
                    isSource,
                    cancellationToken).ConfigureAwait(false));
            }

            private string GetPath(DataTransferProperties properties, bool getSource)
                => getSource ? properties.SourcePath : properties.DestinationPath;

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken)
                => new AppendBlobStorageResource(
                    new AppendBlobClient(new Uri(GetPath(properties, isSource))),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => new AppendBlobStorageResource(
                    new AppendBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => new AppendBlobStorageResource(
                    new AppendBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));

            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => new AppendBlobStorageResource(
                    new AppendBlobClient(new Uri(GetPath(properties, isSource)), credential),
                    await GetOptionsAsync(properties, isSource, cancellationToken).ConfigureAwait(false));
        }
        #endregion

        private static ResourceType GetType(string typeId, bool isContainer)
            => typeId switch
            {
                "BlockBlob" => isContainer ? ResourceType.BlobContainer : ResourceType.BlockBlob,
                "PageBlob" => isContainer ? ResourceType.BlobContainer : ResourceType.PageBlob,
                "AppendBlob" => isContainer ? ResourceType.BlobContainer : ResourceType.AppendBlob,
                _ => ResourceType.Unknown
            };

        private static ArgumentException BadResourceTypeException(ResourceType resourceType)
            => new ArgumentException(
                $"No support for resource type {Enum.GetName(typeof(ResourceType), resourceType)}.");

        private static ArgumentException BadCredentialTypeException(CredentialType credentialType)
            => new ArgumentException(
                $"No support for credential type {Enum.GetName(typeof(CredentialType), credentialType)}.");
    }
}
