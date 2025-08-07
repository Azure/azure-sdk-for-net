// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Extensions.AspNetCore.DataProtection.Blobs;
using Azure.Storage;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

#pragma warning disable // TODO cleanup of all the warning messages. Issue https://github.com/Azure/azure-sdk-for-net/issues/43768
namespace Microsoft.AspNetCore.DataProtection
#pragma warning disable
{
    /// <summary>
    /// Contains Azure-specific extension methods for modifying a
    /// <see cref="IDataProtectionBuilder"/>.
    /// </summary>
    public static class AzureStorageBlobDataProtectionBuilderExtensions
    {
        /// <summary>
        /// Configures the data protection system to persist keys to the specified path
        /// in Azure Blob Storage.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="sasUri">The full URI where the key file should be stored.
        /// The URI must contain the SAS token as a query string parameter.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        /// <remarks>
        /// The container referenced by <paramref name="blobSasUri"/> must already exist.
        /// </remarks>
        public static IDataProtectionBuilder PersistKeysToAzureBlobStorage(this IDataProtectionBuilder builder, Uri blobSasUri)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (blobSasUri == null)
            {
                throw new ArgumentNullException(nameof(blobSasUri));
            }

            var uriBuilder = new BlobUriBuilder(blobSasUri);
            BlobClient client;

            // The SAS token is present in the query string.
            if (uriBuilder.Sas == null)
            {
                throw new ArgumentException($"{nameof(blobSasUri)} is expected to be a SAS URL.", nameof(blobSasUri));
            }
            else
            {
                client = new BlobClient(blobSasUri);
            }

            return PersistKeysToAzureBlobStorage(builder, client);
        }

        /// <summary>
        /// Configures the data protection system to persist keys to the specified path
        /// in Azure Blob Storage.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="sasUri">The full URI where the key file should be stored.
        /// The URI must contain the SAS token as a query string parameter.</param>
        /// <param name="tokenCredential">The credentials to connect to the blob.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        /// <remarks>
        /// The container referenced by <paramref name="blobUri"/> must already exist.
        /// </remarks>
        public static IDataProtectionBuilder PersistKeysToAzureBlobStorage(this IDataProtectionBuilder builder, Uri blobUri, TokenCredential tokenCredential)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (blobUri == null)
            {
                throw new ArgumentNullException(nameof(blobUri));
            }
            if (tokenCredential == null)
            {
                throw new ArgumentNullException(nameof(tokenCredential));
            }

            var client = new BlobClient(blobUri, tokenCredential);

            return PersistKeysToAzureBlobStorage(builder, client);
        }

        /// <summary>
        /// Configures the data protection system to persist keys to the specified path
        /// in Azure Blob Storage.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="sasUri">The full URI where the key file should be stored.
        /// The URI must contain the SAS token as a query string parameter.</param>
        /// <param name="sharedKeyCredential">The credentials to connect to the blob.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        /// <remarks>
        /// The container referenced by <paramref name="blobUri"/> must already exist.
        /// </remarks>
        public static IDataProtectionBuilder PersistKeysToAzureBlobStorage(this IDataProtectionBuilder builder, Uri blobUri, StorageSharedKeyCredential sharedKeyCredential)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (blobUri == null)
            {
                throw new ArgumentNullException(nameof(blobUri));
            }
            if (sharedKeyCredential == null)
            {
                throw new ArgumentNullException(nameof(sharedKeyCredential));
            }

            var client = new BlobClient(blobUri, sharedKeyCredential);

            return PersistKeysToAzureBlobStorage(builder, client);
        }

        /// <summary>
        /// Configures the data protection system to persist keys to the specified path
        /// in Azure Blob Storage.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="connectionString">A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        /// </param>
        /// <param name="containerName">The container name to use.</param>
        /// <param name="blobName">The blob name to use.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        /// <remarks>
        /// The container referenced by <paramref name="containerName"/> must already exist.
        /// </remarks>
        public static IDataProtectionBuilder PersistKeysToAzureBlobStorage(this IDataProtectionBuilder builder, string connectionString, string containerName, string blobName)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            if (containerName == null)
            {
                throw new ArgumentNullException(nameof(containerName));
            }
            if (blobName == null)
            {
                throw new ArgumentNullException(nameof(blobName));
            }

            var client = new BlobServiceClient(connectionString).GetBlobContainerClient(containerName).GetBlobClient(blobName);

            return PersistKeysToAzureBlobStorage(builder, client);
        }

        /// <summary>
        /// Configures the data protection system to persist keys to the specified path
        /// in Azure Blob Storage.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="blobClient">The <see cref="BlobClient"/> in which the
        /// key file should be stored.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        /// <remarks>
        /// The blob referenced by <paramref name="blobClient"/> must already exist.
        /// </remarks>
        public static IDataProtectionBuilder PersistKeysToAzureBlobStorage(this IDataProtectionBuilder builder, BlobClient blobClient)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (blobClient == null)
            {
                throw new ArgumentNullException(nameof(blobClient));
            }

            builder.Services.Configure<KeyManagementOptions>(options =>
            {
                options.XmlRepository = new AzureBlobXmlRepository(blobClient);
            });

            return builder;
        }

        /// <summary>
        /// Configures the data protection system to persist keys to the specified path
        /// in Azure Blob Storage.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="blobClientFactory">The factory delegate used to create the <see cref="BlobClient"/> in which the
        /// key file should be stored.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        /// <remarks>
        /// The blob referenced by <paramref name="blobClient"/> must already exist.
        /// </remarks>
        public static IDataProtectionBuilder PersistKeysToAzureBlobStorage(this IDataProtectionBuilder builder, Func<IServiceProvider, BlobClient> blobClientFactory)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (blobClientFactory == null)
            {
                throw new ArgumentNullException(nameof(blobClientFactory));
            }

            builder.Services.AddSingleton(sp =>
            {
                var blobClient = blobClientFactory(sp);
                return new AzureBlobXmlRepository(blobClient);
            });

            builder.Services.AddSingleton<IConfigureOptions<KeyManagementOptions>, ConfigureKeyManagementBlobClientOptions>();

            return builder;
        }
    }
}
