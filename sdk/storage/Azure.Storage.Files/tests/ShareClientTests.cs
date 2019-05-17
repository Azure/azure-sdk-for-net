// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;
using Azure.Storage.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Storage.Files.Test
{
    [TestClass]
    public class ShareClientTests
    {
        [TestMethod]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var shareName = TestHelper.GetNewShareName();

            var share = new ShareClient(connectionString.ToString(true), shareName, TestHelper.GetOptions<FileConnectionOptions>());

            var builder = new FileUriBuilder(share.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual("", builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [TestMethod]
        public void WithSnapshot()
        {
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);
            var builder = new FileUriBuilder(share.Uri);

            Assert.AreEqual("", builder.Snapshot);

            share = share.WithSnapshot("foo");
            builder = new FileUriBuilder(share.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            share = share.WithSnapshot(null);
            builder = new FileUriBuilder(share.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }


        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateAsync()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);

            try
            {
                // Act
                var response = await share.CreateAsync(quotaInBytes: 1);

                // Assert
                Assert.IsNotNull(response.Raw.Headers.RequestId);
            }
            finally
            {
                await share.DeleteAsync();
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateAsync_Metadata()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);
            var metadata = TestHelper.BuildMetadata();

            // Act
            await share.CreateAsync(metadata: metadata);

            // Assert
            var response = await share.GetPropertiesAsync();
            TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);

            // Cleanup
            await share.DeleteAsync();
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateAsync_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);
            // Share is intentionally created twice
            await share.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.CreateAsync(),
                e => Assert.AreEqual("ShareAlreadyExists", e.ErrorCode.Split('\n')[0]));

            // Cleanup
            await share.DeleteAsync();
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateAsync_WithAccountSas()
        {
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_AccountSas();
            var share = service.GetShareClient(shareName);

            try
            {
                var result = await share.CreateAsync(quotaInBytes: 1);

                Assert.AreNotEqual(default, result.Raw.Headers.RequestId, $"{nameof(result)} may not be populated");
            }
            finally
            {
                await share.DeleteAsync();
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateAsync_WithFileServiceSas()
        {
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_FileServiceSasShare(shareName);
            var share = service.GetShareClient(shareName);

            var pass = false;

            try
            {
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    share.CreateAsync(quotaInBytes: 1),
                    e =>
                    {
                        Assert.AreEqual(StorageErrorCode.AuthorizationFailure.ToString(), e.ErrorCode);
                        pass = true;
                    }
                    );
            }
            finally
            {
                if (!pass)
                {
                    await share.DeleteAsync();
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync()
        {
            using (TestHelper.GetNewShare(out var share))
            {
                // Act
                var reponse = await share.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(reponse.Raw.Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.GetPropertiesAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetMetadataAsync()
        {
            using (TestHelper.GetNewShare(out var share))
            {
                // Arrange
                var metadata = TestHelper.BuildMetadata();

                // Act
                await share.SetMetadataAsync(metadata);

                // Assert
                var response = await share.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);
            var metadata = TestHelper.BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetAccessPolicyAsync()
        {
            using (TestHelper.GetNewShare(out var share))
            {
                // Arrange
                var signedIdentifiers = TestHelper.BuildSignedIdentifiers();
                await share.SetAccessPolicyAsync(signedIdentifiers);

                // Act
                var response = await share.GetAccessPolicyAsync();

                // Assert
                var acl = response.Value.First();

                Assert.AreEqual(1, response.Value.Count());
                Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Start, acl.AccessPolicy.Start);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Expiry, acl.AccessPolicy.Expiry);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permission, acl.AccessPolicy.Permission);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetAccessPolicyAsync()
        {
            using (TestHelper.GetNewShare(out var share))
            {
                // Arrange
                var signedIdentifiers = TestHelper.BuildSignedIdentifiers();

                // Act
                var response = await share.SetAccessPolicyAsync(signedIdentifiers);

                // Assert
                Assert.IsNotNull(response.Raw.Headers.RequestId);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);
            var signedIdentifiers = TestHelper.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.SetAccessPolicyAsync(signedIdentifiers),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetStatisticsAsync()
        {
            using (TestHelper.GetNewShare(out var share))
            {
                // Act
                var response = await share.GetStatisticsAsync();

                // Assert
                Assert.IsNotNull(response);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetStatisticsAsync_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);
            var signedIdentifiers = TestHelper.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.GetStatisticsAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateSnapshotAsync()
        {
            using (TestHelper.GetNewShare(out var share))
            {
                // Act
                var response = await share.CreateSnapshotAsync();

                // Assert
                Assert.IsNotNull(response);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CreateSnapshotAsync_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.CreateSnapshotAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetQuotaAsync()
        {
            using (TestHelper.GetNewShare(out var share))
            {
                // Act
                await share.SetQuotaAsync(Constants.KB);

                // Assert
                var response = await share.GetPropertiesAsync();
                Assert.AreEqual(Constants.KB, response.Value.Quota);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetQuotaAsync_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.SetQuotaAsync(Constants.KB),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DeleteAsync()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);
            await share.CreateAsync(quotaInBytes: 1);

            // Act
            var response = await share.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task Delete_Error()
        {
            // Arrange
            var shareName = TestHelper.GetNewShareName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var share = service.GetShareClient(shareName);
            var signedIdentifiers = TestHelper.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.DeleteAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }
    }
}
