// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    public abstract class BlobTestBase : StorageTestBase
    {
        public readonly string ReceivedETag = "\"received\"";
        public readonly string GarbageETag = "\"garbage\"";
        public readonly string ReceivedLeaseId = "received";

        public BlobTestBase(RecordedTestMode? mode = null)
            : base(mode)
        {
        }

        public DateTimeOffset OldDate => this.Recording.Now.AddDays(-1);
        public DateTimeOffset NewDate => this.Recording.Now.AddDays(1);

        public string GetGarbageLeaseId() => this.Recording.Random.NewGuid().ToString();
        public string GetNewContainerName() => $"test-container-{this.Recording.Random.NewGuid()}";
        public string GetNewBlobName() => $"test-blob-{this.Recording.Random.NewGuid()}";
        public string GetNewBlockName() => $"test-block-{this.Recording.Random.NewGuid()}";

        public BlobConnectionOptions GetOptions(IStorageCredentials credentials = null)
            => this.Recording.InstrumentClientOptions(
                    new BlobConnectionOptions
                    {
                        Credentials = credentials,
                        ResponseClassifier = new TestResponseClassifier(),
                        Diagnostics = { DisableLogging = false },
                        Retry =
                        {
                            Mode = RetryMode.Exponential,
                            MaxRetries = Azure.Storage.Constants.MaxReliabilityRetries,
                            Delay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                            MaxDelay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.1 : 10)
                        }
                    });

        public BlobConnectionOptions GetFaultyBlobConnectionOptions(
            SharedKeyCredentials credentials = null,
            int raiseAt = default,
            Exception raise = default)
        {
            raise = raise ?? new Exception("Simulated connection fault");
            var options = this.GetOptions(credentials);
            options.AddPolicy(HttpPipelinePosition.PerCall, new FaultyDownloadPipelinePolicy(raiseAt, raise));
            return options;
        }

        private BlobServiceClient GetServiceClientFromSharedKeyConfig(TenantConfiguration config)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    this.GetOptions(new SharedKeyCredentials(config.AccountName, config.AccountKey))));

        private async Task<BlobServiceClient> GetServiceClientFromOauthConfig(TenantConfiguration config)
        {
            var initalToken = await this.GenerateOAuthToken(
                config.ActiveDirectoryAuthEndpoint,
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

            return this.InstrumentClient(
                new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    this.GetOptions(new TokenCredentials(initalToken))));
        }

        public BlobServiceClient GetServiceClient_SharedKey()
            => this.GetServiceClientFromSharedKeyConfig(TestConfigurations.DefaultTargetTenant);

        public BlobServiceClient GetServiceClient_SecondaryAccount_SharedKey()
            => this.GetServiceClientFromSharedKeyConfig(TestConfigurations.DefaultSecondaryTargetTenant);

        public BlobServiceClient GetServiceClient_PreviewAccount_SharedKey()
            => this.GetServiceClientFromSharedKeyConfig(TestConfigurations.DefaultTargetPreviewBlobTenant);

        public async Task<BlobServiceClient> GetServiceClient_OauthAccount()
            => await this.GetServiceClientFromOauthConfig(TestConfigurations.DefaultTargetOAuthTenant);

        public BlobServiceClient GetServiceClient_AccountSas(
            SharedKeyCredentials sharedKeyCredentials = default,
            SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewAccountSasCredentials(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Container(
            string containerName,
            SharedKeyCredentials sharedKeyCredentials = default,
            SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceSasCredentialsContainer(containerName: containerName, sharedKeyCredentials: sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Container(
            string containerName,
            UserDelegationKey userDelegationKey,
            SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetOAuthTenant.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceIdentitySasCredentialsContainer(containerName: containerName, userDelegationKey, TestConfigurations.DefaultTargetOAuthTenant.AccountName)}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Blob(
            string containerName,
            string blobName,
            SharedKeyCredentials sharedKeyCredentials = default,
            SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceSasCredentialsBlob(containerName: containerName, blobName: blobName, sharedKeyCredentials: sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Blob(
            string containerName,
            string blobName,
            UserDelegationKey userDelegationKey,
            SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetOAuthTenant.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceIdentitySasCredentialsBlob(containerName: containerName, blobName: blobName, userDelegationKey: userDelegationKey, accountName: TestConfigurations.DefaultTargetOAuthTenant.AccountName)}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Snapshot(
            string containerName,
            string blobName,
            string snapshot,
            SharedKeyCredentials sharedKeyCredentials = default,
            SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceSasCredentialsSnapshot(containerName: containerName, blobName: blobName, snapshot: snapshot, sharedKeyCredentials: sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public IDisposable GetNewContainer(
            out BlobContainerClient container,
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default)
        {
            containerName = containerName ?? this.GetNewContainerName();
            service = service ?? this.GetServiceClient_SharedKey();
            var result = new DisposingContainer(
                this.InstrumentClient(service.GetBlobContainerClient(containerName)),
                metadata ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase),
                publicAccessType ?? PublicAccessType.Container);
            container = this.InstrumentClient(result.ContainerClient);
            return result;
        }

        public SharedKeyCredentials GetNewSharedKeyCredentials()
            => new SharedKeyCredentials(
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey);

        public SasQueryParameters GetNewAccountSasCredentials(SharedKeyCredentials sharedKeyCredentials = default)
            => new AccountSasSignatureValues
            {
                Protocol = SasProtocol.None,
                Services = new AccountSasServices { Blob = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { Container = true, Object = true }.ToString(),
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials);

        public SasQueryParameters GetNewBlobServiceSasCredentialsContainer(string containerName, SharedKeyCredentials sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials());

        public SasQueryParameters GetNewBlobServiceIdentitySasCredentialsContainer(string containerName, UserDelegationKey userDelegationKey, string accountName)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(userDelegationKey, accountName);

        public SasQueryParameters GetNewBlobServiceSasCredentialsBlob(string containerName, string blobName, SharedKeyCredentials sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new BlobSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials());

        public SasQueryParameters GetNewBlobServiceIdentitySasCredentialsBlob(string containerName, string blobName, UserDelegationKey userDelegationKey, string accountName)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new BlobSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(userDelegationKey, accountName);

        public SasQueryParameters GetNewBlobServiceSasCredentialsSnapshot(string containerName, string blobName, string snapshot, SharedKeyCredentials sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new SnapshotSasPermissions { Read = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials());

        public async Task<PageBlobClient> CreatePageBlobClientAsync(BlobContainerClient container, long size)
        {
            var blob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
            await blob.CreateAsync(size, 0).ConfigureAwait(false);
            return blob;
        }

        public string ToBase64(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }

        //TODO consider removing this.
        public async Task<string> SetupBlobMatchCondition(BlobClient blob, string match)
        {
            if (match == this.ReceivedETag)
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
        public async Task<string> SetupBlobLeaseCondition(BlobClient blob, string leaseId, string garbageLeaseId)
        {
            Lease lease = null;
            if (leaseId == this.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await blob.AcquireLeaseAsync(-1);
            }
            return leaseId == this.ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        //TODO consider removing this.
        public async Task<string> SetupContainerLeaseCondition(BlobContainerClient container, string leaseId, string garbageLeaseId)
        {
            Lease lease = null;
            if (leaseId == this.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await container.AcquireLeaseAsync(-1);
            }
            return leaseId == this.ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        public SignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new SignedIdentifier
                {
                    Id = this.GetNewString(),
                    AccessPolicy =
                        new AccessPolicy
                        {
                            Start = this.Recording.UtcNow.AddHours(-1),
                            Expiry =  this.Recording.UtcNow.AddHours(1),
                            Permission = "rw"
                        }
                }
            };

        public async Task EnableSoftDelete()
        {
            var service = this.GetServiceClient_SharedKey();
            var properties = await service.GetPropertiesAsync();
            properties.Value.DeleteRetentionPolicy = new RetentionPolicy
            {
                Enabled = true,
                Days = 2
            };
            await service.SetPropertiesAsync(properties);

            do
            {
                await this.Delay(250);
                properties = await service.GetPropertiesAsync();
            } while (!properties.Value.DeleteRetentionPolicy.Enabled);
        }

        public async Task DisableSoftDelete()
        {
            var service = this.GetServiceClient_SharedKey();
            var properties = await service.GetPropertiesAsync();
            properties.Value.DeleteRetentionPolicy = new RetentionPolicy
            {
                Enabled = false
            };
            await service.SetPropertiesAsync(properties);

            do
            {
                await this.Delay(250);
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

        public Task AssertExpectedExceptionAsync<T, U>(StorageTask<U> task, T expectedException, Func<T, T, bool> predicate = null)
            where T : Exception
            => this.AssertExpectedExceptionAsync(task, expectedException, TestHelper.GetDefaultExceptionAssertion(predicate));

        public Task AssertExpectedExceptionAsync<T, U>(StorageTask<U> task, Action<T> assertion)
            where T : Exception
            => this.AssertExpectedExceptionAsync<T, U>(task, default, (_, a) => assertion(a));

        public async Task AssertExpectedExceptionAsync<T, U>(StorageTask<U> task, T expectedException, Action<T, T> assertion)
            where T : Exception
        {
            Assert.IsNotNull(assertion);
            try
            {
                await task;
                Assert.Fail("Expected exception not found");
            }
            catch (T actualException)
            {
                assertion(expectedException, actualException);
            }
        }
    }
}
