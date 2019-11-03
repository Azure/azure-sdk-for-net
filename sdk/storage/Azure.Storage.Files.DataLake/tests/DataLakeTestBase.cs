// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Files.DataLake.Sas;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public abstract class DataLakeTestBase : StorageTestBase
    {
        public readonly string ReceivedETag = "\"received\"";
        public readonly string GarbageETag = "\"garbage\"";
        public readonly string ReceivedLeaseId = "received";
        public readonly string CacheControl = "control";
        public readonly string ContentDisposition = "disposition";
        public readonly string ContentEncoding = "encoding";
        public readonly string ContentLanguage = "language";
        public readonly string ContentType = "type";
        public readonly string AccessControl = "user::rwx,group::r--,other::---,mask::rwx";

        public DataLakeTestBase(bool async) : this(async, null) { }

        public DataLakeTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode)
        {
        }

        public DateTimeOffset OldDate => Recording.Now.AddDays(-1);
        public DateTimeOffset NewDate => Recording.Now.AddDays(1);
        public string GetGarbageLeaseId() => Recording.Random.NewGuid().ToString();
        public string GetNewFileSystemName() => $"test-filesystem-{Recording.Random.NewGuid()}";
        public string GetNewDirectoryName() => $"test-directory-{Recording.Random.NewGuid()}";
        public string GetNewFileName() => $"test-file-{Recording.Random.NewGuid()}";

        public DataLakeClientOptions GetOptions(bool parallelRange = false)
        {
            var options = new DataLakeClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 10)
                }
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording, parallelRange), HttpPipelinePosition.PerCall);
            }

            return Recording.InstrumentClientOptions(options);
        }

        public DataLakeServiceClient GetServiceClientFromSharedKeyConfig(TenantConfiguration config)
            => InstrumentClient(
                new DataLakeServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClientFromOauthConfig(TenantConfiguration config)
            => InstrumentClient(
                new DataLakeServiceClient(
                    (new Uri(config.BlobServiceEndpoint)).ToHttps(),
                    GetOAuthCredential(config),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_SharedKey()
            => GetServiceClientFromSharedKeyConfig(TestConfigHierarchicalNamespace);

        public DataLakeServiceClient GetServiceClient_OAuth()
            => GetServiceClientFromOauthConfig(TestConfigHierarchicalNamespace);


        public IDisposable GetNewFileSystem(
            out DataLakeFileSystemClient fileSystem,
            DataLakeServiceClient service = default,
            string fileSystemName = default,
            IDictionary<string, string> metadata = default,
            Models.PublicAccessType publicAccessType = Models.PublicAccessType.None,
            bool premium = default)
        {
            fileSystemName ??= GetNewFileSystemName();
            service ??= GetServiceClient_SharedKey();
            fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));

            if (publicAccessType == Models.PublicAccessType.None)
            {
                publicAccessType = premium ? Models.PublicAccessType.None : Models.PublicAccessType.Container;
            }

            return new DisposingFileSystem(
                fileSystem,
                metadata ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase),
                publicAccessType);
        }

        public IDisposable GetNewDirectory(out DataLakeDirectoryClient directory, DataLakeServiceClient service = default, string fileSystemName = default, string directoryName = default)
        {
            IDisposable disposingFileSystem = GetNewFileSystem(out DataLakeFileSystemClient fileSystem, service, fileSystemName);
            directory = InstrumentClient(fileSystem.GetDirectoryClient(directoryName ?? GetNewDirectoryName()));
            _ = directory.CreateAsync().Result;
            return disposingFileSystem;
        }

        public IDisposable GetNewFile(out DataLakeFileClient file, DataLakeServiceClient service = default, string fileSystemName = default, string directoryName = default, string fileName = default)
        {
            IDisposable disposingFileSystem = GetNewFileSystem(out DataLakeFileSystemClient fileSystem, service, fileSystemName);
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(directoryName ?? GetNewDirectoryName()));
            _ = directory.CreateAsync().Result;

            file = InstrumentClient(directory.GetFileClient(fileName ?? GetNewFileName()));
            _ = file.CreateAsync().Result;

            return disposingFileSystem;
        }

        public static void AssertValidStoragePathInfo(PathInfo pathInfo)
        {
            Assert.IsNotNull(pathInfo.ETag);
            Assert.IsNotNull(pathInfo.LastModified);
        }

        public void AssertMetadataEquality(
            IDictionary<string, string> expected,
            IDictionary<string, string> actual,
            bool isDirectory)
        {
            Assert.IsNotNull(expected, "Expected metadata is null");
            Assert.IsNotNull(actual, "Actual metadata is null");

            if (isDirectory)
            {
                Assert.AreEqual(expected.Count + 1, actual.Count, "Metadata counts are not equal");
            }
            else
            {
                Assert.AreEqual(expected.Count, actual.Count, "Metadata counts are not equal");
            }


            foreach (KeyValuePair<string, string> kvp in expected)
            {
                if (!actual.TryGetValue(kvp.Key, out var value) ||
                    string.Compare(kvp.Value, value, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    Assert.Fail($"Expected key <{kvp.Key}> with value <{kvp.Value}> not found");
                }
            }
        }

        public DataLakeServiceClient GetServiceClient_AccountSas(
            StorageSharedKeyCredential sharedKeyCredentials = default,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewAccountSasCredentials(sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_DataLakeServiceSas_FileSystem(
            string fileSystemName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewDataLakeServiceSasCredentialsFileSystem(fileSystemName: fileSystemName, sharedKeyCredentials: sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_DataLakeServiceIdentitySas_FileSystem(
            string fileSystemName,
            UserDelegationKey userDelegationKey,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    (new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewDataLakeServiceIdentitySasCredentialsFileSystem(fileSystemName: fileSystemName, userDelegationKey, TestConfigHierarchicalNamespace.AccountName)}")).ToHttps(),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_DataLakeServiceSas_Path(
            string fileSystemName,
            string path,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewDataLakeServiceSasCredentialsPath(fileSystemName: fileSystemName, path: path, sharedKeyCredentials: sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_DataLakeServiceIdentitySas_Path(
            string fileSystemName,
            string path,
            UserDelegationKey userDelegationKey,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    (new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewDataLakeServiceIdentitySasCredentialsPath(fileSystemName: fileSystemName, path: path, userDelegationKey: userDelegationKey, accountName: TestConfigHierarchicalNamespace.AccountName)}")).ToHttps(),
                    GetOptions()));


        public StorageSharedKeyCredential GetNewSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                    TestConfigHierarchicalNamespace.AccountName,
                    TestConfigHierarchicalNamespace.AccountKey);

        public SasQueryParameters GetNewAccountSasCredentials(StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = AccountSasServices.Blobs,
                ResourceTypes = AccountSasResourceTypes.All,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(
                AccountSasPermissions.Read |
                AccountSasPermissions.Add |
                AccountSasPermissions.Create |
                AccountSasPermissions.Write |
                AccountSasPermissions.Delete |
                AccountSasPermissions.List);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public DataLakeSasQueryParameters GetNewDataLakeServiceSasCredentialsFileSystem(string fileSystemName, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new DataLakeSasBuilder
            {
                FileSystemName = fileSystemName,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(DataLakeFileSystemSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public DataLakeSasQueryParameters GetNewDataLakeServiceIdentitySasCredentialsFileSystem(string fileSystemName, UserDelegationKey userDelegationKey, string accountName)
        {
            var builder = new DataLakeSasBuilder
            {
                FileSystemName = fileSystemName,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(DataLakeFileSystemSasPermissions.All);
            return builder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public DataLakeSasQueryParameters GetNewDataLakeServiceSasCredentialsPath(string fileSystemName, string path, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new DataLakeSasBuilder
            {
                FileSystemName = fileSystemName,
                Path = path,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(
                DataLakeSasPermissions.Read |
                DataLakeSasPermissions.Add |
                DataLakeSasPermissions.Create |
                DataLakeSasPermissions.Delete |
                DataLakeSasPermissions.Write);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public DataLakeSasQueryParameters GetNewDataLakeServiceIdentitySasCredentialsPath(string fileSystemName, string path, UserDelegationKey userDelegationKey, string accountName)
        {
            var builder = new DataLakeSasBuilder
            {
                FileSystemName = fileSystemName,
                Path = path,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(
                DataLakeSasPermissions.Read |
                DataLakeSasPermissions.Add |
                DataLakeSasPermissions.Create |
                DataLakeSasPermissions.Delete |
                DataLakeSasPermissions.Write);
            return builder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        //TODO consider removing this.
        public async Task<string> SetupPathMatchCondition(DataLakePathClient path, string match)
        {
            if (match == ReceivedETag)
            {
                Response<PathProperties> headers = await path.GetPropertiesAsync();
                return headers.Value.ETag.ToString();
            }
            else
            {
                return match;
            }
        }

        //TODO consider removing this.
        public async Task<string> SetupPathLeaseCondition(DataLakePathClient path, string leaseId, string garbageLeaseId)
        {
            Models.DataLakeLease lease = null;
            if (leaseId == ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(path.GetDataLakeLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync(DataLakeLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        //TODO consider removing this.
        public async Task<string> SetupFileSystemLeaseCondition(DataLakeFileSystemClient fileSystem, string leaseId, string garbageLeaseId)
        {
            Models.DataLakeLease lease = null;
            if (leaseId == ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync(DataLakeLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        private class DisposingFileSystem : IDisposable
        {
            public DataLakeFileSystemClient FileSystemClient { get; }

            public DisposingFileSystem(DataLakeFileSystemClient fileSystem, IDictionary<string, string> metadata, Models.PublicAccessType publicAccessType = default)
            {
                fileSystem.CreateAsync(metadata: metadata, publicAccessType: publicAccessType).Wait();

                FileSystemClient = fileSystem;
            }

            public void Dispose()
            {
                if (FileSystemClient != null)
                {
                    try
                    {
                        FileSystemClient.DeleteAsync().Wait();
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }
    }
}
