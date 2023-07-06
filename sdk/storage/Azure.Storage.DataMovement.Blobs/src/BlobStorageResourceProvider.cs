// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for an Azure Blob Storage resource.
    /// </summary>
    public class BlobStorageResourceProvider
    {
        internal DataTransferProperties Properties { get; }
        internal bool MakesSource { get; }
        internal BlobStorageResources.ResourceType ResourceType { get; }

        internal BlobStorageResourceProvider(
            DataTransferProperties properties,
            bool asSource,
            BlobStorageResources.ResourceType resourceType)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            if (resourceType == BlobStorageResources.ResourceType.Unknown)
            {
                throw BadResourceTypeException(resourceType);
            }

            Properties = properties;
            MakesSource = asSource;
            ResourceType = resourceType;
        }

        /// <summary>
        /// Creates the configured <see cref="StorageResource"/> instance using the given <see cref="StorageSharedKeyCredential"/>.
        /// </summary>
        /// <returns></returns>
        public async Task<StorageResource> MakeResourceAsync(StorageSharedKeyCredential credential, CancellationToken cancellationToken = default)
        {
            return ResourceType switch
            {
                BlobStorageResources.ResourceType.BlockBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.PageBlob => await PageBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.AppendBlob => await AppendBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.BlobContainer => await BlobStorageResourceContainer
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadResourceTypeException(ResourceType)
            };
        }

        /// <summary>
        /// Creates the configured <see cref="StorageResource"/> instance using the given <see cref="AzureSasCredential"/>.
        /// </summary>
        /// <returns></returns>
        public async Task<StorageResource> MakeResourceAsync(AzureSasCredential credential, CancellationToken cancellationToken = default)
        {
            return ResourceType switch
            {
                BlobStorageResources.ResourceType.BlockBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.PageBlob => await PageBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.AppendBlob => await AppendBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.BlobContainer => await BlobStorageResourceContainer
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadResourceTypeException(ResourceType)
            };
        }

        /// <summary>
        /// Creates the configured <see cref="StorageResource"/> instance using the given <see cref="TokenCredential"/>.
        /// </summary>
        /// <returns></returns>
        public async Task<StorageResource> MakeResourceAsync(TokenCredential credential, CancellationToken cancellationToken = default)
        {
            return ResourceType switch
            {
                BlobStorageResources.ResourceType.BlockBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.PageBlob => await PageBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.AppendBlob => await AppendBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.BlobContainer => await BlobStorageResourceContainer
                    .RehydrateResourceAsync(Properties, MakesSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadResourceTypeException(ResourceType)
            };
        }

        /// <summary>
        /// Creates the configured <see cref="StorageResource"/> instance using no credential.
        /// </summary>
        /// <returns></returns>
        public async Task<StorageResource> MakeResourceAsync(CancellationToken cancellationToken = default)
        {
            return ResourceType switch
            {
                BlobStorageResources.ResourceType.BlockBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.PageBlob => await PageBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.AppendBlob => await AppendBlobStorageResource
                    .RehydrateResourceAsync(Properties, MakesSource, cancellationToken)
                    .ConfigureAwait(false),
                BlobStorageResources.ResourceType.BlobContainer => await BlobStorageResourceContainer
                    .RehydrateResourceAsync(Properties, MakesSource, cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadResourceTypeException(ResourceType)
            };
        }

        private static ArgumentException BadResourceTypeException(BlobStorageResources.ResourceType resourceType)
            => new ArgumentException(
                $"No support for resource type {Enum.GetName(typeof(BlobStorageResources.ResourceType), resourceType)}.");
    }
}
