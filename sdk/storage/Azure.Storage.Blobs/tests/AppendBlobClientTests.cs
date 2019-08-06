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

namespace Azure.Storage.Blobs.Test
{
    public class AppendBlobClientTests : BlobTestBase
    {
        public AppendBlobClientTests(bool async)
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

            var blob = this.InstrumentClient(new AppendBlobClient(connectionString.ToString(true), containerName, blobName, this.GetOptions()));

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

            var blob = this.InstrumentClient(container.GetAppendBlobClient(blobName));

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
        public async Task CreateAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetAppendBlobClient(blobName));

                // Act
                var response = await blob.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                var blobs = await container.GetBlobsAsync().ToListAsync();
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(blobName, blobs.First().Value.Name);
            }
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                var metadata = this.BuildMetadata();

                // Act
                await blob.CreateAsync(
                    metadata: metadata);

                // Assert
                var response = await blob.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        //TODO
        [Ignore("Not yet implemented")]
        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateAsync_Headers()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

        }

        [Test]
        public async Task CreateAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(String.Empty));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CreateAsync(),
                    actualException => Assert.AreEqual("InvalidUri", actualException.ErrorCode)
                    );
            }
        }

        [Test]
        public async Task CreateAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            var data = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = this.OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { Match = this.ReceivedETag },
                new AccessConditionParameters { NoneMatch = this.GarbageETag },
                new AccessConditionParameters { LeaseId = this.ReceivedLeaseId }
            };
            foreach (var parameters in data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                    await blob.CreateAsync();
                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                    var accessConditions = this.BuildDestinationAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    var response = await blob.CreateAsync(accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task CreateAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            var data = new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { Match = this.GarbageETag },
                new AccessConditionParameters { NoneMatch = this.ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (var parameters in data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                    await blob.CreateAsync();
                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    var accessConditions = this.BuildDestinationAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.CreateAsync(accessConditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task AppendBlockAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetAppendBlobClient(blobName));
                await blob.CreateAsync();
                const int blobSize = Constants.KB;
                var data = this.GetRandomBuffer(blobSize);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await blob.AppendBlockAsync(stream);
                }

                // Assert
                var result = await blob.DownloadAsync(new HttpRange(0, data.Length));
                var dataResult = new MemoryStream();
                await result.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(data.Length, dataResult.Length);
                TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
            }
        }

        [Test]
        public async Task AppendBlockAsync_MD5()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                await blob.CreateAsync();
                var data = this.GetRandomBuffer(Constants.KB);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    var response = await blob.AppendBlockAsync(
                        content: stream,
                        transactionalContentHash: MD5.Create().ComputeHash(data));

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task AppendBlockAsync_MD5Fail()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                await blob.CreateAsync();
                var data = this.GetRandomBuffer(Constants.KB);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.AppendBlockAsync(
                            content: stream,
                            transactionalContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garbage"))),
                        e => Assert.AreEqual("Md5Mismatch", e.ErrorCode.Split('\n')[0]));
                }
            }
        }

        [Test]
        public async Task AppendBlockAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Constants.KB);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.AppendBlockAsync(stream),
                        e => Assert.AreEqual("BlobNotFound", e.ErrorCode.Split('\n')[0]));
                }
            }
        }

        [Test]
        public async Task AppendBlockAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            var testCases = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = this.OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { Match = this.ReceivedETag },
                new AccessConditionParameters { NoneMatch = this.GarbageETag },
                new AccessConditionParameters { LeaseId = this.ReceivedLeaseId },
                new AccessConditionParameters { AppendPosE = 0 },
                new AccessConditionParameters { MaxSizeLTE = 100 }
            };
            foreach (var parameters in testCases)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob =  this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await blob.CreateAsync();
                    var data = this.GetRandomBuffer(7);
                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                    var accessConditions = this.BuildDestinationAccessConditions(
                        parameters: parameters,
                        lease: true,
                        appendPosAndMaxSize: true);

                    // Act
                    using (var stream = new MemoryStream(data))
                    {
                        var response = await blob.AppendBlockAsync(
                            content: stream,
                            accessConditions: accessConditions);

                        // Assert
                        Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                    }
                }
            }
        }

        [Test]
        public async Task AppendBlockAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            var testCases = new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { Match = this.GarbageETag },
                new AccessConditionParameters { NoneMatch = this.ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { AppendPosE = 1 },
                new AccessConditionParameters { MaxSizeLTE = 1 }
            };
            foreach (var parameters in testCases)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    var data = this.GetRandomBuffer(7);
                    // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                    await blob.CreateAsync();
                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    var accessConditions = this.BuildDestinationAccessConditions(
                        parameters: parameters,
                        lease: true,
                        appendPosAndMaxSize: true);

                    // Act
                    using (var stream = new MemoryStream(data))
                    {
                        await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                            blob.AppendBlockAsync(
                                content: stream,
                                accessConditions: accessConditions),
                            e => { });
                    }
                }
            }
        }

        [Test]
        public async Task AppendBlockAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;

            using (this.GetNewContainer(out var container))
            {
                var containerFaulty = this.InstrumentClient(
                    new BlobContainerClient(
                        container.Uri,
                        new StorageSharedKeyCredential(
                            this.TestConfigDefault.AccountName,
                            this.TestConfigDefault.AccountKey),
                        this.GetFaultyBlobConnectionOptions()));

                // Arrange
                var blobName = this.GetNewBlobName();
                var blobFaulty = this.InstrumentClient(containerFaulty.GetAppendBlobClient(blobName));
                var blob = this.InstrumentClient(container.GetAppendBlobClient(blobName));

                await blob.CreateAsync();

                var data = this.GetRandomBuffer(blobSize);
                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.AppendBlockAsync(stream, progressHandler: progressHandler);
                    await this.WaitForProgressAsync(progressList, data.LongLength);
                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                    // Changing from Assert.AreEqual because these don't always update fast enough
                    Assert.GreaterOrEqual(data.LongLength, progressList.Last().BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var downloadResponse = await blob.DownloadAsync();
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_Min()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await destBlob.CreateAsync();

                    // Act
                    await destBlob.AppendBlockFromUriAsync(sourceBlob.Uri, new HttpRange(0, Constants.KB));
                }
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_Range()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = this.GetRandomBuffer(4 * Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await destBlob.CreateAsync();

                    // Act
                    await destBlob.AppendBlockFromUriAsync(sourceBlob.Uri, new HttpRange(2 * Constants.KB, 2 * Constants.KB));

                    // Assert
                    var result = await destBlob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
                    var dataResult = new MemoryStream();
                    await result.Value.Content.CopyToAsync(dataResult);
                    Assert.AreEqual(2 * Constants.KB, dataResult.Length);
                    TestHelper.AssertSequenceEqual(data.Skip(2 * Constants.KB).Take(2 * Constants.KB), dataResult.ToArray());
                }
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_MD5()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await destBlob.CreateAsync();

                    // Act
                    await destBlob.AppendBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        sourceContentHash: MD5.Create().ComputeHash(data));
                }
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_MD5_Fail()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                    await destBlob.CreateAsync();

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        destBlob.AppendBlockFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            sourceContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garabage"))),
                        actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
                    );
                }
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            var testCases = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = this.OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { Match = this.ReceivedETag },
                new AccessConditionParameters { NoneMatch = this.GarbageETag },
                new AccessConditionParameters { LeaseId = this.ReceivedLeaseId },
                new AccessConditionParameters { AppendPosE = 0 },
                new AccessConditionParameters { MaxSizeLTE = 100 },
                new AccessConditionParameters { SourceIfModifiedSince = this.OldDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { SourceIfMatch = this.ReceivedETag },
                new AccessConditionParameters { SourceIfNoneMatch = this.GarbageETag }
            };
            foreach (var parameters in testCases)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    await container.SetAccessPolicyAsync(PublicAccessType.Container);

                    var data = this.GetRandomBuffer(7);

                    using (var stream = new MemoryStream(data))
                    {
                        var sourceBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                        await sourceBlob.CreateAsync();
                        await sourceBlob.AppendBlockAsync(stream);

                        var destBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                        await destBlob.CreateAsync();

                        parameters.Match = await this.SetupBlobMatchCondition(destBlob, parameters.Match);
                        parameters.SourceIfMatch = await this.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                        parameters.LeaseId = await this.SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                        var accessConditions = this.BuildDestinationAccessConditions(
                            parameters: parameters,
                            lease: true,
                            appendPosAndMaxSize: true);
                        var sourceAccessConditions = this.BuildSourceAccessConditions(parameters);

                        // Act
                        await destBlob.AppendBlockFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            accessConditions: accessConditions,
                            sourceAccessConditions: sourceAccessConditions);
                    }
                }
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            var testCases = new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { Match = this.GarbageETag },
                new AccessConditionParameters { NoneMatch = this.ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { AppendPosE = 1 },
                new AccessConditionParameters { MaxSizeLTE = 1 },
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
                    await container.SetAccessPolicyAsync(PublicAccessType.Container);

                    var data = this.GetRandomBuffer(7);

                    using (var stream = new MemoryStream(data))
                    {
                        var sourceBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                        await sourceBlob.CreateAsync();
                        await sourceBlob.AppendBlockAsync(stream);

                        var destBlob = this.InstrumentClient(container.GetAppendBlobClient(this.GetNewBlobName()));
                        await destBlob.CreateAsync();

                        parameters.NoneMatch = await this.SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                        parameters.SourceIfNoneMatch = await this.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);

                        var accessConditions = this.BuildDestinationAccessConditions(
                            parameters: parameters,
                            lease: true,
                            appendPosAndMaxSize: true);
                        var sourceAccessConditions = this.BuildSourceAccessConditions(parameters);

                        // Act
                        await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                            destBlob.AppendBlockFromUriAsync(
                                sourceUri: sourceBlob.Uri,
                                accessConditions: accessConditions,
                                sourceAccessConditions: sourceAccessConditions),
                            actualException => Assert.IsTrue(true)
                        );
                    }
                }
            }
        }

        private AppendBlobAccessConditions BuildDestinationAccessConditions(
            AccessConditionParameters parameters,
            bool lease = false,
            bool appendPosAndMaxSize = false)
        {
            var accessConditions = new AppendBlobAccessConditions
            {
                HttpAccessConditions = new HttpAccessConditions
                {
                    IfMatch = parameters.Match != null ? new ETag(parameters.Match) : default(ETag?),
                    IfNoneMatch = parameters.NoneMatch != null ? new ETag(parameters.NoneMatch) : default(ETag?),
                    IfModifiedSince = parameters.IfModifiedSince,
                    IfUnmodifiedSince = parameters.IfUnmodifiedSince
                }
            };

            if(lease)
            {
                accessConditions.LeaseAccessConditions = new LeaseAccessConditions
                {
                    LeaseId = parameters.LeaseId
                };
            }

            if(appendPosAndMaxSize)
            {
                accessConditions.IfAppendPositionEqual = parameters.AppendPosE;
                accessConditions.IfMaxSizeLessThanOrEqual = parameters.MaxSizeLTE;
            }

            return accessConditions;
        }

        private AppendBlobAccessConditions BuildSourceAccessConditions(AccessConditionParameters parameters)
            => new AppendBlobAccessConditions
        {
            HttpAccessConditions = new HttpAccessConditions
            {
                IfMatch = parameters.SourceIfMatch != null ? new ETag(parameters.SourceIfMatch) : default(ETag?),
                IfNoneMatch = parameters.SourceIfNoneMatch != null ? new ETag(parameters.SourceIfNoneMatch) : default(ETag?),
                IfModifiedSince = parameters.SourceIfModifiedSince,
                IfUnmodifiedSince = parameters.SourceIfUnmodifiedSince
            },
        };

        public class AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string Match { get; set; }
            public string NoneMatch { get; set; }
            public string LeaseId { get; set; }
            public long? AppendPosE { get; set; }
            public long? MaxSizeLTE { get; set; }
            public DateTimeOffset? SourceIfModifiedSince { get; set; }
            public DateTimeOffset? SourceIfUnmodifiedSince { get; set; }
            public string SourceIfMatch { get; set; }
            public string SourceIfNoneMatch { get; set; }
        }
    }
}
