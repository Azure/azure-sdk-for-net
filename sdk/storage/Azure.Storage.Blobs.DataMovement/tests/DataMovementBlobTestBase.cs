// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.DataMovement.Tests;
using Azure.Storage.DataMovement.Tests.Shared;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System.Net;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using System.IO;
using NUnit.Framework;
using Azure.Core;

namespace Azure.Storage.Blobs.DataMovement.Tests.Shared
{
    /// <summary>
    /// Base class for Common tests
    /// </summary>
    [ClientTestFixture(
    BlobClientOptions.ServiceVersion.V2020_06_12,
    BlobClientOptions.ServiceVersion.V2020_08_04,
    RecordingServiceVersion = BlobClientOptions.ServiceVersion.V2020_08_04,
    LiveServiceVersions = new object[] { BlobClientOptions.ServiceVersion.V2020_06_12 })]
    public abstract class DataMovementBlobTestBase : DataMovementTestBase
    {
        /// <summary>
        /// Source of clients.
        /// </summary>
        protected ClientBuilder<BlobServiceClient, BlobClientOptions> BlobsClientBuilder { get; }

        public string GetNewContainerName() => BlobsClientBuilder.GetNewContainerName();
        public string GetNewBlobName() => BlobsClientBuilder.GetNewBlobName();
        public string GetNewBlobDirectoryName() => BlobsClientBuilder.GetNewBlobDirectoryName();
        public string GetNewBlockName() => BlobsClientBuilder.GetNewBlockName();

