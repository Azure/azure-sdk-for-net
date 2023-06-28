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
    public class AzureBlobStorageResourceProvider
    {
        private readonly DataTransferProperties _properties;
        private readonly bool _asSource;
        private readonly AzureBlobStorageResources.ResourceType _resourceType;

        internal AzureBlobStorageResourceProvider(
            DataTransferProperties properties,
            bool asSource,
            AzureBlobStorageResources.ResourceType resourceType)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            if (resourceType == AzureBlobStorageResources.ResourceType.Unknown)
            {
                throw BadResourceTypeException(resourceType);
            }

            _properties = properties;
            _asSource = asSource;
            _resourceType = resourceType;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<StorageResource> MakeResourceAsync(StorageSharedKeyCredential credential, CancellationToken cancellationToken = default)
        {
            return _resourceType switch
            {
                AzureBlobStorageResources.ResourceType.BlockBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.PageBlob => await PageBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.AppendBlob => await AppendBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.BlobContainer => await BlobStorageResourceContainer
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadResourceTypeException(_resourceType)
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<StorageResource> MakeResourceAsync(AzureSasCredential credential, CancellationToken cancellationToken = default)
        {
            return _resourceType switch
            {
                AzureBlobStorageResources.ResourceType.BlockBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.PageBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.AppendBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.BlobContainer => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadResourceTypeException(_resourceType)
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<StorageResource> MakeResourceAsync(TokenCredential credential, CancellationToken cancellationToken = default)
        {
            return _resourceType switch
            {
                AzureBlobStorageResources.ResourceType.BlockBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.PageBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.AppendBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.BlobContainer => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, credential, cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadResourceTypeException(_resourceType)
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<StorageResource> MakeResourceAsync(CancellationToken cancellationToken = default)
        {
            return _resourceType switch
            {
                AzureBlobStorageResources.ResourceType.BlockBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.PageBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.AppendBlob => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, cancellationToken)
                    .ConfigureAwait(false),
                AzureBlobStorageResources.ResourceType.BlobContainer => await BlockBlobStorageResource
                    .RehydrateResourceAsync(_properties, _asSource, cancellationToken)
                    .ConfigureAwait(false),
                _ => throw BadResourceTypeException(_resourceType)
            };
        }

        private static ArgumentException BadResourceTypeException(AzureBlobStorageResources.ResourceType resourceType)
            => new ArgumentException(
                $"No support for resource type {Enum.GetName(typeof(AzureBlobStorageResources.ResourceType), resourceType)}.");
    }
}
