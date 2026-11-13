// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    [DataLakeClientTestFixture]
    public abstract class DataLakeTestBase : StorageTestBase<DataLakeTestEnvironment>
    {
        /// <summary>
        /// Source of clients.
        /// </summary>
        protected ClientBuilder<DataLakeServiceClient, DataLakeClientOptions> DataLakeClientBuilder { get; }

        protected readonly DataLakeClientOptions.ServiceVersion _serviceVersion;
        public readonly string ReceivedETag = "\"received\"";
        public readonly string GarbageETag = "\"garbage\"";
        public readonly string ReceivedLeaseId = "received";
        public readonly string CacheControl = "control";
        public readonly string ContentDisposition = "disposition";
        public readonly string ContentEncoding = "encoding";
        public readonly string ContentLanguage = "language";
        public readonly string ContentType = "type";
        public readonly IList<PathAccessControlItem> AccessControlList
            = PathAccessControlExtensions.ParseAccessControlList("user::rwx,group::r--,other::---,mask::rwx");
        public readonly PathPermissions PathPermissions = PathPermissions.ParseSymbolicPermissions("rwxrwxrwx");
        public readonly IList<PathAccessControlItem> ExecuteOnlyAccessControlList
            = PathAccessControlExtensions.ParseAccessControlList("user::--x,group::--x,other::--x");
        public readonly IList<RemovePathAccessControlItem> RemoveAccessControlList
            = RemovePathAccessControlItem.ParseAccessControlList(
                "mask," +
                "default:user,default:group," +
                "user:ec3595d6-2c17-4696-8caa-7e139758d24a,group:ec3595d6-2c17-4696-8caa-7e139758d24a," +
                "default:user:ec3595d6-2c17-4696-8caa-7e139758d24a,default:group:ec3595d6-2c17-4696-8caa-7e139758d24a");
        public DataLakeTestBase(bool async, DataLakeClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _serviceVersion = serviceVersion;
            DataLakeClientBuilder = ClientBuilderExtensions.GetNewDataLakeClientBuilder(Tenants, _serviceVersion);
        }

        public TenantConfiguration TestConfigHierarchicalNamespace
            => Tenants.TestConfigHierarchicalNamespace;

        public DateTimeOffset OldDate => Recording.Now.AddDays(-1);
        public DateTimeOffset NewDate => Recording.Now.AddDays(1);
        public string GetGarbageLeaseId() => DataLakeClientBuilder.GetGarbageLeaseId();
        public string GetNewFileSystemName() => DataLakeClientBuilder.GetNewFileSystemName();
        public string GetNewDirectoryName() => DataLakeClientBuilder.GetNewDirectoryName();
        public string GetNewNonAsciiDirectoryName() => DataLakeClientBuilder.GetNewNonAsciiDirectoryName();
        public string GetNewFileName() => DataLakeClientBuilder.GetNewFileName();
        public string GetNewNonAsciiFileName() => DataLakeClientBuilder.GetNewNonAsciiFileName();
        public Uri GetDefaultPrimaryEndpoint() => new Uri(DataLakeClientBuilder.Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint);

        public async Task<DisposingFileSystem> GetNewFileSystem(
            DataLakeServiceClient service = default,
            string fileSystemName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default,
            bool premium = default,
            bool hnsEnabled = true,
            DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions = default)
            => await DataLakeClientBuilder.GetNewFileSystem(service, fileSystemName, metadata, publicAccessType, premium, hnsEnabled, encryptionScopeOptions);

        public DataLakeClientOptions GetOptions(bool parallelRange = false)
            => DataLakeClientBuilder.GetOptions(parallelRange);

        public DataLakeClientOptions GetFaultyDataLakeConnectionOptions(
            int raiseAt = default,
            Exception raise = default,
            Action onFault = default)
        {
            raise = raise ?? new IOException("Simulated connection fault");
            DataLakeClientOptions options = GetOptions();
            options.AddPolicy(new FaultyDownloadPipelinePolicy(raiseAt, raise, onFault), HttpPipelinePosition.PerCall);
            return options;
        }

        public DataLakeClientOptions GetOptionsWithAudience(DataLakeAudience audience)
        {
            DataLakeClientOptions options = DataLakeClientBuilder.GetOptions(false);
            options.Audience = audience;
            return options;
        }

        public DataLakeServiceClient GetServiceClientFromOauthConfig(TenantConfiguration config)
            => InstrumentClient(
                new DataLakeServiceClient(
                    (new Uri(config.BlobServiceEndpoint)).ToHttps(),
                    TestEnvironment.Credential,
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_OAuth()
            => GetServiceClientFromOauthConfig(Tenants.TestConfigHierarchicalNamespace);

        public StorageSharedKeyCredential GetStorageSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                TestConfigHierarchicalNamespace.AccountName,
                TestConfigHierarchicalNamespace.AccountKey);

        public TokenCredential GetOAuthHnsCredential()
            => TestEnvironment.Credential;

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

        public void AssertAccessControlListEquality(
            IList<PathAccessControlItem> expected,
             IList<PathAccessControlItem> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (PathAccessControlItem expectedItem in expected)
            {
                PathAccessControlItem actualItem = actual.Where(
                    r => r.AccessControlType == expectedItem.AccessControlType).FirstOrDefault();
                if (actualItem == null)
                {
                    Assert.Fail("AccessControlItem not found");
                }
                AssertPathAccessControlItemEquality(expectedItem, actualItem);
            }
        }

        public void AssertPathAccessControlItemEquality(PathAccessControlItem expected, PathAccessControlItem actual)
        {
            Assert.AreEqual(expected.DefaultScope, actual.DefaultScope);
            Assert.AreEqual(expected.AccessControlType, actual.AccessControlType);
            Assert.AreEqual(expected.EntityId, actual.EntityId);
            Assert.AreEqual(expected.Permissions, actual.Permissions);
        }

        public DataLakeCustomerProvidedKey GetCustomerProvidedKey()
        {
            var bytes = new byte[32];
            Recording.Random.NextBytes(bytes);
            return new DataLakeCustomerProvidedKey(bytes);
        }

        public void AssertPathPermissionsEquality(PathPermissions expected, PathPermissions actual)
        {
            Assert.AreEqual(expected.Owner, actual.Owner);
            Assert.AreEqual(expected.Group, actual.Group);
            Assert.AreEqual(expected.Other, actual.Other);
            Assert.AreEqual(expected.StickyBit, actual.StickyBit);
            Assert.AreEqual(expected.ExtendedAcls, actual.ExtendedAcls);
        }

        public DataLakeServiceClient GetServiceClient_AccountSas(
            StorageSharedKeyCredential sharedKeyCredentials = default,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    new Uri($"{Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewAccountSasCredentials(sharedKeyCredentials ?? Tenants.GetNewHnsSharedKeyCredentials())}"),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_DataLakeServiceSas_FileSystem(
            string fileSystemName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    new Uri($"{Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewDataLakeServiceSasCredentialsFileSystem(fileSystemName: fileSystemName, sharedKeyCredentials: sharedKeyCredentials ?? Tenants.GetNewHnsSharedKeyCredentials())}"),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_DataLakeServiceIdentitySas_FileSystem(
            string fileSystemName,
            UserDelegationKey userDelegationKey,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    (new Uri($"{Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewDataLakeServiceIdentitySasCredentialsFileSystem(fileSystemName: fileSystemName, userDelegationKey, Tenants.TestConfigHierarchicalNamespace.AccountName)}")).ToHttps(),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_DataLakeServiceSas_Path(
            string fileSystemName,
            string path,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    new Uri($"{Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewDataLakeServiceSasCredentialsPath(fileSystemName: fileSystemName, path: path, sharedKeyCredentials: sharedKeyCredentials ?? Tenants.GetNewHnsSharedKeyCredentials())}"),
                    GetOptions()));

        public DataLakeServiceClient GetServiceClient_DataLakeServiceIdentitySas_Path(
            string fileSystemName,
            string path,
            UserDelegationKey userDelegationKey,
            DataLakeSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new DataLakeServiceClient(
                    (new Uri($"{Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasCredentials ?? GetNewDataLakeServiceIdentitySasCredentialsPath(fileSystemName: fileSystemName, path: path, userDelegationKey: userDelegationKey, accountName: Tenants.TestConfigHierarchicalNamespace.AccountName)}")).ToHttps(),
                    GetOptions()));

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
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewHnsSharedKeyCredentials());
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
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewHnsSharedKeyCredentials());
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

        public DataLakeSasQueryParameters GetNewDataLakeServiceSasCredentialsPath(string fileSystemName, string path, bool isDirectory = false, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new DataLakeSasBuilder
            {
                FileSystemName = fileSystemName,
                IsDirectory = isDirectory,
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
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewHnsSharedKeyCredentials());
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

        public DataLakeSasQueryParameters GetNewDataLakeSasCredentialsOwner(string fileSystemName, string ownerName, UserDelegationKey userDelegationKey, string accountName)
        {
            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = fileSystemName,
                AgentObjectId = ownerName
            };
            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);
            return dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public string BlobEndpointToDfsEndpoint(string blobEndpoint = default)
        {
            if (String.IsNullOrEmpty(blobEndpoint))
            {
                blobEndpoint = TestConfigDefault.BlobServiceEndpoint;
            }

            int pos = blobEndpoint.IndexOf(Constants.DataLake.BlobUriSuffix);
            if (pos < 0)
            {
                return blobEndpoint;
            }
            return blobEndpoint.Substring(0, pos) + Constants.DataLake.DfsUriSuffix +
                blobEndpoint.Substring(pos + Constants.DataLake.BlobUriSuffix.Length);
        }

        //TODO consider removing this.
        public async Task<string> SetupPathMatchCondition(DataLakePathClient path, string match)
        {
            if (match == ReceivedETag)
            {
                Response<PathProperties> headers = await path.GetPropertiesAsync();
                return headers.GetRawResponse().Headers.ETag.ToString();
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

        /// <summary>
        /// Gets a custom account SAS where the permissions, services and resourceType
        /// comes back in the string character order that the user inputs it as.
        /// </summary>
        /// <param name="permissions"></param>
        /// <param name="services"></param>
        /// <param name="resourceType"></param>
        /// <param name="sharedKeyCredential"></param>
        /// <returns></returns>
        public override string GetCustomAccountSas(
            string permissions = default,
            string services = default,
            string resourceType = default,
            StorageSharedKeyCredential sharedKeyCredential = default)
        {
            // Default to the HNS credentials instead of the primary credentials in the base method
            sharedKeyCredential ??= Tenants.GetNewHnsSharedKeyCredentials();
            return base.GetCustomAccountSas(permissions, services, resourceType, sharedKeyCredential);
        }

        public Dictionary<string, string> BuildTags()
            => new Dictionary<string, string>
            {
                { "tagKey0", "tagValue0" },
                { "tagKey1", "tagValue1" }
            };

        public DataLakeSignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy =
                        new DataLakeAccessPolicy
                        {
                            PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                            PolicyExpiresOn =  Recording.UtcNow.AddHours(1),
                            Permissions = "rcw"
                        }
                }
            };

        public string[] PathNames
        => new[]
            {
                "foo",
                "bar",
                "baz",
                "baz/bar",
                "foo/foo",
                "foo/bar",
                "baz/foo",
                "baz/foo/bar",
                "baz/bar/foo"
            };

        public void AssertSasUserDelegationKey(Uri uri, UserDelegationKey key)
        {
            DataLakeSasQueryParameters sas = new DataLakeUriBuilder(uri).Sas;
            Assert.AreEqual(key.SignedObjectId, sas.KeyObjectId);
            Assert.AreEqual(key.SignedExpiresOn, sas.KeyExpiresOn);
            Assert.AreEqual(key.SignedService, sas.KeyService);
            Assert.AreEqual(key.SignedStartsOn, sas.KeyStartsOn);
            Assert.AreEqual(key.SignedTenantId, sas.KeyTenantId);
            Assert.AreEqual(key.SignedDelegatedUserTenantId, sas.KeyDelegatedUserTenantId);
            //Assert.AreEqual(key.SignedVersion, sas.Version);
        }
    };
}
