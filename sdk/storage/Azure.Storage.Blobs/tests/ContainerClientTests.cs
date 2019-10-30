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

            Assert.AreEqual(containerName, builder.BlobContainerName);
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

            BlobContainerClient client1 = InstrumentClient(new BlobContainerClient(blobEndpoint, credentials));
            BlobContainerClient client2 = InstrumentClient(new BlobContainerClient(blobEndpoint));

            Assert.AreEqual(accountName, client1.AccountName);
            Assert.AreEqual(accountName, client2.AccountName);

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
                Response<BlobContainerInfo> response = await container.CreateAsync();

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
                Response<BlobContainerInfo> response = await container.CreateAsync();

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
                Response<BlobContainerInfo> response = await container.CreateAsync();

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
                Response<BlobContainerInfo> response = await container.CreateAsync();

                Assert.Fail("CreateAsync unexpected success: blob service SAS should not be usable to create container");
            }
            catch (RequestFailedException se) when (se.ErrorCode == "AuthorizationFailure") // TODO verify if this is a missing error code
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
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
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
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            Assert.AreEqual(PublicAccessType.Blob, response.Value.PublicAccess);

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
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.CreateAsync(),
                e => Assert.AreEqual("ContainerAlreadyExists", e.ErrorCode.Split('\n')[0]));

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await container.CreateIfNotExistsAsync();

            // Assert
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            Assert.IsNotNull(response.Value.ETag);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            // Act
            await container.CreateIfNotExistsAsync();

            // Assert
            Response<BlobContainerProperties> response = await container.GetPropertiesAsync();
            Assert.IsNotNull(response.Value.ETag);

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
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
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
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response response = await container.DeleteAsync(conditions: accessConditions);

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
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                parameters.LeaseId = await SetupContainerLeaseCondition(test.Container, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.Container.DeleteAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        public async Task DeleteIfExistsAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            await container.CreateAsync();

            // Act
            Response<bool> response = await container.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_Exists()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            Response<bool> response = await container.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(PublicAccessType.BlobContainer, response.Value.PublicAccess);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.GetPropertiesAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await test.Container.SetMetadataAsync(metadata);

            // Assert
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
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
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                Response<BlobContainerInfo> response = await container.SetMetadataAsync(
                    metadata: metadata,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(new BlobRequestConditions { LeaseId = parameters.LeaseId });
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
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.Container.SetMetadataAsync(
                        metadata: metadata,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        public async Task GetAccessPolicyAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Act
            Response<BlobContainerAccessPolicy> response = await test.Container.GetAccessPolicyAsync();

            // Assert
            Assert.IsNotNull(response);
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
            var leaseAccessConditions = new BlobRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            Response<BlobContainerAccessPolicy> response = await container.GetAccessPolicyAsync(conditions: leaseAccessConditions);

            // Assert
            Assert.IsNotNull(response);

            // Cleanup
            await container.DeleteAsync(conditions: leaseAccessConditions);
        }

        [Test]
        public async Task GetAccessPolicyAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var leaseAccessConditions = new BlobRequestConditions
            {
                LeaseId = garbageLeaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.Container.GetAccessPolicyAsync(conditions: leaseAccessConditions),
                e => Assert.AreEqual("LeaseNotPresentWithContainerOperation", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            PublicAccessType publicAccessType = PublicAccessType.BlobContainer;
            BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await test.Container.SetAccessPolicyAsync(
                accessType: publicAccessType,
                permissions: signedIdentifiers
            );

            // Assert
            Response<BlobContainerProperties> propertiesResponse = await test.Container.GetPropertiesAsync();
            Assert.AreEqual(publicAccessType, propertiesResponse.Value.PublicAccess);

            Response<BlobContainerAccessPolicy> response = await test.Container.GetAccessPolicyAsync();
            Assert.AreEqual(1, response.Value.SignedIdentifiers.Count());

            BlobSignedIdentifier acl = response.Value.SignedIdentifiers.First();
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.StartsOn, acl.AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.ExpiresOn, acl.AccessPolicy.ExpiresOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permissions, acl.AccessPolicy.Permissions);
        }

        [Test]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
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
                PublicAccessType publicAccessType = PublicAccessType.BlobContainer;
                BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                parameters.LeaseId = await SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response<BlobContainerInfo> response = await container.SetAccessPolicyAsync(
                    accessType: publicAccessType,
                    permissions: signedIdentifiers,
                    conditions: accessConditions
                );

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = parameters.LeaseId });
            }
        }

        [Test]
        public async Task SetAccessPolicyAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                PublicAccessType publicAccessType = PublicAccessType.BlobContainer;
                BlobSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.Container.SetAccessPolicyAsync(
                        accessType: publicAccessType,
                        permissions: signedIdentifiers,
                        conditions: accessConditions),
                    e => { });
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
            Response<BlobLease> response = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

            // Assert
            Assert.AreEqual(id, response.Value.LeaseId);

            // Cleanup
            await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
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
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration),
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
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration),
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
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                Response<BlobLease> response = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(
                    duration: duration,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(
                        duration: duration,
                        conditions: accessConditions),
                    e => { });
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

            Response<BlobLease> leaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(
                duration: duration);

            // Act
            Response<BlobLease> renewResponse = await InstrumentClient(container.GetBlobLeaseClient(leaseResponse.Value.LeaseId)).RenewAsync();

            // Assert
            Assert.IsNotNull(renewResponse.GetRawResponse().Headers.RequestId);

            // Cleanup
            await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = renewResponse.Value.LeaseId });
        }

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).ReleaseAsync(),
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
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                BlobLeaseClient lease = InstrumentClient(container.GetBlobLeaseClient(id));
                _ = await lease.AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await lease.RenewAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
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
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                BlobLeaseClient lease = InstrumentClient(container.GetBlobLeaseClient(id));
                Response<BlobLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.RenewAsync(conditions: accessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<BlobLease> leaseResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(duration);

            // Act
            Response<ReleasedObjectInfo> releaseResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(leaseResponse.Value.LeaseId)).ReleaseAsync();

            // Assert
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();

            Assert.AreEqual(LeaseStatus.Unlocked, response.Value.LeaseStatus);
            Assert.AreEqual(LeaseState.Available, response.Value.LeaseState);
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                BlobLeaseClient lease = InstrumentClient(test.Container.GetBlobLeaseClient(id));
                Response<BlobLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
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
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                BlobLeaseClient lease = InstrumentClient(container.GetBlobLeaseClient(id));
                Response<BlobLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ReleaseAsync(conditions: accessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            await InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(duration);
            TimeSpan breakPeriod = TimeSpan.FromSeconds(0);

            // Act
            Response<BlobLease> breakResponse = await InstrumentClient(test.Container.GetBlobLeaseClient()).BreakAsync(breakPeriod);

            // Assert
            Response<BlobContainerProperties> response = await test.Container.GetPropertiesAsync();
            Assert.AreEqual(LeaseStatus.Unlocked, response.Value.LeaseStatus);
            Assert.AreEqual(LeaseState.Broken, response.Value.LeaseState);
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient()).BreakAsync(),
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

                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<BlobLease> aquireLeaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await InstrumentClient(container.GetBlobLeaseClient()).BreakAsync(
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
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
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<BlobLease> aquireLeaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(container.GetBlobLeaseClient()).BreakAsync(
                        conditions: accessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<BlobLease> leaseResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(id)).AcquireAsync(duration);
            var newId = Recording.Random.NewGuid().ToString();

            // Act
            Response<BlobLease> changeResponse = await InstrumentClient(test.Container.GetBlobLeaseClient(id)).ChangeAsync(newId);

            // Assert
            Assert.AreEqual(newId, changeResponse.Value.LeaseId);

            // Cleanup
            await InstrumentClient(test.Container.GetBlobLeaseClient(changeResponse.Value.LeaseId)).ReleaseAsync();
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(container.GetBlobLeaseClient(id)).ChangeAsync(id),
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

                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<BlobLease> aquireLeaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await InstrumentClient(container.GetBlobLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                    proposedId: newId,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = response.Value.LeaseId });
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
                BlobRequestConditions accessConditions = BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<BlobLease> aquireLeaseResponse = await InstrumentClient(container.GetBlobLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(container.GetBlobLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                        proposedId: newId,
                        conditions: accessConditions),
                    e => { });

                // cleanup
                await container.DeleteAsync(conditions: new BlobRequestConditions { LeaseId = aquireLeaseResponse.Value.LeaseId });
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            // Act
            var blobs = new List<BlobItem>();
            await foreach (Page<BlobItem> page in test.Container.GetBlobsAsync().AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            Assert.AreEqual(BlobNames.Length, blobs.Count);

            var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();

            Assert.IsTrue(BlobNames.All(blobName => foundBlobNames.Contains(blobName)));
        }

        [Test]
        [AsyncOnly]
        public async Task ListBlobsFlatSegmentAsync_MaxResults()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            // Act
            Page<BlobItem> page = await test.Container.GetBlobsAsync().AsPages(pageSizeHint: 2).FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
            Assert.IsTrue(page.Values.All(b => b.Metadata == null));
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateAsync(metadata: metadata);

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(traits: BlobTraits.Metadata).ToListAsync();

            // Assert
            AssertMetadataEquality(metadata, blobs.First().Metadata);
        }

        [Test]
        [NonParallelizable]
        public async Task ListBlobsFlatSegmentAsync_Deleted()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await EnableSoftDelete();
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            await blob.DeleteAsync();

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(states: BlobStates.Deleted).ToListAsync();

            // Assert
            if (blobs.Count == 0)
            {
                Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
            }
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);

            // Cleanup
            await DisableSoftDelete();
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Uncommited()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);
            var blockId = ToBase64(GetNewBlockName());

            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(
                    base64BlockId: blockId,
                    content: stream);
            }

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(states: BlobStates.Uncommitted).ToListAsync();

            // Assert
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Snapshot()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(states: BlobStates.Snapshots).ToListAsync();

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Snapshot);
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Prefix()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            // Act
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync(prefix: "foo").ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
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
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
                await blob.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes("data")));
                BlobItem blobItem = await test.Container.GetBlobsAsync().FirstAsync();
                Assert.AreEqual(blobName, blobItem.Name);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            var blobs = new List<BlobItem>();
            var prefixes = new List<string>();
            var delimiter = "/";

            await foreach (Page<BlobHierarchyItem> page in test.Container.GetBlobsByHierarchyAsync(delimiter: delimiter).AsPages())
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

        [Test]
        [AsyncOnly]
        public async Task ListBlobsHierarchySegmentAsync_MaxResults()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);
            var delimiter = "/";

            // Act
            Page<BlobHierarchyItem> page = await test.Container.GetBlobsByHierarchyAsync(delimiter: delimiter)
                .AsPages(pageSizeHint: 2)
                .FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateAsync(metadata: metadata);

            // Act
            BlobHierarchyItem item = await test.Container.GetBlobsByHierarchyAsync(traits: BlobTraits.Metadata).FirstAsync();

            // Assert
            AssertMetadataEquality(metadata, item.Blob.Metadata);
        }

        [Test]
        [NonParallelizable]
        public async Task ListBlobsHierarchySegmentAsync_Deleted()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await EnableSoftDelete();
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            await blob.DeleteAsync();

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(states: BlobStates.Deleted).ToListAsync();

            // Assert
            if (blobs.Count == 0)
            {
                Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
            }
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Blob.Name);

            // Cleanup
            await DisableSoftDelete();
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Uncommited()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);
            var blockId = ToBase64(GetNewBlockName());

            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(
                    base64BlockId: blockId,
                    content: stream);
            }

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(states: BlobStates.Uncommitted).ToListAsync();

            // Assert
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Blob.Name);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Snapshot()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(states: BlobStates.Snapshots).ToListAsync();

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Blob.Snapshot);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Prefix()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await SetUpContainerForListing(test.Container);

            // Act
            IList<BlobHierarchyItem> blobs = await test.Container.GetBlobsByHierarchyAsync(prefix: "foo").ToListAsync();


            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.GetBlobsByHierarchyAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task UploadBlobAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            using var stream = new MemoryStream(GetRandomBuffer(100));
            await test.Container.UploadBlobAsync(name, stream);
            Response<BlobProperties> properties = await InstrumentClient(test.Container.GetBlobClient(name)).GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        public async Task DeleteBlobAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(name));
            using (var stream = new MemoryStream(GetRandomBuffer(100)))
            {
                await blob.UploadAsync(stream);
            }

            await test.Container.DeleteBlobAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [Test]
        public async Task DeleteBlobIfExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var name = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(name));
            using (var stream = new MemoryStream(GetRandomBuffer(100)))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<bool> response = await test.Container.DeleteBlobIfExistsAsync(name);

            // Assert
            Assert.IsTrue(response.Value);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [Test]
        public async Task DeleteBlobIfExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var name = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(name));
            using (var stream = new MemoryStream(GetRandomBuffer(100)))
            {
                await blob.UploadAsync(stream);
            }
            await test.Container.DeleteBlobAsync(name);

            //Act
            Response<bool> response = await test.Container.DeleteBlobIfExistsAsync(name);

            // Assert
            Assert.IsFalse(response.Value);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [Test]
        public async Task DeleteBlobIfExistsAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.DeleteBlobIfExistsAsync(GetNewBlobName()),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        #region Secondary Storage
        [Test]
        public async Task ListContainersSegmentAsync_SecondaryStorageFirstRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }


        private async Task<TestExceptionPolicy> PerformSecondaryStorageTest(int numberOfReadFailuresToSimulate, bool retryOn404 = false)
        {
            BlobContainerClient containerClient = GetBlobContainerClient_SecondaryAccount_ReadEnabledOnRetry(numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, retryOn404);
            await containerClient.CreateAsync();

            Response<BlobContainerProperties> properties = await EnsurePropagatedAsync(
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

        private BlobRequestConditions BuildContainerAccessConditions(
            AccessConditionParameters parameters,
            bool ifUnmodifiedSince,
            bool lease)
        {

            var accessConditions = new BlobRequestConditions { IfModifiedSince = parameters.IfModifiedSince };
            if (ifUnmodifiedSince)
            {
                accessConditions.IfUnmodifiedSince = parameters.IfUnmodifiedSince;
            }
            if (lease)
            {
                accessConditions.LeaseId = parameters.LeaseId;
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
