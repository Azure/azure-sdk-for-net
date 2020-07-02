// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.TestConstants;

namespace Azure.Storage.Blobs.Test
{
    public class BlobBaseClientTests : BlobTestBase
    {
        public BlobBaseClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

            BlobBaseClient blob1 = InstrumentClient(new BlobBaseClient(connectionString.ToString(true), containerName, blobName, GetOptions()));
            BlobBaseClient blob2 = InstrumentClient(new BlobBaseClient(connectionString.ToString(true), containerName, blobName));

            var builder1 = new BlobUriBuilder(blob1.Uri);
            var builder2 = new BlobUriBuilder(blob2.Uri);

            Assert.AreEqual(containerName, builder1.BlobContainerName);
            Assert.AreEqual(blobName, builder1.BlobName);
            Assert.AreEqual("accountName", builder1.AccountName);

            Assert.AreEqual(containerName, builder2.BlobContainerName);
            Assert.AreEqual(blobName, builder2.BlobName);
            Assert.AreEqual("accountName", builder2.AccountName);
        }

        [Test]
        public async Task Ctor_ConnectionStringEscapeBlobName()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = "!*'();[]:@&%=+$,/?#äÄöÖüÜß";

            BlockBlobClient initalBlob = InstrumentClient(test.Container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);

            using var stream = new MemoryStream(data);
            Response<BlobContentInfo> uploadResponse = await initalBlob.UploadAsync(stream);

            // Act
            BlobBaseClient blob = new BlobBaseClient(TestConfigDefault.ConnectionString, test.Container.Name, blobName, GetOptions());
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(uploadResponse.Value.ETag, propertiesResponse.Value.ETag);

