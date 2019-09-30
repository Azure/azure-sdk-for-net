// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Common.Test;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class ContainerClientTests : BlobTestBase
    {
        public ContainerClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (blobEndpoint, blobSecondaryEndpoint), (default, default), (default, default), (default, default));

            var containerName = "containername";

            BlobContainerClient container = InstrumentClient(new BlobContainerClient(connectionString.ToString(true), containerName));

            var builder = new BlobUriBuilder(container.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual("", builder.BlobName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);

            var blob = this.InstrumentClient(new BlobContainerClient(blobEndpoint, credentials));
            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public async Task CreateAsync_WithSharedKey()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            var containerName = GetNewContainerName();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                Response<ContainerInfo> response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                var accountName = new BlobUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => container.AccountName);
                TestHelper.AssertCacheableProperty(containerName, () => container.Name);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithOauth()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_OauthAccount();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                Response<ContainerInfo> response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithAccountSas()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_AccountSas();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                Response<ContainerInfo> response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithBlobServiceSas()
        {
            // Arrange
            var containerName = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_BlobServiceSas_Container(containerName);
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));
            var pass = false;

            try
            {
                // Act
                Response<ContainerInfo> response = await container.CreateAsync();

                Assert.Fail("CreateAsync unexpected success: blob service SAS should not be usable to create container");
            }
            catch (StorageRequestFailedException se) when (se.ErrorCode == "AuthorizationFailure") // TODO verify if this is a missing error code
            {
                pass = true;
            }
            finally
            {
                if (!pass)
                {
                    await container.DeleteAsync();
                }
            }
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await container.CreateAsync(metadata: metadata);

            // Assert
            Response<ContainerItem> response = await container.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_PublicAccess()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await container.CreateAsync(publicAccessType: PublicAccessType.Blob);

            // Assert
            Response<ContainerItem> response = await container.GetPropertiesAsync();
            Assert.AreEqual(PublicAccessType.Blob, response.Value.Properties.PublicAccess);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            // ContainerUri is intentually created twice
            await container.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.CreateAsync(),
                e => Assert.AreEqual("ContainerAlreadyExists", e.ErrorCode.Split('\n')[0]));

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            // Act
            Response response = await container.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.DeleteAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task DeleteAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response response = await container.DeleteAsync(accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                    ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        container.DeleteAsync(accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            using (GetNewContainer(out BlobContainerClient container, publicAccessType: PublicAccessType.Container))
            {
                // Act
                Response<ContainerItem> response = await container.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(PublicAccessType.Container, response.Value.Properties.PublicAccess);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetPropertiesAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await container.SetMetadataAsync(metadata);

                // Assert
                Response<ContainerItem> response = await container.GetPropertiesAsync();
                AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data =
                new[]
                {
                    new AccessConditionParameters(),
                    new AccessConditionParameters { IfModifiedSince = OldDate },
                    new AccessConditionParameters { LeaseId = ReceivedLeaseId }
                };

            // Arrange
            foreach (AccessConditionParameters parameters in data)
            {
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                IDictionary<string, string> metadata = BuildMetadata();
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                Response<ContainerInfo> response = await container.SetMetadataAsync(
                    metadata: metadata,
                    accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = parameters.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (AccessConditionParameters parameters in data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    IDictionary<string, string> metadata = BuildMetadata();
                    ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: false,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        container.SetMetadataAsync(
                            metadata: metadata,
                            accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task GetAccessPolicyAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Act
                Response<ContainerAccessPolicy> response = await container.GetAccessPolicyAsync();

                // Assert
                Assert.IsNotNull(response);
            }
        }

        [Test]
        public async Task GetAccessPolicyAsync_Lease()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();
            var garbageLeaseId = GetGarbageLeaseId();
            var leaseId = await SetupContainerLeaseCondition(container, ReceivedLeaseId, garbageLeaseId);
            var leaseAccessConditions = new LeaseAccessConditions
            {
                LeaseId = leaseId
            };

            // Act
            Response<ContainerAccessPolicy> response = await container.GetAccessPolicyAsync(leaseAccessConditions: leaseAccessConditions);

            // Assert
            Assert.IsNotNull(response);

            // Cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = leaseAccessConditions
            });
        }

        [Test]
        public async Task GetAccessPolicyAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var leaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = garbageLeaseId
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    container.GetAccessPolicyAsync(leaseAccessConditions: leaseAccessConditions),
                    e => Assert.AreEqual("LeaseNotPresentWithContainerOperation", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                PublicAccessType publicAccessType = PublicAccessType.Container;
                SignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

                // Act
                await container.SetAccessPolicyAsync(
                    accessType: publicAccessType,
                    permissions: signedIdentifiers
                );

                // Assert
                Response<ContainerItem> propertiesResponse = await container.GetPropertiesAsync();
                Assert.AreEqual(publicAccessType, propertiesResponse.Value.Properties.PublicAccess);

                Response<ContainerAccessPolicy> response = await container.GetAccessPolicyAsync();
                Assert.AreEqual(1, response.Value.SignedIdentifiers.Count());

                SignedIdentifier acl = response.Value.SignedIdentifiers.First();
                Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Start, acl.AccessPolicy.Start);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Expiry, acl.AccessPolicy.Expiry);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permission, acl.AccessPolicy.Permission);
            }
        }

        [Test]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            SignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.SetAccessPolicyAsync(permissions: signedIdentifiers),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetAccessPolicyAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                PublicAccessType publicAccessType = PublicAccessType.Container;
                SignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response<ContainerInfo> response = await container.SetAccessPolicyAsync(
                    accessType: publicAccessType,
                    permissions: signedIdentifiers,
                    accessConditions: accessConditions
                );

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = parameters.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task SetAccessPolicyAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    PublicAccessType publicAccessType = PublicAccessType.Container;
                    SignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                    ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        container.SetAccessPolicyAsync(
                            accessType: publicAccessType,
                            permissions: signedIdentifiers,
                            accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task AcquireLeaseAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<Lease> response = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration: duration);

            // Assert
            Assert.AreEqual(id, response.Value.LeaseId);

            // Cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = response.Value.LeaseId
                }
            });
        }

        [Test]
        public async Task AcquireLeaseAsync_ErrorDurationTooLarge()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.MaxValue;

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration: duration),
                e => StringAssert.Contains("InvalidHeaderValue", e.ErrorCode));
        }

        [Test]
        public async Task AcquireLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration: duration),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                Response<Lease> response = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(
                    duration: duration,
                    httpAccessConditions: accessConditions.HttpAccessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = response.Value.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: false);

                    var id = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(
                            duration: duration,
                            httpAccessConditions: accessConditions.HttpAccessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            Response<Lease> leaseResponse = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(
                duration: duration);

            // Act
            Response<Lease> renewResponse = await InstrumentClient(container.GetLeaseClient(leaseResponse.Value.LeaseId)).RenewAsync();

            // Assert
            Assert.IsNotNull(renewResponse.GetRawResponse().Headers.RequestId);

            // Cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = renewResponse.Value.LeaseId
                }
            });
        }

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                InstrumentClient(container.GetLeaseClient(id)).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                LeaseClient lease = InstrumentClient(container.GetLeaseClient(id));
                _ = await lease.AcquireAsync(duration: duration);

                // Act
                Response<Lease> response = await lease.RenewAsync(httpAccessConditions: accessConditions.HttpAccessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = response.Value.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                LeaseClient lease = InstrumentClient(container.GetLeaseClient(id));
                Response<Lease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    lease.RenewAsync(httpAccessConditions: accessConditions.HttpAccessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = aquireLeaseResponse.Value.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                Response<Lease> leaseResponse = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration);

                // Act
                Response<ReleasedObjectInfo> releaseResponse = await InstrumentClient(container.GetLeaseClient(leaseResponse.Value.LeaseId)).ReleaseAsync();

                // Assert
                Response<ContainerItem> response = await container.GetPropertiesAsync();

                Assert.AreEqual(LeaseStatus.Unlocked, response.Value.Properties.LeaseStatus);
                Assert.AreEqual(LeaseState.Available, response.Value.Properties.LeaseState);
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                InstrumentClient(container.GetLeaseClient(id)).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                using (GetNewContainer(out BlobContainerClient container))
                {
                    ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: false);

                    var id = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    LeaseClient lease = InstrumentClient(container.GetLeaseClient(id));
                    Response<Lease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                    // Act
                    Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(httpAccessConditions: accessConditions.HttpAccessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                LeaseClient lease = InstrumentClient(container.GetLeaseClient(id));
                Response<Lease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    lease.ReleaseAsync(httpAccessConditions: accessConditions.HttpAccessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = aquireLeaseResponse.Value.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration);
                TimeSpan breakPeriod = TimeSpan.FromSeconds(0);

                // Act
                Response<Lease> breakResponse = await InstrumentClient(container.GetLeaseClient()).BreakAsync(breakPeriod);

                // Assert
                Response<ContainerItem> response = await container.GetPropertiesAsync();
                Assert.AreEqual(LeaseStatus.Unlocked, response.Value.Properties.LeaseStatus);
                Assert.AreEqual(LeaseState.Broken, response.Value.Properties.LeaseState);
            }
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                InstrumentClient(container.GetLeaseClient()).BreakAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();

                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<Lease> aquireLeaseResponse = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<Lease> response = await InstrumentClient(container.GetLeaseClient()).BreakAsync(
                    httpAccessConditions: accessConditions.HttpAccessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = aquireLeaseResponse.Value.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<Lease> aquireLeaseResponse = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    InstrumentClient(container.GetLeaseClient()).BreakAsync(
                        httpAccessConditions: accessConditions.HttpAccessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = aquireLeaseResponse.Value.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                Response<Lease> leaseResponse = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration);
                var newId = Recording.Random.NewGuid().ToString();

                // Act
                Response<Lease> changeResponse = await InstrumentClient(container.GetLeaseClient(id)).ChangeAsync(newId);

                // Assert
                Assert.AreEqual(newId, changeResponse.Value.LeaseId);

                // Cleanup
                await InstrumentClient(container.GetLeaseClient(changeResponse.Value.LeaseId)).ReleaseAsync();
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                InstrumentClient(container.GetLeaseClient(id)).ChangeAsync(id),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();

                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<Lease> aquireLeaseResponse = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<Lease> response = await InstrumentClient(container.GetLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                    proposedId: newId,
                    httpAccessConditions: accessConditions.HttpAccessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = response.Value.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                BlobServiceClient service = GetServiceClient_SharedKey();
                BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
                await container.CreateAsync();
                ContainerAccessConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<Lease> aquireLeaseResponse = await InstrumentClient(container.GetLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    InstrumentClient(container.GetLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                        proposedId: newId,
                        httpAccessConditions: accessConditions.HttpAccessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(accessConditions: new ContainerAccessConditions
                {
                    LeaseAccessConditions = new LeaseAccessConditions
                    {
                        LeaseId = aquireLeaseResponse.Value.LeaseId
                    }
                });
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await SetUpContainerForListing(container);

                // Act
                var blobs = new List<BlobItem>();
                await foreach (Page<BlobItem> page in container.GetBlobsAsync().ByPage())
                {
                    blobs.AddRange(page.Values);
                }

                // Assert
                Assert.AreEqual(BlobNames.Length, blobs.Count);

                var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();

                Assert.IsTrue(BlobNames.All(blobName => foundBlobNames.Contains(blobName)));
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ListBlobsFlatSegmentAsync_MaxResults()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await SetUpContainerForListing(container);

                // Act
                Page<BlobItem> page = await container.GetBlobsAsync().ByPage(pageSizeHint: 2).FirstAsync();

                // Assert
                Assert.AreEqual(2, page.Values.Count);
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Metadata()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                IDictionary<string, string> metadata = BuildMetadata();
                await blob.CreateAsync(metadata: metadata);

                // Act
                IList<Response<BlobItem>> blobs = await container.GetBlobsAsync(new GetBlobsOptions { IncludeMetadata = true }).ToListAsync();

                // Assert
                AssertMetadataEquality(metadata, blobs.First().Value.Metadata);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task ListBlobsFlatSegmentAsync_Deleted()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await EnableSoftDelete();
                var blobName = GetNewBlobName();
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(blobName));
                await blob.CreateAsync();
                await blob.DeleteAsync();

                // Act
                IList<Response<BlobItem>> blobs = await container.GetBlobsAsync(new GetBlobsOptions { IncludeDeletedBlobs = true }).ToListAsync();

                // Assert
                if (blobs.Count == 0)
                {
                    Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
                }
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Name);

                // Cleanup
                await DisableSoftDelete();
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Uncommited()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var blobName = GetNewBlobName();
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));
                var data = GetRandomBuffer(Constants.KB);
                var blockId = ToBase64(GetNewBlockName());

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(
                        base64BlockId: blockId,
                        content: stream);
                }

                // Act
                IList<Response<BlobItem>> blobs = await container.GetBlobsAsync(new GetBlobsOptions { IncludeUncommittedBlobs = true }).ToListAsync();

                // Assert
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Name);
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Snapshot()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                await blob.CreateAsync();
                Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

                // Act
                IList<Response<BlobItem>> blobs = await container.GetBlobsAsync(new GetBlobsOptions { IncludeSnapshots = true }).ToListAsync();

                // Assert
                Assert.AreEqual(2, blobs.Count);
                Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Value.Snapshot);
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Prefix()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await SetUpContainerForListing(container);

                // Act
                IList<Response<BlobItem>> blobs = await container.GetBlobsAsync(new GetBlobsOptions { Prefix = "foo" }).ToListAsync();

                // Assert
                Assert.AreEqual(3, blobs.Count);
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetBlobsAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_PreservesWhitespace()
        {
            await VerifyBlobNameWhitespaceRoundtrips("    prefix");
            await VerifyBlobNameWhitespaceRoundtrips("suffix    ");
            await VerifyBlobNameWhitespaceRoundtrips("    ");

            async Task VerifyBlobNameWhitespaceRoundtrips(string blobName)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));
                    await blob.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes("data")));
                    Response<BlobItem> blobItem = await container.GetBlobsAsync().FirstAsync();
                    Assert.AreEqual(blobName, blobItem.Value.Name);
                }
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await SetUpContainerForListing(container);

                var blobs = new List<BlobItem>();
                var prefixes = new List<string>();
                var delimiter = "/";

                await foreach (Page<BlobHierarchyItem> page in container.GetBlobsByHierarchyAsync(delimiter).ByPage())
                {
                    blobs.AddRange(page.Values.Where(item => item.IsBlob).Select(item => item.Blob));
                    prefixes.AddRange(page.Values.Where(item => item.IsPrefix).Select(item => item.Prefix));
                }

                Assert.AreEqual(3, blobs.Count);
                Assert.AreEqual(2, prefixes.Count);

                var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();
                var foundBlobPrefixes = prefixes.ToArray();
                IEnumerable<string> expectedPrefixes =
                    BlobNames
                    .Where(blobName => blobName.Contains(delimiter))
                    .Select(blobName => blobName.Split(new[] { delimiter[0] })[0] + delimiter)
                    .Distinct()
                    ;

                Assert.IsTrue(
                    BlobNames
                    .Where(blobName => !blobName.Contains(delimiter))
                    .All(blobName => foundBlobNames.Contains(blobName))
                    );

                Assert.IsTrue(
                    expectedPrefixes
                    .All(prefix => foundBlobPrefixes.Contains(prefix))
                    );
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ListBlobsHierarchySegmentAsync_MaxResults()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await SetUpContainerForListing(container);
                var delimiter = "/";

                // Act
                Page<BlobHierarchyItem> page = await container.GetBlobsByHierarchyAsync(delimiter: delimiter)
                    .ByPage(pageSizeHint: 2)
                    .FirstAsync();

                // Assert
                Assert.AreEqual(2, page.Values.Count);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Metadata()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                IDictionary<string, string> metadata = BuildMetadata();
                await blob.CreateAsync(metadata: metadata);

                // Act
                Response<BlobHierarchyItem> item = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { IncludeMetadata = true }).FirstAsync();

                // Assert
                AssertMetadataEquality(metadata, item.Value.Blob.Metadata);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task ListBlobsHierarchySegmentAsync_Deleted()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await EnableSoftDelete();
                var blobName = GetNewBlobName();
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(blobName));
                await blob.CreateAsync();
                await blob.DeleteAsync();

                // Act
                IList<Response<BlobHierarchyItem>> blobs = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { IncludeDeletedBlobs = true }).ToListAsync();

                // Assert
                if (blobs.Count == 0)
                {
                    Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
                }
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Blob.Name);

                // Cleanup
                await DisableSoftDelete();
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Uncommited()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var blobName = GetNewBlobName();
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));
                var data = GetRandomBuffer(Constants.KB);
                var blockId = ToBase64(GetNewBlockName());

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(
                        base64BlockId: blockId,
                        content: stream);
                }

                // Act
                IList<Response<BlobHierarchyItem>> blobs = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { IncludeUncommittedBlobs = true }).ToListAsync();

                // Assert
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Blob.Name);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Snapshot()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
                await blob.CreateAsync();
                Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

                // Act
                IList<Response<BlobHierarchyItem>> blobs = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { IncludeSnapshots = true }).ToListAsync();

                // Assert
                Assert.AreEqual(2, blobs.Count);
                Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Value.Blob.Snapshot);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Prefix()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                await SetUpContainerForListing(container);

                // Act
                IList<Response<BlobHierarchyItem>> blobs = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { Prefix = "foo" }).ToListAsync();


                // Assert
                Assert.AreEqual(3, blobs.Count);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetBlobsByHierarchyAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task UploadBlobAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                var name = GetNewBlobName();
                using var stream = new MemoryStream(GetRandomBuffer(100));
                await container.UploadBlobAsync(name, stream);
                Response<BlobProperties> properties = await InstrumentClient(container.GetBlobClient(name)).GetPropertiesAsync();
                Assert.AreEqual(BlobType.BlockBlob, properties.Value.BlobType);
            }
        }

        [Test]
        public async Task DeleteBlobAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                var name = GetNewBlobName();
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(name));
                using (var stream = new MemoryStream(GetRandomBuffer(100)))
                {
                    await blob.UploadAsync(stream);
                }

                await container.DeleteBlobAsync(name);
                Assert.ThrowsAsync<StorageRequestFailedException>(
                    async () => await blob.GetPropertiesAsync());
            }
        }

        #region Secondary Storage
        [Test]
        public async Task ListContainersSegmentAsync_SecondaryStorageFirstRetrySuccessful()
        {
            var testExceptionPolicy = await this.PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            this.AssertSecondaryStorageFirstRetrySuccessful(this.SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }


        private async Task<TestExceptionPolicy> PerformSecondaryStorageTest(int numberOfReadFailuresToSimulate, bool retryOn404 = false)
        {
            TestExceptionPolicy testExceptionPolicy;
            var containerClient = this.GetBlobContainerClient_SecondaryAccount_ReadEnabledOnRetry(numberOfReadFailuresToSimulate, out testExceptionPolicy, retryOn404);
            await containerClient.CreateAsync();

            var properties = await this.EnsurePropagatedAsync(
                async () => await containerClient.GetPropertiesAsync(),
                properties => properties.GetRawResponse().Status != 404);

            Assert.IsNotNull(properties);
            Assert.AreEqual(200, properties.GetRawResponse().Status);

            await containerClient.DeleteAsync();
            return testExceptionPolicy;
        }
        #endregion

        private string[] BlobNames
            => new[]
            {
                    "foo",
                    "bar",
                    "baz",
                    "foo/foo",
                    "foo/bar",
                    "baz/foo",
                    "baz/foo/bar",
                    "baz/bar/foo"
            };

        private async Task SetUpContainerForListing(BlobContainerClient container)
        {
            var blobNames = BlobNames;

            var data = GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobNames[i]));
                blobs[i] = blob;

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Set metadata on Blob index 3
            IDictionary<string, string> metadata = BuildMetadata();
            await blobs[3].SetMetadataAsync(metadata);
        }

        public IEnumerable<AccessConditionParameters> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };

        public IEnumerable<AccessConditionParameters> AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { LeaseId = GarbageETag },
             };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate }
            };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate }
            };

        private ContainerAccessConditions BuildContainerAccessConditions(
            AccessConditionParameters parameters,
            bool ifUnmodifiedSince,
            bool lease)
        {

            var accessConditions = new ContainerAccessConditions();

            var httpAccessConditions = new HttpAccessConditions
            {
                IfModifiedSince = parameters.IfModifiedSince
            };

            if (ifUnmodifiedSince)
            {
                httpAccessConditions.IfUnmodifiedSince = parameters.IfUnmodifiedSince;
            }

            accessConditions.HttpAccessConditions = httpAccessConditions;

            if (lease)
            {
                accessConditions.LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = parameters.LeaseId
                };
            }

            return accessConditions;
        }

        public class AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string LeaseId { get; set; }
        }
    }
}
