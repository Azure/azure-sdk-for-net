// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Test
{
    partial class TestHelper
    {
        public static string GetNewContainerName() => $"test-container-{Guid.NewGuid()}";
        public static string GetNewBlobName() => $"test-blob-{Guid.NewGuid()}";
        public static string GetNewBlockName() => $"test-block-{Guid.NewGuid()}";

        public static DateTimeOffset OldDate = DateTimeOffset.Now.AddDays(-1);
        public static DateTimeOffset NewDate = DateTimeOffset.Now.AddDays(1);
        public static string ReceivedETag = "\"received\"";
        public static string GarbageETag = "\"garbage\"";
        public static string ReceivedLeaseId = "received";
        public static string GarbageLeaseId = Guid.NewGuid().ToString();

        public static BlobConnectionOptions GetFaultyBlobConnectionOptions(
            SharedKeyCredentials credentials = null,
            int raiseAt = default,
            Exception raise = default)
        {
            raise = raise ?? new Exception("Simulated connection fault");
            var options = GetOptions<BlobConnectionOptions>(credentials);
            options.PerCallPolicies.Add(new FaultyDownloadPipelinePolicy(raiseAt, raise));
            return options;
        }
        
        private static BlobServiceClient GetServiceClientFromSharedKeyConfig(TenantConfiguration config)
            => new BlobServiceClient(
                new Uri(config.BlobServiceEndpoint),
                GetOptions<BlobConnectionOptions>(new SharedKeyCredentials(config.AccountName, config.AccountKey)));

        private static async Task<BlobServiceClient> GetServiceClientFromOauthConfig(TenantConfiguration config)
        {
            var initalToken = await TestHelper.GenerateOAuthToken(
                config.ActiveDirectoryAuthEndpoint,
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

            return new BlobServiceClient(
                new Uri(config.BlobServiceEndpoint),
                GetOptions<BlobConnectionOptions>(new TokenCredentials(initalToken)));
        }

        public static BlobServiceClient GetServiceClient_SharedKey()
            => GetServiceClientFromSharedKeyConfig(TestConfigurations.DefaultTargetTenant);
        
        public static BlobServiceClient GetServiceClient_SecondaryAccount_SharedKey()
            => GetServiceClientFromSharedKeyConfig(TestConfigurations.DefaultSecondaryTargetTenant);

        public static BlobServiceClient GetServiceClient_PreviewAccount_SharedKey()
            => GetServiceClientFromSharedKeyConfig(TestConfigurations.DefaultTargetPreviewBlobTenant);

        public static async Task<BlobServiceClient> GetServiceClient_OauthAccount()
            => await GetServiceClientFromOauthConfig(TestConfigurations.DefaultTargetOAuthTenant);

        public static BlobServiceClient GetServiceClient_AccountSas(
            SharedKeyCredentials sharedKeyCredentials = default,
            SasQueryParameters sasCredentials = default)
            => new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint}?{sasCredentials ?? GetNewAccountSasCredentials(sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<BlobConnectionOptions>());

        public static BlobServiceClient GetServiceClient_BlobServiceSas_Container(
            string containerName,
            SharedKeyCredentials sharedKeyCredentials = default,
            SasQueryParameters sasCredentials = default)
            => new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsContainer(containerName: containerName, sharedKeyCredentials: sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<BlobConnectionOptions>());

        public static BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Container(
            string containerName,
            UserDelegationKey userDelegationKey,
            SasQueryParameters sasCredentials = default)
            => new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetOAuthTenant.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceIdentitySasCredentialsContainer(containerName: containerName, userDelegationKey, TestConfigurations.DefaultTargetOAuthTenant.AccountName)}"),
                    GetOptions<BlobConnectionOptions>());

        public static BlobServiceClient GetServiceClient_BlobServiceSas_Blob(
            string containerName,
            string blobName,
            SharedKeyCredentials sharedKeyCredentials = default,
            SasQueryParameters sasCredentials = default)
            => new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsBlob(containerName: containerName, blobName: blobName, sharedKeyCredentials: sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<BlobConnectionOptions>());

        public static BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Blob(
            string containerName,
            string blobName,
            UserDelegationKey userDelegationKey,
            SasQueryParameters sasCredentials = default)
            => new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetOAuthTenant.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceIdentitySasCredentialsBlob(containerName: containerName, blobName: blobName, userDelegationKey: userDelegationKey, accountName: TestConfigurations.DefaultTargetOAuthTenant.AccountName)}"),
                    GetOptions<BlobConnectionOptions>());

        public static BlobServiceClient GetServiceClient_BlobServiceSas_Snapshot(
            string containerName,
            string blobName,
            string snapshot,
            SharedKeyCredentials sharedKeyCredentials = default,
            SasQueryParameters sasCredentials = default)
            => new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsSnapshot(containerName: containerName, blobName: blobName, snapshot: snapshot, sharedKeyCredentials: sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<BlobConnectionOptions>());

        public static IDisposable GetNewContainer(
            out BlobContainerClient container, 
            BlobServiceClient service = default, 
            string containerName = default, 
            IDictionary<string, string> metadata = default, 
            PublicAccessType? publicAccessType = default)
        {
            containerName = containerName ?? TestHelper.GetNewContainerName();

            service = service ?? GetServiceClient_SharedKey();

            var result = new DisposingContainer(service.GetBlobContainerClient(containerName), metadata ?? new Dictionary<string, string>(), publicAccessType ?? PublicAccessType.Container);

            container = result.ContainerClient;

            return result;
        }
        
        public static SharedKeyCredentials GetNewSharedKeyCredentials()
            => new SharedKeyCredentials(
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey);

        public static SasQueryParameters GetNewAccountSasCredentials(SharedKeyCredentials sharedKeyCredentials = default)
            => new AccountSasSignatureValues
            {
                Protocol = SasProtocol.None,
                Services = new AccountSasServices { Blob = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { Container = true, Object = true }.ToString(),
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials);

        public static SasQueryParameters GetNewBlobServiceSasCredentialsContainer(string containerName, SharedKeyCredentials sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                Protocol = SasProtocol.None,
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());

        public static SasQueryParameters GetNewBlobServiceIdentitySasCredentialsContainer(string containerName, UserDelegationKey userDelegationKey, string accountName)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                Protocol = SasProtocol.None,
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(userDelegationKey, accountName);

        public static SasQueryParameters GetNewBlobServiceSasCredentialsBlob(string containerName, string blobName, SharedKeyCredentials sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Protocol = SasProtocol.None,
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new BlobSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());

        public static SasQueryParameters GetNewBlobServiceIdentitySasCredentialsBlob(string containerName, string blobName, UserDelegationKey userDelegationKey, string accountName)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Protocol = SasProtocol.None,
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new BlobSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(userDelegationKey, accountName);

        public static SasQueryParameters GetNewBlobServiceSasCredentialsSnapshot(string containerName, string blobName, string snapshot, SharedKeyCredentials sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                Protocol = SasProtocol.None,
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new SnapshotSasPermissions { Read = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());

        public static async Task<PageBlobClient> CreatePageBlobClientAsync(BlobContainerClient container, long size)
        {
            var blob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
            await blob.CreateAsync(size, 0)
                .ConfigureAwait(false);
            return blob;
        }

        public static string ToBase64(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }

        //TODO consider removing this.
        public static async Task<string> SetupBlobMatchCondition(BlobClient blob, string match)
        {
            if(match == ReceivedETag)
            {
                var headers = await blob.GetPropertiesAsync();
                return headers.Value.ETag.ToString();
            }
            else
            {
                return match;
            }
        }

        //TODO consider removing this.
        public static async Task<string> SetupBlobLeaseCondition(BlobClient blob, string leaseId)
        {
            Lease lease = null;
            if (leaseId == ReceivedLeaseId || leaseId == GarbageLeaseId)
            {
                lease = await blob.AcquireLeaseAsync(-1);
            }
            return leaseId == ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        //TODO consider removing this.
        public static async Task<string> SetupContainerLeaseCondition(BlobContainerClient container, string leaseId)
        {
            Lease lease = null;
            if (leaseId == ReceivedLeaseId || leaseId == GarbageLeaseId)
            {
                lease = await container.AcquireLeaseAsync(-1);
            }
            return leaseId == ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        public static SignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new SignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy =
                        new AccessPolicy
                        {
                            Start =  DateTimeOffset.UtcNow.AddHours(-1),
                            Expiry =  DateTimeOffset.UtcNow.AddHours(1),
                            Permission = "rw"
                        }
                }
            };

        public static async Task EnableSoftDelete()
        {
            var service = GetServiceClient_SharedKey();
            var properties = await service.GetPropertiesAsync();
            properties.Value.DeleteRetentionPolicy = new RetentionPolicy
            {
                Enabled = true,
                Days = 2
            };
            await service.SetPropertiesAsync(properties);

            do
            {
                await Task.Delay(250);
                properties = await service.GetPropertiesAsync();
            } while (!properties.Value.DeleteRetentionPolicy.Enabled);
        }

        public static async Task DisableSoftDelete()
        {
            var service = GetServiceClient_SharedKey();
            var properties = await service.GetPropertiesAsync();
            properties.Value.DeleteRetentionPolicy = new RetentionPolicy
            {
                Enabled = false
            };
            await service.SetPropertiesAsync(properties);

            do
            {
                await Task.Delay(250);
                properties = await service.GetPropertiesAsync();
            } while (properties.Value.DeleteRetentionPolicy.Enabled);
        }

        class DisposingContainer : IDisposable
        {
            public BlobContainerClient ContainerClient { get; }

            public DisposingContainer(BlobContainerClient container, IDictionary<string, string> metadata, PublicAccessType publicAccessType)
            {
                container.CreateAsync(metadata: metadata, publicAccessType: publicAccessType).Wait();

                this.ContainerClient = container;
            }

            public void Dispose()
            {
                if (this.ContainerClient != null)
                {
                    try
                    {
                        this.ContainerClient.DeleteAsync().Wait();
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
