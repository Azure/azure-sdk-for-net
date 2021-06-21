﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Shared;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Moq;
using NUnit.Framework;
using static Azure.Storage.Blobs.BlobClientOptions;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Test
{
    public class BlockBlobClientTests : BlobTestBase
    {
        private const long Size = 4 * Constants.KB;

        private readonly Func<RequestFailedException, bool> _retryStageBlockFromUri =
            ex => ex.Status == 500 && ex.ErrorCode == BlobErrorCode.CannotVerifyCopySource.ToString();

        public BlockBlobClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
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
            var blobName = GetNewBlobName();

            BlockBlobClient blob = InstrumentClient(new BlockBlobClient(connectionString.ToString(true), containerName, blobName, GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [RecordedTest]
        public void Ctor_Uri()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();

            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName}");

            // Act
            BlockBlobClient blockBlobClient = new BlockBlobClient(uri);

            // Assert
            BlobUriBuilder builder = new BlobUriBuilder(blockBlobClient.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [RecordedTest]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlockBlobClient(httpUri, GetOAuthCredential()),
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
                () => new BlockBlobClient(httpUri, blobClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [RecordedTest]
        [Ignore("#10044: Re-enable failing Storage tests")]
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
                () => new BlockBlobClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            var client = test.Container.GetBlobClient(GetNewBlobName());
            await client.UploadAsync(new MemoryStream());
            Uri blobUri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new BlockBlobClient(blobUri, new AzureSasCredential(sas), GetOptions()));
            BlobProperties blobProperties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(blobProperties);
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
                () => new BlockBlobClient(blobUri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public void WithSnapshot()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = "my/blob/name";
            string snapshot = "2020-07-03T12:45:46.1234567Z";
            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName.EscapePath()}");
            Uri snapshotUri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName.EscapePath()}?snapshot={snapshot}");

            // Act
            BlockBlobClient blockBlobClient = new BlockBlobClient(uri);
            BlockBlobClient snapshotBlockBlobClient = blockBlobClient.WithSnapshot(snapshot);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(snapshotBlockBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, snapshotBlockBlobClient.AccountName);
            Assert.AreEqual(containerName, snapshotBlockBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, snapshotBlockBlobClient.Name);
            Assert.AreEqual(snapshotUri, snapshotBlockBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(snapshot, blobUriBuilder.Snapshot);
            Assert.AreEqual(snapshotUri, blobUriBuilder.ToUri());
        }

        [RecordedTest]
        public void WithVersion()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = "my/blob/name";
            string versionId = "2020-07-03T12:45:46.1234567Z";
            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName.EscapePath()}");
            Uri versionUri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName.EscapePath()}?versionid={versionId}");

            // Act
            BlockBlobClient blockBlobClient = new BlockBlobClient(uri);
            BlockBlobClient versionBlockBlobClient = blockBlobClient.WithVersion(versionId);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(versionBlockBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, versionBlockBlobClient.AccountName);
            Assert.AreEqual(containerName, versionBlockBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, versionBlockBlobClient.Name);
            Assert.AreEqual(versionUri, versionBlockBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(versionId, blobUriBuilder.VersionId);
            Assert.AreEqual(versionUri, blobUriBuilder.ToUri());
        }

        [RecordedTest]
        public async Task StageBlockAsync_Min()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);

            // Create BlockBlob
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            using (var stream = new MemoryStream(data))
            {
                // Act
                Response<BlockInfo> response = await blob.StageBlockAsync(
                    base64BlockId: ToBase64(GetNewBlockName()),
                    content: stream);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task StageBlockAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            var data = GetRandomBuffer(Size);

            // Create BlockBlob
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            using (var stream = new MemoryStream(data))
            {
                // Act
                Response<BlockInfo> response = await blob.StageBlockAsync(
                    base64BlockId: ToBase64(GetNewBlockName()),
                    content: stream);

                // Assert
                Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StageBlockAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            var data = GetRandomBuffer(Size);

            // Create BlockBlob
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            using (var stream = new MemoryStream(data))
            {
                // Act
                Response<BlockInfo> response = await blob.StageBlockAsync(
                    base64BlockId: ToBase64(GetNewBlockName()),
                    content: stream);

                // Assert
                Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
            }
        }

        [RecordedTest]
        public async Task StageBlockAsync_Lease()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);

            // Create BlockBlob
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            var leaseId = await SetupBlobLeaseCondition(blob, ReceivedLeaseId, garbageLeaseId);

            using (var stream = new MemoryStream(data))
            {
                // Act
                Response<BlockInfo> response = await blob.StageBlockAsync(
                    base64BlockId: ToBase64(GetNewBlockName()),
                    content: stream,
                    conditions: new BlobRequestConditions
                    {
                        LeaseId = leaseId
                    });

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task StageBlockAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);

            // Create BlockBlob
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            using (var stream = new MemoryStream(data))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.StageBlockAsync(
                        base64BlockId: ToBase64(GetNewBlockName()),
                        content: stream,
                        conditions: new BlobRequestConditions
                        {
                            LeaseId = garbageLeaseId
                        }),
                    e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
            }
        }

        [RecordedTest]
        public async Task StageBlockAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;
            await using DisposingContainer test = await GetTestContainerAsync();

            var credentials = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlobContainerClient containerFaulty = InstrumentClient(
                new BlobContainerClient(
                    test.Container.Uri,
                    credentials,
                    GetFaultyBlobConnectionOptions()));

            // Arrange
            var blockBlobName = GetNewBlobName();
            var blockName = GetNewBlockName();
            BlockBlobClient blobFaulty = InstrumentClient(containerFaulty.GetBlockBlobClient(blockBlobName));
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            var data = GetRandomBuffer(blobSize);

            var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
            var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
            var timesFaulted = 0;
            // Act
            using (var stream = new FaultyStream(
                new MemoryStream(data),
                256 * Constants.KB,
                1,
                new IOException("Simulated stream fault"),
                () => timesFaulted++))
            {
                await blobFaulty.StageBlockAsync(ToBase64(blockName), stream, null, null, progressHandler: progressHandler);

                await WaitForProgressAsync(progressBag, data.LongLength);
                Assert.IsTrue(progressBag.Count > 1, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                Assert.GreaterOrEqual(data.LongLength, progressBag.Max(), "Final progress has unexpected value");
            }

            // Assert
            Response<BlockList> blobList = await blob.GetBlockListAsync(BlockListTypes.All);
            Assert.AreEqual(0, blobList.Value.CommittedBlocks.Count());
            Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
            Assert.AreEqual(ToBase64(blockName), blobList.Value.UncommittedBlocks.First().Name);
            Assert.AreNotEqual(0, timesFaulted);
        }

        [RecordedTest]
        public async Task StageBlockAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            var data = GetRandomBuffer(Size);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.StageBlockAsync(GetNewBlockName(), stream),
                    e =>
                    {
                        Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode);
                        Assert.AreEqual("Value for one of the query parameters specified in the request URI is invalid.", e.Message.Split('\n')[0]);
                    });
            }
        }

        [LiveOnly]
        [Test]
        public async Task StageBlockAsync_ProgressReporting()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            // Create BlockBlob
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            data = GetRandomBuffer(100 * Constants.MB);
            TestProgress progress = new TestProgress();
            using (var stream = new MemoryStream(data))
            {
                // Act
                Response<BlockInfo> response = await blob.StageBlockAsync(
                    base64BlockId: ToBase64(GetNewBlockName()),
                    content: stream,
                    progressHandler: progress);
            }

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(100 * Constants.MB, progress.List[progress.List.Count - 1]);
        }

        [RecordedTest]
        public async Task StageBlockAsync_InvalidStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            byte[] data = GetRandomBuffer(Size);

            using Stream stream = new MemoryStream(data)
            {
                Position = Size
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.StageBlockAsync(
                base64BlockId: ToBase64(GetNewBlockName()),
                content: stream),
                e => Assert.AreEqual("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.", e.Message));
        }

        [RecordedTest]
        public async Task StageBlockAsync_NonZeroStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = Constants.KB;
            long position = 512;
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            string blockId = ToBase64(GetNewBlockName());

            // Act
            await blob.StageBlockAsync(
                blockId,
                content: stream);

            await blob.CommitBlockListAsync(new List<string>()
            {
                blockId
            });

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_Min()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
            }

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, ToBase64(GetNewBlockName())),
                _retryStageBlockFromUri);
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
            }

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            destBlob = InstrumentClient(destBlob.WithCustomerProvidedKey(customerProvidedKey));

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, ToBase64(GetNewBlockName())),
                _retryStageBlockFromUri);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StageBlockFromUriAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
            }

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            destBlob = InstrumentClient(destBlob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            // Act
            Response<BlockInfo> response = await destBlob.StageBlockFromUriAsync(
                sourceBlob.Uri,
                ToBase64(GetNewBlockName()));

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_Range()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
            }

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            StageBlockFromUriOptions options = new StageBlockFromUriOptions
            {
                SourceRange = new HttpRange(256, 256)
            };

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: ToBase64(GetNewBlockName()),
                    options: options),
                _retryStageBlockFromUri);
            Response<BlockList> getBlockListResult = await destBlob.GetBlockListAsync(BlockListTypes.All);

            // Assert
            Assert.AreEqual(256, getBlockListResult.Value.UncommittedBlocks.First().Size);
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
            }

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            StageBlockFromUriOptions options = new StageBlockFromUriOptions
            {
                SourceContentHash = MD5.Create().ComputeHash(data)
            };

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: ToBase64(GetNewBlockName()),
                    options: options),
                _retryStageBlockFromUri);
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_MD5_Fail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
            }

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            StageBlockFromUriOptions options = new StageBlockFromUriOptions
            {
                SourceContentHash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garbage"))
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                RetryAsync(
                    async () => await destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        options: options),
                    _retryStageBlockFromUri),
                actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
            );
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_Lease()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
                stream.Seek(0, SeekOrigin.Begin);
                await destBlob.UploadAsync(stream);
            }

            BlobRequestConditions leaseAccessConditions = new BlobRequestConditions
            {
                LeaseId = await SetupBlobLeaseCondition(destBlob, ReceivedLeaseId, garbageLeaseId)
            };

            StageBlockFromUriOptions options = new StageBlockFromUriOptions
            {
                DestinationConditions = leaseAccessConditions
            };

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: ToBase64(GetNewBlockName()),
                    options: options),
                _retryStageBlockFromUri);
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_Lease_Fail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
                stream.Seek(0, SeekOrigin.Begin);
                await destBlob.UploadAsync(stream);
            }

            BlobRequestConditions leaseAccessConditions = new BlobRequestConditions
            {
                LeaseId = garbageLeaseId
            };

            StageBlockFromUriOptions options = new StageBlockFromUriOptions
            {
                DestinationConditions = leaseAccessConditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                RetryAsync(
                    async () => await destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        options: options),
                    _retryStageBlockFromUri),
                actualException => Assert.AreEqual("LeaseNotPresentWithBlobOperation", actualException.ErrorCode)
            );
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_SourceAccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                parameters.SourceIfMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                RequestConditions sourceAccessConditions = BuildRequestConditions(parameters);

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                StageBlockFromUriOptions options = new StageBlockFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                // Act
                await RetryAsync(
                    async () => await destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        options: options),
                    _retryStageBlockFromUri);
            }
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_SourceAccessConditions_Fail()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);
                RequestConditions sourceAccessConditions = BuildRequestConditions(parameters);

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                StageBlockFromUriOptions options = new StageBlockFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    RetryAsync(
                        async () => await destBlob.StageBlockFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            base64BlockId: ToBase64(GetNewBlockName()),
                            options: options),
                        _retryStageBlockFromUri),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task StageBlockFromUriAsync_NonAsciiSourceUri()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewNonAsciiBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await sourceBlob.UploadAsync(stream);
            }

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, ToBase64(GetNewBlockName())),
                _retryStageBlockFromUri);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task StageBlockFromUriAsync_SourceBearerToken()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            const int blobSize = Constants.KB;
            byte[] data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            string sourceBearerToken = await GetAuthToken();

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                sourceBearerToken);

            StageBlockFromUriOptions options = new StageBlockFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: ToBase64(GetNewBlockName()),
                    options: options),
                _retryStageBlockFromUri);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task StageBlockFromUriAsync_SourceBearerTokenFail()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            const int blobSize = Constants.KB;
            byte[] data = GetRandomBuffer(blobSize);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                "auth token");

            StageBlockFromUriOptions options = new StageBlockFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: ToBase64(GetNewBlockName()),
                    options: options),
                e => Assert.AreEqual(BlobErrorCode.CannotVerifyCopySource.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public async Task CommitBlockListAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var firstBlockName = GetNewBlockName();
            var secondBlockName = GetNewBlockName();
            var thirdBlockName = GetNewBlockName();

            // Act
            // Stage blocks
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(firstBlockName), stream);
            }
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(secondBlockName), stream);
            }

            // Commit first two Blocks
            var commitList = new string[]
            {
                    ToBase64(firstBlockName),
                    ToBase64(secondBlockName)
            };

            await blob.CommitBlockListAsync(commitList);

            // Stage 3rd Block
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(thirdBlockName), stream);
            }

            // Assert
            Response<BlockList> blobList = await blob.GetBlockListAsync(BlockListTypes.All);
            Assert.AreEqual(2, blobList.Value.CommittedBlocks.Count());
            Assert.AreEqual(ToBase64(firstBlockName), blobList.Value.CommittedBlocks.First().Name);
            Assert.AreEqual(ToBase64(secondBlockName), blobList.Value.CommittedBlocks.ElementAt(1).Name);
            Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
            Assert.AreEqual(ToBase64(thirdBlockName), blobList.Value.UncommittedBlocks.First().Name);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CommitBlockListAsync_Tags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var blockName = GetNewBlockName();

            // Stage block
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(blockName), stream);
            }

            // Commit block
            var commitList = new string[]
            {
                ToBase64(blockName)
            };

            IDictionary<string, string> tags = BuildTags();

            CommitBlockListOptions options = new CommitBlockListOptions
            {
                Tags = tags
            };

            // Act
            await blob.CommitBlockListAsync(commitList, options);
            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, response.Value.Tags);
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_Committed_and_Uncommited_Blocks()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var firstBlockName = GetNewBlockName();
            var secondBlockName = GetNewBlockName();
            var thirdBlockName = GetNewBlockName();

            // Stage blocks
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(firstBlockName), stream);
            }
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(secondBlockName), stream);
            }

            // Commit first two Blocks
            var commitList = new string[]
            {
                    ToBase64(firstBlockName),
                    ToBase64(secondBlockName)
            };

            await blob.CommitBlockListAsync(commitList);

            // Stage 3rd Block
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(thirdBlockName), stream);
            }

            // Act
            commitList = new string[]
            {
                    ToBase64(firstBlockName),
                    ToBase64(secondBlockName),
                    ToBase64(thirdBlockName)
            };
            await blob.CommitBlockListAsync(commitList);

            // Assert
            Response<BlockList> blobList = await blob.GetBlockListAsync(BlockListTypes.All);
            Assert.AreEqual(3, blobList.Value.CommittedBlocks.Count());
            Assert.AreEqual(ToBase64(firstBlockName), blobList.Value.CommittedBlocks.First().Name);
            Assert.AreEqual(ToBase64(secondBlockName), blobList.Value.CommittedBlocks.ElementAt(1).Name);
            Assert.AreEqual(ToBase64(thirdBlockName), blobList.Value.CommittedBlocks.ElementAt(2).Name);
            Assert.AreEqual(0, blobList.Value.UncommittedBlocks.Count());
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));

            var data = GetRandomBuffer(Size);
            var firstBlockName = GetNewBlockName();
            var secondBlockName = GetNewBlockName();

            // Act
            // Stage blocks
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(firstBlockName), stream);
            }
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(secondBlockName), stream);
            }

            var commitList = new string[]
            {
                ToBase64(firstBlockName),
                ToBase64(secondBlockName)
            };

            // Act
            Response<BlobContentInfo> response = await blob.CommitBlockListAsync(commitList);

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CommitBlockListAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            var data = GetRandomBuffer(Size);
            var firstBlockName = GetNewBlockName();
            var secondBlockName = GetNewBlockName();

            // Act
            // Stage blocks
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(firstBlockName), stream);
            }
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(secondBlockName), stream);
            }

            var commitList = new string[]
            {
                ToBase64(firstBlockName),
                ToBase64(secondBlockName)
            };

            // Act
            Response<BlobContentInfo> response = await blob.CommitBlockListAsync(commitList);

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_Headers()
        {
            var constants = TestConstants.Create(this);
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var blockName = GetNewBlockName();

            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(blockName), stream);
            }

            // Act
            await blob.CommitBlockListAsync(
                base64BlockIds: new string[] { ToBase64(blockName) },
                httpHeaders: new BlobHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = constants.ContentEncoding,
                    ContentLanguage = constants.ContentLanguage,
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                });

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5, response.Value.ContentHash);
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var blockName = GetNewBlockName();
            Metadata metadata = BuildMetadata();

            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(blockName), stream);
            }

            // Act
            await blob.CommitBlockListAsync(
                base64BlockIds: new string[] { ToBase64(blockName) },
                metadata: metadata);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_Lease()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var blockName = GetNewBlockName();
            Metadata metadata = BuildMetadata();

            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(blockName), stream);
            }

            var leaseId = await SetupBlobLeaseCondition(blob, ReceivedLeaseId, garbageLeaseId);

            // Act
            Response<BlobContentInfo> response = await blob.CommitBlockListAsync(
                base64BlockIds: new string[] { ToBase64(blockName) },
                conditions: new BlobRequestConditions { LeaseId = leaseId });

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var blockName = GetNewBlockName();
            Metadata metadata = BuildMetadata();

            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(blockName), stream);
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CommitBlockListAsync(
                    base64BlockIds: new string[] { ToBase64(GetNewBlockName()) },
                    conditions: new BlobRequestConditions { LeaseId = garbageLeaseId }),
                e =>
                {
                    Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode);
                    Assert.AreEqual("There is currently no lease on the blob.", e.Message.Split('\n')[0]);
                }
            );
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);
                var blockName = GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Upload to blockBlobUri, exists when we get the ETag
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(ToBase64(blockName), stream);
                }

                parameters.SourceIfMatch = await SetupBlobMatchCondition(blob, parameters.SourceIfMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                // Act
                Response<BlobContentInfo> response = await blob.CommitBlockListAsync(
                    base64BlockIds: new string[] { ToBase64(blockName) },
                    conditions: accessConditions.ToBlobRequestConditions());

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_AccessConditionsFail()
        {
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters { SourceIfModifiedSince = NewDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = OldDate },
                new AccessConditionParameters { SourceIfMatch = GarbageETag },
                new AccessConditionParameters { SourceIfNoneMatch = ReceivedETag }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);
                var blockName = GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Upload to blockBlobUri, exists when we get the ETag
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(ToBase64(blockName), stream);
                }

                parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(blob, parameters.SourceIfNoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.CommitBlockListAsync(
                        base64BlockIds: new string[] { ToBase64(blockName) },
                        conditions: accessConditions.ToBlobRequestConditions()),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CommitBlockListAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var blockName = GetNewBlockName();
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            stream.Position = 0;
            await blob.StageBlockAsync(ToBase64(blockName), stream);

            string[] commitList = new string[]
            {
                ToBase64(blockName),
            };

            BlobRequestConditions condition = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.CommitBlockListAsync(
                commitList,
                conditions: condition);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CommitBlockListAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var blockName = GetNewBlockName();
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            stream.Position = 0;
            await blob.StageBlockAsync(ToBase64(blockName), stream);

            string[] commitList = new string[]
            {
                ToBase64(blockName),
            };

            BlobRequestConditions condition = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CommitBlockListAsync(
                    commitList,
                    conditions: condition),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            var data = GetRandomBuffer(Size);
            var commitList = new string[]
            {
                    ToBase64(GetNewBlockName())
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CommitBlockListAsync(commitList),
                e =>
                {
                    Assert.AreEqual("InvalidBlockList", e.ErrorCode);
                    Assert.AreEqual("The specified block list is invalid.", e.Message.Split('\n')[0]);
                });
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_AccessTier()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var firstBlockName = GetNewBlockName();
            var secondBlockName = GetNewBlockName();
            var thirdBlockName = GetNewBlockName();

            // Act
            // Stage blocks
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(firstBlockName), stream);
            }
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(secondBlockName), stream);
            }

            // Commit first two Blocks
            var commitList = new string[]
            {
                    ToBase64(firstBlockName),
                    ToBase64(secondBlockName)
            };

            await blob.CommitBlockListAsync(commitList, accessTier: AccessTier.Cool);

            // Stage 3rd Block
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(thirdBlockName), stream);
            }

            // Assert
            Response<BlockList> blobList = await blob.GetBlockListAsync(BlockListTypes.All);
            Assert.AreEqual(2, blobList.Value.CommittedBlocks.Count());
            Assert.AreEqual(ToBase64(firstBlockName), blobList.Value.CommittedBlocks.First().Name);
            Assert.AreEqual(ToBase64(secondBlockName), blobList.Value.CommittedBlocks.ElementAt(1).Name);
            Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
            Assert.AreEqual(ToBase64(thirdBlockName), blobList.Value.UncommittedBlocks.First().Name);

            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.AreEqual(AccessTier.Cool.ToString(), response.Value.AccessTier);
        }

        [RecordedTest]
        public async Task CommitBlockListAsync_AccessTierFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var firstBlockName = GetNewBlockName();
            var secondBlockName = GetNewBlockName();

            // Act
            // Stage blocks
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(firstBlockName), stream);
            }
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(secondBlockName), stream);
            }

            // Commit first two Blocks
            var commitList = new string[]
            {
                    ToBase64(firstBlockName),
                    ToBase64(secondBlockName)
            };

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CommitBlockListAsync(commitList, accessTier: AccessTier.P10),
                e => Assert.AreEqual(BlobErrorCode.InvalidHeaderValue.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CommitBlockListAsync_VersionId()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var firstBlockName = GetNewBlockName();

            // Stage blocks
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(ToBase64(firstBlockName), stream);
            }

            var commitList = new string[]
            {
                ToBase64(firstBlockName),
            };

            // Act
            Response<BlobContentInfo> response = await blob.CommitBlockListAsync(commitList);

            // Assert
            Assert.IsNotNull(response.Value.VersionId);
        }

        [RecordedTest]
        public async Task GetBlockListAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);

            // Upload to blockBlobUri, so it exists
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            var blockId0 = ToBase64(GetNewBlockName());
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(blockId0, stream);
            }
            await blob.CommitBlockListAsync(new string[] { blockId0 });

            var blockId1 = ToBase64(GetNewBlobName());
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(blockId1, stream);
            }

            // Act
            Response<BlockList> response = await blob.GetBlockListAsync();

            // Assert
            Assert.AreEqual(1, response.Value.CommittedBlocks.Count());
            Assert.AreEqual(blockId0, response.Value.CommittedBlocks.First().Name);
            Assert.AreEqual(1, response.Value.UncommittedBlocks.Count());
            Assert.AreEqual(blockId1, response.Value.UncommittedBlocks.First().Name);
        }

        [RecordedTest]
        public async Task GetBlockListAsync_Type()
        {
            GetBlockListParameters[] testCases = new[]
            {
                new GetBlockListParameters { BlockListTypes = BlockListTypes.All, CommittedCount = 1, UncommittedCount = 1 },
                new GetBlockListParameters { BlockListTypes = default, CommittedCount = 1, UncommittedCount = 1 },
                new GetBlockListParameters { BlockListTypes = BlockListTypes.Committed | BlockListTypes.Uncommitted, CommittedCount = 1, UncommittedCount = 1 },
                new GetBlockListParameters { BlockListTypes = (BlockListTypes)7, CommittedCount = 1, UncommittedCount = 1 },
                new GetBlockListParameters { BlockListTypes = BlockListTypes.Committed, CommittedCount = 1, UncommittedCount = 0 },
                new GetBlockListParameters { BlockListTypes = BlockListTypes.Uncommitted, CommittedCount = 0, UncommittedCount = 1 }
            };
            foreach (GetBlockListParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);

                // Upload to blockBlobUri, so it exists
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var blockId0 = ToBase64(GetNewBlockName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(blockId0, stream);
                }
                await blob.CommitBlockListAsync(new string[] { blockId0 });

                var blockId1 = ToBase64(GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(blockId1, stream);
                }

                // Act
                Response<BlockList> response = await blob.GetBlockListAsync(parameters.BlockListTypes);

                // Assert
                // CommitedBlocks and UncommittedBlocks are null if empty
                Assert.AreEqual(parameters.CommittedCount, response.Value.CommittedBlocks?.Count() ?? 0);
                Assert.AreEqual(parameters.UncommittedCount, response.Value.UncommittedBlocks?.Count() ?? 0);
            }
        }

        [RecordedTest]
        public async Task GetBlockListAsync_Lease()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);

            // Upload to blockBlobUri, so it exists
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            var leaseId = await SetupBlobLeaseCondition(blob, ReceivedLeaseId, garbageLeaseId);

            // Act
            Response<BlockList> response = await blob.GetBlockListAsync(
                conditions: new BlobRequestConditions
                {
                    LeaseId = leaseId
                });
        }

        [RecordedTest]
        public async Task GetBlockListAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);

            // Upload to blockBlobUri, so it exists
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetBlockListAsync(
                    conditions: new BlobRequestConditions
                    {
                        LeaseId = garbageLeaseId
                    }),
                e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetBlockListAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);

            // Upload to blockBlobUri, so it exists
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            var blockId0 = ToBase64(GetNewBlockName());
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(blockId0, stream);
            }
            await blob.CommitBlockListAsync(new string[] { blockId0 });

            var blockId1 = ToBase64(GetNewBlobName());
            using (var stream = new MemoryStream(data))
            {
                await blob.StageBlockAsync(blockId1, stream);
            }

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.GetBlockListAsync(conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetBlockListAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);

            // Upload to blockBlobUri, so it exists
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetBlockListAsync(conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [RecordedTest]
        public async Task GetBlockListAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetBlockListAsync(BlockListTypes.All, "invalidSnapshot"),
                e =>
                {
                    Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode);
                    Assert.AreEqual("Value for one of the query parameters specified in the request URI is invalid.", e.Message.Split('\n')[0]);
                }
            );
        }

        [RecordedTest]
        public async Task UploadAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            var data = GetRandomBuffer(Size);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(
                    content: stream);
            }

            // Assert
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blockBlobName, blobs.First().Name);

            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadAsync_Tags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            var data = GetRandomBuffer(Size);
            IDictionary<string, string> tags = BuildTags();
            BlobUploadOptions options = new BlobUploadOptions
            {
                Tags = tags
            };

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(
                    content: stream,
                    options: options);
            }

            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, response.Value.Tags);
        }

        [LiveOnly]
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/9487")]
        public async Task UploadAsync_LargeFile()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            var data = GetRandomBuffer(Constants.GB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(
                    content: stream);
            }

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task UploadAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            Metadata metadata = BuildMetadata();

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(
                    content: stream,
                    metadata: metadata);
            }

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        public async Task UploadAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            var data = GetRandomBuffer(Size);

            // Act
            using var stream = new MemoryStream(data);
            Response<BlobContentInfo> response = await blob.UploadAsync(
                content: stream);

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            var data = GetRandomBuffer(Size);

            // Act
            using var stream = new MemoryStream(data);
            Response<BlobContentInfo> response = await blob.UploadAsync(
                content: stream);

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        public async Task UploadAsync_Headers()
        {
            var constants = TestConstants.Create(this);
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            var contentMD5 = MD5.Create().ComputeHash(data);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(
                    content: stream,
                    httpHeaders: new BlobHttpHeaders
                    {
                        CacheControl = constants.CacheControl,
                        ContentDisposition = constants.ContentDisposition,
                        ContentEncoding = constants.ContentEncoding,
                        ContentLanguage = constants.ContentLanguage,
                        ContentHash = contentMD5
                    });
            }

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage);
            TestHelper.AssertSequenceEqual(contentMD5, response.Value.ContentHash);
        }

        [RecordedTest]
        public async Task UploadAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);
                var blockName = GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.SourceIfMatch = await SetupBlobMatchCondition(blob, parameters.SourceIfMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    Response<BlobContentInfo> response = await blob.UploadAsync(
                        content: stream,
                        conditions: accessConditions.ToBlobRequestConditions());

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [RecordedTest]
        public async Task UploadAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);
                var blockName = GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(blob, parameters.SourceIfNoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        blob.UploadAsync(
                            content: stream,
                            conditions: accessConditions.ToBlobRequestConditions()),
                        e => { });
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(
                content: stream);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);
            stream.Position = 0;

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.UploadAsync(
                content: stream,
                conditions: conditions);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Size);
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(
                content: stream);

            stream.Position = 0;

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.UploadAsync(
                    content: stream,
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [RecordedTest]
        public async Task UploadAsync_Error()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.UploadAsync(
                        content: stream,
                        conditions: new BlobRequestConditions { LeaseId = garbageLeaseId }),
                    e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
            }
        }

        [RecordedTest]
        public async Task UploadAsync_NullStream_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            using (var stream = (MemoryStream)null)
            {
                // Check if the correct param name that is causing the error is being returned
                await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                    blob.UploadAsync(content: stream),
                    e => Assert.AreEqual("content", e.ParamName));
            }
        }

        [RecordedTest]
        public async Task UploadAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;
            Metadata metadata = BuildMetadata();
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var credentials = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlobContainerClient containerFaulty = InstrumentClient(
                new BlobContainerClient(
                    test.Container.Uri,
                    credentials,
                    GetFaultyBlobConnectionOptions()));

            var blockBlobName = GetNewBlobName();
            BlockBlobClient blobFaulty = InstrumentClient(containerFaulty.GetBlockBlobClient(blockBlobName));
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            var data = GetRandomBuffer(blobSize);

            var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
            var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
            var timesFaulted = 0;

            // Act
            using (var stream = new FaultyStream(
                new MemoryStream(data),
                256 * Constants.KB,
                1,
                new IOException("Simulated stream fault"),
                () => timesFaulted++))
            {
                await blobFaulty.UploadAsync(stream, null, metadata, null, progressHandler: progressHandler);

                await WaitForProgressAsync(progressBag, data.LongLength);
                Assert.IsTrue(progressBag.Count > 1, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                Assert.GreaterOrEqual(data.LongLength, progressBag.Max(), "Final progress has unexpected value");
            }

            // Assert
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blockBlobName, blobs.First().Name);

            Response<BlobProperties> getPropertiesResponse = await blob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, getPropertiesResponse.Value.Metadata);
            Assert.AreEqual(BlobType.Block, getPropertiesResponse.Value.BlobType);

            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreNotEqual(0, timesFaulted);
        }

        [LiveOnly]
        [Test]
        public async Task UploadAsync_ProgressReporting()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            long blobSize = 256 * Constants.MB;
            var data = GetRandomBuffer(blobSize);
            TestProgress progress = new TestProgress();

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(
                    content: stream,
                    progressHandler: progress);
            }

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(blobSize, progress.List[progress.List.Count - 1]);
        }

        [LiveOnly]
        [Test]
        public async Task UploadAsync_SingleUpload_DefaultThreshold()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            long blobSize = Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes - 1;
            var data = GetRandomBuffer(blobSize);
            using Stream stream = new MemoryStream(data);
            var dateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";
            var progressHandler = new Progress<long>(n =>
            {
                TestContext.Out.WriteLine($"{DateTime.Now.ToString(dateTimeFormat)} sent {n} bytes");
            });

            // Act
            await blob.UploadAsync(content: stream, progressHandler: progressHandler);

            // Assert
            Response<BlockList> blockListResponse = await blob.GetBlockListAsync();
            Assert.AreEqual(0, blockListResponse.Value.CommittedBlocks.ToList().Count);
        }

        [LiveOnly]
        [Test]
        public async Task UploadAsync_MultipleUpload_DefaultThreshold()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            long blobSize = Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes + 1;
            var data = GetRandomBuffer(blobSize);
            using Stream stream = new MemoryStream(data);

            // Act
            await blob.UploadAsync(content: stream);

            // Assert
            Response<BlockList> blockListResponse = await blob.GetBlockListAsync();
            Assert.AreEqual(33, blockListResponse.Value.CommittedBlocks.ToList().Count);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            var data = GetRandomBuffer(Size);

            // Act
            using (var stream = new MemoryStream(data))
            {
                Response<BlobContentInfo> response = await blob.UploadAsync(
                    content: stream);

                // Assert
                Assert.IsNotNull(response.Value.VersionId);
            }
        }

        [RecordedTest]
        public async Task UploadAsync_InvalidStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blockBlobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(blockBlobName));
            byte[] data = GetRandomBuffer(Size);

            using Stream stream = new MemoryStream(data)
            {
                Position = Size
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.UploadAsync(
                content: stream),
                e => Assert.AreEqual("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.", e.Message));
        }

        [RecordedTest]
        public async Task UploadAsync_NonZeroStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = Constants.KB;
            long position = 512;
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            // Act
            await blob.UploadAsync(content: stream);

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [RecordedTest]
        public async Task UploadAsync_NonZeroStreamPositionMultipleBlocks()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 2 * Constants.KB;
            long position = 300;
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            BlobUploadOptions options = new BlobUploadOptions
            {
                TransferOptions = new StorageTransferOptions
                {
                    MaximumTransferSize = 512,
                    InitialTransferSize = 512
                }
            };

            // Act
            await blob.UploadAsync(
                content: stream,
                options: options);

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [RecordedTest]
        public async Task GetBlockBlobClient_AsciiName()
        {
            //Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            //Act
            BlockBlobClient blob = test.Container.GetBlockBlobClient(blobName);
            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(content: stream);
            }

            //Assert
            List<string> names = new List<string>();
            await foreach (BlobItem pathItem in test.Container.GetBlobsAsync())
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(blobName, names);
        }

        [RecordedTest]
        public async Task GetBlockBlobClient_NonAsciiName()
        {
            //Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewNonAsciiBlobName();

            //Act
            BlockBlobClient blob = test.Container.GetBlockBlobClient(blobName);
            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(content: stream);
            }

            //Assert
            List<string> names = new List<string>();
            await foreach (BlobItem pathItem in test.Container.GetBlobsAsync())
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(blobName, names);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewBlob()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            Stream stream = await blob.OpenWriteAsync(
                overwrite: true,
                options);

            byte[] data = GetRandomBuffer(16 * Constants.KB);

            // Act
            await stream.WriteAsync(data, 0, 512);
            await stream.WriteAsync(data, 512, 1024);
            await stream.WriteAsync(data, 1536, 2048);
            await stream.WriteAsync(data, 3584, 77);
            await stream.WriteAsync(data, 3661, 2066);
            await stream.WriteAsync(data, 5727, 4096);
            await stream.WriteAsync(data, 9823, 6561);
            await stream.FlushAsync();

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, data.Length));
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_WithIntermediateFlushes()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            using (Stream stream = await blob.OpenWriteAsync(true))
            {
                using (var writer = new StreamWriter(stream, Encoding.ASCII))
                {
                    writer.Write(new string('A', 100));
                    writer.Flush();

                    writer.Write(new string('B', 50));
                    writer.Flush();

                    writer.Write(new string('C', 25));
                    writer.Flush();
                }
            }

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(new string('A', 100) + new string('B', 50) + new string('C', 25), Encoding.ASCII.GetString(dataResult.ToArray()));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task OpenWriteAsync_NewBlob_WithTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            Dictionary<string, string> tags = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                BufferSize = Constants.KB,
                Tags = tags,
            };

            Stream stream = await blob.OpenWriteAsync(
                overwrite: true,
                options);

            // Act
            await stream.FlushAsync();

            // Assert
            GetBlobTagResult tagsResult = await blob.GetTagsAsync();
            CollectionAssert.AreEqual(tags, tagsResult.Tags);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task OpenWriteAsync_CreateEmptyBlob_WithTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            Dictionary<string, string> tags = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                BufferSize = Constants.KB,
                Tags = tags,
            };

            // Act
            Stream stream = await blob.OpenWriteAsync(
                overwrite: true,
                options);

            // Assert
            GetBlobTagResult tagsResult = await blob.GetTagsAsync();
            CollectionAssert.AreEqual(tags, tagsResult.Tags);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewBlob_WithMetadata()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            Dictionary<string, string> metadata = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                BufferSize = Constants.KB,
                Metadata = metadata,
            };

            Stream stream = await blob.OpenWriteAsync(
                overwrite: true,
                options);

            // Act
            await stream.FlushAsync();

            // Assert
            BlobProperties properties = await blob.GetPropertiesAsync();
            CollectionAssert.AreEqual(metadata, properties.Metadata);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_CreateEmptyBlob_WithMetadata()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            Dictionary<string, string> metadata = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                BufferSize = Constants.KB,
                Metadata = metadata,
            };

            // Act
            Stream stream = await blob.OpenWriteAsync(
                overwrite: true,
                options);

            // Assert
            BlobProperties properties = await blob.GetPropertiesAsync();
            CollectionAssert.AreEqual(metadata, properties.Metadata);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewBlob_WithHeaders()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            BlobHttpHeaders headers = new BlobHttpHeaders()
            {
                ContentType = "application/json",
                ContentLanguage = "en",
            };

            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                BufferSize = Constants.KB,
                HttpHeaders = headers,
            };

            Stream stream = await blob.OpenWriteAsync(
                overwrite: true,
                options);

            // Act
            await stream.FlushAsync();

            // Assert
            BlobProperties properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(headers.ContentType, properties.ContentType);
            Assert.AreEqual(headers.ContentLanguage, properties.ContentLanguage);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_CreateEmptyBlob_WithHeaders()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            BlobHttpHeaders headers = new BlobHttpHeaders()
            {
                ContentType = "application/json",
                ContentLanguage = "en",
            };

            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                BufferSize = Constants.KB,
                HttpHeaders = headers,
            };

            // Act
            Stream stream = await blob.OpenWriteAsync(
                overwrite: true,
                options);

            // Assert
            BlobProperties properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(headers.ContentType, properties.ContentType);
            Assert.AreEqual(headers.ContentLanguage, properties.ContentLanguage);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewBlob_WithUsing()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            byte[] data = GetRandomBuffer(16 * Constants.KB);

            // Act
            using (Stream stream = await blob.OpenWriteAsync(
                overwrite: true,
                options))
            {
                await stream.WriteAsync(data, 0, 512);
                await stream.WriteAsync(data, 512, 1024);
                await stream.WriteAsync(data, 1536, 2048);
                await stream.WriteAsync(data, 3584, 77);
                await stream.WriteAsync(data, 3661, 2066);
                await stream.WriteAsync(data, 5727, 4096);
                await stream.WriteAsync(data, 9823, 6561);
            }

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, data.Length));
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_Overwrite()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            byte[] originalData = GetRandomBuffer(Constants.KB);
            using Stream originalStream = new MemoryStream(originalData);

            await blob.UploadAsync(content: originalStream);

            byte[] newData = GetRandomBuffer(Constants.KB);
            using Stream newStream = new MemoryStream(newData);

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(overwrite: true);
            await newStream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, newData.Length));
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(newData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(newData, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_AlternatingWriteAndFlush()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            byte[] data0 = GetRandomBuffer(512);
            byte[] data1 = GetRandomBuffer(512);
            using Stream dataStream0 = new MemoryStream(data0);
            using Stream dataStream1 = new MemoryStream(data1);
            byte[] expectedData = new byte[Constants.KB];
            Array.Copy(data0, expectedData, 512);
            Array.Copy(data1, 0, expectedData, 512, 512);

            // Act
            Stream writeStream = await blob.OpenWriteAsync(overwrite: true);
            await dataStream0.CopyToAsync(writeStream);
            await writeStream.FlushAsync();
            await dataStream1.CopyToAsync(writeStream);
            await writeStream.FlushAsync();

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.OpenWriteAsync(overwrite: true),
                e => Assert.AreEqual(BlobErrorCode.ContainerNotFound.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NoOverwrite()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.OpenWriteAsync(overwrite: false),
                e => Assert.AreEqual("BlockBlobClient.OpenWrite only supports overwriting", e.Message));
        }

        [RecordedTest]
        public async Task OpenWriteAsync_ModifiedDuringWrite()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(overwrite: true);

            string blockId = ToBase64(GetNewBlockName());
            await blob.StageBlockAsync(blockId, stream);
            stream.Position = 0;
            await blob.CommitBlockListAsync(new List<string> { blockId });

            await stream.CopyToAsync(openWriteStream);

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                openWriteStream.FlushAsync(),
                e => Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public async Task OpenWriteAsync_ProgressReporting()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            TestProgress progress = new TestProgress();
            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
            {
                ProgressHandler = progress,
                BufferSize = 256
            };

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(
                overwrite: true,
                options);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            Assert.IsTrue(progress.List.Count > 0);
            Assert.AreEqual(Constants.KB, progress.List[progress.List.Count - 1]);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

                parameters.SourceIfMatch = await SetupBlobMatchCondition(blob, parameters.SourceIfMatch);
                BlobRequestConditions accessConditions = BuildBlobRequestConditions(parameters);

                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);

                BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
                {
                    OpenConditions = accessConditions
                };

                // Act
                Stream openWriteStream = await blob.OpenWriteAsync(
                    overwrite: true,
                    options);
                await stream.CopyToAsync(openWriteStream);
                await openWriteStream.FlushAsync();

                // Assert
                Response<BlobDownloadInfo> result = await blob.DownloadAsync();
                MemoryStream dataResult = new MemoryStream();
                await result.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(data.Length, dataResult.Length);
                TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
            }
        }

        [RecordedTest]
        public async Task OpenWriteAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                await blob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

                parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(blob, parameters.SourceIfNoneMatch);
                BlobRequestConditions accessConditions = BuildBlobRequestConditions(parameters);

                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);

                BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions
                {
                    OpenConditions = accessConditions
                };

                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.OpenWriteAsync(
                        overwrite: true,
                        options),
                    e => Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), e.ErrorCode));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders
            {
                CacheControl = constants.CacheControl,
                ContentDisposition = constants.ContentDisposition,
                ContentEncoding = constants.ContentEncoding,
                ContentLanguage = constants.ContentLanguage,
                ContentType = constants.ContentType
            };

            Metadata metadata = BuildMetadata();

            BlobUploadOptions uploadOptions = new BlobUploadOptions
            {
                HttpHeaders = blobHttpHeaders,
                Metadata = metadata
            };

            await sourceBlob.UploadAsync(stream, uploadOptions);

            // Act
            Response<BlobContentInfo> uploadResponse = await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri);

            // Assert
            Assert.AreNotEqual(default(ETag), uploadResponse.Value.ETag);
            Assert.AreNotEqual(DateTimeOffset.MinValue, uploadResponse.Value.LastModified);

            // Validate source and destination blob content matches
            Response<BlobDownloadInfo> result = await destBlob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());

            // Validate source and desintation BlobHttpHeaders match
            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_Error()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncUploadFromUriAsync(sourceBlob.Uri),
                e => Assert.AreEqual(BlobErrorCode.CannotVerifyCopySource.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_OverwiteSourceBlobProperties()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            Metadata metadata = BuildMetadata();
            Tags tags = BuildTags();
            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                CopySourceBlobProperties = false,
                HttpHeaders = new BlobHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = constants.ContentEncoding,
                    ContentLanguage = constants.ContentLanguage,
                    ContentType = constants.ContentType
                },
                // TODO service bug.  https://github.com/Azure/azure-sdk-for-net/issues/15969
                // Metadata = metadata,
                Tags = tags,
                AccessTier = AccessTier.Hot
            };

            // Act
            await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options);

            // Assert

            // Validate source and destination blob content matches
            Response<BlobDownloadInfo> result = await destBlob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());

            // Validate source and destination BlobHttpHeaders match
            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
            // TODO service bug.  https://github.com/Azure/azure-sdk-for-net/issues/15969
            //AssertDictionaryEquality(metadata, response.Value.Metadata);
            Assert.AreEqual(tags.Count, response.Value.TagCount);
            Assert.AreEqual(AccessTier.Hot.ToString(), response.Value.AccessTier);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_DestinationAccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

                // Upload data to source blob
                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);
                await sourceBlob.UploadAsync(stream);

                parameters.SourceIfMatch = await SetupBlobMatchCondition(destBlob, parameters.SourceIfMatch);
                BlobRequestConditions accessConditions = BuildBlobRequestConditions(parameters);

                BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options);

                // Assert

                // Validate source and destination blob content matches
                Response<BlobDownloadInfo> result = await destBlob.DownloadAsync();
                MemoryStream dataResult = new MemoryStream();
                await result.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(data.Length, dataResult.Length);
                TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_DestinationAccessConditionsFailed()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

                parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(destBlob, parameters.SourceIfNoneMatch);
                BlobRequestConditions accessConditions = BuildBlobRequestConditions(parameters);

                // Upload data to source blob
                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);

                await sourceBlob.UploadAsync(stream);

                BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options),
                    e => Assert.IsTrue(BlobErrorCode.TargetConditionNotMet.ToString() == e.ErrorCode
                        || BlobErrorCode.ConditionNotMet.ToString() == e.ErrorCode));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_SourceAccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Upload data to source blob
                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);
                await sourceBlob.UploadAsync(stream);

                parameters.SourceIfMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                BlobRequestConditions accessConditions = BuildBlobRequestConditions(parameters);

                BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
                {
                    SourceConditions = accessConditions
                };

                // Act
                await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options);

                // Assert

                // Validate source and destination blob content matches
                Response<BlobDownloadInfo> result = await destBlob.DownloadAsync();
                MemoryStream dataResult = new MemoryStream();
                await result.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(data.Length, dataResult.Length);
                TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_SourceAccessConditions_Failed()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Upload data to source blob
                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);
                await sourceBlob.UploadAsync(stream);

                parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);
                BlobRequestConditions accessConditions = BuildBlobRequestConditions(parameters);

                BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
                {
                    SourceConditions = accessConditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options),
                    e => Assert.IsTrue(BlobErrorCode.CannotVerifyCopySource.ToString() == e.ErrorCode
                        || BlobErrorCode.SourceConditionNotMet.ToString() == e.ErrorCode));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Set tags on destination blob.
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            BlobUploadOptions uploadOptions = new BlobUploadOptions
            {
                Tags = tags
            };
            await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()), uploadOptions);

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };
            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                DestinationConditions = conditions
            };

            // Act
            await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options);

            // Assert

            // Validate source and destination blob content matches
            Response<BlobDownloadInfo> result = await destBlob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };
            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                DestinationConditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options),
                e => Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_Lease()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            // Take out lease on destination blob
            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(60);
            await InstrumentClient(destBlob.GetBlobLeaseClient(leaseId)).AcquireAsync(duration);

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    LeaseId = leaseId
                }
            };

            // Act
            await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options);

            // Assert

            // Validate source and destination blob content matches
            Response<BlobDownloadInfo> result = await destBlob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_LeaseFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            string leaseId = Recording.Random.NewGuid().ToString();
            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    LeaseId = leaseId
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options),
                e => Assert.AreEqual(BlobErrorCode.LeaseNotPresentWithBlobOperation.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_CPK()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            destBlob = destBlob.WithCustomerProvidedKey(customerProvidedKey);

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            // Act
            Response<BlobContentInfo> response = await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri);

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_EncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            destBlob = InstrumentClient(destBlob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            await sourceBlob.UploadAsync(stream);

            // Act
            Response<BlobContentInfo> response = await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri);

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_ContentMd5()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            byte[] sourceContentMd5 = MD5.Create().ComputeHash(data);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                ContentHash = sourceContentMd5
            };

            // Act
            Response<BlobContentInfo> response = await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options);

            // Assert
            Assert.AreEqual(sourceContentMd5, response.Value.ContentHash);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_ContentMd5Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            byte[] sourceContentMd5 = MD5.Create().ComputeHash(GetRandomBuffer(Constants.KB - 1));
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            string leaseId = Recording.Random.NewGuid().ToString();
            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                ContentHash = sourceContentMd5
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, options: options),
                e => Assert.AreEqual(BlobErrorCode.Md5Mismatch.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_Overwrite()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            // Act
            await destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, overwrite: true);

            // Assert

            // Validate source and destination blob content matches
            Response<BlobDownloadInfo> result = await destBlob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task SyncUploadFromUriAsync_OverwriteFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            await destBlob.UploadAsync(new MemoryStream(Array.Empty<byte>()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncUploadFromUriAsync(sourceBlob.Uri, overwrite: false),
                e => Assert.AreEqual(BlobErrorCode.BlobAlreadyExists.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task SyncUploadFromUriAsync_SourceBearerToken()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            string sourceBearerToken = await GetAuthToken();

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                sourceBearerToken);

            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await destBlob.SyncUploadFromUriAsync(
                copySource: sourceBlob.Uri,
                options: options);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        public async Task SyncUploadFromUriAsync_SourceBearerTokenFail()
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(
                service: serviceClient,
                publicAccessType: PublicAccessType.None);

            BlockBlobClient sourceBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Upload data to source blob
            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceBlob.UploadAsync(stream);

            HttpAuthorization sourceAuth = new HttpAuthorization(
                "Bearer",
                "auth token");

            BlobSyncUploadFromUriOptions options = new BlobSyncUploadFromUriOptions
            {
                SourceAuthentication = sourceAuth
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncUploadFromUriAsync(
                    copySource: sourceBlob.Uri,
                    options: options),
                e => Assert.AreEqual(BlobErrorCode.CannotVerifyCopySource.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public async Task WithCustomerProvidedKey()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlockBlobClient cpkBlob = InstrumentClient(test.Container.GetBlockBlobClient(blobName).WithCustomerProvidedKey(customerProvidedKey));
            byte[] data = GetRandomBuffer(Constants.KB);
            Stream stream = new MemoryStream(data);
            await cpkBlob.UploadAsync(stream);
            BlockBlobClient noCpkBlob = InstrumentClient(cpkBlob.WithCustomerProvidedKey(null));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                noCpkBlob.DownloadAsync(),
                e => Assert.AreEqual(BlobErrorCode.BlobUsesCustomerSpecifiedEncryption.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task WithEncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            string encryptionScope = TestConfigDefault.EncryptionScope;
            BlockBlobClient encryptionScopeBlob = InstrumentClient(test.Container.GetBlockBlobClient(blobName).WithEncryptionScope(encryptionScope));
            byte[] data = GetRandomBuffer(Constants.KB);
            Stream stream = new MemoryStream(data);
            await encryptionScopeBlob.UploadAsync(stream);
            BlockBlobClient noEncryptionScopeBlobClient = InstrumentClient(encryptionScopeBlob.WithEncryptionScope(null));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                noEncryptionScopeBlobClient.SetMetadataAsync(BuildMetadata()),
                e => Assert.AreEqual(BlobErrorCode.BlobUsesCustomerSpecifiedEncryption.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<BlockBlobClient>(TestConfigDefault.ConnectionString, "name", "name", new BlobClientOptions()).Object;
            mock = new Mock<BlockBlobClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<BlockBlobClient>(new Uri("https://test/test"), new BlobClientOptions()).Object;
            mock = new Mock<BlockBlobClient>(new Uri("https://test/test"), GetNewSharedKeyCredentials(), new BlobClientOptions()).Object;
            mock = new Mock<BlockBlobClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new BlobClientOptions()).Object;
            mock = new Mock<BlockBlobClient>(new Uri("https://test/test"), GetOAuthCredential(TestConfigHierarchicalNamespace), new BlobClientOptions()).Object;
        }

        private RequestConditions BuildRequestConditions(AccessConditionParameters parameters)
            => new RequestConditions
            {
                IfMatch = parameters.SourceIfMatch != null ? new ETag(parameters.SourceIfMatch) : default(ETag?),
                IfNoneMatch = parameters.SourceIfNoneMatch != null ? new ETag(parameters.SourceIfNoneMatch) : default(ETag?),
                IfModifiedSince = parameters.SourceIfModifiedSince,
                IfUnmodifiedSince = parameters.SourceIfUnmodifiedSince
            };

        private BlobRequestConditions BuildBlobRequestConditions(AccessConditionParameters parameters)
            => new BlobRequestConditions
            {
                IfMatch = parameters.SourceIfMatch != null ? new ETag(parameters.SourceIfMatch) : default(ETag?),
                IfNoneMatch = parameters.SourceIfNoneMatch != null ? new ETag(parameters.SourceIfNoneMatch) : default(ETag?),
                IfModifiedSince = parameters.SourceIfModifiedSince,
                IfUnmodifiedSince = parameters.SourceIfUnmodifiedSince
            };

        public IEnumerable<AccessConditionParameters> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { SourceIfModifiedSince = OldDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = NewDate },
                new AccessConditionParameters { SourceIfMatch = ReceivedETag },
                new AccessConditionParameters { SourceIfNoneMatch = GarbageETag }
            };

        public IEnumerable<AccessConditionParameters> AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { SourceIfModifiedSince = NewDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = OldDate },
                new AccessConditionParameters { SourceIfMatch = GarbageETag },
                new AccessConditionParameters { SourceIfNoneMatch = ReceivedETag }
            };

        public class AccessConditionParameters
        {
            public DateTimeOffset? SourceIfModifiedSince { get; set; }
            public DateTimeOffset? SourceIfUnmodifiedSince { get; set; }
            public string SourceIfMatch { get; set; }
            public string SourceIfNoneMatch { get; set; }
        }

        public struct GetBlockListParameters
        {
            public BlockListTypes BlockListTypes { get; set; }
            public int CommittedCount { get; set; }
            public int UncommittedCount { get; set; }
        }
    }
}
