// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.DataMovement.Tests.Shared;

namespace Azure.Storage.Blobs.DataMovement.Tests
{
    public class BlobFolderClientTests : DataMovementBlobTestBase
    {
        public BlobFolderClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
                : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
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
        private async Task SetUpDirectoryForListing(BlobFolderClient directory)
        {
            var blobNames = BlobNames;

            var data = GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                BlockBlobClient blob = InstrumentClient( (BlockBlobClient)directory.GetBlobBaseClient(blobNames[i]));
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

        /*
        [RecordedTest]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            var containerName = GetNewContainerName();
            BlobContainerClient containerClient = new BlobContainerClient(connectionString.ToString(), containerName);
            var directoryName = GetNewBlobDirectoryName();

            BlobFolderClient directory1 = InstrumentClient(new BlobFolderClient(containerClient, directoryName));
            BlobFolderClient directory2 = InstrumentClient(new BlobFolderClient(containerClient, directoryName));

            var builder1 = new BlobUriBuilder(directory1.Uri);
            var builder2 = new BlobUriBuilder(directory2.Uri);

            Assert.AreEqual(containerName, builder1.BlobContainerName);
            // Directory Name == Blob Name
            Assert.AreEqual(directoryName, builder1.BlobName);
            Assert.AreEqual("accountName", builder1.AccountName);

            Assert.AreEqual(containerName, builder2.BlobContainerName);
            Assert.AreEqual(directoryName, builder2.BlobName);
            Assert.AreEqual("accountName", builder2.AccountName);
        }

        [RecordedTest]
        public async Task Ctor_ConnectionStringEscapeBlobName()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string directoryName = "!*'();[]:@&%=+$,/?#äÄöÖüÜß";
            string fullBlobPath = $"{directoryName}/{GetNewBlobName()}";

            BlockBlobClient initalBlob = InstrumentClient(test.Container.GetBlockBlobClient(fullBlobPath));
            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            Response<BlobContentInfo> uploadResponse = await initalBlob.UploadAsync(stream);

            // Act
            BlobFolderClient directoryClient = new BlobFolderClient(test.Container, directoryName);
            IList<BlobItem> listResponse = await directoryClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(listResponse.First().Name, fullBlobPath);

            // Act
            BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.All, DateTimeOffset.UtcNow.AddDays(1));
            BlobFolderClient directorySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Container(
                    containerName: test.Container.Name)
                .GetBlobContainerClient(test.Container.Name)
                .GetBlobFolderClient(directoryName));

            listResponse = await directorySasBlob.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(listResponse.First().Name, fullBlobPath);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            BlockBlobClient blobClient =(BlockBlobClient) directoryClient.GetBlobBaseClient(GetNewBlobName());
            await blobClient.UploadAsync(new MemoryStream());
            Uri directoryUri = directoryClient.Uri;

            BlobContainerClient containerClient = new BlobContainerClient(test.Container.Uri, new AzureSasCredential(sas), GetBlobClientOptions());

            // Act
            BlobFolderClient sasClient = InstrumentClient(new BlobFolderClient(containerClient, directoryClient.DirectoryPrefix));
            IList<BlobItem> blobItems = await sasClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.IsNotEmpty(blobItems);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_UserDelegationSAS()
        {
            // Arrange
            BlobServiceClient oauthService = BlobsClientBuilder.GetServiceClient_OAuth();
            await using DisposingBlobContainer test = await GetTestContainerAsync(oauthService);
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());
            BlockBlobClient blobClient = (BlockBlobClient)directoryClient.GetBlobBaseClient(GetNewBlobName());

            await blobClient.UploadAsync(new MemoryStream());
            Uri blobUri = blobClient.Uri;
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            var sasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.All, Recording.UtcNow.AddHours(1))
            {
                BlobContainerName = blobClient.BlobContainerName,
            };
            var sas = sasBuilder.ToSasQueryParameters(userDelegationKey.Value, blobClient.AccountName).ToString();

            BlobContainerClient containerClient = new BlobContainerClient(test.Container.Uri, new AzureSasCredential(sas), GetBlobClientOptions());

            // Act
            var sasClient = InstrumentClient(new BlobFolderClient(containerClient, directoryClient.DirectoryPrefix));
            IList<BlobItem> blobItems = await sasClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.IsNotEmpty(blobItems);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();

            BlobContainerClient containerClient = new BlobContainerClient(test.Container.Uri, new AzureSasCredential(sas), GetBlobClientOptions());

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new BlobFolderClient(containerClient, "foo"),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, false, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(4, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());
            // Assert - Check destination blobs
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, false, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(1, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(1, blobs.Count());
            Assert.AreEqual(blobs.First(), dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_SingleSubdirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);
            string openSubchild2 = CreateRandomFile(openSubfolder);
            string openSubchild3 = CreateRandomFile(openSubfolder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, false, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(3, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(3, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild3.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string openSubfolder2 = CreateRandomDirectory(folder);
            string openSubChild2_1 = CreateRandomFile(openSubfolder2);
            string openSubChild2_2 = CreateRandomFile(openSubfolder2);
            string openSubChild2_3 = CreateRandomFile(openSubfolder2);

            string openSubfolder3 = CreateRandomDirectory(folder);
            string openSubChild3_1 = CreateRandomFile(openSubfolder2);
            string openSubChild3_2 = CreateRandomFile(openSubfolder2);
            string openSubChild3_3 = CreateRandomFile(openSubfolder2);

            string openSubfolder4 = CreateRandomDirectory(folder);
            string openSubChild4_1 = CreateRandomFile(openSubfolder2);
            string openSubChild4_2 = CreateRandomFile(openSubfolder2);
            string openSubChild4_3 = CreateRandomFile(openSubfolder2);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, false, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(10, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(10, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild2_3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild3_3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_1.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubChild4_3.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task UploadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string subfolderName = folder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = CreateRandomFile(openSubfolder);
                subfolderName = openSubfolder;
            }

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, false, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(level, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(level, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_EmptySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);
            string openSubchild2 = CreateRandomFile(openSubfolder);
            string openSubchild3 = CreateRandomFile(openSubfolder);
            string openSubchild4 = CreateRandomFile(openSubfolder);
            string openSubchild5 = CreateRandomFile(openSubfolder);
            string openSubchild6 = CreateRandomFile(openSubfolder);

            string openSubfolder2 = CreateRandomDirectory(folder);

            string openSubfolder3 = CreateRandomDirectory(folder);

            string openSubfolder4 = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, false, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(6, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert - Check destination blobs
            Assert.AreEqual(6, blobs.Count());
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild2.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild3.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild4.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild5.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild6.Substring(folder.Length + 1).Replace('\\', '/'));
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task UploadDirectory_ImmutableStorageWithVersioning()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions()
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true,
            };

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, false, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(4, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();

            Assert.AreEqual(4, blobs.Count());
            foreach (BlobItem blob in blobs)
            {
                Assert.AreEqual(blob.Properties.ImmutabilityPolicy.ExpiresOn, expectedImmutabilityPolicyExpiry);
                Assert.AreEqual(blob.Properties.ImmutabilityPolicy.PolicyMode,immutabilityPolicy.PolicyMode);
                Assert.IsTrue(blob.Properties.HasLegalHold);
            }

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_OverwriteTrue()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            BlobClient blobClient = (BlobClient) client.GetBlobBaseClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, true, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(4, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_OverwriteFalse()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobClient blobClient = (BlobClient) client.GetBlobBaseClient(dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
            await blobClient.UploadAsync(openChild);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(folder, false, options);

            // Assert - Check Response
            Assert.NotNull(response);
            Assert.AreEqual(4, response.Count());
            foreach (SingleBlobContentInfo responseItem in response)
            {
                Assert.NotNull(responseItem);
                Assert.NotNull(responseItem.BlobUri);
                Assert.NotNull(responseItem.ContentInfo);
            }

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            Assert.AreEqual(4, blobs.Count());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            await client.UploadAsync(folder, false, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            await client.UploadAsync(folder, false, options);

            Directory.Delete(folder, true);

            await client.DownloadToAsync(folder);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(localItemsAfterDownload, openChild);
                CollectionAssert.Contains(localItemsAfterDownload, lockedChild);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild);
                CollectionAssert.Contains(localItemsAfterDownload, lockedSubchild);
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            // Act
            await client.DownloadToAsync(folder);
            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.IsEmpty(localItemsAfterDownload);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string sourceFolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(sourceFolder);
            string localDirName = sourceFolder.Split('\\').Last();

            string destinationFolder = CreateRandomDirectory(folder);

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            await client.UploadAsync(sourceFolder, false, options);

            // Act
            await client.DownloadToAsync(destinationFolder);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Equals(1, localItemsAfterDownload.Count());
            AssertContentFile(openSubchild, destinationFolder + "/" + localItemsAfterDownload.First());

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_SingleSubDirectory()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string mainSubFolder = CreateRandomDirectory(folder);
            string sourceSubFolder = CreateRandomDirectory(mainSubFolder);
            string sourceSubChild = CreateRandomFile(sourceSubFolder);

            string destinationSubfolder = CreateRandomDirectory(mainSubFolder);
            string destinationSubchild = CreateRandomFile(destinationSubfolder);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            await client.UploadAsync(folder, false, options);

            Directory.Delete(folder, true);

            // Act
            await client.DownloadToAsync(folder);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Equals(1, localItemsAfterDownload.Count());
            Assert.Equals(localItemsAfterDownload.First(), destinationSubchild);
            AssertContentFile(sourceSubChild, destinationSubchild);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task DownloadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            string mainFolder = CreateRandomDirectory(folder);
            string souceSubFolder = CreateRandomDirectory(mainFolder);
            string openSubchild = CreateRandomFile(souceSubFolder);
            string souceSubFolder2 = CreateRandomDirectory(mainFolder);
            string openSubchild2 = CreateRandomFile(souceSubFolder2);
            string souceSubFolder3 = CreateRandomDirectory(mainFolder);
            string openSubchild3 = CreateRandomFile(souceSubFolder3);

            string destinationFolder = CreateRandomDirectory(souceSubFolder);

            string localDirName = folder.Split('\\').Last();

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();

            await client.UploadAsync(folder, false, options);

            // Act
            await client.DownloadToAsync(folder);

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild2);
                CollectionAssert.Contains(localItemsAfterDownload, openSubchild3);
            });

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DownloadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);

            string sourceFolder = CreateRandomDirectory(Path.GetTempPath());
            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            string subfolderName = sourceFolder;
            for (int i = 0; i < level; i++)
            {
                string openSubfolder = CreateRandomDirectory(subfolderName);
                string openSubchild = CreateRandomFile(openSubfolder);
                subfolderName = openSubfolder;
            }

            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            IEnumerable<SingleBlobContentInfo> response = await client.UploadAsync(sourceFolder, false, options);

            // Act
            await client.DownloadToAsync(destinationFolder);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            Assert.Equals(level, localItemsAfterDownload);

            // Cleanup
            Directory.Delete(sourceFolder, true);
            Directory.Delete(destinationFolder, true);
        }

        // This test is here just to see if DM stuff works, but shouldn't sit in here
        // (just needed to use DisposingBlobContainer). Maybe a refactor for Disposing* stuff out to a
        // test common source might be useful for DMLib tests.

        // Test is disabled as it will not function properly until _toScanQueue > _jobsToProcess
        // transition is implemented.
        [RecordedTest]
        public async Task TransferManager_UploadTwoDirectories()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            string dirName = GetNewBlobName();
            BlobFolderClient client = test.Container.GetBlobFolderClient(dirName);
            string dirTwoName = GetNewBlobName();
            BlobFolderClient clientTwo = test.Container.GetBlobFolderClient(dirTwoName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);
            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);
            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);
            BlobFolderUploadOptions options = new BlobFolderUploadOptions();
            // Act
            BlobTransferManager manager = new BlobTransferManager();
            manager.ScheduleFolderUpload(folder, client, options: options);
            manager.ScheduleFolderUpload(folder, clientTwo, options: options);
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(blobs, dirName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + openChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + lockedChild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + openSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
                CollectionAssert.Contains(blobs, dirTwoName + "/" + lockedSubchild.Substring(folder.Length + 1).Replace('\\', '/'));
            });
            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            await SetUpDirectoryForListing(directoryClient);

            // Act
            var blobs = new List<BlobItem>();
            await foreach (Page<BlobItem> page in directoryClient.GetBlobsAsync().AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            Assert.AreEqual(BlobNames.Length, blobs.Count);

            var foundBlobNames = blobs.Select(blob => blob.Name).ToArray();

            Assert.IsTrue(BlobNames.All(blobName => foundBlobNames.Contains(directoryClient.DirectoryPrefix + "/" + blobName)));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsFlatSegmentAsync_Tags()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            IDictionary<string, string> tags = BuildTags();
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = tags
            };
            await appendBlob.CreateAsync(options);

            // Act
            IList<BlobItem> blobItems = await directoryClient.GetBlobsAsync(BlobTraits.Tags).ToListAsync();

            // Assert
            AssertDictionaryEquality(tags, blobItems[0].Tags);
            Assert.AreEqual(tags.Count, blobItems[0].Properties.TagCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(null)]
        [TestCase(RehydratePriority.Standard)]
        [TestCase(RehydratePriority.High)]
        public async Task ListBlobsFlatSegmentAsync_RehydratePriority(RehydratePriority? rehydratePriority)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            BlockBlobClient blockBlob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await blockBlob.UploadAsync(stream);

            if (rehydratePriority.HasValue)
            {
                await blockBlob.SetAccessTierAsync(
                    AccessTier.Archive);

                await blockBlob.SetAccessTierAsync(
                    AccessTier.Hot,
                    rehydratePriority: rehydratePriority.Value);
            }

            // Act
            IList<BlobItem> blobItems = await directoryClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(rehydratePriority, blobItems[0].Properties.RehydratePriority);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task ListBlobsFlatSegmentAsync_MaxResults()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            await SetUpDirectoryForListing(directoryClient);

            // Act
            Page<BlobItem> page = await directoryClient.GetBlobsAsync().AsPages(pageSizeHint: 2).FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
            Assert.IsTrue(page.Values.All(b => b.Metadata.Count == 0));
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Metadata()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateIfNotExistsAsync(metadata: metadata);

            // Act
            IList<BlobItem> blobs = await directoryClient.GetBlobsAsync(traits: BlobTraits.Metadata).ToListAsync();

            // Assert
            AssertDictionaryEquality(metadata, blobs.First().Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ListBlobsFlatSegmentAsync_EncryptionScope()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            await blob.CreateIfNotExistsAsync();

            // Act
            IList<BlobItem> blobs = await directoryClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, blobs.First().Properties.EncryptionScope);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Deleted()
        {
            // Arrange
            BlobServiceClient blobServiceClient = BlobsClientBuilder.GetServiceClient_SoftDelete();
            await using DisposingBlobContainer test = await GetTestContainerAsync(blobServiceClient);
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
            await blob.DeleteIfExistsAsync();

            // Act
            IList<BlobItem> blobs = await directoryClient.GetBlobsAsync(states: BlobStates.Deleted).ToListAsync();

            // Assert
            Assert.AreEqual(blobName, blobs[0].Name);
            Assert.IsTrue(blobs[0].Deleted);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Uncommited()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
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
            IList<BlobItem> blobs = await directoryClient.GetBlobsAsync(states: BlobStates.Uncommitted).ToListAsync();

            // Assert
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Snapshot()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            // Act
            IList<BlobItem> blobs = await directoryClient.GetBlobsAsync(states: BlobStates.Snapshots).ToListAsync();

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Snapshot);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Prefix()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            await SetUpDirectoryForListing(directoryClient);

            // Act
            IList<BlobItem> blobs = await directoryClient.GetBlobsAsync(additionalPrefix: "foo").ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobFolderClient directoryClient = container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directoryClient.GetBlobsAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_PreservesWhitespace()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());
            await VerifyBlobNameWhitespaceRoundtrips($"{directoryClient.DirectoryPrefix}/    prefix");
            await VerifyBlobNameWhitespaceRoundtrips($"{directoryClient.DirectoryPrefix}/suffix    ");
            await VerifyBlobNameWhitespaceRoundtrips($"{directoryClient.DirectoryPrefix}/    ");

            async Task VerifyBlobNameWhitespaceRoundtrips(string blobName)
            {
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
                await blob.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes("data")));
                BlobItem blobItem = await directoryClient.GetBlobsAsync().FirstAsync();
                Assert.AreEqual(blobName, blobItem.Name);
                await blob.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsFlatSegmentAsync_VersionId()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);

            // Act
            var blobs = new List<BlobItem>();
            await foreach (Page<BlobItem> page in directoryClient.GetBlobsAsync(states: BlobStates.Version).AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.IsNull(blobs[0].IsLatestVersion);
            Assert.AreEqual(createResponse.Value.VersionId, blobs[0].VersionId);
            Assert.IsTrue(blobs[1].IsLatestVersion);
            Assert.AreEqual(setMetadataResponse.Value.VersionId, blobs[1].VersionId);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task ListBlobsFlatSegmentAsync_LastAccessed()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            await SetUpDirectoryForListing(directoryClient);

            // Act
            var blobs = new List<BlobItem>();
            await foreach (Page<BlobItem> page in directoryClient.GetBlobsAsync().AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            Assert.AreNotEqual(DateTimeOffset.MinValue, blobs.FirstOrDefault().Properties.LastAccessedOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task ListBlobsFlatSegmentAsync_DeletedWithVersions()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);
            await blob.DeleteAsync();

            // Act
            List<BlobItem> blobItems = new List<BlobItem>();
            await foreach (BlobItem blobItem in directoryClient.GetBlobsAsync(states: BlobStates.DeletedWithVersions))
            {
                blobItems.Add(blobItem);
            }

            // Assert
            Assert.AreEqual(1, blobItems.Count);
            Assert.AreEqual(blob.Name, blobItems[0].Name);
            Assert.IsTrue(blobItems[0].HasVersionsOnly);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsHierarchySegmentAsync_Tags()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            IDictionary<string, string> tags = BuildTags();
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = tags
            };
            await appendBlob.CreateAsync(options);

            // Act
            IList<BlobHierarchyItem> blobHierachyItems = await directoryClient.GetBlobsByHierarchyAsync(BlobTraits.Tags).ToListAsync();

            // Assert
            AssertDictionaryEquality(tags, blobHierachyItems[0].Blob.Tags);
            Assert.AreEqual(tags.Count, blobHierachyItems[0].Blob.Properties.TagCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(null)]
        [TestCase(RehydratePriority.Standard)]
        [TestCase(RehydratePriority.High)]
        public async Task ListBlobsHierarchySegmentAsync_RehydratePriority(RehydratePriority? rehydratePriority)
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            BlockBlobClient blockBlob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await blockBlob.UploadAsync(stream);

            if (rehydratePriority.HasValue)
            {
                await blockBlob.SetAccessTierAsync(
                    AccessTier.Archive);

                await blockBlob.SetAccessTierAsync(
                    AccessTier.Hot,
                    rehydratePriority: rehydratePriority.Value);
            }

            // Act
            IList<BlobHierarchyItem> blobItems = await directoryClient.GetBlobsByHierarchyAsync().ToListAsync();

            // Assert
            Assert.AreEqual(rehydratePriority, blobItems[0].Blob.Properties.RehydratePriority);
        }

        [RecordedTest]
        [PlaybackOnly("Service bug - https://github.com/Azure/azure-sdk-for-net/issues/16516")]
        [AsyncOnly]
        public async Task ListBlobsHierarchySegmentAsync_MaxResults()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            await SetUpDirectoryForListing(directoryClient);
            var delimiter = "/";

            // Act
            Page<BlobHierarchyItem> page = await directoryClient.GetBlobsByHierarchyAsync(delimiter: delimiter)
                .AsPages(pageSizeHint: 2)
                .FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Metadata()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateIfNotExistsAsync(metadata: metadata);

            // Act
            BlobHierarchyItem item = await directoryClient.GetBlobsByHierarchyAsync(traits: BlobTraits.Metadata).FirstAsync();

            // Assert
            AssertDictionaryEquality(metadata, item.Blob.Metadata);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Metadata_NoMetadata()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            // Act
            BlobHierarchyItem item = await directoryClient.GetBlobsByHierarchyAsync(traits: BlobTraits.Metadata).FirstAsync();

            // Assert
            Assert.IsNotNull(item.Blob.Metadata);
            Assert.AreEqual(0, item.Blob.Metadata.Count);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ListBlobsHierarchySegmentAsync_EncryptionScope()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateIfNotExistsAsync();

            // Act
            BlobHierarchyItem item = await directoryClient.GetBlobsByHierarchyAsync().FirstAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, item.Blob.Properties.EncryptionScope);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Deleted()
        {
            // Arrange
            BlobServiceClient blobServiceClient = BlobsClientBuilder.GetServiceClient_SoftDelete();
            await using DisposingBlobContainer test = await GetTestContainerAsync(blobServiceClient);
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            await blob.DeleteAsync();

            // Act
            IList<BlobHierarchyItem> blobs = await directoryClient.GetBlobsByHierarchyAsync(states: BlobStates.Deleted).ToListAsync();

            // Assert
            Assert.AreEqual(blobName, blobs[0].Blob.Name);
            Assert.IsTrue(blobs[0].Blob.Deleted);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Uncommited()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
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
            IList<BlobHierarchyItem> blobs = await directoryClient.GetBlobsByHierarchyAsync(states: BlobStates.Uncommitted).ToListAsync();

            // Assert
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Blob.Name);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Snapshot()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            // Act
            IList<BlobHierarchyItem> blobs = await directoryClient.GetBlobsByHierarchyAsync(states: BlobStates.Snapshots).ToListAsync();

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.AreEqual(snapshotResponse.Value.Snapshot.ToString(), blobs.First().Blob.Snapshot);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsHierarchySegmentAsync_VersionId()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);

            // Act
            var blobs = new List<BlobHierarchyItem>();
            await foreach (Page<BlobHierarchyItem> page in directoryClient.GetBlobsByHierarchyAsync(states: BlobStates.Version).AsPages())
            {
                blobs.AddRange(page.Values);
            }

            // Assert
            Assert.AreEqual(2, blobs.Count);
            Assert.IsNull(blobs[0].Blob.IsLatestVersion);
            Assert.AreEqual(createResponse.Value.VersionId, blobs[0].Blob.VersionId);
            Assert.IsTrue(blobs[1].Blob.IsLatestVersion);
            Assert.AreEqual(setMetadataResponse.Value.VersionId, blobs[1].Blob.VersionId);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Prefix()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            await SetUpDirectoryForListing(directoryClient);

            // Act
            IList<BlobHierarchyItem> blobs = await directoryClient.GetBlobsByHierarchyAsync(additionalPrefix: "foo").ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobFolderClient directoryClient = container.GetBlobFolderClient(GetNewBlobDirectoryName());

            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.GetBlobsByHierarchyAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task ListBlobsHierarchySegmentAsync_LastAccessed()
        {
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPrefix + "/" + GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(content: stream);

            // Act
            BlobHierarchyItem item = await directoryClient.GetBlobsByHierarchyAsync().FirstAsync();

            // Assert
            Assert.IsNotNull(item.Blob.Properties.LastAccessedOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task ListBlobsHierarchySegmentAsync_DeletedWithVersions()
        {
            // Arrange
            await using DisposingBlobContainer test = await GetTestContainerAsync();
            BlobFolderClient directoryClient = test.Container.GetBlobFolderClient(GetNewBlobDirectoryName());

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(directoryClient.DirectoryPrefix + "/" + GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);
            await blob.DeleteAsync();

            // Act
            List<BlobHierarchyItem> blobHierarchyItems = new List<BlobHierarchyItem>();
            await foreach (BlobHierarchyItem blobItem in directoryClient.GetBlobsByHierarchyAsync(states: BlobStates.DeletedWithVersions))
            {
                blobHierarchyItems.Add(blobItem);
            }

            // Assert
            Assert.AreEqual(1, blobHierarchyItems.Count);
            Assert.AreEqual(blob.Name, blobHierarchyItems[0].Blob.Name);
            Assert.IsTrue(blobHierarchyItems[0].Blob.HasVersionsOnly);
        }
        */
    }
}
