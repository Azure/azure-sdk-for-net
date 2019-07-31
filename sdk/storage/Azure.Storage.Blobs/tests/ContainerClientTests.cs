// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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

            var container = this.InstrumentClient(new BlobContainerClient(connectionString.ToString(true), containerName));

            var builder = new BlobUriBuilder(container.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual("", builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task CreateAsync_WithSharedKey()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));

            try
            {
                // Act
                var response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
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
            var containerName = this.GetNewContainerName();
            var service = this.GetServiceClient_OauthAccount();
            var container = this.InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                var response = await container.CreateAsync();

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
            var containerName = this.GetNewContainerName();
            var service = this.GetServiceClient_AccountSas();
            var container = this.InstrumentClient(service.GetBlobContainerClient(containerName));

            try
            {
                // Act
                var response = await container.CreateAsync();

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
            var containerName = this.GetNewContainerName();
            var service = this.GetServiceClient_BlobServiceSas_Container(containerName);
            var container = this.InstrumentClient(service.GetBlobContainerClient(containerName));
            var pass = false;

            try
            {
                // Act
                var response = await container.CreateAsync();

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
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var metadata = this.BuildMetadata();

            // Act
            await container.CreateAsync(metadata: metadata);

            // Assert
            var response = await container.GetPropertiesAsync();
            this.AssertMetadataEquality(metadata, response.Value.Metadata);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_PublicAccess()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));

            // Act
            await container.CreateAsync(publicAccessType: PublicAccessType.Blob);

            // Assert
            var response = await container.GetPropertiesAsync();
            Assert.AreEqual(PublicAccessType.Blob, response.Value.Properties.PublicAccess);

            // Cleanup
            await container.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
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
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            await container.CreateAsync();

            // Act
            var response = await container.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.DeleteAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task DeleteAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.AccessConditions_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                parameters.LeaseId = await this.SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                var response = await container.DeleteAsync(accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.AccessConditionsFail_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    parameters.LeaseId = await this.SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                    var accessConditions = this.BuildContainerAccessConditions(
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
            using (this.GetNewContainer(out var container, publicAccessType: PublicAccessType.Container))
            {
                // Act
                var response = await container.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(PublicAccessType.Container, response.Value.Properties.PublicAccess);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetPropertiesAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var metadata = this.BuildMetadata();

                // Act
                await container.SetMetadataAsync(metadata);

                // Assert
                var response = await container.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var metadata = this.BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            var data =
                new[]
                {
                    new AccessConditionParameters(),
                    new AccessConditionParameters { IfModifiedSince = this.OldDate },
                    new AccessConditionParameters { LeaseId = this.ReceivedLeaseId }
                };

            // Arrange
            foreach (var parameters in data)
            {
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                parameters.LeaseId = await this.SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                var metadata = this.BuildMetadata();
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                var response = await container.SetMetadataAsync(
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
            var garbageLeaseId = this.GetGarbageLeaseId();
            var data = new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (var parameters in data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var metadata = this.BuildMetadata();
                    var accessConditions = this.BuildContainerAccessConditions(
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
            using (this.GetNewContainer(out var container))
            {
                // Act
                var response = await container.GetAccessPolicyAsync();

                // Assert
                Assert.IsNotNull(response);
            }
        }

        [Test]
        public async Task GetAccessPolicyAsync_Lease()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            await container.CreateAsync();
            var garbageLeaseId = this.GetGarbageLeaseId();
            var leaseId = await this.SetupContainerLeaseCondition(container, this.ReceivedLeaseId, garbageLeaseId);
            var leaseAccessConditions = new LeaseAccessConditions
            {
                LeaseId = leaseId
            };

            // Act
            var response = await container.GetAccessPolicyAsync(leaseAccessConditions: leaseAccessConditions);

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
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
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
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var publicAccessType = PublicAccessType.Container;
                var signedIdentifiers = this.BuildSignedIdentifiers();

                // Act
                await container.SetAccessPolicyAsync(
                    accessType: publicAccessType,
                    permissions: signedIdentifiers
                );

                // Assert
                var propertiesResponse = await container.GetPropertiesAsync();
                Assert.AreEqual(publicAccessType, propertiesResponse.Value.Properties.PublicAccess);

                var response = await container.GetAccessPolicyAsync();
                Assert.AreEqual(1, response.Value.SignedIdentifiers.Count());

                var acl = response.Value.SignedIdentifiers.First();
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
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var signedIdentifiers = this.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.SetAccessPolicyAsync(permissions: signedIdentifiers),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetAccessPolicyAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.AccessConditions_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                var publicAccessType = PublicAccessType.Container;
                var signedIdentifiers = this.BuildSignedIdentifiers();
                parameters.LeaseId = await this.SetupContainerLeaseCondition(container, parameters.LeaseId, garbageLeaseId);
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                var response = await container.SetAccessPolicyAsync(
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
            foreach (var parameters in this.AccessConditionsFail_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var publicAccessType = PublicAccessType.Container;
                    var signedIdentifiers = this.BuildSignedIdentifiers();
                    var accessConditions = this.BuildContainerAccessConditions(
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
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            await container.CreateAsync();
            var id = this.Recording.Random.NewGuid().ToString();
            var duration = 15;

            // Act
            var response = await container.GetLeaseClient(id).AcquireAsync(duration: duration);

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
        public async Task AcquireLeaseAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var id = this.Recording.Random.NewGuid().ToString();
            var duration = 15;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetLeaseClient(id).AcquireAsync(duration: duration),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditions()
        {
            foreach (var parameters in this.NoLease_AccessConditions_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;

                // Act
                var response = await container.GetLeaseClient(id).AcquireAsync(
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
            foreach (var parameters in this.NoLease_AccessConditionsFail_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var accessConditions = this.BuildContainerAccessConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: false);

                    var id = this.Recording.Random.NewGuid().ToString();
                    var duration = 15;

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        container.GetLeaseClient(id).AcquireAsync(
                            duration: duration,
                            httpAccessConditions: accessConditions.HttpAccessConditions),
                        e => {});
                }
            }
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            await container.CreateAsync();

            var id = this.Recording.Random.NewGuid().ToString();
            var duration = 15;

            var leaseResponse = await container.GetLeaseClient(id).AcquireAsync(
                duration: duration);

            // Act
            var renewResponse = await container.GetLeaseClient(leaseResponse.Value.LeaseId).RenewAsync();

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
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var id = this.Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetLeaseClient(id).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditions()
        {
            foreach (var parameters in this.NoLease_AccessConditions_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;
                var lease = container.GetLeaseClient(id);
                _ = await lease.AcquireAsync(duration: duration);

                // Act
                var response = await lease.RenewAsync(httpAccessConditions: accessConditions.HttpAccessConditions);

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
            foreach (var parameters in this.NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;

                var lease = container.GetLeaseClient(id);
                var aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;
                var leaseResponse = await container.GetLeaseClient(id).AcquireAsync(duration);

                // Act
                var releaseResponse = await container.GetLeaseClient(leaseResponse.Value.LeaseId).ReleaseAsync();

                // Assert
                var response = await container.GetPropertiesAsync();

                Assert.AreEqual(LeaseStatus.Unlocked, response.Value.Properties.LeaseStatus);
                Assert.AreEqual(LeaseState.Available, response.Value.Properties.LeaseState);
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var id = this.Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetLeaseClient(id).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditions()
        {
            foreach (var parameters in this.NoLease_AccessConditions_Data)
            {
                // Arrange
                using (this.GetNewContainer(out var container))
                {
                    var accessConditions = this.BuildContainerAccessConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: false);

                    var id = this.Recording.Random.NewGuid().ToString();
                    var duration = 15;

                    var lease = container.GetLeaseClient(id);
                    var aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                    // Act
                    var response = await lease.ReleaseAsync(httpAccessConditions: accessConditions.HttpAccessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditionsFail()
        {
            foreach (var parameters in this.NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;

                var lease = container.GetLeaseClient(id); ;
                var aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;
                await container.GetLeaseClient(id).AcquireAsync(duration);
                var breakPeriod = 0;

                // Act
                var breakResponse = await container.GetLeaseClient().BreakAsync(breakPeriod);

                // Assert
                var response = await container.GetPropertiesAsync();
                Assert.AreEqual(LeaseStatus.Unlocked, response.Value.Properties.LeaseStatus);
                Assert.AreEqual(LeaseState.Broken, response.Value.Properties.LeaseState);
            }
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var id = this.Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetLeaseClient().BreakAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditions()
        {
            foreach (var parameters in this.NoLease_AccessConditions_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();

                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;

                var aquireLeaseResponse = await container.GetLeaseClient(id).AcquireAsync(duration: duration);

                // Act
                var response = await container.GetLeaseClient().BreakAsync(
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
            foreach (var parameters in this.NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;

                var aquireLeaseResponse = await container.GetLeaseClient(id).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    container.GetLeaseClient().BreakAsync(
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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var id = this.Recording.Random.NewGuid().ToString();
                var duration = 15;
                var leaseResponse = await container.GetLeaseClient(id).AcquireAsync(duration);
                var newId = this.Recording.Random.NewGuid().ToString();

                // Act
                var changeResponse = await container.GetLeaseClient(id).ChangeAsync(newId);

                // Assert
                Assert.AreEqual(newId, changeResponse.Value.LeaseId);

                // Cleanup
                await container.GetLeaseClient(changeResponse.Value.LeaseId).ReleaseAsync();
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var id = this.Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetLeaseClient(id).ChangeAsync(id),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditions()
        {
            foreach (var parameters in this.NoLease_AccessConditions_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();

                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = this.Recording.Random.NewGuid().ToString();
                var newId = this.Recording.Random.NewGuid().ToString();
                var duration = 15;

                var aquireLeaseResponse = await container.GetLeaseClient(id).AcquireAsync(duration: duration);

                // Act
                var response = await container.GetLeaseClient(aquireLeaseResponse.Value.LeaseId).ChangeAsync(
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
            foreach (var parameters in this.NoLease_AccessConditionsFail_Data)
            {
                // Arrange
                var service = this.GetServiceClient_SharedKey();
                var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
                await container.CreateAsync();
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = this.Recording.Random.NewGuid().ToString();
                var newId = this.Recording.Random.NewGuid().ToString();
                var duration = 15;

                var aquireLeaseResponse = await container.GetLeaseClient(id).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    container.GetLeaseClient(aquireLeaseResponse.Value.LeaseId).ChangeAsync(
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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.SetUpContainerForListing(container);

                // Act
                var blobs = new List<BlobItem>();
                await foreach (var page in container.GetBlobsAsync().ByPage())
                {
                    blobs.AddRange(page.Values);
                }

                // Assert
                Assert.AreEqual(this.BlobNames.Length, blobs.Count);

                var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();

                Assert.IsTrue(this.BlobNames.All(blobName => foundBlobNames.Contains(blobName)));
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ListBlobsFlatSegmentAsync_MaxResults()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.SetUpContainerForListing(container);

                // Act
                var page = await container.GetBlobsAsync().ByPage(pageSizeHint: 2).FirstAsync();

                // Assert
                Assert.AreEqual(2, page.Values.Count);
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Metadata()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                var metadata = this.BuildMetadata();
                await blob.CreateAsync(metadata: metadata);

                // Act
                var blobs = await container.GetBlobsAsync(new GetBlobsOptions { IncludeMetadata = true }).ToListAsync();

                // Assert
                this.AssertMetadataEquality(metadata, blobs.First().Value.Metadata);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task ListBlobsFlatSegmentAsync_Deleted()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.EnableSoftDelete();
                var blobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetAppendBlobClient(blobName));
                await blob.CreateAsync();
                await blob.DeleteAsync();

                // Act
                var blobs = await container.GetBlobsAsync(new GetBlobsOptions { IncludeDeletedBlobs = true }).ToListAsync();

                // Assert
                if (blobs.Count == 0)
                {
                    Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
                }
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Name);

                // Cleanup
                await this.DisableSoftDelete();
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Uncommited()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blobName));
                var data = this.GetRandomBuffer(Constants.KB);
                var blockId = this.ToBase64(this.GetNewBlockName());

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(
                        base64BlockId: blockId,
                        content: stream);
                }

                // Act
                var blobs = await container.GetBlobsAsync(new GetBlobsOptions { IncludeUncommittedBlobs = true }).ToListAsync();

                // Assert
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Name);
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Snapshot()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                await blob.CreateAsync();
                var snapshotResponse = await blob.CreateSnapshotAsync();

                // Act
                var blobs = await container.GetBlobsAsync(new GetBlobsOptions { IncludeSnapshots = true }).ToListAsync();

                // Assert
                Assert.AreEqual(2, blobs.Count);
                Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Value.Snapshot);
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Prefix()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.SetUpContainerForListing(container);

                // Act
                var blobs = await container.GetBlobsAsync(new GetBlobsOptions { Prefix = "foo" }).ToListAsync();

                // Assert
                Assert.AreEqual(3, blobs.Count);
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var id = this.Recording.Random.NewGuid().ToString();

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
                using (this.GetNewContainer(out var container))
                {
                    var blob = this.InstrumentClient(container.GetBlockBlobClient(blobName));
                    await blob.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes("data")));
                    var blobItem = await container.GetBlobsAsync().FirstAsync();
                    Assert.AreEqual(blobName, blobItem.Value.Name);
                }
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.SetUpContainerForListing(container);

                var blobs = new List<BlobItem>();
                var prefixes = new List<string>();
                var delimiter = "/";

                await foreach (var page in container.GetBlobsByHierarchyAsync(delimiter).ByPage())
                {
                    blobs.AddRange(page.Values.Where(item => item.IsBlob).Select(item => item.Blob));
                    prefixes.AddRange(page.Values.Where(item => item.IsPrefix).Select(item => item.Prefix));
                }

                Assert.AreEqual(3, blobs.Count);
                Assert.AreEqual(2, prefixes.Count);

                var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();
                var foundBlobPrefixes = prefixes.ToArray();
                var expectedPrefixes =
                    this.BlobNames
                    .Where(blobName => blobName.Contains(delimiter))
                    .Select(blobName => blobName.Split(new[] { delimiter[0] })[0] + delimiter)
                    .Distinct()
                    ;

                Assert.IsTrue(
                    this.BlobNames
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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.SetUpContainerForListing(container);
                var delimiter = "/";

                // Act
                var page = await container.GetBlobsByHierarchyAsync(delimiter: delimiter)
                    .ByPage(pageSizeHint: 2)
                    .FirstAsync();

                // Assert
                Assert.AreEqual(2, page.Values.Count);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Metadata()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                var metadata = this.BuildMetadata();
                await blob.CreateAsync(metadata: metadata);

                // Act
                var item = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { IncludeMetadata = true }).FirstAsync();

                // Assert
                this.AssertMetadataEquality(metadata, item.Value.Blob.Metadata);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task ListBlobsHierarchySegmentAsync_Deleted()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.EnableSoftDelete();
                var blobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetAppendBlobClient(blobName));
                await blob.CreateAsync();
                await blob.DeleteAsync();

                // Act
                var blobs = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { IncludeDeletedBlobs = true }).ToListAsync();

                // Assert
                if (blobs.Count == 0)
                {
                    Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
                }
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Blob.Name);

                // Cleanup
                await this.DisableSoftDelete();
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Uncommited()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blobName));
                var data = this.GetRandomBuffer(Constants.KB);
                var blockId = this.ToBase64(this.GetNewBlockName());

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(
                        base64BlockId: blockId,
                        content: stream);
                }

                // Act
                var blobs = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { IncludeUncommittedBlobs = true }).ToListAsync();

                // Assert
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Blob.Name);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Snapshot()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                await blob.CreateAsync();
                var snapshotResponse = await blob.CreateSnapshotAsync();

                // Act
                var blobs = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { IncludeSnapshots = true }).ToListAsync();

                // Assert
                Assert.AreEqual(2, blobs.Count);
                Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Value.Blob.Snapshot);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Prefix()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.SetUpContainerForListing(container);

                // Act
                var blobs = await container.GetBlobsByHierarchyAsync(options: new GetBlobsOptions { Prefix = "foo" }).ToListAsync();


                // Assert
                Assert.AreEqual(3, blobs.Count);
            }
        }

        [Test]
        public async Task ListBlobsHierarchySegmentAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));
            var id = this.Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetBlobsByHierarchyAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task UploadBlobAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                using var stream = new MemoryStream(this.GetRandomBuffer(100));
                await container.UploadBlobAsync(name, stream);
                var properties = await container.GetBlobClient(name).GetPropertiesAsync();
                Assert.AreEqual(BlobType.BlockBlob, properties.Value.BlobType);
            }
        }

        [Test]
        public async Task DeleteBlobAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                var blob = container.GetBlockBlobClient(name);
                using (var stream = new MemoryStream(this.GetRandomBuffer(100)))
                {
                    await blob.UploadAsync(stream);
                }

                await container.DeleteBlobAsync(name);
                Assert.ThrowsAsync<StorageRequestFailedException>(
                    async () => await blob.GetPropertiesAsync());
            }
        }

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
            var blobNames = this.BlobNames;

            var data = this.GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blobNames[i]));
                blobs[i] = blob;

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Set metadata on Blob index 3
            var metadata = this.BuildMetadata();
            await blobs[3].SetMetadataAsync(metadata);
        }

        public IEnumerable<AccessConditionParameters> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = this.OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { LeaseId = this.ReceivedLeaseId }
            };

        public IEnumerable<AccessConditionParameters> AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { LeaseId = this.GarbageETag },
             };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = this.OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.NewDate }
            };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.OldDate }
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

            if(lease)
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
