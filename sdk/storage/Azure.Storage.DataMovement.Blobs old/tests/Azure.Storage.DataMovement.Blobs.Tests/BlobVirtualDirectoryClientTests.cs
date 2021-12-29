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

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobVirtualDirectoryClientTests : DataMovementBlobTestBase
    {
        public BlobVirtualDirectoryClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

        private async Task SetUpDirectoryForListing(BlobVirtualDirectoryClient directory)
        {
            var blobNames = BlobNames;

            var data = GetRandomBuffer(Constants.KB);

            var blobs = new BlockBlobClient[blobNames.Length];

            // Upload Blobs
            for (var i = 0; i < blobNames.Length; i++)
            {
                BlockBlobClient blob = InstrumentClient(directory.GetBlockBlobClient(blobNames[i]));
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
            var directoryName = GetNewBlobDirectoryName();

            BlobVirtualDirectoryClient directory1 = InstrumentClient(new BlobVirtualDirectoryClient(connectionString.ToString(true), containerName, directoryName, GetOptions()));
            BlobVirtualDirectoryClient directory2 = InstrumentClient(new BlobVirtualDirectoryClient(connectionString.ToString(true), containerName, directoryName));

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
            await using DisposingContainer test = await GetTestContainerAsync();
            string directoryName = "!*'();[]:@&%=+$,/?#äÄöÖüÜß";
            string fullBlobPath = $"{directoryName}/{GetNewBlobName()}";

            BlockBlobClient initalBlob = InstrumentClient(test.Container.GetBlockBlobClient(fullBlobPath));
            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            Response<BlobContentInfo> uploadResponse = await initalBlob.UploadAsync(stream);

            // Act
            BlobVirtualDirectoryClient directoryClient = new BlobVirtualDirectoryClient(TestConfigDefault.ConnectionString, test.Container.Name, directoryName, GetOptions());
            IList<BlobItem> listResponse = await directoryClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(listResponse.First().Name, fullBlobPath);

            // Act
            BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.All, DateTimeOffset.UtcNow.AddDays(1));
            BlobVirtualDirectoryClient directorySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Container(
                    containerName: test.Container.Name)
                .GetBlobContainerClient(test.Container.Name)
                .GetBlobVirtualDirectoryClient(directoryName));

            listResponse = await directorySasBlob.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(listResponse.First().Name, fullBlobPath);
        }

        [RecordedTest]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            BlobVirtualDirectoryClient directory = InstrumentClient(new BlobVirtualDirectoryClient(blobEndpoint));
            var builder = new BlobUriBuilder(directory.Uri);

            Assert.AreEqual(accountName, builder.AccountName);
        }

        [RecordedTest]
        public void Ctor_UriNonIpStyle()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string directoryName = GetNewBlobDirectoryName();

            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{directoryName}");

            // Act
            BlobVirtualDirectoryClient directoryClient = new BlobVirtualDirectoryClient(uri);

            // Assert
            BlobUriBuilder builder = new BlobUriBuilder(directoryClient.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(directoryName, builder.BlobName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [RecordedTest]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobVirtualDirectoryClient(httpUri, GetOAuthCredential()),
                 new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [RecordedTest]
        public void Ctor_CPK_Http()
        {
            // Arrange
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlobClientOptions blobClientOptions = new BlobClientOptions()
            {
                CustomerProvidedKey = customerProvidedKey
            };
            Uri httpUri = new Uri(TestConfigDefault.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobVirtualDirectoryClient(httpUri, blobClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [RecordedTest]
        public void Ctor_CPK_EncryptionScope()
        {
            // Arrange
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlobClientOptions blobClientOptions = new BlobClientOptions
            {
                CustomerProvidedKey = customerProvidedKey,
                EncryptionScope = TestConfigDefault.EncryptionScope
            };

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobVirtualDirectoryClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            BlobClient blobClient = directoryClient.GetBlobClient(GetNewBlobName());
            await blobClient.UploadAsync(new MemoryStream());
            Uri directoryUri = directoryClient.Uri;

            // Act
            BlobVirtualDirectoryClient sasClient = InstrumentClient(new BlobVirtualDirectoryClient(directoryUri, new AzureSasCredential(sas), GetOptions()));
            IList<BlobItem> blobItems = await sasClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.IsNotEmpty(blobItems);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_UserDelegationSAS()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());
            var blobClient = directoryClient.GetBlobClient(GetNewBlobName());
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

            // Act
            var sasClient = InstrumentClient(new BlobVirtualDirectoryClient(blobUri, new AzureSasCredential(sas), GetOptions()));
            IList<BlobItem> blobItems = await sasClient.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.IsNotEmpty(blobItems);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            Uri blobUri = test.Container.GetBlobClient("foo").Uri;
            blobUri = new Uri(blobUri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new BlobVirtualDirectoryClient(blobUri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        // TODO: Resolve issues with threading causing failures in test playback
        //      (maybe should be resolved in base TransferSchduler, with tests for
        //      threading behavior in its own tests)

        [RecordedTest]
        public async Task UploadDirectoryAsync_RemoteUnspecified()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, false, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
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
        public async Task UploadDirectoryAsync_RemoteGiven()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, false, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
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
        public async Task DownloadDirectoryAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            string localDirName = folder.Split('\\').Last();

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, false, options);

            Directory.Delete(folder, true);

            await client.DownloadAsync(folder, options: new BlobDirectoryDownloadOptions()
            {
                DirectoryRequestConditions = new BlobDirectoryRequestConditions()
            });

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
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobDirectoryName();
            string folder = CreateRandomDirectory(Path.GetTempPath());
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.DownloadAsync(folder, options: new BlobDirectoryDownloadOptions()
            {
                DirectoryRequestConditions = new BlobDirectoryRequestConditions()
            });

            List<string> localItemsAfterDownload = Directory.GetFiles(folder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.IsEmpty(localItemsAfterDownload);

            // Cleanup
            Directory.Delete(folder, true);
        }

        [RecordedTest]
        public async Task UploadDirectoryAsync_Empty()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            string dirName = GetNewBlobName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);

            string folder = CreateRandomDirectory(Path.GetTempPath());

            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();

            // Act
            await client.UploadAsync(folder, false, options);

            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();

            // Assert
            Assert.IsEmpty(blobs);

            // Cleanup
            Directory.Delete(folder, true);
        }

        // This test is here just to see if DM stuff works, but shouldn't sit in here
        // (just needed to use DisposingContainer). Maybe a refactor for Disposing* stuff out to a
        // test common source might be useful for DMLib tests.

        // Test is disabled as it will not function properly until _toScanQueue > _jobsToProcess
        // transition is implemented.

        /*
        [RecordedTest]
        public async Task TransferManager_UploadTwoDirectories()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string dirName = GetNewBlobName();
            BlobVirtualDirectoryClient client = test.Container.GetBlobVirtualDirectoryClient(dirName);
            string dirTwoName = GetNewBlobName();
            BlobVirtualDirectoryClient clientTwo = test.Container.GetBlobVirtualDirectoryClient(dirTwoName);
            string folder = CreateRandomDirectory(Path.GetTempPath());
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);
            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);
            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);
            BlobDirectoryUploadOptions options = new BlobDirectoryUploadOptions();
            // Act
            StorageTransferManager manager = new StorageTransferManager();
            await manager.ScheduleUploadDirectoryAsync(folder, client, options);
            await manager.ScheduleUploadDirectoryAsync(folder, clientTwo, options);
            await manager.StartTransfersAsync();
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
        */

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

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

            Assert.IsTrue(BlobNames.All(blobName => foundBlobNames.Contains(directoryClient.DirectoryPath + "/" + blobName)));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListBlobsFlatSegmentAsync_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            BlobServiceClient blobServiceClient = GetServiceClient_SoftDelete();
            await using DisposingContainer test = await GetTestContainerAsync(blobServiceClient);
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            await SetUpDirectoryForListing(directoryClient);

            // Act
            IList<BlobItem> blobs = await directoryClient.GetBlobsAsync(prefix: "foo").ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobVirtualDirectoryClient directoryClient = container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directoryClient.GetBlobsAsync().ToListAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ListBlobsFlatSegmentAsync_PreservesWhitespace()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());
            await VerifyBlobNameWhitespaceRoundtrips($"{directoryClient.DirectoryPath}/    prefix");
            await VerifyBlobNameWhitespaceRoundtrips($"{directoryClient.DirectoryPath}/suffix    ");
            await VerifyBlobNameWhitespaceRoundtrips($"{directoryClient.DirectoryPath}/    ");

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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            BlobServiceClient blobServiceClient = GetServiceClient_SoftDelete();
            await using DisposingContainer test = await GetTestContainerAsync(blobServiceClient);
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            await SetUpDirectoryForListing(directoryClient);

            // Act
            IList<BlobHierarchyItem> blobs = await directoryClient.GetBlobsByHierarchyAsync(prefix: "foo").ToListAsync();

            // Assert
            Assert.AreEqual(3, blobs.Count);
        }

        [RecordedTest]
        public async Task ListBlobsHierarchySegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlobVirtualDirectoryClient directoryClient = container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            // Arrange
            var blobName = directoryClient.DirectoryPath + "/" + GetNewBlobName();
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
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobVirtualDirectoryClient directoryClient = test.Container.GetBlobVirtualDirectoryClient(GetNewBlobDirectoryName());

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(directoryClient.DirectoryPath + "/" + GetNewBlobName()));
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
    }
}
