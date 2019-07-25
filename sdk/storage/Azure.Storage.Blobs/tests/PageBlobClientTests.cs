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
    public class PageBlobClientTests : BlobTestBase
    {
        const string CacheControl = "control";
        const string ContentDisposition = "disposition";
        const string ContentEncoding = "encoding";
        const string ContentLanguage = "language";
        const string ContentType = "type";

        public PageBlobClientTests(bool async)
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

            var blob = this.InstrumentClient(new PageBlobClient(connectionString.ToString(true), containerName, blobName, this.GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task CreateAsync_Min()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                // Act
                var response = await blob.CreateAsync(Constants.KB);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task CreateAsync_SequenceNumber()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                // Act
                await blob.CreateAsync(
                    size: Constants.KB,
                    sequenceNumber: 2);

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(2, response.Value.BlobSequenceNumber);
            }
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var metadata = this.BuildMetadata();
                var blob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                // Act
                await blob.CreateAsync(Constants.KB, metadata: metadata);

                // Assert
                var getPropertiesResponse = await blob.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata);
                Assert.AreEqual(BlobType.PageBlob, getPropertiesResponse.Value.BlobType);
            }
        }

        /// <summary>
        /// Data for CreateAsync, GetPageRangesAsync, GetPageRangesDiffAsync, ResizeAsync, and 
        /// UpdateSequenceNumber AccessConditions tests
        /// </summary>
        public IEnumerable<AccessConditionParameters> Reduced_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = this.OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { Match = this.ReceivedETag },
                new AccessConditionParameters { NoneMatch = this.GarbageETag },
                new AccessConditionParameters { LeaseId = this.ReceivedLeaseId }
            };

        [Test]
        public async Task CreateAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.Reduced_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    // This PageBlob is intentionally created twice to test the PageBlobAccessConditions
                    var blob = await this.CreatePageBlobClientAsync(container, Constants.KB);

                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    var response = await blob.CreateAsync(
                        size: Constants.KB,
                        accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        /// <summary>
        /// Data for CreateAsync, GetPageRangesAsync, and GetPageRangesDiffAsync AccessConditions Fail tests
        /// </summary>
        public IEnumerable<AccessConditionParameters> GetReduced_AccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { Match = this.GarbageETag },
                new AccessConditionParameters { NoneMatch = this.ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };

        [Test]
        public async Task CreateAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    // This PageBlob is intentionally created twice to test the PageBlobAccessConditions
                    var blob = await this.CreatePageBlobClientAsync(container, Constants.KB);

                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.CreateAsync(
                            size: Constants.KB,
                            accessConditions: accessConditions),
                        actualException => Assert.IsTrue(true));
                }
            }
        }

        [Test]
        public async Task CreateAsync_Headers()
        {
            var contentMD5 = MD5.Create().ComputeHash(this.GetRandomBuffer(16));
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var headers = new BlobHttpHeaders
                {
                    ContentType = ContentType,
                    ContentHash = contentMD5,
                    ContentEncoding = new string[] { ContentEncoding },
                    ContentLanguage = new string[] { ContentLanguage },
                    ContentDisposition = ContentDisposition,
                    CacheControl = CacheControl
                };
                var blob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                // Act
                await blob.CreateAsync(
                    size: Constants.KB,
                    httpHeaders: headers);

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(ContentType, response.Value.ContentType);
                TestHelper.AssertSequenceEqual(contentMD5, response.Value.ContentHash);
                Assert.AreEqual(1, response.Value.ContentEncoding.Count());
                Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(1, response.Value.ContentLanguage.Count());
                Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage.First());
                Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var invalidPageSize = 511;
                var blob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CreateAsync(invalidPageSize),
                    e =>
                    {
                        Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                        Assert.AreEqual("The value for one of the HTTP headers is not in the correct format.", 
                            e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task UploadPagesAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    // Act
                    await blob.UploadPagesAsync(
                        content: stream, 
                        offset: Constants.KB);
                }

                // Assert
                var expectedData = new byte[4 * Constants.KB];
                data.CopyTo(expectedData, Constants.KB);
                var response = await blob.DownloadAsync(range: new HttpRange(0, 4 * Constants.KB));

                var actualData = new byte[4 * Constants.KB];
                var bytesRead = await response.Value.Content.ReadAsync(actualData, 0, 4 * Constants.KB);
                Assert.AreEqual(expectedData.Length, bytesRead);
                TestHelper.AssertSequenceEqual(expectedData, actualData);
            }
        }

        [Test]
        public async Task UploadPagesAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Act
                var data = this.GetRandomBuffer(Constants.KB);
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.UploadPagesAsync(stream, 5 * Constants.KB),
                        e => Assert.AreEqual("InvalidPageRange", e.ErrorCode));
                }
            }
        }

        public IEnumerable<AccessConditionParameters> UploadClearAsync_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = this.OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { Match = this.ReceivedETag },
                new AccessConditionParameters { NoneMatch = this.GarbageETag },
                new AccessConditionParameters { LeaseId = this.ReceivedLeaseId },
                new AccessConditionParameters { SequenceNumberLT = 5 },
                new AccessConditionParameters { SequenceNumberLTE = 3 },
                new AccessConditionParameters { SequenceNumberEqual = 0 }
           };

        [Test]
        public async Task UploadAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.UploadClearAsync_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, Constants.KB);

                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters, 
                        lease: true, 
                        sequenceNumbers: true);

                    var data = this.GetRandomBuffer(Constants.KB);
                    using (var stream = new MemoryStream(data))
                    {
                        // Act
                        var response = await blob.UploadPagesAsync(
                            content: stream,
                            offset: 0,
                            accessConditions: accessConditions);

                        // Assert
                        Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                    }
                }
            }
        }

        public IEnumerable<AccessConditionParameters> GetUploadClearAsync_AccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { Match = this.GarbageETag },
                new AccessConditionParameters { NoneMatch = this.ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { SequenceNumberLT = -1 },
                new AccessConditionParameters { SequenceNumberLTE = -1 },
                new AccessConditionParameters { SequenceNumberEqual = 100 }
            };

        [Test]
        public async Task UploadAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetUploadClearAsync_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, Constants.KB);

                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true,
                        sequenceNumbers: true);

                    var data = this.GetRandomBuffer(Constants.KB);
                    using (var stream = new MemoryStream(data))
                    {
                        // Act
                        await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                            blob.UploadPagesAsync(
                                content: stream,
                                offset: 0,
                                accessConditions: accessConditions),
                            e => Assert.IsTrue(true));
                    }
                }
            }
        }

        [Test]
        public async Task UploadPagesAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;

            using (this.GetNewContainer(out var container))
            {
                var credentials = new StorageSharedKeyCredential(
                    this.TestConfigDefault.AccountName,
                    this.TestConfigDefault.AccountKey);
                var containerClientFaulty = this.InstrumentClient(
                    new BlobContainerClient(
                        container.Uri,
                        credentials,
                        this.GetFaultyBlobConnectionOptions()));

                // Arrange
                var pageBlobName = this.GetNewBlobName();
                var blobFaulty = this.InstrumentClient(containerClientFaulty.GetPageBlobClient(pageBlobName));
                var blob = this.InstrumentClient(container.GetPageBlobClient(pageBlobName));

                await blob.CreateAsync(blobSize)
                    .ConfigureAwait(false);

                var offset = 0 * Constants.KB;
                var data = this.GetRandomBuffer(blobSize);
                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.UploadPagesAsync(stream, offset, progressHandler: progressHandler);

                    await this.WaitForProgressAsync(progressList, data.LongLength);
                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                    // Changing from Assert.AreEqual because these don't always update fast enough
                    Assert.GreaterOrEqual(data.LongLength, progressList.Last().BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var downloadResponse = await blob.DownloadAsync(
                    new HttpRange(offset, data.LongLength));
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task ClearPagesAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var data = this.GetRandomBuffer(4 * Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 0);
                }

                // Act
                await blob.ClearPagesAsync(range: new HttpRange(Constants.KB, Constants.KB));

                // Assert
                var expectedData = new byte[4 * Constants.KB];
                Array.Copy(data, expectedData, 4 * Constants.KB);
                Array.Clear(expectedData, Constants.KB, Constants.KB);
                var downloadResponse = await blob.DownloadAsync();
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
            }
        }

        [Test]
        public async Task ClearPagesAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.ClearPagesAsync(range: new HttpRange(5 * Constants.KB, Constants.KB)),
                    e =>
                    {
                        Assert.AreEqual("InvalidPageRange", e.ErrorCode);
                        Assert.AreEqual("The page range specified is invalid.", e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task ClearPagesAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.UploadClearAsync_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, Constants.KB);

                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true,
                        sequenceNumbers: true);

                    var response = await blob.ClearPagesAsync(
                        range: new HttpRange(0, Constants.KB),
                        accessConditions: accessConditions);

                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task ClearAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetUploadClearAsync_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, Constants.KB);

                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true,
                        sequenceNumbers: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.ClearPagesAsync(
                            range: new HttpRange(0, Constants.KB),
                            accessConditions: accessConditions),
                        e => Assert.IsTrue(true));
                }
            }
        }

        [Test]
        public async Task GetPageRangesAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 0);

                }
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 2 * Constants.KB);
                }

                // Act
                var result = await blob.GetPageRangesAsync(range: new HttpRange(0, 4 * Constants.KB));

                // Assert
                Assert.AreEqual(2, result.Value.Body.PageRange.Count());
                Assert.AreEqual(0, result.Value.Body.PageRange.First().Start);
                Assert.AreEqual(Constants.KB - 1, result.Value.Body.PageRange.First().End);
                Assert.AreEqual(2 * Constants.KB, result.Value.Body.PageRange.ElementAt(1).Start);
                Assert.AreEqual((3 * Constants.KB) - 1, result.Value.Body.PageRange.ElementAt(1).End);
            }
        }

        [Test]
        public async Task GetPageRangesAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.GetPageRangesAsync(range: new HttpRange(5 * Constants.KB, 4 * Constants.KB)),
                    e =>
                    {
                        Assert.AreEqual("InvalidRange", e.ErrorCode);
                        Assert.AreEqual("The range specified is invalid for the current size of the resource.", 
                            e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task GetPageRangesAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.Reduced_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    var response = await blob.GetPageRangesAsync(
                        range: new HttpRange(0, Constants.KB),
                        accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.Value.Body.PageRange);
                }
            }
        }

        [Test]
        public async Task GetPageRangesAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.GetPageRangesAsync(
                            range: new HttpRange(0, Constants.KB),
                            accessConditions: accessConditions),
                        actualException => Assert.IsTrue(true));
                }
            }
        }

        [Test]
        public async Task GetPageRangesDiffAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Upload some Pages
                var data = this.GetRandomBuffer(Constants.KB);
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 0);
                }

                // Create prevSnapshot
                var response = await blob.CreateSnapshotAsync();
                var prevSnapshot = response.Value.Snapshot;

                // Upload additional Pages
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadPagesAsync(stream, 2 * Constants.KB);
                }

                // create snapshot
                response = await blob.CreateSnapshotAsync();
                var snapshot = response.Value.Snapshot;

                // Act
                var result = await blob.GetPageRangesDiffAsync(
                    range: new HttpRange(0, 4 * Constants.KB), 
                    snapshot, 
                    prevSnapshot);

                // Assert
                Assert.AreEqual(1, result.Value.Body.PageRange.Count());
                Assert.AreEqual(2 * Constants.KB, result.Value.Body.PageRange.First().Start);
                Assert.AreEqual((3 * Constants.KB) - 1, result.Value.Body.PageRange.First().End);
            }
        }

        [Test]
        public async Task GetPageRangesDiffAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.GetPageRangesDiffAsync(range: new HttpRange(5 * Constants.KB, 4 * Constants.KB)),
                    e =>
                    {
                        Assert.AreEqual("InvalidRange", e.ErrorCode);
                        Assert.AreEqual("The range specified is invalid for the current size of the resource.", 
                            e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task GetPageRangesDiffAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.Reduced_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                    // Upload some Pages
                    var data = this.GetRandomBuffer(Constants.KB);
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadPagesAsync(stream, 0);
                    }

                    // Create prevSnapshot
                    var snapshotCreateResult = await blob.CreateSnapshotAsync();
                    var prevSnapshot = snapshotCreateResult.Value.Snapshot;

                    // Upload additional Pages
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadPagesAsync(stream, 2 * Constants.KB);
                    }

                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    var response = await blob.GetPageRangesDiffAsync(
                        range: new HttpRange(0, Constants.KB),
                        previousSnapshot: prevSnapshot,
                        accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.Value.Body.PageRange);
                }
            }
        }

        [Test]
        public async Task GetPageRangesDiffAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                    // Upload some Pages
                    var data = this.GetRandomBuffer(Constants.KB);
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadPagesAsync(stream, 0);
                    }

                    // Create prevSnapshot
                    var response = await blob.CreateSnapshotAsync();
                    var prevSnapshot = response.Value.Snapshot;

                    // Upload additional Pages
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadPagesAsync(stream, 2 * Constants.KB);
                    }

                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.GetPageRangesDiffAsync(
                            range: new HttpRange(0, Constants.KB),
                            previousSnapshot: prevSnapshot,
                            accessConditions: accessConditions),
                        e => Assert.IsTrue(true));
                }
            }
        }

        [Test]
        public async Task ResizeAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var newSize = 8 * Constants.KB;

                // Act
                var result = await blob.ResizeAsync(size: newSize);

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(newSize, response.Value.ContentLength);
            }
        }

        [Test]
        public async Task ResizeAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var invalidSize = 511;

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.ResizeAsync(size: invalidSize),
                    e =>
                    {
                        Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                        Assert.AreEqual("The value for one of the HTTP headers is not in the correct format.", 
                            e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task ResizeAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.Reduced_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                    var newSize = 8 * Constants.KB;

                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    var response = await blob.ResizeAsync(
                        size: newSize,
                        accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task ResizeAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                    var newSize = 8 * Constants.KB;

                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.ResizeAsync(
                            size: newSize,
                            accessConditions: accessConditions),
                        e => Assert.IsTrue(true));
                }
            }
        }

        [Test]
        public async Task UpdateSequenceNumberAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                long sequenceAccessNumber = 5;

                // Act
                await blob.UpdateSequenceNumberAsync(
                    action: SequenceNumberAction.Update,
                    sequenceNumber: sequenceAccessNumber);

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(sequenceAccessNumber, response.Value.BlobSequenceNumber);
            }
        }

        [Test]
        public async Task UpdateSequenceNumberAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.Reduced_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                    long sequenceAccessNumber = 5;

                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);
                    parameters.LeaseId = await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    var response = await blob.UpdateSequenceNumberAsync(
                        action: SequenceNumberAction.Update,
                        sequenceNumber: sequenceAccessNumber,
                        accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task UpdateSequenceNumberAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                    long sequenceAccessNumber = 5;

                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.UpdateSequenceNumberAsync(
                            action: SequenceNumberAction.Update,
                            sequenceNumber: sequenceAccessNumber,
                            accessConditions: accessConditions),
                        e => Assert.IsTrue(true));
                }
            }
        }

        [Test]
        public async Task UpdateSequenceNumberAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.UpdateSequenceNumberAsync(
                        action: SequenceNumberAction.Update,
                        sequenceNumber: -1),
                    e =>
                    {
                        Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                        Assert.AreEqual("The value for one of the HTTP headers is not in the correct format.",
                            e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task StartCopyIncrementalAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);
                var data = this.GetRandomBuffer(Constants.KB);
                var expectedData = new byte[4 * Constants.KB];
                data.CopyTo(expectedData, 0);

                // Create Page Blob
                var sourceBlob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Update data to firstPageBlob
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadPagesAsync(stream, Constants.KB);
                }

                // Create Snapshot
                var snapshotResponse = await sourceBlob.CreateSnapshotAsync();

                var snapshot = snapshotResponse.Value.Snapshot;

                var destinationBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                // Act
                var operation = await destinationBlob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    snapshot: snapshot);
                if (this.Mode == RecordedTestMode.Playback)
                {
                    operation.PollingInterval = TimeSpan.FromMilliseconds(10);
                }
                await operation.WaitCompletionAsync();

                // Assert

                var properties = await destinationBlob.GetPropertiesAsync();

                Assert.AreEqual(CopyStatus.Success, properties.Value.CopyStatus);
            }
        }

        [Test]
        public async Task StartCopyIncrementalAsync_Error()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var sourceBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.StartCopyIncrementalAsync(
                        sourceUri: sourceBlob.Uri,
                        // dummy snapshot value.
                        snapshot: "2019-03-29T18:12:15.6608647Z"),
                    e =>
                    {
                        Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode);
                        Assert.AreEqual("The specified blob does not exist.", e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task StartCopyIncrementalAsync_AccessConditions()
        {
            foreach (var parameters in this.Reduced_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    await container.SetAccessPolicyAsync(PublicAccessType.Container);
                    var data = this.GetRandomBuffer(Constants.KB);
                    var expectedData = new byte[4 * Constants.KB];
                    data.CopyTo(expectedData, 0);

                    // Create sourceBlob
                    var sourceBlob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                    // Update data to sourceBlob
                    using (var stream = new MemoryStream(data))
                    {
                        await sourceBlob.UploadPagesAsync(stream, Constants.KB);
                    }

                    // Create Snapshot
                    var snapshotResponse = await sourceBlob.CreateSnapshotAsync();

                    var snapshot = snapshotResponse.Value.Snapshot;

                    var blob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                    var operation = await blob.StartCopyIncrementalAsync(
                        sourceUri: sourceBlob.Uri,
                        snapshot: snapshot);
                    if (this.Mode == RecordedTestMode.Playback)
                    {
                        operation.PollingInterval = TimeSpan.FromMilliseconds(10);
                    }
                    await operation.WaitCompletionAsync();

                    parameters.Match = await this.SetupBlobMatchCondition(blob, parameters.Match);

                    var accessConditions = this.BuildAccessConditions(parameters: parameters);

                    snapshotResponse = await sourceBlob.CreateSnapshotAsync();
                    snapshot = snapshotResponse.Value.Snapshot;

                    // Act
                    var response = await blob.StartCopyIncrementalAsync(
                        sourceUri: sourceBlob.Uri,
                        snapshot: snapshot,
                        accessConditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task StartCopyIncrementalAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetReduced_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    await container.SetAccessPolicyAsync(PublicAccessType.Container);
                    var data = this.GetRandomBuffer(Constants.KB);
                    var expectedData = new byte[4 * Constants.KB];
                    data.CopyTo(expectedData, 0);

                    // Create sourceBlob
                    var sourceBlob = await this.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                    // Update data to sourceBlob
                    using (var stream = new MemoryStream(data))
                    {
                        await sourceBlob.UploadPagesAsync(stream, Constants.KB);
                    }

                    // Create Snapshot
                    var snapshotResponse = await sourceBlob.CreateSnapshotAsync();

                    var snapshot = snapshotResponse.Value.Snapshot;

                    var blob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));

                    var operation = await blob.StartCopyIncrementalAsync(
                        sourceUri: sourceBlob.Uri,
                        snapshot: snapshot);
                    if (this.Mode == RecordedTestMode.Playback)
                    {
                        operation.PollingInterval = TimeSpan.FromMilliseconds(10);
                    }
                    await operation.WaitCompletionAsync();

                    parameters.NoneMatch = await this.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                    await this.SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);

                    var accessConditions = this.BuildAccessConditions(parameters: parameters);

                    snapshotResponse = await sourceBlob.CreateSnapshotAsync();
                    snapshot = snapshotResponse.Value.Snapshot;

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.StartCopyIncrementalAsync(
                            sourceUri: sourceBlob.Uri,
                            snapshot: snapshot,
                            accessConditions: accessConditions),
                        e => Assert.IsTrue(true));
                }
            }
        }

        [Test]
        public async Task UploadPagesFromUriAsync_Min()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                    await destBlob.CreateAsync(Constants.KB);
                    var range = new HttpRange(0, Constants.KB);

                    // Act
                    await destBlob.UploadPagesFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        sourceRange: range,
                        range: range);
                }
            }
        }

        [Test]
        public async Task UploadPagesFromUriAsync_Range()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = this.GetRandomBuffer(4 * Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                    await sourceBlob.CreateAsync(4 * Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                    await destBlob.CreateAsync(2 * Constants.KB);
                    var range = new HttpRange(0, 2 * Constants.KB);

                    // Act
                    await destBlob.UploadPagesFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        sourceRange: new HttpRange(2 * Constants.KB, 2 * Constants.KB),
                        range: range);

                    // Assert
                    var response = await destBlob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
                    var dataResult = new MemoryStream();
                    await response.Value.Content.CopyToAsync(dataResult);
                    Assert.AreEqual(2 * Constants.KB, dataResult.Length);
                    TestHelper.AssertSequenceEqual(data.Skip(2 * Constants.KB).Take(2 * Constants.KB), dataResult.ToArray());
                }
            }
        }

        [Test]
        public async Task UploadPagesFromUriAsync_MD5()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                    await destBlob.CreateAsync(Constants.KB);
                    var range = new HttpRange(0, Constants.KB);

                    // Act
                    await destBlob.UploadPagesFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        sourceRange: range,
                        range: range,
                        sourceContentHash: MD5.Create().ComputeHash(data));
                }
            }
        }

        [Test]
        public async Task UploadPagesFromUriAsync_MD5_Fail()
        {
            using (this.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                    await destBlob.CreateAsync(Constants.KB);
                    var range = new HttpRange(0, Constants.KB);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        destBlob.UploadPagesFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            sourceRange: range,
                            range: range,
                            sourceContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garabage"))),
                        actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
                    );
                }
            }
        }

        public IEnumerable<AccessConditionParameters> UploadPagesFromUriAsync_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = this.OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { Match = this.ReceivedETag },
                new AccessConditionParameters { NoneMatch = this.GarbageETag },
                new AccessConditionParameters { LeaseId = this.ReceivedLeaseId },
                new AccessConditionParameters { SequenceNumberLT = 5 },
                new AccessConditionParameters { SequenceNumberLTE = 3 },
                new AccessConditionParameters { SequenceNumberEqual = 0 },
                new AccessConditionParameters { SourceIfModifiedSince = this.OldDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = this.NewDate },
                new AccessConditionParameters { SourceIfMatch = this.ReceivedETag },
                new AccessConditionParameters { SourceIfNoneMatch = this.GarbageETag }
            };

        [Test]
        public async Task UploadPagesFromUriAsync_AccessConditions()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.UploadPagesFromUriAsync_AccessConditions_Data)
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    await container.SetAccessPolicyAsync(PublicAccessType.Container);

                    var data = this.GetRandomBuffer(Constants.KB);

                    using (var stream = new MemoryStream(data))
                    {
                        var sourceBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                        await sourceBlob.CreateAsync(Constants.KB);
                        await sourceBlob.UploadPagesAsync(stream, 0);

                        var destBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                        await destBlob.CreateAsync(Constants.KB);

                        parameters.Match = await this.SetupBlobMatchCondition(destBlob, parameters.Match);
                        parameters.SourceIfMatch = await this.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                        parameters.LeaseId = await this.SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                        var accessConditions = this.BuildAccessConditions(
                            parameters: parameters,
                            lease: true,
                            sequenceNumbers: true);
                        var sourceAccessConditions = this.BuildSourceAccessConditions(parameters);

                        var range = new HttpRange(0, Constants.KB);

                        // Act
                        await destBlob.UploadPagesFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            sourceRange: range,
                            range: range,
                            accessConditions: accessConditions,
                            sourceAccessConditions: sourceAccessConditions);
                    }
                }
            }
        }

        public IEnumerable<AccessConditionParameters> GetUploadPagesFromUriAsync_AccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = this.NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { Match = this.GarbageETag },
                new AccessConditionParameters { NoneMatch = this.ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { SequenceNumberLT = -1 },
                new AccessConditionParameters { SequenceNumberLTE = -1 },
                new AccessConditionParameters { SequenceNumberEqual = 100 },
                new AccessConditionParameters { SourceIfModifiedSince = this.NewDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = this.OldDate },
                new AccessConditionParameters { SourceIfMatch = this.GarbageETag },
                new AccessConditionParameters { SourceIfNoneMatch = this.ReceivedETag }
            };

        [Test]
        public async Task UploadPagesFromUriAsync_AccessConditionsFail()
        {
            var garbageLeaseId = this.GetGarbageLeaseId();
            foreach (var parameters in this.GetUploadPagesFromUriAsync_AccessConditionsFail_Data(garbageLeaseId))
            {
                using (this.GetNewContainer(out var container))
                {
                    // Arrange
                    await container.SetAccessPolicyAsync(PublicAccessType.Container);

                    var data = this.GetRandomBuffer(Constants.KB);

                    using (var stream = new MemoryStream(data))
                    {
                        var sourceBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                        await sourceBlob.CreateAsync(Constants.KB);
                        await sourceBlob.UploadPagesAsync(stream, 0);

                        var destBlob = this.InstrumentClient(container.GetPageBlobClient(this.GetNewBlobName()));
                        await destBlob.CreateAsync(Constants.KB);

                        parameters.NoneMatch = await this.SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                        parameters.SourceIfNoneMatch = await this.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);

                        var accessConditions = this.BuildAccessConditions(
                            parameters: parameters,
                            lease: true,
                            sequenceNumbers: true);
                        var sourceAccessConditions = this.BuildSourceAccessConditions(parameters);

                        var range = new HttpRange(0, Constants.KB);

                        // Act
                        await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                            destBlob.UploadPagesFromUriAsync(
                                sourceUri: sourceBlob.Uri,
                                sourceRange: range,
                                range: range,
                                accessConditions: accessConditions,
                                sourceAccessConditions: sourceAccessConditions),
                            actualException => Assert.IsTrue(true)
                        );
                    }
                }
            }
        }

        [Test]
        public void WithSnapshot()
        {
            var containerName = this.GetNewContainerName();
            var blobName = this.GetNewBlobName();

            var service = this.GetServiceClient_SharedKey();

            var container = this.InstrumentClient(service.GetBlobContainerClient(containerName));

            var blob = this.InstrumentClient(container.GetPageBlobClient(blobName));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);

            blob = this.InstrumentClient(blob.WithSnapshot("foo"));

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            blob = this.InstrumentClient(blob.WithSnapshot(null));

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        private PageBlobAccessConditions BuildAccessConditions(
            AccessConditionParameters parameters, 
            bool lease = false, 
            bool sequenceNumbers = false)
        {
            var accessConditions = new PageBlobAccessConditions
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

            if(sequenceNumbers)
            {
                accessConditions.IfSequenceNumberLessThan = parameters.SequenceNumberLT;
                accessConditions.IfSequenceNumberEqual = parameters.SequenceNumberEqual;
                accessConditions.IfSequenceNumberLessThanOrEqual = parameters.SequenceNumberLTE;
            }

            return accessConditions;
        }

        private PageBlobAccessConditions BuildSourceAccessConditions(AccessConditionParameters parameters)
            =>  new PageBlobAccessConditions
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
            public long? SequenceNumberLT { get; set; }
            public long? SequenceNumberLTE { get; set; }
            public long? SequenceNumberEqual { get; set; }
            public DateTimeOffset? SourceIfModifiedSince { get; set; }
            public DateTimeOffset? SourceIfUnmodifiedSince { get; set; }
            public string SourceIfMatch { get; set; }
            public string SourceIfNoneMatch { get; set; }
        }
    }
}
