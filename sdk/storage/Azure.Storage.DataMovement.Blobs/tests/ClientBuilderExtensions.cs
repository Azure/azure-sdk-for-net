﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseBlobs;

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using BlobsClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    BaseBlobs::Azure.Storage.Blobs.BlobServiceClient,
    BaseBlobs::Azure.Storage.Blobs.BlobClientOptions>;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Tests;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    internal static class ClientBuilderExtensions
    {
        public static string GetNewContainerName(this BlobsClientBuilder clientBuilder)
            => $"test-container-{clientBuilder.Recording.Random.NewGuid()}";

        public static BlobServiceClient GetServiceClient_SharedKey(this BlobsClientBuilder clientBuilder, BlobClientOptions options = default)
            => clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigDefault, options);

        /// <summary>
        /// Creates a new <see cref="ClientBuilder{TServiceClient, TServiceClientOptions}"/>
        /// setup to generate <see cref="BlobServiceClient"/>s.
        /// </summary>
        /// <param name="tenants"><see cref="TenantConfigurationBuilder"/> powering this client builder.</param>
        /// <param name="serviceVersion">Service version for clients to target.</param>
        public static BlobsClientBuilder GetNewBlobsClientBuilder(TenantConfigurationBuilder tenants, BlobClientOptions.ServiceVersion serviceVersion)
            => new BlobsClientBuilder(
                ServiceEndpoint.Blob,
                tenants,
                (uri, clientOptions) => new BlobServiceClient(uri, clientOptions),
                (uri, sharedKeyCredential, clientOptions) => new BlobServiceClient(uri, sharedKeyCredential, clientOptions),
                (uri, tokenCredential, clientOptions) => new BlobServiceClient(uri, tokenCredential, clientOptions),
                (uri, azureSasCredential, clientOptions) => new BlobServiceClient(uri, azureSasCredential, clientOptions),
                () => new BlobClientOptions(serviceVersion));

        public static async Task<DisposingBlobContainer> GetTestContainerAsync(
            this BlobsClientBuilder clientBuilder,
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default,
            bool premium = default)
        {
            containerName ??= clientBuilder.GetNewContainerName();
            service ??= clientBuilder.GetServiceClient_SharedKey();

            if (publicAccessType == default)
            {
                publicAccessType = premium ? PublicAccessType.None : PublicAccessType.BlobContainer;
            }

            BlobContainerClient container = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateIfNotExistsAsync(metadata: metadata, publicAccessType: publicAccessType.Value);
            return new DisposingBlobContainer(container);
        }
    }
}
