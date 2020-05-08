﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

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

        [Test]
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

        [Test]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlockBlobClient(httpUri, GetOAuthCredential()),
                 new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
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

        [Test]
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

        [Test]
        public void WithSnapshot()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            BlobServiceClient service = GetServiceClient_SharedKey();

            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));

            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);

            blob = InstrumentClient(blob.WithSnapshot("foo"));

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            blob = InstrumentClient(blob.WithSnapshot(null));

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

            var progressList = new List<long>();
            var progressHandler = new Progress<long>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });
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

                await WaitForProgressAsync(progressList, data.LongLength);
                Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                Assert.GreaterOrEqual(data.LongLength, progressList.Last(), "Final progress has unexpected value");
            }

            // Assert
            Response<BlockList> blobList = await blob.GetBlockListAsync(BlockListTypes.All);
            Assert.AreEqual(0, blobList.Value.CommittedBlocks.Count());
            Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
            Assert.AreEqual(ToBase64(blockName), blobList.Value.UncommittedBlocks.First().Name);
            Assert.AreNotEqual(0, timesFaulted);
        }

        [Test]
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

        [Test]
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


        [Test]
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

        [Test]
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

        [Test]
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

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(
                    sourceBlob.Uri,
                    ToBase64(GetNewBlockName()),
                    new HttpRange(256, 256)),
                _retryStageBlockFromUri);
            Response<BlockList> getBlockListResult = await destBlob.GetBlockListAsync(BlockListTypes.All);

            // Assert
            Assert.AreEqual(256, getBlockListResult.Value.UncommittedBlocks.First().Size);
        }

        [Test]
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

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(
                    sourceBlob.Uri,
                    ToBase64(GetNewBlockName()),
                    sourceContentHash: MD5.Create().ComputeHash(data)),
                _retryStageBlockFromUri);

        }

        [Test]
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

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                RetryAsync(
                    async () => await destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        sourceContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garbage"))),
                    _retryStageBlockFromUri),
                actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
            );
        }

        [Test]
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

            var leaseAccessConditions = new BlobRequestConditions
            {
                LeaseId = await SetupBlobLeaseCondition(destBlob, ReceivedLeaseId, garbageLeaseId)
            };

            // Act
            await RetryAsync(
                async () => await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: ToBase64(GetNewBlockName()),
                    conditions: leaseAccessConditions),
                _retryStageBlockFromUri);
        }

        [Test]
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

            var leaseAccessConditions = new BlobRequestConditions
            {
                LeaseId = garbageLeaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                RetryAsync(
                    async () => await destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        conditions: leaseAccessConditions),
                    _retryStageBlockFromUri),
                actualException => Assert.AreEqual("LeaseNotPresentWithBlobOperation", actualException.ErrorCode)
            );
        }

        [Test]
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

                // Act
                await RetryAsync(
                    async () => await destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        sourceConditions: sourceAccessConditions),
                    _retryStageBlockFromUri);
            }
        }

        [Test]
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

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    RetryAsync(
                        async () => await destBlob.StageBlockFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            base64BlockId: ToBase64(GetNewBlockName()),
                            sourceConditions: sourceAccessConditions),
                        _retryStageBlockFromUri),
                    e => { });
            }
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task CommitBlockListAsync_Headers()
        {
            var constants = new TestConstants(this);
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

        [Test]
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
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
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

        [Test]
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

        [Test]
        public async Task UploadAsync_Headers()
        {
            var constants = new TestConstants(this);
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
                    e => Assert.AreEqual("body", e.ParamName));
            }
        }

        [Test]
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

            var progressList = new List<long>();
            var progressHandler = new Progress<long>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });
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

                await WaitForProgressAsync(progressList, data.LongLength);
                Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                Assert.GreaterOrEqual(data.LongLength, progressList.LastOrDefault(), "Final progress has unexpected value");
            }

            // Assert
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blockBlobName, blobs.First().Name);

            Response<BlobProperties> getPropertiesResponse = await blob.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata);
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

        private RequestConditions BuildRequestConditions(AccessConditionParameters parameters)
            => new RequestConditions
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
