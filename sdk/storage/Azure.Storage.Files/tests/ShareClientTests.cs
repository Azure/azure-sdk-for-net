// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;
using Azure.Storage.Files.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Test
{
    [TestFixture]
    public class ShareClientTests : FileTestBase
    {
        public ShareClientTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var shareName = this.GetNewShareName();

            var share = this.InstrumentClient(new ShareClient(connectionString.ToString(true), shareName, this.GetOptions()));

            var builder = new FileUriBuilder(share.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual("", builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public void WithSnapshot()
        {
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));
            var builder = new FileUriBuilder(share.Uri);

            Assert.AreEqual("", builder.Snapshot);

            share = this.InstrumentClient(share.WithSnapshot("foo"));
            builder = new FileUriBuilder(share.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            share = this.InstrumentClient(share.WithSnapshot(null));
            builder = new FileUriBuilder(share.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        [Test]
        public async Task CreateAsync()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));

            try
            {
                // Act
                var response = await share.CreateAsync(quotaInBytes: 1);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
            finally
            {
                await share.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));
            var metadata = this.BuildMetadata();

            // Act
            await share.CreateAsync(metadata: metadata);

            // Assert
            var response = await share.GetPropertiesAsync();
            this.AssertMetadataEquality(metadata, response.Value.Metadata);

            // Cleanup
            await share.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));

            // Share is intentionally created twice
            await share.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.CreateAsync(),
                e => Assert.AreEqual("ShareAlreadyExists", e.ErrorCode.Split('\n')[0]));

            // Cleanup
            await share.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_WithAccountSas()
        {
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_AccountSas();
            var share = this.InstrumentClient(service.GetShareClient(shareName));

            try
            {
                var result = await share.CreateAsync(quotaInBytes: 1);

                Assert.AreNotEqual(default, result.GetRawResponse().Headers.RequestId, $"{nameof(result)} may not be populated");
            }
            finally
            {
                await share.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithFileServiceSas()
        {
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_FileServiceSasShare(shareName);
            var share = this.InstrumentClient(service.GetShareClient(shareName));

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

        [Test]
        public async Task GetPropertiesAsync()
        {
            using (this.GetNewShare(out var share))
            {
                // Act
                var reponse = await share.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(reponse.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.GetPropertiesAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var metadata = this.BuildMetadata();

                // Act
                await share.SetMetadataAsync(metadata);

                // Assert
                var response = await share.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));
            var metadata = this.BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetAccessPolicyAsync()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var signedIdentifiers = this.BuildSignedIdentifiers();
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

        [Test]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var signedIdentifiers = this.BuildSignedIdentifiers();

                // Act
                var response = await share.SetAccessPolicyAsync(signedIdentifiers);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));
            var signedIdentifiers = this.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.SetAccessPolicyAsync(signedIdentifiers),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetStatisticsAsync()
        {
            using (this.GetNewShare(out var share))
            {
                // Act
                var response = await share.GetStatisticsAsync();

                // Assert
                Assert.IsNotNull(response);
            }
        }

        [Test]
        public async Task GetStatisticsAsync_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));
            var signedIdentifiers = this.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.GetStatisticsAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateSnapshotAsync()
        {
            using (this.GetNewShare(out var share))
            {
                // Act
                var response = await share.CreateSnapshotAsync();

                // Assert
                Assert.IsNotNull(response);
            }
        }

        [Test]
        public async Task CreateSnapshotAsync_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.CreateSnapshotAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetQuotaAsync()
        {
            using (this.GetNewShare(out var share))
            {
                // Act
                await share.SetQuotaAsync(Constants.KB);

                // Assert
                var response = await share.GetPropertiesAsync();
                Assert.AreEqual(Constants.KB, response.Value.Quota);
            }
        }

        [Test]
        public async Task SetQuotaAsync_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.SetQuotaAsync(Constants.KB),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));
            await share.CreateAsync(quotaInBytes: 1);

            // Act
            var response = await share.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task Delete_Error()
        {
            // Arrange
            var shareName = this.GetNewShareName();
            var service = this.GetServiceClient_SharedKey();
            var share = this.InstrumentClient(service.GetShareClient(shareName));
            var signedIdentifiers = this.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                share.DeleteAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }
    }
}
