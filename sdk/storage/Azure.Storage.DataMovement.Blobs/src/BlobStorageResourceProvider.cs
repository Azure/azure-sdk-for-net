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
    public class BlobStorageResourceProvider : StorageResourceProvider
    {
        internal enum ResourceType
        {
            Unknown = 0,
            BlockBlob = 1,
            PageBlob = 2,
            AppendBlob = 3,
            BlobContainer = 4,
        }

        /// <summary>
        /// Delegate for getting a credential to use for a given resource.
        /// </summary>
        /// <param name="uri">Resource a credential is requeted for.</param>
        /// <param name="readOnly">Whether only read access is needed.</param>
        /// <returns></returns>
        public delegate Task<(StorageSharedKeyCredential SharedKey, TokenCredential Token, AzureSasCredential Sas)> GetCredentialAsync(string uri, bool readOnly);

        /// <inheritdoc/>
        protected override string TypeId => "blob";

        /// <summary>
        /// Constructs a BlobStorageResourceProvider with the given options.
        /// </summary>
        public BlobStorageResourceProvider(GetCredentialAsync credentialProvider)
        {
        }

        /// <inheritdoc/>
        protected override StorageResource FromSource(DataTransferProperties props)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override StorageResource FromDestination(DataTransferProperties props)
        {
            throw new NotImplementedException();
        }

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
            throw new NotImplementedException();
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
        /// </param>
        /// <returns>
        /// The configured storage resource.
        /// </returns>
        public StorageResource FromBlob(string blobUri, BlobStorageResourceOptions options = default)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            BlobBaseClient client,
            BlobStorageResourceOptions options = default)
        {
            throw new NotImplementedException();
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
            BlobClient client,
            BlobStorageResourceOptions options = default)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

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
