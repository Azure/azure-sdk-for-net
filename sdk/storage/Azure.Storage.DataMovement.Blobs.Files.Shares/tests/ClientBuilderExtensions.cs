// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;
extern alias BaseShares;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using BaseShares::Azure.Storage.Files.Shares;
using Azure.Storage.DataMovement.Files.Shares.Tests;
using Azure.Storage.Blobs.Tests;
using SharesClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    BaseShares::Azure.Storage.Files.Shares.ShareServiceClient,
    BaseShares::Azure.Storage.Files.Shares.ShareClientOptions>;
using BlobsClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Blobs.BlobServiceClient,
    Azure.Storage.Blobs.BlobClientOptions>;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Core;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    internal static class ClientBuilderExtensions
    {
        public static string GetNewContainerName(this BlobsClientBuilder clientBuilder)
            => $"test-container-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewShareName(this SharesClientBuilder clientBuilder)
            => $"test-share-{clientBuilder.Recording.Random.NewGuid()}";

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

        /// <summary>
        /// Creates a new <see cref="ClientBuilder{TServiceClient, TServiceClientOptions}"/>
        /// setup to generate <see cref="BlobServiceClient"/>s.
        /// </summary>
        /// <param name="tenants"><see cref="TenantConfigurationBuilder"/> powering this client builder.</param>
        /// <param name="serviceVersion">Service version for clients to target.</param>
        public static SharesClientBuilder GetNewShareClientBuilder(TenantConfigurationBuilder tenants, ShareClientOptions.ServiceVersion serviceVersion)
            => new SharesClientBuilder(
                ServiceEndpoint.File,
                tenants,
                (uri, clientOptions) => new ShareServiceClient(uri, clientOptions),
                (uri, sharedKeyCredential, clientOptions) => new ShareServiceClient(uri, sharedKeyCredential, clientOptions),
                (uri, tokenCredential, clientOptions) => new ShareServiceClient(uri, tokenCredential, clientOptions),
                (uri, azureSasCredential, clientOptions) => new ShareServiceClient(uri, azureSasCredential, clientOptions),
                () => new ShareClientOptions(serviceVersion));

        public static ShareServiceClient GetServiceClient_OAuthAccount_SharedKey(this SharesClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigOAuth);

        public static ShareServiceClient GetServiceClient_OAuth(
            this SharesClientBuilder clientBuilder, TokenCredential tokenCredential, ShareClientOptions options = default)
        {
            options ??= clientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            return clientBuilder.GetServiceClientFromOauthConfig(clientBuilder.Tenants.TestConfigOAuth, tokenCredential, options);
        }

        public static async Task<DisposingShare> GetTestShareAsync(
            this SharesClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            IDictionary<string, string> metadata = default,
            ShareClientOptions options = default)
        {
            service ??= clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigDefault, options);
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            shareName ??= clientBuilder.GetNewShareName();
            ShareClient share = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetShareClient(shareName));
            return await DisposingShare.CreateAsync(share, metadata);
        }

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
                publicAccessType = PublicAccessType.None;
            }

            BlobContainerClient container = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateIfNotExistsAsync(metadata: metadata, publicAccessType: publicAccessType.Value);
            return new DisposingContainer(container);
        }

        public static async Task<DisposingContainer> GetOAuthTestContainerAsync(
            this BlobsClientBuilder clientBuilder,
            string containerName,
            TokenCredential credential)
        {
            containerName ??= clientBuilder.GetNewContainerName();
            BlobServiceClient service = clientBuilder.GetServiceClientFromOauthConfig(clientBuilder.Tenants.TestConfigDefault, credential);
            BlobContainerClient container = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateIfNotExistsAsync();
            return new DisposingContainer(container);
        }
    }
}
