// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
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

            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            AppendBlobClient blob = InstrumentClient(new AppendBlobClient(connectionString.ToString(true), containerName, blobName, GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
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

            AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(blobName));

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
        public async Task CreateAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await blob.CreateAsync(
                metadata: metadata);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task CreateAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [Test]
        public async Task CreateAsync_CpkHttpError()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(new AppendBlobClient(
                blob.Uri,
                blob.Pipeline,
                blob.ClientDiagnostics,
                customerProvidedKey));
            ;
            Assert.AreEqual(Constants.Blob.Http, blob.Uri.Scheme);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.CreateAsync(),
                actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
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
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(string.Empty));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateAsync(),
                actualException => Assert.AreEqual("InvalidUri", actualException.ErrorCode)
                );
        }

        [Test]
        public async Task CreateAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };
            foreach (AccessConditionParameters parameters in data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobContentInfo> response = await blob.CreateAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task CreateAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (AccessConditionParameters parameters in data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.CreateAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        public async Task CreateIfNotExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            // Act
            Response<BlobContentInfo> response = await blob.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Act
            Response<BlobContentInfo> responseExists = await blob.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(blobName, blobs.First().Name);
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(string.Empty));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateIfNotExistsAsync(),
                actualException => Assert.AreEqual("InvalidUri", actualException.ErrorCode)
                );
        }

        [Test]
        public async Task AppendBlockAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.AppendBlockAsync(stream);
            }

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, data.Length));
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [Test]
        public async Task AppendBlockAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            var data = GetRandomBuffer(Constants.KB);
            await blob.CreateAsync();

            // Act
            using var stream = new MemoryStream(data);
            Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                content: stream);

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [Test]
        public async Task AppendBlockAsync_CpkHttpError()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient httpBlob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            httpBlob = InstrumentClient(new AppendBlobClient(
                httpBlob.Uri,
                httpBlob.Pipeline,
                httpBlob.ClientDiagnostics,
                customerProvidedKey));
            Assert.AreEqual(Constants.Blob.Http, httpBlob.Uri.Scheme);
            AppendBlobClient httpsBlob = InstrumentClient(httpBlob.WithCustomerProvidedKey(customerProvidedKey));
            var data = GetRandomBuffer(Constants.KB);
            await httpsBlob.CreateAsync();

            // Act
            using var stream = new MemoryStream(data);
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                httpBlob.AppendBlockAsync(stream),
                actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
        }

        [Test]
        public async Task AppendBlockAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                    content: stream,
                    transactionalContentHash: MD5.Create().ComputeHash(data));

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task AppendBlockAsync_MD5Fail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.AppendBlockAsync(
                        content: stream,
                        transactionalContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garbage"))),
                    e => Assert.AreEqual("Md5Mismatch", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task AppendBlockAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.AppendBlockAsync(stream),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task AppendBlockAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId },
                new AccessConditionParameters { AppendPosE = 0 },
                new AccessConditionParameters { MaxSizeLTE = 100 }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await blob.CreateAsync();
                var data = GetRandomBuffer(7);
                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                        content: stream,
                        conditions: accessConditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task AppendBlockAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { AppendPosE = 1 },
                new AccessConditionParameters { MaxSizeLTE = 1 }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                var data = GetRandomBuffer(7);
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        blob.AppendBlockAsync(
                            content: stream,
                            conditions: accessConditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task AppendBlockAsync_WithUnreliableConnection()
        {
            const int blobSize = 1 * Constants.MB;
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobContainerClient containerFaulty = InstrumentClient(
                new BlobContainerClient(
                    test.Container.Uri,
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetFaultyBlobConnectionOptions()));

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blobFaulty = InstrumentClient(containerFaulty.GetAppendBlobClient(blobName));
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            await blob.CreateAsync();

            var data = GetRandomBuffer(blobSize);
            var progressList = new List<long>();
            var progressHandler = new Progress<long>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

            // Act
            using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
            {
                await blobFaulty.AppendBlockAsync(stream, progressHandler: progressHandler);
                await WaitForProgressAsync(progressList, data.LongLength);
                Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                Assert.GreaterOrEqual(data.LongLength, progressList.Last(), "Final progress has unexpected value");
            }

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            Assert.AreEqual(data.Length, actual.Length);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        public async Task AppendBlockFromUriAsync_Min()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync();

                // Act
                await destBlob.AppendBlockFromUriAsync(sourceBlob.Uri, new HttpRange(0, Constants.KB));
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                destBlob = InstrumentClient(destBlob.WithCustomerProvidedKey(customerProvidedKey));
                await destBlob.CreateAsync();

                // Act
                Response<BlobAppendInfo> response = await destBlob.AppendBlockFromUriAsync(
                    sourceBlob.Uri,
                    new HttpRange(0, Constants.KB));

                Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_CpkHttpError()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient httpDestBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                httpDestBlob = InstrumentClient(new AppendBlobClient(
                    httpDestBlob.Uri,
                    httpDestBlob.Pipeline,
                    httpDestBlob.ClientDiagnostics,
                    customerProvidedKey));
                Assert.AreEqual(Constants.Blob.Http, httpDestBlob.Uri.Scheme);
                AppendBlobClient httpsDestBlob = InstrumentClient(httpDestBlob.WithCustomerProvidedKey(customerProvidedKey));
                await httpsDestBlob.CreateAsync();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    httpDestBlob.AppendBlockFromUriAsync(
                        sourceBlob.Uri,
                        new HttpRange(0, Constants.KB)),
                    actualException => Assert.AreEqual("Cannot use client-provided key without HTTPS.", actualException.Message));
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_Range()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(4 * Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync();

                // Act
                await destBlob.AppendBlockFromUriAsync(sourceBlob.Uri, new HttpRange(2 * Constants.KB, 2 * Constants.KB));

                // Assert
                Response<BlobDownloadInfo> result = await destBlob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
                var dataResult = new MemoryStream();
                await result.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(2 * Constants.KB, dataResult.Length);
                TestHelper.AssertSequenceEqual(data.Skip(2 * Constants.KB).Take(2 * Constants.KB), dataResult.ToArray());
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync();

                // Act
                await destBlob.AppendBlockFromUriAsync(
                    sourceUri: sourceBlob.Uri,
                    sourceContentHash: MD5.Create().ComputeHash(data));
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_MD5_Fail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.AppendBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        sourceContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garabage"))),
                    actualException => Assert.AreEqual("Md5Mismatch", actualException.ErrorCode)
                );
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8351")]
        public async Task AppendBlockFromUriAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId },
                new AccessConditionParameters { AppendPosE = 0 },
                new AccessConditionParameters { MaxSizeLTE = 100 },
                new AccessConditionParameters { SourceIfModifiedSince = OldDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = NewDate },
                new AccessConditionParameters { SourceIfMatch = ReceivedETag },
                new AccessConditionParameters { SourceIfNoneMatch = GarbageETag }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

                var data = GetRandomBuffer(7);

                using (var stream = new MemoryStream(data))
                {
                    AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await destBlob.CreateAsync();

                    parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                    parameters.SourceIfMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfMatch);
                    parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                    AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                        parameters: parameters,
                        lease: true,
                        appendPosAndMaxSize: true);
                    AppendBlobRequestConditions sourceAccessConditions = BuildSourceAccessConditions(parameters);

                    // Act
                    await destBlob.AppendBlockFromUriAsync(
                        sourceUri: sourceBlob.Uri,
                        conditions: accessConditions,
                        sourceConditions: sourceAccessConditions);
                }
            }
        }

        [Test]
        public async Task AppendBlockFromUriAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
                new AccessConditionParameters { AppendPosE = 1 },
                new AccessConditionParameters { MaxSizeLTE = 1 },
                new AccessConditionParameters { SourceIfModifiedSince = NewDate },
                new AccessConditionParameters { SourceIfUnmodifiedSince = OldDate },
                new AccessConditionParameters { SourceIfMatch = GarbageETag },
                new AccessConditionParameters { SourceIfNoneMatch = ReceivedETag }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

                var data = GetRandomBuffer(7);

                using (var stream = new MemoryStream(data))
                {
                    AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await sourceBlob.CreateAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await destBlob.CreateAsync();

                    parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                    parameters.SourceIfNoneMatch = await SetupBlobMatchCondition(sourceBlob, parameters.SourceIfNoneMatch);

                    AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                        parameters: parameters,
                        lease: true,
                        appendPosAndMaxSize: true);
                    AppendBlobRequestConditions sourceAccessConditions = BuildSourceAccessConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        destBlob.AppendBlockFromUriAsync(
                            sourceUri: sourceBlob.Uri,
                            conditions: accessConditions,
                            sourceConditions: sourceAccessConditions),
                        actualException => Assert.IsTrue(true)
                    );
                }
            }
        }

        private AppendBlobRequestConditions BuildDestinationAccessConditions(
            AccessConditionParameters parameters,
            bool lease = false,
            bool appendPosAndMaxSize = false)
        {
            var accessConditions = new AppendBlobRequestConditions
            {
                IfMatch = parameters.Match != null ? new ETag(parameters.Match) : default(ETag?),
                IfNoneMatch = parameters.NoneMatch != null ? new ETag(parameters.NoneMatch) : default(ETag?),
                IfModifiedSince = parameters.IfModifiedSince,
                IfUnmodifiedSince = parameters.IfUnmodifiedSince
            };

            if (lease)
            {
                accessConditions.LeaseId = parameters.LeaseId;
            }

            if (appendPosAndMaxSize)
            {
                accessConditions.IfAppendPositionEqual = parameters.AppendPosE;
                accessConditions.IfMaxSizeLessThanOrEqual = parameters.MaxSizeLTE;
            }

            return accessConditions;
        }

        private AppendBlobRequestConditions BuildSourceAccessConditions(AccessConditionParameters parameters) =>
            new AppendBlobRequestConditions
            {
                IfMatch = parameters.SourceIfMatch != null ? new ETag(parameters.SourceIfMatch) : default(ETag?),
                IfNoneMatch = parameters.SourceIfNoneMatch != null ? new ETag(parameters.SourceIfNoneMatch) : default(ETag?),
                IfModifiedSince = parameters.SourceIfModifiedSince,
                IfUnmodifiedSince = parameters.SourceIfUnmodifiedSince
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
