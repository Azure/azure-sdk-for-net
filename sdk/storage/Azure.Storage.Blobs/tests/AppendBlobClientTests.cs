// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class AppendBlobClientTests : BlobTestBase
    {
        public AppendBlobClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

            AppendBlobClient blob = InstrumentClient(new AppendBlobClient(connectionString.ToString(true), containerName, blobName, GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public void Ctor_Uri()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();

            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName}");

            // Act
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri);

            // Assert
            BlobUriBuilder builder = new BlobUriBuilder(appendBlobClient.Uri);

            Assert.AreEqual(containerName, builder.BlobContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public void Ctor_TokenAuth_Http()
        {
            // Arrange
            Uri httpUri = new Uri(TestConfigOAuth.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new AppendBlobClient(httpUri, GetOAuthCredential()),
                 new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
        public void Ctor_CPK_Http()
        {
            // Arrange
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlobClientOptions blobClientOptions = new BlobClientOptions
            {
                CustomerProvidedKey = customerProvidedKey
            };
            Uri httpUri = new Uri(TestConfigDefault.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new AppendBlobClient(httpUri, blobClientOptions),
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
                () => new AppendBlobClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [Test]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            var client = test.Container.GetAppendBlobClient(GetNewBlobName());
            await client.CreateAsync();
            Uri blobUri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new AppendBlobClient(blobUri, new AzureSasCredential(sas), GetOptions()));
            BlobProperties blobProperties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(blobProperties);
        }

        [Test]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            Uri blobUri = test.Container.GetAppendBlobClient("foo").Uri;
            blobUri = new Uri(blobUri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new AppendBlobClient(blobUri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [Test]
        public void WithSnapshot()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = "my/blob/name";
            string snapshot = "2020-07-03T12:45:46.1234567Z";
            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{Uri.EscapeDataString(blobName)}");
            Uri snapshotUri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{Uri.EscapeDataString(blobName)}?snapshot={snapshot}");

            // Act
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri);
            AppendBlobClient snapshotAppendBlobClient = appendBlobClient.WithSnapshot(snapshot);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(snapshotAppendBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, snapshotAppendBlobClient.AccountName);
            Assert.AreEqual(containerName, snapshotAppendBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, snapshotAppendBlobClient.Name);
            Assert.AreEqual(snapshotUri, snapshotAppendBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(snapshot, blobUriBuilder.Snapshot);
            Assert.AreEqual(snapshotUri, blobUriBuilder.ToUri());
        }

        [Test]
        public void WithVersion()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = "my/blob/name";
            string versionId = "2020-07-03T12:45:46.1234567Z";
            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{Uri.EscapeDataString(blobName)}");
            Uri versionUri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{Uri.EscapeDataString(blobName)}?versionid={versionId}");

            // Act
            AppendBlobClient appendBlobClient = new AppendBlobClient(uri);
            AppendBlobClient versionAppendBlobClient = appendBlobClient.WithVersion(versionId);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(versionAppendBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, versionAppendBlobClient.AccountName);
            Assert.AreEqual(containerName, versionAppendBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, versionAppendBlobClient.Name);
            Assert.AreEqual(versionUri, versionAppendBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(versionId, blobUriBuilder.VersionId);
            Assert.AreEqual(versionUri, blobUriBuilder.ToUri());
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
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_Tags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = BuildTags()
            };

            // Act
            await blob.CreateAsync(options);
            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(options.Tags, response.Value.Tags);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_TagsWithSpecialCharacters()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                Tags = new Dictionary<string, string>
                {
                    { " +-.:", "_ =" },
                    { "+-.:= _", "+ // _"}
                }
            };

            // Act
            await blob.CreateAsync(options);
            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(options.Tags, response.Value.Tags);
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
            AssertDictionaryEquality(metadata, response.Value.Metadata);
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
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
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
                actualException => Assert.AreEqual(BlobErrorCode.ContainerNotFound.ToString(), actualException.ErrorCode)
                );
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_VersionId()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));

            // Act
            Response<BlobContentInfo> response = await blob.CreateAsync();

            // Assert
            Assert.IsNotNull(response.Value.VersionId);
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
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await blob.CreateAsync(conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task CreateAsync_IfTagsFailed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.CreateAsync(
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
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
            Response<BlobContentInfo> response = await blob.CreateIfNotExistsAsync();

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
                actualException => Assert.AreEqual(BlobErrorCode.ContainerNotFound.ToString(), actualException.ErrorCode)
                );
        }

        [Test]
        public async Task AppendBlockAsync()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
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
            await blob.CreateIfNotExistsAsync();

            // Act
            using var stream = new MemoryStream(data);
            Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                content: stream);

            // Assert
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AppendBlockAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            blob = InstrumentClient(blob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
            var data = GetRandomBuffer(Constants.KB);
            await blob.CreateIfNotExistsAsync();

            // Act
            using var stream = new MemoryStream(data);
            Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                content: stream);

            // Assert
            Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
        }

        [Test]
        public async Task AppendBlockAsync_MD5()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateIfNotExistsAsync();
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
            await blob.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.AppendBlockAsync(
                        content: stream,
                        transactionalContentHash: MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("garbage"))),
                    e => Assert.AreEqual("Md5Mismatch", e.ErrorCode));
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
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
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
                await blob.CreateIfNotExistsAsync();
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
                await blob.CreateIfNotExistsAsync();
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
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendBlockAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = test.Container.GetAppendBlobClient(GetNewBlobName());
            await blob.CreateAsync();
            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blob.SetTagsAsync(tags);

            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);
            using Stream stream = new MemoryStream(data);

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            Response<BlobAppendInfo> response = await blob.AppendBlockAsync(
                content: stream,
                conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendBlockAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = test.Container.GetAppendBlobClient(GetNewBlobName());
            await blob.CreateAsync();

            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);
            using Stream stream = new MemoryStream(data);

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.AppendBlockAsync(
                    content: stream,
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
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

            await blob.CreateIfNotExistsAsync();

            var data = GetRandomBuffer(blobSize);
            var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
            var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
            var timesFaulted = 0;

            // Act
            using (var stream = new FaultyStream(
                new MemoryStream(data),
                256 * Constants.KB,
                1,
                new IOException("Simulated stream fault"),
                () => timesFaulted++))
            {
                await blobFaulty.AppendBlockAsync(stream, progressHandler: progressHandler);
                await WaitForProgressAsync(progressBag, data.LongLength);
                Assert.IsTrue(progressBag.Count > 1, "Too few progress received");
                // Changing from Assert.AreEqual because these don't always update fast enough
                if (progressBag.Count > 0)
                {
                    Assert.GreaterOrEqual(data.LongLength, progressBag.Max(), "Final progress has unexpected value");
                }
            }

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            Assert.AreEqual(data.Length, actual.Length);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreNotEqual(0, timesFaulted);
        }

        [LiveOnly]
        [Test]
        public async Task AppendBlockAsync_ProgressReporting()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateIfNotExistsAsync();
            const int blobSize = 4 * Constants.MB;
            var data = GetRandomBuffer(blobSize);
            TestProgress progress = new TestProgress();

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.AppendBlockAsync(stream, progressHandler: progress);
            }

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(blobSize, progress.List[progress.List.Count - 1]);
        }

        [Test]
        public async Task AppendBlockAsync_InvalidStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            const int blobSize = Constants.KB;
            var data = GetRandomBuffer(blobSize);

            // Act
            using Stream stream = new MemoryStream(data);
            stream.Position = stream.Length;

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.AppendBlockAsync(stream),
                e => Assert.AreEqual("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.", e.Message));
        }

        [Test]
        public async Task AppendBlockAsync_NonZeroStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            const int blobSize = Constants.KB;
            long position = 512;
            byte[] data = GetRandomBuffer(blobSize);
            byte[] expectedData = new byte[blobSize - position];
            Array.Copy(data, position, expectedData, 0, blobSize - position);

            // Act
            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };
            await blob.AppendBlockAsync(stream);

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync();
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(blobSize - position, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
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
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

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
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
                destBlob = InstrumentClient(destBlob.WithCustomerProvidedKey(customerProvidedKey));
                await destBlob.CreateIfNotExistsAsync();

                // Act
                Response<BlobAppendInfo> response = await destBlob.AppendBlockFromUriAsync(
                    sourceBlob.Uri,
                    new HttpRange(0, Constants.KB));

                Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AppendBlockFromUriAsync_EncryptionScope()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                destBlob = InstrumentClient(destBlob.WithEncryptionScope(TestConfigDefault.EncryptionScope));
                await destBlob.CreateIfNotExistsAsync();

                // Act
                Response<BlobAppendInfo> response = await destBlob.AppendBlockFromUriAsync(
                    sourceBlob.Uri,
                    new HttpRange(0, Constants.KB));

                Assert.AreEqual(TestConfigDefault.EncryptionScope, response.Value.EncryptionScope);
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
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

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
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

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
                await sourceBlob.CreateIfNotExistsAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateIfNotExistsAsync();

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
                    await sourceBlob.CreateIfNotExistsAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await destBlob.CreateIfNotExistsAsync();

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
                    await sourceBlob.CreateIfNotExistsAsync();
                    await sourceBlob.AppendBlockAsync(stream);

                    AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await destBlob.CreateIfNotExistsAsync();

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

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendBlockFromUriAsync_IfTags()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await sourceBlob.CreateAsync();
            await sourceBlob.AppendBlockAsync(stream);

            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await destBlob.CreateAsync();

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await destBlob.SetTagsAsync(tags);

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await destBlob.AppendBlockFromUriAsync(
                sourceBlob.Uri,
                new HttpRange(0, Constants.KB),
                conditions: conditions);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendBlockFromUriAsync_IfTagsFailed()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await sourceBlob.CreateAsync();
            await sourceBlob.AppendBlockAsync(stream);

            AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await destBlob.CreateAsync();

            AppendBlobRequestConditions conditions = new AppendBlobRequestConditions
            {
                TagConditions = "\"coolTag\" = 'true'"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destBlob.AppendBlockFromUriAsync(
                    sourceBlob.Uri,
                    new HttpRange(0, Constants.KB),
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task AppendBlockFromUriAsync_NonAsciiSourceUri()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            await test.Container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                AppendBlobClient sourceBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewNonAsciiBlobName()));
                await sourceBlob.CreateAsync();
                await sourceBlob.AppendBlockAsync(stream);

                AppendBlobClient destBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await destBlob.CreateAsync();

                // Act
                await destBlob.AppendBlockFromUriAsync(sourceBlob.Uri, new HttpRange(0, Constants.KB));
            }
        }

        [Test]
        public async Task AppendBlockAsync_NullStream_Error()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));

            // Act
            using (var stream = (MemoryStream)null)
            {
                // Check if the correct param name that is causing the error is being returned
                await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                    blob.AppendBlockAsync(content: stream),
                    e => Assert.AreEqual("body", e.ParamName));
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SealAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await appendBlob.CreateAsync();

            // Act
            await appendBlob.SealAsync();
            Response<BlobProperties> propertiesResponse = await appendBlob.GetPropertiesAsync();
            Response<BlobDownloadInfo> downloadResponse = await appendBlob.DownloadAsync();
            IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();

            // Assert
            Assert.IsTrue(propertiesResponse.Value.IsSealed);
            Assert.IsTrue(downloadResponse.Value.Details.IsSealed);
            Assert.IsTrue(blobs.First().Properties.IsSealed);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SealAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient appendBlob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                appendBlob.SealAsync(),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SealAsync_AccessConditions()
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
            };

            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await blob.CreateAsync();
                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                // Act
                Response<BlobInfo> response = await blob.SealAsync(accessConditions);

                // Assert
                Assert.IsNotNull(response.Value.ETag);
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SealAsync_AccessConditionsFailed()
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
            };

            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();

                // Arrange
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                // AppendBlob needs to exists for us to test CreateAsync() with access conditions
                await blob.CreateAsync();
                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blob.SealAsync(
                        conditions: accessConditions),
                    e => { });
            }
        }

        public async Task GetAppendBlobClient_AsciiName()
        {
            //Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            //Act
            AppendBlobClient blob = test.Container.GetAppendBlobClient(blobName);
            await blob.CreateAsync();

            //Assert
            List<string> names = new List<string>();
            await foreach (BlobItem pathItem in test.Container.GetBlobsAsync())
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(blobName, names);
        }

        [Test]
        public async Task GetAppendBlobClient_NonAsciiName()
        {
            //Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewNonAsciiBlobName();

            //Act
            AppendBlobClient blob = test.Container.GetAppendBlobClient(blobName);
            await blob.CreateAsync();

            //Assert
            List<string> names = new List<string>();
            await foreach (BlobItem pathItem in test.Container.GetBlobsAsync())
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(blobName, names);
        }

        [Test]
        public async Task OpenWriteAsync_NewBlob()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            AppendBlobOpenWriteOptions options = new AppendBlobOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            Stream stream = await blob.OpenWriteAsync(
                overwrite: false,
                options);

            byte[] data = GetRandomBuffer(16 * Constants.KB);

            // Act
            await stream.WriteAsync(data, 0, 512);
            await stream.WriteAsync(data, 512, 1024);
            await stream.WriteAsync(data, 1536, 2048);
            await stream.WriteAsync(data, 3584, 77);
            await stream.WriteAsync(data, 3661, 2066);
            await stream.WriteAsync(data, 5727, 4096);
            await stream.WriteAsync(data, 9823, 6561);
            await stream.FlushAsync();

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, data.Length));
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_NewBlob_WithUsing()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            AppendBlobOpenWriteOptions options = new AppendBlobOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            byte[] data = GetRandomBuffer(16 * Constants.KB);

            // Act
            using (Stream stream = await blob.OpenWriteAsync(
                overwrite: false,
                options))
            {
                await stream.WriteAsync(data, 0, 512);
                await stream.WriteAsync(data, 512, 1024);
                await stream.WriteAsync(data, 1536, 2048);
                await stream.WriteAsync(data, 3584, 77);
                await stream.WriteAsync(data, 3661, 2066);
                await stream.WriteAsync(data, 5727, 4096);
                await stream.WriteAsync(data, 9823, 6561);
            }

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, data.Length));
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_AppendExistingBlob()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();

            byte[] originalData = GetRandomBuffer(Constants.KB);
            using Stream originalStream = new MemoryStream(originalData);

            await blob.AppendBlockAsync(content: originalStream);

            byte[] newData = GetRandomBuffer(Constants.KB);
            using Stream newStream = new MemoryStream(newData);

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(overwrite: false);
            await newStream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            byte[] expectedData = new byte[2 * Constants.KB];
            Array.Copy(originalData, 0, expectedData, 0, Constants.KB);
            Array.Copy(newData, 0, expectedData, Constants.KB, Constants.KB);

            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_AlternatingWriteAndFlush()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            byte[] data0 = GetRandomBuffer(512);
            byte[] data1 = GetRandomBuffer(512);
            using Stream dataStream0 = new MemoryStream(data0);
            using Stream dataStream1 = new MemoryStream(data1);
            byte[] expectedData = new byte[Constants.KB];
            Array.Copy(data0, expectedData, 512);
            Array.Copy(data1, 0, expectedData, 512, 512);

            // Act
            Stream writeStream = await blob.OpenWriteAsync(overwrite: true);
            await dataStream0.CopyToAsync(writeStream);
            await writeStream.FlushAsync();
            await dataStream1.CopyToAsync(writeStream);
            await writeStream.FlushAsync();

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(GetNewContainerName()));
            AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.OpenWriteAsync(overwrite: false),
                e => Assert.AreEqual(BlobErrorCode.ContainerNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task OpenWriteAsync_ModifiedDuringWrite()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            AppendBlobOpenWriteOptions options = new AppendBlobOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(
                overwrite: false,
                options);

            await stream.CopyToAsync(openWriteStream);
            stream.Position = 0;

            await blob.AppendBlockAsync(stream);
            stream.Position = 0;

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                stream.CopyToAsync(openWriteStream),
                e => Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task OpenWriteAsync_ProgressReporting()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            TestProgress progress = new TestProgress();
            AppendBlobOpenWriteOptions options = new AppendBlobOpenWriteOptions
            {
                ProgressHandler = progress,
                BufferSize = 256
            };

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(
                overwrite: false,
                options);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            Assert.IsTrue(progress.List.Count > 0);
            Assert.AreEqual(Constants.KB, progress.List[progress.List.Count - 1]);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task OpenWriteAsync_OverwiteNewBlob(bool blobExists)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
            if (blobExists)
            {
                await blob.CreateAsync();
            }

            byte[] expectedData = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(expectedData);

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(overwrite: false);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            Response<BlobDownloadInfo> result = await blob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task OpenWriteAsync_AccessConditions(bool overwrite)
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
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await blob.CreateAsync();

                parameters.Match = await SetupBlobMatchCondition(blob, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blob, parameters.LeaseId, garbageLeaseId);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                byte[] data = GetRandomBuffer(7);
                using Stream stream = new MemoryStream(data);

                AppendBlobOpenWriteOptions options = new AppendBlobOpenWriteOptions
                {
                    OpenConditions = accessConditions
                };

                // Act
                Stream openWriteStream = await blob.OpenWriteAsync(
                    overwrite: overwrite,
                    options);
                await stream.CopyToAsync(openWriteStream);
                await openWriteStream.FlushAsync();

                // Assert
                Response<BlobDownloadInfo> result = await blob.DownloadAsync();
                MemoryStream dataResult = new MemoryStream();
                await result.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(data.Length, dataResult.Length);
                TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
            }
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task OpenWriteAsync_AccessConditionsFail(bool overwite)
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] testCases = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (AccessConditionParameters parameters in testCases)
            {
                await using DisposingContainer test = await GetTestContainerAsync();
                AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                await blob.CreateAsync();
                parameters.NoneMatch = await SetupBlobMatchCondition(blob, parameters.NoneMatch);
                AppendBlobRequestConditions accessConditions = BuildDestinationAccessConditions(
                    parameters: parameters,
                    lease: true,
                    appendPosAndMaxSize: true);

                byte[] data = GetRandomBuffer(7);
                using Stream stream = new MemoryStream(data);

                AppendBlobOpenWriteOptions options = new AppendBlobOpenWriteOptions
                {
                    OpenConditions = accessConditions
                };

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        Stream openWriteStream = await blob.OpenWriteAsync(
                            overwrite: true,
                            options);
                        await stream.CopyToAsync(openWriteStream);
                        await openWriteStream.FlushAsync();
                    });
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
