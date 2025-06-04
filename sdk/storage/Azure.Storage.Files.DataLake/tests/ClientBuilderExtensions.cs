// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

using DataLakeClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Files.DataLake.DataLakeServiceClient,
    Azure.Storage.Files.DataLake.DataLakeClientOptions>;

namespace Azure.Storage.Files.DataLake.Tests
{
    public static class ClientBuilderExtensions
    {
        /// <summary>
        /// Creates a new <see cref="ClientBuilder{TServiceClient, TServiceClientOptions}"/>
        /// setup to generate <see cref="DataLakeClientBuilder"/>s.
        /// </summary>
        /// <param name="tenants"><see cref="TenantConfigurationBuilder"/> powering this client builder.</param>
        /// <param name="serviceVersion">Service version for clients to target.</param>
        public static DataLakeClientBuilder GetNewDataLakeClientBuilder(TenantConfigurationBuilder tenants, DataLakeClientOptions.ServiceVersion serviceVersion)
            => new DataLakeClientBuilder(
                ServiceEndpoint.Blob,
                tenants,
                (uri, clientOptions) => new DataLakeServiceClient(uri, clientOptions),
                (uri, sharedKeyCredential, clientOptions) => new DataLakeServiceClient(uri, sharedKeyCredential, clientOptions),
                (uri, tokenCredential, clientOptions) => new DataLakeServiceClient(uri, tokenCredential, clientOptions),
                (uri, azureSasCredential, clientOptions) => new DataLakeServiceClient(uri, azureSasCredential, clientOptions),
                () => new DataLakeClientOptions(serviceVersion));

        public static string GetGarbageLeaseId(this DataLakeClientBuilder clientBuilder)
            => clientBuilder.Recording.Random.NewGuid().ToString();
        public static string GetNewFileSystemName(this DataLakeClientBuilder clientBuilder)
            => $"test-filesystem-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewDirectoryName(this DataLakeClientBuilder clientBuilder)
            => $"test-directory-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiDirectoryName(this DataLakeClientBuilder clientBuilder)
            => $"test-dire¢t Ø®ϒ%3A-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewFileName(this DataLakeClientBuilder clientBuilder)
            => $"test-file-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiFileName(this DataLakeClientBuilder clientBuilder)
            => $"test-ƒ¡£€‽%3A-{clientBuilder.Recording.Random.NewGuid()}";

        public static DataLakeServiceClient GetServiceClient_Hns(this DataLakeClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigHierarchicalNamespace);

        public static DataLakeServiceClient GetServiceClient_NonHns(this DataLakeClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigDefault);

        public static async Task<DisposingFileSystem> GetNewFileSystem(
            this DataLakeClientBuilder clientBuilder,
            DataLakeServiceClient service = default,
            string fileSystemName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default,
            bool premium = default,
            bool hnsEnabled = true,
            DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions = default)
        {
            fileSystemName ??= clientBuilder.GetNewFileSystemName();
            service ??= hnsEnabled ? clientBuilder.GetServiceClient_Hns() : clientBuilder.GetServiceClient_NonHns();

            if (publicAccessType == default)
            {
                publicAccessType = PublicAccessType.None;
            }

            DataLakeFileSystemClient fileSystem = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetFileSystemClient(fileSystemName));

            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                PublicAccessType = publicAccessType.GetValueOrDefault(),
                Metadata = metadata,
                EncryptionScopeOptions = encryptionScopeOptions
            };

            // due to a service issue, if the initial container creation request times out, subsequent requests
            // can return a ContainerAlreadyExists code even though the container doesn't really exist.
            // we delay until after the service cache timeout and then attempt to create the container one more time.
            // If this attempt still fails, we mark the test as inconclusive.
            // TODO Remove this handling after the service bug is fixed https://github.com/Azure/azure-sdk-for-net/issues/9399
            try
            {
                await StorageTestBase<DataLakeTestEnvironment>.RetryAsync(
                    clientBuilder.AzureCoreRecordedTestBase.Recording.Mode,
                    async () => await fileSystem.CreateAsync(options),
                    ex => ex.ErrorCode == Blobs.Models.BlobErrorCode.ContainerAlreadyExists,
                    retryDelay: TestConstants.DataLakeRetryDelay,
                    retryAttempts: 1);
            }
            catch (RequestFailedException storageRequestFailedException)
            when (storageRequestFailedException.ErrorCode == Blobs.Models.BlobErrorCode.ContainerAlreadyExists)
            {
                // if we still get this error after retrying, mark the test as inconclusive
                TestContext.Out.WriteLine(
                    $"{TestContext.CurrentContext.Test.Name} is inconclusive due to hitting " +
                    $"the DataLake service bug described in https://github.com/Azure/azure-sdk-for-net/issues/9399");
                Assert.Inconclusive(); // passing the message in Inconclusive call doesn't show up in Console output.
            }

            return new DisposingFileSystem(fileSystem);
        }
    }
}
