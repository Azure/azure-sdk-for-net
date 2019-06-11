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
    public class AppendBlobClientTests
    {
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

            var blob = new AppendBlobClient(connectionString.ToString(true), containerName, blobName, TestHelper.GetOptions<BlobConnectionOptions>());

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public void WithSnapshot()
        {
            var containerName = TestHelper.GetNewContainerName();
            var blobName = TestHelper.GetNewBlobName();

            var service = TestHelper.GetServiceClient_SharedKey();

            var container = service.GetBlobContainerClient(containerName);

            var blob = container.GetAppendBlobClient(blobName);

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);

            blob = blob.WithSnapshot("foo");

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            blob = blob.WithSnapshot(null);

            builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blobName = TestHelper.GetNewBlobName();
                var blob = container.GetAppendBlobClient(blobName);

                // Act
                var response = await blob.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                var listResponse = await container.ListBlobsFlatSegmentAsync();
                Assert.AreEqual(1, listResponse.Value.BlobItems.Count());
                Assert.AreEqual(blobName, listResponse.Value.BlobItems.First().Name);
                Assert.IsNull(listResponse.Value.Marker);
            }
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync_Metadata()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                var metadata = TestHelper.BuildMetadata();

                // Act
                await blob.CreateAsync(
                    metadata: metadata);

                // Assert
                var response = await blob.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
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
        [Category("Live")]
        public async Task CreateAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(String.Empty);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CreateAsync(),
                    actualException => Assert.AreEqual("InvalidUri", actualException.ErrorCode)
                    );
            }
        }

        public static IEnumerable<object[]> CreateAsync_AccessConditions_Data
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
        [TestCaseSource(nameof(CreateAsync_AccessConditions_Data))]
        [Category("Live")]
        public async Task CreateAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);
                var accessConditions = this.BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                var response = await blob.CreateAsync(accessConditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        public static IEnumerable<object[]> CreateAsync_AccessConditionsFail_Data
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
        [TestCaseSource(nameof(CreateAsync_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task CreateAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
                var accessConditions = this.BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    blob.CreateAsync(accessConditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [Category("Live")]
        public async Task AppendBlockAsync()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blobName = TestHelper.GetNewBlobName();
                var blob = container.GetAppendBlobClient(blobName);
                await blob.CreateAsync();
                const int blobSize = Constants.KB;
                var data = TestHelper.GetRandomBuffer(blobSize);

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
                Assert.IsTrue(data.SequenceEqual(dataResult.GetBuffer()));
            }
        }

        [Test]
        [Category("Live")]
        public async Task AppendBlockAsync_MD5()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                await blob.CreateAsync();
                var data = TestHelper.GetRandomBuffer(Constants.KB);

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
        [Category("Live")]
        public async Task AppendBlockAsync_MD5Fail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                await blob.CreateAsync();
                var data = TestHelper.GetRandomBuffer(Constants.KB);

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
        [Category("Live")]
        public async Task AppendBlockAsync_Error()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(Constants.KB);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                        blob.AppendBlockAsync(stream),
                        e => Assert.AreEqual("BlobNotFound", e.ErrorCode.Split('\n')[0]));
                }
            }
        }

        public static IEnumerable<object[]> AppendBlockAsync_AccessConditions_Data
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
                    AppendPosE = 0
                },
                new AccessConditionParameters
                {
                    MaxSizeLTE = 100
                }
            }.Select(x => new object[] { x });

        [Test]
        [TestCaseSource(nameof(AppendBlockAsync_AccessConditions_Data))]
        [Category("Live")]
        public async Task AppendBlockAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob =  container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                await blob.CreateAsync();
                var data = TestHelper.GetRandomBuffer(7);
                parameters.Match = await TestHelper.SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(blob, parameters.LeaseId);
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

        public static IEnumerable<object[]> AppendBlockAsync_AccessConditionsFail_Data
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
                    AppendPosE = 1
                },
                new AccessConditionParameters
                {
                    MaxSizeLTE = 1
                }
            }.Select(x => new object[] { x });

        [Test]
        [TestCaseSource(nameof(AppendBlockAsync_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task AppendBlockAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                var blob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                var data = TestHelper.GetRandomBuffer(7);
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(blob, parameters.NoneMatch);
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


        [Test]
        [Category("Live")]
        public async Task AppendBlockAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;

            using (TestHelper.GetNewContainer(out var container))
            {
                var containerFaulty = new BlobContainerClient(
                    container.Uri,
                    TestHelper.GetFaultyBlobConnectionOptions(
                        new SharedKeyCredentials(
                            TestConfigurations.DefaultTargetTenant.AccountName,
                            TestConfigurations.DefaultTargetTenant.AccountKey)));

                // Arrange
                var blobName = TestHelper.GetNewBlobName();
                var blobFaulty = containerFaulty.GetAppendBlobClient(blobName);
                var blob = container.GetAppendBlobClient(blobName);

                await blob.CreateAsync();

                var data = TestHelper.GetRandomBuffer(blobSize);
                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    await blobFaulty.AppendBlockAsync(stream, progressHandler: progressHandler);

                    await Task.Delay(1000); // wait 1s to allow lingering progress events to execute

                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");

                    var lastProgress = progressList.Last();

                    Assert.AreEqual(data.LongLength, lastProgress.BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var downloadResponse = await blob.DownloadAsync();
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                Assert.IsTrue(data.SequenceEqual(actual.ToArray()));
            }
        }

        [Test]
        [Category("Live")]
        public async Task AppendBlockFromUriAsync_Min()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await destBlob.CreateAsync();

                    // Act
                    await destBlob.AppendBlockFromUriAsync(sourceBlob.Uri, new HttpRange(0, Constants.KB));
                }
            }
        }

        [Test]
        [Category("Live")]
        public async Task AppendBlockFromUriAsync_Range()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(4 * Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await destBlob.CreateAsync();

                    // Act
                    await destBlob.AppendBlockFromUriAsync(sourceBlob.Uri, new HttpRange(2 * Constants.KB, 2 * Constants.KB));

                    // Assert
                    var result = await destBlob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
                    var dataResult = new MemoryStream();
                    await result.Value.Content.CopyToAsync(dataResult);
                    Assert.AreEqual(2 * Constants.KB, dataResult.Length);
                    Assert.IsTrue(data.Skip(2 * Constants.KB).Take(2 * Constants.KB).SequenceEqual(dataResult.GetBuffer()));
                }
            }
        }


        [Test]
        [Category("Live")]
        public async Task AppendBlockFromUriAsync_MD5()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await destBlob.CreateAsync();

                    // Act
                    await destBlob.AppendBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri, 
                        sourceContentHash: MD5.Create().ComputeHash(data));
                }
            }
        }

        [Test]
        [Category("Live")]
        public async Task AppendBlockFromUriAsync_MD5_Fail()
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
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

        public static IEnumerable<object[]> AppendBlockFromUriAsync_AccessConditions_Data
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
                    AppendPosE = 0
                },
                new AccessConditionParameters
                {
                    MaxSizeLTE = 100
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
        [TestCaseSource(nameof(AppendBlockFromUriAsync_AccessConditions_Data))]
        [Category("Live")]
        public async Task AppendBlockFromUriAsync_AccessConditions(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(7);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await destBlob.CreateAsync();

                    parameters.Match = await TestHelper.SetupBlobMatchCondition(destBlob, parameters.Match);
                    parameters.SourceIfMatch = await TestHelper.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                    parameters.LeaseId = await TestHelper.SetupBlobLeaseCondition(destBlob, parameters.LeaseId);

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

        public static IEnumerable<object[]> AppendBlockFromUriAsync_AccessConditionsFail_Data
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
                    AppendPosE = 1
                },
                new AccessConditionParameters
                {
                    MaxSizeLTE = 1
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
        [TestCaseSource(nameof(AppendBlockFromUriAsync_AccessConditionsFail_Data))]
        [Category("Live")]
        public async Task AppendBlockFromUriAsync_AccessConditionsFail(AccessConditionParameters parameters)
        {
            using (TestHelper.GetNewContainer(out var container))
            {
                // Arrange
                await container.SetAccessPolicyAsync(PublicAccessType.Container);

                var data = TestHelper.GetRandomBuffer(7);

                using (var stream = new MemoryStream(data))
                {
                    var sourceBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    var destBlob = container.GetAppendBlobClient(TestHelper.GetNewBlobName());
                    await destBlob.CreateAsync();

                    parameters.NoneMatch = await TestHelper.SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                    parameters.SourceIfNoneMatch = await TestHelper.SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);

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

        public struct AccessConditionParameters
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
