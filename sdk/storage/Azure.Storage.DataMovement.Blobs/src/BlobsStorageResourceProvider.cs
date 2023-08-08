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
        private enum CredType
        {
            None = 0,
            SharedKey = 1,
            Token = 2,
            Sas = 4,
        }

        private enum ResourceType
        {
            Unknown = 0,
            BlockBlob = 1,
            PageBlob = 2,
            AppendBlob = 3,
            BlobContainer = 4,
        }

        /// <summary>
        /// Retrieves a credential for the given URI.
        /// </summary>
        /// <param name="uri">
        /// URI to get credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the credential can be scoped to readonly.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation Token.
        /// </param>
        /// <returns>
        /// Credential to the given URI.
        /// </returns>
        public delegate Task<StorageSharedKeyCredential> GetSharedKeyCredentialAsync(string uri, bool readOnly, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a credential for the given URI.
        /// </summary>
        /// <param name="uri">
        /// URI to get credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the credential can be scoped to readonly.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation Token.
        /// </param>
        /// <returns>
        /// Credential to the given URI.
        /// </returns>
        public delegate Task<TokenCredential> GetTokenCredentialAsync(string uri, bool readOnly, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a credential for the given URI.
        /// </summary>
        /// <param name="uri">
        /// URI to get credential for.
        /// </param>
        /// <param name="readOnly">
        /// Whether the credential can be scoped to readonly.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation Token.
        /// </param>
        /// <returns>
        /// Credential to the given URI.
        /// </returns>
        public delegate Task<AzureSasCredential> GetSasCredentialAsync(string uri, bool readOnly, CancellationToken cancellationToken);

        /// <inheritdoc/>
        protected override string TypeId => "blob";

        private readonly CredType _credType;
        private readonly GetSharedKeyCredentialAsync _getSharedKeyCredentialAsync;
        private readonly GetTokenCredentialAsync _getTokenCredentialAsync;
        private readonly GetSasCredentialAsync _getSasCredentialAsync;

        /// <summary>
        /// Default constrctor.
        /// </summary>
        public BlobsStorageResourceProvider()
        {
            _credType = CredType.None;
            _getSharedKeyCredentialAsync = null;
            _getTokenCredentialAsync = null;
            _getSasCredentialAsync = null;
        }

        /// <summary>
        /// Constructs this provider to use the given credential when creating a <see cref="StorageResource"/>.
        /// </summary>
        /// <param name="credential">
        /// Credential to use.
        /// </param>
        public BlobsStorageResourceProvider(StorageSharedKeyCredential credential)
            : this((_, _, _) => Task.FromResult(credential))
        {
        }

        /// <summary>
        /// Constructs this provider to use the given credential when creating a <see cref="StorageResource"/>.
        /// </summary>
        /// <param name="credential">
        /// Credential to use.
        /// </param>
        public BlobsStorageResourceProvider(TokenCredential credential)
            : this((_, _, _) => Task.FromResult(credential))
        {
        }

        /// <summary>
        /// Constructs this provider to use the given credential when creating a <see cref="StorageResource"/>.
        /// </summary>
        /// <param name="credential">
        /// Credential to use.
        /// </param>
        public BlobsStorageResourceProvider(AzureSasCredential credential)
            : this((_, _, _) => Task.FromResult(credential))
        {
        }

        /// <summary>
        /// Constructs this provider to use the given callback for fetching a credential
        /// when creating a <see cref="StorageResource"/>.
        /// </summary>
        /// <param name="credentialSupplier">
        /// Callback to get the correct credential.
        /// </param>
        public BlobsStorageResourceProvider(GetSharedKeyCredentialAsync credentialSupplier)
        {
            _credType = CredType.SharedKey;
            _getSharedKeyCredentialAsync = credentialSupplier;
            _getTokenCredentialAsync = null;
            _getSasCredentialAsync = null;
        }

        /// <summary>
        /// Constructs this provider to use the given callback for fetching a credential
        /// when creating a <see cref="StorageResource"/>.
        /// </summary>
        /// <param name="credentialSupplier">
        /// Callback to get the correct credential.
        /// </param>
        public BlobsStorageResourceProvider(GetTokenCredentialAsync credentialSupplier)
        {
            _credType = CredType.Token;
            _getSharedKeyCredentialAsync = null;
            _getTokenCredentialAsync = credentialSupplier;
            _getSasCredentialAsync = null;
        }

        /// <summary>
        /// Constructs this provider to use the given callback for fetching a credential
        /// when creating a <see cref="StorageResource"/>.
        /// </summary>
        /// <param name="credentialSupplier">
        /// Callback to get the correct credential.
        /// </param>
        public BlobsStorageResourceProvider(GetSasCredentialAsync credentialSupplier)
        {
            _credType = CredType.Sas;
            _getSharedKeyCredentialAsync = null;
            _getTokenCredentialAsync = null;
            _getSasCredentialAsync = credentialSupplier;
        }

        /// <inheritdoc/>
        protected override async Task<StorageResource> FromSourceAsync(DataTransferProperties props, CancellationToken cancellationToken)
            => await FromTransferPropertiesAsync(props, getSource: true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc/>
        protected override async Task<StorageResource> FromDestinationAsync(DataTransferProperties props, CancellationToken cancellationToken)
            => await FromTransferPropertiesAsync(props, getSource: false, cancellationToken).ConfigureAwait(false);

        private async Task<StorageResource> FromTransferPropertiesAsync(
            DataTransferProperties props,
            bool getSource,
            CancellationToken cancellationToken)
        {
            ResourceType type = GetType(getSource ? props.SourceTypeId : props.DestinationTypeId, props.IsContainer);
            IBlobResourceRehydrator rehydrator = type switch
            {
                ResourceType.BlockBlob => new BlockBlobResourceRehydrator(),
                ResourceType.PageBlob => new PageBlobResourceRehydrator(),
                ResourceType.AppendBlob => new AppendBlobResourceRehydrator(),
                ResourceType.BlobContainer => new BlobContainerResourceRehydrator(),
                _ => throw BadResourceTypeException(type)
            };
            string uri = getSource ? props.SourcePath : props.DestinationPath;
            return _credType switch
            {
                CredType.None => await rehydrator.RehydrateAsync(props, getSource, cancellationToken)
                    .ConfigureAwait(false),
                CredType.SharedKey => await rehydrator.RehydrateAsync(
                    props,
                    getSource,
                    await _getSharedKeyCredentialAsync(uri, getSource, cancellationToken).ConfigureAwait(false),
                    cancellationToken).ConfigureAwait(false),
                CredType.Token => await rehydrator.RehydrateAsync(
                    props,
                    getSource,
                    await _getTokenCredentialAsync(uri, getSource, cancellationToken).ConfigureAwait(false),
                    cancellationToken).ConfigureAwait(false),
                CredType.Sas => await rehydrator.RehydrateAsync(
                    props,
                    getSource,
                    await _getSasCredentialAsync(uri, getSource, cancellationToken).ConfigureAwait(false),
                    cancellationToken).ConfigureAwait(false),
                _ => throw BadResourceTypeException(type),
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
            return new BlobStorageResourceContainer(new BlobContainerClient(new Uri(containerUri)), options);
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
                return new BlockBlobStorageResource(new BlockBlobClient(new Uri(blobUri)), options as BlockBlobStorageResourceOptions);
            }
            if (options is PageBlobStorageResourceOptions)
            {
                return new PageBlobStorageResource(new PageBlobClient(new Uri(blobUri)), options as PageBlobStorageResourceOptions);
            }
            if (options is AppendBlobStorageResourceOptions)
            {
                return new AppendBlobStorageResource(new AppendBlobClient(new Uri(blobUri)), options as AppendBlobStorageResourceOptions);
            }
            return new BlockBlobStorageResource(new BlockBlobClient(new Uri(blobUri)), new BlockBlobStorageResourceOptions(options));
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
            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken)
                => await BlobStorageResourceContainer.RehydrateResourceAsync(properties, isSource, cancellationToken)
                    .ConfigureAwait(false);

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");
        }

        private class BlockBlobResourceRehydrator : IBlobResourceRehydrator
        {
            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken)
                => await BlockBlobStorageResource.RehydrateResourceAsync(properties, isSource, cancellationToken)
                    .ConfigureAwait(false);

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");
        }

        private class PageBlobResourceRehydrator : IBlobResourceRehydrator
        {
            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken)
                => await PageBlobStorageResource.RehydrateResourceAsync(properties, isSource, cancellationToken)
                    .ConfigureAwait(false);

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");
        }

        private class AppendBlobResourceRehydrator : IBlobResourceRehydrator
        {
            public async Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                CancellationToken cancellationToken)
                => await AppendBlobStorageResource.RehydrateResourceAsync(properties, isSource, cancellationToken)
                    .ConfigureAwait(false);

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                StorageSharedKeyCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Get creds into static rehydrate method on the StorageResource implementation.");
        }
        #endregion

        private static ResourceType GetType(string typeId, bool isContainer)
            => typeId switch
            {
                // TODO figure out actual strings
                "BlockBlob" => isContainer ? ResourceType.BlobContainer : ResourceType.BlockBlob,
                "PageBlob" => isContainer ? ResourceType.BlobContainer : ResourceType.PageBlob,
                "AppendBlob" => isContainer ? ResourceType.BlobContainer : ResourceType.AppendBlob,
                _ => ResourceType.Unknown
            };

        private static ArgumentException BadResourceTypeException(ResourceType resourceType)
            => new ArgumentException(
                $"No support for resource type {Enum.GetName(typeof(ResourceType), resourceType)}.");
    }
}
