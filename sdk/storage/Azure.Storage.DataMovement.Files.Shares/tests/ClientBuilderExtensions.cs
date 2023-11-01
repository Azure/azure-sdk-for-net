// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using SharesClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Files.Shares.ShareServiceClient,
    Azure.Storage.Files.Shares.ShareClientOptions>;
using System.Threading;
using Azure.Core;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    internal static class ClientBuilderExtensions
    {
        public static string GetNewShareName(this SharesClientBuilder clientBuilder)
            => $"test-share-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewDirectoryName(this SharesClientBuilder clientBuilder)
            => $"test-directory-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiDirectoryName(this SharesClientBuilder clientBuilder)
            => $"test-dire¢t Ø®ϒ%3A-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewFileName(this SharesClientBuilder clientBuilder)
            => $"test-file-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiFileName(this SharesClientBuilder clientBuilder)
            => $"test-ƒ¡£€‽%3A-{clientBuilder.Recording.Random.NewGuid()}";

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

        public static async Task<DisposingShare> GetTestShareAsync(
            this SharesClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            IDictionary<string, string> metadata = default,
            ShareClientOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            service ??= clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigDefault, options);
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            shareName ??= clientBuilder.GetNewShareName();
            ShareClient share = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetShareClient(shareName));
            return await DisposingShare.CreateAsync(share, metadata);
        }
    }
}
