// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    public abstract class BlobTestBase : StorageTestBase
    {
        public readonly string ReceivedETag = "\"received\"";
        public readonly string GarbageETag = "\"garbage\"";
        public readonly string ReceivedLeaseId = "received";

        public BlobTestBase(bool async) : this(async, null) { }

        public BlobTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode)
        {
        }

        public DateTimeOffset OldDate => this.Recording.Now.AddDays(-1);
        public DateTimeOffset NewDate => this.Recording.Now.AddDays(1);

        public string GetGarbageLeaseId() => this.Recording.Random.NewGuid().ToString();
        public string GetNewContainerName() => $"test-container-{this.Recording.Random.NewGuid()}";
        public string GetNewBlobName() => $"test-blob-{this.Recording.Random.NewGuid()}";
        public string GetNewBlockName() => $"test-block-{this.Recording.Random.NewGuid()}";

        public BlobClientOptions GetOptions()
            => this.Recording.InstrumentClientOptions(
                    new BlobClientOptions
                    {
                        ResponseClassifier = new TestResponseClassifier(),
                        Diagnostics = { IsLoggingEnabled = true },
                        Retry =
                        {
                            Mode = RetryMode.Exponential,
                            MaxRetries = Azure.Storage.Constants.MaxReliabilityRetries,
                            Delay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                            MaxDelay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.1 : 10)
                        }
                    });

        public BlobClientOptions GetFaultyBlobConnectionOptions(
            int raiseAt = default,
            Exception raise = default)
        {
            raise = raise ?? new Exception("Simulated connection fault");
            var options = this.GetOptions();
            options.AddPolicy(HttpPipelinePosition.PerCall, new FaultyDownloadPipelinePolicy(raiseAt, raise));
            return options;
        }

        private BlobServiceClient GetServiceClientFromSharedKeyConfig(TenantConfiguration config)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    this.GetOptions()));

        private BlobServiceClient GetServiceClientFromOauthConfig(TenantConfiguration config) =>
            this.InstrumentClient(
                new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    this.GetOAuthCredential(config),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_SharedKey()
            => this.GetServiceClientFromSharedKeyConfig(this.TestConfigDefault);

        public BlobServiceClient GetServiceClient_SecondaryAccount_SharedKey()
            => this.GetServiceClientFromSharedKeyConfig(this.TestConfigSecondary);

        public BlobServiceClient GetServiceClient_PreviewAccount_SharedKey()
            => this.GetServiceClientFromSharedKeyConfig(this.TestConfigPreviewBlob);

        public BlobServiceClient GetServiceClient_OauthAccount() =>
            this.GetServiceClientFromOauthConfig(this.TestConfigOAuth);

        public BlobServiceClient GetServiceClient_AccountSas(
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{this.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewAccountSasCredentials(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Container(
            string containerName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{this.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceSasCredentialsContainer(containerName: containerName, sharedKeyCredentials: sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Container(
            string containerName,
            UserDelegationKey userDelegationKey,
            BlobSasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{this.TestConfigOAuth.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceIdentitySasCredentialsContainer(containerName: containerName, userDelegationKey, this.TestConfigOAuth.AccountName)}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Blob(
            string containerName,
            string blobName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{this.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceSasCredentialsBlob(containerName: containerName, blobName: blobName, sharedKeyCredentials: sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Blob(
            string containerName,
            string blobName,
            UserDelegationKey userDelegationKey,
            BlobSasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{this.TestConfigOAuth.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceIdentitySasCredentialsBlob(containerName: containerName, blobName: blobName, userDelegationKey: userDelegationKey, accountName: this.TestConfigOAuth.AccountName)}"),
                    this.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Snapshot(
            string containerName,
            string blobName,
            string snapshot,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{this.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? this.GetNewBlobServiceSasCredentialsSnapshot(containerName: containerName, blobName: blobName, snapshot: snapshot, sharedKeyCredentials: sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public IDisposable GetNewContainer(
            out BlobContainerClient container,
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default)
        {
            containerName ??= this.GetNewContainerName();
            service ??= this.GetServiceClient_SharedKey();
            container = this.InstrumentClient(service.GetBlobContainerClient(containerName));
            return new DisposingContainer(
                container,
                metadata ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase),
                publicAccessType ?? PublicAccessType.Container);
        }

        public StorageSharedKeyCredential GetNewSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                    this.TestConfigDefault.AccountName,
                    this.TestConfigDefault.AccountKey);

        public SasQueryParameters GetNewAccountSasCredentials(StorageSharedKeyCredential sharedKeyCredentials = default)
            => new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = new AccountSasServices { Blobs = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { Container = true, Object = true }.ToString(),
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials);

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsContainer(string containerName, StorageSharedKeyCredential sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials());

        public BlobSasQueryParameters GetNewBlobServiceIdentitySasCredentialsContainer(string containerName, UserDelegationKey userDelegationKey, string accountName)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new ContainerSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(userDelegationKey, accountName);

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsBlob(string containerName, string blobName, StorageSharedKeyCredential sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new BlobSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials());

        public BlobSasQueryParameters GetNewBlobServiceIdentitySasCredentialsBlob(string containerName, string blobName, UserDelegationKey userDelegationKey, string accountName)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new BlobSasPermissions { Read = true, Add = true, Create = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(userDelegationKey, accountName);

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsSnapshot(string containerName, string blobName, string snapshot, StorageSharedKeyCredential sharedKeyCredentials = default)
            => new BlobSasBuilder
            {
                ContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new SnapshotSasPermissions { Read = true, Write = true, Delete = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
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
        public async Task<string> SetupBlobMatchCondition(BlobBaseClient blob, string match)
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
        public async Task<string> SetupBlobLeaseCondition(BlobBaseClient blob, string leaseId, string garbageLeaseId)
        {
            Lease lease = null;
            if (leaseId == this.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await this.InstrumentClient(blob.GetLeaseClient(this.Recording.Random.NewGuid().ToString())).AcquireAsync(-1);
            }
            return leaseId == this.ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        //TODO consider removing this.
        public async Task<string> SetupContainerLeaseCondition(BlobContainerClient container, string leaseId, string garbageLeaseId)
        {
            Lease lease = null;
            if (leaseId == this.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await container.GetLeaseClient(this.Recording.Random.NewGuid().ToString()).AcquireAsync(-1);
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
    }
}
