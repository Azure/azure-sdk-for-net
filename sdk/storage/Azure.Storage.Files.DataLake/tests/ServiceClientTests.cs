// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class ServiceClientTests : DataLakeTestBase
    {
        public ServiceClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task Ctor_Uri()
        {
            // Arrange
            SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasQueryParameters}");
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(uri, GetOptions()));

            // Act
            await serviceClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(uri, serviceClient.Uri);
        }

        [Test]
        public async Task Ctor_SharedKey()
        {
            // Arrange
            StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                TestConfigHierarchicalNamespace.AccountName,
                TestConfigHierarchicalNamespace.AccountKey);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint);
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(uri, sharedKey, GetOptions()));

            // Act
            await serviceClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(uri, serviceClient.Uri);
        }

        [Test]
        public async Task Ctor_TokenCredential()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttps();
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(uri, tokenCredential, GetOptions()));

            // Act
            await serviceClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(uri, serviceClient.Uri);
        }

        [Test]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_OAuth();

            // Act
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(start: null, expiry: Recording.UtcNow.AddHours(1));

            // Assert
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(start: null, expiry: Recording.UtcNow.AddHours(1)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetFileSystemsAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewFileSystem(out _, service: service))
            {
                // Act
                IList<FileSystemItem> fileSystems = await service.GetFileSystemsAsync().ToListAsync();

                // Assert
                Assert.IsTrue(fileSystems.Count >= 1);
                var accountName = new DataLakeUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
            }
        }

        [Test]
        public async Task GetFileSystemsAsync_Marker()
        {
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, service: service))
            {
                var marker = default(string);
                var fileSystems = new List<FileSystemItem>();

                await foreach (Page<FileSystemItem> page in service.GetFileSystemsAsync().AsPages(marker))
                {
                    fileSystems.AddRange(page.Values);
                }

                Assert.AreNotEqual(0, fileSystems.Count);
                Assert.AreEqual(fileSystems.Count, fileSystems.Select(c => c.Name).Distinct().Count());
                Assert.IsTrue(fileSystems.Any(c => fileSystem.Uri == InstrumentClient(service.GetFileSystemClient(c.Name)).Uri));
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetFileSystemsAsync_MaxResults()
        {
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewFileSystem(out _, service: service))
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, service: service))
            {
                // Act
                Page<FileSystemItem> page = await
                    service.GetFileSystemsAsync()
                    .AsPages(pageSizeHint: 1)
                    .FirstAsync();

                // Assert
                Assert.AreEqual(1, page.Values.Count());
            }
        }

        [Test]
        public async Task GetFileSystemsAsync_Prefix()
        {
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            var prefix = "aaa";
            var fileSystemName = prefix + GetNewFileSystemName();
            // Ensure at least one container
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, service: service, fileSystemName: fileSystemName))
            {
                // Act
                AsyncPageable<FileSystemItem> fileSystems = service.GetFileSystemsAsync(prefix: prefix);
                IList<FileSystemItem> items = await fileSystems.ToListAsync();
                // Assert
                Assert.AreNotEqual(0, items.Count());
                Assert.IsTrue(items.All(c => c.Name.StartsWith(prefix)));
                Assert.IsNotNull(items.Single(c => c.Name == fileSystemName));
            }
        }

        [Test]
        public async Task GetFileSystemsAsync_Metadata()
        {
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, service: service))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();
                await fileSystem.SetMetadataAsync(metadata);

                // Act
                IList<FileSystemItem> items = await service.GetFileSystemsAsync(FileSystemTraits.Metadata).ToListAsync();

                // Assert
                AssertMetadataEquality(
                    metadata,
                    items.Where(i => i.Name == fileSystem.Name).FirstOrDefault().Properties.Metadata);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetFileSystemsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetFileSystemsAsync().AsPages(continuationToken: "garbage").FirstAsync(),
                e =>
                {
                    Assert.AreEqual("OutOfRangeInput", e.ErrorCode);
                    Assert.AreEqual("One of the request inputs is out of range.", e.Message.Split('\n')[0]);
                });
        }

        [Test]
        public async Task CreateFileSystemAsync()
        {
            var name = GetNewFileSystemName();
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            try
            {
                DataLakeFileSystemClient fileSystem = InstrumentClient((await service.CreateFileSystemAsync(name)).Value);
                Response<FileSystemProperties> properties = await fileSystem.GetPropertiesAsync();
                Assert.IsNotNull(properties.Value);
            }
            finally
            {
                await service.DeleteFileSystemAsync(name);
            }
        }

        [Test]
        public async Task DeleteFileSystemAsync()
        {
            var name = GetNewFileSystemName();
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient((await service.CreateFileSystemAsync(name)).Value);

            await service.DeleteFileSystemAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await fileSystem.GetPropertiesAsync());
        }
    }
}
