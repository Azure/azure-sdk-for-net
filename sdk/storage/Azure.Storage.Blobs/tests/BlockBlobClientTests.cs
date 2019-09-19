// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Blobs.Test
{
    public class BlockBlobClientTests : BlobTestBase
    {
        const long Size = 4 * Constants.KB;

        public BlockBlobClientTests(bool async)
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

            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            BlockBlobClient blob = InstrumentClient(new BlockBlobClient(connectionString.ToString(true), containerName, blobName, GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
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
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        [Test]
        public async Task StageBlockAsync_CPK()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                blob = InstrumentClient(new BlockBlobClient(
                    GetHttpsUri(blob.Uri),
                    blob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
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
        }

        [Test]
        public async Task StageBlockAsync_CpkHttpError()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient httpBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                httpBlob = InstrumentClient(new BlockBlobClient(
                    httpBlob.Uri,
                    httpBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
                Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
                BlockBlobClient httpsBlob = InstrumentClient(new BlockBlobClient(
                    GetHttpsUri(httpBlob.Uri),
                    httpBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));

                var data = GetRandomBuffer(Size);

                // Create BlockBlob
                using (var stream = new MemoryStream(data))
                {
                    await httpsBlob.UploadAsync(stream);
                }

                using (var stream = new MemoryStream(data))
                {
                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                        httpBlob.StageBlockAsync(
                            base64BlockId: ToBase64(GetNewBlockName()),
                            content: stream),
                        actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
                }
            }
        }

        [Test]
        public async Task StageBlockAsync_Lease()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
                        leaseAccessConditions: new LeaseAccessConditions
                        {
                            LeaseId = leaseId
                        });

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task StageBlockAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);

                // Create BlockBlob
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                using (var stream = new MemoryStream(data))
                {
                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.StageBlockAsync(
                            base64BlockId: ToBase64(GetNewBlockName()),
                            content: stream,
                            leaseAccessConditions: new LeaseAccessConditions
                            {
                                LeaseId = garbageLeaseId
                            }),
                        e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
                }
            }
        }

        [Test]
        public async Task StageBlockAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;

            using (GetNewContainer(out BlobContainerClient container))
            {
                var credentials = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                BlobContainerClient containerFaulty = InstrumentClient(
                    new BlobContainerClient(
                        container.Uri,
                        credentials,
                        GetFaultyBlobConnectionOptions()));

                // Arrange
                var blockBlobName = GetNewBlobName();
                var blockName = GetNewBlockName();
                BlockBlobClient blobFaulty = InstrumentClient(containerFaulty.GetBlockBlobClient(blockBlobName));
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = GetRandomBuffer(blobSize);

                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.StageBlockAsync(ToBase64(blockName), stream, null, null, progressHandler: progressHandler);

                    await WaitForProgressAsync(progressList, data.LongLength);
                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                    // Changing from Assert.AreEqual because these don't always update fast enough
                    Assert.GreaterOrEqual(data.LongLength, progressList.Last().BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                Response<BlockList> blobList = await blob.GetBlockListAsync(BlockListType.All);
                Assert.AreEqual(0, blobList.Value.CommittedBlocks.Count());
                Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
                Assert.AreEqual(ToBase64(blockName), blobList.Value.UncommittedBlocks.First().Name);
            }
        }

        [Test]
        public async Task StageBlockAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var blockBlobName = GetNewBlobName();
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.StageBlockAsync(GetNewBlockName(), stream),
                        e =>
                        {
                            Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode);
                            Assert.AreEqual("Value for one of the query parameters specified in the request URI is invalid.", e.Message.Split('\n')[0]);
                        });
                }
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_Min()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, ToBase64(GetNewBlockName()));
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_CPK()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                destBlob = InstrumentClient(new BlockBlobClient(
                    GetHttpsUri(destBlob.Uri),
                    destBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));

                // Act
                await destBlob.StageBlockFromUriAsync(
                    sourceBlob.Uri,
                    ToBase64(GetNewBlockName()));
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_CpkHttpError()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                destBlob = InstrumentClient(new BlockBlobClient(
                    destBlob.Uri,
                    destBlob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
                Assert.AreEqual(Constants.Blob.Http, destBlob.Uri.Scheme);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    destBlob.StageBlockFromUriAsync(
                        sourceBlob.Uri,
                        ToBase64(GetNewBlockName())),
                    actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_Range()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, ToBase64(GetNewBlockName()), new HttpRange(256, 256));
                Response<BlockList> getBlockListResult = await destBlob.GetBlockListAsync(BlockListType.All);

                // Assert
                Assert.AreEqual(256, getBlockListResult.Value.UncommittedBlocks.First().Size);
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_MD5()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: ToBase64(GetNewBlockName()),
                    sourceContentHash: MD5.Create().ComputeHash(data));
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_MD5_Fail()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        sourceContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garbage"))),
                    actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
                );
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_Lease()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    await destBlob.UploadAsync(stream);
                }

                var leaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = await SetupBlobLeaseCondition(destBlob, ReceivedLeaseId, garbageLeaseId)
                };

                // Act
                await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: ToBase64(GetNewBlockName()),
                    leaseAccessConditions: leaseAccessConditions);
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_Lease_Fail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = GetRandomBuffer(blobSize);

                BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    await destBlob.UploadAsync(stream);
                }

                var leaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = garbageLeaseId
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        leaseAccessConditions: leaseAccessConditions),
                    actualException => Assert.AreEqual("LeaseNotPresentWithBlobOperation", actualException.ErrorCode)
                );
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_SourceAccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    const int blobSize = Constants.KB;
                    var data = GetRandomBuffer(blobSize);

                    BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await sourceBlob.UploadAsync(stream);
                    }

                    parameters.SourceIfMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                    HttpAccessConditions sourceAccessConditions = BuildHttpAccessConditions(parameters);

                    BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                    // Act
                    await destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: ToBase64(GetNewBlockName()),
                        sourceAccessConditions: sourceAccessConditions);
                }
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_SourceAccessConditions_Fail()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    const int blobSize = Constants.KB;
                    var data = GetRandomBuffer(blobSize);

                    BlockBlobClient sourceBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await sourceBlob.UploadAsync(stream);
                    }

                    parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);
                    HttpAccessConditions sourceAccessConditions = BuildHttpAccessConditions(parameters);

                    BlockBlobClient destBlob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        destBlob.StageBlockFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            base64BlockId: ToBase64(GetNewBlockName()),
                            sourceAccessConditions: sourceAccessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task CommitBlockListAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
                Response<BlockList> blobList = await blob.GetBlockListAsync(BlockListType.All);
                Assert.AreEqual(2, blobList.Value.CommittedBlocks.Count());
                Assert.AreEqual(ToBase64(firstBlockName), blobList.Value.CommittedBlocks.First().Name);
                Assert.AreEqual(ToBase64(secondBlockName), blobList.Value.CommittedBlocks.ElementAt(1).Name);
                Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
                Assert.AreEqual(ToBase64(thirdBlockName), blobList.Value.UncommittedBlocks.First().Name);
            }
        }

        [Test]
        public async Task CommitBlockListAsync_Headers()
        {
            var constants = new TestConstants(this);
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);
                var blockName = GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(ToBase64(blockName), stream);
                }

                // Act
                await blob.CommitBlockListAsync(
                    base64BlockIds: new string[] { ToBase64(blockName) },
                    blobHttpHeaders: new BlobHttpHeaders
                    {
                        CacheControl = constants.CacheControl,
                        ContentDisposition = constants.ContentDisposition,
                        ContentEncoding = new string[] { constants.ContentEncoding },
                        ContentLanguage = new string[] { constants.ContentLanguage },
                        ContentHash = constants.ContentMD5,
                        ContentType = constants.ContentType
                    });

                // Assert
                Response<BlobProperties> response = await blob.GetPropertiesAsync();
                Assert.AreEqual(constants.ContentType, response.Value.ContentType);
                TestHelper.AssertSequenceEqual(constants.ContentMD5, response.Value.ContentHash);
                Assert.AreEqual(1, response.Value.ContentEncoding.Count());
                Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(1, response.Value.ContentLanguage.Count());
                Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage.First());
                Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        public async Task CommitBlockListAsync_Metadata()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        [Test]
        public async Task CommitBlockListAsync_Lease()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
                    blobAccessConditions: new BlobAccessConditions
                    {
                        LeaseAccessConditions = new LeaseAccessConditions
                        {
                            LeaseId = leaseId
                        }
                    });

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task CommitBlockListAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);
                var blockName = GetNewBlockName();
                Metadata metadata = BuildMetadata();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(ToBase64(blockName), stream);
                }

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CommitBlockListAsync(
                        base64BlockIds: new string[] { ToBase64(GetNewBlockName()) },
                        blobAccessConditions: new BlobAccessConditions
                        {
                            LeaseAccessConditions = new LeaseAccessConditions
                            {
                                LeaseId = garbageLeaseId
                            }
                        }),
                    e =>
                    {
                        Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode);
                        Assert.AreEqual("There is currently no lease on the blob.", e.Message.Split('\n')[0]);
                    }
                );
            }
        }

        [Test]
        public async Task CommitBlockListAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    // Act
                    Response<BlobContentInfo> response = await blob.CommitBlockListAsync(
                        base64BlockIds: new string[] { ToBase64(blockName) },
                        blobAccessConditions: new BlobAccessConditions
                        {
                            HttpAccessConditions = accessConditions
                        });

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
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
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.CommitBlockListAsync(
                            base64BlockIds: new string[] { ToBase64(blockName) },
                            blobAccessConditions: new BlobAccessConditions
                            {
                                HttpAccessConditions = accessConditions
                            }),
                        e => { });
                }
            }
        }

        [Test]
        public async Task CommitBlockListAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var blockBlobName = GetNewBlobName();
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = GetRandomBuffer(Size);
                var commitList = new string[]
                {
                    ToBase64(GetNewBlockName())
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CommitBlockListAsync(commitList),
                    e =>
                    {
                        Assert.AreEqual("InvalidBlockList", e.ErrorCode);
                        Assert.AreEqual("The specified block list is invalid.", e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task CommitBlockListAsync_AccessTier()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
                Response<BlockList> blobList = await blob.GetBlockListAsync(BlockListType.All);
                Assert.AreEqual(2, blobList.Value.CommittedBlocks.Count());
                Assert.AreEqual(ToBase64(firstBlockName), blobList.Value.CommittedBlocks.First().Name);
                Assert.AreEqual(ToBase64(secondBlockName), blobList.Value.CommittedBlocks.ElementAt(1).Name);
                Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
                Assert.AreEqual(ToBase64(thirdBlockName), blobList.Value.UncommittedBlocks.First().Name);

                Response<BlobProperties> response = await blob.GetPropertiesAsync();
                Assert.AreEqual(AccessTier.Cool.ToString(), response.Value.AccessTier);
            }
        }

        [Test]
        public async Task CommitBlockListAsync_AccessTierFail()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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

                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CommitBlockListAsync(commitList, accessTier: AccessTier.P10),
                    e => Assert.AreEqual(BlobErrorCode.InvalidHeaderValue.ToString(), e.ErrorCode));
            }
        }

        [Test]
        public async Task GetBlockListAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        [Test]
        public async Task GetBlockListAsync_Type()
        {
            GetBlockListParameters[] testCases = new[]
            {
                new GetBlockListParameters { BlockListType = BlockListType.All, CommittedCount = 1, UncommittedCount = 1 },
                new GetBlockListParameters { BlockListType = BlockListType.Committed, CommittedCount = 1, UncommittedCount = 0 },
                new GetBlockListParameters { BlockListType = BlockListType.Uncommitted, CommittedCount = 0, UncommittedCount = 1 }
            };
            foreach (GetBlockListParameters parameters in testCases)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
                    Response<BlockList> response = await blob.GetBlockListAsync(parameters.BlockListType);

                    // Assert
                    // CommitedBlocks and UncommittedBlocks are null if empty
                    Assert.AreEqual(parameters.CommittedCount, response.Value.CommittedBlocks?.Count() ?? 0);
                    Assert.AreEqual(parameters.UncommittedCount, response.Value.UncommittedBlocks?.Count() ?? 0);
                }
            }
        }

        [Test]
        public async Task GetBlockListAsync_Lease()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);

                // Upload to blockBlobUri, so it exists
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var leaseId = await SetupBlobLeaseCondition(blob, ReceivedLeaseId, garbageLeaseId);

                // Act
                Response<BlockList> response = await blob.GetBlockListAsync(
                    leaseAccessConditions: new LeaseAccessConditions
                    {
                        LeaseId = leaseId
                    });
            }
        }

        [Test]
        public async Task GetBlockListAsync_LeaseFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);

                // Upload to blockBlobUri, so it exists
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.GetBlockListAsync(
                        leaseAccessConditions: new LeaseAccessConditions
                        {
                            LeaseId = garbageLeaseId
                        }),
                    e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task GetBlockListAsync_Error()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var blockBlobName = GetNewBlobName();
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blockBlobName));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.GetBlockListAsync(BlockListType.All, "invalidSnapshot"),
                    e =>
                    {
                        Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode);
                        Assert.AreEqual("Value for one of the query parameters specified in the request URI is invalid.", e.Message.Split('\n')[0]);
                    }
                );
            }
        }

        [Test]
        public async Task UploadAsync()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var blockBlobName = GetNewBlobName();
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(
                        content: stream);
                }

                // Assert
                IList<Response<BlobItem>> blobs = await container.GetBlobsAsync().ToListAsync();
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blockBlobName, blobs.First().Value.Name);

                Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task UploadAsync_Metadata()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
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
        }

        [Test]
        public async Task UploadAsync_CPK()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                blob = InstrumentClient(new BlockBlobClient(
                    GetHttpsUri(blob.Uri),
                    blob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
                var data = GetRandomBuffer(Size);

                // Act
                using var stream = new MemoryStream(data);
                Response<BlobContentInfo> response = await blob.UploadAsync(
                    content: stream);

                // Assert
                Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
            }
        }

        [Test]
        public async Task UploadAsync_CpkHttpError()
        {
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                blob = InstrumentClient(new BlockBlobClient(
                    blob.Uri,
                    blob.Pipeline,
                    new BlobClientOptions(customerProvidedKey: customerProvidedKey)));
                Assert.AreEqual(Constants.Blob.Http, blob.Uri.Scheme);
                var data = GetRandomBuffer(Size);

                // Act
                using var stream = new MemoryStream(data);
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    blob.UploadAsync(
                        content: stream),
                    actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
            }
        }

        [Test]
        public async Task UploadAsync_Headers()
        {
            var constants = new TestConstants(this);
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Size);
                var contentMD5 = MD5.Create().ComputeHash(data);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(
                        content: stream,
                        blobHttpHeaders: new BlobHttpHeaders
                        {
                            CacheControl = constants.CacheControl,
                            ContentDisposition = constants.ContentDisposition,
                            ContentEncoding = new string[] { constants.ContentEncoding },
                            ContentLanguage = new string[] { constants.ContentLanguage },
                            ContentHash = contentMD5
                        });
                }

                // Assert
                Response<BlobProperties> response = await blob.GetPropertiesAsync();
                Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
                Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage.First());
                TestHelper.AssertSequenceEqual(contentMD5, response.Value.ContentHash);
            }
        }

        [Test]
        public async Task UploadAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    var data = GetRandomBuffer(Size);
                    var blockName = GetNewBlockName();

                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    parameters.SourceIfMatch = await SetupBlobMatchCondition(blob, parameters.SourceIfMatch);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    // Act
                    using (var stream = new MemoryStream(data))
                    {
                        Response<BlobContentInfo> response = await blob.UploadAsync(
                            content: stream,
                            blobAccessConditions: new BlobAccessConditions
                            {
                                HttpAccessConditions = accessConditions
                            });

                        // Assert
                        Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                    }
                }
            }
        }

        [Test]
        public async Task UploadAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in AccessConditionsFail_Data)
            {
                using (GetNewContainer(out BlobContainerClient container))
                {
                    // Arrange
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    var data = GetRandomBuffer(Size);
                    var blockName = GetNewBlockName();

                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(blob, parameters.SourceIfNoneMatch);
                    HttpAccessConditions accessConditions = BuildHttpAccessConditions(parameters);

                    // Act
                    using (var stream = new MemoryStream(data))
                    {
                        await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                            blob.UploadAsync(
                                content: stream,
                                blobAccessConditions: new BlobAccessConditions
                                {
                                    HttpAccessConditions = accessConditions
                                }),
                            e => { });
                    }
                }
            }
        }

        [Test]
        public async Task UploadAsync_Error()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(Constants.KB);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.UploadAsync(
                            content: stream,
                            blobAccessConditions: new BlobAccessConditions
                            {
                                LeaseAccessConditions = new LeaseAccessConditions
                                {
                                    LeaseId = garbageLeaseId
                                }
                            }),
                        e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode.Split('\n')[0]));
                }
            }
        }

        [Test]
        public async Task UploadAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;
            Metadata metadata = BuildMetadata();
            using (GetNewContainer(out BlobContainerClient container))
            {
                // Arrange
                var credentials = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                BlobContainerClient containerFaulty = InstrumentClient(
                    new BlobContainerClient(
                        container.Uri,
                        credentials,
                        GetFaultyBlobConnectionOptions()));

                var blockBlobName = GetNewBlobName();
                BlockBlobClient blobFaulty = InstrumentClient(containerFaulty.GetBlockBlobClient(blockBlobName));
                BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = GetRandomBuffer(blobSize);

                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.UploadAsync(stream, null, metadata, null, progressHandler: progressHandler);

                    await WaitForProgressAsync(progressList, data.LongLength);
                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                    // Changing from Assert.AreEqual because these don't always update fast enough
                    Assert.GreaterOrEqual(data.LongLength, progressList.LastOrDefault().BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                IList<Response<BlobItem>> blobs = await container.GetBlobsAsync().ToListAsync();
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blockBlobName, blobs.First().Value.Name);

                Response<BlobProperties> getPropertiesResponse = await blob.GetPropertiesAsync();
                AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata);
                Assert.AreEqual(BlobType.BlockBlob, getPropertiesResponse.Value.BlobType);

                Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        private HttpAccessConditions BuildHttpAccessConditions(AccessConditionParameters parameters)
            => new HttpAccessConditions
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
            public BlockListType BlockListType { get; set; }
            public int CommittedCount { get; set; }
            public int UncommittedCount { get; set; }
        }
    }
}