            // Act
            BlobBaseClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Blob(
                    containerName: test.Container.Name,
                    blobName: blobName)
                .GetBlobContainerClient(test.Container.Name)
                .GetBlobClient(blobName));

            propertiesResponse = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(uploadResponse.Value.ETag, propertiesResponse.Value.ETag);
        }

        [Test]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            BlobBaseClient blob = InstrumentClient(new BlobBaseClient(blobEndpoint));
            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new BlobBaseClient(httpUri, GetOAuthCredential()),
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
                () => new BlobBaseClient(httpUri, blobClientOptions),
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
                () => new BlobBaseClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        #region Sequential Download

        [Test]
        public async Task DownloadAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        public async Task DownloadAsync_ZeroSizeBlob()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            byte[] data = new byte[] { };
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            IDictionary<string, string> tags = BuildTags();
            await blob.SetTagsAsync(tags);

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(tags.Count, response.Value.Details.TagCount);
        }

        #region Secondary Storage
        [Test]
        public async Task DownloadAsync_ReadFromSecondaryStorage()
        {
            await using DisposingContainer test = await GetTestContainerAsync(GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(1, out TestExceptionPolicy testExceptionPolicy));

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blockBlobClient.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await EnsurePropagatedAsync(
                async () => await blockBlobClient.DownloadAsync(),
                downloadInfo => downloadInfo.GetRawResponse().Status != 404);

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreEqual(SecondaryStorageTenantPrimaryHost(), testExceptionPolicy.HostsSetInRequests[0]);
            Assert.AreEqual(SecondaryStorageTenantSecondaryHost(), testExceptionPolicy.HostsSetInRequests[1]);
        }

        [Test]
        public async Task DownloadAsync_ReadFromSecondaryStorageShouldNotPut()
        {
            BlobServiceClient serviceClient = GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(
                1,
                out TestExceptionPolicy testExceptionPolicy,
                false,
                new List<RequestMethod>(new RequestMethod[] { RequestMethod.Put }));
            await using DisposingContainer test = await GetTestContainerAsync(serviceClient);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreEqual(SecondaryStorageTenantPrimaryHost(), testExceptionPolicy.HostsSetInRequests[0]);
            // should not toggle to secondary host on put request failure
            Assert.AreEqual(SecondaryStorageTenantPrimaryHost(), testExceptionPolicy.HostsSetInRequests[1]);
        }
        #endregion

        [Test]
        public async Task DownloadAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.Details.EncryptionKeySha256);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.Details.EncryptionScope);
        }

        [Test]
        [TestCase(10 * Constants.KB, 1 * Constants.KB)]
        [TestCase(256 * Constants.KB, 255 * Constants.KB)]
        [TestCase(257 * Constants.KB, 256 * Constants.KB)]
        [TestCase(1 * Constants.MB, 1 * Constants.KB)]
        [LiveOnly] // Stream copy uses ArrayPool under the hood. Which brings undeterministic behavior for larger content.
        public async Task DownloadAsync_WithUnreliableConnection(int dataSize, int faultPoint)
        {
            // Arrange
            int timesFaulted = 0;
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    GetFaultyBlobConnectionOptions(
                        raiseAt: faultPoint,
                        raise: new IOException("Manually injected testing fault"),
                        () => {
                            timesFaulted++;
                        })));

            await using DisposingContainer test = await GetTestContainerAsync(service: service);

            var data = GetRandomBuffer(dataSize);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreNotEqual(0, timesFaulted);
        }

        [Test]
        public async Task DownloadAsync_Range()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(10 * Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var offset = Constants.KB;
            var count = 2 * Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync(range: new HttpRange(offset, count));

            // Assert
            Assert.AreEqual(count, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            Assert.AreEqual(count, actual.Length);
            TestHelper.AssertSequenceEqual(data.Skip(offset).Take(count), actual.ToArray());
        }

        [Test]
        public async Task DownloadAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                Response<BlobDownloadInfo> response = await blob.DownloadAsync(conditions: accessConditions);

                // Assert
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task DownloadAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.DownloadAsync(
                            conditions: accessConditions)).Value;
                    });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

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
            await blob.DownloadAsync(conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadAsync(
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task DownloadAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(10 * Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var offset = Constants.KB;
            var count = 2 * Constants.KB;
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadInfo> response = await blob.DownloadAsync(
                range: new HttpRange(offset, count),
                rangeGetContentHash: true);

            // Assert
            var expectedMD5 = MD5.Create().ComputeHash(data.Skip(offset).Take(count).ToArray());
            TestHelper.AssertSequenceEqual(expectedMD5, response.Value.ContentHash);
        }

        [Test]
        public async Task DownloadAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DownloadAsync(),
                e => Assert.AreEqual("The specified blob does not exist.", e.Message.Split('\n')[0]));
        }

        [Test]
        public async Task DownloadAsync_Overloads()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            await Verify(await blob.DownloadAsync());
            await Verify(await blob.DownloadAsync(CancellationToken.None));
            await Verify(await blob.DownloadAsync(range: default));

            async Task Verify(Response<BlobDownloadInfo> response)
            {
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                using var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> uploadResponse;
            using (var stream = new MemoryStream(data))
            {
                uploadResponse = await blob.UploadAsync(stream);
            }

            // Act
            BlockBlobClient versionBlob = blob.WithVersion(uploadResponse.Value.VersionId);
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert
            Assert.IsNotNull(response.Value.Details.VersionId);
        }

        [PlaybackOnly("Object Replication policies is only enabled on certain storage accounts")]
        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DownloadAsync_ObjectReplication()
        {
            // TODO: The tests will temporarily use designated account, containers and blobs to check the
            // existence of OR headers
            BlobServiceClient sourceServiceClient = GetServiceClient_SharedKey();
            BlobServiceClient destinationServiceClient = GetServiceClient_SecondaryAccount_SharedKey();

            // This is a PLAYBACK ONLY test with a special container we previously setup, as we can't auto setup policies yet
            BlobContainerClient sourceContainer = InstrumentClient(sourceServiceClient.GetBlobContainerClient("test1"));
            BlobContainerClient destinationContainer = InstrumentClient(destinationServiceClient.GetBlobContainerClient("test2"));

            // Arrange
            string blob_name = "netgetpropertiesors2blobapitestgetpropertiesors";
            BlobClient sourceBlob = sourceContainer.GetBlobClient(blob_name);
            BlobClient destBlob = destinationContainer.GetBlobClient(blob_name);

            //Act
            Response<BlobDownloadInfo> sourceResponse = await sourceBlob.DownloadAsync();
            Response<BlobDownloadInfo> destResponse = await destBlob.DownloadAsync();

            //Assert
            Assert.AreEqual(1, sourceResponse.Value.Details.ObjectReplicationSourceProperties.Count);
            Assert.IsNull(sourceResponse.Value.Details.ObjectReplicationDestinationPolicyId);
            Assert.IsNotEmpty(destResponse.Value.Details.ObjectReplicationDestinationPolicyId);
            Assert.IsNull(destResponse.Value.Details.ObjectReplicationSourceProperties);
        }
        #endregion Sequential Download

        #region Parallel Download

        private async Task ParallelDownloadFileAndVerify(
            long size,
            long singleBlockThreshold,
            StorageTransferOptions transferOptions)
        {
            var data = GetRandomBuffer(size);
            var path = Path.GetTempFileName();

            try
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                // Create a special blob client for downloading that will
                // assign client request IDs based on the range so that out
                // of order operations still get predictable IDs and the
                // recordings work correctly
                var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                BlobClient downloadingBlob = InstrumentClient(new BlobClient(blob.Uri, credential, GetOptions(true)));

                using (FileStream file = File.OpenWrite(path))
                {
                    await downloadingBlob.StagedDownloadAsync(
                        file,
                        transferOptions: transferOptions);
                }

                using (FileStream resultStream = File.OpenRead(path))
                {
                    TestHelper.AssertSequenceEqual(data, resultStream.AsBytes());
                }
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        [Test]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        [TestCase(501 * Constants.KB)]
        public async Task DownloadFileAsync_Parallel_SmallBlobs(long size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await ParallelDownloadFileAndVerify(size, Constants.KB, new StorageTransferOptions { MaximumTransferLength = Constants.KB });

        [Ignore("These tests currently take 40 mins for little additional coverage")]
        [Test]
        [Category("Live")]
        [TestCase(33 * Constants.MB, 1)]
        [TestCase(33 * Constants.MB, 4)]
        [TestCase(33 * Constants.MB, 8)]
        [TestCase(33 * Constants.MB, 16)]
        [TestCase(33 * Constants.MB, null)]
        [TestCase(257 * Constants.MB, 1)]
        [TestCase(257 * Constants.MB, 4)]
        [TestCase(257 * Constants.MB, 8)]
        [TestCase(257 * Constants.MB, 16)]
        [TestCase(257 * Constants.MB, null)]
        [TestCase(1 * Constants.GB, 1)]
        [TestCase(1 * Constants.GB, 4)]
        [TestCase(1 * Constants.GB, 8)]
        [TestCase(1 * Constants.GB, 16)]
        [TestCase(1 * Constants.GB, null)]
        public async Task DownloadFileAsync_Parallel_LargeBlobs(long size, int? maximumThreadCount)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            if (Mode == RecordedTestMode.Live)
            {
                await ParallelDownloadFileAndVerify(size, 16 * Constants.MB, new StorageTransferOptions { MaximumConcurrency = maximumThreadCount });
            }
        }

        [Test]
        public async Task DownloadToAsync_ZeroSizeBlob()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using Stream stream = new MemoryStream(new byte[] { });
            await blob.UploadAsync(stream);

            // Act
            using Stream resultStream = new MemoryStream();
            await blob.DownloadToAsync(resultStream);
        }

        [Test]
        [Ignore("Don't want to record 300 MB of data in the tests")]
        public async Task DownloadToAsync_LargeStream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(300 * Constants.MB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            using (var resultStream = new MemoryStream(data))
            {
                await blob.DownloadToAsync(resultStream);
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }

        [Test]
        public async Task DownloadTo_Initial304()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a blob
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Add conditions to cause a failure and ensure we don't explode
            Response result = await blob.DownloadToAsync(
                Stream.Null,
                new BlobRequestConditions
                {
                    IfModifiedSince = Recording.UtcNow
                });
            Assert.AreEqual(304, result.Status);
        }

        [Test]
        public async Task DownloadTo_ReplacedDuringDownload()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a large blob
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(GetRandomBuffer(10 * Constants.KB)))
            {
                await blob.UploadAsync(stream);
            }

            // Check the error we get when a download fails because the blob
            // was replaced while we're downloading
            RequestFailedException ex = Assert.CatchAsync<RequestFailedException>(
                async () =>
                {
                    // Create a stream that replaces the blob as soon as it starts downloading
                    bool replaced = false;
                    await blob.StagedDownloadAsync(
                        new FuncStream(
                            Stream.Null,
                            async () =>
                            {
                                if (!replaced)
                                {
                                    replaced = true;
                                    using var newStream = new MemoryStream(GetRandomBuffer(Constants.KB));
                                    await blob.UploadAsync(newStream, overwrite: true);
                                }
                            }),
                        transferOptions:
                            new StorageTransferOptions
                            {
                                MaximumConcurrency = 1,
                                MaximumTransferLength = Constants.KB,
                                InitialTransferLength = Constants.KB
                            });
                });
            Assert.IsTrue(ex.ErrorCode == BlobErrorCode.ConditionNotMet);
        }

        [Test]
        public async Task DownloadToAsync_PathOverloads()
        {
            var path = Path.GetTempFileName();
            try
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                var data = GetRandomBuffer(Constants.KB);

                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
                await Verify(await blob.DownloadToAsync(path));
                await Verify(await blob.DownloadToAsync(path, CancellationToken.None));
                await Verify(await blob.DownloadToAsync(path,
                    new BlobRequestConditions() { IfModifiedSince = default }));

                async Task Verify(Response response)
                {
                    Assert.AreEqual(data.Length, File.ReadAllBytes(path).Length);
                    using var actual = new MemoryStream();
                    using (FileStream resultStream = File.OpenRead(path))
                    {
                        await resultStream.CopyToAsync(actual);
                        TestHelper.AssertSequenceEqual(data, actual.ToArray());
                    }
                }
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        [Test]
        public async Task DownloadToAsync_StreamOverloads()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            using (var resultStream = new MemoryStream(data))
            {
                await blob.DownloadToAsync(resultStream);
                Verify(resultStream);
            }
            using (var resultStream = new MemoryStream())
            {
                await blob.DownloadToAsync(resultStream, CancellationToken.None);
                Verify(resultStream);
            }
            using (var resultStream = new MemoryStream())
            {
                await blob.DownloadToAsync(resultStream,
                    new BlobRequestConditions() { IfModifiedSince = default });
                Verify(resultStream);
            }

            void Verify(MemoryStream resultStream)
            {
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }
        #endregion Parallel Download

        [Test]
        public async Task DownloadEmptyBlobTest()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blobClient = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }

            // Act
            await blobClient.DownloadAsync();
        }

        [Test]
        public async Task StartCopyFromUriAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

            // Assert
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_Tags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            IDictionary<string, string> tags = BuildTags();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                Tags = tags
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri, options);

            // Assert
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            Response<IDictionary<string, string>> response = await destBlob.GetTagsAsync();
            AssertDictionaryEquality(tags, response.Value);
        }

        [Test]
        public async Task StartCopyFromUriAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                Metadata = metadata
            };

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await destBlob.StartCopyFromUriAsync(
                source: srcBlob.Uri,
                options);

            // Assert
            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task StartCopyFromUriAsync_Source_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(srcBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(srcBlob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions sourceAccessConditions = BuildAccessConditions(
                    parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                Operation<long> response = await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    options);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_Source_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(srcBlob, parameters.NoneMatch);

                BlobRequestConditions sourceAccessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: false);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        options),
                    e => { });

            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_Source_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await srcBlob.SetTagsAsync(tags);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                SourceConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options: options);

            // Assert
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_Source_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                SourceConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(
                            srcBlob.Uri,
                            options: options),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task StartCopyFromUriAsync_Destination_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();


                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // destBlob needs to exist so we can get its lease and etag
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                BlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                Operation<long> response = await destBlob.StartCopyFromUriAsync(
                    source: srcBlob.Uri,
                    options);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
        public async Task StartCopyFromUriAsync_Destination_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();


                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }

                // destBlob needs to exist so we can get its etag
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.StartCopyFromUriAsync(
                        source: srcBlob.Uri,
                        options),
                    e => { });

            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await destBlob.SetTagsAsync(tags);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options: options);

            // Assert
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(
                            srcBlob.Uri,
                            options: options),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task StartCopyFromUriAsync_AccessTier()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.Cool
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options);

            // Assert
            // data copied within an account, so copy should be instantaneous
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_Seal()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient srcBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await srcBlob.CreateAsync();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                IsSealed = true
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri, options);

            // Assert
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            Assert.IsTrue(response.Value.IsSealed);
        }

        [Test]
        public async Task StartCopyFromUriAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(srcBlob.Uri),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));

        }

        [Test]
        public async Task StartCopyFromUriAsync_RehydratePriority()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            var data2 = GetRandomBuffer(Constants.KB);
            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }

            // destBlob needs to exist so we can get its lease and etag
            using (var stream = new MemoryStream(data2))
            {
                await destBlob.UploadAsync(stream);
            }

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.Archive,
                RehydratePriority = RehydratePriority.High
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options);

            // Assert
            // data copied within an account, so copy should be instantaneous
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            // Act
            await destBlob.SetAccessTierAsync(AccessTier.Cool);
            Response<BlobProperties> propertiesResponse = await destBlob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual("rehydrate-pending-to-cool", propertiesResponse.Value.ArchiveStatus);

        }

        [Test]
        public async Task StartCopyFromUriAsync_AccessTierFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.P20
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.StartCopyFromUriAsync(
                srcBlob.Uri,
                options),
                e => Assert.AreEqual(BlobErrorCode.InvalidHeaderValue.ToString(), e.ErrorCode));

        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task StartCopyFromUriAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

            // Assert
            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.IsTrue(operation.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.VersionId, out var _));
        }

        [Test]
        public async Task AbortCopyFromUriAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }

            BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);


            {
                BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));

                Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri);

                // Act
                try
                {
                    Response response = await destBlob.AbortCopyFromUriAsync(operation.Id);

                    // Assert
                    Assert.IsNotNull(response.Headers.RequestId);
                }
                catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                {
                    WarnCopyCompletedTooQuickly();
                }

            }
        }

        [Test]
        public async Task AbortCopyFromUriAsync_Lease()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }
            BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);


            BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await destBlob.UploadAsync(stream);
            }

            TimeSpan duration = BlobLeaseClient.InfiniteLeaseDuration;
            BlobLeaseClient lease = InstrumentClient(destBlob.GetBlobLeaseClient(Recording.Random.NewGuid().ToString()));
            Response<BlobLease> leaseResponse = await lease.AcquireAsync(duration);

            Operation<long> operation = await destBlob.StartCopyFromUriAsync(
                source: srcBlob.Uri,
                destinationConditions: new BlobRequestConditions { LeaseId = leaseResponse.Value.LeaseId });


            // Act
            try
            {
                Response response = await destBlob.AbortCopyFromUriAsync(
                    copyId: operation.Id,
                    conditions: new BlobRequestConditions
                    {
                        LeaseId = leaseResponse.Value.LeaseId
                    });

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
            catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
            {
                WarnCopyCompletedTooQuickly();
            }

        }

        [Test]
        public async Task AbortCopyFromUriAsync_LeaseFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();


            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var data = GetRandomBuffer(8 * Constants.MB);

            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await srcBlob.UploadAsync(stream);
            }
            BlobServiceClient secondaryService = GetServiceClient_SecondaryAccount_SharedKey();
            await using DisposingContainer destTest = await GetTestContainerAsync(service: secondaryService);

            BlockBlobClient destBlob = InstrumentClient(destTest.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await destBlob.UploadAsync(stream);
            }

            Operation<long> operation = await destBlob.StartCopyFromUriAsync(source: srcBlob.Uri);

            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            try
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.AbortCopyFromUriAsync(
                        copyId: operation.Id,
                        conditions: new BlobRequestConditions
                        {
                            LeaseId = leaseId
                        }),
                    e =>
                    {
                        switch (e.ErrorCode)
                        {
                            case "NoPendingCopyOperation":
                                WarnCopyCompletedTooQuickly();
                                break;
                            default:
                                Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode);
                                break;
                        }
                    }
                    );
            }
            catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
            {
                WarnCopyCompletedTooQuickly();
            }

        }

        [Test]
        public async Task AbortCopyFromUriAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var copyId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.AbortCopyFromUriAsync(copyId),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SyncCopyFromUriAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Response<BlobCopyInfo> copyResponse = await destBlob.SyncCopyFromUriAsync(srcBlob.Uri);

            // Check that destBlob actually exists
            await destBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(copyResponse.Value.ETag);
            Assert.IsNotNull(copyResponse.Value.LastModified);
            Assert.IsNotNull(copyResponse.Value.CopyId);
            Assert.AreEqual(CopyStatus.Success, copyResponse.Value.CopyStatus);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SyncCopyFromUriAsync_Tags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            IDictionary<string, string> tags = BuildTags();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                Tags = tags
            };

            // Act
            Response<BlobCopyInfo> copyResponse = await destBlob.SyncCopyFromUriAsync(srcBlob.Uri, options);

            // Assert
            Response<IDictionary<string, string>> response = await destBlob.GetTagsAsync();
            AssertDictionaryEquality(tags, response.Value);
        }

        [Test]
        public async Task SyncCopyFromUriAsync_Metadata()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                Metadata = metadata
            };

            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await destBlob.SyncCopyFromUriAsync(
                source: srcBlob.Uri,
                options);

            // Assert
            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SyncCopyFromUriAsync_Source_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(srcBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(srcBlob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions sourceAccessConditions = BuildAccessConditions(
                    parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                Response<BlobCopyInfo> response = await destBlob.SyncCopyFromUriAsync(
                    source: srcBlob.Uri,
                    options);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task SyncCopyFromUriAsync_Source_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(srcBlob, parameters.NoneMatch);

                BlobRequestConditions sourceAccessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: false);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    SourceConditions = sourceAccessConditions
                };

                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.SyncCopyFromUriAsync(
                        source: srcBlob.Uri,
                        options),
                    e => { });
            }
        }

        [Test]
        public async Task SyncCopyFromUriAsync_Destination_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();


                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

                // destBlob needs to exist so we can get its lease and etag
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.Match = await SetupBlobMatchCondition(destBlob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(destBlob, parameters.LeaseId, garbageLeaseId);

                BlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                Response<BlobCopyInfo> response = await destBlob.SyncCopyFromUriAsync(
                    source: srcBlob.Uri,
                    options);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
        public async Task SyncCopyFromUriAsync_Destination_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();


                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await srcBlob.UploadAsync(stream);
                }

                // destBlob needs to exist so we can get its etag
                BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await destBlob.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupBlobMatchCondition(destBlob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters: parameters);
                BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
                {
                    DestinationConditions = accessConditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destBlob.SyncCopyFromUriAsync(
                        source: srcBlob.Uri,
                        options),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SyncCopyFromUriAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await destBlob.SetTagsAsync(tags);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            Response<BlobCopyInfo> copyResponse = await destBlob.SyncCopyFromUriAsync(
                srcBlob.Uri,
                options: options);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SyncCopyFromUriAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlobBaseClient destBlob = await GetNewBlobClient(test.Container);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationConditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncCopyFromUriAsync(
                    srcBlob.Uri,
                    options: options),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        [Ignore("Inducing a 500 in the service")]
        public async Task SyncCopyFromUriAsync_AccessTier()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.Cool
            };

            // Act
            await destBlob.SyncCopyFromUriAsync(
                srcBlob.Uri,
                options);

            Response<BlobProperties> response = await destBlob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(AccessTier.Cool, response.Value.AccessTier);
        }

        [Test]
        public async Task SyncCopyFromUriAsync_AccessTierFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                AccessTier = AccessTier.P20
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncCopyFromUriAsync(
                srcBlob.Uri,
                options),
                e => Assert.AreEqual(BlobErrorCode.InvalidHeaderValue.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task SyncCopyFromUriAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient srcBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.SyncCopyFromUriAsync(srcBlob.Uri),
                e => Assert.AreEqual(BlobErrorCode.CannotVerifyCopySource.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SyncCopyFromUriAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(test.Container);
            BlockBlobClient destBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Response<BlobCopyInfo> response = await destBlob.SyncCopyFromUriAsync(srcBlob.Uri);

            // Assert
            Assert.IsNotNull(response.Value.VersionId);
        }

        [Test]
        public async Task DeleteAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();


            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response response = await blob.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Options()
        {
            await using DisposingContainer test = await GetTestContainerAsync();


            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            await blob.CreateSnapshotAsync();

            // Act
            await blob.DeleteAsync(snapshotsOption: DeleteSnapshotsOption.OnlySnapshots);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response response = await blob.DeleteAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.DeleteAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
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
            Response response = await blob.DeleteAsync(conditions: conditions);

            // Assert
            bool exists = await blob.ExistsAsync();
            Assert.IsFalse(exists);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DeleteAsync(conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DeleteAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_Version()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            BlobBaseClient versionBlob = blob.WithVersion(createResponse.Value.VersionId);

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_VersionSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetBlobVersionSas(
                test.Container.Name,
                blob.Name,
                createResponse.Value.VersionId,
                BlobVersionSasPermissions.Delete,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_InvalidVersionSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetBlobSas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Read);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.DeleteAsync(),
                e => Assert.AreEqual(BlobErrorCode.AuthorizationPermissionMismatch.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_VersionIdentitySAS()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            SasQueryParameters sasQueryParameters = GetBlobVersionIdentitySas(
                test.Container.Name,
                blob.Name,
                createResponse.Value.VersionId,
                BlobVersionSasPermissions.Delete,
                userDelegationKey,
                oauthService.AccountName,
                Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_VersionInvalidSAS()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            SasQueryParameters sasQueryParameters = GetBlobIdentitySas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Read,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.DeleteAsync(),
                e => Assert.AreEqual(BlobErrorCode.AuthorizationPermissionMismatch.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(BlobSasPermissions.DeleteBlobVersion)]
        [TestCase(BlobSasPermissions.All)]
        public async Task DeleteAsync_VersionBlobSAS(BlobSasPermissions blobSasPermissions)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetBlobSas(
                test.Container.Name,
                blob.Name,
                blobSasPermissions,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(BlobSasPermissions.DeleteBlobVersion)]
        [TestCase(BlobSasPermissions.All)]
        public async Task DeleteAsync_VersionBlobIdentitySAS(BlobSasPermissions blobSasPermissions)
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            SasQueryParameters sasQueryParameters = GetBlobIdentitySas(
                test.Container.Name,
                blob.Name,
                blobSasPermissions,
                userDelegationKey,
                oauthService.AccountName,
                Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(BlobContainerSasPermissions.DeleteBlobVersion)]
        [TestCase(BlobContainerSasPermissions.All)]
        public async Task DeleteAsync_VersionContainerSAS(BlobContainerSasPermissions blobContainerSasPermissions)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetContainerSas(
                test.Container.Name,
                blobContainerSasPermissions,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(BlobContainerSasPermissions.DeleteBlobVersion)]
        [TestCase(BlobContainerSasPermissions.All)]
        public async Task DeleteAsync_VersionContainerIdentitySAS(BlobContainerSasPermissions blobContainerSasPermissions)
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            SasQueryParameters sasQueryParameters = GetContainerIdentitySas(
                test.Container.Name,
                blobContainerSasPermissions,
                userDelegationKey,
                oauthService.AccountName,
                Constants.DefaultSasVersion);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(AccountSasPermissions.DeleteVersion)]
        [TestCase(AccountSasPermissions.All)]
        public async Task DeleteAsync_VersionAccountSAS(AccountSasPermissions accountSasPermissions)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials(
                accountSasResourceTypes: AccountSasResourceTypes.All,
                accountSasPermissions: AccountSasPermissions.All);
            BlobBaseClient versionBlob = new BlobBaseClient(
                new Uri($"{blob.WithVersion(createResponse.Value.VersionId).Uri}&{sasQueryParameters}"), GetOptions());

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task DeleteAsync_InvalidSAS()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            SasQueryParameters sasQueryParameters = GetBlobSas(test.Container.Name, blob.Name, BlobSasPermissions.Read);
            BlobBaseClient versionBlob = blob.WithVersion(createResponse.Value.VersionId);

            Response response = await versionBlob.DeleteAsync();

            // Assert
            Assert.IsTrue(await blob.ExistsAsync());
        }

        [Test]
        public async Task DeleteIfExistsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<bool> response = await blob.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        [Test]
        public async Task DeleteIfExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            Response<bool> response = await blob.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.GetPropertiesAsync());
        }

        //[Test]
        //public async Task DeleteAsync_Batch()
        //{
        //    using (this.GetNewContainer(out var container, serviceUri: this.GetServiceUri_PreviewAccount_SharedKey()))
        //    {
        //        const int blobSize = Constants.KB;
        //        var data = this.GetRandomBuffer(blobSize);

        //        var blob1 = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob1.UploadAsync(stream);
        //        }

        //        var blob2 = this.InstrumentClient(container.GetBlockBlobClient(this.GetNewBlobName()));
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob2.UploadAsync(stream);
        //        }

        //        var batch =
        //            blob1.DeleteAsync()
        //            .And(blob2.DeleteAsync())
        //            ;

        //        var result = await batch;

        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(2, result.Length);
        //        Assert.IsNotNull(result[0].RequestId);
        //        Assert.IsNotNull(result[1].RequestId);
        //    }
        //}

        [Test]
        [NonParallelizable]
        public async Task UndeleteAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await EnableSoftDelete();
            try
            {
                BlobBaseClient blob = await GetNewBlobClient(test.Container);
                await blob.DeleteAsync();

                // Act
                Response response = await blob.UndeleteAsync();

                // Assert
                response.Headers.TryGetValue("x-ms-version", out var version);
                Assert.IsNotNull(version);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                Assert.Inconclusive("Delete may have happened before soft delete was fully enabled!");
            }
            finally
            {
                // Cleanup
                await DisableSoftDelete();
            }
        }

        [Test]
        public async Task UndeleteAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.UndeleteAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));

        }

        [Test]
        public async Task ExistsAsync_Exists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task ExistsAsync_NotExists()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));

            // Act
            Response<bool> response = await blob.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync(publicAccessType: PublicAccessType.None);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            BlobBaseClient unauthorizedBlobClient = InstrumentClient(new BlobBaseClient(blob.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedBlobClient.ExistsAsync(),
                e => { });
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> tags = BuildTags();
            await blob.SetTagsAsync(tags);

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(tags.Count, response.Value.TagCount);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(null)]
        [TestCase(RehydratePriority.Standard)]
        [TestCase(RehydratePriority.High)]
        public async Task GetPropertiesAsync_RehydratePriority(RehydratePriority? rehydratePriority)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            if (rehydratePriority.HasValue)
            {
                await blob.SetAccessTierAsync(
                    AccessTier.Archive);

                await blob.SetAccessTierAsync(
                    AccessTier.Hot,
                    rehydratePriority: rehydratePriority.Value);
            }

            // Act
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(rehydratePriority.HasValue ? rehydratePriority.Value.ToString() : null, propertiesResponse.Value.RehydratePriority);
        }

        [Test]
        public async Task GetPropertiesAsync_CPK()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateAsync();

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetPropertiesAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateAsync();

            // Act
            Response<BlobProperties> response = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [Test]
        public async Task GetPropertiesAsync_ContainerSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlockBlobClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Container(
                    containerName: containerName)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            var accountName = new BlobUriBuilder(test.Container.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => blob.AccountName);
            TestHelper.AssertCacheableProperty(containerName, () => blob.BlobContainerName);
            TestHelper.AssertCacheableProperty(blobName, () => blob.Name);

        }

        [Test]
        public async Task GetPropertiesAsync_ContainerIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlockBlobClient identitySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceIdentitySas_Container(
                    containerName: containerName,
                    userDelegationKey: userDelegationKey)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();
            AssertSasUserDelegationKey(identitySasBlob.Uri, userDelegationKey.Value);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_BlobSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlockBlobClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Blob(
                    containerName: containerName,
                    blobName: blobName)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_BlobSasWithIdentifier()
        {
            // Arrange
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            string signedIdentifierId = GetNewString();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlobSignedIdentifier identifier = new BlobSignedIdentifier
            {
                Id = signedIdentifierId,
                AccessPolicy = new BlobAccessPolicy
                {
                    StartsOn = Recording.UtcNow.AddHours(-1),
                    ExpiresOn = Recording.UtcNow.AddHours(1),
                    Permissions = "rw"
                }
            };
            await test.Container.SetAccessPolicyAsync(permissions: new BlobSignedIdentifier[] { identifier });

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Identifier = signedIdentifierId
            };
            BlobSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(GetNewSharedKeyCredentials());

            BlobUriBuilder uriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = sasQueryParameters
            };

            BlockBlobClient sasBlob = InstrumentClient(new BlockBlobClient(
                uriBuilder.ToUri(),
                GetOptions()));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_BlobSasWithContentHeaders()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
                CacheControl = "\\cache control?",
                ContentDisposition = "\\content disposition?",
                ContentEncoding = "\\content encoding?",
                ContentLanguage = "\\content language?",
                ContentType = "\\content type?"
            };
            blobSasBuilder.SetPermissions(
                BlobSasPermissions.All);

            BlobSasQueryParameters blobSasQueryParameters = blobSasBuilder.ToSasQueryParameters(GetNewSharedKeyCredentials());

            // Act
            string queryParametersString = blobSasQueryParameters.ToString();

            // Assert
            Assert.IsTrue(queryParametersString.Contains("rscc=%5Ccache+control%3F"));
            Assert.IsTrue(queryParametersString.Contains("rscd=%5Ccontent+disposition%3F"));
            Assert.IsTrue(queryParametersString.Contains("rsce=%5Ccontent+encoding%3F"));
            Assert.IsTrue(queryParametersString.Contains("rscl=%5Ccontent+language%3F"));
            Assert.IsTrue(queryParametersString.Contains("rsct=%5Ccontent+type%3F"));

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri(TestConfigDefault.BlobServiceEndpoint));
            blobUriBuilder.BlobName = blobName;
            blobUriBuilder.BlobContainerName = containerName;
            blobUriBuilder.Sas = blobSasQueryParameters;
            BlockBlobClient sasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            Assert.IsTrue(sasBlob.Uri.Query.Contains("rscc=%5Ccache+control%3F"));
            Assert.IsTrue(sasBlob.Uri.Query.Contains("rscd=%5Ccontent+disposition%3F"));
            Assert.IsTrue(sasBlob.Uri.Query.Contains("rsce=%5Ccontent+encoding%3F"));
            Assert.IsTrue(sasBlob.Uri.Query.Contains("rscl=%5Ccontent+language%3F"));
            Assert.IsTrue(sasBlob.Uri.Query.Contains("rsct=%5Ccontent+type%3F"));
        }

        [Test]
        public async Task GetPropertiesAsync_BlobIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlockBlobClient identitySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceIdentitySas_Blob(
                    containerName: containerName,
                    blobName: blobName,
                    userDelegationKey: userDelegationKey)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName));

            AssertSasUserDelegationKey(identitySasBlob.Uri, userDelegationKey.Value);

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_Version()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);
            BlobBaseClient versionBlob = blob.WithVersion(createResponse.Value.VersionId);

            // Act
            Response<BlobProperties> response = await versionBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.VersionId);
            Assert.IsFalse(response.Value.IsLatestVersion);
        }

        private void AssertSasUserDelegationKey(Uri uri, UserDelegationKey key)
        {
            BlobSasQueryParameters sas = new BlobUriBuilder(uri).Sas;
            Assert.AreEqual(key.SignedObjectId, sas.KeyObjectId);
            Assert.AreEqual(key.SignedExpiresOn, sas.KeyExpiresOn);
            Assert.AreEqual(key.SignedService, sas.KeyService);
            Assert.AreEqual(key.SignedStartsOn, sas.KeyStartsOn);
            Assert.AreEqual(key.SignedTenantId, sas.KeyTenantId);
            Assert.AreEqual(key.SignedVersion, sas.Version);
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotSAS()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlockBlobClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Snapshot(
                    containerName: containerName,
                    blobName: blobName,
                    snapshot: snapshotResponse.Value.Snapshot)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName)
                .WithSnapshot(snapshotResponse.Value.Snapshot));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotSAS_Using_BlobClient()
        {
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobBaseClient sasBlob = InstrumentClient(
                GetServiceClient_BlobServiceSas_Snapshot(
                    containerName: containerName,
                    blobName: blobName,
                    snapshot: snapshotResponse.Value.Snapshot)
                .GetBlobContainerClient(containerName)
                .GetBlobClient(blobName)
                .WithSnapshot(snapshotResponse.Value.Snapshot));

            // Act
            Response<BlobProperties> response = await sasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotIdentitySAS()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlockBlobClient identitySasBlob = InstrumentClient(
                GetServiceClient_BlobServiceIdentitySas_Container(
                    containerName: containerName,
                    userDelegationKey: userDelegationKey)
                .GetBlobContainerClient(containerName)
                .GetBlockBlobClient(blobName)
                .WithSnapshot(snapshotResponse.Value.Snapshot));

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            AssertSasUserDelegationKey(identitySasBlob.Uri, userDelegationKey.Value);
        }

        [Test]
        public async Task GetPropertiesAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobProperties> response = await blob.GetPropertiesAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
        public async Task GetPropertiesAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await blob.GetPropertiesAsync(
                            conditions: accessConditions)).Value;
                    });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
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
            Response<BlobProperties> response = await blob.GetPropertiesAsync(conditions: conditions);

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPropertiesAsync(conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [PlaybackOnly("Object Replication policies is only enabled on certain storage accounts")]
        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetPropertiesAsync_ObjectReplication()
        {
            // TODO: The tests will temporarily use designated account, containers and blobs to check the
            // existence of OR headers
            BlobServiceClient sourceServiceClient = GetServiceClient_SharedKey();
            BlobServiceClient destinationServiceClient = GetServiceClient_SecondaryAccount_SharedKey();

            // This is a PLAYBACK ONLY test with a special container we previously setup, as we can't auto setup policies yet
            BlobContainerClient sourceContainer = InstrumentClient(sourceServiceClient.GetBlobContainerClient("test1"));
            BlobContainerClient destinationContainer = InstrumentClient(destinationServiceClient.GetBlobContainerClient("test2"));

            // Arrange
            string blob_name = "netgetpropertiesors2blobapitestgetpropertiesors";
            BlobClient sourceBlob = sourceContainer.GetBlobClient(blob_name);
            BlobClient destBlob = destinationContainer.GetBlobClient(blob_name);

            // Act
            Response<BlobProperties> source_response = await sourceBlob.GetPropertiesAsync();
            Response<BlobProperties> dest_response = await destBlob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(1, source_response.Value.ObjectReplicationSourceProperties.Count);
            Assert.IsNull(source_response.Value.ObjectReplicationDestinationPolicyId);
            Assert.IsNotEmpty(dest_response.Value.ObjectReplicationDestinationPolicyId);
            Assert.IsNull(dest_response.Value.ObjectReplicationSourceProperties);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetPropertiesAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            await blob.SetHttpHeadersAsync(new BlobHttpHeaders
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
        public async Task SetHttpHeadersAsync_MultipleHeaders()
        {
            var constants = new TestConstants(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            await blob.SetHttpHeadersAsync(new BlobHttpHeaders
            {
                ContentEncoding = "deflate, gzip",
                ContentLanguage = "de-DE, en-CA",
            });

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            Assert.AreEqual("deflate,gzip", response.Value.ContentEncoding);
            Assert.AreEqual("de-DE,en-CA", response.Value.ContentLanguage);
        }

        [Test]
        public async Task SetHttpHeadersAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobInfo> response = await blob.SetHttpHeadersAsync(
                    httpHeaders: new BlobHttpHeaders(),
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task SetHttpHeadersAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.SetHttpHeadersAsync(
                        httpHeaders: new BlobHttpHeaders(),
                        conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetHttpHeadersAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
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
            Response<BlobInfo> response = await blob.SetHttpHeadersAsync(
                new BlobHttpHeaders
                {
                    ContentEncoding = "deflate, gzip",
                    ContentLanguage = "de-DE, en-CA",
                },
                conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetHttpHeadersAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetHttpHeadersAsync(
                    new BlobHttpHeaders
                    {
                        ContentEncoding = "deflate, gzip",
                        ContentLanguage = "de-DE, en-CA",
                    },
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task SetHttpHeadersAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetHttpHeadersAsync(new BlobHttpHeaders()),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await blob.SetMetadataAsync(metadata);

            // Assert
            Response<BlobProperties> response = await blob.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetMetadataAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<BlobInfo> response = await blob.SetMetadataAsync(metadata);

            // Assert
            Assert.IsNotNull(response.Value.VersionId);
        }

        [Test]
        public async Task SetMetadataAsync_CPK()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateAsync();

            // Act
            await blob.SetMetadataAsync(metadata);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetMetadataAsync_EncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            IDictionary<string, string> metadata = BuildMetadata();
            await blob.CreateAsync();

            // Act
            Response<BlobInfo> response = await blob.SetMetadataAsync(metadata);
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);
                IDictionary<string, string> metadata = BuildMetadata();

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobInfo> response = await blob.SetMetadataAsync(
                    metadata: metadata,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task SetMetadataAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);
                IDictionary<string, string> metadata = BuildMetadata();

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.SetMetadataAsync(
                        metadata: metadata,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetMetadataAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<BlobInfo> response = await blob.SetMetadataAsync(
                metadata: metadata,
                conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetMetadataAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetMetadataAsync(
                    metadata: metadata,
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetMetadataAsync(metadata),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task CreateSnapshotAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

        }

        [Test]
        public async Task CreateSnapshotAsync_CPK()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            blob = InstrumentClient(blob.WithCustomerProvidedKey(customerProvidedKey));
            await blob.CreateAsync();

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateSnapshotAsync_EncryptionScope()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            await blob.CreateAsync();

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task CreateSnapshotAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            }
        }

        [Test]
        public async Task CreateSnapshotAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.CreateSnapshotAsync(conditions: accessConditions),
                    e => { });

            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateSnapshotAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
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
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync(conditions: conditions);

            // Assert
            bool exists = await blob.WithSnapshot(response.Value.Snapshot).ExistsAsync();
            Assert.IsTrue(exists);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateSnapshotAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateSnapshotAsync(conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task CreateSnapshotAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateSnapshotAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateSnapshotAsync_Version()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response<BlobSnapshotInfo> response = await blob.CreateSnapshotAsync();

            // Assert
            Assert.IsNotNull(response.Value.VersionId);

        }

        [Test]
        public async Task AcquireLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<BlobLease> response = await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(duration);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                // Act
                Response<BlobLease> response = await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(
                    duration: duration,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(
                        duration: duration,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AcquireLeaseAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(
                duration,
                conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AcquireLeaseAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(
                    duration,
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task AcquireLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(duration),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<BlobLease> response = await lease.RenewAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await lease.RenewAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task RenewLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.RenewAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RenewLeaseAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await lease.RenewAsync(conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RenewLeaseAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                lease.RenewAsync(conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).ReleaseAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<ReleasedObjectInfo> response = await lease.ReleaseAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ReleaseAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ReleaseLeaseAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await lease.ReleaseAsync(conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ReleaseLeaseAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                lease.ReleaseAsync(conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).RenewAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<BlobLease> response = await lease.BreakAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task BreakLeaseAsync_BreakPeriod()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            TimeSpan breakPeriod = TimeSpan.FromSeconds(5);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<BlobLease> response = await lease.BreakAsync(breakPeriod: breakPeriod);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await lease.BreakAsync(conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task BreakLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.BreakAsync(conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task BreakLeaseAsync_IfTag()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await lease.BreakAsync(conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task BreakLeaseAsync_IfTagFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                lease.BreakAsync(conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient()).BreakAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<BlobLease> response = await lease.ChangeAsync(newLeaseId);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditions_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                RequestConditions accessConditions = BuildRequestConditions(
                    parameters: parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<BlobLease> response = await lease.ChangeAsync(
                    proposedId: newLeaseId,
                    conditions: accessConditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_AccessConditionsFail_Data)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                // Arrange
                BlobBaseClient blob = await GetNewBlobClient(test.Container);

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                RequestConditions accessConditions = BuildRequestConditions(parameters);

                BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ChangeAsync(
                        proposedId: newLeaseId,
                        conditions: accessConditions),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ChangeLeaseAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await lease.ChangeAsync(
                newLeaseId,
                conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ChangeLeaseAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobLeaseRequestConditions conditions = new BlobLeaseRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            BlobLeaseClient lease = InstrumentClient(blob.GetBlobLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                lease.ChangeAsync(
                newLeaseId,
                conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(blob.GetBlobLeaseClient(leaseId)).ChangeAsync(proposedId: newLeaseId),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetTierAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            // Act
            Response response = await blob.SetAccessTierAsync(AccessTier.Cool);

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task SetTierAsync_Lease()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            await InstrumentClient(blob.GetBlobLeaseClient(leaseId)).AcquireAsync(duration);

            // Act
            Response response = await blob.SetAccessTierAsync(
                accessTier: AccessTier.Cool,
                conditions: new BlobRequestConditions
                {
                    LeaseId = leaseId
                });

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task SetTierAsync_LeaseFail()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetAccessTierAsync(
                    accessTier: AccessTier.Cool,
                    conditions: new BlobRequestConditions
                    {
                        LeaseId = leaseId
                    }),
                e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
        }

        [Test]
        public async Task SetTierAsync_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetAccessTierAsync(AccessTier.Cool),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetTierAsync_Rehydrate()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            await blob.SetAccessTierAsync(AccessTier.Archive);

            // Act
            Response setTierResponse = await blob.SetAccessTierAsync(
                accessTier: AccessTier.Cool,
                rehydratePriority: RehydratePriority.High);
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual("rehydrate-pending-to-cool", propertiesResponse.Value.ArchiveStatus);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_Snapshot()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();
            BlobBaseClient snapshotBlob = blob.WithSnapshot(snapshotResponse.Value.Snapshot);

            // Act
            await snapshotBlob.SetAccessTierAsync(AccessTier.Cool);
            Response<BlobProperties> propertiesResponse = await snapshotBlob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(AccessTier.Cool.ToString(), propertiesResponse.Value.AccessTier);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_SnapshotError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            string fakeVersion = "2020-04-17T20:37:16.5129130Z";
            BlobBaseClient snapshotBlob = blob.WithSnapshot(fakeVersion);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                snapshotBlob.SetAccessTierAsync(AccessTier.Cool),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_Version()
        {
            // Arrange
            var constants = new TestConstants(this);
            await using DisposingContainer test = await GetTestContainerAsync();
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Response<BlobContentInfo> uploadResponse;
            using (var stream = new MemoryStream(data))
            {
                uploadResponse = await blob.UploadAsync(stream);
            }

            // Act
            BlobBaseClient versionBlob = blob.WithVersion(uploadResponse.Value.VersionId);

            // Act
            await versionBlob.SetAccessTierAsync(AccessTier.Cool);
            Response<BlobProperties> propertiesResponse = await versionBlob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(AccessTier.Cool.ToString(), propertiesResponse.Value.AccessTier);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTierAsync_VersionError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            string fakeVersion = "2020-04-17T20:37:16.5129130Z";
            BlobBaseClient versionBlob = blob.WithVersion(fakeVersion);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.SetAccessTierAsync(AccessTier.Cool),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            Dictionary<string, string> tags = BuildTags();

            // Act
            await blob.SetTagsAsync(tags);
            Response<IDictionary<string, string>> getTagsResponse = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_BlobTagSas()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetBlobSas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Tag,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await sasBlob.SetTagsAsync(tags);
            Response<IDictionary<string, string>> getTagsResponse = await sasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_InvalidBlobSas()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetBlobSas(
                test.Container.Name, blob.Name,
                BlobSasPermissions.Read,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasBlob.SetTagsAsync(tags),
                e => Assert.AreEqual(BlobErrorCode.AuthorizationPermissionMismatch.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_BlobIdentityTagSas()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            SasQueryParameters sasQueryParameters = GetBlobIdentitySas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Tag,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);

            BlobBaseClient identitySasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await identitySasBlob.SetTagsAsync(tags);
            Response<IDictionary<string, string>> getTagsResponse = await identitySasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_InvalidBlobIdentitySas()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            SasQueryParameters sasQueryParameters = GetBlobIdentitySas(
                test.Container.Name,
                blob.Name,
                BlobSasPermissions.Read,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);

            BlobBaseClient identitySasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identitySasBlob.SetTagsAsync(tags),
                e => Assert.AreEqual(BlobErrorCode.AuthorizationPermissionMismatch.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_ContainerTagSas()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetContainerSas(
                test.Container.Name,
                BlobContainerSasPermissions.Tag,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await sasBlob.SetTagsAsync(tags);
            Response<IDictionary<string, string>> getTagsResponse = await sasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_InvalidContainerSas()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetContainerSas(
                test.Container.Name,
                BlobContainerSasPermissions.Read,
                sasVersion: Constants.DefaultSasVersion);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasBlob.SetTagsAsync(tags),
                e => Assert.AreEqual(BlobErrorCode.AuthorizationPermissionMismatch.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_ContainerIdentityTagSas()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            SasQueryParameters sasQueryParameters = GetContainerIdentitySas(
                test.Container.Name,
                BlobContainerSasPermissions.Tag,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);

            BlobBaseClient identitySasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await identitySasBlob.SetTagsAsync(tags);
            Response<IDictionary<string, string>> getTagsResponse = await identitySasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_InvalidContainerIdentitySas()
        {
            BlobServiceClient oauthService = GetServiceClient_OauthAccount();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            SasQueryParameters sasQueryParameters = GetContainerIdentitySas(
                test.Container.Name,
                BlobContainerSasPermissions.Read,
                userDelegationKey,
                oauthService.AccountName,
                sasVersion: Constants.DefaultSasVersion);

            BlobBaseClient identitySasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identitySasBlob.SetTagsAsync(tags),
                e => Assert.AreEqual(BlobErrorCode.AuthorizationPermissionMismatch.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(AccountSasPermissions.Tag)]
        [TestCase(AccountSasPermissions.All)]
        public async Task GetSetTagsAsync_AccountSas(AccountSasPermissions accountSasPermissions)
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials(accountSasPermissions: accountSasPermissions);
            BlobBaseClient sasBlob = new BlobBaseClient(new Uri($"{blob.Uri}?{sasQueryParameters}"), GetOptions());

            Dictionary<string, string> tags = BuildTags();

            // Act
            await sasBlob.SetTagsAsync(tags);
            Response<IDictionary<string, string>> getTagsResponse = await sasBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };

            await blob.SetTagsAsync(tags);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            tags.Add("anotherTag", "anotherValue");

            // Act
            await blob.SetTagsAsync(
                tags,
                conditions: conditions);
            Response<IDictionary<string, string>> getTagsResponse = await blob.GetTagsAsync(
                conditions: conditions);

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetTagsAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetTagsAsync(
                conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTagsAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetTagsAsync(
                    tags,
                conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_Version()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(BuildMetadata());
            BlobBaseClient versionBlob = blob.WithVersion(metadataResponse.Value.VersionId);
            Dictionary<string, string> tags = BuildTags();

            // Act
            await versionBlob.SetTagsAsync(tags);
            Response<IDictionary<string, string>> getVersionTagsResponse = await versionBlob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getVersionTagsResponse.Value);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetSetTagsAsync_VersionError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);
            string fakeVersion = "2020-04-17T21:55:48.6692074Z";
            BlobBaseClient versionBlob = blob.WithVersion(fakeVersion);
            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.SetTagsAsync(tags),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                versionBlob.GetTagsAsync(),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task GetTagsAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = InstrumentClient(test.Container.GetBlobBaseClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.GetTagsAsync(),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetTagsAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = InstrumentClient(test.Container.GetBlobBaseClient(GetNewBlobName()));
            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetTagsAsync(tags),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        //[Test]
        //public async Task SetTierAsync_Batch()
        //{
        //    using (this.GetNewContainer(out var container, service: this.GetServiceClient_PreviewAccount_SharedKey()))
        //    {
        //        const int blobSize = Constants.KB;
        //        var data = this.GetRandomBuffer(blobSize);

        //        var blob1 = this.InstrumentClient(container.CreateBlockBlobClient(this.GetNewBlobName()));
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob1.UploadAsync(stream);
        //        }

        //        var blob2 = this.InstrumentClient(container.CreateBlockBlobClient(this.GetNewBlobName()));
        //        using (var stream = new MemoryStream(data))
        //        {
        //            await blob2.UploadAsync(stream);
        //        }

        //        var batch =
        //            blob1.SetTierAsync(AccessTier.Cool)
        //            .And(blob2.SetTierAsync(AccessTier.Cool))
        //            ;

        //        var result = await batch;

        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(2, result.Length);
        //        Assert.IsNotNull(result[0].RequestId);
        //        Assert.IsNotNull(result[1].RequestId);
        //    }
        //}

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

        private async Task<BlobBaseClient> GetNewBlobClient(BlobContainerClient container, string blobName = default)
        {
            blobName ??= GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            return blob;
        }

        public IEnumerable<AccessConditionParameters> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };

        public IEnumerable<AccessConditionParameters> GetAccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
             };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
            };

        public IEnumerable<AccessConditionParameters> NoLease_AccessConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
            };

        private RequestConditions BuildRequestConditions(
            AccessConditionParameters parameters)
            => new RequestConditions
            {
                IfModifiedSince = parameters.IfModifiedSince,
                IfUnmodifiedSince = parameters.IfUnmodifiedSince,
                IfMatch = parameters.Match != null ? new ETag(parameters.Match) : default(ETag?),
                IfNoneMatch = parameters.NoneMatch != null ? new ETag(parameters.NoneMatch) : default(ETag?)
            };

        private BlobRequestConditions BuildAccessConditions(
            AccessConditionParameters parameters,
            bool lease = true)
        {
            var accessConditions = BuildRequestConditions(parameters).ToBlobRequestConditions();
            if (lease)
            {
                accessConditions.LeaseId = parameters.LeaseId;
            }
            return accessConditions;
        }

        public class AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string Match { get; set; }
            public string NoneMatch { get; set; }
            public string LeaseId { get; set; }
        }
    }
}
