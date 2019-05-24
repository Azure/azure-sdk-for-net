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
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Blobs.Test
{
    [TestClass]
    public class BlockBlobClientTests
    {
        const long Size = 4 * Constants.KB;
        static readonly Metadata metadata = TestHelper.BuildMetadata();

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
            var blobName = TestHelper.GetNewBlobName();

            var blob = new BlockBlobClient(connectionString.ToString(true), containerName, blobName, TestHelper.GetOptions<BlobConnectionOptions>());

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [TestMethod]
        public void WithSnapshot()
        {
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();

            var service = TestHelper.GetServiceClient_SharedKey();

            var container = service.GetBlobContainerClient(containerName);

            var blob = container.GetBlockBlobClient(blobName);

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);

            blob = blob.WithSnapshot("foo");

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            blob = blob.WithSnapshot(null);

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockAsync_Min()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);

                // Create BlockBlob
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                using (var stream = new MemoryStream(data))
                {
                    // Act
                    var response = await blob.StageBlockAsync(
                        base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
                        content: stream);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockAsync_Lease()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);

                // Create BlockBlob
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var leaseId = await TestHelper.SetupBlobLeaseCondition(blob, TestHelper.ReceivedLeaseId);

                using (var stream = new MemoryStream(data))
                {
                    // Act
                    var response = await blob.StageBlockAsync(
                        base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
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

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockAsync_LeaseFail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);

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
                            base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
                            content: stream,
                            leaseAccessConditions: new LeaseAccessConditions
                            {
                                LeaseId = TestHelper.GarbageLeaseId
                            }),
                        e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;

            using (TestHelper.GetNewContainer(out var container))
            {
                var credentials = new SharedKeyCredentials(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey);
                var containerFaulty = new BlobContainerClient(
                    container.Uri,
                    TestHelper.GetFaultyBlobConnectionOptions(credentials));

                // Arrange
                var blockBlobName = TestHelper.GetNewBlobName();
                var blockName = TestHelper.GetNewBlockName();
                var blobFaulty = containerFaulty.GetBlockBlobClient(blockBlobName);
                var blob = container.GetBlockBlobClient(blockBlobName);
                var data = TestHelper.GetRandomBuffer(blobSize);

                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.StageBlockAsync(TestHelper.ToBase64(blockName), stream, null, null, progressHandler: progressHandler);

                    await Task.Delay(1000); // wait 1s to allow lingering progress events to execute

                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");

                    var lastProgress = progressList.Last();

                    Assert.AreEqual(data.LongLength, lastProgress.BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var blobList = await blob.GetBlockListAsync(BlockListType.All);
                Assert.AreEqual(0, blobList.Value.CommittedBlocks.Count());
                Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
                Assert.AreEqual(TestHelper.ToBase64(blockName), blobList.Value.UncommittedBlocks.First().Name);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blockBlobName = TestHelper.GetNewBlobName();
                var blob = container.GetBlockBlobClient(blockBlobName);
                var data = TestHelper.GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.StageBlockAsync(TestHelper.GetNewBlockName(), stream),
                        e =>
                        {
                            Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode);
                            Assert.AreEqual("Value for one of the query parameters specified in the request URI is invalid.", e.Message.Split('\n')[0]);
                        });
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockFromUriAsync_Min()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

                var sourceBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, TestHelper.ToBase64(TestHelper.GetNewBlockName()));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockFromUriAsync_Range()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

                var sourceBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await destBlob.StageBlockFromUriAsync(sourceBlob.Uri, TestHelper.ToBase64(TestHelper.GetNewBlockName()), new HttpRange(256, 256));
                var getBlockListResult = await destBlob.GetBlockListAsync(BlockListType.All);

                // Assert
                Assert.AreEqual(256, getBlockListResult.Value.UncommittedBlocks.First().Size);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockFromUriAsync_MD5()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

                var sourceBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
                    sourceContentHash: MD5.Create().ComputeHash(data));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockFromUriAsync_MD5_Fail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

                var sourceBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
                        sourceContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garabage"))),
                    actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
                );
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockFromUriAsync_Lease()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

                var sourceBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    await destBlob.UploadAsync(stream);
                }

                var leaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = await TestHelper.SetupBlobLeaseCondition(destBlob, TestHelper.ReceivedLeaseId)
                };

                // Act
                await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
                    leaseAccessConditions: leaseAccessConditions);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task StageBlockFromUriAsync_Lease_Fail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

                var sourceBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    await destBlob.UploadAsync(stream);
                }

                var leaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = TestHelper.GarbageLeaseId
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
                        leaseAccessConditions: leaseAccessConditions),
                    actualException => Assert.AreEqual("LeaseNotPresentWithBlobOperation", actualException.ErrorCode)
                );
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task StageBlockFromUriAsync_SourceAccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

                var sourceBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                parameters.SourceIfMatch = await TestHelper.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                var sourceAccessConditions = this.BuildHttpAccessConditions(parameters);

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await destBlob.StageBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
                    sourceAccessConditions: sourceAccessConditions);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task StageBlockFromUriAsync_SourceAccessConditions_Fail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

                var sourceBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadAsync(stream);
                }

                parameters.SourceIfNoneMatch = await TestHelper.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);
                var sourceAccessConditions = this.BuildHttpAccessConditions(parameters);

                var destBlob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    destBlob.StageBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        base64BlockID: TestHelper.ToBase64(TestHelper.GetNewBlockName()),
                        sourceAccessConditions: sourceAccessConditions),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CommitBlockListAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var firstBlockName = TestHelper.GetNewBlockName();
                var secondBlockName = TestHelper.GetNewBlockName();
                var thirdBlockName = TestHelper.GetNewBlockName();

                // Act
                // Stage blocks
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(firstBlockName), stream);
                }
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(secondBlockName), stream);
                }

                // Commit first two Blocks
                var commitList = new string[]
                {
                    TestHelper.ToBase64(firstBlockName),
                    TestHelper.ToBase64(secondBlockName)
                };

                await blob.CommitBlockListAsync(commitList);

                // Stage 3rd Block
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(thirdBlockName), stream);
                }

                // Assert
                var blobList = await blob.GetBlockListAsync(BlockListType.All);
                Assert.AreEqual(2, blobList.Value.CommittedBlocks.Count());
                Assert.AreEqual(TestHelper.ToBase64(firstBlockName), blobList.Value.CommittedBlocks.First().Name);
                Assert.AreEqual(TestHelper.ToBase64(secondBlockName), blobList.Value.CommittedBlocks.ElementAt(1).Name);
                Assert.AreEqual(1, blobList.Value.UncommittedBlocks.Count());
                Assert.AreEqual(TestHelper.ToBase64(thirdBlockName), blobList.Value.UncommittedBlocks.First().Name);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CommitBlockListAsync_Headers()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var blockName = TestHelper.GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(blockName), stream);
                }

                // Act
                await blob.CommitBlockListAsync(
                    base64BlockIDs: new string[] { TestHelper.ToBase64(blockName) },
                    blobHttpHeaders: new BlobHttpHeaders
                    {
                        CacheControl = TestConstants.CacheControl,
                        ContentDisposition = TestConstants.ContentDisposition,
                        ContentEncoding = new string[] { TestConstants.ContentEncoding },
                        ContentLanguage = new string[] { TestConstants.ContentLanguage },
                        ContentHash = TestConstants.ContentMD5,
                        ContentType = TestConstants.ContentType
                    });

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(TestConstants.ContentType, response.Value.ContentType);
                Assert.IsTrue(TestConstants.ContentMD5.ToList().SequenceEqual(response.Value.ContentHash.ToList()));
                Assert.AreEqual(1, response.Value.ContentEncoding.Count());
                Assert.AreEqual(TestConstants.ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(1, response.Value.ContentLanguage.Count());
                Assert.AreEqual(TestConstants.ContentLanguage, response.Value.ContentLanguage.First());
                Assert.AreEqual(TestConstants.ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(TestConstants.CacheControl, response.Value.CacheControl);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CommitBlockListAsync_Metadata()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var blockName = TestHelper.GetNewBlockName();
                var metadata = TestHelper.BuildMetadata();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(blockName), stream);
                }

                // Act
                await blob.CommitBlockListAsync(
                    base64BlockIDs: new string[] { TestHelper.ToBase64(blockName) },
                    metadata: metadata);

                // Assert
                var response = await blob.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CommitBlockListAsync_Lease()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var blockName = TestHelper.GetNewBlockName();
                var metadata = TestHelper.BuildMetadata();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(blockName), stream);
                }

                var leaseId = await TestHelper.SetupBlobLeaseCondition(blob, TestHelper.ReceivedLeaseId);

                // Act
                var response = await blob.CommitBlockListAsync(
                    base64BlockIDs: new string[] { TestHelper.ToBase64(blockName) },
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

        [TestMethod]
        [TestCategory("Live")]
        public async Task CommitBlockListAsync_LeaseFail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var blockName = TestHelper.GetNewBlockName();
                var metadata = TestHelper.BuildMetadata();

                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(blockName), stream);
                }

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CommitBlockListAsync(
                        base64BlockIDs: new string[] { TestHelper.ToBase64(TestHelper.GetNewBlockName()) },
                        blobAccessConditions: new BlobAccessConditions
                        {
                            LeaseAccessConditions = new LeaseAccessConditions
                            {
                                LeaseId = TestHelper.GarbageLeaseId
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

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task CommitBlockListAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var blockName = TestHelper.GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Upload to blockBlobUri, exists when we get the ETag
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(blockName), stream);
                }

                parameters.SourceIfMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.SourceIfMatch);
                var accessConditions = this.BuildHttpAccessConditions(parameters);

                // Act
                var response = await blob.CommitBlockListAsync(
                    base64BlockIDs: new string[] { TestHelper.ToBase64(blockName) },
                    blobAccessConditions: new BlobAccessConditions
                    {
                        HttpAccessConditions = accessConditions
                    });

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        public static IEnumerable<object[]> CommitBlockFromUriAsync_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    SourceIfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    SourceIfUnmodifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    SourceIfMatch = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    SourceIfNoneMatch = TestHelper.ReceivedETag
                }
            }.Select(x => new object[] { x });

        [DataTestMethod]
        [DynamicData(nameof(CommitBlockFromUriAsync_AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task CommitBlockListAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var blockName = TestHelper.GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Upload to blockBlobUri, exists when we get the ETag
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(TestHelper.ToBase64(blockName), stream);
                }

                parameters.SourceIfNoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.SourceIfNoneMatch);
                var accessConditions = this.BuildHttpAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CommitBlockListAsync(
                        base64BlockIDs: new string[] { TestHelper.ToBase64(blockName) },
                        blobAccessConditions: new BlobAccessConditions
                        {
                            HttpAccessConditions = accessConditions
                        }),
                    e => { });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task CommitBlockListAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blockBlobName = TestHelper.GetNewBlobName();
                var blob = container.GetBlockBlobClient(blockBlobName);
                var data = TestHelper.GetRandomBuffer(Size);
                var commitList = new string[]
                {
                    TestHelper.ToBase64(TestHelper.GetNewBlockName())
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

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetBlockListAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);

                // Upload to blockBlobUri, so it exists
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var blockId0 = TestHelper.ToBase64(TestHelper.GetNewBlockName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(blockId0, stream);
                }
                await blob.CommitBlockListAsync(new string[] { blockId0 });

                var blockId1 = TestHelper.ToBase64(TestHelper.GetNewBlobName());
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

        public static IEnumerable<object[]> GetBlockListAsync_Type_Data
            => new[]
            {
                new GetBlockListParameters
                {
                    BlockListType = BlockListType.All,
                    CommittedCount = 1,
                    UncommittedCount = 1
                },
                new GetBlockListParameters
                {
                    BlockListType = BlockListType.Committed,
                    CommittedCount = 1,
                    UncommittedCount = 0
                },
                new GetBlockListParameters
                {
                    BlockListType = BlockListType.Uncommitted,
                    CommittedCount = 0,
                    UncommittedCount = 1
                }
            }.Select(x => new object[] { x });

        [DataTestMethod]
        [DynamicData(nameof(GetBlockListAsync_Type_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task GetBlockListAsync_Type(GetBlockListParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);

                // Upload to blockBlobUri, so it exists
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var blockId0 = TestHelper.ToBase64(TestHelper.GetNewBlockName());
                using (var stream = new MemoryStream(data))
                {
                    await blob.StageBlockAsync(blockId0, stream);
                }
                await blob.CommitBlockListAsync(new string[] { blockId0 });

                var blockId1 = TestHelper.ToBase64(TestHelper.GetNewBlobName());
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

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetBlockListAsync_Lease()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);

                // Upload to blockBlobUri, so it exists
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var leaseId = await TestHelper.SetupBlobLeaseCondition(blob, TestHelper.ReceivedLeaseId);

                // Act
                var response = await blob.GetBlockListAsync(
                    leaseAccessConditions: new LeaseAccessConditions
                    {
                        LeaseId = leaseId
                    });
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetBlockListAsync_LeaseFail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);

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
                            LeaseId = TestHelper.GarbageLeaseId
                        }),
                    e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode.Split('\n')[0]));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetBlockListAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blockBlobName = TestHelper.GetNewBlobName();
                var blob = container.GetBlockBlobClient(blockBlobName);

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

        [TestMethod]
        [TestCategory("Live")]
        public async Task UploadAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blockBlobName = TestHelper.GetNewBlobName();
                var blob = container.GetBlockBlobClient(blockBlobName);
                var data = TestHelper.GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(
                        content: stream);
                }

                // Assert
                var listBlobsFlatResult = await container.ListBlobsFlatSegmentAsync();
                Assert.IsNull(listBlobsFlatResult.Value.Marker);
                Assert.AreEqual(1, listBlobsFlatResult.Value.BlobItems.Count());
                Assert.AreEqual(blockBlobName, listBlobsFlatResult.Value.BlobItems.First().Name);

                var downloadResponse = await blob.DownloadAsync();
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                Assert.IsTrue(data.SequenceEqual(actual.ToArray()));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task UploadAsync_Metadata()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var metadata = TestHelper.BuildMetadata();

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(
                        content: stream,
                        metadata: metadata);
                }

                // Assert
                var response = await blob.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task UploadAsync_Headers()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var contentMD5 = MD5.Create().ComputeHash(data);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(
                        content: stream,
                        blobHttpHeaders: new BlobHttpHeaders
                        {
                            CacheControl = TestConstants.CacheControl,
                            ContentDisposition = TestConstants.ContentDisposition,
                            ContentEncoding = new string[] { TestConstants.ContentEncoding },
                            ContentLanguage = new string[] { TestConstants.ContentLanguage },
                            ContentHash = contentMD5
                        });
                }

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(TestConstants.CacheControl, response.Value.CacheControl);
                Assert.AreEqual(TestConstants.ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(TestConstants.ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(TestConstants.ContentLanguage, response.Value.ContentLanguage.First());
                Assert.IsTrue(contentMD5.ToList().SequenceEqual(response.Value.ContentHash.ToList()));
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AccessConditions_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task UploadAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var blockName = TestHelper.GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.SourceIfMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.SourceIfMatch);
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

        [DataTestMethod]
        [DynamicData(nameof(AccessConditionsFail_Data), DynamicDataSourceType.Property)]
        [TestCategory("Live")]
        public async Task UploadAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Size);
                var blockName = TestHelper.GetNewBlockName();

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.SourceIfNoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.SourceIfNoneMatch);
                var accessConditions = this.BuildHttpAccessConditions(parameters);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException, Response<BlobContentInfo>>(
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

        [TestMethod]
        [TestCategory("Live")]
        public async Task UploadAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetBlockBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Constants.KB);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException, Response<BlobContentInfo>>(
                        blob.UploadAsync(
                            content: stream,
                            blobAccessConditions: new BlobAccessConditions
                            {
                                LeaseAccessConditions = new LeaseAccessConditions
                                {
                                    LeaseId = TestHelper.GarbageLeaseId
                                }
                            }),
                        e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode.Split('\n')[0]));
                }
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task UploadAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;

            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var credentials = new SharedKeyCredentials(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey);
                var containerFaulty = new BlobContainerClient(
                    container.Uri,
                    TestHelper.GetFaultyBlobConnectionOptions(credentials));

                var blockBlobName = TestHelper.GetNewBlobName();
                var blobFaulty = containerFaulty.GetBlockBlobClient(blockBlobName);
                var blob = container.GetBlockBlobClient(blockBlobName);
                var data = TestHelper.GetRandomBuffer(blobSize);

                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.UploadAsync(stream, null, metadata, null, progressHandler: progressHandler);

                    await Task.Delay(1000); // wait 1s to allow lingering progress events to execute

                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");

                    var lastProgress = progressList.Last();

                    Assert.AreEqual(data.LongLength, lastProgress.BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var listBlobsFlatResult = await container.ListBlobsFlatSegmentAsync();
                Assert.IsNull(listBlobsFlatResult.Value.Marker);
                Assert.AreEqual(1, listBlobsFlatResult.Value.BlobItems.Count());
                Assert.AreEqual(blockBlobName, listBlobsFlatResult.Value.BlobItems.First().Name);

                var getPropertiesResponse = await blob.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata);
                Assert.AreEqual(BlobType.BlockBlob, getPropertiesResponse.Value.BlobType);

                var downloadResponse = await blob.DownloadAsync();
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                Assert.IsTrue(data.SequenceEqual(actual.ToArray()));
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

        public static IEnumerable<object[]> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    SourceIfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    SourceIfUnmodifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    SourceIfMatch = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    SourceIfNoneMatch = TestHelper.GarbageETag
                }
            }.Select(x => new object[] { x });

        public static IEnumerable<object[]> AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    SourceIfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    SourceIfUnmodifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    SourceIfMatch = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    SourceIfNoneMatch = TestHelper.ReceivedETag
                }
            }.Select(x => new object[] { x });

        public struct AccessConditionParameters
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
