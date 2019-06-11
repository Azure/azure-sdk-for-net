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
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    [TestFixture]
    public class PageBlobClientTests
    {
        const string CacheControl = "control";
        const string ContentDisposition = "disposition";
        const string ContentEncoding = "encoding";
        const string ContentLanguage = "language";
        const string ContentType = "type";
        readonly byte[] ContentMD5 = MD5.Create().ComputeHash(TestHelper.GetRandomBuffer(16));

        [Test]
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

            var blob = new PageBlobClient(connectionString.ToString(true), containerName, blobName, TestHelper.GetOptions<BlobConnectionOptions>());

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync_Min()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

                // Act
                var response = await blob.CreateAsync(Constants.KB);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync_SequenceNumber()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

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
        [Category("Live")]
        public async Task CreateAsync_Metadata()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var metadata = TestHelper.BuildMetadata();
                var blob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

                // Act
                await blob.CreateAsync(Constants.KB, metadata: metadata);

                // Assert
                var getPropertiesResponse = await blob.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata);
                Assert.AreEqual(BlobType.PageBlob, getPropertiesResponse.Value.BlobType);
            }
        }

        /// <summary>
        /// Data for CreateAsync, GetPageRangesAsync, GetPageRangesDiffAsync, ResizeAsync, and 
        /// UpdateSequenceNumber AccessConditions tests
        /// </summary>
        public static IEnumerable<object[]> Reduced_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.ReceivedLeaseId
                }
            }.Select(x => new object[] { x });

        [Test]
        [TestCaseSource(nameof(Reduced_AccessConditions_Data))]
        [Category("Live")]
        public async Task CreateAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                // This PageBlob is intentionally created twice to test the PageBlobAccessConditions
                var blob = await TestHelper.CreatePageBlobClientAsync(container, Constants.KB);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        /// <summary>
        /// Data for CreateAsync, GetPageRangesAsync, and GetPageRangesDiffAsync AccessConditions Fail tests
        /// </summary>
        public static IEnumerable<object[]> Reduced_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.GarbageLeaseId
                }
            }.Select(x => new object[] { x });

        [Test]
        [TestCaseSource(nameof(Reduced_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task CreateAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                // This PageBlob is intentionally created twice to test the PageBlobAccessConditions
                var blob = await TestHelper.CreatePageBlobClientAsync(container, Constants.KB);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [Category("Live")]
        public async Task CreateAsync_Headers()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var headers = new BlobHttpHeaders
                {
                    ContentType = ContentType,
                    ContentHash = ContentMD5,
                    ContentEncoding = new string[] { ContentEncoding },
                    ContentLanguage = new string[] { ContentLanguage },
                    ContentDisposition = ContentDisposition,
                    CacheControl = CacheControl
                };
                var blob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

                // Act
                await blob.CreateAsync(
                    size: Constants.KB,
                    httpHeaders: headers);

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(ContentType, response.Value.ContentType);
                Assert.IsTrue(this.ContentMD5.ToList().SequenceEqual(response.Value.ContentHash.ToList()));
                Assert.AreEqual(1, response.Value.ContentEncoding.Count());
                Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(1, response.Value.ContentLanguage.Count());
                Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage.First());
                Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var invalidPageSize = 511;
                var blob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

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
        [Category("Live")]
        public async Task UploadPagesAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var data = TestHelper.GetRandomBuffer(Constants.KB);


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
                Assert.IsTrue(actualData.SequenceEqual(expectedData));
            }
        }

        [Test]
        [Category("Live")]
        public async Task UploadPagesAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Act
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.UploadPagesAsync(stream, 5 * Constants.KB),
                        e => Assert.AreEqual("InvalidPageRange", e.ErrorCode));
                }
            }
        }

        public static IEnumerable<object[]> UploadClearAsync_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.ReceivedLeaseId
                },
                new AccessConditionParameters
                {
                    SequenceNumberLT = 5
                },
                new AccessConditionParameters
                {
                    SequenceNumberLTE = 3
                },
                new AccessConditionParameters
                {
                    SequenceNumberEqual = 0
                }
           }.Select(x => new object[] { x });

        [Test]
        [TestCaseSource(nameof(UploadClearAsync_AccessConditions_Data))]
        [Category("Live")]
        public async Task UploadAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, Constants.KB);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters, 
                    lease: true, 
                    sequenceNumbers: true);

                var data = TestHelper.GetRandomBuffer(Constants.KB);
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

        public static IEnumerable<object[]> UploadClearAsync_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.GarbageLeaseId
                },
                new AccessConditionParameters
                {
                    SequenceNumberLT = -1
                },
                new AccessConditionParameters
                {
                    SequenceNumberLTE = -1
                },
                new AccessConditionParameters
                {
                    SequenceNumberEqual = 100
                }
            }.Select(x => new object[] { x });

        [Test]
        [TestCaseSource(nameof(UploadClearAsync_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task UploadAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, Constants.KB);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true,
                    sequenceNumbers: true);

                var data = TestHelper.GetRandomBuffer(Constants.KB);
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

        [Test]
        [Category("Live")]
        public async Task UploadPagesAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;

            using (TestHelper.GetNewContainer(out var container))
            {
                var credentials = new SharedKeyCredentials(
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey);
                var containerClientFaulty = new BlobContainerClient(
                    container.Uri,
                    TestHelper.GetFaultyBlobConnectionOptions(credentials));

                // Arrange
                var pageBlobName = TestHelper.GetNewBlobName();
                var blobFaulty = containerClientFaulty.GetPageBlobClient(pageBlobName);
                var blob = container.GetPageBlobClient(pageBlobName);

                await blob.CreateAsync(blobSize)
                    .ConfigureAwait(false);

                var offset = 0 * Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);
                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.UploadPagesAsync(stream, offset, progressHandler: progressHandler);
                    await Task.Delay(1000); // wait 1s to allow lingering progress events to execute
                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                    var lastProgress = progressList.Last();
                    Assert.AreEqual(data.LongLength, lastProgress.BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var downloadResponse = await blob.DownloadAsync(
                    new HttpRange(offset, data.LongLength));
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                Assert.IsTrue(data.SequenceEqual(actual.ToArray()));
            }
        }

        [Test]
        [Category("Live")]
        public async Task ClearPagesAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var data = TestHelper.GetRandomBuffer(4 * Constants.KB);

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
                Assert.AreEqual(data.Length, actual.Length);
                var actualData = actual.ToArray();
                Assert.IsTrue(expectedData.SequenceEqual(actualData));
            }
        }

        [Test]
        [Category("Live")]
        public async Task ClearPagesAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

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
        [TestCaseSource(nameof(UploadClearAsync_AccessConditions_Data))]
        [Category("Live")]
        public async Task ClearPagesAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, Constants.KB);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [TestCaseSource(nameof(UploadClearAsync_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task ClearAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, Constants.KB);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [Category("Live")]
        public async Task GetPageRangesAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var data = TestHelper.GetRandomBuffer(Constants.KB);

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
        [Category("Live")]
        public async Task GetPageRangesAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

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
        [TestCaseSource(nameof(Reduced_AccessConditions_Data))]
        [Category("Live")]
        public async Task GetPageRangesAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [TestCaseSource(nameof(Reduced_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task GetPageRangesAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [Category("Live")]
        public async Task GetPageRangesDiffAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Upload some Pages
                var data = TestHelper.GetRandomBuffer(Constants.KB);
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
        [Category("Live")]
        public async Task GetPageRangesDiffAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

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
        [TestCaseSource(nameof(Reduced_AccessConditions_Data))]
        [Category("Live")]
        public async Task GetPageRangesDiffAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Upload some Pages
                var data = TestHelper.GetRandomBuffer(Constants.KB);
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

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                var response = await blob.GetPageRangesDiffAsync(
                    range: new HttpRange(0, Constants.KB),
                    prevSnapshot: prevSnapshot,
                    accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Value.Body.PageRange);
            }
        }

        [Test]
        [TestCaseSource(nameof(Reduced_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task GetPageRangesDiffAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Upload some Pages
                var data = TestHelper.GetRandomBuffer(Constants.KB);
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

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

                var accessConditions = this.BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.GetPageRangesDiffAsync(
                        range: new HttpRange(0, Constants.KB),
                        prevSnapshot: prevSnapshot,
                        accessConditions: accessConditions),
                    e => Assert.IsTrue(true));
            }
        }

        [Test]
        [Category("Live")]
        public async Task ResizeAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var newSize = 8 * Constants.KB;

                // Act
                var result = await blob.ResizeAsync(size: newSize);

                // Assert
                var response = await blob.GetPropertiesAsync();
                Assert.AreEqual(newSize, response.Value.ContentLength);

            }
        }

        [Test]
        [Category("Live")]
        public async Task ResizeAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
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
        [TestCaseSource(nameof(Reduced_AccessConditions_Data))]
        [Category("Live")]
        public async Task ResizeAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var newSize = 8 * Constants.KB;

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [TestCaseSource(nameof(Reduced_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task ResizeAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var newSize = 8 * Constants.KB;

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [Category("Live")]
        public async Task UpdateSequenceNumberAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
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
        [TestCaseSource(nameof(Reduced_AccessConditions_Data))]
        [Category("Live")]
        public async Task UpdateSequenceNumberAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                long sequenceAccessNumber = 5;

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [TestCaseSource(nameof(Reduced_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task UpdateSequenceNumberAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                long sequenceAccessNumber = 5;

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [Category("Live")]
        public async Task UpdateSequenceNumberAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

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
        [Category("Live")]
        public async Task StartCopyIncrementalAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var expectedData = new byte[4 * Constants.KB];
                data.CopyTo(expectedData, 0);

                // Create Page Blob
                var sourceBlob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Update data to firstPageBlob
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadPagesAsync(stream, Constants.KB);
                }

                // Create Snapshot
                var snapshotResponse = await sourceBlob.CreateSnapshotAsync();

                var snapshot = snapshotResponse.Value.Snapshot;

                var destinationBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

                // Act
                var response = await destinationBlob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    snapshot: snapshot);

                await this.WaitForCopy(destinationBlob);

                // Assert

                var properties = await destinationBlob.GetPropertiesAsync();

                Assert.AreEqual(CopyStatus.Success, properties.Value.CopyStatus);
            }
        }

        [Test]
        [Category("Live")]
        public async Task StartCopyIncrementalAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);
                var sourceBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

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
        [TestCaseSource(nameof(Reduced_AccessConditions_Data))]
        [Category("Live")]
        public async Task StartCopyIncrementalAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var expectedData = new byte[4 * Constants.KB];
                data.CopyTo(expectedData, 0);

                // Create sourceBlob
                var sourceBlob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Update data to sourceBlob
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadPagesAsync(stream, Constants.KB);
                }

                // Create Snapshot
                var snapshotResponse = await sourceBlob.CreateSnapshotAsync();

                var snapshot = snapshotResponse.Value.Snapshot;

                var blob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

                await blob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    snapshot: snapshot);

                await this.WaitForCopy(blob);

                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);

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

        [Test]
        [TestCaseSource(nameof(Reduced_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task StartCopyIncrementalAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);
                var data = TestHelper.GetRandomBuffer(Constants.KB);
                var expectedData = new byte[4 * Constants.KB];
                data.CopyTo(expectedData, 0);

                // Create sourceBlob
                var sourceBlob = await TestHelper.CreatePageBlobClientAsync(container, 4 * Constants.KB);

                // Update data to sourceBlob
                using (var stream = new MemoryStream(data))
                {
                    await sourceBlob.UploadPagesAsync(stream, Constants.KB);
                }

                // Create Snapshot
                var snapshotResponse = await sourceBlob.CreateSnapshotAsync();

                var snapshot = snapshotResponse.Value.Snapshot;

                var blob = container.GetPageBlobClient(TestHelper.GetNewBlobName());

                await blob.StartCopyIncrementalAsync(
                    sourceUri: sourceBlob.Uri,
                    snapshot: snapshot);

                await this.WaitForCopy(blob);

                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);

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

        [Test]
        [Category("Live")]
        public async Task UploadPagesFromUriAsync_Min()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
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
        [Category("Live")]
        public async Task UploadPagesFromUriAsync_Range()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(4 * Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync(4 * Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
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
                    Assert.IsTrue(data.Skip(2 * Constants.KB).Take(2 * Constants.KB).SequenceEqual(dataResult.GetBuffer()));
                }
            }
        }

        [Test]
        [Category("Live")]
        public async Task UploadPagesFromUriAsync_MD5()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
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
        [Category("Live")]
        public async Task UploadPagesFromUriAsync_MD5_Fail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
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

        public static IEnumerable<object[]> UploadPagesFromUriAsync_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.ReceivedLeaseId
                },
                new AccessConditionParameters
                {
                    SequenceNumberLT = 5
                },
                new AccessConditionParameters
                {
                    SequenceNumberLTE = 3
                },
                new AccessConditionParameters
                {
                    SequenceNumberEqual = 0
                },
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

        [Test]
        [TestCaseSource(nameof(UploadPagesFromUriAsync_AccessConditions_Data))]
        [Category("Live")]
        public async Task UploadPagesFromUriAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
                    await destBlob.CreateAsync(Constants.KB);

                    parameters.Match = await TestHelper.SetupBlobMatchCondition(destBlob, parameters.Match);
                    parameters.SourceIfMatch = await TestHelper.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                    parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(destBlob, parameters.LeaseId);

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

        public static IEnumerable<object[]> UploadPagesFromUriAsync_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters
                {
                    IfModifiedSince = TestHelper.NewDate
                },
                new AccessConditionParameters
                {
                    IfUnmodifiedSince = TestHelper.OldDate
                },
                new AccessConditionParameters
                {
                    Match = TestHelper.GarbageETag
                },
                new AccessConditionParameters
                {
                    NoneMatch = TestHelper.ReceivedETag
                },
                new AccessConditionParameters
                {
                    LeaseId = TestHelper.GarbageLeaseId
                },
                new AccessConditionParameters
                {
                    SequenceNumberLT = -1
                },
                new AccessConditionParameters
                {
                    SequenceNumberLTE = -1
                },
                new AccessConditionParameters
                {
                    SequenceNumberEqual = 100
                },
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

        [Test]
        [TestCaseSource(nameof(UploadPagesFromUriAsync_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task UploadPagesFromUriAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync(Constants.KB);
                    await sourceBlob.UploadPagesAsync(stream, 0);

                    var destBlob = container.GetPageBlobClient(TestHelper.GetNewBlobName());
                    await destBlob.CreateAsync(Constants.KB);

                    parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                    parameters.SourceIfNoneMatch = await TestHelper.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);

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

        [Test]
        public void WithSnapshot()
        {
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();

            var service = TestHelper.GetServiceClient_SharedKey();

            var container = service.GetBlobContainerClient(containerName);

            var blob = container.GetPageBlobClient(blobName);

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);

            blob = blob.WithSnapshot("foo");

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            blob = blob.WithSnapshot(null);

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

        private PageBlobAccessConditions BuildSourceAccessConditions(AccessConditionParameters parameters) => new PageBlobAccessConditions
        {
            HttpAccessConditions = new HttpAccessConditions
            {
                IfMatch = parameters.SourceIfMatch != null ? new ETag(parameters.SourceIfMatch) : default(ETag?),
                IfNoneMatch = parameters.SourceIfNoneMatch != null ? new ETag(parameters.SourceIfNoneMatch) : default(ETag?),
                IfModifiedSince = parameters.SourceIfModifiedSince,
                IfUnmodifiedSince = parameters.SourceIfUnmodifiedSince
            },
        };

        public struct AccessConditionParameters
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

        private async Task WaitForCopy(BlobClient blobUri, int milliWait = 200)
        {
            var status = CopyStatus.Pending;
            var start = DateTimeOffset.Now;
            while(status != CopyStatus.Success)
            {
                status = (await blobUri.GetPropertiesAsync()).Value.CopyStatus;
                var currentTime = DateTimeOffset.Now;
                if(status == CopyStatus.Failed || currentTime.AddMinutes(-1) > start)
                {
                    throw new Exception("Copy failed or took too long");
                }
                await Task.Delay(milliWait);
            }
        }
    }
}
