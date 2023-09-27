// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using SharesClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Files.Shares.ShareServiceClient,
    Azure.Storage.Files.Shares.ShareClientOptions>;

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
    }
}
