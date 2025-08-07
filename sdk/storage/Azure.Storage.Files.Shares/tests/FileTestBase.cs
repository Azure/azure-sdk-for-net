// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class FileTestBase : StorageTestBase<StorageTestEnvironment>
    {
        /// <summary>
        /// Source of clients.
        /// </summary>
        protected ClientBuilder<ShareServiceClient, ShareClientOptions> SharesClientBuilder { get; }

        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        public static Uri s_invalidUri = new Uri("https://error.file.core.windows.net");

        public FileTestBase(bool async, ShareClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _serviceVersion = serviceVersion;
            SharesClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, _serviceVersion);
        }

        public string GetNewShareName() => SharesClientBuilder.GetNewShareName();
        public string GetNewDirectoryName() => SharesClientBuilder.GetNewDirectoryName();
        public string GetNewNonAsciiDirectoryName() => SharesClientBuilder.GetNewNonAsciiDirectoryName();
        public string GetNewFileName() => SharesClientBuilder.GetNewFileName();
        public string GetNewNonAsciiFileName() => SharesClientBuilder.GetNewNonAsciiFileName();
        public Uri GetDefaultPrimaryEndpoint() => new Uri(SharesClientBuilder.Tenants.TestConfigDefault.FileServiceEndpoint);

        public async Task<DisposingShare> GetTestShareAsync(
            ShareServiceClient service = default,
            string shareName = default,
            IDictionary<string, string> metadata = default,
            ShareClientOptions options = default)
            => await SharesClientBuilder.GetTestShareAsync(service, shareName, metadata, options);

        public ShareClientOptions GetOptions()
        {
            var options = new ShareClientOptions(_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        public ShareClientOptions GetFaultyFileConnectionOptions(
            int raiseAt = default,
            Exception raise = default,
            Action onFault = default)
        {
            raise = raise ?? new IOException("Simulated connection fault");
            ShareClientOptions options = GetOptions();
            options.AddPolicy(new FaultyDownloadPipelinePolicy(raiseAt, raise, onFault), HttpPipelinePosition.PerCall);
            return options;
        }

        public ShareClientOptions GetOptionsWithAudience(ShareAudience audience)
        {
            ShareClientOptions options = SharesClientBuilder.GetOptions(false);
            options.Audience = audience;
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            return options;
        }

        public ShareServiceClient GetServiceClient_AccountSas(StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri($"{TestConfigDefault.FileServiceEndpoint}?{sasCredentials ?? GetNewAccountSasCredentials(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_FileServiceSasShare(string shareName, StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri($"{TestConfigDefault.FileServiceEndpoint}?{sasCredentials ?? GetNewFileServiceSasCredentialsShare(shareName, sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_FileServiceSasFile(string shareName, string filePath, StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri($"{TestConfigDefault.FileServiceEndpoint}?{sasCredentials ?? GetNewFileServiceSasCredentialsFile(shareName, filePath, sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_OAuth()
            => SharesClientBuilder.GetServiceClient_OAuth(TestEnvironment.Credential);

        public ShareServiceClient GetServiceClient_PremiumFileOAuth()
            => SharesClientBuilder.GetServiceClient_PremiumFileOAuth(TestEnvironment.Credential);

        public SasQueryParameters GetNewAccountSasCredentials(StorageSharedKeyCredential sharedKeyCredentials = default,
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.Container,
            AccountSasPermissions permissions = AccountSasPermissions.Create | AccountSasPermissions.Delete)
        {
            var builder = new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = AccountSasServices.Files,
                ResourceTypes = resourceTypes,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(permissions);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
        }

        public SasQueryParameters GetNewFileServiceSasCredentialsShare(
            string shareName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            ShareSasPermissions permissions = ShareSasPermissions.All)
        {
            var builder = new ShareSasBuilder
            {
                ShareName = shareName,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(permissions);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
        }

        public SasQueryParameters GetNewFileServiceSasCredentialsFile(string shareName, string filePath, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new ShareSasBuilder
            {
                ShareName = shareName,
                FilePath = filePath,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(ShareFileSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
        }

        public ShareSignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new ShareSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy =
                        new ShareAccessPolicy
                        {
                            PolicyStartsOn =  Recording.UtcNow.AddHours(-1),
                            PolicyExpiresOn =  Recording.UtcNow.AddHours(1),
                            Permissions = "rw"
                        }
                }
            };

        internal StorageConnectionString GetConnectionString(
            SharedAccessSignatureCredentials credentials = default,
            bool includeEndpoint = true)
        {
            credentials ??= GetAccountSasCredentials();
            if (!includeEndpoint)
            {
                return new StorageConnectionString(
                    credentials,
                    (new Uri(TestConfigDefault.BlobServiceEndpoint), new Uri(TestConfigDefault.BlobServiceSecondaryEndpoint)),
                    (new Uri(TestConfigDefault.QueueServiceEndpoint), new Uri(TestConfigDefault.QueueServiceSecondaryEndpoint)),
                    (new Uri(TestConfigDefault.TableServiceEndpoint), new Uri(TestConfigDefault.TableServiceSecondaryEndpoint)),
                    (new Uri(TestConfigDefault.FileServiceEndpoint), new Uri(TestConfigDefault.FileServiceSecondaryEndpoint)));
            }

            (Uri, Uri) fileUri = (new Uri(TestConfigDefault.FileServiceEndpoint), new Uri(TestConfigDefault.FileServiceSecondaryEndpoint));

            return new StorageConnectionString(
                    credentials,
                    fileStorageUri: fileUri);
        }

        public static void AssertValidStorageFileInfo(ShareFileInfo storageFileInfo)
        {
            Assert.IsNotNull(storageFileInfo.ETag);
            Assert.IsNotNull(storageFileInfo.LastModified);
            Assert.IsNotNull(storageFileInfo.IsServerEncrypted);
            Assert.IsNotNull(storageFileInfo.SmbProperties);
            AssertValidFileSmbProperties(storageFileInfo.SmbProperties);
        }

        public static void AssertValidStorageDirectoryInfo(ShareDirectoryInfo storageDirectoryInfo)
        {
            Assert.IsNotNull(storageDirectoryInfo.ETag);
            Assert.IsNotNull(storageDirectoryInfo.LastModified);
            Assert.IsNotNull(storageDirectoryInfo.SmbProperties);
            AssertValidFileSmbProperties(storageDirectoryInfo.SmbProperties);
        }

        public static void AssertValidFileSmbProperties(FileSmbProperties fileSmbProperties)
        {
            Assert.IsNotNull(fileSmbProperties.FileAttributes);
            Assert.IsNotNull(fileSmbProperties.FilePermissionKey);
            Assert.IsNotNull(fileSmbProperties.FileCreatedOn);
            Assert.IsNotNull(fileSmbProperties.FileLastWrittenOn);
            Assert.IsNotNull(fileSmbProperties.FileChangedOn);
            Assert.IsNotNull(fileSmbProperties.FileId);
            Assert.IsNotNull(fileSmbProperties.ParentId);
        }

        internal static void AssertPropertiesEqual(FileSmbProperties left, FileSmbProperties right)
        {
            Assert.AreEqual(left.FileAttributes, right.FileAttributes);
            Assert.AreEqual(left.FileCreatedOn, right.FileCreatedOn);
            Assert.AreEqual(left.FileChangedOn, right.FileChangedOn);
            Assert.AreEqual(left.FileId, right.FileId);
            Assert.AreEqual(left.FileLastWrittenOn, right.FileLastWrittenOn);
            Assert.AreEqual(left.FilePermissionKey, right.FilePermissionKey);
            Assert.AreEqual(left.ParentId, right.ParentId);
        }
    }
}
