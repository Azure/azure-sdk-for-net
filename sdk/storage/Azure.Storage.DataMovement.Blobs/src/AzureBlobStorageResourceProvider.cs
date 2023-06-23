// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for an Azure Blob Storage resource.
    /// </summary>
    public class AzureBlobStorageResourceProvider
    {
        private readonly AzureBlobStorageResources.ResourceType _resourceType;
        private readonly Uri _uri;

        internal AzureBlobStorageResourceProvider(AzureBlobStorageResources.ResourceType resourceType, Uri uri)
        {
            if (resourceType == AzureBlobStorageResources.ResourceType.Unknown)
            {
                throw BadResourceTypeException(resourceType);
            }
            _resourceType = resourceType;
            _uri = uri;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public StorageResource MakeResource(StorageSharedKeyCredential credential)
        {
            return _resourceType switch
            {
                AzureBlobStorageResources.ResourceType.BlockBlob => MakeResource(new BlockBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.PageBlob => MakeResource(new PageBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.AppendBlob => MakeResource(new AppendBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.BlobContainer => MakeResource(new BlobContainerClient(_uri, credential)),
                _ => throw BadResourceTypeException(_resourceType)
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public StorageResource MakeResource(AzureSasCredential credential)
        {
            return _resourceType switch
            {
                AzureBlobStorageResources.ResourceType.BlockBlob => MakeResource(new BlockBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.PageBlob => MakeResource(new PageBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.AppendBlob => MakeResource(new AppendBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.BlobContainer => MakeResource(new BlobContainerClient(_uri, credential)),
                _ => throw BadResourceTypeException(_resourceType)
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public StorageResource MakeResource(TokenCredential credential)
        {
            return _resourceType switch
            {
                AzureBlobStorageResources.ResourceType.BlockBlob => MakeResource(new BlockBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.PageBlob => MakeResource(new PageBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.AppendBlob => MakeResource(new AppendBlobClient(_uri, credential)),
                AzureBlobStorageResources.ResourceType.BlobContainer => MakeResource(new BlobContainerClient(_uri, credential)),
                _ => throw BadResourceTypeException(_resourceType)
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public StorageResource MakeResource()
        {
            return _resourceType switch
            {
                AzureBlobStorageResources.ResourceType.BlockBlob => MakeResource(new BlockBlobClient(_uri)),
                AzureBlobStorageResources.ResourceType.PageBlob => MakeResource(new PageBlobClient(_uri)),
                AzureBlobStorageResources.ResourceType.AppendBlob => MakeResource(new AppendBlobClient(_uri)),
                AzureBlobStorageResources.ResourceType.BlobContainer => MakeResource(new BlobContainerClient(_uri)),
                _ => throw BadResourceTypeException(_resourceType)
            };
        }

        private BlobStorageResourceContainer MakeResource(BlobContainerClient client)
        {
            return new BlobStorageResourceContainer(client); // TODO get options
        }

        private BlockBlobStorageResource MakeResource(BlockBlobClient client)
        {
            return new BlockBlobStorageResource(client);
        }

        private PageBlobStorageResource MakeResource(PageBlobClient client)
        {
            return new PageBlobStorageResource(client);
        }

        private AppendBlobStorageResource MakeResource(AppendBlobClient client)
        {
            return new AppendBlobStorageResource(client);
        }

        private static ArgumentException BadResourceTypeException(AzureBlobStorageResources.ResourceType resourceType)
            => new ArgumentException(
                $"No support for resource type {Enum.GetName(typeof(AzureBlobStorageResources.ResourceType), resourceType)}.");
    }
}
