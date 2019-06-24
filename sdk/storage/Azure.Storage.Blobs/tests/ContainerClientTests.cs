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
    [TestFixture]
    public class ContainerClientTests : BlobTestBase
    {
        public ContainerClientTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
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
        public async Task GetAccountInfoAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Act
                var response = await container.GetAccountInfoAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task GetAccountInfoAsync_Error()
        {
            // Arrange
            var service = this.InstrumentClient(
                new BlobServiceClient(
                    this.GetServiceClient_SharedKey().Uri,
                    this.GetOptions()));
            var container = this.InstrumentClient(service.GetBlobContainerClient(this.GetNewContainerName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetAccountInfoAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
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
            var response = await container.AcquireLeaseAsync(
                duration: duration,
                proposedId: id);

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
                container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id),
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
                var response = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id,
                    accessConditions: accessConditions);

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
                        container.AcquireLeaseAsync(
                            duration: duration,
                            proposedId: id,
                            accessConditions: accessConditions),
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

            var leaseResponse = await container.AcquireLeaseAsync(
                duration: duration,
                proposedId: id); 

            // Act
            var renewResponse = await container.RenewLeaseAsync(leaseResponse.Value.LeaseId);

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
                container.ReleaseLeaseAsync(
                    leaseId: id),
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
                _ = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id);

                // Act
                var response = await container.RenewLeaseAsync(
                    leaseId: id,
                    accessConditions: accessConditions);

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

                var aquireLeaseResponse = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    container.RenewLeaseAsync(
                        leaseId: id,
                        accessConditions: accessConditions),
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
                var leaseResponse = await container.AcquireLeaseAsync(duration, id);

                // Act
                var releaseResponse = await container.ReleaseLeaseAsync(leaseResponse.Value.LeaseId);

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
                container.ReleaseLeaseAsync(
                    leaseId: id),
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

                    var aquireLeaseResponse = await container.AcquireLeaseAsync(
                        duration: duration,
                        proposedId: id);

                    // Act
                    var response = await container.ReleaseLeaseAsync(
                        leaseId: id,
                        accessConditions: accessConditions);

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

                var aquireLeaseResponse = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    container.ReleaseLeaseAsync(
                        leaseId: id,
                        accessConditions: accessConditions),
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
                await container.AcquireLeaseAsync(duration, id);
                var breakPeriod = 0;

                // Act
                var breakResponse = await container.BreakLeaseAsync(breakPeriod);

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
                container.BreakLeaseAsync(),
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

                var aquireLeaseResponse = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id);

                // Act
                var response = await container.BreakLeaseAsync(
                    accessConditions: accessConditions);

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

                var aquireLeaseResponse = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    container.BreakLeaseAsync(
                        accessConditions: accessConditions),
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
                var leaseResponse = await container.AcquireLeaseAsync(duration, id);
                var newId = this.Recording.Random.NewGuid().ToString();

                // Act
                var changeResponse = await container.ChangeLeaseAsync(leaseResponse.Value.LeaseId, newId);

                // Assert
                Assert.AreEqual(newId, changeResponse.Value.LeaseId);

                // Cleanup
                await container.ReleaseLeaseAsync(changeResponse.Value.LeaseId);
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
                container.ChangeLeaseAsync(id, id),
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

                var aquireLeaseResponse = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id);

                // Act
                var response = await container.ChangeLeaseAsync(
                    leaseId: aquireLeaseResponse.Value.LeaseId,
                    proposedId: newId,
                    accessConditions: accessConditions);

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

                var aquireLeaseResponse = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    container.ChangeLeaseAsync(
                        leaseId: aquireLeaseResponse.Value.LeaseId,
                        proposedId: newId,
                        accessConditions: accessConditions),
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

                var blobs = new List<BlobItem>();
                var marker = default(string);

                // Act
                do
                {
                    var response = await container.ListBlobsFlatSegmentAsync(marker);
                    blobs.AddRange(response.Value.BlobItems);
                    marker = response.Value.NextMarker;
                }
                while (!String.IsNullOrWhiteSpace(marker));

                // Assert
                Assert.AreEqual(this.BlobNames.Length, blobs.Count);

                var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();

                Assert.IsTrue(this.BlobNames.All(blobName => foundBlobNames.Contains(blobName)));
            }
        }

        [Test]
        public async Task ListBlobsFlatSegmentAsync_MaxResults()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.SetUpContainerForListing(container);

                // Act
                var response = await container.ListBlobsFlatSegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        MaxResults = 2
                    });


                // Assert
                Assert.AreEqual(2, response.Value.BlobItems.Count());
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
                var response = await container.ListBlobsFlatSegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Details = new BlobListingDetails
                        {
                            Metadata = true
                        }
                    });

                // Assert
                this.AssertMetadataEquality(metadata, response.Value.BlobItems.First().Metadata);
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
                var response = await container.ListBlobsFlatSegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Details = new BlobListingDetails
                        {
                            Deleted = true
                        }
                    });

                // Assert
                Assert.AreEqual("", response.Value.NextMarker);
                if (response.Value.BlobItems.Count() == 0)
                {
                    Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
                }
                Assert.AreEqual(1, response.Value.BlobItems.Count());
                Assert.AreEqual(blobName, response.Value.BlobItems.First().Name);

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
                var response = await container.ListBlobsFlatSegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Details = new BlobListingDetails
                        {
                            UncommittedBlobs = true
                        }
                    });

                // Assert
                Assert.AreEqual("", response.Value.NextMarker);
                Assert.AreEqual(1, response.Value.BlobItems.Count());
                Assert.AreEqual(blobName, response.Value.BlobItems.First().Name);
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
                var response = await container.ListBlobsFlatSegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Details = new BlobListingDetails
                        {
                            Snapshots = true
                        }
                    });

                // Assert
                Assert.AreEqual("", response.Value.NextMarker);
                Assert.AreEqual(2, response.Value.BlobItems.Count());
                Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), response.Value.BlobItems.First().Snapshot);
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
                var response = await container.ListBlobsFlatSegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Prefix = "foo"
                    });


                // Assert
                Assert.AreEqual(3, response.Value.BlobItems.Count());
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
                container.ListBlobsFlatSegmentAsync(),
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
                    var response = await container.ListBlobsFlatSegmentAsync();
                    var blobItem = response.Value.BlobItems.First();
                    Assert.AreEqual(blobName, blobItem.Name);
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
                var prefixes = new List<BlobPrefix>();
                var marker = default(string);
                var delimiter = "/";

                do
                {
                    var response = await container.ListBlobsHierarchySegmentAsync(marker, delimiter);
                    blobs.AddRange(response.Value.BlobItems);
                    prefixes.AddRange(response.Value.BlobPrefixes);
                    marker = response.Value.NextMarker;
                }
                while (!String.IsNullOrWhiteSpace(marker));

                Assert.AreEqual(3, blobs.Count);
                Assert.AreEqual(2, prefixes.Count);

                var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();
                var foundBlobPrefixes = prefixes.Select(prefix => prefix.Name).ToArray();
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
        public async Task ListBlobsHierarchySegmentAsync_MaxResults()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await this.SetUpContainerForListing(container);
                var delimiter = "/";

                // Act
                var response = await container.ListBlobsHierarchySegmentAsync(
                    delimiter: delimiter,
                    options: new BlobsSegmentOptions
                    {
                        MaxResults = 2
                    });

                // Assert
                Assert.AreEqual(2, response.Value.BlobItems.Count());
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
                var response = await container.ListBlobsHierarchySegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Details = new BlobListingDetails
                        {
                            Metadata = true
                        }
                    });

                // Assert
                this.AssertMetadataEquality(metadata, response.Value.BlobItems.First().Metadata);
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
                var response = await container.ListBlobsHierarchySegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Details = new BlobListingDetails
                        {
                            Deleted = true
                        }
                    });

                // Assert
                Assert.AreEqual("", response.Value.NextMarker);
                if (response.Value.BlobItems.Count() == 0)
                {
                    Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
                }
                Assert.AreEqual(1, response.Value.BlobItems.Count());
                Assert.AreEqual(blobName, response.Value.BlobItems.First().Name);

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
                var response = await container.ListBlobsHierarchySegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Details = new BlobListingDetails
                        {
                            UncommittedBlobs = true
                        }
                    });

                // Assert
                Assert.AreEqual("", response.Value.NextMarker);
                Assert.AreEqual(1, response.Value.BlobItems.Count());
                Assert.AreEqual(blobName, response.Value.BlobItems.First().Name);
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
                var response = await container.ListBlobsHierarchySegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Details = new BlobListingDetails
                        {
                            Snapshots = true
                        }
                    });

                // Assert
                Assert.AreEqual("", response.Value.NextMarker);
                Assert.AreEqual(2, response.Value.BlobItems.Count());
                Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), response.Value.BlobItems.First().Snapshot);
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
                var response = await container.ListBlobsHierarchySegmentAsync(
                    options: new BlobsSegmentOptions
                    {
                        Prefix = "foo"
                    });


                // Assert
                Assert.AreEqual(3, response.Value.BlobItems.Count());
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
                container.ListBlobsHierarchySegmentAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
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
