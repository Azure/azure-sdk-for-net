﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    [ClientTestFixture(
        BlobClientOptions.ServiceVersion.V2019_02_02,
        BlobClientOptions.ServiceVersion.V2019_07_07,
        BlobClientOptions.ServiceVersion.V2019_12_12,
        BlobClientOptions.ServiceVersion.V2020_02_10)]
    public abstract class BlobTestBase : StorageTestBase
    {
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;
        public readonly string ReceivedETag = "\"received\"";
        public readonly string GarbageETag = "\"garbage\"";
        public readonly string ReceivedLeaseId = "received";

        protected string SecondaryStorageTenantPrimaryHost() =>
            new Uri(TestConfigSecondary.BlobServiceEndpoint).Host;

        protected string SecondaryStorageTenantSecondaryHost() =>
            new Uri(TestConfigSecondary.BlobServiceSecondaryEndpoint).Host;

        public BlobTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, RecordedTestMode.Playback)
        {
            _serviceVersion = serviceVersion;
        }

        public DateTimeOffset OldDate => Recording.Now.AddDays(-1);
        public DateTimeOffset NewDate => Recording.Now.AddDays(1);

        public string GetGarbageLeaseId() => Recording.Random.NewGuid().ToString();
        public string GetNewContainerName() => $"test-container-{Recording.Random.NewGuid()}";
        public string GetNewBlobName() => $"test-blob-{Recording.Random.NewGuid()}";
        public string GetNewBlockName() => $"test-block-{Recording.Random.NewGuid()}";
        public string GetNewNonAsciiBlobName() => $"test-β£©þ‽%3A-{Recording.Random.NewGuid()}";

        public BlobClientOptions GetOptions(bool parallelRange = false)
        {
            var options = new BlobClientOptions(_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Storage.Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 10)
                },
                Transport = GetTransport()
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording, parallelRange), HttpPipelinePosition.PerCall);
            }

            return Recording.InstrumentClientOptions(options);
        }

        public BlobClientOptions GetFaultyBlobConnectionOptions(
            int raiseAt = default,
            Exception raise = default,
            Action onFault = default)
        {
            raise = raise ?? new IOException("Simulated connection fault");
            BlobClientOptions options = GetOptions();
            options.AddPolicy(new FaultyDownloadPipelinePolicy(raiseAt, raise, onFault), HttpPipelinePosition.PerCall);
            return options;
        }

        private BlobServiceClient GetServiceClientFromSharedKeyConfig(TenantConfiguration config, BlobClientOptions options = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options ?? GetOptions()));

        private BlobServiceClient GetSecondaryReadServiceClient(TenantConfiguration config, int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
        {
            BlobClientOptions options = GetSecondaryStorageOptions(config, out testExceptionPolicy, numberOfReadFailuresToSimulate, simulate404, enabledRequestMethods);
            return InstrumentClient(
                 new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options));
        }

        private BlobBaseClient GetSecondaryReadBlobBaseClient(TenantConfiguration config, int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
        {
            BlobClientOptions options = GetSecondaryStorageOptions(config, out testExceptionPolicy, numberOfReadFailuresToSimulate, simulate404, enabledRequestMethods);
            return InstrumentClient(
                 new BlobBaseClient(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options));
        }

        private BlobContainerClient GetSecondaryReadBlobContainerClient(TenantConfiguration config, int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
        {
            BlobClientOptions options = GetSecondaryStorageOptions(config, out testExceptionPolicy, numberOfReadFailuresToSimulate, simulate404, enabledRequestMethods);
            Uri uri = new Uri(config.BlobServiceEndpoint);
            string containerName = GetNewContainerName();
            return InstrumentClient(
                 new BlobContainerClient(
                    uri.AppendToPath(containerName),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options));
        }

        private BlobClientOptions GetSecondaryStorageOptions(
            TenantConfiguration config,
            out TestExceptionPolicy testExceptionPolicy,
            int numberOfReadFailuresToSimulate = 1,
            bool simulate404 = false,
            List<RequestMethod> trackedRequestMethods = null)
        {
            BlobClientOptions options = GetOptions();
            options.GeoRedundantSecondaryUri = new Uri(config.BlobServiceSecondaryEndpoint);
            options.Retry.MaxRetries = 4;
            testExceptionPolicy = new TestExceptionPolicy(numberOfReadFailuresToSimulate, options.GeoRedundantSecondaryUri, simulate404, trackedRequestMethods);
            options.AddPolicy(testExceptionPolicy, HttpPipelinePosition.PerRetry);
            return options;
        }

        private BlobServiceClient GetServiceClientFromOauthConfig(TenantConfiguration config) =>
            InstrumentClient(
                new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    GetOAuthCredential(config),
                    GetOptions()));

        public BlobServiceClient GetServiceClient_SharedKey(BlobClientOptions options = default)
            => GetServiceClientFromSharedKeyConfig(TestConfigDefault, options);

        public BlobServiceClient GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
            => GetSecondaryReadServiceClient(TestConfigSecondary, numberOfReadFailuresToSimulate, out testExceptionPolicy, simulate404, enabledRequestMethods);

        public BlobBaseClient GetBlobBaseClient_SecondaryAccount_ReadEnabledOnRetry(int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
    => GetSecondaryReadBlobBaseClient(TestConfigSecondary, numberOfReadFailuresToSimulate, out testExceptionPolicy, simulate404, enabledRequestMethods);

        public BlobContainerClient GetBlobContainerClient_SecondaryAccount_ReadEnabledOnRetry(int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
    => GetSecondaryReadBlobContainerClient(TestConfigSecondary, numberOfReadFailuresToSimulate, out testExceptionPolicy, simulate404, enabledRequestMethods);

        public BlobServiceClient GetServiceClient_SecondaryAccount_SharedKey()
            => GetServiceClientFromSharedKeyConfig(TestConfigSecondary);

        public BlobServiceClient GetServiceClient_PreviewAccount_SharedKey()
            => GetServiceClientFromSharedKeyConfig(TestConfigPreviewBlob);

        public BlobServiceClient GetServiceClient_PremiumBlobAccount_SharedKey()
            => GetServiceClientFromSharedKeyConfig(TestConfigPremiumBlob);

        public BlobServiceClient GetServiceClient_OauthAccount() =>
            GetServiceClientFromOauthConfig(TestConfigOAuth);

        public BlobServiceClient GetServiceClient_ManagedDisk() =>
            GetServiceClientFromSharedKeyConfig(TestConfigManagedDisk);

        public BlobServiceClient GetServiceClient_Hns() =>
            GetServiceClientFromSharedKeyConfig(TestConfigHierarchicalNamespace);

        public BlobServiceClient GetServiceClient_SoftDelete() =>
            GetServiceClientFromSharedKeyConfig(TestConfigSoftDelete);

        public BlobServiceClient GetServiceClient_AccountSas(
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewAccountSas(sharedKeyCredentials: sharedKeyCredentials)}"),
                    GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Container(
            string containerName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsContainer(containerName: containerName, sharedKeyCredentials: sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Container(
            string containerName,
            UserDelegationKey userDelegationKey,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigOAuth.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceIdentitySasCredentialsContainer(containerName: containerName, userDelegationKey, TestConfigOAuth.AccountName)}"),
                    GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Blob(
            string containerName,
            string blobName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsBlob(containerName: containerName, blobName: blobName, sharedKeyCredentials: sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Blob(
            string containerName,
            string blobName,
            UserDelegationKey userDelegationKey,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigOAuth.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceIdentitySasCredentialsBlob(containerName: containerName, blobName: blobName, userDelegationKey: userDelegationKey, accountName: TestConfigOAuth.AccountName)}"),
                    GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Snapshot(
            string containerName,
            string blobName,
            string snapshot,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsSnapshot(containerName: containerName, blobName: blobName, snapshot: snapshot, sharedKeyCredentials: sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public Security.KeyVault.Keys.KeyClient GetKeyClient_TargetKeyClient()
            => GetKeyClient(TestConfigurations.DefaultTargetKeyVault);

        public TokenCredential GetTokenCredential_TargetKeyClient()
            => GetKeyClientTokenCredential(TestConfigurations.DefaultTargetKeyVault);

        private static Security.KeyVault.Keys.KeyClient GetKeyClient(KeyVaultConfiguration config)
            => new Security.KeyVault.Keys.KeyClient(
                new Uri(config.VaultEndpoint),
                GetKeyClientTokenCredential(config));

        private static TokenCredential GetKeyClientTokenCredential(KeyVaultConfiguration config)
            => new Identity.ClientSecretCredential(
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

        public async Task<DisposingContainer> GetTestContainerAsync(
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default,
            bool premium = default)
        {

            containerName ??= GetNewContainerName();
            service ??= GetServiceClient_SharedKey();

            if (publicAccessType == default)
            {
                publicAccessType = premium ? PublicAccessType.None : PublicAccessType.BlobContainer;
            }

            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateAsync(metadata: metadata, publicAccessType: publicAccessType.Value);
            return new DisposingContainer(container);
        }


        public StorageSharedKeyCredential GetNewSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                    TestConfigDefault.AccountName,
                    TestConfigDefault.AccountKey);

        public SasQueryParameters GetNewAccountSas(
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All,
            AccountSasPermissions permissions = AccountSasPermissions.All,
            StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = AccountSasServices.Blobs,
                ResourceTypes = resourceTypes,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
                Version = ToSasVersion(_serviceVersion)
            };
            builder.SetPermissions(permissions);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsContainer(string containerName, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = GetBlobSasBuilder(containerName);
            builder.SetPermissions(BlobContainerSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetNewBlobServiceIdentitySasCredentialsContainer(string containerName, UserDelegationKey userDelegationKey, string accountName)
        {
            var builder = GetBlobSasBuilder(containerName);
            builder.SetPermissions(BlobContainerSasPermissions.All);
            return builder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsBlob(string containerName, string blobName, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            BlobSasBuilder builder = GetBlobSasBuilder(containerName, blobName);
            builder.SetPermissions(
                BlobSasPermissions.Read |
                BlobSasPermissions.Add |
                BlobSasPermissions.Create |
                BlobSasPermissions.Delete |
                BlobSasPermissions.Write);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetBlobSas(
            string containerName,
            string blobName,
            BlobSasPermissions permissions,
            StorageSharedKeyCredential sharedKeyCredential = default,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetBlobIdentitySas(
            string containerName,
            string blobName,
            BlobSasPermissions permissions,
            UserDelegationKey userDelegationKey,
            string accountName,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetContainerSas(
            string containerName,
            BlobContainerSasPermissions permissions,
            StorageSharedKeyCredential sharedKeyCredential = default,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetContainerIdentitySas(
            string containerName,
            BlobContainerSasPermissions permissions,
            UserDelegationKey userDelegationKey,
            string accountName,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetSnapshotSas(
            string containerName,
            string blobName,
            string snapshot,
            SnapshotSasPermissions permissions,
            StorageSharedKeyCredential sharedKeyCredential = default,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, snapshot: snapshot, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetSnapshotIdentitySas(
            string containerName,
            string blobName,
            string snapshot,
            SnapshotSasPermissions permissions,
            UserDelegationKey userDelegationKey,
            string accountName,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, snapshot: snapshot, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetBlobVersionSas(
            string containerName,
            string blobName,
            string blobVersion,
            BlobVersionSasPermissions permissions,
            StorageSharedKeyCredential sharedKeyCredential = default,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, blobVersion: blobVersion, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetBlobVersionIdentitySas(
            string containerName,
            string blobName,
            string blobVersion,
            BlobVersionSasPermissions permissions,
            UserDelegationKey userDelegationKey,
            string accountName,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, blobVersion: blobVersion, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        private BlobSasBuilder GetBlobSasBuilder(
            string containerName,
            string blobName = default,
            string snapshot = default,
            string blobVersion = default,
            string sasVersion = default)
            => new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                BlobVersionId = blobVersion,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
                Version = sasVersion ?? ToSasVersion(BlobClientOptions.ServiceVersion.V2020_02_10)
            };

        public BlobSasQueryParameters GetNewBlobServiceIdentitySasCredentialsBlob(string containerName, string blobName, UserDelegationKey userDelegationKey, string accountName)
        {
            var builder = GetBlobSasBuilder(containerName, blobName);
            builder.SetPermissions(
                BlobSasPermissions.Read |
                BlobSasPermissions.Add |
                BlobSasPermissions.Create |
                BlobSasPermissions.Delete |
                BlobSasPermissions.Write);
            return builder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsSnapshot(string containerName, string blobName, string snapshot, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
                Version = ToSasVersion(_serviceVersion)
            };
            builder.SetPermissions(SnapshotSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public static string ToSasVersion(BlobClientOptions.ServiceVersion serviceVersion)
        {
            return serviceVersion switch
            {
                BlobClientOptions.ServiceVersion.V2019_02_02 => "2019-02-02",
                BlobClientOptions.ServiceVersion.V2019_07_07 => "2019-07-07",
                BlobClientOptions.ServiceVersion.V2019_12_12 => "2019-12-12",
                BlobClientOptions.ServiceVersion.V2020_02_10 => "2020-02-10",
                _ => throw new ArgumentException("Invalid service version"),
            };
        }

        public async Task<PageBlobClient> CreatePageBlobClientAsync(BlobContainerClient container, long size)
        {
            PageBlobClient blob = InstrumentClient(container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(size, 0).ConfigureAwait(false);
            return blob;
        }

        public string ToBase64(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }

        public CustomerProvidedKey GetCustomerProvidedKey()
        {
            var bytes = new byte[32];
            Recording.Random.NextBytes(bytes);
            return new CustomerProvidedKey(bytes);
        }

        public Uri GetHttpsUri(Uri uri)
        {
            var uriBuilder = new UriBuilder(uri)
            {
                Scheme = TestConstants.Https,
                Port = TestConstants.HttpPort
            };
            return uriBuilder.Uri;
        }

        //TODO consider removing this.
        public async Task<string> SetupBlobMatchCondition(BlobBaseClient blob, string match)
        {
            if (match == ReceivedETag)
            {
                Response<BlobProperties> headers = await blob.GetPropertiesAsync();
                return headers.Value.ETag.ToString();
            }
            else
            {
                return match;
            }
        }

        //TODO consider removing this.
        public async Task<string> SetupBlobLeaseCondition(BlobBaseClient blob, string leaseId, string garbageLeaseId)
        {
            BlobLease lease = null;
            if (leaseId == ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(blob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync(BlobLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        //TODO consider removing this.
        public async Task<string> SetupContainerLeaseCondition(BlobContainerClient container, string leaseId, string garbageLeaseId)
        {
            BlobLease lease = null;
            if (leaseId == ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(container.GetBlobLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync(BlobLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        public BlobSignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new BlobSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new BlobAccessPolicy()
                    {
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        PolicyExpiresOn = Recording.UtcNow.AddHours(1),
                        Permissions = "rw"
                    }
                }
            };

        internal StorageConnectionString GetConnectionString(
            SharedAccessSignatureCredentials credentials = default,
            bool includeEndpoint = true,
            bool includeTable = false)
        {
            credentials ??= GetAccountSasCredentials();
            if (!includeEndpoint)
            {
                return TestExtensions.CreateStorageConnectionString(
                    credentials,
                    TestConfigDefault.AccountName);
            }

            (Uri, Uri) blobUri = StorageConnectionString.ConstructBlobEndpoint(
                Constants.Https,
                TestConfigDefault.AccountName,
                default,
                default);

            (Uri, Uri) tableUri = default;
            if (includeTable)
            {
                tableUri = StorageConnectionString.ConstructTableEndpoint(
                    Constants.Https,
                    TestConfigDefault.AccountName,
                    default,
                    default);
            }

            return new StorageConnectionString(
                    credentials,
                    blobStorageUri: blobUri,
                    tableStorageUri: tableUri);
        }

        public async Task EnableSoftDelete()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            Response<BlobServiceProperties> properties = await service.GetPropertiesAsync();
            properties.Value.DeleteRetentionPolicy = new BlobRetentionPolicy()
            {
                Enabled = true,
                Days = 2
            };
            await service.SetPropertiesAsync(properties);

            do
            {
                await Delay(250);
                properties = await service.GetPropertiesAsync();
            } while (!properties.Value.DeleteRetentionPolicy.Enabled);
        }

        public async Task DisableSoftDelete()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            Response<BlobServiceProperties> properties = await service.GetPropertiesAsync();
            properties.Value.DeleteRetentionPolicy = new BlobRetentionPolicy() { Enabled = false };
            await service.SetPropertiesAsync(properties);

            do
            {
                await Delay(250);
                properties = await service.GetPropertiesAsync();
            } while (properties.Value.DeleteRetentionPolicy.Enabled);
        }

        public Dictionary<string, string> BuildTags()
            => new Dictionary<string, string>
            {
                { "tagKey0", "tagValue0" },
                { "tagKey1", "tagValue1" }
            };

        public class DisposingContainer : IAsyncDisposable
        {
            public BlobContainerClient Container;

            public DisposingContainer(BlobContainerClient client)
            {
                Container = client;
            }

            public async ValueTask DisposeAsync()
            {
                if (Container != null)
                {
                    try
                    {
                        await Container.DeleteAsync();
                        Container = null;
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }

        public class BlobQueryErrorHandler
        {
            private readonly BlobQueryError _expectedBlobQueryError;

            public BlobQueryErrorHandler(BlobQueryError expected)
            {
                _expectedBlobQueryError = expected;
            }

            public void Handle(BlobQueryError blobQueryError)
            {
                Assert.AreEqual(_expectedBlobQueryError.IsFatal, blobQueryError.IsFatal);
                Assert.AreEqual(_expectedBlobQueryError.Name, blobQueryError.Name);
                Assert.AreEqual(_expectedBlobQueryError.Description, blobQueryError.Description);
                Assert.AreEqual(_expectedBlobQueryError.Position, blobQueryError.Position);
            }
        }
    }
}
