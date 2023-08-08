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
        private enum ResourceType
        {
            Unknown = 0,
            BlockBlob = 1,
            PageBlob = 2,
            AppendBlob = 3,
            BlobContainer = 4,
        }

        /// <inheritdoc/>
        protected override string TypeId => "blob";

        /// <summary>
        /// Default constrctor.
        /// </summary>
        public BlobsStorageResourceProvider()
        {
        }

        #region Abstract Class Implementation
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
            return await rehydrator.RehydrateAsync(props, getSource, cancellationToken).ConfigureAwait(false);
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
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");
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
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");
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
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");
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
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                TokenCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");

            public Task<StorageResource> RehydrateAsync(
                DataTransferProperties properties,
                bool isSource,
                AzureSasCredential credential,
                CancellationToken cancellationToken)
                => throw new NotImplementedException("Creds not yet suppored on rehydration.");
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
    }
}
