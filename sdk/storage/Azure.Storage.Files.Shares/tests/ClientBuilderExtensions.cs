// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test.Shared;
using ShareClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Files.Shares.ShareServiceClient,
    Azure.Storage.Files.Shares.ShareClientOptions>;

namespace Azure.Storage.Files.Shares.Tests
{
    public static class ClientBuilderExtensions
    {
        /// <summary>
        /// Creates a new <see cref="ClientBuilder{TServiceClient, TServiceClientOptions}"/>
        /// setup to generate <see cref="ShareClientBuilder"/>s.
        /// </summary>
        /// <param name="tenants"><see cref="TenantConfigurationBuilder"/> powering this client builder.</param>
        /// <param name="serviceVersion">Service version for clients to target.</param>
        public static ShareClientBuilder GetNewShareClientBuilder(TenantConfigurationBuilder tenants, ShareClientOptions.ServiceVersion serviceVersion)
            => new ShareClientBuilder(
                ServiceEndpoint.File,
                tenants,
                (uri, clientOptions) => new ShareServiceClient(uri, clientOptions),
                (uri, sharedKeyCredential, clientOptions) => new ShareServiceClient(uri, sharedKeyCredential, clientOptions),
                (uri, tokenCredential, clientOptions) => new ShareServiceClient(uri, tokenCredential, clientOptions),
                (uri, azureSasCredential, clientOptions) => new ShareServiceClient(uri, azureSasCredential, clientOptions),
                () => new ShareClientOptions(serviceVersion));

        public static string GetNewShareName(this ShareClientBuilder clientBuilder)
            => $"test-share-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewDirectoryName(this ShareClientBuilder clientBuilder)
            => $"test-directory-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiDirectoryName(this ShareClientBuilder clientBuilder)
            => $"test-dire¢t Ø®ϒ%3A-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewFileName(this ShareClientBuilder clientBuilder)
            => $"test-file-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiFileName(this ShareClientBuilder clientBuilder)
            => $"test-ƒ¡£€‽%3A-{clientBuilder.Recording.Random.NewGuid()}";

        public static ShareServiceClient GetServiceClient_SharedKey(this ShareClientBuilder clientBuilder, ShareClientOptions options = default)
            => clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigDefault, options);

        public static ShareServiceClient GetServiceClient_OAuth(
            this ShareClientBuilder clientBuilder, TokenCredential tokenCredential, ShareClientOptions options = default)
        {
            options ??= clientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            return clientBuilder.GetServiceClientFromOauthConfig(clientBuilder.Tenants.TestConfigOAuth, tokenCredential, options);
        }

        public static ShareServiceClient GetServiceClient_OAuthAccount_SharedKey(this ShareClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigOAuth);

        public static ShareServiceClient GetServiceClient_PremiumFile(this ShareClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigPremiumFile);

        public static ShareServiceClient GetServiceClient_PremiumFileOAuth(
            this ShareClientBuilder clientBuilder,
            TokenCredential tokenCredential,
            ShareClientOptions options = default)
        {
            options ??= clientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            return clientBuilder.GetServiceClientFromOauthConfig(clientBuilder.Tenants.TestConfigPremiumFile, tokenCredential, options);
        }

        public static ShareServiceClient GetServiceClient_SoftDelete(this ShareClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigSoftDelete);

        public static async Task<DisposingShare> GetTestShareAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            IDictionary<string, string> metadata = default,
            ShareClientOptions options = default,
            bool nfs = false)
        {
            service ??= nfs ? clientBuilder.GetServiceClient_PremiumFile() : clientBuilder.GetServiceClient_SharedKey(options);
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            shareName ??= clientBuilder.GetNewShareName();
            ShareClient share = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetShareClient(shareName));
            return await DisposingShare.CreateAsync(share, metadata, nfs);
        }

        public static async Task<DisposingDirectory> GetTestDirectoryAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            string directoryName = default,
            ShareClientOptions options = default,
            bool nfs = false)
        {
            DisposingShare test = await clientBuilder.GetTestShareAsync(service, shareName, options: options, nfs: nfs);
            directoryName ??= clientBuilder.GetNewDirectoryName();

            ShareDirectoryClient directory = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            return await DisposingDirectory.CreateAsync(test, directory);
        }

        public static async Task<DisposingFile> GetTestFileAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            string directoryName = default,
            string fileName = default,
            ShareClientOptions options = default,
            bool nfs = false)
        {
            DisposingDirectory test = await clientBuilder.GetTestDirectoryAsync(service, shareName, directoryName, options, nfs: nfs);
            fileName ??= clientBuilder.GetNewFileName();
            ShareFileClient file = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(test.Directory.GetFileClient(fileName));
            return await DisposingFile.CreateAsync(test, file);
        }
    }
}
