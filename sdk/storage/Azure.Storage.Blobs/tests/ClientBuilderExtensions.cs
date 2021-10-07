// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

using BlobsClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Blobs.BlobServiceClient,
    Azure.Storage.Blobs.BlobClientOptions>;

namespace Azure.Storage.Blobs.Tests
{
    public static class ClientBuilderExtensions
    {
        public static string GetGarbageLeaseId(this BlobsClientBuilder clientBuilder)
            => clientBuilder.Recording.Random.NewGuid().ToString();
        public static string GetNewContainerName(this BlobsClientBuilder clientBuilder)
            => $"test-container-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewBlobName(this BlobsClientBuilder clientBuilder)
            => $"test-blob-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewBlockName(this BlobsClientBuilder clientBuilder)
            => $"test-block-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiBlobName(this BlobsClientBuilder clientBuilder)
            => $"test-β£©þ‽%3A-{clientBuilder.Recording.Random.NewGuid()}";

        public static BlobServiceClient GetServiceClient_SharedKey(this BlobsClientBuilder clientBuilder, BlobClientOptions options = default)
            => clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigDefault, options);

        public static BlobServiceClient GetServiceClient_SecondaryAccount_SharedKey(this BlobsClientBuilder clientBuilder)
            => clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigSecondary);

        public static BlobServiceClient GetServiceClient_PreviewAccount_SharedKey(this BlobsClientBuilder clientBuilder)
            => clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigPreviewBlob);

        public static BlobServiceClient GetServiceClient_PremiumBlobAccount_SharedKey(this BlobsClientBuilder clientBuilder)
            => clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigPremiumBlob);

        public static BlobServiceClient GetServiceClient_OAuth(this BlobsClientBuilder clientBuilder)
            => clientBuilder.GetServiceClientFromOauthConfig(clientBuilder.Tenants.TestConfigOAuth);

        public static BlobServiceClient GetServiceClient_OAuthAccount_SharedKey(this BlobsClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigOAuth);

        public static BlobServiceClient GetServiceClient_ManagedDisk(this BlobsClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigManagedDisk);

        public static BlobServiceClient GetServiceClient_Hns(this BlobsClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigHierarchicalNamespace);

        public static BlobServiceClient GetServiceClient_SoftDelete(this BlobsClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigSoftDelete);

        public static async Task<DisposingContainer> GetTestContainerAsync(
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
            return new DisposingContainer(container);
        }
    }
}
