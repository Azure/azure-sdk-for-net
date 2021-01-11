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
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    [ClientTestFixture(
        ShareClientOptions.ServiceVersion.V2019_02_02,
        ShareClientOptions.ServiceVersion.V2019_07_07,
        ShareClientOptions.ServiceVersion.V2019_12_12,
        ShareClientOptions.ServiceVersion.V2020_02_10,
        ShareClientOptions.ServiceVersion.V2020_04_08)]
    public class FileTestBase : StorageTestBase
    {
        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        public static Uri s_invalidUri = new Uri("https://error.file.core.windows.net");

        public FileTestBase(bool async, ShareClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _serviceVersion = serviceVersion;
        }

        public string GetNewShareName() => $"test-share-{Recording.Random.NewGuid()}";
        public string GetNewDirectoryName() => $"test-directory-{Recording.Random.NewGuid()}";
        public string GetNewNonAsciiDirectoryName() => $"test-dire¢t Ø®ϒ%3A-{Recording.Random.NewGuid()}";
        public string GetNewFileName() => $"test-file-{Recording.Random.NewGuid()}";
        public string GetNewNonAsciiFileName() => $"test-ƒ¡£€‽%3A-{Recording.Random.NewGuid()}";

        public ShareClientOptions GetOptions()
        {
            var options = new ShareClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
                Transport = GetTransport()
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        public async Task<DisposingShare> GetTestShareAsync(ShareServiceClient service = default, string shareName = default, IDictionary<string, string> metadata = default)
        {
            service ??= GetServiceClient_SharedKey();
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            shareName ??= GetNewShareName();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            return await DisposingShare.CreateAsync(share, metadata);
        }

        public async Task<DisposingDirectory> GetTestDirectoryAsync(ShareServiceClient service = default, string shareName = default, string directoryName = default)
        {
            DisposingShare test = await GetTestShareAsync(service, shareName);
            directoryName ??= GetNewDirectoryName();

            ShareDirectoryClient directory = InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            return await DisposingDirectory.CreateAsync(test, directory);
        }

        public async Task<DisposingFile> GetTestFileAsync(ShareServiceClient service = default, string shareName = default, string directoryName = default, string fileName = default)
        {
            DisposingDirectory test = await GetTestDirectoryAsync(service, shareName, directoryName);
            fileName ??= GetNewFileName();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(fileName));
            return await DisposingFile.CreateAsync(test, file);
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

        public ShareServiceClient GetServiceClient_SharedKey()
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigDefault.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_Premium()
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigPremiumBlob.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigPremiumBlob.AccountName,
                        TestConfigPremiumBlob.AccountKey),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_SoftDelete()
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigSoftDelete.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigSoftDelete.AccountName,
                        TestConfigSoftDelete.AccountKey),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_PremiumFile()
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigPremiumFile.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigPremiumFile.AccountName,
                        TestConfigPremiumFile.AccountKey),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_AccountSas(StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri($"{TestConfigDefault.FileServiceEndpoint}?{sasCredentials ?? GetNewAccountSasCredentials(sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_FileServiceSasShare(string shareName, StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri($"{TestConfigDefault.FileServiceEndpoint}?{sasCredentials ?? GetNewFileServiceSasCredentialsShare(shareName, sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public ShareServiceClient GetServiceClient_FileServiceSasFile(string shareName, string filePath, StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri($"{TestConfigDefault.FileServiceEndpoint}?{sasCredentials ?? GetNewFileServiceSasCredentialsFile(shareName, filePath, sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public StorageSharedKeyCredential GetNewSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                TestConfigDefault.AccountName,
                TestConfigDefault.AccountKey);

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
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public SasQueryParameters GetNewFileServiceSasCredentialsShare(string shareName, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new ShareSasBuilder
            {
                ShareName = shareName,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(ShareSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
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
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
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
                return TestExtensions.CreateStorageConnectionString(
                    credentials,
                    TestConfigDefault.AccountName);
            }

            (Uri, Uri) fileUri = StorageConnectionString.ConstructFileEndpoint(
                Constants.Https,
                TestConfigDefault.AccountName,
                default,
                default);

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

        public class DisposingShare : IAsyncDisposable
        {
            public ShareClient Share { get; private set; }

            public static async Task<DisposingShare> CreateAsync(ShareClient share, IDictionary<string, string> metadata)
            {
                await share.CreateIfNotExistsAsync(metadata: metadata);
                return new DisposingShare(share);
            }

            public DisposingShare(ShareClient share)
            {
                Share = share;
            }

            public async ValueTask DisposeAsync()
            {
                if (Share != null)
                {
                    try
                    {
                        await Share.DeleteIfExistsAsync();
                        Share = null;
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }

        public class DisposingDirectory : IAsyncDisposable
        {
            private DisposingShare _test;

            public ShareClient Share => _test.Share;
            public ShareDirectoryClient Directory { get; }

            public static async Task<DisposingDirectory> CreateAsync(DisposingShare test, ShareDirectoryClient directory)
            {
                await directory.CreateIfNotExistsAsync();
                return new DisposingDirectory(test, directory);
            }

            private DisposingDirectory(DisposingShare test, ShareDirectoryClient directory)
            {
                _test = test;
                Directory = directory;
            }

            public async ValueTask DisposeAsync()
            {
                await _test.DisposeAsync();
            }
        }

        public class DisposingFile : IAsyncDisposable
        {
            private DisposingDirectory _test;

            public ShareClient Share => _test.Share;
            public ShareDirectoryClient Directory => _test.Directory;
            public ShareFileClient File { get; }

            public static async Task<DisposingFile> CreateAsync(DisposingDirectory test, ShareFileClient file)
            {
                await file.CreateAsync(maxSize: Constants.MB);
                return new DisposingFile(test, file);
            }

            private DisposingFile(DisposingDirectory test, ShareFileClient file)
            {
                _test = test;
                File = file;
            }

            public async ValueTask DisposeAsync()
            {
                await _test.DisposeAsync();
            }
        }
    }
}
