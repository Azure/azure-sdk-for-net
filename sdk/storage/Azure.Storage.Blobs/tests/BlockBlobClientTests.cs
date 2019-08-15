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

            var containerName = this.GetNewContainerName();
            var blobName = this.GetNewBlobName();

            var blob = this.InstrumentClient(new BlockBlobClient(connectionString.ToString(true), containerName, blobName, this.GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public void WithSnapshot()
        {
            var containerName = this.GetNewContainerName();
            var blobName = this.GetNewBlobName();

            var service = this.GetServiceClient_SharedKey();

            var container = this.InstrumentClient(service.GetBlobContainerClient(containerName));

            var blob = this.InstrumentClient(container.GetBlockBlobClient(blobName));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);

            blob = this.InstrumentClient(blob.WithSnapshot("foo"));

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            blob = this.InstrumentClient(blob.WithSnapshot(null));

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        [Test]
        public async Task StageBlockAsync_Min()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);

                // Create BlockBlob
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                using (var stream = new MemoryStream(data))
                {
                    // Act
                    var response = await blob.StageBlockAsync(
                        base64BlockId: this.ToBase64(this.GetNewBlockName()),
                        content: stream);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task StageBlockAsync_Lease()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);

                // Create BlockBlob
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var leaseId = await this.SetupBlobLeaseCondition(blob, this.ReceivedLeaseId, garbageLeaseId);

                using (var stream = new MemoryStream(data))
                {
                    // Act
                    var response = await blob.StageBlockAsync(
                        base64BlockId: this.ToBase64(this.GetNewBlockName()),
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
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);

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
                            base64BlockId: this.ToBase64(this.GetNewBlockName()),
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

            using (this.GetNewContainer(out var container))
            {
                var credentials = new StorageSharedKeyCredential(this.TestConfigDefault.AccountName, this.TestConfigDefault.AccountKey);
                var containerFaulty = this.InstrumentClient(
                    new BlobContainerClient(
                        container.Uri,
                        credentials,
                        this.GetFaultyBlobConnectionOptions()));

                // Arrange
                var blockBlobName = this.GetNewBlobName();
                var blockName = this.GetNewBlockName();
                var blobFaulty = this.InstrumentClient(containerFaulty.GetBlockBlobClient(blockBlobName));
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = this.GetRandomBuffer(blobSize);

                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.StageBlockAsync(this.ToBase64(blockName), stream, null, null, progressHandler: progressHandler);

                    await this.WaitForProgressAsync(progressList, data.LongLength);
                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                    // Changing from Assert.AreEqual because these don't always update fast enough
                    Assert.GreaterOrEqual(data.LongLength, progressList.Last().BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var blobList = await blob.GetBlockListAsync(BlockListType.All);
                Assert.AreEqual(0, blobList.Value.CommittedBlocks.Count());
                Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
                Assert.AreEqual(this.ToBase64(blockName), blobList.Value.UncommittedBlocks.First().Name);
            }
        }

        [Test]
        public async Task StageBlockAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blockBlobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = this.GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.StageBlockAsync(this.GetNewBlockName(), stream),
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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = this.GetRandomBuffer(blobSize);

                var sourceBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                var destBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));

                // Act
                await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, this.ToBase64(this.GetNewBlockName()));
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_Range()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = this.GetRandomBuffer(blobSize);

                var sourceBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                var destBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));

                // Act
                await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, this.ToBase64(this.GetNewBlockName()), new HttpRange(256, 256));
                var getBlockListResult = await destBlob.GetBlockListAsync(BlockListType.All);

                // Assert
                Assert.AreEqual(256, getBlockListResult.Value.UncommittedBlocks.First().Size);
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_MD5()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = this.GetRandomBuffer(blobSize);

                var sourceBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                var destBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));

                // Act
                await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: this.ToBase64(this.GetNewBlockName()),
                    sourceContentHash: MD5.Create().ComputeHash(data));
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_MD5_Fail()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = this.GetRandomBuffer(blobSize);

                var sourceBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                var destBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: this.ToBase64(this.GetNewBlockName()),
                        sourceContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garbage"))),
                    actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
                );
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_Lease()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = this.GetRandomBuffer(blobSize);

                var sourceBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var destBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));

                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    await destBlob.UploadAsync(stream);
                }

                var leaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = await this.SetupBlobLeaseCondition(destBlob, this.ReceivedLeaseId, garbageLeaseId)
                };

                // Act
                await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockId: this.ToBase64(this.GetNewBlockName()),
                    leaseAccessConditions: leaseAccessConditions);
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_Lease_Fail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = this.GetRandomBuffer(blobSize);

                var sourceBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var destBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));

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
                        base64BlockId: this.ToBase64(this.GetNewBlockName()),
                        leaseAccessConditions: leaseAccessConditions),
                    actualException => Assert.AreEqual("LeaseNotPresentWithBlobOperation", actualException.ErrorCode)
                );
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_SourceAccessConditions()
        {
            foreach (var parameters in this.AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    const int blobSize = Constants.KB;
                    var data = this.GetRandomBuffer(blobSize);

                    var sourceBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await sourceBlob.UploadAsync(stream);
                    }

                    parameters.SourceIfMatch = await this.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                    var sourceAccessConditions = this.BuildHttpAccessConditions(parameters);

                    var destBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));

                    // Act
                    await destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockId: this.ToBase64(this.GetNewBlockName()),
                        sourceAccessConditions: sourceAccessConditions);
                }
            }
        }

        [Test]
        public async Task StageBlockFromUriAsync_SourceAccessConditions_Fail()
        {
            foreach (var parameters in this.AccessConditionsFail_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    const int blobSize = Constants.KB;
                    var data = this.GetRandomBuffer(blobSize);

                    var sourceBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await sourceBlob.UploadAsync(stream);
                    }

                    parameters.SourceIfNoneMatch = await this.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);
                    var sourceAccessConditions = this.BuildHttpAccessConditions(parameters);

                    var destBlob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        destBlob.StageBlockFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            base64BlockId: this.ToBase64(this.GetNewBlockName()),
                            sourceAccessConditions: sourceAccessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task CommitBlockListAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);
                var firstBlockName = this.GetNewBlockName();
                var secondBlockName = this.GetNewBlockName();
                var thirdBlockName = this.GetNewBlockName();

                // Act
                // Stage blocks
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(this.ToBase64(firstBlockName), stream);
                }
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(this.ToBase64(secondBlockName), stream);
                }

                // Commit first two Blocks
                var commitList = new string[]
                {
                    this.ToBase64(firstBlockName),
                    this.ToBase64(secondBlockName)
                };

                await blob.CommitBlockListAsync(commitList);

                // Stage 3rd Block
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(this.ToBase64(thirdBlockName), stream);
                }

                // Assert
                var blobList = await blob.GetBlockListAsync(BlockListType.All);
                Assert.AreEqual(2, blobList.Value.CommittedBlocks.Count());
                Assert.AreEqual(this.ToBase64(firstBlockName), blobList.Value.CommittedBlocks.First().Name);
                Assert.AreEqual(this.ToBase64(secondBlockName), blobList.Value.CommittedBlocks.ElementAt(1).Name);
                Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
                Assert.AreEqual(this.ToBase64(thirdBlockName), blobList.Value.UncommittedBlocks.First().Name);
            }
        }

        [Test]
        public async Task CommitBlockListAsync_Headers()
        {
            var constants = new TestConstants(this);
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);
                var blockName = this.GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(this.ToBase64(blockName), stream);
                }

                // Act
                await blob.CommitBlockListAsync(
                    base64BlockIds: new string[] { this.ToBase64(blockName) },
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
                var response = await blob.GetPropertiesAsync();
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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);
                var blockName = this.GetNewBlockName();
                var metadata = this.BuildMetadata();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(this.ToBase64(blockName), stream);
                }

                // Act
                await blob.CommitBlockListAsync(
                    base64BlockIds: new string[] { this.ToBase64(blockName) },
                    metadata: metadata);

                // Assert
                var response = await blob.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task CommitBlockListAsync_Lease()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);
                var blockName = this.GetNewBlockName();
                var metadata = this.BuildMetadata();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(this.ToBase64(blockName), stream);
                }

                var leaseId = await this.SetupBlobLeaseCondition(blob, this.ReceivedLeaseId, garbageLeaseId);

                // Act
                var response = await blob.CommitBlockListAsync(
                    base64BlockIds: new string[] { this.ToBase64(blockName) },
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
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);
                var blockName = this.GetNewBlockName();
                var metadata = this.BuildMetadata();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(this.ToBase64(blockName), stream);
                }

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CommitBlockListAsync(
                        base64BlockIds: new string[] { this.ToBase64(this.GetNewBlockName()) },
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
            foreach (var parameters in this.AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                    var data = this.GetRandomBuffer(Size);
                    var blockName = this.GetNewBlockName();

                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    // Upload to blockBlobUri, exists when we get the ETag
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.StageBlockAsync(this.ToBase64(blockName), stream);
                    }

                    parameters.SourceIfMatch = await this.SetupBlobMatchCondition(blob, parameters.SourceIfMatch);
                    var accessConditions = this.BuildHttpAccessConditions(parameters);

                    // Act
                    var response = await blob.CommitBlockListAsync(
                        base64BlockIds: new string[] { this.ToBase64(blockName) },
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
            var testCases = new[]
            {
                new AccessConditionParameters { SourceIfModifiedSince = this.NewDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { SourceIfMatch = this.GarbageETag },
                new AccessConditionParameters { SourceIfNoneMatch = this.ReceivedETag }
            };
            foreach (var parameters in testCases)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                    var data = this.GetRandomBuffer(Size);
                    var blockName = this.GetNewBlockName();

                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    // Upload to blockBlobUri, exists when we get the ETag
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.StageBlockAsync(this.ToBase64(blockName), stream);
                    }

                    parameters.SourceIfNoneMatch = await this.SetupBlobMatchCondition(blob, parameters.SourceIfNoneMatch);
                    var accessConditions = this.BuildHttpAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.CommitBlockListAsync(
                            base64BlockIds: new string[] { this.ToBase64(blockName) },
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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blockBlobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = this.GetRandomBuffer(Size);
                var commitList = new string[]
                {
                    this.ToBase64(this.GetNewBlockName())
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
        public async Task GetBlockListAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);

                // Upload to blockBlobUri, so it exists
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var blockId0 = this.ToBase64(this.GetNewBlockName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(blockId0, stream);
                }
                await blob.CommitBlockListAsync(new string[] { blockId0 });

                var blockId1 = this.ToBase64(this.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(blockId1, stream);
                }

                // Act
                var response = await blob.GetBlockListAsync();

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
            var testCases = new[]
            {
                new GetBlockListParameters { BlockListType = BlockListType.All, CommittedCount = 1, UncommittedCount = 1 },
                new GetBlockListParameters { BlockListType = BlockListType.Committed, CommittedCount = 1, UncommittedCount = 0 },
                new GetBlockListParameters { BlockListType = BlockListType.Uncommitted, CommittedCount = 0, UncommittedCount = 1 }
            };
            foreach (var parameters in testCases)
            { 
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                    var data = this.GetRandomBuffer(Size);

                    // Upload to blockBlobUri, so it exists
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    var blockId0 = this.ToBase64(this.GetNewBlockName());
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.StageBlockAsync(blockId0, stream);
                    }
                    await blob.CommitBlockListAsync(new string[] { blockId0 });

                    var blockId1 = this.ToBase64(this.GetNewBlobName());
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.StageBlockAsync(blockId1, stream);
                    }

                    // Act
                    var response = await blob.GetBlockListAsync(parameters.BlockListType);

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
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);

                // Upload to blockBlobUri, so it exists
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var leaseId = await this.SetupBlobLeaseCondition(blob, this.ReceivedLeaseId, garbageLeaseId);

                // Act
                var response = await blob.GetBlockListAsync(
                    leaseAccessConditions: new LeaseAccessConditions
                    {
                        LeaseId = leaseId
                    });
            }
        }

        [Test]
        public async Task GetBlockListAsync_LeaseFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);

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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blockBlobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blockBlobName));

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
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blockBlobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = this.GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(
                        content: stream);
                }

                // Assert
                var blobs = await container.GetBlobsAsync().ToListAsync();
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blockBlobName, blobs.First().Value.Name);

                var downloadResponse = await blob.DownloadAsync();
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task UploadAsync_Metadata()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);
                var metadata = this.BuildMetadata();

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(
                        content: stream,
                        metadata: metadata);
                }

                // Assert
                var response = await blob.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task UploadAsync_Headers()
        {
            var constants = new TestConstants(this);
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Size);
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
                var response = await blob.GetPropertiesAsync();
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
            foreach (var parameters in this.AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                    var data = this.GetRandomBuffer(Size);
                    var blockName = this.GetNewBlockName();

                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    parameters.SourceIfMatch = await this.SetupBlobMatchCondition(blob, parameters.SourceIfMatch);
                    var accessConditions = this.BuildHttpAccessConditions(parameters);

                    // Act
                    using (var stream = new MemoryStream(data))
                    {
                        var response = await blob.UploadAsync(
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
            foreach (var parameters in this.AccessConditionsFail_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                    var data = this.GetRandomBuffer(Size);
                    var blockName = this.GetNewBlockName();

                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }

                    parameters.SourceIfNoneMatch = await this.SetupBlobMatchCondition(blob, parameters.SourceIfNoneMatch);
                    var accessConditions = this.BuildHttpAccessConditions(parameters);

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
            var garbageLeaseId = this.GetGarbageLeaseId();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Constants.KB);

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
            var metadata = this.BuildMetadata();
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var credentials = new StorageSharedKeyCredential(this.TestConfigDefault.AccountName, this.TestConfigDefault.AccountKey);
                var containerFaulty = this.InstrumentClient(
                    new BlobContainerClient(
                        container.Uri,
                        credentials,
                        this.GetFaultyBlobConnectionOptions()));

                var blockBlobName = this.GetNewBlobName();
                var blobFaulty = this.InstrumentClient(containerFaulty.GetBlockBlobClient(blockBlobName));
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blockBlobName));
                var data = this.GetRandomBuffer(blobSize);

                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.UploadAsync(stream, null, metadata, null, progressHandler: progressHandler);

                    await this.WaitForProgressAsync(progressList, data.LongLength);
                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                    // Changing from Assert.AreEqual because these don't always update fast enough
                    Assert.GreaterOrEqual(data.LongLength, progressList.LastOrDefault().BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var blobs = await container.GetBlobsAsync().ToListAsync();
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blockBlobName, blobs.First().Value.Name);

                var getPropertiesResponse = await blob.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata);
                Assert.AreEqual(BlobType.BlockBlob, getPropertiesResponse.Value.BlobType);

                var downloadResponse = await blob.DownloadAsync();
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
                new AccessConditionParameters { SourceIfModifiedSince = this.OldDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { SourceIfMatch = this.ReceivedETag },
                new AccessConditionParameters { SourceIfNoneMatch = this.GarbageETag }
            };

        public IEnumerable<AccessConditionParameters> AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { SourceIfModifiedSince = this.NewDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { SourceIfMatch = this.GarbageETag },
                new AccessConditionParameters { SourceIfNoneMatch = this.ReceivedETag }
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
