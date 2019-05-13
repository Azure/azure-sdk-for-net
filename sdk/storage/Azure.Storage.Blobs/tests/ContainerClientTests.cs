// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Storage.Blobs.Test
{
    [TestClass]
    public class ContainerClientTests
    {
        [TestMethod]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (blobEndpoint, blobSecondaryEndpoint), (default, default), (default, default), (default, default));

            var containerName = TestHelper.GetNewContainerName();

            var container = new BlobContainerClient(connectionString.ToString(true), containerName, TestHelper.GetOptions<BlobConnectionOptions>());

            var builder = new BlobUriBuilder(container.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual("", builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [TestMethod]
        public async Task CreateAsync_WithSharedKey()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());

            try
            {
                // Act
                var response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.Raw.Headers.RequestId);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [TestMethod]
        public async Task CreateAsync_WithOauth()
        {
            // Arrange
            var containerName = TestHelper.GetNewContainerName();
            var service = await TestHelper.GetServiceClient_OauthAccount();
            var container = service.GetBlobContainerClient(containerName);

            try
            {
                // Act
                var response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.Raw.Headers.RequestId);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [TestMethod]
        public async Task CreateAsync_WithAccountSas()
        {
            // Arrange
            var containerName = TestHelper.GetNewContainerName();
            var service = TestHelper.GetServiceClient_AccountSas();
            var container = service.GetBlobContainerClient(containerName);

            try
            {
                // Act
                var response = await container.CreateAsync();

                // Assert
                Assert.IsNotNull(response.Raw.Headers.RequestId);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        [TestMethod]
        public async Task CreateAsync_WithBlobServiceSas()
        {
            // Arrange
            var containerName = TestHelper.GetNewContainerName();
            var service = TestHelper.GetServiceClient_BlobServiceSas_Container(containerName);
            var container = service.GetBlobContainerClient(containerName);
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

        [TestMethod]
        public async Task CreateAsync_Metadata()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var metadata = TestHelper.BuildMetadata();

            // Act
            await container.CreateAsync(metadata: metadata);

            // Assert
            var response = await container.GetPropertiesAsync();
            TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);

            // Cleanup
            await container.DeleteAsync();
        }

        [TestMethod]
        public async Task CreateAsync_PublicAccess()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());

            // Act
            await container.CreateAsync(publicAccessType: PublicAccessType.Blob);

            // Assert
            var response = await container.GetPropertiesAsync();
            Assert.AreEqual(PublicAccessType.Blob, response.Value.Properties.PublicAccess);

            // Cleanup
            await container.DeleteAsync();
        }

        [TestMethod]
        public async Task CreateAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            // ContainerUri is intentually created twice
            await container.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.CreateAsync(),
                e => Assert.AreEqual("ContainerAlreadyExists", e.ErrorCode.Split('\n')[0]));

            // Cleanup
            await container.DeleteAsync();
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();

            // Act
            var response = await container.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [TestMethod]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.DeleteAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }


        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        public async Task DeleteAsync_AccessConditions(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            parameters.LeaseId = await TestHelper.SetupContainerLeaseCondition(container, parameters.LeaseId);
            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: true);

            // Act
            var response = await container.DeleteAsync(accessConditions: accessConditions);

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        public async Task DeleteAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                parameters.LeaseId = await TestHelper.SetupContainerLeaseCondition(container, parameters.LeaseId);
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

        [TestMethod]
        public async Task GetAccountInfoAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Act
                var response = await container.GetAccountInfoAsync();

                // Assert
                Assert.IsNotNull(response.Raw.Headers.RequestId);
            }
        }

        [TestMethod]
        public async Task GetAccountInfoAsync_Error()
        {
            // Arrange
            var service = new BlobServiceClient(
                TestHelper.GetServiceClient_SharedKey().Uri,
                TestHelper.GetOptions<BlobConnectionOptions>());
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetAccountInfoAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        public async Task GetPropertiesAsync()
        {
            using (TestHelper.GetNewContainer(out var container, publicAccessType: PublicAccessType.Container))
            {
                // Act
                var response = await container.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(PublicAccessType.Container, response.Value.Properties.PublicAccess);
            }
        }

        [TestMethod]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetPropertiesAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        public async Task SetMetadataAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var metadata = TestHelper.BuildMetadata();

                // Act
                await container.SetMetadataAsync(metadata);

                // Assert
                var response = await container.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [TestMethod]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var metadata = TestHelper.BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        public static IEnumerable<object[]> SetMetadataAsync_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.ReceivedLeaseId
                },

            }.Select(x => new object[] { x });

        [DataTestMethod]
        [DynamicData(nameof(SetMetadataAsync_AccessConditions_Data), DynamicDataSourceType.Property)]
        public async Task SetMetadataAsync_AccessConditions(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            parameters.LeaseId = await TestHelper.SetupContainerLeaseCondition(container, parameters.LeaseId);
            var metadata = TestHelper.BuildMetadata();
            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: false,
                lease: true);

            // Act
            var response = await container.SetMetadataAsync(
                metadata: metadata,
                accessConditions: accessConditions);

            // Assert
            Assert.IsNotNull(response.Raw.Headers.RequestId);

            // Cleanup
            await container.DeleteAsync(new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = parameters.LeaseId
                }
            });
        }

        public static IEnumerable<object[]> SetMetadataAsync_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.GarbageLeaseId
                },

            }.Select(x => new object[] { x });

        [DataTestMethod]
        [DynamicData(nameof(SetMetadataAsync_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        public async Task SetMetadataAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var metadata = TestHelper.BuildMetadata();
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

        [TestMethod]
        public async Task GetAccessPolicyAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Act
                var response = await container.GetAccessPolicyAsync();

                // Assert
                Assert.IsNotNull(response);
            }
        }

        [TestMethod]
        public async Task GetAccessPolicyAsync_Lease()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var leaseId = await TestHelper.SetupContainerLeaseCondition(container, TestHelper.ReceivedLeaseId);
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

        [TestMethod]
        public async Task GetAccessPolicyAsync_LeaseFail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var leaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = TestHelper.GarbageLeaseId
                };

                 // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    container.GetAccessPolicyAsync(leaseAccessConditions: leaseAccessConditions),
                    e => Assert.AreEqual("LeaseNotPresentWithContainerOperation", e.ErrorCode.Split('\n')[0]));
            }
        }

        [TestMethod]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        public async Task SetAccessPolicyAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var publicAccessType = PublicAccessType.Container;
                var signedIdentifiers = TestHelper.BuildSignedIdentifiers();

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

        [TestMethod]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var signedIdentifiers = TestHelper.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.SetAccessPolicyAsync(permissions: signedIdentifiers),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestMethod]
        public async Task SetAccessPolicyAsync_AccessConditions(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var publicAccessType = PublicAccessType.Container;
            var signedIdentifiers = TestHelper.BuildSignedIdentifiers();
            parameters.LeaseId = await TestHelper.SetupContainerLeaseCondition(container, parameters.LeaseId);
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
            Assert.IsNotNull(response.Raw.Headers.RequestId);

            // Cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = parameters.LeaseId
                }
            });
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestMethod]
        public async Task SetAccessPolicyAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var publicAccessType = PublicAccessType.Container;
                var signedIdentifiers = TestHelper.BuildSignedIdentifiers();
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

        [TestMethod]
        public async Task AcquireLeaseAsync()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var id = Guid.NewGuid().ToString();
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

        [TestMethod]
        public async Task AcquireLeaseAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var id = Guid.NewGuid().ToString();
            var duration = 15;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        public async Task AcquireLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: false);

            var id = Guid.NewGuid().ToString();
            var duration = 15;

            // Act
            var response = await container.AcquireLeaseAsync(
                duration: duration,
                proposedId: id,
                accessConditions: accessConditions);

            // Assert
            Assert.IsNotNull(response.Raw.Headers.RequestId);

            // cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = response.Value.LeaseId
                }
            });
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        public async Task AcquireLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Guid.NewGuid().ToString();
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

        [TestMethod]
        public async Task RenewLeaseAsync()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();

            var id = Guid.NewGuid().ToString();
            var duration = 15;

            var leaseResponse = await container.AcquireLeaseAsync(
                duration: duration,
                proposedId: id); 

            // Act
            var renewResponse = await container.RenewLeaseAsync(leaseResponse.Value.LeaseId);

            // Assert
            Assert.IsNotNull(renewResponse.Raw.Headers.RequestId);

            // Cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = renewResponse.Value.LeaseId
                }
            });
        }

        [TestMethod]
        public async Task RenewLeaseAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var id = Guid.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.ReleaseLeaseAsync(
                    leaseId: id),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        public async Task RenewLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: false);

            var id = Guid.NewGuid().ToString();
            var duration = 15;
            _ = await container.AcquireLeaseAsync(
                duration: duration,
                proposedId: id);

            // Act
            var response = await container.RenewLeaseAsync(
                leaseId: id,
                accessConditions: accessConditions);

            // Assert
            Assert.IsNotNull(response.Raw.Headers.RequestId);

            // cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = response.Value.LeaseId
                }
            });
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        public async Task RenewLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: false);

            var id = Guid.NewGuid().ToString();
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

        [TestMethod]
        public async Task ReleaseLeaseAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var id = Guid.NewGuid().ToString();
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

        [TestMethod]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var id = Guid.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.ReleaseLeaseAsync(
                    leaseId: id),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        public async Task ReleaseLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            // Arrange
            using (TestHelper.GetNewContainer(out var container))
            {
                var accessConditions = this.BuildContainerAccessConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Guid.NewGuid().ToString();
                var duration = 15;

                var aquireLeaseResponse = await container.AcquireLeaseAsync(
                    duration: duration,
                    proposedId: id);

                // Act
                var response = await container.ReleaseLeaseAsync(
                    leaseId: id,
                    accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Raw.Headers.RequestId);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        public async Task ReleaseLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: false);

            var id = Guid.NewGuid().ToString();
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

        [TestMethod]
        public async Task BreakLeaseAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var id = Guid.NewGuid().ToString();
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

        [TestMethod]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var id = Guid.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.BreakLeaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        public async Task BreakLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();

            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: false);

            var id = Guid.NewGuid().ToString();
            var duration = 15;

            var aquireLeaseResponse = await container.AcquireLeaseAsync(
                duration: duration,
                proposedId: id);

            // Act
            var response = await container.BreakLeaseAsync(
                accessConditions: accessConditions);

            // Assert
            Assert.IsNotNull(response.Raw.Headers.RequestId);

            // Cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                }
            });
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        public async Task BreakLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: false);

            var id = Guid.NewGuid().ToString();
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

        [TestMethod]
        public async Task ChangeLeaseAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var id = Guid.NewGuid().ToString();
                var duration = 15;
                var leaseResponse = await container.AcquireLeaseAsync(duration, id);
                var newId = Guid.NewGuid().ToString();

                // Act
                var changeResponse = await container.ChangeLeaseAsync(leaseResponse.Value.LeaseId, newId);

                // Assert
                Assert.AreEqual(newId, changeResponse.Value.LeaseId);

                // Cleanup
                await container.ReleaseLeaseAsync(changeResponse.Value.LeaseId);
            }
        }

        [TestMethod]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var id = Guid.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.ChangeLeaseAsync(id, id),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditions_Data), DynamicDataSourceType.Property)]
        public async Task ChangeLeaseAsync_AccessConditions(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();

            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: false);

            var id = Guid.NewGuid().ToString();
            var newId = Guid.NewGuid().ToString();
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
            Assert.IsNotNull(response.Raw.Headers.RequestId);

            // Cleanup
            await container.DeleteAsync(accessConditions: new ContainerAccessConditions
            {
                LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = response.Value.LeaseId
                }
            });
        }

        [DataTestMethod]
        [DynamicData(nameof(NoLease_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        public async Task ChangeLeaseAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            await container.CreateAsync();
            var accessConditions = this.BuildContainerAccessConditions(
                parameters: parameters,
                ifUnmodifiedSince: true,
                lease: false);

            var id = Guid.NewGuid().ToString();
            var newId = Guid.NewGuid().ToString();
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

        [TestMethod]
        public async Task ListBlobsFlatSegmentAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
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

        [TestMethod]
        public async Task ListBlobsFlatSegmentAsync_MaxResults()
        {
            using (TestHelper.GetNewContainer(out var container))
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
        
        [TestMethod]
        public async Task ListBlobsFlatSegmentAsync_Metadata()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                var metadata = TestHelper.BuildMetadata();
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
                TestHelper.AssertMetadataEquality(metadata, response.Value.BlobItems.First().Metadata);
            }
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task ListBlobsFlatSegmentAsync_Deleted()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await TestHelper.EnableSoftDelete();
                var blobName = TestHelper.GetNewBlobName();
                var blob = container.GetAppendBlobClient(blobName);
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
                await TestHelper.DisableSoftDelete();
            }
        }

        [TestMethod]
        public async Task ListBlobsFlatSegmentAsync_Uncommited()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blobName = TestHelper.GetNewBlobName();
                var blob = container.GetBlockBlobClient(blobName);
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var blockId = TestHelper.ToBase64(TestHelper.GetNewBlockName());

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(
                        base64BlockID: blockId,
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

        [TestMethod]
        public async Task ListBlobsFlatSegmentAsync_Snapshot()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
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

        [TestMethod]
        public async Task ListBlobsFlatSegmentAsync_Prefix()
        {
            using (TestHelper.GetNewContainer(out var container))
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

        [TestMethod]
        public async Task ListBlobsFlatSegmentAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var id = Guid.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                container.ListBlobsFlatSegmentAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        public async Task ListBlobsHierarchySegmentAsync()
        { 

            using (TestHelper.GetNewContainer(out var container))
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

        [TestMethod]
        public async Task ListBlobsHierarchySegmentAsync_MaxResults()
        {
            using (TestHelper.GetNewContainer(out var container))
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
        
        [TestMethod]
        public async Task ListBlobsHierarchySegmentAsync_Metadata()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                var metadata = TestHelper.BuildMetadata();
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
                TestHelper.AssertMetadataEquality(metadata, response.Value.BlobItems.First().Metadata);
            }
        }

        [TestMethod]
        [DoNotParallelize]
        public async Task ListBlobsHierarchySegmentAsync_Deleted()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await TestHelper.EnableSoftDelete();
                var blobName = TestHelper.GetNewBlobName();
                var blob = container.GetAppendBlobClient(blobName);
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
                await TestHelper.DisableSoftDelete();
            }
        }

        [TestMethod]
        public async Task ListBlobsHierarchySegmentAsync_Uncommited()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blobName = TestHelper.GetNewBlobName();
                var blob = container.GetBlockBlobClient(blobName);
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var blockId = TestHelper.ToBase64(TestHelper.GetNewBlockName());

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(
                        base64BlockID: blockId,
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

        [TestMethod]
        public async Task ListBlobsHierarchySegmentAsync_Snapshot()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
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

        [TestMethod]
        public async Task ListBlobsHierarchySegmentAsync_Prefix()
        {
            using (TestHelper.GetNewContainer(out var container))
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

        [TestMethod]
        public async Task ListBlobsHierarchySegmentAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var container = service.GetBlobContainerClient(TestHelper.GetNewContainerName());
            var id = Guid.NewGuid().ToString();

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

            var data = TestHelper.GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                var blob = container.GetBlockBlobClient(blobNames[i]);
                blobs[i] = blob;

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Set metadata on Blob index 3
            var metadata = TestHelper.BuildMetadata();
            await blobs[3].SetMetadataAsync(metadata);
        }

        public static IEnumerable<object[]> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.ReceivedLeaseId
                }
            }.Select(x => new object[] { x });

        public static IEnumerable<object[]> AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.GarbageETag
                },
             }.Select(x => new object[] { x });

        public static IEnumerable<object[]> NoLease_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.NewDate
                }
            }.Select(x => new object[] { x });

        public static IEnumerable<object[]> NoLease_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.OldDate
                },
            }.Select(x => new object[] { x });

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

        public struct AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string LeaseId { get; set; }
        }

    }
}