        public DataMovementBlobTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, serviceVersion, RecordedTestMode.Live /* RecordedTestMode.Record /* to re-record */)
        {
            BlobsClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, _serviceVersion);
        }

        public async Task<DisposingBlobContainer> GetTestContainerAsync(
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default,
            bool premium = default)
            => await BlobsClientBuilder.GetTestContainerAsync(service, containerName, metadata, publicAccessType, premium);

        public BlobClientOptions GetBlobClientOptions(bool parallelRange = false)
            => BlobsClientBuilder.GetOptions(parallelRange);

        internal async Task<BlobBaseClient> GetNewBlobDirectoryClient(BlobContainerClient container, string blobName = default)
        {
            blobName ??= BlobsClientBuilder.GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            return blob;
        }

        private BlobClientOptions GetSecondaryStorageOptions(
            TenantConfiguration config,
            out TestExceptionPolicy testExceptionPolicy,
            int numberOfReadFailuresToSimulate = 1,
            bool simulate404 = false,
            List<RequestMethod> trackedRequestMethods = null)
        {
            BlobClientOptions options = BlobsClientBuilder.GetOptions();
            options.GeoRedundantSecondaryUri = new Uri(config.BlobServiceSecondaryEndpoint);
            options.Retry.MaxRetries = 4;
            testExceptionPolicy = new TestExceptionPolicy(numberOfReadFailuresToSimulate, options.GeoRedundantSecondaryUri, simulate404, trackedRequestMethods);
            options.AddPolicy(testExceptionPolicy, HttpPipelinePosition.PerRetry);
            return options;
        }

        private BlobServiceClient GetSecondaryReadServiceClient(TenantConfiguration config, int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
        {
            BlobClientOptions options = GetSecondaryStorageOptions(config, out testExceptionPolicy, numberOfReadFailuresToSimulate, simulate404, enabledRequestMethods);
            return InstrumentClient(
                 new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options));
        }

        private static TokenCredential GetKeyClientTokenCredential(KeyVaultConfiguration config)
            => new Identity.ClientSecretCredential(
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

        public BlobServiceClient GetServiceClient_BlobServiceSas_Container(
            string containerName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsContainer(containerName: containerName, sharedKeyCredentials: sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Blob(
            string containerName,
            string blobName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsBlob(containerName: containerName, blobName: blobName, sharedKeyCredentials: sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Blob(
            string containerName,
            string blobName,
            UserDelegationKey userDelegationKey,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigOAuth.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceIdentitySasCredentialsBlob(containerName: containerName, blobName: blobName, userDelegationKey: userDelegationKey, accountName: Tenants.TestConfigOAuth.AccountName)}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsContainer(string containerName, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = GetBlobSasBuilder(containerName);
            builder.SetPermissions(BlobContainerSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
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
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
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
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? Tenants.GetNewSharedKeyCredentials());
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
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? Tenants.GetNewSharedKeyCredentials());
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
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? Tenants.GetNewSharedKeyCredentials());
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
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? Tenants.GetNewSharedKeyCredentials());
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

        public BlobServiceClient GetServiceClient_AccountSas(
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? BlobsClientBuilder.GetNewAccountSas(sharedKeyCredentials: sharedKeyCredentials)}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Snapshot(
            string containerName,
            string blobName,
            string snapshot,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsSnapshot(containerName: containerName, blobName: blobName, snapshot: snapshot, sharedKeyCredentials: sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsSnapshot(string containerName, string blobName, string snapshot, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                Protocol = SasProtocol.None,
                StartsOn = Tenants.Recording.UtcNow.AddHours(-1),
                ExpiresOn = Tenants.Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
            };
            builder.SetPermissions(SnapshotSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
        }

        public async Task<PageBlobClient> CreatePageBlobClientAsync(BlobContainerClient container, long size)
        {
            PageBlobClient blob = InstrumentClient(container.GetPageBlobClient(BlobsClientBuilder.GetNewBlobName()));
            await blob.CreateIfNotExistsAsync(size, 0).ConfigureAwait(false);
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
                return new StorageConnectionString(credentials,
                    (new Uri(Tenants.TestConfigDefault.BlobServiceEndpoint), new Uri(Tenants.TestConfigDefault.BlobServiceSecondaryEndpoint)),
                    (new Uri(Tenants.TestConfigDefault.QueueServiceEndpoint), new Uri(Tenants.TestConfigDefault.QueueServiceSecondaryEndpoint)),
                    (new Uri(Tenants.TestConfigDefault.TableServiceEndpoint), new Uri(Tenants.TestConfigDefault.TableServiceSecondaryEndpoint)),
                    (new Uri(Tenants.TestConfigDefault.FileServiceEndpoint), new Uri(Tenants.TestConfigDefault.FileServiceSecondaryEndpoint)));
            }

            (Uri, Uri) blobUri = (new Uri(Tenants.TestConfigDefault.BlobServiceEndpoint), new Uri(Tenants.TestConfigDefault.BlobServiceSecondaryEndpoint));

            (Uri, Uri) tableUri = default;
            if (includeTable)
            {
                tableUri = (new Uri(Tenants.TestConfigDefault.TableServiceEndpoint), new Uri(Tenants.TestConfigDefault.TableServiceSecondaryEndpoint));
            }

            return new StorageConnectionString(
                    credentials,
                    blobStorageUri: blobUri,
                    tableStorageUri: tableUri);
        }

        public async Task EnableSoftDelete()
        {
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
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
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
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

        internal DateTimeOffset RoundToNearestSecond(DateTimeOffset initalDateTimeOffset)
            => new DateTimeOffset(
                year: initalDateTimeOffset.Year,
                month: initalDateTimeOffset.Month,
                day: initalDateTimeOffset.Day,
                hour: initalDateTimeOffset.Hour,
                minute: initalDateTimeOffset.Minute,
                second: initalDateTimeOffset.Second,
                offset: TimeSpan.Zero);

        internal void AssertContentFile(string sourceFile, string destinationFile)
        {
            FileInfo sourceFileInfo = new FileInfo(sourceFile);
            FileInfo destFileInfo = new FileInfo(destinationFile);
            Assert.AreEqual(sourceFileInfo.Length, destFileInfo.Length);
            using (FileStream sourceStream = File.OpenRead(sourceFile))
            {
                using (FileStream resultStream = File.OpenRead(destinationFile))
                {
                    TestHelper.AssertSequenceEqual(sourceStream.AsBytes(), resultStream.AsBytes());
                }
            }
        }
    }
}
