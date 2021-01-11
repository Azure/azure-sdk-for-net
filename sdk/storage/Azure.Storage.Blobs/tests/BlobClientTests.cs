// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobClientTests : BlobTestBase
    {
        public BlobClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
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

            BlobClient blob1 = InstrumentClient(new BlobClient(connectionString.ToString(true), containerName, blobName, GetOptions()));

            BlobClient blob2 = InstrumentClient(new BlobClient(connectionString.ToString(true), containerName, blobName));

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
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var blobEndpoint = new Uri("https://127.0.0.1/" + accountName);
            BlobClient blob1 = InstrumentClient(new BlobClient(blobEndpoint));
            BlobClient blob2 = InstrumentClient(new BlobClient(blobEndpoint, new SharedTokenCacheCredential()));

            var builder1 = new BlobUriBuilder(blob1.Uri);
            var builder2 = new BlobUriBuilder(blob2.Uri);

            Assert.AreEqual(accountName, builder1.AccountName);
            Assert.AreEqual(accountName, builder2.AccountName);
        }

        [Test]
        public void Ctor_UriNonIpStyle()
        {
            // Arrange
            string accountName = "accountname";
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();

            Uri uri = new Uri($"https://{accountName}.blob.core.windows.net/{containerName}/{blobName}");

            // Act
            BlobClient blobClient = new BlobClient(uri);

            // Assert
            BlobUriBuilder builder = new BlobUriBuilder(blobClient.Uri);

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
                () => new BlobClient(httpUri, GetOAuthCredential()),
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
                () => new BlobClient(httpUri, blobClientOptions),
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
                () => new BlobClient(new Uri(TestConfigDefault.BlobServiceEndpoint), blobClientOptions),
                new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set"));
        }

        [Test]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string sas = GetContainerSas(test.Container.Name, BlobContainerSasPermissions.All).ToString();
            var client = test.Container.GetBlobClient(GetNewBlobName());
            await client.UploadAsync(new MemoryStream());
            Uri blobUri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new BlobClient(blobUri, new AzureSasCredential(sas), GetOptions()));
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
            Uri blobUri = test.Container.GetBlobClient("foo").Uri;
            blobUri = new Uri(blobUri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new BlobClient(blobUri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        #region Upload

        [Test]
        public async Task UploadAsync_Stream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            System.Collections.Generic.IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(name, blobs.First().Name);

            Response<BlobDownloadInfo> download = await blob.DownloadAsync();
            using var actual = new MemoryStream();
            await download.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadAsync_Stream_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);
            IDictionary<string, string> tags = BuildTags();
            BlobUploadOptions options = new BlobUploadOptions
            {
                Tags = tags
            };

            // Act
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream, options);
            }

            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, response.Value.Tags);
        }

        [Test]
        public async Task UploadAsync_Stream_UploadsBlock()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        [TestCase(null)]
        public async Task UploadAsync_Stream_StorageTransferOptions(int? maximumThreadCount)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var options = new StorageTransferOptions { MaximumConcurrency = maximumThreadCount };

                await Verify(stream => blob.UploadAsync(stream, transferOptions: options));

                async Task Verify(Func<Stream, Task<Response<BlobContentInfo>>> upload)
                {
                    using (var stream = new MemoryStream(data))
                    {
                        await upload(stream);
                    }

                    Response<BlobDownloadInfo> download = await blob.DownloadAsync();
                    using var actual = new MemoryStream();
                    await download.Value.Content.CopyToAsync(actual);
                    TestHelper.AssertSequenceEqual(data, actual.ToArray());
                }
            }

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        public async Task UploadAsync_Stream_Overloads()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            await Verify(stream => blob.UploadAsync(stream));
            await Verify(stream => blob.UploadAsync(stream, true, CancellationToken.None));
            await Verify(stream => blob.UploadAsync(stream, metadata: default));

            async Task Verify(Func<Stream, Task<Response<BlobContentInfo>>> upload)
            {
                using (var stream = new MemoryStream(data))
                {
                    await upload(stream);
                }

                Response<BlobDownloadInfo> download = await blob.DownloadAsync();
                using var actual = new MemoryStream();
                await download.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task UploadAsync_Stream_NullStreamFail()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = (Stream)null)
            {
                // Check if the correct param name that is causing the error is being returned
                await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                    blob.UploadAsync(stream),
                    e => Assert.AreEqual("content", e.ParamName));
            }
        }

        [Test]
        public async Task UploadAsync_File()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    // Test that we can upload a read-only file.
                    File.SetAttributes(path, FileAttributes.ReadOnly);

                    await blob.UploadAsync(path);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.SetAttributes(path, FileAttributes.Normal);
                        File.Delete(path);
                    }
                }
            }

            System.Collections.Generic.IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(name, blobs.First().Name);

            Response<BlobDownloadInfo> download = await blob.DownloadAsync();
            using var actual = new MemoryStream();
            await download.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UploadAsync_File_Tags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);
            IDictionary<string, string> tags = BuildTags();
            BlobUploadOptions options = new BlobUploadOptions
            {
                Tags = tags
            };

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    // Test that we can upload a read-only file.
                    File.SetAttributes(path, FileAttributes.ReadOnly);

                    // Act
                    await blob.UploadAsync(path, options);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.SetAttributes(path, FileAttributes.Normal);
                        File.Delete(path);
                    }
                }
            }

            Response<GetBlobTagResult> response = await blob.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, response.Value.Tags);
        }

        [Test]
        public async Task UploadAsync_File_UploadsBlock()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await blob.UploadAsync(path);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        public async Task UploadAsync_Stream_InvalidStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            long size = Constants.KB;
            byte[] data = GetRandomBuffer(size);

            using Stream stream = new MemoryStream(data)
            {
                Position = size
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.UploadAsync(
                content: stream),
                e => Assert.AreEqual("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.", e.Message));
        }

        [Test]
        public async Task UploadAsync_NonZeroStreamPosition()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            long size = Constants.KB;
            long position = 512;
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            // Act
            await blob.UploadAsync(content: stream);

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [Test]
        public async Task UploadAsync_NonZeroStreamPositionMultipleBlocks()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            long size = 2 * Constants.KB;
            long position = 300;
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            BlobUploadOptions options = new BlobUploadOptions
            {
                TransferOptions = new StorageTransferOptions
                {
                    MaximumTransferSize = 512,
                    InitialTransferSize = 512
                }
            };

            // Act
            await blob.UploadAsync(
                content: stream,
                options: options);

            // Assert
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        [TestCase(null)]
        public async Task UploadAsync_File_StorageTransferOptions(int? maximumThreadCount)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    var options = new StorageTransferOptions { MaximumConcurrency = maximumThreadCount };

                    await Verify(blob.UploadAsync(path, transferOptions: options));

                    async Task Verify(Task<Response<BlobContentInfo>> upload)
                    {
                        using (var stream = new MemoryStream(data))
                        {
                            await upload;
                        }

                        Response<BlobDownloadInfo> download = await blob.DownloadAsync();
                        using var actual = new MemoryStream();
                        await download.Value.Content.CopyToAsync(actual);
                        TestHelper.AssertSequenceEqual(data, actual.ToArray());
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

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        [TestCase(1)]
        public async Task UploadAsync_File_AccessTier(int? maximumThreadCount)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await blob.UploadAsync(
                        path,
                        accessTier: AccessTier.Cool);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(AccessTier.Cool.ToString(), properties.Value.AccessTier);
        }

        [Test]
        [TestCase(1)]
        public async Task UploadAsync_File_AccessTierFail(int? maximumThreadCount)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    var options = new StorageTransferOptions { MaximumConcurrency = maximumThreadCount };

                    // Assert
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        blob.UploadAsync(
                        path,
                        transferOptions: options,
                        accessTier: AccessTier.P10),
                        e => Assert.AreEqual(BlobErrorCode.InvalidHeaderValue.ToString(), e.ErrorCode));
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
        }

        [Test]
        public async Task UploadAsync_File_Overloads()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            var path = Path.GetTempFileName();

            try
            {
                File.WriteAllBytes(path, data);

                await Verify(blob.UploadAsync(path));
                await Verify(blob.UploadAsync(path, true, CancellationToken.None));
                await Verify(blob.UploadAsync(path, metadata: default));

                async Task Verify(Task<Response<BlobContentInfo>> upload)
                {
                    using (var stream = new MemoryStream(data))
                    {
                        await upload;
                    }

                    Response<BlobDownloadInfo> download = await blob.DownloadAsync();
                    using var actual = new MemoryStream();
                    await download.Value.Content.CopyToAsync(actual);
                    TestHelper.AssertSequenceEqual(data, actual.ToArray());
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

        private async Task UploadStreamAndVerify(
            long size,
            StorageTransferOptions transferOptions)
        {
            using Stream stream = await CreateLimitedMemoryStream(size);
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            blob = InstrumentClient(new BlobClient(blob.Uri, credential, GetOptions(true)));

            await blob.StagedUploadInternal(
                content: stream,
                new BlobUploadOptions
                {
                    TransferOptions = transferOptions
                },
                async: true);

            await DownloadAndAssertAsync(stream, blob);
        }

        private async Task UploadFileAndVerify(
            long size,
            StorageTransferOptions transferOptions)
        {
            var path = Path.GetTempFileName();

            try
            {
                using Stream stream = await CreateLimitedMemoryStream(size);

                // create a new file and copy contents of stream into it, and then close the FileStream
                // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                using (FileStream fileStream = File.Create(path))
                {
                    await stream.CopyToAsync(fileStream);
                }

                await using DisposingContainer test = await GetTestContainerAsync();

                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
                var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                blob = InstrumentClient(new BlobClient(blob.Uri, credential, GetOptions(true)));

                await blob.StagedUploadInternal(
                    path: path,
                    new BlobUploadOptions
                    {
                        TransferOptions = transferOptions
                    },
                    async: true);

                await DownloadAndAssertAsync(stream, blob);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        private static async Task DownloadAndAssertAsync(Stream stream, BlobClient blob)
        {
            var actual = new byte[Constants.DefaultBufferSize];
            using var actualStream = new MemoryStream(actual);

            // reset the stream before validating
            stream.Seek(0, SeekOrigin.Begin);
            long size = stream.Length;
            // we are testing Upload, not download: so we download in partitions to avoid the default timeout
            for (var i = 0; i < size; i += Constants.DefaultBufferSize * 5 / 2)
            {
                var startIndex = i;
                var count = Math.Min(Constants.DefaultBufferSize, (int)(size - startIndex));

                Response<BlobDownloadInfo> download = await blob.DownloadAsync(new HttpRange(startIndex, count));
                actualStream.Seek(0, SeekOrigin.Begin);
                await download.Value.Content.CopyToAsync(actualStream);

                var buffer = new byte[count];
                stream.Seek(i, SeekOrigin.Begin);
                await stream.ReadAsync(buffer, 0, count);

                TestHelper.AssertSequenceEqual(
                    buffer,
                    actual.AsSpan(0, count).ToArray());
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
        // [TestCase(501 * Constants.KB)] // TODO: #6781 We don't want to add 500K of random data in the recordings
        public async Task UploadStreamAsync_SmallBlobs(long size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await UploadStreamAndVerify(
                size,
                new StorageTransferOptions
                {
                    MaximumTransferLength = Constants.KB,
                    InitialTransferLength = Constants.KB
                });

        [Test]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        // [TestCase(501 * Constants.KB)] // TODO: #6781 We don't want to add 500K of random data in the recordings
        public async Task UploadFileAsync_SmallBlobs(long size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await UploadFileAndVerify(
                size,
                new StorageTransferOptions
                {
                    MaximumTransferLength = Constants.KB,
                    InitialTransferLength = Constants.KB
                });

        [Test]
        [LiveOnly]
        [Explicit("These tests are timing out occasionally due to issue described in https://github.com/Azure/azure-sdk-for-net/issues/9340")]
        [TestCase(33 * Constants.MB, 1)]
        [TestCase(33 * Constants.MB, 4)]
        [TestCase(33 * Constants.MB, 8)]
        [TestCase(33 * Constants.MB, 16)]
        [TestCase(33 * Constants.MB, null)]
        [TestCase(257 * Constants.MB, 1)]
        [TestCase(257 * Constants.MB, 4)]
        [TestCase(257 * Constants.MB, 8)]
        [TestCase(257 * Constants.MB, null)]
        [TestCase(257 * Constants.MB, 16)]
        [TestCase(1 * Constants.GB, 1)]
        [TestCase(1 * Constants.GB, 4)]
        [TestCase(1 * Constants.GB, 8)]
        [TestCase(1 * Constants.GB, null)]
        [TestCase(1 * Constants.GB, 16)]
        public async Task UploadStreamAsync_LargeBlobs(long size, int? maximumThreadCount)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            await UploadStreamAndVerify(
                size,
                new StorageTransferOptions
                {
                    MaximumConcurrency = maximumThreadCount,
                    MaximumTransferLength = 16 * Constants.MB,
                    InitialTransferLength = 16 * Constants.MB
                });
        }

        [Test]
        [LiveOnly]
        [Explicit("These tests are timing out occasionally due to issue described in https://github.com/Azure/azure-sdk-for-net/issues/9340")]
        [TestCase(33 * Constants.MB, 1)]
        [TestCase(33 * Constants.MB, 4)]
        [TestCase(33 * Constants.MB, 8)]
        [TestCase(33 * Constants.MB, 16)]
        [TestCase(33 * Constants.MB, null)]
        [TestCase(257 * Constants.MB, 1)]
        [TestCase(257 * Constants.MB, 4)]
        [TestCase(257 * Constants.MB, 8)]
        [TestCase(257 * Constants.MB, null)]
        [TestCase(257 * Constants.MB, 16)]
        [TestCase(1 * Constants.GB, 1)]
        [TestCase(1 * Constants.GB, 4)]
        [TestCase(1 * Constants.GB, 8)]
        [TestCase(1 * Constants.GB, null)]
        [TestCase(1 * Constants.GB, 16)]
        public async Task UploadFileAsync_LargeBlobs(long size, int? maximumThreadCount)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            await UploadFileAndVerify(
                size,
                new StorageTransferOptions {
                    MaximumConcurrency = maximumThreadCount,
                    MaximumTransferLength = 16 * Constants.MB,
                    InitialTransferLength = 16 * Constants.MB
                });
        }

        [Test]
        public async Task UploadAsync_DoesNotOverwriteDefault_Stream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload one blob
            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            using var stream = new MemoryStream(GetRandomBuffer(Constants.KB));
            await blob.UploadAsync(stream);

            // Overwriting fails
            using var stream2 = new MemoryStream(GetRandomBuffer(Constants.KB));
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.UploadAsync(stream2));
        }

        [Test]
        public async Task UploadAsync_DoesNotOverwrite_Stream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload one blob
            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            using var stream = new MemoryStream(GetRandomBuffer(Constants.KB));
            await blob.UploadAsync(stream);

            // Overwriting fails
            using var stream2 = new MemoryStream(GetRandomBuffer(Constants.KB));
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.UploadAsync(stream2, overwrite: false));
        }

        [Test]
        public async Task UploadAsync_OverwritesDeliberately_Stream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload one blob
            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            using var stream = new MemoryStream(GetRandomBuffer(Constants.KB));
            await blob.UploadAsync(stream);

            // Overwriting works if allowed
            using var stream2 = new MemoryStream(GetRandomBuffer(Constants.KB));
            await blob.UploadAsync(stream2, overwrite: true);
        }

        [Test]
        public async Task UploadAsync_DoesNotOverwriteDefault_Path()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var path = Path.GetTempFileName();
            try
            {
                // Upload one blob
                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
                File.WriteAllBytes(path, GetRandomBuffer(Constants.KB));
                await blob.UploadAsync(path);

                // Overwriting fails
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await blob.UploadAsync(path));
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
        public async Task UploadAsync_DoesNotOverwrite_Path()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var path = Path.GetTempFileName();
            try
            {
                // Upload one blob
                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
                File.WriteAllBytes(path, GetRandomBuffer(Constants.KB));
                await blob.UploadAsync(path);

                // Overwriting fails
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await blob.UploadAsync(path, overwrite: false));
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
        public async Task UploadAsync_OverwritesDeliberately_Path()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var path = Path.GetTempFileName();
            try
            {
                // Upload one blob
                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
                File.WriteAllBytes(path, GetRandomBuffer(Constants.KB));
                await blob.UploadAsync(path);

                // Overwriting works if allowed
                await blob.UploadAsync(path, overwrite: true);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        [LiveOnly]
        [Test]
        [Explicit("#10716 - Disabled failing UploadAsync_ProgressReporting live test")]
        public async Task UploadAsync_ProgressReporting()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            TestProgress progress = new TestProgress();
            StorageTransferOptions options = new StorageTransferOptions
            {
                MaximumTransferLength = Constants.MB,
                MaximumConcurrency = 16
            };
            long size = new Specialized.BlockBlobClient(new Uri("")).BlockBlobMaxUploadBlobBytes + 1; // ensure that the Parallel upload code path is hit
            using var stream = new MemoryStream(GetRandomBuffer(size));

            // Act
            await blob.UploadAsync(content: stream, progressHandler: progress, transferOptions: options);

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(size, progress.List[progress.List.Count - 1]);
        }
        #endregion Upload

        [Test]
        [Explicit]
        [Ignore("The latest test runner isn't handling the [Explicit] attribute properly")]
        public async Task Perf_SmallBlobs()
        {
            // Turn off logging and diagnostics
            TestDiagnostics = false;
            BlobClientOptions options = new BlobClientOptions();
            options.Diagnostics.IsDistributedTracingEnabled = false;
            options.Diagnostics.IsLoggingEnabled = false;

            BlobServiceClient service = new BlobServiceClient(
                new Uri(TestConfigDefault.BlobServiceEndpoint),
                GetNewSharedKeyCredentials(),
                options);

            await using DisposingContainer test = await GetTestContainerAsync(service);

            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            } // Add breakpoint here to start collecting traces

            for (int trial = 0; trial < 1000; trial++)
            {
                BlobClient b = test.Container.GetBlobClient(blob.Name);
                using BlobDownloadInfo download = await b.DownloadAsync();
            }
        } // Add breakpoint here to stop collecting traces

        [Test]
        [Explicit] // This runs for a full minute and uploads a ton of data.  Don't want this on every run.
        [Ignore("The latest test runner isn't handling the [Explicit] attribute properly")]
        public async Task Upload_Stress()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            try
            {
                // Create a CancellationToken that times out after 60s
                CancellationTokenSource source = new CancellationTokenSource(TimeSpan.FromSeconds(60));
                CancellationToken token = source.Token;

                // Keep uploading a GB
                var data = GetRandomBuffer(Constants.GB);
                for (; ; )
                {
                    BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
                    using var stream = new MemoryStream(data);
                    await blob.UploadAsync(
                        stream,
                        transferOptions: new StorageTransferOptions { MaximumConcurrency = 8 },
                        cancellationToken: token);
                }
            }
            catch (OperationCanceledException)
            {
                return; // Succeeded
            }
        }

        [Test]
        [LiveOnly] // Don't want a 100MB recording
        [Explicit("#10717 - Disabled failing ChecksForCancelation live test")]
        public async Task ChecksForCancelation()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload 100MB
            var data = GetRandomBuffer(100 * Constants.MB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using var stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            await AssertDownloadAsync();
            await AssertDownloadToAsync();

            async Task AssertDownloadAsync()
            {
                // Create a CancellationToken that is already cancelled
                CancellationToken token = new CancellationToken(canceled: true);

                // Verifying Download will cancel
                await TestHelper.CatchAsync<OperationCanceledException>(
                    async () => await blob.DownloadAsync(cancellationToken: token));
            }

            async Task AssertDownloadToAsync()
            {
                // Create a CancellationToken that times out after .01s
                // Intentionally not delaying here, as DownloadToAsync operation should always cancel
                // since it buffers the full response.
                CancellationTokenSource source = new CancellationTokenSource(TimeSpan.FromSeconds(.01));
                CancellationToken token = source.Token;

                // Verifying DownloadTo will cancel
                using var downloadStream = new MemoryStream();
                await TestHelper.CatchAsync<OperationCanceledException>(
                    async () => await blob.DownloadToAsync(
                        destination: downloadStream,
                        cancellationToken: token));
            }
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
            BlobClient blobClient = new BlobClient(uri);
            BlobClient snapshotBlobClient = blobClient.WithSnapshot(snapshot);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(snapshotBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, snapshotBlobClient.AccountName);
            Assert.AreEqual(containerName, snapshotBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, snapshotBlobClient.Name);
            Assert.AreEqual(snapshotUri, snapshotBlobClient.Uri);

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
            BlobClient blobClient = new BlobClient(uri);
            BlobClient versionBlobClient = blobClient.WithVersion(versionId);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(versionBlobClient.Uri);

            // Assert
            Assert.AreEqual(accountName, versionBlobClient.AccountName);
            Assert.AreEqual(containerName, versionBlobClient.BlobContainerName);
            Assert.AreEqual(blobName, versionBlobClient.Name);
            Assert.AreEqual(versionUri, versionBlobClient.Uri);

            Assert.AreEqual(accountName, blobUriBuilder.AccountName);
            Assert.AreEqual(containerName, blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual(versionId, blobUriBuilder.VersionId);
            Assert.AreEqual(versionUri, blobUriBuilder.ToUri());
        }
    }
}
